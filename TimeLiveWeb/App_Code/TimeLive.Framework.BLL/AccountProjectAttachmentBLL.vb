Imports Microsoft.VisualBasic
Imports AccountProjectTableAdapters
Imports System.Configuration

<System.ComponentModel.DataObject()> _
Public Class AccountProjectAttachmentBLL
    Private _AccountProjectAttachmentTableAdapter As AccountProjectAttachmentTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountProjectAttachmentTableAdapter
        Get
            If _AccountProjectAttachmentTableAdapter Is Nothing Then
                _AccountProjectAttachmentTableAdapter = New AccountProjectAttachmentTableAdapter()
            End If

            Return _AccountProjectAttachmentTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectAttachments() As AccountProject.AccountProjectAttachmentDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectAttachmentsByAccountProjectId(ByVal AccountProjectId As Integer, Optional ByVal NotFixTable As Boolean = False) As AccountProject.AccountProjectAttachmentDataTable

        GetAccountProjectAttachmentsByAccountProjectId = Adapter.GetDataByAccountProjectId(AccountProjectId)

        If NotFixTable = False Then
            UIUtilities.FixTableForNoRecords(GetAccountProjectAttachmentsByAccountProjectId)
        End If

        Return GetAccountProjectAttachmentsByAccountProjectId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectAttachment( _
                        ByVal AccountProjectId As Integer, ByVal AttachmentName As String, ByVal AttachmentLocalPath As String _
                    ) As Boolean
        ' Create a new ProductRow instance

        Dim AccountProjectAttachmentId As Guid = System.Guid.NewGuid
        _AccountProjectAttachmentTableAdapter = New AccountProjectAttachmentTableAdapter
        Dim AccountProjectAttachments As New AccountProject.AccountProjectAttachmentDataTable
        Dim AccountProjectAttachment As AccountProject.AccountProjectAttachmentRow = AccountProjectAttachments.NewAccountProjectAttachmentRow

        With AccountProjectAttachment
            .AccountProjectAttachmentId = AccountProjectAttachmentId
            .AccountProjectId = AccountProjectId
            .AttachmentName = AttachmentName
            .AttachmentLocalPath = AttachmentLocalPath
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        End With

        AccountProjectAttachments.AddAccountProjectAttachmentRow(AccountProjectAttachment)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectAttachments)

        'AfterAddNewTaskAttachment(GetLastInsertedId)

        AfterUpdate()
        System.Web.HttpContext.Current.Session.Add("AccountProjectAttachmentId", AccountProjectAttachmentId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountProjectAttachmentDataTable", , True)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectAttachment(ByVal Original_AccountProjectAttachmentId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectAttachmentId)

        AfterUpdate()

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Shared Function CreateAccountFolderPath() As String
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        If Not System.IO.Directory.Exists(strRoot) Then
            System.IO.Directory.CreateDirectory(strRoot)
        End If
        Dim strAccountPath As String = strRoot & DBUtilities.GetSessionAccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            System.IO.Directory.CreateDirectory(strAccountPath)
        End If
        Return strAccountPath

    End Function
    Public Shared Function CreateTempFolderPath() As String

        Dim strAccountPath As String = AccountProjectAttachmentBLL.CreateAccountFolderPath()

        Dim strTempPath As String = strAccountPath & "Temp\"
        If Not System.IO.Directory.Exists(strTempPath) Then
            System.IO.Directory.CreateDirectory(strTempPath)
        End If

        Return strTempPath

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function FileUpload(ByVal objFileUpload As FileUpload, ByVal AccountProjectId As Integer, ByVal AccountId As Integer, ByVal AttachmentName As String) As Boolean


        If objFileUpload.FileName = "" Then
            Return True
        End If

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        Dim AttachmentLocalPath As String = objFileUpload.FileName

        Dim strAccountPath As String = AccountProjectTaskAttachmentBLL.CreateAccountFolderPath()

        Dim strTaskPath As String = strAccountPath & AccountProjectId & "\"
        If Not System.IO.Directory.Exists(strTaskPath) Then
            System.IO.Directory.CreateDirectory(strTaskPath)
        End If
        Dim FileToSave As String = strTaskPath & objFileUpload.FileName
        objFileUpload.SaveAs(FileToSave)


        Me.AddAccountProjectAttachment(AccountProjectId, AttachmentName, AttachmentLocalPath)
        AfterUpdate()

    End Function
    Public Function GetLastInsertedId() As Guid
        'Dim a As TimeLiveDataSet.IdentityQueryRow
        'Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        'a = ad.GetAccountTimeExpenseBillingLastId.Rows(0)
        'Return a.LastId
        Return System.Web.HttpContext.Current.Session("AccountProjectAttachmentId")
    End Function
End Class
