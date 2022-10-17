Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports System.Configuration

<System.ComponentModel.DataObject()> _
Public Class AccountProjectTaskAttachmentBLL

    Private _AccountProjectTaskAttachmentTableAdapter As AccountProjectTaskAttachmentTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountProjectTaskAttachmentTableAdapter
        Get
            If _AccountProjectTaskAttachmentTableAdapter Is Nothing Then
                _AccountProjectTaskAttachmentTableAdapter = New AccountProjectTaskAttachmentTableAdapter()
            End If

            Return _AccountProjectTaskAttachmentTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskAttachments() As TimeLiveDataSet.AccountProjectTaskAttachmentDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskAttachmentsByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.AccountProjectTaskAttachmentDataTable

        GetAccountProjectTaskAttachmentsByAccountProjectTaskId = Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)

        If NotFixTable = False Then
            UIUtilities.FixTableForNoRecords(GetAccountProjectTaskAttachmentsByAccountProjectTaskId)
        End If

        Return GetAccountProjectTaskAttachmentsByAccountProjectTaskId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskAttachmentsByAccountProjectTaskAttachmentId(ByVal AccountProjectTaskAttachmentId As Integer) As TimeLiveDataSet.AccountProjectTaskAttachmentDataTable
        Return Adapter.GetDataByAccountProjectTaskAttachmentId(AccountProjectTaskAttachmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskAttachmentsByAccountProjectTaskAttachmentId(ByVal AccountProjectTaskAttachmentId As Long) As TimeLiveDataSet.vueAccountProjectTaskAttachmentDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskAttachmentTableAdapter
        Return vueAdapter.GetDataByAccountProjectTaskAttachmentId(AccountProjectTaskAttachmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskAttachmentsByAccountProjectTaskId(ByVal AccountProjectTaskId As Long) As TimeLiveDataSet.vueAccountProjectTaskAttachmentDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskAttachmentTableAdapter
        Return vueAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskAttachmentsEMailByAccountProjectTaskAttachmentId(ByVal AccountProjectTaskAttachmentId As Long) As TimeLiveDataSet.vueAccountProjectTaskAttachmentDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskAttachmentTableAdapter
        Return vueAdapter.GetDataByAccountProjectTaskAttachmentIdEMail(AccountProjectTaskAttachmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectTaskAttachment( _
                        ByVal AccountProjectTaskId As Integer, ByVal AttachmentName As String, ByVal AttachmentLocalPath As String _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountProjectTaskAttachmentTableAdapter = New AccountProjectTaskAttachmentTableAdapter

        Dim AccountProjectTaskAttachments As New TimeLiveDataSet.AccountProjectTaskAttachmentDataTable
        Dim AccountProjectTaskAttachment As TimeLiveDataSet.AccountProjectTaskAttachmentRow = AccountProjectTaskAttachments.NewAccountProjectTaskAttachmentRow

        With AccountProjectTaskAttachment
            .AccountProjectTaskId = AccountProjectTaskId
            .AttachmentName = AttachmentName
            .AttachmentLocalPath = AttachmentLocalPath
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        End With

        AccountProjectTaskAttachments.AddAccountProjectTaskAttachmentRow(AccountProjectTaskAttachment)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectTaskAttachments)

        AfterAddNewTaskAttachment(GetLastInsertedId)

        AfterUpdate()

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountProjectTaskAttachmentDataTable", , True)
    End Sub

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectTaskAttachment(ByVal Original_AccountProjectTaskAttachmentId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectTaskAttachmentId)


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

        Dim strAccountPath As String = AccountProjectTaskAttachmentBLL.CreateAccountFolderPath()

        Dim strTempPath As String = strAccountPath & "Temp\"
        If Not System.IO.Directory.Exists(strTempPath) Then
            System.IO.Directory.CreateDirectory(strTempPath)
        End If

        Return strTempPath

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function FileUpload(ByVal objFileUpload As FileUpload, ByVal AccountProjectTaskId As Integer, ByVal AccountId As Integer, ByVal AttachmentName As String) As Boolean


        If objFileUpload.FileName = "" Then
            Return True
        End If

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        Dim AttachmentLocalPath As String = objFileUpload.FileName

        Dim strAccountPath As String = AccountProjectTaskAttachmentBLL.CreateAccountFolderPath()

        Dim strTaskPath As String = strAccountPath & AccountProjectTaskId & "\"
        If Not System.IO.Directory.Exists(strTaskPath) Then
            System.IO.Directory.CreateDirectory(strTaskPath)
        End If
        Dim FileToSave As String = strTaskPath & objFileUpload.FileName
        objFileUpload.SaveAs(FileToSave)


        Me.AddAccountProjectTaskAttachment(AccountProjectTaskId, AttachmentName, AttachmentLocalPath)
        AfterUpdate()

    End Function
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectTaskAttachmentLastId.Rows(0)
        Return a.LastId
    End Function
    Public Sub AfterAddNewTaskAttachment(ByVal AccountProjectTaskAttachmentId As Integer)
        SendNewTaskAttachmentMail(AccountProjectTaskAttachmentId)
    End Sub
    Public Sub SendNewTaskAttachmentMail(ByVal AccountProjectTaskAttachmentId As Integer)

        SendNewTaskAttachmentMailtoAssignee(AccountProjectTaskAttachmentId)
        EMailUtilities.DequeueEmail()
    End Sub
    Public Sub SendNewTaskAttachmentMailtoAssignee(ByVal AccountProjectTaskAttachmentId As Integer)



        Dim objAccountProjectTaskAttachment As New AccountProjectTaskAttachmentBLL
        Dim dtAccountProjectTaskAttachment As TimeLiveDataSet.vueAccountProjectTaskAttachmentDataTable = objAccountProjectTaskAttachment.GetvueAccountProjectTaskAttachmentsEMailByAccountProjectTaskAttachmentId(AccountProjectTaskAttachmentId)
        Dim drAccountProjectTaskAttachment As TimeLiveDataSet.vueAccountProjectTaskAttachmentRow
        If dtAccountProjectTaskAttachment.Rows.Count > 0 Then
            drAccountProjectTaskAttachment = dtAccountProjectTaskAttachment.Rows(0)


            Dim drAccountProjectTaskEmployee As AccountEmployee.vueAccountEmployeeRow
            Dim dtAccountProjectTaskEmployee As AccountEmployee.vueAccountEmployeeDataTable
            Dim objAccountProjectTaskEmployee As New AccountEmployeeBLL
            dtAccountProjectTaskEmployee = objAccountProjectTaskEmployee.GetAccountEmployeesByAccountProjectTaskId(drAccountProjectTaskAttachment.CreatedByEmployeeId, drAccountProjectTaskAttachment.AccountProjectId, drAccountProjectTaskAttachment.AccountProjectTaskId)

            For Each drAccountProjectTaskEmployee In dtAccountProjectTaskEmployee.Rows
                EMailUtilities.SendEMail(("[" & drAccountProjectTaskAttachment.ProjectName & " : " & drAccountProjectTaskAttachment.AccountProjectTaskId & "]" & " " & "Attachment Added"), "TaskAttachmentTemplate", GetPreparedEMailMessageForNewTaskAttachment(drAccountProjectTaskAttachment), drAccountProjectTaskEmployee.EMailAddress, drAccountProjectTaskEmployee.FirstName & " " & drAccountProjectTaskEmployee.LastName, EMailUtilities.TASK_NOTIFICATION_DISPLAY_NAME)
            Next
        End If
    End Sub
    Public Function GetPreparedEMailMessageForNewTaskAttachment(ByVal drAccountProjectTaskAttachment As TimeLiveDataSet.vueAccountProjectTaskAttachmentRow) As StringDictionary

        Dim dict As New StringDictionary

        dict.Add("[projectname]", drAccountProjectTaskAttachment.ProjectName)
        dict.Add("[accountprojecttaskid]", drAccountProjectTaskAttachment.AccountProjectTaskId)
        dict.Add("[attachmentname]", drAccountProjectTaskAttachment.AttachmentName)
        dict.Add("[filename]", drAccountProjectTaskAttachment.AttachmentLocalPath)
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "Employee/AccountProjectTaskComments.aspx?AccountProjectTaskId=" & drAccountProjectTaskAttachment.AccountProjectTaskId)

        Dim drAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeRow
        Dim dtAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim objAccountProjectTaskEmployee As New AccountProjectTaskEmployeeBLL

        dtAccountProjectTaskEmployee = objAccountProjectTaskEmployee.GetAccountProjectTaskEmployeesByvueAccountProjectTaskId(drAccountProjectTaskAttachment.AccountProjectTaskId)
        Dim Assignee As String = ""

        For Each drAccountProjectTaskEmployee In dtAccountProjectTaskEmployee.Rows
            Assignee = Assignee & IIf(Assignee = "", "", ",") & (drAccountProjectTaskEmployee.FirstName & " " & drAccountProjectTaskEmployee.LastName) & (Chr(13))
        Next

        dict.Add("[assignee]", Assignee)

        'Dim drAccountEmployee As AccountEmployee.AccountEmployeeRow
        'Dim objAccountEmployee As New AccountEmployeeBLL
        'drAccountEmployee = objAccountEmployee.GetAccountEmployeesByAccountEmployeeId(drAccountProjectTaskAttachment.CreatedByEmployeeId).Rows(0)

        dict.Add("[employeename]", (drAccountProjectTaskAttachment.EmployeeName))
        Return dict

    End Function
End Class
