
Partial Class Authenticate_Controls_ctlPasswordChange
    Inherits System.Web.UI.UserControl

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Username As String = ""
        Dim IsPasswordExpired As Boolean = False
        Dim CurrentPassword As String = CType(Membership.Provider, CustomProviders.LiveMembershipProvider).EncodePassword(txtCurrentPassword.Text)
        Dim NewPassword As String = CType(Membership.Provider, CustomProviders.LiveMembershipProvider).EncodePassword(txtNewPassword.Text)

        Dim AccountEmployeeBLL As New AccountEmployeeBLL
        If Not Request.QueryString("Username") Is Nothing Then
            Username = Request.QueryString("Username")
        End If
        If Not Request.QueryString("IsPasswordExpired") Is Nothing Then
            IsPasswordExpired = Request.QueryString("IsPasswordExpired")
        End If
        If CurrentPassword = NewPassword Then
            Me.lblSameError.Visible = True
            Me.lblIncorrect.Visible = False
            Return
        End If
        Dim AccountEmployees As AccountEmployee.vueAccountEmployeeDataTable = AccountEmployeeBLL.GetViewAccountEmployeesByUsernameAndPassword(Username, CurrentPassword)
        Dim dr As AccountEmployee.vueAccountEmployeeRow
        If AccountEmployees.Rows.Count > 0 Then
            dr = AccountEmployees.Rows(0)
            AccountEmployeeBLL.UpdatePasswordAndPasswordChangedDateByEmailAddress(Username, NewPassword)
            If IsPasswordExpired Then
                AccountEmployeeBLL.UpdatePasswordChangedDateByAccountId(dr.AccountId, Now)
            End If
            ShowPasswordChangedMessage()
        Else
            Me.lblIncorrect.Visible = True
            Me.lblSameError.Visible = False
        End If
    End Sub
    Public Sub ShowPasswordChangedMessage()
        Dim strMessage As String = "Your password has been successfully changed. Please login with your new password."
        Dim strScript As String = "alert('" & strMessage & "'); window.location.href = '../Default.aspx';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
        'window.location = '" & URL & "';
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AccountId As Integer
        Dim PasswordComplexity As Boolean = True
        Dim dt As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetVueAccountEmployeesByEmailAddress(Me.Request.QueryString("UserName"))
        Dim dr As AccountEmployee.vueAccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            AccountId = dr.AccountId
        End If
        Dim dtPreference As TimeLiveDataSet.vueAccountDataTable = New AccountBLL().GetAccountViewAsAccountId(AccountId)
        Dim drPreference As TimeLiveDataSet.vueAccountRow
        If dtPreference.Rows.Count > 0 Then
            drPreference = dtPreference.Rows(0)
            If Not IsDBNull(drPreference.Item("EnablePasswordComplexity")) Then
                PasswordComplexity = drPreference.EnablePasswordComplexity
            End If
        End If
        If PasswordComplexity = False Then
            Me.RegularExpressionValidator2.Enabled = False
        End If
    End Sub
End Class
