Imports System.DirectoryServices
Imports Microsoft.VisualBasic
Imports System.IO

Namespace TimeLive
    Partial Class ctlLicenseActivation
        Inherits System.Web.UI.UserControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim lblExceptionText As Label
        Dim cvTimesheetPrintFooterargs As Boolean
        Dim cvExpenseSheetPrintFooterargs As Boolean
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me.Page.Title = ResourceHelper.GetFromResource(Me.Page.Title)
            If Not Me.IsPostBack Then
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    If System.Configuration.ConfigurationManager.AppSettings("SHOW_LOGIN_WITH_ACCOUNT_PAGE") = "Yes" Then
                        Response.Redirect("~/Default.aspx", False)
                    End If
                    ShowUsername()

                Else
                    ShowUsername()
                    If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                        lblExceptionText = Me.FormView1.FindControl("ExceptionDetails")
                    End If
                End If
               
            Else
            End If
            AccountPagePermissionBLL.IspageHasRights(121)
            CType(Me.FormView1.FindControl("Literal2"), Literal).Text = ResourceHelper.GetFromResource("Disable Account")
            CType(Me.FormView1.FindControl("Literal5"), Literal).Text = ResourceHelper.GetFromResource("Administrator Username:")
            CType(Me.FormView1.FindControl("Literal6"), Literal).Text = ResourceHelper.GetFromResource("Administrator Password:")
            If System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME") Is Nothing Then
                CType(Me.FormView1.FindControl("Literal3"), Literal).Text = ResourceHelper.GetFromResource("Disabling account will stop any activities in your TimeLive account. Your employee will not be able to login in TimeLive.")
            Else
                Dim C_Name As String = System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME")
                CType(Me.FormView1.FindControl("Literal3"), Literal).Text = "Disabling account will stop any activities in your " & C_Name & " account. Your employee will not be able to login in " & C_Name & "."
            End If
            If LicensingBLL.GetNumberOfUsersAllowed(DBUtilities.GetSessionAccountId) <> "99999" Then
                CType(Me.FormView1.FindControl("btnUpdateExisting"), Button).Visible = LicensingBLL.IsUpgradeExistingPlan
            End If
        End Sub
        Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                Me.FormView1.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(160, 3)
                If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then

                    CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).DataSource = LicensingBLL.GetHostedPackagesOfCurrentUsers
                    CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).DataTextField = "PackageName"
                    CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).DataValueField = "PackageCode"
                    CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = LicensingBLL.GetCurrentHostedPackage
                    CType(Me.FormView1.FindControl("btnRenew"), Button).Visible = LicensingBLL.IsHostedPaidCustomer()
                    CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).DataBind()

                    If New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId).AccountExpiryActivation <> "" Then
                        Dim ExpiryDate As String = GetExpiryDateAsString(New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId).AccountExpiryActivation)
                        CType(Me.FormView1.FindControl("lblExpiryDate"), Label).Text = LicensingBLL.GetAccountExpiryDateFromDateString(ExpiryDate)
                    Else
                        CType(Me.FormView1.FindControl("lblExpiryDate"), Label).Text = Now.Date
                    End If
                    If LicensingBLL.IsHostedPaidCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                        CType(Me.FormView1.FindControl("Label26"), Label).Text = "(Your subscription has been expired. In order to continue using TimeLive, make payment by clicking on """ & "Renew Plan" & """ button.)"
                    End If
                ElseIf System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
                    CType(Me.FormView1.FindControl("btnRenew"), Button).Visible = False

                    If New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId).AccountExpiryActivation <> "" Then
                        Dim ExpiryDate As String = GetExpiryDateAsString(New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId).AccountExpiryActivation)
                        CType(Me.FormView1.FindControl("lblExpiryDateLicense"), Label).Text = LicensingBLL.GetAccountExpiryDateFromDateString(ExpiryDate)
                    Else
                        CType(Me.FormView1.FindControl("lblExpiryDateLicense"), Label).Text = Now.Date
                    End If
                End If

                CType(Me.FormView1.FindControl("MachineNameTextBox"), TextBox).Text = LicensingBLL.GetMachineID


                If Not IsDBNull(Me.FormView1.DataItem("ActivationMachineKey")) Then
                    CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).Text = Me.FormView1.DataItem("ActivationMachineKey")
                End If

                If Not IsDBNull(Me.FormView1.DataItem("ActivationType")) Then
                    If Me.FormView1.DataItem("ActivationType") = "Online Activation" Then
                        CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True
                    ElseIf Me.FormView1.DataItem("ActivationType") = "Manual Activation" Then
                        CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True
                    End If
                Else
                    CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True
                End If
                If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                    CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = True
                End If



                If Not IsDBNull(Me.FormView1.DataItem("ActivationLicenseKey")) Then
                    If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                        CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).Text = Me.FormView1.DataItem("ActivationLicenseKey")
                    ElseIf CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True Then
                        CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).Text = ""
                        CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = True
                    End If
                End If
                If CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True And LicensingBLL.IsValidLicenseActivation() = False Then
                    CType(Me.FormView1.FindControl("lblActivationFailed"), Label).Visible = True
                End If

                If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                    CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = False
                ElseIf CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True Then
                    CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = False
                Else
                    CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = True
                    CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = True
                End If

                CType(Me.FormView1.FindControl("lblNumberofUsers"), Label).Text = New AccountEmployeeBLL().GetEmployeeByAccountIdForLicense(DBUtilities.GetSessionAccountId).Rows.Count & " Out Of " & LicensingBLL.GetNumberOfUsersAllowed(DBUtilities.GetSessionAccountId) & " " & ResourceHelper.GetFromResource("Users")

                CType(Me.FormView1.FindControl("lblNumberOfUsersForHosted"), Label).Text = New AccountEmployeeBLL().GetEmployeeByAccountIdForLicense(DBUtilities.GetSessionAccountId).Rows.Count & " Out Of " & LicensingBLL.GetNumberOfUsersAllowed(DBUtilities.GetSessionAccountId) & " " & ResourceHelper.GetFromResource("Users")
                ''CType(Me.FormView1.FindControl("lblTrialAccount"), Label).Text = "After 30Day Trial your account convert into free lite version"
                Dim LDAP As New LDAPUtilitiesBLL
                If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                    'CType(Me.FormView1.FindControl("RequiredFieldValidator3"), RequiredFieldValidator).Enabled = False
                    'CType(Me.FormView1.FindControl("RangeValidator2"), RangeValidator).Enabled = False
                End If

            End If
        End Sub
        Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
            If Not e.Exception Is Nothing Then
                Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
                lblExceptionText.Visible = True
                lblExceptionText.Text = e.Exception.InnerException.Message
                e.ExceptionHandled = True
                e.KeepInInsertMode = True

            ElseIf Not Request.QueryString("ApplicationMode") Is Nothing Then
                Dim bll As New AccountBLL
                bll.PostInstalledAccountAdd()
                If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
                    If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
                        Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, False)
                    Else
                        UIUtilities.RedirectToLoginPage()
                    End If
                Else
                    LoginIn()
                End If
            ElseIf Request.QueryString("Mode") Is Nothing Then
                If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
                    Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, False)
                Else
                    LoginIn()
                End If
            ElseIf Not Request.QueryString("Mode") Is Nothing Then
                Dim AccountId As Integer = CType(New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter().GetAccountLastId.Rows(0), TimeLiveDataSet.IdentityQueryRow).LastId

                Dim LTCustomerBLL As New LTCustomerBLL
                Dim drLTCustomer As TimeLiveDataSet.LTCustomerRow = LTCustomerBLL.GetLTCustomerByAccountId(AccountId)
                Dim CustomerId As Integer = drLTCustomer.CustomerId

                EMailUtilities.DequeueEmail()

                Dim PaymentURL As String = LicensingBLL.GetPaymentURL(Me.Request, CustomerId)
                Response.Redirect(PaymentURL, False)

            End If

        End Sub
        Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting

        End Sub
        Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated

        End Sub
        Protected Sub dsTimeZone_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)

        End Sub
        Protected Sub cmdActivateSerial_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim ActivationType As String = ""
            If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                If Me.CheckTextBoxValue(CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton), CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox)) = True Then
                    CType(Me.FormView1.FindControl("lblLicenseError"), Label).Visible = True
                    Exit Sub
                End If
                ActivationType = "Online Activation"
            ElseIf CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True Then
                If Me.CheckTextBoxValue(CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton), CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox)) = True Then
                    CType(Me.FormView1.FindControl("lblMachineKeyError"), Label).Visible = True
                    Exit Sub
                End If
                ActivationType = "Manual Activation"
            End If

            Dim LicensingBLL As New LicensingBLL
            If LicensingBLL.ActivateLincese(CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).Text, ActivationType, CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked, CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("MachineNameTextBox"), TextBox).Text) = True Then
                Me.ShowLicenseActivationMessage(ResourceHelper.GetFromResource("License Activated Successfully."))
            Else
                Me.ShowLicenseActivationMessage("Unable To Activate License")
            End If

        End Sub
        Public Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating


        End Sub
        Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        End Sub
        Public Function Validate() As Boolean
            Dim LDAP As New LDAPUtilitiesBLL
            Dim username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
            Dim password As String = CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text

            If LDAP.IsValidUserNameAndPassword(username, password) = True Then
                Return True
            Else
                Return False
            End If

        End Function
        Public Sub ShowUsername()
            Dim LDAP As New LDAPUtilitiesBLL
            If Not LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).ReadOnly = True
                End If
            End If
        End Sub
        Protected Sub UsernameTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.GetUserData()
        End Sub
        Public Function GetUserData() As Boolean
            Dim LDAP As New LDAPUtilitiesBLL

            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                Dim Username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
                Dim Admin As DirectoryEntry = LDAPUtilitiesBLL.GetUserByName(Username)
                If Not Admin Is Nothing Then
                    If Admin.Properties("givenname").Count > 0 AndAlso Not Admin.Properties("givenname").Item(0) Is Nothing Then
                        CType(Me.FormView1.FindControl("FirstNameTextBox"), TextBox).Text = Admin.Properties("givenname").Item(0)
                    End If
                    If Admin.Properties("sn").Count > 0 AndAlso Not Admin.Properties("sn").Item(0) Is Nothing Then
                        CType(Me.FormView1.FindControl("LastNameTextBox"), TextBox).Text = Admin.Properties("sn").Item(0)
                    End If
                    If Not Admin.Properties("mail").Count = 0 AndAlso Not Admin.Properties("mail").Item(0) Is Nothing Then
                        CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text = Admin.Properties("mail").Item(0)
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
                Dim Username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
                Dim Admin As DirectoryEntry = LDAPUtilitiesBLL.GetUserByName(Username)
                If Not Admin Is Nothing Then
                    If LDAPUtilitiesBLL.IsUserTimeLiveAdministrator(Username) = True Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        End Function
        Protected Sub CustomValidator2_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            Dim LDAP As New LDAPUtilitiesBLL
            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                args.IsValid = Me.GetUserGroup = True
            End If
        End Sub
        Protected Sub CustomValidatorInsert_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            Dim LDAP As New LDAPUtilitiesBLL

            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                args.IsValid = Me.Validate = True
            End If
        End Sub
        Protected Sub EmployeeEMailAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub
        Protected Sub btnChangePlanTo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                LicensingBLL.ChangeHostedPlan(CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue)
            End If
        End Sub
        Public Sub ForRenewal(ByVal drAccount As TimeLiveDataSet.AccountRow)
            If CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 1 Then
                Dim bll As New AccountBLL
                bll.UpdateLicenseKey("TLHL", DBUtilities.GetSessionAccountId)
            ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 5 Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & drAccount.LicenseId, False)
            ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 10 Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & drAccount.LicenseId, False)
            ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 15 Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & drAccount.LicenseId, False)
            End If
        End Sub
        Public Function GetPackage() As Integer
            Dim BLL As New AccountBLL
            Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)

            If IsDBNull(dr.Item("SystemPackageTypeId")) OrElse dr.Item("SystemPackageTypeId") = 1 Then
                Return 1
            ElseIf dr.Item("SystemPackageTypeId") = 5 Then
                Return 5
            ElseIf dr.Item("SystemPackageTypeId") = 10 Then
                Return 10
            ElseIf dr.Item("SystemPackageTypeId") = 15 Then
                Return 15
            End If

            Return Nothing

        End Function
        Public Function GetExpiryDateAsString(ByVal dtDate As String) As String

            Return LicensingBLL.GetStringFromEncryptedValue(dtDate)
        End Function
        Public Sub ShowLicenseActivationMessage(ByVal message As String)
            Dim strMessage As String = message
            Dim strScript As String = "alert('" & strMessage & "'); window.location = 'AdminMain.aspx';"
            If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
            End If
        End Sub
        Protected Sub rdManualActivation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True Then
                CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = False
                CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = True
            End If
        End Sub
        Protected Sub rdOnlineActivation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = True
                CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = False
            End If
        End Sub
        Public Function CheckTextBoxValue(ByVal checkbox As CheckBox, ByVal textbox As TextBox) As Boolean
            If checkbox.Checked = True And textbox.Text = "" Then
                Return True
            End If
        End Function
        Protected Sub btnRenew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim BLL As New AccountBLL
            Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
            If Not IsDBNull(dr.Item("LicenseId")) Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & dr.Item("LicenseId"), False)
            End If
        End Sub
        Public Sub LoginIn()
            Dim Username As String = CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text
            Dim Password As String = CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text
            Dim BLL As New AuthenticateBLL
            BLL.AuthenticateLogin(Username, Password)
            BLL.LoggedIn(Username, Password)
            If DBUtilities.IsTimeLiveMobileLogin Then
                Response.Redirect(UIUtilities.RedirectToMobileHomePage())
            Else
                Response.Redirect(UIUtilities.RedirectToHomePage())
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

        Protected Sub btnDisabled_Click(sender As Object, e As System.EventArgs)
            CType(Me.FormView1.FindControl("Label2"), Label).Visible = False
            Dim Password As String = CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text
            Dim MembershipProvider As New CustomProviders.LiveMembershipProvider
            Password = MembershipProvider.EncodePassword(Password)

            Dim dt As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetViewAccountEmployeesByUsernameAndPassword(CType(Me.FormView1.FindControl("UserNameTextBox"), TextBox).Text, Password)
            Dim dr As AccountEmployee.vueAccountEmployeeRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                Call New AccountBLL().UpdateIsDisableForAccountClosed(dr.AccountId)
                Call New AccountEmployeeBLL().UpdateIsDisableForAccountClosed(dr.AccountId)
                Call New AccountEMailNotificationPreferenceBLL().UpdateEnableForAccountDisable(dr.AccountId)
                Call New AccountEmployeeBLL().UpdateEmailAddressAndUserNameForAccountClosed(dr.AccountId)
                Me.ShowAccountDisabledMessage()
            Else
                CType(Me.FormView1.FindControl("Label2"), Label).Visible = True
            End If
        End Sub

        Protected Sub btnUpdateExisting_Click(sender As Object, e As System.EventArgs)
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                LicensingBLL.ChangeUpdateExistingPlan(CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue)
            End If
        End Sub
    End Class
End Namespace
