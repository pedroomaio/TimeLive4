
Partial Class Reports_ControlsViewer_ctlAccountEmployeeTimesheetSubmissionStatusReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountID As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountDepartmentID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)
        Dim Report As New xtrEmployeeTimesheetSubmissionStatusReport

        Dim ds As New dsEmployeeTimesheetSubmissionStatusReport.vueAccountEmployeeTimesheetSubmissionStatusDataTable
        Dim adap As New dsEmployeeTimesheetSubmissionStatusReportTableAdapters.vueAccountEmployeeTimesheetSubmissionStatusTableAdapter
        ds = adap.GetDataForEmployeeTimesheetSubmissionStatusReport(AccountID, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), ddlDepartment.SelectedValue, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Me.ddlEmployees)
        Report.DataAdapter = adap
        Report.DataSource = ds
        Report.DataMember = "vueAccountEmployeeTimesheetSubmissionStatus"
        Report.DetailPrintCount = 0
        Me.ReportViewer1.Report = Report
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
            AccountEmployeeBLL.SetDataForEmployeeDropdownForCustomaizeReport(Me.ddlEmployees, AccountReportId)
            ' AccountProjectBLL.SetDataForProjectDropdown(53, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)


            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If

        'If Not Me.IsPostBack Then
        '   End If
    End Sub

    Public Sub ShowReportFromFilter()
        '' Dim nAccountProjectTaskId As Long
        ''If ddlProjectTasks.SelectedValue = "" Then
        ''    nAccountProjectTaskId = 0
        ''Else
        ''    nAccountProjectTaskId = ddlProjectTasks.SelectedValue
        ''End If
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlDepartment.SelectedValue, chkIncludeDateRange.Checked, StartDate.SelectedDate, EndDate.SelectedDate)

    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)

        Me.ShowReportFromFilter()
    End Sub
End Class
