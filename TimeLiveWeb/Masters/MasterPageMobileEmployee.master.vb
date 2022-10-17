
Partial Class Masters_MasterPageMobileEmployee
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If AuthenticateBLL.IsNewSession() Then
            AuthenticateBLL.DoLogout(Me.Page, True)
        End If

        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)

    End Sub
End Class

