Imports System.Web.Services
Imports System.DirectoryServices
Partial Class Home_AccountAdd
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim FileName As String
        Dim registerKey As String
        FileName = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/AccountAdd.txt")
        If System.IO.File.Exists(FileName) Then
            registerKey = System.IO.File.ReadAllText(FileName)
            If registerKey <> "" Then
                If Not Page.ClientScript.IsStartupScriptRegistered("key1") Then
                    Page.ClientScript.RegisterStartupScript([GetType](), "key1", registerKey)
                End If
            End If
        End If
    End Sub

    Protected Sub btnSignUp_ServerClick(sender As Object, e As System.EventArgs) Handles btnsignup.ServerClick
        Try
        Dim BLL As New AccountBLL
            Dim employee As New AccountEmployeeBLL()
            Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
            If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then
                If Not BLL.IsSubDomainExists(txtSubDomain.Text) And Not txtSubDomain.Text = "" Then
                    If employee.ValidateNewEmployee(txtEmail.Value) And txtEmail.Value <> "" Then
                        If UIUtilities.GetApplicationMode = "Hosted" Then
                            BLL.AddNewAccount(2, txtCompanyName.Value, "", "", "", "", 233, txtEmail.Value, "", txtPhoneNo.Value, "", 1, 8, txtEmail.Value, txtPassword.Value, _
                                                txtEmail.Value, txtFirstName.Value, txtLastName.Value, "", "", "", False, False, Now.Date, Now.Date, "en-US", txtSubDomain.Text)
                        End If
                        AfterInsertAccount()
                    Else
                        UIUtilities.ShowMessage("Specified email already exist.", CurrentPage)
                    End If
                Else
                    UIUtilities.ShowMessage(txtSubDomain.Text & ".livetecs.com is not avaiable.", Me.Page)

                End If
            Else
                If employee.ValidateNewEmployee(txtEmail.Value) And txtEmail.Value <> "" Then
                    If UIUtilities.GetApplicationMode = "Installed" Then
                        If UIUtilities.IsAspNetActiveDirectoryMembershipProvider Then
                            If Me.Validate Then
                                BLL.AddNewAccount(2, txtCompanyName.Value, "", "", "", "", 233, txtEmail.Value, "", txtPhoneNo.Value, "", 1, 8, txtADUsername.Value, txtPassword.Value, _
                                                   txtEmail.Value, txtFirstName.Value, txtLastName.Value, "", "", "", False, False, Now.Date, Now.Date, "en-US", txtSubDomain.Text)
                                AfterInsertAccount()
                            Else
                                UIUtilities.ShowMessage("Invalid username or password.", CurrentPage)
                            End If
                        Else
                            BLL.AddNewAccount(2, txtCompanyName.Value, "", "", "", "", 233, txtEmail.Value, "", txtPhoneNo.Value, "", 1, 8, txtEmail.Value, txtPassword.Value, _
                                               txtEmail.Value, txtFirstName.Value, txtLastName.Value, "", "", "", False, False, Now.Date, Now.Date, "en-US", txtSubDomain.Text)
                            AfterInsertAccount()
                        End If
                    End If
                Else
                    UIUtilities.ShowMessage("Specified email already exist.", CurrentPage)
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Function Validate() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL
        Dim username As String = txtADUsername.Value
        Dim password As String = txtPassword.Value

        If LDAP.IsValidUserNameAndPassword(username, password) = True Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Sub AfterInsertAccount()
        If Not Request.QueryString("ApplicationMode") Is Nothing Then
            Dim bll As New AccountBLL
            bll.PostInstalledAccountAdd()
            If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
                If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
                    If UIUtilities.IsAspNetActiveDirectoryMembershipProvider <> True Then
                        Server.Transfer("RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value & "&Password=" & txtPassword.Value, True)
                    Else
                        Server.Transfer("RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value & "&Username=" & txtADUsername.Value & "&Password=" & txtPassword.Value, True)
                    End If

                Else
                    UIUtilities.RedirectToLoginPage()
                End If
            Else
                LoginIn()
            End If
        ElseIf Request.QueryString("Mode") Is Nothing Then
            If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
                'reg_form.Action = "RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value
                If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
                    If UIUtilities.IsAspNetActiveDirectoryMembershipProvider <> True Then
                        Server.Transfer("RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value & "&Password=" & txtPassword.Value, True)
                    Else
                        Server.Transfer("RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value & "&Username=" & txtADUsername.Value & "&Password=" & txtPassword.Value, True)
                    End If
                Else
                    Server.Transfer("RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value & "&Password=" & txtPassword.Value, True)
                End If
                'Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & txtEmail.Value, False)
                'LoginIn(True)
            Else
                LoginIn()
            End If
        ElseIf Not Request.QueryString("Mode") Is Nothing Then
            Dim AccountId As Integer = CType(New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter().GetAccountLastId.Rows(0), TimeLiveDataSet.IdentityQueryRow).LastId

            'Dim LTCustomerBLL As New LTCustomerBLL
            'Dim drLTCustomer As TimeLiveDataSet.LTCustomerRow = LTCustomerBLL.GetLTCustomerByAccountId(AccountId)
            'Dim CustomerId As Integer = drLTCustomer.CustomerId

            EMailUtilities.DequeueEmail()

            Dim PaymentURL As String = LicensingBLL.GetPaymentURL(Me.Request, AccountId)
            Response.Redirect(PaymentURL, False)

        End If
    End Sub
    Public Sub LoginIn(Optional ByVal RedirectToFeaturePage As Boolean = True)
        Dim Username As String = txtEmail.Value
        Dim Password As String = txtPassword.Value
        Dim BLL As New AuthenticateBLL
        If (BLL.AuthenticateLogin(Username, Password)) = True Then
            BLL.LoggedIn(Username, Password)
            If Not RedirectToFeaturePage Then
                If DBUtilities.IsTimeLiveMobileLogin Then
                    Response.Redirect(UIUtilities.RedirectToMobileHomePage())
                Else
                    Response.Redirect(UIUtilities.RedirectToHomePage())
                End If
            Else
                Response.Redirect("~/AccountAdmin/AccountFeatureManagement.aspx", False)
            End If
        End If
    End Sub
    Public Function GetUserData() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL

        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            Dim Username As String = txtADUsername.Value
            Dim Admin As DirectoryEntry = LDAPUtilitiesBLL.GetUserByName(Username)
            If Not Admin Is Nothing Then
                If Admin.Properties("givenname").Count > 0 AndAlso Not Admin.Properties("givenname").Item(0) Is Nothing Then
                    txtFirstName.Value = Admin.Properties("givenname").Item(0)
                End If
                If Admin.Properties("sn").Count > 0 AndAlso Not Admin.Properties("sn").Item(0) Is Nothing Then
                    txtLastName.Value = Admin.Properties("sn").Item(0)
                End If
                If Not Admin.Properties("mail").Count = 0 AndAlso Not Admin.Properties("mail").Item(0) Is Nothing Then
                    txtEmail.Value = Admin.Properties("mail").Item(0)
                End If
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function
    Public Function GetUserGroup() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL

        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            Dim Username As String = txtADUsername.Value
            Dim Admin As DirectoryEntry = LDAPUtilitiesBLL.GetUserByName(Username)
            If Not Admin Is Nothing Then
                If LDAPUtilitiesBLL.IsUserTimeLiveAdministrator(Username) = True Or LDAPUtilitiesBLL.IsOpenLDAPMembershipProvider Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function
    Public Sub ShowUsername()
        Dim LDAP As New LDAPUtilitiesBLL
        If Not LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            txtADUsername.Disabled = True
        End If
    End Sub
    <WebMethod()> _
    Public Shared Function IsSubDomainAvailable(SubDomain As String) As Boolean
        Dim accountbll As New AccountBLL()
        Return accountbll.IsSubDomainExists(SubDomain)
    End Function
    <WebMethod()> _
    Public Shared Function IsEmailAddressAvailable(emailaddress As String) As Boolean
        Dim employee As New AccountEmployeeBLL()
        Return Not employee.ValidateNewEmployee(emailaddress)
    End Function

    Protected Sub btnADUsername_ServerClick(sender As Object, e As System.EventArgs) Handles btnADUsername.ServerClick
        Me.GetUserData()

    End Sub
End Class
