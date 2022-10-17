Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Employees
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddEmployee(ByVal objEmployee As Employee) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployees() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim EmployeeArrayList As New ArrayList
        Dim objEmployee As New Employee
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtEmployee As AccountEmployee.vueAccountEmployeeForQBDataTable = EmployeeBLL.GetEmployeeForQB(AccountId)
        Dim drEmployee As AccountEmployee.vueAccountEmployeeForQBRow
        For Each drEmployee In dtEmployee.Rows
            objEmployee = New Employee
            With objEmployee
                .EmployeeId = drEmployee.AccountEmployeeId
                .EmployeeName = drEmployee.FullName
                .FirstName = drEmployee.FirstName
                If IsDBNull(drEmployee.Item("MiddleName")) Then
                    .MiddleName = ""
                Else
                    .MiddleName = drEmployee.MiddleName
                End If
                .LastName = drEmployee.LastName
                .EmailAddress = drEmployee.EMailAddress
                If IsDBNull(drEmployee.Item("AddressLine1")) Then
                    .Address1 = ""
                Else
                    .Address1 = drEmployee.AddressLine1
                End If
                If IsDBNull(drEmployee.Item("AddressLine2")) Then
                    .Address2 = ""
                Else
                    .Address2 = drEmployee.AddressLine2
                End If
                If IsDBNull(drEmployee.Item("City")) Then
                    .City = ""
                Else
                    .City = drEmployee.City
                End If
                If IsDBNull(drEmployee.Item("State")) Then
                    .State = ""
                Else
                    .State = drEmployee.State
                End If
                If IsDBNull(drEmployee.Item("Zip")) Then
                    .PostalCode = ""
                Else
                    .PostalCode = drEmployee.Zip
                End If
                If IsDBNull(drEmployee.Item("HomePhoneNo")) Then
                    .Phone = ""
                Else
                    .Phone = drEmployee.HomePhoneNo
                End If
                If IsDBNull(drEmployee.Item("MobilePhoneNo")) Then
                    .Mobile = ""
                Else
                    .Mobile = drEmployee.MobilePhoneNo
                End If
                If IsDBNull(drEmployee.Item("HiredDate")) Then
                    .HiredDate = Now.Date
                Else
                    .HiredDate = drEmployee.HiredDate
                End If
                If IsDBNull(drEmployee.Item("IsVendor")) Then
                    .IsVendor = False
                Else
                    .IsVendor = drEmployee.IsVendor
                End If
            End With
            EmployeeArrayList.Add(objEmployee)
        Next
        Return EmployeeArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub InsertEmployee(ByVal Username As String, ByVal Password As String, ByVal FirstName As String, _
        ByVal LastName As String, ByVal EmailAddress As String, ByVal EmployeeCode As String, _
        ByVal AccountDepartmentId As Integer, ByVal AccountRoleId As Integer, _
        ByVal AccountLocationId As Integer, ByVal CountryId As Short, ByVal BillingTypeId As Integer, _
        ByVal StartDate As Date, ByVal DefaultProjectId As Integer, ByVal EmployeeManagerId As Integer, _
        ByVal TimeZoneId As Byte, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer, _
        ByVal EmployeePayTypeId As Guid, ByVal StatusId As Integer, ByVal JobTitle As String, _
        ByVal HiredDate As Date, ByVal TerminationDate As Date, ByVal AccountWorkingDayTypeId As Guid, _
        ByVal AccountTimeOffPolicyId As Guid, ByVal TimeOffApprovalTypeId As Integer, _
        ByVal AccountHolidayTypeId As Guid, ByVal IsForcePasswordChange As Boolean, ByVal Address1 As String, _
        ByVal Address2 As String, ByVal State As String, ByVal City As String, ByVal Zip As String, _
        ByVal HomePhoneNo As String, ByVal WorkPhoneNo As String, ByVal MobilePhoneNo As String, _
        ByVal MiddleName As String, ByVal Prefix As String, ByVal DoNotSendEmail As Boolean)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objEmployee As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = objEmployee.GetAccountEmployeesByEmployeeName(AccountId, FirstName + " " + LastName)
        If dtEmployee.Rows.Count > 0 Then

        Else
            objEmployee.AddAccountEmployee(Username, Password, FirstName, LastName, EmailAddress, EmployeeCode, _
            AccountId, AccountDepartmentId, AccountRoleId, AccountLocationId, CountryId, BillingTypeId, _
            StartDate, DefaultProjectId, EmployeeManagerId, TimeZoneId, CreatedByEmployeeId, ModifiedByEmployeeId, _
            EmployeePayTypeId, StatusId, JobTitle, HiredDate, TerminationDate, AccountWorkingDayTypeId, _
            AccountTimeOffPolicyId, TimeOffApprovalTypeId, AccountHolidayTypeId, IsForcePasswordChange, "en-US", False, False, Address1, _
            Address2, State, City, Zip, HomePhoneNo, WorkPhoneNo, MobilePhoneNo, MiddleName, Prefix, DoNotSendEmail)
        End If
    End Sub
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub UpdateEmployee(ByVal AccountEmployeeId As Integer, ByVal Password As String, ByVal Prefix As String, ByVal FirstName As String, ByVal LastName As String, _
                    ByVal MiddleName As String, ByVal EMailAddress As String, ByVal EmployeeCode As String, _
                    ByVal AccountDepartmentId As System.Nullable(Of Integer), ByVal AccountRoleId As System.Nullable(Of Integer), ByVal AccountLocationId As System.Nullable(Of Integer), _
                    ByVal AddressLine1 As String, ByVal AddressLine2 As String, ByVal State As String, ByVal City As String, ByVal Zip As String, ByVal CountryId As System.Nullable(Of Short), _
                    ByVal HomePhoneNo As String, ByVal WorkPhoneNo As String, ByVal MobilePhoneNo As String, ByVal BillingTypeId As System.Nullable(Of Integer), _
                    ByVal StartDate As System.Nullable(Of Date), ByVal TerminationDate As System.Nullable(Of Date), ByVal StatusId As Integer, ByVal IsDeleted As System.Nullable(Of Boolean), _
                    ByVal IsDisabled As System.Nullable(Of Boolean), ByVal DefaultProjectId As System.Nullable(Of Integer), ByVal EmployeeManagerId As Integer, _
                    ByVal TimeZoneId As System.Nullable(Of Byte), ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer, ByVal AllowedAccessFromIP As String, _
                    ByVal EmployeePayTypeId As Guid, ByVal JobTitle As String, ByVal HiredDate As System.Nullable(Of Date), _
                    ByVal AccountWorkingDayTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid, ByVal TimeOffApprovalTypeId As Integer, ByVal AccountHolidayTypeId As Guid, _
                    ByVal IsForcePasswordChange As System.Nullable(Of Boolean), ByVal UserInterfaceLanguage As String, ByVal IsShowEmployeeProfilePicture As Boolean)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objEmployee As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = objEmployee.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)

        If dtEmployee.Rows.Count > 0 Then
            objEmployee.UpdateAccountEmployee(EMailAddress, Password, Prefix, FirstName, LastName, MiddleName, EMailAddress, EmployeeCode, _
            AccountId, AccountDepartmentId, AccountRoleId, AccountLocationId, AddressLine1, AddressLine2, State, City, Zip, CountryId, HomePhoneNo, WorkPhoneNo, MobilePhoneNo, BillingTypeId, _
            StartDate, TerminationDate, StatusId, IsDeleted, IsDisabled, DefaultProjectId, EmployeeManagerId, TimeZoneId, CreatedByEmployeeId, ModifiedByEmployeeId, AllowedAccessFromIP, AccountEmployeeId, EmployeePayTypeId, _
            JobTitle, HiredDate, AccountWorkingDayTypeId, AccountTimeOffPolicyId, TimeOffApprovalTypeId, AccountHolidayTypeId, IsForcePasswordChange, UserInterfaceLanguage, IsShowEmployeeProfilePicture, False, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", True)
        End If
    End Sub
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployeeId(ByVal EmployeeName As String) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objEmployee As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nEmployeeId As Integer
        Try
            nEmployeeId = objEmployee.GetAccountEmployeesByEmployeeName(AccountId, EmployeeName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Employee " & """" & EmployeeName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nEmployeeId
    End Function
    ''    <WebMethod()> _
    ''<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    ''    Public Function GetEmployeeNameByEmployeeId(ByVal AccountEmployeeId As Integer) As ArrayList
    ''        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
    ''            Throw New Exception("You are not authorized to access this.")
    ''        End If
    ''        Dim EmployeeArrayList As New ArrayList
    ''        Dim objEmployee As New Employee
    ''        Dim EmployeeBLL As New AccountEmployeeBLL
    ''        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
    ''        Dim drEmployee As AccountEmployee.AccountEmployeeRow
    ''        For Each drEmployee In dtEmployee.Rows
    ''            objEmployee = New Employee
    ''            With objEmployee
    ''                .EmployeeName = drEmployee.Username
    ''            End With
    ''            EmployeeArrayList.Add(objEmployee)
    ''        Next
    ''        Return EmployeeArrayList
    ''    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetUserRoleId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objAccountRoles As New AccountRoleBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim UserRoleId As Integer = objAccountRoles.GetAccountRolesByAccountIdAndMasterAccountRoleId(AccountId, 2).Rows(0).Item(0)
        Return UserRoleId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployeeTypeId() As Guid
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objEmployeeType As New AccountEmployeeTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nEmployeeTypeId As Guid = objEmployeeType.GetDefaultAccountEmployeeTypeId(AccountId)
        Return nEmployeeTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployeeStatusId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objAccountStatus As New AccountStatusBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nEmployeeStatusId As Integer = objAccountStatus.GetDefaultAccountStatusId(AccountId)
        Return nEmployeeStatusId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployeeBillingTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objBillingType As New AccountBillingTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nBillingTypeId As Integer = objBillingType.GetAccountBillingTypesByMasterBillingTypeId(AccountId, 1).Rows(0).Item(0)
        Return nBillingTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployeeWorkingDayTypeId() As Guid
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objWorkingDayType As New AccountWorkingDayTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nWorkingDayTypeId As Guid = objWorkingDayType.InsertDefault(AccountId, 0)
        Return nWorkingDayTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetEmployeesData() As DataTable
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objEmployee As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        GetEmployeesData = objEmployee.GetEmployeeForQB(AccountId)
        Return GetEmployeesData
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function IsEmployeeExistsByEmailAddress(ByVal EmailAddress As String) As Boolean
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objEmployee As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        If objEmployee.GetAccountEmployeesByEmailAddress(EmailAddress).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
