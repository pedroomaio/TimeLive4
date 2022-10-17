
Partial Class Reports_ControlsViewer_ctlEmployeeAbsenceDetailReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date)

        'Dim m As TimeLiveDataSet.vueAccountAttendanceForEmployeeAbsenceDetailDataTable
        'm = New AccountEmployeeAttendanceBLL().GetDataForEmployeeAbsenceDetailReport(DBUtilities.GetSessionAccountId, AccountEmployeeId, IncludeDateRange, AttendanceStartDate, AttendanceEndDate)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrEmployeeAbsenceDetailReport

        Dim ds As New dsEmployeeAbsenceDetailReport.vueAccountAttendanceDataTable
        Dim adap As New dsEmployeeAbsenceDetailReportTableAdapters.vueAccountAttendanceAdapter
        ds = adap.GetDataForEmployeeAbsenceDetailReport(DBUtilities.GetSessionAccountId, AccountEmployeeId, IncludeDateRange, AttendanceStartDate, AttendanceEndDate)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(55, Me.ddlEmployees)
            ReportUtilities.SetDefaultValuesOfFilerItem(Me.ddlEmployees, Me.txtStartDate, Me.txtEndDate, Me.chkIncludeDateRange)
            ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If

    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)

        Me.txtStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtStartDate.PostedDate)
        Me.txtEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtEndDate.PostedDate)

        Me.ShowReportFromFilter()

    End Sub
    Public Sub ShowReportFromFilter()
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, chkIncludeDateRange.Checked, txtStartDate.SelectedDate, txtEndDate.SelectedDate)
    End Sub
End Class
