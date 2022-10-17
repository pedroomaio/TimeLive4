Imports System
Imports System.Xml
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Configuration.Provider
Imports System.Web.Security
Imports System.Web.Hosting
Imports System.Web.Management
Imports System.Security.Permissions
Imports System.Web
Imports System.Security.Cryptography
Namespace CustomProviders
    Public Class LiveMembershipProvider
        Inherits MembershipProvider

        Public AccountEmployeeBLL As New AccountEmployeeBLL

        Private pPasswordFormat As MembershipPasswordFormat
        Public Overrides Property ApplicationName() As String
            Get
                Throw New NotSupportedException
            End Get
            Set(ByVal value As String)
                Throw New NotSupportedException
            End Set
        End Property

        Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property _
      MaxInvalidPasswordAttempts() As Integer
            Get
                Throw New NotSupportedException
            End Get
        End Property

        Public Overrides ReadOnly Property _
               MinRequiredNonAlphanumericCharacters() As Integer
            Get
                Throw New NotSupportedException
            End Get
        End Property

        Public Overrides ReadOnly Property _
               MinRequiredPasswordLength() As Integer
            Get
                Throw New NotSupportedException
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
            Get
                Throw New NotSupportedException
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
            Get
                Return pPasswordFormat
            End Get
        End Property

        Public Overrides ReadOnly Property _
         PasswordStrengthRegularExpression() As String
            Get
                Throw New NotSupportedException
            End Get
        End Property

        Public Overrides ReadOnly Property _
         RequiresQuestionAndAnswer() As Boolean
            Get
                Throw New NotSupportedException
            End Get
        End Property

        Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
            Get
                Throw New NotSupportedException
            End Get
        End Property

        ' MembershipProvider Methods
        Public Overrides Sub Initialize(ByVal name As String, _
      ByVal config As NameValueCollection)


            AccountEmployeeBLL = New AccountEmployeeBLL

            ' Verify that config isn't null
            If (config Is Nothing) Then
                Throw New ArgumentNullException("config")
            End If
            If String.IsNullOrEmpty(name) Then
                name = "LiveMembershipProvider"
            End If

            Dim temp_format As String = config("passwordFormat")
            If temp_format Is Nothing Then
                temp_format = "Hashed"
            End If

            Select Case temp_format
                Case "Hashed"
                    pPasswordFormat = MembershipPasswordFormat.Hashed
                    Exit Select
                Case "Encrypted"
                    pPasswordFormat = MembershipPasswordFormat.Encrypted
                    Exit Select
                Case "Clear"
                    pPasswordFormat = MembershipPasswordFormat.Clear
                    Exit Select
                Case Else
                    Throw New ProviderException("Password format not supported.")
            End Select

            ' Add a default "description" attribute to config if the
            ' attribute doesn't exist or is empty
            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "Live Membership Provider")
            End If
            ' Call the base class's Initialize method
            MyBase.Initialize(name, config)
        End Sub
        Public Overrides Function ValidateUser(ByVal username As String, _
             ByVal password As String) As Boolean
            Dim InstalledVersion As System.Version = AccountBLL.GetInstalledVersionOfUsername(username)

            If Not InstalledVersion Is Nothing Then
                If InstalledVersion >= New System.Version(AccountBLL.VERSION_PASSWORD_ENCRYPTION) Then
                    If password.ToUpper.Contains("HASHEDCLAIMEDIDENTIFIER") Then
                        password = Replace(password, "HASHEDCLAIMEDIDENTIFIER", "")
                    Else
                        password = Me.EncodePassword(password)
                    End If
                End If
            End If


            'Try
            Return Me.AccountEmployeeBLL.ValidateLogin(username, password)
            'Catch e As Exception
            'Return False
            'End Try
        End Function

        Public Overloads Overrides Function GetUser( _
      ByVal username As String, _
               ByVal userIsOnline As Boolean _
      ) As MembershipUser

            Return Nothing
        End Function

        Public Overrides Function GetAllUsers( _
      ByVal pageIndex As Integer, _
      ByVal pageSize As Integer, _
               ByRef totalRecords As Integer _
      ) As MembershipUserCollection
            Return Nothing
        End Function

        Public Overrides Function GetNumberOfUsersOnline() As Integer
            Throw New NotSupportedException
        End Function

        Public Overrides Function ChangePassword( _
      ByVal username As String, _
      ByVal oldPassword As String, _
               ByVal newPassword As String _
      ) As Boolean

            Throw New NotSupportedException
        End Function

        Public Overrides Function ChangePasswordQuestionAndAnswer( _
      ByVal username As String, _
               ByVal password As String, ByVal newPasswordQuestion As String, _
               ByVal newPasswordAnswer As String _
      ) As Boolean

            Throw New NotSupportedException
        End Function

        Public Overrides Function CreateUser(ByVal username As String, _
      ByVal password As String, _
               ByVal email As String, _
      ByVal passwordQuestion As String, _
               ByVal passwordAnswer As String, _
      ByVal isApproved As Boolean, _
               ByVal providerUserKey As Object, _
               ByRef status As MembershipCreateStatus _
      ) As MembershipUser

            Throw New NotSupportedException
        End Function

        Public Overrides Function DeleteUser( _
      ByVal username As String, _
               ByVal deleteAllRelatedData As Boolean _
      ) As Boolean

            Throw New NotSupportedException
        End Function


        Public Overrides Function FindUsersByEmail( _
      ByVal emailToMatch As String, _
               ByVal pageIndex As Integer, ByVal pageSize As Integer, _
               ByRef totalRecords As Integer _
      ) As MembershipUserCollection

            Throw New NotSupportedException
        End Function

        Public Overrides Function FindUsersByName( _
      ByVal usernameToMatch As String, _
               ByVal pageIndex As Integer, ByVal pageSize As Integer, _
               ByRef totalRecords As Integer _
      ) As MembershipUserCollection

            Throw New NotSupportedException
        End Function

        Public Overrides Function GetPassword( _
      ByVal username As String, _
      ByVal answer As String _
      ) As String

            Throw New NotSupportedException
        End Function

        Public Overloads Overrides Function GetUser( _
      ByVal providerUserKey As Object, _
               ByVal userIsOnline As Boolean _
      ) As MembershipUser

            Throw New NotSupportedException
        End Function

        Public Overrides Function GetUserNameByEmail( _
      ByVal email As String) As String

            Throw New NotSupportedException
        End Function

        Public Overrides Function ResetPassword( _
      ByVal username As String, ByVal answer As String _
      ) As String

            Throw New NotSupportedException
        End Function

        Public Overrides Function UnlockUser( _
      ByVal userName As String) As Boolean

            Throw New NotSupportedException
        End Function

        Public Overrides Sub UpdateUser(ByVal user As MembershipUser)
            Throw New NotSupportedException
        End Sub


        Private Function HexToByte(ByVal hexString As String) As Byte()
            Dim returnBytes As Byte() = New Byte(hexString.Length / 2 - 1) {}
            For i As Integer = 0 To returnBytes.Length - 1
                returnBytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
            Next
            Return returnBytes
        End Function
        Private Function stringtoByte(ByVal textdata As String) As Byte()
            Dim encoding As New System.Text.ASCIIEncoding()
            Return encoding.GetBytes(textdata)

        End Function
        Public Function EncodePassword(ByVal password As String) As String
            Dim encodedPassword As String = password

            Select Case Membership.Provider.PasswordFormat
                Case MembershipPasswordFormat.Clear
                    Exit Select
                Case MembershipPasswordFormat.Encrypted
                    encodedPassword = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)))
                    Exit Select
                Case MembershipPasswordFormat.Hashed
                    Dim hash As New HMACSHA1()
                    hash.Key = stringtoByte(LicensingBLL.ENCRYPTION_KEY)
                    encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)))
                    Exit Select
                Case Else
                    Throw New ProviderException("Unsupported password format.")
            End Select

            Return encodedPassword
        End Function
        Public Function UnEncodePassword(ByVal encodedPassword As String) As String
            Dim password As String = encodedPassword

            Select Case PasswordFormat
                Case MembershipPasswordFormat.Clear
                    Exit Select
                Case MembershipPasswordFormat.Encrypted
                    password = Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)))
                    Exit Select
                Case MembershipPasswordFormat.Hashed
                    Throw New ProviderException("Cannot unencode a hashed password.")
                Case Else
                    Throw New ProviderException("Unsupported password format.")
            End Select

            Return password
        End Function

        Public Function PasswordReset(ByVal EmailAddress As String) As Boolean
            Dim Password As String
            Dim EmployeeBll As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBll.GetAccountEmployeesByEmailAddress(EmailAddress)
            Dim drEmployee As AccountEmployee.AccountEmployeeRow
            If dtEmployee.Rows.Count > 0 Then
                drEmployee = dtEmployee.Rows(0)
                Password = GeneratePassword()
                EmployeeBll.SendPasswordResetEMail(EmailAddress, Password)
                EmployeeBll.UpdatePasswordReset(EmailAddress, Password)
                Return True
            End If
            Return False
        End Function

        Public Function GeneratePassword() As String
            Const alphabets As String = "abcdefghijklmnopqrstuvwxyz"
            Const digits As String = "0123456789"
            Dim password As New StringBuilder(8)
            Dim rng As New Random()
            Dim n As Integer = 0

            For i As Integer = 0 To 7
                If i Mod 2 = 0 Then
                    n = rng.[Next](26)
                    password.Append(alphabets.Substring(n, 1))
                Else
                    n = rng.[Next](10)
                    password.Append(digits.Substring(n, 1))
                End If
            Next


            Return password.ToString()
        End Function
    End Class
End Namespace

