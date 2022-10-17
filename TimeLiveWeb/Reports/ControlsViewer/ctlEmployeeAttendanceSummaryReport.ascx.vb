
Partial Class Reports_ControlsViewer_ctlEmployeeAttendanceSummaryReport
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(59, Me.ddlEmployees)
            ReportUtilities.SetDefaultValuesOfFilerItemForAttendanceReport(ddlEmployees, Me.txtStartDate, Me.txtEndDate)
            Me.ShowReport(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, Now.Date, Now.Date)
        Else
            Me.ShowReportFromFilter()
        End If

    End Sub

    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date)

        'Dim m As TimeLiveDataSet.vueAccountAttendanceForEmployeeAttendanceDataTable
        'm = New AccountEmployeeAttendanceBLL().GetDataForEmployeeAttendanceReport(DBUtilities.GetSessionAccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AttendanceStartDate, AttendanceEndDate)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrEmployeeAttendanceSummaryReport

        Dim ds As New dsEmployeeAttendanceSummaryReport.vueAccountAttendanceDataTable
        Dim adap As New dsEmployeeAttendanceSummaryReportTableAdapters.vueAccountAttendanceTableAdapter
        ds = adap.GetDataForEmployeeAttendanceSummaryReport(DBUtilities.GetSessionAccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AttendanceStartDate, AttendanceEndDate)


        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtStartDate.PostedDate)
        Me.txtEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtEndDate.PostedDate)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()
    End Sub
    Public Sub ShowReportFromFilter()
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, txtStartDate.SelectedDate, txtEndDate.SelectedDate)
    End Sub
End Class
