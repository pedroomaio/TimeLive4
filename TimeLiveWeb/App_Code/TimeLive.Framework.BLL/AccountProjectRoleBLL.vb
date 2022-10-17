Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountProjectRoleBLL

    Private _AccountProjectRoleTableAdapter As AccountProjectRoleTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountProjectRoleTableAdapter
        Get
            If _AccountProjectRoleTableAdapter Is Nothing Then
                _AccountProjectRoleTableAdapter = New AccountProjectRoleTableAdapter()
            End If

            Return _AccountProjectRoleTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRoles() As TimeLiveDataSet.AccountProjectRoleDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRolesForSelection(ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectRoleDataTable
        Dim _vueAccountProjectRoleTableAdapter As New vueAccountProjectRoleTableAdapter
        Return _vueAccountProjectRoleTableAdapter.GetDataByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRolesForSelectionByAccountWorkTypeId(ByVal AccountProjectId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.vueAccountProjectRoleDataTable
        Dim _vueAccountProjectRoleTableAdapter As New vueAccountProjectRoleTableAdapter
        Return _vueAccountProjectRoleTableAdapter.GetDataByAccountProjectIdAndAccountWorkTypeId(AccountProjectId, AccountWorkTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectRolesByAccountProjectRoleId(ByVal AccountProjectRoleId As Integer) As TimeLiveDataSet.vueAccountProjectRoleDataTable
        Dim _vueAccountProjectRoleTableAdapter As New vueAccountProjectRoleTableAdapter
        Return _vueAccountProjectRoleTableAdapter.GetDataByAccountProjectRoleId(AccountProjectRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRolesByAccountProjectIdAsView(ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectRoleFullJoinDataTable
        Dim _vueAccountProjectRoleTableAdapterFullJoin As New vueAccountProjectRoleFullJoinTableAdapter
        Return _vueAccountProjectRoleTableAdapterFullJoin.GetDataByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectRoleBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectRoleBillingRateDataTable", "GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId", "AccountEmployeeId=" & AccountEmployeeId & "_AccountProjectId=" & AccountProjectId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountProjectRoleBillingRate As New vueAccountProjectRoleBillingRateTableAdapter
            GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId = _vueAccountProjectRoleBillingRate.GetDataByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectId)
            CacheManager.AddAccountDataInCache(GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId, strCacheKey)
        End If
        Return GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRolesByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectRoleDataTable
        Return Adapter.GetDataByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectRolesByAccountProjectRoleId(ByVal AccountProjectRoleId As Integer) As TimeLiveDataSet.AccountProjectRoleDataTable
        Return Adapter.GetDataByAccountProjectRoleId(AccountProjectRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectRoleLastId.Rows(0)
        Return a.LastId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectRole( _
                        ByVal AccountProjectId As Integer, ByVal AccountRoleId As Integer, ByVal NumberOfResources As System.Nullable(Of Integer), ByVal BillingRate As System.Nullable(Of Decimal), ByVal BillingTypeid As Integer, ByVal AccountBillingRateId As Integer) As Boolean
        ' Create a new ProductRow instance


        _AccountProjectRoleTableAdapter = New AccountProjectRoleTableAdapter

        Dim AccountProjectRoles As New TimeLiveDataSet.AccountProjectRoleDataTable
        Dim AccountProjectRole As TimeLiveDataSet.AccountProjectRoleRow = AccountProjectRoles.NewAccountProjectRoleRow

        ' Add Newly AccountProjectId if it is from AddProject form
        If AccountProjectId = 0 Then
            Dim a As TimeLiveDataSet.IdentityQueryRow
            Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
            a = ad.GetAccountProjectLastId.Rows(0)
            AccountProjectId = a.LastId
        End If

        With AccountProjectRole
            .AccountProjectId = AccountProjectId
            .AccountRoleId = AccountRoleId
            If NumberOfResources.HasValue Then
                .NumberOfResources = NumberOfResources
            End If
            If BillingRate.HasValue Then
                .BillingRate = BillingRate
            End If
            .BillingTypeId = BillingTypeid
            .Item("AccountBillingRateId") = IIf(AccountBillingRateId = 0, System.DBNull.Value, AccountBillingRateId)
        End With

        AccountProjectRoles.AddAccountProjectRoleRow(AccountProjectRole)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectRoles)

        'Dim AccountProjectPreferences As New AccountRoleProjectPreferencesBLL
        'AccountProjectPreferences.AddAccountRoleProjectPreference(AccountRoleId, AccountProjectId, True, False)


        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectRole( _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountRoleId As Integer, _
                    ByVal NumberOfResources As System.Nullable(Of Integer), _
                    ByVal BillingRate As System.Nullable(Of Decimal), _
                    ByVal BillingTypeid As Integer, _
                    ByVal AccountBillingRateId As Integer, _
                    ByVal Original_AccountProjectRoleId As Integer _
                ) As Boolean

        ' Update the product record

        Dim AccountProjectRoles As TimeLiveDataSet.AccountProjectRoleDataTable = Adapter.GetDataByAccountProjectRoleId(Original_AccountProjectRoleId)
        Dim AccountProjectRole As TimeLiveDataSet.AccountProjectRoleRow = AccountProjectRoles.Rows(0)

        With AccountProjectRole
            .AccountProjectId = AccountProjectId
            .AccountRoleId = AccountRoleId
            If NumberOfResources.HasValue Then
                .NumberOfResources = NumberOfResources
            End If
            If BillingRate.HasValue Then
                .BillingRate = BillingRate
            End If
            .BillingTypeId = BillingTypeid
            .AccountBillingRateId = AccountBillingRateId
        End With




        Dim rowsAffected As Integer = Adapter.Update(AccountProjectRole)

        CacheManager.ClearCache("AccountProjectRoleDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectRoleId(ByVal Original_AccountProjectRoleId As Integer) As Boolean
        'Call New AccountBillingRateBLL().DeleteBillingRateByAccountIdAndAccountProjectRoleId(DBUtilities.GetSessionAccountId, Original_AccountProjectRoleId)
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectRoleId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InserAccountProjectRolesByProjectTempalte(ByVal AccountProjectId As Integer, ByVal AccountProjectTemplateId As Integer)
        Adapter.InsertAccountProjectRoleByProjectTemplate(AccountProjectId, AccountProjectTemplateId)
    End Sub
    Public Function IfWorkTypeBillingRateExistOfProjectRole(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectRoleId As Integer, ByVal AccountWorkTypeId As Integer) As Boolean
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectRoleWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectRoleId, AccountWorkTypeId)

        If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function AddDefaultAccountProjectRoleByImport(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountRoleId As Integer, ByVal NumberOfResources As Integer, ByVal BillingTypeId As Integer, ByVal BillingRate As Double)
        Dim objAccountWorkType As New AccountWorkTypeBLL
        Dim objAccountBillingRate As New AccountBillingRateBLL
        Dim objAccountProjectEmployee As New AccountProjectEmployeeBLL
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = objAccountWorkType.GetAccountWorkTypesByAccountId(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        If dtWorkType.Rows.Count > 0 Then
            drWorkType = dtWorkType.Rows(0)
            If GetProjectBillingRateTypeId(AccountProjectId) = 2 Then
                If Me.IsProjectRoleExists(AccountProjectId, AccountRoleId) Then
                    Me.AddAccountProjectRole(AccountProjectId, AccountRoleId, NumberOfResources, BillingRate, BillingTypeId, Nothing)
                    For Each drWorkType In dtWorkType.Rows
                        If drWorkType.SystemWorkTypeId = 1 Then
                            objAccountBillingRate.AddAccountBillingRate(AccountId, 2, 0, Me.GetLastInsertedId, AccountEmployeeId, 0, BillingRate, Now.Date.Date, Now.Date.Date.AddYears(1), drWorkType.AccountWorkTypeId, BillingRate, DBUtilities.GetAccountBaseCurrencyId, DBUtilities.GetAccountBaseCurrencyId)
                            Me.UpdateAccountProjectRole(AccountProjectId, AccountRoleId, NumberOfResources, BillingRate, BillingTypeId, objAccountBillingRate.GetLastInsertedId, Me.GetLastInsertedId)
                            Me.UpdateWorkTypeBillingRateOfProjectRole(AccountId, 2, Me.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                        End If
                    Next
                End If
                If objAccountProjectEmployee.IsProjectEmployeeExistsForRole(AccountId, AccountProjectId, AccountEmployeeId, AccountRoleId) Then
                    objAccountProjectEmployee.AddAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, AccountRoleId, Nothing)
                End If
            End If
        End If
    End Function
    Public Sub UpdateWorkTypeBillingRateOfProjectRole(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectRoleId As Integer, ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer)

        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim objAccountProjectRole As New AccountProjectRoleBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetEmployeeOwnWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectRoleId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow

        If objAccountProjectRole.IfWorkTypeBillingRateExistOfProjectRole(AccountId, SystemBillingRateTypeId, AccountProjectRoleId, AccountWorkTypeId) <> True Then
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, 0, AccountProjectRoleId, 0, AccountBillingRateId, AccountWorkTypeId)
        Else
            If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
                drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
                objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, 0, AccountProjectRoleId, 0, AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
            End If
        End If

    End Sub
    Public Function GetProjectBillingRateTypeId(ByVal AccountProjectId As Integer) As Object

        Dim dtAccountProject As TimeLiveDataSet.AccountProjectDataTable
        dtAccountProject = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId)

        If dtAccountProject.Rows.Count > 0 Then

            Dim nProjectBillingRateTypeId As Object = CType(dtAccountProject.Rows(0), TimeLiveDataSet.AccountProjectRow).Item("ProjectBillingRateTypeId")
            If IsDBNull(nProjectBillingRateTypeId) Then
                Return 1 ' Use employee own billing rate
            Else
                Return nProjectBillingRateTypeId
            End If
        Else
            Return 1 ' Use employee own billing rate
        End If
    End Function
    Public Function IsProjectRoleExists(ByVal AccountProjectId As Integer, ByVal AccountRoleId As Integer)
        If Me.Adapter.GetDataByAccountProjectIdAndAccountRoleId(AccountProjectId, AccountRoleId).Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Public Sub DeleteAccountProjectRolesByAccountProjectId(ByVal AccountProjectId As Integer)
        Adapter.DeleteAccountProjectRolesByAccountProjectId(AccountProjectId)
    End Sub
End Class
