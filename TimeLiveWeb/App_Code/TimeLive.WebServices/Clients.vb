Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Clients
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddClient(ByVal objClient As Client) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetClients() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ClientArrayList As New ArrayList
        Dim objClient As New Client
        Dim ClientBLL As New AccountPartyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtClient As TimeLiveDataSet.AccountPartyDataTable = ClientBLL.GetAccountPartiesByAccountId(AccountId)
        Dim drClient As TimeLiveDataSet.AccountPartyRow
        For Each drClient In dtClient.Rows
            objClient = New Client
            objClient.ClientName = drClient.PartyName
            If IsDBNull(drClient.Item("EmailAddress")) Then
                objClient.EmailAddress = ""
            Else
                objClient.EmailAddress = drClient.EMailAddress
            End If
            If IsDBNull(drClient("Notes")) Then
                objClient.Notes = ""
            Else
                objClient.Notes = drClient.Notes
            End If
            If IsDBNull(drClient("Telephone1")) Then
                objClient.Telephone1 = ""
            Else
                objClient.Telephone1 = drClient.Telephone1
            End If
            If IsDBNull(drClient("Telephone2")) Then
                objClient.Telephone2 = ""
            Else
                objClient.Telephone2 = drClient.Telephone2
            End If
            If IsDBNull(drClient("Fax")) Then
                objClient.Fax = ""
            Else
                objClient.Fax = drClient.Fax
            End If
            ClientArrayList.Add(objClient)
        Next
        Return ClientArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub InsertClient(ByVal ClientName As String, ByVal ClientNick As String, _
    ByVal EmailAddress As String, ByVal Address1 As String, ByVal Address2 As String, _
    ByVal CountryId As Short, ByVal State As String, ByVal City As String, ByVal ZipCode As String, _
    ByVal Telephone1 As String, ByVal Telephone2 As String, ByVal Fax As String, _
    ByVal DefaultBillingRate As Decimal, ByVal Website As String, ByVal Notes As String, _
    ByVal IsDisabled As Boolean, ByVal IsDeleted As Boolean, ByVal CreatedOn As Date, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As Date, ByVal ModifiedByEmployeeId As Integer)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ClientBLL As New AccountPartyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtClient As TimeLiveDataSet.AccountPartyDataTable = ClientBLL.GetClientsByName(AccountId, ClientName)
        If dtClient.Rows.Count > 0 Then
        Else
            ClientBLL.AddAccountParty(AccountId, ClientName, ClientNick, EmailAddress, Address1, Address2, _
            CountryId, State, City, ZipCode, Telephone1, Telephone2, Fax, DefaultBillingRate, _
            Website, Notes, IsDisabled, IsDeleted, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, 0, 0, True)
        End If
    End Sub
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetClientId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objClient As New AccountPartyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nClientId As Integer
        Try
            nClientId = objClient.GetAccountPartiesByAccountId(AccountId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Client not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nClientId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetClientIdByName(ByVal ClientName As String) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objClient As New AccountPartyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nClientId As Integer
        Try
            nClientId = objClient.GetClientsByName(AccountId, ClientName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Client " & """" & ClientName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nClientId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAssignedClients() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ClientArrayList As New ArrayList
        Dim objClient As New Client
        Dim PartyBLL As New AccountPartyBLL
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeID
        Dim dtClient As AccountClient.TimeEntryClientDataTable = PartyBLL.GetAccountPartiesForTimeEntryByAccountEmployeeId(AccountEmployeeId)
        Dim drClient As AccountClient.TimeEntryClientRow
        For Each drClient In dtClient.Rows
            objClient = New Client
            With objClient
                .ClientId = drClient.AccountPartyId
                .ClientName = drClient.PartyName
            End With
            ClientArrayList.Add(objClient)
        Next
        Return ClientArrayList
    End Function
End Class