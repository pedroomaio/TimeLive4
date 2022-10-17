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
Namespace CustomProviders

    Public Class LiveLDAPMembershipProvider
        Inherits MembershipProvider

        Private ldapPath As String '; // Host and Base
        Private authType As DirectoryServices.AuthenticationTypes '; // Used to record useSSL parameter: default SSL [useSSL]
        Private sbUser As String  '; //Search bind username: default null [username]
        Private sbPass As String '; //search bind password: default null [password]"
        Private uidAttrib As String '; //Attribute we are searching for: default uid [UserIDAttrib]
        Private sbFilter As String ';    //Additional Filter requirements: default (uid=username)
        '// becomes (&(uid=username)sbFilter)) [SearchFilter]


        Private _Users As Dictionary(Of String, MembershipUser)
        Private _XmlFileName As String

        ' MembershipProvider Properties
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

        ' MembershipProvider Methods
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

        Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean
            Dim userDN As String
            Dim userPath As String
            Dim root As DirectoryServices.DirectoryEntry = New DirectoryServices.DirectoryEntry(ldapPath, sbUser, sbPass, authType)
            Using root
                Dim dbFilter As String = Nothing
                If String.IsNullOrEmpty(sbFilter) Then
                    dbFilter = String.Format("({0}={1})", uidAttrib, username)
                Else
                    dbFilter = String.Format("(&({0}={1}){2})", uidAttrib, username, sbFilter)
                End If
                Dim ds As DirectoryServices.DirectorySearcher = New DirectoryServices.DirectorySearcher(root, dbFilter, New String() {"cn"})
                Dim sr As DirectoryServices.SearchResult = Nothing
                sr = ds.FindOne
                Try
                Catch e As Exception
                    Return False
                End Try
                If sr Is Nothing Then
                    Return False
                Else
                    userPath = sr.Path
                    userDN = userPath.Split(New Char() {"/"})(3)
                    Dim myDirectoryEntry As DirectoryServices.DirectoryEntry = sr.GetDirectoryEntry
                End If
            End Using
            Dim sslEntry As DirectoryServices.DirectoryEntry = New DirectoryServices.DirectoryEntry(userPath, userDN, password, authType)
            Using sslEntry
                Try
                    sslEntry.RefreshCache()
                    Return True
                Catch ex As Exception
                    Dim errMsg As String = ex.Message
                    Return False
                End Try
            End Using
        End Function

        Public Overloads Overrides Function GetUser(ByVal username As String, _
                                                    ByVal userIsOnline As Boolean _
                                                    ) As MembershipUser

            ' Note: This implementation ignores userIsOnline
            ' Validate input parameters
            If String.IsNullOrEmpty(username) Then
                Return Nothing
            End If
            ' Make sure the data source has been loaded
            ReadMembershipDataStore()
            ' Retrieve the user from the data source
            Dim user As MembershipUser
            If _Users.TryGetValue(username, user) Then
                Return user
            End If
            Return Nothing
        End Function

        Public Overrides Function GetAllUsers( _
      ByVal pageIndex As Integer, _
      ByVal pageSize As Integer, _
               ByRef totalRecords As Integer _
      ) As MembershipUserCollection

            ' Note: This implementation ignores pageIndex and pageSize,
            ' and it doesn't sort the MembershipUser objects returned
            ' Make sure the data source has been loaded
            ReadMembershipDataStore()
            Dim users As MembershipUserCollection = New _
             MembershipUserCollection
            ' insert code here
            Return users
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

        ' Helper method
        Private Sub ReadMembershipDataStore()
            SyncLock Me
                If (_Users Is Nothing) Then
                    _Users = New Dictionary(Of String, MembershipUser) _
                           (16, StringComparer.InvariantCultureIgnoreCase)
                    Dim doc As XmlDocument = New XmlDocument
                    doc.Load(_XmlFileName)
                    Dim nodes As XmlNodeList = _
           doc.GetElementsByTagName("User")
                    For Each node As XmlNode In nodes
                        Dim user As MembershipUser = New MembershipUser( _
                                                                      Name, _
                                                                      node("UserName").InnerText, _
                                                                      Nothing, _
                                                                      node("EMail").InnerText, _
                                                                      String.Empty, _
                                                                      node("Password").InnerText, _
                                                                      True, _
                                                                      False, _
                                                                      DateTime.Now, _
                                                                      DateTime.Now, _
                                                                      DateTime.Now, _
                                                                      DateTime.Now, _
                                                                      New DateTime(1980, 1, 1))
                        _Users.Add(user.UserName, user)
                    Next
                End If
            End SyncLock
            If _Users Is Nothing Then
                _Users = New Dictionary(Of String, MembershipUser) _
                (16, StringComparer.CurrentCultureIgnoreCase)
            End If
        End Sub
    End Class
End Namespace

