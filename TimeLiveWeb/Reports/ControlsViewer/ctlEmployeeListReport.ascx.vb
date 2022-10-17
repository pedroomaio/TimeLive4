
Partial Class Reports_ControlsViewer_ctlEmployeeListReport
    Inherits System.Web.UI.UserControl
    Dim AccountLocationId As Integer
    Dim AccountDepartmentId As Integer
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountLocationId As Integer, ByVal AccountDepartmentId As Integer, ByVal AccountRoleId As Integer)

        'Dim m As AccountEmployee.vueAccountEmployeeDataTable
        '  m = New AccountEmployeeBLL().GetAccountEmployeesByLocationAndDepartment(DBUtilities.GetSessionAccountId, AccountLocationId, AccountDepartmentId)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        'Dim Report As New xtrEmployeeListReport
        'Dim ds As New dsEmployeeListReportForXtrReport
        'Dim dt As New dsEmployeeListReportForXtrReport.vueAccountEmployeeDetailForReportDataTableDataTable
        'Dim adap As New dsEmployeeListReportForXtrReportTableAdapters.vueAccountEmployeeDetailForReportTableAdapter


        'dt = ds.Tables(0)
        'adap.FillBy(dt, DBUtilities.GetSessionAccountId, AccountLocationId, AccountDepartmentId)
        'Report.DataSource = ds
        'Me.ReportViewer1.Report = Report
        'Me.ReportViewer1.DataBind()

        Dim Report As New xtrEmployeeListReport

        Dim ds As New dsEmployeeListReport.vueAccountEmployeeDataTable
        Dim adap As New dsEmployeeListReportTableAdapters.vueAccountEmployeeTableAdapter
        ds = adap.GetDataByAccountIdLocationIdDepartmentId(DBUtilities.GetSessionAccountId, AccountLocationId, AccountDepartmentId, AccountRoleId)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.ShowReport(DBUtilities.GetSessionAccountId, 0, 0, 0)
        Else
            FltEmployeeListReport1_FilterClick(CType(Me.FltEmployeeListReport1.FindControl("ddlLocation"), DropDownList).SelectedValue, CType(Me.FltEmployeeListReport1.FindControl("ddlDepartment"), DropDownList).SelectedValue, CType(Me.FltEmployeeListReport1.FindControl("ddlRole"), DropDownList).SelectedValue)
        End If
    End Sub

    Protected Sub FltEmployeeListReport1_FilterClick(ByVal AccountLocationId As Integer, ByVal AccountDepartmentId As Integer, ByVal AccountRoleId As Integer) Handles FltEmployeeListReport1.FilterClick
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReport(DBUtilities.GetSessionAccountId, CType(Me.FltEmployeeListReport1.FindControl("ddlLocation"), DropDownList).SelectedValue, CType(Me.FltEmployeeListReport1.FindControl("ddlDepartment"), DropDownList).SelectedValue, CType(Me.FltEmployeeListReport1.FindControl("ddlRole"), DropDownList).SelectedValue)
    End Sub
End Class
