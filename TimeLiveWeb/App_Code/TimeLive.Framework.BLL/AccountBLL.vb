Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountEmployeeTableAdapters
Imports AccountPreferencesTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountBLL
    Dim IsPasswordChanged As Boolean
    Private _AccountTableAdapter As AccountTableAdapter = Nothing
    Private _vueAccountTableAdapter As vueAccountTableAdapter = Nothing
    Private _AccountPreferencesTableAdapter As AccountPreferencesTableAdapter = Nothing
    Private _AccountEmployeeTableAdapter As AccountEmployeeTableAdapter = Nothing


    Public Const VERSION_START = "2.51.0001"
    Public Const VERSION_PASSWORD_ENCRYPTION = "2.61.0001"

    Protected ReadOnly Property Adapter() As AccountTableAdapter
        Get
            If _AccountTableAdapter Is Nothing Then
                _AccountTableAdapter = New AccountTableAdapter()
            End If

            Return _AccountTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountTableAdapter
        Get
            If _vueAccountTableAdapter Is Nothing Then
                _vueAccountTableAdapter = New vueAccountTableAdapter()
            End If

            Return _vueAccountTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountPreferencesTableAdapter() As AccountPreferencesTableAdapter
        Get
            If _AccountPreferencesTableAdapter Is Nothing Then
                _AccountPreferencesTableAdapter = New AccountPreferencesTableAdapter()
            End If

            Return _AccountPreferencesTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccounts() As TimeLiveDataSet.AccountDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountDataTable
        Return Me.Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountViewAsAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountDataTable
        Return Me.vueAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRow
        Return Adapter.GetDataByAccountId(AccountId).rows(0)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPreferencesByAccountId(ByVal AccountId As Integer) As AccountPreferences.AccountPreferencesDataTable
        Return AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataBySubDomain(ByVal SubDomain As String) As TimeLiveDataSet.AccountDataTable
        Return Me.Adapter.GetDataBySubDomain(SubDomain)
    End Function
    Public Function IsSubDomainExists(SubDomain As String) As Boolean
        If Me.GetDataBySubDomain(SubDomain).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccount(ByVal AccountTypeId As System.Nullable(Of Short), _
                    ByVal AccountName As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal ZipCode As String, _
                    ByVal City As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal EMailAddress As String, _
                    ByVal EmployeeCode As String, _
                    ByVal Telephone As String, _
                    ByVal Fax As String, _
                    ByVal DefaultCurrencyId As System.Nullable(Of Short), _
                    ByVal TimeZoneId As System.Nullable(Of Byte), _
                    ByVal EmployeeLogin As String, _
                    ByVal EmployeePassword As String, _
                    ByVal EmployeeEMailAddress As String, _
                    ByVal EmployeeFirstName As String, _
                    ByVal EmployeeLastName As String, _
                    ByVal EmployeePrefix As String, _
                    ByVal EmployeeMiddleName As String, _
                    ByVal State As String, _
                    ByVal IsDisabled As Boolean, _
                    ByVal IsDeleted As Boolean, _
                    ByVal CreatedOn As DateTime, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal UserInterfaceLanguage As String, _
                    Optional ByVal SubDomain As String = "" _
                    ) As Boolean

        Try

            LocaleUtilitiesBLL.SetCurrentThreadCulture(UserInterfaceLanguage)

            If Not New AccountEmployeeBLL().ValidateNewEmployee(EmployeeEMailAddress) Then
                Throw New Exception("Specified email address already exist")
                Return False
            End If

            ' Create a new ProductRow instance
            Dim NewAccountId As Integer
            NewAccountId = Adapter.InsertAccount(2, AccountName, Address1, Address2, ZipCode, State, City, CInt(CountryId), EMailAddress, Telephone, Fax, CInt(DefaultCurrencyId), False, False, 1, Date.Now, Date.Now, TimeZoneId, Me.GetExpiryString(), UIUtilities.IsTrakLiveApplication(), SubDomain)


            Dim objDepartments As New AccountDepartmentBLL
            Dim nNewDepartmentId As Integer = objDepartments.AddAccountDepartment(NewAccountId, ResourceHelper.GetDefaultDataLocalValue("Default"), ResourceHelper.GetDefaultDataLocalValue("Default Department"), 0, 0)
            _AccountEmployeeTableAdapter = New AccountEmployeeTableAdapter()
            Dim nAccountRoleId As Integer

            Dim objAccountRoles As New AccountRoleBLL
            nAccountRoleId = objAccountRoles.InsertDefault(NewAccountId, 0, UserInterfaceLanguage)

            _AccountEmployeeTableAdapter = New AccountEmployeeTableAdapter()

            Dim objAccountLocations As New AccountLocationBLL
            Dim nAccountLocationId As Integer = objAccountLocations.AddAccountLocation(NewAccountId, ResourceHelper.GetDefaultDataLocalValue("Default Location"), 0, 0)

            Dim objEmployeeType As New AccountEmployeeTypeBLL
            Dim nAccountEmployeeTypeId As Guid = objEmployeeType.InsertDefault(NewAccountId, 0, UserInterfaceLanguage)
            Dim objAccountStatus As New AccountStatusBLL
            Dim nEmployeeStatusId As Integer = objAccountStatus.InsertDefault(NewAccountId, UserInterfaceLanguage)
            Call New AccountTimesheetPeriodTypeBLL().InsertDefault(NewAccountId, 0)
            Dim objWorkingDayType As New AccountWorkingDayTypeBLL
            Dim nAccountWorkingDayTypeId As Guid = objWorkingDayType.InsertDefault(NewAccountId, 0, UserInterfaceLanguage)

            _AccountEmployeeTableAdapter = New AccountEmployeeTableAdapter()
            Dim AccountHolidayTypeId As Guid
            Dim objAccountEmployeeBLL As New AccountEmployeeBLL
            objAccountEmployeeBLL.AddAccountEmployee(EmployeeLogin, EmployeePassword, EmployeeFirstName, EmployeeLastName, EmployeeEMailAddress, EmployeeCode, NewAccountId, nNewDepartmentId, nAccountRoleId, nAccountLocationId, CountryId, Nothing, System.DateTime.Today, -1, 0, TimeZoneId, 0, 0, nAccountEmployeeTypeId, nEmployeeStatusId, "", System.DateTime.Now, Nothing, nAccountWorkingDayTypeId, System.Guid.Empty, 0, AccountHolidayTypeId, False, UserInterfaceLanguage, True, False, , , , , , , , , EmployeeMiddleName, EmployeePrefix, True, True)

            Me.PopulatedDefaultData(NewAccountId, 0, UserInterfaceLanguage)


            Me.AfterAddNewAccount(NewAccountId, EmployeeEMailAddress, EmployeeFirstName & " " & EmployeeLastName, EmployeePassword, EmployeeFirstName, EmployeeLastName, AccountName)

            Return True

            ' Return true if precisely one row was inserted, otherwise false

        Catch ex As Exception
            LoggingBLL.WriteExceptionToLog("AddAccount", ex)

            Return False
        End Try


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddNewAccount(ByVal AccountTypeId As System.Nullable(Of Short), _
                    ByVal AccountName As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal ZipCode As String, _
                    ByVal City As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal EMailAddress As String, _
                    ByVal EmployeeCode As String, _
                    ByVal Telephone As String, _
                    ByVal Fax As String, _
                    ByVal DefaultCurrencyId As System.Nullable(Of Short), _
                    ByVal TimeZoneId As System.Nullable(Of Byte), _
                    ByVal EmployeeLogin As String, _
                    ByVal EmployeePassword As String, _
                    ByVal EmployeeEMailAddress As String, _
                    ByVal EmployeeFirstName As String, _
                    ByVal EmployeeLastName As String, _
                    ByVal EmployeePrefix As String, _
                    ByVal EmployeeMiddleName As String, _
                    ByVal State As String, _
                    ByVal IsDisabled As Boolean, _
                    ByVal IsDeleted As Boolean, _
                    ByVal CreatedOn As DateTime, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal UserInterfaceLanguage As String, _
                    Optional ByVal SubDomain As String = "" _
                    ) As Boolean

        Dim LDAP As New LDAPUtilitiesBLL

        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            Me.AddAccountForActiveDirectory(2, AccountName, Address1, Address2, ZipCode, City, CountryId, EMailAddress, EmployeeCode, Telephone, Fax, DefaultCurrencyId, TimeZoneId, EmployeeLogin, EmployeePassword, EmployeeEMailAddress, EmployeeFirstName, EmployeeLastName, EmployeePrefix, EmployeeMiddleName, State, IsDisabled, IsDeleted, CreatedOn, ModifiedOn, UserInterfaceLanguage, SubDomain)
            Return True
        Else
            Me.AddAccount(2, AccountName, Address1, Address2, ZipCode, City, CountryId, EMailAddress, EmployeeCode, Telephone, Fax, DefaultCurrencyId, TimeZoneId, EmployeeEMailAddress, EmployeePassword, EmployeeEMailAddress, EmployeeFirstName, EmployeeLastName, EmployeePrefix, EmployeeMiddleName, State, IsDisabled, IsDeleted, CreatedOn, ModifiedOn, UserInterfaceLanguage, SubDomain)
            Return True
        End If
        Return False
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    'Public Function AddNewAccountForWizard( _
    '                ByVal AccountName As String, _
    '                ByVal EMailAddress As String, _
    '                ByVal TimeZoneId As System.Nullable(Of Byte), _
    '                 ByVal CountryId As System.Nullable(Of Short), _
    '                ByVal EmployeeLogin As String, _
    '                ByVal EmployeePassword As String, _
    '                ByVal EmployeeEMailAddress As String, _
    '                ByVal EmployeeFirstName As String, _
    '                ByVal EmployeeLastName As String _
    '                ) As Boolean

    '    Dim LDAP As New LDAPUtilitiesBLL

    '    If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
    '        Me.AddAccountForActiveDirectory(2, AccountName, "", "", "", "", CountryId, EMailAddress, "", "", "", 1, TimeZoneId, EmployeeLogin, EmployeePassword, EmployeeEMailAddress, EmployeeFirstName, EmployeeLastName, "", "", "", False, False, Now, Now, "")
    '        Return True
    '    Else
    '        Me.AddAccount(2, AccountName, "", "", "", "", CountryId, EMailAddress, "", "", "", 1, TimeZoneId, EmployeeEMailAddress, EmployeePassword, EmployeeEMailAddress, EmployeeFirstName, EmployeeLastName, "", "", "", False, False, Now, Now, "")
    '        Return True
    '    End If
    '    Return False
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountForActiveDirectory(ByVal AccountTypeId As System.Nullable(Of Short), _
                    ByVal AccountName As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal ZipCode As String, _
                    ByVal City As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal EMailAddress As String, _
                    ByVal EmployeeCode As String, _
                    ByVal Telephone As String, _
                    ByVal Fax As String, _
                    ByVal DefaultCurrencyId As System.Nullable(Of Short), _
                    ByVal TimeZoneId As System.Nullable(Of Byte), _
                    ByVal EmployeeLogin As String, _
                    ByVal EmployeePassword As String, _
                    ByVal EmployeeEMailAddress As String, _
                    ByVal EmployeeFirstName As String, _
                    ByVal EmployeeLastName As String, _
                    ByVal EmployeePrefix As String, _
                    ByVal EmployeeMiddleName As String, _
                    ByVal State As String, _
                    ByVal IsDisabled As Boolean, _
                    ByVal IsDeleted As Boolean, _
                    ByVal CreatedOn As DateTime, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal UserInterfaceLanguage As String, _
                    Optional ByVal SubDomain As String = "" _
                    ) As Boolean


        Try

            If Not New AccountEmployeeBLL().ValidateNewEmployee(EmployeeEMailAddress) Then
                Throw New Exception("Specified email address already exist")
                Return False
            End If

            ' Create a new ProductRow instance
            Dim NewAccountId As Integer
            NewAccountId = Adapter.InsertAccount(2, AccountName, Address1, Address2, ZipCode, State, City, CInt(CountryId), EMailAddress, Telephone, Fax, CInt(DefaultCurrencyId), False, False, 1, Date.Now, Date.Now, TimeZoneId, Me.GetExpiryString, UIUtilities.IsTrakLiveApplication(), SubDomain)


            Dim objDepartments As New AccountDepartmentBLL
            Dim nNewDepartmentId As Integer = objDepartments.AddAccountDepartment(NewAccountId, "Default", "Default Department", 0, 0)
            _AccountEmployeeTableAdapter = New AccountEmployeeTableAdapter()
            Dim nAccountRoleId As Integer

            Dim objAccountRoles As New AccountRoleBLL
            nAccountRoleId = objAccountRoles.InsertDefault(NewAccountId, 0, UserInterfaceLanguage)

            _AccountEmployeeTableAdapter = New AccountEmployeeTableAdapter()

            Dim objAccountLocations As New AccountLocationBLL
            Dim nAccountLocationId As Integer = objAccountLocations.AddAccountLocation(NewAccountId, "Default Location", 0, 0)

            Dim objEmployeeType As New AccountEmployeeTypeBLL
            Dim nAccountEmployeeTypeId As Guid = objEmployeeType.InsertDefault(NewAccountId, 0, UserInterfaceLanguage)
            Dim objAccountStatus As New AccountStatusBLL
            Dim nEmployeeStatusId As Integer = objAccountStatus.InsertDefault(NewAccountId, UserInterfaceLanguage)
            Call New AccountTimesheetPeriodTypeBLL().InsertDefault(NewAccountId, 0)
            Dim objWorkingDayType As New AccountWorkingDayTypeBLL
            Dim nAccountWorkingDayTypeId As Guid = objWorkingDayType.InsertDefault(NewAccountId, 0, UserInterfaceLanguage)
            Dim AccountHolidayTypeId As Guid
            _AccountEmployeeTableAdapter = New AccountEmployeeTableAdapter()

            Dim objAccountEmployeeBLL As New AccountEmployeeBLL
            objAccountEmployeeBLL.AddAccountEmployeeActiveDirectory(EmployeeLogin, EmployeeLogin, EmployeeFirstName, EmployeeLastName, EmployeeEMailAddress, EmployeeCode, NewAccountId, nNewDepartmentId, nAccountRoleId, nAccountLocationId, CountryId, Nothing, System.DateTime.Today, -1, 0, TimeZoneId, 0, 0, nAccountEmployeeTypeId, nEmployeeStatusId, "", System.DateTime.Now, Nothing, nAccountWorkingDayTypeId, System.Guid.Empty, 0, AccountHolidayTypeId, False, UserInterfaceLanguage, True, False, , , , , , , , , EmployeeMiddleName, EmployeePrefix, True)

            Me.PopulatedDefaultData(NewAccountId, 0, UserInterfaceLanguage)

            Me.AfterAddNewADAccount(NewAccountId, EmployeeEMailAddress, EmployeeFirstName & " " & EmployeeLastName, EmployeePassword)

            Return True

            ' Return true if precisely one row was inserted, otherwise false

        Catch ex As Exception
            LoggingBLL.WriteExceptionToLog("AddAccount", ex)

            Return False
        End Try


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccount( _
                    ByVal AccountName As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal ZipCode As String, _
                    ByVal City As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal EMailAddress As String, _
                    ByVal Telephone As String, _
                    ByVal Fax As String, _
                    ByVal DefaultCurrencyId As System.Nullable(Of Short), _
                    ByVal ShowClockStartEnd As System.Nullable(Of Boolean), _
                    ByVal TimeEntryFormat As String, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal original_AccountId As Integer, _
                    ByVal TimeZoneId As System.Nullable(Of Byte), _
                    ByVal CultureInfoName As String, _
                    ByVal CurrencySymbol As String, _
                    ByVal AccountSessionTimeout As System.Nullable(Of Integer), _
                    ByVal ShowCompletedTasksInTimeSheet As System.Nullable(Of Boolean), _
                    ByVal ScheduledEmailSendTime As DateTime, _
                    ByVal LockSubmittedRecords As Boolean, _
                    ByVal LockApprovedRecords As Boolean, _
                    ByVal ShowWorkTypeInTimeSheet As Boolean, _
                    ByVal NumberOfBlankRowsInTimeEntry As Short, _
                    ByVal ShowCostCenterInTimeSheet As Boolean, _
                    ByVal UserInterfaceLanguage As String, _
                    ByVal DefaultTimeEntryMode As String, _
                    ByVal PageSize As Integer, _
                    ByVal ShowClientInTimesheet As System.Nullable(Of Boolean), _
                    ByVal ShowDescriptionInWeekView As System.Nullable(Of Boolean), _
                    ByVal InvoiceNoPrefix As String, _
                    ByVal ShowAdditionalTaskInformationType As Integer, _
                    ByVal ShowCompletedProjectsInTimeSheet As System.Nullable(Of Boolean), _
                    ByVal ShowProjectForTimeOff As System.Nullable(Of Boolean), _
                    ByVal ShowTimeOffInTimesheet As System.Nullable(Of Boolean), _
                    ByVal PasswordExpiryPeriod As Integer, _
                    ByVal ShowAllInTimesheetReadOnly As System.Nullable(Of Boolean), _
                    ByVal ShowTaskInExpenseSheet As System.Nullable(Of Boolean), _
                    ByVal InvoiceBillingTypeId As Guid, _
                    ByVal ShowBillingRateInInvoiceReport As Boolean, _
                    ByVal InvoiceFooter As String, _
                    ByVal TimesheetOverduePeriods As Short, _
                    ByVal ShowPercentageInTimesheet As Boolean, _
                    ByVal TimeEntryHoursFormatId As Guid, _
                    ByVal EnablePasswordComplexity As Boolean, _
                    ByVal IsShowElectronicSign As Boolean _
                    ) As Boolean

        ' Update the product record

        Dim Accounts As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(original_AccountId)
        Dim Account As TimeLiveDataSet.AccountRow = Accounts.Rows(0)

        With Account
            .AccountName = AccountName
            .Address1 = Address1
            .Address2 = Address2
            .ZipCode = ZipCode
            .City = City
            .CountryId = CountryId
            .EMailAddress = EMailAddress
            .Telephone = Telephone
            .Fax = Fax
            '.DefaultCurrencyId = DefaultCurrencyId
            .TimeZoneId = TimeZoneId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With


        Dim rowsAffected As Integer = Adapter.Update(Account)

        Try


            Dim Preference As AccountPreferences.AccountPreferencesRow
            Dim Preferences As AccountPreferences.AccountPreferencesDataTable
            Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(original_AccountId)

            Preference = Preferences.Rows(0)

            With Preference
                '.CultureInfoName = CultureInfoName
                '.AccountSessionTimeout = AccountSessionTimeout
                '.CurrencySymbol = CurrencySymbol
                '.ScheduledEmailSendTime = ScheduledEmailSendTime
                '.LockSubmittedRecords = LockSubmittedRecords
                '.LockApprovedRecords = LockApprovedRecords
                '.IsShowElectronicSign = IsShowElectronicSign
                '.WeekStartDay = WeekStartDay
                '.UserInterfaceLanguage = UserInterfaceLanguage
                '.PageSize = PageSize
                'If Not IsDBNull(.Item("PasswordExpiryPeriod")) Then
                'If .PasswordExpiryPeriod <> PasswordExpiryPeriod Then
                'IsPasswordChanged = True
                'End If
                'Else
                'If PasswordExpiryPeriod <> 0 Then
                '    IsPasswordChanged = True
                'End If
                'End If
                '.PasswordExpiryPeriod = PasswordExpiryPeriod
                '.EnablePasswordComplexity = EnablePasswordComplexity
            End With

            'rowsAffected = AccountPreferencesTableAdapter.Update(Preferences)

            Dim objEmployeeBLL As New AccountEmployeeBLL
            'If IsPasswordChanged Then
            '    objEmployeeBLL.UpdatePasswordChangedDateByAccountId(original_AccountId, Now)
            'End If
            objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
            Call New AccountPagePermissionBLL().ResetPageSecurity()

        Catch ex As Exception
            LoggingBLL.WriteExceptionToLog("AccountPreference Update", ex)
            Throw ex
        End Try

        CacheManager.ClearCache("AccountDataTable", , True)


        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountPayment(ByVal LicenseKey As String, ByVal Quantity As Integer, ByVal original_AccountId As Integer) As Boolean

        ' Update the product record

        Dim Accounts As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(original_AccountId)
        Dim Account As TimeLiveDataSet.AccountRow = Accounts.Rows(0)

        With Account
            .LicenseKey = LicenseKey
            .LicenseActivation = LicensingBLL.GetEncryptedStringAsBase64(LicenseKey)
            .SystemPackageTypeId = ShoppingCart.GetPackageTypeId(LicenseKey)
            Try
                Dim objTemp As Object = IsDBNull(.AccountExpiry)
                .AccountExpiry = .AccountExpiry.AddMonths(Quantity)
            Catch ex As Exception
                .AccountExpiry = Now.Date.AddMonths(Quantity)
            End Try

        End With


        Dim rowsAffected As Integer = Adapter.Update(Account)


        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub UpdateLicenseKey(ByVal LicenseKey As String, ByVal AccountId As Integer)
        Dim Accounts As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim Account As TimeLiveDataSet.AccountRow = Accounts.Rows(0)

        With Account
            .Item("LicenseKey") = IIf(LicenseKey = "TLHL", System.DBNull.Value, LicenseKey)
            .SystemPackageTypeId = ShoppingCart.GetPackageTypeId(LicenseKey)
            .Item("LicenseActivation") = IIf(LicenseKey = "TLHL", System.DBNull.Value, LicensingBLL.GetEncryptedStringAsBase64(LicenseKey))
        End With

        Dim rowsAffected As Integer = Adapter.Update(Account)

    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateLastScheduledEmailSentTime(ByVal AccountId As Integer, ByVal LastScheduledEmailSentTime As DateTime) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        If Preferences.Rows.Count > 0 Then
            Preference = Preferences.Rows(0)
            With Preference
                .LastScheduledEmailSentTime = LastScheduledEmailSentTime
            End With
            Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
            Return rowsAffected = 1
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateEmailPreferences(ByVal AccountId As Integer, ByVal FromEmailAddressDisplayName As String, ByVal FromEmailAddress As String) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            .FromEmailAddressDisplayName = FromEmailAddressDisplayName
            .FromEmailAddress = FromEmailAddress
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Return rowsAffected = 1
    End Function
    Public Function GetExpiryDateAsString(ByVal dtDate As Date) As String
        Return LicensingBLL.GetEncryptedStringAsBase64(dtDate.Year & dtDate.Month.ToString.PadLeft(2, "0") & dtDate.Day.ToString.PadLeft(2, "0"))
    End Function
    Public Function GetExpiryString() As String
        Return Me.GetExpiryDateAsString(Now.AddMonths(1))
    End Function
    Public Sub PopulatedDefaultData(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        Call New AccountWorkingDayBLL().InsertDefault(AccountId)
        Call New AccountPriorityBLL().InsertDefault(AccountId, UserInterfaceLanguage)
        Call New AccountBillingTypeBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountProjectTypeBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountTaskTypeBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountAbsenceTypeBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        'Call New AccountPagePermissionBLL().InsertDefaultPermissionOfAccount(AccountId)
        Call New AccountApprovalBLL().InsertDefaultAccountApprovalType(AccountId, UserInterfaceLanguage)
        Call New AccountApprovalBLL().InsertDefaultAccountApprovalPath(AccountId)
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(AccountId)
        Call New AccountCurrencyBLL().InsertDefault(AccountId)
        Call New AccountCurrencyExchangeRateBLL().InsertDefault(AccountId)
        Call New AccountCurrencyBLL().UpdateDefault(AccountId)
        Call New AccountPaymentMethodBLL().InsertDefault(AccountId, UserInterfaceLanguage)
        Call New AccountTaxCodeBLL().InsertDefault(AccountId, UserInterfaceLanguage)
        Call New AccountExpenseTypeBLL().InsertDefault(AccountId, UserInterfaceLanguage)
        'Call New AccountExpenseTypeBLL().UpdateDefault(AccountId)
        Dim ProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountId(AccountId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow
        If dtProject.Rows.Count > 0 Then
            drProject = dtProject.Rows(0)
            For Each drProject In dtProject.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountProjectEMailNotificationPreference(drProject.AccountProjectId)
            Next
        End If
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(AccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow
        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If
        Dim AccountPreferences As New AccountPreferencesTableAdapters.AccountPreferencesTableAdapter
        AccountPreferences.InsertDefault(AccountId, SystemUtilitiesBLL.GetApplicationVersion.ToString, UserInterfaceLanguage)
        Dim objRoleBLL As New AccountRoleBLL
        objRoleBLL.InsertDefault(AccountId, 0, UserInterfaceLanguage)
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(AccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionIfBlank(AccountId, role.AccountRoleId)
        Next
        Call New AccountApprovalBLL().InsertDefaultAccountApprovalType(AccountId, UserInterfaceLanguage)
        Call New AccountApprovalBLL().InsertDefaultAccountApprovalPath(AccountId)
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(AccountId)
        Call New AccountExpenseBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountWorkTypeBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountTaxZoneBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountTaxCodeBLL().UpdateAccountTaxZoneId(AccountId)
        Call New AccountExpenseTypeBLL().InsertAccountExpenseTypeTaxCode(AccountId, AccountEmployeeId)
        Call New AccountCostCenterBLL().InsertDefault(AccountId, AccountEmployeeId)
        Call New ObjectPermissionBLL().InsertDefaultReportPermission(AccountId)
        Call New AccountBillingRateBLL().InsertDefaultBillingRateOfNewEmployee(AccountId)
        Call New AccountWorkTypeBLL().InsertDefaultWorkTypeBillingRateOfNewEmployee(AccountId)
        Call New AccountEmployeeBLL().UpdateBillingRateIdInNewEmployee(AccountId)
        Call New AccountRoleBLL().UpdateDefaultPageForExternalUser(AccountId)
        Call New AccountTimeOffTypeBLL().InsertDefault(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountTimeOffPolicyBLL().InsertDefaultForPolicy(AccountId, AccountEmployeeId, UserInterfaceLanguage)
        Call New AccountTimeOffPolicyBLL().InsertDefaultForPolicyDetail(AccountId, AccountEmployeeId)
        Call New AccountFeatureManagementBLL().InsertDefault(AccountId)
        Call New AccountEmployeeDashboardBLL().InsertDefault(AccountId)
        Call New AccountEmployeeChartBLL().InsertDefault(AccountId)

        ''New Account Default value change preference table
        Dim AccountPreferencesHoursFormat As New AccountPreferencesTableAdapters.AccountPreferencesTableAdapter
        AccountPreferencesHoursFormat.UpdateTimeEntryHoursFormat(AccountId)
        AccountPreferencesHoursFormat.UpdateAutoResizeTimesheet(True, AccountId)
        AccountPreferencesHoursFormat.UpdateShowDisableProjectInReport(True, AccountId)
        Call New AccountWorkingDayTypeBLL().UpdateEnableBalanceValidation(True, AccountId)

    End Sub
    Public Sub AfterAddNewAccount(ByVal AccountId As Integer, ByVal ToEMailAddress As String, ByVal ToEMailAddressDisplayName As String, ByVal Password As String, ByVal FirstName As String, ByVal LastName As String, ByVal CompanyName As String)
        Me.SendNewAccountSignup(AccountId, ToEMailAddress, ToEMailAddressDisplayName, Password)
        EMailUtilities.DequeueEmail()
        Dim CustomerId As Integer = New LTCustomerBLL().AddLTCustomerForNewAccount(AccountId)
        If DBUtilities.IsApplicationContext Then
            System.Web.HttpContext.Current.Session("CustomerId") = CustomerId
        End If
        Call CallAccountAddPHooks(AccountId, ToEMailAddress, Password, FirstName, LastName, CompanyName)
    End Sub
    Public Sub CallAccountAddPHooks(ByVal AccountId As Integer, ByVal EmailAddress As String, ByVal password As String, ByVal FirstName As String, ByVal LastName As String, ByVal CompanyName As String)
        If Not System.Configuration.ConfigurationManager.AppSettings("AccountAddHookURL") Is Nothing Then
            Dim url As String = System.Configuration.ConfigurationManager.AppSettings("AccountAddHookURL")
            Dim param As String
            param = param & "FirstName=" & FirstName
            param = param & "&LastName=" & LastName
            param = param & "&EmailAddress=" & EmailAddress
            param = param & "&password=" & password
            param = param & "&CompanyName=" & CompanyName
            url = url & "?" & param
            SystemUtilitiesBLL.OpenURL(url)
        End If
    End Sub
    Public Sub SendNewAccountSignup(ByVal AccountId As Integer, ByVal ToEMailAddress As String, ByVal ToEMailAddressDisplayName As String, ByVal Password As String)
        If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
            EMailUtilities.SendEMail(ResourceHelper.GetFromResource("Welcome To " & UIUtilities.GetCompanyNameByApplication()), IIf(UIUtilities.IsTrakLiveApplication, "NewTrakLiveSignupTemplate", "NewSignupTemplate"), GetPreparedNameValueForAccountSignup(AccountId, Password), ToEMailAddress, ToEMailAddressDisplayName)
        Else
            EMailUtilities.SendEMail(ResourceHelper.GetFromResource("Welcome To " & UIUtilities.GetCompanyNameByApplication()), IIf(UIUtilities.IsTrakLiveApplication, "NewTrakLiveSignupTemplate", "NewSignupTemplate"), GetPreparedNameValueForAccountSignup(AccountId, Password), ToEMailAddress, ToEMailAddressDisplayName, , , , True)
        End If
    End Sub
    Public Function GetPreparedNameValueForAccountSignup(ByVal AccountId As Integer, ByVal Password As String) As StringDictionary
        Dim drAccount As AccountEmployee.vueAccountEmployeeRow
        Dim objAccountEmployee As New AccountEmployeeBLL
        drAccount = objAccountEmployee.GetAccountEmployeesViewByAccountId(AccountId).Rows(0)

        Dim dict As New StringDictionary

        dict.Add("[AccountId]", drAccount.AccountId)
        dict.Add("[EMailAddress]", drAccount.EMailAddress)
        dict.Add("[Password]", Password)
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix"))

        Return dict
    End Function
    Public Sub AfterAddNewADAccount(ByVal AccountId As Integer, ByVal ToEMailAddress As String, ByVal ToEMailAddressDisplayName As String, ByVal Password As String)
        Me.SendNewADAccountSignup(AccountId, ToEMailAddress, ToEMailAddressDisplayName, Password)
        EMailUtilities.DequeueEmail()
        ' Add new customer id
        Dim CustomerId As Integer = New LTCustomerBLL().AddLTCustomerForNewAccount(AccountId)
        System.Web.HttpContext.Current.Session("CustomerId") = CustomerId

    End Sub
    Public Sub SendNewADAccountSignup(ByVal AccountId As Integer, ByVal ToEMailAddress As String, ByVal ToEMailAddressDisplayName As String, ByVal Password As String)
        If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
            EMailUtilities.SendEMail(ResourceHelper.GetFromResource("Welcome To " & UIUtilities.GetCompanyNameByApplication()), IIf(UIUtilities.IsTrakLiveApplication, "NewADTrakLiveSignupTemplate", "NewADSignupTemplate"), GetPreparedNameValueForADAccountSignup(AccountId, Password), ToEMailAddress, ToEMailAddressDisplayName)
        Else
            EMailUtilities.SendEMail(ResourceHelper.GetFromResource("Welcome To " & UIUtilities.GetCompanyNameByApplication()), IIf(UIUtilities.IsTrakLiveApplication, "NewADTrakLiveSignupTemplate", "NewADSignupTemplate"), GetPreparedNameValueForADAccountSignup(AccountId, Password), ToEMailAddress, ToEMailAddressDisplayName, , , , True)
        End If
    End Sub

    Public Function GetPreparedNameValueForADAccountSignup(ByVal AccountId As Integer, ByVal Password As String) As StringDictionary

        Dim drAccount As AccountEmployee.vueAccountEmployeeRow
        Dim objAccountEmployee As New AccountEmployeeBLL
        drAccount = objAccountEmployee.GetAccountEmployeesViewByAccountId(AccountId).Rows(0)

        Dim dict As New StringDictionary

        dict.Add("[AccountId]", drAccount.AccountId)
        dict.Add("[EMailAddress]", drAccount.Username)
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix"))

        Return dict

    End Function
    Public Sub PostInstalledAccountAdd()
        Try
            Dim NewAccount As Integer = CType(New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter().GetAccountLastId.Rows(0), TimeLiveDataSet.IdentityQueryRow).LastId
            ' UltraDev issue
            '            UIUtilities.ModifyAppSettings("InstalledCustomerId", NewAccount)

        Catch ex As Exception
            LoggingBLL.WriteExceptionToLog("PostInstalledAccountAdd", ex)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Shared Sub InsertDefaultDataForVersionBefore2_5_0001()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        Dim ProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountId(DBUtilities.GetSessionAccountId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow

        If dtProject.Rows.Count > 0 Then
            drProject = dtProject.Rows(0)
            For Each drProject In dtProject.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountProjectEMailNotificationPreference(drProject.AccountProjectId)
            Next
        End If

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 96)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 97)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 98)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 99)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 100)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 101)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_51_0001()

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 96)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 97)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 98)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 99)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 100)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 101)
        Next

    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_71_0001()

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 102)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 103)
        Next

    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_71_0002()
        Call New AccountCurrencyBLL().InsertDefault(DBUtilities.GetSessionAccountId)
        Call New AccountCurrencyExchangeRateBLL().InsertDefault(DBUtilities.GetSessionAccountId)
        Call New AccountCurrencyBLL().UpdateDefault(DBUtilities.GetSessionAccountId)
        Call New AccountPaymentMethodBLL().InsertDefault(DBUtilities.GetSessionAccountId)
        Call New AccountTaxCodeBLL().InsertDefault(DBUtilities.GetSessionAccountId)

        'Call New AccountExpenseTypeBLL().UpdateAccountTaxCodeId(DBUtilities.GetSessionAccountId)
        'Call New AccountExpenseTypeBLL().UpdateDefault(DBUtilities.GetSessionAccountId)

        Dim dtCurrencies As AccountCurrency.AccountCurrencyDataTable = New AccountCurrencyBLL().GetAccountCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim drCurrencies As AccountCurrency.AccountCurrencyRow

        If dtCurrencies.Rows.Count > 0 Then
            drCurrencies = dtCurrencies.Rows(0)
            Call New AccountBLL().UpdateDefaultAccountBaseCurrencyId(DBUtilities.GetSessionAccountId, drCurrencies.AccountCurrencyId)
            Dim dt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = New AccountCurrencyExchangeRateBLL().GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(DBUtilities.GetSessionAccountId, drCurrencies.AccountCurrencyId)
            Dim dr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow = dt.Rows(0)
            Call New AccountExpenseEntryBLL().UpdateAccountBaseCurrencyId(dr.AccountCurrencyId, dr.ExchangeRate, dr.AccountCurrencyId)
        End If

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 104)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 105)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 106)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 107)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 108)
            'Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 109)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 110)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 111)
        Next
    End Sub

    Public Shared Sub InsertDefaultDataForVersion2_71_0003()

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 112)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 113)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 114)
        Next
    End Sub

    Public Shared Sub InsertDefaultDataForVersion2_71_0004()

        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(DBUtilities.GetSessionAccountEmployeeId)

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 115)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 116)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_81_0002()
        'Dim objRoleBLL As New AccountRoleBLL
        'Dim role As TimeLiveDataSet.AccountRoleRow
        'Dim roles As TimeLiveDataSet.AccountRoleDataTable

        'Dim roleBLL As New AccountRoleBLL
        'roles = roleBLL.GetAccountRoleForExternalUser(DBUtilities.GetSessionAccountId)

        'For Each role In roles.Rows
        '    Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 101)
        'Next

        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL
        Dim dt As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByEmployeeTypeId(2)
        Dim dr As AccountEmployee.AccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If objAccountEMailNotificationPreference.GetAccountEMailNotificationPreferencessByAccountEmployeeIdForOldVersion(dr.AccountEmployeeId).Rows.Count = 0 Then
                    objAccountEMailNotificationPreference.InsertDefaultAccountEmployeeEMailNotificationPreference(dr.AccountEmployeeId)
                End If
            Next
        End If
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_91_0001()
        Call New AccountTaxZoneBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountTaxCodeBLL().UpdateAccountTaxZoneId(DBUtilities.GetSessionAccountId)
        Call New AccountExpenseTypeBLL().InsertAccountExpenseTypeTaxCodeForOldVersion(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountWorkTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)

        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = New AccountWorkTypeBLL().GetAccountWorkTypesByAccountIdAndAccountWorkType(DBUtilities.GetSessionAccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        If dtWorkType.Rows.Count > 0 Then
            drWorkType = dtWorkType.Rows(0)
            Call New AccountBillingRateBLL().UpdateAccountWorkType(drWorkType.AccountWorkTypeId, DBUtilities.GetSessionAccountId)
            Call New AccountEmployeeTimeEntryBLL().UpdateAccountWorkType(drWorkType.AccountWorkTypeId, DBUtilities.GetSessionAccountId)
        End If

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 117)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 118)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 119)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 120)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_91_0002()
        Call New AccountWorkTypeBLL().InsertAccountWorkTypeBillingRate(DBUtilities.GetSessionAccountId)
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_93_0001()

        Call New AccountCostCenterBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)

        Dim objCurrency As New AccountCurrencyExchangeRateBLL
        Dim dtCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = objCurrency.GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim drCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
        If dtCurrency.Rows.Count > 0 Then
            drCurrency = dtCurrency.Rows(0)
            Call New AccountBillingRateBLL().UpdateCurrenciesInBillngRate(drCurrency.AccountBaseCurrencyId, DBUtilities.GetSessionAccountId)
        End If

        Dim objApproval As New AccountApprovalBLL
        objApproval.InsertEmployeeManagerApprovalType(DBUtilities.GetSessionAccountId)
        objApproval.InsertEmployeeManagerApprovalPath(DBUtilities.GetSessionAccountId, objApproval.GetLastInsertedId)

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 121)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 122)
        Next

    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_94_0001()

        Dim drRole As TimeLiveDataSet.AccountRoleRow
        Dim dtRole As TimeLiveDataSet.AccountRoleDataTable
        Dim ObjRole As New AccountRoleBLL


        ObjRole.InsertAfterRoles(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, 102)
        ObjRole.InsertAfterRoles(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, 103)
        ObjRole.InsertAfterRoles(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, 104)


        dtRole = ObjRole.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each drRole In dtRole.Rows
            If Not IsDBNull(drRole.Item("MasterAccountRoleId")) Then
                Call New AccountPagePermissionBLL().InsertDefaultPermissionOfRole(drRole.MasterAccountRoleId, drRole.AccountRoleId, DBUtilities.GetSessionAccountId)
            End If
        Next



        dtRole = ObjRole.GetAccountRolesByAccountIdAndMasterAccountRoleId(DBUtilities.GetSessionAccountId, 103)
        If dtRole.Rows.Count > 0 Then
            drRole = dtRole.Rows(0)
            Call New AccountPagePermissionBLL().InsertDefaultPermissionOfRole(103, drRole.AccountRoleId, DBUtilities.GetSessionAccountId)
        End If

        If dtRole.Rows.Count > 0 Then
            dtRole = ObjRole.GetAccountRolesByAccountIdAndMasterAccountRoleId(DBUtilities.GetSessionAccountId, 104)
            drRole = dtRole.Rows(0)
            Call New AccountPagePermissionBLL().InsertDefaultPermissionOfRole(104, drRole.AccountRoleId, DBUtilities.GetSessionAccountId)
        End If

        dtRole = ObjRole.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each drRole In dtRole.Rows
            If Not IsDBNull(drRole.Item("MasterAccountRoleId")) Then
                Call New AccountPagePermissionBLL().UpdateShowDataPagePermission(DBUtilities.GetSessionAccountId, 28, drRole.MasterAccountRoleId, drRole.AccountRoleId)
                Call New AccountPagePermissionBLL().UpdateShowDataPagePermission(DBUtilities.GetSessionAccountId, 21, drRole.MasterAccountRoleId, drRole.AccountRoleId)
            End If
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_94_0002()

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 123)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion2_95_0001()

        Call New AccountBillingRateBLL().InsertBillingRateOfEmployeeWhichIsNotExists(DBUtilities.GetSessionAccountId)
        Call New AccountWorkTypeBLL().InsertWorkTypeBillingRateOfEmployeeWhichIsNotExists(DBUtilities.GetSessionAccountId)
        Call New AccountEmployeeBLL().UpdateEmployeeBillingRateWhichIsNotExists(DBUtilities.GetSessionAccountId)
        Call New ObjectPermissionBLL().InsertDefaultReportPermission(DBUtilities.GetSessionAccountId)
        Call New AccountProjectTaskBLL().UpdateEstimatedCurrencyIdForOldAccount(DBUtilities.GetAccountBaseCurrencyId, DBUtilities.GetSessionAccountId)

        Dim objCurrency As New AccountCurrencyBLL
        Dim dtCurrency As AccountCurrency.vueAccountCurrencyDataTable = objCurrency.GetvueAccountCurrencyByAccountCurrencyId(DBUtilities.GetAccountBaseCurrencyId)
        Dim drCurrency As AccountCurrency.vueAccountCurrencyRow
        If dtCurrency.Rows.Count > 0 Then
            drCurrency = dtCurrency.Rows(0)
            Call New AccountEmployeeTimeEntryBLL().UpdateCurrenciesInTimeEntry(drCurrency.AccountCurrencyId, drCurrency.ExchangeRate, DBUtilities.GetSessionAccountId)
        End If

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 124)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 125)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 126)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 127)
        Next

    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_00_0001()
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_00_0003()
        Call New AccountStatusBLL().InsertStatusForEmployee(DBUtilities.GetSessionAccountId)
        Call New AccountEmployeeTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountEmployeeBLL().UpdateEmployeeTypeIdAndStatusId(DBUtilities.GetSessionAccountId)

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 128)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_00_0004()
        Call New AccountTimesheetPeriodTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountWorkingDayTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountWorkingDayBLL().UpdateAccountWorkingDayTypeId(DBUtilities.GetSessionAccountId)
        Call New AccountEmployeeBLL().UpdateDefaultAccountWorkingDayTypeId(DBUtilities.GetSessionAccountId)
        Call New AccountPagePermissionBLL().DeletePagePermissionByAccountIdAndSystemSecurityCategoryPageId(DBUtilities.GetSessionAccountId, 13)
        Call New AccountWorkingDayTypeBLL().UpdateWeekStartDay(DBUtilities.GetSessionAccountId)
        Call New AccountWorkingDayTypeBLL().UpdateAccounTimesheetPeriodTypeId(DBUtilities.GetSessionAccountId)

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 129)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 130)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 131)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 132)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 133)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 134)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 13)
        Next

    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_00_0005()

        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next

    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_01_0001()
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 135)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_01_0002()
        Call New AccountWorkTypeBLL().InsertAccountWorkTypeBillingRateWhichIsNotExists(DBUtilities.GetSessionAccountId)
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_02_0001()
        Call New AccountTimesheetPeriodTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountWorkingDayTypeBLL().UpdateAccounTimesheetPeriodTypeId(DBUtilities.GetSessionAccountId)
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 136)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_05_0001()
        Call New AccountTimeOffTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountTimeOffPolicyBLL().InsertDefaultForPolicy(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountTimeOffPolicyBLL().InsertDefaultForPolicyDetail(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Call New AccountApprovalBLL().InsertDefaultAccountApprovalTypeForEmployeeTimeOff(DBUtilities.GetSessionAccountId)
        Call New AccountApprovalBLL().InsertDefaultAccountApprovalPathForEmployeeTimeOff(DBUtilities.GetSessionAccountId)

        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 137)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 138)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 139)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 140)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 141)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 142)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 143)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 144)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_05_0002()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 145)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 146)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_05_0003()
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 147)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 148)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 149)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_05_0004()
        Dim drRole As TimeLiveDataSet.AccountRoleRow
        Dim dtRole As TimeLiveDataSet.AccountRoleDataTable
        Dim ObjRole As New AccountRoleBLL
        dtRole = ObjRole.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each drRole In dtRole.Rows
            If Not IsDBNull(drRole.Item("MasterAccountRoleId")) Then
                Call New AccountPagePermissionBLL().UpdateShowDataPagePermission(DBUtilities.GetSessionAccountId, 18, drRole.MasterAccountRoleId, drRole.AccountRoleId)
            End If
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_05_0005()
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_06_0004()
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_06_0015()
        Call New AccountFeatureManagementBLL().InsertDefault(DBUtilities.GetSessionAccountId)

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 150)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_07_0008()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 151)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_08_0007()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 152)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_09_0008()
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion3_09_0009()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByMasterAccountRoleIdEdit(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertEditPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 28, 3)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion4_02_0001()
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If
    End Sub
    Public Shared Sub InsertDefaultDataForVersion4_02_0002()
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If
    End Sub
    Public Shared Sub InsertDefaultDataForVersion5_01_0001()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 153)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 154)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 155)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_00_0001()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 156)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_00_0008()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 157)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_01_0001()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 158)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_02_0001()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 159)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 160)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 161)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_02_0002()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 159)
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 132)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_02_0003()
        Dim BLL As New AccountEmployeeTimeEntryBLL
        BLL.UpdateAccountEmployeeTimeEntriesByAccount(DBUtilities.GetSessionAccountId)
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_02_0006()
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_02_00061()
        Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)

        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow

        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            For Each drEmployee In dtEmployee.Rows
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreference(drEmployee.AccountEmployeeId)
            Next
        End If
    End Sub
    Public Shared Sub InsertDefaultDataForVersion6_02_0071()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 162)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion7_01_0002()
        Dim ObjectBLL As New ObjectPermissionBLL
        Dim dtReport As dsObjectPermission.vueSystemReportPermissionDataTable = ObjectBLL.GetvueSystemReportPermissionByAccountId(DBUtilities.GetSessionAccountId)
        Dim drReport As dsObjectPermission.vueSystemReportPermissionRow = dtReport.Rows(0)

        For Each drReport In dtReport.Rows
            ObjectBLL.InsertPermissionForReportByReportId(drReport.AccountId, drReport.AccountRoleId, drReport.AccountReportId)
        Next

        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 167)
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion7_02_0002()

    End Sub
    Public Shared Sub InsertDefaultDataForVersion8_01_0005()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)
        For Each role In roles.Rows
            If Not IsDBNull(role.Item("MasterAccountRoleId")) Then
                If role.masteraccountroleid = 102 Then
                    Call New AccountPagePermissionBLL().InsertPermissionOfSelectedPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 25, 1)
                    Call New AccountPagePermissionBLL().InsertPermissionOfSelectedPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 159, 1)
                End If
            End If
        Next
    End Sub
    Public Shared Sub InsertDefaultDataForVersion8_03_0001()
        Dim objRoleBLL As New AccountRoleBLL
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable
        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountId(DBUtilities.GetSessionAccountId)

        For Each role In roles.Rows
            Call New AccountPagePermissionBLL().InsertPermissionOfPage(DBUtilities.GetSessionAccountId, role.AccountRoleId, 169)
        Next
    End Sub
    Public Shared Sub UpdateApplicationVersionToCurrent(Optional ByVal UserCurrentVersion As System.Version = Nothing)
        Dim PreferencesBLL As New AccountBLL
        Dim NewVersion As System.Version = SystemUtilitiesBLL.GetApplicationVersion
        If Not UserCurrentVersion Is Nothing Then
            PreferencesBLL.UpdateApplicationVersion(UserCurrentVersion.ToString, DBUtilities.GetSessionAccountId)
        Else
            PreferencesBLL.UpdateApplicationVersion(NewVersion.ToString, DBUtilities.GetSessionAccountId)
        End If
    End Sub
    Public Shared Sub InsertNewDefaultDataWhichIsNotExist()
        Dim NewVersion As System.Version = SystemUtilitiesBLL.GetApplicationVersion
        Dim InstalledVersion As Version = GetInstalledVersion()
        Dim bUpdated As Boolean = False

        If InstalledVersion Is Nothing Then
            InsertDefaultDataForVersionBefore2_5_0001()
            InsertDefaultDataForVersion2_51_0001()
            InstalledVersion = New System.Version("2.51.0002")
            bUpdated = True
        End If

        If InstalledVersion < New System.Version(AccountBLL.VERSION_PASSWORD_ENCRYPTION) Then
            Call New AccountEmployeeBLL().SetAllEmployeePasswordEncrypted(DBUtilities.GetSessionAccountId)
            bUpdated = True
        End If

        If InstalledVersion < New System.Version("2.71.0001") Then
            InsertDefaultDataForVersion2_71_0001()
            InstalledVersion = New System.Version("2.71.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.71.0002") Then
            InsertDefaultDataForVersion2_71_0002()
            InstalledVersion = New System.Version("2.71.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.71.0003") Then
            InsertDefaultDataForVersion2_71_0003()
            InstalledVersion = New System.Version("2.71.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.71.0004") Then
            InsertDefaultDataForVersion2_71_0004()
            InstalledVersion = New System.Version("2.71.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.81.0001") Then
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.81.0002") Then
            InsertDefaultDataForVersion2_81_0002()
            InstalledVersion = New System.Version("2.81.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.91.0001") Then
            InsertDefaultDataForVersion2_91_0001()
            InstalledVersion = New System.Version("2.91.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.91.0002") Then
            InsertDefaultDataForVersion2_91_0002()
            InstalledVersion = New System.Version("2.91.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.93.0001") Then
            InsertDefaultDataForVersion2_93_0001()
            InstalledVersion = New System.Version("2.93.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.94.0001") Then
            InsertDefaultDataForVersion2_94_0001()
            InstalledVersion = New System.Version("2.94.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.94.0002") Then
            InsertDefaultDataForVersion2_94_0002()
            InstalledVersion = New System.Version("2.94.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("2.95.0001") Then
            InsertDefaultDataForVersion2_95_0001()
            InstalledVersion = New System.Version("2.95.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.00.0001") Then
            InsertDefaultDataForVersion3_00_0001()
            InstalledVersion = New System.Version("3.00.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.00.0003") Then
            InsertDefaultDataForVersion3_00_0003()
            InstalledVersion = New System.Version("3.00.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.00.0004") Then
            InsertDefaultDataForVersion3_00_0004()
            InstalledVersion = New System.Version("3.00.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.00.0005") Then
            InsertDefaultDataForVersion3_00_0005()
            InstalledVersion = New System.Version("3.00.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.01.0001") Then
            InsertDefaultDataForVersion3_01_0001()
            InstalledVersion = New System.Version("3.01.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.01.0002") Then
            InsertDefaultDataForVersion3_01_0002()
            InstalledVersion = New System.Version("3.01.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.02.0001") Then
            InsertDefaultDataForVersion3_02_0001()
            InstalledVersion = New System.Version("3.02.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.05.0001") Then
            InsertDefaultDataForVersion3_05_0001()
            InstalledVersion = New System.Version("3.05.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.05.0002") Then
            InsertDefaultDataForVersion3_05_0002()
            InstalledVersion = New System.Version("3.05.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.05.0003") Then
            InsertDefaultDataForVersion3_05_0003()
            InstalledVersion = New System.Version("3.05.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.05.0004") Then
            InsertDefaultDataForVersion3_05_0004()
            InstalledVersion = New System.Version("3.05.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.05.0005") Then
            InsertDefaultDataForVersion3_05_0005()
            InstalledVersion = New System.Version("3.05.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0001") Then
            InstalledVersion = New System.Version("3.06.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0002") Then
            InstalledVersion = New System.Version("3.06.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0003") Then
            InstalledVersion = New System.Version("3.06.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0004") Then
            InsertDefaultDataForVersion3_06_0004()
            InstalledVersion = New System.Version("3.06.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0005") Then
            InstalledVersion = New System.Version("3.06.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0006") Then
            InstalledVersion = New System.Version("3.06.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0007") Then
            InstalledVersion = New System.Version("3.06.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0008") Then
            InstalledVersion = New System.Version("3.06.0008")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0009") Then
            InstalledVersion = New System.Version("3.06.0009")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0010") Then
            InstalledVersion = New System.Version("3.06.0010")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0011") Then
            InstalledVersion = New System.Version("3.06.0011")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0012") Then
            InstalledVersion = New System.Version("3.06.0012")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0013") Then
            InstalledVersion = New System.Version("3.06.0013")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0014") Then
            InstalledVersion = New System.Version("3.06.0014")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0015") Then
            InsertDefaultDataForVersion3_06_0015()
            InstalledVersion = New System.Version("3.06.0015")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0016") Then
            InstalledVersion = New System.Version("3.06.0016")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0017") Then
            InstalledVersion = New System.Version("3.06.0017")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0018") Then
            InstalledVersion = New System.Version("3.06.0018")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0019") Then
            InstalledVersion = New System.Version("3.06.0019")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0020") Then
            InstalledVersion = New System.Version("3.06.0020")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0021") Then
            InstalledVersion = New System.Version("3.06.0021")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.06.0022") Then
            InstalledVersion = New System.Version("3.06.0022")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0001") Then
            InstalledVersion = New System.Version("3.07.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0002") Then
            InstalledVersion = New System.Version("3.07.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0003") Then
            InstalledVersion = New System.Version("3.07.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0004") Then
            InstalledVersion = New System.Version("3.07.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0005") Then
            InstalledVersion = New System.Version("3.07.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0006") Then
            InstalledVersion = New System.Version("3.07.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0007") Then
            InstalledVersion = New System.Version("3.07.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0008") Then
            InsertDefaultDataForVersion3_07_0008()
            InstalledVersion = New System.Version("3.07.0008")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.07.0009") Then
            InstalledVersion = New System.Version("3.07.0009")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0001") Then
            InstalledVersion = New System.Version("3.08.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0002") Then
            InstalledVersion = New System.Version("3.08.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0003") Then
            InstalledVersion = New System.Version("3.08.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0004") Then
            InstalledVersion = New System.Version("3.08.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0005") Then
            InstalledVersion = New System.Version("3.08.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0006") Then
            InstalledVersion = New System.Version("3.08.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0007") Then
            InsertDefaultDataForVersion3_08_0007()
            InstalledVersion = New System.Version("3.08.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0008") Then
            InstalledVersion = New System.Version("3.08.0008")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.08.0009") Then
            InstalledVersion = New System.Version("3.08.0009")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0001") Then
            InstalledVersion = New System.Version("3.09.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0002") Then
            InstalledVersion = New System.Version("3.09.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0003") Then
            InstalledVersion = New System.Version("3.09.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0004") Then
            InstalledVersion = New System.Version("3.09.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0005") Then
            InstalledVersion = New System.Version("3.09.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0006") Then
            InstalledVersion = New System.Version("3.09.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0007") Then
            InstalledVersion = New System.Version("3.09.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0008") Then
            InsertDefaultDataForVersion3_09_0008()
            InstalledVersion = New System.Version("3.09.0008")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("3.09.0009") Then
            InsertDefaultDataForVersion3_09_0009()
            InstalledVersion = New System.Version("3.09.0009")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.01.0001") Then
            InstalledVersion = New System.Version("4.01.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.02.0001") Then
            InsertDefaultDataForVersion4_02_0001()
            InstalledVersion = New System.Version("4.02.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.02.0002") Then
            InsertDefaultDataForVersion4_02_0002()
            InstalledVersion = New System.Version("4.02.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.03.0001") Then
            InstalledVersion = New System.Version("4.03.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.04.0001") Then
            InstalledVersion = New System.Version("4.04.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.05.0001") Then
            InstalledVersion = New System.Version("4.05.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.06.0001") Then
            InstalledVersion = New System.Version("4.06.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.07.0001") Then
            InstalledVersion = New System.Version("4.07.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.08.0001") Then
            InstalledVersion = New System.Version("4.08.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.09.0001") Then
            InstalledVersion = New System.Version("4.09.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.09.0005") Then
            InstalledVersion = New System.Version("4.09.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.09.0006") Then
            InstalledVersion = New System.Version("4.09.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("4.09.0007") Then
            InstalledVersion = New System.Version("4.09.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.01.0001") Then
            InsertDefaultDataForVersion5_01_0001()
            InstalledVersion = New System.Version("5.01.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.02.0001") Then
            InstalledVersion = New System.Version("5.02.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.02.0002") Then
            InstalledVersion = New System.Version("5.02.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.02.0003") Then
            InstalledVersion = New System.Version("5.02.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.02.0005") Then
            InstalledVersion = New System.Version("5.02.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.02.0006") Then
            InstalledVersion = New System.Version("5.02.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.03.0001") Then
            InstalledVersion = New System.Version("5.03.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.03.0002") Then
            InstalledVersion = New System.Version("5.03.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("5.03.0003") Then
            InstalledVersion = New System.Version("5.03.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("5.03.0005") Then
            InstalledVersion = New System.Version("5.03.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("6.00.0001") Then
            InsertDefaultDataForVersion6_00_0001()
            InstalledVersion = New System.Version("6.00.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("6.00.0002") Then
            InstalledVersion = New System.Version("6.00.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("6.00.0003") Then
            InstalledVersion = New System.Version("6.00.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("6.00.0005") Then
            InstalledVersion = New System.Version("6.00.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If

        If InstalledVersion < New System.Version("6.00.0006") Then
            InstalledVersion = New System.Version("6.00.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.00.0007") Then
            InstalledVersion = New System.Version("6.00.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.01.0000") Then
            InsertDefaultDataForVersion6_00_0008()
            InstalledVersion = New System.Version("6.01.0000")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.01.0001") Then
            InsertDefaultDataForVersion6_01_0001()
            InstalledVersion = New System.Version("6.01.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0001") Then
            InsertDefaultDataForVersion6_02_0001()
            InstalledVersion = New System.Version("6.02.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0002") Then
            InsertDefaultDataForVersion6_02_0002()
            InstalledVersion = New System.Version("6.02.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0003") Then
            InsertDefaultDataForVersion6_02_0003()
            InstalledVersion = New System.Version("6.02.0003")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0004") Then
            InstalledVersion = New System.Version("6.02.0004")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0006") Then
            InsertDefaultDataForVersion6_02_0006()
            InstalledVersion = New System.Version("6.02.0006")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0061") Then
            InsertDefaultDataForVersion6_02_00061()
            InstalledVersion = New System.Version("6.02.0061")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0062") Then
            InstalledVersion = New System.Version("6.02.0062")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0007") Then
            InstalledVersion = New System.Version("6.02.0007")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.02.0071") Then
            InsertDefaultDataForVersion6_02_0071()
            InstalledVersion = New System.Version("6.02.0071")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("6.05.0001") Then
            InstalledVersion = New System.Version("6.05.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("7.01.0001") Then
            InstalledVersion = New System.Version("7.01.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("7.01.0002") Then
            InsertDefaultDataForVersion7_01_0002()
            InstalledVersion = New System.Version("7.01.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("7.02.0001") Then
            InstalledVersion = New System.Version("7.02.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("7.02.0002") Then
            InsertDefaultDataForVersion7_02_0002()
            InstalledVersion = New System.Version("7.02.0002")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("8.01.0001") Then
            InstalledVersion = New System.Version("8.01.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("8.01.0005") Then
            InsertDefaultDataForVersion8_01_0005()
            InstalledVersion = New System.Version("8.01.0005")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If InstalledVersion < New System.Version("8.03.0001") Then
            InsertDefaultDataForVersion8_03_0001()
            InstalledVersion = New System.Version("8.03.0001")
            bUpdated = True
            UpdateApplicationVersionToCurrent(InstalledVersion)
        End If
        If bUpdated = True Then
            UpdateApplicationVersionToCurrent()
        End If

        IfCurrencyNotExist()
    End Sub
    Public Shared Function GetInstalledVersion() As System.Version
        Dim PreferencesBLL As New AccountBLL
        Dim dtPreferences As AccountPreferences.AccountPreferencesDataTable = PreferencesBLL.GetPreferencesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drPreferences As AccountPreferences.AccountPreferencesRow
        If dtPreferences.Rows.Count > 0 Then
            drPreferences = dtPreferences.Rows(0)
            If Not IsDBNull(drPreferences.Item("Version")) And drPreferences.Item("Version").ToString <> "" Then
                Return New System.Version(drPreferences.Item("Version"))
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function
    Public Shared Function GetInstalledVersionOfUsername(ByVal UserName As String) As System.Version
        Dim objAccountEmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployees As AccountEmployee.vueAccountEmployeeDataTable = objAccountEmployeeBLL.GetAccountEmployeesViewByUsername(UserName)
        Dim Employee As AccountEmployee.vueAccountEmployeeRow
        If dtEmployees.Rows.Count > 0 Then
            Employee = dtEmployees.Rows(0)
            If Not IsDBNull(Employee.Item("Version")) Then
                Return New System.Version(Employee.Version)
            Else
                Return New System.Version(VERSION_START)
            End If
        Else
            Return Nothing
        End If

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function FileUpload(ByVal objFileUpload As FileUpload) As Boolean


        If objFileUpload.FileName = "" Then
            Return True
        End If

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        If Not System.IO.Directory.Exists(strRoot) Then
            System.IO.Directory.CreateDirectory(strRoot)
        End If
        Dim strAccountPath As String = strRoot & DBUtilities.GetSessionAccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            System.IO.Directory.CreateDirectory(strAccountPath)
        End If
        Dim strLogoPath As String = strAccountPath & "Logo" & "\"
        If Not System.IO.Directory.Exists(strLogoPath) Then
            System.IO.Directory.CreateDirectory(strLogoPath)
        End If
        Dim FileToSave As String = strLogoPath & "CompanyLogo.gif" 'objFileUpload.FileName
        objFileUpload.SaveAs(FileToSave)

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateIsCompanyOwnLogo(ByVal AccountId As Integer, ByVal IsCompanyOwnLogo As Boolean) As Boolean

        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)

        Preference = Preferences.Rows(0)

        With Preference
            .IsCompanyOwnLogo = IsCompanyOwnLogo
        End With



        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)


        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1



    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateShowTimeOffinTimesheet(ByVal AccountId As Integer, ByVal ShowTimeOffInTimesheet As Boolean) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        If Preferences.Rows.Count > 0 Then
            Preference = Preferences.Rows(0)
            With Preference
                .ShowTimeOffInTimesheet = ShowTimeOffInTimesheet
            End With
            Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
            CacheManager.ClearCache("AccountDataTable", , True)
            Dim objEmployeeBLL As New AccountEmployeeBLL
            objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
            Return rowsAffected = 1
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function btnUpdatePrintInfo(ByVal AccountId As Integer, ByVal ShowTaskInExpenseSheet As System.Nullable(Of Boolean), ByVal ExpenseSheetPrintFooter As String, ByVal ShowClientInExpenseSheet As System.Nullable(Of Boolean)) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            .ExpenseSheetPrintFooter = ExpenseSheetPrintFooter
            .ShowTaskInExpenseSheet = ShowTaskInExpenseSheet
            .ShowClientInExpenseSheet = ShowClientInExpenseSheet
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function btnUpdateInvoiceInfo(ByVal AccountId As Integer, ByVal InvoiceNoPrefix As String, ByVal InvoiceBillingTypeId As Guid, ByVal ShowBillingRateInInvoiceReport As Boolean, _
                                         ByVal InvoiceFooter As String, ByVal ShowProjectNameInInvoiceReport As Boolean, ByVal ShowEntryDateInInvoiceReport As Boolean, ByVal ShowEmployeeNameInInvoiceReport As Boolean, ByVal ShowWorkTypeInInvoiceDescription As Boolean, ByVal RoundOffValueInInvoice As Boolean, ByVal IsProjectTemplateMandatory As Boolean) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            If InvoiceNoPrefix = "" Then
                .Item("InvoiceNoPrefix") = ""
            Else
                .InvoiceNoPrefix = InvoiceNoPrefix
            End If
            If InvoiceBillingTypeId <> System.Guid.Empty Then
                .InvoiceBillingTypeId = InvoiceBillingTypeId
            End If
            .ShowBillingRateInInvoiceReport = ShowBillingRateInInvoiceReport
            .InvoiceFooter = InvoiceFooter
            .ShowProjectNameInInvoiceReport = ShowProjectNameInInvoiceReport
            .ShowEntryDateInInvoiceReport = ShowEntryDateInInvoiceReport
            .ShowEmployeeNameInInvoiceReport = ShowEmployeeNameInInvoiceReport
            .ShowWorkTypeInInvoiceDescription = ShowWorkTypeInInvoiceDescription
            .RoundOffValueInInvoice = RoundOffValueInInvoice
            .IsProjectTemplateMandatory = IsProjectTemplateMandatory
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function btnUpdateProjectInfo(ByVal AccountId As Integer, ByVal ProjectCodePrefix As String, ByVal AutoGenerateProjectCode As Boolean, ByVal ShowClientDepartmentInProject As Boolean, _
                                         ByVal ShowCompletedProjectInProjectGrid As Boolean, ByVal IncludeCurrentYearInProjectCode As Boolean, ByVal AutomaticallyIncludeAdministratorInProjectTeam As Boolean, ByVal ShowDisableProjectInReport As Boolean) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            If ProjectCodePrefix = "" Then
                .Item("ProjectCodePrefix") = ""
            Else
                .ProjectCodePrefix = ProjectCodePrefix
            End If
            .AutoGenerateProjectCode = AutoGenerateProjectCode
            .ShowClientDepartmentInProject = ShowClientDepartmentInProject
            .ShowCompletedProjectInProjectGrid = ShowCompletedProjectInProjectGrid
            .IncludeCurrentYearInProjectCode = IncludeCurrentYearInProjectCode
            .AutomaticallyIncludeAdminitratorInProjectTeam = AutomaticallyIncludeAdministratorInProjectTeam
            .ShowDisableProjectInReport = ShowDisableProjectInReport
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateGeneralPreference(ByVal AccountId As Integer, ByVal EnablePasswordComplexity As Boolean, ByVal LockSubmittedRecords As Boolean, ByVal LockApprovedRecords As Boolean, ByVal IsShowElectronicSign As Boolean, ByVal PasswordExpiryPeriod As Integer, ByVal ScheduledEmailSendTime As DateTime, ByVal AccountSessionTimeout As System.Nullable(Of Integer), ByVal PageSize As Integer, ByVal CultureInfoName As String, ByVal CurrencySymbol As String, ByVal ShowAdditionalDepartmentInformationInEmployee As Boolean, ByVal DomainName As String, ByVal IsShowEmployeeNameWithCode As Boolean, ByVal EnableGoogleAuthentication As Boolean, ByVal IsShowDisableEmployeesInReport As Boolean, ByVal ShowClockStartEndBy As String, ByVal ShowEmployeeNameBy As Integer, ByVal HideProjectFromApplication As Boolean, ByVal EnableSinglesignonSSO As Boolean, ByVal SAMLSSOURL As String) As Boolean

        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            .EnablePasswordComplexity = EnablePasswordComplexity
            .LockSubmittedRecords = LockSubmittedRecords
            .LockApprovedRecords = LockApprovedRecords
            .IsShowElectronicSign = IsShowElectronicSign
            If Not IsDBNull(.Item("PasswordExpiryPeriod")) Then
                If .PasswordExpiryPeriod <> PasswordExpiryPeriod Then
                    IsPasswordChanged = True
                End If
            Else
                If PasswordExpiryPeriod <> 0 Then
                    IsPasswordChanged = True
                End If
            End If
            .PasswordExpiryPeriod = PasswordExpiryPeriod
            .ScheduledEmailSendTime = ScheduledEmailSendTime
            .AccountSessionTimeout = AccountSessionTimeout
            .PageSize = PageSize
            .CurrencySymbol = CurrencySymbol
            .CultureInfoName = CultureInfoName
            .ShowAdditionalDepartmentInformationInEmployee = ShowAdditionalDepartmentInformationInEmployee
            .GoogleAppsDomain = DomainName
            .IsShowEmployeeNameWithCode = IsShowEmployeeNameWithCode
            .EnableGoogleAuthentication = EnableGoogleAuthentication
            .IsShowDisableEmployeesInReport = IsShowDisableEmployeesInReport
            If Not IsDBNull(Preference.Item("ShowClockStartEndBy")) Then
                If Preference.ShowClockStartEndBy <> ShowClockStartEndBy Then
                    If ShowClockStartEndBy = "Account" Then
                        Dim AccountWorkingDayTypeBLL As New AccountWorkingDayTypeBLL
                        AccountWorkingDayTypeBLL.UpdateAccountWorkingDayTypes(False, DBUtilities.GetSessionAccountId)
                    End If
                End If
            End If
            .ShowClockStartEndBy = ShowClockStartEndBy
            .ShowEmployeeNameBy = ShowEmployeeNameBy
            .HideProjectFromApplication = HideProjectFromApplication
            .EnableSingleSignOnSSO = EnableSinglesignonSSO
            If EnableSinglesignonSSO = False Then
                .SAMLSSOURL = ""
            Else
                .SAMLSSOURL = SAMLSSOURL
            End If

        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        If IsPasswordChanged Then
            objEmployeeBLL.UpdatePasswordChangedDateByAccountId(AccountId, Now)
        End If
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateOrganization(ByVal AccountId As Integer, ByVal AccountName As String, ByVal EMailAddress As String, ByVal Address1 As String, ByVal Address2 As String, _
                                       ByVal Zipcode As String, ByVal City As String, ByVal CountryId As System.Nullable(Of Short), ByVal Telephone As String, ByVal Fax As String, _
                                       ByVal TimeZoneId As System.Nullable(Of Byte)) As Boolean

        Dim Accounts As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim Account As TimeLiveDataSet.AccountRow = Accounts.Rows(0)

        With Account
            .AccountName = AccountName
            .EMailAddress = EMailAddress
            .Address1 = Address1
            .Address2 = Address2
            .ZipCode = Zipcode
            .City = City
            .CountryId = CountryId
            .Telephone = Telephone
            .Fax = Fax
            .TimeZoneId = TimeZoneId
        End With
        Dim rowsAffected As Integer = Adapter.Update(Accounts)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        'If IsPasswordChanged Then
        '    objEmployeeBLL.UpdatePasswordChangedDateByAccountId(AccountId, Now)
        'End If
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function btnUpdateTaskInfo(ByVal AccountId As Integer, ByVal ShowProjectNameInTask As Boolean, ByVal ShowClientNameInTask As Boolean, ByVal InsertDefaultTaskNameInProject As Boolean, ByVal DefaultTaskName As String, ByVal SortTaskBy As String) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            .ShowProjectNameInTask = ShowProjectNameInTask
            .ShowClientNameInTask = ShowClientNameInTask
            .InsertDefaultTaskNameInProject = InsertDefaultTaskNameInProject
            .DefaultTaskName = DefaultTaskName
            If Not IsDBNull(Preference.Item("SortTaskBy")) Then
                If Preference.SortTaskBy <> SortTaskBy Then
                    CacheManager.ClearCache("vueAccountProjectTaskDataTable", , True)
                End If
            End If
            .SortTaskBy = SortTaskBy
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function btnUpdateTimeOff(ByVal AccountId As Integer, ByVal ShowProjectForTimeOff As Boolean, ByVal ShowTimeOffTypesBy As String, ByVal IsTimeOffStatusEditMode As Boolean, ByVal ShowTimeOffInTimesheet As System.Nullable(Of Boolean), ByVal IsShowTimeOffInDays As Boolean) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            .ShowProjectForTimeOff = ShowProjectForTimeOff
            .ShowTimeOffTypesBy = ShowTimeOffTypesBy
            .IsTimeOffStatusEditMode = IsTimeOffStatusEditMode
            .ShowTimeOffInTimesheet = ShowTimeOffInTimesheet
            .IsShowTimeOffInDays = IsShowTimeOffInDays
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateTimesheetSetup(ByVal AccountId As Integer, ByVal ShowClockStartEnd As System.Nullable(Of Boolean), ByVal ShowClientInTimesheet As System.Nullable(Of Boolean), ByVal ShowDescriptionInWeekView As System.Nullable(Of Boolean), ByVal ShowCompletedProjectsInTimeSheet As System.Nullable(Of Boolean), _
                                         ByVal ShowCompletedTasksInTimeSheet As System.Nullable(Of Boolean), ByVal ShowWorkTypeInTimeSheet As Boolean, ByVal ShowCostCenterInTimeSheet As Boolean, _
                                         ByVal ShowAllInTimesheetReadOnly As System.Nullable(Of Boolean), ByVal ShowPercentageInTimesheet As Boolean, ByVal NumberOfBlankRowsInTimeEntry As Short, _
                                         ByVal TimesheetOverduePeriods As Short, ByVal TimeEntryHoursFormatId As Guid, ByVal TimeEntryFormat As String, ByVal ShowAdditionalTaskInformationType As Integer, ByVal DefaultTimeEntryMode As String, _
                                         ByVal TimesheetPrintFooter As String, ByVal TimesheetSort As String, ByVal ShowCostCenterInTimesheetBy As String, ByVal ShowCopyActivitiesButtonInTimesheet As Boolean, ByVal ShowCopyTimesheetButton As Boolean, _
                                         ByVal CalculateTaskPercentageAutomatically As Boolean, ByVal ShowAdditionalProjectInformationType As Integer, ByVal EnableOfflineTimesheet As Boolean, ByVal DefaultProjectTaskSelectionInTimesheet As Boolean, ByVal AutoResizeTimesheet As Boolean, ByVal ShowProjectInTimesheet As Boolean) As Boolean
        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Preference = Preferences.Rows(0)
        With Preference
            .ShowClockStartEnd = ShowClockStartEnd
            .ShowClientInTimesheet = ShowClientInTimesheet
            .TimeEntryFormat = TimeEntryFormat
            .ShowCompletedTasksInTimeSheet = ShowCompletedTasksInTimeSheet
            .ShowWorkTypeInTimeSheet = ShowWorkTypeInTimeSheet
            .NumberOfBlankRowsInTimeEntry = NumberOfBlankRowsInTimeEntry
            .ShowCostCenterInTimeSheet = ShowCostCenterInTimeSheet
            '.WeekStartDay = WeekStartDay
            .DefaultTimeEntryMode = DefaultTimeEntryMode
            .ShowDescriptionInWeekView = ShowDescriptionInWeekView
            .ShowAdditionalTaskInformationType = ShowAdditionalTaskInformationType
            .ShowCompletedProjectsInTimeSheet = ShowCompletedProjectsInTimeSheet
            .ShowAllInTimesheetReadOnly = ShowAllInTimesheetReadOnly
            .TimesheetOverduePeriods = TimesheetOverduePeriods
            .ShowPercentageInTimesheet = ShowPercentageInTimesheet
            .TimesheetPrintFooter = TimesheetPrintFooter
            .TimesheetSort = TimesheetSort
            .ShowCostCenterInTimesheetBy = ShowCostCenterInTimesheetBy
            .ShowCopyActivitiesButtonInTimesheet = ShowCopyActivitiesButtonInTimesheet
            .ShowCopyTimesheetButton = ShowCopyTimesheetButton
            .CalculateTaskPercentageAutomatically = CalculateTaskPercentageAutomatically
            .ShowAdditionalProjectInformationType = ShowAdditionalProjectInformationType
            .EnableOfflineTimesheet = EnableOfflineTimesheet
            .DefaultProjectTaskSelectionInTimesheet = DefaultProjectTaskSelectionInTimesheet
            .AutoResizeTimesheet = AutoResizeTimesheet
            .ShowProjectInTimesheet = ShowProjectInTimesheet
            If TimeEntryHoursFormatId <> System.Guid.Empty Then
                .TimeEntryHoursFormatId = TimeEntryHoursFormatId
            Else
                .Item("TimeEntryHoursFormatId") = System.DBNull.Value
            End If
        End With
        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)
        If TimesheetSort <> DBUtilities.GetSortTimesheet Then
            CacheManager.ClearCache("vueAccountEmployeeTimeEntryWithStatusDataTable", "", , True)
            CacheManager.ClearCache("vueAccountEmployeeTimeEntryWithStatusGroupedDataTable", "", , True)
        End If
        If ShowCostCenterInTimesheetBy <> DBUtilities.GetCostCenterInTimesheetBy Then
            CacheManager.ClearCache("AccountCostCenterDataTable", , True)
        End If
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateApplicationVersion(ByVal Version As String, ByVal AccountId As Integer) As Boolean

        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)

        Preference = Preferences.Rows(0)

        With Preference
            .Version = Version
        End With



        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)


        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1



    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountBaseCurrencyId(ByVal Original_AccountId As Integer, ByVal AccountBaseCurrencyId As Integer) As Boolean

        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(Original_AccountId)

        Preference = Preferences.Rows(0)

        With Preference
            .AccountBaseCurrencyId = AccountBaseCurrencyId
        End With

        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    Public Function UpdateDefaultAccountBaseCurrencyId(ByVal Original_AccountId As Integer, ByVal AccountCurrencyId As Integer) As Boolean

        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(Original_AccountId)

        Preference = Preferences.Rows(0)

        With Preference
            .AccountBaseCurrencyId = AccountCurrencyId
            .AccountReimbursementCurrencyId = AccountCurrencyId
        End With

        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountReimbursementCurrencyId(ByVal Original_AccountId As Integer, ByVal AccountReimbursementCurrencyId As Integer) As Boolean

        Dim Preference As AccountPreferences.AccountPreferencesRow
        Dim Preferences As AccountPreferences.AccountPreferencesDataTable
        Preferences = Me.AccountPreferencesTableAdapter.GetDataByAccountId(Original_AccountId)

        Preference = Preferences.Rows(0)

        With Preference
            .AccountReimbursementCurrencyId = AccountReimbursementCurrencyId
        End With

        Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(Preferences)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    Public Shared Function IfCurrencyNotExist()
        Dim dtCurrencies As AccountCurrency.AccountCurrencyDataTable = New AccountCurrencyBLL().GetAccountCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim drCurrencies As AccountCurrency.AccountCurrencyRow

        If dtCurrencies.Rows.Count = 0 Then
            InsertDefaultDataForVersion2_71_0002()
            InsertDefaultDataForVersion2_71_0003()
        End If
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAllAccountLastScheduledEmailSentTime() As Boolean
        Me.AccountPreferencesTableAdapter.UpdateLastScheduledEmailSentTime(Now)
    End Function
    Public Function UpdateIsDisableForAccountClosed(ByVal AccountId As Integer) As Boolean
        Me.Adapter.UpdateIsDisabledForAccountDisable(AccountId)
    End Function
    Public Function UpdateUILanguage(ByVal UserInterfaceLanguage As String, ByVal AccountId As Integer) As Boolean
        AccountPreferencesTableAdapter.UpdateUserInterfaceLanguageByAccountId(UserInterfaceLanguage, AccountId)
    End Function
    Public Function GetLicenseID(ByVal AccountId As Integer) As String
        Dim Accounts As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim Account As TimeLiveDataSet.AccountRow = Accounts.Rows(0)
        Return Account.LicenseId
    End Function
    Public Sub UpdateLicenseInformation(ByVal AccountId As Integer, ByVal MachineId As String, ByVal ActivationMachineKey As String, ByVal ActivationType As String, ByVal ActivationLicenseKey As String, ByVal NumberOfUsers As Integer)
        Dim Accounts As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim Account As TimeLiveDataSet.AccountRow = Accounts.Rows(0)

        With Account
            If Not MachineId = "" Then
                .MachineId = MachineId
            End If
            If Not ActivationMachineKey = "" Then
                .ActivationMachineKey = ActivationMachineKey
            End If
            If Not ActivationType = "" Then
                .ActivationType = ActivationType
            End If
            If Not ActivationLicenseKey = "" Then
                .ActivationLicenseKey = ActivationLicenseKey
            End If
            .LicenseId = LicensingBLL.GetEncryptedStringAsBase64(NumberOfUsers)
        End With

        Dim rowsAffected As Integer = Adapter.Update(Account)

    End Sub
    Public Function UpdateWizardInformation(ByVal AccountId As Integer, CultureInfoName As String, TimeZoneId As Byte, _
                                            UserInterfaceLanguage As String, ShowEmployeeNameBy As Integer, NumberOfBlankRowsInTimeEntry As Short, _
                                            ShowClockStartEnd As Boolean, ShowClientInTimesheet As Boolean, TimeEntryHoursFormatId As Guid, _
                                            SystemCurrencyId As Integer, SmtpServer As String, SmtpServerUserName As String, SmtpServerPassword As String, _
                                            SmtpPortnumber As String, EnableSSL As Boolean, AccountTimesheetPeriodTypeId As Guid) As Boolean
        '--currency in accountcurrency and set base currency
        '--ShowClockStartEndEmployee(workingday)
        'UpdateDefaultAccountBaseCurrencyId
        Dim currencybll As New AccountCurrencyBLL
        Dim currencyExchangeratebll As New AccountCurrencyExchangeRateBLL
        Dim AccountCurrencyId As Integer = currencybll.AddCurrencyFromWizard(SystemCurrencyId, AccountId)
        If AccountCurrencyId <> 0 Then
            currencybll.AddAccountCurrencyForExchangeRate(Convert.ToDecimal(1), Date.Today, Date.Today.AddYears(1))
            currencyExchangeratebll.UpdateBaseCurrencyExchangeRateFromWizard(AccountId, AccountCurrencyId)
        End If
        Dim dtPreference As AccountPreferences.AccountPreferencesDataTable = Me.AccountPreferencesTableAdapter.GetDataByAccountId(AccountId)
        Dim drPreference As AccountPreferences.AccountPreferencesRow
        Dim dtAccount As TimeLiveDataSet.AccountDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim drAccount As TimeLiveDataSet.AccountRow
        If dtAccount.Rows.Count > 0 Then
            drAccount = dtAccount.Rows(0)
            With drAccount
                .TimeZoneId = TimeZoneId
            End With
            Dim rowsAffected As Integer = Adapter.Update(dtAccount)
        End If
        If dtPreference.Rows.Count > 0 Then
            drPreference = dtPreference.Rows(0)
            With drPreference
                .CultureInfoName = CultureInfoName
                .UserInterfaceLanguage = UserInterfaceLanguage
                .ShowEmployeeNameBy = ShowEmployeeNameBy
                .NumberOfBlankRowsInTimeEntry = NumberOfBlankRowsInTimeEntry
                .ShowClockStartEnd = ShowClockStartEnd
                .ShowClientInTimesheet = ShowClientInTimesheet
                .TimeEntryHoursFormatId = TimeEntryHoursFormatId
                If AccountCurrencyId <> 0 Then
                    .AccountBaseCurrencyId = AccountCurrencyId
                    .AccountReimbursementCurrencyId = AccountCurrencyId
                End If
            End With
            Dim rowsAffected As Integer = AccountPreferencesTableAdapter.Update(dtPreference)
            rowsAffected = 1
        End If
        Dim workingbll As New AccountWorkingDayTypeBLL
        workingbll.UpdateWorkindDayFromWizard(DBUtilities.GetSessionAccountWorkingDayTypeId, AccountTimesheetPeriodTypeId)
        If UIUtilities.GetApplicationMode <> "Hosted" Then
            If SmtpServer <> "" Then
                UIUtilities.ModifyAppSettings("SmtpServer", SmtpServer)
            End If
            If SmtpServerUserName <> "" Then
                UIUtilities.ModifyAppSettings("SmtpServerUserName", SmtpServerUserName)
            End If
            If SmtpServerPassword <> "" Then
                UIUtilities.ModifyAppSettings("SmtpServerPassword", SmtpServerPassword)
            End If
            If SmtpPortnumber <> "" Then
                UIUtilities.ModifyAppSettings("SmtpPortnumber", SmtpPortnumber)
            End If
            UIUtilities.ModifyAppSettings("EnableSSL", EnableSSL)
        End If
        Dim objEmployeeBLL As New AccountEmployeeBLL
        objEmployeeBLL.UpdateTimeZoneIdByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId, TimeZoneId)
        objEmployeeBLL.SetSessionValues(Nothing, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    Public Sub UpdateIsWizardSkipByAccountId(AccountId As Integer)
        Adapter.UpdateIsWizardSkip(AccountId)
    End Sub
End Class
