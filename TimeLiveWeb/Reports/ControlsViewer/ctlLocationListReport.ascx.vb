'Imports dsLocationListReportForXtrReportTableAdapters
Partial Class Reports_ControlsViewer_ctlLocationListReport
    Inherits System.Web.UI.UserControl

    Public Sub ShowReport(ByVal AccountId As Integer)

        Dim Report As New xtrLocationListReport

        Dim dt As New dsLocationListReport.AccountLocationDataTable
        Dim adap As New dsLocationListReportTableAdapters.AccountLocationTableAdapter

        Dim objdsLocationListReport As New dsLocationListReport
        dt = objdsLocationListReport.Tables(0)
        adap.FillBy(dt, DBUtilities.GetSessionAccountId)

        Report.DataSource = objdsLocationListReport
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ShowReport(DBUtilities.GetSessionAccountId)
    End Sub
End Class
