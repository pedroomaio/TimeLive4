Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class CostCenter
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddCostCenter(ByVal objCostCenter As CostCenter) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetCostCenter() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim CostCenterArrayList As New ArrayList
        Dim objCostCenter As New CostCenterService
        Dim CostCenterBLL As New AccountCostCenterBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtCostCenter As AccountCostCenter.AccountCostCenterDataTable = CostCenterBLL.GetAccountCostCenterByAccountId(AccountId)
        Dim drCostCenter As AccountCostCenter.AccountCostCenterRow
        For Each drCostCenter In dtCostCenter.Rows
            objCostCenter = New CostCenterService
            objCostCenter.AccountCostCenter = drCostCenter.AccountCostCenter
            objCostCenter.AccountCostCenterId = drCostCenter.AccountCostCenterId

            CostCenterArrayList.Add(objCostCenter)
        Next
        Return CostCenterArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetCostCenterId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objCostCenter As New AccountCostCenterBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nCostCenterId As Integer
        Try
            nCostCenterId = objCostCenter.GetAccountCostCenterByAccountId(AccountId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Cost Center not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nCostCenterId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetCostCenterIdByName(ByVal CostCenter As String) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objCostCenter As New AccountCostCenterBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nCostCenterId As Integer
        Try
            nCostCenterId = objCostCenter.GetAccountCostCenterByAccountIdAndAccountCostCenter(AccountId, CostCenter).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Cost Center " & """" & CostCenter & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nCostCenterId
    End Function
End Class