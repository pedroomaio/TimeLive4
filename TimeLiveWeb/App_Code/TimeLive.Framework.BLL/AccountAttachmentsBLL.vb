Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports System.Configuration
Imports System.IO.file

<System.ComponentModel.DataObject()> _
Public Class AccountAttachmentsBLL

    Private _AccountAttachmentsTableAdapter As AccountAttachmentsTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountAttachmentsTableAdapter
        Get
            If _AccountAttachmentsTableAdapter Is Nothing Then
                _AccountAttachmentsTableAdapter = New AccountAttachmentsTableAdapter()
            End If

            Return _AccountAttachmentsTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAttachments() As TimeLiveDataSet.AccountAttachmentsDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAttachmentsByAccountAttachmentId(ByVal AccountAttachmentId As Integer) As TimeLiveDataSet.AccountAttachmentsDataTable
        Return Adapter.GetDataByAccountAttachmentId(AccountAttachmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountAttachmentsByAccountExpenseEntryId(ByVal AccountExpenseEntryId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.AccountAttachmentsDataTable
        If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            GetAccountAttachmentsByAccountExpenseEntryId = Adapter.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
        Else
            GetAccountAttachmentsByAccountExpenseEntryId = Adapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        End If
        If NotFixTable = False Then
            UIUtilities.FixTableForNoRecords(GetAccountAttachmentsByAccountExpenseEntryId)
        End If
        Return GetAccountAttachmentsByAccountExpenseEntryId
    End Function

    Public Function GetAttachmentsCountByExpenseEntryId(ByVal AccountExpenseEntryId As Integer) As Integer
        Return Adapter.GetAttachementsCountByExpenseEntryId(AccountExpenseEntryId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCountAccountExpenseEntryId(ByVal AccountExpenseEntryId As Integer) As TimeLiveDataSet.CountAccountExpenseEntryIdDataTable
        Dim _CountAccountExpenseEntryId As New CountAccountExpenseEntryIdTableAdapter
        GetCountAccountExpenseEntryId = _CountAccountExpenseEntryId.GetData(AccountExpenseEntryId)
        Return GetCountAccountExpenseEntryId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountAttachments( _
                       ByVal AccountAttachmentTypeId As Integer, ByVal AccountExpenseEntryId As Integer, ByVal AttachmentName As String, ByVal AttachmentLocalPath As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                   Optional ByVal CreatedByEmployeeId As Integer = 0, Optional ByVal ModifiedByEmployeeId As Integer = 0) As Boolean
        ' Create a new ProductRow instance


        _AccountAttachmentsTableAdapter = New AccountAttachmentsTableAdapter

        Dim AccountAttachments As New TimeLiveDataSet.AccountAttachmentsDataTable
        Dim AccountAttachment As TimeLiveDataSet.AccountAttachmentsRow = AccountAttachments.NewAccountAttachmentsRow

        With AccountAttachment
            .AccountAttachmentTypeId = AccountAttachmentTypeId
            .AccountExpenseEntryId = AccountExpenseEntryId
            .AttachmentName = AttachmentName
            .AttachmentLocalPath = AttachmentLocalPath
            .CreatedOn = Now
            If CreatedByEmployeeId <> 0 Then
                .CreatedByEmployeeId = CreatedByEmployeeId
            Else
                .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            End If
            .ModifiedOn = Now
            If ModifiedByEmployeeId <> 0 Then
                .ModifiedByEmployeeId = ModifiedByEmployeeId
            Else
                .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            End If

            .AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
        End With

        AccountAttachments.AddAccountAttachmentsRow(AccountAttachment)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountAttachments)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountAttachments(ByVal Original_AccountAttachmentId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountAttachmentId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function FileUpload(ByVal objFileUpload As FileUpload, ByVal AccountAttachmentTypeId As Integer, ByVal AccountExpenseEntryId As Integer, ByVal AccountId As Integer, ByVal AttachmentName As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid) As Boolean
        If objFileUpload.FileName = "" Then
            Return True
        End If
        Dim strAccountAttachmentsPath As String
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        Dim AttachmentLocalPath As String = objFileUpload.FileName
        If Not System.IO.Directory.Exists(strRoot) Then
            System.IO.Directory.CreateDirectory(strRoot)
        End If
        Dim strAccountPath As String = strRoot & AccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            System.IO.Directory.CreateDirectory(strAccountPath)
        End If
        If AccountAttachmentTypeId = 2 Then
            strAccountAttachmentsPath = strAccountPath & AccountEmployeeTimeEntryPeriodId.ToString & "\"
        Else
            strAccountAttachmentsPath = strAccountPath & AccountExpenseEntryId & "\"
        End If
        If Not System.IO.Directory.Exists(strAccountAttachmentsPath) Then
            System.IO.Directory.CreateDirectory(strAccountAttachmentsPath)
        End If
        Dim FileToSave As String = strAccountAttachmentsPath & objFileUpload.FileName
        objFileUpload.SaveAs(FileToSave)
        If AccountAttachmentTypeId = 1 Then
            Me.AddAccountAttachments(AccountAttachmentTypeId, AccountExpenseEntryId, AttachmentName, AttachmentLocalPath, System.Guid.Empty)
        Else
            Me.AddAccountAttachments(AccountAttachmentTypeId, AccountExpenseEntryId, AttachmentName, AttachmentLocalPath, AccountEmployeeTimeEntryPeriodId)
        End If
    End Function

    Public Sub InsertAccountAttachmentsByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.InsertAccountAttachmentByExpenseSheetId(AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
        GetAndCopyAttachmentsByExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub GetAndCopyAttachmentsByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid)
        Dim dt As TimeLiveDataSet.AccountAttachmentsDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As TimeLiveDataSet.AccountAttachmentsRow
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                Dim SourceFileName As String = GetFileByAccountExpenseEntryId(dr.AttachmentLocalPath, dr.Item("OldAccountExpenseEntryId"), dr.Item("AccountId"))
                Dim DestinationFileName As String = GetFileByAccountExpenseEntryId(dr.AttachmentLocalPath, dr.AccountExpenseEntryId, dr.Item("AccountId"))
                If Exists(SourceFileName) Then
                    Copy(SourceFileName, DestinationFileName)
                End If
            Next
        End If
    End Sub
    Public Function GetFileByAccountExpenseEntryId(ByVal FileName As String, ByVal AccountExpenseEntryId As Integer, ByVal AccountId As Integer) As String
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        Dim AttachmentLocalPath As String = FileName
        If Not System.IO.Directory.Exists(strRoot) Then
            System.IO.Directory.CreateDirectory(strRoot)
        End If
        Dim strAccountPath As String = strRoot & AccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            System.IO.Directory.CreateDirectory(strAccountPath)
        End If
        Dim strAccountAttachmentsPath As String = strAccountPath & AccountExpenseEntryId & IIf(FileName = "", "", "\")
        If Not System.IO.Directory.Exists(strAccountAttachmentsPath) Then
            System.IO.Directory.CreateDirectory(strAccountAttachmentsPath)
        End If
        Return strAccountAttachmentsPath & FileName
    End Function
    Public Sub DeleteAccountAttachmentsFileByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid)
        Dim dt As TimeLiveDataSet.AccountAttachmentsDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As TimeLiveDataSet.AccountAttachmentsRow
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                Dim strPath As String = GetFileByAccountExpenseEntryId("", dr.AccountExpenseEntryId, dr.Item("AccountId"))
                If System.IO.Directory.Exists(strPath) Then
                    System.IO.Directory.Delete(strPath, True)
                End If
            Next
        End If
    End Sub
End Class
