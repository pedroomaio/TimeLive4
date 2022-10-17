Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Public Class SecuredWebServiceHeader
    Inherits System.Web.Services.Protocols.SoapHeader
    Public Username As String
    Public Password As String
    Public AuthenticatedToken As String
    Public AccountId As Integer
    Public AccountEmployeeId As Integer
End Class
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TimeLiveServices
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AuthenticateUser() As String
        If SoapHeader Is Nothing Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(SoapHeader.Username) OrElse String.IsNullOrEmpty(SoapHeader.Password) Then
            Return Nothing
        End If
        ' Are the credentials validYou are not authorized to access this.
        If Not IsUserValid(SoapHeader.Username, SoapHeader.Password) Then
            Return Nothing
            '"Invalid Username or Password"
        End If
        ' Create and store the AuthenticatedToken before returning it
        Dim SecurityToken As New WebServiceToken
        SecurityToken.AccountID = GetAccountId(SoapHeader.Username, SoapHeader.Password)
        SecurityToken.AccountEmployeeID = GetAccountEmployeeId(SoapHeader.Username, SoapHeader.Password)
        SecurityToken.TokenID = Guid.NewGuid().ToString()
        SecurityToken.Username = SoapHeader.Username
        HttpRuntime.Cache.Add(SecurityToken.TokenID, SecurityToken, Nothing, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60), System.Web.Caching.CacheItemPriority.NotRemovable, _
         Nothing)
        Return SecurityToken.TokenID
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AuthenticateMobileUser() As String
        If SoapHeader Is Nothing Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(SoapHeader.Username) OrElse String.IsNullOrEmpty(SoapHeader.Password) Then
            Return Nothing
        End If
        ' Are the credentials validYou are not authorized to access this.
        If Not IsMobileUserValid(SoapHeader.Username, SoapHeader.Password) Then
            Return Nothing
            '"Invalid Username or Password"
        End If
        ' Create and store the AuthenticatedToken before returning it
        Dim SecurityToken As New WebServiceToken
        SecurityToken.AccountID = GetAccountIdForMobile(SoapHeader.Username, SoapHeader.Password)
        SecurityToken.AccountEmployeeId = GetAccountEmployeeIdForMobile(SoapHeader.Username, SoapHeader.Password)
        SecurityToken.TokenID = Guid.NewGuid().ToString()
        SecurityToken.Username = SoapHeader.Username
        HttpRuntime.Cache.Add(SecurityToken.TokenID, SecurityToken, Nothing, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60), System.Web.Caching.CacheItemPriority.NotRemovable, _
         Nothing)
        Return SecurityToken.TokenID
    End Function
    Private Function IsMobileUserValid(ByVal Username As String, ByVal Password As String) As Boolean
        ' Ask the SQL Memebership to verify the credentials for us
        'Return System.Web.Security.Membership.ValidateUser(Username, Password)
        Return New AccountEmployeeBLL().ValidateMobileLogin(Username, Password)
    End Function
    <WebMethod()> _
    Public Function GetAccountIdForMobile(ByVal Username As String, ByVal Password As String) As Integer
        Dim BLL As New AccountEmployeeBLL
        Password = DBUtilities.EncryptPasswordInHash(Password)
        Dim dtAccountEmployee As AccountEmployee.vueAccountEmployeeDataTable
        If New LDAPUtilitiesBLL().IsAspNetActiveDirectoryMembershipProvider = True Then
            dtAccountEmployee = BLL.GetAccountEmployeesViewByUsername(Username)
        Else
            dtAccountEmployee = BLL.GetViewAccountEmployeesByUsernameAndPassword(Username, Password)
        End If
        Dim drAccountEmployee As AccountEmployee.vueAccountEmployeeRow
        If dtAccountEmployee.Rows.Count > 0 Then
            drAccountEmployee = dtAccountEmployee.Rows(0)
            Return drAccountEmployee.AccountId
        Else
            Return 0
        End If
    End Function
    <WebMethod()> _
    Public Function GetAccountEmployeeIdForMobile(ByVal Username As String, ByVal Password As String) As Integer
        Dim BLL As New AccountEmployeeBLL
        Password = DBUtilities.EncryptPasswordInHash(Password)
        Dim dtAccountEmployee As AccountEmployee.vueAccountEmployeeDataTable
        If New LDAPUtilitiesBLL().IsAspNetActiveDirectoryMembershipProvider = True Then
            dtAccountEmployee = BLL.GetAccountEmployeesViewByUsername(Username)
        Else
            dtAccountEmployee = BLL.GetViewAccountEmployeesByUsernameAndPassword(Username, Password)
        End If
        Dim drAccountEmployee As AccountEmployee.vueAccountEmployeeRow
        If dtAccountEmployee.Rows.Count > 0 Then
            drAccountEmployee = dtAccountEmployee.Rows(0)
            Return drAccountEmployee.AccountEmployeeId
        Else
            Return 0
        End If
    End Function
    <WebMethod()> _
    Public Shared Function GetSecurityToken(ByVal TokenID As String) As WebServiceToken
        Return HttpRuntime.Cache.Get(TokenID)
    End Function
    <WebMethod()> _
    Public Function GetAccountId(ByVal Username As String, ByVal Password As String) As Integer
        Dim BLL As New AccountEmployeeBLL
        Dim dtAccountEmployee As AccountEmployee.vueAccountEmployeeDataTable = BLL.GetDataByAdminLogin(Username, Password)
        Dim drAccountEmployee As AccountEmployee.vueAccountEmployeeRow
        If dtAccountEmployee.Rows.Count > 0 Then
            drAccountEmployee = dtAccountEmployee.Rows(0)
            Return drAccountEmployee.AccountId
        Else
            Return 0
        End If
    End Function
    <WebMethod()> _
    Public Function GetAccountEmployeeId(ByVal Username As String, ByVal Password As String) As Integer
        Dim BLL As New AccountEmployeeBLL
        Dim dtAccountEmployee As AccountEmployee.vueAccountEmployeeDataTable = BLL.GetDataByAdminLogin(Username, Password)
        Dim drAccountEmployee As AccountEmployee.vueAccountEmployeeRow
        If dtAccountEmployee.Rows.Count > 0 Then
            drAccountEmployee = dtAccountEmployee.Rows(0)
            Return drAccountEmployee.AccountEmployeeId
        Else
            Return 0
        End If
    End Function
    Private Function IsUserValid(ByVal Username As String, ByVal Password As String) As Boolean
        ' Ask the SQL Memebership to verify the credentials for us
        'Return System.Web.Security.Membership.ValidateUser(Username, Password)
        Return New AccountEmployeeBLL().ValidateLoginWS(Username, Password)
    End Function
    Public Shared Function IsUserValid(ByVal SoapHeader As SecuredWebServiceHeader) As Boolean
        If SoapHeader Is Nothing Then
            Return False
        End If
        ' Does the token exists in our CacheYou are not authorized to access this.
        If Not String.IsNullOrEmpty(SoapHeader.AuthenticatedToken) Then
            Return (HttpRuntime.Cache(SoapHeader.AuthenticatedToken) IsNot Nothing)
        End If
        Return False
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetDepartmentId() As Integer
        If Not IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim nDepartmentId As Integer
        Dim objDepartment As New AccountDepartmentBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtDepartment As TimeLiveDataSet.AccountDepartmentDataTable = objDepartment.GetDefaultDepartmentByAccountId(AccountId)
        Dim drDepartment As TimeLiveDataSet.AccountDepartmentRow
        If dtDepartment.Rows.Count > 0 Then
            drDepartment = dtDepartment.Rows(0)
            nDepartmentId = drDepartment.AccountDepartmentId
        Else
            nDepartmentId = objDepartment.AddAccountDepartment(AccountId, "Default", "Default Department", 0, 0)
        End If
        Return nDepartmentId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetLocationId() As Integer
        If Not IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim nLocationId As Integer
        Dim objLocation As New AccountLocationBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtLocation As TimeLiveDataSet.AccountLocationDataTable = objLocation.GetDefaultLocationByAccountId(AccountId)
        Dim drLocation As TimeLiveDataSet.AccountLocationRow
        If dtLocation.Rows.Count > 0 Then
            drLocation = dtLocation.Rows(0)
            nLocationId = drLocation.AccountLocationId
        Else
            nLocationId = objLocation.AddAccountLocation(AccountId, "Default Location", 0, 0)
        End If
        Return nLocationId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetWorkTypeId() As Integer
        If Not IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objWorkType As New AccountWorkTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nWorkTypeId As Integer = objWorkType.GetAccountWorkTypesByAccountIdAndAccountWorkType(AccountId).Rows(0).Item(0)
        Return nWorkTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetCurrencyId() As Integer
        If Not IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objCurrency As New AccountCurrencyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nCurrencyId As Integer = objCurrency.GetAccountCurrencyByAccountId(AccountId).Rows(0).Item(0)
        Return nCurrencyId
    End Function
End Class
