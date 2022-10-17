Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WorkType
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddWorkType(ByVal objWorkType As WorkTypeService) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetWorkType() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim WorkTypeArrayList As New ArrayList
        Dim objWorkType As New WorkTypeService
        Dim WorkTypeBLL As New AccountWorkTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = WorkTypeBLL.GetAccountWorkTypeByAccountId(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        For Each drWorkType In dtWorkType.Rows
            objWorkType = New WorkTypeService
            objWorkType.AccountWorkType = drWorkType.AccountWorkType
            objWorkType.AccountWorkTypeId = drWorkType.AccountWorkTypeId
            WorkTypeArrayList.Add(objWorkType)
        Next
        Return WorkTypeArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetWorkTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objWorkType As New AccountWorkTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nWorkTypeId As Integer
        Try
            nWorkTypeId = objWorkType.GetAccountWorkTypeByAccountId(AccountId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("WorkType not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nWorkTypeId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetWorkTypeByWorkTypeId(ByVal AccountWorkTypeId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim WorkTypeArrayList As New ArrayList
        Dim objWorkType As New WorkTypeService
        Dim WorkTypeBLL As New AccountWorkTypeBLL
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = WorkTypeBLL.GetAccountWorkTypesByAccountWorkTypeId(AccountWorkTypeId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        For Each drWorkType In dtWorkType.Rows
            objWorkType = New WorkTypeService
            With objWorkType
                objWorkType.AccountWorkType = drWorkType.AccountWorkType
                objWorkType.AccountWorkTypeId = drWorkType.AccountWorkTypeId
            End With
            WorkTypeArrayList.Add(objWorkType)
        Next
        Return WorkTypeArrayList
    End Function
End Class