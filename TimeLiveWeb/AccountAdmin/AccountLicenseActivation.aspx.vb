
Partial Class AccountAdmin_AccountLicenseActivation
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            'Dim objFormView As FormView = Me.Ctlaccountform1.FindControl("FormView1")
            'objFormView.ChangeMode(FormViewMode.Edit)
            'objFormView.DataBind()
            'CType(Me.Ctlaccountform1.FindControl("UpdatePanel1"), UpdatePanel).UpdateMode = UpdatePanelUpdateMode.Conditional
            'CType(Me.Ctlaccountform1.FindControl("UpdatePanel1"), UpdatePanel).Update()

        End If

    End Sub
End Class
