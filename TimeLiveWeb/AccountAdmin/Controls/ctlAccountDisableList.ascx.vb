Imports System.Reflection
Imports System.IO
Partial Class AccountAdmin_Controls_ctlAccountDisableList
    Inherits System.Web.UI.UserControl

    Protected Sub btnDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisabled.Click
        Label1.Visible = False
        Dim Password As String = Me.PasswordTextBox.Text
        Dim MembershipProvider As New CustomProviders.LiveMembershipProvider
        Password = MembershipProvider.EncodePassword(Password)

        Dim dt As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetViewAccountEmployeesByUsernameAndPassword(Me.UserNameTextBox.Text, Password)
        Dim dr As AccountEmployee.vueAccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Call New AccountBLL().UpdateIsDisableForAccountClosed(dr.AccountId)
            Call New AccountEmployeeBLL().UpdateIsDisableForAccountClosed(dr.AccountId)
            Call New AccountEMailNotificationPreferenceBLL().UpdateEnableForAccountDisable(dr.AccountId)
            Call New AccountEmployeeBLL().UpdateEmailAddressAndUserNameForAccountClosed(dr.AccountId)
            Me.ShowAccountDisabledMessage()
        Else
            Label1.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.IspageHasRights(121)
        Me.Literal1.Text = ResourceHelper.GetFromResource("Disable Account")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Administrator Username:")
        Me.Literal3.Text = ResourceHelper.GetFromResource("Administrator Password:")
        If System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME") Is Nothing Then
            Me.Literal4.Text = ResourceHelper.GetFromResource("Disabling account will stop any activities in your TimeLive account. Your employee will not be able to login in TimeLive.")
        Else
            Dim C_Name As String = System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME")
            Me.Literal4.Text = "Disabling account will stop any activities in your " & C_Name & " account. Your employee will not be able to login in " & C_Name & "."
        End If
    End Sub
    Public Sub ShowAccountDisabledMessage()
        Dim strMessage As String
        If System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME") Is Nothing Then
            strMessage = "Thanks for using TimeLive. Your account has been disabled successfully."
        Else
            strMessage = "Thanks for using " & System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME") & ". Your account has been disabled successfully."
        End If
        Dim strScript As String = "alert('" & strMessage & "'); window.location.href = '../Default.aspx';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
        'window.location = '" & URL & "';
    End Sub
End Class
