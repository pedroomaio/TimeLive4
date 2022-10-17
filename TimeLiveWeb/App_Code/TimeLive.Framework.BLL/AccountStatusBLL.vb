Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountStatusBLL
    Private _AccountStatusTableAdapter As AccountStatusTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountStatusTableAdapter
        Get
            If _AccountStatusTableAdapter Is Nothing Then
                _AccountStatusTableAdapter = New AccountStatusTableAdapter()
            End If

            Return _AccountStatusTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatus() As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusByAccountIdAndStatus(ByVal AccountId As Integer, ByVal Status As String) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByAccountIdAndStatus(AccountId, Status)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusByAccountStatusId(ByVal AccountStatusId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByAccountStatusId(AccountStatusId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusByStatusTypeId(ByVal AccountId As Integer, ByVal StatusTypeId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusTypeId(AccountId, StatusTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForProject(ByVal AccountId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusTypeId(AccountId, 3)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForProjectByIsDisabled(ByVal AccountId As Integer, ByVal AccountStatusId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusIdAndIsDisabled(AccountId, 3, AccountStatusId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForEmployeeByIsDisabled(ByVal AccountId As Integer, ByVal AccountStatusId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusIdAndIsDisabled(AccountId, 2, AccountStatusId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusByMasterStatusId(ByVal AccountId As Integer, ByVal MasterStatusId As Integer, ByVal AccountStatusId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByMasterAccountStatusId(AccountId, MasterStatusId, AccountStatusId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForEmployee(ByVal AccountId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusTypeId(AccountId, 2)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForAccount(ByVal AccountId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusTypeId(AccountId, 1)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForTask(ByVal AccountId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusTypeId(AccountId, 4)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountsStatusForTaskByAccountStatusId(ByVal AccountId As Integer, ByVal AccountStatusId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetDataByStatusTypeIdAndAccountStatusId(AccountId, 4, AccountStatusId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountStatusForEmployeesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountStatusDataTable
        Return Adapter.GetEmployeesDataByAccountId(AccountId)
    End Function
    Public Function GetAccountStatusIdByMasterAccountStatusIdStarted(ByVal AccountId As Integer) As Integer
        Dim dt As TimeLiveDataSet.AccountStatusDataTable = Me.Adapter.GetDataByMasterAccountStatusTypeId(AccountId, 4, 2)
        Dim dr As TimeLiveDataSet.AccountStatusRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountStatusId
        End If
    End Function
 
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountStatusForSelection(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountStatusDataTable

        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountStatusDataTable", "GetAccountStatusForSelection", AccountId)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountStatusForSelection = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAccountStatusTableAdapter As New vueAccountStatusTableAdapter
        GetAccountStatusForSelection = _vueAccountStatusTableAdapter.GetDataByAccountId(AccountId)
        'CacheManager.AddAccountDataInCache(GetAccountStatusForSelection, strCacheKey)
        'End If

        UIUtilities.FixTableForNoRecords(GetAccountStatusForSelection)

        Return GetAccountStatusForSelection


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountStatusForSelectionByAccountId(ByVal AccountId As Integer) As AccountStatus.vueAccountStatusDataTable

        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountStatusDataTable", "GetAccountStatusForSelection", AccountId)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountStatusForSelection = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAccountStatusTableAdapter As New AccountStatusTableAdapters.vueAccountStatusTableAdapter
        GetAccountStatusForSelectionByAccountId = _vueAccountStatusTableAdapter.GetDataByAccountId(AccountId)
        'CacheManager.AddAccountDataInCache(GetAccountStatusForSelection, strCacheKey)
        'End If

        Uiutilities.FixTableForNoRecords(GetAccountStatusForSelectionByAccountId)

        Return GetAccountStatusForSelectionByAccountId


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountStatus( _
                        ByVal AccountId As Integer, ByVal Status As String, ByVal StatusTypeId As Integer _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountStatusTableAdapter = New AccountStatusTableAdapter

        Dim AccountsStatus As New TimeLiveDataSet.AccountStatusDataTable
        Dim AccountStatus As TimeLiveDataSet.AccountStatusRow = AccountsStatus.NewAccountStatusRow

        With AccountStatus
            .AccountId = AccountId
            .Status = Status
            .StatusTypeId = StatusTypeId
            .IsDisabled = False
        End With

        AccountsStatus.AddAccountStatusRow(AccountStatus)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountsStatus)

        CacheManager.ClearCache("AccountStatusDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountStatus(ByVal AccountId As Integer, ByVal Status As String, ByVal StatusTypeId As Integer, ByVal Original_AccountStatusId As Integer, ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountsStatus As TimeLiveDataSet.AccountStatusDataTable = Adapter.GetDataByAccountStatusId(Original_AccountStatusId)
        Dim AccountStatus As TimeLiveDataSet.AccountStatusRow = AccountsStatus.Rows(0)


        With AccountStatus
            .AccountId = AccountId
            .Status = Status
            .StatusTypeId = StatusTypeId
            .IsDisabled = IsDisabled
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountStatus)


        CacheManager.ClearCache("AccountStatusDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountStatus(ByVal Original_AccountStatusId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountStatusId)

        CacheManager.ClearCache("AccountStatusDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Function InsertDefault(ByVal AccountId As Integer, ByVal UserInterfaceLanguage As String)
        Adapter.InsertDefault(AccountId)
        Dim AccountStatusId As Integer = GetDefaultAccountStatusId(AccountId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeStatusNameByUICulture(AccountId)
        End If
        Return AccountStatusId
    End Function
    Public Sub ChangeStatusNameByUICulture(ByVal AccountId As Integer)
        Dim dtStatus As TimeLiveDataSet.AccountStatusDataTable = Me.GetAccountsStatusByAccountId(AccountId)
        Dim drStatus As TimeLiveDataSet.AccountStatusRow
        For Each drStatus In dtStatus.Rows
            Me.UpdateAccountStatus(AccountId, ResourceHelper.GetDefaultDataLocalValue(drStatus.Status), drStatus.StatusTypeId, drStatus.AccountStatusId, drStatus.IsDisabled)
        Next

    End Sub
    Public Sub InsertStatusForEmployee(ByVal AccountId As Integer)
        Adapter.InsertStatusForEmployee(AccountId)
    End Sub
    Public Function GetDefaultAccountStatusId(ByVal AccountId As Integer) As Integer
        Dim dtStatus As TimeLiveDataSet.AccountStatusDataTable = Me.GetAccountsStatusByMasterStatusId(AccountId, 20, 0)
        Dim drStatus As TimeLiveDataSet.AccountStatusRow
        If dtStatus.Rows.Count > 0 Then
            drStatus = dtStatus.Rows(0)
            Return drStatus.AccountStatusId
        End If
    End Function
    Public Sub ResetStatus()
        CacheManager.ClearCache("vueAccountProjectTaskDataTable", , True)
    End Sub
    Public Sub UpdateAccountStatus(ByVal AccountId As Integer)
        Adapter.UpdateAccountStatus(AccountId)
    End Sub
End Class
