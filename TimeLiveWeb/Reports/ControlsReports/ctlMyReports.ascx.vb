
Partial Class Reports_ControlsReports_ctlMyReports
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HyperLink12.Text = ResourceHelper.GetFromResource("All Location Report")
        HyperLink12.ToolTip = ResourceHelper.GetFromResource("All Location Report")
        HyperLink63.ToolTip = ResourceHelper.GetFromResource("All Location Report")
        Literal33.Text = ResourceHelper.GetFromResource("All Location Report")
    End Sub
End Class
