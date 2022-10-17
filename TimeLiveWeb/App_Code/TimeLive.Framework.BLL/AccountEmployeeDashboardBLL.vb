Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountEmployeeDashboardTableAdapters
Imports SystemEmployeeDashboardTableAdapters
Imports System.Web
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeDashboardBLL
    Private _AccountEmployeeDashboardAdapter As AccountEmployeeDashboardTableAdapter = Nothing
    Private _SystemEmployeeDashboardAdapter As SystemEmployeeDashboardTableAdapter = Nothing
    Private _vueAccountEmployeeDashboardAdapter As VueAccountEmployeeDashboardTableAdapter = Nothing

    Protected ReadOnly Property SystemEmployeeDashboardAdapter As SystemEmployeeDashboardTableAdapter
        Get
            If _SystemEmployeeDashboardAdapter Is Nothing Then
                _SystemEmployeeDashboardAdapter = New SystemEmployeeDashboardTableAdapter
            End If
            Return _SystemEmployeeDashboardAdapter
        End Get
    End Property

    Protected ReadOnly Property AccountEmployeeDashboardAdapter As AccountEmployeeDashboardTableAdapter
        Get
            If _AccountEmployeeDashboardAdapter Is Nothing Then
                _AccountEmployeeDashboardAdapter = New AccountEmployeeDashboardTableAdapter
            End If
            Return _AccountEmployeeDashboardAdapter
        End Get
    End Property

    Protected ReadOnly Property vueAccountEmployeeDashboardAdapter As VueAccountEmployeeDashboardTableAdapter
        Get
            If _vueAccountEmployeeDashboardAdapter Is Nothing Then
                _vueAccountEmployeeDashboardAdapter = New VueAccountEmployeeDashboardTableAdapter
            End If
            Return _vueAccountEmployeeDashboardAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemEmployeeDashboard() As AccountEmployeeDashboard.SystemEmployeeDashboardDataTable
        Return SystemEmployeeDashboardAdapter.GetSystemEmployeedashboard(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeDashboard() As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
        Return AccountEmployeeDashboardAdapter.GetAccountEmployeeDashboard
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeDashboard() As AccountEmployeeDashboard.VueAccountEmployeeDashboardDataTable
        Return vueAccountEmployeeDashboardAdapter.GetvueAccountEmployeeDashboard
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeIdByAccountEmployeeDashboard(ByVal AccountEmployeeDashboardId As Guid) As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
        Return AccountEmployeeDashboardAdapter.GetAccountEmployeeDashboardByAccountEmployeeDashboardId(AccountEmployeeDashboardId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeDashboardBySystemEmployeeDashboard(ByVal SystemAccountEmployeeDashboardId As Guid, ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
        Return AccountEmployeeDashboardAdapter.GetAccountEmployeeDashboardBySystemEmployeeDashboard(SystemAccountEmployeeDashboardId, AccountEmployeeId, AccountId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IsPanelView As Boolean) As AccountEmployeeDashboard.VueAccountEmployeeDashboardDataTable
        Return vueAccountEmployeeDashboardAdapter.GetDataByEmployeeId(AccountId, AccountEmployeeId, IsPanelView)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeDashboardByAccountIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
        Return AccountEmployeeDashboardAdapter.GetDataByAccountIdAndAccountEmployeeId(AccountId, AccountEmployeeId)
    End Function


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeDashboard(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal SystemEmployeeDashboardId As Guid, ByVal IsPanelView As Boolean, ByVal SortOrder As Integer) As Boolean
        Dim dtAccountEmployeeDashboard As New AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
        Dim drAccountEmployeeDashboard As AccountEmployeeDashboard.AccountEmployeeDashboardRow = dtAccountEmployeeDashboard.NewAccountEmployeeDashboardRow

        With drAccountEmployeeDashboard
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .SystemEmployeeDashboardId = SystemEmployeeDashboardId
            .AccountEmployeeDashboardId = System.Guid.NewGuid
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .IsPanelView = IsPanelView
            .SortOrder = SortOrder
        End With

        dtAccountEmployeeDashboard.AddAccountEmployeeDashboardRow(drAccountEmployeeDashboard)
        Dim rowsAffected As Integer = AccountEmployeeDashboardAdapter.Update(dtAccountEmployeeDashboard)
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeDashboard(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal SystemEmployeeDashboardId As Guid, ByVal Original_AccountEmployeeDashboardId As Guid, ByVal SortOrder As Integer) As Boolean
        Dim dtAccountEmployeeDashboard As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable = AccountEmployeeDashboardAdapter.GetAccountEmployeeDashboardByAccountEmployeeDashboardId(Original_AccountEmployeeDashboardId)
        Dim drAccountEmployeeDashboard As AccountEmployeeDashboard.AccountEmployeeDashboardRow = dtAccountEmployeeDashboard.Rows(0)

        With drAccountEmployeeDashboard
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .SystemEmployeeDashboardId = SystemEmployeeDashboardId
            .AccountEmployeeDashboardId = System.Guid.NewGuid
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .SortOrder = SortOrder
        End With

        Dim rowsAffected As Integer = AccountEmployeeDashboardAdapter.Update(drAccountEmployeeDashboard)
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeDashboard(ByVal Original_SystemAccountEmployeeDashboardId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountEmployeeDashboardAdapter.DeleteQuery(Original_SystemAccountEmployeeDashboardId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer)
        AccountEmployeeDashboardAdapter.InsertDefault(AccountId)
    End Sub
    Public Sub InsertDefaultForEmployeee(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        AccountEmployeeDashboardAdapter.InsertDefaultForEmployees(AccountId, AccountEmployeeId)
    End Sub
End Class
