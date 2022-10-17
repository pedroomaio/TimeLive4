Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountBillingRateTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountBillingRateBLL

    Private _AccountBillingRateTableAdapter As AccountBillingRateTableAdapters.AccountBillingRateTableAdapter = Nothing
    Private _vueAccountBillingRateTableAdapter As AccountBillingRateTableAdapters.vueAccountBillingRateTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountBillingRateTableAdapters.AccountBillingRateTableAdapter
        Get
            If _AccountBillingRateTableAdapter Is Nothing Then
                _AccountBillingRateTableAdapter = New AccountBillingRateTableAdapters.AccountBillingRateTableAdapter()
            End If

            Return _AccountBillingRateTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As AccountBillingRateTableAdapters.vueAccountBillingRateTableAdapter
        Get
            If _vueAccountBillingRateTableAdapter Is Nothing Then
                _vueAccountBillingRateTableAdapter = New AccountBillingRateTableAdapters.vueAccountBillingRateTableAdapter()
            End If

            Return _vueAccountBillingRateTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRates() As AccountBillingRate.AccountBillingRateDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountProjectEmployeeId(ByVal AccountProjectEmployeeId As Long, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.vueAccountBillingRateDataTable
        Return vueAdapter.GetDataByAccountProjectEmployeeId(AccountProjectEmployeeId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountProjectRoleId(ByVal AccountProjectRoleId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.vueAccountBillingRateDataTable
        Return vueAdapter.GetDataByAccountProjectRoleId(AccountProjectRoleId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.vueAccountBillingRateDataTable
        GetAccountBillingRatesByAccountEmployeeId = vueAdapter.GetDataByAccountEmployeeId(AccountEmployeeId, AccountWorkTypeId)

        Uiutilities.FixTableForNoRecords(GetAccountBillingRatesByAccountEmployeeId)

        Return GetAccountBillingRatesByAccountEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate", "AccountEmployeeId=" & AccountEmployeeId & "_TimeEntryDate=" & TimeEntryDate & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate = Adapter.GetBillingRateByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, AccountWorkTypeId, TimeEntryDate)
            CacheManager.AddAccountDataInCache(GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate, strCacheKey)
        End If
        Return GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate(ByVal AccountProjectEmployeeId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate", "AccountProjectEmployeeId=" & AccountProjectEmployeeId & "_TimeEntryDate=" & TimeEntryDate & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate = Adapter.GetBillingRateByAccountProjectEmployeeIdAndTimeEntryDate(AccountProjectEmployeeId, AccountWorkTypeId, TimeEntryDate)
            CacheManager.AddAccountDataInCache(GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate, strCacheKey)
        End If
        Return GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate(ByVal AccountProjectRoleId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate", "AccountProjectRoleId=" & AccountProjectRoleId & "_TimeEntryDate=" & TimeEntryDate & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate = Adapter.GetBillingRateByAccountProjectRoleIdAndTimeEntryDate(AccountProjectRoleId, AccountWorkTypeId, TimeEntryDate)
            CacheManager.AddAccountDataInCache(GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate, strCacheKey)
        End If
        Return GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountIdAndAccountProjectRoleId(ByVal AccountId As Integer, ByVal AccountProjectRoleId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        Return Adapter.GetDataByAccountIdAndAccountProjectRoleId(AccountId, AccountProjectRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfTimeEntry(ByVal AccountBillingRateId As Integer, _
                        ByVal SystemBillingRateTypeId As Short, _
                        ByVal AccountProjectEmployeeId As Long, _
                        ByVal AccountProjectRoleId As Integer, _
                        ByVal AccountEmployeeId As Integer, _
                        ByVal AccountProjectTaskId As Integer, _
                        ByVal BillingRate As Decimal, _
                        ByVal StartDate As Date, _
                        ByVal EndDate As Date, _
                        ByVal EmployeeRate As Decimal, _
                        ByVal AccountWorkTypeId As Integer, _
                        ByVal BillingRateCurrencyId As Integer, _
                        ByVal EmployeeRateCurrencyId As Integer, _
                        ByVal BaseCurrencyId As Integer) As Decimal

        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL

        Dim BillingRateExchangeRate As Double = GetBillingRateExchangeRate(BillingRateCurrencyId)
        Dim EmployeeRateExchangeRate As Double = GetEmployeeRateExchangeRate(EmployeeRateCurrencyId)

        If SystemBillingRateTypeId = 1 Then
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfEmployee(BillingRate, StartDate, EndDate, AccountEmployeeId, EmployeeRate, AccountWorkTypeId, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId)
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfEmployeeUnBillable(StartDate, EndDate, AccountEmployeeId, AccountWorkTypeId)
        ElseIf SystemBillingRateTypeId = 2 Then
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfProjectRole(BillingRate, StartDate, EndDate, AccountProjectRoleId, EmployeeRate, AccountWorkTypeId, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId)
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfProjectRoleUnBillable(StartDate, EndDate, AccountProjectRoleId, AccountWorkTypeId)
        ElseIf SystemBillingRateTypeId = 3 Then
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfProjectEmployee(BillingRate, StartDate, EndDate, AccountProjectEmployeeId, EmployeeRate, AccountWorkTypeId, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId)
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfProjectEmployeeUnBillable(StartDate, EndDate, AccountProjectEmployeeId, AccountWorkTypeId)
        ElseIf SystemBillingRateTypeId = 4 Then
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfProjectTask(BillingRate, StartDate, EndDate, AccountProjectTaskId, EmployeeRate, AccountWorkTypeId, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId)
            Call New AccountEmployeeTimeEntryBLL().UpdateBillingRateOfProjectTaskUnBillable(StartDate, EndDate, AccountProjectTaskId, AccountWorkTypeId)
        End If

        'Me.GetAccountBillingRatesByAccountBillingRateId(AccountBillingRateId)
        'Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = TimeEntryBLL.GetAccountEmployeeTimeEntriesByDateRange(DBUtilities.GetSessionAccountEmployeeId, StartDate, EndDate)
        'Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = dtTimeEntry.Rows(0)



    End Function
    Public Function GetBillingRateExchangeRate(ByVal BillingRateCurrencyId As Integer) As Double
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = BLL.GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(DBUtilities.GetSessionAccountId, BillingRateCurrencyId)
        Dim dr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.ExchangeRate
        Else
            Return 0
        End If
    End Function
    Public Function GetEmployeeRateExchangeRate(ByVal EmployeeRateCurrencyId As Integer) As Double
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = BLL.GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(DBUtilities.GetSessionAccountId, EmployeeRateCurrencyId)
        Dim dr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.ExchangeRate
        Else
            Return 0
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountBillingRateId(ByVal AccountBillingRateId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        Return Adapter.GetDataByAccountBillingRateId(AccountBillingRateId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountBillingRateLastId.Rows(0)
        Return a.LastId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountBillingRate( _
                        ByVal AccountId As Integer, _
                        ByVal SystemBillingRateTypeId As Short, _
                        ByVal AccountProjectEmployeeId As Long, _
                        ByVal AccountProjectRoleId As Integer, _
                        ByVal AccountEmployeeId As Integer, _
                        ByVal AccountProjectTaskId As Integer, _
                        ByVal BillingRate As Decimal, _
                        ByVal StartDate As Date, _
                        ByVal EndDate As Date, _
                        ByVal AccountWorkTypeId As Integer, _
                        ByVal EmployeeRate As Decimal, _
                        ByVal BillingRateCurrencyId As Integer, _
                        ByVal EmployeeRateCurrencyId As Integer _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountBillingRateTableAdapter = New AccountBillingRateTableAdapters.AccountBillingRateTableAdapter

        Dim AccountBillingRates As New AccountBillingRate.AccountBillingRateDataTable
        Dim AccountBillingRate As AccountBillingRate.AccountBillingRateRow = AccountBillingRates.NewAccountBillingRateRow

        With AccountBillingRate
            .AccountId = AccountId
            .SystemBillingRateTypeId = SystemBillingRateTypeId
            If AccountProjectEmployeeId <> 0 Then
                .AccountProjectEmployeeId = AccountProjectEmployeeId
            Else
                .Item("AccountProjectEmployeeId") = System.DBNull.Value
            End If
            If AccountProjectRoleId <> 0 Then
                .AccountProjectRoleId = AccountProjectRoleId
            Else
                .Item("AccountProjectRoleId") = System.DBNull.Value
            End If
            If AccountEmployeeId <> 0 Then
                .AccountEmployeeId = AccountEmployeeId
            Else
                .Item("AccountEmployeeId") = System.DBNull.Value
            End If
            .BillingRate = BillingRate
            .StartDate = StartDate
            .EndDate = EndDate
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            Else
                .Item("AccountProjectTaskId") = System.DBNull.Value
            End If
            .AccountWorkTypeId = AccountWorkTypeId
            .EmployeeRate = EmployeeRate
            .BillingRateCurrencyId = BillingRateCurrencyId
            .EmployeeRateCurrencyId = EmployeeRateCurrencyId
        End With

        AccountBillingRates.AddAccountBillingRateRow(AccountBillingRate)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountBillingRates)

        CacheManager.ClearCache("AccountBillingTypeRateTable", , True)


        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountBillingRate( _
                        ByVal AccountId As Integer, _
                        ByVal SystemBillingRateTypeId As Short, _
                        ByVal AccountProjectEmployeeId As Long, _
                        ByVal AccountProjectRoleId As Integer, _
                        ByVal AccountEmployeeId As Integer, _
                        ByVal BillingRate As Decimal, _
                        ByVal StartDate As Date, _
                        ByVal EndDate As Date, _
                        ByVal AccountProjectTaskId As Integer, _
                        ByVal AccountWorkTypeId As Integer, _
                        ByVal EmployeeRate As Decimal, _
                        ByVal BillingRateCurrencyId As Integer, _
                        ByVal EmployeeRateCurrencyId As Integer, _
                        ByVal Original_AccountBillingRateId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim AccountBillingRates As AccountBillingRate.AccountBillingRateDataTable = Adapter.GetDataByAccountBillingRateId(Original_AccountBillingRateId)
        Dim AccountBillingRate As AccountBillingRate.AccountBillingRateRow = AccountBillingRates.Rows(0)

        With AccountBillingRate
            .AccountId = AccountId
            .SystemBillingRateTypeId = SystemBillingRateTypeId
            If AccountProjectEmployeeId <> 0 Then
                .AccountProjectEmployeeId = AccountProjectEmployeeId
            Else
                .Item("AccountProjectEmployeeId") = System.DBNull.Value
            End If
            If AccountProjectRoleId <> 0 Then
                .AccountProjectRoleId = AccountProjectRoleId
            Else
                .Item("AccountProjectRoleId") = System.DBNull.Value
            End If
            If AccountEmployeeId <> 0 Then
                .AccountEmployeeId = AccountEmployeeId
            Else
                .Item("AccountEmployeeId") = System.DBNull.Value
            End If
            .BillingRate = BillingRate
            .StartDate = StartDate
            .EndDate = EndDate
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            Else
                .Item("AccountProjectTaskId") = System.DBNull.Value
            End If
            .AccountWorkTypeId = AccountWorkTypeId
            .EmployeeRate = EmployeeRate
            .BillingRateCurrencyId = BillingRateCurrencyId
            .EmployeeRateCurrencyId = EmployeeRateCurrencyId
        End With


        AfterUpdate()

        Dim rowsAffected As Integer = Adapter.Update(AccountBillingRate)

        CacheManager.ClearCache("AccountBillingRateDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountBillingRate", , True)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountBillingRate(ByVal Original_AccountBillingRateId As Integer) As Boolean
        Try
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountBillingRateId)
            CacheManager.ClearCache("AccountBillingRateDataTable", , True)

            ' Return true if precisely one row was deleted, otherwise false
            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try

    End Function


    'Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
    '    Adapter.InsertDefault(AccountId, AccountEmployeeId)
    'End Sub

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.vueAccountBillingRateDataTable
        Return vueAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate(ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate", "AccountProjectTaskId=" & AccountProjectTaskId & "_TimeEntryDate=" & TimeEntryDate & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate = Adapter.GetBillingRateByAccountProjectTaskIdAndTimeEntryDate(AccountProjectTaskId, AccountWorkTypeId, TimeEntryDate)
            CacheManager.AddAccountDataInCache(GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate, strCacheKey)
        End If
        Return GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate
    End Function
    Public Sub InsertAccountBillingRatesByProjectTaskTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        Dim BLL As New AccountProjectTaskBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = BLL.GetProjectTasksByAccountProjectId(AccountProjectId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            Adapter.InsertAccountBillingRatesByProjectTaskTemplate(AccountId, AccountProjectId)
            Call New AccountProjectTaskBLL().UpdateAccountBillingRateIdByAccountProjectId(AccountProjectId)
        End If
    End Sub
    Public Sub InserAccountProjectEmployeeBillingRate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        Adapter.InsertAccountProjectEmployeeBillingRate(AccountId, AccountProjectId)
    End Sub
    Public Sub InserAccountProjectRoleBillingRate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        Adapter.InsertAccountProjectRoleBillingRate(AccountId, AccountProjectId)
    End Sub
    Public Sub UpdateAccountWorkType(ByVal AccountWorkTypeId As Integer, ByVal AccountId As Integer)
        Adapter.UpdateAccountWorkType(AccountWorkTypeId, AccountId)
    End Sub
    Public Sub UpdateCurrenciesInBillngRate(ByVal AccountCurrencyId As Integer, ByVal AccountId As Integer)
        Adapter.UpdateCurrenciesInBillingRate(AccountCurrencyId, AccountId)
    End Sub
    Public Sub InsertDefaultBillingRateOfNewEmployee(ByVal AccountId As Integer)
        Adapter.InsertDefaultBillingRateOfNewEmployee(AccountId, Now.Date, Now.Date.AddYears(1))
    End Sub
    Public Sub InsertBillingRateOfEmployeeWhichIsNotExists(ByVal AccountId As Integer)
        Adapter.InsertBillingRateOfEmployeeWhichIsNotExists(AccountId, Now.Date, Now.Date.AddYears(1))
    End Sub
    Public Sub DeleteBillingRateByAccountIdAndAccountProjectRoleId(ByVal AccountId As Integer, ByVal AccountProjectRoleId As Integer)
        Adapter.DeleteBillingRateByAccountIdAndAccountProjectRoleId(AccountId, AccountProjectRoleId)
    End Sub
    Public Sub DeleteBillingRateByAccountIdAndAccountProjectId(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        Adapter.DeleteBillingRateByAccountIdAndAccountProjectId(AccountId, AccountProjectId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetBillingRatesByAccountEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetBillingRatesByAccountEmployeeId", "AccountEmployeeId=" & AccountEmployeeId & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetBillingRatesByAccountEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetBillingRatesByAccountEmployeeId = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId, AccountWorkTypeId)
            CacheManager.AddAccountDataInCache(GetBillingRatesByAccountEmployeeId, strCacheKey)
        End If
        Return GetBillingRatesByAccountEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetBillingRatesByAccountProjectRoleId(ByVal AccountProjectRoleId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetBillingRatesByAccountProjectRoleId", "AccountProjectRoleId=" & AccountProjectRoleId & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetBillingRatesByAccountProjectRoleId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetBillingRatesByAccountProjectRoleId = Adapter.GetDataByAccountProjectRoleId(AccountProjectRoleId, AccountWorkTypeId)
            CacheManager.AddAccountDataInCache(GetBillingRatesByAccountProjectRoleId, strCacheKey)
        End If
        Return GetBillingRatesByAccountProjectRoleId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetBillingRatesByAccountProjectEmployeeId(ByVal AccountProjectEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetBillingRatesByAccountProjectEmployeeId", "AccountProjectEmployeeId=" & AccountProjectEmployeeId & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetBillingRatesByAccountProjectEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetBillingRatesByAccountProjectEmployeeId = Adapter.GetDataByAccountProjectEmployeeId(AccountProjectEmployeeId, AccountWorkTypeId)
            CacheManager.AddAccountDataInCache(GetBillingRatesByAccountProjectEmployeeId, strCacheKey)
        End If
        Return GetBillingRatesByAccountProjectEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetBillingRatesByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer) As AccountBillingRate.AccountBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountBillingRateDataTable", "GetBillingRatesByAccountProjectTaskId", "AccountProjectTaskId=" & AccountProjectTaskId & "_AccountWorkTypeId=" & AccountWorkTypeId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetBillingRatesByAccountProjectTaskId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetBillingRatesByAccountProjectTaskId = Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
            CacheManager.AddAccountDataInCache(GetBillingRatesByAccountProjectTaskId, strCacheKey)
        End If
        Return GetBillingRatesByAccountProjectTaskId
    End Function
End Class
