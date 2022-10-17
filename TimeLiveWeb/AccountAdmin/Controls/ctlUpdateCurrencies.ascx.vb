
Partial Class AccountAdmin_Controls_ctlUpdateCurrencies
    Inherits System.Web.UI.UserControl

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermissionForFormView(112, Me.FormView1, "btnUpdate")
    End Sub
End Class
