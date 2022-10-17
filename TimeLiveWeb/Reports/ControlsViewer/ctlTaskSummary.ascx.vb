
Partial Class Reports_ControlsViewer_ctlTaskSummary
    Inherits System.Web.UI.UserControl

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()
    End Sub

    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountPartyId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Approval As String, ByVal Submitted As String, ByVal Billable As String)

        'Dim m As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
        '  m = New AccountEmployeeTimeEntryBLL().GetDataForTaskSummarReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountPartyId, AccountProjectId, AccountProjectTaskId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable)

        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrTaskSummary

        Dim ds As New dsTaskSummary.vueAccountEmployeeTimeEntryDataTable
        Dim adap As New dsTaskSummaryTableAdapters.vueAccountEmployeeTimeEntryTableAdapter
        ds = adap.GetDataByTaskSummary(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountPartyId, AccountProjectId, AccountProjectTaskId, AccountLocationId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Submitted, Billable)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(111, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(111, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(Me.ddlEmployees, Me.txtStartDate, Me.txtEndDate, Me.chkIncludeDateRange)
            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If
    End Sub

    Public Sub ShowReportFromFilter()
        Dim nAccountProjectTaskId As Long
        If ddlProjectTasks.SelectedValue = "" Then
            nAccountProjectTaskId = 0
        Else
            nAccountProjectTaskId = ddlProjectTasks.SelectedValue
        End If
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropdown1"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & nAccountProjectTaskId
        Me.txtStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtStartDate.PostedDate)
        Me.txtEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtEndDate.PostedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlClients.SelectedValue, ddlProjects.SelectedValue, nAccountProjectTaskId, ddlLocation.SelectedValue, chkIncludeDateRange.Checked, txtStartDate.SelectedDate, txtEndDate.SelectedDate, ddlApproved.SelectedValue, ddlSubmitted.SelectedValue, ddlBillable.SelectedValue)
    End Sub
End Class
