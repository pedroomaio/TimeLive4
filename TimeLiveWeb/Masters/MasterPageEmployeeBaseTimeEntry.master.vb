Partial Class MasterPageEmployeeBaseTimeEntry
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init '
        If AuthenticateBLL.IsNewSession() Then
            AuthenticateBLL.DoLogout(Me.Page)
        End If

        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)
        If Not AccountPagePermissionBLL.IsPageHasRightsByPage(Me.Page) Then
            Response.Redirect("~/Employee/NoPermission.aspx", False)
        End If

    End Sub
End Class

