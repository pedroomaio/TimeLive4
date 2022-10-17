Imports Microsoft.VisualBasic
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
Imports System.DirectoryServices

Namespace CustomProviders


    Public Class LDAPProvider
        Inherits MembershipProvider
        Private ldapPath As String '; // Host and Base
        Private authType As DirectoryServices.AuthenticationTypes '; // Used to record useSSL parameter: default SSL [useSSL]
        Private sbUser As String  '; //Search bind username: default null [username]
        Private sbPass As String '; //search bind password: default null [password]"
        Private uidAttrib As String '; //Attribute we are searching for: default uid [UserIDAttrib]
        Private sbFilter As String ';    //Additional Filter requirements: default (uid=username)
        Public Overrides Property ApplicationName() As String
            Get
                Throw New NotSupportedException
            End Get
            Set(ByVal value As String)
                Throw New NotSupportedException
            End Set
        End Property
        Public Property enableSearchMethods() As String
            Get
            End Get
            Set(ByVal value As String)
            End Set
        End Property
        Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
            Get
                Return False
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

        Public Overrides ReadOnly Property PasswordFormat( _
      ) As MembershipPasswordFormat
            Get
                Return MembershipPasswordFormat.Hashed
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
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

        Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, _
                                            ByVal passwordQuestion As String, ByVal passwordAnswer As String, _
                                            ByVal isApproved As Boolean, ByVal providerUserKey As Object, _
                                            ByRef status As MembershipCreateStatus) As MembershipUser

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
                ByVal pageIndex As Integer, _
                ByVal pageSize As Integer, _
                ByRef totalRecords As Integer _
                ) As MembershipUserCollection

            Throw New NotSupportedException
        End Function

        Public Overrides Function FindUsersByName( _
                ByVal usernameToMatch As String, _
                ByVal pageIndex As Integer, _
                ByVal pageSize As Integer, _
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
        Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)

            If config Is Nothing Then
                Throw New ArgumentNullException("config")
            End If
            If String.IsNullOrEmpty(name) Then
                name = "LDAPROMembershipProvider"
            End If
            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "Read-only LDAP membership provider")
            End If
            MyBase.Initialize(name, config)

            config.Remove("connectionString")

            If String.IsNullOrEmpty(config("connectionProtection")) Or config("connectionProtection") = "Secure" Then
                authType = DirectoryServices.AuthenticationTypes.Encryption
            Else
                authType = DirectoryServices.AuthenticationTypes.None
            End If
            config.Remove("connectionProtection")

            sbUser = config("connectionUsername")
            config.Remove("connectionUsername")
            sbPass = config("connectionPassword")
            config.Remove("connectionPassword")

            uidAttrib = config("attributeMapUsername")
            If String.IsNullOrEmpty(uidAttrib) Then
                uidAttrib = "uid"
            End If

            config.Remove("attributeMapUsername")

            sbFilter = config("SearchFilter")
            config.Remove("SearchFilter")
            config.Remove("enableSearchMethods")

            Dim ConnectionStringSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(config("connectionStringName"))
            config.Remove("connectionStringName")
            If ConnectionStringSettings Is Nothing Or ConnectionStringSettings.ConnectionString.Trim = "" Then
                Throw New ProviderException("Connection string cannot be blank.")
            End If
            ldapPath = ConnectionStringSettings.ConnectionString

            '// Throw an exception if unrecognized attributes remain
            If config.Count > 0 Then
                Dim attr As String = config.GetKey(0)
                If Not String.IsNullOrEmpty(attr) Then
                    Throw New ProviderException("Unrecognized attribute: " + attr)
                End If
            End If
        End Sub
        Public Overrides Function ValidateUser(username As String, password As String) As Boolean
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Start username=" & username & " - password=" & password & " - ldapPath=" & ldapPath)
            'Find the person in the directory to determine their distinct name
            'Try
            Dim ObjectClassArray As New ArrayList
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Start DirectorySearcher objectClassSearcher")
            Dim objectClassSearcher As New DirectorySearcher(LDAPUtilitiesBLL.OpenLDAPRoot)
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: End DirectorySearcher objectClassSearcher")
            objectClassSearcher.SearchScope = SearchScope.OneLevel
            objectClassSearcher.Filter = "(objectClass=*)"
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Start SearchResultCollection objectClassSearcher.FindAll()")
            Dim objectClassfindResult As SearchResultCollection = objectClassSearcher.FindAll()
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: End SearchResultCollection objectClassSearcher.FindAll()")
            For Each objectClassSearchResult As SearchResult In objectClassfindResult
                If objectClassSearchResult.GetDirectoryEntry.Name <> "" Then
                    ObjectClassArray.Add(objectClassSearchResult.GetDirectoryEntry.Name)
                    LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Start objectClassSearchResult.GetDirectoryEntry.Name -- " & objectClassSearchResult.GetDirectoryEntry.Name)
                End If
            Next
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Start DirectorySearcher UIDSearcher")
            Dim UIDSearcher As New DirectorySearcher(LDAPUtilitiesBLL.OpenLDAPRoot)
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: End DirectorySearcher UIDSearcher")
            UIDSearcher.SearchScope = SearchScope.Subtree
            UIDSearcher.Filter = LDAPUtilitiesBLL.GetSearchByNameFormat(username)
            LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: UIDSearcher.Filter -- " & UIDSearcher.Filter)
            Dim UIDfindResult As SearchResult = UIDSearcher.FindOne()
            If UIDfindResult Is Nothing Then
                LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: No uid found")
                Throw New Exception("No UID attribute found for " & username)
            End If
            For i As Integer = 0 To ObjectClassArray.Count - 1
                Dim DistinctName As String = ""
                If UIDfindResult.GetDirectoryEntry.Name <> "" Then
                    DistinctName += UIDfindResult.GetDirectoryEntry.Name
                    LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: DistinctName -- " & DistinctName)
                End If
                DistinctName += "," & ObjectClassArray(i) & "," & UIUtilities.GetLDAPBaseDN()
                LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Full DistinctName -- " & DistinctName & "," & ObjectClassArray(i) & "," & UIUtilities.GetLDAPBaseDN())
                'Authenticate the person which is currently login.
                Dim root As New DirectoryEntry(ldapPath, DistinctName, password, AuthenticationTypes.ServerBind)
                Using root
                    'Try
                    LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: Start RefreshCache")
                    root.RefreshCache()
                    LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: End RefreshCache")
                    LoggingBLL.WriteToLog("LDAPProvider:ValidateUser: End username=" & username & " - password=" & password)
                    Return True
                    'Catch ex As Exception
                    'End Try
                End Using
            Next
            'Catch ex As Exception
            'Return False
            'End Try
        End Function
        Public Overrides Function GetAllUsers(pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

        End Function
        Public Overloads Overrides Function GetUser(username As String, userIsOnline As Boolean) As System.Web.Security.MembershipUser

        End Function
    End Class
End Namespace