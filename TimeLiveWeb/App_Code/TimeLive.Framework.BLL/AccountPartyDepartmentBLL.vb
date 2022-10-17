Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountPartyDepartmentBLL

    Dim _AccountPartyDepartmentTableAdapter As AccountPartyDepartmentTableAdapter = Nothing
    Dim _vueAccountPartyDepartmentTableAdapter As vueAccountPartyDepartmentTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountPartyDepartmentTableAdapter

        Get
            If _AccountPartyDepartmentTableAdapter Is Nothing Then
                _AccountPartyDepartmentTableAdapter = New AccountPartyDepartmentTableAdapter
            End If
            Return _AccountPartyDepartmentTableAdapter
        End Get

    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountPartyDepartmentTableAdapter

        Get
            If _vueAccountPartyDepartmentTableAdapter Is Nothing Then
                _vueAccountPartyDepartmentTableAdapter = New vueAccountPartyDepartmentTableAdapter
            End If
            Return _vueAccountPartyDepartmentTableAdapter
        End Get

    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartyDepartments() As TimeLiveDataSet.AccountPartyDepartmentDataTable
        Return Adapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountPartyDepartments() As TimeLiveDataSet.vueAccountPartyDepartmentDataTable
        Return vueAdapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountPartyDepartmentId(ByVal AccountPartyDepartmentId As Integer) As TimeLiveDataSet.AccountPartyDepartmentDataTable
        Return Adapter.GetDataByAccountPartyDepartmentId(AccountPartyDepartmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountPartyId(ByVal AccountPartyId As Integer) As TimeLiveDataSet.AccountPartyDepartmentDataTable
        Return Adapter.GetDataByAccountPartyId(AccountPartyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueDataByAccountPartyId(ByVal AccountPartyId As Integer) As TimeLiveDataSet.vueAccountPartyDepartmentDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountPartyDepartmentDataTable", "GetvueDataByAccountPartyId", "AccountPartyId=" & AccountPartyId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueDataByAccountPartyId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountPartyDepartmentTableAdapter As New vueAccountPartyDepartmentTableAdapter
            GetvueDataByAccountPartyId = _vueAccountPartyDepartmentTableAdapter.GetDataByAccountPartyId(DBUtilities.GetSessionAccountId, AccountPartyId)
            CacheManager.AddAccountDataInCache(GetvueDataByAccountPartyId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetvueDataByAccountPartyId)

        Return GetvueDataByAccountPartyId

        Return vueAdapter.GetDataByAccountPartyId(DBUtilities.GetSessionAccountId, AccountPartyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function AddAccountPartyDepartment(ByVal AccountPartyId As Integer, ByVal PartyDepartmentCode As String, _
    ByVal PartyDepartmentName As String, ByVal PartyDepartmentLocation As String) As Boolean

        _AccountPartyDepartmentTableAdapter = New AccountPartyDepartmentTableAdapter

        Dim AccountPartyDepartments As New TimeLiveDataSet.AccountPartyDepartmentDataTable
        Dim AccountPartyDepartmentRow As TimeLiveDataSet.AccountPartyDepartmentRow = AccountPartyDepartments.NewAccountPartyDepartmentRow

        With AccountPartyDepartmentRow
            .AccountPartyId = AccountPartyId
            .PartyDepartmentCode = PartyDepartmentCode
            .PartyDepartmentName = PartyDepartmentName
            .PartyDepartmentLocation = PartyDepartmentLocation
        End With

        AccountPartyDepartments.AddAccountPartyDepartmentRow(AccountPartyDepartmentRow)


        CacheManager.ClearCache("AccountPartyDepartmentDataTable", , True)

        Dim rowsAffected As Integer = Adapter.Update(AccountPartyDepartments)
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAccountPartyDepartment(ByVal AccountPartyId As Integer, ByVal PartyDepartmentCode As String, _
    ByVal PartyDepartmentName As String, ByVal PartyDepartmentLocation As String, ByVal Original_AccountPartyDepartmentId As Integer) As Boolean

        Dim AccountPartyDepartments As TimeLiveDataSet.AccountPartyDepartmentDataTable = Adapter.GetDataByAccountPartyDepartmentId(Original_AccountPartyDepartmentId)
        Dim AccountPartyDepartmentRow As TimeLiveDataSet.AccountPartyDepartmentRow = AccountPartyDepartments.Rows(0)


        With AccountPartyDepartmentRow
            .AccountPartyId = AccountPartyId
            .PartyDepartmentCode = PartyDepartmentCode
            .PartyDepartmentName = PartyDepartmentName
            .PartyDepartmentLocation = PartyDepartmentLocation
        End With

        CacheManager.ClearCache("AccountPartyDepartmentDataTable", , True)

        Dim rowsAffected As Integer = Adapter.Update(AccountPartyDepartments)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function DeleteAccountPartyDepartment(ByVal Original_AccountPartyDepartmentId As Integer) As Boolean

        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountPartyDepartmentId)

        CacheManager.ClearCache("AccountPartyDepartmentDataTable", , True)

        Return rowsAffected = 1

    End Function
End Class
