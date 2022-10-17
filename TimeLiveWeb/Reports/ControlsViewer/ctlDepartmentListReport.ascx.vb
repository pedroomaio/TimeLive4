
Partial Class Reports_ControlsViewer_ctlDepartmentListReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer)
        ''Dim docReport As New C1.Web.C1WebReport.C1WebReport
        ''docReport.ReportSource.FileName = (Server.MapPath("ReportFiles\rptDepartmentListReport.xml"))

        'Dim m As TimeLiveDataSet.AccountDepartmentDataTable
        '  m = New AccountDepartmentBLL().GetAccountDepartmentsByAccountId(DBUtilities.GetSessionAccountId)


        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()


        Dim Report As New xtrDepartmentListReport
        Dim ds As New dsDepartmentListReport
        Dim dt As New dsDepartmentListReport.AccountDepartmentDataTable
        Dim adap As New dsDepartmentListReportTableAdapters.AccountDepartmentTableAdapter


        dt = ds.Tables(0)
        adap.FillBy(dt, DBUtilities.GetSessionAccountId)
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '     If Not Me.IsPostBack Then
        Me.ShowReport(DBUtilities.GetSessionAccountId)
        '  End If
    End Sub
End Class
