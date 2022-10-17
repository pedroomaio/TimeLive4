Imports dsDetailTimeSheetReportForXtrReportTableAdapters
Partial Class Reports_ControlsViewer_ctlDetailTimeSheetReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountDepartmentId As Integer, ByVal AccountProjectTaskId As Long, ByVal AccountPartyId As Integer, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Approval As String, ByVal Submitted As String, ByVal Billable As String)
        ''Dim docReport As New C1.Web.C1WebReport.C1WebReport
        ''docReport.ReportSource.FileName = (Server.MapPath("ReportFiles\rptDepartmentListReport.xml"))


        '        Dim m As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
        '       m = New AccountEmployeeTimeEntryBLL().GetDataForDetailTimeSheetReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountProjectTaskId, AccountPartyId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable)
        ''Dim dv As New DataView(m)

        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrDetailTimeSheetReport

        Dim ds As New dsDetailTimeSheetReport.vueAccountEmployeeTimeEntryDataTable
        Dim adap As New dsDetailTimeSheetReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
        ds = adap.GetDataByAccountIdAndEmployees(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountDepartmentId, AccountProjectTaskId, AccountPartyId, AccountLocationId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Submitted, Billable)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()

        ''Me.C1WebReport1.Report.RenderToFile("C:\xlsfile.xls", C1.Win.C1Report.FileFormatEnum.Excel)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(53, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(53, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If
        Literal8.Text = ResourceHelper.GetFromResource("Location:")
        'If Not Me.IsPostBack Then
        '   End If
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
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, ddlDepartment.SelectedValue, nAccountProjectTaskId, ddlClients.SelectedValue, ddlLocation.SelectedValue, chkIncludeDateRange.Checked, StartDate.SelectedDate, EndDate.SelectedDate, ddlApproved.SelectedValue, ddlSubmitted.SelectedValue, ddlBillable.SelectedValue)

    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)

        Me.ShowReportFromFilter()
    End Sub
End Class
