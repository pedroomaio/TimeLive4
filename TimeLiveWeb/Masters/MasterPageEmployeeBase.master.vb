Partial Class MasterPageEmployeeBase
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init '
        If LicensingBLL.IsPaidCustomerLicenseExpired(Session("AccountId")) And Me.Page.ToString.Contains("accountlicenseactivation") = False Then
            System.Web.HttpContext.Current.Response.Redirect("~/AccountAdmin/AccountLicenseActivation.aspx", False)
        End If
        If AuthenticateBLL.IsNewSession() Then
            If Me.Page.IsCallback Then
                AuthenticateBLL.DoLogoutForCallBack(Me.Page)
            Else
                AuthenticateBLL.DoLogout(Me.Page)
            End If
        End If
        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)
        If Not AccountPagePermissionBLL.IsPageHasRightsByPage(Me.Page) Then
            If Me.Page.IsCallback Then
                DevExpress.Web.ASPxClasses.ASPxWebControl.RedirectOnCallback("~/Employee/NoPermission.aspx")
            Else
                Response.Redirect("~/Employee/NoPermission.aspx", False)
            End If
        End If

    End Sub
    Public Sub SetFilters()
        Master.SetFilterResult()
    End Sub
    Public Sub HideFilters()
        Master.HideFilterResult()
    End Sub
End Class

