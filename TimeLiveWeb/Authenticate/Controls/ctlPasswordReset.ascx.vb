
Partial Class Authenticate_Controls_ctlPasswordReset
    Inherits System.Web.UI.UserControl

    Protected Sub btnPasswordReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPasswordReset.Click
        Me.Label1.Visible = False
        Me.Label2.Visible = False
        Dim EmployeeBLL As New AccountEmployeeBLL
        If EmployeeBLL.SendPasswordResetVerificationCode(Me.txtEmailAddress.Text) <> True Then
            Me.Label2.Visible = True
        Else
            Me.Label1.Text = ResourceHelper.GetFromResource("To get back into your account, follow the instructions we've sent to your " & Me.txtEmailAddress.Text & " email address.")
            Me.Label1.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UIUtilities.GetApplicationMode = "Installed" Then
            Me.Page.Title = ResourceHelper.GetFromResource(Me.Page.Title)
        Else
        End If
    End Sub
End Class
