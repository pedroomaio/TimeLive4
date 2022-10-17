
Partial Class Employee_Controls_ctlStatusLegend
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Literal4.Text = ResourceHelper.GetFromResource("Approved")
    End Sub
End Class
