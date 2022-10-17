Imports System.Security.Principal
Imports System.Web.Security
Imports DotNetOpenAuth.OpenId
Imports DotNetOpenAuth.OpenId.RelyingParty
Imports DotNetOpenAuth.OpenId.Extensions.AttributeExchange
Imports DotNetOpenAuth.OAuth
Imports DotNetOpenAuth.OpenId.Extensions
Imports DotNetOpenAuth.OAuth2
Imports System.Web.Mvc
Imports DotNetOpenAuth.Messaging
Imports System.Linq
Imports System
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Net
Imports System.IO

Partial Class Auth_Controls_ctlLogin
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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If UIUtilities.GetApplicationMode = "Installed" Then
        '    CType(Me.Login1.FindControl("GAAR"), HtmlTableRow).Style.Add("display", "none")
        'End If
        Me.SetImageUrl()
        CType(Me.Login1.FindControl("VersionLabel"), Label).Text = "Version " & SystemUtilitiesBLL.GetApplicationVersion.ToString
        If UIUtilities.IsSignUpOnLogin Then
            CType(Me.Login1.FindControl("Button2"), Button).Visible = True
        Else
            CType(Me.Login1.FindControl("Button2"), Button).Visible = False
        End If

        ''--Google Authentication

        Client_ID = System.Configuration.ConfigurationManager.AppSettings("google_clientId")
        Return_url = System.Configuration.ConfigurationManager.AppSettings("google_RedirectUrl")
        If Not Me.IsPostBack Then
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
                Dim result As String = EmployeeBLL.SignInByEmailAddress(Email_address)
                If result = "NoEmailAddressFound" Then
                    CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).Visible = True
                    CType(Me.Login1.FindControl("trBeforeError"), HtmlTableRow).Visible = False
                    CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).InnerText = "Sorry for the inconvienance but in our system, we cannot find """ & Email_address & """. Please verify and check it at your end. " & vbCrLf & vbCrLf & "If the problem persists, verify that your administrator has configured your account to sign in using Google."
                ElseIf result = "EnableGoogleAuthentication" Then
                    CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).Visible = True
                    CType(Me.Login1.FindControl("trBeforeError"), HtmlTableRow).Visible = False
                    CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).InnerText = "Your account only allows sign-in via email/password. Please contact your administrator to enable Google authentication option."
                End If
            End If
        End If
        If System.Configuration.ConfigurationManager.AppSettings("GAppsAuthentication") Is Nothing Then
            CType(Me.Login1.FindControl("googleLoginButton"), HtmlAnchor).Visible = False
            'CType(Me.Login1.FindControl("yahooLoginButton"), OpenIdButton).Visible = False
            'CType(Me.Login1.FindControl("googleappsLoginButton"), OpenIdButton).Visible = False
            ' CType(Me.Login1.FindControl("Literal6"), Literal).Visible = False
        End If
    End Sub
    Public Sub SetImageUrl()
        If System.Configuration.ConfigurationManager.AppSettings("SHOW_HELP_ICON") = "No" Then
            CType(Me.Login1.FindControl("Literal1"), Literal).Visible = False
        End If
        If UIUtilities.GetApplicationMode = "Installed" Then
            If Membership.Provider.Name = "AspNetActiveDirectoryMembershipProvider" Then
                CType(Me.Login1.FindControl("Literal5"), Literal).Visible = False
            End If
            CType(Me.Login1.FindControl("CopyRightText"), System.Web.UI.WebControls.Literal).Text = ResourceHelper.GetFromResource("Copyright 2007 - 2009 Livetecs LLC. All rights reserved.")
            Me.Page.Title = ResourceHelper.GetFromResource(Me.Page.Title)
            If DBUtilities.GetIsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExist(False) = True Then
                CType(Me.Login1.FindControl("imgCompanyOwnLogo"), System.Web.UI.WebControls.Image).ImageUrl = ("~/Uploads/" & DBUtilities.GetInstalledAccountId & "/Logo/CompanyLogo.gif")
            Else
                If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
                    CType(Me.Login1.FindControl("imgCompanyOwnLogo"), System.Web.UI.WebControls.Image).ImageUrl = "~/Images/TrakLiveLogo.png"
                Else
                    CType(Me.Login1.FindControl("imgCompanyOwnLogo"), System.Web.UI.WebControls.Image).ImageUrl = "~/Images/TopHeader.png"
                End If
            End If
        End If
        If UIUtilities.GetApplicationMode = "Hosted" Then
            Dim accountbll As New AccountBLL
            Dim Domain As String = HttpContext.Current.Request.Url.Host.ToString.ToLower
            Dim SubDomain() As String = Domain.Split(".")

            If accountbll.IsSubDomainExists(SubDomain(0)) = True Then
                If DBUtilities.GetIsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExist(True, SubDomain(0)) = True Then
                    CType(Me.Login1.FindControl("imgCompanyOwnLogo"), System.Web.UI.WebControls.Image).ImageUrl = ("~/Uploads/" & DBUtilities.GetAccountIdbySubDomain(SubDomain(0)) & "/Logo/CompanyLogo.gif")
                End If
            Else
                If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
                    CType(Me.Login1.FindControl("imgCompanyOwnLogo"), System.Web.UI.WebControls.Image).ImageUrl = "~/Images/TrakLiveLogo.png"
                Else
                    CType(Me.Login1.FindControl("imgCompanyOwnLogo"), System.Web.UI.WebControls.Image).ImageUrl = "~/Images/TopHeader.png"
                End If
            End If
        End If
    End Sub
    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim Username As String = CType(Me.Login1.FindControl("UserName"), TextBox).Text
        Dim Password As String = CType(Me.Login1.FindControl("Password"), TextBox).Text
        Dim BLL As New AuthenticateBLL

        If EmployeeBLL.IsEmployeeDisabled(Username) = True Then
            e.Authenticated = False
            CType(Me.Login1.FindControl("FailureText1"), HtmlGenericControl).InnerText = "Your user account is disabled."
            CType(Me.Login1.FindControl("FailureText1"), HtmlGenericControl).Visible = True
            CType(Me.Login1.FindControl("trBeforeError"), HtmlTableRow).Visible = False
            Return
        End If
        LoggingBLL.WriteToLog("Login1_Authenticate: Initiated")
        Try
            If BLL.AuthenticateLogin(Username, Password) = True Then
                Me.UpdateUILanguage()
                e.Authenticated = True
            Else
                e.Authenticated = False
                CType(Me.Login1.FindControl("FailureText1"), HtmlGenericControl).InnerText = "Your login attempt was not successful. Please try again."
                CType(Me.Login1.FindControl("FailureText1"), HtmlGenericControl).Visible = True
                CType(Me.Login1.FindControl("trBeforeError"), HtmlTableRow).Visible = False
            End If
        Catch ex As Exception
            CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).Visible = True
            CType(Me.Login1.FindControl("trBeforeError"), HtmlTableRow).Visible = False
            CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).InnerText = "Configuration Error: " & ex.Message
        End Try
        LoggingBLL.WriteToLog("Login1_Authenticate: Finish")
    End Sub
    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        Dim Username As String = CType(Me.Login1.FindControl("UserName"), TextBox).Text
        Dim Password As String = CType(Me.Login1.FindControl("Password"), TextBox).Text
        Dim BLL As New AuthenticateBLL
        BLL.LoggedIn(Username, Password)
        If DBUtilities.IsTimeLiveMobileLogin Then
            Login1.DestinationPageUrl = UIUtilities.RedirectToMobileHomePage()
        Else
            Login1.DestinationPageUrl = UIUtilities.RedirectToHomePage()
        End If
        LoggingBLL.WriteToLog("Login1_LoggedIn: Finish")
    End Sub
    Public Sub UpdateUILanguage()
        Dim bll As New AccountEmployeeBLL
        Dim Accountbll As New AccountBLL
        Dim dt As AccountEmployee.vueAccountEmployeeDataTable = bll.GetAccountEmployeeIdByEmailAddress(CType(Me.Login1.FindControl("UserName"), TextBox).Text)
        Dim dr As AccountEmployee.vueAccountEmployeeRow
        Dim EmployeeId As Integer
        Dim AccountId As Integer
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            EmployeeId = dr.AccountEmployeeId
            AccountId = dr.AccountId
            If CType(Me.Login1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue <> "0" Then
                If CType(Me.Login1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue <> dr.UserInterfaceLanguage Then
                    'bll.UpdateUILanguage(CType(Me.Login1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue, EmployeeId)
                    bll.SetSessionValuesUILanguage(Nothing, EmployeeId, CType(Me.Login1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue)
                End If
            End If
        End If
        'AccountEmployeeBLL.get
        'System.Web.HttpContext.Current.Session.Add("UserInterfaceLanguage", CType(Me.Login1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue)
    End Sub
    Protected Sub Button2_Click(sender As Object, e As System.EventArgs)
        Response.Redirect(SignUpURL, False)
    End Sub
    Public Shared Function SignUpURL() As String
        Return "~/Home/SignUp.aspx"
    End Function
    Protected Sub yahooLoginButton_LoggingIn(ByVal sender As Object, ByVal e As DotNetOpenAuth.OpenId.RelyingParty.OpenIdEventArgs)

    End Sub
    Protected Sub yahooLoginButton_LoggedIn(ByVal sender As Object, ByVal e As DotNetOpenAuth.OpenId.RelyingParty.OpenIdEventArgs)
        If Not e.Cancel Then
            Dim EmployeeBLL As New AccountEmployeeBLL
            If EmployeeBLL.SignInByClaimIdentifier(e.Response.ClaimedIdentifier) = False Then
                CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).Visible = True
                CType(Me.Login1.FindControl("trBeforeError"), HtmlTableRow).Visible = False
                CType(Me.Login1.FindControl("ErrorText"), HtmlGenericControl).InnerText = "Configuration Error: Your user account is not linked with Yahoo login. " & vbCrLf & "Please login with your livetecs account and linked your account."
                UIUtilities.RedirectToLoginPage()
            End If
        End If
    End Sub
    Public Sub ShowMessage(ByVal message As String)
        Dim strMessage As String = message
        Dim strScript As String = "alert('" & strMessage & "'); window.location = 'Default.aspx';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
End Class
