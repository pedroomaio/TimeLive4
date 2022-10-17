
Partial Class Reports_ControlsViewer_ctlAttendanceDetailReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date)


        'Dim m As TimeLiveDataSet.vueAccountAttendanceForAttendanceDetailDataTable
        'm = New AccountEmployeeAttendanceBLL().GetDataForAttendanceDetailReport(DBUtilities.GetSessionAccountId, AccountEmployeeId, AttendanceStartDate, AttendanceEndDate)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrAttendanceDetailReport

        Dim ds As New dsAttendanceDetailReport.vueAccountAttendanceDataTable
        Dim adap As New dsAttendanceDetailReportTableAdapters.vueAccountAttendanceTableAdapter
        ds = adap.GetDataForAttendanceDetailReport(AttendanceStartDate, AttendanceEndDate, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), DBUtilities.GetSessionAccountId)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(52, Me.ddlEmployees)
            ReportUtilities.SetDefaultValuesOfFilerItemForAttendanceReport(ddlEmployees, Me.txtStartDate, Me.txtEndDate)
            Me.ShowReport(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, Now.Date, Now.Date)
            '            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If


    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()
    End Sub
    Public Sub ShowReportFromFilter()
        Me.txtStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtStartDate.PostedDate)
        Me.txtEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtEndDate.PostedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, txtStartDate.SelectedDate, txtEndDate.SelectedDate)
    End Sub
End Class