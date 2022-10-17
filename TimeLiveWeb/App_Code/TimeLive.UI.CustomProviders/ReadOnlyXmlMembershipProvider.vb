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
    Public Class ReadOnlyXmlMembershipProvider
        Inherits MembershipProvider

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
                Throw New NotSupportedException
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

            ' Verify that config isn't null
            If (config Is Nothing) Then
                Throw New ArgumentNullException("config")
            End If
            If String.IsNullOrEmpty(name) Then
                name = "ReadOnlyXmlMembershipProvider"
            End If
            ' Add a default "description" attribute to config if the
            ' attribute doesn't exist or is empty
            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "Read-only XML membership provider")
            End If
            ' Call the base class's Initialize method
            MyBase.Initialize(name, config)
            ' Initialize _XmlFileName and make sure the path
            ' is app-relative
            Dim path As String = config("xmlFileName")
            If String.IsNullOrEmpty(path) Then
                path = "~/App_Data/Users.xml"
            End If
            If Not VirtualPathUtility.IsAppRelative(path) Then
                Throw New _
    ArgumentException("xmlFileName must be app-relative")
            End If
            Dim fullyQualifiedPath As String = _
              VirtualPathUtility.Combine(VirtualPathUtility.AppendTrailingSlash(HttpRuntime.AppDomainAppVirtualPath), path)
            _XmlFileName = HostingEnvironment.MapPath(fullyQualifiedPath)

            config.Remove("xmlFileName")
            ' Make sure we have permission to read the XML data source and
            ' throw an exception if we don't
            Dim permission As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Read, _XmlFileName)
            permission.Demand()
            ' Throw an exception if unrecognized attributes remain
            If (config.Count > 0) Then
                Dim attr As String = config.GetKey(0)
                If Not String.IsNullOrEmpty(attr) Then
                    Throw New _
    ProviderException(("Unrecognized attribute: " + attr))
                End If
            End If
        End Sub

        Public Overrides Function ValidateUser(ByVal username As String, _
             ByVal password As String) As Boolean

            ' Di()
            ' Validate input parameters
            If (String.IsNullOrEmpty(username) OrElse _
                String.IsNullOrEmpty(password)) Then
                Return False
            End If
            Try
                ' Make sure the data source has been loaded
                ReadMembershipDataStore()
                ' Validate the user name and password
                Dim user As MembershipUser = Nothing
                If _Users.TryGetValue(username, user) Then
                    If (user.Comment = password) Then
                        ' NOTE: A read/write membership provider
                        ' would update the user's LastLoginDate here.
                        ' A fully featured provider would also fire
                        ' an AuditMembershipAuthenticationSuccess
                        ' Web event
                        Return True
                    End If
                End If
                ' NOTE: A fully featured membership provider would
                ' fire an AuditMembershipAuthenticationFailure
                ' Web event here
                Return False
            Catch e As Exception
                Return False
            End Try
        End Function

        Public Overloads Overrides Function GetUser( _
      ByVal username As String, _
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
            For Each pair As KeyValuePair(Of String, MembershipUser) In _Users
                users.Add(pair.Value)
            Next
            totalRecords = users.Count
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
                                   Nothing, node("EMail").InnerText, String.Empty, _
                                   node("Password").InnerText, True, False, _
                                   DateTime.Now, DateTime.Now, DateTime.Now, _
                                   DateTime.Now, New DateTime(1980, 1, 1))

                        _Users.Add(user.UserName, user)
                    Next
                End If
            End SyncLock
        End Sub
    End Class

End Namespace

