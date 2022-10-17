Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountWorkingDayBLL

    Private _AccountWorkingDayTableAdapter As AccountWorkingDayTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountWorkingDayTableAdapter
        Get
            If _AccountWorkingDayTableAdapter Is Nothing Then
                _AccountWorkingDayTableAdapter = New AccountWorkingDayTableAdapter()
            End If

            Return _AccountWorkingDayTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDays() As TimeLiveDataSet.AccountWorkingDayDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDaysByAccountIdForGrid(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountWorkingDayDataTable
        Dim _vueAccountWorkingDayTableAdapter As New vueAccountWorkingDayTableAdapter
        Return _vueAccountWorkingDayTableAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDaysByAccountIdForGridEdit(ByVal AccountId As Integer, ByVal AccountWorkingDayTypeId As Guid) As TimeLiveDataSet.vueAccountWorkingDayDataTable
        Dim _vueAccountWorkingDayTableAdapter As New vueAccountWorkingDayTableAdapter
        Return _vueAccountWorkingDayTableAdapter.GetDataByAccountIdAndAccountWorkingDayTypeId(AccountId, AccountWorkingDayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDaysByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountWorkingDayDataTable
        Dim _vueAccountWorkingDayTableAdapter As New vueAccountWorkingDayTableAdapter
        Return _vueAccountWorkingDayTableAdapter.GetDataByAccountIdNew(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetWorkingDaysByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable
        Dim _AccountEmployeeWorkingDaysTableAdapter As New vueAccountEmployeeWorkingDaysTableAdapter
        GetWorkingDaysByAccountEmployeeId = _AccountEmployeeWorkingDaysTableAdapter.GetWorkingDaysByEmployeeId(AccountEmployeeId)
        Return GetWorkingDaysByAccountEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId(ByVal AccountId As Integer, ByVal AccountWorkingDayTypeId As Guid) As TimeLiveDataSet.vueAccountWorkingDayDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountWorkingDayDataTable", "GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId", AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountWorkingDayTableAdapter As New vueAccountWorkingDayTableAdapter
            GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId = _vueAccountWorkingDayTableAdapter.GetDataByAccountWorkingDayTypeIdAndAccountId(AccountId, AccountWorkingDayTypeId)
            CacheManager.AddAccountDataInCache(GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId, strCacheKey)
        End If
        Return GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDaysResourceByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountWorkingDayDataTable
        Dim _vueAccountWorkingDayTableAdapter As New vueAccountWorkingDayTableAdapter
        GetAccountWorkingDaysResourceByAccountId = _vueAccountWorkingDayTableAdapter.GetDataByAccountIdNew(AccountId)
        Return ResourceHelper.SetResourceValueInDataTable(GetAccountWorkingDaysResourceByAccountId, "WorkingDay")
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountWorkingDay( _
                        ByVal AccountId As Integer, ByVal WorkingDayNo As Integer, ByVal AccountWorkingDayTypeId As Guid) As Boolean
        ' Create a new ProductRow instance


        _AccountWorkingDayTableAdapter = New AccountWorkingDayTableAdapter

        Dim AccountWorkingDays As New TimeLiveDataSet.AccountWorkingDayDataTable
        Dim AccountWorkingDay As TimeLiveDataSet.AccountWorkingDayRow = AccountWorkingDays.NewAccountWorkingDayRow

        With AccountWorkingDay
            .AccountId = AccountId
            .WorkingDayNo = WorkingDayNo
            .AccountWorkingDayTypeId = AccountWorkingDayTypeId
        End With

        AccountWorkingDays.AddAccountWorkingDayRow(AccountWorkingDay)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountWorkingDays)
        CacheManager.ClearCache("vueAccountWorkingDayDataTable", , True)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountWorkingDayId(ByVal Original_AccountWorkingDayId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountWorkingDayId)
        CacheManager.ClearCache("vueAccountWorkingDayDataTable", , True)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer)
        Adapter.InsertDefault(AccountId)
    End Sub
    Public Sub UpdateAccountWorkingDayTypeId(ByVal AccountId As Integer)
        Adapter.UpdateAccountWorkingDayTypeId(AccountId)
    End Sub
End Class