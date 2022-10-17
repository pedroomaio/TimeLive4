Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountTaxCodeBLL
    Private _AccountTaxCodeTableAdapter As AccountTaxCodeTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountTaxCodeTableAdapter
        Get
            If _AccountTaxCodeTableAdapter Is Nothing Then
                _AccountTaxCodeTableAdapter = New AccountTaxCodeTableAdapter()
            End If
            Return _AccountTaxCodeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountTaxCodeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodes() As TimeLiveDataSet.AccountTaxCodeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountTaxCodeDataTable
        GetAccountTaxCodesByAccountId = Adapter.GetDataByAccountId(AccountId)
        Uiutilities.FixTableForNoRecords(GetAccountTaxCodesByAccountId)
        Return GetAccountTaxCodesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodesByAccountIdAndAccountTaxZoneId(ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.AccountTaxCodeDataTable
        GetAccountTaxCodesByAccountIdAndAccountTaxZoneId = Adapter.GetDataByAccountIdAndAccountTaxZoneId(AccountId, AccountTaxZoneId)
        Uiutilities.FixTableForNoRecords(GetAccountTaxCodesByAccountIdAndAccountTaxZoneId)
        Return GetAccountTaxCodesByAccountIdAndAccountTaxZoneId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodesByAccountIdAndAccountTaxZoneIdForDropDown(ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.AccountTaxCodeDataTable
        GetAccountTaxCodesByAccountIdAndAccountTaxZoneIdForDropDown = Adapter.GetDataByAccountIdAndAccountTaxZoneId(AccountId, AccountTaxZoneId)
        Return GetAccountTaxCodesByAccountIdAndAccountTaxZoneIdForDropDown
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodesByAccountTaxCodeId(ByVal AccountTaxCodeId As Integer) As TimeLiveDataSet.AccountTaxCodeDataTable
        Return Adapter.GetDataByAccountTaxCodeId(AccountTaxCodeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxCodesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountTaxCodeId As Integer) As TimeLiveDataSet.AccountTaxCodeDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountTaxCodeId)
    End Function
    Public Function ValidateNewTaxCode(ByVal TaxCode As String, ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As Boolean
        If Adapter.GetByTaxCodeAccountIdAndAccountTaxZoneId(TaxCode, AccountId, AccountTaxZoneId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function ValidateExistingTaxCode(ByVal TaxCode As String, ByVal AccountTaxCodeId As Integer) As Boolean
        If Adapter.GetTaxCodeExcludingAccountTaxCodeIdAndAccountTaxZoneId(TaxCode, AccountTaxCodeId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTaxCode( _
            ByVal AccountId As Integer, _
            ByVal TaxCode As String, _
            ByVal Formula As String, _
            ByVal AccountTaxZoneId As Integer _
            ) As Boolean

        If Not Me.ValidateNewTaxCode(TaxCode, AccountId, AccountTaxZoneId) Then
            Throw New Exception("Specified tax code already exist")
            Return False
        End If

        Try
            _AccountTaxCodeTableAdapter = New AccountTaxCodeTableAdapter

            Dim AccountTaxCode As New TimeLiveDataSet.AccountTaxCodeDataTable
            Dim AccountTaxCodeRow As TimeLiveDataSet.AccountTaxCodeRow = AccountTaxCode.NewAccountTaxCodeRow

            With AccountTaxCodeRow
                .TaxCode = TaxCode
                .Formula = Formula
                .IsDisabled = False
                .AccountId = AccountId
                .AccountTaxZoneId = AccountTaxZoneId
            End With

            AccountTaxCode.AddAccountTaxCodeRow(AccountTaxCodeRow)

            Dim rowsAffected As Integer = Adapter.Update(AccountTaxCode)

            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTaxCode( _
            ByVal AccountId As Integer, _
            ByVal TaxCode As String, _
            ByVal Formula As String, _
            ByVal Original_AccountTaxCodeId As Integer, _
            ByVal IsDisabled As Boolean) As Boolean

        Dim AccountTaxCode As TimeLiveDataSet.AccountTaxCodeDataTable = Adapter.GetDataByAccountTaxCodeId(Original_AccountTaxCodeId)
        Dim AccountTaxCodeRow As TimeLiveDataSet.AccountTaxCodeRow = AccountTaxCode.Rows(0)

        With AccountTaxCodeRow
            If .TaxCode <> TaxCode Then
                If Not Me.ValidateExistingTaxCode(TaxCode, Original_AccountTaxCodeId) Then
                    Throw New Exception("Specified tax code already exist")
                    Return False
                Else
                    .TaxCode = TaxCode
                End If
            End If
            .Formula = Formula
            .IsDisabled = IsDisabled
            .AccountId = AccountId
            '.AccountTaxZoneId = AccountTaxZoneId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountTaxCode)

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTaxCodes( _
            ByVal AccountId As Integer, _
            ByVal TaxCode As String, _
            ByVal Original_AccountTaxCodeId As Integer)


        Dim AccountTaxCode As TimeLiveDataSet.AccountTaxCodeDataTable = Adapter.GetDataByAccountTaxCodeId(Original_AccountTaxCodeId)
        Dim AccountTaxCodeRow As TimeLiveDataSet.AccountTaxCodeRow = AccountTaxCode.Rows(0)

        With AccountTaxCodeRow
            .TaxCode = TaxCode
            .AccountId = AccountId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountTaxCode)

        Return rowsAffected = 1

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTaxCode(ByVal Original_AccountTaxCodeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTaxCodeId)

        Return rowsAffected = 1

    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        Adapter.InsertDefault(AccountId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeTaxCodeNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangeTaxCodeNameByUICulture(ByVal AccountId As Integer)
        Dim dtTaxCode As TimeLiveDataSet.AccountTaxCodeDataTable = Me.GetAccountTaxCodeByAccountId(AccountId)
        Dim drTaxCode As TimeLiveDataSet.AccountTaxCodeRow
        If dtTaxCode.Rows.Count > 0 Then
            drTaxCode = dtTaxCode.Rows(0)
            For Each drTaxCode In dtTaxCode.Rows
                Me.UpdateAccountTaxCodes(AccountId, ResourceHelper.GetDefaultDataLocalValue(drTaxCode.TaxCode), drTaxCode.AccountTaxCodeId)
            Next
        End If
    End Sub
    Public Sub UpdateAccountTaxZoneId(ByVal AccountId As Integer)
        Adapter.UpdateAccountTaxZoneId(AccountId)
    End Sub
End Class
