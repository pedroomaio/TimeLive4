
Partial Class Reports_ControlsViewer_ctlTaskSummaryReport
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.ShowReport(DBUtilities.GetSessionAccountId, 0, 0)
        Else
            Me.ShowReportFromFilter()
        End If
    End Sub

    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountTaskTypeId As Integer)

        'Dim m As TimeLiveDataSet.vueAccountProjectTaskForReportDataTable
        '   m = New AccountProjectTaskBLL().GetDataForTaskSummary(AccountId, AccountProjectId, AccountTaskTypeId)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrTaskSummaryReport

        Dim ds As New dsTaskSummaryReport.vueAccountEmployeeTimeEntryDataTable
        Dim adap As New dsTaskSummaryReportTableAdapters.vueAccountEmployeeTimeEntryTableAdapter
        ds = adap.GetDataForTaskSummaryReport(AccountId, AccountProjectId, AccountTaskTypeId)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()
    End Sub
    Public Sub ShowReportFromFilter()
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlProjects.SelectedValue, ddlTaskType.SelectedValue)
    End Sub
End Class
