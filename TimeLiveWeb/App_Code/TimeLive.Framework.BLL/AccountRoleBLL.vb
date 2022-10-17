Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountRoleBLL

    Private _AccountRoleTableAdapter As AccountRoleTableAdapter = Nothing
    Private _vueAccountRoleTableAdapter As vueAccountRoleTableAdapter = Nothing

    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountRoleTableAdapter
        Get
            If _AccountRoleTableAdapter Is Nothing Then
                _AccountRoleTableAdapter = New AccountRoleTableAdapter()
            End If

            Return _AccountRoleTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountRoleAdapter() As vueAccountRoleTableAdapter
        Get
            If _vueAccountRoleTableAdapter Is Nothing Then
                _vueAccountRoleTableAdapter = New vueAccountRoleTableAdapter()
            End If

            Return _vueAccountRoleTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRoleByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRoleByAccountIdForNewAccount(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByAccountIdandIsDisabled(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRoles() As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetData
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRoleForExternalUser(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetAccountRoleForExternalUser(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
Public Function GetAccountRolesByAccountIdAndAccountRoleId(ByVal AccountId As Integer, ByVal AccountRoleId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByAccountIdAndAccountRoleId(AccountId, AccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByAccountIdAndMasterAccountRoleId(ByVal AccountId As Integer, ByVal MasterAccountRoleId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByMasterAccountRoleId(AccountId, MasterAccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByMasterAccountRoleIdEdit(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByAccountIdandMasterAccountRole(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountRolesByIsSystemRole(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountRoleDataTable
        Return vueAccountRoleAdapter.GetDataByIsSystemRole(AccountId)
    End Function
    Public Sub UpdateDefaultAccountPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal DefaultAccountPageId As Integer)
        Adapter.UpdateDefaultAccountPage(DefaultAccountPageId, AccountRoleId, AccountId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
Public Function GetvueAccountRolesByIsSystemRoleAndIsDisabled(ByVal AccountId As Integer, ByVal AccountRoleId As Integer) As TimeLiveDataSet.vueAccountRoleDataTable
        Return vueAccountRoleAdapter.GetDataByIsSystemRoleAndIsDisabled(AccountId, AccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
Public Function GetAccountRolesByAccountIdAndRoles(ByVal AccountId As Integer, ByVal Roles As String) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByAccountIdAndRole(AccountId, Roles)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRoleDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountRoleDataTable", "GetAccountRolesByAccountId", AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountRolesByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountRolesByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountRolesByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountRolesByAccountId)

        Return GetAccountRolesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByAccountIdForAssign(ByVal AccountId As Integer) As TimeLiveDataSet.AccountRoleDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountRoleDataTable", "GetAccountRolesByAccountIdForAssign", AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountRolesByAccountIdForAssign = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountRolesByAccountIdForAssign = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountRolesByAccountIdForAssign, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountRolesByAccountIdForAssign)

        Return GetAccountRolesByAccountIdForAssign
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByAccountRoleId(ByVal AccountRoleId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByAccountRoleId(AccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByLDAPRole(ByVal AccountId As Integer, ByVal LDAPRole As String) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetDataByLDAPRole(AccountId, LDAPRole)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountRolesByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountRoleDataTable
        Return Adapter.GetAccountRolesByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountRoleLastId.Rows(0)
        Return a.LastId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountRole( _
                        ByVal AccountId As Integer, ByVal Role As String, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer, ByVal LDAPRole As String _
                    ) As Integer
        ' Create a new ProductRow instance


        _AccountRoleTableAdapter = New AccountRoleTableAdapter
        Try


            With _AccountRoleTableAdapter
                Dim rowsAffected As Integer = .InsertRole(AccountId, Role, False, Now, CreatedByEmployeeId, Now, ModifiedByEmployeeId, LDAPRole)
                Call New AccountPagePermissionBLL().InsertDefaultPermissionOfRole(2, Me.GetLastInsertedId, AccountId)
                Call New ObjectPermissionBLL().InsertPermissionForReportByRole(AccountId, Me.GetLastInsertedId, 2)
                CacheManager.ClearCache("AccountRoleDataTable", , True)

                ' Return true if precisely one row was inserted, otherwise false
                Return rowsAffected
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountRole(ByVal AccountId As Integer, ByVal Role As String, ByVal original_AccountRoleId As Integer, ByVal IsDisabled As Boolean, ByVal IsDeleted As Boolean, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal LDAPRole As String) As Boolean

        ' Update the product record

        Dim AccountRoles As TimeLiveDataSet.AccountRoleDataTable = Adapter.GetDataByAccountRoleId(original_AccountRoleId)

        Dim AccountRole As TimeLiveDataSet.AccountRoleRow = AccountRoles.Rows(0)

        With AccountRole
            .AccountId = AccountId
            .Role = Role
            .IsDisabled = IsDisabled
            .ModifiedOn = Now
            .LDAPRole = LDAPRole
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountRole)

        CacheManager.ClearCache("AccountRoleDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountRole(ByVal original_AccountRoleId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(original_AccountRoleId)

        CacheManager.ClearCache("AccountRoleDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    'Public Function InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As Integer
    '    Return Adapter.InsertDefault(AccountId, AccountEmployeeId)
    'End Function

    Public Function InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal UserInterfaceLanguage As String)

        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeRoleNameByUICulture(AccountId)
        End If
        Return Adapter.InsertDefault(AccountId, AccountEmployeeId)
    End Function
    Public Sub ChangeRoleNameByUICulture(ByVal AccountId As Integer)
        Dim dtRole As TimeLiveDataSet.AccountRoleDataTable = Me.GetAccountRoleByAccountId(AccountId)
        Dim drRole As TimeLiveDataSet.AccountRoleRow
        For Each drRole In dtRole.Rows
            Me.UpdateAccountRole(AccountId, ResourceHelper.GetDefaultDataLocalValue(drRole.Role), drRole.AccountRoleId, drRole.IsDisabled, drRole.IsDeleted, drRole.CreatedOn, drRole.CreatedByEmployeeId, drRole.ModifiedOn, drRole.ModifiedByEmployeeId, ResourceHelper.GetDefaultDataLocalValue(drRole.LDAPRole))
        Next

    End Sub
    Public Function InsertAfterRoles(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal MasterRoleId As Integer) As Integer
        Return Adapter.InsertAfterRoles(AccountId, Now, AccountEmployeeId, MasterRoleId)
    End Function
    Public Sub UpdateDefaultPageForExternalUser(ByVal AccountId As Integer)
        Adapter.UpdateDefaultAccountPageIdForExternalUser(38, AccountId)
    End Sub
End Class