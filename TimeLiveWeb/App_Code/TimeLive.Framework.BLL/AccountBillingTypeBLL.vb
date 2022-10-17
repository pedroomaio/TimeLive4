Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountBillingTypeBLL

    Private _AccountBillingTypeTableAdapter As AccountBillingTypeTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountBillingTypeTableAdapter
        Get
            If _AccountBillingTypeTableAdapter Is Nothing Then
                _AccountBillingTypeTableAdapter = New AccountBillingTypeTableAdapter()
            End If

            Return _AccountBillingTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypes() As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountBillingTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable


        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingTypeDataTable", "GetvueAccountBillingTypesByAccountId", AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueAccountBillingTypesByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetvueAccountBillingTypesByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetvueAccountBillingTypesByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetvueAccountBillingTypesByAccountId)

        Return GetvueAccountBillingTypesByAccountId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesForSelection(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountBillingTypeDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountBillingTypeDataTable", "GetAccountBillingTypesForSelection", AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountBillingTypesForSelection = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountBillingTypeTableAdapter As New vueAccountBillingTypeTableAdapter
            GetAccountBillingTypesForSelection = _vueAccountBillingTypeTableAdapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountBillingTypesForSelection, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountBillingTypesForSelection)

        Return GetAccountBillingTypesForSelection
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetBillingTypeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesByAccountBillingTypeId(ByVal AccountBillingTypeId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByAccountBillingTypeId(AccountBillingTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesForClientByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByBillingCategoryId(AccountId, 2)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesForProjectByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByBillingCategoryId(AccountId, 2)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesForProjectByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountBillingTypeId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByBillingCategoryIdAndIsDisabled(AccountId, 2, AccountBillingTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesForEmployeeByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountBillingTypeId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByBillingCategoryIdAndIsDisabled(AccountId, 1, AccountBillingTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesByMasterBillingTypeId(ByVal AccountId As Integer, ByVal MasterAccountBillingTypeId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByMasterBillingTypeId(AccountId, MasterAccountBillingTypeId, 1)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingTypesForEmployeeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountBillingTypeDataTable
        Return Adapter.GetDataByBillingCategoryId(AccountId, 1)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountBillingType( _
                        ByVal AccountId As Integer, ByVal BillingType As String, ByVal BillingCategoryId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountBillingTypeTableAdapter = New AccountBillingTypeTableAdapter

        Dim AccountBillingTypes As New TimeLiveDataSet.AccountBillingTypeDataTable
        Dim AccountBillingType As TimeLiveDataSet.AccountBillingTypeRow = AccountBillingTypes.NewAccountBillingTypeRow

        With AccountBillingType
            .AccountId = AccountId
            .BillingType = BillingType
            .BillingCategoryId = BillingCategoryId
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Item("MasterAccountBillingTypeId") = System.DBNull.Value
            .IsDisabled = False
        End With

        AccountBillingTypes.AddAccountBillingTypeRow(AccountBillingType)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountBillingTypes)

        CacheManager.ClearCache("AccountBillingTypeDataTable", , True)


        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountBillingType(ByVal AccountId As Integer, ByVal BillingType As String, _
    ByVal BillingCategoryId As Integer, ByVal Original_AccountBillingTypeId As Integer, ByVal CreatedOn As DateTime, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, _
    ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountBillingTypes As TimeLiveDataSet.AccountBillingTypeDataTable = Adapter.GetDataByAccountBillingTypeId(Original_AccountBillingTypeId)
        Dim AccountBillingType As TimeLiveDataSet.AccountBillingTypeRow = AccountBillingTypes.Rows(0)

        With AccountBillingType
            .BillingType = BillingType
            .BillingCategoryId = BillingCategoryId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountBillingType)

        CacheManager.ClearCache("AccountBillingTypeDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountBillingType(ByVal Original_AccountBillingTypeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountBillingTypeId)

        CacheManager.ClearCache("AccountBillingTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal UserInterfaceLanguage As String)
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeBillingNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangeBillingNameByUICulture(ByVal AccountId As Integer)
        Dim dtBillingType As TimeLiveDataSet.AccountBillingTypeDataTable = Me.GetBillingTypeByAccountId(AccountId)
        Dim drBillingType As TimeLiveDataSet.AccountBillingTypeRow
        For Each drBillingType In dtBillingType.Rows
            Me.UpdateAccountBillingType(AccountId, ResourceHelper.GetDefaultDataLocalValue(drBillingType.BillingType), drBillingType.BillingCategoryId, drBillingType.AccountBillingTypeId, drBillingType.CreatedOn, drBillingType.CreatedByEmployeeId, drBillingType.ModifiedOn, drBillingType.ModifiedByEmployeeId, drBillingType.IsDisabled)
        Next

    End Sub
    Public Function GetDefaultBillingType(ByVal AccountId As Integer, ByVal MasterAccountBillingTypeId As Integer) As Integer
        Dim dtbilling As TimeLiveDataSet.AccountBillingTypeDataTable = Me.GetAccountBillingTypesByMasterBillingTypeId(AccountId, MasterAccountBillingTypeId)
        Dim drbilling As TimeLiveDataSet.AccountBillingTypeRow
        If dtbilling.Rows.Count > 0 Then
            drbilling = dtbilling.Rows(0)
            Return drbilling.AccountBillingTypeId
        End If

    End Function
End Class
