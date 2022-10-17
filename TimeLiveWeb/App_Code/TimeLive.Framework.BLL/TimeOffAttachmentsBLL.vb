Imports Microsoft.VisualBasic
Imports TimeOffAttachments
Imports TimeOffAttachmentsTableAdapters

<System.ComponentModel.DataObject()>
Public Class TimeOffAttachmentsBLL
    Private _AccountAttachmentsTableAdapter As TimeOffAttachmentsTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As TimeOffAttachmentsTableAdapter
        Get
            If _AccountAttachmentsTableAdapter Is Nothing Then
                _AccountAttachmentsTableAdapter = New TimeOffAttachmentsTableAdapter()
            End If

            Return _AccountAttachmentsTableAdapter
        End Get
    End Property
    Public Function FileUpload(ByVal objFileUpload As FileUpload, ByVal AttachmentName As String, ByVal TimeEntryId As Integer) As Boolean
        If objFileUpload.FileName = "" Then
            Return True
        End If

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        Dim AttachmentLocalPath As String = objFileUpload.FileName

        CreateDir(strRoot)

        Dim strAccountPath As String = strRoot & DBUtilities.GetSessionAccountId & "\"
        CreateDir(strAccountPath)

        Dim strTimeOffPath As String = strAccountPath & "TimeOffAttachments\"
        CreateDir(strTimeOffPath)

        Dim strTimeEntryPath As String = strTimeOffPath & TimeEntryId & "\"
        CreateDir(strTimeEntryPath)

        Dim FileToSave As String = strTimeEntryPath & objFileUpload.FileName
        objFileUpload.SaveAs(FileToSave)

        Me.AddTimeOffAttachments(AttachmentName, AttachmentLocalPath, TimeEntryId)

    End Function


    Private Function AddTimeOffAttachments(ByVal AttachmentName As String, ByVal AttachmentLocalPath As String, ByVal TimeEntryId As Integer) As Boolean
        _AccountAttachmentsTableAdapter = New TimeOffAttachmentsTableAdapter

        Dim AccountAttachments As New TimeOffAttachmentsDataTable
        Dim AccountAttachment As TimeOffAttachmentsRow = AccountAttachments.NewTimeOffAttachmentsRow

        With AccountAttachment

            .AttachmentName = AttachmentName
            .TimeEntryId = TimeEntryId
            .AttachmentLocalPath = AttachmentLocalPath
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId

        End With

        AccountAttachments.AddTimeOffAttachmentsRow(AccountAttachment)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountAttachments)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetTimeOffAttachmentsByTimeEntryId(ByVal TimeEntryId As Integer) As TimeOffAttachmentsDataTable
        Return Adapter.GetTimeOffAttachmentsByTimeEntryId(TimeEntryId)
    End Function


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)>
    Public Function DeleteTimeOffAttachments(ByVal Original_AccountAttachmentId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountAttachmentId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub DeleteTimeOffAttachmentsFiles(ByVal TimeEntryId As Integer)

        Dim strFileName = ""
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)

        Dim TimeOffAttachments = Me.GetTimeOffAttachmentsByTimeEntryId(TimeEntryId)
        Dim row As TimeOffAttachmentsRow
        For Each row In TimeOffAttachments

            strFileName = strRoot & DBUtilities.GetSessionAccountId & "\TimeOffAttachments\" & TimeEntryId & "\" & row.AttachmentLocalPath

            If System.IO.File.Exists(strFileName) Then
                Try
                    System.IO.File.Delete(strFileName)

                    Dim pathToDir = strRoot & DBUtilities.GetSessionAccountId & "\TimeOffAttachments\" & TimeEntryId
                    Dim myDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(pathToDir)
                    If Not myDir.EnumerateFiles().Any() Then
                        System.IO.Directory.Delete(pathToDir)
                    End If

                Catch ex As Exception

                End Try
            End If
        Next


    End Sub
    Public Function CountAttachmentsByProjectIdAndTimeOffTypeAndPeriodId(ByVal ProjectId As Integer, ByVal TimeOffType As Guid, ByVal StartDate As DateTime, ByVal AccountEmployeeId As Integer) As Integer
        Dim BLL = New AccountEmployeeTimeEntryBLL
        Dim Period = BLL.GetTimeEntryPeriodByAccountEmployeeIdAndStartDate(AccountEmployeeId, StartDate)
        If Period <> Guid.Empty Then
            Return Adapter.GetAttachmentsCountByProjectIdAndTimeOffTypeAndPeriodId(ProjectId, TimeOffType, Period)
        End If
        Return 0
    End Function
    Public Function CountAttachmentsByTimeEntryId(ByVal TimeEntryId As Integer) As Integer
        Return Adapter.CountTimeOffAttachmentsByTimeEntryId(TimeEntryId)
    End Function
    Public Function CountAttachmentsByTimeOffRequestId(ByVal AccountEmployeeTimeOffRequest As Guid) As Integer
        Return Adapter.CountAttachmentsByTimeOffRequestId(AccountEmployeeTimeOffRequest)
    End Function

    Public Function GetTimeOffAttachmentsByProjectIdAndTimeOffTypeAndAccountEmployeeIdAndDate(ByVal AccountProjectId As Integer, ByVal AccountTimeOffType As Guid, ByVal StartDate As DateTime, ByVal AccountEmployeeId As Integer) As TimeOffAttachmentsDataTable
        Dim BLL = New AccountEmployeeTimeEntryBLL
        Dim Period = BLL.GetTimeEntryPeriodByAccountEmployeeIdAndStartDate(AccountEmployeeId, StartDate)
        If Period <> Guid.Empty Then
            Return Adapter.GetTimeOffAttachmentsByProjectIdAndTimeOffTypeAndPeriodId(AccountProjectId, AccountTimeOffType, Period)
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetTimeOffAttachmentsByTimeOffRequest(ByVal TimeOffRequestId As Guid) As TimeOffAttachmentsDataTable
        Return Adapter.GetTimeOffAttachmentsByTimeOffRequestId(TimeOffRequestId)
    End Function
    Private Sub CreateDir(ByVal path As String)
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
    End Sub
End Class
