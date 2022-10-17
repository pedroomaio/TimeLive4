
Partial Class Employee_ExportOfflineTimesheet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ExportOfflineTimesheet(Me.Request.QueryString("TimeEntryAccountEmployeeId"), Me.Request.QueryString("WhereClause"))
    End Sub
    Public Sub ExportOfflineTimesheet(TimeEntryAccountEmployeeId As Integer, WhereClause As String)
        Dim tempfile As String
        Dim objImportExportBLL As New ImportExportBLL
        tempfile = objImportExportBLL.GetTempFileForExport("Delimited")
        objImportExportBLL.ExportCSV("Time Entry", tempfile, "Delimited", Now, Now, TimeEntryAccountEmployeeId, -1, WhereClause, True)
        Dim downloadFile As String = objImportExportBLL.GetDownloadLink(tempfile)
        Dim i As String = LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & downloadFile)
        Response.Redirect("~/Shared/FileDownload.aspx?" & i, False)
        'btnExportOfflineTimesheet.Attributes("onclick") = "window.location='../Shared/FileDownload.aspx?" & i & "'"
    End Sub
End Class
