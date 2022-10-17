
Partial Class Reports_ControlsViewer_ctlDepartmentWiseTimesheetReport
    Inherits System.Web.UI.UserControl

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()
    End Sub

    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountPartyId As Integer, ByVal AccountLocationId As Integer, ByVal Submitted As String, ByVal Billable As String, ByVal AccountDepartmentID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)

        'Dim m As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
        '        m = New AccountEmployeeTimeEntryBLL().GetDataForUserHoursDetailReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountProjectTaskId, AccountPartyId, Billable, AccountDepartmentID, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate)

        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrDepartmentWiseTimesheetReport

        Dim ds As New dsDepartmentWiseTimesheetReportForXtrReport.vueAccountEmployeeTimeEntryDataTable
        Dim adap As New dsDepartmentWiseTimesheetReportForXtrReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
        ds = adap.GetDataByDepartmentWiseTimeSheetReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountProjectTaskId, AccountPartyId, AccountLocationId, Submitted, Billable, AccountDepartmentID, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate)


        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(110, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(110, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(ddlEmployees, Me.txtStartDate, Me.txtEndDate, Me.chkIncludeDateRange)
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
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, nAccountProjectTaskId, ddlClients.SelectedValue, ddlLocation.SelectedValue, ddlSubmitted.SelectedValue, ddlBillable.SelectedValue, ddlDepartment.SelectedValue, chkIncludeDateRange.Checked, txtStartDate.SelectedDate, txtEndDate.SelectedDate)
    End Sub

End Class
