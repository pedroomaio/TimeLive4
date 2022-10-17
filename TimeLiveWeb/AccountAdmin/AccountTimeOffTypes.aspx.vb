
Partial Class AccountAdmin_AccountTimeOffTypes
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        Dim baseMasterPage As MasterPage = Me.Master
        While baseMasterPage.Master IsNot Nothing
            baseMasterPage = baseMasterPage.Master
        End While

        baseMasterPage.FindControl("phDefaultFooterScripts").Visible = False
    End Sub
End Class
