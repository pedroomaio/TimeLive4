
Partial Class Reports_ControlsViewer_ctlProjectListReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal IsActive As Integer, ByVal ProjectStatusId As Integer)


        'Dim m As TimeLiveDataSet.vueAccountProjectsDataTable
        'm = New AccountProjectBLL().GetAccountEmployeesForReport(AccountId, AccountClientId, IsActive, ProjectStatusId)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrProjectListReport

        Dim ds As New dsProjectListReportForXtrReport.vueAccountProjectsDataTable
        Dim adap As New dsProjectListReportForXtrReportTableAdapters.vueAccountProjectsTableAdapter
        ds = adap.GetDataForProjectReport(AccountId, AccountClientId, IsActive, ProjectStatusId)

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.ShowReport(DBUtilities.GetSessionAccountId, 0, -1, 0)
        Else
            Me.FltProjectListReport1_FilterClick(CType(Me.FltProjectListReport1.FindControl("ddlClientName"), DropDownList).SelectedValue, CType(Me.FltProjectListReport1.FindControl("ddlActiveStatus"), DropDownList).SelectedValue, CType(Me.FltProjectListReport1.FindControl("ddlProjectStatus"), DropDownList).SelectedValue)
        End If
    End Sub

    Protected Sub FltProjectListReport1_FilterClick(ByVal AccountClientId As Integer, ByVal IsActive As Boolean, ByVal ProjectStatusId As Integer) Handles FltProjectListReport1.FilterClick
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReport(DBUtilities.GetSessionAccountId, CType(Me.FltProjectListReport1.FindControl("ddlClientName"), DropDownList).SelectedValue, CType(Me.FltProjectListReport1.FindControl("ddlActiveStatus"), DropDownList).SelectedValue, CType(Me.FltProjectListReport1.FindControl("ddlProjectStatus"), DropDownList).SelectedValue)
    End Sub
End Class
