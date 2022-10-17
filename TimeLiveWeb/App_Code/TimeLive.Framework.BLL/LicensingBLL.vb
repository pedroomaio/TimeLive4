Imports Microsoft.VisualBasic
Imports InteractiveStudios.QlmLicenseLib
Imports System.Security
Imports System.Security.Cryptography

Public Class LicensingBLL
    Public Const ACTIVATION_PRODUCT_ID = 2
    Public Const ACTIVATION_PRODUCT_NAME = "TimeLive Web Timesheet"
    Public Const ACTIVATION_PRODUCT_KEY = "TLDE"
    Public Const ACTIVATION_GUID_KEY = "{F37FC02F-13E6-4255-AA98-AF526FCA16FE}"
    Public Const ACTIVATION_VERSION_MAJOR = 2
    Public Const ACTIVATION_VERSION_MINOR = 95
    Public Const ACTIVATION_COMMUNICATION_KEY = "{B6163D99-F46A-4580-BB42-BF276A507A14}"
    Public Const ACTIVATION_URL = "http://licensemanager.livetecs.com/"
    Public Const ACTIVATION_APP_SETTING_PARAMETER_NAME = "ActivationURL"
    Public Const ENCRYPTION_KEY = "zooooooooooo123"
    Public Const TRAKLIVE_ACTIVATION_PRODUCT_ID = 4
    Public Const TRAKLIVE_ACTIVATION_PRODUCT_NAME = "TrakLive Bug Tracking"
    Public Const TRAKLIVE_ACTIVATION_PRODUCT_KEY = "ITDE"
    Public Const TRAKLIVE_ACTIVATION_GUID_KEY = "{C447C2E5-BCDE-48EC-8B2D-2383D8249B84}"
    Public Const TRAKLIVE_ACTIVATION_VERSION_MAJOR = 6
    Public Const TRAKLIVE_ACTIVATION_VERSION_MINOR = 2

    Public Function ActivateLicenseKey(ByVal strLicenseKey As String, ByVal AccountId As Integer) As Boolean

        If Left(strLicenseKey, 4) = "TLDE" Then
            Me.ActivateProduct(strLicenseKey, AccountId)
            Return True
        Else
            Return False
        End If

    End Function
    Public Shared Function IsExpiryDateValid(ByVal strExpiryDateActivation As Object) As Boolean

        If IsDBNull(strExpiryDateActivation) Then
            Return False
        ElseIf strExpiryDateActivation = "" Then
            Return False
        Else
            If LicensingBLL.GetAccountExpiryDateFromDateString(GetStringFromEncryptedValue(strExpiryDateActivation)) > Now.Date Then
                Return True
            Else
                Return False
            End If
        End If

    End Function
    Public Shared Function IsUnlimitedLicense(ByVal strLicenseActivation As Object) As Boolean

        If IsDBNull(strLicenseActivation) Then
            Return False
        Else
            If GetStringFromEncryptedValue(strLicenseActivation).Substring(0, 4) = "TLDE" Then
                Return True
            Else
                Return False
            End If
        End If

    End Function
    Public Shared Function IsUserIsAllowedToLogin(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer, ByVal AccountExpiryActivation As Object, ByVal LicenseActivation As Object)
        Dim NumberOfAllowedUser As Integer = LicensingBLL.GetNumberOfUsersAllowed(AccountId)
        Dim TotalUsers As Integer = AccountEmployeeBLL.GetAccountEmployeesByAccountIdCount(AccountId)
        If (TotalUsers = NumberOfAllowedUser And LicensingBLL.IsExpiryDateValid(AccountExpiryActivation)) Or IsUnlimitedLicense(LicenseActivation) Then
            Return True
        End If
        If TotalUsers > NumberOfAllowedUser Then
            If New AccountEmployeeBLL().GetAccountEmployeesByNumberOfUsersAllowed(AccountId, AccountEmployeeId, NumberOfAllowedUser).Count > 0 Then
                Return True
            Else
                LoggingBLL.WriteToLog("LicensingBLL:IsUserIsAllowedToLogin: User is not available in top " & NumberOfAllowedUser & ": AccountId = " & AccountId & " EmployeeId " & AccountEmployeeId)
                Throw New Exception("Only top " & NumberOfAllowedUser & " user(s) can login in your TimeLive account.")
                Return False
            End If
        Else
            Return True
        End If

    End Function
    Public Shared Function IsFreeAccount(ByVal AccountId As Integer)
        If Not UIUtilities.DisableLicense Then
            Dim dtAccount As TimeLiveDataSet.AccountDataTable = New AccountBLL().GetDataByAccountId(AccountId)
            If dtAccount.Rows.Count > 0 Then
                Dim Account As TimeLiveDataSet.AccountRow = dtAccount.Rows(0)
                If IsHosted() Then
                    If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False Then
                        Return True
                    End If
                End If
                If IsLocalInstalled() Then
                    If IsDBNull(Account.Item("ActivationType")) Then
                        If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False Then
                            Return True
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Public Shared Function IsHostedPaidCustomerLicenseExpired(ByVal AccountId As Integer)
        If Not UIUtilities.DisableLicense And IsHosted() Then
            Dim dtAccount As TimeLiveDataSet.AccountDataTable = New AccountBLL().GetDataByAccountId(AccountId)
            If dtAccount.Rows.Count > 0 Then
                Dim Account As TimeLiveDataSet.AccountRow = dtAccount.Rows(0)
                If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False And Not IsDBNull(Account.item("LicenseID")) Then
                    Return True
                End If
            End If
        End If
    End Function
    Public Shared Function IsHostedFreeCustomerLicenseExpired(ByVal AccountId As Integer)
        Dim dtAccount As TimeLiveDataSet.AccountDataTable = New AccountBLL().GetDataByAccountId(AccountId)
        If dtAccount.Rows.Count > 0 Then
            Dim Account As TimeLiveDataSet.AccountRow = dtAccount.Rows(0)
            If IsHosted() Then
                If Not UIUtilities.DisableLicense And IsHosted() Then
                    If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False And IsDBNull(Account.Item("LicenseID")) Then
                        Return True
                    End If
                End If
            ElseIf IsLocalInstalled() And IsValidLicenseActivation(AccountId) = False Then
                If IsDBNull(Account.Item("ActivationType")) Then
                    If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False Then
                        Return True
                    End If
                End If
            End If
        End If
    End Function
    Public Shared Function GetNumberOfUsersAllowed(ByVal AccountId As Integer) As Integer

        Dim Account As TimeLiveDataSet.AccountRow = New AccountBLL().GetAccountByAccountId(AccountId)
        If Account.LicenseActivation = "" Then
            Return LicensingBLL.GetNumberOfUserOfPackage("Lite", GetAccountExpiryDateFromDateString(LicensingBLL.GetStringFromEncryptedValue(Account.Item("AccountExpiryActivation"))))
        End If

        Dim LicenseKey As String
        LicenseKey = LicensingBLL.GetStringFromEncryptedValue(Account.LicenseActivation)

        If Account.AccountExpiryActivation <> "" Then
            Return GetNumberOfUserOfPackage(LicenseKey, GetAccountExpiryDateFromDateString(GetStringFromEncryptedValue(Account.AccountExpiryActivation)))
        Else
            Return GetNumberOfUserOfPackage(LicenseKey, GetAccountExpiryDateFromDateString(Account.AccountExpiryActivation))
        End If

    End Function
    Public Shared Function GetDecryptedLicenseKey() As String
        Dim Account As TimeLiveDataSet.AccountRow = New AccountBLL().GetAccountByAccountId(DBUtilities.GetSessionAccountId)
        If IsDBNull(Account("LicenseActivation")) Then
            Return ""
        ElseIf Account("LicenseActivation") = "" Then
            Return ""
        Else
            Dim LicenseKey As String = LicensingBLL.GetStringFromEncryptedValue(Account.LicenseActivation)
            Return LicenseKey
        End If
    End Function
    Public Shared Function GetPackgeOfProductCode(ByVal ProductCode As String)
        If ProductCode.Substring(0, 3) = "TLH" Then
            Return ProductCode.Substring(0, 4)
        ElseIf ProductCode.Substring(0, 3) = "TH4" Then
            Return ProductCode
        ElseIf ProductCode.Substring(0, 3) = "TH5" Then
            Return ProductCode
        ElseIf ProductCode.Substring(0, 4) = "TLBT" Then
            Return ProductCode
        ElseIf ProductCode.Substring(0, 2) = "TH" Then
            Return ProductCode.Substring(0, ProductCode.IndexOf("_", 3))
        ElseIf ProductCode.Contains("_STANDARD") Then
            Return ProductCode
        End If
    End Function
    Public Shared Function GetNumberOfUserOfPackage(ByVal strPackagePrefix As String, ByVal dtExpiry As Date) As Integer
        If System.Configuration.ConfigurationManager.AppSettings("DISABLE_LICENSE") = "Yes" Then
            Return 99999
        End If
        If IsValidLicenseActivation() = True And LicensingBLL.IsLocalInstalled Then
            Return GetValidatedLicenseNumberOfUsers()
        ElseIf dtExpiry.Date >= Now.Date Then
            Return New SystemLicenseBLL().GetNumberOfUserOfPackage(strPackagePrefix, False)
        Else
            If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                Return 3
            End If
            Return 5
        End If
    End Function
    Public Shared Function GetNumberOfUsersAllowedFromLicenseActivation(ByVal strLicenseActivation As Object) As Integer
        Return GetNumberOfUserOfPackage("", LicensingBLL.GetAccountExpiryDateFromDateString(LicensingBLL.GetStringFromEncryptedValue(strLicenseActivation)))
    End Function
    Public Shared Function GetNumbeOfUsers(ByVal strLicenseActivation As Object) As Integer
        Return GetNumberOfUserOfPackage("", LicensingBLL.GetAccountExpiryDateFromDateString(LicensingBLL.GetStringFromEncryptedValue(strLicenseActivation)))
    End Function
    Public Shared Function GetAccountExpiryDateFromDateString(ByVal strDate As String) As Date
        If strDate = "" Then
            Return Now.AddDays(-1)
        End If
        Return New Date(strDate.Substring(0, 4), strDate.Substring(4, 2), strDate.Substring(6, 2))
    End Function
    Private Sub ActivateProduct(ByVal strLicenseKey As String, ByVal AccountId As Integer)
        Dim objAccountBLL As New AccountBLL
        objAccountBLL.UpdateLicenseKey(strLicenseKey, AccountId)
    End Sub
    Public Shared Function GetEncryptedStringAsBase64(ByVal LicenseKey As String) As String

        Dim sec As New Encryption.Symmetric(Encryption.Symmetric.Provider.DES)

        Dim keyData As New Encryption.Data(LicensingBLL.ENCRYPTION_KEY)
        Dim ivData As New Encryption.Data(LicenseKey)

        Dim EncryptedValue As Encryption.Data = sec.Encrypt(ivData, keyData)

        Return EncryptedValue.ToBase64

    End Function
    Public Shared Function GetEncryptedStringAsBase64ByUTF8(EncryptedValue As String) As String
        Dim Results As Byte()
        Dim UTF8 As New System.Text.UTF8Encoding()
        Dim HashProvider As New MD5CryptoServiceProvider()
        Dim TDESKey As Byte() = HashProvider.ComputeHash(UTF8.GetBytes(LicensingBLL.ENCRYPTION_KEY))
        Dim TDESAlgorithm As New TripleDESCryptoServiceProvider()
        TDESAlgorithm.Key = TDESKey
        TDESAlgorithm.Mode = CipherMode.ECB
        TDESAlgorithm.Padding = PaddingMode.PKCS7
        Dim DataToEncrypt As Byte() = UTF8.GetBytes(EncryptedValue)
        Try
            Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor()
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)
        Finally
            TDESAlgorithm.Clear()
            HashProvider.Clear()
        End Try
        Return Convert.ToBase64String(Results)
    End Function
    Public Shared Function GetStringFromEncryptedValueByUTF8(EncryptedValue As String) As String
        Dim Results As Byte()
        Dim UTF8 As New System.Text.UTF8Encoding()
        Dim HashProvider As New MD5CryptoServiceProvider()
        Dim TDESKey As Byte() = HashProvider.ComputeHash(UTF8.GetBytes(LicensingBLL.ENCRYPTION_KEY))
        Dim TDESAlgorithm As New TripleDESCryptoServiceProvider()
        TDESAlgorithm.Key = TDESKey
        TDESAlgorithm.Mode = CipherMode.ECB
        TDESAlgorithm.Padding = PaddingMode.PKCS7
        Dim DataToDecrypt As Byte() = Convert.FromBase64String(EncryptedValue)
        Try
            Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor()
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)
        Finally
            TDESAlgorithm.Clear()
            HashProvider.Clear()
        End Try
        Return UTF8.GetString(Results)
    End Function
    Public Shared Function GetStringFromEncryptedValue(ByVal EncryptedValue As Object) As String
        If IsDBNull(EncryptedValue) Then
            Return ""
        End If
        Dim keyData As New Encryption.Data(LicensingBLL.ENCRYPTION_KEY)
        Dim ivData As New Encryption.Data()
        ivData.Base64 = EncryptedValue

        Dim sec As New Encryption.Symmetric(Encryption.Symmetric.Provider.DES)
        Dim DecryptedValue As Encryption.Data = sec.Decrypt(ivData, keyData)

        Return DecryptedValue.Text
    End Function
    Public Shared Function ActivateLincese(ByVal ActivationKey As String, ByVal ActivationType As String, ByVal IsOnlineActivation As Boolean, ByVal MachineKey As String, ByVal MachineName As String) As Boolean
        Dim AccountBLL As New AccountBLL
        Dim licenseInfo As ILicenseInfo = New LicenseInfo()
        Dim license As New QlmLicense
        Dim machineID As String = LicensingBLL.GetMachineID()
        Dim message As String = String.Empty
        SetLicenseDefineProduct(license)
        license.CommunicationEncryptionKey = ACTIVATION_COMMUNICATION_KEY
        Try
            If IsOnlineActivation Then
                Dim response As String = String.Empty
                license.ActivateLicense(GetApplicationURL, ActivationKey, machineID, machineID, "4.0.00", "", response)
                If license.ParseResults(response, licenseInfo, message) Then
                    response = ""
                    Dim NumberOfUsers As String = license.GetUserData(GetApplicationURL, ActivationKey, response)
                    If NumberOfUsers = "" Then
                        NumberOfUsers = "0"
                    End If
                    AccountBLL.UpdateLicenseInformation(DBUtilities.GetSessionAccountId, machineID, licenseInfo.ComputerKey, ActivationType, ActivationKey, NumberOfUsers)
                    LicensingBLL.UpdateFeaturesOfAccounts()
                    Return True
                Else
                    Return False
                End If
            Else
                If license.ValidateMachineLicenseEx(ActivationKey, MachineKey, MachineName, message) = True Then
                    AccountBLL.UpdateLicenseInformation(DBUtilities.GetSessionAccountId, MachineName, MachineKey, ActivationType, ActivationKey, license.NumberOfLicenses)
                    LicensingBLL.UpdateFeaturesOfAccounts()
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Sub UpdateFeaturesOfAccounts()
        Dim FeatureBll As New AccountFeatureManagementBLL
        Dim TimeOffSystemFeatureId As Object
        TimeOffSystemFeatureId = New System.Guid("76aaf57e-96a4-4476-94a4-575824e9b9fa")
        Dim dtTimeOff As AccountFeatureManagement.AccountFeaturesDataTable = FeatureBll.GetAccountFeatureByAccountIdAndSystemFeatureId(DBUtilities.GetSessionAccountId, TimeOffSystemFeatureId)
        Dim drTimeOff As AccountFeatureManagement.AccountFeaturesRow
        If dtTimeOff.Rows.Count > 0 Then
            drTimeOff = dtTimeOff.Rows(0)
            If IsTimeOffFeature() = False Then
                FeatureBll.DeleteAccountFeatureData(drTimeOff.AccountId, drTimeOff.SystemFeatureId)
            End If
        End If
        Dim TimesheetSystemFeatureId As Object
        TimesheetSystemFeatureId = New System.Guid("db17deb7-51a0-4400-bf3b-9094e01ef038")
        Dim dtTimesheet As AccountFeatureManagement.AccountFeaturesDataTable = FeatureBll.GetAccountFeatureByAccountIdAndSystemFeatureId(DBUtilities.GetSessionAccountId, TimesheetSystemFeatureId)
        Dim drTimesheet As AccountFeatureManagement.AccountFeaturesRow
        If dtTimesheet.Rows.Count > 0 Then
            drTimesheet = dtTimesheet.Rows(0)
            If IsTimesheetFeature() = False Then
                FeatureBll.DeleteAccountFeatureData(drTimesheet.AccountId, drTimesheet.SystemFeatureId)
            End If
        End If
        Dim ExpenseSystemFeatureId As Object
        ExpenseSystemFeatureId = New System.Guid("537f44e5-ec0f-4de6-aa29-09450961c5e9")
        Dim dtExpensesheet As AccountFeatureManagement.AccountFeaturesDataTable = FeatureBll.GetAccountFeatureByAccountIdAndSystemFeatureId(DBUtilities.GetSessionAccountId, ExpenseSystemFeatureId)
        Dim drExpensesheet As AccountFeatureManagement.AccountFeaturesRow
        If dtExpensesheet.Rows.Count > 0 Then
            drExpensesheet = dtExpensesheet.Rows(0)
            If IsExpenseSheetFeature() = False Then
                FeatureBll.DeleteAccountFeatureData(drExpensesheet.AccountId, drExpensesheet.SystemFeatureId)
            End If
        End If
    End Sub
    Public Shared Function GetMachineID() As String
        Return Environment.MachineName
    End Function
    Public Shared Function GetAccountLicense(Optional ByVal AccountId As Integer = 0) As QlmLicense
        If AccountId = 0 Then
            AccountId = DBUtilities.GetSessionAccountId
        Else
            AccountId = AccountId
        End If
        Dim drAccount As TimeLiveDataSet.AccountRow = New AccountBLL().GetAccountByAccountId(AccountId)
        Dim message As String = String.Empty
        Dim license As New QlmLicense
        SetLicenseDefineProduct(license)
        license.CommunicationEncryptionKey = ACTIVATION_COMMUNICATION_KEY
        If Not IsDBNull(drAccount.Item("ActivationMachineKey")) Then
            If license.ValidateMachineLicenseEx("", drAccount.ActivationMachineKey, GetMachineID, message) = True Then
                Return license
            End If
        End If
        Return license
    End Function
    Public Shared Function IsValidLicenseActivation(Optional ByVal AccountId As Integer = 0) As Boolean
        Dim license As QlmLicense = GetAccountLicense(AccountId)
        If license.IsValid Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function GetValidatedLicenseNumberOfUsers() As Integer
        Dim license As QlmLicense = GetAccountLicense()
        If license.IsFeatureEnabledEx(1, 32) Then
            Return 10
        ElseIf license.IsFeatureEnabledEx(1, 16) Then
            Return 25
        ElseIf license.IsFeatureEnabledEx(1, 8) Then
            Return 50
        ElseIf license.IsFeatureEnabledEx(1, 4) Then
            Return 75
        ElseIf license.IsFeatureEnabledEx(1, 2) Then
            Return 100
        ElseIf license.IsFeatureEnabledEx(1, 2) Then
            Return 100
        ElseIf license.IsFeatureEnabledEx(1, 1) Then
            Return 99999
        ElseIf IsFeaturesBasedLicense() Then
            Return LicensingBLL.GetStringFromEncryptedValue(New AccountBLL().GetLicenseID(DBUtilities.GetSessionAccountId))
        ElseIf UIUtilities.IsTrakLiveApplication Then
            Return LicensingBLL.GetStringFromEncryptedValue(New AccountBLL().GetLicenseID(DBUtilities.GetSessionAccountId))
        ElseIf license.NumberOfLicenses > 1 Then
            Return license.NumberOfLicenses
        Else
            Return 99999
        End If
    End Function
    Public Shared Function IsFeaturesBasedLicense() As Boolean
        If IsTimesheetFeature(True) Or IsExpenseSheetFeature(True) Or IsTimeOffFeature(True) Or IsQuickBooksFeature(True) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsFeaturesBasedHosted() As Boolean
        If LicensingBLL.IsHosted Then
            If LicensingBLL.GetDecryptedLicenseKey.Contains("_STANDARD") Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Shared Function IsTimesheetFeature(Optional IsLicensed As Boolean = False) As Boolean
        If LicensingBLL.IsLocalInstalled Then
            Dim license As QlmLicense = GetAccountLicense()
            If IsLicensed = True Then
                Return license.IsFeatureEnabledEx(2, 1)
            ElseIf LicensingBLL.IsValidLicenseActivation = True And IsFeaturesBasedLicense() Then
                Return license.IsFeatureEnabledEx(2, 1)
            Else
                Return True
            End If
        ElseIf LicensingBLL.IsFeaturesBasedHosted Then
            Return LicensingBLL.GetDecryptedLicenseKey().Contains("TIMESHEET")
        ElseIf IsHostedEnterprise() Then
            Return True
        Else
            Return True
        End If
    End Function
    Public Shared Function IsHostedEnterprise() As Boolean
        If LicensingBLL.GetDecryptedLicenseKey().Contains("99999") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsExpenseSheetFeature(Optional IsLicensed As Boolean = False) As Boolean
        If LicensingBLL.IsLocalInstalled Then
            Dim license As QlmLicense = GetAccountLicense()
            If IsLicensed = True Then
                Return license.IsFeatureEnabledEx(2, 2)
            ElseIf LicensingBLL.IsValidLicenseActivation = True And IsFeaturesBasedLicense() Then
                Return license.IsFeatureEnabledEx(2, 2)
            Else
                Return True
            End If
        ElseIf LicensingBLL.IsFeaturesBasedHosted Then
            Return LicensingBLL.GetDecryptedLicenseKey().Contains("EXPENSE")
        ElseIf IsHostedEnterprise() Then
            Return True
        Else
            Return True
        End If
    End Function
    Public Shared Function IsTimeOffFeature(Optional IsLicensed As Boolean = False) As Boolean
        If LicensingBLL.IsLocalInstalled Then
            Dim license As QlmLicense = GetAccountLicense()
            If IsLicensed = True Then
                Return license.IsFeatureEnabledEx(2, 4)
            ElseIf LicensingBLL.IsValidLicenseActivation = True And IsFeaturesBasedLicense() Then
                Return license.IsFeatureEnabledEx(2, 4)
            Else
                Return True
            End If
        ElseIf LicensingBLL.IsFeaturesBasedHosted Then
            Return LicensingBLL.GetDecryptedLicenseKey().Contains("TIMEOFF")
        ElseIf IsHostedEnterprise() Then
            Return True
        Else
            Return True
        End If
    End Function
    Public Shared Function IsQuickBooksFeature(Optional IsLicensed As Boolean = False) As Boolean
        If LicensingBLL.IsLocalInstalled Then
            Dim license As QlmLicense = GetAccountLicense()
            If IsLicensed = True Then
                Return license.IsFeatureEnabledEx(2, 8)
            ElseIf LicensingBLL.IsValidLicenseActivation = True And IsFeaturesBasedLicense() Then
                Return license.IsFeatureEnabledEx(2, 8)
            Else
                Return True
            End If
        ElseIf LicensingBLL.IsFeaturesBasedHosted Then
            Return LicensingBLL.GetDecryptedLicenseKey().Contains("QB")
        ElseIf IsHostedEnterprise() Then
            Return True
        Else
            Return True
        End If
    End Function
    Public Shared Function GetApplicationURL() As String
        If System.Configuration.ConfigurationManager.AppSettings(ACTIVATION_APP_SETTING_PARAMETER_NAME) Is Nothing Then
            Return ACTIVATION_URL
        Else
            Return System.Configuration.ConfigurationManager.AppSettings(ACTIVATION_APP_SETTING_PARAMETER_NAME)
        End If
    End Function
    Public Shared Function GetPaymentURL(ByVal RequestObject As System.Web.HttpRequest, ByVal CustomerId As Integer)
        Dim ProductId As String = RequestObject.QueryString("Mode")
        Dim PaymentURL As String = "https://secure.avangate.com/order/product.php?PRODS=" & ProductId & "&QTY=1&REF=" & CustomerId
        Return PaymentURL
    End Function
    Public Shared Function GetCurrentPackageRow() As DataRow
        Dim dtPackages As DataTable = GetHostedPackagesOfCurrentUsers()
        Dim CurrentHostedPackage As String = GetCurrentHostedPackage()
        Return GetRowOfPackage(CurrentHostedPackage)
    End Function
    Public Shared Function GetRowOfPackage(ByVal PackageCode As String) As DataRow
        Dim dtPackages As DataTable = GetHostedPackagesOfCurrentUsers()
        Dim drSearched() As DataRow = dtPackages.Select("PackageCode='" & PackageCode & "'")
        Return drSearched(0)
    End Function
    Public Shared Function GetHostedPackagesOfCurrentUsers() As DataTable
        Return GetHostedPackages()
    End Function
    Public Shared Function GetCurrentHostedPackage() As String
        Dim LicenseKey As String = GetCurrentHostedPackageKey()
        Return LicenseKey
    End Function
    Public Shared Sub ChangeHostedPlan(ByVal PackageCode As String)
        Dim CurrentPackageCode As String = GetCurrentPackageRow("PackageCode")
        If CurrentPackageCode <> PackageCode Then
            Dim NewPaymentProduct As String = GetRowOfPackage(PackageCode)("ProductCode")
            'Dim CustomerBLL As New LTCustomerBLL
            'Dim drCustomer As TimeLiveDataSet.LTCustomerRow = CustomerBLL.GetLTCustomerByAccountId(DBUtilities.GetSessionAccountId)
            Dim PaymentURL As String = String.Format("https://secure.avangate.com/order/product.php?PRODS={0}&QTY=1&REF={1}", NewPaymentProduct, DBUtilities.GetSessionAccountId)
            System.Web.HttpContext.Current.Response.Redirect(PaymentURL, False)
        End If
    End Sub
    Public Shared Function GetLicense() As String
        Dim BLL As New AccountBLL
        Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
        If IsDBNull(dr("LicenseKey")) Then
            Return "Lite"
        Else
            Return dr("LicenseKey")
        End If
    End Function
    Public Shared Function IsHostedPaidCustomer() As Boolean
        Dim BLL As New AccountBLL
        Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
        If IsDBNull(dr("LicenseID")) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function IsHosted() As Boolean
        If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsLocalInstalled() As Boolean
        If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function GetCurrentHostedPackageKey() As String
        Dim BLL As New AccountBLL
        Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
        If IsDBNull(dr("LicenseKey")) Then
            Return "Lite"
        Else
            Return New SystemLicenseBLL().GetPackageCode(dr.LicenseKey, False)
        End If
        Return "Lite"
    End Function
    Public Shared Function GetHostedPackageVersion() As Integer
        Return New SystemLicenseBLL().GetVersionOfPackage(GetLicense(), UIUtilities.IsTrakLiveApplication)
    End Function
    Public Shared Function GetHostedPackageLicenseID(IsTrakLive As Integer) As Guid
        Return New SystemLicenseBLL().GetHostedCurrrentSystemLicenseID(GetLicense(), IsTrakLive)
    End Function
    Public Shared Function GetHostedPackages() As DataTable
        Dim dtPackages As SystemLicense.SystemLicenseDataTable = New SystemLicenseBLL().GetLicenseDataByVersion(GetHostedPackageVersion, UIUtilities.IsTrakLiveApplication)
        Return dtPackages
    End Function
    'Public Shared Function GetHostedPackagesForTrakLive(ByVal SystemLicenseID As Guid) As DataTable
    '    Dim dtPackages As SystemLicense.SystemLicenseDataTable = New SystemLicenseBLL().GetHostedPackageFromSystemLicense(SystemLicenseID)
    '    Return dtPackages
    'End Function
    Public Shared Sub SetLicenseDefineProduct(license As QlmLicense)
        If UIUtilities.IsTrakLiveApplication Then
            license.DefineProduct(TRAKLIVE_ACTIVATION_PRODUCT_ID, TRAKLIVE_ACTIVATION_PRODUCT_NAME, TRAKLIVE_ACTIVATION_VERSION_MAJOR, TRAKLIVE_ACTIVATION_VERSION_MINOR, TRAKLIVE_ACTIVATION_PRODUCT_KEY, TRAKLIVE_ACTIVATION_GUID_KEY)
        Else
            license.DefineProduct(ACTIVATION_PRODUCT_ID, ACTIVATION_PRODUCT_NAME, ACTIVATION_VERSION_MAJOR, ACTIVATION_VERSION_MINOR, ACTIVATION_PRODUCT_KEY, ACTIVATION_GUID_KEY)
        End If
    End Sub
    Public Shared Sub ChangeUpdateExistingPlan(ByVal PackageCode As String)
        Dim CurrentPackageCode As String = GetCurrentPackageRow("PackageCode")
        Dim NewPaymentProduct As String = GetRowOfPackage(PackageCode)("ProductCode")
        Dim BLL As New AccountBLL
        'Dim drCustomer As TimeLiveDataSet.LTCustomerRow = CustomerBLL.GetLTCustomerByAccountId(DBUtilities.GetSessionAccountId)
        Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
        Dim PaymentURL As String = String.Format("https://secure.avangate.com/order/upgrade.php?LICENSE={0}", dr.Item("LicenseId"))
        System.Web.HttpContext.Current.Response.Redirect(PaymentURL, False)
    End Sub
    Public Shared Function IsUpgradeExistingPlan() As Boolean
        If LicensingBLL.IsHostedPaidCustomer Then
            If LicensingBLL.GetHostedPackageVersion = 5 Or LicensingBLL.GetHostedPackageVersion > 5 Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Shared Function IsPaidCustomerLicenseExpired(ByVal AccountId As Integer)
        Dim dtAccount As TimeLiveDataSet.AccountDataTable = New AccountBLL().GetDataByAccountId(AccountId)
        If dtAccount.Rows.Count > 0 Then
            Dim Account As TimeLiveDataSet.AccountRow = dtAccount.Rows(0)
            If IsHosted() Then
                If Not UIUtilities.DisableLicense And Not IsDBNull(Account.Item("LicenseID")) Then
                    If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False Then
                        Return True
                    End If
                End If
            ElseIf IsLocalInstalled() And IsValidLicenseActivation(AccountId) = False Then
                If Not IsDBNull(Account.Item("ActivationType")) Then
                    If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) = False Then
                        Return True
                    End If
                End If
            End If
        End If
    End Function
    Public Shared Function IsPurchaseCustomerLicense(ByVal AccountId As Integer)
        Dim dtAccount As TimeLiveDataSet.AccountDataTable = New AccountBLL().GetDataByAccountId(AccountId)
        If dtAccount.Rows.Count > 0 Then
            Dim Account As TimeLiveDataSet.AccountRow = dtAccount.Rows(0)
            If IsHosted() Then
                If Not UIUtilities.DisableLicense And IsHosted() Then
                    If IsDBNull(Account.Item("LicenseID")) Then
                        Return True
                    End If
                End If
            ElseIf IsLocalInstalled() And IsValidLicenseActivation(AccountId) = False Then
                If IsDBNull(Account.Item("ActivationType")) Then
                    Return True
                End If
            End If
        End If
    End Function
    Public Shared Function IsFreeLiteVersion(ByVal AccountId As Integer)
        If Not UIUtilities.DisableLicense Then
            Dim dtAccount As TimeLiveDataSet.AccountDataTable = New AccountBLL().GetDataByAccountId(AccountId)
            If dtAccount.Rows.Count > 0 Then
                Dim Account As TimeLiveDataSet.AccountRow = dtAccount.Rows(0)
                If IsHosted() Then
                    If IsDBNull(Account.Item("LicenseID")) Then
                        If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) Then
                            Return True
                        End If
                    End If
                End If
                If IsLocalInstalled() Then
                    If IsDBNull(Account.Item("ActivationType")) Then
                        If LicensingBLL.IsExpiryDateValid(Account.Item("AccountExpiryActivation")) Then
                            Return True
                        End If
                    End If
                End If
            End If
        End If
    End Function
End Class
