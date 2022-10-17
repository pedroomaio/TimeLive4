Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountProjectTaskTableAdapters
Imports System.Data.SqlClient
Imports TimeLiveDataSet
Imports ProjectTaskForGraphTableAdapter

<System.ComponentModel.DataObject()> _
Public Class AccountProjectTaskBLL

    Private _AccountProjectTaskTableAdapter As AccountProjectTaskTableAdapter = Nothing
    Private _ViewAccountProjectTaskAdapter As vueAccountProjectTaskEmployeeForFullJoin1TableAdapter
    Private _ViewAccountProjectTaskWithPreferencesAdapter As vueAccountProjectTaskWithPreferencesTableAdapter
    Private _AccountProjectTaskForQBTableAdapter As vueAccountProjectTaskForQBTableAdapter

    Dim strCacheKey As String
    Dim Name As String
    Protected ReadOnly Property Adapter() As AccountProjectTaskTableAdapter
        Get
            If _AccountProjectTaskTableAdapter Is Nothing Then
                _AccountProjectTaskTableAdapter = New AccountProjectTaskTableAdapter()
            End If

            Return _AccountProjectTaskTableAdapter
        End Get
    End Property

    Protected ReadOnly Property ViewAdapter() As vueAccountProjectTaskEmployeeForFullJoin1TableAdapter
        Get
            If _ViewAccountProjectTaskAdapter Is Nothing Then
                _ViewAccountProjectTaskAdapter = New vueAccountProjectTaskEmployeeForFullJoin1TableAdapter()
            End If

            Return _ViewAccountProjectTaskAdapter
        End Get
    End Property

    Protected ReadOnly Property ViewAdapterPreferences() As vueAccountProjectTaskWithPreferencesTableAdapter
        Get
            If _ViewAccountProjectTaskWithPreferencesAdapter Is Nothing Then
                _ViewAccountProjectTaskWithPreferencesAdapter = New vueAccountProjectTaskWithPreferencesTableAdapter
            End If

            Return _ViewAccountProjectTaskWithPreferencesAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasks() As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountIdByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetAccountIdByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectTaskId(AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTasksByAccountProjectTaskId(AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetDataByvueAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectTaskEstCostByAccountId(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As ProjectTaskForGraph.AccountProjectTaskEstCostForGraphDataTable
        Dim ProjectTaskForGraphTableAdapter As New ProjectTaskForGraphTableAdapters.AccountProjectTaskEstCostFroGraphTableAdapter
        Return ProjectTaskForGraphTableAdapter.GetProjectTaskEstCostByAccountId(AccountId, AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectTasksCountByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.MyProjectTasksCountDataTable
        Dim MyProjectTasksCountTableAdapter As New TimeLiveDataSetTableAdapters.MyProjectTasksCountTableAdapter

        GetProjectTasksCountByAccountEmployeeId = MyProjectTasksCountTableAdapter.GetDataForMyProjectTasksCount(AccountEmployeeId)

        UIUtilities.FixTableForNoRecords(GetProjectTasksCountByAccountEmployeeId)

        Return GetProjectTasksCountByAccountEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTaskCountByProjectTask(ByVal AccountEmployeeId As Integer) As AccountProjectTask.vueAccountProjectTaskForGraphDataTable
        Dim vueTaskAdapterForGraph As New AccountProjectTaskTableAdapters.vueAccountProjectTaskForGraphTableAdapterForGraph
        Return vueTaskAdapterForGraph.GetDataByAccountId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTypesByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTaskDataTable", "GetAccountProjectTypesByAccountProjectTaskId", "AccountProjectTaskId=" & AccountProjectTaskId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectTypesByAccountProjectTaskId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountProjectTypesByAccountProjectTaskId = Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
            CacheManager.AddAccountDataInCache(GetAccountProjectTypesByAccountProjectTaskId, strCacheKey)
        End If
        Return GetAccountProjectTypesByAccountProjectTaskId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountIdAndDatabaseFieldName(AccountId, DatabaseFieldName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectTasksByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetAccountProjectTasksByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByParentAccountProjectTaskId(ByVal Original_AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByParentAccountProjectTaskId(Original_AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectIdAndParentAccountProjectTaskId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetAccountProjectTasksByAccountProjectIdAndParentAccountProjectTaskId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskByvueAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        Return vueAdapter.GetDataByvueAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskByAccountIdAndIsDisabled(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        Return vueAdapter.GetAccountProjectTaskByAccountIdAndIsDisabled(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskByAccountId(ByVal AccountId As Integer) As AccountProjectTask.vueAccountProjectTaskForQBDataTable
        Dim _vueAccountProjectTaskForQBTableAdapter As New vueAccountProjectTaskForQBTableAdapter
        Return _vueAccountProjectTaskForQBTableAdapter.GetTasksByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskAddEMailByvueAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        Return vueAdapter.GetDataByvueAccountProjectTaskIdAddEMail(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskUpdateEMailByvueAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        Return vueAdapter.GetDataByvueAccountProjectTaskIdUpdateEMail(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectIdCascading(ByVal AccountProjectId As Integer, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.AccountProjectTaskDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTaskDataTable", "GetAccountProjectTasksByAccountProjectIdCascading", "AccountProjectId=" & AccountProjectId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectTasksByAccountProjectIdCascading = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountProjectTasksByAccountProjectIdCascading = Adapter.GetDataByAccountProjectId(AccountProjectId)
            CacheManager.AddAccountDataInCache(GetAccountProjectTasksByAccountProjectIdCascading, strCacheKey)
        End If
        If NotFixTable = False Then
            UIUtilities.FixTableForNoRecords(GetAccountProjectTasksByAccountProjectIdCascading)
        End If

        Return GetAccountProjectTasksByAccountProjectIdCascading
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectIdForService(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetAssignedAccountProjectTasksByAccountProjectIdForService = vueAdapter.GetAssignedDataByAccountProjectIdAndIsDisabled(AccountProjectId, AccountProjectTaskId, AccountEmployeeId)

        Return GetAssignedAccountProjectTasksByAccountProjectIdForService
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectIdForReports(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetAssignedAccountProjectTasksByAccountProjectIdForReports = vueAdapter.GetAssignedDataByAccountProjectIdForReports(AccountProjectId, AccountProjectTaskId, AccountEmployeeId)

        Return GetAssignedAccountProjectTasksByAccountProjectIdForReports
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForReports(ByVal AccountProjectId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForReports = vueAdapter.GetDataByAccountIdAndAccountProjectId(AccountProjectId, AccountId)

        Return GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForReports
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetParentTasksByAccountProjectIdForInvoice(ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetParentTasksByAccountProjectIdForInvoice = vueAdapter.GetParentTaskByAccountProjectIdForInvoice(AccountProjectId, DBUtilities.GetSessionAccountId)

        Return GetParentTasksByAccountProjectIdForInvoice
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForInvoice(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, Optional ByVal AccountProjectTaskId As Integer = 0) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForInvoice = vueAdapter.GetAssignedDataByAccountProjectIdForInvoice(AccountProjectId, AccountId, AccountProjectTaskId)

        Return GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForInvoice
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedParentAccountProjectTasksByAccountProjectIdAndAccountIdForGridView(ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetAssignedParentAccountProjectTasksByAccountProjectIdAndAccountIdForGridView = vueAdapter.GetAssignedDataByAccountProjectIdForParentTask(AccountProjectId, DBUtilities.GetSessionAccountId)

        Return GetAssignedParentAccountProjectTasksByAccountProjectIdAndAccountIdForGridView
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectId(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTaskDataTable", "GetAssignedAccountProjectTasksByAccountProjectId", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedAccountProjectTasksByAccountProjectId = CacheManager.GetItemFromCache(strCacheKey)
        Else

            GetAssignedAccountProjectTasksByAccountProjectId = Adapter.GetAssignedDataByAccountProjectId(AccountProjectId, AccountEmployeeId)

            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectTasksByAccountProjectId, strCacheKey)
        End If

        Return GetAssignedAccountProjectTasksByAccountProjectId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectIdForMobile(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        GetAssignedAccountProjectTasksByAccountProjectIdForMobile = vueAdapter.GetAssignedDataByAccountProjectId(AccountId, AccountProjectId, AccountEmployeeId)
        Return GetAssignedAccountProjectTasksByAccountProjectIdForMobile
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountProjectIdAndIsDisabled(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTaskDataTable", "GetAssignedAccountProjectTasksByAccountProjectIdAndIsDisabled", "AccountProjectId=" & AccountProjectId & "_AccountEmployeeId=" & AccountEmployeeId & "_AccountProjectTaskId=" & AccountProjectTaskId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedAccountProjectTasksByAccountProjectIdAndIsDisabled = CacheManager.GetItemFromCache(strCacheKey)
        Else

            GetAssignedAccountProjectTasksByAccountProjectIdAndIsDisabled = Adapter.GetAssignedDataByAccountProjectIdAndIsDisabled(AccountProjectTaskId, AccountProjectId, AccountEmployeeId)

            CacheManager.AddAccountDataInCache(GetAssignedAccountProjectTasksByAccountProjectIdAndIsDisabled, strCacheKey)
        End If

        Return GetAssignedAccountProjectTasksByAccountProjectIdAndIsDisabled
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetInCompletedAssignedAccountProjectTasksByAccountProjectId(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable

        GetInCompletedAssignedAccountProjectTasksByAccountProjectId = Adapter.GetInCompletedAssignedDataByAccountProjectId(AccountProjectId, AccountEmployeeId)


        Return GetInCompletedAssignedAccountProjectTasksByAccountProjectId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedProjectTasksFromvueAccountProjectTask(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountId As Integer, ByVal Completed As Boolean) As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTaskTimesheetDataTable", "GetAssignedProjectTasksFromvueAccountProjectTask", "AccountEmployeeId=" & AccountEmployeeId & "_AccountProjectId=" & AccountProjectId & "_AccountProjectTaskId=" & AccountProjectTaskId & "_AccountId=" & AccountId & "_Completed=" & Completed, AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAssignedProjectTasksFromvueAccountProjectTask = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim vueAdapter As New TimeLiveDataSetTableAdapters.AccountProjectTaskTimesheetTableAdapter
            GetAssignedProjectTasksFromvueAccountProjectTask = vueAdapter.GetAssignedProjectTasksFromvueAccountProjectTask(AccountId, AccountEmployeeId, AccountProjectId, AccountProjectTaskId, Completed)

            CacheManager.AddAccountDataInCache(GetAssignedProjectTasksFromvueAccountProjectTask, strCacheKey)
        End If

        Return GetAssignedProjectTasksFromvueAccountProjectTask
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedProjectTasksFromvueAccountProjectTaskForCLient(ByVal AccountClientId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountId As Integer, ByVal Completed As Boolean) As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTaskTimesheetDataTable", "GetAssignedProjectTasksFromvueAccountProjectTaskForCLient", "AccountEmployeeId=" & AccountEmployeeId & "_AccountClientId=" & AccountClientId & "_AccountProjectTaskId=" & AccountProjectTaskId & "_AccountId=" & AccountId & "_Completed=" & Completed, AccountId)
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAssignedProjectTasksFromvueAccountProjectTaskForCLient = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.AccountProjectTaskTimesheetTableAdapter
        GetAssignedProjectTasksFromvueAccountProjectTaskForCLient = vueAdapter.GetAssignedProjectTasksFromvueAccountProjectTaskForCLient(AccountId, AccountEmployeeId, AccountClientId, AccountProjectTaskId, Completed)
        'CacheManager.AddAccountDataInCache(GetAssignedProjectTasksFromvueAccountProjectTaskForCLient, strCacheKey)
        'End If
        Return GetAssignedProjectTasksFromvueAccountProjectTaskForCLient
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedProjectTasksFromvueAccountProjectTaskForTimesheetTaskDropdown(ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountId As Integer, ByVal Completed As Boolean) As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.AccountProjectTaskTimesheetTableAdapter
        GetAssignedProjectTasksFromvueAccountProjectTaskForTimesheetTaskDropdown = vueAdapter.GetAssignedProjectTasksFromvueAccountProjectTaskForTimesheetTaskDropdown(AccountId, AccountEmployeeId, AccountProjectTaskId, Completed)
        Return GetAssignedProjectTasksFromvueAccountProjectTaskForTimesheetTaskDropdown
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedProjectTasksForImportExport(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountId As Integer, ByVal Completed As Boolean, ByVal TaskName As String) As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.AccountProjectTaskTimesheetTableAdapter
        GetAssignedProjectTasksForImportExport = vueAdapter.GetAssignedProjectTasksFromvueAccountProjectTask(AccountId, AccountEmployeeId, AccountProjectId, AccountProjectTaskId, Completed, True, TaskName)
        Return GetAssignedProjectTasksForImportExport
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetParentAccountProjectTasksByAccountProjectId(ByVal AccountProjectId As Integer, ByVal ParentAccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetParentDataByAccountProjectId(AccountProjectId, ParentAccountProjectTaskId)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    ' Public Function GetParentAccountProjectTasksByAccountProjectIdAndIsDisabled(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
    '    Return Adapter.GetParentDataByAccountProjectIdAndIsDisabled(AccountProjectId, AccountProjectTaskId)
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForTaskSummary(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountTaskTypeId As Integer) As TimeLiveDataSet.vueAccountProjectTaskForReportDataTable
        Dim _vueAccountProjectTaskForReportTableAdapter As New vueAccountProjectTaskForReportTableAdapter
        Return _vueAccountProjectTaskForReportTableAdapter.GetDataForTaskSummary(AccountId, AccountProjectId, AccountTaskTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskEmployeeEmail(ByVal AccountProjectTaskId) As TimeLiveDataSet.vueAccountProjectTaskEmployeeEmailDataTable
        Dim _vueAccountProjectTaskEmployeeEmailTableAdapter As New vueAccountProjectTaskEmployeeEmailTableAdapter
        Return _vueAccountProjectTaskEmployeeEmailTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskEmail(ByVal AccountProjectTaskId) As TimeLiveDataSet.vueAccountProjectTaskEmailDataTable
        Dim _vueAccountProjectTaskEmailTableAdapter As New vueAccountProjectTaskEmailTableAdapter
        Return _vueAccountProjectTaskEmailTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskEmployeeUpdateEmail(ByVal AccountProjectTaskId) As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailDataTable
        Dim _vueAccountProjectTaskEmployeeUpdateEmailTableAdapter As New vueAccountProjectTaskEmployeeUpdateEmailTableAdapter
        Return _vueAccountProjectTaskEmployeeUpdateEmailTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskUpdateEmail(ByVal AccountProjectTaskId) As TimeLiveDataSet.vueAccountProjectTaskUpdateEmailDataTable
        Dim _vueAccountProjectTaskUpdateEmailTableAdapter As New vueAccountProjectTaskUpdateEmailTableAdapter
        Return _vueAccountProjectTaskUpdateEmailTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksForTaskSearch(ByVal AccountProjectTaskId As Long, ByVal AccountProjects As String, ByVal AccountTaskTypeId As Integer, ByVal ReportedBy As Integer, ByVal IncludeDateRange As String, ByVal CreatedDateFrom As Date, ByVal CreatedDateUpto As Date, ByVal AssignedTo As Integer, ByVal TaskStatusId As Integer, ByVal CompletedStatus As String, ByVal Description As String, ByVal AccountId As Integer, ByVal AccountProjectMilestoneId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal IsTaskAdd As Boolean = False) As TimeLiveDataSet.vueAccountProjectTaskDataTable


        If Description = Nothing Then
            Description = ""
        End If

        If Description <> "" Then
            Description = "%" & Description & "%"
        End If

        If AccountProjectTaskId = 0 Then
            AccountProjectTaskId = -1
        End If

        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter

        GetAccountProjectTasksForTaskSearch = Me.GetDataTableFillWithAssignedTo(_vueAccountProjectTaskTableAdapter.GetDataTaskSearchForMyTask(AccountId, AccountProjectTaskId, AccountProjectMilestoneId, AccountTaskTypeId, ReportedBy, IncludeDateRange, CreatedDateFrom, CreatedDateUpto, AssignedTo, TaskStatusId, CompletedStatus, Description, AccountProjects, AccountEmployeeId, IsTaskAdd), , AccountId)

        'UIUtilities.FixTableForNoRecords(GetAccountProjectTasksForTaskSearch)

        Return GetAccountProjectTasksForTaskSearch

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountEmployeeIdAndDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountEmployeeIdAndTimeEntryDate(TimeEntryEndDate, AccountEmployeeId, TimeEntryStartDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectIdandTaskName(ByVal AccountProjectId As Integer, ByVal ParentTaskName As String) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountProjectIdandTaskName(AccountProjectId, ParentTaskName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectIdandIsParentTaskId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountProjectIdandParentTaskId(AccountProjectId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksByAccountEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        GetAssignedAccountProjectTasksByAccountEmployeeId = _vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOnlyTasks(AccountId, AccountEmployeeId)
        If GetAssignedAccountProjectTasksByAccountEmployeeId.Rows.Count = 0 Then
            GetAssignedAccountProjectTasksByAccountEmployeeId.Rows.Add(GetAssignedAccountProjectTasksByAccountEmployeeId.NewRow)
        End If
        Return GetAssignedAccountProjectTasksByAccountEmployeeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedOpenAccountProjectTasksByAccountEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable

        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectTaskDataTable", "GetAssignedOpenAccountProjectTasksByAccountEmployeeId", "AccountEmployeeId=" & AccountEmployeeId)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAssignedOpenAccountProjectTasksByAccountEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        GetAssignedOpenAccountProjectTasksByAccountEmployeeId = _vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOpenTask(AccountId, AccountEmployeeId) 'GetDataTableFillWithAssignedTo(_vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOpenTaskOne(AccountId, AccountEmployeeId), AccountEmployeeId)
        'CacheManager.AddAccountDataInCache(GetAssignedOpenAccountProjectTasksByAccountEmployeeId, strCacheKey)


        'End If

        UIUtilities.FixTableForNoRecords(GetAssignedOpenAccountProjectTasksByAccountEmployeeId)

        Return GetAssignedOpenAccountProjectTasksByAccountEmployeeId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByCreatedByEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable

        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectTaskDataTable", "GetAccountProjectTasksByCreatedByEmployeeId", "AccountEmployeeId=" & AccountEmployeeId)


        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountProjectTasksByCreatedByEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        GetAccountProjectTasksByCreatedByEmployeeId = _vueAccountProjectTaskTableAdapter.GetDataByCreatedByEmployeeId(AccountEmployeeId)
        'CacheManager.AddAccountDataInCache(GetAccountProjectTasksByCreatedByEmployeeId, strCacheKey)
        'End If

        UIUtilities.FixTableForNoRecords(GetAccountProjectTasksByCreatedByEmployeeId)
        Return GetAccountProjectTasksByCreatedByEmployeeId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByCreatedByEmployeeIdAsTable(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountProjectTaskDataTable
        Return Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    Public Function GetDataTableFillWithAssignedTo(ByVal TasksTable As vueAccountProjectTaskDataTable, Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal AccountId As Integer = 0) As vueAccountProjectTaskDataTable

        Dim dtAssignedTo As TimeLiveDataSet.vueAccountProjectTaskEmployeeForFullJoinDataTable
        If AccountEmployeeId <> 0 Then
            dtAssignedTo = New AccountProjectTaskEmployeeBLL().GetAccountProjectTaskEmployeeFullJoinByAccountEmployeeId(AccountEmployeeId)
        ElseIf AccountId <> 0 Then
            dtAssignedTo = New AccountProjectTaskEmployeeBLL().GetAccountProjectTaskEmployeeFullJoinByAccountId(AccountId)
        End If

        Dim ds As New DataSet
        ds.Tables.Add(TasksTable)
        ds.Tables.Add(dtAssignedTo)

        Dim rel As System.Data.DataRelation
        rel = ds.Relations.Add("RelAccountProjectTaskEmployee", ds.Tables("vueAccountProjectTask").Columns("AccountProjectTaskId"), ds.Tables("vueAccountProjectTaskEmployeeForFullJoin").Columns("AccountProjectTaskId"), False)

        TasksTable = ds.Tables("vueAccountProjectTask")

        For n As Integer = 0 To TasksTable.Rows.Count - 1
            Dim objRow As vueAccountProjectTaskRow = TasksTable.Rows(n)

            Dim ChildRows() As vueAccountProjectTaskEmployeeForFullJoinRow = objRow.GetChildRows("RelAccountProjectTaskEmployee")

            Dim strAssignedTo As String = ""
            For n2 As Integer = 0 To ChildRows.Length - 1
                Dim ChildRow As vueAccountProjectTaskEmployeeForFullJoinRow = ChildRows(n2)
                If DBUtilities.GetShowEmployeeNameBy = 1 Then
                    strAssignedTo = strAssignedTo + IIf(strAssignedTo = "", "", ",") + (ChildRow.FirstName & " " & ChildRow.LastName)
                Else
                    strAssignedTo = strAssignedTo + IIf(strAssignedTo = "", "", ",") + (ChildRow.LastName & " " & ChildRow.FirstName)
                End If
            Next

            objRow.AssignedTo = strAssignedTo

        Next
        Return TasksTable
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectTask( _
                    ByVal AccountProjectId As System.Nullable(Of Integer), _
                    ByVal ParentAccountProjectTaskId As System.Nullable(Of Integer), _
                    ByVal TaskName As String, _
                    ByVal TaskDescription As String, _
                    ByVal AccountTaskTypeId As System.Nullable(Of Integer), _
                    ByVal Duration As Double, _
                    ByVal DurationUnit As String, _
                    ByVal CompletedPercent As Double, _
                    ByVal Completed As Boolean, _
                    ByVal DeadlineDate As Date, _
                    ByVal TaskStatusId As System.Nullable(Of Integer), _
                    ByVal AccountPriorityId As System.Nullable(Of Integer), _
                    ByVal AccountProjectMilestoneId As System.Nullable(Of Integer), _
                    ByVal IsForAllEmployees As Boolean, _
                    ByVal IsParentTask As Boolean, _
                    ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal EstimatedCost As Double, _
                    ByVal EstimatedTimeSpent As Double, _
                    ByVal EstimatedTimeSpentUnit As String, _
                    ByVal IsBillable As Boolean, _
                    ByVal TaskCode As String, _
                    ByVal AccountBillingRateId As Integer, _
                    ByVal IsForAllProjectTask As Boolean, _
                    ByVal EstimatedCurrencyId As Integer, _
                    ByVal StartDate As Date, _
                    ByVal FixedCost As Double, _
                    Optional ByVal IsWebServiceCall As Boolean = False, _
                    Optional ByVal original_Predecessors As String = "", _
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
                    ) As Integer
        ' Create a new ProductRow instance
        Try
            Dim valParentAccountProjectTaskId As System.Nullable(Of Long)
            If ParentAccountProjectTaskId.HasValue Then
                If ParentAccountProjectTaskId.Value = -1 Then
                    valParentAccountProjectTaskId = Nothing
                ElseIf ParentAccountProjectTaskId.Value = 0 Then
                    valParentAccountProjectTaskId = Nothing
                Else
                    valParentAccountProjectTaskId = ParentAccountProjectTaskId.Value
                End If
            Else
                valParentAccountProjectTaskId = Nothing
            End If
            If TaskDescription Is Nothing Then
                TaskDescription = ""
            End If
            Dim InsertedAccountProjectTaskId As Integer = Adapter.InsertAccountProjectTask(AccountProjectId, _
            valParentAccountProjectTaskId, _
            TaskName, TaskDescription, IIf(AccountTaskTypeId.Value = 0, Nothing, AccountTaskTypeId), CompletedPercent, Completed, _
            CreatedByEmployeeId, ModifiedByEmployeeId, "Hours", Duration, _
            DeadlineDate, IsParentTask, IsForAllEmployees, IIf(TaskStatusId.Value = 0, Nothing, TaskStatusId), _
            IIf(AccountPriorityId.Value = 0, Nothing, AccountPriorityId), _
            IIf(AccountProjectMilestoneId.Value = 0, Nothing, AccountProjectMilestoneId), _
            EstimatedCost, EstimatedTimeSpentUnit, EstimatedTimeSpent, IsBillable, TaskCode, IsForAllProjectTask, _
            EstimatedCurrencyId, StartDate, original_Predecessors, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, _
            CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, FixedCost)
            If Not IsWebServiceCall Then
                AfterUpdate()
            End If
            Return InsertedAccountProjectTaskId
        Catch ex As Exception
            LoggingBLL.WriteExceptionNoRaiseToLog("LogException: Add Task", ex)
        End Try
    End Function
    Public Sub AfterUpdate(Optional ByVal AccountProjectTaskId As Integer = 0)
        If DBUtilities.IsApplicationContext Then
            CacheManager.ClearCache("AccountProjectTask", , True)
            'CacheManager.ClearCache("AccountProjectTaskDataTable", "AccountProjectTaskId=" & AccountProjectTaskId, True)
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectTask( _
                    ByVal AccountProjectId As System.Nullable(Of Integer), _
                    ByVal ParentAccountProjectTaskId As System.Nullable(Of Integer), _
                    ByVal TaskName As String, _
                    ByVal TaskDescription As String, _
                    ByVal AccountTaskTypeId As System.Nullable(Of Integer), _
                    ByVal Duration As Double, _
                    ByVal DurationUnit As String, _
                    ByVal CompletedPercent As Double, _
                    ByVal Completed As Boolean, _
                    ByVal DeadlineDate As Date, _
                    ByVal TaskStatusId As System.Nullable(Of Integer), _
                    ByVal AccountPriorityId As System.Nullable(Of Integer), _
                    ByVal IsForAllEmployees As Boolean, _
                    ByVal IsParentTask As Boolean, _
                    ByVal AccountProjectMilestoneId As System.Nullable(Of Integer), _
                    ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal EstimatedCost As Double, _
                    ByVal EstimatedTimeSpent As Double, _
                    ByVal EstimatedTimeSpentUnit As String, _
                    ByVal IsBillable As Boolean, _
                    ByVal Original_AccountProjectTaskId As Integer, _
                    ByVal IsDisabled As Boolean, _
                    ByVal TaskCode As String, _
                    ByVal IsForAllProjectTask As Boolean, _
                    ByVal EstimatedCurrencyId As Integer, _
                    ByVal StartDate As Date, _
                    ByVal FixedCost As Double, _
                    Optional ByVal original_Predecessors As String = "", _
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

        ' Update the product record

        Dim AccountProjectTasks As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(Original_AccountProjectTaskId)
        Dim AccountProjectTask As TimeLiveDataSet.AccountProjectTaskRow = AccountProjectTasks.Rows(0)

        If System.Web.HttpContext.Current.Session("IsTemplate") Is Nothing Then
            AddOldObjectInSession(Original_AccountProjectTaskId)
        Else
            System.Web.HttpContext.Current.Session.Remove("IsTemplate")
        End If



        With AccountProjectTask
            If ParentAccountProjectTaskId.HasValue Then
                If ParentAccountProjectTaskId.Value = -1 Then
                    .Item("ParentAccountProjectTaskId") = System.DBNull.Value
                ElseIf ParentAccountProjectTaskId.Value = 0 Then
                    .Item("ParentAccountProjectTaskId") = System.DBNull.Value
                Else
                    .Item("ParentAccountProjectTaskId") = ParentAccountProjectTaskId.Value
                End If
            Else
                .Item("ParentAccountProjectTaskId") = System.DBNull.Value
            End If

            Dim CompletedTaskStatusId = Me.GetCompletedTaskStatusId("Completed")
            If CompletedTaskStatusId <> 0 Then
                If AccountProjectTask.CompletedPercent = 100 And AccountProjectTask.Completed = True And AccountProjectTask.TaskStatusId = CompletedTaskStatusId Then
                    If Completed <> True Or CompletedPercent <> 100 Or TaskStatusId <> CompletedTaskStatusId Then
                        Completed = False
                    End If
                Else
                    If Completed <> False Or CompletedPercent = 100 Or TaskStatusId = CompletedTaskStatusId Then
                        Completed = True
                        TaskStatusId = CompletedTaskStatusId
                        CompletedPercent = 100
                    End If
                End If
            Else
                If AccountProjectTask.CompletedPercent = 100 And AccountProjectTask.Completed = True Then
                    If Completed <> True Or CompletedPercent <> 100 Then
                        Completed = False
                    End If
                Else
                    If Completed <> False Or CompletedPercent = 100 Then
                        Completed = True
                        TaskStatusId = TaskStatusId
                        CompletedPercent = 100
                    End If
                End If
            End If


            .TaskName = TaskName
            .AccountTaskTypeId = AccountTaskTypeId
            .TaskDescription = TaskDescription
            .Duration = Duration
            .DurationUnit = DurationUnit
            .CompletedPercent = CompletedPercent
            .Completed = Completed
            .DeadlineDate = DeadlineDate
            .StartDate = StartDate
            .TaskStatusId = TaskStatusId
            .AccountPriorityId = AccountPriorityId
            .AccountProjectMilestoneId = AccountProjectMilestoneId
            .IsForAllEmployees = IsForAllEmployees
            .IsParentTask = IsParentTask
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .EstimatedCost = EstimatedCost
            .EstimatedTimeSpent = EstimatedTimeSpent
            .EstimatedTimeSpentUnit = EstimatedTimeSpentUnit
            .IsBillable = IsBillable
            .IsDisabled = IsDisabled
            .TaskCode = TaskCode
            .IsForAllProjectTask = IsForAllProjectTask
            .EstimatedCurrencyId = EstimatedCurrencyId
            .FixedCost = FixedCost
            If original_Predecessors <> "" Then
                .Predecessors = original_Predecessors
            Else
                .Item("Predecessors") = System.DBNull.Value
            End If
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

        Try
            Dim rowsAffected As Integer = Adapter.Update(AccountProjectTask)
            'AfterUpdate(Original_AccountProjectTaskId)
            AfterUpdateTask(Original_AccountProjectTaskId)

            ' Return true if precisely one row was updated, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub AddOldObjectInSession(ByVal Original_AccountProjectTaskId As Integer)
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectTaskDataTable", "OldAccountProjectTask", "AccountProjectTaskId=" & Original_AccountProjectTaskId)
        Dim drAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskRow
        Dim objAccountEmployee As New AccountProjectTaskBLL
        drAccountProjectTask = objAccountEmployee.GetAccountProjectTaskByvueAccountProjectTaskId(Original_AccountProjectTaskId).Rows(0)
        CacheManager.AddAccountDataInCache(drAccountProjectTask, strCacheKey)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectTaskUpdateInformation( _
                     ByVal AccountProjectId As System.Nullable(Of Integer), _
                     ByVal ParentAccountProjectTaskId As System.Nullable(Of Integer), _
                     ByVal TaskName As String, _
                     ByVal TaskDescription As String, _
                     ByVal AccountTaskTypeId As System.Nullable(Of Integer), _
                     ByVal Duration As Double, _
                     ByVal DurationUnit As String, _
                     ByVal CompletedPercent As Double, _
                     ByVal Completed As Boolean, _
                     ByVal DeadlineDate As Date, _
                     ByVal TaskStatusId As System.Nullable(Of Integer), _
                     ByVal AccountPriorityId As System.Nullable(Of Integer), _
                     ByVal IsForAllEmployees As Boolean, _
                     ByVal IsParentTask As Boolean, _
                     ByVal IsReOpen As Boolean, _
                     ByVal AccountProjectMilestoneId As System.Nullable(Of Integer), _
                     ByVal CreatedOn As DateTime, _
                     ByVal CreatedByEmployeeId As Integer, _
                     ByVal ModifiedOn As DateTime, _
                     ByVal ModifiedByEmployeeId As Integer, _
                     ByVal EstimatedCost As Double, _
                     ByVal EstimatedTimeSpent As Double, _
                     ByVal EstimatedTimeSpentUnit As String, _
                     ByVal IsBillable As Boolean, _
                     ByVal Original_AccountProjectTaskId As Integer, _
                     ByVal TaskCode As String, _
                     ByVal IsForAllProjectTask As Boolean _
                     ) As Boolean

        ' Update the product record
        Try
            Dim AccountProjectTasks As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(Original_AccountProjectTaskId)
            Dim AccountProjectTask As TimeLiveDataSet.AccountProjectTaskRow = AccountProjectTasks.Rows(0)

            AddOldObjectInSession(Original_AccountProjectTaskId)

            With AccountProjectTask

                If ParentAccountProjectTaskId.HasValue Then
                    If ParentAccountProjectTaskId.Value = -1 Then
                        .Item("ParentAccountProjectTaskId") = System.DBNull.Value
                    ElseIf ParentAccountProjectTaskId.Value = 0 Then
                        .Item("ParentAccountProjectTaskId") = System.DBNull.Value
                    Else
                        .Item("ParentAccountProjectTaskId") = ParentAccountProjectTaskId.Value
                    End If
                Else
                    .Item("ParentAccountProjectTaskId") = System.DBNull.Value
                End If

                .TaskName = TaskName
                .TaskDescription = TaskDescription
                .AccountTaskTypeId = AccountTaskTypeId
                .Duration = Duration
                .DurationUnit = DurationUnit
                .CompletedPercent = CompletedPercent

                .Completed = Completed
                .DeadlineDate = DeadlineDate
                .TaskStatusId = TaskStatusId
                .AccountPriorityId = AccountPriorityId
                .AccountProjectMilestoneId = AccountProjectMilestoneId
                .IsReOpen = IsReOpen
                .IsParentTask = IsParentTask
                .IsForAllEmployees = IsForAllEmployees
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
                .EstimatedCost = EstimatedCost
                .EstimatedTimeSpent = EstimatedTimeSpent
                .EstimatedTimeSpentUnit = EstimatedTimeSpentUnit
                .IsBillable = IsBillable
                .TaskCode = TaskCode
                .IsForAllProjectTask = IsForAllProjectTask
            End With


            Dim rowsAffected As Integer = Adapter.Update(AccountProjectTask)

            'AfterUpdate()
            AfterUpdateTask(Original_AccountProjectTaskId)
            ' Return true if precisely one row was updated, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectType(ByVal Original_AccountProjectTaskId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectTaskId)

        AfterUpdate()

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskHierarchyCached(ByVal AccountProjectId As Long) As Object

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectTaskDataTable", "GetAccountProjectTaskHierarchyCached", "AccountProjectId=" & AccountProjectId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectTaskHierarchyCached = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountProjectTaskHierarchyCached = Me.GetAccountProjectTaskHierarchy(AccountProjectId)
            CacheManager.AddAccountDataInCache(GetAccountProjectTaskHierarchyCached, strCacheKey)
        End If

        If CType(GetAccountProjectTaskHierarchyCached, DataTable).Rows.Count = 0 Then
            UIUtilities.FixTableForNoRecords(GetAccountProjectTaskHierarchyCached)
            CType(GetAccountProjectTaskHierarchyCached, DataTable).Rows(0)("Depth") = 0
            CType(GetAccountProjectTaskHierarchyCached, DataTable).Rows(0)("IsParentTask") = False
            CType(GetAccountProjectTaskHierarchyCached, DataTable).Rows(0)("TaskName") = ""


        End If

        Return GetAccountProjectTaskHierarchyCached


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskHierarchy(ByVal AccountProjectId As Long) As Object
        Dim AccountProjectTaskId As Integer = System.Web.HttpContext.Current.Session("AccountProjectTaskId")
        Dim IsAdd As String = System.Web.HttpContext.Current.Session("IsAdd")

        Dim objConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
        objConnection.Open()

        Dim AccountProjectTaskDataSet As New System.Data.DataSet
        Dim Sort As String
        If IsAdd = "1" Then
            Sort = "AccountProjectTaskId"
        Else
            If DBUtilities.GetSortTask = "TaskId" Then
                Sort = "AccountProjectTaskId"
            Else
                Sort = "DeadlineDate"
            End If
        End If
        'If IsAdd = "1" Then
        '    Dim cmdAccountProjectTasks As New SqlDataAdapter("Select * from vueAccountProjectTask where AccountProjectId = " & AccountProjectId & "and " & "AccountId =" & DBUtilities.GetSessionAccountId & " and " & "AccountProjectTaskId=" & AccountProjectTaskId & "", objConnection)
        '    cmdAccountProjectTasks.Fill(AccountProjectTaskDataSet, "AccountProjectTask")
        'Else
        Dim cmdAccountProjectTasks As New SqlDataAdapter("Select * from vueAccountProjectTask where AccountProjectId = " & AccountProjectId & "and " & "AccountId =" & DBUtilities.GetSessionAccountId & " Order By " & Sort & "", objConnection)
        cmdAccountProjectTasks.Fill(AccountProjectTaskDataSet, "AccountProjectTask")
        'End If
        System.Web.HttpContext.Current.Session.Remove("IsAdd")
        Dim rel As System.Data.DataRelation
        rel = AccountProjectTaskDataSet.Relations.Add("RelAccountProjectTask", AccountProjectTaskDataSet.Tables("AccountProjectTask").Columns("AccountProjectTaskId"), AccountProjectTaskDataSet.Tables("AccountProjectTask").Columns("ParentAccountProjectTaskId"), False)
        rel.Nested = True
        Dim tbl As DataTable
        tbl = AccountProjectTaskDataSet.Tables("AccountProjectTask")
        tbl = AccountProjectTaskBLL.GetOrderedTable(tbl, "RelAccountProjectTask", "ParentAccountProjectTaskId")
        objConnection.Close()
        Return tbl

    End Function
    ' Receives a Table and orders the rows based on a specific relationship and
    ' a parent column.
    Public Shared Function GetOrderedTable( _
                    ByVal baseTable As DataTable, _
                    ByVal relationshipName As String, _
                    ByVal parentColumnName As String _
                ) As DataTable

        ' Configure the ordered table that will be passed out to the client
        Dim tbl As DataTable = baseTable.Clone()
        tbl.Columns.Add(New DataColumn("Depth", GetType(Int32)))
        ComputeHierarchy(tbl, baseTable.Select(parentColumnName & " Is NULL"), 0)
        Return tbl
    End Function

    ' Recursive routine that appends rows to the Private 
    ' table in an ordered manner
    Private Shared Sub ComputeHierarchy( _
                    ByRef orderedTable As DataTable, _
                    ByVal members() As DataRow, _
                    ByVal depth As Int32 _
                )

        Dim member As DataRow
        For Each member In members
            orderedTable.ImportRow(member)
            orderedTable.Rows(orderedTable.Rows.Count - 1).Item("Depth") = depth
            ComputeHierarchy(orderedTable, member.GetChildRows("relAccountProjectTask"), depth + 1)
        Next
    End Sub

    Public Sub AfterUpdateTask(ByVal AccountProjectTaskId As Integer)
        '        SendUpdatedTaskEMail(AccountProjectTaskId)
    End Sub

    Public Sub SendNewTaskEMail(ByVal AccountProjectTaskId As Integer)

        SendNewTaskEmailtoAssignee(AccountProjectTaskId)
        EMailUtilities.DequeueEmail()
    End Sub

    Public Sub SendUpdatedTaskEMail(ByVal AccountProjectTaskId As Integer)

        SendUpdatedTaskEmailtoAssignee(AccountProjectTaskId)
        EMailUtilities.DequeueEmail()
        AfterUpdate()
    End Sub

    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectTaskLastId.Rows(0)
        Return a.LastId

    End Function
    Public Sub SendNewTaskEmailtoAssignee(ByVal AccountProjectTaskId As Integer)

        Dim objvueAccountProjectTaskEmployeeEmail As New AccountProjectTaskBLL
        Dim dtvueAccountProjectTaskEmployeeEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeEmailDataTable = objvueAccountProjectTaskEmployeeEmail.GetvueAccountProjectTaskEmployeeEmail(AccountProjectTaskId)
        Dim drvueAccountProjectTaskEmployeeEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeEmailRow

        Dim objvueAccountProjectTaskEmail As New AccountProjectTaskBLL
        Dim dtvueAccountProjectTaskEmail As TimeLiveDataSet.vueAccountProjectTaskEmailDataTable = objvueAccountProjectTaskEmail.GetvueAccountProjectTaskEmail(AccountProjectTaskId)
        Dim drvueAccountProjectTaskEmail As TimeLiveDataSet.vueAccountProjectTaskEmailRow

        Dim objvueAccountProjectTask As New AccountProjectTaskBLL
        Dim dtvueAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = objvueAccountProjectTask.GetAccountProjectTaskByvueAccountProjectTaskId(AccountProjectTaskId)
        Dim drvueAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskRow

        If dtvueAccountProjectTaskEmployeeEmail.Rows.Count > 0 Then
            drvueAccountProjectTaskEmployeeEmail = dtvueAccountProjectTaskEmployeeEmail.Rows(0)

            For Each drvueAccountProjectTaskEmployeeEmail In dtvueAccountProjectTaskEmployeeEmail.Rows
                EMailUtilities.SendEMail(("[" & drvueAccountProjectTaskEmployeeEmail.ProjectName & " : " & drvueAccountProjectTaskEmployeeEmail.AccountProjectTaskId & "]" & " " & drvueAccountProjectTaskEmployeeEmail.TaskName), "TaskAddedTemplate", GetPreparedEMailMessageForNewTask(Nothing, drvueAccountProjectTaskEmployeeEmail), drvueAccountProjectTaskEmployeeEmail.EMailAddress, drvueAccountProjectTaskEmployeeEmail.FirstName & " " & drvueAccountProjectTaskEmployeeEmail.LastName, EMailUtilities.TASK_NOTIFICATION_DISPLAY_NAME)
            Next
        End If

        If dtvueAccountProjectTaskEmail.Rows.Count > 0 Then
            drvueAccountProjectTaskEmail = dtvueAccountProjectTaskEmail.Rows(0)
            If dtvueAccountProjectTask.Rows.Count > 0 Then
                drvueAccountProjectTask = dtvueAccountProjectTask.Rows(0)
                EMailUtilities.SendEMail(("[" & drvueAccountProjectTaskEmail.ProjectName & " : " & drvueAccountProjectTaskEmail.AccountProjectTaskId & "]" & " " & drvueAccountProjectTaskEmail.TaskName), "TaskAddedTemplate", GetPreparedEMailMessageForNewTask(drvueAccountProjectTask, Nothing), drvueAccountProjectTaskEmail.EMailAddress, drvueAccountProjectTaskEmail.CreatedByFirstName & " " & drvueAccountProjectTaskEmail.CreatedByLastName, EMailUtilities.TASK_NOTIFICATION_DISPLAY_NAME)
            End If
        End If

    End Sub

    Public Sub SendUpdatedTaskEmailtoAssignee(ByVal AccountProjectTaskId As Integer)
        Dim objvueAccountProjectTaskEmployeeUpdateEmail As New AccountProjectTaskBLL
        Dim dtvueAccountProjectTaskEmployeeUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailDataTable = objvueAccountProjectTaskEmployeeUpdateEmail.GetvueAccountProjectTaskEmployeeUpdateEmail(AccountProjectTaskId)
        Dim drvueAccountProjectTaskEmployeeUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailRow

        Dim objvueAccountProjectTaskUpdateEmail As New AccountProjectTaskBLL
        Dim dtvueAccountProjectTaskUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskUpdateEmailDataTable = objvueAccountProjectTaskUpdateEmail.GetvueAccountProjectTaskUpdateEmail(AccountProjectTaskId)
        Dim drvueAccountProjectTaskUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskUpdateEmailRow

        If dtvueAccountProjectTaskEmployeeUpdateEmail.Rows.Count > 0 Then
            drvueAccountProjectTaskEmployeeUpdateEmail = dtvueAccountProjectTaskEmployeeUpdateEmail.Rows(0)

            For Each drvueAccountProjectTaskEmployeeUpdateEmail In dtvueAccountProjectTaskEmployeeUpdateEmail.Rows
                EMailUtilities.SendEMail(("[" & drvueAccountProjectTaskEmployeeUpdateEmail.ProjectName & " : " & drvueAccountProjectTaskEmployeeUpdateEmail.AccountProjectTaskId & "]" & " " & drvueAccountProjectTaskEmployeeUpdateEmail.TaskName), "TaskUpdatedTemplate", GetPreparedEMailMessageForUpdatedTask(Nothing, drvueAccountProjectTaskEmployeeUpdateEmail), drvueAccountProjectTaskEmployeeUpdateEmail.EMailAddress, drvueAccountProjectTaskEmployeeUpdateEmail.FirstName & " " & drvueAccountProjectTaskEmployeeUpdateEmail.LastName, EMailUtilities.TASK_NOTIFICATION_DISPLAY_NAME)
            Next
        End If

        If dtvueAccountProjectTaskUpdateEmail.Rows.Count > 0 Then
            drvueAccountProjectTaskUpdateEmail = dtvueAccountProjectTaskUpdateEmail.Rows(0)
            EMailUtilities.SendEMail(("[" & drvueAccountProjectTaskUpdateEmail.ProjectName & " : " & drvueAccountProjectTaskUpdateEmail.AccountProjectTaskId & "]" & " " & drvueAccountProjectTaskUpdateEmail.TaskName), "TaskUpdatedTemplate", GetPreparedEMailMessageForUpdatedTask(drvueAccountProjectTaskUpdateEmail, Nothing), drvueAccountProjectTaskUpdateEmail.EMailAddress, drvueAccountProjectTaskUpdateEmail.CreatedByFirstName & " " & drvueAccountProjectTaskUpdateEmail.CreatedByLastName, EMailUtilities.TASK_NOTIFICATION_DISPLAY_NAME)
        End If

    End Sub


    Public Function GetPreparedEMailMessageForUpdatedTask(Optional ByVal drvueAccountProjectTaskUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskUpdateEmailRow = Nothing, Optional ByVal drvueAccountProjectTaskEmployeeUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailRow = Nothing) As StringDictionary

        Dim dict As StringDictionary
        Dim DataRow As DataRow

        If Not drvueAccountProjectTaskUpdateEmail Is Nothing Then
            DataRow = drvueAccountProjectTaskUpdateEmail
            Dim objvueAccountProjectTask As New AccountProjectTaskBLL
            Dim dtvueAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = objvueAccountProjectTask.GetAccountProjectTaskByvueAccountProjectTaskId(DataRow("AccountProjectTaskId"))
            Dim drvueAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskRow
            If dtvueAccountProjectTask.Rows.Count > 0 Then
                drvueAccountProjectTask = dtvueAccountProjectTask.Rows(0)
                dict = Me.GetPreparedEMailMessageForUpdateTask(drvueAccountProjectTask, Nothing)
            End If
        Else
            DataRow = drvueAccountProjectTaskEmployeeUpdateEmail
            Dim objvueAccountProjectTaskEmployeeUpdateEmail As New AccountProjectTaskBLL
            Dim dtvueAccountProjectTaskEmployeeUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailDataTable = objvueAccountProjectTaskEmployeeUpdateEmail.GetvueAccountProjectTaskEmployeeUpdateEmail(DataRow("AccountProjectTaskId"))
            'Dim drvueAccountProjectTaskEmployeeUpdateEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailRow
            If dtvueAccountProjectTaskEmployeeUpdateEmail.Rows.Count > 0 Then
                drvueAccountProjectTaskEmployeeUpdateEmail = dtvueAccountProjectTaskEmployeeUpdateEmail.Rows(0)
                dict = Me.GetPreparedEMailMessageForUpdateTask(Nothing, drvueAccountProjectTaskEmployeeUpdateEmail)
            End If

        End If



        Dim olddrAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskRow
        'olddrAccountProjectTask = System.Web.HttpContext.Current.Session("OldAccountProjectTask")
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountProjectTaskDataTable", "OldAccountProjectTask", "AccountProjectTaskId=" & DataRow("AccountProjectTaskId"))
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            olddrAccountProjectTask = CacheManager.GetItemFromCache(strCacheKey)
        End If

        'Dim olddrAccountProjectMilestone As TimeLiveDataSet.AccountProjectMilestoneRow
        'olddrAccountProjectMilestone = System.Web.HttpContext.Current.Session("OldAccountProjectMilestone")
        If Not IsDBNull(DataRow("DurationUnit")) Then
            If DataRow("Duration") <> olddrAccountProjectTask.Duration Or DataRow("DurationUnit") <> olddrAccountProjectTask.DurationUnit Then
                dict.Add("[oldduration]", "[was:" & olddrAccountProjectTask.Duration)
                dict.Add("[olddurationunit]", " " & olddrAccountProjectTask.DurationUnit & "]")
            Else
                dict.Add("[oldduration]", "")
                dict.Add("[olddurationunit]", "")
            End If
        End If
        dict.Add("[modifiedemployeename]", DataRow("ModifiedByFirstName") & " " & DataRow("ModifiedByLastName"))

        If DataRow("TaskStatus") <> olddrAccountProjectTask.TaskStatus Then
            dict.Add("[oldtaskstatus]", "[was:" & olddrAccountProjectTask.TaskStatus & "]")
        Else
            dict.Add("[oldtaskstatus]", "")
        End If

        'Dim MilestoneBll As New AccountProjectMilestoneBLL
        'Dim drMilestone As TimeLiveDataSet.AccountProjectMilestoneRow
        'drMilestone = MilestoneBll.GetAccountProjectMilestonesByAccountProjectTaskId(drAccountProjectTask.AccountProjectTaskId).Rows(0)

        If Not IsDBNull(DataRow("ProjectCode")) Then
            If DataRow("ProjectCode") <> olddrAccountProjectTask.ProjectCode Then
                dict.Add("[oldprojectcode]", "[was:" & olddrAccountProjectTask.ProjectCode & "]")
            Else
                dict.Add("[oldprojectcode]", "")
            End If
        End If

        If DataRow("ProjectName") <> olddrAccountProjectTask.ProjectName Then
            dict.Add("[oldprojectname]", "[was:" & olddrAccountProjectTask.ProjectName & "]")
        Else
            dict.Add("[oldprojectname]", "")
        End If

        If DataRow("TaskName") <> olddrAccountProjectTask.TaskName Then
            dict.Add("[oldtaskname]", "[was:" & olddrAccountProjectTask.TaskName & "]")
        Else
            dict.Add("[oldtaskname]", "")
        End If

        If Not IsDBNull(DataRow("ProjectCode")) Then
            If DataRow("TaskDescription") <> olddrAccountProjectTask.TaskDescription Then
                dict.Add("[oldtaskdescription]", "[was:" & olddrAccountProjectTask.TaskDescription & "]")
            End If
        Else
            dict.Add("[oldtaskdescription]", "")
        End If


        If DataRow("TaskType") <> olddrAccountProjectTask.TaskType Then
            dict.Add("[oldtasktype]", "[was:" & olddrAccountProjectTask.TaskType & "]")
        Else
            dict.Add("[oldtasktype]", "")
        End If

        If DataRow("Priority") <> olddrAccountProjectTask.Priority Then
            dict.Add("[oldpriority]", "[was:" & olddrAccountProjectTask.Priority & "]")
        Else
            dict.Add("[oldpriority]", "")
        End If

        If DataRow("MilestoneDescription") <> olddrAccountProjectTask.MilestoneDescription Then
            dict.Add("[oldmilestonedescription]", "[was:" & olddrAccountProjectTask.MilestoneDescription & "]")
        Else
            dict.Add("[oldmilestonedescription]", "")
        End If

        If DataRow("DeadlineDate") <> olddrAccountProjectTask.DeadlineDate Then
            dict.Add("[olddeadline]", "[was:" & olddrAccountProjectTask.DeadlineDate & "]")
        Else
            dict.Add("[olddeadline]", "")
        End If

        If DataRow("CompletedPercent") <> olddrAccountProjectTask.CompletedPercent Then
            dict.Add("[oldcompletedpercent]", "[was:" & olddrAccountProjectTask.CompletedPercent & "%" & "]")
        Else
            dict.Add("[oldcompletedpercent]", "")
        End If

        If DataRow("Completed") <> olddrAccountProjectTask.Completed Then
            dict.Add("[oldcompleted]", "[was:" & IIf(olddrAccountProjectTask.Completed = True, "Yes", "No") & "]")
        Else
            dict.Add("[oldcompleted]", "")
        End If

        If DataRow("IsReOpen") <> olddrAccountProjectTask.IsReOpen Then
            dict.Add("[oldisreopen]", "[was:" & IIf(olddrAccountProjectTask.IsReOpen = True, "Yes", "No") & "]")
        Else
            dict.Add("[oldisreopen]", "")
        End If
        dict.Add("[tasknamecolumn]", IIf(System.Configuration.ConfigurationManager.AppSettings("BugTracking") Is Nothing, "Task Name", "Bug Name"))
        dict.Add("[tasktypecolumn]", IIf(System.Configuration.ConfigurationManager.AppSettings("BugTracking") Is Nothing, "Task Type", "Bug Type"))
        Return dict

    End Function

    Public Function GetPreparedEMailMessageForNewTask(Optional ByVal drvueAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskRow = Nothing, Optional ByVal drvueAccountProjectTaskEmployeeEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeEmailRow = Nothing) As StringDictionary

        Dim dict As New StringDictionary

        'Dim MilestoneBll As New AccountProjectMilestoneBLL
        'Dim drMilestone As TimeLiveDataSet.AccountProjectMilestoneRow
        'drMilestone = MilestoneBll.GetAccountProjectMilestonesByAccountProjectTaskId(drAccountProjectTask.AccountProjectTaskId).Rows(0)

        Dim DataRow As DataRow
        If Not drvueAccountProjectTask Is Nothing Then
            DataRow = drvueAccountProjectTask
        Else
            DataRow = drvueAccountProjectTaskEmployeeEmail
        End If
        If Not IsDBNull(DataRow("ProjectCode")) Then
            dict.Add("[projectcode]", DataRow("ProjectCode"))
        End If
        dict.Add("[projectname]", DataRow("ProjectName"))
        dict.Add("[taskname]", DataRow("TaskName"))
        dict.Add("[taskdescription]", DataRow("TaskDescription"))
        dict.Add("[tasktype]", DataRow("TaskType"))
        dict.Add("[taskstatus]", DataRow("TaskStatus"))
        dict.Add("[priority]", DataRow("Priority"))
        dict.Add("[createdon]", LTrim(RTrim(Left(DataRow("CreatedOn"), 10))))
        dict.Add("[employeename]", DataRow("CreatedByFirstName") & " " & DataRow("CreatedByLastName"))
        dict.Add("[projecttaskid]", DataRow("AccountProjectTaskId"))
        dict.Add("[reporter]", DataRow("CreatedByFirstName") & " " & DataRow("CreatedByLastName"))
        dict.Add("[milestonedescription]", DataRow("MilestoneDescription"))
        dict.Add("[duration]", DataRow("Duration"))
        dict.Add("[durationunit]", DataRow("DurationUnit"))
        dict.Add("[deadline]", DataRow("DeadlineDate"))
        dict.Add("[completedpercent]", DataRow("CompletedPercent"))
        dict.Add("[completed]", IIf(DataRow("Completed") = True, "Yes", "No"))
        dict.Add("[isreopen]", IIf(DataRow("IsReOpen") = True, "Yes", "No"))
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "Employee/AccountProjectTaskComments.aspx?AccountProjectTaskId=" & DataRow("AccountProjectTaskId"))
        dict.Add("[tasknamecolumn]", IIf(System.Configuration.ConfigurationManager.AppSettings("BugTracking") Is Nothing, "Task Name", "Bug Name"))
        dict.Add("[tasktypecolumn]", IIf(System.Configuration.ConfigurationManager.AppSettings("BugTracking") Is Nothing, "Task Type", "Bug Type"))

        Dim drAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeRow
        Dim dtAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim objAccountProjectTaskEmployee As New AccountProjectTaskEmployeeBLL

        dtAccountProjectTaskEmployee = objAccountProjectTaskEmployee.GetAccountProjectTaskEmployeesByvueAccountProjectTaskId(DataRow("AccountProjectTaskId"))
        Dim Assignee As String = ""

        For Each drAccountProjectTaskEmployee In dtAccountProjectTaskEmployee.Rows
            Assignee = Assignee & IIf(Assignee = "", "", ",") & (drAccountProjectTaskEmployee.FirstName & " " & drAccountProjectTaskEmployee.LastName) & (Chr(13))
        Next

        dict.Add("[assignedto]", Assignee)
        Return dict

    End Function
    Public Function GetPreparedEMailMessageForUpdateTask(Optional ByVal drvueAccountProjectTask As TimeLiveDataSet.vueAccountProjectTaskRow = Nothing, Optional ByVal drvueAccountProjectTaskEmployeeEmail As TimeLiveDataSet.vueAccountProjectTaskEmployeeUpdateEmailRow = Nothing) As StringDictionary

        Dim dict As New StringDictionary

        'Dim MilestoneBll As New AccountProjectMilestoneBLL
        'Dim drMilestone As TimeLiveDataSet.AccountProjectMilestoneRow
        'drMilestone = MilestoneBll.GetAccountProjectMilestonesByAccountProjectTaskId(drAccountProjectTask.AccountProjectTaskId).Rows(0)

        Dim DataRow As DataRow
        If Not drvueAccountProjectTask Is Nothing Then
            DataRow = drvueAccountProjectTask
        Else
            DataRow = drvueAccountProjectTaskEmployeeEmail
        End If

        If Not IsDBNull(DataRow("ProjectCode")) Then
            dict.Add("[projectcode]", DataRow("ProjectCode"))
        End If
        dict.Add("[projectname]", DataRow("ProjectName"))
        dict.Add("[taskname]", DataRow("TaskName"))
        If Not IsDBNull(DataRow("TaskDescription")) Then
            dict.Add("[taskdescription]", DataRow("TaskDescription"))
        End If
        dict.Add("[tasktype]", DataRow("TaskType"))
        dict.Add("[taskstatus]", DataRow("TaskStatus"))
        dict.Add("[priority]", DataRow("Priority"))
        dict.Add("[createdon]", LTrim(RTrim(Left(DataRow("CreatedOn"), 10))))
        dict.Add("[employeename]", DataRow("CreatedByFirstName") & " " & DataRow("CreatedByLastName"))
        dict.Add("[projecttaskid]", DataRow("AccountProjectTaskId"))
        dict.Add("[reporter]", DataRow("CreatedByFirstName") & " " & DataRow("CreatedByLastName"))
        dict.Add("[milestonedescription]", DataRow("MilestoneDescription"))
        dict.Add("[duration]", DataRow("Duration"))
        If Not IsDBNull(DataRow("DurationUnit")) Then
            dict.Add("[durationunit]", DataRow("DurationUnit"))
        End If
        dict.Add("[deadline]", DataRow("DeadlineDate"))
        dict.Add("[completedpercent]", DataRow("CompletedPercent"))
        dict.Add("[completed]", IIf(DataRow("Completed") = True, "Yes", "No"))
        dict.Add("[isreopen]", IIf(DataRow("IsReOpen") = True, "Yes", "No"))
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "Employee/AccountProjectTaskComments.aspx?AccountProjectTaskId=" & DataRow("AccountProjectTaskId"))

        Dim drAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeRow
        Dim dtAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim objAccountProjectTaskEmployee As New AccountProjectTaskEmployeeBLL

        dtAccountProjectTaskEmployee = objAccountProjectTaskEmployee.GetAccountProjectTaskEmployeesByvueAccountProjectTaskId(DataRow("AccountProjectTaskId"))
        Dim Assignee As String = ""

        For Each drAccountProjectTaskEmployee In dtAccountProjectTaskEmployee.Rows
            Assignee = Assignee & IIf(Assignee = "", "", ",") & (drAccountProjectTaskEmployee.FirstName & " " & drAccountProjectTaskEmployee.LastName) & (Chr(13))
        Next

        dict.Add("[assignedto]", Assignee)
        Return dict

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectEmployeeTaskByAccountProjectTaskId(ByVal AccountProjectTaskId) As TimeLiveDataSet.vueAccountProjectEmployeeTaskDataTable
        Dim _vueAccountProjectEmployeeTaskTableAdapter As New vueAccountProjectEmployeeTaskTableAdapter
        Return _vueAccountProjectEmployeeTaskTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    Public Function AddBillingRateOfTask(ByVal BillingRate As Decimal, ByVal BillingRateStartDate As Date, ByVal BillingRateEndDate As Date, ByVal AccountWorkTypeId As Integer, ByVal EmployeeRate As Decimal, ByVal BillingRateCurrencyId As Integer, ByVal EmployeeRateCurrencyId As Integer, ByVal AccountProjectTaskId As Long)
        Dim objAccountBillingRate As New AccountBillingRateBLL
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectTaskWorkTypeBillingRate(DBUtilities.GetSessionAccountId, 4, AccountProjectTaskId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow
        'Change in currency
        objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 4, 0, 0, 0, AccountProjectTaskId, BillingRate, BillingRateStartDate, BillingRateEndDate, AccountWorkTypeId, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId)
        Me.UpdateAccountBillingRateId(objAccountBillingRate.GetLastInsertedId, AccountProjectTaskId)

        If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
            drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
            objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(DBUtilities.GetSessionAccountId, 4, 0, 0, 0, AccountProjectTaskId, drAccountWorkTypeBillingRate.AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
        Else
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(DBUtilities.GetSessionAccountId, 4, 0, 0, 0, AccountProjectTaskId, objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAccountBillingRateId(ByVal AccountBillingRateId As Integer, ByVal AccountProjectTaskId As Integer) As Integer
        Return Adapter.UpdateAccountBillingRateId(AccountBillingRateId, AccountProjectTaskId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskWithBillingRateByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer) As TimeLiveDataSet.vueAccountProjectTaskWithBillingRateDataTable
        Dim _vueAccountProjectTaskWithBillingRateTableAdapter As New vueAccountProjectTaskWithBillingRateTableAdapter
        Return _vueAccountProjectTaskWithBillingRateTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
    End Function
    Public Sub InsertAccountProjectTasksByProjectTemplate(ByVal AccountProjectId As Integer, ByVal AccountProjectTemplateId As Integer)
        Dim BLL As New AccountProjectTaskBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = BLL.GetProjectTasksByAccountProjectId(AccountProjectTemplateId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Adapter.InsertAccountProjectTasksByProjectTemplate(AccountProjectId, AccountProjectTemplateId)
        End If
    End Sub
    Public Sub UpdateParentAccountProjectTaskId(ByVal AccountProjectId As Integer, ByVal AccountProjectTemplateId As Integer)
        Dim BLL As New AccountProjectTaskBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = BLL.GetAccountProjectTasksByAccountProjectIdAndParentAccountProjectTaskId(AccountProjectTemplateId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Adapter.UpdateParentAccountProjectTaskId(AccountProjectId)
        End If
    End Sub
    Public Function IfWorkTypeBillingRateExistOfProjectTask(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer) As Boolean
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectTaskWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectTaskId, AccountWorkTypeId)

        If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub UpdateEstimatedCurrencyIdForOldAccount(ByVal EstimatedCurrencyId As Integer, ByVal AccountId As Integer)
        If Adapter.GetDataByAccountId(AccountId).Rows.Count > 0 Then
            Adapter.UpdateEstimatedCurrencyId(EstimatedCurrencyId, AccountId)
        End If
    End Sub
    Public Sub UpdateEstimatedCurrencies(ByVal EstimatedCurrencyId As Integer, ByVal AccountId As Integer)
        If Adapter.GetDataByAccountId(AccountId).Rows.Count > 0 Then
            Adapter.UpdateEstimatedCurrencies(EstimatedCurrencyId, AccountId)
        End If
    End Sub
    Public Function GetShowAdditionalTaskInformationValue(ByVal TypeId As Integer, ByVal ParentAccountProjectTaskId As Integer, ByVal TaskCode As String) As String
        If TypeId = 1 Then
            Return GetTaskNameByAccountProjectTaskId(ParentAccountProjectTaskId)
        ElseIf TypeId = 2 Then
            Return GetTaskCodeByAccountProjectTaskId(ParentAccountProjectTaskId)
        ElseIf TypeId = 3 Then
            Return TaskCode
        End If
        Return ""
    End Function
    Public Function GetTaskNameByAccountProjectTaskId(ByVal ParentAccountProjectTaskId As Integer)
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(ParentAccountProjectTaskId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("TaskName")) Then
                Return dr.TaskName
            End If
        End If
    End Function
    Public Function GetTaskCodeByAccountProjectTaskId(ByVal ParentAccountProjectTaskId As Integer)
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(ParentAccountProjectTaskId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("TaskCode")) Then
                Return dr.TaskCode
            End If
        End If
    End Function
    Public Sub UpdateAccountBillingRateIdByAccountProjectId(ByVal AccountProjectId As Integer)
        Adapter.UpdateAccountBillingRateIdByAccountProjectId(AccountProjectId)
    End Sub
    Public Function GetAssignedTaskWhereClause(ByVal Completed As Boolean)
        Dim sql As String

        sql = " SELECT AccountProjectTaskId, ParentAccountProjectTaskId, TaskName, TaskCode " & _
                          " FROM AccountProjectTask INNER JOIN dbo.AccountProject " & _
                          " ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId " & _
                          " AND dbo.AccountProject.AccountId = @AccountId " & _
                          " WHERE "

        sql = sql + " ((dbo.AccountProject.IsDeleted <> 1 OR dbo.AccountProject.IsDeleted IS NULL) AND (IsParentTask <> 1) AND (AccountProjectTask.IsDisabled <> 1) AND (IsTemplate <> 1) AND "

        If Completed <> True Then
            sql = sql + " (AccountProjectTask.Completed = @Completed) AND "
        End If

        sql = sql + " (((IsForAllProjectTask = 1) AND (AccountProjectTaskId IN (SELECT AccountProjectTaskId FROM " & _
                    " AccountProjectTaskEmployee WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                    " (AccountProjectTask.AccountProjectId = AccountProjectTask.AccountProjectId) AND  " & _
                    " (AccountEmployeeId = @AccountEmployeeId)))) OR "

        sql = sql + " ((IsForAllEmployees = 1) AND (AccountProjectTask.AccountProjectId = @AccountProjectId)) OR "


        sql = sql + " ((IsForAllProjectTask = 1) AND (IsForAllEmployees = 1) AND (AccountProjectTask.AccountProjectId IN " & _
                    " (SELECT AccountProjectId FROM AccountProjectEmployee " & _
                    " WHERE (AccountProjectId = AccountProjectTask.AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

        sql = sql + " ((IsForAllProjectTask IS NULL OR IsForAllProjectTask <> 1) AND (IsForAllEmployees IS NULL OR IsForAllEmployees <> 1) " & _
                    " AND (AccountProjectTaskId IN " & _
                    " (SELECT AccountProjectTaskId FROM AccountProjectTaskEmployee AS AccountProjectTaskEmployee_1 " & _
                    " WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                    " (AccountProjectTask.AccountProjectId = @AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

        sql = sql + " ((IsForAllEmployees = 1) AND (IsForAllProjectTask = 1) AND (AccountId = @AccountId)))) "

        sql = sql + " OR ((AccountProjectTaskId = @AccountProjectTaskId)) "

        ' sql = sql + " ORDER BY TaskName "
        Return sql
    End Function
    Public Function GetAdministratorWhereClause()
        Return " OR ((dbo.AccountProject.AccountId = @AccountId) And (dbo.AccountProject.AccountProjectId = @AccountProjectId))"
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedProjectTasksFromvueAccountProjectTaskForCustomizedReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean, ByVal AccountReportId As Guid, ByVal Roles As String) As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.AccountProjectTaskTimesheetTableAdapter
        Dim WhereClause As String
        Dim ReportPermission As New ObjectPermissionBLL
        WhereClause = GetAssignedTaskWhereClause(Completed)
        If ReportPermission.IsReportHasPermissionOfAllowAllUserByRoles(AccountReportId, True, Roles, AccountId) Then
            WhereClause = WhereClause & GetAdministratorWhereClause()
        End If
        WhereClause = WhereClause + " ORDER BY TaskName "
        GetAssignedProjectTasksFromvueAccountProjectTaskForCustomizedReport = vueAdapter.GetAssignedProjectTasksFromvueAccountProjectTaskForCustomizedReport(WhereClause, AccountId, AccountEmployeeId, AccountProjectId, AccountProjectTaskId, Completed)
        Return GetAssignedProjectTasksFromvueAccountProjectTaskForCustomizedReport
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Sub UpdateIsParentInAccountProjectTask(ByVal AccountProjectTaskId As Integer, ByVal IsParentTask As Boolean)
        Adapter.UpdateIsParentInTask(IsParentTask, AccountProjectTaskId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskByAccountIdAndTaskName(ByVal AccountId As Integer, ByVal TaskName As String) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskTableAdapter
        Return vueAdapter.GetDataByAccountIdAndTaskName(AccountId, TaskName)
    End Function
    Public Function GetTasksForWSByAccountId(ByVal AccountId As Integer) As Object
        Dim objConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
        objConnection.Open()
        Dim AccountProjectTaskDataSet As New DataSet
        Dim cmdAccountProjectTasks As New SqlDataAdapter("Select * from vueAccountProjectTask Where AccountId = " & AccountId & "Order By AccountProjectTaskId", objConnection)
        cmdAccountProjectTasks.Fill(AccountProjectTaskDataSet, "vueAccountProjectTask")
        Dim rel As System.Data.DataRelation
        rel = AccountProjectTaskDataSet.Relations.Add("RelAccountProjectTask", AccountProjectTaskDataSet.Tables("vueAccountProjectTask").Columns("ParentAccountProjectTaskId"), AccountProjectTaskDataSet.Tables("vueAccountProjectTask").Columns("AccountProjectTaskId"), False)
        'rel.Nested = True
        Dim tbl As DataTable
        tbl = AccountProjectTaskDataSet.Tables("vueAccountProjectTask")
        tbl.Columns.Add("ParentChild")
        tbl.Columns.Add("JobParent")
        tbl.Columns.Add("ItemParent")
        tbl.Columns.Add("JobItemParent")
        Dim row As DataRow
        For Each row In tbl.Rows
            Dim ReplacedTask As String
            row("ParentChild") = GetHierarchyRow(row, "")
            ReplacedTask = IIf(row("ParentChild").ToString().Contains(":"), Replace(row("ParentChild"), ":" & row("TaskName"), ""), Replace(row("ParentChild"), row("TaskName"), ""))
            row("JobParent") = row("PartyName") & ":" & row("ProjectName") & IIf(ReplacedTask = "", "", ":") & ReplacedTask
            row("ItemParent") = row("ProjectName") & IIf(ReplacedTask = "", "", ":") & ReplacedTask
            row("JobItemParent") = ReplacedTask
            Name = ""
        Next row
        objConnection.Close()
        Return tbl
    End Function
    Public Function GetTaskNameForWSByAccountProjectTaskId(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer) As String
        Dim objConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
        objConnection.Open()
        Dim AccountProjectTaskDataSet As New DataSet
        Dim cmdAccountProjectTasks As New SqlDataAdapter("Select * from vueAccountProjectTask Where AccountProjectId = " & AccountProjectId & "Order By AccountProjectTaskId", objConnection)
        cmdAccountProjectTasks.Fill(AccountProjectTaskDataSet, "vueAccountProjectTask")
        Dim rel As System.Data.DataRelation
        rel = AccountProjectTaskDataSet.Relations.Add("RelAccountProjectTask", AccountProjectTaskDataSet.Tables("vueAccountProjectTask").Columns("ParentAccountProjectTaskId"), AccountProjectTaskDataSet.Tables("vueAccountProjectTask").Columns("AccountProjectTaskId"), False)
        'rel.Nested = True
        Dim tbl As DataTable
        tbl = AccountProjectTaskDataSet.Tables("vueAccountProjectTask")
        Dim row As DataRow
        For Each row In tbl.Rows
            If row("AccountProjectTaskId") = AccountProjectTaskId Then
                GetTaskNameForWSByAccountProjectTaskId = GetHierarchyRow(row, "")
                Name = ""
            End If
        Next row
        objConnection.Close()
        Return GetTaskNameForWSByAccountProjectTaskId
    End Function
    Public Function GetHierarchyRow(ByVal row As DataRow, ByVal strIndent As String) As String
        Name = row("TaskName") & strIndent & Name
        Dim rowChild As DataRow
        For Each rowChild In row.GetChildRows("RelAccountProjectTask")
            GetHierarchyRow(rowChild, ":")
        Next rowChild
        Return Name
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateCompletedInTask(ByVal AccountProjectId As Integer, _
            ByVal AccountProjectMilestoneId As Integer, ByVal TaskStatusId As Integer, ByVal Completed As Boolean) As Boolean

        ' Update the product record

        Dim AccountProjectTaskDataTable As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectIdandAccountProjectMilestoneId(AccountProjectId, AccountProjectMilestoneId)
        Dim AccountProjectTaskRow As TimeLiveDataSet.AccountProjectTaskRow

        If AccountProjectTaskDataTable.Rows.Count > 0 Then
            AccountProjectTaskRow = AccountProjectTaskDataTable.Rows(0)

            For Each AccountProjectTaskRow In AccountProjectTaskDataTable.Rows
                AccountProjectTaskRow.Completed = Completed
                AccountProjectTaskRow.TaskStatusId = TaskStatusId
                AccountProjectTaskRow.CompletedPercent = 100
            Next
        End If

        Dim rowsAffected As Integer = Adapter.Update(AccountProjectTaskDataTable)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub UpdatePercentageAndCompleteTask(ByVal AccountProjectTaskId As Integer, ByVal Old_AccountProjectTaskId As Object, ByVal Old_Percentage As Integer, ByVal Percentage As Integer)
        If Not Old_AccountProjectTaskId Is Nothing Then
            Dim dtOld As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(Old_AccountProjectTaskId)
            Dim drOld As TimeLiveDataSet.AccountProjectTaskRow
            If dtOld.Rows.Count > 0 Then
                drOld = dtOld.Rows(0)
                If Not IsDBNull(drOld.Item("CompletedPercent")) Then
                    drOld.CompletedPercent = drOld.CompletedPercent - Old_Percentage
                    Dim rowsAffected As Integer = Adapter.Update(dtOld)
                    AfterUpdate(Old_AccountProjectTaskId)
                End If
            End If
        End If
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        Dim CompletePercentage As Integer = 0
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Percentage = Old_Percentage And Old_AccountProjectTaskId Is Nothing Then
                Exit Sub
            End If
            If Not IsDBNull(dr.Item("CompletedPercent")) Then
                CompletePercentage = dr.CompletedPercent
                If Old_Percentage <> 0 And Old_AccountProjectTaskId Is Nothing Then
                    CompletePercentage = CompletePercentage - Old_Percentage
                End If
            End If
            CompletePercentage = CompletePercentage + Percentage
            With dr
                .CompletedPercent = CompletePercentage
                If CompletePercentage = 100 Then
                    .Completed = True
                Else
                    .Completed = False
                End If
            End With
            Dim rowsAffected As Integer = Adapter.Update(dt)
            AfterUpdate(AccountProjectTaskId)
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectTaskMassUpdate(value1 As String, value2 As String, value3 As String, value4 As String, value5 As String, value6 As String, AccountProjectTaskId As Integer) As Boolean
        Adapter.UpdateAccountProjectTaskMassUpdate(value1, value2, value3, value4, value5, value6, AccountProjectTaskId)
        AfterUpdate(AccountProjectTaskId)
    End Function
    Public Function GetCompletedPercentByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As Integer
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("CompletedPercent")) Then
                Return dr.CompletedPercent
            End If
        End If
        Return 0
    End Function
    Public Function GetCompletedTaskStatusId(ByVal Completed As String)
        Dim TaskStatusbll As New AccountStatusBLL
        Dim dtstatus As TimeLiveDataSet.AccountStatusDataTable = TaskStatusbll.GetAccountsStatusByAccountIdAndStatus(DBUtilities.GetSessionAccountId, ResourceHelper.GetFromResource(Completed, DBUtilities.GetSessionAccountId))
        Dim drstatus As TimeLiveDataSet.AccountStatusRow
        Dim TaskStatusId As Integer

        If dtstatus.Rows.Count <> 0 Then
            drstatus = dtstatus.Rows(0)
            TaskStatusId = drstatus.AccountStatusId
            Return TaskStatusId
        Else
            Return 0
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedOpenAccountProjectTasksByAccountEmployeeIdForChart(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOpenTask(AccountId, AccountEmployeeId) 'GetDataTableFillWithAssignedTo(_vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOpenTaskOne(AccountId, AccountEmployeeId), AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedOpenAccountProjectTasksByAccountEmployeeIdForCompletedPercentageChart(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOpenTaskforCompletedPercentChart(AccountId, AccountEmployeeId) 'GetDataTableFillWithAssignedTo(_vueAccountProjectTaskTableAdapter.GetAccountEmployeeAssignedOpenTaskOne(AccountId, AccountEmployeeId), AccountEmployeeId)
    End Function
    ''GetAccountProjectTaskByAccountProjectTaskId
    Public Function GetvueAccountProjectTaskByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, ByVal IsProject As Boolean) As Integer
        Dim BLL As New AccountProjectTaskBLL
        Dim dt As TimeLiveDataSet.vueAccountProjectTaskDataTable = BLL.GetvueAccountProjectTasksByAccountProjectTaskId(AccountProjectTaskId)
        Dim dr As TimeLiveDataSet.vueAccountProjectTaskRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If IsProject = True Then
                Return dr.AccountProjectId
            Else
                Return dr.AccountClientId
            End If
        End If
    End Function
    Public Function GetMaxAccountProjectTaskIdForAccountProjectGantt(AccountId As Integer) As Integer
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            Using command As New SqlCommand("Select max(AccountProjectTaskId) as AccountProjectTaskId from AccountProjectTask where AccountProjectId in (select AccountProjectId from AccountProject where AccountId = @AccountId)", connection)
                command.Parameters.AddWithValue("@AccountId", AccountId)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        If reader.HasRows Then
                            Return reader("AccountProjectTaskId")
                        End If
                    End While

                Catch e As Exception
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
        Return 0
    End Function
End Class