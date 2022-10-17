
Partial Class MasterPageEmployeeNoAjax
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If System.Web.HttpContext.Current.Session.IsNewSession Then
            System.Web.Security.FormsAuthentication.SignOut()
            System.Web.Security.FormsAuthentication.RedirectToLoginPage()
        End If

        If Not AccountPagePermissionBLL.IsPageHasRightsByPage(Me.Page) Then

            Response.Redirect("~/Employee/NoPermission.aspx", False)

        End If

    End Sub
End Class

