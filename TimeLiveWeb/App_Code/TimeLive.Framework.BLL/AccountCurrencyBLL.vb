Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountCurrencyTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountCurrencyBLL
    Private _AccountCurrencyTableAdapter As AccountCurrencyTableAdapters.AccountCurrencyTableAdapter = Nothing
    '   Private _ExpenseByClientTableAdapter As vueAccountExpenseEntryAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountCurrencyTableAdapters.AccountCurrencyTableAdapter
        Get
            If _AccountCurrencyTableAdapter Is Nothing Then
                _AccountCurrencyTableAdapter = New AccountCurrencyTableAdapters.AccountCurrencyTableAdapter()
            End If
            Return _AccountCurrencyTableAdapter
        End Get
    End Property

    'Protected ReadOnly Property ExpenseByClientAdapter() As vueAccountExpenseEntryAdapter
    '    Get
    '        If _ExpenseByClientTableAdapter Is Nothing Then
    '            _ExpenseByClientTableAdapter = New vueAccountExpenseEntryAdapter()
    '        End If
    '        Return _ExpenseByClientTableAdapter
    '    End Get
    'End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrency() As AccountCurrency.AccountCurrencyDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyByAccountCurrencyId(ByVal AccountCurrencyId As Integer) As AccountCurrency.AccountCurrencyDataTable
        Return Adapter.GetDataByAccountCurrencyId(AccountCurrencyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyBySystemCurrencyId(ByVal SystemCurrencyId As Integer, ByVal AccountId As Integer) As AccountCurrency.AccountCurrencyDataTable
        Return Adapter.GetDataBySystemCurrencyId(SystemCurrencyId, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCurrencyByAccountId(ByVal AccountId As Integer) As AccountCurrency.AccountCurrencyDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCurrencyByAccountId(ByVal AccountId As Integer, Optional ByVal NotFixTable As Boolean = False) As AccountCurrency.vueAccountCurrencyDataTable
        Dim _vueAccountCurrencyTableAdapter As New AccountCurrencyTableAdapters.vueAccountCurrencyTableAdapter
        GetvueAccountCurrencyByAccountId = _vueAccountCurrencyTableAdapter.GetDataByAccountId(AccountId)
        If NotFixTable = False Then
            Uiutilities.FixTableForNoRecords(GetvueAccountCurrencyByAccountId)
        End If
        Return GetvueAccountCurrencyByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCurrencyByAccountCurrencyId(ByVal AccountCurrencyId As Integer) As AccountCurrency.vueAccountCurrencyDataTable
        Dim _vueAccountCurrencyTableAdapter As New AccountCurrencyTableAdapters.vueAccountCurrencyTableAdapter
        Return _vueAccountCurrencyTableAdapter.GetDataByAccountCurrencyId(AccountCurrencyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountIdforBaseCurrency(ByVal AccountId As Integer) As AccountCurrency.vueAccountCurrencyDataTable
        Dim _vueAccountCurrencyTableAdapter As New AccountCurrencyTableAdapters.vueAccountCurrencyTableAdapter
        Return _vueAccountCurrencyTableAdapter.GetDataByAccountIdforBaseCurrency(AccountId)
    End Function

    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetDataByExpenseByClientByAccountId(ByVal AccountExpenseId As Integer) As dsExpenseByClientForXtrReport.vueAccountExpenseEntryDataTable
    '    Dim _ExpenseByClientTableAdapter As New vueAccountExpenseEntryAdapter
    '    Return _ExpenseByClientTableAdapter.GetDataByAccountExpenseId(AccountExpenseId)
    'End Function


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCurrencyByAccountIdAndDisabled(ByVal AccountId As Integer, ByVal AccountCurrencyId As Integer) As AccountCurrency.vueAccountCurrencyDataTable
        Dim _vueAccountCurrencyTableAdapter As New AccountCurrencyTableAdapters.vueAccountCurrencyTableAdapter
        Return _vueAccountCurrencyTableAdapter.GetDataByAccountIdAndDisabled(AccountId, AccountCurrencyId)
    End Function
    Public Function ValidateNewCurrency(ByVal SystemCurrencyId As Integer, ByVal AccountId As Integer) As Boolean
        If Adapter.GetBySystemCurrencyIdAndAccountId(SystemCurrencyId, AccountId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function ValidateExistingCurrency(ByVal SystemCurrencyId As Integer, ByVal AccountCurrencyId As Integer) As Boolean
        If Adapter.GetCurrencyExisting_AccountCurrencyId(SystemCurrencyId, AccountCurrencyId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountCurrency( _
            ByVal SystemCurrencyId As Integer, _
            ByVal AccountId As Integer, _
            ByVal AccountCurrencyExchangeRateId As Integer, _
            ByVal Disabled As Boolean) As Boolean

        Try
            If Not Me.ValidateNewCurrency(SystemCurrencyId, AccountId) Then
                Throw New Exception("Specified Currency already exist")
                Return False
            End If
            _AccountCurrencyTableAdapter = New AccountCurrencyTableAdapters.AccountCurrencyTableAdapter

            Dim AccountCurrency As New AccountCurrency.AccountCurrencyDataTable
            Dim AccountCurrencyRow As AccountCurrency.AccountCurrencyRow = AccountCurrency.NewAccountCurrencyRow

            With AccountCurrencyRow
                .SystemCurrencyId = SystemCurrencyId
                If AccountCurrencyExchangeRateId <> 0 Then
                    .AccountCurrencyExchangeRateId = AccountCurrencyExchangeRateId
                End If
                .AccountId = AccountId
                .Disabled = False
            End With

            AccountCurrency.AddAccountCurrencyRow(AccountCurrencyRow)

            Dim rowsAffected As Integer = Adapter.Update(AccountCurrency)

            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountCurrency( _
            ByVal SystemCurrencyId As Integer, _
            ByVal Original_AccountCurrencyId As Integer, _
            ByVal AccountCurrencyExchangeRateId As Integer, _
            ByVal AccountId As Integer, _
            ByVal Disabled As Boolean) As Boolean

        Dim AccountCurrency As AccountCurrency.AccountCurrencyDataTable = Adapter.GetDataByAccountCurrencyId(Original_AccountCurrencyId)
        Dim AccountCurrencyRow As AccountCurrency.AccountCurrencyRow = AccountCurrency.Rows(0)

        With AccountCurrencyRow

            If .SystemCurrencyId <> SystemCurrencyId Then
                If Not Me.ValidateNewCurrency(SystemCurrencyId, AccountId) Then
                    Throw New Exception("Specified Currency already exist")
                    Return False
                Else
                    .SystemCurrencyId = SystemCurrencyId
                End If
            End If
            .AccountCurrencyExchangeRateId = AccountCurrencyExchangeRateId
            .AccountId = AccountId
            .Disabled = Disabled
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountCurrency)

        Return rowsAffected = 1

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountCurrency(ByVal Original_AccountCurrencyId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountCurrencyId)

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAccountCurrencyExchangeRateId(ByVal AccountCurrencyExchangeRateId As Integer, ByVal AccountCurrencyId As Integer) As Integer
        Return Adapter.UpdateAccountCurrencyExchangeRateId(AccountCurrencyExchangeRateId, AccountCurrencyId)
    End Function

    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountCurrencyLastId.Rows(0)
        Return a.LastId
    End Function

    Public Function AddAccountCurrencyForExchangeRate(ByVal ExchangeRate As Decimal, ByVal ExchangeRateEffectiveStartDate As Date, ByVal ExchangeRateEffectiveEndDate As Date)
        Dim objAccountCurrencyExchangeRate As New AccountCurrencyExchangeRateBLL

        objAccountCurrencyExchangeRate.AddAccountCurrencyExchangeRate(ExchangeRateEffectiveStartDate, ExchangeRateEffectiveEndDate, ExchangeRate, DBUtilities.GetSessionAccountId, Me.GetLastInsertedId)
        Me.UpdateAccountCurrencyExchangeRateId(objAccountCurrencyExchangeRate.GetLastInsertedId, Me.GetLastInsertedId)
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer)
        Adapter.InsertDefault(AccountId)
    End Sub
    Public Sub UpdateDefault(ByVal AccountId As Integer)
        Adapter.UpdateDefault(AccountId)
    End Sub
    Public Sub UpdateExchangeRate()
        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = Me.GetvueAccountCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim dr As AccountCurrency.vueAccountCurrencyRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                Dim dtBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
                Dim drBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow

                If dtBaseCurrency.Rows.Count > 0 Then
                    drBaseCurrency = dtBaseCurrency.Rows(0)
                    If drBaseCurrency.AccountBaseCurrencyId = dr.AccountCurrencyId Then

                    End If

                End If
            Next
        End If

    End Sub
    Public Function GetExchangeRateByAccountCurrencyId(ByVal AccountCurrencyId As Integer) As Double
        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = Me.GetvueAccountCurrencyByAccountCurrencyId(AccountCurrencyId)
        Dim dr As AccountCurrency.vueAccountCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("ExchangeRate")) Then
                Return dr.ExchangeRate
            End If
        End If
        Return 0
    End Function
    Public Function AddCurrencyFromWizard(SystemCurrencyId As Integer, AccountId As Integer) As Integer
        If Not Me.ValidateNewCurrency(SystemCurrencyId, AccountId) Then
            Return 0
        Else
            Me.AddAccountCurrency(SystemCurrencyId, AccountId, 0, False)
            Return Me.GetLastInsertedId()
        End If
    End Function
End Class
