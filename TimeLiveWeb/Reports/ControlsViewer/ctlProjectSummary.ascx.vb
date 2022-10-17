Imports DevExpress.XtraReports.UI


Partial Class Reports_ControlsViewer_ctlProjectSummaryReport


    Inherits System.Web.UI.UserControl

    '    Public Sub ShowReport(ByVal AccountID As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectID As Integer, ByVal AccountClientID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)
    Public Sub ShowReport(ByVal AccountID As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectID As Integer, ByVal AccountClientID As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)


        Dim report As New repProjectSummary
        Dim f As New TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable
        Dim adap As New TimeLiveDataSetTableAdapters.vueAccountProjectForProjectSummaryTableAdapter
        f = adap.GetProjectsByAccountID(AccountID, AccountProjectID)
        report.DataAdapter = adap
        report.DataSource = f
        report.DataMember = "vueAccountProjectForProjectSummary"
        report.DetailPrintCount = 0        

        Dim R3 As New repProjectSummaryTimeEntries
        Dim m3 As New TimeLiveDataSet.vueProjectSummaryDataTable
        Dim m3adap As New TimeLiveDataSetTableAdapters.vueProjectSummaryTableAdapter
        m3 = m3adap.GetDataAll(AccountID, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectID, AccountClientID, TimeEntryStartDate, TimeEntryEndDate)
        R3.DataAdapter = m3adap
        R3.DataSource = m3
        R3.xrPivotGrid1.DataSource = m3
        R3.DataMember = "vueProjectSummary"
        R3.DetailPrintCount = 0
        report.xrSubreport3.ReportSource = R3

        Dim R2 As New XtraReport1
        Dim m2 As New TimeLiveDataSet.vueProjectSummaryDataTable
        Dim m2adap As New TimeLiveDataSetTableAdapters.vueProjectSummaryTableAdapter
        m2 = m2adap.GetDataAll(AccountID, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectID, AccountClientID, TimeEntryStartDate, TimeEntryEndDate)
        R2.DataAdapter = m2adap
        R2.DataSource = m2
        R2.DataMember = "vueProjectSummary"
        R2.DetailPrintCount = 0
        report.xrSubreport2.ReportSource = R2

        Dim R1 As New repProjectSummaryExpenseReport
        Dim m1 As New TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        Dim m1adap As New TimeLiveDataSetTableAdapters.vueAccountExpenseEntryForDetailExpenseReportTableAdapter
        m1 = m1adap.GetDataByAccountIdAndEmployeesForProjectSummaryReport(AccountID, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectID, AccountClientID, TimeEntryStartDate, TimeEntryEndDate, 1, -1)
        R1.DataAdapter = m1adap
        R1.DataSource = m1
        R1.DataMember = "vueAccountExpenseEntryForDetailExpenseReport"
        R1.DetailPrintCount = 0
        report.xrSubreport1.ReportSource = R1
        report.FillDataSource()
        Me.ReportViewer1.Report = report
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
            AccountEmployeeBLL.SetDataForEmployeeDropdownForCustomaizeReport(Me.ddlEmployees, AccountReportId)
            AccountProjectBLL.SetDataForProjectDropdownForCustomaizeReport(Me.ddlProjects, AccountReportId, 0)
            '            ReportUtilities.SetDefaultValuesOfFilerItem(ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            ReportUtilities.SetDefaultValuesOfFilerItemForProjectSummaryReport(ddlEmployees, Me.StartDate, Me.EndDate)


            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If

        'If Not Me.IsPostBack Then
        '   End If
    End Sub

    Public Sub ShowReportFromFilter()
        Dim nAccountProjectTaskId As Long
        ''If ddlProjectTasks.SelectedValue = "" Then
        ''    nAccountProjectTaskId = 0
        ''Else
        ''    nAccountProjectTaskId = ddlProjectTasks.SelectedValue
        ''End If
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        '        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, 0, chkIncludeDateRange.Checked, StartDate.SelectedDate, EndDate.SelectedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, 0, StartDate.SelectedDate, EndDate.SelectedDate)

    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '    If ddlProjects.SelectedValue = 0 Then
        ' Exit Sub
        ' End If

        Me.ViewState.Add("IsFromFilter", True)

        Me.ShowReportFromFilter()
    End Sub
End Class
