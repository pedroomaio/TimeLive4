Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountPriorityBLL

    Private _AccountPriorityTableAdapter As AccountPriorityTableAdapter = Nothing
    Dim strCacheKey As String


    Protected ReadOnly Property Adapter() As AccountPriorityTableAdapter
        Get
            If _AccountPriorityTableAdapter Is Nothing Then
                _AccountPriorityTableAdapter = New AccountPriorityTableAdapter()
            End If

            Return _AccountPriorityTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPriorities() As TimeLiveDataSet.AccountPriorityDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPrioritiesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountPriorityDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountPriorityDataTable", "GetAccountPrioritiesByAccountId", "AccountId=" & AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountPrioritiesByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountPrioritiesByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountPrioritiesByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountPrioritiesByAccountId)

        Return GetAccountPrioritiesByAccountId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPriorityByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountPriorityDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPrioritiesByAccountIdAndAccountPriorityId(ByVal AccountId As Integer, ByVal AccountPriorityId As Integer) As TimeLiveDataSet.AccountPriorityDataTable
        Return Adapter.GetDataByAccountIdAndAccountPriorityId(AccountId, AccountPriorityId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPrioritiesByAccountPriorityId(ByVal AccountPriorityId As Integer) As TimeLiveDataSet.AccountPriorityDataTable
        Return Adapter.GetDataByAccountPriorityId(AccountPriorityId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountPriority( _
                        ByVal AccountId As Integer, ByVal Priority As String, ByVal PriorityOrder As Byte _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountPriorityTableAdapter = New AccountPriorityTableAdapter

        Dim AccountPriorities As New TimeLiveDataSet.AccountPriorityDataTable
        Dim AccountPriority As TimeLiveDataSet.AccountPriorityRow = AccountPriorities.NewAccountPriorityRow

        With AccountPriority
            .AccountId = AccountId
            .Priority = Priority
            .PriorityOrder = PriorityOrder
            .IsDisabled = False
        End With

        AccountPriorities.AddAccountPriorityRow(AccountPriority)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountPriorities)

        CacheManager.ClearCache("AccountPriorityDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountPriority(ByVal AccountId As Integer, ByVal Priority As String, ByVal PriorityOrder As Byte, ByVal Original_AccountPriorityId As Integer, _
    ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountPriorities As TimeLiveDataSet.AccountPriorityDataTable = Adapter.GetDataByAccountPriorityId(Original_AccountPriorityId)
        Dim AccountPriority As TimeLiveDataSet.AccountPriorityRow = AccountPriorities.Rows(0)

        With AccountPriority
            .Priority = Priority
            .PriorityOrder = PriorityOrder
            .IsDisabled = IsDisabled
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountPriority)

        CacheManager.ClearCache("AccountPriorityDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountPriority(ByVal Original_AccountPriorityId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountPriorityId)

        CacheManager.ClearCache("AccountPriorityDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal UserInterfaceLanguage As String)
        Adapter.InsertDefault(AccountId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangePriorityNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangePriorityNameByUICulture(ByVal AccountId As Integer)
        Dim dtPriority As TimeLiveDataSet.AccountPriorityDataTable = Me.GetPriorityByAccountId(AccountId)
        Dim drPriority As TimeLiveDataSet.AccountPriorityRow
        For Each drPriority In dtPriority.Rows
            Me.UpdateAccountPriority(AccountId, ResourceHelper.GetDefaultDataLocalValue(drPriority.Priority), drPriority.PriorityOrder, drPriority.AccountPriorityId, drPriority.IsDisabled)
        Next

    End Sub
End Class

