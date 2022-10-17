Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountExpenseTypeBLL

    Private _AccountExpenseTypeTableAdapter As AccountExpenseTypeTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountExpenseTypeTableAdapter
        Get
            If _AccountExpenseTypeTableAdapter Is Nothing Then
                _AccountExpenseTypeTableAdapter = New AccountExpenseTypeTableAdapter()
            End If
            Return _AccountExpenseTypeTableAdapter
        End Get
    End Property

    Private _AccountExpenseTypeTaxCodeTableAdapter As AccountExpenseTypeTaxCodeTableAdapter = Nothing

    Protected ReadOnly Property AccountExpenseTypeTaxCodeTableAdapter() As AccountExpenseTypeTaxCodeTableAdapter
        Get
            If _AccountExpenseTypeTaxCodeTableAdapter Is Nothing Then
                _AccountExpenseTypeTaxCodeTableAdapter = New AccountExpenseTypeTaxCodeTableAdapter()
            End If
            Return _AccountExpenseTypeTaxCodeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseTypeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountExpenseTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseTypes() As TimeLiveDataSet.AccountExpenseTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountExpenseTypeDataTable
        GetAccountExpenseTypesByAccountId = Adapter.GetDataByAccountId(AccountId)
        Uiutilities.FixTableForNoRecords(GetAccountExpenseTypesByAccountId)
        Return GetAccountExpenseTypesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseTypesByAccountIdandIsDisabled(ByVal AccountId As Integer, ByVal AccountExpenseTypeId As Integer) As TimeLiveDataSet.AccountExpenseTypeDataTable
        GetAccountExpenseTypesByAccountIdandIsDisabled = Adapter.GetDataByAccountIdandIsDisabled(AccountId, AccountExpenseTypeId)
        ''UIUtilities.FixTableForNoRecords(GetAccountExpenseTypesByAccountIdandIsDisabled)
        Return GetAccountExpenseTypesByAccountIdandIsDisabled
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountExpenseTypeDataTable
        Dim _vueAccountExpenseTypeTableAdapter As New vueAccountExpenseTypeTableAdapter
        GetvueAccountExpenseTypesByAccountId = _vueAccountExpenseTypeTableAdapter.GetDataByAccountId(AccountId)
        Uiutilities.FixTableForNoRecords(GetvueAccountExpenseTypesByAccountId)
        Return GetvueAccountExpenseTypesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpenseTypesByAccountIdAndAccountTaxZoneId(ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.vueAccountExpenseTypeDataTable
        Dim _vueAccountExpenseTypeTableAdapter As New vueAccountExpenseTypeTableAdapter
        GetvueAccountExpenseTypesByAccountIdAndAccountTaxZoneId = _vueAccountExpenseTypeTableAdapter.GetDataByAccountIdAndAccountTaxZoneId(AccountId, AccountTaxZoneId)
        Uiutilities.FixTableForNoRecords(GetvueAccountExpenseTypesByAccountIdAndAccountTaxZoneId)
        Return GetvueAccountExpenseTypesByAccountIdAndAccountTaxZoneId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpenseTypesByAccountExpenseTypeId(ByVal AccountExpenseTypeId As Integer) As TimeLiveDataSet.vueAccountExpenseTypeDataTable
        Dim _vueAccountExpenseTypeTableAdapter As New vueAccountExpenseTypeTableAdapter
        GetvueAccountExpenseTypesByAccountExpenseTypeId = _vueAccountExpenseTypeTableAdapter.GetDataByAccountExpenseTypeId(AccountExpenseTypeId)
        Return GetvueAccountExpenseTypesByAccountExpenseTypeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpenseTypesByAccountExpenseTypeIdAndAccountTaxZoneId(ByVal AccountExpenseTypeId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.vueAccountExpenseTypeDataTable
        Dim _vueAccountExpenseTypeTableAdapter As New vueAccountExpenseTypeTableAdapter
        GetvueAccountExpenseTypesByAccountExpenseTypeIdAndAccountTaxZoneId = _vueAccountExpenseTypeTableAdapter.GetDataByAccountExpenseTypeIdAndAccountTaxZoneId(AccountExpenseTypeId, AccountTaxZoneId)
        Return GetvueAccountExpenseTypesByAccountExpenseTypeIdAndAccountTaxZoneId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseTypesByAccountExpenseTypeId(ByVal AccountExpenseTypeId As Integer) As TimeLiveDataSet.AccountExpenseTypeDataTable
        Return Adapter.GetDataByAccountExpenseTypeId(AccountExpenseTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseTypesByAccountIdAndAccountExpenseTypeId(ByVal AccountId As Integer, ByVal AccountExpenseTypeId As Integer) As TimeLiveDataSet.AccountExpenseTypeDataTable
        Return Adapter.GetDataByAccountIdAndAccountExpenseTypeId(AccountId, AccountExpenseTypeId)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetAccountExpenseTypesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountExpenseTypeId As Integer) As TimeLiveDataSet.AccountExpenseTypeDataTable
    '    Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountExpenseTypeId)
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountExpenseType( _
                        ByVal AccountId As Integer, ByVal ExpenseType As String, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal AccountTaxCodeId As System.Nullable(Of Integer), _
                    ByVal QuantityFieldCaption As String, ByVal IsQuantityField As Boolean, ByVal AccountTaxZoneId As Integer) As Boolean
        ' Create a new ProductRow instance
        Try

            If QuantityFieldCaption <> "" Then
                QuantityFieldCaption = QuantityFieldCaption
            Else
                QuantityFieldCaption = ""
            End If

            Dim NewAccountExpenseTypeId As Integer
            NewAccountExpenseTypeId = Adapter.InsertAccountExpenseType(ExpenseType, AccountId, Now, Now, CreatedByEmployeeId, ModifiedByEmployeeId, False, QuantityFieldCaption, IsQuantityField)
            If Not AccountTaxCodeId.Value = 0 Then
                Me.AddAccountExpenseTypeTaxCode(NewAccountExpenseTypeId, AccountTaxZoneId, AccountTaxCodeId, AccountId, CreatedByEmployeeId, ModifiedByEmployeeId)
            End If

            '_AccountExpenseTypeTableAdapter = New AccountExpenseTypeTableAdapter

            'Dim AccountExpenseTypes As New TimeLiveDataSet.AccountExpenseTypeDataTable
            'Dim AccountExpenseType As TimeLiveDataSet.AccountExpenseTypeRow = AccountExpenseTypes.NewAccountExpenseTypeRow

            'With AccountExpenseType
            '    .AccountId = AccountId
            '    .ExpenseType = ExpenseType
            '    .CreatedOn = Now
            '    .CreatedByEmployeeId = CreatedByEmployeeId
            '    .ModifiedOn = Now
            '    .ModifiedByEmployeeId = ModifiedByEmployeeId
            '    .IsDisabled = False

            '    .IsQuantityField = IsQuantityField
            '    If QuantityFieldCaption <> "" Then
            '        .QuantityFieldCaption = QuantityFieldCaption
            '    Else
            '        .QuantityFieldCaption = ""
            '    End If

            'End With

            'AccountExpenseTypes.AddAccountExpenseTypeRow(AccountExpenseType)


            '' Add the new product
            'Dim rowsAffected As Integer = Adapter.Update(AccountExpenseTypes)
            'rowsAffected = 1
            'CacheManager.ClearCache("AccountExpenseTypeDataTable", , True)
            '_AccountExpenseTypeTaxCodeTableAdapter = New AccountExpenseTypeTaxCodeTableAdapter

            'Dim AccountExpenseTypeTaxCode As New TimeLiveDataSet.AccountExpenseTypeTaxCodeDataTable
            'Dim AccountExpenseTypeTaxCodeRow As TimeLiveDataSet.AccountExpenseTypeTaxCodeRow = AccountExpenseTypeTaxCode.NewAccountExpenseTypeTaxCodeRow

            'With AccountExpenseTypeTaxCodeRow
            '    .AccountExpenseTypeId = NewAccountExpenseTypeId
            '    .AccountTaxZoneId = AccountTaxZoneId
            '    'If Not AccountTaxCodeId.Value = 0 Then
            '    .AccountTaxCodeId = AccountTaxCodeId
            '    'End If
            '    .AccountId = AccountId
            '    .CreatedOn = Now
            '    .CreatedByEmployeeId = CreatedByEmployeeId
            '    .ModifiedOn = Now
            '    .ModifiedByEmployeeId = ModifiedByEmployeeId
            'End With
            'AccountExpenseTypeTaxCode.AddAccountExpenseTypeTaxCodeRow(AccountExpenseTypeTaxCodeRow)
            'Dim rowsAffected1 As Integer = AccountExpenseTypeTaxCodeTableAdapter.Update(AccountExpenseTypeTaxCode)
            '' Return true if precisely one row was inserted, otherwise false
            'Return rowsAffected1 = 1

        Catch ex As Exception

        End Try

    End Function
    Public Function AddAccountExpenseTypeTaxCode(ByVal NewAccountExpenseTypeId As Integer, ByVal AccountTaxZoneId As Integer, ByVal AccountTaxCodeId As Integer, ByVal AccountId As Integer, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer) As Boolean

        _AccountExpenseTypeTaxCodeTableAdapter = New AccountExpenseTypeTaxCodeTableAdapter

        Dim AccountExpenseTypeTaxCode As New TimeLiveDataSet.AccountExpenseTypeTaxCodeDataTable
        Dim AccountExpenseTypeTaxCodeRow As TimeLiveDataSet.AccountExpenseTypeTaxCodeRow = AccountExpenseTypeTaxCode.NewAccountExpenseTypeTaxCodeRow

        With AccountExpenseTypeTaxCodeRow
            .AccountExpenseTypeId = NewAccountExpenseTypeId
            .AccountTaxZoneId = AccountTaxZoneId
            'If Not AccountTaxCodeId.Value = 0 Then
            .AccountTaxCodeId = AccountTaxCodeId
            'End If
            .AccountId = AccountId
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With
        AccountExpenseTypeTaxCode.AddAccountExpenseTypeTaxCodeRow(AccountExpenseTypeTaxCodeRow)
        Dim rowsAffected1 As Integer = AccountExpenseTypeTaxCodeTableAdapter.Update(AccountExpenseTypeTaxCode)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected1 = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountExpenseType(ByVal AccountId As Integer, ByVal ExpenseType As String, ByVal Original_AccountExpenseTypeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean, ByVal AccountTaxCodeId As System.Nullable(Of Integer), ByVal IsQuantityField As Boolean, ByVal QuantityFieldCaption As String, ByVal AccountTaxZoneId As Integer) As Boolean

        ' Update the product record

        Dim AccountExpenseTypes As TimeLiveDataSet.AccountExpenseTypeDataTable = Adapter.GetDataByAccountExpenseTypeId(Original_AccountExpenseTypeId)
        Dim AccountExpenseType As TimeLiveDataSet.AccountExpenseTypeRow = AccountExpenseTypes.Rows(0)

        With AccountExpenseType
            .ExpenseType = ExpenseType
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
            .IsQuantityField = IsQuantityField
            If QuantityFieldCaption <> "" Then
                .QuantityFieldCaption = QuantityFieldCaption
            Else
                .QuantityFieldCaption = ""
            End If
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseType)
        rowsAffected = 1

        Dim AccountExpenseTypeTaxCodeId As Integer

        Dim dtAccountExpenseTypeTaxCode As TimeLiveDataSet.AccountExpenseTypeTaxCodeDataTable = AccountExpenseTypeTaxCodeTableAdapter.GetDataByAccountExpenseTypeIdAndAccountTaxZoneId(Original_AccountExpenseTypeId, AccountTaxZoneId)
        Dim drAccountExpenseTypeTaxCodeRow As TimeLiveDataSet.AccountExpenseTypeTaxCodeRow
        If dtAccountExpenseTypeTaxCode.Rows.Count > 0 Then
            drAccountExpenseTypeTaxCodeRow = dtAccountExpenseTypeTaxCode.Rows(0)
            With drAccountExpenseTypeTaxCodeRow
                If Not AccountTaxZoneId = .AccountTaxZoneId Then
                    Return Me.AddAccountExpenseTypeTaxCode(Original_AccountExpenseTypeId, AccountTaxZoneId, _
                    AccountTaxCodeId, AccountId, ModifiedByEmployeeId, ModifiedByEmployeeId)
                End If
                AccountExpenseTypeTaxCodeId = .AccountExpenseTypeTaxCodeId
                If Not AccountTaxCodeId.Value <> 0 Then
                    Return Me.DeleteAccountExpenseTypeTaxCode(AccountExpenseTypeTaxCodeId)
                End If
                .AccountExpenseTypeId = Original_AccountExpenseTypeId
                .AccountTaxZoneId = AccountTaxZoneId
                .AccountTaxCodeId = AccountTaxCodeId
                .AccountId = AccountId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
            End With
            Dim rowsAffected1 As Integer = AccountExpenseTypeTaxCodeTableAdapter.Update(drAccountExpenseTypeTaxCodeRow)
            Return rowsAffected1 = 1
        Else
            If Not AccountTaxCodeId.Value = 0 Then
                Me.AddAccountExpenseTypeTaxCode(Original_AccountExpenseTypeId, AccountTaxZoneId, AccountTaxCodeId, AccountId, ModifiedByEmployeeId, ModifiedByEmployeeId)
            End If
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function UpdateAccountExpenseTypes(ByVal AccountId As Integer, ByVal ExpenseType As String, ByVal Original_AccountExpenseTypeId As Integer)

        ' Update the product record

        Dim AccountExpenseTypes As TimeLiveDataSet.AccountExpenseTypeDataTable = Adapter.GetDataByAccountExpenseTypeId(Original_AccountExpenseTypeId)
        Dim AccountExpenseType As TimeLiveDataSet.AccountExpenseTypeRow = AccountExpenseTypes.Rows(0)

        With AccountExpenseType
            .ExpenseType = ExpenseType
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseType)
        Return rowsAffected = 1


    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountExpenseType(ByVal Original_AccountExpenseTypeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountExpenseTypeId)

        'CacheManager.ClearCache("AccountExpenseTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Function DeleteAccountExpenseTypeTaxCode(ByVal Original_AccountExpenseTypeTaxCodeId As Integer) As Boolean
        Dim rowsAffected As Integer = AccountExpenseTypeTaxCodeTableAdapter.Delete(Original_AccountExpenseTypeTaxCodeId)

        'CacheManager.ClearCache("AccountExpenseTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal UserInterfaceLanguage As String)
        If IsExistsMasterRecord(AccountId) = False Then
            Adapter.InsertDefault(AccountId)
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeExpenseTypeNameByUICulture(AccountId)
            End If
        End If
    End Sub
    Public Sub ChangeExpenseTypeNameByUICulture(ByVal AccountId As Integer)
        Dim dtExpenseTypes As TimeLiveDataSet.AccountExpenseTypeDataTable = Me.GetAccountExpenseTypesByAccountId(AccountId)
        Dim drExpenseType As TimeLiveDataSet.AccountExpenseTypeRow
        For Each drExpenseType In dtExpenseTypes.Rows
            Me.UpdateAccountExpenseTypes(AccountId, ResourceHelper.GetDefaultDataLocalValue(drExpenseType.ExpenseType), drExpenseType.AccountExpenseTypeId)
        Next

    End Sub
    Public Sub UpdateDefault(ByVal AccountId As Integer)
        'Adapter.UpdateDefault(AccountId)
    End Sub
    'Public Sub UpdateAccountTaxCodeId(ByVal AccountId As Integer)
    '    'Adapter.UpdateAccountTaxCodeId(AccountId)
    'End Sub
    Public Function UpdateDefaultAccountTaxCodeId(ByVal Original_AccountId As Integer, ByVal AccountTaxCodeId As Integer) As Boolean

        'Dim drExpenseType As TimeLiveDataSet.AccountExpenseTypeRow
        'Dim dtExpenseType As TimeLiveDataSet.AccountExpenseTypeDataTable
        'dtExpenseType = New AccountExpenseTypeBLL().GetAccountExpenseTypesByAccountId(Original_AccountId)

        'drExpenseType = dtExpenseType.Rows(0)

        'With drExpenseType
        '    .AccountTaxCodeId = AccountTaxCodeId
        'End With

        'Dim rowsAffected As Integer = Me.Adapter.Update(dtExpenseType)

        '' Return true if precisely one row was updated, otherwise false
        'Return rowsAffected = 1

    End Function
    Public Sub InsertAccountExpenseTypeTaxCode(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        AccountExpenseTypeTaxCodeTableAdapter.InsertDefault(AccountId, AccountEmployeeId, Now)
    End Sub

    Public Sub InsertAccountExpenseTypeTaxCodeForOldVersion(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        AccountExpenseTypeTaxCodeTableAdapter.InsertDefaultForOldVersion(AccountId, AccountEmployeeId, Now)
    End Sub
    Public Function IsExistsMasterRecord(ByVal AccountId As Integer) As Boolean
        If AccountExpenseTypeTaxCodeTableAdapter.GetDataByAccountId(AccountId).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
