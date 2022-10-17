Partial Class Reports_ControlsViewer_ctlClientListReport
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  If Not Me.IsPostBack Then
        Me.ShowReport(DBUtilities.GetSessionAccountId)
        '   End If

    End Sub

    Public Sub ShowReport(ByVal AccountId As Integer)

        'Dim m As TimeLiveDataSet.vueAccountPartyDataTable
        'm = New AccountPartyBLL().GetvueAccountPartiesByAccountId(AccountId)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrClentListReport
        Dim ds As New dsClientListReportForXtrReport
        Dim dt As New dsClientListReportForXtrReport.vueAccountPartyDataTable
        Dim adap As New dsClientListReportForXtrReportTableAdapters.vueAccountPartyAdapter


        dt = ds.Tables(0)
        adap.FillBy(dt, DBUtilities.GetSessionAccountId)
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

End Class
