
Partial Class AccountAdmin_Controls_ctlAuthenticationSetting
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UIUtilities.RedirectToHomePage()
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        UIUtilities.RedirectToHomePage()
    End Sub

    Protected Sub chkActiveDirectoryAuthentication_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
