Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountWorkTypeBLL

    Private _AccountWorkTypeTableAdapter As AccountWorkTypeTableAdapter = Nothing
    Private _AccountWorkTypeBillingRateTableAdapter As AccountWorkTypeBillingRateTableAdapter = Nothing
    Private _SystemBillingRateTypeTableAdapter As SystemBillingRateTypeTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountWorkTypeTableAdapter
        Get
            If _AccountWorkTypeTableAdapter Is Nothing Then
                _AccountWorkTypeTableAdapter = New AccountWorkTypeTableAdapter()
            End If

            Return _AccountWorkTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountWorkTypeBillingRateAdapter() As AccountWorkTypeBillingRateTableAdapter
        Get
            If _AccountWorkTypeBillingRateTableAdapter Is Nothing Then
                _AccountWorkTypeBillingRateTableAdapter = New AccountWorkTypeBillingRateTableAdapter()
            End If

            Return _AccountWorkTypeBillingRateTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemBillingRateTypeAdapter() As SystemBillingRateTypeTableAdapter
        Get
            If _SystemBillingRateTypeTableAdapter Is Nothing Then
                _SystemBillingRateTypeTableAdapter = New SystemBillingRateTypeTableAdapter()
            End If

            Return _SystemBillingRateTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountWorkTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypes() As TimeLiveDataSet.AccountWorkTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeeOwnWorkTypeBillingRate(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable
        Return AccountWorkTypeBillingRateAdapter.GetDataForEmployeeOwnWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountEmployeeId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectTaskWorkTypeBillingRate(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable
        Return AccountWorkTypeBillingRateAdapter.GetDataForProjectTaskWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectTaskId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectEmployeeWorkTypeBillingRate(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable
        Return AccountWorkTypeBillingRateAdapter.GetDataForProjectEmployeeWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectEmployeeId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectRoleWorkTypeBillingRate(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectRoleId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable
        Return AccountWorkTypeBillingRateAdapter.GetDataForProjectRoleWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectRoleId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypesByAccountWorkTypeId(ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.AccountWorkTypeDataTable
        Return Adapter.GetDataByAccountWorkTypeId(AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountWorkTypeDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountWorkTypeDataTable", "GetAccountWorkTypesByAccountId", AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountWorkTypesByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountWorkTypesByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountWorkTypesByAccountId, strCacheKey)
        End If
        UIUtilities.FixTableForNoRecords(GetAccountWorkTypesByAccountId)

        Return GetAccountWorkTypesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.AccountWorkTypeDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountWorkTypeDataTable", "GetAccountWorkTypesByAccountIdAndIsDisabled", "AccountWorkTypeId=" & AccountWorkTypeId, AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountWorkTypesByAccountIdAndIsDisabled = CacheManager.GetItemFromCache(strCacheKey)
        Else
            'If System.Configuration.ConfigurationManager.AppSettings("HIDE_DEFAULT_WORKTYPE_VALUES") = "Yes" Then
            If DBUtilities.GetSessionAccountId = 7354 Then
                GetAccountWorkTypesByAccountIdAndIsDisabled = Adapter.GetDataByAccountIdAndHideDefaultWorkType(AccountId, AccountWorkTypeId)
            Else
                GetAccountWorkTypesByAccountIdAndIsDisabled = Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountWorkTypeId)
            End If
            CacheManager.AddAccountDataInCache(GetAccountWorkTypesByAccountIdAndIsDisabled, strCacheKey)
        End If
        'UIUtilities.FixTableForNoRecords(GetAccountWorkTypesByAccountIdAndIsDisabled)
        Return GetAccountWorkTypesByAccountIdAndIsDisabled
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypesByAccountIdWorkType(ByVal AccountId As Integer) As TimeLiveDataSet.AccountWorkTypeDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountWorkTypeDataTable", "GetAccountWorkTypesByAccountIdWorkType", AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountWorkTypesByAccountIdWorkType = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountWorkTypesByAccountIdWorkType = Adapter.GetDataByAccountIdWorkType(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountWorkTypesByAccountIdWorkType, strCacheKey)
        End If
        UIUtilities.FixTableForNoRecords(GetAccountWorkTypesByAccountIdWorkType)

        Return GetAccountWorkTypesByAccountIdWorkType
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkTypesByAccountIdAndAccountWorkType(ByVal AccountId As Integer) As TimeLiveDataSet.AccountWorkTypeDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountWorkTypeDataTable", "GetAccountWorkTypesByAccountIdAndAccountWorkType", AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountWorkTypesByAccountIdAndAccountWorkType = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountWorkTypesByAccountIdAndAccountWorkType = Adapter.GetDataByAccountIdAndAccountWorkType(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountWorkTypesByAccountIdAndAccountWorkType, strCacheKey)
        End If
        Return GetAccountWorkTypesByAccountIdAndAccountWorkType
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountWorkType( _
                        ByVal AccountWorkTypeCode As String, ByVal AccountWorkType As String, ByVal AccountId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, _
ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal SortOrder As Integer) As Boolean
        ' Create a new ProductRow instance


        _AccountWorkTypeTableAdapter = New AccountWorkTypeTableAdapter

        Dim dtAccountWorkType As New TimeLiveDataSet.AccountWorkTypeDataTable
        Dim drAccountWorkType As TimeLiveDataSet.AccountWorkTypeRow = dtAccountWorkType.NewAccountWorkTypeRow

        With drAccountWorkType
            .AccountWorkTypeCode = AccountWorkTypeCode
            .AccountWorkType = AccountWorkType
            .Item("SystemWorkTypeId") = System.DBNull.Value
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

        dtAccountWorkType.AddAccountWorkTypeRow(drAccountWorkType)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountWorkType)

        CacheManager.ClearCache("AccountWorkTypeDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountWorkType(ByVal AccountWorkTypeCode As String, ByVal AccountWorkType As String, _
                    ByVal AccountId As Integer, ByVal Original_AccountWorkTypeId As Integer, ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean, ByVal SortOrder As Integer) As Boolean

        ' Update the product record

        Dim dtAccountWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = Adapter.GetDataByAccountWorkTypeId(Original_AccountWorkTypeId)
        Dim drAccountWorkType As TimeLiveDataSet.AccountWorkTypeRow = dtAccountWorkType.Rows(0)

        With drAccountWorkType
            .AccountWorkTypeCode = AccountWorkTypeCode
            .AccountWorkType = AccountWorkType
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


        Dim rowsAffected As Integer = Adapter.Update(dtAccountWorkType)

        CacheManager.ClearCache("AccountWorkTypeDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountWorkType(ByVal Original_AccountWorkTypeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountWorkTypeId)

        CacheManager.ClearCache("AccountWorkTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        If IsExistsMasterRecord(AccountId) = False Then
            Adapter.InsertDefault(AccountId, AccountEmployeeId, Now)
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeWorkTypeNameByUICulture(AccountId)
            End If
        End If
    End Sub
    Public Sub ChangeWorkTypeNameByUICulture(ByVal AccountId As Integer)
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = Me.GetAccountWorkTypeByAccountId(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        For Each drWorkType In dtWorkType.Rows
            Me.UpdateAccountWorkType(drWorkType.AccountWorkTypeCode, ResourceHelper.GetDefaultDataLocalValue(drWorkType.AccountWorkType), AccountId, drWorkType.AccountWorkTypeId, drWorkType.ModifiedOn, drWorkType.ModifiedByEmployeeId, drWorkType.IsDisabled, drWorkType.SortOrder)
        Next
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountWorkTypeBillingRate( _
                        ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountEmployeeId As Integer, _
                        ByVal AccountProjectEmployeeId As Integer, ByVal AccountProjectRoleId As Integer, ByVal AccountProjectTaskId As Integer, _
                        ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountWorkTypeBillingRateTableAdapter = New AccountWorkTypeBillingRateTableAdapter

        Dim dtAccountWorkTypeBillingRate As New TimeLiveDataSet.AccountWorkTypeBillingRateDataTable
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow = dtAccountWorkTypeBillingRate.NewAccountWorkTypeBillingRateRow

        With drAccountWorkTypeBillingRate
            .AccountId = AccountId
            .SystemBillingRateTypeId = SystemBillingRateTypeId
            If AccountEmployeeId <> 0 Then
                .AccountEmployeeId = AccountEmployeeId
            Else
                .Item("AccountEmployeeId") = System.DBNull.Value
            End If
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
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            Else
                .Item("AccountProjectTaskId") = System.DBNull.Value
            End If
            .AccountBillingRateId = AccountBillingRateId
            .AccountWorkTypeId = AccountWorkTypeId
        End With

        dtAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRateRow(drAccountWorkTypeBillingRate)

        ' Add the new product
        Dim rowsAffected As Integer = AccountWorkTypeBillingRateAdapter.Update(dtAccountWorkTypeBillingRate)

        CacheManager.ClearCache("AccountWorkTypeBillingRateDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountWorkTypeBillingRate(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountEmployeeId As Integer, _
                        ByVal AccountProjectEmployeeId As Integer, ByVal AccountProjectRoleId As Integer, ByVal AccountProjectTaskId As Integer, _
                        ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer, ByVal Original_AccountWorkTypeBillingRateId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = AccountWorkTypeBillingRateAdapter.GetDataByAccountWorkTypeBillingRateId(Original_AccountWorkTypeBillingRateId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow = dtAccountWorkTypeBillingRate.Rows(0)

        With drAccountWorkTypeBillingRate
            .AccountId = AccountId
            .SystemBillingRateTypeId = SystemBillingRateTypeId
            If AccountEmployeeId <> 0 Then
                .AccountEmployeeId = AccountEmployeeId
            Else
                .Item("AccountEmployeeId") = System.DBNull.Value
            End If
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
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            Else
                .Item("AccountProjectTaskId") = System.DBNull.Value
            End If
            .AccountBillingRateId = AccountBillingRateId
            .AccountWorkTypeId = AccountWorkTypeId
        End With


        Dim rowsAffected As Integer = AccountWorkTypeBillingRateAdapter.Update(dtAccountWorkTypeBillingRate)

        CacheManager.ClearCache("AccountWorkTypeBillingRateDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertAccountWorkTypeBillingRate(ByVal AccountId As Integer)
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = Me.GetAccountWorkTypesByAccountIdAndAccountWorkType(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow = dtWorkType.Rows(0)
        Me.InsertWorkTypeBillingRateOfEmployeeOwn(AccountId, drWorkType.AccountWorkTypeId)
        Me.InsertWorkTypeBillingRateOfProjectRole(AccountId, drWorkType.AccountWorkTypeId)
        Me.InsertWorkTypeBillingRateOfProjectEmployee(AccountId, drWorkType.AccountWorkTypeId)
        Me.InsertWorkTypeBillingRateOfProjectTask(AccountId, drWorkType.AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfEmployeeOwn(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfEmployeeOwn(AccountId, AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfProjectRole(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfProjectRole(AccountId, AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfProjectEmployee(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfProjectEmployee(AccountId, AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfProjectTask(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfProjectTask(AccountId, AccountWorkTypeId)
    End Sub

    Public Sub InsertWorkTypeBillingRateOfProjectEmployeeByTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfProjectEmployeeByTemplate(AccountId, AccountProjectId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfProjectRoleByTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfProjectRoleByTemplate(AccountId, AccountProjectId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfProjectTaskByTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfProjectTaskByTemplate(AccountId, AccountProjectId)
    End Sub
    Public Sub InsertDefaultWorkTypeBillingRateOfNewEmployee(ByVal AccountId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertDefaultWorkTypeBillingRateOfNewEmployee(AccountId)
    End Sub
    Public Sub InsertWorkTypeBillingRateOfEmployeeWhichIsNotExists(ByVal AccountId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateOfEmployeeWhichIsNotExists(AccountId)
    End Sub
    Public Function IsExistsMasterRecord(ByVal AccountId As Integer) As Boolean
        If Adapter.GetDataByAccountIdMaster(AccountId).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Sub InsertWorkTypeBillingRateWhichIsNotExistsOfEmployeeOwn(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateWhichIsNotExists(AccountId, 1, AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateWhichIsNotExistsOfProjectRole(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateWhichIsNotExists(AccountId, 2, AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateWhichIsNotExistsOfProjectEmployee(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateWhichIsNotExists(AccountId, 3, AccountWorkTypeId)
    End Sub
    Public Sub InsertWorkTypeBillingRateWhichIsNotExistsOfProjectTask(ByVal AccountId As Integer, ByVal AccountWorkTypeId As Integer)
        AccountWorkTypeBillingRateAdapter.InsertWorkTypeBillingRateWhichIsNotExists(AccountId, 4, AccountWorkTypeId)
    End Sub
    Public Sub InsertAccountWorkTypeBillingRateWhichIsNotExists(ByVal AccountId As Integer)
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = Me.GetAccountWorkTypesByAccountIdAndAccountWorkType(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        For Each drWorkType In dtWorkType.Rows
            Me.InsertWorkTypeBillingRateWhichIsNotExistsOfEmployeeOwn(AccountId, drWorkType.AccountWorkTypeId)
            Me.InsertWorkTypeBillingRateWhichIsNotExistsOfProjectRole(AccountId, drWorkType.AccountWorkTypeId)
            Me.InsertWorkTypeBillingRateWhichIsNotExistsOfProjectEmployee(AccountId, drWorkType.AccountWorkTypeId)
            Me.InsertWorkTypeBillingRateWhichIsNotExistsOfProjectTask(AccountId, drWorkType.AccountWorkTypeId)
        Next
    End Sub
    Public Function GetDefaultWorkType(ByVal AccountId As Integer) As Integer
        Dim dtworktype As TimeLiveDataSet.AccountWorkTypeDataTable = Me.GetAccountWorkTypeByAccountId(AccountId)
        Dim drworktype As TimeLiveDataSet.AccountWorkTypeRow
        If dtworktype.Rows.Count > 0 Then
            drworktype = dtworktype.Rows(0)
            Return drworktype.AccountWorkTypeId
        End If
    End Function
End Class
