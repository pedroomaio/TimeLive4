
Partial Class Masters_MasterPageReport
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)
    End Sub
End Class

