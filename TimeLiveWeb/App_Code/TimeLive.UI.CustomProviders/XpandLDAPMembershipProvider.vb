Imports AccountEmployeeTableAdapters
Imports CustomProviders
Imports System.DirectoryServices
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.Configuration

Namespace com.xpand.membership.provider.ldap
    Public NotInheritable Class XpandLDAPMembershipProvider
        Inherits LiveMembershipProvider
#Region "Private Properties"

        Private Const masterPasswordFilePathConfigurationKey As String = "Xpand.LDAPMembershipProvider.MasterPasswordFilePath"
        Private Const loggingFilePathConfigurationKey As String = "Xpand.LDAPMembershipProvider.LoggingFilePath"

        'private const string MasterPasswordFilePath = @"c:\windows\timelive_masterpassword.txt";

        Private ReadOnly Property masterPasswordFilePath() As String
            Get
                Return WebConfigurationManager.AppSettings(masterPasswordFilePathConfigurationKey)
            End Get
        End Property

        Private ReadOnly Property loggingFilePath() As String
            Get
                Return WebConfigurationManager.AppSettings(loggingFilePathConfigurationKey)
            End Get
        End Property

#End Region

        Public Sub logDebug(logMessage As String)
            'StreamWriter streamWriter = new StreamWriter((Stream)new FileStream("c:\\auth\\LDAPMembershipProvider.log", FileMode.Append, FileAccess.Write));
            Dim loggingFullFilePath = GetFullPath(loggingFilePath)
            Using streamWriter As New StreamWriter(New FileStream(loggingFullFilePath, FileMode.Append, FileAccess.Write))
                streamWriter.WriteLine(logMessage)
                streamWriter.Flush()
                streamWriter.Close()
            End Using
        End Sub

#Region "LiveMembershipProvider Methods"

        Public Overrides Function ValidateUser(username__1 As String, password As String) As Boolean
            logDebug(Convert.ToString("Authenticating user ") & username__1)
            Dim masterPasswordFullFilePath = GetFullPath(masterPasswordFilePath)
            Dim masterPassword = GetMasterPasswordFromFile(masterPasswordFullFilePath)
            If masterPassword Is Nothing Then
                logDebug(Convert.ToString("Couldn't read master password. Path = ") & masterPasswordFullFilePath)
                Return False
            End If

            Dim Username__2 As String = username__1

            If password <> masterPassword Then
                Try
                    Me.logDebug(Convert.ToString("Going LDAP ") & username__1)
                    Dim searchRoot As New DirectoryEntry("LDAP://black/ou=People,dc=xpand-it,dc=com", (Convert.ToString("uid=") & username__1) + ",ou=People,dc=xpand-it,dc=com", password, AuthenticationTypes.ServerBind)
                    Username__2 = New DirectorySearcher(searchRoot) With { _
                     .SearchScope = SearchScope.Subtree, _
                     .Filter = (Convert.ToString("uid=") & username__1) _
                    }.FindOne().Properties("mail")(0).ToString()
                    Me.logDebug(Convert.ToString("Email found for this user ") & Username__2)
                    searchRoot.Close()
                Catch ex As Exception
                    Me.logDebug("User not found in LDAP")
                    Return MyBase.ValidateUser(username__1, password)
                End Try
            End If
            Dim dataByEmployeeLogin As AccountEmployee.vueAccountEmployeeDataTable = New vueAccountEmployeeTableAdapter().GetDataByEmployeeLogin(Username__2)
            If dataByEmployeeLogin.Rows.Count > 0 Then
                Me.logDebug("User found in database" & vbLf)
                Dim AccountEmployeeRow As AccountEmployee.vueAccountEmployeeRow = DirectCast(dataByEmployeeLogin.Rows(0), AccountEmployee.vueAccountEmployeeRow)
                HttpContext.Current.Response.Cookies("AccountEmployeeId").Value = AccountEmployeeRow.AccountEmployeeId.ToString()
                HttpContext.Current.Session.Add("AccountEmployeeId", DirectCast(AccountEmployeeRow.AccountEmployeeId, Object))
                HttpContext.Current.Session.Add("AccountId", DirectCast(AccountEmployeeRow.AccountId, Object))
                HttpContext.Current.Session.Add("CountryId", DirectCast(AccountEmployeeRow.CountryId, Object))
                HttpContext.Current.Session.Add("DefaultCurrencyId", DirectCast(AccountEmployeeRow.DefaultCurrencyId, Object))
                Me.AccountEmployeeBLL.SetSessionValues(AccountEmployeeRow, AccountEmployeeRow.AccountEmployeeId)
                Return True
            End If
            Me.logDebug("User not found in database")
            Return False
        End Function

#End Region

#Region "Private Methods"

        Private Shared Function GetMasterPasswordFromFile(masterpasswordPath As String) As String
            Try
                Return File.ReadLines(masterpasswordPath).First()
            Catch generatedExceptionName As Exception
                Return Nothing
            End Try
        End Function

        Private Shared Function GetFullPath(providedPath As String) As String
            If Path.IsPathRooted(providedPath) Then
                Return providedPath
            End If

            Return HttpContext.Current.Server.MapPath(providedPath)
        End Function

#End Region
    End Class
End Namespace
