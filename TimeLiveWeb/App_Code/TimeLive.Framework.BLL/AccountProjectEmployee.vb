Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports TimeLiveDataSet

''' <summary>
''' ''' This class perform database operations for AccountProjectEmployee table. AccountProjectEmployee table 
''' store records for Project Employee data
''' </summary>
''' <remarks>Account Project Employee Business Layer Classes</remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountProjectEmployeeBLL

    Private _AccountProjectEmployeeTableAdapter As AccountProjectEmployeeTableAdapter = Nothing
    Private _vueAccountProjectEmployeeTableAdapter As vueAccountProjectEmployeeTableAdapter = Nothing
    Private _vueAccountEmployeeProjectTableAdapter As vueAccountEmployeeProjectTableAdapter = Nothing
    Dim strCacheKey As String
    ''' <summary>
    ''' Return Adapter object of AccountProjectEmployeeTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountProjectEmployeeTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Adapter() As AccountProjectEmployeeTableAdapter
        Get
            If _AccountProjectEmployeeTableAdapter Is Nothing Then
                _AccountProjectEmployeeTableAdapter = New AccountProjectEmployeeTableAdapter()
            End If

            Return _AccountProjectEmployeeTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountProjectEmployeeTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountProjectEmployeeTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueProjectEmployeeAdapter() As vueAccountProjectEmployeeTableAdapter
        Get
            If _vueAccountProjectEmployeeTableAdapter Is Nothing Then
                _vueAccountProjectEmployeeTableAdapter = New vueAccountProjectEmployeeTableAdapter()
            End If

            Return _vueAccountProjectEmployeeTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeProjectTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeProjectTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueEmployeeProjectAdapter() As vueAccountEmployeeProjectTableAdapter
        Get
            If _vueAccountEmployeeProjectTableAdapter Is Nothing Then
                _vueAccountEmployeeProjectTableAdapter = New vueAccountEmployeeProjectTableAdapter()
            End If

            Return _vueAccountEmployeeProjectTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return all project employee records
    ''' </summary>
    ''' <returns>account project employee data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployees() As TimeLiveDataSet.AccountProjectEmployeeDataTable
        Return Adapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountProjectEmployee records of specified AccountId and AccountProjectId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns>vueaccountprojectemployee data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesForSelection(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeeDataTable
        Dim _vueAccountProjectEmployeeTableAdapter As New vueAccountProjectEmployeeTableAdapter
        Return _vueAccountProjectEmployeeTableAdapter.GetDataByAccountProjectId(AccountId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Returns all AccountProjectEmployee records of specified AccountId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns>accountprojectemployee data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectEmployeeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    ''' <summary>
    ''' Returns all _vueAccountProjectEmployeeTableAdapter records of specified AccountId, AccountProjectId and AccountWorkTypeId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns>vueaccountprojectemployee data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesForSelectionByAccountWorkTypeId(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountWorkTypeId As Integer, ByVal IsSelected As Boolean) As TimeLiveDataSet.vueAccountProjectEmployeeDataTable
        Dim _vueAccountProjectEmployeeTableAdapter As New vueAccountProjectEmployeeTableAdapter
        If IsSelected = False Then
            'Return _vueAccountProjectEmployeeTableAdapter.GetDataByAccountProjectIdAndAccountWorkTypeId(AccountId, AccountProjectId, AccountWorkTypeId)
            Return _vueAccountProjectEmployeeTableAdapter.GetDataByAccountProjectIdAndAccountWorkTypeIdForIsNotSelected(AccountId, AccountProjectId, AccountWorkTypeId)
        Else
            Return _vueAccountProjectEmployeeTableAdapter.GetDataByAccountProjectIdAndAccountWorkTypeIdForIsSelected(AccountId, AccountProjectId, AccountWorkTypeId)
        End If
    End Function
    ''' <summary>
    ''' Returns all _vueAccountEmployeeProjectTableAdapter records of specified AccountId and AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeProject data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeProjectByAccountIdandAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeProjectDataTable
        Dim _vueAccountEmployeeProjectTableAdapter As New vueAccountEmployeeProjectTableAdapter
        Return _vueAccountEmployeeProjectTableAdapter.GetDataByAccountIdandAccountEmployeeId(AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountEmployeeIdForEmployeeProjectList(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IsSelected As Boolean) As TimeLiveDataSet.vueAccountEmployeeProjectDataTable
        Dim _vueAccountEmployeeProjectTableAdapter As New vueAccountEmployeeProjectTableAdapter
        If IsSelected = True Then
            Return _vueAccountEmployeeProjectTableAdapter.GetDataByAccountEmployeeIdForIsSelected(AccountId, AccountEmployeeId)
        Else
            Return _vueAccountEmployeeProjectTableAdapter.GetDataByAccountEmployeeIdForEmployeeProjectList(AccountId, AccountEmployeeId)
        End If

    End Function
    ''' <summary>
    ''' Returns  vueAccountProjectEmployeeTableAdapter record of specified AccountId. 
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>vueAccountProjectEmployee data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesForSelectionByAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountWorkTypeId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeeDataTable
        Dim _vueAccountProjectEmployeeTableAdapter As New vueAccountProjectEmployeeTableAdapter
        Return _vueAccountProjectEmployeeTableAdapter.GetDataByAccountProjectIdAndAccountEmployeeId(AccountId, AccountProjectId, AccountWorkTypeId, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns  AccountProjectEmployeesBillingRate record of specified AccountEmployeeId and AccountProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesBillingRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectEmployeeBillingRateDataTable", "GetAccountProjectEmployeesBillingRate", "AccountEmployeeId=" & AccountEmployeeId & "_AccountProjectId=" & AccountProjectId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectEmployeesBillingRate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountProjectEmployeebillingrateTableAdapter As New vueAccountProjectEmployeeBillingRateTableAdapter
            GetAccountProjectEmployeesBillingRate = _vueAccountProjectEmployeebillingrateTableAdapter.GetDataByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectId)
            CacheManager.AddAccountDataInCache(GetAccountProjectEmployeesBillingRate, strCacheKey)
        End If
        Return GetAccountProjectEmployeesBillingRate
    End Function
    ''' <summary>
    ''' Returns  vueAccountProjectEmployeeTableAdapter record of specified AccountProjectEmployeeId.
    ''' </summary>
    ''' <param name="AccountProjectEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesByAccountProjectEmployeeId(ByVal AccountProjectEmployeeId As Long) As TimeLiveDataSet.vueAccountProjectEmployeeDataTable
        Dim _vueAccountProjectEmployeeTableAdapter As New vueAccountProjectEmployeeTableAdapter
        Return _vueAccountProjectEmployeeTableAdapter.GetDataByAccountProjectEmployeeId(AccountProjectEmployeeId)
    End Function
    ''' <summary>
    ''' view project employee by projectid
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesByAccountProjectIdAsView(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeFullJoinDataTable
        Dim _vueAccountProjectEmployeeTableAdapterFullJoin As New vueAccountProjectEmployeFullJoinTableAdapter
        Return _vueAccountProjectEmployeeTableAdapterFullJoin.GetDataByAccountProjectId(AccountProjectId, AccountProjectTaskId)
    End Function
    ''' <summary>
    ''' view project employee by projectid
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectGanttEmployeesByAccountIdAsView(ByVal AccountId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeFullJoinDataTable
        Dim _vueAccountProjectEmployeeTableAdapterFullJoin As New vueAccountProjectEmployeFullJoinTableAdapter
        Return _vueAccountProjectEmployeeTableAdapterFullJoin.GetDataByAccountIdForProjectGantt (AccountId,AccountProjectTaskId )
    End Function
    ''' <summary>
    ''' view project employee by employeeid
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesByAccountEmployeeIdAsView(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeFullJoinDataTable
        Dim _vueAccountProjectEmployeeTableAdapterFullJoin As New vueAccountProjectEmployeFullJoinTableAdapter
        Return _vueAccountProjectEmployeeTableAdapterFullJoin.GetDataByAccountEmployeeId(AccountProjectId, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' return project employee by project id
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectEmployeeDataTable
        Return Adapter.GetDataByAccountProjectId(AccountProjectId)
    End Function
    ''' <summary>
    ''' return project employee by accountprojectid and accountemployeeid
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectEmployeesByAccountProjectIdandAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectEmployeeDataTable
        Return Adapter.GetDataByAccountIdProjectIdAndEmployeeId(AccountId, AccountEmployeeId, AccountProjectId)
    End Function
    ''' <summary>
    ''' return number of resource project
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetNumberOfResourcesOfProject(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectEmployeeDataTable
        Return AddBlankRowsInDataTable(vueProjectEmployeeAdapter.GetDataByAccountProjectId(AccountId, AccountProjectId))
    End Function
    ''' <summary>
    ''' delete null rows
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function DeleteNullAccountProjectEmployeeRows(ByVal AccountProjectId As Integer) As Integer
        Return Adapter.DeleteNullAccountProjectRoleEmployee(AccountProjectId)
    End Function
    ''' <summary>
    ''' get last insert id
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectEmployeeLastId.Rows(0)
        Return a.LastId
    End Function
    ''' <summary>
    ''' add project employee
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountRoleId"></param>
    ''' <param name="AccountBillingRateId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectEmployee( _
                        ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountRoleId As Integer, ByVal AccountBillingRateId As Integer, Optional ByVal IsWebServiceCall As Boolean = False) As Boolean
        ' Create a new ProductRow instance

        _AccountProjectEmployeeTableAdapter = New AccountProjectEmployeeTableAdapter

        Dim AccountProjectEmployees As New TimeLiveDataSet.AccountProjectEmployeeDataTable
        Dim AccountProjectEmployee As TimeLiveDataSet.AccountProjectEmployeeRow = AccountProjectEmployees.NewAccountProjectEmployeeRow

        ' Add Newly AccountProjectId if it is from AddProject form
        If AccountProjectId = 0 Then
            Dim a As TimeLiveDataSet.IdentityQueryRow
            Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
            a = ad.GetAccountProjectLastId.Rows(0)
            AccountProjectId = a.LastId
        End If

        With AccountProjectEmployee
            .AccountId = AccountId
            .AccountProjectId = AccountProjectId
            .AccountEmployeeId = AccountEmployeeId
            .AccountRoleId = AccountRoleId
            .Item("AccountBillingRateId") = IIf(AccountBillingRateId = 0, System.DBNull.Value, AccountBillingRateId)
        End With

        AccountProjectEmployees.AddAccountProjectEmployeeRow(AccountProjectEmployee)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectEmployees)

        Dim AccountProjectPreferences As New AccountEmployeeProjectPreferencesBLL
        AccountProjectPreferences.AddAccountEmployeeProjectPreference(AccountEmployeeId, AccountProjectId, True, False)
        If Not IsWebServiceCall Then
            Me.AfterUpdate(AccountProjectId)
        End If

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' update project employee
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountRoleId"></param>
    ''' <param name="AccountBillingRateId"></param>
    ''' <param name="Original_AccountProjectEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectEmployee( _
                        ByVal AccountId As Integer, _
                        ByVal AccountProjectId As Integer, _
                        ByVal AccountEmployeeId As Integer, _
                        ByVal AccountRoleId As Integer, _
                        ByVal AccountBillingRateId As Integer, _
                        ByVal Original_AccountProjectEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim AccountProjectEmployees As TimeLiveDataSet.AccountProjectEmployeeDataTable = Adapter.GetDataByAccountProjectEmployeeId(Original_AccountProjectEmployeeId)
        Dim AccountProjectEmployee As TimeLiveDataSet.AccountProjectEmployeeRow = AccountProjectEmployees.Rows(0)

        With AccountProjectEmployee
            .AccountId = AccountId
            .AccountProjectId = AccountProjectId
            .AccountEmployeeId = AccountEmployeeId
            .AccountRoleId = AccountRoleId
            .AccountBillingRateId = AccountBillingRateId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountProjectEmployee)

        Me.AfterUpdate(AccountProjectId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' after update 
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <remarks></remarks>
    Public Sub AfterUpdate(ByVal AccountProjectId As Integer)
        CacheManager.ClearCache("AccountProjectEmployeeDataTable", "AccountProjectId=" & AccountProjectId, True)
        CacheManager.ClearCache("AccountProject", , True)

        Dim Project As New AccountProjectBLL()
        Project.AfterUpdate()

        Dim Party As New AccountPartyBLL()
        Party.AfterUpdate()
    End Sub
    ''' <summary>
    ''' delete project employee
    ''' </summary>
    ''' <param name="Original_AccountProjectEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectEmployeeId(ByVal Original_AccountProjectEmployeeId As Integer, Optional ByVal AccountProjectId As Integer = 0, Optional ByVal AccountEmployeeId As Integer = 0) As Boolean
        '' delete employee record for project team
        'Dim DeletedAccountProjectId = Adapter.GetDataByAccountProjectEmployeeId(Original_AccountProjectEmployeeId).Rows(0)("AccountEmployeeId")
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectEmployeeId)

        '' delete all Task record for select project
        Dim bll As New AccountProjectTaskEmployeeBLL
        Dim accountid As Integer
        Dim dttaskemployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable = bll.GetvueAccountProjectTaskEmployeeByAccountEmployeeIdandAccountProjectId(AccountEmployeeId, AccountProjectId)
        Dim drtaskemployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeRow
        If dttaskemployee.Rows.Count > 0 Then
            drtaskemployee = dttaskemployee.Rows(0)
            For Each drtaskemployee In dttaskemployee.Rows
                bll.DeleteAccountProjectTaskEmployeeId(drtaskemployee.AccountProjectTaskEmployeeId)
            Next
        End If

        Me.AfterUpdate(AccountProjectId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' insert blank rows
    ''' </summary>
    ''' <param name="dtBlank"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddBlankRowsInDataTable(ByVal dtBlank As vueAccountProjectEmployeeDataTable) As TimeLiveDataSet.vueAccountProjectEmployeeDataTable

        'Dim dtBlank As TexasGulfDataSet.QuotationDetailDataTable = Me.GetDetailQuotationsByQuotationId(-1)
        'dtBlank.Columns.Add("Product", GetType(System.String))
        Dim dr As vueAccountProjectEmployeeRow

        'Dim dtProjectRole As AccountProjectRoleDataTable = New AccountProjectRoleBLL().GetAccountProjectRolesByAccountProjectId(AccountProjectId)
        'Dim row As AccountProjectRoleRow

        'Dim row As InquiryDetailRow
        'For Each row In dtProjectRole.Rows
        'If row.NumberOfResources > 0 Then
        For n As Integer = 1 To 5

            dr = dtBlank.NewvueAccountProjectEmployeeRow
            dr.AccountId = DBUtilities.GetSessionAccountId
            dr.AccountEmployeeId = 0
            dr.AccountRoleId = 0
            dr.AccountProjectId = 0

            dtBlank.Rows.Add(dr)
        Next
        'End If
        'Next

        Return dtBlank
    End Function
    ''' <summary>
    ''' Return project employee
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetFilledRowsOfAccountProjectEmployee(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectEmployeeDataTable

        Dim Project As TimeLiveDataSet.AccountProjectRow = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId).Rows(0)

        If Project.ProjectBillingRateTypeId = 2 Then
            Me.DeleteNullAccountProjectEmployeeRows(AccountProjectId)
        End If

        Dim dtBlank As TimeLiveDataSet.AccountProjectEmployeeDataTable = Me.GetAccountProjectEmployeesByAccountProjectId(AccountProjectId)
        'dtBlank.Columns.Add("Product", GetType(System.String))
        Dim dr As AccountProjectEmployeeRow

        'Dim row As InquiryDetailRow
        Dim dtProjectRole As AccountProjectRoleDataTable = New AccountProjectRoleBLL().GetAccountProjectRolesByAccountProjectId(AccountProjectId)
        Dim row As AccountProjectRoleRow

        'Dim row As InquiryDetailRow
        Dim nRoles As Integer = 1
        For Each row In dtProjectRole.Rows
            If Not IsDBNull(row("NumberOfResources")) Then
                If row.NumberOfResources > 0 Then
                    Dim filtered() As DataRow = dtBlank.Select("AccountRoleId = " & row.AccountRoleId)
                    Dim filterdCount As Integer = filtered.Length

                    For count As Integer = 0 To row.NumberOfResources - filterdCount - 1
                        dr = dtBlank.NewAccountProjectEmployeeRow
                        dr.AccountId = DBUtilities.GetSessionAccountId
                        dr.AccountEmployeeId = 0
                        dr.AccountRoleId = row.AccountRoleId
                        dr.AccountProjectId = row.AccountProjectId
                        If IsDBNull(row("AccountBillingRateId")) Then
                            dr.AccountBillingRateId = 0
                        Else
                            dr.AccountBillingRateId = row.AccountBillingRateId
                        End If

                        dr.AccountProjectEmployeeId = -(nRoles * 1000) - 1 - count
                        dtBlank.Rows.Add(dr)
                    Next
                End If
            End If
            nRoles = nRoles + 1
        Next
        Return dtBlank
    End Function
    ''' <summary>
    ''' insert project employee
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTemplateId"></param>
    ''' <remarks></remarks>
    Public Sub InsertProjectEmployeesByProjectTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTemplateId As Integer)
        Adapter.InsertProjectEmployeesByProjectTemplate(AccountId, AccountProjectId, AccountProjectTemplateId)
    End Sub
    ''' <summary>
    ''' check project employee work type billing rate exist
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="SystemBillingRateTypeId"></param>
    ''' <param name="AccountProjectEmployeeId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IfWorkTypeBillingRateExistOfProjectEmployee(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As Boolean
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectEmployeeWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectEmployeeId, AccountWorkTypeId)

        If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Add import project employee
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub AddDefaultAccountProjectEmplyeeByImport(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer)
        Dim objAccountWorkType As New AccountWorkTypeBLL
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = objAccountWorkType.GetAccountWorkTypesByAccountId(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        If dtWorkType.Rows.Count > 0 Then
            drWorkType = dtWorkType.Rows(0)

            Dim objAccountProjectEmployeeBLL As New AccountProjectEmployeeBLL
            Dim objAccountBillingRate As New AccountBillingRateBLL

            If Me.IsProjectEmployeeExists(AccountId, AccountProjectId, AccountEmployeeId) Then
                Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(AccountId, AccountProjectId, drWorkType.AccountWorkTypeId, AccountEmployeeId)
                Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtProjectEmployee.Rows(0)
                If Not Me.GetProjectBillingRateTypeId(AccountProjectId) = 2 Then
                    objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, Nothing, Nothing)
                    If Me.GetProjectBillingRateTypeId(AccountProjectId) = 3 Then
                        For Each drWorkType In dtWorkType.Rows
                            objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                            objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                            Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                        Next
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Update work type billing rate
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="SystemBillingRateTypeId"></param>
    ''' <param name="AccountProjectEmployeeId"></param>
    ''' <param name="AccountBillingRateId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateWorkTypeBillingRateOfProjectEmployee(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectEmployeeId As Integer, ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer)

        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim objAccountProjectEmployee As New AccountProjectEmployeeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetEmployeeOwnWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectEmployeeId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow

        If objAccountProjectEmployee.IfWorkTypeBillingRateExistOfProjectEmployee(AccountId, SystemBillingRateTypeId, AccountProjectEmployeeId, AccountWorkTypeId) <> True Then
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, AccountProjectEmployeeId, 0, 0, AccountBillingRateId, AccountWorkTypeId)
        Else
            If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
                drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
                objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, AccountProjectEmployeeId, 0, 0, AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
            End If
        End If

    End Sub
    ''' <summary>
    ''' Get Billing Rate Type
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' check project employee exist
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsProjectEmployeeExists(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer) As Boolean
        If Adapter.GetDataByAccountIdProjectIdAndEmployeeId(AccountId, AccountEmployeeId, AccountProjectId).Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' check project employee exist for role
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountRoleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsProjectEmployeeExistsForRole(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountRoleId As Integer) As Boolean
        If Adapter.IsProjectEmployeeExistsForRole(AccountId, AccountProjectId, AccountEmployeeId, AccountRoleId).Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
End Class