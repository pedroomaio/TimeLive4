
Partial Class AccountAdmin_ResetAllSecurity
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call New AccountPagePermissionBLL().ResetAllPagePermission(DBUtilities.GetSessionAccountId)
        UIUtilities.RedirectToLoginPage()
    End Sub
End Class
