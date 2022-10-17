Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountProjectTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountProjectBLL
    
    Private _AccountProjectTableAdapter As AccountProjectTableAdapter = Nothing
    Private _rptvueAccountProjectsReportTableAdapter As rptvueAccountProjectsReportTableAdapter = Nothing
    Dim strCacheKey As String

    Public Const PROJECT_BILLING_RATE_TYPE_ID_FROM_EMPLOYEE = 1
    Public Const PROJECT_BILLING_RATE_TYPE_ID_FROM_PROJECT_ROLE = 2
    Protected ReadOnly Property Adapter() As AccountProjectTableAdapter
        Get
            If _AccountProjectTableAdapter Is Nothing Then
                _AccountProjectTableAdapter = New AccountProjectTableAdapter()
            End If

            Return _AccountProjectTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjects() As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountId(ByVal AccountId As Integer, ByVal IsForAllClientProject As Boolean) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountIdAndIsForAllClientProject(AccountId, IsForAllClientProject)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetAccountProjectsByAccountIdAndDatabaseFieldName(AccountId, DatabaseFieldName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByTeamLeadIdOrProjectManagerId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountProjectDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectDataTable", "GetAccountProjectsByTeamLeadIdOrProjectManagerId", "AccountEmployeeId=" & AccountEmployeeId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectsByTeamLeadIdOrProjectManagerId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountProjectsByTeamLeadIdOrProjectManagerId = Adapter.GetDataByTeamLeadIdOrAccountProjectId(AccountEmployeeId)
            CacheManager.AddAccountDataInCache(GetAccountProjectsByTeamLeadIdOrProjectManagerId, strCacheKey)
        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectsRowsCount(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetProjectsRowsCount = _vueAccountProjectsTableAdapter.GetProjectsRowCount(AccountId)
        Return GetProjectsRowsCount
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsForGridView(ByVal AccountId As Integer, ByVal IsTemplate As Boolean, Optional ByVal Completed As String = "", Optional ByVal ProjectStatusId As Integer = 0, Optional ByVal Disabled As String = "", Optional ByVal AccountClientId As Integer = 0, Optional ByVal AccountProjectId As Integer = 0, Optional ByVal ProjectCode As String = "", Optional ByVal IsProjectAdd As Boolean = False) As TimeLiveDataSet.vueAccountProjectsDataTable

        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectsDataTable", "GetAccountProjectsForGridView", AccountId)
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        '    GetAccountProjectsForGridView = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        'If LocaleUtilitiesBLL.ShowCompletedProjectInProjectGrid = True Then
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(AccountId) Then
            GetAccountProjectsForGridView = _vueAccountProjectsTableAdapter.GetDataByAccountProjectsForGridViewFreeAccount(AccountId, IsTemplate, Completed, ProjectStatusId, Disabled, AccountClientId, AccountProjectId, ProjectCode, IsProjectAdd)
        Else
            GetAccountProjectsForGridView = _vueAccountProjectsTableAdapter.GetDataByAccountProjectsForGridView(AccountId, IsTemplate, Completed, ProjectStatusId, Disabled, AccountClientId, AccountProjectId, ProjectCode, IsProjectAdd)
        End If


        'CacheManager.AddAccountDataInCache(GetAccountProjectsForGridView, strCacheKey)
        'End If
        'UIUtilities.FixTableForNoRecords(GetAccountProjectsForGridView)
        Return GetAccountProjectsForGridView

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectsByAccountIdAndAccountProjectIdForNotDeleted(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        '''''''''''''''''Retruns 0 record if specific AccountProjectId isdeleted=1
        Dim _AccountProjectTableAdapter As New AccountProjectTableAdapter
        Return _AccountProjectTableAdapter.GetProjectsByAccountIdAndAccountProjectIdNotDeleted(AccountId, AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectsByAccountId(ByVal AccountId As Integer, ByVal IsTemplate As Boolean) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetDataByAccountId(AccountId, IsTemplate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountIdForGraph(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        Dim _AccountProjectTableAdapter As New AccountProjectTableAdapter
        GetAccountProjectsByAccountIdForGraph = _AccountProjectTableAdapter.GetAccountProjectsByAccountId(AccountId)
        Return GetAccountProjectsByAccountIdForGraph
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountIdAndAccountProjectIdForReport(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As AccountProject.rptvueAccountProjectsReportDataTable
        Dim _rptvueAccountProjectsReportTableAdapter As New rptvueAccountProjectsReportTableAdapter
        GetAccountProjectsByAccountIdAndAccountProjectIdForReport = _rptvueAccountProjectsReportTableAdapter.GetDataByAccountIdAndAccountProjectIdForReport(AccountId, AccountProjectId)
        Return GetAccountProjectsByAccountIdAndAccountProjectIdForReport
    End Function
    ''' <summary>
    ''' return all accountproject records of specified AccountId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns>AccountProjectsDataTable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountIdWithoutDeleted(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountIdWithoutDeleted(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountIdWithoutDeletedForIsDeleted(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountIdWithoutDeletedForIsDeleted(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTemplatesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetAccountProjectTemplatesByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectsTemplateByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetvueAccountProjectsTemplateByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeesForReport(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal IsActive As Integer, ByVal ProjectStatusId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetDataForProjectReport(AccountId, AccountClientId, IsActive, ProjectStatusId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectsForTimeEntryApproval(ByVal ApproverEmployeeId) As AccountProject.vueTimeEntryApprovalProjectsDataTable
        Dim _vueTimeEntryApprovalProjectsTableAdapter As New vueTimeEntryApprovalProjectsTableAdapter
        Return _vueTimeEntryApprovalProjectsTableAdapter.GetProjectsForTimeEntryApproval(ApproverEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectsForExpenseEntryApproval(ByVal ApproverEmployeeId) As AccountProject.vueExpenseEntryApprovalProjectsDataTable
        Dim _vueExpenseEntryApprovalProjectsTableAdapter As New vueExpenseEntryApprovalProjectsTableAdapter
        Return _vueExpenseEntryApprovalProjectsTableAdapter.GetProjectForExpenseEntryApproval(ApproverEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectByLeaderEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetDataByLeaderEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectByProjectManagerEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetDataByProjectManagerEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetVueAccountProjectForGraph(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As AccountProject.DataTable1DataTable
        Dim _vueAccountProjectsForGraphTableAdapter As New DataTable1TableAdapter
        GetVueAccountProjectForGraph = _vueAccountProjectsForGraphTableAdapter.GetDataByAccountIdandAccountProjectIdForGraph(AccountId, AccountProjectId)
        UIUtilities.FixTableForNoRecords(GetVueAccountProjectForGraph)
        Return GetVueAccountProjectForGraph
    End Function
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectLastId.Rows(0)
        Return a.LastId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeId(ByVal AccountEmployeeId As Integer, Optional ByVal Completed As String = "", Optional ByVal ProjectStatusId As Integer = 0, Optional ByVal Disabled As String = "", Optional ByVal AccountClientId As Integer = 0, Optional ByVal AccountProjectId As Integer = 0, Optional ByVal ProjectCode As String = "") As TimeLiveDataSet.vueAccountProjectsDataTable


        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectsDataTable", "GetAssignedAccountProjectsByAccountEmployeeId", AccountEmployeeId)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAssignedAccountProjectsByAccountEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
            GetAssignedAccountProjectsByAccountEmployeeId = _vueAccountProjectsTableAdapter.GetAssignedDataByAccountEmployeeIdForMyProjectsFreeAccount(DBUtilities.GetSessionAccountId, AccountEmployeeId, Completed, ProjectStatusId, Disabled, AccountClientId, AccountProjectId, ProjectCode)
        Else
            GetAssignedAccountProjectsByAccountEmployeeId = _vueAccountProjectsTableAdapter.GetAssignedDataByAccountEmployeeIdForMyProjects(DBUtilities.GetSessionAccountId, AccountEmployeeId, Completed, ProjectStatusId, Disabled, AccountClientId, AccountProjectId, ProjectCode)
        End If

        'CacheManager.AddAccountDataInCache(GetAssignedAccountProjectsByAccountEmployeeId, strCacheKey)
        'End If

        'UIUtilities.FixTableForNoRecords(GetAssignedAccountProjectsByAccountEmployeeId)

        Return GetAssignedAccountProjectsByAccountEmployeeId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdForMobile(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal Completed As String = "", Optional ByVal ProjectStatusId As Integer = 0, Optional ByVal Disabled As String = "", Optional ByVal AccountClientId As Integer = 0, Optional ByVal AccountProjectId As Integer = 0, Optional ByVal ProjectCode As String = "") As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjectsByAccountEmployeeIdForMobile = _vueAccountProjectsTableAdapter.GetAssignedDataByAccountEmployeeIdForMyProjects(AccountId, AccountEmployeeId, Completed, ProjectStatusId, Disabled, AccountClientId, AccountProjectId, ProjectCode)

        UIUtilities.FixTableForNoRecords(GetAssignedAccountProjectsByAccountEmployeeIdForMobile)

        Return GetAssignedAccountProjectsByAccountEmployeeIdForMobile
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdForReport(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetAssignedDataByAccountEmployeeId(DBUtilities.GetSessionAccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectCountByAccountProject(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountProject.vueAccountProjectsForGraphDataTable
        Dim vueProjectAdapterForGraph As New AccountProjectTableAdapters.vueAccountProjectsTableAdapterForGraph
        Return vueProjectAdapterForGraph.GetProjectCountByAccountProject(AccountId, AccountEmployeeId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal IsTemplate As Boolean = False) As TimeLiveDataSet.AccountProjectDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectDataTable", "GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId & "_IsTemplate=" & IsTemplate)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then

            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId = Adapter.GetAssignedDataByAccountEmployeeIdAndAccountProjectId(AccountId, IsTemplate, AccountProjectId, AccountEmployeeId)
            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId, strCacheKey)
        End If
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal IsTemplate As Boolean = False) As TimeLiveDataSet.vueAccountProjectsDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectsDataTable", "GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId & "_IsTemplate=" & IsTemplate)
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted = _vueAccountProjectsTableAdapter.GetAssignedDataByAccountEmployeeIdAndAccountProjectIdForIsDeleted(IsTemplate, AccountProjectId, AccountEmployeeId)
            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted, strCacheKey)
        End If
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjects(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.AccountProjectDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectDataTable", "GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjects", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId & "_IsTemplate=" & IsTemplate & "_Completed=" & Completed, AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjects = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _AccountProjectTableAdapter As New AccountProjectTableAdapter
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjects = _AccountProjectTableAdapter.GetAssignedDataByEmployeeIdProjectIdAndCompleted(AccountProjectId, AccountEmployeeId, Completed, IsTemplate, AccountId)
            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjects, strCacheKey)
        End If
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjects
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.vueAccountProjectsDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectsDataTable", "GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId & "_IsTemplate=" & IsTemplate & "_Completed=" & Completed, AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountProjectTableAdapter As New vueAccountProjectsTableAdapter
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient = _vueAccountProjectTableAdapter.GetAssignedDataByEmployeeIdProjectIdAndCompleted(AccountProjectId, AccountEmployeeId, Completed, IsTemplate, AccountId)
            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient, strCacheKey)
        End If
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndSelected(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjectsByAccountEmployeeIdAndSelected = _vueAccountProjectTableAdapter.GetAssignedDataByEmployeeIdProjectIDSelected(AccountProjectId, AccountEmployeeId, Completed, IsTemplate, AccountId)

        Return GetAssignedAccountProjectsByAccountEmployeeIdAndSelected
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjectsForImportExport(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1, Optional ByVal ProjectName As String = "") As TimeLiveDataSet.AccountProjectDataTable
        Dim _AccountProjectTableAdapter As New AccountProjectTableAdapter
        GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjectsForImportExport = _AccountProjectTableAdapter.GetAssignedDataByEmployeeIdProjectIdAndCompleted(AccountProjectId, AccountEmployeeId, Completed, IsTemplate, AccountId, True, ProjectName)
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjectsForImportExport
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientId(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientId = _vueAccountProjectsTableAdapter.GetAssignedDataByAccountEmployeeIdAndAccountClientId(AccountClientId, AccountProjectId, AccountEmployeeId)
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal Completed As Boolean, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.vueAccountProjectsDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectDataTable", "GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId & "_AccountClientId=" & AccountClientId & "_Completed=" & Completed, AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
            GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects = _vueAccountProjectsTableAdapter.GetAssignedDataByEmployeeIdClientIdAndCompleted(AccountProjectId, AccountEmployeeId, AccountClientId, Completed, AccountId)
            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects, strCacheKey)
        End If
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjects(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal IsTemplate As Boolean = False) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjects = _vueAccountProjectsTableAdapter.GetAssignedAccountProjects(IsTemplate, AccountProjectId, AccountEmployeeId)
        Return GetAssignedAccountProjects
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountEmployeeAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As TimeLiveDataSet.AccountProjectDataTable
        Return Adapter.GetDataByAccountEmployeeAndTimeEntryDate(AccountEmployeeId, StartDate, EndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectDataTable", "GetAccountProjectsByAccountProjectId", "AccountProjectId=" & AccountProjectId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectsByAccountProjectId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountProjectsByAccountProjectId = Adapter.GetDataByAccountProjectId(AccountProjectId)
            CacheManager.AddAccountDataInCache(GetAccountProjectsByAccountProjectId, strCacheKey)
        End If
        Return GetAccountProjectsByAccountProjectId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountClientByAccountProjectId(ByVal AccountClientId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetAccountClientByAccountProjectId(AccountClientId)
    End Function
    'GetAccountClientByAccountProjectIdandIsDisabled
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountClientByAccountProjectIdandIsDisabled(ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetAccountClientByAccountProjectIdandIsDisabled(AccountClientId, AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectByLastProjectCode(ByVal AccountId As Integer, ByVal ProjectPrefix As String) As TimeLiveDataSet.AccountProjectCodeDataTable
        Dim _AccountProjectCodeTableAdapter As New AccountProjectCodeTableAdapter
        GetAccountProjectByLastProjectCode = _AccountProjectCodeTableAdapter.GetDataByLastProjectCode(AccountId, ProjectPrefix)
        Return GetAccountProjectByLastProjectCode
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectByCheckProjectCode(ByVal AccountId As Integer, ByVal ProjectCode As String) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        Return _vueAccountProjectsTableAdapter.GetDataByAccountIdandProjectCode(AccountId, ProjectCode)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetVueAccountProjectForGraph(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As AccountProject.DataTable1DataTable
    '    Dim _vueAccountProjectsForGraphTableAdapter As New DataTable1TableAdapter
    '    Return _vueAccountProjectsForGraphTableAdapter.GetDataByAccountIdandAccountProjectIdForGraph(AccountId, AccountProjectId)
    'End Function

    Public Sub UpdateProjectManagerAndTeamLeadPreferences(ByVal AccountProjectId As Integer, ByVal TeamLeadId As Integer, ByVal ProjectManagerId As Integer, Optional ByVal OldTeamLeadId As Integer = 0, Optional ByVal OldProjectManagerId As Integer = 0)
        Dim PreferencesBLL As New AccountEmployeeProjectPreferencesBLL
        If OldTeamLeadId = 0 And OldProjectManagerId = 0 Then
            PreferencesBLL.AddAccountEmployeeProjectPreference(TeamLeadId, AccountProjectId, True, True)
            PreferencesBLL.AddAccountEmployeeProjectPreference(ProjectManagerId, AccountProjectId, True, True)
        Else
            If TeamLeadId <> OldTeamLeadId Then
                PreferencesBLL.AddAccountEmployeeProjectPreference(TeamLeadId, AccountProjectId, True, True)
            End If
            If ProjectManagerId <> OldProjectManagerId Then
                PreferencesBLL.AddAccountEmployeeProjectPreference(ProjectManagerId, AccountProjectId, True, True)
            End If
        End If
    End Sub
    Public Sub AfterUpdate(Optional ByVal AccountProjectId As Integer = 0)
        'CacheManager.ClearCache("AccountProject", , True)
        If DBUtilities.IsApplicationContext Then
            Dim str As String = "AccountProjectId=" & AccountProjectId
            CacheManager.ClearCache("vueAccountProjectsDataTable", str, True)
            CacheManager.ClearCache("AccountProjectDataTable", str, True)
            Call New AccountPartyBLL().AfterUpdate()
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProject( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal AccountProjectTypeId As System.Nullable(Of Integer), _
                    ByVal AccountClientId As System.Nullable(Of Integer), _
                    ByVal AccountPartyContactId As Integer, _
                    ByVal AccountPartyDepartmentId As Integer, _
                    ByVal ProjectBillingTypeId As System.Nullable(Of Integer), _
                    ByVal ProjectName As String, _
                    ByVal ProjectDescription As String, _
                    ByVal StartDate As Date, _
                    ByVal Deadline As Date, _
                    ByVal ProjectStatusId As System.Nullable(Of Integer), _
                    ByVal LeaderEmployeeId As System.Nullable(Of Integer), _
                    ByVal ProjectManagerEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeSheetApprovalTypeId As System.Nullable(Of Integer), _
                    ByVal ExpenseApprovalTypeId As System.Nullable(Of Integer), _
                    ByVal EstimatedDuration As Double, _
                    ByVal EstimatedDurationUnit As String, _
                    ByVal ProjectCode As String, _
                    ByVal DefaultBillingRate As Decimal, _
                    ByVal ProjectBillingRateTypeId As System.Nullable(Of Integer), _
                    ByVal IsTemplate As Boolean, _
                    ByVal IsProject As Boolean, _
                    ByVal AccountProjectTemplateId As Integer, _
                    ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal Completed As Boolean, _
                    ByVal ProjectPrefix As String, _
                    ByVal IsForAllClientProject As Boolean, _
                    ByVal ProjectEstimatedCost As Double, _
                    ByVal FixedCost As Double, _
                    Optional ByVal IsWebServiceCall As Boolean = False, _
                    Optional ByVal CustomField1 As String = "", _
                    Optional ByVal CustomField2 As String = "", _
                    Optional ByVal CustomField3 As String = "", _
                    Optional ByVal CustomField4 As String = "", _
                    Optional ByVal CustomField5 As String = "", _
                    Optional ByVal CustomField6 As String = "", _
                    Optional ByVal CustomField7 As String = "", _
                    Optional ByVal CustomField8 As String = "", _
                    Optional ByVal CustomField9 As String = "", _
                    Optional ByVal CustomField10 As String = "", _
                    Optional ByVal CustomField11 As String = "", _
                    Optional ByVal CustomField12 As String = "", _
                    Optional ByVal CustomField13 As String = "", _
                    Optional ByVal CustomField14 As String = "", _
                    Optional ByVal CustomField15 As String = "" _
                          ) As Boolean

        ' Create a new ProductRow instance


        _AccountProjectTableAdapter = New AccountProjectTableAdapter

        Dim AccountProjects As New TimeLiveDataSet.AccountProjectDataTable
        Dim AccountProject As TimeLiveDataSet.AccountProjectRow = AccountProjects.NewAccountProjectRow

        With AccountProject
            .AccountId = AccountId
            .AccountProjectTypeId = AccountProjectTypeId
            .AccountClientId = AccountClientId
            .AccountPartyContactId = AccountPartyContactId
            .AccountPartyDepartmentId = AccountPartyDepartmentId
            .ProjectBillingTypeId = ProjectBillingTypeId
            .ProjectName = ProjectName
            .ProjectDescription = ProjectDescription
            .StartDate = StartDate
            .Deadline = Deadline
            .ProjectStatusId = ProjectStatusId
            .LeaderEmployeeId = LeaderEmployeeId
            .ProjectManagerEmployeeId = ProjectManagerEmployeeId
            If TimeSheetApprovalTypeId.Value = 0 Then
                .Item("TimeSheetApprovalTypeId") = System.DBNull.Value
            Else
                .TimeSheetApprovalTypeId = TimeSheetApprovalTypeId
            End If

            If ExpenseApprovalTypeId.Value = 0 Then
                .Item("ExpenseApprovalTypeId") = System.DBNull.Value
            Else
                .ExpenseApprovalTypeId = ExpenseApprovalTypeId
            End If
            .ProjectEstimatedCost = ProjectEstimatedCost
            .EstimatedDuration = EstimatedDuration
            .EstimatedDurationUnit = EstimatedDurationUnit
            .ProjectCode = ProjectCode
            .DefaultBillingRate = DefaultBillingRate
            .ProjectBillingRateTypeId = ProjectBillingRateTypeId
            .IsTemplate = IsTemplate
            .FixedCost = FixedCost
            If IsTemplate <> True Then
                .IsProject = True
            Else
                .IsProject = False
            End If
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
            .ProjectPrefix = ProjectPrefix
            .IsForAllClientProject = IsForAllClientProject
            If AccountProjectTemplateId <> 0 Then
                .AccountProjectTemplateId = AccountProjectTemplateId
            End If
            .Completed = Completed
            If CustomField1 <> "" Then
                .CustomField1 = CustomField1
            Else
                .Item("CustomField1") = System.DBNull.Value
            End If
            If CustomField2 <> "" Then
                .CustomField2 = CustomField2
            Else
                .Item("CustomField2") = System.DBNull.Value
            End If
            If CustomField3 <> "" Then
                .CustomField3 = CustomField3
            Else
                .Item("CustomField3") = System.DBNull.Value
            End If
            If CustomField4 <> "" Then
                .CustomField4 = CustomField4
            Else
                .Item("CustomField4") = System.DBNull.Value
            End If
            If CustomField5 <> "" Then
                .CustomField5 = CustomField5
            Else
                .Item("CustomField5") = System.DBNull.Value
            End If
            If CustomField6 <> "" Then
                .CustomField6 = CustomField6
            Else
                .Item("CustomField6") = System.DBNull.Value
            End If
            If CustomField7 <> "" Then
                .CustomField7 = CustomField7
            Else
                .Item("CustomField7") = System.DBNull.Value
            End If
            If CustomField8 <> "" Then
                .CustomField8 = CustomField8
            Else
                .Item("CustomField8") = System.DBNull.Value
            End If
            If CustomField9 <> "" Then
                .CustomField9 = CustomField9
            Else
                .Item("CustomField9") = System.DBNull.Value
            End If
            If CustomField10 <> "" Then
                .CustomField10 = CustomField10
            Else
                .Item("CustomField10") = System.DBNull.Value
            End If
            If CustomField11 <> "" Then
                .CustomField11 = CustomField11
            Else
                .Item("CustomField11") = System.DBNull.Value
            End If
            If CustomField12 <> "" Then
                .CustomField12 = CustomField12
            Else
                .Item("CustomField12") = System.DBNull.Value
            End If
            If CustomField13 <> "" Then
                .CustomField13 = CustomField13
            Else
                .Item("CustomField13") = System.DBNull.Value
            End If
            If CustomField14 <> "" Then
                .CustomField14 = CustomField14
            Else
                .Item("CustomField14") = System.DBNull.Value
            End If
            If CustomField15 <> "" Then
                .CustomField15 = CustomField15
            Else
                .Item("CustomField15") = System.DBNull.Value
            End If
        End With

        AccountProjects.AddAccountProjectRow(AccountProject)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjects)

        If Not IsWebServiceCall Then
            AfterUpdate()
        End If

        Dim AccountProjectMilestones As New AccountProjectMilestoneBLL
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL

        Dim NewId As Integer = Me.GetLastInsertedId
        If AccountProjectTemplateId = 0 Then
            AccountProjectMilestones.AddAccountProjectMilestone(AccountId, NewId, System.Web.HttpContext.GetGlobalResourceObject("TimeLive.Web", "Default Milestone"), Deadline, Date.Now, CreatedByEmployeeId, Date.Now, ModifiedByEmployeeId, "", False, IsWebServiceCall)
        End If
        Me.UpdateProjectManagerAndTeamLeadPreferences(NewId, LeaderEmployeeId, ProjectManagerEmployeeId)
        If AccountProjectTemplateId = 0 Then
            objAccountEMailNotificationPreference.InsertDefaultAccountProjectEMailNotificationPreference(NewId)
        End If
        If AccountProjectTemplateId = 0 Then
            Me.AddDefaultAccountProjectEmplyee(AccountId, NewId, ProjectBillingRateTypeId, LeaderEmployeeId, ProjectManagerEmployeeId, IsWebServiceCall)
        End If
        If LocaleUtilitiesBLL.InsertDefaultTaskNameInProject Then
            Me.InsertDefaultTaskFromProjectCreation(Me.GetLastInsertedId)
        End If
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProject( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal AccountProjectTypeId As System.Nullable(Of Integer), _
                    ByVal AccountClientId As System.Nullable(Of Integer), _
                    ByVal AccountPartyContactId As Integer, _
                    ByVal AccountPartyDepartmentId As Integer, _
                    ByVal ProjectBillingTypeId As System.Nullable(Of Integer), _
                    ByVal ProjectName As String, _
                    ByVal ProjectDescription As String, _
                    ByVal StartDate As Date, _
                    ByVal DeadLine As Date, _
                    ByVal ProjectStatusId As System.Nullable(Of Integer), _
                    ByVal LeaderEmployeeId As System.Nullable(Of Integer), _
                    ByVal ProjectManagerEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeSheetApprovalTypeId As System.Nullable(Of Integer), _
                    ByVal ExpenseApprovalTypeId As System.Nullable(Of Integer), _
                    ByVal EstimatedDuration As Double, _
                    ByVal EstimatedDurationUnit As String, _
                    ByVal ProjectCode As String, _
                    ByVal DefaultBillingRate As Decimal, _
                    ByVal ProjectBillingRateTypeId As System.Nullable(Of Integer), _
                    ByVal IsTemplate As Boolean, _
                    ByVal IsProject As Boolean, _
                    ByVal AccountProjectTemplateId As Integer, _
                    ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal Original_AccountProjectId As Integer, _
                    ByVal IsDisabled As Boolean, _
                    ByVal Completed As Boolean, _
                    ByVal ProjectPrefix As String, _
                    ByVal IsForAllClientProject As Boolean, _
                    ByVal ProjectEstimatedCost As Double, _
                    ByVal FixedCost As Double, _
                    Optional ByVal CustomField1 As String = "", _
                    Optional ByVal CustomField2 As String = "", _
                    Optional ByVal CustomField3 As String = "", _
                    Optional ByVal CustomField4 As String = "", _
                    Optional ByVal CustomField5 As String = "", _
                    Optional ByVal CustomField6 As String = "", _
                    Optional ByVal CustomField7 As String = "", _
                    Optional ByVal CustomField8 As String = "", _
                    Optional ByVal CustomField9 As String = "", _
                    Optional ByVal CustomField10 As String = "", _
                    Optional ByVal CustomField11 As String = "", _
                    Optional ByVal CustomField12 As String = "", _
                    Optional ByVal CustomField13 As String = "", _
                    Optional ByVal CustomField14 As String = "", _
                    Optional ByVal CustomField15 As String = "" _
                      ) As Boolean
        Try


            ' Update the product record

            Dim AccountProjects As TimeLiveDataSet.AccountProjectDataTable = Adapter.GetDataByAccountProjectId(Original_AccountProjectId)
            Dim AccountProject As TimeLiveDataSet.AccountProjectRow = AccountProjects.Rows(0)

            Me.UpdateProjectManagerAndTeamLeadPreferences(Original_AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, AccountProject.LeaderEmployeeId, AccountProject.ProjectManagerEmployeeId)
            Dim EmpBll As New AccountProjectEmployeeBLL

            With AccountProject
                '.AccountId = AccountId
                .AccountProjectTypeId = AccountProjectTypeId
                .AccountClientId = AccountClientId
                .AccountPartyContactId = AccountPartyContactId
                .AccountPartyDepartmentId = AccountPartyDepartmentId
                .ProjectBillingTypeId = ProjectBillingTypeId
                .ProjectName = ProjectName
                If ProjectDescription <> "" Then
                    .ProjectDescription = ProjectDescription
                Else
                    .ProjectDescription = ""
                End If

                .StartDate = StartDate
                .Deadline = DeadLine

                .LeaderEmployeeId = LeaderEmployeeId

                .ProjectManagerEmployeeId = ProjectManagerEmployeeId

                .ProjectStatusId = ProjectStatusId
                .ProjectEstimatedCost = ProjectEstimatedCost


                If TimeSheetApprovalTypeId.Value = 0 Then
                    .Item("TimeSheetApprovalTypeId") = DBNull.Value
                Else
                    .TimeSheetApprovalTypeId = TimeSheetApprovalTypeId
                End If

                If ExpenseApprovalTypeId.Value = 0 Then
                    .Item("ExpenseApprovalTypeId") = DBNull.Value
                Else
                    .ExpenseApprovalTypeId = ExpenseApprovalTypeId
                End If

                .EstimatedDuration = EstimatedDuration
                .EstimatedDurationUnit = EstimatedDurationUnit
                'If DBUtilities.GetProjectCodePrefix <> True Then
                .ProjectCode = ProjectCode
                .ProjectPrefix = ProjectPrefix
                'End If
                .DefaultBillingRate = DefaultBillingRate
                If ProjectBillingRateTypeId.HasValue Then
                    .ProjectBillingRateTypeId = ProjectBillingRateTypeId
                End If
                .IsTemplate = IsTemplate
                .IsProject = IsProject
                .FixedCost = FixedCost
                If AccountProjectTemplateId <> 0 Then
                    .AccountProjectTemplateId = AccountProjectTemplateId
                End If
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
                .IsDisabled = IsDisabled
                .Completed = Completed
                .IsForAllClientProject = IsForAllClientProject
                If CustomField1 <> "" Then
                    .CustomField1 = CustomField1
                Else
                    .Item("CustomField1") = System.DBNull.Value
                End If
                If CustomField2 <> "" Then
                    .CustomField2 = CustomField2
                Else
                    .Item("CustomField2") = System.DBNull.Value
                End If
                If CustomField3 <> "" Then
                    .CustomField3 = CustomField3
                Else
                    .Item("CustomField3") = System.DBNull.Value
                End If
                If CustomField4 <> "" Then
                    .CustomField4 = CustomField4
                Else
                    .Item("CustomField4") = System.DBNull.Value
                End If
                If CustomField5 <> "" Then
                    .CustomField5 = CustomField5
                Else
                    .Item("CustomField5") = System.DBNull.Value
                End If
                If CustomField6 <> "" Then
                    .CustomField6 = CustomField6
                Else
                    .Item("CustomField6") = System.DBNull.Value
                End If
                If CustomField7 <> "" Then
                    .CustomField7 = CustomField7
                Else
                    .Item("CustomField7") = System.DBNull.Value
                End If
                If CustomField8 <> "" Then
                    .CustomField8 = CustomField8
                Else
                    .Item("CustomField8") = System.DBNull.Value
                End If
                If CustomField9 <> "" Then
                    .CustomField9 = CustomField9
                Else
                    .Item("CustomField9") = System.DBNull.Value
                End If
                If CustomField10 <> "" Then
                    .CustomField10 = CustomField10
                Else
                    .Item("CustomField10") = System.DBNull.Value
                End If
                If CustomField11 <> "" Then
                    .CustomField11 = CustomField11
                Else
                    .Item("CustomField11") = System.DBNull.Value
                End If
                If CustomField12 <> "" Then
                    .CustomField12 = CustomField12
                Else
                    .Item("CustomField12") = System.DBNull.Value
                End If
                If CustomField13 <> "" Then
                    .CustomField13 = CustomField13
                Else
                    .Item("CustomField13") = System.DBNull.Value
                End If
                If CustomField14 <> "" Then
                    .CustomField14 = CustomField14
                Else
                    .Item("CustomField14") = System.DBNull.Value
                End If
                If CustomField15 <> "" Then
                    .CustomField15 = CustomField15
                Else
                    .Item("CustomField15") = System.DBNull.Value
                End If
            End With


            Dim rowsAffected As Integer = Adapter.Update(AccountProject)


            AfterUpdate(Original_AccountProjectId)
            Me.AddAccountProjectEmplyeeForTemplate(DBUtilities.GetSessionAccountId, Original_AccountProjectId)
            ' Return true if precisely one row was updated, otherwise false
            Return rowsAffected = 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProject(ByVal Original_AccountProjectId As Integer) As Boolean
        'Call New AccountProjectRoleBLL().DeleteAccountProjectRolesByAccountProjectId(Original_AccountProjectId)
        Dim AccountProjects As TimeLiveDataSet.AccountProjectDataTable = Adapter.GetDataByAccountProjectId(Original_AccountProjectId)
        Dim AccountProject As TimeLiveDataSet.AccountProjectRow = AccountProjects.Rows(0)
        With AccountProject
            .IsDeleted = True
            .ModifiedOn = Now.Date
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        End With
        Dim rowsAffected As Integer = Adapter.Update(AccountProject)
        AfterUpdate()
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Shared Function GetProjectBillingRateTypeId(ByVal AccountProjectId As Integer) As Object

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
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProjectDescription(ByVal ProjectDescription As String, ByVal Original_AccountProjectId As Integer) As Boolean
        Dim AccountProjects As TimeLiveDataSet.AccountProjectDataTable = Adapter.GetDataByAccountProjectId(Original_AccountProjectId)
        Dim AccountProject As TimeLiveDataSet.AccountProjectRow = AccountProjects.Rows(0)

        With AccountProject
            .ProjectDescription = ProjectDescription
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountProject)
        ' Return true if precisely one row was updated, otherwise false

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByProjectCode(ByVal ProjectCode As String) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAccountProjectsByProjectCode = _vueAccountProjectsTableAdapter.GetDataByProjectCode(ProjectCode)
        Return GetAccountProjectsByProjectCode
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectsByAccountProjectId(ByVal AccountProjectId As String) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetvueAccountProjectsByAccountProjectId = _vueAccountProjectsTableAdapter.GetDataByAccountProjectId(AccountProjectId)
        Return GetvueAccountProjectsByAccountProjectId
    End Function
    Public Shared Sub SetDataForProjectDropdown(ByVal SystemSecurtiyCategoryPageId As Integer, ByVal DropDownName As DropDownList)
        'Dim bllAccountPagePermission As New AccountPagePermissionBLL
        'Dim dtAccountPagePermission As TimeLiveDataSet.vueAccountPagePermissionDataTable
        ''dtAccountPagePermission = bllAccountPagePermission.GetAccountPagePermissionViewByAccountId(DBUtilities.GetSessionAccountId, 5)
        'Dim drAccountPagePermission As TimeLiveDataSet.vueAccountPagePermissionRow = dtAccountPagePermission.Rows(0)
        Dim objDataView As New DataView()
        Dim bllAccountProject As New AccountProjectBLL
        Dim dtvueAccountProject As TimeLiveDataSet.vueAccountProjectsDataTable
        If AccountPagePermissionBLL.IsPageHasPermissionOfShowAllData(SystemSecurtiyCategoryPageId) = True Then
            dtvueAccountProject = bllAccountProject.GetvueAccountProjectsByAccountId(DBUtilities.GetSessionAccountId, False)

        ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyData(SystemSecurtiyCategoryPageId) = True Then
            dtvueAccountProject = bllAccountProject.GetAssignedAccountProjectsByAccountEmployeeIdForReport(DBUtilities.GetSessionAccountEmployeeId)
            'If DropDownName.Items.Count > 0 Then
            'DropDownName.Items.RemoveAt(0)
            'End If
        ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyTeamsData(SystemSecurtiyCategoryPageId) = True Then
            dtvueAccountProject = bllAccountProject.GetProjectByLeaderEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
            'If DropDownName.Items.Count > 0 Then
            'DropDownName.Items.RemoveAt(0)
            'End If
        ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyProjectsData(SystemSecurtiyCategoryPageId) = True Then
            dtvueAccountProject = bllAccountProject.GetProjectByProjectManagerEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
            'If DropDownName.Items.Count > 0 Then
            'DropDownName.Items.RemoveAt(0)
            'End If
        Else
            dtvueAccountProject = bllAccountProject.GetAssignedAccountProjectsByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
            'If DropDownName.Items.Count > 0 Then
            'DropDownName.Items.RemoveAt(0)
            'End If
        End If


        objDataView = dtvueAccountProject.DefaultView
        objDataView.Sort = "ProjectName"
        DropDownName.DataSource = objDataView
        DropDownName.DataBind()

    End Sub
    Public Sub AddDefaultAccountProjectEmplyee(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal ProjectBillingRateTypeId As System.Nullable(Of Integer), ByVal LeaderEmployeeId As System.Nullable(Of Integer), ByVal ProjectManagerEmployeeId As System.Nullable(Of Integer), Optional ByVal IsWebServiceCall As Boolean = False)
        Dim objAccountWorkType As New AccountWorkTypeBLL
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = objAccountWorkType.GetAccountWorkTypesByAccountId(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        If dtWorkType.Rows.Count > 0 Then
            drWorkType = dtWorkType.Rows(0)

            Dim objAccountProjectEmployeeBLL As New AccountProjectEmployeeBLL
            Dim objAccountBillingRate As New AccountBillingRateBLL

            If LeaderEmployeeId.Value <> 0 Then
                Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(AccountId, AccountProjectId, drWorkType.AccountWorkTypeId, LeaderEmployeeId)
                Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtProjectEmployee.Rows(0)
                If Not ProjectBillingRateTypeId.Value = 2 Then
                    objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, AccountProjectId, LeaderEmployeeId, Nothing, Nothing, IsWebServiceCall)
                    If ProjectBillingRateTypeId.Value = 3 Then
                        For Each drWorkType In dtWorkType.Rows
                            objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                            objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, AccountProjectId, LeaderEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                            Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                        Next
                    End If
                End If
            End If

            If ProjectManagerEmployeeId.Value <> 0 And LeaderEmployeeId.Value <> ProjectManagerEmployeeId.Value Then
                Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(AccountId, AccountProjectId, drWorkType.AccountWorkTypeId, ProjectManagerEmployeeId)
                Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtProjectEmployee.Rows(0)
                If Not ProjectBillingRateTypeId.Value = 2 Then
                    objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, AccountProjectId, ProjectManagerEmployeeId, Nothing, Nothing, IsWebServiceCall)
                    If ProjectBillingRateTypeId.Value = 3 Then
                        For Each drWorkType In dtWorkType.Rows
                            objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                            objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, AccountProjectId, ProjectManagerEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                            Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                        Next
                    End If
                End If
            End If
            Dim RoleBLL As New AccountRoleBLL
            Dim EmployeeBLL As New AccountEmployeeBLL
            If Not IsWebServiceCall Then
                Dim AccountEmployeeId As Integer = DBUtilities.GetSessionAccountEmployeeId
                If DBUtilities.AutomaticallyIncludeAdminitratorInProjectTeam = False Then
                    If AccountEmployeeId <> LeaderEmployeeId.Value And AccountEmployeeId <> ProjectManagerEmployeeId.Value Then
                        Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(AccountId, AccountProjectId, drWorkType.AccountWorkTypeId, AccountEmployeeId)
                        Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtProjectEmployee.Rows(0)
                        If Not ProjectBillingRateTypeId.Value = 2 Then
                            objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, Nothing, Nothing, IsWebServiceCall)
                            If ProjectBillingRateTypeId.Value = 3 Then
                                For Each drWorkType In dtWorkType.Rows
                                    objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                                    objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                                    Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                                Next
                            End If
                        End If
                    End If
                Else
                    Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountIdAndRole(DBUtilities.GetSessionAccountId, "Administrator")
                    Dim drEmployee As AccountEmployee.vueAccountEmployeeRow
                    If dtEmployee.Rows.Count > 0 Then
                        For Each drEmployee In dtEmployee.Rows
                            If drEmployee.AccountEmployeeId <> LeaderEmployeeId And drEmployee.AccountEmployeeId <> ProjectManagerEmployeeId Then
                                objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, AccountProjectId, drEmployee.AccountEmployeeId, Nothing, Nothing, IsWebServiceCall)
                            End If
                        Next
                    End If
                End If
            End If
        End If

    End Sub
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
    Public Shared Function IsAllowProjectNONE(ByVal AccountReportId As Guid)
        If LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "5ad7c2ee-4cbd-42a7-a4ff-394beaa47cf8" Then
            Return True
        ElseIf LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "3a080202-6842-4eca-8c79-a945978810b4" Then
            Return True
        ElseIf LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "07c1c8c9-c148-40c0-a700-af2fb1a0a149" Then
            Return True
        End If
        Return False
    End Function
    Public Shared Sub SetDataForProjectDropdownForCustomaizeReport(ByVal DropDownName As DropDownList, ByVal AccountReportId As Guid, ByVal AccountClientId As Integer)
        Dim ReportPermission As New ObjectPermissionBLL
        Dim objDataView As New DataView()
        Dim bllAccountProject As New AccountProjectBLL
        Dim dtvueAccountProject As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim WhereClause As String = ""
        Dim IsReportHasNoPermission As Boolean = False
        Dim chk As Boolean

        If DropDownName.Items(0).Value = 0 Then
            chk = True
        End If
        DropDownName.Items.Clear()
        If chk = True Then
            AddDropDownItem(ResourceHelper.GetFromResource("<All>"), 0, DropDownName)
        End If
        If IsAllowProjectNONE(AccountReportId) Then
            AddDropDownItem(ResourceHelper.GetFromResource("<None>"), -1, DropDownName)
        End If

        If ReportPermission.IsReportHasPermissionOfAllowOwnApproval(AccountReportId, True) = True Then
            If LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "ad0ea79d-c1d7-40ed-a7c4-03cc4f565873" Or LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "e3803dc0-49fd-4fc8-b414-ea264ffe85aa" Then
                SetProjectOwnApprovalPermission(DropDownName, AccountReportId)
                Return
            End If
        End If

        If ReportPermission.IsReportHasPermissionOfAllowAllUser(AccountReportId, True) Then
            WhereClause = bllAccountProject.GetAdministratorWhereClause(AccountClientId)
            IsReportHasNoPermission = True
        End If

        If ReportPermission.IsReportHasPermissionOfAllowOwnReport(AccountReportId, True) Then
            WhereClause = WhereClause & bllAccountProject.GetMyOwnWhereClause(0, AccountClientId, DBUtilities.GetSessionAccountEmployeeId, WhereClause)
            IsReportHasNoPermission = True
        End If

        If ReportPermission.IsReportHasPermissionOfAllowOwnTeam(AccountReportId, True) Then
            WhereClause = WhereClause & bllAccountProject.GetTeamLeadWhereClause(WhereClause, AccountClientId)
            IsReportHasNoPermission = True
        End If

        If ReportPermission.IsReportHasPermissionOfAllowOwnSubOrdinates(AccountReportId, True) Then
            WhereClause = WhereClause & bllAccountProject.GetEmployeeManagerWhereClause(WhereClause, AccountClientId, DBUtilities.GetSessionAccountEmployeeId)
            IsReportHasNoPermission = True
        End If

        If ReportPermission.IsReportHasPermissionOfAllowOwnProject(AccountReportId, True) Then
            WhereClause = WhereClause & bllAccountProject.GetProjectManagerWhereClause(WhereClause, AccountClientId)
            IsReportHasNoPermission = True
        End If

        If IsReportHasNoPermission = False Then
            dtvueAccountProject = bllAccountProject.GetAssignedAccountProjectsByAccountEmployeeIdForReport(DBUtilities.GetSessionAccountEmployeeId)
        Else
            Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
            If LocaleUtilitiesBLL.ShowDisableProjectInReport Then
                dtvueAccountProject = _vueAccountProjectsTableAdapter.GetvueAccountProjectsForReport(WhereClause, "IsDisabled,ProjectNameWithDisabled")
            Else
                dtvueAccountProject = _vueAccountProjectsTableAdapter.GetvueAccountProjectsForReport(WhereClause)
            End If

        End If


        objDataView = dtvueAccountProject.DefaultView
        If LocaleUtilitiesBLL.ShowDisableProjectInReport Then
            'objDataView.Sort = "ProjectName"
            DropDownName.DataTextField = "ProjectNameWithDisabled"
        Else
            objDataView.Sort = "ProjectName"
            DropDownName.DataTextField = "ProjectName"
        End If

        DropDownName.DataValueField = "AccountProjectId"
        DropDownName.DataSource = objDataView
        DropDownName.DataBind()

    End Sub
    Public Shared Sub SetProjectOwnApprovalPermission(ByVal DropdownName As DropDownList, ByVal AccountReportId As Guid)
        Dim ReportFiler As New ReportFilterBLL
        Dim objDataView As New DataView()
        Dim dt As New DataTable
        If LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "ad0ea79d-c1d7-40ed-a7c4-03cc4f565873" Then
            Dim dtvueApprovedBy As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
            dtvueApprovedBy = ReportFiler.GetApprovalProjectByAccountId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            dt = dtvueApprovedBy
        ElseIf LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "e3803dc0-49fd-4fc8-b414-ea264ffe85aa" Then
            Dim dtvueApprovedBy As dsReportFilterSource.ApprovedByExpenseFilterDataTable
            dtvueApprovedBy = ReportFiler.GetApprovalProjectByAccountIdForExpense(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            dt = dtvueApprovedBy
        End If
        objDataView = dt.DefaultView
        objDataView.Sort = "ProjectName"
        DropdownName.DataTextField = "ProjectName"
        DropdownName.DataValueField = "AccountProjectId"
        DropdownName.DataSource = objDataView
        DropdownName.DataBind()
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountClientId(ByVal AccountClientId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjectsByAccountClientId = _vueAccountProjectsTableAdapter.GetDataByAccountClientId(AccountClientId)
        Return GetAssignedAccountProjectsByAccountClientId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountClientIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjectsByAccountClientIdAndAccountEmployeeId = _vueAccountProjectsTableAdapter.GetAssignedDataByAccountClientIdAndAccountEmployeeIdForReport(AccountId, AccountClientId, AccountEmployeeId)
        Return GetAssignedAccountProjectsByAccountClientIdAndAccountEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByAccountIdForReport(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAccountProjectsByAccountIdForReport = _vueAccountProjectsTableAdapter.GetDataByAccountIdForReport(AccountId)
        Return GetAccountProjectsByAccountIdForReport
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectByAccountIdandAccountClientId(ByVal AccountId As Integer, ByVal AccountClientId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectsTableAdapter As New vueAccountProjectsTableAdapter
        GetAccountProjectByAccountIdandAccountClientId = _vueAccountProjectsTableAdapter.GetDataByAccountIdandAccountClientId(AccountId, AccountClientId)
        Return GetAccountProjectByAccountIdandAccountClientId
    End Function
    Public Shared Sub AddDropDownItem(ByVal Text As String, ByVal value As String, ByVal ddl As DropDownList)
        Dim item As New System.Web.UI.WebControls.ListItem
        ddl.AppendDataBoundItems = True
        item.Text = Text
        item.Value = value
        ddl.Items.Add(item)
    End Sub
    Public Function GetMyOwnWhereClause(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountEmployeeId As Integer, ByVal WhereClause As String) As String
        If WhereClause = "" Then
            If AccountClientId <> 0 Then
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & ")))) "

            Else
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & ")))) "
            End If
        Else
            If AccountClientId <> 0 Then
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & ")))) "
            Else
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & ")))) "
            End If
        End If
    End Function
    Public Function GetTeamLeadWhereClause(ByVal whereclause As String, ByVal AccountClientId As Integer) As String
        If whereclause = "" Then
            If AccountClientId <> 0 Then
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (LeaderEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            Else
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (LeaderEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            End If
        Else
            If AccountClientId <> 0 Then
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (LeaderEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            Else
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (LeaderEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            End If

        End If
    End Function
    Public Function GetProjectManagerWhereClause(ByVal whereclause As String, ByVal AccountClientId As Integer) As String
        If whereclause = "" Then
            If AccountClientId <> 0 Then
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (ProjectManagerEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            Else
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (ProjectManagerEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            End If
        Else
            If AccountClientId <> 0 Then
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (ProjectManagerEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            Else
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (IsTemplate <> 1) AND (ProjectManagerEmployeeId = " & DBUtilities.GetSessionAccountEmployeeId & ") " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
            End If
        End If
    End Function
    Public Function GetAdministratorWhereClause(ByVal AccountClientId As Integer) As String
        If AccountClientId = 0 Then
            Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (AccountId = " & DBUtilities.GetSessionAccountId & ") AND (IsTemplate <> 1) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
        Else
            Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) And (AccountClientId = " & AccountClientId & ") AND (IsTemplate <> 1) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & ") "
        End If
    End Function
    Public Function GetEmployeeManagerWhereClause(ByVal whereclause As String, ByVal AccountClientId As Integer, ByVal AccountEmployeeId As Integer) As String
        If whereclause = "" Then
            If AccountClientId <> 0 Then
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId IN (Select AccountEmployeeId FROM AccountEmployee WHERE EmployeeManagerId = " & AccountEmployeeId & " )))))"
            Else
                Return " WHERE ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId IN (Select AccountEmployeeId FROM AccountEmployee WHERE EmployeeManagerId = " & AccountEmployeeId & " )))))"
            End If
        Else
            If AccountClientId <> 0 Then
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountClientId = " & AccountClientId & ") AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId IN (Select AccountEmployeeId FROM AccountEmployee WHERE EmployeeManagerId = " & AccountEmployeeId & " )))))"
            Else
                Return " OR ((IsDeleted <> 1 Or IsDeleted Is NULL) And (IsDeletedClient <> 1 Or IsDeletedClient Is NULL) " & IIf(LocaleUtilitiesBLL.ShowDisableProjectInReport, "", "And (IsDisabled <> 1)") & " And (IsTemplate <> 1) AND (AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId IN (Select AccountEmployeeId FROM AccountEmployee WHERE EmployeeManagerId = " & AccountEmployeeId & " )))))"
            End If
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsForMobile(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        If DBUtilities.GetShowClientInTimesheet Then
            GetAccountProjectsForMobile = GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects(AccountProjectId, AccountEmployeeId, AccountClientId, LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet, AccountId)
        Else
            GetAccountProjectsForMobile = GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient(AccountProjectId, AccountEmployeeId, LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet, False, AccountId)
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsForTimer(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
        GetAccountProjectsForTimer = GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects(AccountProjectId, AccountEmployeeId, AccountClientId, LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectsByProjectName(ByVal AccountId As Integer, ByVal ProjectName As String) As TimeLiveDataSet.AccountProjectDataTable
        GetAccountProjectsByProjectName = Adapter.GetDataByAccountIdAndProjectName(ProjectName, AccountId)
        Return GetAccountProjectsByProjectName
    End Function
    Public Sub UpdateCustomFieldInProject(CustomFieldColumnName As String, AccountId As Integer)
        Adapter.UpdateProjectCustomFieldByCustomFieldId(CustomFieldColumnName, AccountId)
    End Sub
    Public Sub AddAccountProjectEmplyeeForTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        Dim LeaderEmployeeId As Integer
        Dim ProjectManagerEmployeeId As Integer
        Dim AdministratorId As Integer
        Dim ProjectBillingRateTypeId As Integer
        Dim ExpenseApprovalTypeId As Integer
        Dim TimesheetApprovalTypeId As Integer
        Dim objAccountWorkType As New AccountWorkTypeBLL
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable = objAccountWorkType.GetAccountWorkTypesByAccountId(AccountId)
        Dim drWorkType As TimeLiveDataSet.AccountWorkTypeRow
        If dtWorkType.Rows.Count > 0 Then
            drWorkType = dtWorkType.Rows(0)

            Dim objAccountProjectEmployeeBLL As New AccountProjectEmployeeBLL
            Dim ObjProjectBLL As New AccountProjectBLL
            Dim objAccountBillingRate As New AccountBillingRateBLL


            Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ObjProjectBLL.GetAccountProjectsByAccountProjectId(IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId))
            Dim drProject As TimeLiveDataSet.AccountProjectRow = dtProject.Rows(0)

            If dtProject.Rows.Count > 0 Then
                drProject = dtProject.Rows(0)
                LeaderEmployeeId = drProject.LeaderEmployeeId
                ProjectManagerEmployeeId = drProject.ProjectManagerEmployeeId
                ProjectBillingRateTypeId = drProject.ProjectBillingRateTypeId
                If Not IsDBNull(drProject.Item("TimeSheetApprovalTypeId")) Then
                    TimesheetApprovalTypeId = drProject.TimeSheetApprovalTypeId
                End If
                If Not IsDBNull(drProject.Item("ExpenseApprovalTypeId")) Then
                    ExpenseApprovalTypeId = drProject.ExpenseApprovalTypeId
                End If

            End If

            Dim dtprojectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(DBUtilities.GetSessionAccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), drWorkType.AccountWorkTypeId, LeaderEmployeeId)
            Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtprojectEmployee.Rows(0)

            If dtprojectEmployee.Rows.Count > 0 Then
                If IsDBNull(drProjectEmployee.Item("AccountProjectEmployeeId")) Then
                    If Not ProjectBillingRateTypeId = 2 Then
                        objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), LeaderEmployeeId, Nothing, Nothing)
                        If ProjectBillingRateTypeId = 3 Then
                            For Each drWorkType In dtWorkType.Rows
                                objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                                objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), LeaderEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                                Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                            Next
                        End If
                    End If
                End If
            End If

            Dim dtprojectEmployeePM As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(DBUtilities.GetSessionAccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), drWorkType.AccountWorkTypeId, ProjectManagerEmployeeId)
            Dim drProjectEmployeePM As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtprojectEmployeePM.Rows(0)

            If dtprojectEmployeePM.Rows.Count > 0 Then
                If IsDBNull(drProjectEmployeePM.Item("AccountProjectEmployeeId")) Then
                    If Not ProjectBillingRateTypeId = 2 Then
                        objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), ProjectManagerEmployeeId, Nothing, Nothing)
                        If ProjectBillingRateTypeId = 3 Then
                            For Each drWorkType In dtWorkType.Rows
                                objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                                objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), ProjectManagerEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                                Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                            Next
                        End If
                    End If
                End If
            End If

            Dim AccountEmployeeId As Integer = DBUtilities.GetSessionAccountEmployeeId
            If AccountEmployeeId <> LeaderEmployeeId And AccountEmployeeId <> ProjectManagerEmployeeId Then
                Dim dtprojectEmployeeAD As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesForSelectionByAccountEmployeeId(DBUtilities.GetSessionAccountId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId), drWorkType.AccountWorkTypeId, AccountEmployeeId)
                Dim drProjectEmployeeAD As TimeLiveDataSet.vueAccountProjectEmployeeRow = dtprojectEmployeePM.Rows(0)
                'If dtprojectEmployeeAD.Rows.Count > 0 Then
                '    If IsDBNull(drProjectEmployeeAD.Item("AccountProjectEmployeeId")) Then
                If Not ProjectBillingRateTypeId = 2 Then
                    Dim dtEmployee As TimeLiveDataSet.AccountProjectEmployeeDataTable = objAccountProjectEmployeeBLL.GetAccountProjectEmployeesByAccountProjectIdandAccountEmployeeId(DBUtilities.GetSessionAccountId, AccountEmployeeId, IIf(AccountProjectId = 0, Me.GetLastInsertedId, AccountProjectId))
                    If dtEmployee.Rows.Count = 0 Then
                        objAccountProjectEmployeeBLL.AddAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, Nothing, Nothing)

                        If ProjectBillingRateTypeId = 3 Then
                            For Each drWorkType In dtWorkType.Rows
                                objAccountBillingRate.AddAccountBillingRate(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, 0, 0, 0, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeBillingRate")), drProjectEmployee.Item("EmployeeBillingRate"), 0), Date.Now.Date, Date.Now.AddYears(1).Date, drWorkType.AccountWorkTypeId, IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeEmployeeRate")), drProjectEmployee.Item("EmployeeEmployeeRate"), 0), IIf(Not IsDBNull(drProjectEmployee.Item("BillingRateCurrencyId")), drProjectEmployee.Item("BillingRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId), IIf(Not IsDBNull(drProjectEmployee.Item("EmployeeRateCurrencyId")), drProjectEmployee.Item("EmployeeRateCurrencyId"), DBUtilities.GetAccountBaseCurrencyId))
                                objAccountProjectEmployeeBLL.UpdateAccountProjectEmployee(AccountId, AccountProjectId, AccountEmployeeId, Nothing, objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployeeBLL.GetLastInsertedId)
                                Me.UpdateWorkTypeBillingRateOfProjectEmployee(AccountId, 3, objAccountProjectEmployeeBLL.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, drWorkType.AccountWorkTypeId)
                            Next
                            '    End If
                            'End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Function GetShowAdditionalProjectInformationValue(ByVal TypeId As Integer, ByVal AccountProjectId As Integer, ByVal ProjectCode As String) As String
        If TypeId = 1 Then
            Return ProjectCode
        End If
        Return ""
    End Function
    Public Function GetProjectNameByAccountProjectId(ByVal AccountProjectId As Integer)
        Dim dt As TimeLiveDataSet.AccountProjectDataTable = Adapter.GetDataByAccountProjectId(AccountProjectId)
        Dim dr As TimeLiveDataSet.AccountProjectRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("ProjectName")) Then
                Return dr.ProjectName
            End If
        End If
    End Function
    Public Function GetProjectCodeByAccountProjectId(ByVal AccountProjectId As Integer)
        Dim dt As TimeLiveDataSet.AccountProjectDataTable = Adapter.GetDataByAccountProjectId(AccountProjectId)
        Dim dr As TimeLiveDataSet.AccountProjectRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("ProjectCode")) Then
                Return dr.ProjectCode
            End If
        End If
    End Function
    Public Function IsEmployeeExistInProjectTeam(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As Boolean
        Dim EmployeeBll As New AccountProjectEmployeeBLL
        Dim dtEmployee As TimeLiveDataSet.AccountProjectEmployeeDataTable = EmployeeBll.GetAccountProjectEmployeesByAccountProjectIdandAccountEmployeeId(DBUtilities.GetSessionAccountId, AccountEmployeeId, AccountProjectId)
        If dtEmployee.Rows.Count > 0 Then
            Return True
        Else
            EmployeeBll.AddAccountProjectEmployee(DBUtilities.GetSessionAccountId, AccountProjectId, AccountEmployeeId, Nothing, Nothing)
            Return False
        End If
        Return False
    End Function
    Public Sub InsertDefaultTaskFromProjectCreation(AccountProjectId As Integer)
        Dim ProjectTask As New AccountProjectTaskBLL
        Dim AccountTaskTypeId As Integer = New TimeLiveFileHelperTableAdapters.AccountTaskTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountTaskTypeId")
        Dim TaskStatusId As Integer = New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountStatusId")
        Dim AccountPriorityId As Integer = New TimeLiveFileHelperTableAdapters.AccountPriorityTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountPriorityId")
        Dim EstimatedCurrencyId As Integer = New AccountCurrencyTableAdapters.AccountCurrencyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountCurrencyId")
        Dim AccountProjectMilestoneId As Integer = New TimeLiveFileHelperTableAdapters.AccountProjectMilestoneTableAdapter().GetDataByAccountProjectId(AccountProjectId).Rows(0)("AccountProjectMilestoneId")
        ProjectTask.AddAccountProjectTask(AccountProjectId, Nothing, IIf(LocaleUtilitiesBLL.DefaultTaskName = "", "Default Task", LocaleUtilitiesBLL.DefaultTaskName), IIf(LocaleUtilitiesBLL.DefaultTaskName = "", "Default Task", LocaleUtilitiesBLL.DefaultTaskName), AccountTaskTypeId, 8, _
                                          "Hours", 0, False, Now.Date.AddDays(1), TaskStatusId, AccountPriorityId, AccountProjectMilestoneId, True, _
                                          False, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, 0, 0, "", True, IIf(LocaleUtilitiesBLL.DefaultTaskName = "", "Default Task", LocaleUtilitiesBLL.DefaultTaskName), 0, False, EstimatedCurrencyId, Now.Date, 0)
    End Sub
    Public Function GetFirstProject(ByVal AccountId As Integer, ByVal IsForAllClientProject As Boolean) As Integer
        Dim BLL As New AccountProjectBLL
        Dim dt As TimeLiveDataSet.AccountProjectDataTable = BLL.GetAccountProjectsByAccountId(AccountId, IsForAllClientProject)
        Dim dr As TimeLiveDataSet.AccountProjectRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountProjectId
        End If
    End Function

    Public Function InsertDefaultProject(ByVal AccountId As Integer, ByVal AccountProjectTypeId As Integer, ByVal AccountClientId As Integer, _
                    ByVal AccountPartyContactId As Integer, ByVal AccountPartyDepartmentId As Integer, ByVal ProjectBillingTypeId As Integer, ByVal ProjectName As String, _
                    ByVal ProjectDescription As String, ByVal StartDate As Date, ByVal Deadline As Date, ByVal ProjectStatusId As Integer, ByVal LeaderEmployeeId As Integer, _
                    ByVal ProjectManagerEmployeeId As Integer, ByVal TimeSheetApprovalTypeId As Integer, ByVal ExpenseApprovalTypeId As Integer, _
                    ByVal EstimatedDuration As Double, ByVal EstimatedDurationUnit As String, ByVal ProjectCode As String, ByVal DefaultBillingRate As Decimal, ByVal ProjectBillingRateTypeId As Integer, _
                    ByVal IsTemplate As Boolean, ByVal IsProject As Boolean, ByVal AccountProjectTemplateId As Integer, ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Completed As Boolean, ByVal ProjectPrefix As String, _
                    ByVal IsForAllClientProject As Boolean) As Integer

        Return Adapter.InsertQuery(AccountId, AccountProjectTypeId, AccountClientId, ProjectBillingTypeId, ProjectName, ProjectDescription, StartDate, Deadline, LeaderEmployeeId, ProjectCode, DefaultBillingRate, CreatedOn, CreatedByEmployeeId, ProjectManagerEmployeeId, EstimatedDurationUnit, ProjectStatusId, ProjectBillingRateTypeId, IsForAllClientProject, ModifiedOn, ModifiedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForMobile(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.vueAccountProjectsDataTable
        Dim _vueAccountProjectTableAdapter As New vueAccountProjectsTableAdapter
        GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForMobile = _vueAccountProjectTableAdapter.GetAssignedDataByEmployeeIdProjectIdAndCompleted(AccountProjectId, AccountEmployeeId, Completed, IsTemplate, AccountId)
        Return GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForMobile
    End Function
    Public Function IsCheckProjectRowsForLicense(AccountId As Integer) As Boolean
        Dim BLL As New AccountProjectBLL
        Dim dt As TimeLiveDataSet.vueAccountProjectsDataTable = BLL.GetProjectsRowsCount(AccountId)
        If dt.Rows.Count > 3 Then
            Return True
        End If
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetTimeOffInternalProjects() As TimeLiveDataSet.vueAccountProjectsDataTable

        Dim _vueAccountProjectTableAdapter As New vueAccountProjectsTableAdapter

        Return _vueAccountProjectTableAdapter.GetTimeOffInternalProjects()
    End Function
End Class
