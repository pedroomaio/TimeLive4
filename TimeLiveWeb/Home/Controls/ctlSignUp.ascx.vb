Imports System.DirectoryServices
Namespace TimeLive
    Partial Class ctlSignUp
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
                    Me.dsAccountRoleObjectInsert.SelectParameters("AccountId").DefaultValue = CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue
                    ShowUsername()
                    CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue = DBUtilities.GetTimeZoneId
                    CType(Me.FormView1.FindControl("ddlCountryId"), DropDownList).SelectedValue = DBUtilities.GetAccountCountryId
                Else
                    ShowUsername()
                    If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                        lblExceptionText = Me.FormView1.FindControl("ExceptionDetails")
                    End If
                End If
            Else
                If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                    CType(Me.FormView1.FindControl("lblLicenseError"), Label).Visible = False
                    CType(Me.FormView1.FindControl("lblMachineKeyError"), Label).Visible = False
                End If
            End If
        End Sub
        Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                Me.FormView1.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(91, 3)
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
                ElseIf System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
                    CType(Me.FormView1.FindControl("btnRenew"), Button).Visible = False
                    If New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId).AccountExpiryActivation <> "" Then
                        Dim ExpiryDate As String = GetExpiryDateAsString(New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId).AccountExpiryActivation)
                        CType(Me.FormView1.FindControl("lblExpiryDateLicense"), Label).Text = LicensingBLL.GetAccountExpiryDateFromDateString(ExpiryDate)
                    Else
                        CType(Me.FormView1.FindControl("lblExpiryDateLicense"), Label).Text = Now.Date
                    End If
                End If
                CType(Me.FormView1.FindControl("MaskedEditExtenderTPScheduledEmailSendTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                If DBUtilities.IsNotSupportedCultureFormats = True Then
                    DBUtilities.SetMaskEditExtenderCultureToUS(Me.FormView1.FindControl("MaskedEditExtenderTPScheduledEmailSendTime"))
                    CType(Me.FormView1.FindControl("TPScheduledEmailSendTime"), TextBox).Text = DBUtilities.GetTimeFromDateTimeInUSCulture(LocaleUtilitiesBLL.ShowScheduledEmailSendTime)
                End If


                CType(Me.FormView1.FindControl("CultureInfoName"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetCurrentCulture
                CType(Me.FormView1.FindControl("CurrencySymbol"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetCurrencySymbol
                CType(Me.FormView1.FindControl("ddlTimeEntryFormat"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetCurrentTimeEntryFormat
                CType(Me.FormView1.FindControl("SessionTimeOutTextBox"), TextBox).Text = LocaleUtilitiesBLL.GetCurrentSessionTimeout
                CType(Me.FormView1.FindControl("chkShowCompletedTasksInTimeSheet"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet
                CType(Me.FormView1.FindControl("chkShowCompletedProjectsInTimeSheet"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet
                CType(Me.FormView1.FindControl("chkShowWorkTypeInTimeSheet"), CheckBox).Checked = DBUtilities.IsShowWorkTypeInTimeSheet
                CType(Me.FormView1.FindControl("chkShowCostCenterInTimeSheet"), CheckBox).Checked = DBUtilities.IsShowCostCenterInTimeSheet
                CType(Me.FormView1.FindControl("chkIsShowCompanyOwnLogo"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowCompanyOwnLogo
                If DBUtilities.IsNotSupportedCultureFormats <> True Then
                    If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = False Then
                        CType(Me.FormView1.FindControl("TPScheduledEmailSendTime"), TextBox).Text = DBUtilities.GetTimeFromDateTime(LocaleUtilitiesBLL.ShowScheduledEmailSendTime, LocaleUtilitiesBLL.GetCurrentTimeEntryFormatForTotalTime)
                    Else
                        CType(Me.FormView1.FindControl("TPScheduledEmailSendTime"), TextBox).Text = DBUtilities.GetTimeFromDateTime(LocaleUtilitiesBLL.ShowScheduledEmailSendTime)
                    End If
                End If
                CType(Me.FormView1.FindControl("FromEmailAddressDisplayNameTextBox"), TextBox).Text = DBUtilities.GetFromEmailAddressDisplayName
                CType(Me.FormView1.FindControl("txtTimesheetPrintFooter"), TextBox).Text = DBUtilities.GetTimesheetPrintFooter
                CType(Me.FormView1.FindControl("txtExpenseSheetPrintFooter"), TextBox).Text = DBUtilities.GetExpenseSheetPrintFooter
                CType(Me.FormView1.FindControl("FromEmailAddressTextBox"), TextBox).Text = DBUtilities.GetFromEmailAddress
                CType(Me.FormView1.FindControl("chkLockSubmittedRecord"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
                CType(Me.FormView1.FindControl("chkLockApprovedRecord"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowLockApprovedRecords
                CType(Me.FormView1.FindControl("txtNumberOfBlankRowsInTimeEntry"), TextBox).Text = DBUtilities.GetNumberOfBlankRowsInTimeEntry
                'CType(Me.FormView1.FindControl("ddlWeekStartDay"), DropDownList).SelectedValue = DBUtilities.GetWeekStartDayInWeekTimeEntry
                'CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetSavedCurrentUICulture
                CType(Me.FormView1.FindControl("ddlDefaultTimeEntryMode"), DropDownList).SelectedValue = DBUtilities.GetDefaultTimeEntryMode
                CType(Me.FormView1.FindControl("ddlTimesheetSort"), DropDownList).SelectedValue = DBUtilities.GetSortTimesheet
                CType(Me.FormView1.FindControl("ddlCostCenterInTimesheetBy"), DropDownList).SelectedValue = DBUtilities.GetCostCenterInTimesheetBy
                CType(Me.FormView1.FindControl("ddlPageSize"), DropDownList).SelectedValue = DBUtilities.GetPageSize
                CType(Me.FormView1.FindControl("chkShowClientInTimeSheet"), CheckBox).Checked = DBUtilities.GetShowClientInTimesheet
                CType(Me.FormView1.FindControl("chkShowDescriptionInWeekView"), CheckBox).Checked = DBUtilities.GetShowDescriptionInWeekView
                CType(Me.FormView1.FindControl("InvoiceNoPrefixTextBox"), TextBox).Text = DBUtilities.GetInvoiceNoPrefix
                'CType(Me.FormView1.FindControl("ProjectCodePrefixTextBox"), TextBox).Text = DBUtilities.GetProjectCodePrefix
                CType(Me.FormView1.FindControl("MachineNameTextBox"), TextBox).Text = LicensingBLL.GetMachineID
                CType(Me.FormView1.FindControl("chkShowProjectForTimeOff"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowProjectForTimeOff
                CType(Me.FormView1.FindControl("chkShowTimeOffInTimesheet"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowTimeOffInTimesheet
                CType(Me.FormView1.FindControl("chkShowElectronicSign"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowElectronicSign
                CType(Me.FormView1.FindControl("chkShowAllInTimesheetReadOnly"), CheckBox).Checked = LocaleUtilitiesBLL.ShowAllInTimesheetReadOnly
                CType(Me.FormView1.FindControl("chkShowCompletedProjectInProjectGrid"), CheckBox).Checked = LocaleUtilitiesBLL.ShowCompletedProjectInProjectGrid
                CType(Me.FormView1.FindControl("chkShowPercentageInTimeSheet"), CheckBox).Checked = LocaleUtilitiesBLL.ShowPercentageInTimesheet
                CType(Me.FormView1.FindControl("chkShowCopyTimesheetButton"), CheckBox).Checked = DBUtilities.ShowCopyTimesheetButton
                CType(Me.FormView1.FindControl("chkShowCopyActivitiesButtonInTimesheet"), CheckBox).Checked = DBUtilities.ShowCopyActivitiesButtonInTimesheet
                CType(Me.FormView1.FindControl("chkShowTaskInExpenseSheet"), CheckBox).Checked = LocaleUtilitiesBLL.ShowTaskInExpenseSheet
                CType(Me.FormView1.FindControl("chkShowBillingRateInInvoiceReport"), CheckBox).Checked = LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport
                CType(Me.FormView1.FindControl("chkShowProjectNameInInvoiceReport"), CheckBox).Checked = LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport
                CType(Me.FormView1.FindControl("chkShowEntryDateInInvoiceReport"), CheckBox).Checked = DBUtilities.ShowEntryDateInInvoiceReport
                CType(Me.FormView1.FindControl("chkShowEmployeeNameInInvoiceReport"), CheckBox).Checked = LocaleUtilitiesBLL.ShowEmployeeNameInInvoiceReport
                CType(Me.FormView1.FindControl("chkEnablePasswordComplexity"), CheckBox).Checked = DBUtilities.EnablePasswordComplexity
                CType(Me.FormView1.FindControl("chkShowClientDepartmentInProject"), CheckBox).Checked = DBUtilities.ShowClientDepartmentInProject
                CType(Me.FormView1.FindControl("chkAutoGenerateProjectCode"), CheckBox).Checked = LocaleUtilitiesBLL.AutoGenerateProjectCode
                CType(Me.FormView1.FindControl("txtInvoiceFooter"), TextBox).Text = DBUtilities.GetInvoiceFooter
                CType(Me.FormView1.FindControl("txtTimesheetOverduePeriods"), TextBox).Text = DBUtilities.GetSessionTimesheetOverduePeriods
                CType(Me.FormView1.FindControl("ddlTimeEntryHoursFormatId"), DropDownList).SelectedValue = DBUtilities.GetSessionTimeEntryHoursFormat.ToString
                CType(Me.FormView1.FindControl("ddlInvoiceBillingTypeId"), DropDownList).SelectedValue = DBUtilities.GetSessionInvoiceBillingType.ToString
                CType(Me.FormView1.FindControl("chkShowProjectNameInTask"), CheckBox).Checked = LocaleUtilitiesBLL.ShowProjectNameInTask
                CType(Me.FormView1.FindControl("chkShowClientNameInTask"), CheckBox).Checked = LocaleUtilitiesBLL.ShowClientNameInTask
                CType(Me.FormView1.FindControl("chkCalculateTaskPercentageAutomatically"), CheckBox).Checked = LocaleUtilitiesBLL.EnableCalculateTaskPercentageAutomatically

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
                CType(Me.FormView1.FindControl("ddlTaskInformation"), DropDownList).SelectedValue = DBUtilities.GetShowAdditionalTaskInformationType
                CType(Me.FormView1.FindControl("txtPasswordExpiryPeriod"), TextBox).Text = DBUtilities.GetPasswordExpiryPeriod
                Dim LDAP As New LDAPUtilitiesBLL
                If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                    CType(Me.FormView1.FindControl("RequiredFieldValidator3"), RequiredFieldValidator).Enabled = False
                    CType(Me.FormView1.FindControl("RangeValidator2"), RangeValidator).Enabled = False
                End If
            End If
        End Sub
        Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
            ''If Not e.Exception Is Nothing Then
            ''    Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            ''    lblExceptionText.Visible = True
            ''    lblExceptionText.Text = e.Exception.InnerException.Message
            ''    e.ExceptionHandled = True
            ''    e.KeepInInsertMode = True

            ''ElseIf Not Request.QueryString("ApplicationMode") Is Nothing Then
            ''    Dim bll As New AccountBLL
            ''    bll.PostInstalledAccountAdd()
            ''    If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
            ''        If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
            ''            Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, False)
            ''        Else
            ''            UIUtilities.RedirectToLoginPage()
            ''        End If
            ''    Else
            ''        LoginIn()
            ''    End If
            ''ElseIf Request.QueryString("Mode") Is Nothing Then
            ''    If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
            ''        Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, False)
            ''    Else
            ''        LoginIn()
            ''    End If
            ''ElseIf Not Request.QueryString("Mode") Is Nothing Then
            ''    Dim AccountId As Integer = CType(New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter().GetAccountLastId.Rows(0), TimeLiveDataSet.IdentityQueryRow).LastId

            ''    Dim LTCustomerBLL As New LTCustomerBLL
            ''    Dim drLTCustomer As TimeLiveDataSet.LTCustomerRow = LTCustomerBLL.GetLTCustomerByAccountId(AccountId)
            ''    Dim CustomerId As Integer = drLTCustomer.CustomerId

            ''    EMailUtilities.DequeueEmail()

            ''    Dim PaymentURL As String = LicensingBLL.GetPaymentURL(Me.Request, CustomerId)
            ''    Response.Redirect(PaymentURL, False)

            ''    End If
        End Sub
        Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
            

        End Sub
        Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
            System.Web.HttpContext.Current.Session.Remove("RootNode")
            UIUtilities.RedirectToAdminHomePage()
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
            Dim BLL As New AccountBLL
            BLL.FileUpload(Me.FormView1.FindControl("txtCompanyLogo"))
            BLL.UpdateIsCompanyOwnLogo(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("chkIsShowCompanyOwnLogo"), CheckBox).Checked)
            UIUtilities.RedirectToAdminHomePage()
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
            Dim strScript As String = "alert('" & strMessage & "'); window.location = 'AccountPreferences.aspx';"
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
        Protected Sub btnUpdatePrintInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If cvExpenseSheetPrintFooterargs <> False Or CType(Me.FormView1.FindControl("txtExpenseSheetPrintFooter"), TextBox).Text = "" Then
                UpdatePrintInfo()
            End If
        End Sub
        Public Sub UpdatePrintInfo()
            Dim BLL As New AccountBLL
            BLL.btnUpdatePrintInfo(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("chkShowTaskInExpenseSheet"), CheckBox).Checked, CType(Me.FormView1.FindControl("txtExpenseSheetPrintFooter"), TextBox).Text, False)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateInvoiceInfo()
            Dim BLL As New AccountBLL
            Dim InvoiceBillingTypeId As Guid = New Guid(CType(Me.FormView1.FindControl("ddlInvoiceBillingTypeId"), DropDownList).SelectedValue)
            BLL.btnUpdateInvoiceInfo(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("InvoiceNoPrefixTextBox"), TextBox).Text, InvoiceBillingTypeId, CType(Me.FormView1.FindControl("chkShowBillingRateInInvoiceReport"), CheckBox).Checked, CType(Me.FormView1.FindControl("txtInvoiceFooter"), TextBox).Text, CType(Me.FormView1.FindControl("chkShowProjectNameInInvoiceReport"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowEntryDateInInvoiceReport"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowEmployeeNameInInvoiceReport"), CheckBox).Checked, False, False, False)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateProjectInfo()
            Dim BLL As New AccountBLL
            BLL.btnUpdateProjectInfo(DBUtilities.GetSessionAccountId, " ", CType(Me.FormView1.FindControl("chkAutoGenerateProjectCode"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowClientDepartmentInProject"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowCompletedProjectInProjectGrid"), CheckBox).Checked, False, False, False)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateTaskInfo()
            Dim BLL As New AccountBLL
            BLL.btnUpdateTaskInfo(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("chkShowProjectNameInTask"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowClientNameInTask"), CheckBox).Checked, False, "", "")
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateTimeOff()
            Dim BLL As New AccountBLL
            BLL.btnUpdateTimeOff(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("chkShowProjectForTimeOff"), CheckBox).Checked, "", False, CType(Me.FormView1.FindControl("chkShowTimeOffInTimesheet"), CheckBox).Checked, False)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateTimesheetSetup()
            Dim BLL As New AccountBLL
            Dim TimeEntryHoursFormat As Guid
            Dim ShowClockStartEnd As Boolean
            If Not CType(Me.FormView1.FindControl("ddlTimeEntryHoursFormatId"), DropDownList).SelectedValue = "None" Then
                TimeEntryHoursFormat = New Guid(CType(Me.FormView1.FindControl("ddlTimeEntryHoursFormatId"), DropDownList).SelectedValue)
            Else
                TimeEntryHoursFormat = System.Guid.Empty
            End If
            If CType(Me.FormView1.FindControl("chkShowPercentageInTimesheet"), CheckBox).Checked = True And CType(Me.FormView1.FindControl("ddlTimeEntryHoursFormatId"), DropDownList).SelectedValue <> "074187eb-81d9-4e06-8e70-db7bc0c53784" Or CType(Me.FormView1.FindControl("ddlTimeEntryHoursFormatId"), DropDownList).SelectedValue = "EE9CB3B1-E1A1-4346-B9FC-A3DA1C92A45E".ToLower Then
                ShowClockStartEnd = False
            Else
                ShowClockStartEnd = CType(Me.FormView1.FindControl("chkShowClockStartEnd"), CheckBox).Checked
            End If
            If cvTimesheetPrintFooterargs <> False Or CType(Me.FormView1.FindControl("txtTimesheetPrintFooter"), TextBox).Text = "" Then
                BLL.UpdateTimesheetSetup(DBUtilities.GetSessionAccountId, ShowClockStartEnd, CType(Me.FormView1.FindControl("chkShowClientInTimesheet"), CheckBox).Checked, _
                                         CType(Me.FormView1.FindControl("chkShowDescriptionInWeekView"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowCompletedProjectsInTimeSheet"), CheckBox).Checked, _
                                         CType(Me.FormView1.FindControl("chkShowCompletedTasksInTimeSheet"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowWorkTypeInTimesheet"), CheckBox).Checked, _
                                         CType(Me.FormView1.FindControl("chkShowCostCenterInTimesheet"), CheckBox).Checked, _
                                         CType(Me.FormView1.FindControl("chkShowAllInTimesheetReadOnly"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkShowPercentageInTimesheet"), CheckBox).Checked, _
                                         CType(Me.FormView1.FindControl("txtNumberOfBlankRowsInTimeEntry"), TextBox).Text, _
                                         CType(Me.FormView1.FindControl("txtTimesheetOverduePeriods"), TextBox).Text, TimeEntryHoursFormat, CType(Me.FormView1.FindControl("ddlTimeEntryFormat"), DropDownList).SelectedValue, _
                                         CType(Me.FormView1.FindControl("ddlTaskInformation"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("ddlDefaultTimeEntryMode"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("txtTimesheetPrintFooter"), TextBox).Text, _
                                         CType(Me.FormView1.FindControl("ddlTimesheetSort"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("ddlCostCenterInTimesheetBy"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("chkShowCopyActivitiesButtonInTimesheet"), CheckBox).Checked, _
                                         CType(Me.FormView1.FindControl("chkShowCopyTimesheetButton"), CheckBox).Checked, CType(Me.FormView1.FindControl("chkCalculateTaskPercentageAutomatically"), CheckBox).Checked, False, False, False, False, 1)
                UIUtilities.RedirectToAdminHomePage()
            End If
        End Sub
        Protected Sub cvTimesheetPrintFooter_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            If CType(Me.FormView1.FindControl("txtTimesheetPrintFooter"), TextBox).Text.Length > 2000 Then
                args.IsValid = False
                cvTimesheetPrintFooterargs = False
            Else
                args.IsValid = True
                cvTimesheetPrintFooterargs = True
            End If
        End Sub
        Protected Sub cvExpenseSheetPrintFooter_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            If CType(Me.FormView1.FindControl("txtExpenseSheetPrintFooter"), TextBox).Text.Length > 2000 Then
                args.IsValid = False
                cvExpenseSheetPrintFooterargs = False
            Else
                args.IsValid = True
                cvExpenseSheetPrintFooterargs = True
            End If
        End Sub
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
        Protected Sub btnInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            UpdateInvoiceInfo()
        End Sub
        Protected Sub btnUpdateProjectInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateProjectInfo()
        End Sub

        Protected Sub btnApplicationPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        End Sub
        Protected Sub btnUpdateTimesheetSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateTimesheetSetup()
        End Sub
        Protected Sub btnUpdateTimeOff_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateTimeOff()
        End Sub
        Protected Sub btnUpdateTaskInfo_Click(sender As Object, e As System.EventArgs)
            Me.UpdateTaskInfo()
        End Sub
        Protected Sub Button1_Click(sender As Object, e As System.EventArgs)
            Dim EmployeeBll As New AccountEmployeeBLL
            Dim RoleBll As New AccountRoleBLL
            Dim LocationBll As New AccountLocationBLL
            Dim EmployeeTypeBll As New AccountEmployeeTypeBLL
            Dim statusBll As New AccountStatusBLL
            Dim WorkingDayBll As New AccountWorkingDayTypeBLL
            Dim BillingTypeBll As New AccountBillingTypeBLL
            Dim CurrencyBll As New AccountCurrencyBLL

            Dim RoleId As Integer
            Dim DepartmentId As Integer
            Dim LocationId As Integer
            Dim EmployeeTypeId As Guid
            Dim StatusId As Integer
            Dim WorkingDayTypeId As Guid
            Dim BillingTypeId As Integer
            Dim CurrencyId As Integer
            '''''
            Dim DepartmentBll As New AccountDepartmentBLL
            Dim dtrole As TimeLiveDataSet.AccountRoleDataTable = RoleBll.GetAccountRolesByAccountIdAndMasterAccountRoleId(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue, 2)
            Dim drrole As TimeLiveDataSet.AccountRoleRow
            If dtrole.Rows.Count > 0 Then
                drrole = dtrole.Rows(0)
                RoleId = drrole.AccountRoleId
            End If
            '''''
            Dim dtDepartment As TimeLiveDataSet.AccountDepartmentDataTable = DepartmentBll.GetAccountDepartmentsByAccountId(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue)
            Dim drDepartment As TimeLiveDataSet.AccountDepartmentRow
            If dtDepartment.Rows.Count > 0 Then
                drDepartment = dtDepartment.Rows(0)
                DepartmentId = drDepartment.AccountDepartmentId
            End If
            '''''''
            Dim dtLocation As TimeLiveDataSet.AccountLocationDataTable = LocationBll.GetAccountLocationsByAccountId(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue)
            Dim drLocation As TimeLiveDataSet.AccountLocationRow
            If dtLocation.Rows.Count > 0 Then
                drLocation = dtLocation.Rows(0)
                LocationId = drLocation.AccountLocationId
            End If
            ''''''
            Dim MasterEmployeeTypeId As New Guid("E13DBA1D-E94A-45A2-B9FE-0281217D4EF5")
            Dim dtemployeetype As AccountEmployeeType.AccountEmployeeTypeDataTable = EmployeeTypeBll.GetAccountEmployeeTypeByAccountIdAndMasterEmployeeTypeId(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue, MasterEmployeeTypeId)
            Dim dremployeetype As AccountEmployeeType.AccountEmployeeTypeRow
            If dtemployeetype.Rows.Count > 0 Then
                dremployeetype = dtemployeetype.Rows(0)
                EmployeeTypeId = dremployeetype.AccountEmployeeTypeId
            End If
            ''''
            Dim dtstatus As TimeLiveDataSet.AccountStatusDataTable = statusBll.GetAccountStatusForEmployeesByAccountId(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue)
            Dim drstatus As TimeLiveDataSet.AccountStatusRow
            If dtstatus.Rows.Count > 0 Then
                drstatus = dtstatus.Rows(0)
                StatusId = drstatus.AccountStatusId
            End If
            '''''
            Dim MasterWorkingDayTypeId As New Guid("06DDC13D-7195-489D-A7E7-935567B7A285")
            Dim dtworkingday As AccountWorkingDayType.AccountWorkingDayTypeDataTable = WorkingDayBll.GetAccountWorkingDayTypeByMasterWorkingDayTypeIdAndAccountId(MasterWorkingDayTypeId, CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue)
            Dim drworkingday As AccountWorkingDayType.AccountWorkingDayTypeRow
            If dtworkingday.Rows.Count > 0 Then
                drworkingday = dtworkingday.Rows(0)
                WorkingDayTypeId = drworkingday.AccountWorkingDayTypeId
            End If
            '''
            Dim dtBillingType As TimeLiveDataSet.AccountBillingTypeDataTable = BillingTypeBll.GetBillingTypeByAccountId(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue)
            Dim drBillingType As TimeLiveDataSet.AccountBillingTypeRow
            If dtBillingType.Rows.Count > 0 Then
                drBillingType = dtBillingType.Rows(0)
                BillingTypeId = drBillingType.AccountBillingTypeId
            End If
            '''''
            Dim dtCurrency As AccountCurrency.vueAccountCurrencyDataTable = CurrencyBll.GetDataByAccountIdforBaseCurrency(CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue)
            Dim drCurrency As AccountCurrency.vueAccountCurrencyRow
            If dtCurrency.Rows.Count > 0 Then
                drCurrency = dtCurrency.Rows(0)
                CurrencyId = drCurrency.AccountCurrencyId
            End If

            Dim dtemployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBll.GetAccountEmployeeIdByEmailAddress(CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text)
            If dtemployee.Rows.Count <> 0 Then
                CType(Me.FormView1.FindControl("lblExceptionText"), Label).Text = "Specified email address already exist"
                CType(Me.FormView1.FindControl("lblExceptionText"), Label).Visible = True
                Exit Sub
            End If

            EmployeeBll.AddAccountEmployee(CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("FirstNameTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("LastNameTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, "", CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue, DepartmentId, CType(Me.FormView1.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, LocationId, CType(Me.FormView1.FindControl("ddlCountryId"), DropDownList).SelectedValue, BillingTypeId, Now.Date, 0, 0, CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue, 0, 0, EmployeeTypeId, StatusId, "", Now.Date, Now.Date, WorkingDayTypeId, System.Guid.Empty, 0, System.Guid.Empty, False, "en-US", "", "", "", "", "", "", "", "", "", "", False, "", "", True, "", "", "", " ", "", "", "", "", "", "", "", "", "")
            UIUtilities.RedirectToLoginPage()
        End Sub

        Protected Sub FormView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.FormViewPageEventArgs) Handles FormView1.PageIndexChanging

        End Sub

        Protected Sub DropDownList4_SelectedIndexChanged(sender As Object, e As System.EventArgs)
            Me.dsAccountRoleObjectInsert.SelectParameters("AccountId").DefaultValue = CType(Me.FormView1.FindControl("DropDownList4"), DropDownList).SelectedValue
        End Sub
    End Class
End Namespace
