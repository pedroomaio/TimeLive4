
Partial Class WebReport_Reports_DeleteReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BLL As New TimeLive.WebReport.ReportDesignBLL
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        BLL.DeleteAccountReport(AccountReportId)
        Response.Redirect("~/WebReport/MyReports.aspx", False)
    End Sub
End Class
