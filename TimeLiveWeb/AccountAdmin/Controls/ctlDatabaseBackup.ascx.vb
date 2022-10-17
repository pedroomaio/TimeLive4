
Partial Class AccountAdmin_Controls_ctlDatabaseBackup
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' Start backup, restore, delete and create download link succesfully.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnbackupdatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbackupdatabase.Click
        LoggingBLL.WriteToLog("Starting database backup" & " " & " ")
        'DBUtilities.BackupDatabase(GetTempFolder)
        LoggingBLL.WriteToLog("database backup ended" & " " & " ")

        LoggingBLL.WriteToLog("Restoring database from backup" & " " & " ")
        'DBUtilities.CreateDatabaseFromBackupAndRestore(GetTempFolder)
        LoggingBLL.WriteToLog("Database restored successfully" & " " & " ")

        LoggingBLL.WriteToLog("Deleting database backup file" & " " & " ")
        'DBUtilities.DeleteBackupFile(GetTempFolder)
        LoggingBLL.WriteToLog("Database backup file deleted successfully" & " " & " ")

        LoggingBLL.WriteToLog("Start delete data from database" & " " & " ")
        'DBUtilities.DeleteAllDataFromAnotherAccount()
        LoggingBLL.WriteToLog("Succesfully delete data from database" & " " & " ")

        LoggingBLL.WriteToLog("Starting database backup user account" & " " & " ")
        'DBUtilities.BackupDatabaseUserAccount(GetTempFolder)
        LoggingBLL.WriteToLog("Succesfully database backup user account" & " " & " ")

        LoggingBLL.WriteToLog("Delete database user account" & " " & " ")
        'DBUtilities.DeleteDatabaseUserAccount(GetTempFolder)
        LoggingBLL.WriteToLog("Succesfully Delete database user account" & " " & " ")

        LoggingBLL.WriteToLog("Create Download Link" & " " & " ")
        Dim IEBll As New ImportExportBLL
        Dim tempfile As String
        tempfile = IEBll.GetTempFileForDatabaseBackup
        Dim spbll As New StoreProcedureBLL
        Dim dstfile As String = GetTempFolder() & DBUtilities.GetSessionAccountId & ".zip"
        spbll.CreateZipFileDatabaseBackup(tempfile, dstfile, 1)
        Dim downloadFile As String = IEBll.GetDownloadLink(dstfile)
        Response.Redirect("~/Shared/FileDownload.aspx?FileName=" & downloadFile, False)
        LoggingBLL.WriteToLog("Create Download Link Succesfully" & " " & " ")
    End Sub
    ''' <summary>
    ''' Get temp folder path
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTempFolder() As String
        Dim TempFolderPath As String = AccountProjectTaskAttachmentBLL.CreateTempFolderPath()
        Return TempFolderPath
    End Function
    ''' <summary>
    ''' Set page permission 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnbackupdatabase.Enabled = AccountPagePermissionBLL.IspageHasRights(151)
    End Sub
End Class
