Partial Class Reports_ControlsViewer_ctlClientListReportViewer
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''  If Not Me.IsPostBack Then
        'Me.ShowReport(DBUtilities.GetSessionAccountId)
        ''   End If

    End Sub

    Public Sub ShowReport(ByVal AccountId As Integer)

        'Dim m As TimeLiveDataSet.vueAccountPartyDataTable
        'm = New AccountPartyBLL().GetvueAccountPartiesByAccountId(AccountId)
        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()
        'Me.C1WebReport1.DataBind()

    End Sub

End Class
