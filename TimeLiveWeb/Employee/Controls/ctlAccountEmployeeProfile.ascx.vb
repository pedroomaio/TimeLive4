Imports DotNetOpenAuth.OpenId
Imports DotNetOpenAuth.OpenId.RelyingParty
Imports DotNetOpenAuth.OpenId.Extensions.AttributeExchange
Imports DotNetOpenAuth.OAuth
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data
Imports System.Configuration
Partial Class Controls_ctlAccountEmployeeProfile
    Inherits System.Web.UI.UserControl
    Private Shared ReadOnly relyingParty As New OpenIdRelyingParty
    Public Email_address As String = ""
    Public Google_ID As String = ""
    Public firstName As String = ""
    Public LastName As String = ""
    Public Client_ID As String = ""
    Public Return_url As String = ""
    Shared Sub New()
        Dim googleAppsDiscovery As New HostMetaDiscoveryService()
        googleAppsDiscovery.UseGoogleHostedHostMeta = True

        relyingParty.DiscoveryServices.Insert(0, googleAppsDiscovery)
        relyingParty.SecuritySettings.MinimumRequiredOpenIdVersion = DotNetOpenAuth.OpenId.ProtocolVersion.V20
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If Not IsDBNull(Me.FormView1.DataItem("CountryId")) Then
            CType(Me.FormView1.FindControl("DropDownList3"), DropDownList).SelectedValue = Me.FormView1.DataItem("CountryId")
        End If
        If Not IsDBNull(Me.FormView1.DataItem("TimeZoneId")) Then
            CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue = Me.FormView1.DataItem("TimeZoneId")
        End If
        If Not IsDBNull(Me.FormView1.DataItem("UserInterfaceLanguage")) Then
            CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue = Me.FormView1.DataItem("UserInterfaceLanguage")
        End If
        If Not IsDBNull(Me.FormView1.DataItem("IsShowEmployeeProfilePicture")) Then
            CType(Me.FormView1.FindControl("chkIsShowEmployeePicture"), CheckBox).Checked = Me.FormView1.DataItem("IsShowEmployeeProfilePicture")
        End If
        If DBUtilities.EnablePasswordComplexity = False Then
            CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = False
        End If
        If Not IsDBNull(Me.FormView1.DataItem("IsTimeInOutAvailable")) Then
            CType(Me.FormView1.FindControl("chkTimeinOut"), CheckBox).Checked = Me.FormView1.DataItem("IsTimeInOutAvailable")
        End If
        Dim LDAP As New LDAPUtilitiesBLL

        CType(Me.FormView1.FindControl("txtUsername"), TextBox).ReadOnly = True
        If FormView1.CurrentMode = FormViewMode.Edit Then
            CType(Me.FormView1.FindControl("FileUpload2"), FileUpload).DataBind()
        End If
        If DBUtilities.GetOpenIDClaimIdentifier <> "" Then
            CType(Me.FormView1.FindControl("lblAuthenticate"), Label).Visible = True
            CType(Me.FormView1.FindControl("lblAuthentication"), Label).Visible = True
            CType(Me.FormView1.FindControl("lblAuthEmailAddress"), Label).Visible = True
            CType(Me.FormView1.FindControl("lblAuthClick"), Label).Visible = True
            CType(Me.FormView1.FindControl("lblAuthToUnlink"), Label).Visible = True
            'If DBUtilities.GetOpenIDSource = "GoogleApps" Then
            'CType(Me.FormView1.FindControl("lblAuthentication"), Label).Text = "Linked to Google:"
            CType(Me.FormView1.FindControl("lblAuthenticate"), Label).Text = "This account is linked with "
            CType(Me.FormView1.FindControl("lblAuthEmailAddress"), Label).Text = DBUtilities.GetOpenIDSource & "."
            'DBUtilities.GetOpenIDClaimIdentifier()
            'ElseIf DBUtilities.GetOpenIDSource = "Google" Then
            '    CType(Me.FormView1.FindControl("lblAuthentication"), Label).Text = "Linked to Google:"
            '    CType(Me.FormView1.FindControl("lblAuthenticate"), HyperLink).Text = DBUtilities.GetOpenIDClaimIdentifier
            'ElseIf DBUtilities.GetOpenIDSource = "Yahoo" Then
            '    CType(Me.FormView1.FindControl("lblAuthentication"), Label).Text = "Linked to Yahoo:"
            '    CType(Me.FormView1.FindControl("lblAuthenticate"), HyperLink).Text = DBUtilities.GetOpenIDClaimIdentifier
            'End If
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
        End If
    End Sub
    Dim IsUpdate As Boolean
    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text <> "" And CType(Me.FormView1.FindControl("VerifyPasswordTextbox"), TextBox).Text <> "" Then
            Dim AccountEmployeeId As Integer
            Dim Username As String = ""
            Dim IsPasswordExpired As Boolean = False
            Dim CurrentPassword As String = CType(Membership.Provider, CustomProviders.LiveMembershipProvider).EncodePassword(CType(Me.FormView1.FindControl("CurrentPasswordTextBox"), TextBox).Text)
            Dim NewPassword As String = CType(Membership.Provider, CustomProviders.LiveMembershipProvider).EncodePassword(CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text)

            Dim AccountEmployeeBLL As New AccountEmployeeBLL
            AccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            Username = AccountEmployeeBLL.GetEmailAddressByAccountEmployeeId(AccountEmployeeId)

            ''If Not Request.QueryString("IsPasswordExpired") Is Nothing Then
            ''    IsPasswordExpired = Request.QueryString("IsPasswordExpired")
            ''End If
            If IsCheckPasswordValidation() = False Then
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
                ''ShowPasswordChangedMessage()
            Else
                If CType(Me.FormView1.FindControl("CurrentPasswordTextBox"), TextBox).Text <> "" Then
                    Me.ShowNotFoundMessagePasswordWrongValidation()
                    IsUpdate = True
                End If
            End If
        End If

        ''Me.dsAccountEmployeeObject.Update()
    End Sub
    Public Sub ShowPasswordChangedMessage()
        Dim strMessage As String = "Your password has been successfully changed. Please login with your new password."
        Dim strScript As String = "alert('" & strMessage & "'); window.location.href = '../Default.aspx';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
        'window.location = '" & URL & "';
    End Sub
    Public Sub ShowNotFoundMessagePasswordSameValidation()
        Dim strMessage As String = "The New Password cannot be the same as the Current Password. Please enter a new password."
        Dim strScript As String = "alert('" & strMessage & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Public Sub ShowNotFoundMessagePasswordWrongValidation()
        Dim strMessage As String = "Incorrect current password."
        Dim strScript As String = "alert('" & strMessage & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub FormView1_ItemCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ItemCreated
        Dim dllBillingType As DropDownList = Me.FormView1.Row.FindControl("dllBillingTypeEdit")

        If Not dllBillingType Is Nothing And Not Me.FormView1.DataItem Is Nothing Then
            If Not IsDBNull(Me.FormView1.DataItem("BillingTypeId")) Then
                dllBillingType.SelectedValue = Me.FormView1.DataItem("BillingTypeId")
            End If
        End If

    End Sub
    Protected Sub ObjectDataSource1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Updated
        If IsCheckPasswordValidation() = True Then
            Response.Redirect(UIUtilities.RedirectToHomePage, False)
        End If

    End Sub
    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim txtPasswordTextBox As TextBox = Me.FormView1.Row.FindControl("PasswordTextBox")
        If txtPasswordTextBox.Text <> "" Then
            e.InputParameters("Password") = txtPasswordTextBox.Text
        End If
        e.InputParameters("CountryId") = CType(Me.FormView1.FindControl("DropDownList3"), DropDownList).SelectedValue
        e.InputParameters("TimeZoneId") = CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue
        e.InputParameters("UserInterfaceLanguage") = CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue
        e.InputParameters("IsShowEmployeeProfilePicture") = CType(Me.FormView1.FindControl("chkIsShowEmployeePicture"), CheckBox).Checked
        If DBUtilities.IsAttendanceFeature Then
            e.InputParameters("IsTimeInOutAvailable") = CType(Me.FormView1.FindControl("chkTimeinOut"), CheckBox).Checked
        Else
            e.InputParameters("IsTimeInOutAvailable") = False
        End If


        DBUtilities.SetRowForUpdating(e)
        If IsCheckPasswordValidation() = False And CType(Me.FormView1.FindControl("VerifyPasswordTextBox"), TextBox).Text <> "" Then
            ShowNotFoundMessagePasswordSameValidation()
            e.Cancel = True
        End If
        If IsUpdate = True Then
            e.Cancel = True
        End If
    End Sub
    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(UIUtilities.RedirectToHomePage, False)
    End Sub
    Public Function IsCheckPasswordValidation() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL
        Dim AccountEmployeeId As Integer
        Dim Username As String
        If LDAP.IsAspNetActiveDirectoryMembershipProvider() Then
            Return True
        Else
            Dim CurrentPassword As String = CType(Membership.Provider, CustomProviders.LiveMembershipProvider).EncodePassword(CType(Me.FormView1.FindControl("CurrentPasswordTextBox"), TextBox).Text)
            Dim NewPassword As String = CType(Membership.Provider, CustomProviders.LiveMembershipProvider).EncodePassword(CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text)

            Dim AccountEmployeeBLL As New AccountEmployeeBLL
            AccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            Username = AccountEmployeeBLL.GetEmailAddressByAccountEmployeeId(AccountEmployeeId)
            If CType(Me.FormView1.FindControl("VerifyPasswordTextBox"), TextBox).Text <> "" Then
                If CurrentPassword = NewPassword Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        End If
    End Function

    Protected Sub FormView1_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Dim EmployeeBLL As New AccountEmployeeBLL
        EmployeeBLL.FileUploadForProfile(Me.FormView1.FindControl("FileUpload2"), DBUtilities.GetSessionAccountEmployeeId)
        Response.Redirect("~/Employee/Default.aspx", False)
    End Sub

    Protected Sub FormView1_ItemUpdating(sender As Object, e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Dim googleAppsDiscovery As New HostMetaDiscoveryService()
        'googleAppsDiscovery.UseGoogleHostedHostMeta = True

        'Dim RelyingParty As New OpenIdRelyingParty()
        'RelyingParty.DiscoveryServices.Clear()
        'RelyingParty.DiscoveryServices.Insert(0, googleAppsDiscovery)
        Client_ID = System.Configuration.ConfigurationManager.AppSettings("google_clientId")
        Return_url = System.Configuration.ConfigurationManager.AppSettings("google_RedirectUrl")
        If Request.QueryString("access_token") IsNot Nothing Then
            Dim URI As [String] = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString("access_token").ToString()
            Dim webClient As New WebClient()
            Dim stream As Stream = webClient.OpenRead(URI)
            Dim b As String
            'I have not used any JSON parser because I do not want to use any extra dll/3rd party dll
            Using br As New StreamReader(stream)
                b = br.ReadToEnd()
            End Using
            b = b.Replace("id", "").Replace("email", "")
            b = b.Replace("given_name", "")
            b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "")
            b = b.Replace("gender", "").Replace("locale", "").Replace(":", "")
            b = b.Replace("""", "").Replace("name", "").Replace("{", "").Replace("}", "")
            Dim ar As Array = b.Split(",".ToCharArray())
            For p As Integer = 0 To ar.Length - 1
                ar.SetValue(ar.GetValue(p).ToString().Trim(), p)
            Next
            Email_address = ar.GetValue(1).ToString()
            Google_ID = ar.GetValue(0).ToString()
            firstName = ar.GetValue(4).ToString()
            LastName = ar.GetValue(5).ToString()
            Dim EmployeeBLL As New AccountEmployeeBLL
            EmployeeBLL.UpdateOpenIDClaimIdentifierByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId, Google_ID, Email_address)
            Response.Redirect("~/Employee/Default.aspx", False)
        End If

        Dim authResponse As IAuthenticationResponse = relyingParty.GetResponse()
        If authResponse IsNot Nothing Then
            If authResponse.Status = AuthenticationStatus.Authenticated Then
                Dim EmployeeBLL As New AccountEmployeeBLL
                Dim URL As String = authResponse.ClaimedIdentifier
                If URL.Contains("yahoo") Then
                    EmployeeBLL.UpdateOpenIDClaimIdentifierByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId, authResponse.ClaimedIdentifier, "Yahoo")
                End If
                Response.Redirect("~/Employee/Default.aspx", False)
            End If
        End If
    End Sub
    Protected Sub yahooLoginButton_LoggingIn(ByVal sender As Object, ByVal e As DotNetOpenAuth.OpenId.RelyingParty.OpenIdEventArgs)

    End Sub
    Protected Sub yahooLoginButton_LoggedIn(ByVal sender As Object, ByVal e As DotNetOpenAuth.OpenId.RelyingParty.OpenIdEventArgs)
        If Not e.Cancel Then
            Dim EmployeeBLL As New AccountEmployeeBLL
            EmployeeBLL.UpdateOpenIDClaimIdentifierByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId, e.Response.ClaimedIdentifier, "Yahoo")
        End If
    End Sub
    Private Sub sendGoogleRequest(request As IAuthenticationRequest)
        ' Request access to e-mail address, first name and last name
        ' via OpenID Attribute Exchange (AX)
        Dim fetch As New FetchRequest()
        fetch.Attributes.Add(New AttributeRequest(WellKnownAttributes.Contact.Email, True))
        fetch.Attributes.Add(New AttributeRequest(WellKnownAttributes.Name.First, True))
        fetch.Attributes.Add(New AttributeRequest(WellKnownAttributes.Name.Last, True))
        request.AddExtension(fetch)

        ' Send your visitor to their Provider for authentication.  
        request.RedirectToProvider()
    End Sub
    Protected Sub loginButton_Click(sender As Object, e As EventArgs)
      
    End Sub
    Protected Sub btnunlink_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim EmployeeBLL As New AccountEmployeeBLL
        EmployeeBLL.UpdateGoogleAuthenticatebyEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
    End Sub
End Class
