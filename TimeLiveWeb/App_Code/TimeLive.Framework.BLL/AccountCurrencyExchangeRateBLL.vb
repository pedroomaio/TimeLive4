Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountCurrencyExchangeRateTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountCurrencyExchangeRateBLL
    Private _AccountCurrencyExchangeRateTableAdapter As AccountCurrencyExchangeRateTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountCurrencyExchangeRateTableAdapter
        Get
            If _AccountCurrencyExchangeRateTableAdapter Is Nothing Then
                _AccountCurrencyExchangeRateTableAdapter = New AccountCurrencyExchangeRateTableAdapter()
            End If
            Return _AccountCurrencyExchangeRateTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyExchangeRates() As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyExchangeRatesByAccountCurrencyExchangeRateId(ByVal AccountCurrencyExchangeRateId As Integer) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        Return Adapter.GetDataByAccountCurrencyExchangeRateId(AccountCurrencyExchangeRateId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyExchangeRatesByAccountId(ByVal AccountId As Integer) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(ByVal AccountId As Integer, ByVal AccountCurrencyId As Integer) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId = Adapter.GetDataByAccountIdAndAccountCurrencyId(AccountId, AccountCurrencyId)
        Uiutilities.FixTableForNoRecords(GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId)
        Return GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(ByVal AccountId As Integer, ByVal AccountCurrencyId As Integer) As AccountCurrencyExchangeRate.vueAccountCurrencyExchangeRateDataTable
        Dim _vueAccountCurrencyExchangeRateTableAdapter As New vueAccountCurrencyExchangeRateTableAdapter
        GetvueAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId = _vueAccountCurrencyExchangeRateTableAdapter.GetDataByAccountIdAndAccountCurrencyId(AccountId, AccountCurrencyId)
        Uiutilities.FixTableForNoRecords(GetvueAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId)
        Return GetvueAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountBaseCurrencyByAccountId(ByVal AccountId As Integer) As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountBaseCurrencyDataTable", "GetvueAccountBaseCurrencyByAccountId", "AccountId=" & AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueAccountBaseCurrencyByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountBaseCurrencyTableAdapter As New vueAccountBaseCurrencyTableAdapter
            GetvueAccountBaseCurrencyByAccountId = _vueAccountBaseCurrencyTableAdapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetvueAccountBaseCurrencyByAccountId, strCacheKey)
        End If
        Return GetvueAccountBaseCurrencyByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetExchangeRateByAccountCurrencyIdAndExpenseEntryDate(ByVal AccountCurrencyId As Integer, ByVal ExpenseEntryDate As Date) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        Return Adapter.GetExchangeRateByAccountCurrencyIdAndExpenseEntryDate(AccountCurrencyId, ExpenseEntryDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetExchangeRateByAccountCurrencyIdAndTimeEntryDate(ByVal AccountId As Integer, ByVal AccountCurrencyId As Integer, ByVal TimeEntryDate As Date) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        Return Adapter.GetDataByAccountCurrencyIdAndTimeEntryDate(AccountId, AccountCurrencyId, TimeEntryDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetExchangeRateByAccountCurrencyId(ByVal AccountCurrencyId As Integer) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountCurrencyExchangeRateDataTable", "GetExchangeRateByAccountCurrencyId", "AccountCurrencyId=" & AccountCurrencyId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetExchangeRateByAccountCurrencyId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetExchangeRateByAccountCurrencyId = Adapter.GetDataByAccountCurrencyId(AccountCurrencyId)
            CacheManager.AddAccountDataInCache(GetExchangeRateByAccountCurrencyId, strCacheKey)
        End If
        Return GetExchangeRateByAccountCurrencyId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetExchangeRateByAccountCurrencyIdAndDate(ByVal AccountCurrencyId As Integer, ByVal EntryDate As Date) As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountCurrencyExchangeRateDataTable", "GetExchangeRateByAccountCurrencyIdAndDate", "AccountCurrencyId=" & AccountCurrencyId & "_EntryDate=" & EntryDate)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetExchangeRateByAccountCurrencyIdAndDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetExchangeRateByAccountCurrencyIdAndDate = Adapter.GetDataByAccountCurrencyIdAndDate(AccountCurrencyId, EntryDate)
            CacheManager.AddAccountDataInCache(GetExchangeRateByAccountCurrencyIdAndDate, strCacheKey)
        End If
        Return GetExchangeRateByAccountCurrencyIdAndDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountCurrencyExchangeRate( _
        ByVal ExchangeRateEffectiveStartDate As Date, _
        ByVal ExchangeRateEffectiveEndDate As Date, _
        ByVal ExchangeRate As Decimal, _
        ByVal AccountId As Integer, _
        ByVal AccountCurrencyId As Integer _
                       ) As Boolean

        Try
            _AccountCurrencyExchangeRateTableAdapter = New AccountCurrencyExchangeRateTableAdapter

            Dim AccountCurrencyExchangeRate As New AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable
            Dim AccountCurrencyExchangeRateRow As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow = AccountCurrencyExchangeRate.NewAccountCurrencyExchangeRateRow

            With AccountCurrencyExchangeRateRow
                .ExchangeRateEffectiveStartDate = ExchangeRateEffectiveStartDate
                .ExchangeRateEffectiveEndDate = ExchangeRateEffectiveEndDate
                .ExchangeRate = ExchangeRate
                .AccountId = AccountId
                .AccountCurrencyId = AccountCurrencyId
            End With

            AccountCurrencyExchangeRate.AddAccountCurrencyExchangeRateRow(AccountCurrencyExchangeRateRow)
            AfterUpdate()
            Dim rowsAffected As Integer = Adapter.Update(AccountCurrencyExchangeRate)

            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountCurrencyExchangeRate( _
        ByVal ExchangeRateEffectiveStartDate As Date, _
        ByVal ExchangeRateEffectiveEndDate As Date, _
        ByVal ExchangeRate As Decimal, _
        ByVal AccountId As Integer, _
        ByVal Original_AccountCurrencyExchangeRateId As Integer, _
        ByVal AccountCurrencyId As Integer _
                ) As Boolean

        Dim AccountCurrencyExchangeRate As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = Adapter.GetDataByAccountCurrencyExchangeRateId(Original_AccountCurrencyExchangeRateId)
        Dim AccountCurrencyExchangeRateRow As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow = AccountCurrencyExchangeRate.Rows(0)

        With AccountCurrencyExchangeRateRow
            .ExchangeRateEffectiveStartDate = ExchangeRateEffectiveStartDate
            .ExchangeRateEffectiveEndDate = ExchangeRateEffectiveEndDate
            .ExchangeRate = ExchangeRate
            .AccountId = AccountId
            .AccountCurrencyId = AccountCurrencyId
        End With

        AfterUpdate()
        Dim rowsAffected As Integer = Adapter.Update(AccountCurrencyExchangeRate)

        Return rowsAffected = 1

    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountCurrencyExchangeRate", , True)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function UpdateExchangeRateOfExpenseEntry( _
    ByVal ExchangeRateEffectiveStartDate As Date, _
    ByVal ExchangeRateEffectiveEndDate As Date, _
    ByVal ExchangeRate As Decimal, _
    ByVal AccountCurrencyId As Integer _
            ) As Boolean

        Dim BLL As New AccountExpenseEntryBLL

        BLL.UpdateExchangeRateOfExpenseEntry(ExchangeRate, ExchangeRateEffectiveStartDate, ExchangeRateEffectiveEndDate, AccountCurrencyId)
        'BLL.UpdateExchangeRateOfExpenseEntryUnBillable(ExchangeRateEffectiveStartDate, ExchangeRateEffectiveEndDate, AccountCurrencyId)

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountCurrencyExchangeRate(ByVal Original_AccountCurrencyExchangeRateId As Integer) As Boolean
        Try
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountCurrencyExchangeRateId)

            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try
    End Function

    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountCurrencyExchangeRateLastId.Rows(0)
        Return a.LastId
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer)
        Adapter.InsertDefault(AccountId, Now.Date, Now.Date.AddYears(1))
    End Sub
    Public Sub UpdateExchangeRates(ByVal ExchangeRate As Decimal, ByVal AccountId As Integer)
        Adapter.UpdateExchangeRate(ExchangeRate, AccountId)
    End Sub
    Public Function UpdateBaseCurrencyExchangeRate(ByVal AccountCurrencyExchangeRateId As Integer)

        Dim AccountCurrencyExchangeRate As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = Adapter.GetDataByAccountCurrencyExchangeRateId(AccountCurrencyExchangeRateId)
        Dim AccountCurrencyExchangeRateRow As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow

        If AccountCurrencyExchangeRate.Rows.Count > 0 Then
            AccountCurrencyExchangeRateRow = AccountCurrencyExchangeRate.Rows(0)
            AccountCurrencyExchangeRateRow.ExchangeRate = 1
        End If

        Dim rowsAffected As Integer = Adapter.Update(AccountCurrencyExchangeRate)

        Return rowsAffected = 1

    End Function
    Public Function GetCurrentExchangeRateByCurrencyIdAndDate(ByVal AccountCurrencyId As Integer, ByVal EntryDate As Date) As Decimal
        Dim drExchangeRate As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim dtExchangeRate As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = ExchangeRateBLL.GetExchangeRateByAccountCurrencyIdAndDate(AccountCurrencyId, EntryDate)
        If dtExchangeRate.Rows.Count > 0 Then
            drExchangeRate = dtExchangeRate.Rows(0)
            If Not IsDBNull(drExchangeRate.Item("ExchangeRate")) Then
                Return drExchangeRate.ExchangeRate
            Else
                Return 0
            End If
        Else
            Dim drExchangeRates As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
            Dim dtExchangeRates As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = ExchangeRateBLL.GetExchangeRateByAccountCurrencyId(AccountCurrencyId)
            If dtExchangeRates.Rows.Count > 0 Then

                Dim CalculatedIntrevals(dtExchangeRates.Rows.Count - 1) As Integer

                If dtExchangeRates.Rows.Count > 1 Then

                    For i = 0 To dtExchangeRates.Rows.Count - 1

                        Dim drExchangeRateInFor As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow = dtExchangeRates.Rows(i)
                        Dim CalculateDate As Integer = DateDiff(DateInterval.Day, drExchangeRateInFor.ExchangeRateEffectiveEndDate, EntryDate)

                        If CalculateDate < 0 Then
                            CalculatedIntrevals(i) = CalculateDate * -1
                        Else
                            CalculatedIntrevals(i) = CalculateDate
                        End If

                    Next

                    Dim Index = CalculatedIntrevals.IndexOf(CalculatedIntrevals, CalculatedIntrevals.Min())
                    drExchangeRates = dtExchangeRates.Rows(Index)

                Else

                    drExchangeRates = dtExchangeRates.Rows(0)

                End If

                If Not IsDBNull(drExchangeRates.Item("ExchangeRate")) Then
                    Return drExchangeRates.ExchangeRate
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End If
    End Function
    Public Sub UpdateBaseCurrencyExchangeRateFromWizard(AccountId As Integer, AccountCurrencyId As Integer)
        Dim ExchangeRatedt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = Me.GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(AccountId, AccountCurrencyId)
        Dim ExchangeRatedr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        If ExchangeRatedt.Rows.Count > 0 Then
            ExchangeRatedr = ExchangeRatedt.Rows(0)
            Me.UpdateExchangeRates(ExchangeRatedr.ExchangeRate, AccountId)
            Me.UpdateBaseCurrencyExchangeRate(ExchangeRatedr.AccountCurrencyExchangeRateId)
        End If
    End Sub
End Class
