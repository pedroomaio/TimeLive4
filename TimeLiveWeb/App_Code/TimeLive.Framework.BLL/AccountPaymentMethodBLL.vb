Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountPaymentMethodBLL
    Private _AccountPaymentMethodTableAdapter As AccountPaymentMethodTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountPaymentMethodTableAdapter
        Get
            If _AccountPaymentMethodTableAdapter Is Nothing Then
                _AccountPaymentMethodTableAdapter = New AccountPaymentMethodTableAdapter()
            End If
            Return _AccountPaymentMethodTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPaymentByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountPaymentMethodDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPaymentMethod() As TimeLiveDataSet.AccountPaymentMethodDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPaymentMethodByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountPaymentMethodDataTable
        GetAccountPaymentMethodByAccountId = Adapter.GetDataByAccountId(AccountId)
        Uiutilities.FixTableForNoRecords(GetAccountPaymentMethodByAccountId)
        Return GetAccountPaymentMethodByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPaymentMethodByAccountPaymentMethodId(ByVal AccountPaymentMethodId As Integer) As TimeLiveDataSet.AccountPaymentMethodDataTable
        Return Adapter.GetDataByAccountPaymentMethodId(AccountPaymentMethodId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPaymentMethodByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountPaymentMethodId As Integer) As TimeLiveDataSet.AccountPaymentMethodDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountPaymentMethodId)
    End Function
    Public Function ValidateNewPaymentMethod(ByVal PaymentMethod As String, ByVal AccountId As Integer) As Boolean
        If Adapter.GetByPaymentMethodAndAccountId(PaymentMethod, AccountId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function ValidateExistingPaymentMethod(ByVal PaymentMethod As String, ByVal AccountPaymentMethodId As Integer) As Boolean
        If Adapter.GetPaymentMethodExcludingAccountPaymentMethodId(PaymentMethod, AccountPaymentMethodId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountPaymentMethod( _
            ByVal AccountId As Integer, _
            ByVal PaymentMethod As String, _
            ByVal IsDisabled As Boolean) As Boolean

        If Not Me.ValidateNewPaymentMethod(PaymentMethod, AccountId) Then
            Throw New Exception("Specified payment method already exist")
            Return False
        End If
        Try
            _AccountPaymentMethodTableAdapter = New AccountPaymentMethodTableAdapter

            Dim AccountPaymentMethod As New TimeLiveDataSet.AccountPaymentMethodDataTable
            Dim AccountPaymentMethodRow As TimeLiveDataSet.AccountPaymentMethodRow = AccountPaymentMethod.NewAccountPaymentMethodRow

            With AccountPaymentMethodRow
                .PaymentMethod = PaymentMethod
                .IsDisabled = False
                .AccountId = AccountId
            End With

            AccountPaymentMethod.AddAccountPaymentMethodRow(AccountPaymentMethodRow)

            Dim rowsAffected As Integer = Adapter.Update(AccountPaymentMethod)

            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountPaymentMethod( _
            ByVal AccountId As Integer, _
            ByVal PaymentMethod As String, _
            ByVal Original_AccountPaymentMethodId As Integer, _
            ByVal IsDisabled As Boolean) As Boolean

        Dim AccountPaymentMethod As TimeLiveDataSet.AccountPaymentMethodDataTable = Adapter.GetDataByAccountPaymentMethodId(Original_AccountPaymentMethodId)
        Dim AccountPaymentMethodRow As TimeLiveDataSet.AccountPaymentMethodRow = AccountPaymentMethod.Rows(0)

        With AccountPaymentMethodRow
            If .PaymentMethod <> PaymentMethod Then
                If Not Me.ValidateExistingPaymentMethod(PaymentMethod, Original_AccountPaymentMethodId) Then
                    Throw New Exception("Specified payment method already exist")
                    Return False
                Else
                    .PaymentMethod = PaymentMethod
                End If
            End If
            .IsDisabled = IsDisabled
            .AccountId = AccountId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountPaymentMethod)

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function UpdateAccountPaymentMethods( _
        ByVal AccountId As Integer, _
        ByVal PaymentMethod As String, _
        ByVal Original_AccountPaymentMethodId As Integer)

        Dim AccountPaymentMethod As TimeLiveDataSet.AccountPaymentMethodDataTable = Adapter.GetDataByAccountPaymentMethodId(Original_AccountPaymentMethodId)
        Dim AccountPaymentMethodRow As TimeLiveDataSet.AccountPaymentMethodRow = AccountPaymentMethod.Rows(0)

        With AccountPaymentMethodRow
            .PaymentMethod = PaymentMethod
            .AccountId = AccountId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountPaymentMethod)

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountPaymentMethod(ByVal Original_AccountPaymentMethodId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountPaymentMethodId)

        Return rowsAffected = 1

    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        Adapter.InsertDefault(AccountId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangePaymentMethodNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangePaymentMethodNameByUICulture(ByVal AccountId As Integer)
        Dim dtPaymentMethod As TimeLiveDataSet.AccountPaymentMethodDataTable = Me.GetAccountPaymentByAccountId(AccountId)
        Dim drPaymentMethod As TimeLiveDataSet.AccountPaymentMethodRow
        For Each drPaymentMethod In dtPaymentMethod.Rows
            Me.UpdateAccountPaymentMethods(AccountId, ResourceHelper.GetDefaultDataLocalValue(drPaymentMethod.PaymentMethod), drPaymentMethod.AccountPaymentMethodId)
        Next

    End Sub
End Class
