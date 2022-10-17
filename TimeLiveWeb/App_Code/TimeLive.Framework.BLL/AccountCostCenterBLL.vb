Imports Microsoft.VisualBasic
Imports AccountCostCenterTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountCostCenterBLL

    Private _AccountCostCenterTableAdapter As AccountCostCenterTableAdapter = Nothing
    Private _AccountCostCenterEmployeeTableAdapter As AccountCostCenterEmployeeTableAdapter = Nothing
    Private _vueAccountCostCenterEmployeeTableAdapter As vueAccountCostCenterEmployeeTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountCostCenterTableAdapter
        Get
            If _AccountCostCenterTableAdapter Is Nothing Then
                _AccountCostCenterTableAdapter = New AccountCostCenterTableAdapter
            End If

            Return _AccountCostCenterTableAdapter
        End Get
    End Property
    Protected ReadOnly Property CostCenterEmployeeAdapter() As AccountCostCenterEmployeeTableAdapter
        Get
            If _AccountCostCenterEmployeeTableAdapter Is Nothing Then
                _AccountCostCenterEmployeeTableAdapter = New AccountCostCenterEmployeeTableAdapter
            End If

            Return _AccountCostCenterEmployeeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueCostCenterEmployeeAdapter() As vueAccountCostCenterEmployeeTableAdapter
        Get
            If _vueAccountCostCenterEmployeeTableAdapter Is Nothing Then
                _vueAccountCostCenterEmployeeTableAdapter = New vueAccountCostCenterEmployeeTableAdapter
            End If

            Return _vueAccountCostCenterEmployeeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCostCenterByAccountId(ByVal AccountId As Integer) As AccountCostCenter.AccountCostCenterDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCostCenter() As AccountCostCenter.AccountCostCenterDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCostCenterByAccountCostCenterId(ByVal AccountCostCenterId As Integer) As AccountCostCenter.AccountCostCenterDataTable
        Return Adapter.GetDataByAccountCostCenterId(AccountCostCenterId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCostCenterByAccountIdAndAccountCostCenter(ByVal AccountId As Integer, ByVal AccountCostCenter As String) As AccountCostCenter.AccountCostCenterDataTable
        Return Adapter.GetDataByAccountIdAndAccountCostCenter(AccountId, AccountCostCenter)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCostCenterEmployeeByAccountIdandAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountCostCenter.vueAccountCostCenterEmployeeDataTable
        Return vueCostCenterEmployeeAdapter.GetDataByAccountIdandAccountEmployeeId(AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCostCenterByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountCostCenterId As Integer, ByVal AccountEmployeeId As Integer) As AccountCostCenter.AccountCostCenterDataTable
        If DBUtilities.GetCostCenterInTimesheetBy = "Account" Then
            strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountCostCenterDataTable", "GetAccountCostCenterByAccountIdAndIsDisabled", "AccountCostCenterId=" & AccountCostCenterId, AccountId)
        Else
            strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountCostCenterDataTable", "GetAccountCostCenterByAccountIdAndIsDisabled", "AccountCostCenterId=" & AccountCostCenterId & "_AccountEmployeeId=" & AccountEmployeeId, AccountId)
        End If
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountCostCenterByAccountIdAndIsDisabled = CacheManager.GetItemFromCache(strCacheKey)
        Else
            If DBUtilities.GetCostCenterInTimesheetBy = "Account" Then
                GetAccountCostCenterByAccountIdAndIsDisabled = Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountCostCenterId)
                CacheManager.AddAccountDataInCache(GetAccountCostCenterByAccountIdAndIsDisabled, strCacheKey)
            Else
                GetAccountCostCenterByAccountIdAndIsDisabled = Adapter.GetAssignedCostCenterByAccountEmployeeIdandIsDisabled(AccountId, AccountCostCenterId, AccountEmployeeId)
                CacheManager.AddAccountDataInCache(GetAccountCostCenterByAccountIdAndIsDisabled, strCacheKey)
            End If
        End If
        Return GetAccountCostCenterByAccountIdAndIsDisabled
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCostCenterByAccountId(ByVal AccountId As Integer) As AccountCostCenter.AccountCostCenterDataTable
        GetAccountCostCenterByAccountId = Adapter.GetDataByAccountId(AccountId)

        Uiutilities.FixTableForNoRecords(GetAccountCostCenterByAccountId)

        Return GetAccountCostCenterByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountCostCenter( _
                    ByVal AccountCostCenterCode As String, ByVal AccountCostCenter As String, ByVal AccountId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, ByVal SortOrder As Integer) As Boolean
        ' Create a new ProductRow instance


        _AccountCostCenterTableAdapter = New AccountCostCenterTableAdapter

        Dim dtAccountCostCenter As New AccountCostCenter.AccountCostCenterDataTable
        Dim drAccountCostCenter As AccountCostCenter.AccountCostCenterRow = dtAccountCostCenter.NewAccountCostCenterRow

        With drAccountCostCenter
            .AccountCostCenterCode = AccountCostCenterCode
            .AccountCostCenter = AccountCostCenter
            .AccountId = AccountId
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
            If SortOrder = 0 Then
                .Item("SortOrder") = System.DBNull.Value
            Else
                .SortOrder = SortOrder
            End If
        End With

        dtAccountCostCenter.AddAccountCostCenterRow(drAccountCostCenter)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountCostCenter)
        CacheManager.ClearCache("AccountCostCenterDataTable", , True)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountCostCenter(ByVal AccountCostCenterCode As String, ByVal AccountCostCenter As String, _
                ByVal AccountId As Integer, ByVal Original_AccountCostCenterId As Integer, ByVal ModifiedOn As DateTime, _
                ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean, ByVal SortOrder As Integer) As Boolean

        ' Update the product record

        Dim dtAccountCostCenter As AccountCostCenter.AccountCostCenterDataTable = Adapter.GetDataByAccountCostCenterId(Original_AccountCostCenterId)
        Dim drAccountCostCenter As AccountCostCenter.AccountCostCenterRow = dtAccountCostCenter.Rows(0)

        With drAccountCostCenter
            .AccountCostCenterCode = AccountCostCenterCode
            .AccountCostCenter = AccountCostCenter
            .AccountId = AccountId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
            If SortOrder = 0 Then
                .Item("SortOrder") = System.DBNull.Value
            Else
                .SortOrder = SortOrder
            End If
        End With


        Dim rowsAffected As Integer = Adapter.Update(dtAccountCostCenter)
        CacheManager.ClearCache("AccountCostCenterDataTable", , True)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountCostCenter(ByVal Original_AccountCostCenterId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountCostCenterId)
        CacheManager.ClearCache("AccountCostCenterDataTable", , True)
        Return rowsAffected = 1

    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeCostCenterNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangeCostCenterNameByUICulture(ByVal AccountId As Integer)
        Dim dtCostCenter As AccountCostCenter.AccountCostCenterDataTable = Me.GetCostCenterByAccountId(AccountId)
        Dim drCostCenter As AccountCostCenter.AccountCostCenterRow
        For Each drCostCenter In dtCostCenter.Rows
            Me.UpdateAccountCostCenter(ResourceHelper.GetDefaultDataLocalValue(drCostCenter.AccountCostCenterCode), ResourceHelper.GetDefaultDataLocalValue(drCostCenter.AccountCostCenter), drCostCenter.AccountId, drCostCenter.AccountCostCenterId, drCostCenter.ModifiedOn, drCostCenter.ModifiedByEmployeeId, drCostCenter.IsDisabled, drCostCenter.SortOrder)
        Next

    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountCostCenterEmployee( _
                    ByVal AccountCostCenterId As Integer, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As Boolean
        ' Create a new ProductRow instance


        _AccountCostCenterEmployeeTableAdapter = New AccountCostCenterEmployeeTableAdapter

        Dim dtAccountCostCenterEmployee As New AccountCostCenter.AccountCostCenterEmployeeDataTable
        Dim drAccountCostCenterEmployee As AccountCostCenter.AccountCostCenterEmployeeRow = dtAccountCostCenterEmployee.NewAccountCostCenterEmployeeRow
        Dim AccountCostCenterEmployeeId As Guid = System.Guid.NewGuid
        With drAccountCostCenterEmployee
            .AccountCostCenterEmployeeId = AccountCostCenterEmployeeId
            .AccountCostCenterId = AccountCostCenterId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
        End With

        dtAccountCostCenterEmployee.AddAccountCostCenterEmployeeRow(drAccountCostCenterEmployee)

        ' Add the new product
        Dim rowsAffected As Integer = _AccountCostCenterEmployeeTableAdapter.Update(dtAccountCostCenterEmployee)
        CacheManager.ClearCache("AccountCostCenterEmployeeDataTable", , True)
        CacheManager.ClearCache("AccountCostCenterDataTable", , True)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountCostCenterEmployee(ByVal Original_AccountCostCenterEmployeeId As Guid) As Boolean
        Dim rowsAffected As Integer = CostCenterEmployeeAdapter.Delete(Original_AccountCostCenterEmployeeId)
        CacheManager.ClearCache("AccountCostCenterDataTable", , True)
        Return rowsAffected = 1

    End Function
End Class
