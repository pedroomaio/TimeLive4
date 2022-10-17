Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports System.Web.Security



Public Class LiveMembershipProvider
    Inherits MembershipProvider
    Private _strName As String
    Private _strApplicationName As String
    Private _boolEnablePasswordReset As [Boolean]
    Private _boolEnablePasswordRetrieval As [Boolean]
    Private _boolRequiresQuestionAndAnswer As [Boolean]
    Private _boolRequiresUniqueEMail As [Boolean]
    Private _iPasswordAttemptThreshold As Integer
    Private _oPasswordFormat As MembershipPasswordFormat

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get

        End Get
    End Property
    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get

        End Get
    End Property
    Public Overrides ReadOnly Property Description() As String
        Get

            Return MyBase.Description
        End Get
    End Property


    '
    'ToDo: Error processing original source shown below
    ' public MyCustomerMembershipProvider 
    '        {
    '---------^--- Syntax error: 'identifier' expected
    '
    'ToDo: Error processing original source shown below
    '        {
    '            _strName = "";
    '----------------------^--- Syntax error: '{' expected

    'DFB: reads entries from web.config and initializes this class from those values
    '  Once the provider is loaded, the 
    '  runtime calls Initialize and passes the settings as name-value 
    '  pairs in an instance of the NameValueCollection class.
    '
    Public Overrides Sub Initialize(ByVal strName As String, ByVal config As System.Collections.Specialized.NameValueCollection) '
        'ToDo: Error processing original source shown below
        '        //
        ' public override void Initialize(string strName, System.Collections.Specialized.NameValueCollection config)
        '--^--- 'get' or 'set' expected

        _strName = strName
        _strApplicationName = "/"

        _boolRequiresQuestionAndAnswer = False
        _boolEnablePasswordReset = True
        _boolEnablePasswordRetrieval = True
        _boolRequiresQuestionAndAnswer = False
        _boolRequiresUniqueEMail = True
    End Sub 'Initialize


    Public Overrides Function ValidateUser(ByVal strName As String, ByVal strPassword As String) As Boolean
        Dim boolReturn As Boolean = False

        boolReturn = True
        Return boolReturn
    End Function 'ValidateUser

    Public Overrides Function GetPassword(ByVal strName As String, ByVal strAnswer As String) As String
        Throw New Exception("The method or operation is not implemented.")
    End Function 'GetPassword

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get

        End Get
    End Property
    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get

        End Get
    End Property

    Public Overrides Property ApplicationName() As String
        Get

            Return _strApplicationName
        End Get
        Set(ByVal value As String)
            _strApplicationName = value
        End Set
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get
            Return _strName
        End Get
    End Property

    Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get

            Return _boolEnablePasswordReset
        End Get
    End Property

    Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get
            Return _boolEnablePasswordRetrieval
        End Get
    End Property



    Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
        Get
            Return _oPasswordFormat
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get
            Return _boolRequiresQuestionAndAnswer
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get
            Throw New Exception("The method or operation is not implemented.")
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get
            Return _boolRequiresUniqueEMail
        End Get
    End Property


    Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, ByVal userId As Object, ByRef status As MembershipCreateStatus) As MembershipUser

        Throw New Exception("The method or operation is not implemented.")
    End Function 'CreateUser

    Public Overrides Function GetUserNameByEmail(ByVal strEmail As String) As String
        Throw New Exception("The method or operation is not implemented.")
    End Function 'GetUserNameByEmail


    Public Overrides Function ResetPassword(ByVal strName As String, ByVal strAnswer As String) As String
        Throw New Exception("The method or operation is not implemented.")
    End Function 'ResetPassword

    Public Overrides Function ChangePassword(ByVal strName As String, ByVal strOldPwd As String, ByVal strNewPwd As String) As Boolean
        Throw New Exception("The method or operation is not implemented.")
    End Function 'ChangePassword

    Public Overrides Function GetNumberOfUsersOnline() As Integer
        Throw New Exception("The method or operation is not implemented.")
    End Function 'GetNumberOfUsersOnline

    Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal strName As String, ByVal strPassword As String, ByVal strNewPwdQuestion As String, ByVal strNewPwdAnswer As String) As Boolean
        Throw New Exception("The method or operation is not implemented.")
    End Function 'ChangePasswordQuestionAndAnswer

    Public Overloads Overrides Function GetUser(ByVal strName As String, ByVal boolUserIsOnline As Boolean) As MembershipUser
        Throw New Exception("The method or operation is not implemented.")
    End Function 'GetUser


    Public Overrides Function DeleteUser(ByVal strName As String, ByVal boolDeleteAllRelatedData As Boolean) As Boolean
        Throw New Exception("The method or operation is not implemented.")
    End Function 'DeleteUser

    Public Overrides Function FindUsersByEmail(ByVal strEmailToMatch As String, ByVal iPageIndex As Integer, ByVal iPageSize As Integer, ByRef iTotalRecords As Integer) As MembershipUserCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function 'FindUsersByEmail

    Public Overrides Function FindUsersByName(ByVal strUsernameToMatch As String, ByVal iPageIndex As Integer, ByVal iPageSize As Integer, ByRef iTotalRecords As Integer) As MembershipUserCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function 'FindUsersByName

    Public Overrides Function GetAllUsers(ByVal iPageIndex As Integer, ByVal iPageSize As Integer, ByRef iTotalRecords As Integer) As MembershipUserCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function 'GetAllUsers


    Public Overrides Sub UpdateUser(ByVal user As MembershipUser)
        Throw New Exception("The method or operation is not implemented.")
    End Sub 'UpdateUser

    Public Overrides Function UnlockUser(ByVal strUserName As String) As Boolean
        Throw New Exception("The method or operation is not implemented.")
    End Function 'UnlockUser

    Public Overloads Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As MembershipUser
        Throw New Exception("The method or operation is not implemented.")
    End Function 'GetUser
End Class 'MyCustomerMembershipProvider
