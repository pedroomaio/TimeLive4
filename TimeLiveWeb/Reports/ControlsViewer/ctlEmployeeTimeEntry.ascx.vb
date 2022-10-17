Partial Class Reports_ControlsViewer_ctlEmployeeTimeEntry
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountPartyId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Long, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Submitted As String, ByVal Billable As String)


        'Dim m As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
        'm = New AccountEmployeeTimeEntryBLL().GetDataForReport(AccountId, AccountPartyId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountProjectTaskId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Billable)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrEmployeeTimeEntryReport

        Dim ds As New dsEmployeeTimeEntryReport.vueAccountEmployeeTimeEntryDataTable
        Dim adap As New dsEmployeeTimeEntryReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
        ds = adap.GetDataForEmployeeTimeEntryReport(AccountId, AccountPartyId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountProjectTaskId, AccountLocationId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Submitted, Billable)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub
    Public Sub SetCascadingAccountId()
        Me.CascadingDropDown1.Category = DBUtilities.GetSessionAccountEmployeeId
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(56, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(56, Me.ddlProjects)
            SetCascadingAccountId()
            ReportUtilities.SetDefaultValuesOfFilerItem(Me.ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            Me.ShowReportFromFilter()


        Else
            Me.ShowReportFromFilter()
        End If

    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()
    End Sub
    Public Sub ShowReportFromFilter()
        Dim TaskId As Integer
        If ddlProjectTasks.SelectedValue <> "" Then
            TaskId = ddlProjectTasks.SelectedValue
        End If
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropdown1"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & TaskId
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlClients.SelectedValue, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, TaskId, ddlLocation.SelectedValue, chkIncludeDateRange.Checked, StartDate.SelectedDate, EndDate.SelectedDate, ddlSubmitted.SelectedValue, ddlBillable.SelectedValue)
    End Sub


End Class
