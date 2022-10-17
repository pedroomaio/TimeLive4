Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountExpenseBLL

    Private _AccountExpenseTableAdapter As AccountExpenseTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountExpenseTableAdapter
        Get
            If _AccountExpenseTableAdapter Is Nothing Then
                _AccountExpenseTableAdapter = New AccountExpenseTableAdapter()
            End If
            Return _AccountExpenseTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountExpenseDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenses() As TimeLiveDataSet.AccountExpenseDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpensesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountExpenseDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpensesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountExpenseId As Integer) As TimeLiveDataSet.AccountExpenseDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountExpenseId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpensesByAccountExpenseId(ByVal AccountExpenseId As Integer) As TimeLiveDataSet.AccountExpenseDataTable
        Return Adapter.GetDataByAccountExpenseId(AccountExpenseId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpensesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountExpenseDataTable
        Dim _vueAccountExpenseTableAdapter As New vueAccountExpenseTableAdapter
        GetvueAccountExpensesByAccountId = _vueAccountExpenseTableAdapter.GetDataByAccountId(AccountId)
        Uiutilities.FixTableForNoRecords(GetvueAccountExpensesByAccountId)
        Return GetvueAccountExpensesByAccountId
        'Return Nothing
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpensesWithTaxCodeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable
        Dim _vueAccountExpenseWithTaxCodeTableAdapter As New vueAccountExpenseWithTaxCodeTableAdapter
        GetvueAccountExpensesWithTaxCodeByAccountId = _vueAccountExpenseWithTaxCodeTableAdapter.GetDataByAccountId(AccountId)
        Return GetvueAccountExpensesWithTaxCodeByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId(ByVal AccountId As Integer, ByVal AccountExpenseId As Integer) As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable
        Dim _vueAccountExpenseWithTaxCodeTableAdapter As New vueAccountExpenseWithTaxCodeTableAdapter
        GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId = _vueAccountExpenseWithTaxCodeTableAdapter.GetDataByAccountIdAndAccountExpenseId(AccountId, AccountExpenseId)
        Return GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountTaxZoneId(ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable
        Dim _vueAccountExpenseWithTaxCodeTableAdapter As New vueAccountExpenseWithTaxCodeTableAdapter
        GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountTaxZoneId = _vueAccountExpenseWithTaxCodeTableAdapter.GetDataByAccountIdAndAccountTaxZoneId(AccountId, AccountTaxZoneId)
        Return GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountTaxZoneId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseIdAndAccountTaxZoneId(ByVal AccountId As Integer, ByVal AccountExpenseId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable
        Dim _vueAccountExpenseWithTaxCodeTableAdapter As New vueAccountExpenseWithTaxCodeTableAdapter
        GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseIdAndAccountTaxZoneId = _vueAccountExpenseWithTaxCodeTableAdapter.GetDataByAccountIdAndAccountExpenseIdAndAccountTaxZoneId(AccountId, AccountExpenseId, AccountTaxZoneId)
        Return GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseIdAndAccountTaxZoneId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function AddAccountExpense(
                        ByVal AccountId As Integer, ByVal AccountExpenseName As String, ByVal AccountExpenseTypeId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal IsBillable As Boolean,
                        ByVal DefaultExpenseRate As Double, ByVal DisabledEditingOfRate As Boolean, ByVal Reimburse As Boolean, ByVal Optional ReimburseIsReadOnly As Boolean = True, ByVal Optional BillableIsReadOnly As Boolean = True
                    ) As Boolean
        ' Create a new ProductRow instance
        Try



            _AccountExpenseTableAdapter = New AccountExpenseTableAdapter

            Dim AccountExpenses As New TimeLiveDataSet.AccountExpenseDataTable
            Dim AccountExpense As TimeLiveDataSet.AccountExpenseRow = AccountExpenses.NewAccountExpenseRow

            With AccountExpense
                .AccountId = AccountId
                .AccountExpenseName = AccountExpenseName
                .AccountExpenseTypeId = AccountExpenseTypeId
                .CreatedOn = Now
                .CreatedByEmployeeId = CreatedByEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
                .IsBillable = IsBillable
                .IsDisabled = False
                .DefaultExpenseRate = DefaultExpenseRate
                .DisabledEditingOfRate = DisabledEditingOfRate
                .Reimburse = Reimburse
                .BillableIsReadOnly = BillableIsReadOnly
                .ReimburseIsReadOnly = ReimburseIsReadOnly
            End With

            AccountExpenses.AddAccountExpenseRow(AccountExpense)


            ' Add the new product
            Dim rowsAffected As Integer = Adapter.Update(AccountExpenses)

            'CacheManager.ClearCache("AccountExpenseTypeDataTable", , True)


            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateAccountExpense(ByVal AccountId As Integer, ByVal AccountExpenseName As String, ByVal AccountExpenseTypeId As Integer,
    ByVal Original_AccountExpenseId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal IsBillable As Boolean,
    ByVal IsDisabled As Boolean, ByVal DefaultExpenseRate As Double, ByVal DisabledEditingOfRate As Boolean, ByVal Reimburse As Boolean, ByVal Optional ReimburseIsReadOnly As Boolean = True, ByVal Optional BillableIsReadOnly As Boolean = True) As Boolean

        Dim AccountExpenses As TimeLiveDataSet.AccountExpenseDataTable = Adapter.GetDataByAccountExpenseId(Original_AccountExpenseId)
        Dim AccountExpense As TimeLiveDataSet.AccountExpenseRow = AccountExpenses.Rows(0)

        With AccountExpense
            .AccountExpenseName = AccountExpenseName
            .AccountExpenseTypeId = AccountExpenseTypeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsBillable = IsBillable
            .IsDisabled = IsDisabled
            .DefaultExpenseRate = DefaultExpenseRate
            .DisabledEditingOfRate = DisabledEditingOfRate
            .Reimburse = Reimburse
            .BillableIsReadOnly = BillableIsReadOnly
            .ReimburseIsReadOnly = ReimburseIsReadOnly
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountExpense)

        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountExpense(ByVal Original_AccountExpenseId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountExpenseId)

        'CacheManager.ClearCache("AccountExpenseTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal UserInterfaceLanguage As String)
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeExpenseNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangeExpenseNameByUICulture(ByVal AccountId As Integer)
        Dim dtExpenseName As TimeLiveDataSet.AccountExpenseDataTable = Me.GetAccountExpenseByAccountId(AccountId)
        Dim drExpenseName As TimeLiveDataSet.AccountExpenseRow
        For Each drExpenseName In dtExpenseName.Rows
            Me.UpdateRecorcesValue(ResourceHelper.GetDefaultDataLocalValue(drExpenseName.AccountExpenseName), drExpenseName.AccountExpenseId)
        Next

    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateRecorcesValue(ByVal AccountExpenseName As String, ByVal Original_AccountExpenseId As Integer) As Boolean

        Dim AccountExpenses As TimeLiveDataSet.AccountExpenseDataTable = Adapter.GetDataByAccountExpenseId(Original_AccountExpenseId)
        Dim AccountExpense As TimeLiveDataSet.AccountExpenseRow = AccountExpenses.Rows(0)

        With AccountExpense
            .AccountExpenseName = AccountExpenseName
            .ModifiedOn = Now
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountExpense)

        Return rowsAffected = 1
    End Function
End Class
