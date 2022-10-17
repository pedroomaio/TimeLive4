Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountEmployeeTimeEntryTableAdapters
Imports System.Data.SqlClient
Imports System.Threading
Imports TimeLiveDataSet
''' <summary>
''' This class perform database operations for AccountEmployeeTimeEntry table. AccountEmployeeTimeEntry table 
''' store records for Timesheet data
''' </summary>
''' <remarks>AccountEmployeeTimeEntry Business Layer class</remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTimeEntryBLL
    Dim AccountEmployeeTimeEntryPeriodIdTS As Guid
    Dim TimesheetPeriodTypeTS As String
    Dim PeriodStartDateTS As Date
    Dim PeriodEndDateTS As Date
    Dim strCacheKey As String
    Dim nAccountEmployeeTimeEntryPeriodId As Guid
    Dim nAccountEmployeeTimeEntryApprovalProjectId As Guid
    Dim SystemTimesheetPeriodTypeWS As String
    Dim EmployeeWeekStartDayWS As Integer
    Dim SystemInitialDayOfFirstPeriodWS As Integer
    Dim SystemInitialDayOfLastPeriodWS As Integer
    Dim InitialDayOfTheMonthWS As Integer
    Dim AccountIdWS As Integer
    Dim n1 As String
    Private _AccountEmployeeTimeEntryTableAdapter As AccountEmployeeTimeEntryTableAdapter = Nothing
    Private _AccountEmployeeTimeEntryPeriodListTableAdapter As AccountEmployeeTimeEntryPeriodListTableAdapter = Nothing
    Private _AccountEmployeeTimeEntryApprovalTableAdapter As AccountEmployeeTimeEntryApprovalTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryApprovalTableAdapter As vueAccountEmployeeTimeEntryApprovalTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryApprovalPendingAdapter As vueAccountEmployeeTimeEntryApprovalPendingTableAdapter = Nothing
    Private _sumAccountEmployeeTimeEntryWeekSummaryTableAdapter As sumAccountEmployeeTimeEntryWeekSummaryTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryWithLastStatusTableAdapter As vueAccountEmployeeTimeEntryWithLastStatusTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryWithStatusTableAdapter As vueAccountEmployeeTimeEntryWithStatusTableAdapter = Nothing
    Private _AccountEmployeeTimeEntryPeriodAdapter As AccountEmployeeTimeEntryPeriodTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryPeriodAdapter As vueAccountEmployeeTimeEntryPeriodTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter As vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter As vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter As vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter As vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter = Nothing
    Private _vueTimesheetPendingForApprovalTableAdapter As vueTimesheetPendingForApprovalTableAdapter = Nothing
    Private _vueTimesheetEntriesForApprovalTableAdapter As vueTimesheetEntriesForApprovalTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryTableAdapter As vueAccountEmployeeTimeEntryTableAdapter = Nothing
    Private _vueAccountEmployeeTimeEntryForQBTableAdapter As vueAccountEmployeeTimeEntryForQBTableAdapter = Nothing
    Private _AccountEmployeeTimeEntryApprovalProjectAdapter As AccountEmployeeTimeEntryApprovalProjectTableAdapter = Nothing
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Adapter() As AccountEmployeeTimeEntryTableAdapter
        Get
            If _AccountEmployeeTimeEntryTableAdapter Is Nothing Then
                _AccountEmployeeTimeEntryTableAdapter = New AccountEmployeeTimeEntryTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryPeriodListTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryPeriodListTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeTimeEntryPeriodListAdapter() As AccountEmployeeTimeEntryPeriodListTableAdapter
        Get
            If _AccountEmployeeTimeEntryPeriodListTableAdapter Is Nothing Then
                _AccountEmployeeTimeEntryPeriodListTableAdapter = New AccountEmployeeTimeEntryPeriodListTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryPeriodListTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryWithLastStatusTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryWithLastStatusTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryWithLastStatusAdapter() As vueAccountEmployeeTimeEntryWithLastStatusTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryWithLastStatusTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryWithLastStatusTableAdapter = New vueAccountEmployeeTimeEntryWithLastStatusTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryWithLastStatusTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryWithStatusTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryWithStatusAdapter() As vueAccountEmployeeTimeEntryWithStatusTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryWithStatusTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryWithStatusTableAdapter = New vueAccountEmployeeTimeEntryWithStatusTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryWithStatusTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryWithLastStatusGroupedAdapter() As vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter = New vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryWithLastStatusGroupedTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryWithStatusGroupedAdapter() As vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter = New vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryPeriodApprovalDetailAdapter() As vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter = New vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryPeriodApprovalDetailTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryApprovalTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryApprovalTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeTimeEntryApprovalAdapter() As AccountEmployeeTimeEntryApprovalTableAdapter
        Get
            If _AccountEmployeeTimeEntryApprovalTableAdapter Is Nothing Then
                _AccountEmployeeTimeEntryApprovalTableAdapter = New AccountEmployeeTimeEntryApprovalTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryApprovalTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryApprovalProjectTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryApprovalProjectTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeTimeEntryApprovalProjectAdapter() As AccountEmployeeTimeEntryApprovalProjectTableAdapter
        Get
            If _AccountEmployeeTimeEntryApprovalProjectAdapter Is Nothing Then
                _AccountEmployeeTimeEntryApprovalProjectAdapter = New AccountEmployeeTimeEntryApprovalProjectTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryApprovalProjectAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryPeriodTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryPeriodTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeTimeEntryPeriodAdapter() As AccountEmployeeTimeEntryPeriodTableAdapter
        Get
            If _AccountEmployeeTimeEntryPeriodAdapter Is Nothing Then
                _AccountEmployeeTimeEntryPeriodAdapter = New AccountEmployeeTimeEntryPeriodTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryPeriodAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryPeriodTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryPeriodTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryPeriodAdapter() As vueAccountEmployeeTimeEntryPeriodTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryPeriodAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryPeriodAdapter = New vueAccountEmployeeTimeEntryPeriodTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryPeriodAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryApprovalWithProjectAdapter() As vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter = New vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryApprovalWithProjectTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryApprovalPendingTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryApprovalPendingAdapter() As vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryApprovalPendingAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryApprovalPendingAdapter = New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryApprovalPendingAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountEmployeeTimeEntryApprovalTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountEmployeeTimeEntryApprovalAdapter() As vueAccountEmployeeTimeEntryApprovalTableAdapter
        Get
            If _vueAccountEmployeeTimeEntryApprovalTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeEntryApprovalTableAdapter = New vueAccountEmployeeTimeEntryApprovalTableAdapter()
            End If
            Return _vueAccountEmployeeTimeEntryApprovalTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records
    ''' </summary>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAccountEmployeeTimeEntries() As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records
    ''' </summary>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryByTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountEmployeeTimeEntryDataTable", "GetAccountEmployeeTimeEntryByTimeEntryId", "AccountEmployeeTimeEntryId=" & AccountEmployeeTimeEntryId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEmployeeTimeEntryByTimeEntryId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountEmployeeTimeEntryByTimeEntryId = Adapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
            CacheManager.AddAccountDataInCache(GetAccountEmployeeTimeEntryByTimeEntryId, strCacheKey)
        End If
        Return GetAccountEmployeeTimeEntryByTimeEntryId
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Retual all AccountEmployeeTimeEntry records of spcified AccountEmployeeTimeEntryPeriodId and is not time off request required
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    Public Function GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdIsNotTimeOffRequestRequired(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeEntryPeriodIdIsNotTimeOffRequestRequired(AccountEmployeeTimeEntryPeriodId)
    End Function

    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records of specified AccountId And DatabaseFieldName
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountIdAndDatabaseFieldName(AccountId, DatabaseFieldName)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records of specified AccountEmployeeTimeEntryApprovalProjectId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryApprovalProjectId(ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryApprovalProjectId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryPeriodList records of specified AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, IncludeDateRange, TimesheetApprovalStatusId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimesheetApprovalStatusId"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriodList datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryPeriodList(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal TimesheetApprovalStatusId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodListDataTable
        GetAccountEmployeeTimeEntryPeriodList = AccountEmployeeTimeEntryPeriodListAdapter.GetAccountEmployeeTimeEntryPeriodList(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, IncludeDateRange, TimesheetApprovalStatusId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetAccountEmployeeTimeEntryPeriodList)
        Return GetAccountEmployeeTimeEntryPeriodList
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryPeriodApprovalDetail records of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryPeriodApprovalDetail datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryPeriodApprovalDetailByTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodApprovalDetailDataTable
        Return vueAccountEmployeeTimeEntryPeriodApprovalDetailAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApprovalWithProject records of specified BatchId
    ''' </summary>
    ''' <param name="BatchId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalWithProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryApprovalWithProjectByBatchId(ByVal BatchId As Guid) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalWithProjectDataTable
        Return vueAccountEmployeeTimeEntryApprovalWithProjectAdapter.GetDataByBatchId(BatchId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryPeriod records of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryPeriod datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryPeriodByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodDataTable
        Return vueAccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryPeriod records of specified AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType. 
    ''' After retrieved first time, datatable will be stored in TimeLive Cache collection with a unique key. 
    ''' If a cache record will be found, this function will simply return datatable from cache collection.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriod datatable</returns>
    ''' <remarks>This will return all AccountEmployeeTimeEntryPeriod of specified AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType</remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryViewType As String) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
        If DBUtilities.IsApplicationContext Then
            Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountId=" & AccountId & "_AccountEmployeeId=" & AccountEmployeeId & "_TimeEntryStartDate=" & TimeEntryStartDate & "_TimeEntryEndDate=" & TimeEntryEndDate & "_TimeEntryViewType=" & TimeEntryViewType, TimeEntryStartDate, TimeEntryEndDate)
            ' Creating of unique cache key by combining of parameter value and function name
            strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("AccountEmployeeTimeEntryPeriodDataTable", "GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView", strParameters)
            ' If found in cache, then return from cache collection
            If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
                GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView = CacheManager.GetItemFromCache(strCacheKey)
                Return GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView
            End If
        End If
        GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView = AccountEmployeeTimeEntryPeriodAdapter.GetDataByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType)
        CacheManager.AddAccountEmployeeDataInCache(GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView, strCacheKey)
        Return GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject records.
    ''' </summary>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetAccountEmployeeTimeEntryApprovalProject() As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Return GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryPeriodId
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject submitted records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSubmittedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetSubmittedTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject inapproval records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetInApprovalAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetInApprovalTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject approved records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetApprovedTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns approved status record of specified AccountEmployeeTimeEntryApprovalProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedStatusByAccountEmployeeTimeEntryApprovalProjectId(ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid) As Boolean
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetApprovedApprovalProjectByApprovalProjectId(AccountEmployeeTimeEntryApprovalProjectId)
    End Function
    ''' <summary>
    ''' Returns AccountEmployeeTimeEntryApprovalProjectId record of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalProjectIdByTimesheetPeriodIdAndProjectId(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer) As Guid
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetApprovalProjectIdByPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntryApprovalProject record of specified AccountEmployeeTimeEntryPeriodId if not exist.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    Public Function DeleteAccountEmployeeTimeEntryApprovalProjectIfNotExist(ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.DeleteAccountEmployeeTimeEntryApprovalProjectByPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject rejected records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetRejectedTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject records of specified AccountEmployeeTimeEntryApprovalProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryApprovalProjectId(ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryApprovalProjectId)
    End Function
    ''' Returns all AccountEmployeeTimeEntryApprovalProject records of specified AccountEmployeeTimeEntryApprovalProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryApprovalProjectIdAndApproved(ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid, ByVal Approved As Boolean) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectIdAndApproved(AccountEmployeeTimeEntryApprovalProjectId, Approved)
    End Function
    ''' <summary>
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApprovalProject records of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
        Return AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApproval records of specified AccountEmployeeTimeEntryid.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryid"></param>
    ''' <returns>AccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAccountEmployeeTimeEntriesApprovalByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryid As Integer) As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable
        Return AccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryid)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApproval records of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns>AccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAccountEmployeeTimeEntriesApprovalByTimeEntryPeriodIdAndProjectId(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable
        Return AccountEmployeeTimeEntryApprovalAdapter.GetDataByTimeEntryPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApprovalPending records.
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountAccountEmployeeTimeEntryApprovalPendings() As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Return vueAccountEmployeeTimeEntryApprovalPendingAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApproval records of specified TimeSheetApprovalId, TimeEntryAccountEmployeeId.
    ''' </summary>
    ''' <param name="TimeSheetApprovalId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountAccountEmployeeTimeEntryApprovalsByTimeSheetApprovalIdAndTimeEntryAccountEmployeeId(ByVal TimeSheetApprovalId As Integer, ByVal TimeEntryAccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalDataTable
        Return vueAccountEmployeeTimeEntryApprovalAdapter.GetDataByTimeSheetApprovalIdAndTimeEntryAccountEmployeeId(TimeSheetApprovalId, TimeEntryAccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApproval records of specified AccountEmployeeTimeEntryId, TimeEntryAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountAccountEmployeeTimeEntryApprovalsByAccountEmployeeTimeEntryIdAndTimeEntryAccountEmployeeId(ByVal AccountEmployeeTimeEntryId As Integer, ByVal TimeEntryAccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalDataTable
        Return vueAccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryIdAndTimeEntryAccountEmployeeId(AccountEmployeeTimeEntryId, TimeEntryAccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApproval records of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalDataTable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryApprovalsByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalDataTable
        Return vueAccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApproval approved records of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountAccountEmployeeTimeEntryApprovalsApprovedEMailByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalDataTable
        Return vueAccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryIdApprovedEMail(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryApproval rejected records of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountAccountEmployeeTimeEntryApprovalsRejectedEMailByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalDataTable
        Return vueAccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryIdRejectedEMail(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryApproval records.
    ''' </summary>
    ''' <returns>AccountEmployeeTimeEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryApprovals() As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable
        Return AccountEmployeeTimeEntryApprovalAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryIdForIsTimeOff(ByVal AccountEmployeeTimeEntryId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeEntryIdForIsTimeOff(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryViewType records of specified AccountEmployeeId, PeriodStartDate, PeriodEndDate.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <returns>AccountEmployeeTimeEntryViewType datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate(ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryViewTypeDataTable
        'Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_" & "TimeEntryStartDate=" & PeriodStartDate & "_" & "TimeEntryEndDate=" & PeriodStartDate, PeriodStartDate, PeriodStartDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        'strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("AccountEmployeeTimeEntryViewTypeDataTable", "GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate", strParameters)
        ' If found in cache, then return from cache collection.
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _AccountEmployeeTimeEntryViewType As New AccountEmployeeTimeEntryViewTypeTableAdapter
        GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate = _AccountEmployeeTimeEntryViewType.GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate(AccountEmployeeId, PeriodStartDate, PeriodEndDate)
        'CacheManager.AddAccountEmployeeDataInCache(GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate, strCacheKey)
        'End If
        Return GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryPeriodStartDate records of specified AccountEmployeeId, PeriodDate, TimeEntryViewType.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodDate"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriodStartDate datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPeriodStartDateByAccountEmployeeIdAndDate(ByVal AccountEmployeeId As Integer, ByVal PeriodDate As Date, ByVal TimeEntryViewType As String) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodStartDateDataTable
        Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_" & "PeriodDate=" & PeriodDate & "_" & "TimeEntryViewType=" & TimeEntryViewType, PeriodDate, PeriodDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("AccountEmployeeTimeEntryPeriodStartDateDataTable", "GetPeriodStartDateByAccountEmployeeIdAndDate", strParameters)
        ' If found in cache, then return from cache collection.
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetPeriodStartDateByAccountEmployeeIdAndDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _AccountEmployeeTimeEntryPeriodStartDate As New AccountEmployeeTimeEntryPeriodStartDateTableAdapter
            GetPeriodStartDateByAccountEmployeeIdAndDate = _AccountEmployeeTimeEntryPeriodStartDate.GetPeriodStartDateByAccountEmployeeIdAndDate(AccountEmployeeId, PeriodDate, TimeEntryViewType)
            CacheManager.AddAccountEmployeeDataInCache(GetPeriodStartDateByAccountEmployeeIdAndDate, strCacheKey)
        End If
        Return GetPeriodStartDateByAccountEmployeeIdAndDate
    End Function

    Public Function UpdateAccountEmployeeTimeEntryTimeOffRequestId(ByVal submitValue As Boolean, accountEmployeeId As Integer, timeOffRequestId As Guid)
        Return Adapter.UpdateSubmittedAccountEmployeeTimeOffRequestId(submitValue, timeOffRequestId, accountEmployeeId)
    End Function

    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryPeriodEndDate records of specified AccountEmployeeId, PeriodDate, TimeEntryViewType.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodDate"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriodEndDate datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPeriodEndDateByAccountEmployeeIdAndDate(ByVal AccountEmployeeId As Integer, ByVal PeriodDate As Date, ByVal TimeEntryViewType As String) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodEndDateDataTable
        Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_" & "PeriodDate=" & PeriodDate & "_" & "TimeEntryViewType=" & TimeEntryViewType, PeriodDate, PeriodDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("AccountEmployeeTimeEntryPeriodEndDateDataTable", "GetPeriodEndDateByAccountEmployeeIdAndDate", strParameters)
        ' If found in cache, then return from cache collection.
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetPeriodEndDateByAccountEmployeeIdAndDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _AccountEmployeeTimeEntryPeriodEndDate As New AccountEmployeeTimeEntryPeriodEndDateTableAdapter
            GetPeriodEndDateByAccountEmployeeIdAndDate = _AccountEmployeeTimeEntryPeriodEndDate.GetPeriodEndDateByAccountEmployeeIdAndDate(AccountEmployeeId, PeriodDate, TimeEntryViewType)
            CacheManager.AddAccountEmployeeDataInCache(GetPeriodEndDateByAccountEmployeeIdAndDate, strCacheKey)
        End If
        Return GetPeriodEndDateByAccountEmployeeIdAndDate
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryDataTable records of specified AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry team lead records of specified AccountProjectId, AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForTeamLeadByAccountEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetApprovalEntriesForTeamLead(AccountProjectId, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry project manager records of specified AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForProjectManagerByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetApprovalEntriesForProjectManager(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry organization records of specified AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForOrganizationByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetApprovalEntriesForOrganization(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry records of specified StartDate, EndDate.
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeEntriesByStartDateAndEndDate(ByVal StartDate As Date, ByVal EndDate As Date) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetTimeEntriesByStartDateAndEndDate(StartDate, EndDate)
    End Function
    ''' <summary>
    ''' Update billing rate of employee of specified BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountEmployeeId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="BillingRate"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeRate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="BillingRateCurrencyId"></param>
    ''' <param name="EmployeeRateCurrencyId"></param>
    ''' <param name="BillingRateExchangeRate"></param>
    ''' <param name="EmployeeRateExchangeRate"></param>
    ''' <param name="BaseCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfEmployee(ByVal BillingRate As Decimal, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As Integer, ByVal EmployeeRate As Decimal, ByVal AccountWorkTypeId As Integer, ByVal BillingRateCurrencyId As Integer, ByVal EmployeeRateCurrencyId As Integer, ByVal BillingRateExchangeRate As Double, ByVal EmployeeRateExchangeRate As Double, ByVal BaseCurrencyId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfEmployee(BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountEmployeeId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update unbillable billing rate of employee of specified StartDate, EndDate, AccountEmployeeId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfEmployeeUnBillable(ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfEmployeeUnBillable(StartDate, EndDate, AccountEmployeeId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update billing rate of project role of specified BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountProjectRoleId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="BillingRate"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountProjectRoleId"></param>
    ''' <param name="EmployeeRate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="BillingRateCurrencyId"></param>
    ''' <param name="EmployeeRateCurrencyId"></param>
    ''' <param name="BillingRateExchangeRate"></param>
    ''' <param name="EmployeeRateExchangeRate"></param>
    ''' <param name="BaseCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfProjectRole(ByVal BillingRate As Decimal, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountProjectRoleId As Integer, ByVal EmployeeRate As Decimal, ByVal AccountWorkTypeId As Integer, ByVal BillingRateCurrencyId As Integer, ByVal EmployeeRateCurrencyId As Integer, ByVal BillingRateExchangeRate As Double, ByVal EmployeeRateExchangeRate As Double, ByVal BaseCurrencyId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfProjectRole(BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountProjectRoleId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update Billing Rate Of Project Role of UnBillable of specified StartDate, EndDate, AccountProjectRoleId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountProjectRoleId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfProjectRoleUnBillable(ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountProjectRoleId As Integer, ByVal AccountWorkTypeId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfProjectRoleUnBillable(StartDate, EndDate, AccountProjectRoleId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update Billing Rate Of Project Employee of specified BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountProjectEmployeeId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="BillingRate"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountProjectEmployeeId"></param>
    ''' <param name="EmployeeRate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="BillingRateCurrencyId"></param>
    ''' <param name="EmployeeRateCurrencyId"></param>
    ''' <param name="BillingRateExchangeRate"></param>
    ''' <param name="EmployeeRateExchangeRate"></param>
    ''' <param name="BaseCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfProjectEmployee(ByVal BillingRate As Decimal, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountProjectEmployeeId As Integer, ByVal EmployeeRate As Decimal, ByVal AccountWorkTypeId As Integer, ByVal BillingRateCurrencyId As Integer, ByVal EmployeeRateCurrencyId As Integer, ByVal BillingRateExchangeRate As Double, ByVal EmployeeRateExchangeRate As Double, ByVal BaseCurrencyId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfProjectEmployee(BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountProjectEmployeeId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update Billing Rate Of Project Employee of Unbillable of specifiedStartDate, EndDate, AccountProjectEmployeeId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountProjectEmployeeId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfProjectEmployeeUnBillable(ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountProjectEmployeeId As Integer, ByVal AccountWorkTypeId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfProjectEmployeeUnBillable(StartDate, EndDate, AccountProjectEmployeeId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update Billing Rate Of Project Task of specified BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountProjectTaskId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="BillingRate"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="EmployeeRate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="BillingRateCurrencyId"></param>
    ''' <param name="EmployeeRateCurrencyId"></param>
    ''' <param name="BillingRateExchangeRate"></param>
    ''' <param name="EmployeeRateExchangeRate"></param>
    ''' <param name="BaseCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfProjectTask(ByVal BillingRate As Decimal, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountProjectTaskId As Integer, ByVal EmployeeRate As Decimal, ByVal AccountWorkTypeId As Integer, ByVal BillingRateCurrencyId As Integer, ByVal EmployeeRateCurrencyId As Integer, ByVal BillingRateExchangeRate As Double, ByVal EmployeeRateExchangeRate As Double, ByVal BaseCurrencyId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfProjectTask(BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, BaseCurrencyId, StartDate, EndDate, AccountProjectTaskId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Update Billing Rate Of Project Task of UnBillable of specified StartDate, EndDate, AccountProjectTaskId, AccountWorkTypeId.
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateBillingRateOfProjectTaskUnBillable(ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer) As Integer
        Return Adapter.UpdateBillingRateOfProjectTaskUnBillable(StartDate, EndDate, AccountProjectTaskId, AccountWorkTypeId)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry for user hours detail report records of specified StartDate, EndDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="Billable"></param>
    ''' <param name="AccountDepartmentID"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntry1 datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForUserHoursDetailReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountPartyId As Integer, ByVal Billable As String, ByVal AccountDepartmentID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
        Dim _vueAccountEmployeeTimeEntry1TableAdapter As New vueAccountEmployeeTimeEntry1TableAdapter
        Return _vueAccountEmployeeTimeEntry1TableAdapter.GetDataByUserHoursDetailReport(AccountId, AccountEmployees, AccountProjectId, AccountProjectTaskId, AccountPartyId, Billable, AccountDepartmentID, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry for user hours detail report records of specified AccountId, StartDate, EndDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntry1 datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeEntriesByAccountIdAndDateRange(ByVal AccountId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBDataTable
        Dim _vueAccountEmployeeTimeEntryForQBTableAdapter As New vueAccountEmployeeTimeEntryForQBTableAdapter
        Return _vueAccountEmployeeTimeEntryForQBTableAdapter.GetTimeEntriesByAccountIdAndDateRange(AccountId, TimeEntryStartDate, TimeEntryEndDate)
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntry for user hours detail report records of specified AccountId, AccountEmployeeId, StartDate, EndDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntry1 datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeEntriesByAccountEmployeeIdAndDateRange(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBDataTable
        Dim _vueAccountEmployeeTimeEntryForQBTableAdapter As New vueAccountEmployeeTimeEntryForQBTableAdapter
        Return _vueAccountEmployeeTimeEntryForQBTableAdapter.GetTimeEntriesByAccountEmployeeIdAndDateRange(AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryStatus records of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryStatus datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForTimeEntryStatus(ByVal AccountEmployeeTimeEntryId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryStatusDataTable
        Dim _vueAccountEmployeeTimeEntryStatusTableAdapter As New vueAccountEmployeeTimeEntryStatusTableAdapter
        Return _vueAccountEmployeeTimeEntryStatusTableAdapter.GetDataForTimeEntryStatus(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountEmployeeTimeEntryForTaskBillingReport records of specified AccountId, AccountEmployees, AccountPartyId, AccountProjectId, AccountProjectTaskId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForTaskBillingReport datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForTaskSummarReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountPartyId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
        Dim _vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter As New vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter
        Return _vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter.GetDataByTaskSummaryReport(AccountId, AccountEmployees, AccountPartyId, AccountProjectId, AccountProjectTaskId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Return AccountBaseCurrencyId of specified AccountId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAccountBaseCurrencyId(ByVal AccountId As Integer) As Integer
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = BLL.GetvueAccountBaseCurrencyByAccountId(AccountId)
        Dim dr As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountBaseCurrencyId
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Return BillingRateExchangeRate of specified AccountId, BillingRateCurrencyId, TimeEntryDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="BillingRateCurrencyId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentBillingRateExchangeRate(ByVal AccountId As Integer, ByVal BillingRateCurrencyId As Integer, ByVal TimeEntryDate As Date) As Decimal
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = BLL.GetExchangeRateByAccountCurrencyIdAndTimeEntryDate(AccountId, BillingRateCurrencyId, TimeEntryDate)
        Dim dr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.ExchangeRate
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Return EmployeeRateExchangeRate of specified AccountId, EmployeeRateCurrencyId, TimeEntryDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="EmployeeRateCurrencyId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentEmployeeRateExchangeRate(ByVal AccountId As Integer, ByVal EmployeeRateCurrencyId As Integer, ByVal TimeEntryDate As Date) As Decimal
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = BLL.GetExchangeRateByAccountCurrencyIdAndTimeEntryDate(AccountId, EmployeeRateCurrencyId, TimeEntryDate)
        Dim dr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.ExchangeRate
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Return all employee time entries of specified AccountEmployeeId, TimeEntryDate, IsCopy.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="IsCopy"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, ByVal IsCopy As Boolean) As Object
        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("vueAccountEmployeeTimeEntryDataTable", "GetAccountEmployeeTimeEntriesByDate", "AccountEmployeeId=" & AccountEmployeeId & "&TimeEntryDate=" & TimeEntryDate & "&IsCopy=" & IsCopy)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEmployeeTimeEntriesByDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountEmployeeTimeEntriesByDate = vueAccountEmployeeTimeEntryWithLastStatusAdapter.GetDataByEmployeeIdAndDate(AccountEmployeeId, TimeEntryDate, IsCopy, LocaleUtilitiesBLL.IsShowTimeOffInTimesheet)
            If GetAccountEmployeeTimeEntriesByDate.Columns.Item("TimeType") Is Nothing Then
                GetAccountEmployeeTimeEntriesByDate.Columns.Add("TimeType", GetType(System.String), "")
                GetAccountEmployeeTimeEntriesByDate.Columns.Add("GroupFieldTimeOff", GetType(System.String), "")
            End If
            For n As Integer = 0 To GetAccountEmployeeTimeEntriesByDate.Rows.Count - 1
                If GetAccountEmployeeTimeEntriesByDate.Item(n)("IsTimeOff") = "False" Then
                    GetAccountEmployeeTimeEntriesByDate.Item(n)("TimeType") = "Standard Time"
                    GetAccountEmployeeTimeEntriesByDate.Item(n)("GroupFieldTimeOff") = "1"
                Else
                    GetAccountEmployeeTimeEntriesByDate.Item(n)("TimeType") = "Time Off"
                    GetAccountEmployeeTimeEntriesByDate.Item(n)("GroupFieldTimeOff") = "2"
                End If
            Next
            For i As Integer = 0 To DBUtilities.GetNumberOfBlankRowsInTimeEntry - 1
                AddRowsInDatatable(GetAccountEmployeeTimeEntriesByDate, "Standard Time", "False", "1")
            Next
            If LocaleUtilitiesBLL.IsShowTimeOffInTimesheet Then
                For i As Integer = 0 To 2 - 1
                    AddRowsInDatatable(GetAccountEmployeeTimeEntriesByDate, "Time Off", "True", "2")
                Next
            End If
            CacheManager.AddAccountEmployeeDataInCache(GetAccountEmployeeTimeEntriesByDate, strCacheKey)
        End If
        GetAccountEmployeeTimeEntriesByDate.DefaultView.Sort = "GroupFieldTimeOff"
        Return GetAccountEmployeeTimeEntriesByDate.DefaultView
    End Function
    ''' <summary>
    ''' Return all employee time entries of specified AccountEmployeeId, TimeEntryDate, IsCopy From TimeLive Mobile.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="IsCopy"></param>
    ''' <param name="IsFromMobile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateForMobile(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, ByVal IsCopy As Boolean, ByVal IsFromMobile As Boolean) As Object
        GetAccountEmployeeTimeEntriesByDateForMobile = vueAccountEmployeeTimeEntryWithLastStatusAdapter.GetDataByEmployeeIdAndDate(AccountEmployeeId, TimeEntryDate, IsCopy, LocaleUtilitiesBLL.IsShowTimeOffInTimesheet, IsFromMobile)
        Return GetAccountEmployeeTimeEntriesByDateForMobile.DefaultView
    End Function
    ''' <summary>
    ''' Add rows in data table of specified DataTable, TimeType, IsTimeOff, GroupFieldTimeOff.
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="TimeType"></param>
    ''' <param name="IsTimeOff"></param>
    ''' <param name="GroupFieldTimeOff"></param>
    ''' <remarks></remarks>
    Public Sub AddRowsInDatatable(ByVal dt As DataTable, ByVal TimeType As String, ByVal IsTimeOff As String, ByVal GroupFieldTimeOff As String)
        Dim objRow As DataRow
        objRow = dt.NewRow()
        objRow("AccountEmployeeId") = 0
        objRow("TimeEntryDate") = Now.Date
        objRow("IsTimeOff") = IsTimeOff
        objRow("TimeType") = TimeType
        objRow("GroupFieldTimeOff") = GroupFieldTimeOff
        dt.Rows.Add(objRow)
    End Sub
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithLastStatus of specified AccountEmployeeId, TimeEntryDate.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <returns>
    ''' vueAccountEmployeeTimeEntryWithLastStatus data table.
    ''' </returns>
    ''' <remarks>
    ''' This will return all AccountEmployeeTimeEntries by date of specified AccountEmployeeId, TimeEntryDate.
    ''' </remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateForCopyTimeSheet(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
        Return vueAccountEmployeeTimeEntryWithLastStatusAdapter.GetDataByEmployeeIdAndDate(AccountEmployeeId, TimeEntryDate)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatus of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate.
    ''' After retrieved first time, datatable will be stored in TimeLive Cache collection with a unique key. 
    ''' If a cache record will be found, this function will simply return datatable from cache collection.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatus data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateRangeWithStatus(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, Optional ByVal IsFromMobileTimeSheet As Boolean = False) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
        Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_" & "TimeEntryStartDate=" & TimeEntryStartDate & "_" & "TimeEntryEndDate=" & TimeEntryEndDate, TimeEntryStartDate, TimeEntryEndDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("vueAccountEmployeeTimeEntryWithStatusDataTable", "GetAccountEmployeeTimeEntriesByDateRangeWithStatus", strParameters)
        ' If found in cache, then return from cache collection.
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEmployeeTimeEntriesByDateRangeWithStatus = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountEmployeeTimeEntriesByDateRangeWithStatus = vueAccountEmployeeTimeEntryWithStatusAdapter.GetDataByAccountEmployeeIdAndDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, IsFromMobileTimeSheet)
            CacheManager.AddAccountEmployeeDataInCache(GetAccountEmployeeTimeEntriesByDateRangeWithStatus, strCacheKey)
        End If
        Return GetAccountEmployeeTimeEntriesByDateRangeWithStatus
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithLast of speified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithLastStatus data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateRange(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
        GetAccountEmployeeTimeEntriesByDateRange = vueAccountEmployeeTimeEntryWithLastStatusAdapter.GetDataByAccountEmployeeIdAndDateRange(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Return GetAccountEmployeeTimeEntriesByDateRange
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatus of specified AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate.
    ''' After retrieved first time, datatable will be stored in TimeLive Cache collection with a unique key. 
    ''' If a cache record will be found, this function will simply return datatable from cache collection.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatus data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, Optional ByVal IsFromMobileTimeSheet As Boolean = False) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
        Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_" & "TimeEntryStartDate=" & TimeEntryStartDate & "_" & "TimeEntryEndDate=" & TimeEntryEndDate, TimeEntryStartDate, TimeEntryEndDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        'strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("vueAccountEmployeeTimeEntryWithStatusDataTable", "GetAccountEmployeeTimeEntriesByPeriodId", strParameters)
        ' If found in cache, then return from cache collection.
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountEmployeeTimeEntriesByPeriodId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        GetAccountEmployeeTimeEntriesByPeriodId = vueAccountEmployeeTimeEntryWithStatusAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId, IsFromMobileTimeSheet)
        '    CacheManager.AddAccountEmployeeDataInCache(GetAccountEmployeeTimeEntriesByPeriodId, strCacheKey)
        'End If
        Return GetAccountEmployeeTimeEntriesByPeriodId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountEmployeeTimeEntryWithLastStatusDataTable", "GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView", "AccountEmployeeId=" & AccountEmployeeId & "_TimeEntryStartDate=" & TimeEntryStartDate & "_TimeEntryEndDate=" & TimeEntryEndDate)
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView = vueAccountEmployeeTimeEntryWithLastStatusAdapter.GetDataByAccountEmployeeIdAndDateRangeForDescriptionReadOnlyView(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        'CacheManager.AddAccountDataInCache(GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView, strCacheKey)
        'End If
        Return GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithLastStatus of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="ViewerAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithLastStatus data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyViewForRelevantProject(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, ByVal ViewerAccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
        GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyViewForRelevantProject = vueAccountEmployeeTimeEntryWithLastStatusAdapter.GetDataByAccountEmployeeIdAndDateRangeForDescriptionReadOnlyViewForRelevantProject(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId)
        Return GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyViewForRelevantProject
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithLastStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithLastStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRange(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithLastStatusGroupedDataTable
        GetGroupedTimeEntryByDateRange = vueAccountEmployeeTimeEntryWithLastStatusGroupedAdapter.GetGroupedTimeEntryByDateRange(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Return GetGroupedTimeEntryByDateRange
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate.
    ''' After retrieved first time, datatable will be stored in TimeLive Cache collection with a unique key. 
    ''' If a cache record will be found, this function will simply return datatable from cache collection.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRangeWithStatus(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_TimeEntryStartDate=" & TimeEntryStartDate & "_TimeEntryEndDate=" & TimeEntryEndDate, TimeEntryStartDate, TimeEntryEndDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("vueAccountEmployeeTimeEntryWithStatusGroupedDataTable", "GetGroupedTimeEntryByDateRangeWithStatus", strParameters)
        ' If found in cache, then return from cache collection.
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetGroupedTimeEntryByDateRangeWithStatus = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetGroupedTimeEntryByDateRangeWithStatus = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetGroupedTimeEntryByDateRange(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
            CacheManager.AddAccountEmployeeDataInCache(GetGroupedTimeEntryByDateRangeWithStatus, strCacheKey)
        End If
        Return GetGroupedTimeEntryByDateRangeWithStatus
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate.
    ''' After retrieved first time, datatable will be stored in TimeLive Cache collection with a unique key. 
    ''' If a cache record will be found, this function will simply return datatable from cache collection.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByPeriodIdWithStatus(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountEmployeeId=" & AccountEmployeeId & "_TimeEntryStartDate=" & TimeEntryStartDate & "_TimeEntryEndDate=" & TimeEntryEndDate, TimeEntryStartDate, TimeEntryEndDate)
        ' Creating of unique cache key by combining of parameter value and function name.
        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("vueAccountEmployeeTimeEntryWithStatusGroupedDataTable", "GetGroupedTimeEntryByPeriodIdWithStatus", strParameters)
        ' If found in cache, then return from cache collection.
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetGroupedTimeEntryByPeriodIdWithStatus = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetGroupedTimeEntryByPeriodIdWithStatus = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
            CacheManager.AddAccountEmployeeDataInCache(GetGroupedTimeEntryByPeriodIdWithStatus, strCacheKey)
        End If
        Return GetGroupedTimeEntryByPeriodIdWithStatus
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="ViewerAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRangeForRelevantProjectTeamLead(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, ByVal ViewerAccountEmployeeId As Integer) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        GetGroupedTimeEntryByDateRangeForRelevantProjectTeamLead = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetGroupedTimeEntryByDateRangeForRelevantProjectTeamLead(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId)
        Return GetGroupedTimeEntryByDateRangeForRelevantProjectTeamLead
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="ViewerAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRangeForRelevantProjectProjectManager(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, ByVal ViewerAccountEmployeeId As Integer) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        GetGroupedTimeEntryByDateRangeForRelevantProjectProjectManager = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetGroupedTimeEntryByDateRangeForRelevantProjectProjectManager(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId)
        Return GetGroupedTimeEntryByDateRangeForRelevantProjectProjectManager
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="ViewerAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificEmployee(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, ByVal ViewerAccountEmployeeId As Integer) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificEmployee = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificEmployee(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId)
        Return GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificEmployee
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="ViewerAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificExternalUser(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, ByVal ViewerAccountEmployeeId As Integer) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificExternalUser = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificExternalUser(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId)
        Return GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificExternalUser
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryWithStatusGrouped of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="ViewerAccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryWithStatusGrouped data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedTimeEntryByDateRangeForRelevantProjectEmployeeManager(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As DateTime, ByVal ViewerAccountEmployeeId As Integer) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        GetGroupedTimeEntryByDateRangeForRelevantProjectEmployeeManager = vueAccountEmployeeTimeEntryWithStatusGroupedAdapter.GetGroupedTimeEntryByDateRangeForRelevantProjectEmployeeManager(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, ViewerAccountEmployeeId)
        Return GetGroupedTimeEntryByDateRangeForRelevantProjectEmployeeManager
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference of specified ApproverEmployeeId.
    ''' </summary>
    ''' <param name="ApproverEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryApprovalsWithPreferenceByApproverEmployeeId(ByVal ApproverEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter.GetDataByApproverEmployeeId(ApproverEmployeeId)
    End Function
    ''' <summary>
    ''' Inserting into logfile.
    ''' </summary>
    ''' <param name="ApproverEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail(ByVal ApproverEmployeeId As Integer, AccountId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceDataTable
        LoggingBLL.WriteToLog("GetPendingTimeEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail" & " " & ApproverEmployeeId & " and AccountId=" & AccountId)
        Dim _vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter
        '_vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter.SetCommandTimeOut(5000)
        GetPendingTimeEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail = _vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter.GetDataByApproverEmployeeIdForEmail(ApproverEmployeeId, AccountId)
        '_vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter.SetCommandTimeOut(30)
        Return GetPendingTimeEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeId.
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeId data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryApprovalsWithPreferenceGroupByApproverEmployeeId() As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter
        '_vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter.SetCommandTimeOut(5000)
        GetPendingTimeEntryApprovalsWithPreferenceGroupByApproverEmployeeId = _vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter.GetData()
        '_vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter.SetCommandTimeOut(30)
        Return GetPendingTimeEntryApprovalsWithPreferenceGroupByApproverEmployeeId
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovedEmail of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovedEmail data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedAccountEmployeeTimeEntryForEmail(ByVal AccountEmployeeTimeEntryId) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovedEmailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovedEmail As New vueAccountEmployeeTimeEntryApprovedEmailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovedEmail.GetDataByTimeEntryId(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryRejectedEmail of specified AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns>AccountEmployeeTimeEntryId.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedAccountEmployeeTimeEntryForEmail(ByVal AccountEmployeeTimeEntryId) As TimeLiveDataSet.vueAccountEmployeeTimeEntryRejectedEmailDataTable
        Dim _vueAccountEmployeeTimeEntryRejectedEmail As New vueAccountEmployeeTimeEntryRejectedEmailTableAdapter
        Return _vueAccountEmployeeTimeEntryRejectedEmail.GetDataByTimeEntryId(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPending of specified TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForTeamLead(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter.GetApprovalEntriesForTeamLead1(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryForTaskBillingReport of specified AccountId, AccountPartyId, AccountEmployees, AccountProjectId, AccountProjectTaskId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForTaskBillingReport data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForReport(ByVal AccountId As Integer, ByVal AccountPartyId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Long, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
        Dim _vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter As New vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter
        Return _vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter.GetDataByAccountIdAndEmployees(AccountId, AccountPartyId, AccountEmployees, AccountProjectId, AccountProjectTaskId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Billable)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPending of specified AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryApprovalsByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPendingEMail of specified AccountEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingEMail data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryApprovalsEMailByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEMailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingEMailTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingEMailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingEMailTableAdapter.GetDataByAccountEmployeeIdPendingEMail(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntry1 of specified AccountId, AccountEmployees, AccountProjectId, AccountProjectTaskId, AccountPartyId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountEmployeeTimeEntry1 data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForDetailTimeSheetReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Long, ByVal AccountPartyId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
        Dim _vueAccountEmployeeTimeEntry1TableAdapter As New vueAccountEmployeeTimeEntry1TableAdapter
        Return _vueAccountEmployeeTimeEntry1TableAdapter.GetDataByAccountIdAndEmployees(AccountId, AccountEmployees, AccountProjectId, AccountProjectTaskId, AccountPartyId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntry1 of specified AccountId, AccountEmployees, AccountProjectId, AccountProjectTaskId, AccountPartyId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountEmployeeTimeEntry1 data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForDetailTimeSheetReportForTimeSheetArchive(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Long, ByVal AccountPartyId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
        Dim _vueAccountEmployeeTimeEntry1TableAdapter As New vueAccountEmployeeTimeEntry1TableAdapter
        Return _vueAccountEmployeeTimeEntry1TableAdapter.GetDataByAccountIdAndEmployeesForTimeSheetArchive(AccountId, AccountEmployees, AccountProjectId, AccountProjectTaskId, AccountPartyId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Return vueEmployeeProjectUtilizationReport of specified AccountId, AccountPartyId, AccountProjectId, AccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueEmployeeProjectUtilizationReport data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForEmployeeProjectUtilizationReport(ByVal AccountId As Integer, ByVal AccountPartyId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As TimeLiveDataSet.vueEmployeeProjectUtilizationReportDataTable
        Dim _vueEmployeeProjectUtilizationReportTableAdapter As New vueEmployeeProjectUtilizationReportTableAdapter
        Return _vueEmployeeProjectUtilizationReportTableAdapter.GetDataForEmployeeProjectUtilizationReport(AccountId, AccountPartyId, AccountProjectId, AccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPending of specified TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificEmployee(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter.GetApprovalEntriesForSpecificEmployee1(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPending of specified TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificExternalUser(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter.GetApprovalEntriesForSpecificExternalUser1(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPending of specified TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForProjectManager(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter.GetApprovalEntriesForProjectManager1(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Return vueAccountEmployeeTimeEntryApprovalPending of specified 
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPending data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForEmployeeManager(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingTableAdapter.GetApprovalEntriesForEmployeeManager1(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, AccountProjectId)
    End Function
    ''' <summary>
    ''' Return sumAccountEmployeeTimeEntryWeekSummary of specified TimeEntryStartDate, AccountEmployeeId, TimeEntryEndDate.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>sumAccountEmployeeTimeEntryWeekSummary data table.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryWeekSummmaryByEmployeeId(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.sumAccountEmployeeTimeEntryWeekSummaryDataTable
        Dim _sumAccountEmployeeTimeEntryWeekSummaryTableAdapter As New sumAccountEmployeeTimeEntryWeekSummaryTableAdapter
        GetAccountEmployeeTimeEntryWeekSummmaryByEmployeeId = _sumAccountEmployeeTimeEntryWeekSummaryTableAdapter.GetDataByAccountEmployeeIdAndTimeEntryDateRange(TimeEntryStartDate, AccountEmployeeId, TimeEntryEndDate)
        Return GetAccountEmployeeTimeEntryWeekSummmaryByEmployeeId
    End Function
    ''' <summary>
    ''' Return LastInsertedId.
    ''' </summary>
    ''' <returns>LastInsertedId.</returns>
    ''' <remarks></remarks>
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountEmployeeTimeEntryLastId.Rows(0)
        Return a.LastId
    End Function
    ''' <summary>
    ''' Add AccountEmployeeTimeEntry for import export.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="StartTime"></param>
    ''' <param name="EndTime"></param>
    ''' <param name="TotalTime"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="Description"></param>
    ''' <param name="Approved"></param>
    ''' <param name="CreatedOn"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="AccountCostCenterId"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="RowsCountEqual"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntryForImportExport( _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeEntryDate As DateTime, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal Description As String, _
                    ByVal Approved As Boolean, _
                    ByVal CreatedOn As Date, _
                    ByVal ModifiedOn As Date, _
                    ByVal AccountPartyId As Integer, _
                    ByVal Submitted As Boolean, _
                    ByVal AccountWorkTypeId As Integer, _
                    ByVal AccountCostCenterId As Integer, _
                    ByVal TimesheetPeriodType As String, _
                    ByVal PeriodStartDate As Date, _
                    ByVal PeriodEndDate As Date, _
                    ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal RowsCountEqual As Boolean, _
                    ByVal OfflineTimesheet As Boolean _
                   ) As Boolean
        If CheckCurrentPeriodDateForOfflineTimesheet(OfflineTimesheet, TimeEntryDate) Then
            If OfflineTimesheet Then
                AccountEmployeeId = Convert.ToInt32(System.Web.HttpContext.Current.Session("OfflineTimesheetAccountEmployeeId"))
            End If
            If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate)
                TimesheetPeriodType = TimesheetPeriodTypeTS
                PeriodStartDate = PeriodStartDateTS
                PeriodEndDate = PeriodEndDateTS
                AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodIdTS
            End If
            Dim HoursOff As Double
            Dim Hours As Decimal
            Dim TArray() As String
            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" And TotalTime.Contains(":") Then
                ''done
                Dim strHoursOff As String() = Split(Replace(TotalTime, ":", "."), ".")
                If strHoursOff.Length = 1 Then
                    HoursOff = strHoursOff(0)
                Else
                    HoursOff = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strHoursOff(0), strHoursOff(1))
                End If
            ElseIf DBUtilities.IsTimeEntryHoursFormat = "Decimal" And TotalTime.Contains(".") Then
                ''done
                HoursOff = TotalTime

            ElseIf DBUtilities.IsTimeEntryHoursFormat = "Time" And TotalTime.Contains(":") Then
                ''done
            ElseIf DBUtilities.IsTimeEntryHoursFormat = "Time" And TotalTime.Contains(".") Then
                ''done
                TArray = Convert.ToDouble(TotalTime, LocaleUtilitiesBLL.GetBaseCultureInfo).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
                Hours = Convert.ToDecimal(TotalTime, LocaleUtilitiesBLL.GetBaseCultureInfo)
                TotalTime = LocaleUtilitiesBLL.ConvertHoursToTimeFormat(TArray(0), TArray(1))
                ''TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)

            End If
            Dim InsertedAccountEmployeeTimeEntryId As Integer = Me.AddAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, StartTime, EndTime, IIf(DBUtilities.IsTimeEntryHoursFormat = "Decimal", HoursOff, TotalTime), AccountProjectId, AccountProjectTaskId, Description, Approved, CreatedOn, ModifiedOn, AccountPartyId, Submitted, AccountWorkTypeId, AccountCostCenterId, TimesheetPeriodType, PeriodStartDate, PeriodEndDate, AccountEmployeeTimeEntryPeriodId, False, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty, 0)
            Me.SetAccountEmployeeTimeEntryApprovalProject(InsertedAccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId, AccountProjectId, AccountEmployeeId, 0, Submitted, False, False, Approved, False, TimesheetPeriodType, AccountProjectId)
            Me.SetAccountEmployeeTimeEntryPeriodApprovalStatus(DBUtilities.GetSessionAccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType, AccountEmployeeTimeEntryPeriodId)
            Dim count As Integer = 0
            If Not System.Web.HttpContext.Current.Session("OfflineTimesheetCount") Is Nothing Then
                count = System.Web.HttpContext.Current.Session("OfflineTimesheetCount")
            Else
                System.Web.HttpContext.Current.Session.Add("OfflineTimesheetCount", count)
            End If
            System.Web.HttpContext.Current.Session("OfflineTimesheetCount") = count + 1
        End If
    End Function
    Public Function CheckCurrentPeriodDateForOfflineTimesheet(OfflineTimesheet As Boolean, TimeEntryDate As Date) As Boolean
        If OfflineTimesheet Then
            Dim dtStartDate As Date = System.Web.HttpContext.Current.Session("OfflineTimesheetStartDate")
            Dim dtEndDate As Date = System.Web.HttpContext.Current.Session("OfflineTimesheetEndDate")
            If TimeEntryDate >= dtStartDate And TimeEntryDate <= dtEndDate Then
                Return True
            End If
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntryFromAPI(ByVal AccountId As Integer, _
                    ByVal AccountEmployeeId As Integer, _
                    ByVal TimeEntryDate As DateTime, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal TotalTime As Double, _
                    ByVal Description As String, _
                    ByVal Submitted As Boolean _
                   ) As Boolean
        If TotalTime > 23.99 Then
            Throw New Exception("You may not enter more than 24 hours per day")
        End If
        Dim AccountEmployeeTimeEntryPeriodId As Guid
        Dim TimesheetPeriodType As String
        Dim PeriodStartDate As Date
        Dim PeriodEndDate As Date
        Dim AccountWorkTypeId As Integer
        Dim WorkTypeBLL As New AccountWorkTypeBLL
        AccountWorkTypeId = WorkTypeBLL.GetAccountWorkTypeByAccountId(AccountId).Rows(0)("AccountWorkTypeId")
        If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            SetPeriodDataByAccountEmployeeIdAndTimeEntryDateForAPI(AccountId, AccountEmployeeId, TimeEntryDate)
            TimesheetPeriodType = TimesheetPeriodTypeTS
            PeriodStartDate = PeriodStartDateTS
            PeriodEndDate = PeriodEndDateTS
            AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodIdTS
        End If
        Dim TH() As String
        Dim TotalHours As String
        TH = (TotalTime).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
        TotalHours = LocaleUtilitiesBLL.ConvertHoursToTimeFormat(TH(0), TH(1))
        Description = IIf(Description = "", Nothing, Description)
        AccountIdWS = AccountId
        Dim InsertedAccountEmployeeTimeEntryId As Integer = Me.AddAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, Nothing, Nothing, TotalHours, AccountProjectId, AccountProjectTaskId, Description, False, Now, Now, 0, Submitted, AccountWorkTypeId, 0, TimesheetPeriodTypeTS, PeriodStartDateTS, PeriodEndDateTS, AccountEmployeeTimeEntryPeriodIdTS, False, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty, 0)
        Me.SetAccountEmployeeTimeEntryApprovalProject(InsertedAccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId, AccountProjectId, AccountEmployeeId, 0, Submitted, False, False, False, False, TimesheetPeriodType, AccountProjectId)
        Me.SetAccountEmployeeTimeEntryPeriodApprovalStatus(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType, AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Add AccountEmployeeTimeEntry.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="StartTime"></param>
    ''' <param name="EndTime"></param>
    ''' <param name="TotalTime"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="Description"></param>
    ''' <param name="Approved"></param>
    ''' <param name="CreatedOn"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="AccountCostCenterId"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="IsTimeOff"></param>
    ''' <param name="AccountTimeOffTypeId"></param>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns>InsertedAccountEmployeeTimeEntryId</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntry( _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeEntryDate As DateTime, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal Description As String, _
                    ByVal Approved As Boolean, _
                    ByVal CreatedOn As Date, _
                    ByVal ModifiedOn As Date, _
                    ByVal AccountPartyId As Integer, _
                    ByVal Submitted As Boolean, _
                    ByVal AccountWorkTypeId As Integer, _
                    ByVal AccountCostCenterId As Integer, _
                    ByVal TimesheetPeriodType As String, _
                    ByVal PeriodStartDate As Date, _
                    ByVal PeriodEndDate As Date, _
                    ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal IsTimeOff As Boolean, _
                    ByVal AccountTimeOffTypeId As Guid, _
                    ByVal AccountEmployeeTimeOffRequestId As Guid, _
                    ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                    ByVal Percentage As Double, _
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
        'LoggingBLL.WriteToLog("BLL-AddAccountEmployeeTimeEntry Start: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
        '  DBUtilities.GetSessionAccountEmployeeId & " TimeEntryDate=" & TimeEntryDate & _
        '  " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
        '  AccountEmployeeTimeEntryApprovalProjectId.ToString)

        Try
            _AccountEmployeeTimeEntryTableAdapter = New AccountEmployeeTimeEntryTableAdapter
            Dim Hours As Decimal
            Dim TimeOffConsumedHours As String = TotalTime
            Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
            Dim AccountEmployeeTimeEntries As New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
            Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.NewAccountEmployeeTimeEntryRow
            If Not StartTime Is Nothing And StartTime <> "" Then
                StartTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(StartTime, TimeEntryDate)
            End If
            If Not EndTime Is Nothing And EndTime <> "" Then
                EndTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(EndTime, TimeEntryDate)
            End If
            Dim HArray() As String
            Dim TArray() As String
            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                If LocaleUtilitiesBLL.IsNotSupportedCultureFormatsForDecimal Then
                    TArray = Convert.ToDouble(TotalTime, LocaleUtilitiesBLL.GetCurrentCultureInfo).ToString("N", LocaleUtilitiesBLL.GetCurrentCultureInfo).Split(".")
                    Hours = Convert.ToDecimal(TotalTime, LocaleUtilitiesBLL.GetCurrentCultureInfo)
                    TotalTime = Replace(TotalTime, ",", ".")
                End If
                ''''Dim IETotalTime = Replace(TotalTime, ":", ".")

                TArray = Convert.ToDouble(TotalTime, LocaleUtilitiesBLL.GetBaseCultureInfo).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
                Hours = Convert.ToDecimal(TotalTime, LocaleUtilitiesBLL.GetBaseCultureInfo)
                TotalTime = LocaleUtilitiesBLL.ConvertHoursToTimeFormat(TArray(0), TArray(1))
                TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)
            ElseIf DBUtilities.IsTimeEntryHoursFormat = "Time" Then
                HArray = Split(TotalTime, ":")
                If HArray.Length = 1 Then
                    Hours = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray(0), 0)
                Else
                    Hours = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray(0), HArray(1))
                End If
                TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)
            Else
                HArray = Split(TotalTime, ":")
                TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)
            End If
            Dim FixedCost As Decimal = 0
            Dim BillingRate As Decimal = 0
            Dim EmployeeRate As Decimal = 0
            Dim BillingRateCurrencyId As Integer = 0
            Dim EmployeeRateCurrencyId As Integer = 0
            Dim AccountBaseCurrencyId As Integer = 0
            Dim BillingRateExchangeRate As Double = 0
            Dim EmployeeRateExchangeRate As Double = 0
            Dim IsBillingModePerHour As Boolean
            If Not IsTimeOff Then
                BillingRate = Me.GetCurrentBillingRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                EmployeeRate = Me.GetCurrentEmployeeRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                BillingRateCurrencyId = Me.GetCurrentBillingRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                If Not BillingRateCurrencyId = Nothing Then
                    BillingRateCurrencyId = BillingRateCurrencyId
                End If
                EmployeeRateCurrencyId = Me.GetCurrentEmployeeRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                If Not EmployeeRateCurrencyId = Nothing Then
                    EmployeeRateCurrencyId = EmployeeRateCurrencyId
                End If
                AccountBaseCurrencyId = Me.GetAccountBaseCurrencyId(IIf(Not System.Web.HttpContext.Current.Session Is Nothing, DBUtilities.GetSessionAccountId, AccountIdWS))
                BillingRateExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(BillingRateCurrencyId, TimeEntryDate)
                EmployeeRateExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(EmployeeRateCurrencyId, TimeEntryDate)

                IsBillingModePerHour = Me.IsBillingModePerHour(AccountPartyId)
                If IsBillingModePerHour <> True Then
                    FixedCost = Me.GetFixBidCost(AccountPartyId, AccountProjectId, AccountProjectTaskId)
                    BillingRate = FixedCost
                End If
            End If

            If CheckTimeEntryDateInPeriod(AccountEmployeeTimeEntryPeriodId, TimeEntryDate) = False Then
                Throw New Exception("Date differ from period date.")
            End If


            Dim InsertedAccountEmployeeTimeEntryId As Integer = Me.Adapter.TimeEntryInsert(AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, _
             AccountProjectId, IIf(IsTimeOff, Nothing, AccountProjectTaskId), _
            Description, Approved, _
            Now, Now, AccountPartyId, Submitted, IIf(AccountWorkTypeId <> 0 And IsTimeOff = False, AccountWorkTypeId, Nothing), _
            IIf(Not AccountCostCenterId <= 0 And IsTimeOff = False, AccountCostCenterId, Nothing), AccountEmployeeTimeEntryPeriodId, _
            IsTimeOff, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, _
            BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, _
            BillingRateExchangeRate, EmployeeRateExchangeRate, AccountBaseCurrencyId, IIf(IsTimeOff = False, AccountEmployeeTimeEntryApprovalProjectId, System.Guid.Empty), Percentage, Hours, IIf(IsBillingModePerHour = True, False, True), _
            CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, _
            CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15)

            'LoggingBLL.WriteToLog("BLL-AddAccountEmployeeTimeEntry End: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
            '   DBUtilities.GetSessionAccountEmployeeId & " TimeEntryDate=" & TimeEntryDate & _
            '   " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
            '   AccountEmployeeTimeEntryApprovalProjectId.ToString)

            If IsTimeOff = True And AccountEmployeeTimeOffRequestId = System.Guid.Empty And Approved = True Then
                Me.UpdateEmployeeTimeOffHours(AccountEmployeeId, AccountTimeOffTypeId, TimeOffConsumedHours, "System-As Approval not Required", "Approved", "TimeEntry Week View", InsertedAccountEmployeeTimeEntryId)
            End If
            If IsTimeOff = False And Percentage <> 0 Then
                Call New AccountProjectTaskBLL().UpdatePercentageAndCompleteTask(AccountProjectTaskId, Nothing, 0, Percentage)
            End If
            Me.AfterUpdate(TimeEntryDate)
            Return InsertedAccountEmployeeTimeEntryId
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Check time entry date in period of specified AccountEmployeeTimeEntryPeriodId, TimeEntryDate.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckTimeEntryDateInPeriod(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryDate As Date) As Boolean
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If TimeEntryDate >= dr.TimeEntryStartDate And TimeEntryDate <= dr.TimeEntryEndDate Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Check and update approval of time entry of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckAndUpdateApprovalOfTimeEntry(ByVal AccountEmployeeTimeEntryId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer) As Boolean
        Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
        Dim drTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        If dtTimeEntryApprovalProject.Rows.Count > 0 Then
            drTimeEntryApprovalProject = dtTimeEntryApprovalProject.Rows(0)
            If drTimeEntryApprovalProject.Approved = True Then
                Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
                Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = dtTimeEntry.Rows(0)
                drTimeEntry.Submitted = drTimeEntryApprovalProject.Submitted
                drTimeEntry.Approved = drTimeEntryApprovalProject.Approved
                Adapter.Update(dtTimeEntry)
                Me.UpdateAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryId, drTimeEntryApprovalProject.AccountEmployeeTimeEntryApprovalProjectId)
                Me.AfterUpdate(drTimeEntry.TimeEntryDate)
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' Add account employee time entry period of specified AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, Submitted,  Rejected, Approved, InApproval, TimeEntryViewType, PeriodDescription.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Approved"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <param name="PeriodDescription"></param>
    ''' <returns>nAccountEmployeeTimeEntryPeriodId</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntryPeriod( _
                    ByVal AccountId As Integer, _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeEntryStartDate As DateTime, _
                    ByVal TimeEntryEndDate As DateTime, _
                    ByVal Submitted As Boolean, _
                    ByVal Rejected As Boolean, _
                    ByVal Approved As Boolean, _
                    ByVal InApproval As Boolean, _
                    ByVal TimeEntryViewType As String, _
                    Optional ByVal PeriodDescription As String = "PeriodDescription" _
                    ) As Guid
        Try
            'LoggingBLL.WriteToLog("BLL-AddAccountEmployeeTimeEntryPeriod Start: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
            ' DBUtilities.GetSessionAccountEmployeeId & " TimeEntryStartDate=" & TimeEntryStartDate & _
            ' " TimeEntryEndDate=" & TimeEntryEndDate & " Submitted=" & Submitted)

            _AccountEmployeeTimeEntryPeriodAdapter = New AccountEmployeeTimeEntryPeriodTableAdapter
            Dim dtAccountEmployeeTimeEntryPeriod As New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.NewAccountEmployeeTimeEntryPeriodRow
            nAccountEmployeeTimeEntryPeriodId = System.Guid.NewGuid
            With drAccountEmployeeTimeEntryPeriod
                .AccountEmployeeTimeEntryPeriodId = nAccountEmployeeTimeEntryPeriodId
                .AccountId = AccountId
                .AccountEmployeeId = AccountEmployeeId
                .TimeEntryStartDate = TimeEntryStartDate
                .TimeEntryEndDate = TimeEntryEndDate
                .Submitted = Submitted
                If Submitted = True Then
                    .SubmittedDate = Now.Date
                    .SubmittedBy = DBUtilities.GetSessionAccountEmployeeId
                End If
                .Rejected = Rejected
                .Approved = Approved
                If Approved = True Then
                    .ApprovedOn = Now.Date
                    .ApprovedByEmployeeId = AccountEmployeeId
                End If
                .InApproval = InApproval
                .TimeEntryViewType = TimeEntryViewType
                .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
                .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
                If PeriodDescription <> "PeriodDescription" Then
                    .PeriodDescription = PeriodDescription
                End If
                .CreatedOn = Now
                .ModifiedOn = Now
            End With
            dtAccountEmployeeTimeEntryPeriod.AddAccountEmployeeTimeEntryPeriodRow(drAccountEmployeeTimeEntryPeriod)
            Me.AfterUpdate()
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(dtAccountEmployeeTimeEntryPeriod)
            '  LoggingBLL.WriteToLog("BLL-AddAccountEmployeeTimeEntryPeriod End: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
            'DBUtilities.GetSessionAccountEmployeeId & " TimeEntryStartDate=" & TimeEntryStartDate & _
            '" TimeEntryEndDate=" & TimeEntryEndDate & " nAccountEmployeeTimeEntryPeriodId=" & nAccountEmployeeTimeEntryPeriodId.ToString)
            Return nAccountEmployeeTimeEntryPeriodId
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Add AccountEmployeeTimeEntryApprovalProject of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId, TimeEntryAccountEmployeeId, ApprovedByEmployeeId, Submitted, InApproval, IsRejected, Approved, Rejected.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <returns>nAccountEmployeeTimeEntryApprovalProjectId</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntryApprovalProject( _
                    ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal AccountProjectId As Integer, _
                    ByVal TimeEntryAccountEmployeeId As Integer, _
                    ByVal ApprovedByEmployeeId As Integer, _
                    ByVal Submitted As Boolean, _
                    ByVal InApproval As Boolean, _
                    ByVal IsRejected As Boolean, _
                    ByVal Approved As Boolean, _
                    ByVal Rejected As Boolean, _
                    ByVal IsEmailSend As Boolean _
                    ) As Guid
        ' Create a new ProductRow instance

        Try
            'LoggingBLL.WriteToLog("BLL-AddAccountEmployeeTimeEntryApprovalProject Start: AccountEmployeeId=" & TimeEntryAccountEmployeeId & " Session-AccountEmployeeId= " & _
            '    DBUtilities.GetSessionAccountEmployeeId & " AccountProjectId=" & AccountProjectId & _
            '    " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString)

            _AccountEmployeeTimeEntryApprovalProjectAdapter = New AccountEmployeeTimeEntryApprovalProjectTableAdapter

            Dim dtAccountEmployeeTimeEntryApprovalProject As New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable
            Dim drAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow = dtAccountEmployeeTimeEntryApprovalProject.NewAccountEmployeeTimeEntryApprovalProjectRow

            nAccountEmployeeTimeEntryApprovalProjectId = System.Guid.NewGuid
            'System.Web.HttpContext.Current.Session.Add("AccountEmployeeTimeEntryApprovalProjectId", nAccountEmployeeTimeEntryApprovalProjectId)
            With drAccountEmployeeTimeEntryApprovalProject
                .AccountEmployeeTimeEntryApprovalProjectId = nAccountEmployeeTimeEntryApprovalProjectId
                .AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
                .AccountProjectId = AccountProjectId
                .TimeEntryAccountEmployeeId = TimeEntryAccountEmployeeId
                If ApprovedByEmployeeId <> 0 Then
                    .ApprovedByEmployeeId = ApprovedByEmployeeId
                Else
                    .Item("ApprovedByEmployeeId") = System.DBNull.Value
                End If
                .Submitted = Submitted
                .InApproval = InApproval
                .IsRejected = IsRejected
                .Approved = Approved
                .Rejected = Rejected
                .CreatedOn = Now
                .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
                .IsEmailSend = IsEmailSend
            End With

            dtAccountEmployeeTimeEntryApprovalProject.AddAccountEmployeeTimeEntryApprovalProjectRow(drAccountEmployeeTimeEntryApprovalProject)

            Me.AfterUpdate()

          
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(dtAccountEmployeeTimeEntryApprovalProject)

            'LoggingBLL.WriteToLog("BLL-AddAccountEmployeeTimeEntryApprovalProject End: AccountEmployeeId=" & TimeEntryAccountEmployeeId & " Session-AccountEmployeeId= " & _
            '     DBUtilities.GetSessionAccountEmployeeId & " AccountProjectId=" & AccountProjectId & _
            '     " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
            '     nAccountEmployeeTimeEntryApprovalProjectId.ToString)

            Return nAccountEmployeeTimeEntryApprovalProjectId

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' Set approval state.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntry"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="IsTimeOff"></param>
    ''' <remarks></remarks>
    Public Sub SetApprovalState(ByVal AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow, ByVal AccountProjectId As Integer, Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal IsTimeOff As Boolean = False)
        If Not IsTimeOff Then
            Dim Project As TimeLiveDataSet.AccountProjectRow = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId).Rows(0)
            If IsDBNull(Project("TimeSheetApprovalTypeId")) Then
                AccountEmployeeTimeEntry.Approved = True
            Else
                If Project.TimeSheetApprovalTypeId = 0 Then
                    AccountEmployeeTimeEntry.Approved = True
                End If
            End If
        Else
            Dim Employee As AccountEmployee.AccountEmployeeRow = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId).Rows(0)
            If IsDBNull(Employee("TimeOffApprovalTypeId")) Then
                AccountEmployeeTimeEntry.Approved = True
            Else
                If Employee.TimeOffApprovalTypeId = 0 Then
                    AccountEmployeeTimeEntry.Approved = True
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' Set approval state on inserting TimeEntry of specified AccountProjectId, AccountEmployeeId, IsTimeOff
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="IsTimeOff"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetApprovalStateOnInsertTimeEntry(ByVal AccountProjectId As Integer, Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal IsTimeOff As Boolean = False) As Boolean
        If Not IsTimeOff Then
            Dim Project As TimeLiveDataSet.AccountProjectRow = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId).Rows(0)
            If IsDBNull(Project("TimeSheetApprovalTypeId")) Then
                Return True
            Else
                If Project.TimeSheetApprovalTypeId = 0 Then
                    Return True
                End If
            End If
        Else
            Dim Employee As AccountEmployee.AccountEmployeeRow = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId).Rows(0)
            If IsDBNull(Employee("TimeOffApprovalTypeId")) Then
                Return True
            Else
                If Employee.TimeOffApprovalTypeId = 0 Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' SetApprovalStateForApprovalProject
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetApprovalStateForApprovalProject(ByVal AccountProjectId As Integer) As Boolean
        Dim Project As TimeLiveDataSet.AccountProjectRow = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId).Rows(0)
        If IsDBNull(Project("TimeSheetApprovalTypeId")) Then
            Return True
        Else
            If Project.TimeSheetApprovalTypeId = 0 Then
                Return True
            End If
        End If
    End Function
    ''' <summary>
    ''' Set ApprovalState for timeoff
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetApprovalStateForTimeOff(ByVal AccountEmployeeId As Integer)
        Dim Employee As AccountEmployee.AccountEmployeeRow = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId).Rows(0)
        If IsDBNull(Employee("TimeOffApprovalTypeId")) Then
            Return True
        Else
            If Employee.TimeOffApprovalTypeId = 0 Then
                Return True
            End If
        End If
    End Function
    ''' <summary>
    ''' After update
    ''' </summary>
    ''' <param name="TimeEntryDate"></param>
    ''' <remarks></remarks>
    Public Sub AfterUpdate(Optional ByVal TimeEntryDate As Date = #1/1/1900#)
        CacheManager.ClearCache("AccountEmployeeTimeEntryDataTable", , , True)
        CacheManager.ClearCache("sumAccountEmployeeTimeEntryWeekSummaryDataTable", , True)
        Dim str As String = "TimeEntryDate=" & TimeEntryDate
        CacheManager.ClearCache("vueAccountEmployeeTimeEntryWithStatusDataTable", str, , True)
        CacheManager.ClearCache("vueAccountEmployeeTimeEntryWithStatusGroupedDataTable", str, , True)
        CacheManager.ClearCache("AccountEmployeeTimeEntryPeriodDataTable", str, , True)
        CacheManager.ClearCache("AccountEmployeeTimeEntryViewTypeDataTable", str, , True)
        CacheManager.ClearCache("AccountEmployeeTimeEntryPeriodStartDateDataTable", str, , True)
        CacheManager.ClearCache("AccountEmployeeTimeEntryPeriodEndDateDataTable", str, , True)
    End Sub
    ''' <summary>
    ''' Clear TimeEntry cache 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ClearTimeEntryCacheOfAllAccount()
        CacheManager.ClearCache("AccountEmployeeTimeEntryDataTable", , True)
        CacheManager.ClearCache("sumAccountEmployeeTimeEntryWeekSummaryDataTable", , True)
    End Sub
    ''' <summary>
    ''' Update AccountEmployee TimeEntryPeriodId of specified Original_AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns> Return true if precisely one row was updated, otherwise false</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntryPeriodId( _
                    ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                    ByVal AccountEmployeeTimeEntryPeriodId As Guid _
                    ) As Boolean

        ' Update the product record

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        AddOldObjectInSession(Original_AccountEmployeeTimeEntryId)

        With AccountEmployeeTimeEntry
            .AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update AccountEmployee TimeEntryPeriodId in TimeEntryApproval of specified Original_AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntryPeriodIdInTimeEntryApproval( _
                ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal AccountEmployeeTimeEntryPeriodId As Guid _
                ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryApproval As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable = AccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim drAccountEmployeeTimeEntryApproval As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalRow

        If dtAccountEmployeeTimeEntryApproval.Rows.Count > 0 Then
            For Each drAccountEmployeeTimeEntryApproval In dtAccountEmployeeTimeEntryApproval.Rows
                drAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
            Next

            Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalAdapter.Update(dtAccountEmployeeTimeEntryApproval)

            Me.AfterUpdate()

            ' Return true if precisely one row was updated, otherwise false
            Return rowsAffected = 1
        End If
    End Function
    ''' <summary>
    ''' Update in approval of EmployeeTimeEntryPeriod of specified Original_AccountEmployeeTimeEntryPeriodId, InApproval
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="InApproval"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateInApprovalInAccountEmployeeTimeEntryPeriod( _
                    ByVal Original_AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal InApproval As Boolean _
                    ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
        Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.Rows(0)

        With drAccountEmployeeTimeEntryPeriod
            .InApproval = InApproval
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(drAccountEmployeeTimeEntryPeriod)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update in approval of AccountEmployeeTimeEntryApprovalProject of specified Original_AccountEmployeeTimeEntryApprovalProjectId, InApproval, ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateInApprovalInAccountEmployeeTimeEntryApprovalProject( _
                ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                ByVal InApproval As Boolean, _
                ByVal ApprovedByEmployeeId As Integer _
                ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(Original_AccountEmployeeTimeEntryApprovalProjectId)
        Dim drAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow = dtAccountEmployeeTimeEntryApprovalProject.Rows(0)

        With drAccountEmployeeTimeEntryApprovalProject
            .InApproval = InApproval
            .ApprovedByEmployeeId = ApprovedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ApprovedByEmployeeId
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(drAccountEmployeeTimeEntryApprovalProject)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update approved in AccountEmployeeTimeEntryPeriod of specified Original_AccountEmployeeTimeEntryPeriodId,Approved, Original_ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateApprovedInAccountEmployeeTimeEntryPeriod( _
                    ByVal Original_AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
        Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.Rows(0)

        With drAccountEmployeeTimeEntryPeriod
            .Approved = Approved
            '.Rejected = False
            .ApprovedByEmployeeId = Original_ApprovedByEmployeeId
            .ApprovedOn = Now.Date
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(drAccountEmployeeTimeEntryPeriod)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update approved in account employee of timeentryapprovalproject of specified Original_AccountEmployeeTimeEntryApprovalProjectId, Approved
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateApprovedInAccountEmployeeTimeEntryApprovalProject( _
                ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                ByVal Approved As Boolean _
                ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(Original_AccountEmployeeTimeEntryApprovalProjectId)
        Dim drAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow = dtAccountEmployeeTimeEntryApprovalProject.Rows(0)

        With drAccountEmployeeTimeEntryApprovalProject
            .Approved = Approved
            .Rejected = False
            .ModifiedOn = Now
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(drAccountEmployeeTimeEntryApprovalProject)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update rejected in account employee timeentryperiod of specified Original_AccountEmployeeTimeEntryPeriodId, Rejected, Original_RejectedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_RejectedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateRejectedInAccountEmployeeTimeEntryPeriod( _
                    ByVal Original_AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal Rejected As Boolean, ByVal Original_RejectedByEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
        Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.Rows(0)

        With drAccountEmployeeTimeEntryPeriod
            .Rejected = Rejected
            .InApproval = False
            .Submitted = False
            .RejectedOn = Date.Now
            .RejectedByEmployeeId = Original_RejectedByEmployeeId
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(drAccountEmployeeTimeEntryPeriod)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update rejected in account employee timeentryapprovalproject of specified Original_AccountEmployeeTimeEntryApprovalProjectId, Rejected
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="Rejected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateRejectedInAccountEmployeeTimeEntryApprovalProject( _
                ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                ByVal Rejected As Boolean _
                ) As Boolean

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(Original_AccountEmployeeTimeEntryApprovalProjectId)
        Dim drAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow = dtAccountEmployeeTimeEntryApprovalProject.Rows(0)

        With drAccountEmployeeTimeEntryApprovalProject
            .Rejected = Rejected
            .IsRejected = True
            .InApproval = False
            .Submitted = False
            .ModifiedOn = Now
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(drAccountEmployeeTimeEntryApprovalProject)

        Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update AccountEmployeeTimeEntry of specified AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, AccountProjectId
    ''' AccountProjectTaskId, Description, Approved, TeamLeadApproved, ProjectManagerApproved, AdministratorApproved, ModifiedOn
    ''' Original_AccountEmployeeTimeEntryId, AccountPartyId, Submitted, AccountWorkTypeId, AccountCostCenterId, TimesheetPeriodType
    ''' PeriodStartDate, PeriodEndDate, AccountEmployeeTimeEntryPeriodId, IsTimeOff, AccountTimeOffTypeId, AccountEmployeeTimeEntryApprovalProjectId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="StartTime"></param>
    ''' <param name="EndTime"></param>
    ''' <param name="TotalTime"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="Description"></param>
    ''' <param name="Approved"></param>
    ''' <param name="TeamLeadApproved"></param>
    ''' <param name="ProjectManagerApproved"></param>
    ''' <param name="AdministratorApproved"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountPartyId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="AccountCostCenterId"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="IsTimeOff"></param>
    ''' <param name="AccountTimeOffTypeId"></param>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntry( _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeEntryDate As DateTime, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal Description As String, _
                    ByVal Approved As Boolean, _
                    ByVal TeamLeadApproved As Boolean, _
                    ByVal ProjectManagerApproved As Boolean, _
                    ByVal AdministratorApproved As Boolean, _
                    ByVal ModifiedOn As Date, _
                    ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                    ByVal AccountPartyId As Integer, _
                    ByVal Submitted As Boolean, _
                    ByVal AccountWorkTypeId As Integer, _
                    ByVal AccountCostCenterId As Integer, _
                    ByVal TimesheetPeriodType As String, _
                    ByVal PeriodStartDate As Date, _
                    ByVal PeriodEndDate As Date, _
                    ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                    ByVal IsTimeOff As Boolean, _
                    ByVal AccountTimeOffTypeId As Guid, _
                    ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                    ByVal Percentage As Double, _
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
        Try
            If Original_AccountEmployeeTimeEntryId = 0 Then
                Exit Function
            End If
            Dim Old_AccountProjectId As Integer
            Dim Old_AccountProjectTaskId As Object
            Dim TimeOffConsumedHours As Double
            Dim Old_Percentage As Double
            Dim Rejected As Boolean
            Dim OldTotalTime As String
            Dim TimeOffTotalTime As String
            Dim Hours As Decimal
            Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
            Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetAccountEmployeeTimeEntryByTimeEntryId(Original_AccountEmployeeTimeEntryId)
            Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)
            AddOldObjectInSession(Original_AccountEmployeeTimeEntryId)
            If CheckTimeEntryDateInPeriod(AccountEmployeeTimeEntryPeriodId, TimeEntryDate) = False Then
                Throw New Exception("Date differ from period date.")
            End If
            With AccountEmployeeTimeEntry
                Dim HArray() As String
                Dim TArray() As String
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    TArray = Convert.ToDouble(TotalTime).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
                    TimeOffTotalTime = LocaleUtilitiesBLL.ConvertHoursToTimeFormat(TArray(0), TArray(1))
                Else
                    TimeOffTotalTime = TotalTime
                End If
                If IsTimeOff Then
                    TimeOffConsumedHours = GetDiffTimeOffConsumedHours(TimeOffTotalTime, AccountEmployeeTimeEntry.TotalTime.ToString("HH:mm"))
                    OldTotalTime = .TotalTime.ToString("HH:mm")
                    If Approved = True And AccountEmployeeTimeEntry.Item("Approved") = False And AccountTimeOffTypeId = .AccountTimeOffTypeId Then
                        Me.UpdateEmployeeTimeOffHours(AccountEmployeeId, AccountTimeOffTypeId, TimeOffTotalTime, Original_AccountEmployeeTimeEntryId)
                        TimeOffConsumedHours = 0
                    End If
                    If CheckAndUpdateTimeOffTypeHours(AccountEmployeeId, AccountEmployeeTimeEntry.AccountTimeOffTypeId, AccountTimeOffTypeId, TimeOffTotalTime, Approved, OldTotalTime, .Item("Approved")) Then
                        TimeOffConsumedHours = 0
                    End If
                End If
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    TArray = Convert.ToDouble(TotalTime).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
                    Hours = TotalTime
                    TotalTime = LocaleUtilitiesBLL.ConvertHoursToTimeFormat(TArray(0), TArray(1))
                    TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)
                Else
                    HArray = Split(TotalTime, ":")
                    Hours = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray(0), HArray(1))
                    TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)
                End If
                If IsTimeOff <> True Then
                    If Submitted = True Then
                        Submitted = Submitted
                        Rejected = False
                    ElseIf Submitted = False And AccountProjectId = .AccountProjectId Then
                        Submitted = .Submitted
                        Approved = .Approved
                        Rejected = .Rejected
                    ElseIf Submitted = False And AccountProjectId <> .AccountProjectId Then
                        Submitted = Submitted
                        Rejected = .Rejected
                    End If
                Else
                    If Submitted = True Then
                        Submitted = Submitted
                        Rejected = False
                    Else
                        Submitted = .Submitted
                        Approved = .Approved
                        Rejected = .Rejected
                    End If
                End If
                If Not IsDBNull(AccountEmployeeTimeEntry.Item("Percentage")) And Not IsTimeOff Then
                    Old_Percentage = AccountEmployeeTimeEntry.Percentage
                End If
                If Not IsDBNull(AccountEmployeeTimeEntry.Item("AccountProjectTaskId")) And Not IsTimeOff Then
                    If AccountEmployeeTimeEntry.AccountProjectTaskId <> AccountProjectTaskId Then
                        Old_AccountProjectTaskId = AccountEmployeeTimeEntry.AccountProjectTaskId
                    End If
                End If
            End With
            If Not StartTime Is Nothing And StartTime <> "" Then
                StartTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(StartTime, TimeEntryDate)
            End If
            If Not EndTime Is Nothing And EndTime <> "" Then
                EndTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(EndTime, TimeEntryDate)
            End If
            'TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeFormatWithDate(TotalTime, TimeEntryDate)
            Dim FixedCost As Decimal = 0
            Dim BillingRate As Decimal = 0
            Dim EmployeeRate As Decimal = 0
            Dim BillingRateCurrencyId As Integer = 0
            Dim EmployeeRateCurrencyId As Integer = 0
            Dim AccountBaseCurrencyId As Integer = 0
            Dim BillingRateExchangeRate As Double = 0
            Dim EmployeeRateExchangeRate As Double = 0
            Dim IsBillingModePerHour As Boolean
            If Not IsTimeOff Then
                BillingRate = Me.GetCurrentBillingRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                EmployeeRate = Me.GetCurrentEmployeeRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                BillingRateCurrencyId = Me.GetCurrentBillingRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                If Not BillingRateCurrencyId = Nothing Then
                    BillingRateCurrencyId = BillingRateCurrencyId
                End If
                EmployeeRateCurrencyId = Me.GetCurrentEmployeeRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
                If Not EmployeeRateCurrencyId = Nothing Then
                    EmployeeRateCurrencyId = EmployeeRateCurrencyId
                End If
                AccountBaseCurrencyId = Me.GetAccountBaseCurrencyId(DBUtilities.GetSessionAccountId)
                BillingRateExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(BillingRateCurrencyId, TimeEntryDate)
                EmployeeRateExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(EmployeeRateCurrencyId, TimeEntryDate)
                IsBillingModePerHour = Me.IsBillingModePerHour(AccountPartyId)
                If IsBillingModePerHour <> True Then
                    FixedCost = Me.GetFixBidCost(AccountPartyId, AccountProjectId, AccountProjectTaskId)
                    BillingRate = FixedCost
                End If
            End If

            'LoggingBLL.WriteToLog("BLL-UpdateAccountEmployeeTimeEntry Start: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
            '  DBUtilities.GetSessionAccountEmployeeId & " TimeEntryDate=" & TimeEntryDate & _
            '  " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
            '  AccountEmployeeTimeEntryApprovalProjectId.ToString & " Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)

            Dim UpdatedAccountEmployeeTimeEntryId As Integer = Me.Adapter.TimeEntryUpdate(AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, _
            AccountProjectId, IIf(IsTimeOff, Nothing, AccountProjectTaskId), _
            Description, Approved, _
            Now, Submitted, Rejected, IIf(AccountWorkTypeId <> 0 And IsTimeOff = False, AccountWorkTypeId, Nothing), _
            IIf(Not AccountCostCenterId <= 0 And IsTimeOff = False, AccountCostCenterId, Nothing), AccountEmployeeTimeEntryPeriodId, _
            IsTimeOff, AccountTimeOffTypeId, _
            BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, _
            BillingRateExchangeRate, EmployeeRateExchangeRate, AccountBaseCurrencyId, AccountEmployeeTimeEntryApprovalProjectId, Original_AccountEmployeeTimeEntryId, Percentage, Hours, IIf(IsBillingModePerHour = True, False, True), _
            AccountPartyId, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, _
            CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15)
            Me.AfterUpdate(TimeEntryDate)

            'LoggingBLL.WriteToLog("BLL-UpdateAccountEmployeeTimeEntry End: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
            'DBUtilities.GetSessionAccountEmployeeId & " TimeEntryDate=" & TimeEntryDate & _
            '" AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
            'AccountEmployeeTimeEntryApprovalProjectId.ToString & " Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)

            If IsTimeOff = True And TimeOffConsumedHours <> 0 And Approved = True Then
                Call New AccountEmployeeTimeOffBLL().SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, TimeOffConsumedHours, DBUtilities.GetEmployeeNameWithCode, "Approved", "TimeEntry Approval")
            End If
            If IsTimeOff = False And (Percentage <> 0 Or Old_Percentage <> 0) Then
                Call New AccountProjectTaskBLL().UpdatePercentageAndCompleteTask(AccountProjectTaskId, Old_AccountProjectTaskId, Old_Percentage, Percentage)
            End If
            If IsTimeOff = True And Submitted = True And AccountTimeOffTypeId <> System.Guid.Empty And AccountEmployeeTimeEntry.Submitted = False Then
                Dim bll As New AccountEmployeeTimeOffRequestBLL
                bll.SendPendingTimeEntryForTimeOffInstantEmail(AccountEmployeeTimeEntryPeriodId)
            End If
            ' Return true if precisely one row was updated, otherwise false
            Return UpdatedAccountEmployeeTimeEntryId
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateAccountEmployeeTimeEntries(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        Me.Adapter.TimeEntriesUpdate(AccountId, AccountEmployeeId)
    End Sub
    Public Sub UpdateAccountEmployeeTimeEntriesByAccount(ByVal AccountId As Integer)
        'Me.Adapter.TimeEntriesUpdateAccount(AccountId)
    End Sub
    ''' <summary>
    ''' Get difference of timeoff of consumed hours of specified NewTime, OldTime
    ''' </summary>
    ''' <param name="NewTime"></param>
    ''' <param name="OldTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDiffTimeOffConsumedHours(ByVal NewTime As String, ByVal OldTime As String)
        Dim strNewHoursOff As String() = Split(Replace(NewTime, ":", "."), ".")
        Dim NewHoursOff As Double = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strNewHoursOff(0), strNewHoursOff(1))
        Dim strOldHoursOff As String() = Split(Replace(OldTime, ":", "."), ".")
        Dim OldHoursOff As Double = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strOldHoursOff(0), strOldHoursOff(1))
        Return NewHoursOff - OldHoursOff
    End Function
    ''' <summary>
    ''' Check and update of timeofftypehours of specified AccountEmployeeId, OldTimeOffType, NewTimeOffType, Hours, Approved, 
    ''' OldTotalTime, TimesheetApproved
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="OldTimeOffType"></param>
    ''' <param name="NewTimeOffType"></param>
    ''' <param name="Hours"></param>
    ''' <param name="Approved"></param>
    ''' <param name="OldTotalTime"></param>
    ''' <param name="TimesheetApproved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckAndUpdateTimeOffTypeHours(ByVal AccountEmployeeId As Integer, ByVal OldTimeOffType As Guid, ByVal NewTimeOffType As Guid, ByVal Hours As String, ByVal Approved As Boolean, ByVal OldTotalTime As String, ByVal TimesheetApproved As Boolean)

        If OldTimeOffType <> NewTimeOffType And Approved = True Then
            Dim strNewHoursOff As String() = Split(Replace(Hours, ":", "."), ".")
            Dim NewHoursOff As Double = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strNewHoursOff(0), strNewHoursOff(1))
            Dim strOldHoursOff As String() = Split(Replace(OldTotalTime, ":", "."), ".")
            Dim OldHoursOff As Double = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strOldHoursOff(0), strOldHoursOff(1))
            If TimesheetApproved Then
                Call New AccountEmployeeTimeOffBLL().SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, OldTimeOffType, -OldHoursOff)
            End If
            Call New AccountEmployeeTimeOffBLL().SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, NewTimeOffType, NewHoursOff)
            Return True
        End If
    End Function
    ''' <summary>
    ''' Get submitted status of TimeEntryUpdate
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSubmittedStatusOfTimeEntryUpdate(ByVal AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow) As Boolean
        If IsDBNull(AccountEmployeeTimeEntry.Item("Submitted")) Then
            Return False
        ElseIf AccountEmployeeTimeEntry.Item("Submitted") = False Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Update account employee timeentryperiod of specified AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate
    ''' Submitted, Rejected, Approved, TimeEntryViewType, Original_AccountEmployeeTimeEntryPeriodId, PeriodDescription
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Approved"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="PeriodDescription"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntryPeriod( _
                    ByVal AccountId As Integer, _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal TimeEntryStartDate As DateTime, _
                    ByVal TimeEntryEndDate As DateTime, _
                    ByVal Submitted As Boolean, _
                    ByVal Rejected As Boolean, _
                    ByVal Approved As Boolean, _
                    ByVal TimeEntryViewType As String, _
                    ByVal Original_AccountEmployeeTimeEntryPeriodId As Guid, _
                    Optional ByVal PeriodDescription As String = "PeriodDescription" _
                    ) As Guid
        '        LoggingBLL.WriteToLog("BLL-UpdateAccountEmployeeTimeEntryPeriod Start: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
        'DBUtilities.GetSessionAccountEmployeeId & " TimeEntryStartDate=" & TimeEntryStartDate & _
        '" TimeEntryEndDate=" & TimeEntryEndDate & " nAccountEmployeeTimeEntryPeriodId=" & Original_AccountEmployeeTimeEntryPeriodId.ToString)

        Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
        Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.Rows(0)
        'System.Web.HttpContext.Current.Session("AccountEmployeeTimeEntryPeriodId") = Original_AccountEmployeeTimeEntryPeriodId
        With drAccountEmployeeTimeEntryPeriod
            .AccountId = AccountId
            .TimeEntryStartDate = TimeEntryStartDate
            .TimeEntryEndDate = TimeEntryEndDate
            If Submitted = True Then
                .SubmittedBy = DBUtilities.GetSessionAccountEmployeeId
                .SubmittedDate = Now.Date
            End If
            .Submitted = Submitted
            .Rejected = Rejected
            .Approved = Approved
            .TimeEntryViewType = TimeEntryViewType
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If PeriodDescription <> "PeriodDescription" Then
                .PeriodDescription = PeriodDescription
            End If
            .ModifiedOn = Now
        End With
        Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(dtAccountEmployeeTimeEntryPeriod)
        Me.AfterUpdate()
        '        LoggingBLL.WriteToLog("BLL-UpdateAccountEmployeeTimeEntryPeriod End: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
        'DBUtilities.GetSessionAccountEmployeeId & " TimeEntryStartDate=" & TimeEntryStartDate & _
        '" TimeEntryEndDate=" & TimeEntryEndDate & " nAccountEmployeeTimeEntryPeriodId=" & Original_AccountEmployeeTimeEntryPeriodId.ToString)
        Return Original_AccountEmployeeTimeEntryPeriodId
    End Function
    ''' <summary>
    ''' Update AccountEmployeeTimeEntryApprovalProject of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId, TimeEntryAccountEmployeeId
    ''' ApprovedByEmployeeId, Submitted, InApproval, IsRejected, Approved, Rejected, Original_AccountEmployeeTimeEntryApprovalProjectId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntryApprovalProject( _
                ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                ByVal AccountProjectId As Integer, _
                ByVal TimeEntryAccountEmployeeId As Integer, _
                ByVal ApprovedByEmployeeId As Integer, _
                ByVal Submitted As Boolean, _
                ByVal InApproval As String, _
                ByVal IsRejected As Boolean, _
                ByVal Approved As String, _
                ByVal Rejected As Boolean, _
                ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Guid _
                ) As Boolean
        'LoggingBLL.WriteToLog("BLL-UpdateAccountEmployeeTimeEntryApprovalProject Start: AccountEmployeeId=" & TimeEntryAccountEmployeeId & " Session-AccountEmployeeId= " & _
        '   DBUtilities.GetSessionAccountEmployeeId & " AccountProjectId=" & AccountProjectId & _
        '   " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
        '   Original_AccountEmployeeTimeEntryApprovalProjectId.ToString)

        Dim dtAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(Original_AccountEmployeeTimeEntryApprovalProjectId)
        Dim drAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        'System.Web.HttpContext.Current.Session("AccountEmployeeTimeEntryApprovalProjectId") = Original_AccountEmployeeTimeEntryApprovalProjectId
        If dtAccountEmployeeTimeEntryApprovalProject.Rows.Count > 0 Then
            drAccountEmployeeTimeEntryApprovalProject = dtAccountEmployeeTimeEntryApprovalProject.Rows(0)
            With drAccountEmployeeTimeEntryApprovalProject
                .AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
                .AccountProjectId = AccountProjectId
                If ApprovedByEmployeeId <> 0 Then
                    .ApprovedByEmployeeId = ApprovedByEmployeeId
                Else
                    .Item("ApprovedByEmployeeId") = System.DBNull.Value
                End If
                .Submitted = Submitted
                .Rejected = Rejected
                If Approved <> "NULL" Then
                    .Approved = CBool(Approved)
                End If
                If InApproval <> "NULL" Then
                    .InApproval = CBool(InApproval)
                End If
                .IsRejected = IsRejected
                .ModifiedOn = Now
            End With
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(dtAccountEmployeeTimeEntryApprovalProject)
            Me.AfterUpdate()
            '   LoggingBLL.WriteToLog("BLL-UpdateAccountEmployeeTimeEntryApprovalProject End: AccountEmployeeId=" & TimeEntryAccountEmployeeId & " Session-AccountEmployeeId= " & _
            'DBUtilities.GetSessionAccountEmployeeId & " AccountProjectId=" & AccountProjectId & _
            '" AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
            'Original_AccountEmployeeTimeEntryApprovalProjectId.ToString)
            Return rowsAffected = 1
        End If
    End Function
    ''' <summary>
    ''' Locking team lead time entry of specified Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockTeamLeadTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                    ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry
            .ModifiedOn = Now
            .Approved = Approved
            .Rejected = False
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetApprovedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Approved)
        Me.SetApprovedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Locking of team lead time entry rejected of specified Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_RejectedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockTeamLeadTimeEntryRejected(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                    ByVal Rejected As Boolean, ByVal Original_RejectedByEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry
            .ModifiedOn = Now
            .Rejected = Rejected
            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetRejectedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId)
        Me.SetRejectedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Rejected)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Delete rejected status approval of specified Original_AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function DeleteIsRejectStatusApproval(ByVal Original_AccountEmployeeTimeEntryId As Integer _
                    ) As Boolean


        Dim AccountEmployeeTimeEntryApprovals As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable = AccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntryApproval As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalRow
        If AccountEmployeeTimeEntryApprovals.Rows.Count > 0 Then
            AccountEmployeeTimeEntryApproval = AccountEmployeeTimeEntryApprovals.Rows(0)
            For Each AccountEmployeeTimeEntryApproval In AccountEmployeeTimeEntryApprovals.Rows
                If AccountEmployeeTimeEntryApproval.IsReject = True Then
                    Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalAdapter.Delete(AccountEmployeeTimeEntryApproval.TimeSheetApprovalId)
                    rowsAffected = 1
                End If
            Next
        End If


    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntryPeriod of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimesheetPeriodType, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function DeleteAccountEmployeeTimeEntryPeriod(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimesheetPeriodType As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid _
                    ) As Boolean
        Dim IsTimeEntryPeriodDeleted As Boolean = False
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        If dtTimeEntry.Rows.Count = 0 Then
            DeleteAccountEmployeeTimeEntryApprovalProjectByPeriodId(AccountEmployeeTimeEntryPeriodId)
            Dim dtTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
            If dtTimeEntryPeriod.Rows.Count > 0 Then
                AccountEmployeeTimeEntryPeriodAdapter.Delete(AccountEmployeeTimeEntryPeriodId)
                IsTimeEntryPeriodDeleted = True
            End If
            Me.AfterUpdate(TimeEntryStartDate)
        End If
        Return IsTimeEntryPeriodDeleted
    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntryApprovalProject of specified AccountEmployeeTimeEntryApprovalProjectId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function DeleteAccountEmployeeTimeEntryApprovalProject(ByVal AccountEmployeeTimeEntryApprovalProjectId As Object _
                ) As Boolean
        Dim IsApprovalProjectDeleted As Boolean = False
        If AccountEmployeeTimeEntryApprovalProjectId.ToString <> "" Then
            Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryApprovalProjectId)
            If dtTimeEntry.Rows.Count = 0 Then
                Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryApprovalProjectId)
                Dim drTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
                If dtTimeEntryApprovalProject.Rows.Count > 0 Then
                    drTimeEntryApprovalProject = dtTimeEntryApprovalProject.Rows(0)
                    AccountEmployeeTimeEntryApprovalProjectAdapter.Delete(drTimeEntryApprovalProject.AccountEmployeeTimeEntryApprovalProjectId)
                    IsApprovalProjectDeleted = True
                End If
            End If
        End If
        Return IsApprovalProjectDeleted
    End Function
    ''' <summary>
    ''' Delete approved status approval
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function DeleteIsApprovedStatusApproval(ByVal Original_AccountEmployeeTimeEntryId As Integer _
                ) As Boolean


        Dim AccountEmployeeTimeEntryApprovals As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable = AccountEmployeeTimeEntryApprovalAdapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntryApproval As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalRow
        If AccountEmployeeTimeEntryApprovals.Rows.Count > 0 Then
            AccountEmployeeTimeEntryApproval = AccountEmployeeTimeEntryApprovals.Rows(0)
            For Each AccountEmployeeTimeEntryApproval In AccountEmployeeTimeEntryApprovals.Rows
                If AccountEmployeeTimeEntryApproval.IsApproved = True Then
                    Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalAdapter.Delete(AccountEmployeeTimeEntryApproval.TimeSheetApprovalId)
                    rowsAffected = 1
                End If
            Next
        End If


    End Function
    ''' <summary>
    ''' Add TimeSheetApproval of specified AccountEmployeeTimeEntryId, TimeSheetApprovalTypeId, TimeSheetApprovalPathId
    ''' ApprovedByEmployeeId, Comments, IsReject, IsApproved, AccountProjectId, BatchId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="TimeSheetApprovalTypeId"></param>
    ''' <param name="TimeSheetApprovalPathId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Comments"></param>
    ''' <param name="IsReject"></param>
    ''' <param name="IsApproved"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="BatchId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddTimeSheetApproval( _
                    ByVal AccountEmployeeTimeEntryId As Integer, _
                    ByVal TimeSheetApprovalTypeId As Integer, _
                    ByVal TimeSheetApprovalPathId As Integer, _
                    ByVal ApprovedByEmployeeId As Integer, _
                    ByVal Comments As String, _
                    ByVal IsReject As Boolean, _
                    ByVal IsApproved As Boolean, _
                    ByVal AccountProjectId As Integer, _
                    ByVal BatchId As Guid _
                    ) As Boolean
        ' Create a new ProductRow instance

        Try


            _AccountEmployeeTimeEntryApprovalTableAdapter = New AccountEmployeeTimeEntryApprovalTableAdapter

            Dim TimeSheetApprovals As New TimeLiveDataSet.AccountEmployeeTimeEntryApprovalDataTable
            Dim TimeSheetApproval As TimeLiveDataSet.AccountEmployeeTimeEntryApprovalRow = TimeSheetApprovals.NewAccountEmployeeTimeEntryApprovalRow

            Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
            Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
            If dtTimeEntry.Rows.Count > 0 Then
                drTimeEntry = dtTimeEntry.Rows(0)
                TimeSheetApproval.AccountEmployeeTimeEntryPeriodId = drTimeEntry.AccountEmployeeTimeEntryPeriodId
            End If

            'Dim Project As TimeLiveDataSet.AccountProjectRow = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId).Rows(0)

            With TimeSheetApproval
                .AccountEmployeeTimeEntryId = AccountEmployeeTimeEntryId
                .TimeSheetApprovalTypeId = TimeSheetApprovalTypeId
                .TimeSheetApprovalPathId = TimeSheetApprovalPathId
                .ApprovedByEmployeeId = ApprovedByEmployeeId
                .ApprovedOn = Date.Now
                .Comments = Comments
                .IsReject = IsReject
                .IsApproved = IsApproved
                If BatchId <> System.Guid.Empty Then
                    .AccountProjectId = AccountProjectId
                    .BatchId = BatchId
                End If
            End With

            TimeSheetApprovals.AddAccountEmployeeTimeEntryApprovalRow(TimeSheetApproval)

            CacheManager.ClearCache("AccountEmployeeTimeEntryApprovalDataTable", , , True)

            ' Add the new product
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalAdapter.Update(TimeSheetApprovals)

            Me.UpdatePreviousStatusInTimesheetApproval(IsReject, TimeSheetApproval.AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.SetInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryId, IsApproved)
            Me.SetInApprovalInAccountEmployeeTimeEntryApprovalProject(AccountEmployeeTimeEntryId, IsApproved, ApprovedByEmployeeId)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' Lock ProjectManagerTimeEntry of specified Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockProjectManagerTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                    ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)


        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Approved = Approved

            .Rejected = False

        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetApprovedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Approved)
        Me.SetApprovedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock ProjectManagerTimeEntryRejected of specified Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_RejectedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockProjectManagerTimeEntryRejected(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                    ByVal Rejected As Boolean, ByVal Original_RejectedByEmployeeId As Integer _
                    ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)


        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Rejected = Rejected

            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetRejectedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId)
        Me.SetRejectedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Rejected)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock SpecificEmployeeTimeEntry of specified Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId 
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockSpecificEmployeeTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer _
                ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Approved = Approved

            .Rejected = False

        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetApprovedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Approved)
        Me.SetApprovedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock TimeOffTimeEntry of specified Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockTimeOffTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
            ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid _
            ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Approved = Approved

            .Rejected = False

        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)
        AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, Approved, Original_ApprovedByEmployeeId, Date.Now)
        Me.SetApprovedInAccountEmployeeTimeEntryApprovalProjectForTimeOff(Original_AccountEmployeeTimeEntryId, Approved, AccountEmployeeTimeEntryPeriodId, Original_ApprovedByEmployeeId)
        ''AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, Approved, Original_ApprovedByEmployeeId, Date.Now)
        'Me.SetApprovedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock SpecificEmployeeTimeEntryRejected of specified Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_RejectedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockSpecificEmployeeTimeEntryRejected(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal Rejected As Boolean, ByVal Original_RejectedByEmployeeId As Integer _
                ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Rejected = Rejected

            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetRejectedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId)
        Me.SetRejectedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Rejected)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock SpecificExternalUserTimeEntry of specified Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockSpecificExternalUserTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer _
                ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Approved = Approved

            .Rejected = False

        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetApprovedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Approved)
        Me.SetApprovedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock EmployeeManagerTimeEntry of specified Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Original_ApprovedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockEmployeeManagerTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
            ByVal Approved As Boolean, ByVal Original_ApprovedByEmployeeId As Integer _
            ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Approved = Approved

            .Rejected = False

        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetApprovedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Approved)
        Me.SetApprovedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Approved, Original_ApprovedByEmployeeId)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock SpecificExternalUserTimeEntryRejected of specified Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_RejectedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockSpecificExternalUserTimeEntryRejected(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal Rejected As Boolean, ByVal Original_RejectedByEmployeeId As Integer _
                ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Rejected = Rejected

            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetRejectedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId)
        Me.SetRejectedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Rejected)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock EmployeeManagerTimeEntryRejected of specified Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Original_RejectedByEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockEmployeeManagerTimeEntryRejected(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal Rejected As Boolean, ByVal Original_RejectedByEmployeeId As Integer _
                ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now

            .Rejected = Rejected

            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)

        Me.SetRejectedInAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeTimeEntryId, Rejected, Original_RejectedByEmployeeId)
        Me.SetRejectedInAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryId, Rejected)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntry of specified Original_AccountEmployeeTimeEntryId, Original_TimeEntryViewType
    ''' Original_AccountEmployeeId, Original_TimeEntryStartDate, Original_TimeEntryEndDate, Original_AccountEmployeeTimeEntryApprovalProjectId
    ''' Original_AccountEmployeeTimeEntryPeriodId, Original_TimeEntryDate
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Original_TimeEntryViewType"></param>
    ''' <param name="Original_AccountEmployeeId"></param>
    ''' <param name="Original_TimeEntryStartDate"></param>
    ''' <param name="Original_TimeEntryEndDate"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="Original_TimeEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer, ByVal Original_TimeEntryViewType As Object, Optional ByVal Original_AccountEmployeeId As Integer = 0, Optional ByVal Original_TimeEntryStartDate As Object = #1/1/1900#, Optional ByVal Original_TimeEntryEndDate As Object = #1/1/1900#, Optional ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Object = "", Optional ByVal Original_AccountEmployeeTimeEntryPeriodId As Object = "", Optional ByVal Original_TimeEntryDate As Date = #1/1/2007#, Optional ByVal Original_IsTimeOff As Boolean = False, Optional ByVal Original_AccountEmployeeTimeOffRequestId As Object = "") As Boolean
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId & _
        '                      " Original_TimeEntryViewType= " & Original_TimeEntryViewType & " Original_AccountEmployeeId= " & Original_AccountEmployeeId & _
        '                      " Original_TimeEntryStartDate= " & Original_TimeEntryStartDate & " Original_TimeEntryEndDate= " & Original_TimeEntryEndDate _
        '                       & " Original_AccountEmployeeTimeEntryApprovalProjectId= " & Original_AccountEmployeeTimeEntryApprovalProjectId.ToString & " Original_AccountEmployeeTimeEntryPeriodId= " & Original_AccountEmployeeTimeEntryPeriodId.ToString _
        '                        & " Original_TimeEntryDate= " & Original_TimeEntryDate & " Original_IsTimeOff= " & Original_IsTimeOff _
        '                         & " Original_AccountEmployeeTimeOffRequestId= " & Original_AccountEmployeeTimeOffRequestId.ToString)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryTimeOffRequest Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        DeleteAccountEmployeeTimeEntryTimeOffRequest(Original_AccountEmployeeTimeEntryId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryTimeOffRequest Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction(Original_AccountEmployeeTimeEntryId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        Dim IsDeletedTimeEntryPeriod As Boolean = False
        If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) Then
            If Original_AccountEmployeeTimeEntryPeriodId <> System.Guid.Empty Then
                If Original_TimeEntryViewType <> "" Then
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryApprovalProject Original_AccountEmployeeTimeEntryApprovalProjectId=" & Original_AccountEmployeeTimeEntryApprovalProjectId.ToString)
                    IsDeletedTimeEntryPeriod = Me.DeleteAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryApprovalProjectId)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryApprovalProject Original_AccountEmployeeTimeEntryApprovalProjectId=" & Original_AccountEmployeeTimeEntryApprovalProjectId.ToString)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryPeriod Original_AccountEmployeeTimeEntryPeriodId=" & Original_AccountEmployeeTimeEntryPeriodId.ToString)
                    IsDeletedTimeEntryPeriod = Me.DeleteAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeId, Original_TimeEntryStartDate, Original_TimeEntryEndDate, Original_TimeEntryViewType, Original_AccountEmployeeTimeEntryPeriodId)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryPeriod Original_AccountEmployeeTimeEntryPeriodId=" & Original_AccountEmployeeTimeEntryPeriodId.ToString & "IsDeletedTimeEntryPeriod= " & IsDeletedTimeEntryPeriod)
                End If
                Me.AfterUpdate()
            End If
            Me.AfterUpdate(Original_TimeEntryStartDate)
        End If
        Return IsDeletedTimeEntryPeriod
    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntry of specified Original_AccountEmployeeTimeEntryId, Original_TimeEntryViewType
    ''' Original_AccountEmployeeId, Original_TimeEntryStartDate, Original_TimeEntryEndDate, Original_AccountEmployeeTimeEntryApprovalProjectId
    ''' Original_AccountEmployeeTimeEntryPeriodId, Original_TimeEntryDate
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Original_TimeEntryViewType"></param>
    ''' <param name="Original_AccountEmployeeId"></param>
    ''' <param name="Original_TimeEntryStartDate"></param>
    ''' <param name="Original_TimeEntryEndDate"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="Original_TimeEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeTimeEntryForWeekView(ByVal Original_AccountEmployeeTimeEntryId As Integer, ByVal Original_TimeEntryViewType As Object, Optional ByVal Original_AccountEmployeeId As Integer = 0, Optional ByVal Original_TimeEntryStartDate As Object = #1/1/1900#, Optional ByVal Original_TimeEntryEndDate As Object = #1/1/1900#, Optional ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Object = "", Optional ByVal Original_AccountEmployeeTimeEntryPeriodId As Object = "", Optional ByVal Original_TimeEntryDate As Date = #1/1/2007#, Optional ByVal Original_IsTimeOff As Boolean = False, Optional ByVal Original_AccountEmployeeTimeOffRequestId As Object = "") As Boolean
        LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId & _
                              " Original_TimeEntryViewType= " & Original_TimeEntryViewType & " Original_AccountEmployeeId= " & Original_AccountEmployeeId & _
                              " Original_TimeEntryStartDate= " & Original_TimeEntryStartDate & " Original_TimeEntryEndDate= " & Original_TimeEntryEndDate _
                               & " Original_AccountEmployeeTimeEntryApprovalProjectId= " & Original_AccountEmployeeTimeEntryApprovalProjectId.ToString & " Original_AccountEmployeeTimeEntryPeriodId= " & Original_AccountEmployeeTimeEntryPeriodId.ToString _
                                & " Original_TimeEntryDate= " & Original_TimeEntryDate & " Original_IsTimeOff= " & Original_IsTimeOff _
                                 & " Original_AccountEmployeeTimeOffRequestId= " & Original_AccountEmployeeTimeOffRequestId.ToString)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryTimeOffRequest Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        DeleteAccountEmployeeTimeEntryTimeOffRequest(Original_AccountEmployeeTimeEntryId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryTimeOffRequest Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction(Original_AccountEmployeeTimeEntryId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction Original_AccountEmployeeTimeEntryId=" & Original_AccountEmployeeTimeEntryId)
        Dim IsDeletedTimeEntryPeriod As Boolean = False
        Dim IsDeletedTimeEntryApprovalProject As Boolean = False
        If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) Then
            If Original_AccountEmployeeTimeEntryPeriodId <> System.Guid.Empty Then
                If Original_TimeEntryViewType <> "" Then
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryApprovalProject Original_AccountEmployeeTimeEntryApprovalProjectId=" & Original_AccountEmployeeTimeEntryApprovalProjectId.ToString)
                    IsDeletedTimeEntryApprovalProject = Me.DeleteAccountEmployeeTimeEntryApprovalProject(Original_AccountEmployeeTimeEntryApprovalProjectId)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryApprovalProject Original_AccountEmployeeTimeEntryApprovalProjectId=" & Original_AccountEmployeeTimeEntryApprovalProjectId.ToString)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: Start DeleteAccountEmployeeTimeEntryPeriod Original_AccountEmployeeTimeEntryPeriodId=" & Original_AccountEmployeeTimeEntryPeriodId.ToString)

                    IsDeletedTimeEntryPeriod = Me.DeleteAccountEmployeeTimeEntryPeriod(Original_AccountEmployeeId, Original_TimeEntryStartDate, Original_TimeEntryEndDate, Original_TimeEntryViewType, Original_AccountEmployeeTimeEntryPeriodId)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod-BLL: Function DeleteAccountEmployeeTimeEntry: End DeleteAccountEmployeeTimeEntryPeriod Original_AccountEmployeeTimeEntryPeriodId=" & Original_AccountEmployeeTimeEntryPeriodId.ToString & "IsDeletedTimeEntryPeriod= " & IsDeletedTimeEntryPeriod)
                End If
                Me.AfterUpdate()
            End If
            Me.AfterUpdate(Original_TimeEntryStartDate)
        End If
        If IsDeletedTimeEntryApprovalProject Or IsDeletedTimeEntryPeriod Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntry with TimeOffHoursDeduction of specified AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub DeleteAccountEmployeeTimeEntryWithTimeOffHoursDeduction(ByVal AccountEmployeeTimeEntryId As Integer)
        Dim AccountEmployeeId As Integer
        Dim AccountTimeOffTypeId As Guid
        Dim TimeOffBll As New AccountEmployeeTimeOffBLL
        Dim TotalTime As String
        Dim IsTimeOff As Boolean
        Dim Approved As Boolean
        Dim AccountProjectTaskId As Integer
        Dim Percentage As Double
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.IsTimeOff = True Then
                If TimeOffBll.CheckTimeEntryTimeOffDeduction(dr) Then
                    AccountEmployeeId = dr.AccountEmployeeId
                    AccountTimeOffTypeId = dr.AccountTimeOffTypeId
                    TotalTime = "-" & dr.TotalTime.ToString("HH:mm")
                    IsTimeOff = dr.IsTimeOff
                    Approved = dr.Approved
                End If
            Else
                AccountProjectTaskId = dr.AccountProjectTaskId
                Percentage = IIf(IsDBNull(dr.Item("Percentage")), 0, dr.Item("Percentage"))
            End If
        End If
        Dim rowsAffected As Integer = Adapter.Delete(AccountEmployeeTimeEntryId)
        If IsTimeOff And Approved Then
            Me.UpdateEmployeeTimeOffHours(AccountEmployeeId, AccountTimeOffTypeId, TotalTime, DBUtilities.GetEmployeeNameWithCode, "Deleted", "Time Entry Archive")
        End If
        If IsTimeOff = False And Percentage <> 0 Then
            Call New AccountProjectTaskBLL().UpdatePercentageAndCompleteTask(AccountProjectTaskId, Nothing, Percentage, 0)
        End If
    End Sub
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntryTimeOffRequest of specified AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub DeleteAccountEmployeeTimeEntryTimeOffRequest(ByVal AccountEmployeeTimeEntryId As Integer)
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("AccountEmployeeTimeOffRequestId")) Then
                Call New AccountEmployeeTimeOffRequestBLL().DeleteAccountEmployeeTimeOffRequest(dr.AccountEmployeeTimeOffRequestId, DBUtilities.GetEmployeeNameWithCode, "Deleted", "Time Entry Archive")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get AccountEmployeeTimeEntries by date week view of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate
    ''' AccountEmployeeTimeEntryPeriodId, IsCopy, CopyToStartDate, CopyToEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="IsCopy"></param>
    ''' <param name="CopyToStartDate"></param>
    ''' <param name="CopyToEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateWeekView(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeTimeEntryPeriodId As Guid, Optional ByVal IsCopy As Boolean = False, Optional ByVal CopyToStartDate As Date = #1/1/2010#, Optional ByVal CopyToEndDate As Date = #1/7/2010#) As DataView
        Dim dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Dim dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable = New AccountEmployeeTimeEntryBLL().GetAccountEmployeeTimeEntriesByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Dim WorkingDays As ArrayList
        Dim WorkingDaysCount As Integer
        Dim dt As New DataTable
        If IsCopy <> True Then
            WorkingDays = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
            WorkingDaysCount = WorkingDays.Count
            Me.AddDefaultColumn(dt, dtGrouped, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount)
            Me.FillAllDayEntries(dt, dtGrouped, dtTimeEntries, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount)
        Else
            WorkingDays = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, CopyToStartDate, CopyToStartDate, CopyToEndDate)
            WorkingDaysCount = WorkingDays.Count
            Me.AddDefaultColumn(dt, dtGrouped, CopyToStartDate, CopyToEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount)
            WorkingDays = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
            WorkingDaysCount = WorkingDays.Count
            Me.FillAllDayEntries(dt, dtGrouped, dtTimeEntries, CopyToStartDate, CopyToEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount)
        End If
        For i As Integer = 0 To DBUtilities.GetNumberOfBlankRowsInTimeEntry - 1
            AddRowsInDatatableForWeekView(dt, "Standard Time", "False", "1")
        Next
        Dim dv As New DataView(dt)
        'dv.Sort = "AccountProjectTaskId"
        Return dv
    End Function
    ''' <summary>
    ''' Get AccountEmployeeTimeEntries for period view of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate
    ''' AccountEmployeeTimeEntryPeriodId, IsCopy, CopyToStartDate, CopyToEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="IsCopy"></param>
    ''' <param name="CopyToStartDate"></param>
    ''' <param name="CopyToEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesForPeriodView(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeTimeEntryPeriodId As Guid, Optional ByVal IsCopy As Boolean = False, Optional ByVal CopyToStartDate As Date = #1/1/2010#, Optional ByVal CopyToEndDate As Date = #1/7/2010#, Optional ByVal IsFromMobileTimeSheet As Boolean = False, Optional IsFromTemplate As Boolean = False) As DataView
        Dim dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        Dim dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
        If Not IsFromTemplate Then
            If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                dtGrouped = Me.GetGroupedTimeEntryByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                dtTimeEntries = Me.GetAccountEmployeeTimeEntriesByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, IsFromMobileTimeSheet)
            Else
                dtGrouped = Me.GetGroupedTimeEntryByPeriodIdWithStatus(AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                dtTimeEntries = Me.GetAccountEmployeeTimeEntriesByPeriodId(AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, IsFromMobileTimeSheet)
            End If
        End If
        Dim WorkingDays As ArrayList
        Dim WorkingDaysCount As Integer
        Dim dt As New DataTable
        Me.SetTimeEntryDataForPeriodView(IsCopy, WorkingDays, WorkingDaysCount, dt, dtGrouped, dtTimeEntries, _
        AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, CopyToStartDate, CopyToEndDate, IsFromMobileTimeSheet, IsFromTemplate)
        Dim dv As DataView
        If Not IsFromMobileTimeSheet Then
            dv = New DataView(dt)
            dv.Sort = "GroupFieldTimeOff"
        Else
            dv = New DataView(dtTimeEntries)
            dv.Sort = "TimeEntryDate"
        End If
        Return dv
    End Function
    ''' <summary>
    ''' Set TimeEntryData for period view of specified IsCopy, WorkingDays, WorkingDaysCount, DataTable, dtGrouped
    ''' dtTimeEntries, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, CopyToStartDate, CopyToEndDate
    ''' </summary>
    ''' <param name="IsCopy"></param>
    ''' <param name="WorkingDays"></param>
    ''' <param name="WorkingDaysCount"></param>
    ''' <param name="dt"></param>
    ''' <param name="dtGrouped"></param>
    ''' <param name="dtTimeEntries"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="CopyToStartDate"></param>
    ''' <param name="CopyToEndDate"></param>
    ''' <remarks></remarks>
    Public Sub SetTimeEntryDataForPeriodView(ByVal IsCopy As Boolean, ByVal WorkingDays As ArrayList, ByVal WorkingDaysCount As Integer, _
    ByVal dt As DataTable, ByVal dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable, _
    ByVal dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable, ByVal AccountEmployeeId As Integer, _
    ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal CopyToStartDate As Date, ByVal CopyToEndDate As Date, _
    Optional ByVal IsFromMobileTimeSheet As Boolean = False, Optional IsFromTemplate As Boolean = False)
        If IsCopy <> True Then
            WorkingDays = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
            WorkingDaysCount = WorkingDays.Count
            Me.AddDefaultColumn(dt, dtGrouped, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount, IsFromMobileTimeSheet)
            If Not IsFromTemplate Then
                Me.FillAllDayEntries(dt, dtGrouped, dtTimeEntries, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount, , , , IsFromMobileTimeSheet)
            End If
        Else
            WorkingDays = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, CopyToStartDate, CopyToStartDate, CopyToEndDate)
            WorkingDaysCount = WorkingDays.Count
            Me.AddDefaultColumn(dt, dtGrouped, CopyToStartDate, CopyToEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount, IsFromMobileTimeSheet)
            If Not IsFromTemplate Then
                WorkingDays = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
                WorkingDaysCount = WorkingDays.Count
                Me.FillAllDayEntries(dt, dtGrouped, dtTimeEntries, CopyToStartDate, CopyToEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount, IsCopy, , , IsFromMobileTimeSheet)
            End If
        End If
        If Not IsFromMobileTimeSheet Then
            If IsFromTemplate Then
                AddRowsInDatatableForWeekViewTemplate(dt, AccountEmployeeId, "Standard Time", "False", "1")
            End If
            For i As Integer = 0 To DBUtilities.GetNumberOfBlankRowsInTimeEntry - 1
                AddRowsInDatatableForWeekView(dt, "Standard Time", "False", "1")
            Next
            If LocaleUtilitiesBLL.IsShowTimeOffInTimesheet Then
                For i As Integer = 0 To 2 - 1
                    AddRowsInDatatableForWeekView(dt, "Time Off", "True", "2")
                Next
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get all employees time entries by DateWeekView of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate 
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllAccountEmployeeTimeEntriesByDateWeekViewReadOnly(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As DataView

        Dim dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Dim dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable = New AccountEmployeeTimeEntryBLL().GetAccountEmployeeTimeEntriesByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Dim WorkingDays As ArrayList = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
        Dim WorkingDaysCount As Integer = WorkingDays.Count
        Dim dt As New DataTable
        Me.AddDefaultColumn(dt, dtGrouped, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount)
        Me.FillAllDayEntries(dt, dtGrouped, dtTimeEntries, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount, False, True, True)

        Dim dv As New DataView(dt)
        dv.Sort = "GroupFieldTimeOff"
        Return dv
    End Function
    ''' <summary>
    ''' Add rows in data table for weekview of specified TimeType, IsTimeOff, GroupFieldTimeOff
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="TimeType"></param>
    ''' <param name="IsTimeOff"></param>
    ''' <param name="GroupFieldTimeOff"></param>
    ''' <remarks></remarks>
    Public Sub AddRowsInDatatableForWeekView(ByVal dt As DataTable, ByVal TimeType As String, ByVal IsTimeOff As String, ByVal GroupFieldTimeOff As String)
        Dim objRow As DataRow
        objRow = dt.NewRow()
        objRow("IsTimeOff") = IsTimeOff
        objRow("TimeType") = TimeType
        objRow("GroupFieldTimeOff") = GroupFieldTimeOff
        dt.Rows.Add(objRow)
    End Sub
    Public Sub AddRowsInDatatableForWeekViewTemplate(ByVal dt As DataTable, AccountEmployeeId As Integer, ByVal TimeType As String, ByVal IsTimeOff As String, ByVal GroupFieldTimeOff As String)
        Dim TemplateBLL As New AccountEmployeeTimeEntryTemplate
        Dim dtTemplate As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable = TemplateBLL.GetDataByAccountEmployeeIdForTimesheet(AccountEmployeeId)
        Dim drTemplate As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateRow
        For Each drTemplate In dtTemplate.Rows
            Dim objRow As DataRow
            objRow = dt.NewRow()
            objRow("AccountProjectId") = drTemplate.AccountProjectId
            objRow("AccountProjectTaskId") = drTemplate.AccountProjectTaskId
            objRow("IsTimeOff") = IsTimeOff
            objRow("TimeType") = TimeType
            objRow("GroupFieldTimeOff") = GroupFieldTimeOff
            dt.Rows.Add(objRow)
        Next
    End Sub
    ''' <summary>
    ''' Get employee time entries by DateWeekView of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, Type
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Type"></param>
    ''' <returns>Data view</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByDateWeekViewReadOnly(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Type As String) As DataView

        Dim dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
        If Type = "TeamLead" Then
            dtGrouped = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeForRelevantProjectTeamLead(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, DBUtilities.GetSessionAccountEmployeeId)
        ElseIf Type = "ProjectManager" Then
            dtGrouped = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeForRelevantProjectProjectManager(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, DBUtilities.GetSessionAccountEmployeeId)
        ElseIf Type = "SpecificEmployee" Then
            dtGrouped = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificEmployee(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, DBUtilities.GetSessionAccountEmployeeId)
        ElseIf Type = "SpecificExternalUser" Then
            dtGrouped = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeForRelevantProjectSpecificExternalUser(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, DBUtilities.GetSessionAccountEmployeeId)
        ElseIf Type = "EmployeeManager" Then
            dtGrouped = New AccountEmployeeTimeEntryBLL().GetGroupedTimeEntryByDateRangeForRelevantProjectEmployeeManager(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, DBUtilities.GetSessionAccountEmployeeId)
        End If

        Dim dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable = New AccountEmployeeTimeEntryBLL().GetAccountEmployeeTimeEntriesByDateRangeWithStatus(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        Dim dt As New DataTable
        Dim WorkingDays As ArrayList = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
        Dim WorkingDaysCount As Integer = WorkingDays.Count
        Me.AddDefaultColumn(dt, dtGrouped, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount)
        Me.FillAllDayEntries(dt, dtGrouped, dtTimeEntries, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount, False, True, False)
        Dim dv As New DataView(dt)
        dv.Sort = "AccountProjectTaskId"

        Return dv

    End Function
    ''' <summary>
    ''' Add default column of specified dtGrouped, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId, WorkingDays, WorkingDaysCount
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dtGrouped"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="WorkingDays"></param>
    ''' <param name="WorkingDaysCount"></param>
    ''' <remarks></remarks>
    Public Sub AddDefaultColumn(ByVal dt As DataTable, ByVal dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As Integer, ByVal WorkingDays As ArrayList, ByVal WorkingDaysCount As Integer, Optional ByVal IsFromMobileTimeSheet As Boolean = False)

        dt.Columns.Add("AccountProjectId", GetType(Integer))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("AccountProjectTaskId", GetType(Integer))
        dt.Columns.Add("TaskName", GetType(String))
        dt.Columns.Add("AccountWorkTypeId", GetType(Integer))
        dt.Columns.Add("AccountWorkType", GetType(String))
        dt.Columns.Add("AccountCostCenterId", GetType(Integer))
        dt.Columns.Add("AccountCostCenter", GetType(String))
        dt.Columns.Add("IsApproved", GetType(Boolean))
        dt.Columns.Add("IsReject", GetType(Boolean))
        dt.Columns.Add("Submitted", GetType(Boolean))
        dt.Columns.Add("Approved", GetType(Boolean))
        dt.Columns.Add("Rejected", GetType(Boolean))
        dt.Columns.Add("AccountClientId", GetType(Integer))
        dt.Columns.Add("PartyName", GetType(String))
        dt.Columns.Add("PeriodDescription", GetType(String))
        dt.Columns.Add("TimeType", GetType(String))
        dt.Columns.Add("GroupFieldTimeOff", GetType(String))
        dt.Columns.Add("IsTimeOff", GetType(Boolean))
        dt.Columns.Add("AccountTimeOffTypeId", GetType(Guid))
        dt.Columns.Add("AccountEmployeeTimeOffRequestId", GetType(Guid))
        dt.Columns.Add("AccountTimeOffType", GetType(String))
        dt.Columns.Add("AccountEmployeeTimeEntryApprovalProjectId", GetType(Guid))
        dt.Columns.Add("ProjectApproved", GetType(Boolean))
        dt.Columns.Add("TimeEntryDate", GetType(Date))
        If IsFromMobileTimeSheet Then
            dt.Columns.Add("AccountEmployeeTimeEntryId", GetType(Integer))
            dt.Columns.Add("StartTime", GetType(DateTime))
            dt.Columns.Add("EndTime", GetType(DateTime))
            dt.Columns.Add("TotalTime", GetType(DateTime))
            dt.Columns.Add("Hours", GetType(Decimal))
            dt.Columns.Add("Description", GetType(String))
        End If

        Dim dtDate As DateTime = TimeEntryStartDate
        Dim n As Integer = 0


        For n = 0 To WorkingDaysCount - 1

            dt.Columns.Add("AccountEmployeeTimeEntryId" & n, GetType(Integer))
            dt.Columns.Add("StartTime" & n, GetType(DateTime))
            dt.Columns.Add("EndTime" & n, GetType(DateTime))
            dt.Columns.Add("Hours" & n, GetType(Decimal))
            dt.Columns.Add("TotalTime" & n, GetType(DateTime))
            dt.Columns.Add("IsApproved" & n, GetType(Boolean))
            dt.Columns.Add("IsReject" & n, GetType(Boolean))
            dt.Columns.Add("Submitted" & n, GetType(Boolean))
            dt.Columns.Add("Approved" & n, GetType(Boolean))
            dt.Columns.Add("Rejected" & n, GetType(Boolean))
            dt.Columns.Add("Description" & n, GetType(String))
            dt.Columns.Add("Percentage" & n, GetType(Double))
            dt.Columns.Add("CustomField1" & n, GetType(String))
            dt.Columns.Add("CustomField2" & n, GetType(String))
            dt.Columns.Add("CustomField3" & n, GetType(String))
            dt.Columns.Add("CustomField4" & n, GetType(String))
            dt.Columns.Add("CustomField5" & n, GetType(String))
            dt.Columns.Add("CustomField6" & n, GetType(String))
            dt.Columns.Add("CustomField7" & n, GetType(String))
            dt.Columns.Add("CustomField8" & n, GetType(String))
            dt.Columns.Add("CustomField9" & n, GetType(String))
            'dt.Columns.Add("PeriodDescription" & n, GetType(String))

            'n = n + 1
            dtDate = WorkingDays(n)

        Next
    End Sub
    ''' <summary>
    ''' Fill all day entries of specified dtGrouped, dtTimeEntries, TimeEntryStartDate, TimeEntryEndDate
    ''' AccountEmployeeId, WorkingDays, WorkingDaysCount, IsCopy, IsFromWeekViewReadOnly, IsCheckedALLFromWeekViewReadOnly
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dtGrouped"></param>
    ''' <param name="dtTimeEntries"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="WorkingDays"></param>
    ''' <param name="WorkingDaysCount"></param>
    ''' <param name="IsCopy"></param>
    ''' <param name="IsFromWeekViewReadOnly"></param>
    ''' <param name="IsCheckedALLFromWeekViewReadOnly"></param>
    ''' <remarks></remarks>
    Public Sub FillAllDayEntries(ByVal dt As DataTable, ByVal dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable, ByVal dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As Integer, ByVal WorkingDays As ArrayList, ByVal WorkingDaysCount As Integer, Optional ByVal IsCopy As Boolean = False, Optional ByVal IsFromWeekViewReadOnly As Boolean = False, Optional ByVal IsCheckedALLFromWeekViewReadOnly As Boolean = False, Optional ByVal IsFromMobileTimeSheet As Boolean = False)

        Dim dtDate As DateTime = TimeEntryStartDate

        Dim n As Integer = 0

        For n = 0 To WorkingDaysCount - 1
            If n <= DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate).Count - 1 Then
                dtDate = WorkingDays(n)
                If Not IsFromMobileTimeSheet Then
                    Me.FillOneDayEntries(dt, dtGrouped, dtTimeEntries, dtDate, n, IsCopy, IsFromWeekViewReadOnly, IsCheckedALLFromWeekViewReadOnly, IsFromMobileTimeSheet)
                Else
                    Me.FillOneDayEntriesForMobile(dt, dtGrouped, dtTimeEntries, dtDate, IsCopy, IsFromWeekViewReadOnly, IsCheckedALLFromWeekViewReadOnly, IsFromMobileTimeSheet)
                End If
            End If
        Next

    End Sub
    ''' <summary>
    ''' Fill one day entries of specified dtGrouped, dtTimeEntries, TimeEntryDate, DayNo, IsCopy, IsFromWeekViewReadOnly, IsCheckedALLFromWeekViewReadOnly
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dtGrouped"></param>
    ''' <param name="dtTimeEntries"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="DayNo"></param>
    ''' <param name="IsCopy"></param>
    ''' <param name="IsFromWeekViewReadOnly"></param>
    ''' <param name="IsCheckedALLFromWeekViewReadOnly"></param>
    ''' <remarks></remarks>
    Public Sub FillOneDayEntries(ByVal dt As DataTable, ByVal dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable, ByVal dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable, ByVal TimeEntryDate As Date, ByVal DayNo As Integer, Optional ByVal IsCopy As Boolean = False, Optional ByVal IsFromWeekViewReadOnly As Boolean = False, Optional ByVal IsCheckedALLFromWeekViewReadOnly As Boolean = False, Optional ByVal IsFromMobileTimeSheet As Boolean = False)

        Dim objRow As DataRow
        For Each objRow In dtGrouped.Rows
            Dim objTimeEntryRow As DataRow
            Dim IsTimeOff As Boolean
            If Not IsDBNull(objRow("IsTimeOff")) Then
                IsTimeOff = objRow("IsTimeOff")
            End If
            If IsTimeOff = False Or (IsTimeOff And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet And Not IsFromMobileTimeSheet) Then
                Dim findRows As DataRow()
                Dim findExpr As String
                Dim findExprDt As String
                If IsTimeOff Then
                    findExpr = "TimeEntryDate = '" & TimeEntryDate & "' and AccountTimeOffTypeId = '" & objRow("AccountTimeOffTypeId").ToString & "'" & IIf(IsCopy, " and AccountEmployeeTimeOffRequestId is null ", "") & IIf(LocaleUtilitiesBLL.IsShowProjectForTimeOff, "and AccountProjectId " & IIf(IsDBNull(objRow("AccountProjectId")), "Is Null", "=" & objRow("AccountProjectId")), "")
                    findExprDt = "AccountTimeOffTypeId = '" & objRow("AccountTimeOffTypeId").ToString & "'" & IIf(IsCopy, " and AccountEmployeeTimeOffRequestId is null ", "") & IIf(LocaleUtilitiesBLL.IsShowProjectForTimeOff, "and AccountProjectId " & IIf(IsDBNull(objRow("AccountProjectId")), "Is Null", "=" & objRow("AccountProjectId")), "")
                    If IsFromWeekViewReadOnly And Not IsCheckedALLFromWeekViewReadOnly Then
                        findExpr = "AccountEmployeeTimeOffRequestId Is Not Null AND IsTimeOff = False"
                        findExprDt = "AccountEmployeeTimeOffRequestId Is Not Null AND IsTimeOff = False"
                    End If
                Else
                    findExpr = "TimeEntryDate = '" & TimeEntryDate & "' and AccountProjectId = " & objRow("AccountProjectId") & " and AccountProjectTaskId = " & objRow("AccountProjectTaskId") & " and AccountWorkTypeId = " & objRow("AccountWorkTypeId") & " and AccountCostCenterId " & IIf(IsDBNull(objRow("AccountCostCenterId")), "Is Null", "=" & objRow("AccountCostCenterId"))
                    findExprDt = "AccountProjectId = " & objRow("AccountProjectId") & " and AccountProjectTaskId = " & objRow("AccountProjectTaskId") & " and AccountWorkTypeId = " & objRow("AccountWorkTypeId") & " and AccountCostCenterId " & IIf(IsDBNull(objRow("AccountCostCenterId")), "Is Null", "=" & objRow("AccountCostCenterId"))
                End If

                findRows = dtTimeEntries.Select(findExpr)
                Dim dtRow As DataRow

                For n As Integer = 0 To findRows.Length - 1
                    Dim dtDateEntries As DataRow() = dt.Select(findExprDt)

                    If n >= dtDateEntries.Length Then

                        objTimeEntryRow = dt.NewRow
                        If IsTimeOff Then
                            objTimeEntryRow("PeriodDescription") = objRow("PeriodDescription")
                            objTimeEntryRow("AccountTimeOffTypeId") = objRow("AccountTimeOffTypeId")
                            objTimeEntryRow("AccountTimeOffType") = objRow("AccountTimeOffType")
                            If Not IsDBNull(objRow("AccountProjectId")) Then
                                objTimeEntryRow("AccountProjectId") = objRow("AccountProjectId")
                                objTimeEntryRow("ProjectName") = objRow("ProjectName")
                            End If
                            If Not IsDBNull(objRow("PartyName")) Then
                                objTimeEntryRow("PartyName") = objRow("PartyName")
                            End If
                        Else
                            objTimeEntryRow("TimeEntryDate") = TimeEntryDate
                            objTimeEntryRow("AccountProjectId") = objRow("AccountProjectId")
                            objTimeEntryRow("ProjectName") = objRow("ProjectName")
                            objTimeEntryRow("AccountProjectTaskId") = objRow("AccountProjectTaskId")
                            objTimeEntryRow("TaskName") = objRow("TaskName")
                            objTimeEntryRow("AccountWorkTypeId") = objRow("AccountWorkTypeId")
                            objTimeEntryRow("AccountWorkType") = objRow("AccountWorktype")
                            objTimeEntryRow("AccountCostCenterId") = objRow("AccountCostCenterId")
                            objTimeEntryRow("AccountCostCenter") = objRow("AccountCostCenter")
                            objTimeEntryRow("PartyName") = objRow("PartyName")
                            objTimeEntryRow("PeriodDescription") = objRow("PeriodDescription")
                            objTimeEntryRow("AccountEmployeeTimeEntryApprovalProjectId") = objRow("AccountEmployeeTimeEntryApprovalProjectId")
                            objTimeEntryRow("ProjectApproved") = objRow("ProjectApproved")
                        End If

                        dt.Rows.Add(objTimeEntryRow)
                        dtRow = objTimeEntryRow
                    Else
                        dtRow = dtDateEntries(n)

                    End If
                    If IsTimeOff Then
                        dtRow("AccountTimeOffTypeId") = findRows(n).Item("AccountTimeOffTypeId")
                        dtRow("AccountEmployeeTimeOffRequestId") = findRows(n).Item("AccountEmployeeTimeOffRequestId")
                        If Not IsDBNull(findRows(n).Item("AccountProjectId")) Then
                            dtRow("AccountProjectId") = findRows(n).Item("AccountProjectId")
                        End If

                        If Not IsDBNull(findRows(n).Item("PartyName")) Then
                            dtRow("AccountClientId") = findRows(n).Item("AccountClientId")
                            dtRow("PartyName") = findRows(n).Item("PartyName")
                        End If

                        dtRow("TimeType") = "Time Off"
                        dtRow("GroupFieldTimeOff") = "2"
                        dtRow("IsTimeOff") = "True"
                    Else
                        dtRow("AccountProjectId") = findRows(n).Item("AccountProjectId")
                        dtRow("AccountClientId") = findRows(n).Item("AccountClientId")
                        dtRow("AccountWorkTypeId") = findRows(n).Item("AccountWorkTypeId")
                        dtRow("AccountCostCenterId") = findRows(n).Item("AccountCostCenterId")
                        dtRow("TimeType") = "Standard Time"
                        dtRow("GroupFieldTimeOff") = "1"
                        dtRow("IsTimeOff") = "False"
                    End If
                    dtRow("AccountEmployeeTimeEntryId" & DayNo) = findRows(n).Item("AccountEmployeeTimeEntryId")
                    dtRow("StartTime" & DayNo) = findRows(n).Item("StartTime")
                    dtRow("EndTime" & DayNo) = findRows(n).Item("EndTime")
                    dtRow("TotalTime" & DayNo) = findRows(n).Item("TotalTime")
                    dtRow("Hours" & DayNo) = findRows(n).Item("Hours")
                    dtRow("Percentage" & DayNo) = findRows(n).Item("Percentage")
                    dtRow("Description" & DayNo) = findRows(n).Item("Description")
                    dtRow("CustomField1" & DayNo) = findRows(n).Item("CustomField1")
                    dtRow("CustomField2" & DayNo) = findRows(n).Item("CustomField2")
                    dtRow("CustomField3" & DayNo) = findRows(n).Item("CustomField3")
                    dtRow("CustomField4" & DayNo) = findRows(n).Item("CustomField4")
                    dtRow("CustomField5" & DayNo) = findRows(n).Item("CustomField5")
                    dtRow("CustomField6" & DayNo) = findRows(n).Item("CustomField6")
                    dtRow("CustomField7" & DayNo) = findRows(n).Item("CustomField7")
                    dtRow("CustomField8" & DayNo) = findRows(n).Item("CustomField8")
                    dtRow("CustomField9" & DayNo) = findRows(n).Item("CustomField9")
                    'dtRow("PeriodDescription" & DayNo) = findRows(n).Item("PeriodDescription")
                    If IsDBNull(dtRow("IsApproved")) AndAlso Not IsDBNull(findRows(n).Item("IsApproved")) Then
                        dtRow("IsApproved") = findRows(n).Item("IsApproved")
                    End If
                    If IsDBNull(dtRow("Submitted")) AndAlso Not IsDBNull(findRows(n).Item("Submitted")) Then
                        dtRow("Submitted") = findRows(n).Item("Submitted")
                    End If
                    If IsDBNull(dtRow("Approved")) AndAlso Not IsDBNull(findRows(n).Item("Approved")) Then
                        dtRow("Approved") = findRows(n).Item("Approved")
                    End If
                    If IsDBNull(dtRow("Rejected")) AndAlso Not IsDBNull(findRows(n).Item("Rejected")) Then
                        dtRow("Rejected") = findRows(n).Item("Rejected")
                    End If
                    'If IsDBNull(dtRow("IsApproved")) AndAlso Not isdbnull(findRows(n).Item("IsApproved")) AndAlso findRows(n).Item("IsApproved") <> True Then
                    dtRow("IsApproved" & DayNo) = findRows(n).Item("IsApproved")
                    dtRow("Submitted" & DayNo) = findRows(n).Item("Submitted")
                    dtRow("Approved" & DayNo) = findRows(n).Item("Approved")
                    dtRow("Rejected" & DayNo) = findRows(n).Item("Rejected")
                Next
            End If
        Next
    End Sub
    Public Sub FillOneDayEntriesForMobile(ByVal dt As DataTable, ByVal dtGrouped As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable, ByVal dtTimeEntries As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable, ByVal TimeEntryDate As Date, Optional ByVal IsCopy As Boolean = False, Optional ByVal IsFromWeekViewReadOnly As Boolean = False, Optional ByVal IsCheckedALLFromWeekViewReadOnly As Boolean = False, Optional ByVal IsFromMobileTimeSheet As Boolean = False)

        Dim objRow As DataRow
        For Each objRow In dtGrouped.Rows
            Dim objTimeEntryRow As DataRow
            Dim IsTimeOff As Boolean
            If Not IsDBNull(objRow("IsTimeOff")) Then
                IsTimeOff = objRow("IsTimeOff")
            End If
            If IsTimeOff = False Or (IsTimeOff And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet And Not IsFromMobileTimeSheet) Then
                Dim findRows As DataRow()
                Dim findExpr As String
                Dim findExprDt As String
                If IsTimeOff Then
                    findExpr = "TimeEntryDate = '" & TimeEntryDate & "' and AccountTimeOffTypeId = '" & objRow("AccountTimeOffTypeId").ToString & "'" & IIf(IsCopy, " and AccountEmployeeTimeOffRequestId is null ", "") & IIf(LocaleUtilitiesBLL.IsShowProjectForTimeOff, "and AccountProjectId " & IIf(IsDBNull(objRow("AccountProjectId")), "Is Null", "=" & objRow("AccountProjectId")), "")
                    findExprDt = "AccountTimeOffTypeId = '" & objRow("AccountTimeOffTypeId").ToString & "'" & IIf(IsCopy, " and AccountEmployeeTimeOffRequestId is null ", "") & IIf(LocaleUtilitiesBLL.IsShowProjectForTimeOff, "and AccountProjectId " & IIf(IsDBNull(objRow("AccountProjectId")), "Is Null", "=" & objRow("AccountProjectId")), "")
                    If IsFromWeekViewReadOnly And Not IsCheckedALLFromWeekViewReadOnly Then
                        findExpr = "AccountEmployeeTimeOffRequestId Is Not Null AND IsTimeOff = False"
                        findExprDt = "AccountEmployeeTimeOffRequestId Is Not Null AND IsTimeOff = False"
                    End If
                Else
                    findExpr = "TimeEntryDate = '" & TimeEntryDate & "' and AccountProjectId = " & objRow("AccountProjectId") & " and AccountProjectTaskId = " & objRow("AccountProjectTaskId") & " and AccountWorkTypeId = " & objRow("AccountWorkTypeId") & " and AccountCostCenterId " & IIf(IsDBNull(objRow("AccountCostCenterId")), "Is Null", "=" & objRow("AccountCostCenterId"))
                    findExprDt = "AccountProjectId = " & objRow("AccountProjectId") & " and AccountProjectTaskId = " & objRow("AccountProjectTaskId") & " and AccountWorkTypeId = " & objRow("AccountWorkTypeId") & " and AccountCostCenterId " & IIf(IsDBNull(objRow("AccountCostCenterId")), "Is Null", "=" & objRow("AccountCostCenterId"))
                End If

                findRows = dtTimeEntries.Select(findExpr)
                Dim dtRow As DataRow

                For n As Integer = 0 To findRows.Length - 1
                    Dim dtDateEntries As DataRow() = dt.Select(findExprDt)

                    If n >= dtDateEntries.Length Then

                        objTimeEntryRow = dt.NewRow
                        If IsTimeOff Then
                            objTimeEntryRow("PeriodDescription") = objRow("PeriodDescription")
                            objTimeEntryRow("AccountTimeOffTypeId") = objRow("AccountTimeOffTypeId")
                            objTimeEntryRow("AccountTimeOffType") = objRow("AccountTimeOffType")
                            If Not IsDBNull(objRow("AccountProjectId")) Then
                                objTimeEntryRow("AccountProjectId") = objRow("AccountProjectId")
                                objTimeEntryRow("ProjectName") = objRow("ProjectName")
                            End If
                            If Not IsDBNull(objRow("PartyName")) Then
                                objTimeEntryRow("PartyName") = objRow("PartyName")
                            End If
                        Else
                            objTimeEntryRow("TimeEntryDate") = TimeEntryDate
                            objTimeEntryRow("AccountProjectId") = objRow("AccountProjectId")
                            objTimeEntryRow("ProjectName") = objRow("ProjectName")
                            objTimeEntryRow("AccountProjectTaskId") = objRow("AccountProjectTaskId")
                            objTimeEntryRow("TaskName") = objRow("TaskName")
                            objTimeEntryRow("AccountWorkTypeId") = objRow("AccountWorkTypeId")
                            objTimeEntryRow("AccountWorkType") = objRow("AccountWorktype")
                            objTimeEntryRow("AccountCostCenterId") = objRow("AccountCostCenterId")
                            objTimeEntryRow("AccountCostCenter") = objRow("AccountCostCenter")
                            objTimeEntryRow("PartyName") = objRow("PartyName")
                            objTimeEntryRow("PeriodDescription") = objRow("PeriodDescription")
                            objTimeEntryRow("AccountEmployeeTimeEntryApprovalProjectId") = objRow("AccountEmployeeTimeEntryApprovalProjectId")
                            objTimeEntryRow("ProjectApproved") = objRow("ProjectApproved")
                        End If

                        dt.Rows.Add(objTimeEntryRow)
                        dtRow = objTimeEntryRow
                    Else
                        dtRow = dtDateEntries(n)

                    End If
                    If IsTimeOff Then
                        dtRow("AccountTimeOffTypeId") = findRows(n).Item("AccountTimeOffTypeId")
                        dtRow("AccountEmployeeTimeOffRequestId") = findRows(n).Item("AccountEmployeeTimeOffRequestId")
                        If Not IsDBNull(findRows(n).Item("AccountProjectId")) Then
                            dtRow("AccountProjectId") = findRows(n).Item("AccountProjectId")
                        End If

                        If Not IsDBNull(findRows(n).Item("PartyName")) Then
                            dtRow("AccountClientId") = findRows(n).Item("AccountClientId")
                            dtRow("PartyName") = findRows(n).Item("PartyName")
                        End If

                        dtRow("TimeType") = "Time Off"
                        dtRow("GroupFieldTimeOff") = "2"
                        dtRow("IsTimeOff") = "True"
                    Else
                        dtRow("AccountProjectId") = findRows(n).Item("AccountProjectId")
                        dtRow("AccountClientId") = findRows(n).Item("AccountClientId")
                        dtRow("AccountWorkTypeId") = findRows(n).Item("AccountWorkTypeId")
                        dtRow("AccountCostCenterId") = findRows(n).Item("AccountCostCenterId")
                        dtRow("TimeType") = "Standard Time"
                        dtRow("GroupFieldTimeOff") = "1"
                        dtRow("IsTimeOff") = "False"
                    End If
                    dtRow("AccountEmployeeTimeEntryId") = findRows(n).Item("AccountEmployeeTimeEntryId")
                    dtRow("StartTime") = findRows(n).Item("StartTime")
                    dtRow("EndTime") = findRows(n).Item("EndTime")
                    dtRow("TotalTime") = findRows(n).Item("TotalTime")
                    dtRow("Hours") = findRows(n).Item("Hours")
                    dtRow("Description") = findRows(n).Item("Description")
                    'dtRow("PeriodDescription" & DayNo) = findRows(n).Item("PeriodDescription")
                    If IsDBNull(dtRow("IsApproved")) AndAlso Not IsDBNull(findRows(n).Item("IsApproved")) Then
                        dtRow("IsApproved") = findRows(n).Item("IsApproved")
                    End If
                    If IsDBNull(dtRow("Submitted")) AndAlso Not IsDBNull(findRows(n).Item("Submitted")) Then
                        dtRow("Submitted") = findRows(n).Item("Submitted")
                    End If
                    If IsDBNull(dtRow("Approved")) AndAlso Not IsDBNull(findRows(n).Item("Approved")) Then
                        dtRow("Approved") = findRows(n).Item("Approved")
                    End If
                    If IsDBNull(dtRow("Rejected")) AndAlso Not IsDBNull(findRows(n).Item("Rejected")) Then
                        dtRow("Rejected") = findRows(n).Item("Rejected")
                    End If
                    'If IsDBNull(dtRow("IsApproved")) AndAlso Not isdbnull(findRows(n).Item("IsApproved")) AndAlso findRows(n).Item("IsApproved") <> True Then
                Next
            End If
        Next
    End Sub
    ''' <summary>
    ''' Get prepared email message for approved time sheet
    ''' </summary>
    ''' <param name="drvueAccountEmployeeTimeEntryApprovedEmail"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForApprovedTimeSheet(ByVal drvueAccountEmployeeTimeEntryApprovedEmail As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovedEmailRow) As StringDictionary


        Dim drAccountEmployee As AccountEmployee.AccountEmployeeRow
        Dim objAccountEmployee As New AccountEmployeeBLL
        drAccountEmployee = objAccountEmployee.GetAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId).Rows(0)

        Dim dict As New StringDictionary

        dict.Add("[employeename]", drvueAccountEmployeeTimeEntryApprovedEmail.EmployeeName)
        dict.Add("[timeentrydate]", drvueAccountEmployeeTimeEntryApprovedEmail.TimeEntryDate)
        dict.Add("[projectname]", drvueAccountEmployeeTimeEntryApprovedEmail.ProjectName)
        dict.Add("[taskname]", drvueAccountEmployeeTimeEntryApprovedEmail.TaskName)
        dict.Add("[status]", "Approved")

        Dim TTime As String
        TTime = Format(drvueAccountEmployeeTimeEntryApprovedEmail.TotalTime, "HH:mm")
        dict.Add("[totaltime]", TTime)

        dict.Add("[comments]", drvueAccountEmployeeTimeEntryApprovedEmail.Comments)
        dict.Add("[approvedby]", drAccountEmployee.FirstName + " " + drAccountEmployee.LastName)

        Return dict

    End Function
    ''' <summary>
    ''' Send approved time sheet of specified AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub SendApprovedTimesheet(ByVal AccountEmployeeTimeEntryId As Integer)

        Dim objvueAccountEmployeeTimeEntryApprovedEmail As New AccountEmployeeTimeEntryBLL
        Dim dtvueAccountEmployeeTimeEntryApprovedEmail As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovedEmailDataTable = objvueAccountEmployeeTimeEntryApprovedEmail.GetApprovedAccountEmployeeTimeEntryForEmail(AccountEmployeeTimeEntryId)
        Dim drvueAccountEmployeeTimeEntryApprovedEmail As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovedEmailRow

        If dtvueAccountEmployeeTimeEntryApprovedEmail.Rows.Count > 0 Then
            drvueAccountEmployeeTimeEntryApprovedEmail = dtvueAccountEmployeeTimeEntryApprovedEmail.Rows(0)


            'For Each drvueAccountEmployeeTimeEntryApproval In dtvueAccountEmployeeTimeEntryApproval.Rows
            EMailUtilities.SendEMail("Your timesheet has been approved", "TimesheetApprovedTemplate", GetPreparedEMailMessageForApprovedTimeSheet(drvueAccountEmployeeTimeEntryApprovedEmail), drvueAccountEmployeeTimeEntryApprovedEmail.EMailAddress, drvueAccountEmployeeTimeEntryApprovedEmail.EmployeeName, , EMailUtilities.TIMESHEET_APPROVED_NOTIFICATION_INFORMATION_FROM)
            'Next
        End If
    End Sub
    ''' <summary>
    ''' Send time sheet approved email of specified AccountEmployeeTimeEntryId 
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetApprovedEMail(ByVal AccountEmployeeTimeEntryId As Integer)
        SendApprovedTimesheet(AccountEmployeeTimeEntryId)
        EMailUtilities.DequeueEmail()
    End Sub
    ''' <summary>
    ''' Send time sheet approved email summary of specified EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="Comments"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetApprovedEMailSummary(ByVal EmployeeName As String, ByVal TotalMinutes As Double, ByVal Comments As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal EmailAddress As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        SendApprovedTimesheetSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        SendPendingTimesheetForSpecificTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId)
        EMailUtilities.DequeueEmail()
    End Sub
    ''' <summary>
    ''' Send approved time sheet summary of specified EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="Comments"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SendApprovedTimesheetSummary(ByVal EmployeeName As String, ByVal TotalMinutes As Double, ByVal Comments As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal EmailAddress As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        If GetApprovedAccountEmployeeTimeEntryPeriodForEmailByPeriodId(AccountEmployeeTimeEntryPeriodId).Rows.Count > 0 Then
            EMailUtilities.SendEMail("Your timesheet has been approved", "TimesheetApprovedSummaryTemplate", GetPreparedEMailMessageForApprovedTimeSheetSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate), EmailAddress, EmployeeName, , EMailUtilities.TIMESHEET_APPROVED_NOTIFICATION_INFORMATION_FROM)
        End If
        If GetApprovedAccountEmployeeTimeEntryPeriodForEmailByPeriodIdToApprover(AccountEmployeeTimeEntryPeriodId).Rows.Count > 0 Then
            EMailUtilities.SendEMail(EmployeeName & "'s timesheet has been approved", "TimesheetApprovedSummaryTemplate", GetPreparedEMailMessageForApprovedTimeSheetSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate), DBUtilities.GetSessionEmailAddress, DBUtilities.GetSessionEmployeeName, , EMailUtilities.TIMESHEET_APPROVED_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    ''' <summary>
    ''' Get prepared email message for approved time sheet summary of specified EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="Comments"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForApprovedTimeSheetSummary(ByVal EmployeeName As String, ByVal TotalMinutes As Integer, ByVal Comments As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As StringDictionary
        Dim dict As New StringDictionary

        dict.Add("[employeename]", EmployeeName)
        dict.Add("[timeentrystartdate]", LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(TimeEntryStartDate))
        dict.Add("[timeentryenddate]", LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(TimeEntryEndDate))
        dict.Add("[status]", "Approved")

        Dim TTime As String = DBUtilities.GetDateTimeOfMinutesAsString(TotalMinutes)
        dict.Add("[totaltime]", TTime)

        dict.Add("[comments]", Comments)
        dict.Add("[approvedby]", DBUtilities.GetSessionEmployeeName())

        Return dict

    End Function
    ''' <summary>
    ''' Send time sheet rejected email summary of specified EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddres, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="Comments"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetRejectedEMailSummary(ByVal EmployeeName As String, ByVal TotalMinutes As Double, ByVal Comments As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal EmailAddress As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        SendRejectedTimesheetSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        EMailUtilities.DequeueEmail()
    End Sub
    ''' <summary>
    ''' Send rejected time sheet summary of specified EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate,
    ''' EmailAddress,  AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="Comments"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SendRejectedTimesheetSummary(ByVal EmployeeName As String, ByVal TotalMinutes As Double, ByVal Comments As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal EmailAddress As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        If GetRejectedAccountEmployeeTimeEntryPeriodForEmailByPeriodId(AccountEmployeeTimeEntryPeriodId).Rows.Count > 0 Then
            EMailUtilities.SendEMail("Your timesheet has been rejected", "TimesheetRejectedSummaryTemplate", GetPreparedEMailMessageForRejectedTimeSheetSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate), EmailAddress, EmployeeName, , EMailUtilities.TIMESHEET_REJECTED_NOTIFICATION_INFORMATION_FROM)
        End If
        If GetRejectedAccountEmployeeTimeEntryPeriodForEmailByPeriodIdToApprover(AccountEmployeeTimeEntryPeriodId).Rows.Count > 0 Then
            EMailUtilities.SendEMail(EmployeeName & "'s timesheet has been rejected", "TimesheetRejectedSummaryTemplate", GetPreparedEMailMessageForRejectedTimeSheetSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate), DBUtilities.GetSessionEmailAddress, DBUtilities.GetSessionEmployeeName, , EMailUtilities.TIMESHEET_REJECTED_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    ''' <summary>
    ''' Get prepared email message for rejected time sheet summary of specified EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="Comments"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForRejectedTimeSheetSummary(ByVal EmployeeName As String, ByVal TotalMinutes As Integer, ByVal Comments As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As StringDictionary
        Dim dict As New StringDictionary

        dict.Add("[employeename]", EmployeeName)
        dict.Add("[timeentrystartdate]", LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(TimeEntryStartDate))
        dict.Add("[timeentryenddate]", LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(TimeEntryEndDate))
        dict.Add("[status]", "Rejected")

        Dim TTime As String = DBUtilities.GetDateTimeOfMinutesAsString(TotalMinutes)
        dict.Add("[totaltime]", TTime)

        dict.Add("[comments]", Comments)
        dict.Add("[rejectedby]", DBUtilities.GetSessionEmployeeName())

        Return dict

    End Function
    ''' <summary>
    ''' Get prepared email message for rejected time sheet
    ''' </summary>
    ''' <param name="drvueAccountEmployeeTimeEntryRejectedEmail"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForRejectedTimeSheet(ByVal drvueAccountEmployeeTimeEntryRejectedEmail As TimeLiveDataSet.vueAccountEmployeeTimeEntryRejectedEmailRow) As StringDictionary
        Dim drAccountEmployee As AccountEmployee.AccountEmployeeRow
        Dim objAccountEmployee As New AccountEmployeeBLL
        drAccountEmployee = objAccountEmployee.GetAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId).Rows(0)

        Dim dict As New StringDictionary

        dict.Add("[employeename]", drvueAccountEmployeeTimeEntryRejectedEmail.EmployeeName)
        dict.Add("[timeentrydate]", drvueAccountEmployeeTimeEntryRejectedEmail.TimeEntryDate)
        dict.Add("[projectname]", drvueAccountEmployeeTimeEntryRejectedEmail.ProjectName)
        dict.Add("[taskname]", drvueAccountEmployeeTimeEntryRejectedEmail.TaskName)
        dict.Add("[status]", "Rejected")

        Dim TTime As String
        TTime = Format(drvueAccountEmployeeTimeEntryRejectedEmail.TotalTime, "HH:mm")
        dict.Add("[totaltime]", TTime)

        dict.Add("[comments]", drvueAccountEmployeeTimeEntryRejectedEmail.Comments)
        dict.Add("[rejectedby]", drAccountEmployee.FirstName + " " + drAccountEmployee.LastName)

        Return dict

    End Function
    ''' <summary>
    ''' Send rejected time sheet of specified AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub SendRejectedTimesheet(ByVal AccountEmployeeTimeEntryId As Integer)

        Dim objvueAccountEmployeeTimeEntryRejectedEmail As New AccountEmployeeTimeEntryBLL
        Dim dtvueAccountEmployeeTimeEntryRejectedEmail As TimeLiveDataSet.vueAccountEmployeeTimeEntryRejectedEmailDataTable = objvueAccountEmployeeTimeEntryRejectedEmail.GetRejectedAccountEmployeeTimeEntryForEmail(AccountEmployeeTimeEntryId)
        Dim drvueAccountEmployeeTimeEntryRejectedEmail As TimeLiveDataSet.vueAccountEmployeeTimeEntryRejectedEmailRow

        If dtvueAccountEmployeeTimeEntryRejectedEmail.Rows.Count > 0 Then
            drvueAccountEmployeeTimeEntryRejectedEmail = dtvueAccountEmployeeTimeEntryRejectedEmail.Rows(0)

            'For Each drvueAccountEmployeeTimeEntryRejectedEmail In dtvueAccountEmployeeTimeEntryRejectedEmail.Rows
            EMailUtilities.SendEMail("Your timesheet has been rejected", "TimesheetRejectedTemplate", GetPreparedEMailMessageForRejectedTimeSheet(drvueAccountEmployeeTimeEntryRejectedEmail), drvueAccountEmployeeTimeEntryRejectedEmail.EMailAddress, drvueAccountEmployeeTimeEntryRejectedEmail.EmployeeName, , EMailUtilities.TIMESHEET_REJECTED_NOTIFICATION_INFORMATION_FROM)
            'Next
        End If
    End Sub
    ''' <summary>
    ''' Send time sheet rejected email of specified AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetRejectedEMail(ByVal AccountEmployeeTimeEntryId As Integer)

        SendRejectedTimesheet(AccountEmployeeTimeEntryId)
        EMailUtilities.DequeueEmail()
    End Sub
    'Public Function GetPreparedEMailMessageForPendingTimeSheet(ByVal drvueAccountEmployeeTimeEntryApprovalPending As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingRow) As StringDictionary
    ''' <summary>
    ''' Get prepared email message for pending time sheet of specified strBody, strHeader
    ''' </summary>
    ''' <param name="strBody"></param>
    ''' <param name="strHeader"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForPendingTimeSheet(ByVal strBody As String, ByVal strHeader As String) As StringDictionary

        Dim dict As New StringDictionary

        dict.Add("[strBody]", strBody)
        dict.Add("[strHeader]", strHeader)
        Dim URL As String = "<a href=""" & System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "ProjectAdmin/TimeSheetApproval.aspx""" & ">" & System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "ProjectAdmin/TimeSheetApproval.aspx" & "</a>"
        dict.Add("[url]", URL)
        'dict.Add("[timeentrydate]", drvueAccountEmployeeTimeEntryApprovalPending.TimeEntryDate)
        'dict.Add("[projectname]", drvueAccountEmployeeTimeEntryApprovalPending.ProjectName)
        'dict.Add("[taskname]", drvueAccountEmployeeTimeEntryApprovalPending.TaskName)

        'Dim TTime As String
        'TTime = Format(drvueAccountEmployeeTimeEntryApprovalPending.TotalTime, "HH:mm")
        'dict.Add("[totaltime]", TTime)

        Return dict

    End Function
    ''' <summary>
    ''' Send pending time sheet of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingTimesheet(ByVal AccountEmployeeId As Integer, AccountId As Integer)

        Dim BLL As New AccountEmployeeTimeEntryBLL

        Dim dtPendingApprovals As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceDataTable = BLL.GetPendingTimeEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail(AccountEmployeeId, AccountId)
        If dtPendingApprovals.Rows.Count > 0 Then
            Dim drPendingApprovals As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceRow = dtPendingApprovals.Rows(0)

            Dim strHeader As String = ""
            Dim strBody As String = ""
            Dim CultureName As String
            If IsDBNull(drPendingApprovals.Item("CultureInfoName")) Or drPendingApprovals.Item("CultureInfoName").ToString = "auto" Then
                CultureName = "en-us"
            Else
                CultureName = drPendingApprovals.Item("CultureInfoName")
            End If
            strHeader = strHeader & IIf(strHeader = "", "", "") & "<td align=" & "center" & ">" & ("Employee Name" & "</td>" & "<td align=" & "center" & ">" & "Timesheet Period" & "</td>" & "<td align=" & "center" & ">" & "Total Billable Hours" & "</td>" & "<td align=" & "center" & ">" & "Non Billable Hours" & "</td>" & "<td align=" & "center" & ">" & "Total Hours" & "</td>" & "<td align=" & "center" & ">" & "Submitted Date" & "</td>")

            For Each drPendingApprovals In dtPendingApprovals.Rows
                Dim StartDate As Date = drPendingApprovals.TimeEntryStartDate
                Dim EndDate As Date = drPendingApprovals.TimeEntryEndDate
                Dim SubmittedDate As Date = Me.GetSubmittedDateForTimesheetEmail(drPendingApprovals.AccountEmployeeTimeEntryPeriodId, StartDate)

                strBody = strBody & IIf(strBody = "", "", "<br/>") & "<tr>" & "<td>" & (drPendingApprovals.EmployeeName & "</td>" & "<td>" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(StartDate, CultureName) & " - " & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(EndDate, CultureName) & "</td>" & "<td align=" & "center" & ">" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(drPendingApprovals.BillableTotalMinutes) & "</td>" & "<td align=" & "center" & ">" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(drPendingApprovals.NonBillableTotalMinutes) & "</td>" & "<td align=" & "center" & " ; " & "valign=" & "middle" & ">" & "<b>" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(drPendingApprovals.TotalMinutes) & "</b>" & "</td>" & "<td align=" & "center" & ">" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(SubmittedDate, CultureName) & "</td>" & "</tr>")

            Next
            EMailUtilities.SendEMail("Timesheet approvals are due", "TimesheetPendingTemplate", GetPreparedEMailMessageForPendingTimeSheet(strBody, strHeader), drPendingApprovals.ApproverEMailAddress, , , EMailUtilities.TIMESHEET_APPROVAL_PENDING_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    ''' <summary>
    ''' Send time sheet pending email of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetPendingEMail(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer)

        SendPendingTimesheet(AccountEmployeeId, AccountId)

    End Sub
    ''' <summary>
    ''' Get submitted date for time sheet email of specified AccountEmployeeTimeEntryPeriodId, StartDate
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="StartDate"></param>
    ''' <returns>StartDate</returns>
    ''' <remarks></remarks>
    Public Function GetSubmittedDateForTimesheetEmail(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal StartDate As Date) As Date
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow

        If dtWeekView.Rows.Count > 0 Then
            drWeekView = dtWeekView.Rows(0)
            If Not IsDBNull(drWeekView.Item("SubmittedDate")) Then
                Return drWeekView.SubmittedDate
            End If
        End If
        Return StartDate
    End Function
    ''' <summary>
    ''' Get prepared email message for pending time entry strWorkingDay, strTotalMinutes, EmployeeName, TimeEntryStartDate
    ''' TimeEntryEndDate, strTotal
    ''' </summary>
    ''' <param name="strWorkingDay"></param>
    ''' <param name="strTotalMinutes"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="strTotal"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForPendingTimeEntry(ByVal strWorkingDay As String, ByVal strTotalMinutes As String, ByVal EmployeeName As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal strTotal As String) As StringDictionary

        Dim dict As New StringDictionary

        dict.Add("[employeename]", EmployeeName)
        dict.Add("[strworkingday]", strWorkingDay)
        dict.Add("[strtotalminutes]", strTotalMinutes)
        dict.Add("[timeentrystartdate]", TimeEntryStartDate.ToLongDateString)
        dict.Add("[timeentryenddate]", TimeEntryEndDate.ToLongDateString)
        dict.Add("[strtotal]", strTotal)

        Return dict

    End Function
    ''' <summary>
    ''' Send pending time entry of specified AccountId, AccountEmployeeId, EmployeeName, EmailAddress
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="EmailAddress"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingTimeEntry(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal EmailAddress As String, _
                                    ByVal CultureName As String, ByVal UserCurrentDateTime As DateTime, Optional ByVal SystemTimesheetPeriodTypeEmail As String = "", _
                                    Optional ByVal EmployeeWeekStartDayEmail As Integer = 0, Optional ByVal SystemInitialDayOfFirstPeriodEmail As Integer = 0, _
                                    Optional ByVal SystemInitialDayOfLastPeriodEmail As Integer = 0, Optional ByVal InitialDayOfTheMonthEmail As Integer = 0)

        Dim WorkingDaysArray As ArrayList = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, UserCurrentDateTime.Date, UserCurrentDateTime.Date, UserCurrentDateTime.Date, True, SystemTimesheetPeriodTypeEmail, EmployeeWeekStartDayEmail, SystemInitialDayOfFirstPeriodEmail, SystemInitialDayOfLastPeriodEmail, InitialDayOfTheMonthEmail)
        If WorkingDaysArray.Count > 0 Then
            Dim dtTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = Me.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(AccountEmployeeId, WorkingDaysArray(0), WorkingDaysArray(WorkingDaysArray.Count - 1))
            Dim strWorkingDay As String = ""
            Dim strTotalMinutes As String = ""
            Dim SumTotalMinutes As Integer
            Dim strTotal As String = ""
            Dim TotalMinutes As String = 0
            LoggingBLL.WriteToLog("SendPendingTimeEntry:WorkingDaysArrayStartDate = " & WorkingDaysArray(0) & " WorkingDaysArrayEndDate = " & WorkingDaysArray(WorkingDaysArray.Count - 1) & "AccountEmployeeId=" & AccountEmployeeId)
            For n As Integer = 0 To WorkingDaysArray.Count - 1
                Dim dr() As DataRow = dtTimeEntry.Select("TimeEntryDate = '" & WorkingDaysArray(n) & "'")
                If dr.Length > 0 Then
                    TotalMinutes = dr(0).Item("TotalMinutes")
                End If
                Dim TotalHours As String = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(TotalMinutes)
                strWorkingDay = strWorkingDay & IIf(strWorkingDay = "", "", "") & "<td width = 200px align=" & "center" & ">" & (LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDaysArray(n)) & " " & LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocaleForEmail(WorkingDaysArray(n), CultureName)) & "</td>"
                If WorkingDaysArray(n) <= Now.Date Then
                    strTotalMinutes = strTotalMinutes & IIf(strTotalMinutes = "", "", "") & "<td width = 200px align=" & "center" & ">" & IIf(TotalHours = "00:00", "<font style=" & "'" & "COLOR: red" & "'" & ">" & TotalHours & "</font>", "<font style=" & "'" & "COLOR: #003366" & "'" & ">" & TotalHours & "</font>") & "</td>"
                    SumTotalMinutes += TotalMinutes
                Else
                    strTotalMinutes = strTotalMinutes & IIf(strTotalMinutes = "", "", "") & "<td width = 200px align=" & "center" & ">-</td>"
                End If
                TotalMinutes = 0
            Next
            Dim TotalMinutesSum As String = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(SumTotalMinutes)
            strTotal = strTotal & IIf(strTotal = "", "", "") & IIf(TotalMinutesSum = "00:00", "<font style=" & "'" & "COLOR: red" & "'" & ">" & TotalMinutesSum & "</font>", TotalMinutesSum)
            EMailUtilities.SendEMail("TimeEntry Notification", "TimeEntryPendingTemplate", GetPreparedEMailMessageForPendingTimeEntry(strWorkingDay, strTotalMinutes, EmployeeName, WorkingDaysArray(0), WorkingDaysArray(WorkingDaysArray.Count - 1), strTotal), EmailAddress, , , EMailUtilities.PENDING_TIMEENTRY_NOTIFICATION_INFORMATION_FORM)
        End If
    End Sub
    ''' <summary>
    ''' Get culture name for email
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns>en-us(English-US)</returns>
    ''' <remarks></remarks>
    Public Function GetCultureNameForEmail(ByVal dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable) As String
        Dim drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailRow
        If dt.Rows.Count > 0 Then
            drTimeEntry = dt.Rows(0)
            If drTimeEntry.CultureInfoName <> "auto" Then
                Return drTimeEntry.CultureInfoName
            End If
        End If
        Return "en-us"
    End Function
    ''' <summary>
    ''' Get total minutes by time entry date and employeeId of specified TimeEntryDate
    ''' </summary>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTotalMinutesByTimeEntryDateAndAccountEmployeeId(ByVal TimeEntryDate As Date, ByVal dt As DataTable) As String
        Dim dr() As DataRow = dt.Select("TimeEntryDate = '" & TimeEntryDate & "'")
        If dr.Length > 0 Then
            Return dr(0).Item("TotalMinutes")
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Get GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeId of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForEmail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable
        Dim _vueAccountEmployeeTimeEntryTableAdapter As New AccountEmployeeTimeEntryTableAdapters.vueAccountEmployeeTimeEntryForEmailTableAdapter
        Return _vueAccountEmployeeTimeEntryTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate of specified AccountEmployeeId, TimeEntryStartDate and TimeEntryEndDate.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable
        Dim _vueAccountEmployeeTimeEntryTableAdapter As New AccountEmployeeTimeEntryTableAdapters.vueAccountEmployeeTimeEntryForEmailTableAdapter
        Return _vueAccountEmployeeTimeEntryTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Send time entry pending email of specified AccountId, AccountEmployeeId, EmployeeName, EmailAddress
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="EmailAddress"></param>
    ''' <remarks></remarks>
    Public Sub SendTimeEntryPendingEMail(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal EmailAddress As String, ByVal CultureName As String, ByVal UserCurrentDateTime As DateTime, Optional ByVal SystemTimesheetPeriodTypeEmail As String = "", _
    Optional ByVal EmployeeWeekStartDayEmail As Integer = 0, Optional ByVal SystemInitialDayOfFirstPeriodEmail As Integer = 0, Optional ByVal SystemInitialDayOfLastPeriodEmail As Integer = 0, Optional ByVal InitialDayOfTheMonthEmail As Integer = 0)

        SendPendingTimeEntry(AccountId, AccountEmployeeId, EmployeeName, EmailAddress, CultureName, UserCurrentDateTime, SystemTimesheetPeriodTypeEmail, EmployeeWeekStartDayEmail, SystemInitialDayOfFirstPeriodEmail, SystemInitialDayOfLastPeriodEmail, InitialDayOfTheMonthEmail)

    End Sub
    ''' <summary>
    ''' Get pending time entry with preference
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreference</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryWithPreference() As TimeLiveDataSet.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceDataTable
        Dim _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceTableAdapter As New vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceTableAdapter
        Return _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Get pending time entry with preference group by accountemployeeid
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceGroupByAccountEmployeeId</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryWithPreferenceGroupByAccountEmployeeId() As TimeLiveDataSet.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceGroupByAccountEmployeeIdDataTable
        Dim _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceGroupByAccountEmployeeIdTableAdapter As New vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceGroupByAccountEmployeeIdTableAdapter
        Return _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceGroupByAccountEmployeeIdTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Get default schedule emailsendtime
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDefaultScheduleEmailSendTime(ByVal dr As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdRow) As DateTime
        If Not IsDBNull(dr.Item("ScheduledEmailSendTime")) Then
            Return dr.ScheduledEmailSendTime
        Else
            Return "11:00:00 PM"
        End If
    End Function
    ''' <summary>
    ''' Get default schedule email send time for pending time entry
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDefaultScheduleEmailSendTimeForPendingTimeEntry(ByVal dr As TimeLiveDataSet.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceRow) As DateTime
        If Not IsDBNull(dr.Item("ScheduledEmailSendTime")) Then
            Return dr.ScheduledEmailSendTime
        Else
            Return "11:00:00 PM"
        End If
    End Function
    ''' <summary>
    ''' Get default schedule email send time for pending time entry by datarow
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDefaultScheduleEmailSendTimeForPendingTimeEntryByDataRow(ByVal dr As DataRow) As DateTime
        If Not IsDBNull(dr.Item("ScheduledEmailSendTime")) Then
            Return dr.Item("ScheduledEmailSendTime")
        Else
            Return "11:00:00 PM"
        End If
    End Function
    ''' <summary>
    ''' Check new and old values
    ''' </summary>
    ''' <param name="drAccountEmployeeTimeEntry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckNewAndOldValues(Optional ByVal drAccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = Nothing) As Boolean

        Dim DataRow As DataRow

        'If Not drAccountEmployeeTimeEntry Is Nothing Then
        DataRow = drAccountEmployeeTimeEntry
        'End If

        Dim OlddrAccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        OlddrAccountEmployeeTimeEntry = System.Web.HttpContext.Current.Session("OldAccountEmployeeTimeEntry")


        If DataRow("AccountProjectId") <> OlddrAccountEmployeeTimeEntry.AccountProjectId Then
            Return True
        End If

        If DataRow("AccountProjectTaskId") <> OlddrAccountEmployeeTimeEntry.AccountProjectTaskId Then
            Return True
        End If

        If Not IsDBNull(DataRow.Item("StartTime")) Then
            If IsDBNull(OlddrAccountEmployeeTimeEntry.Item("StartTime")) OrElse DataRow("StartTime") <> OlddrAccountEmployeeTimeEntry("StartTime") Then
                Return True
            End If
        End If

        If Not IsDBNull(DataRow.Item("EndTime")) Then
            If IsDBNull(OlddrAccountEmployeeTimeEntry.Item("EndTime")) OrElse DataRow("EndTime") <> OlddrAccountEmployeeTimeEntry.EndTime Then
                Return True
            End If
        End If

        If Not IsDBNull(DataRow.Item("TotalTime")) Then
            If IsDBNull(OlddrAccountEmployeeTimeEntry.Item("TotalTime")) OrElse DataRow("TotalTime") <> OlddrAccountEmployeeTimeEntry.TotalTime Then
                Return True
            End If
        End If

        If Not IsDBNull(DataRow.Item("Description")) Then
            If IsDBNull(OlddrAccountEmployeeTimeEntry.Item("Description")) OrElse DataRow("Description") <> OlddrAccountEmployeeTimeEntry.Description Then
                Return True
            End If
        End If

        If Not IsDBNull(drAccountEmployeeTimeEntry.Item("Submitted")) Then
            If drAccountEmployeeTimeEntry.Submitted = True Then
                Return True
            End If
        End If
        Return False

    End Function
    ''' <summary>
    ''' Add old object in session of specified Original_AccountEmployeeTimeEntryId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <remarks></remarks>
    Public Sub AddOldObjectInSession(ByVal Original_AccountEmployeeTimeEntryId As Integer)

        'Dim drAccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        'Dim objAccountEmployeeTimeEntry As New AccountEmployeeTimeEntryBLL
        'drAccountEmployeeTimeEntry = objAccountEmployeeTimeEntry.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId).Rows(0)

        'System.Web.HttpContext.Current.Session.Add("OldAccountEmployeeTimeEntry", drAccountEmployeeTimeEntry)
    End Sub
    ''' <summary>
    ''' Update time entry archive of specified Original_AccountEmployeeTimeEntryId, Approved, BillingRate, Submitted,
    ''' Original_TimeEntryDate, Original_AccountEmployeeId, Original_TimeEntryStartDate, Original_TimeEntryEndDate,
    ''' Original_TimeEntryViewType, Original_AccountEmployeeTimeEntryApprovalProjectId, Original_AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="BillingRate"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Original_TimeEntryDate"></param>
    ''' <param name="Original_AccountEmployeeId"></param>
    ''' <param name="Original_TimeEntryStartDate"></param>
    ''' <param name="Original_TimeEntryEndDate"></param>
    ''' <param name="Original_TimeEntryViewType"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="Original_AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateTimeEntrArchive(ByVal Original_AccountEmployeeTimeEntryId As Integer,
            ByVal Approved As Boolean, ByVal BillingRate As Decimal, ByVal Submitted As Boolean, ByVal original_IsTimeOff As Boolean, ByVal Original_TimeEntryDate As DateTime,
            ByVal Original_AccountEmployeeId As Integer, ByVal Original_TimeEntryStartDate As Object, ByVal Original_TimeEntryEndDate As Object, ByVal Original_TimeEntryViewType As String, ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Object, ByVal Original_AccountEmployeeTimeEntryPeriodId As Object, Optional ByVal original_AccountEmployeeTimeOffRequestId As Object = "") As Boolean
        Dim Original_IsTimeOffRequest = False
        Dim TimeEntryBll As New AccountEmployeeTimeEntryBLL
        Dim AccountEmployeeTimeEntryApprovalProjectId As Guid
        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If
        Dim TimeEntryPeriodApproved As Boolean = Approved

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) Then
            If original_IsTimeOff <> True Then
                AccountEmployeeTimeEntries = Adapter.GetDataByAccountEmployeeTimeEntryPeriodIdWithoutTimeOff(Original_AccountEmployeeTimeEntryPeriodId)
            Else
                AccountEmployeeTimeEntries = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
            End If
        Else
            AccountEmployeeTimeEntries = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        End If
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow

        For Each AccountEmployeeTimeEntry In AccountEmployeeTimeEntries.Rows
            If original_IsTimeOff <> True Then
                If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) And AccountEmployeeTimeEntry.IsTimeOff <> True Then
                    AccountEmployeeTimeEntryApprovalProjectId = Me.SetAccountEmployeeTimeEntryApprovalProjectByTimeEntryArchive(Original_AccountEmployeeTimeEntryPeriodId, AccountEmployeeTimeEntry.AccountProjectId, Original_AccountEmployeeId, DBUtilities.GetSessionAccountEmployeeId, Submitted, Approved)
                End If
                AccountEmployeeTimeEntry.ModifiedOn = Now
                If AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = Original_AccountEmployeeTimeEntryId Then
                    AccountEmployeeTimeEntry.BillingRate = BillingRate
                End If
            End If
            If AccountEmployeeTimeEntry.Item("IsTimeOff").ToString = "True" Then
                If Submitted = False Then
                    Approved = False
                End If
                If Approved = True And AccountEmployeeTimeEntry.Approved = False Then
                    If Not IsDBNull(AccountEmployeeTimeEntry.Item("AccountEmployeeTimeOffRequestId")) Then
                        If Submitted = True Then
                            AccountEmployeeTimeEntry.Submitted = Submitted
                            Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(True, AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId)
                        End If
                        Call New AccountEmployeeTimeEntryBLL().UpdateEmployeeTimeOffHoursForTimeEntryArchiveForTimeOffRequest(Original_AccountEmployeeId, AccountEmployeeTimeEntry.AccountTimeOffTypeId, AccountEmployeeTimeEntry.Hours, True, Original_AccountEmployeeTimeEntryId, DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Entry Archive", AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId)
                        Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId)
                        Call New AccountEmployeeTimeOffRequestBLL().LockSpecificEmployeeTimeOffRequestSubmit(AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, True)
                        'Me.SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AccountEmployeeTimeEntry.Item("AccountEmployeeTimeOffRequestId"))
                    Else
                        Call New AccountEmployeeTimeEntryBLL().UpdateEmployeeTimeOffHoursForTimeEntryArchive(Original_AccountEmployeeId, AccountEmployeeTimeEntry.AccountTimeOffTypeId, AccountEmployeeTimeEntry.Hours, True, Original_AccountEmployeeTimeEntryId, DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Entry Archive")
                    End If
                ElseIf Approved = False And AccountEmployeeTimeEntry.Approved = True Then
                    If Not IsDBNull(AccountEmployeeTimeEntry.Item("AccountEmployeeTimeOffRequestId")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateEmployeeTimeOffHoursForTimeEntryArchiveForTimeOffRequest(Original_AccountEmployeeId, AccountEmployeeTimeEntry.AccountTimeOffTypeId, -AccountEmployeeTimeEntry.Hours, False, Original_AccountEmployeeTimeEntryId, DBUtilities.GetEmployeeNameWithCode, "UnApproved", "Time Entry Archive", AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId)
                        Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(False, AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId)
                        Call New AccountEmployeeTimeOffRequestBLL().LockSpecificEmployeeTimeOff(AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, False)
                        Call New AccountEmployeeTimeOffRequestBLL().DeleteTimeOffRequestApproval(AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId)
                    Else
                        Call New AccountEmployeeTimeEntryBLL().UpdateEmployeeTimeOffHoursForTimeEntryArchive(Original_AccountEmployeeId, AccountEmployeeTimeEntry.AccountTimeOffTypeId, -AccountEmployeeTimeEntry.Hours, False, Original_AccountEmployeeTimeEntryId, DBUtilities.GetEmployeeNameWithCode, "UnApproved", "Time Entry Archive")
                    End If
                End If
            End If

            If original_IsTimeOff <> True Then
                If AccountEmployeeTimeEntry.Item("IsTimeOff").ToString = "False" Or (Submitted = True And AccountEmployeeTimeEntry.Submitted = False) Then
                    AccountEmployeeTimeEntry.Submitted = Submitted
                End If
                'Call New AccountEmployeeTimeEntryBLL().UpdateAccountEmployeeTimeEntryPeriodStatusForTimeEntryArchive(DBUtilities.GetSessionAccountId, Original_AccountEmployeeId, Submitted, Approved, False, Original_AccountEmployeeTimeEntryPeriodId)
            End If

            If original_IsTimeOff = True Then
                Dim dttimeoff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
                Dim drtimeoff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)
                If dttimeoff.Rows.Count > 0 Then
                    If IsDBNull(drtimeoff.Item("AccountEmployeeTimeOffRequestId")) Then
                        AccountEmployeeTimeEntry.Submitted = Submitted
                        AccountEmployeeTimeEntry.Rejected = 0
                        'Call New AccountEmployeeTimeEntryBLL().UpdateAccountEmployeeTimeEntryPeriodStatusForTimeEntryArchive(DBUtilities.GetSessionAccountId, Original_AccountEmployeeId, Submitted, Approved, False, Original_AccountEmployeeTimeEntryPeriodId)

                    End If

                End If
            End If

            If original_IsTimeOff <> True Then
                If Submitted <> True Then
                    Approved = False
                    AccountEmployeeTimeEntry.Approved = Approved
                Else
                    AccountEmployeeTimeEntry.Approved = Approved
                End If
            Else
                If Submitted <> True Then
                    Approved = False
                    AccountEmployeeTimeEntry.Approved = Approved
                Else
                    AccountEmployeeTimeEntry.Approved = Approved
                End If
            End If

            If Approved = False Then
                TimeEntryPeriodApproved = False
                If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) Then
                    AccountEmployeeTimeEntryApprovalAdapter.DeleteApprovalByPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
                End If
            End If

            If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) And AccountEmployeeTimeEntry.IsTimeOff <> True And original_IsTimeOff <> True Then
                AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = Original_AccountEmployeeTimeEntryPeriodId
                AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId = AccountEmployeeTimeEntryApprovalProjectId
            ElseIf Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) Then
                AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = Original_AccountEmployeeTimeEntryPeriodId
            End If

            If Not IsDBNull(AccountEmployeeTimeEntry.Item("AccountEmployeeTimeOffRequestId")) Then
                Me.SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, AccountEmployeeTimeEntry.Item("AccountEmployeeTimeOffRequestId"))
                Original_IsTimeOffRequest = True
            End If
            Adapter.Update(AccountEmployeeTimeEntry)
        Next
        If original_IsTimeOff <> True Then
            If Not IsDBNull(Original_AccountEmployeeTimeEntryPeriodId) Then
                If TimeEntryPeriodApproved <> True And Submitted <> True Then
                    SetAccountEmployeeTimeEntryApprovalProjectIdToNULLInTimeEntry(Original_AccountEmployeeTimeEntryPeriodId)
                    DeleteAccountEmployeeTimeEntryApprovalProjectByPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
                End If
            End If
        End If

        If Original_IsTimeOffRequest = False Then
            SetTimeSheetStatusOnTimeEntryArchive(Original_AccountEmployeeTimeEntryPeriodId, Original_AccountEmployeeId)
        End If



        Me.UpdateAccountEmployeeTimeEntries(DBUtilities.GetSessionAccountId, Original_AccountEmployeeId)
        Me.AfterUpdate(Original_TimeEntryDate)
        Return 1
    End Function

    Public Sub SetTimeSheetStatusOnTimeEntryArchive(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountEmployeeId As Integer)
        Dim AccountTimeEntryPeriod = Me.GetvueAccountEmployeeTimeEntryPeriodByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        If AccountTimeEntryPeriod.Rows.Count > 0 Then
            Me.SetAccountEmployeeTimeEntryPeriodApprovalStatus(DBUtilities.GetSessionAccountId, AccountEmployeeId, AccountTimeEntryPeriod.Item(0).TimeEntryStartDate, AccountTimeEntryPeriod.Item(0).TimeEntryEndDate, "", AccountEmployeeTimeEntryPeriodId)

        End If


    End Sub

    ''' <summary>
    ''' Get data all of specified AccountID, AccountEmployees, AccountDepartmentID, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountID"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountDepartmentID"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="objDropdown"></param>
    ''' <returns>vueAccountEmployeeTimesheetSubmissionStatus</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataAll(ByVal AccountID As Integer, ByVal AccountEmployees As String, ByVal AccountDepartmentID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal objDropdown As DropDownList) As TimeLiveDataSet.vueAccountEmployeeTimesheetSubmissionStatusDataTable
        Dim _vueAccountEmployeeTimesheetSubmissionStatusTableAdapter As New vueAccountEmployeeTimesheetSubmissionStatusTableAdapter
        Return _vueAccountEmployeeTimesheetSubmissionStatusTableAdapter.GetDataAll(AccountID, AccountEmployees, AccountDepartmentID, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, objDropdown)

    End Function
    ''' <summary>
    ''' Lock time entry if submitted
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="ControlName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LockTimeEntryIfSubmitted(ByVal row As GridViewRow, Optional ByVal ControlName As String = "") As Boolean
        Dim Submitted As Boolean
        Submitted = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Submitted")), False, DataBinder.Eval(row.DataItem, "Submitted"))
        If Submitted = True Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Lock or unlock time entry recrods of Specified grid view row and control name optional.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="ControlName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoUnlock(ByVal row As GridViewRow, Optional ByVal ControlName As String = "") As Boolean
        Dim Submitted As Boolean
        Dim IsApproved As Boolean
        Dim Approved As Boolean
        Dim LockSubmittedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
        Dim LockApprovedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockApprovedRecords
        Submitted = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Submitted")), False, DataBinder.Eval(row.DataItem, "Submitted"))
        IsApproved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "IsApproved")), False, DataBinder.Eval(row.DataItem, "IsApproved"))
        Approved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Approved")), False, DataBinder.Eval(row.DataItem, "Approved"))
        If DataBinder.Eval(row.DataItem, "IsTimeOff").ToString = "True" Then
            IsApproved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Approved")), False, DataBinder.Eval(row.DataItem, "Approved"))
        End If
        If (LockSubmittedRecords = True And Submitted = False) Or (ControlName = "btnDelete" And AccountPagePermissionBLL.IsPageHasPermissionOf(18, 4) = False) Then
            Return True
        End If
        If (LockSubmittedRecords = True And Submitted = True) Or (LockApprovedRecords = True And IsApproved = True) Or (LockApprovedRecords = True And Approved = True) Or (ControlName = "btnDelete" And AccountPagePermissionBLL.IsPageHasPermissionOf(18, 4) = False) Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Do unlock by day no
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="dayNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoUnlockBydayNo(ByVal row As GridViewRow, ByVal dayNo As Integer) As Boolean
        Dim Submitted As Boolean
        Dim IsApproved As Boolean
        Dim Approved As Boolean
        Dim LockSubmittedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
        Dim LockApprovedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockApprovedRecords
        Submitted = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Submitted" & dayNo)), False, DataBinder.Eval(row.DataItem, "Submitted" & dayNo))
        IsApproved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "IsApproved" & dayNo)), False, DataBinder.Eval(row.DataItem, "IsApproved" & dayNo))
        Approved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Approved" & dayNo)), False, DataBinder.Eval(row.DataItem, "Approved" & dayNo))
        If DataBinder.Eval(row.DataItem, "IsTimeOff").ToString = "True" Then
            IsApproved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Approved" & dayNo)), False, DataBinder.Eval(row.DataItem, "Approved" & dayNo))
        End If
        If (LockSubmittedRecords = True And Submitted = False) Then
            Return True
        End If
        If (LockSubmittedRecords = True And Submitted = True) Or (LockApprovedRecords = True And IsApproved = True) Or (LockApprovedRecords = True And Approved = True) Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Lock time entry if submitted by day no
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="dayNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LockTimeEntryIfSubmittedBydayNo(ByVal row As GridViewRow, ByVal dayNo As Integer) As Boolean
        Dim Submitted As Boolean
        Submitted = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Submitted" & dayNo)), False, DataBinder.Eval(row.DataItem, "Submitted" & dayNo))
        If Submitted = True Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Update work type of specified AccountWorkTypeId, AccountId
    ''' </summary>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <param name="AccountId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateAccountWorkType(ByVal AccountWorkTypeId As Integer, ByVal AccountId As Integer)
        Adapter.UpdateAccountWorkType(AccountWorkTypeId, AccountId)
    End Sub
    ''' <summary>
    ''' Get approval entries for team lead summarize of specified AccountEmployeeId, TimeEntryAccountEmployeeId 
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary> 
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummary</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForTeamLeadSummarize(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter.GetApprovalEntriesForTeamLeadSummarized(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for team lead summarize For Mobile of specified ApproverEmployeeId
    ''' </summary> 
    ''' <param name="ApproverEmployeeId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummary</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForMobile(ByVal ApproverEmployeeId As Integer) As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingForApprovalDataTable
        Dim _vueTimesheetSummaryPendingForApprovalTableAdapter As New vueTimesheetSummaryPendingForApprovalTableAdapter
        Return _vueTimesheetSummaryPendingForApprovalTableAdapter.GetDataByApprovalEntries(ApproverEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for team lead for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetPendingForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForTeamLeadForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
        Dim _vueTimesheetPendingForApprovalTableAdapter As New vueTimesheetPendingForApprovalTableAdapter
        Return _vueTimesheetPendingForApprovalTableAdapter.GetApprovalEntriesForTeamLead(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get time sheet entries for team lead for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetEntriesForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetEntriesForTeamLeadForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
        Dim _vueTimesheetEntriesForApprovalTableAdapter As New vueTimesheetEntriesForApprovalTableAdapter
        Return _vueTimesheetEntriesForApprovalTableAdapter.GetApprovalEntriesForTeamLead(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for project manager summarize of specified AccountEmployeeId, TimeEntryAccountEmployeeId, TimeEntryStartDate,
    ''' TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummary</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForProjectManagerSummarize(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter.GetApprovalEntriesForProjectManagerSummarized(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for project manager for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetPendingForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForProjectManagerForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
        Dim _vueTimesheetPendingForApprovalTableAdapter As New vueTimesheetPendingForApprovalTableAdapter
        Return _vueTimesheetPendingForApprovalTableAdapter.GetApprovalEntriesForProjectManager(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get time sheet entries for project manager for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId, TimeEntryStartDate
    ''' TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetEntriesForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetEntriesForProjectManagerForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
        Dim _vueTimesheetEntriesForApprovalTableAdapter As New vueTimesheetEntriesForApprovalTableAdapter
        Return _vueTimesheetEntriesForApprovalTableAdapter.GetApprovalEntriesForProjectManager(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific employee summarize of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummary</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificEmployeeSummarize(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter.GetApprovalEntriesForSpecificEmployeeSummarized(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific employee for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetPendingForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificEmployeeForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
        Dim _vueTimesheetPendingForApprovalTableAdapter As New vueTimesheetPendingForApprovalTableAdapter
        Return _vueTimesheetPendingForApprovalTableAdapter.GetApprovalEntriesForSpecificEmployee(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get time sheet entries for specific employee for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetEntriesForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetEntriesForSpecificEmployeeForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
        Dim _vueTimesheetEntriesForApprovalTableAdapter As New vueTimesheetEntriesForApprovalTableAdapter
        Return _vueTimesheetEntriesForApprovalTableAdapter.GetApprovalEntriesForSpecificEmployee(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific external user summarize of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryStartDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummary</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificExternalUserSummarize(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter.GetApprovalEntriesForSpecificExternalUserSummarized(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific external user for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetPendingForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificExternalUserForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
        Dim _vueTimesheetPendingForApprovalTableAdapter As New vueTimesheetPendingForApprovalTableAdapter
        Return _vueTimesheetPendingForApprovalTableAdapter.GetApprovalEntriesForSpecificExternalUser(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get time sheet entries for specific external user for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetEntriesForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetEntriesForSpecificExternalUserForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
        Dim _vueTimesheetEntriesForApprovalTableAdapter As New vueTimesheetEntriesForApprovalTableAdapter
        Return _vueTimesheetEntriesForApprovalTableAdapter.GetApprovalEntriesForSpecificExternalUser(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for employee manager summarize of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummary</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForEmployeeManagerSummarize(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter.GetApprovalEntriesForEmployeeManagerSummarized(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for employee manager for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetPendingForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForEmployeeManagerForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
        Dim _vueTimesheetPendingForApprovalTableAdapter As New vueTimesheetPendingForApprovalTableAdapter
        Return _vueTimesheetPendingForApprovalTableAdapter.GetApprovalEntriesForEmployeeManager(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get time sheet entries for employee manager for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId
    ''' TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueTimesheetEntriesForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetEntriesForEmployeeManagerForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
        Dim _vueTimesheetEntriesForApprovalTableAdapter As New vueTimesheetEntriesForApprovalTableAdapter
        Return _vueTimesheetEntriesForApprovalTableAdapter.GetApprovalEntriesForEmployeeManager(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Update approved in team lead approval project of specified Approved, Rejected, ModifiedOn, AccountEmployeeId
    ''' AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateApprovedInTeamLeadApprovalProject(ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInTeamLeadApprovalProject(Approved, Rejected, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update approved in project manager approval project of specified Approved, Rejected, ModifiedOn, AccountEmployeeId
    ''' AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateApprovedInProjectManagerApprovalProject(ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInProjectManagerApprovalProject(Approved, Rejected, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update approved in specific employee approval project of specified Approved, Rejected, ModifiedOn, AccountEmployeeId
    ''' AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateApprovedInSpecificEmployeeApprovalProject(ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInSpecificEmployeeApprovalProject(Approved, Rejected, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update approved in specific external user approval project of specified Approved, Rejected, ModifiedOn, AccountEmployeeId
    ''' AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateApprovedInSpecificExternalUserApprovalProject(ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInSpecificExternalUserApprovalProject(Approved, Rejected, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update approved in employee manager approval project of specified Approved, Rejected, ModifiedOn, AccountEmployeeId
    ''' AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateApprovedInEmployeeManagerApprovalProject(ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInEmployeeManagerApprovalProject(Approved, Rejected, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Bulk time sheet approval entries for approved of specified AccountEmployeeId, TimeEntryAccountEmployeeId, TimeEntryStartDate,
    ''' TimeEntryEndDate, Comments, chkTeamLead, chkProjectManager, chkSpecificEmployee, chkSpecificExternalUser, chkEmployeeManager,
    ''' TimeEntryDate, AccountEmployeeTimeEntryPeriodId, EmployeeName, TotalMinutes, EmailAddress, TimeEntryViewType
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Comments"></param>
    ''' <param name="chkTeamLead"></param>
    ''' <param name="chkProjectManager"></param>
    ''' <param name="chkSpecificEmployee"></param>
    ''' <param name="chkSpecificExternalUser"></param>
    ''' <param name="chkEmployeeManager"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BulkTimeSheetApprovalEntriesForApproved(ByVal AccountEmployeeId As Integer, _
    ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, _
    ByVal Comments As String, ByVal chkTeamLead As Boolean, ByVal chkProjectManager As Boolean, _
    ByVal chkSpecificEmployee As Boolean, ByVal chkSpecificExternalUser As Boolean, ByVal chkEmployeeManager As Boolean, ByVal TimeEntryDate As Date, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal EmployeeName As String, ByVal TotalMinutes As Double, ByVal EmailAddress As String, ByVal TimeEntryViewType As String)
        'For Team Lead
        If chkTeamLead = True Then
            Dim TLBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForTeamLeadApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInTeamLeadApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateApprovedInTeamLeadApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInTeamLeadApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForTeamLead(Date.Now, Comments, False, True, False, TLBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            Me.SendTimesheetApprovedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)

        End If
        'For Project Manager
        If chkProjectManager = True Then
            Dim PMBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForProjectManagerApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInProjectManagerApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            UpdateApprovedInProjectManagerApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInProjectManagerApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForProjectManager(Date.Now, Comments, False, True, False, PMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            Me.SendTimesheetApprovedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        'For Specific Employee
        If chkSpecificEmployee = True Then
            Dim SEBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForSpecificEmployeeApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificEmployeeApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInSpecificEmployeeApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInSpecificEmployeeApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificEmployee(Date.Now, Comments, False, True, False, SEBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            Me.SendTimesheetApprovedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        'For Specific External User
        If chkSpecificExternalUser = True Then
            Dim SEUBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForSpecificExternalUserApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificExternalUserApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInSpecificExternalUserApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInSpecificExternalUserApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificExternalUser(Date.Now, Comments, False, True, False, SEUBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            Me.SendTimesheetApprovedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        'For Employee Manager
        If chkEmployeeManager = True Then
            Dim EMBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForEmployeeManagerApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInEmployeeManagerApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInEmployeeManagerApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInEmployeeManagerApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForEmployeeManager(Date.Now, Comments, False, True, False, EMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            Me.SendTimesheetApprovedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        Me.AfterUpdate(TimeEntryDate)
    End Function
    ''' <summary>
    ''' Update rejected in team lead approval project of specified Rejected, IsRejected, InApproval, Submitted, ModifiedOn, AccountEmployeeId
    ''' AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateRejectedInTeamLeadApprovalProject(ByVal Rejected As Boolean, ByVal IsRejected As Boolean, ByVal InApproval As Boolean, ByVal Submitted As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateRejectedInTeamLeadApprovalProject(Rejected, IsRejected, InApproval, Submitted, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update rejected in project manager approval project of specified Rejected, IsRejected, InApproval, Submitted, ModifiedOn,
    ''' AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateRejectedInProjectManagerApprovalProject(ByVal Rejected As Boolean, ByVal IsRejected As Boolean, ByVal InApproval As Boolean, ByVal Submitted As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateRejectedInProjectManagerApprovalProject(Rejected, IsRejected, InApproval, Submitted, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' UpdateRejectedInSpecificEmployeeApprovalProject
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateRejectedInSpecificEmployeeApprovalProject(ByVal Rejected As Boolean, ByVal IsRejected As Boolean, ByVal InApproval As Boolean, ByVal Submitted As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateRejectedInSpecificEmployeeApprovalProject(Rejected, IsRejected, InApproval, Submitted, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update Rejected In Specific External User Approval Project of specified Rejected, IsRejected, InApproval, Submitted,
    ''' ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateRejectedInSpecificExternalUserApprovalProject(ByVal Rejected As Boolean, ByVal IsRejected As Boolean, ByVal InApproval As Boolean, ByVal Submitted As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateRejectedInSpecificExternalUserApprovalProject(Rejected, IsRejected, InApproval, Submitted, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Update rejected in employee manager approval project of specified Rejected, IsRejected, InApproval, Submitted, ModifiedOn,
    ''' AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateRejectedInEmployeeManagerApprovalProject(ByVal Rejected As Boolean, ByVal IsRejected As Boolean, ByVal InApproval As Boolean, ByVal Submitted As Boolean, ByVal ModifiedOn As Date, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryAccountEmployeeId As Integer) As Integer
        Dim rowsaffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateRejectedInEmployeeManagerApprovalProject(Rejected, IsRejected, InApproval, Submitted, ModifiedOn, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
        Return rowsaffected
    End Function
    ''' <summary>
    ''' Bulk time sheet approval entries for rejected of specified AccountEmployeeId, TimeEntryAccountEmployeeId, TimeEntryStartDate,
    ''' TimeEntryEndDate, Comments, chkTeamLead, chkTeamLeadRejected, chkProjectManager, chkProjectManagerRejected, chkSpecificEmployee,
    ''' chkSpecificEmployeeRejected, chkSpecificExternalUser, chkSpecificExternalUserRejected, chkEmployeeManagerchkEmployeeManagerRejected,
    ''' TimeEntryDate, AccountEmployeeTimeEntryPeriodId, EmployeeName, TotalMinutes, EmailAddress, TimeEntryViewType, AccountProjectId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Comments"></param>
    ''' <param name="chkTeamLead"></param>
    ''' <param name="chkTeamLeadRejected"></param>
    ''' <param name="chkProjectManager"></param>
    ''' <param name="chkProjectManagerRejected"></param>
    ''' <param name="chkSpecificEmployee"></param>
    ''' <param name="chkSpecificEmployeeRejected"></param>
    ''' <param name="chkSpecificExternalUser"></param>
    ''' <param name="chkSpecificExternalUserRejected"></param>
    ''' <param name="chkEmployeeManager"></param>
    ''' <param name="chkEmployeeManagerRejected"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="TotalMinutes"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BulkTimeSheetApprovalEntriesForRejected(ByVal AccountEmployeeId As Integer, _
        ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, _
        ByVal Comments As String, ByVal chkTeamLead As Boolean, _
        ByVal chkTeamLeadRejected As Boolean, ByVal chkProjectManager As Boolean, ByVal chkProjectManagerRejected As Boolean, _
        ByVal chkSpecificEmployee As Boolean, ByVal chkSpecificEmployeeRejected As Boolean, ByVal chkSpecificExternalUser As Boolean, _
        ByVal chkSpecificExternalUserRejected As Boolean, ByVal chkEmployeeManager As Boolean, ByVal chkEmployeeManagerRejected As Boolean, ByVal TimeEntryDate As Date, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal EmployeeName As String, ByVal TotalMinutes As Double, ByVal EmailAddress As String, ByVal TimeEntryViewType As String, ByVal AccountProjectId As Integer)
        If chkTeamLeadRejected = True Then
            Dim TLBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForTeamLeadApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInTeamLeadApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateRejectedInTeamLeadApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForTeamLead(Date.Now, Comments, True, False, True, TLBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        If chkProjectManagerRejected = True Then
            Dim PMBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForProjectManagerApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInProjectManagerApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateRejectedInProjectManagerApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForProjectManager(Date.Now, Comments, True, False, True, PMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        If chkSpecificEmployeeRejected = True Then
            Dim SEBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForSpecificEmployeeApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificEmployeeApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateRejectedInSpecificEmployeeApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificEmployee(Date.Now, Comments, True, False, True, SEBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        If chkSpecificExternalUserRejected = True Then
            Dim SEUBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForSpecificExternalUserApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificExternalUserApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateRejectedInSpecificExternalUserApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificExternalUser(Date.Now, Comments, True, False, True, SEUBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        If chkEmployeeManagerRejected = True Then
            Dim EMBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForEmployeeManagerApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInEmployeeManagerApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateRejectedInEmployeeManagerApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForEmployeeManager(Date.Now, Comments, True, False, True, EMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If

        Me.AfterUpdate(TimeEntryDate)
    End Function
    ''' <summary>
    ''' Get approval entries for team lead approved and email of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForEMail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForTeamLeadApprovedAndEmail(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForEMailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForEMailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter.GetApprovalEntriesForTeamLeadEmail(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get team lead entries for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTeamLeadEntriesForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
        Dim _vueAccountEmployeeTimeEntryForApprovalTableAdapter As New vueAccountEmployeeTimeEntryForApprovalTableAdapter
        Return _vueAccountEmployeeTimeEntryForApprovalTableAdapter.GetTeamLeadEntriesForApproval(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get project manager entries for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectManagerEntriesForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
        Dim _vueAccountEmployeeTimeEntryForApprovalTableAdapter As New vueAccountEmployeeTimeEntryForApprovalTableAdapter
        Return _vueAccountEmployeeTimeEntryForApprovalTableAdapter.GetProjectManagerEntriesForApproval(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get specific employee entries for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSpecificEmployeeEntriesForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
        Dim _vueAccountEmployeeTimeEntryForApprovalTableAdapter As New vueAccountEmployeeTimeEntryForApprovalTableAdapter
        Return _vueAccountEmployeeTimeEntryForApprovalTableAdapter.GetSpecificEmployeeEntriesForApproval(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get specific external user entries for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSpecificExternalUserEntriesForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
        Dim _vueAccountEmployeeTimeEntryForApprovalTableAdapter As New vueAccountEmployeeTimeEntryForApprovalTableAdapter
        Return _vueAccountEmployeeTimeEntryForApprovalTableAdapter.GetSpecificExternalUserEntriesForApproval(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get employee manager entries for approval of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryForApproval</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeeManagerEntriesForApproval(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
        Dim _vueAccountEmployeeTimeEntryForApprovalTableAdapter As New vueAccountEmployeeTimeEntryForApprovalTableAdapter
        Return _vueAccountEmployeeTimeEntryForApprovalTableAdapter.GetEmployeeManagerEntriesForApproval(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for project manager approved and email of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForEMail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForProjectManagerApprovedAndEmail(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForEMailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForEMailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter.GetApprovalEntriesForProjectManagerEmail(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific employee approved and email of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForEMail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificEmployeeApprovedAndEmail(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForEMailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForEMailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter.GetApprovalEntriesForSpecificEmployeeEmail(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific external user approved and email of specified AccountEmployeeId, TimeEntryAccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForEMail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSpecificExternalUserApprovedAndEmail(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForEMailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForEMailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter.GetApprovalEntriesForSpecificExternalUserEmail(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for employee manager approved and email of specified AccountEmployeeId, AccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryStartDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForEMail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForEmployeeManagerApprovedAndEmail(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForEMailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForEMailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForEmailTableAdapter.GetApprovalEntriesForEmployeeManagerEmail(TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Set submitted status of specified StatusImageName, ApprovedDataItemName, SubmittedDataItemName, RejectedDataItemName
    ''' </summary>
    ''' <param name="StatusImageName"></param>
    ''' <param name="Row"></param>
    ''' <param name="i"></param>
    ''' <param name="ApprovedDataItemName"></param>
    ''' <param name="SubmittedDataItemName"></param>
    ''' <param name="RejectedDataItemName"></param>
    ''' <param name="BGV"></param>
    ''' <param name="dayNo"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetSubmittedStatus(ByVal StatusImageName As String, ByVal Row As GridViewRow, ByVal i As Integer, ByVal ApprovedDataItemName As String, ByVal SubmittedDataItemName As String, ByVal RejectedDataItemName As String, ByVal BGV As GridView, ByVal dayNo As Integer)
        If IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = False Then
            If IsDBNull(DataBinder.Eval(Row.DataItem, RejectedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, RejectedDataItemName) = False Then
                BGVColumnVisible(BGV, i)
                SetNotSubmitted(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
            Else
                BGVColumnVisible(BGV, i)
                SetRejected(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
            End If
        ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) Then
            If IsDBNull(DataBinder.Eval(Row.DataItem, ApprovedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = False Then
                BGVColumnVisible(BGV, i)
                SetSubmitted(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
            ElseIf DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = True And DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = True Then
                BGVColumnVisible(BGV, i)
                SetApproved(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
            End If
        End If
        If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
            If IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = False Then
                If IsDBNull(DataBinder.Eval(Row.DataItem, RejectedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, RejectedDataItemName) = False Then
                    BGVColumnVisible(BGV, i)
                    SetNotSubmitted(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                Else
                    BGVColumnVisible(BGV, i)
                    SetRejected(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                End If
            ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) Then
                If IsDBNull(DataBinder.Eval(Row.DataItem, ApprovedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = False Then
                    BGVColumnVisible(BGV, i)
                    SetSubmitted(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                ElseIf DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = True And DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = True Then
                    BGVColumnVisible(BGV, i)
                    SetApproved(CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set submitted status of period view by ApprovedDataItemName, SubmittedDataItemName, RejectedDataItemName
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="ApprovedDataItemName"></param>
    ''' <param name="SubmittedDataItemName"></param>
    ''' <param name="RejectedDataItemName"></param>
    ''' <param name="dayNo"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetSubmittedStatusForPeriodView(ByVal Row As GridViewRow, ByVal ApprovedDataItemName As String, ByVal SubmittedDataItemName As String, _
                                                      ByVal RejectedDataItemName As String, ByVal dayNo As Integer)
        Dim NotSubmittedColor As Color = Color.FromName("#FFCF01")
        Dim SubmittedColor As Color = Color.FromName("#2AAAFF")
        Dim ApprovedColor As Color = Color.FromName("#6CCF3A")
        Dim RejectedColor As Color = Color.FromName("#FF4A19")
        Dim UnitPixel As Integer = 2
        If IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = False Then
            If IsDBNull(DataBinder.Eval(Row.DataItem, RejectedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, RejectedDataItemName) = False Then
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = NotSubmittedColor
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
            Else
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = RejectedColor
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
            End If
        ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) Then
            If IsDBNull(DataBinder.Eval(Row.DataItem, ApprovedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = False Then
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = SubmittedColor
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
            ElseIf DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = True And DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = True Then
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = ApprovedColor
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
            End If
        End If
        If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
            If IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = False Then
                If IsDBNull(DataBinder.Eval(Row.DataItem, RejectedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, RejectedDataItemName) = False Then
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = NotSubmittedColor
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
                Else
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = RejectedColor
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
                End If
            ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) Then
                If IsDBNull(DataBinder.Eval(Row.DataItem, ApprovedDataItemName)) OrElse DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = False Then
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = SubmittedColor
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
                ElseIf DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = True And DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = True Then
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderColor = ApprovedColor
                    CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).BorderWidth = Unit.Pixel(2)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' BGVColumnVisible
    ''' </summary>
    ''' <param name="BGV"></param>
    ''' <param name="i"></param>
    ''' <remarks></remarks>
    Public Shared Sub BGVColumnVisible(ByVal BGV As GridView, ByVal i As Integer)
        If Not BGV Is Nothing Then
            BGV.Columns(i).Visible = True
        End If
    End Sub
    ''' <summary>
    ''' SetSubmitted
    ''' </summary>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetSubmitted(ByVal StatusImage As System.Web.UI.WebControls.Image)
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
    End Sub
    ''' <summary>
    ''' SetApproved
    ''' </summary>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetApproved(ByVal StatusImage As System.Web.UI.WebControls.Image)
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/ApprovedStatus.gif"
    End Sub
    ''' <summary>
    ''' SetRejected
    ''' </summary>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetRejected(ByVal StatusImage As System.Web.UI.WebControls.Image)
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/RejectedStatus.gif"
    End Sub
    ''' <summary>
    ''' SetNotSubmitted
    ''' </summary>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetNotSubmitted(ByVal StatusImage As System.Web.UI.WebControls.Image)
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
    End Sub
    ''' <summary>
    ''' Update currencies in time entry of specified CurrencyId, ExchangeRate, AccountId
    ''' </summary>
    ''' <param name="CurrencyId"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <param name="AccountId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateCurrenciesInTimeEntry(ByVal CurrencyId As Integer, ByVal ExchangeRate As Double, ByVal AccountId As Integer)
        Adapter.UpdateCurrenciesInTimeEntry(CurrencyId, ExchangeRate, AccountId)
    End Sub
    ''' <summary>
    ''' Update currencies and exchange rates of specified CurrencyId, ExchangeRate, AccountId
    ''' </summary>
    ''' <param name="CurrencyId"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <param name="AccountId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateCurrenciesAndExchangeRates(ByVal CurrencyId As Integer, ByVal ExchangeRate As Double, ByVal AccountId As Integer)
        Adapter.UpdateCurrenciesAndExchangeRates(CurrencyId, ExchangeRate, AccountId)
    End Sub
    ''' <summary>
    ''' Get time entry period id for time entry of specified AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType,
    ''' Submitted, Approved,  Rejected, InApproval, IsFromTimeOffRequest
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="IsFromTimeOffRequest"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriodId</returns>
    ''' <remarks></remarks>
    Public Function GetTimeEntryPeriodIdForTimeEntry(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimesheetPeriodType As String, ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal InApproval As Boolean, Optional ByVal IsFromTimeOffRequest As Boolean = False) As Guid
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = Me.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dtWeekView.Rows.Count = 0 Then
            Dim AccountEmployeeTimeEntryPeriodId As Guid = Me.AddAccountEmployeeTimeEntryPeriod(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, Submitted, Rejected, Approved, InApproval, TimesheetPeriodType)
            Return AccountEmployeeTimeEntryPeriodId
        Else
            drWeekView = dtWeekView.Rows(0)
            If Not IsFromTimeOffRequest Then
                Me.UpdateAccountEmployeeTimeEntryPeriod(drWeekView.AccountId, drWeekView.AccountEmployeeId, drWeekView.TimeEntryStartDate, drWeekView.TimeEntryEndDate, Submitted, Rejected, Approved, TimesheetPeriodType, drWeekView.AccountEmployeeTimeEntryPeriodId)
            End If
            Return drWeekView.AccountEmployeeTimeEntryPeriodId
        End If
    End Function
    ''' <summary>
    ''' Get time entry period id for period view of specified AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTimeEntryPeriodIdForPeriodView(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimesheetPeriodType As String) As Guid
        Dim dtPeriodView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = Me.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType)
        Dim drPeriodView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dtPeriodView.Rows.Count <> 0 Then
            drPeriodView = dtPeriodView.Rows(0)
            Return drPeriodView.AccountEmployeeTimeEntryPeriodId
        End If
        Return System.Guid.Empty
    End Function
    ''' <summary>
    ''' Set inapproval in account employee time entry period of specified AccountEmployeeTimeEntryId, InApproval
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="InApproval"></param>
    ''' <remarks></remarks>
    Public Sub SetInApprovalInAccountEmployeeTimeEntryPeriod(ByVal AccountEmployeeTimeEntryId As Integer, ByVal InApproval As Boolean)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)

            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId")) Then
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId"), InApproval)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set in approval in account employee time entry approval project of specified AccountEmployeeTimeEntryId, InApproval, ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SetInApprovalInAccountEmployeeTimeEntryApprovalProject(ByVal AccountEmployeeTimeEntryId As Integer, ByVal InApproval As Boolean, ByVal ApprovedByEmployeeId As Integer)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)
            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId")) Then
                Me.UpdateInApprovalInAccountEmployeeTimeEntryApprovalProject(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId"), InApproval, ApprovedByEmployeeId)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set approved in account employee time entry period of specified AccountEmployeeTimeEntryId, Approved, ApprovedByEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SetApprovedInAccountEmployeeTimeEntryPeriod(ByVal AccountEmployeeTimeEntryId As Integer, ByVal Approved As Boolean, ByVal ApprovedByEmployeeId As Integer)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim TotalApproved As Boolean
        Dim AccountEmployeeTimeEntryPeriodId As Guid
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)
            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId")) Then
                AccountEmployeeTimeEntryPeriodId = drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId")
            End If
            Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
            Dim dtApprovedTimeEntryApprovalProjects As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetApprovedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
            Dim dtApprovedTimeEntryForTimeOff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetApprovedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
            Dim dtTimeEntryForTimeOff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdForTimeOff(AccountEmployeeTimeEntryPeriodId)
            If dtApprovedTimeEntryApprovalProjects.Rows.Count > 0 Then
                If dtApprovedTimeEntryApprovalProjects.Rows.Count = dtTimeEntryApprovalProject.Rows.Count Then
                    TotalApproved = True
                End If
            End If
            If LocaleUtilitiesBLL.IsShowTimeOffInTimesheet And dtApprovedTimeEntryForTimeOff.Rows.Count > 0 Then
                If dtApprovedTimeEntryForTimeOff.Rows.Count = dtTimeEntryForTimeOff.Rows.Count Then
                    TotalApproved = True
                End If
            End If
            If TotalApproved Then
                Me.UpdateApprovedInAccountEmployeeTimeEntryPeriod(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId"), Approved, ApprovedByEmployeeId)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set approved in account employee time entry approval project of specified AccountEmployeeTimeEntryId, Approved
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <remarks></remarks>
    Public Sub SetApprovedInAccountEmployeeTimeEntryApprovalProject(ByVal AccountEmployeeTimeEntryId As Integer, ByVal Approved As Boolean)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)
            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId")) Then
                Me.UpdateApprovedInAccountEmployeeTimeEntryApprovalProject(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId"), Approved)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set rejected in account employee time entry period of specified AccountEmployeeTimeEntryId, Rejected, RejectedByEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="RejectedByEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SetRejectedInAccountEmployeeTimeEntryPeriod(ByVal AccountEmployeeTimeEntryId As Integer, ByVal Rejected As Boolean, ByVal RejectedByEmployeeId As Integer)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)
            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId")) Then
                Me.UpdateRejectedInAccountEmployeeTimeEntryPeriod(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId"), Rejected, RejectedByEmployeeId)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set approved in account employee time entry approval project of specified AccountEmployeeTimeEntryId, Approved
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <remarks></remarks>
    Public Sub SetApprovedInAccountEmployeeTimeEntryApprovalProjectForTimeOff(ByVal AccountEmployeeTimeEntryId As Integer, ByVal Approved As Boolean, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal ApprovedByEmployeeId As Integer)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)
            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId")) Then
                If CheckApprovalProjectRecord(drTimeEntry.AccountEmployeeTimeEntryApprovalProjectId) = False Then
                    Me.UpdateApprovedInAccountEmployeeTimeEntryApprovalProject(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId"), Approved)
                    AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, Approved, ApprovedByEmployeeId, Date.Now)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set approved in account employee time entry approval project of specified AccountEmployeeTimeEntryId, Approved
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <remarks></remarks>
    Public Function CheckApprovalProjectRecord(ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid) As Boolean
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntryAP As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = BLL.GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryApprovalProjectIdAndApproved(AccountEmployeeTimeEntryApprovalProjectId, False)
        Dim drTimeEntryAP As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        If dtTimeEntryAP.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Set rejected in account employee time entry approval project of specified AccountEmployeeTimeEntryId, Rejected
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <remarks></remarks>
    Public Sub SetRejectedInAccountEmployeeTimeEntryApprovalProject(ByVal AccountEmployeeTimeEntryId As Integer, ByVal Rejected As Boolean)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dtTimeEntry.Rows.Count > 0 Then
            drTimeEntry = dtTimeEntry.Rows(0)

            If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId")) Then
                Me.UpdateRejectedInAccountEmployeeTimeEntryApprovalProject(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId"), Rejected)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Check submitted and lock day view of specified PeriodStartDate, PeriodEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckSubmittedAndLockDayView(ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimesheetPeriodType As String, ByVal TimeEntryAccountEmployeeId As Integer) As Boolean

        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = BLL.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow

        If dtWeekView.Rows.Count > 0 Then
            drWeekView = dtWeekView.Rows(0)
            If LocaleUtilitiesBLL.IsShowLockSubmittedRecords Then
                Return drWeekView.Submitted
            End If
            If LocaleUtilitiesBLL.IsShowLockApprovedRecords Then
                Return drWeekView.Approved
            End If
        Else
            Return False
        End If


    End Function
    ''' <summary>
    ''' Check submitted and lock week view of specified PeriodStartDate, PeriodEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckSubmittedAndLockWeekView(ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimesheetPeriodType As String, ByVal TimeEntryAccountEmployeeId As Integer) As Boolean
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = BLL.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dtWeekView.Rows.Count > 0 Then
            drWeekView = dtWeekView.Rows(0)
            If LocaleUtilitiesBLL.IsShowLockSubmittedRecords Then
                Return drWeekView.Submitted
            End If
            If LocaleUtilitiesBLL.IsShowLockApprovedRecords Then
                Return drWeekView.Approved
            End If
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Set account employee time entry period by time entry archive of specified AccountId, AccountEmployeeId, TimeEntryStartDate,
    ''' TimeEntryEndDate, Submitted, Approved, TimesheetPeriodType
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetAccountEmployeeTimeEntryPeriodByTimeEntryArchive(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal TimesheetPeriodType As String)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = BLL.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimesheetPeriodType)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        Dim nAccountEmployeeTimeEntryPeriodId As Guid
        If dtWeekView.Rows.Count = 0 Then
            nAccountEmployeeTimeEntryPeriodId = Me.AddAccountEmployeeTimeEntryPeriod(AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, Submitted, False, Approved, False, TimesheetPeriodType)
        Else
            drWeekView = dtWeekView.Rows(0)
            With drWeekView
                .Submitted = Submitted
                .Approved = Approved
                If Approved = False Then
                    .InApproval = False
                End If
            End With
            nAccountEmployeeTimeEntryPeriodId = drWeekView.AccountEmployeeTimeEntryPeriodId
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(dtWeekView)
        End If
        Return nAccountEmployeeTimeEntryPeriodId
    End Function
    ''' <summary>
    ''' Set account employee time entry approval project by time entry archive of specified AccountEmployeeTimeEntryPeriodId, AccountProjectId,
    ''' TimeEntryAccountEmployeeId, ApprovedByEmployeeId, Submitted, Approved
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetAccountEmployeeTimeEntryApprovalProjectByTimeEntryArchive(ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal ApprovedByEmployeeId As Integer, ByVal Submitted As Boolean, ByVal Approved As Boolean)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = BLL.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        Dim nAccountEmployeeTimeEntryApprovalProjectId As Guid
        If dtWeekView.Rows.Count = 0 Then
            nAccountEmployeeTimeEntryApprovalProjectId = Me.AddAccountEmployeeTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId, AccountProjectId, TimeEntryAccountEmployeeId, ApprovedByEmployeeId, Submitted, False, False, Approved, False, False)
        Else
            drWeekView = dtWeekView.Rows(0)
            With drWeekView
                .Submitted = Submitted
                .Approved = Approved
                .Rejected = 0
                .IsRejected = 0
                If Approved = False Then
                    .InApproval = False
                End If
            End With
            nAccountEmployeeTimeEntryApprovalProjectId = drWeekView.AccountEmployeeTimeEntryApprovalProjectId
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(dtWeekView)
        End If
        Return nAccountEmployeeTimeEntryApprovalProjectId
    End Function
    ''' <summary>
    ''' Update billing rate exchange rate of time entry of specified AccountCurrencyId, StartDate, EndDate, ExchangeRate
    ''' </summary>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <remarks></remarks>
    Public Sub UpdateBillingRateExchangeRateOfTimeEntry(ByVal AccountCurrencyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ExchangeRate As Double)
        Adapter.UpdateBilllingRateExchangeRateOfTimeEntry(ExchangeRate, StartDate, EndDate, AccountCurrencyId)
    End Sub
    ''' <summary>
    ''' Update billing rate exchange rate of time entry non billable of specified AccountCurrencyId, StartDate, EndDate
    ''' </summary>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <remarks></remarks>
    Public Sub UpdateBillingRateExchangeRateOfTimeEntryNonBillable(ByVal AccountCurrencyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date)
        Adapter.UpdateBillingRateExchangeRateOfTimeEntryNonBillable(StartDate, EndDate, AccountCurrencyId)
    End Sub
    ''' <summary>
    ''' Update employee rate exchange rate of time entry of specified AccountCurrencyId, StartDate, EndDate, ExchangeRate
    ''' </summary>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <remarks></remarks>
    Public Sub UpdateEmployeeRateExchangeRateOfTimeEntry(ByVal AccountCurrencyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ExchangeRate As Double)
        Adapter.UpdateEmployeeRateExchangeRateOfTimeEntry(ExchangeRate, StartDate, EndDate, AccountCurrencyId)
    End Sub
    ''' <summary>
    ''' Update employee rate exchange rate of time entry non billable of specified AccountCurrencyId, StartDate, EndDate
    ''' </summary>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <remarks></remarks>
    Public Sub UpdateEmployeeRateExchangeRateOfTimeEntryNonBillable(ByVal AccountCurrencyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date)
        Adapter.UpdateEmployeeRateExchangeRateOfTimeEntryNonBillable(StartDate, EndDate, AccountCurrencyId)
    End Sub
    ''' <summary>
    ''' Update billing and employee rate exchange rate of time entry of specified AccountCurrencyId, StartDate, EndDate, ExchangeRate
    ''' </summary>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <remarks></remarks>
    Public Sub UpdateBillingAndEmployeeRateExchangeRateOfTimeEntry(ByVal AccountCurrencyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ExchangeRate As Double)
        Me.UpdateBillingRateExchangeRateOfTimeEntry(AccountCurrencyId, StartDate, EndDate, ExchangeRate)
        Me.UpdateBillingRateExchangeRateOfTimeEntryNonBillable(AccountCurrencyId, StartDate, EndDate)
        Me.UpdateEmployeeRateExchangeRateOfTimeEntry(AccountCurrencyId, StartDate, EndDate, ExchangeRate)
        Me.UpdateEmployeeRateExchangeRateOfTimeEntryNonBillable(AccountCurrencyId, StartDate, EndDate)
    End Sub
    ''' <summary>
    ''' Set account employee time entry approval project of specified AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId,
    ''' AccountProjectId, TimeEntryAccountEmployeeId, ApprovedByEmployeeId, ApprovedByEmployeeId, Submitted, InApproval, IsRejected,
    ''' Approved, Rejected, TimeEntryMode, Old_AccountProjectId, TimeEntryDate
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="TimeEntryMode"></param>
    ''' <param name="Old_AccountProjectId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <remarks></remarks>
    Public Sub SetAccountEmployeeTimeEntryApprovalProject(ByVal AccountEmployeeTimeEntryId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal ApprovedByEmployeeId As Integer, ByVal Submitted As Boolean, ByVal InApproval As Boolean, ByVal IsRejected As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal TimeEntryMode As String, ByVal Old_AccountProjectId As Integer, Optional ByVal TimeEntryDate As Date = #1/1/2007#)
        Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
        Dim drTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        If dtTimeEntryApprovalProject.Rows.Count = 0 Then
            Dim AccountEmployeeTimeEntryApprovalProjectId As Guid = Me.AddAccountEmployeeTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId, AccountProjectId, TimeEntryAccountEmployeeId, ApprovedByEmployeeId, Submitted, InApproval, IsRejected, IIf(Submitted = True, Me.SetApprovalStateForApprovalProject(AccountProjectId), False), Rejected, False)
            Me.UpdateAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryApprovalProjectId)
        Else
            drTimeEntryApprovalProject = dtTimeEntryApprovalProject.Rows(0)
            With drTimeEntryApprovalProject
                Me.UpdateAccountEmployeeTimeEntryApprovalProject(.AccountEmployeeTimeEntryPeriodId, AccountProjectId, .TimeEntryAccountEmployeeId, IIf(IsDBNull(.Item("ApprovedByEmployeeId")), Nothing, .Item("ApprovedByEmployeeId")), IIf(.Submitted = True, True, Submitted), IIf(.InApproval = True, True, InApproval), IIf(Submitted = True, IsRejected, .IsRejected), IIf(.Submitted = True, IIf(.Approved = True, True, Approved), IIf(Submitted = True, IIf(Me.SetApprovalStateForApprovalProject(AccountProjectId) = True, True, .Approved), .Approved)), IIf(Submitted = True, Rejected, .Rejected), .AccountEmployeeTimeEntryApprovalProjectId)
                Me.UpdateAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryId, .AccountEmployeeTimeEntryApprovalProjectId)
            End With
        End If
        'Me.CheckAndDeleteAccountEmployeeTimeEntryApprovalProject(Old_AccountProjectId, AccountProjectId, AccountEmployeeTimeEntryPeriodId)
        Me.AfterUpdate(TimeEntryDate)
    End Sub
    ''' <summary>
    ''' Check and delete account employee time entry approval project of specified Old_AccountProjectId, AccountProjectId, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="Old_AccountProjectId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub CheckAndDeleteAccountEmployeeTimeEntryApprovalProject(ByVal Old_AccountProjectId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        If Old_AccountProjectId <> AccountProjectId Then
            Dim dtTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodId, Old_AccountProjectId)
            Dim drTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
            If dtTimeEntries.Rows.Count = 0 Then
                AccountEmployeeTimeEntryApprovalProjectAdapter.DeleteApprovalProjectByPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodId, Old_AccountProjectId)
                AccountEmployeeTimeEntryApprovalAdapter.DeleteApprovalByPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodId, Old_AccountProjectId)
            Else
                drTimeEntries = dtTimeEntries.Rows(0)
                AccountEmployeeTimeEntryApprovalAdapter.UpdateTimeEntryIdByPeriodIdAndProjectId(drTimeEntries.AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId, Old_AccountProjectId)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Update new account project id in approval project of specified AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId, AccountProjectId,
    ''' TimeEntryAccountEmployeeId, ApprovedByEmployeeId, Submitted, InApproval, IsRejected, Approved, Rejected, AccountEmployeeTimeEntry
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="AccountEmployeeTimeEntry"></param>
    ''' <param name="TimeEntryMode"></param>
    ''' <param name="Old_AccountProjectId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateNewAccountProjectIdInApprovalProject(ByVal AccountEmployeeTimeEntryId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal ApprovedByEmployeeId As Integer, ByVal Submitted As Boolean, ByVal InApproval As Boolean, ByVal IsRejected As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow, ByVal TimeEntryMode As String, ByVal Old_AccountProjectId As Integer)
        Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, Old_AccountProjectId)
        Dim drTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        If dtTimeEntryApprovalProject.Rows.Count > 0 Then
            drTimeEntryApprovalProject = dtTimeEntryApprovalProject.Rows(0)
            With drTimeEntryApprovalProject
                Me.UpdateAccountEmployeeTimeEntryApprovalProject(.AccountEmployeeTimeEntryPeriodId, AccountProjectId, .TimeEntryAccountEmployeeId, IIf(IsDBNull(.Item("ApprovedByEmployeeId")), Nothing, .Item("ApprovedByEmployeeId")), IIf(.Submitted = True, True, Submitted), IIf(.InApproval = True, True, InApproval), IIf(Submitted = True, IsRejected, .IsRejected), IIf(.Submitted = True, IIf(.Approved = True, True, Approved), IIf(Submitted = True, IIf(Me.SetApprovalStateForApprovalProject(AccountProjectId) = True, True, .Approved), .Approved)), IIf(Submitted = True, Rejected, .Rejected), .AccountEmployeeTimeEntryApprovalProjectId)
                Me.UpdateAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryId, .AccountEmployeeTimeEntryApprovalProjectId)
            End With
        End If
    End Sub
    ''' <summary>
    ''' Set account employee time entry period approval status of specified AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate,
    ''' TimeEntryPeriodType, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="TimeEntryPeriodType"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SetAccountEmployeeTimeEntryPeriodApprovalStatus(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimeEntryPeriodType As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        Dim Submitted As Boolean
        Dim InApproval As Boolean
        Dim Approved As Boolean
        Dim Rejected As Boolean
        Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtSubmittedTimeEntryApprovalProjects As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetSubmittedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtInApprovalTimeEntryApprovalProjects As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetInApprovalAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtApprovedTimeEntryApprovalProjects As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetApprovedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtRejectedTimeEntryApprovalProjects As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetRejectedAccountEmployeeTimeEntryApprovalProjectsByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtSubmittedTimeEntryForTimeOff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetSubmittedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtApprovedTimeEntryForTimeOff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetApprovedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtRejectedTimeEntryForTimeOff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetRejectedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtTimeEntryForTimeOff As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdForTimeOff(AccountEmployeeTimeEntryPeriodId)

        If dtSubmittedTimeEntryApprovalProjects.Rows.Count > 0 Or dtSubmittedTimeEntryForTimeOff.Rows.Count > 0 Then
            If (dtSubmittedTimeEntryApprovalProjects.Rows.Count = dtTimeEntryApprovalProject.Rows.Count And dtTimeEntryApprovalProject.Rows.Count <> 0 And (dtSubmittedTimeEntryForTimeOff.Rows.Count = dtTimeEntryForTimeOff.Rows.Count And dtTimeEntryForTimeOff.Rows.Count <> 0)) Or ((dtSubmittedTimeEntryForTimeOff.Rows.Count = dtTimeEntryForTimeOff.Rows.Count And dtTimeEntryForTimeOff.Rows.Count <> 0) And (dtSubmittedTimeEntryApprovalProjects.Rows.Count = dtTimeEntryApprovalProject.Rows.Count And dtTimeEntryApprovalProject.Rows.Count <> 0)) Then
                Submitted = True
            End If
        End If
        If dtInApprovalTimeEntryApprovalProjects.Rows.Count > 0 Then
            InApproval = True
        End If
        If dtApprovedTimeEntryApprovalProjects.Rows.Count > 0 OrElse dtApprovedTimeEntryForTimeOff.Rows.Count > 0 Then
            If dtApprovedTimeEntryApprovalProjects.Rows.Count = dtTimeEntryApprovalProject.Rows.Count And dtApprovedTimeEntryForTimeOff.Rows.Count = dtTimeEntryForTimeOff.Rows.Count Then
                Approved = True
            End If
        End If
        If dtRejectedTimeEntryApprovalProjects.Rows.Count > 0 Or dtRejectedTimeEntryForTimeOff.Rows.Count > 0 Then
            Submitted = False
            Rejected = True
        End If

        Me.UpdateAccountEmployeeTimeEntryPeriodStatus(AccountId, AccountEmployeeId, Submitted, Approved, Rejected, InApproval, AccountEmployeeTimeEntryPeriodId)
        Me.UpdateAccountEmployeeTimeEntries(AccountId, AccountEmployeeId)
        Me.AfterUpdate(PeriodStartDate)
    End Sub
    Public Sub SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(ByVal AccountId As Integer, ByVal AccountEmployeeTimeOffRequestId As Guid, Optional ByVal Delete As Boolean = False)

        Dim AccountEmployeeTimeEntryPeriodId As Guid
        Dim MinWeekHours As Integer
        Dim AccountEmployeeId As Integer
        Dim AccountEmployeeTimeOffRequestBll As New AccountEmployeeTimeOffRequestBLL
        Dim dtTimeEntriesByRequestId = Me.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
        If dtTimeEntriesByRequestId.Count > 0 Then
            AccountEmployeeId = dtTimeEntriesByRequestId.Item(0).AccountEmployeeId
            MinWeekHours = Me.GetEmployeeMinWeekHours(AccountEmployeeId)

            Dim AccountEmployeeTimeEntryPeriodIdList = From row In dtTimeEntriesByRequestId.AsEnumerable()
                                                       Select row.Field(Of Guid)("AccountEmployeeTimeEntryPeriodId") Distinct

            For Each AccountEmployeeTimeEntryPeriodId In AccountEmployeeTimeEntryPeriodIdList
                If Me.GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdIsNotTimeOffRequestRequired(AccountEmployeeTimeEntryPeriodId).Rows.Count = 0 Then
                    Me.UpdateTimeSheetStatusByTimeOffRequestRequired(AccountId, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, MinWeekHours, Delete)
                End If
            Next
        End If
    End Sub
    Private Sub UpdateTimeSheetStatusByTimeOffRequestRequired(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal MinWeekHours As Integer, ByVal Delete As Boolean)
        Dim Submitted As Boolean
        Dim InApproval As Boolean
        Dim Approved As Boolean
        Dim Rejected As Boolean

        Dim dtSubmittedTimeEntryForTimeOffRequestRequired As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetSubmittedAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtApprovedTimeEntryForTimeOffRequestRequired As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetApprovedAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtRejectedTimeEntryForTimeOffRequestRequired As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetRejectedAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dtTimeEntryForTimeOffRequestRequired As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Me.GetAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim TotalHours = dtTimeEntryForTimeOffRequestRequired.Sum(Function(x) x("Hours"))
        If dtSubmittedTimeEntryForTimeOffRequestRequired.Rows.Count > 0 And dtSubmittedTimeEntryForTimeOffRequestRequired.Sum(Function(x) x("Hours")) >= MinWeekHours Then
            Submitted = True
        End If

        If dtApprovedTimeEntryForTimeOffRequestRequired.Rows.Count > 0 And dtApprovedTimeEntryForTimeOffRequestRequired.Sum(Function(x) x("Hours")) >= MinWeekHours Then
            Approved = True
        End If
        If Not Delete And dtRejectedTimeEntryForTimeOffRequestRequired.Rows.Count > 0 And TotalHours >= MinWeekHours Then
            Submitted = False
            Rejected = True
        End If

        Me.UpdateAccountEmployeeTimeEntryPeriodStatus(AccountId, AccountEmployeeId, Submitted, Approved, Rejected, InApproval, AccountEmployeeTimeEntryPeriodId)
        Me.UpdateAccountEmployeeTimeEntries(AccountId, AccountEmployeeId)
        Me.AfterUpdate()
    End Sub
    Private Function GetEmployeeMinWeekHours(ByVal AccountEmployeeId As Integer) As Int32
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
        Return drEmployee.MinimumHoursPerWeek
    End Function

    ''' <summary>
    ''' Update account employee time entry period status of specified AccountId, AccountEmployeeId, Submitted, Approved, Rejected, InApproval, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateAccountEmployeeTimeEntryPeriodStatus(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal InApproval As Boolean, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        AccountEmployeeTimeEntryPeriodAdapter.UpdateAccountEmployeeTimeEntryPeriodStatus(AccountId, AccountEmployeeId, Submitted, Approved, Rejected, InApproval, IIf(Approved = True, Now.Date, Nothing), IIf(Approved = True, AccountEmployeeId, Nothing), AccountEmployeeTimeEntryPeriodId)
    End Sub
    ''' <summary>
    ''' Update account employee time entry period status for time entry archive of specified AccountId, AccountEmployeeId, Submitted, Approved,
    ''' Rejected, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateAccountEmployeeTimeEntryPeriodStatusForTimeEntryArchive(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        AccountEmployeeTimeEntryPeriodAdapter.UpdatePeriodStatusForTimeEntryArchive(AccountId, AccountEmployeeId, Submitted, Approved, Rejected, IIf(Approved = True, Now.Date, Nothing), IIf(Approved = True, AccountEmployeeId, Nothing), AccountEmployeeTimeEntryPeriodId)
    End Sub
    ''' <summary>
    ''' Update previous status in time sheet approval of specified PreviousStatus, AccountEmployeeTimeEntryPeriodId, AccountProjectId
    ''' </summary>
    ''' <param name="PreviousStatus"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <remarks></remarks>
    Public Sub UpdatePreviousStatusInTimesheetApproval(ByVal PreviousStatus As Boolean, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer)
        AccountEmployeeTimeEntryApprovalAdapter.UpdatePreviousStatusInTimesheetApproval(PreviousStatus, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
    End Sub
    ''' <summary>
    ''' Update account employee time entry approval projectId of specified Original_AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryApprovalProjectId
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntryApprovalProjectId( _
                ByVal Original_AccountEmployeeTimeEntryId As Integer, _
                ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid _
                ) As Boolean
        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)
        AddOldObjectInSession(Original_AccountEmployeeTimeEntryId)
        With AccountEmployeeTimeEntry
            .AccountEmployeeTimeEntryApprovalProjectId = AccountEmployeeTimeEntryApprovalProjectId
        End With
        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)
        Me.AfterUpdate()
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Set time sheet status of specified TimeSheetStatusLabel, StatusImage, dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId
    ''' </summary>
    ''' <param name="TimeSheetStatusLabel"></param>
    ''' <param name="StatusImage"></param>
    ''' <param name="dtStartDate"></param>
    ''' <param name="dtEndDate"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SetTimesheetStatus(ByVal TimeSheetStatusLabel As Label, ByVal StatusImage As System.Web.UI.WebControls.Image, ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal TimesheetPeriodType As String, ByVal TimeEntryAccountEmployeeId As Integer)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = BLL.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.Submitted = False And dr.Rejected = False And dr.Approved = False And dr.InApproval = False Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            ElseIf dr.Submitted = True And dr.Approved = True And dr.Rejected = False Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Approved")
                StatusImage.ImageUrl = "~/images/ApprovedStatus.gif"
            ElseIf dr.Rejected = True And dr.Submitted = False Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Rejected")
                StatusImage.ImageUrl = "~/images/RejectedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = False And dr.Approved = False And dr.InApproval = True Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Submitted")
                StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = False And dr.Approved = False And dr.InApproval = False Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Submitted")
                StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
            ElseIf dr.Submitted = False And dr.Approved = True Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            ElseIf dr.Submitted = False And dr.InApproval = True Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = True And dr.Approved = False And dr.InApproval = True Then
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Rejected")
                StatusImage.ImageUrl = "~/images/RejectedStatus.gif"
            Else
                TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            End If
        Else
            TimeSheetStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
            StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
        End If
    End Sub
    ''' <summary>
    ''' Delete time entry day view by employeeId and time entry date of specified AccountEmployeeId, TimeEntryDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <remarks></remarks>
    Public Sub DeleteTimeEntryDayViewByEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date)
        Adapter.DeleteTimeEntryByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate)
    End Sub
    ''' <summary>
    ''' Delete time entry week view by employeeId and time entry date of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <remarks></remarks>
    Public Sub DeleteTimeEntryWeekViewByEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)
        If Adapter.GetDataByAccountEmployeeIdAndDateRange(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate).Rows.Count > 0 Then
            Adapter.DeleteTimeEntryWeekByEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        End If
    End Sub
    ''' <summary>
    ''' Check time entry of specified AccountEmployeeId, TimeEntryDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsExistsTimeEntryByEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date) As Boolean
        If Me.Adapter.GetDataByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Get projects for approval detail
    ''' </summary>
    ''' <param name="BatchId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectsForApprovalDetailReadOnly(ByVal BatchId As Guid) As String
        Dim dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalWithProjectDataTable = Me.GetvueAccountEmployeeTimeEntryApprovalWithProjectByBatchId(BatchId)
        Dim dr As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalWithProjectRow
        If dt.Rows.Count > 0 Then
            Dim Projects As String = ""
            Dim count As Integer
            For Each dr In dt.Rows
                Projects += IIf(count = 0, "", ", ") & dr.ProjectName
                count += 1
            Next
            Return Projects
        Else
            Return ""
        End If
        Return ""
    End Function
    ''' <summary>
    ''' Get account employee time entry period id by time entry date and time entry view of specified AccountId, AccountEmployeeId,
    ''' TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAccountEmployeeTimeEntryPeriodIdByTimeEntryDateAndTimeEntryView(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal TimeEntryViewType As String) As Guid
        Dim dtPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType)
        Dim drPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dtPeriod.Rows.Count > 0 Then
            drPeriod = dtPeriod.Rows(0)
            Return drPeriod.AccountEmployeeTimeEntryPeriodId
        End If
        Return System.Guid.Empty
    End Function
    ''' <summary>
    ''' Get approved employee time entry for email by periodId and projectId of specified AccountEmployeeTimeEntryPeriodID, AccountPRojectId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodID"></param>
    ''' <param name="AccountPRojectId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovedEmail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedAccountEmployeeTimeEntryForEmailByPeriodIdAndProjectId(ByVal AccountEmployeeTimeEntryPeriodID As Guid, ByVal AccountPRojectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovedEmailDataTable
        Dim _vueAccountEmployeeTimeEntryApprovedEmail As New vueAccountEmployeeTimeEntryApprovedEmailTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovedEmail.GetDataByPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodID, AccountPRojectId)
    End Function
    ''' <summary>
    ''' Get rejected account employee time entry for email by periodId and projectId of specified AccountEmployeeTimeEntryPeriodID, AccountPRojectId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodID"></param>
    ''' <param name="AccountPRojectId"></param>
    ''' <returns>vueAccountEmployeeTimeEntryRejectedEmail</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedAccountEmployeeTimeEntryForEmailByPeriodIdAndProjectId(ByVal AccountEmployeeTimeEntryPeriodID As Guid, ByVal AccountPRojectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryRejectedEmailDataTable
        Dim _vueAccountEmployeeTimeEntryRejectedEmail As New vueAccountEmployeeTimeEntryRejectedEmailTableAdapter
        Return _vueAccountEmployeeTimeEntryRejectedEmail.GetDataByPeriodIdAndProjectId(AccountEmployeeTimeEntryPeriodID, AccountPRojectId)
    End Function
    ''' <summary>
    ''' Check and get time sheet period type of specified AccountEmployeeId, PeriodStartDate, PeriodEndDate, EmployeeTimesheetPeriodType
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodStartDate"></param>
    ''' <param name="PeriodEndDate"></param>
    ''' <param name="EmployeeTimesheetPeriodType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckAndGetTimesheetPeriodType(ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal EmployeeTimesheetPeriodType As String) As String
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryViewTypeDataTable = BLL.GetTimeEntryViewTypeByAccountEmployeeIdAndPeriodDate(AccountEmployeeId, PeriodStartDate, PeriodEndDate)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryViewTypeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.TimeEntryViewType <> EmployeeTimesheetPeriodType Then
                Return dr.TimeEntryViewType
            Else
                Return EmployeeTimesheetPeriodType
            End If
        Else
            Return EmployeeTimesheetPeriodType
        End If
    End Function
    ''' <summary>
    ''' Get period start date of specified AccountEmployeeId, PeriodDate, TimeEntryViewType
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodDate"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPeriodStartDate(ByVal AccountEmployeeId As Integer, ByVal PeriodDate As Date, ByVal TimeEntryViewType As String) As Date
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodStartDateDataTable = BLL.GetPeriodStartDateByAccountEmployeeIdAndDate(AccountEmployeeId, PeriodDate, TimeEntryViewType)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodStartDateRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.TimeEntryStartDate
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Get period end date of specified AccountEmployeeId, PeriodDate, TimeEntryViewType
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="PeriodDate"></param>
    ''' <param name="TimeEntryViewType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPeriodEndDate(ByVal AccountEmployeeId As Integer, ByVal PeriodDate As Date, ByVal TimeEntryViewType As String) As Date
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodEndDateDataTable = BLL.GetPeriodEndDateByAccountEmployeeIdAndDate(AccountEmployeeId, PeriodDate, TimeEntryViewType)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodEndDateRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.TimeEntryEndDate
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Set period data by account employeeId and time entry date of specified AccountEmployeeId, TimeEntryDate, Submitted, Approved
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, Optional ByVal Submitted As Boolean = False, Optional ByVal Approved As Boolean = False) As Guid
        Dim dtPeriodStartDate As Date = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, DBUtilities.GetEmployeeTimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        Dim dtPeriodEndDate As Date = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, DBUtilities.GetEmployeeTimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, DBUtilities.GetEmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> DBUtilities.GetEmployeeTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        End If
        Dim dtAccountEmployeeTimeEntryPeriodId As Guid = Me.GetTimeEntryPeriodIdForTimeEntry(DBUtilities.GetSessionAccountId, AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, TimesheetPeriodType, Submitted, Approved, False, False)
        TimesheetPeriodTypeTS = TimesheetPeriodType
        PeriodStartDateTS = dtPeriodStartDate
        PeriodEndDateTS = dtPeriodEndDate
        AccountEmployeeTimeEntryPeriodIdTS = dtAccountEmployeeTimeEntryPeriodId
    End Function

    Public Function GetThisWeekTimeSheetPeriodId(ByVal AccountEmployeeId As Integer, ByVal Submitted As Boolean, ByVal Approved As Boolean) As Guid

        Dim Today = DateTime.Now

        While Today.DayOfWeek <> DayOfWeek.Monday
            Today = Today.AddDays(-1)
        End While


        Dim StartDate As New Date
        StartDate = Today
        Dim EndDate As New Date
        EndDate = Today.AddDays(6)

        Dim dtAccountEmployeeTimeEntryPeriodId As Guid = Me.GetTimeEntryPeriodIdForTimeEntry(354, AccountEmployeeId, StartDate, EndDate, DBUtilities.GetEmployeeTimesheetPeriodType, Submitted, Approved, False, False)
        Return dtAccountEmployeeTimeEntryPeriodId

    End Function
    ''' <summary>
    ''' Set data in variables for API of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SetDataInVariableForAPI(ByVal AccountEmployeeId As Integer)
        If Not DBUtilities.IsApplicationContext() Then
            Dim EmployeeBLL As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
            Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
            SystemTimesheetPeriodTypeWS = IIf(Not IsDBNull(drEmployee.Item("SystemTimesheetPeriodType")), drEmployee.Item("SystemTimesheetPeriodType"), "Weekly")
            EmployeeWeekStartDayWS = IIf(Not IsDBNull(drEmployee.Item("EmployeeWeekStartDay")), drEmployee.Item("EmployeeWeekStartDay"), 1)
            SystemInitialDayOfFirstPeriodWS = drEmployee.SystemInitialDayOfFirstPeriod
            SystemInitialDayOfLastPeriodWS = drEmployee.SystemInitialDayOfLastPeriod
            InitialDayOfTheMonthWS = drEmployee.InitialDayOfTheMonth
        Else
            SystemTimesheetPeriodTypeWS = DBUtilities.GetEmployeeTimesheetPeriodType
            EmployeeWeekStartDayWS = DBUtilities.GetSessionEmployeeWeekStartDay
            SystemInitialDayOfFirstPeriodWS = DBUtilities.GetSystemInitialDayOfFirstPeriod
            SystemInitialDayOfLastPeriodWS = DBUtilities.GetSystemInitialDayOfLastPeriod
            InitialDayOfTheMonthWS = DBUtilities.GetInitialDayOfTheMonth
        End If
    End Sub
    ''' <summary>
    ''' Set period data by account employeeId and time entry date of specified AccountId, AccountEmployeeId, TimeEntryDate, Submitted, Approved
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPeriodDataByAccountEmployeeIdAndTimeEntryDateForAPI(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, Optional ByVal Submitted As Boolean = False, Optional ByVal Approved As Boolean = False) As Guid
        Me.SetDataInVariableForAPI(AccountEmployeeId)
        Dim dtPeriodStartDate As Date = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, SystemTimesheetPeriodTypeWS, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
        Dim dtPeriodEndDate As Date = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, SystemTimesheetPeriodTypeWS, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodTypeWS)
        If TimesheetPeriodType <> SystemTimesheetPeriodTypeWS Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
        End If
        Dim dtAccountEmployeeTimeEntryPeriodId As Guid = Me.GetTimeEntryPeriodIdForTimeEntry(AccountId, AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, TimesheetPeriodType, Submitted, Approved, False, False)
        TimesheetPeriodTypeTS = TimesheetPeriodType
        PeriodStartDateTS = dtPeriodStartDate
        PeriodEndDateTS = dtPeriodEndDate
        AccountEmployeeTimeEntryPeriodIdTS = dtAccountEmployeeTimeEntryPeriodId
    End Function
    ''' <summary>
    ''' Get employee own billing rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEmployeeOwnBillingRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                Return 0
            Else
                Return drBillingRate.BillingRate
            End If
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountEmployeeId(AccountEmployeeId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return 0
                Else
                    Return drBillingRate.BillingRate
                End If
            Else
                Return 0
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project role billing rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectRoleBillingRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectRoleBLL As New AccountProjectRoleBLL
        Dim dtProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateDataTable = ProjectRoleBLL.GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectId)
        Dim drProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateRow
        If dtProjectRole.Rows.Count > 0 Then
            drProjectRole = dtProjectRole.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate(drProjectRole.AccountProjectRoleId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return 0
                Else
                    Return drBillingRate.BillingRate
                End If
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectRoleId(drProjectRole.AccountProjectRoleId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                        Return 0
                    Else
                        Return drBillingRate.BillingRate
                    End If
                Else
                    Return 0
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project employee billing rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectEmployeeBillingRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectEmployeeBLL As New AccountProjectEmployeeBLL
        Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateDataTable = ProjectEmployeeBLL.GetAccountProjectEmployeesBillingRate(AccountEmployeeId, AccountProjectId)
        Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateRow
        If dtProjectEmployee.Rows.Count > 0 Then
            drProjectEmployee = dtProjectEmployee.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate(drProjectEmployee.AccountProjectEmployeeId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return 0
                Else
                    Return drBillingRate.BillingRate
                End If
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectEmployeeId(drProjectEmployee.AccountProjectEmployeeId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                        Return 0
                    Else
                        Return drBillingRate.BillingRate
                    End If
                Else
                    Return 0
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project task billing rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectTaskBillingRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate(AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                Return 0
            Else
                Return drBillingRate.BillingRate
            End If
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return 0
                Else
                    Return drBillingRate.BillingRate
                End If
            Else
                Return 0
            End If
        End If
    End Function
    ''' <summary>
    ''' Get employee own employee rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEmployeeOwnEmployeeRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            Return drBillingRate.EmployeeRate
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountEmployeeId(AccountEmployeeId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRate
            Else
                Return 0
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project role employee rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectRoleEmployeeRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectRoleBLL As New AccountProjectRoleBLL
        Dim dtProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateDataTable = ProjectRoleBLL.GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectId)
        Dim drProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateRow
        If dtProjectRole.Rows.Count > 0 Then
            drProjectRole = dtProjectRole.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate(drProjectRole.AccountProjectRoleId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)

                Return drBillingRate.EmployeeRate

            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectRoleId(drProjectRole.AccountProjectRoleId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    Return drBillingRate.EmployeeRate
                Else
                    Return 0
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project employee employee rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectEmployeeEmployeeRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectEmployeeBLL As New AccountProjectEmployeeBLL
        Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateDataTable = ProjectEmployeeBLL.GetAccountProjectEmployeesBillingRate(AccountEmployeeId, AccountProjectId)
        Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateRow
        If dtProjectEmployee.Rows.Count > 0 Then
            drProjectEmployee = dtProjectEmployee.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate(drProjectEmployee.AccountProjectEmployeeId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRate
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectEmployeeId(drProjectEmployee.AccountProjectEmployeeId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    Return drBillingRate.EmployeeRate
                Else
                    Return 0
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project task employee rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectTaskEmployeeRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate(AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            Return drBillingRate.EmployeeRate
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRate
            Else
                Return 0
            End If
        End If
    End Function
    ''' <summary>
    ''' Get employee own billing rate currencyId of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEmployeeOwnBillingRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                Return Nothing
            Else
                Return drBillingRate.BillingRateCurrencyId
            End If
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountEmployeeId(AccountEmployeeId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return Nothing
                Else
                    Return drBillingRate.BillingRateCurrencyId
                End If
            Else
                Return Nothing
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project role billing rate currencyId of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectRoleBillingRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectRoleBLL As New AccountProjectRoleBLL
        Dim dtProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateDataTable = ProjectRoleBLL.GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectId)
        Dim drProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateRow
        If dtProjectRole.Rows.Count > 0 Then
            drProjectRole = dtProjectRole.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate(drProjectRole.AccountProjectRoleId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return Nothing
                Else
                    Return drBillingRate.BillingRateCurrencyId
                End If
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectRoleId(drProjectRole.AccountProjectRoleId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                        Return Nothing
                    Else
                        Return drBillingRate.BillingRateCurrencyId
                    End If
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project employee billing rate currencyId of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectEmployeeBillingRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectEmployeeBLL As New AccountProjectEmployeeBLL
        Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateDataTable = ProjectEmployeeBLL.GetAccountProjectEmployeesBillingRate(AccountEmployeeId, AccountProjectId)
        Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateRow
        If dtProjectEmployee.Rows.Count > 0 Then
            drProjectEmployee = dtProjectEmployee.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate(drProjectEmployee.AccountProjectEmployeeId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return Nothing
                Else
                    Return drBillingRate.BillingRateCurrencyId
                End If
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectEmployeeId(drProjectEmployee.AccountProjectEmployeeId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                        Return Nothing
                    Else
                        Return drBillingRate.BillingRateCurrencyId
                    End If
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project task billing rate currencyId of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectTaskBillingRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate(AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                Return Nothing
            Else
                Return drBillingRate.BillingRateCurrencyId
            End If
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                If IsDBNull(drProjectTask.Item("IsBillable")) OrElse drProjectTask.IsBillable = False Then
                    Return Nothing
                Else
                    Return drBillingRate.BillingRateCurrencyId
                End If
            Else
                Return Nothing
            End If
        End If
    End Function
    ''' <summary>
    ''' Get employee own employee rate currencyId of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEmployeeOwnEmployeeRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            Return drBillingRate.EmployeeRateCurrencyId
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountEmployeeId(AccountEmployeeId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRateCurrencyId
            Else
                Return Nothing
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project role employee rate currencyId of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectRoleEmployeeRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectRoleBLL As New AccountProjectRoleBLL
        Dim dtProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateDataTable = ProjectRoleBLL.GetAccountProjectRolesByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectId)
        Dim drProjectRole As TimeLiveDataSet.vueAccountProjectRoleBillingRateRow
        If dtProjectRole.Rows.Count > 0 Then
            drProjectRole = dtProjectRole.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectRoleIdAndTimeEntryDate(drProjectRole.AccountProjectRoleId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRateCurrencyId
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectRoleId(drProjectRole.AccountProjectRoleId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    Return drBillingRate.EmployeeRateCurrencyId
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project employee rate currencyid of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectEmployeeEmployeeRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim ProjectEmployeeBLL As New AccountProjectEmployeeBLL
        Dim dtProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateDataTable = ProjectEmployeeBLL.GetAccountProjectEmployeesBillingRate(AccountEmployeeId, AccountProjectId)
        Dim drProjectEmployee As TimeLiveDataSet.vueAccountProjectEmployeeBillingRateRow
        If dtProjectEmployee.Rows.Count > 0 Then
            drProjectEmployee = dtProjectEmployee.Rows(0)
            Dim BillingRateBLL As New AccountBillingRateBLL
            Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectEmployeeIdAndTimeEntryDate(drProjectEmployee.AccountProjectEmployeeId, TimeEntryDate, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRateCurrencyId
            Else
                dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectEmployeeId(drProjectEmployee.AccountProjectEmployeeId, AccountWorkTypeId)
                If dtBillingRate.Rows.Count > 0 Then
                    drBillingRate = dtBillingRate.Rows(0)
                    Return drBillingRate.EmployeeRateCurrencyId
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Get project task employee rate currencyid of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectTaskEmployeeRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim drBillingRate As AccountBillingRate.AccountBillingRateRow
        Dim drvueBillingRate As AccountBillingRate.vueAccountBillingRateRow
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
        Dim drProjectTask As TimeLiveDataSet.AccountProjectTaskRow = dtProjectTask.Rows(0)
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountProjectTaskIdAndTimeEntryDate(AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        If dtBillingRate.Rows.Count > 0 Then
            drBillingRate = dtBillingRate.Rows(0)
            Return drBillingRate.EmployeeRateCurrencyId
        Else
            dtBillingRate = BillingRateBLL.GetBillingRatesByAccountProjectTaskId(AccountProjectTaskId, AccountWorkTypeId)
            If dtBillingRate.Rows.Count > 0 Then
                drBillingRate = dtBillingRate.Rows(0)
                Return drBillingRate.EmployeeRateCurrencyId
            Else
                Return Nothing
            End If
        End If
    End Function
    ''' <summary>
    ''' Get current billing rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCurrentBillingRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim ProjectBLL As New AccountProjectBLL()
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow = dtProject.Rows(0)
        If IsDBNull(drProject("ProjectBillingRateTypeId")) OrElse drProject.ProjectBillingRateTypeId = 1 Then 'Employee Own Billing Rate
            Return GetEmployeeOwnBillingRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 2 Then 'use project role billing rate
            Return GetProjectRoleBillingRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 3 Then 'use project employee billing rate
            Return GetProjectEmployeeBillingRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 4 Then 'use project task billing rate
            Return GetProjectTaskBillingRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        End If
    End Function
    ''' <summary>
    ''' Get current billing rate currencyid of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCurrentBillingRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim ProjectBLL As New AccountProjectBLL()
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow = dtProject.Rows(0)
        If IsDBNull(drProject("ProjectBillingRateTypeId")) OrElse drProject.ProjectBillingRateTypeId = 1 Then 'Employee Own Billing Rate
            Return GetEmployeeOwnBillingRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 2 Then 'use project role billing rate
            Return GetProjectRoleBillingRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 3 Then 'use project employee billing rate
            Return GetProjectEmployeeBillingRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 4 Then 'use project task billing rate
            Return GetProjectTaskBillingRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        End If
    End Function
    ''' <summary>
    ''' Get current employee rate of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCurrentEmployeeRate(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim ProjectBLL As New AccountProjectBLL()
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow = dtProject.Rows(0)
        If IsDBNull(drProject("ProjectBillingRateTypeId")) OrElse drProject.ProjectBillingRateTypeId = 1 Then 'Employee Own Billing Rate
            Return GetEmployeeOwnEmployeeRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 2 Then 'use project role billing rate
            Return GetProjectRoleEmployeeRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 3 Then 'use project employee billing rate
            Return GetProjectEmployeeEmployeeRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 4 Then 'use project task billing rate
            Return GetProjectTaskEmployeeRate(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        End If
    End Function
    ''' <summary>
    ''' Get current employee rate currencyid of specified AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCurrentEmployeeRateCurrencyId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryDate As Date, ByVal AccountWorkTypeId As Integer) As Decimal
        Dim ProjectBLL As New AccountProjectBLL()
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow = dtProject.Rows(0)
        If IsDBNull(drProject("ProjectBillingRateTypeId")) OrElse drProject.ProjectBillingRateTypeId = 1 Then 'Employee Own Billing Rate
            Return GetEmployeeOwnEmployeeRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 2 Then 'use project role billing rate
            Return GetProjectRoleEmployeeRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 3 Then 'use project employee billing rate
            Return GetProjectEmployeeEmployeeRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        ElseIf drProject.ProjectBillingRateTypeId = 4 Then 'use project task billing rate
            Return GetProjectTaskEmployeeRateCurrencyId(AccountEmployeeId, AccountProjectId, AccountProjectTaskId, TimeEntryDate, AccountWorkTypeId)
        End If
    End Function
    ''' <summary>
    ''' Set account employee time entry approval project id to null in time entry of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SetAccountEmployeeTimeEntryApprovalProjectIdToNULLInTimeEntry(ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        Adapter.SetAccountEmployeeTimeEntryApprovalProjectToNULL(AccountEmployeeTimeEntryPeriodId)
    End Sub
    ''' <summary>
    ''' Delete employee time entry approval project by periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub DeleteAccountEmployeeTimeEntryApprovalProjectByPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        AccountEmployeeTimeEntryApprovalProjectAdapter.DeleteAccountEmployeeTimeEntryApprovalProjectByPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Sub
    ''' <summary>
    ''' Get pending time entry with preference for administrator
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryWithPreferenceForAdministrator() As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForAdministratorDataTable
        Dim _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForAdministratorTableAdapter As New vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForAdministratorTableAdapter
        Return _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForAdministratorTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Get pending time entry with preference for project manager
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForProjectManager</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryWithPreferenceForProjectManager() As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForProjectManagerDataTable
        Dim _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForProjectManagerTableAdapter As New vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForProjectManagerTableAdapter
        Return _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForProjectManagerTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Get pending time entry with preference for team lead
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForTeamLead</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryWithPreferenceForTeamLead() As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForTeamLeadDataTable
        Dim _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForTeamLeadTableAdapter As New vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForTeamLeadTableAdapter
        Return _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForTeamLeadTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Get pending time entry with preference for employee manager
    ''' </summary>
    ''' <returns>vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForEmployeeManager</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryWithPreferenceForEmployeeManager() As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForEmployeeManagerDataTable
        Dim _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForEmployeeManagerTableAdapter As New vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForEmployeeManagerTableAdapter
        Return _vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForEmployeeManagerTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Send pending time entry for admin and project manager and team lead and employee manager of specified AccountId, AccountEmployeeId,
    ''' EmployeeName, EmailAddress, PendingEmailType, CultureInfoName
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="PendingEmailType"></param>
    ''' <param name="CultureInfoName"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingTimeEntryForADMINAndPMAndTLAndEM(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal EmailAddress As String, ByVal PendingEmailType As String, ByVal CultureInfoName As String, ByVal SystemCurrentDateTime As SMInformatik.Util.SMDateTime)
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim strTable As String = "<table border=1 width=100%> "
        Dim SystemTimesheetPeriodType As String = ""
        Dim WorkingDaysArray As ArrayList
        Dim TimeEntryStartDate As Date
        Dim TimeEntryEndDate As Date
        Dim dtEmployees As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetEmployeesDataTableForTimeEntryPendingEmail(AccountId, AccountEmployeeId, PendingEmailType)
        Dim drEmployees As AccountEmployee.vueAccountEmployeeRow
        If dtEmployees.Rows.Count > 0 Then
            Dim starttime As DateTime = Now
            For Each drEmployees In dtEmployees.Rows
                Dim UserCurrentDateTime As DateTime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(SystemCurrentDateTime, EMailUtilities.GetTimeZoneId(drEmployees.AccountEmployeeId))
                WorkingDaysArray = DateTimeUtilities.GetWorkingDays(drEmployees.AccountEmployeeId, UserCurrentDateTime.Date, UserCurrentDateTime.Date, UserCurrentDateTime.Date, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                If WorkingDaysArray.Count > 0 Then
                    TimeEntryStartDate = WorkingDaysArray(0)
                    TimeEntryEndDate = GetTimeEntryEndDateForEmail(WorkingDaysArray(WorkingDaysArray.Count - 1), TimeEntryEndDate)
                    LoggingBLL.WriteToLog("SendPendingTimeEntryForADMINAndPMAndTLAndEM:WorkingDaysArrayStartDate = " & WorkingDaysArray(0) & " WorkingDaysArrayEndDate = " & WorkingDaysArray(WorkingDaysArray.Count - 1) & "AccountEmployeeId=" & drEmployees.AccountEmployeeId)
                    If SystemTimesheetPeriodType <> drEmployees.SystemTimesheetPeriodType Then
                        strTable = strTable & CreateStringOfWorkingDaysInHTMLFormatForEmail(WorkingDaysArray, CultureInfoName)
                    End If
                    Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = Me.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(drEmployees.AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                    strTable = strTable & CreateStringOfTimeEntryHoursInHTMLFormatForEmail(WorkingDaysArray, dtEmployeesWithTimeEntry, drEmployees.EmployeeName)
                    SystemTimesheetPeriodType = drEmployees.SystemTimesheetPeriodType
                End If
            Next
            Dim endtime As DateTime = Now
            Dim a As Double = (endtime - starttime).TotalSeconds
            'Dim totaltime As DateTime = endtime - starttime
            strTable = strTable & "</table>"
            EMailUtilities.SendEMail(GetSubjectByEmail(PendingEmailType), "TimeEntryPendingEmployeesTemplate", GetPreparedEMailMessageForPendingTimeEntryADMINAndPMAndTLAndEM(strTable, TimeEntryStartDate, TimeEntryEndDate, PendingEmailType), EmailAddress, , , GetNotificationInformationForm(PendingEmailType))
        End If
    End Sub
    ''' <summary>
    ''' Send time entry pending email for admin and project manager and team lead and employee manager of specified AccountId, AccountEmployeeId,
    ''' EmployeeName, EmailAddress, PendingEmailType, CultureInfoName
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="PendingEmailType"></param>
    ''' <param name="CultureInfoName"></param>
    ''' <remarks></remarks>
    Public Sub SendTimeEntryPendingEMailForADMINAndPMAndTLAndEM(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal EmailAddress As String, ByVal PendingEmailType As String, ByVal CultureInfoName As String, ByVal SystemCurrentDateTime As SMInformatik.Util.SMDateTime)
        SendPendingTimeEntryForADMINAndPMAndTLAndEM(AccountId, AccountEmployeeId, EmployeeName, EmailAddress, PendingEmailType, CultureInfoName, SystemCurrentDateTime)
    End Sub
    ''' <summary>
    ''' Get subject by email of specified PendingEmailType
    ''' </summary>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSubjectByEmail(ByVal PendingEmailType As String) As String
        If PendingEmailType = "Administrator" Then
            Return "TimeEntry Notification To Administrator"
        ElseIf PendingEmailType = "ProjectManager" Then
            Return "TimeEntry Notification To Project Manager"
        ElseIf PendingEmailType = "TeamLead" Then
            Return "TimeEntry Notification To Team Lead"
        ElseIf PendingEmailType = "EmployeeManager" Then
            Return "TimeEntry Notification To Employee Manager"
        End If
    End Function
    ''' <summary>
    ''' Get notification information form of specified PendingEmailType
    ''' </summary>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNotificationInformationForm(ByVal PendingEmailType As String) As String
        If PendingEmailType = "Administrator" Then
            Return EMailUtilities.PENDING_TIMEENTRY_NOTIFICATION_INFORMATION_FORM_FOR_ADMINISTRATOR
        ElseIf PendingEmailType = "ProjectManager" Then
            Return EMailUtilities.PENDING_TIMEENTRY_NOTIFICATION_INFORMATION_FORM_FOR_PROJECT_MANAGER
        ElseIf PendingEmailType = "TeamLead" Then
            Return EMailUtilities.PENDING_TIMEENTRY_NOTIFICATION_INFORMATION_FORM_FOR_TEAM_LEAD
        ElseIf PendingEmailType = "EmployeeManager" Then
            Return EMailUtilities.PENDING_TIMEENTRY_NOTIFICATION_INFORMATION_FORM_FOR_EMPLOYEE_MANAGER
        End If
    End Function
    ''' <summary>
    ''' Create string of working days in html format for email of specified WorkingDaysArray, CultureInfoName
    ''' </summary>
    ''' <param name="WorkingDaysArray"></param>
    ''' <param name="CultureInfoName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateStringOfWorkingDaysInHTMLFormatForEmail(ByVal WorkingDaysArray As ArrayList, ByVal CultureInfoName As String, Optional IsFromOverdueEmail As Boolean = False) As String
        Dim strWorkingDay As String = ""
        strWorkingDay = strWorkingDay & "<tr> <td> </td> <b>"
        For n As Integer = 0 To WorkingDaysArray.Count - 1
            strWorkingDay = strWorkingDay & "<td width = 200px align=" & "center" & ">" & (LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDaysArray(n)) & " " & LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocaleForEmail(WorkingDaysArray(n), CultureInfoName)) & "</td>"
        Next
        If IsFromOverdueEmail Then
            strWorkingDay = strWorkingDay & "</b> <td width = 200px align=" & "center" & " style=background:#EFEFEF" & ">" & " <b>Minimum Hours</b> </td>"
        End If
        strWorkingDay = strWorkingDay & "</b> <td width = 200px align=" & "center" & " style=background:#EFEFEF" & ">" & " <b>Total Hours</b> </td>" & IIf(IsFromOverdueEmail, "", "</tr>")
        If IsFromOverdueEmail Then
            strWorkingDay = strWorkingDay & "</b> <td width = 200px align=" & "center" & " style=background:#EFEFEF" & ">" & " <b>Timesheet Status</b> </td> </tr>"
        End If
        Return strWorkingDay
    End Function
    ''' <summary>
    ''' Create string of time entry hours in html format for email of specified WorkingDaysArray, drEmployees
    ''' </summary>
    ''' <param name="WorkingDaysArray"></param>
    ''' <param name="drEmployees"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateStringOfTimeEntryHoursInHTMLFormatForEmail(ByVal WorkingDaysArray As ArrayList, ByVal dtEmployees As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable, ByVal EmployeeName As String, Optional IsFromOverdueEmail As Boolean = False, Optional MinimumHours As Double = 0, Optional TimesheetStatus As String = "") As String
        Dim strTotalMinutes As String = ""
        Dim strTotal As String = ""
        Dim SumTotalMinutes As Integer
        Dim TotalHours As String = "00:00"
        Dim TotalMinutes As Integer = 0
        strTotalMinutes = strTotalMinutes & "<tr> <td> <b>" & EmployeeName & "</b> </td>"
        For n As Integer = 0 To WorkingDaysArray.Count - 1
            If WorkingDaysArray(n) <= Now.Date Then
                'If dtEmployees.Rows.Count > 0 Then
                '    TotalMinutes = GetTotalMinutesByTimeEntryDateAndAccountEmployeeId(WorkingDaysArray(n), dtEmployees)
                'End If
                Dim dr() As DataRow = dtEmployees.Select("TimeEntryDate = '" & WorkingDaysArray(n) & "'")
                If dr.Length > 0 Then
                    TotalMinutes = dr(0).Item("TotalMinutes")
                End If
                TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(TotalMinutes)
                strTotalMinutes = strTotalMinutes & "<td width = 200px align=" & "center" & ">" & IIf(TotalHours = "00:00", "<font style=" & "'" & "COLOR: red" & "'" & ">" & TotalHours & "</font>", "<font style=" & "'" & "COLOR: #003366" & "'" & ">" & TotalHours & "</font>") & "</td>"
                SumTotalMinutes += TotalMinutes
            Else
                strTotalMinutes = strTotalMinutes & "<td width = 200px align=" & "center" & ">-</td>"
            End If
            TotalMinutes = 0
        Next
        If IsFromOverdueEmail Then
            strTotalMinutes = strTotalMinutes & "<td width = 200px align=" & "center" & " style=background:#EFEFEF" & ">" & "<b>" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(MinimumHours * 60) & "</b></td>"
        End If
        Dim TotalMinutesSum As String = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(SumTotalMinutes)
        strTotal = strTotal & IIf(TotalMinutesSum = "00:00", "<font style=" & "'" & "COLOR: red" & "'" & ">" & TotalMinutesSum & "</font>", TotalMinutesSum)
        strTotalMinutes = strTotalMinutes & "<td width = 200px align=" & "center" & " style=background:#EFEFEF" & ">" & "<b>" & strTotal & "</b></td>" & IIf(IsFromOverdueEmail, "", "</tr>")
        If IsFromOverdueEmail Then
            strTotalMinutes = strTotalMinutes & "<td width = 200px align=" & "center" & " style=background:#EFEFEF" & ">" & "<b>" & TimesheetStatus & "</b></td></tr>"
        End If
        Return strTotalMinutes
    End Function
    ''' <summary>
    ''' Get time entry end date for email of specified ArrayEndDate, EndDate
    ''' </summary>
    ''' <param name="ArrayEndDate"></param>
    ''' <param name="EndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTimeEntryEndDateForEmail(ByVal ArrayEndDate As Date, ByVal EndDate As Date) As Date
        If ArrayEndDate > EndDate Then
            Return ArrayEndDate
        Else
            Return EndDate
        End If
    End Function
    ''' <summary>
    ''' Get prepared email message for pending time entry admin and project manager and team lead and employee manager of specified 
    ''' strTable, TimeEntryStartDate, TimeEntryEndDate, PendingEmailType
    ''' </summary>
    ''' <param name="strTable"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="PendingEmailType"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForPendingTimeEntryADMINAndPMAndTLAndEM(ByVal strTable As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal PendingEmailType As String) As StringDictionary
        Dim dict As New StringDictionary
        dict.Add("[timeentrystartdate]", TimeEntryStartDate.ToLongDateString)
        dict.Add("[timeentryenddate]", TimeEntryEndDate.ToLongDateString)
        dict.Add("[strtable]", strTable)
        dict.Add("[pendingemailtype]", GetPendingTypeForEmailBody(PendingEmailType))
        Return dict
    End Function
    ''' <summary>
    ''' Get pending type for email body of specified PendingEmailType
    ''' </summary>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPendingTypeForEmailBody(ByVal PendingEmailType As String) As String
        If PendingEmailType = "Administrator" Then
            Return "Administrator"
        ElseIf PendingEmailType = "ProjectManager" Then
            Return "Project Manager"
        ElseIf PendingEmailType = "TeamLead" Then
            Return "Team Lead"
        ElseIf PendingEmailType = "EmployeeManager" Then
            Return "Employee Manager"
        End If
    End Function
    ''' <summary>
    ''' Get account employee time entries by employee time off requestid of specified AccountEmployeeTimeOffRequestId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByAccountEmployeeTimeOffRequestId(ByVal AccountEmployeeTimeOffRequestId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
    End Function
    ''' <summary>
    ''' Delete employee time entry by employee time off requestid of specified AccountEmployeeTimeOffRequestId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeTimeEntryByAccountEmployeeTimeOffRequestId(ByVal AccountEmployeeTimeOffRequestId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.DeleteTimeEntryByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update approved by employee time off requestid
    ''' </summary>
    ''' <param name="Approved"></param>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateApprovedByAccountEmployeeTimeOffRequestId(ByVal Approved As Boolean, ByVal AccountEmployeeTimeOffRequestId As Guid)
        Adapter.UpdateApprovedByAccountEmployeeTimeOffRequestId(Approved, AccountEmployeeTimeOffRequestId)
    End Sub
   
    ''' <summary>
    ''' Update submitted by employee time off requestid of specified Submitted, AccountEmployeeTimeOffRequestId
    ''' </summary>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateSubmittedByAccountEmployeeTimeOffRequestId(ByVal Submitted As Boolean, ByVal AccountEmployeeTimeOffRequestId As Guid)
        Adapter.UpdateSubmittedByAccountEmployeeTimeOffRequestId(Submitted, AccountEmployeeTimeOffRequestId)
    End Sub
    ''' <summary>
    ''' Update rejected by account employee time off requestid of specified Rejected, AccountEmployeeTimeOffRequestId
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRejectedByAccountEmployeeTimeOffRequestId(ByVal Rejected As Boolean, ByVal AccountEmployeeTimeOffRequestId As Guid)
        Adapter.UpdateRejectedByAccountEmployeeTimeOffRequestId(Rejected, AccountEmployeeTimeOffRequestId)
    End Sub
    ''' <summary>
    ''' Get approval entries specific employee for time off
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesSpecificEmployeeForTimeOff(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter.GetApprovalEntriesForSpecificEmployee(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries employee manager for time off of specified AccountEmployeeId, TimeEntryAccountEmployeeId, TimeEntryStartDate,
    ''' TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountEmployeeTimeEntryApprovalPendingForTimeOff</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesEmployeeManagerForTimeOff(ByVal AccountEmployeeId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter.GetApprovalEntriesForEmployeeManager(TimeEntryAccountEmployeeId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, AccountEmployeeId)
    End Function

    ''' Get approval entries project maanger for time off of specified AccountEmployeeId,  TimeEntryStartDate,TimeEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="ProjectManagerId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns></returns>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForProjectManagerTimeOff(ByVal ProjectManagerId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter.GetApprovalEntriesForProjectManagerTimeOff(ProjectManagerId, TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, IncludeDateRange)
    End Function

    ''' <summary>
    ''' Update employee time off hours of specified AccountEmployeeId, AccountTimeOffTypeId, TotalTime
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountTimeOffTypeId"></param>
    ''' <param name="TotalTime"></param>
    ''' <remarks></remarks>
    Public Sub UpdateEmployeeTimeOffHours(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal TotalTime As String, Optional ByVal PolicyExecutionType As String = "", Optional ByVal PolicyEarnResetAutidAction As String = "", Optional ByVal AuditSource As String = "", Optional ByVal AccountEmployeeTimeEntryId As Integer = 0)
        Dim HoursOff As Double
        Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
        Dim strHoursOff As String() = Split(Replace(TotalTime, ":", "."), ".")
        If DBUtilities.IsTimeEntryHoursFormat = "Decimal" And Not TotalTime.Contains(":") Then
            HoursOff = TotalTime
        Else
            If strHoursOff.Count = 1 Then
                HoursOff = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strHoursOff(0), 0)
            Else
                HoursOff = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strHoursOff(0), strHoursOff(1))
            End If
        End If

        If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, HoursOff, PolicyExecutionType, PolicyEarnResetAutidAction, AuditSource) And AccountEmployeeTimeEntryId <> 0 Then
            Me.UpdateIsTimeOffConsumedByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId, True)
        End If
    End Sub
    Public Sub UpdateEmployeeTimeOffHoursForTimeEntryArchive(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal TotalTime As String, ByVal IsTimeOffConsumed As Boolean, Optional ByVal AccountEmployeeTimeEntryId As Integer = 0, Optional ByVal PolicyExecutionType As String = "", Optional ByVal PolicyEarnResetAutidAction As String = "", Optional ByVal AuditSource As String = "")
        Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
        'Dim strHoursOff As String() = Split(Replace(TotalTime, ":", "."), ".")
        'Dim HoursOff As Double = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strHoursOff(0), strHoursOff(1))
        Dim HoursOff As Double = TotalTime

        If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, HoursOff, PolicyExecutionType, PolicyEarnResetAutidAction, AuditSource) And AccountEmployeeTimeEntryId <> 0 Then
            Me.UpdateIsTimeOffConsumedByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId, IsTimeOffConsumed)
        End If
    End Sub
    ''' <summary>
    ''' Get submitted employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetSubmittedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetSubmittedTimeEntryTimeOff(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get submitted employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetMissingEntrysPeriods(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntry.sp_xpTimeSheetsMissingDaysDataTable
        Dim SPadapter As New sp_xpTimeSheetsMissingDaysTableAdapter
        Return SPadapter.GetDataForSpMissingEntrys(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get submitted employee time entry time off request required by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    Public Function GetSubmittedAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetSubmittedTimeEntryTimeOffRequestRequired(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get approved employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetApprovedTimeEntryTimeOff(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get approved employee time entry time off request required by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovedAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetApprovedTimeEntryTimeOffRequestRequired(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get rejected employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetRejectedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetRejectedTimeEntryTimeOff(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get rejected employee time entry time off request required by employee time entry period of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriod"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetRejectedAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriod As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetRejectedTimeEntryTimeOffRequestRequired(AccountEmployeeTimeEntryPeriod)
    End Function
    ''' <summary>
    ''' Get all employee time entry time off request required by employee time entry period of a specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriod"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountEmployeeTimeEntryTimeOffRequestRequiredByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriod As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetTimeEntryTimeOffRequestRequired(AccountEmployeeTimeEntryPeriod)
    End Function

    ''' <summary>
    ''' Get employee time entries by employee time entry period id for timeoff of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdForTimeOff(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetDataByAccountEmployeeTimeEntryPeriodIdForTimeOff(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get approved employee time entry period for email by periodId of specified AccountEmployeeTimeEntryPeriodId 
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriod</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedAccountEmployeeTimeEntryPeriodForEmailByPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
        Dim _vueAccountEmployeeTimeEntryApprovedEmail As New vueAccountEmployeeTimeEntryApprovedEmailTableAdapter
        Return AccountEmployeeTimeEntryPeriodAdapter.GetApprovedEmailByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get rejected account employee time entry period for email by periodId of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriod</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedAccountEmployeeTimeEntryPeriodForEmailByPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
        Dim _vueAccountEmployeeTimeEntryApprovedEmail As New vueAccountEmployeeTimeEntryApprovedEmailTableAdapter
        Return AccountEmployeeTimeEntryPeriodAdapter.GetRejectedEmailByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get Time Entry By AccountEMployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryWithLastStatusByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
        Dim _vueAccountEmployeeTimeEntryWithLastStatusTableAdapter As New vueAccountEmployeeTimeEntryWithLastStatusTableAdapter
        Return _vueAccountEmployeeTimeEntryWithLastStatusTableAdapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Update AccountEmployeeTimeEntryApprovalProject by AccountEmployeeTimeEntryPeriodid And AccountProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryApprovalProjectId"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <remarks></remarks>
    Public Sub UpdateAccountEmployeeTimeEntryApprovalProjectIdByPeriodIdAndProjectId(ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer, ByVal Submitted As Boolean, ByVal Approved As Boolean)
        Adapter.UpdateAccountEmployeeTimeEntryApprovalProjectIdByProjectIdAndPeriodId(AccountEmployeeTimeEntryApprovalProjectId, Approved, Submitted, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
    End Sub
    ''' <summary>
    '''  Lock or unlock time entry recrods of Specified repeater row and control name optional.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="ControlName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoUnlockForRepeater(ByVal row As RepeaterItemEventArgs, Optional ByVal ControlName As String = "") As Boolean
        Dim Submitted As Boolean
        Dim IsApproved As Boolean
        Dim Approved As Boolean
        Dim LockSubmittedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
        Dim LockApprovedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockApprovedRecords
        Submitted = IIf(IsDBNull(DataBinder.Eval(row.Item.DataItem, "Submitted")), False, DataBinder.Eval(row.Item.DataItem, "Submitted"))
        IsApproved = IIf(IsDBNull(DataBinder.Eval(row.Item.DataItem, "IsApproved")), False, DataBinder.Eval(row.Item.DataItem, "IsApproved"))
        Approved = IIf(IsDBNull(DataBinder.Eval(row.Item.DataItem, "Approved")), False, DataBinder.Eval(row.Item.DataItem, "Approved"))
        If DataBinder.Eval(row.Item.DataItem, "IsTimeOff").ToString = "True" Then
            IsApproved = IIf(IsDBNull(DataBinder.Eval(row.Item.DataItem, "Approved")), False, DataBinder.Eval(row.Item.DataItem, "Approved"))
        End If
        If (LockSubmittedRecords = True And Submitted = True) Or (LockApprovedRecords = True And IsApproved = True) Or (LockApprovedRecords = True And Approved = True) Or (ControlName = "btnDelete" And AccountPagePermissionBLL.IsPageHasPermissionOf(18, 4) = False) Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Delete AccountEmployeeTimeEntry From mobile timesheet.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="TimesheetPeriodType"></param>
    ''' <param name="TimeEntryAccountEmployeeId"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <remarks></remarks>
    Public Sub DeleteAccountEmployeeTimeEntryForMobile(ByVal AccountEmployeeTimeEntryId As Integer, ByVal TimesheetPeriodType As String, _
    ByVal TimeEntryAccountEmployeeId As Integer, ByVal StartDate As Date, ByVal EndDate As Date)
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = objTimeEntryBLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            objTimeEntryBLL.DeleteAccountEmployeeTimeEntry(AccountEmployeeTimeEntryId, TimesheetPeriodType, _
            TimeEntryAccountEmployeeId, StartDate, EndDate, dr.Item("AccountEmployeeTimeEntryApprovalProjectId"), _
            dr.Item("AccountEmployeeTimeEntryPeriodId"), dr.TimeEntryDate)
        End If
    End Sub
    ''' <summary>
    ''' Update AccountEmployeeTimeEntry field IsTimeOffConsumed By AccountEmployeeTimeEntryId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryId"></param>
    ''' <param name="IsTimeOffConsumed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateIsTimeOffConsumedByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer, ByVal IsTimeOffConsumed As Boolean)
        Adapter.UpdateIsTimeOffConsumedByAccountEmployeeTimeEntryId(IsTimeOffConsumed, AccountEmployeeTimeEntryId)
    End Function
    ''' <summary>
    ''' Update AccountEmployeeTimeEntry field IsTimeOffConsumed By AccountEmployeeTimeOffRequestId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <param name="IsTimeOffConsumed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(ByVal AccountEmployeeTimeOffRequestId As Guid, ByVal IsTimeOffConsumed As Boolean)
        Adapter.UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(IsTimeOffConsumed, AccountEmployeeTimeOffRequestId)
    End Function
    ''' <summary>
    ''' Get IsTimeOffConsumed By AccountEmployeeTimeOffRequestId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeOffRequestId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(ByVal AccountEmployeeTimeOffRequestId As Guid) As Boolean
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
        For Each dr In dt.Rows
            If IsDBNull(dr.Item("IsTimeOffConsumed")) OrElse dr.Item("IsTimeOffConsumed").ToString = "True" Then
                Return True
            End If
        Next
    End Function
    ''' <summary>
    ''' Send pending time sheet of specified TimeEntryPeriodId and For Specific Project Approval.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingTimesheetForSpecificTimeEntryPeriod(ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim AccountEmployeeTimeEntryApprovalProjectId As New ArrayList
        Dim dtPendingApprovals As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingApprovalForEmailWithPreferenceGroupedDataTable = BLL.GetGroupedApprovalEntriesForSendingEmailByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        If dtPendingApprovals.Rows.Count > 0 Then
            Dim drPendingApprovals As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingApprovalForEmailWithPreferenceGroupedRow = dtPendingApprovals.Rows(0)
            For Each drPendingApprovals In dtPendingApprovals.Rows
                SendPendingTimesheetByApproverEmployeeId(drPendingApprovals.ApproverEmployeeId, AccountEmployeeTimeEntryApprovalProjectId)
            Next
            For n As Integer = 0 To AccountEmployeeTimeEntryApprovalProjectId.Count - 1
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendByAccountEmployeeTimeEntryApprrovalProjectId(True, AccountEmployeeTimeEntryApprovalProjectId.Item(n))
            Next

            EMailUtilities.DequeueEmail()
        End If
    End Sub
    ''' <summary>
    ''' Thread based function for sending pending time sheet of specified TimeEntryPeriodId and For Specific Project Approval.
    ''' </summary> 
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingTimesheetForSpecificTimeEntryPeriodWithThread(ByVal list As Guid)
        Dim ParameterizedThreadStart As New ParameterizedThreadStart(AddressOf SendPendingTimesheetForSpecificTimeEntryPeriod)
        Dim newThread As New Thread(ParameterizedThreadStart)
        newThread.Priority = ThreadPriority.Highest
        newThread.Start(list)
    End Sub
    ''' <summary>
    ''' Send pending time sheet by Approver Employee.
    ''' </summary>
    ''' <param name="ApproverEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingTimesheetByApproverEmployeeId(ByVal ApproverEmployeeId As Integer, ByVal AccountEmployeeTimeEntryApprovalProjectId As ArrayList)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim strHeader As String = "<td align=" & "center" & ">" & ("Employee Name" & "</td>" & "<td align=" & "center" & ">" & "Timesheet Period" & "</td>" & "<td align=" & "center" & ">" & "Total Billable Hours" & "</td>" & "<td align=" & "center" & ">" & "Non Billable Hours" & "</td>" & "<td align=" & "center" & ">" & "Total Hours" & "</td>" & "<td align=" & "center" & ">" & "Submitted Date" & "</td>")
        Dim strBody As String = ""
        Dim dtPendingApprovals As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingApprovalForEmailWithPreferenceDataTable = BLL.GetApprovalEntriesForSendingEmailByApproverEmployeeId(ApproverEmployeeId)
        If dtPendingApprovals.Rows.Count > 0 Then
            Dim drPendingApprovals As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingApprovalForEmailWithPreferenceRow = dtPendingApprovals.Rows(0)
            For Each drPendingApprovals In dtPendingApprovals.Rows

                Dim CultureName As String = drPendingApprovals.CultureInfoName
                Dim StartDate As Date = drPendingApprovals.TimeEntryStartDate
                Dim EndDate As Date = drPendingApprovals.TimeEntryEndDate
                Dim SubmittedDate As Date
                If Not IsDBNull(drPendingApprovals.Item("SubmittedDate")) Then
                    SubmittedDate = drPendingApprovals.Item("SubmittedDate")
                Else
                    SubmittedDate = StartDate
                End If
                strBody = strBody & IIf(strBody = "", "", "<br/>") & "<tr>" & "<td>" & (drPendingApprovals.EmployeeName & "</td>" & "<td>" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(StartDate, CultureName) & " - " & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(EndDate, CultureName) & "</td>" & "<td align=" & "center" & ">" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(drPendingApprovals.Item("BillableTotalMinutes")) & "</td>" & "<td align=" & "center" & ">" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(drPendingApprovals.Item("NonBillableTotalMinutes")) & "</td>" & "<td align=" & "center" & " ; " & "valign=" & "middle" & ">" & "<b>" & DBUtilities.GetDateTimeOfMinutesAsStringForEmail(drPendingApprovals.Item("TotalMinutes")) & "</b>" & "</td>" & "<td align=" & "center" & ">" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(SubmittedDate, CultureName) & "</td>" & "</tr>")
                AccountEmployeeTimeEntryApprovalProjectId.Add(drPendingApprovals.Item("AccountEmployeeTimeEntryApprovalProjectId"))
            Next
            EMailUtilities.SendEMail("Timesheet approvals are due", "TimesheetPendingTemplate", GetPreparedEMailMessageForPendingTimeSheet(strBody, strHeader), drPendingApprovals.Item("ApproverEMailAddress"), , , EMailUtilities.TIMESHEET_APPROVAL_PENDING_NOTIFICATION_INFORMATION_FROM)

        End If
    End Sub
    ''' <summary>
    ''' Get Submitted TimeEntries for sending email to their approval.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEntriesForSendingEmailByApproverEmployeeId(ByVal ApproverEmployeeId As Integer) As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingApprovalForEmailWithPreferenceDataTable
        Dim _vueTimesheetSummaryPendingApprovalForEmailWithPreferenceTableAdapter As New vueTimesheetSummaryPendingApprovalForEmailWithPreferenceTableAdapter
        Return _vueTimesheetSummaryPendingApprovalForEmailWithPreferenceTableAdapter.GetDataByApproverEmployeeIdAndIsEmalSend(ApproverEmployeeId)
    End Function
    ''' <summary>
    ''' Get Grouped ApproverEmployeeId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetGroupedApprovalEntriesForSendingEmailByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingApprovalForEmailWithPreferenceGroupedDataTable
        Dim _vueTimesheetSummaryPendingApprovalForEmailWithPreferenceGroupedTableAdapter As New vueTimesheetSummaryPendingApprovalForEmailWithPreferenceGroupedTableAdapter
        Return _vueTimesheetSummaryPendingApprovalForEmailWithPreferenceGroupedTableAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get Approved AccountEmployeeTimeEntryPeriod for sending approved email to approver.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedAccountEmployeeTimeEntryPeriodForEmailByPeriodIdToApprover(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
        Return AccountEmployeeTimeEntryPeriodAdapter.GetApprovedEmailToApproverByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get Rejected AccountEmployeeTimeEntryPeriod for sending approved email to approver.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedAccountEmployeeTimeEntryPeriodForEmailByPeriodIdToApprover(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
        Return AccountEmployeeTimeEntryPeriodAdapter.GetRejectedEmailToApproverByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Send timesheet overdue notification email. Create table for Administrator, Employee manager, Project manager, Team lead or employee own.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="PendingEmailType"></param>
    ''' <param name="CultureInfoName"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetOverdueNotification(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal EmailAddress As String, ByVal PendingEmailType As String, ByVal CultureInfoName As String, ByVal UserCurrentDateTime As DateTime)
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim strTable As String = ""
        Dim SystemTimesheetPeriodType As String = ""
        Dim AccountWorkingDayType As String = ""
        Dim WorkingDaysArray As ArrayList
        Dim TimesheetPeriodDaysArray As ArrayList
        Dim TimeEntryStartDate As Date = UserCurrentDateTime.Date
        Dim TimeEntryEndDate As Date = UserCurrentDateTime.Date
        Dim WeekStartDate As Date
        Dim starttime As DateTime = Now
        Dim dtEmployees As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetEmployeesDataTableForTimeEntryPendingEmail(AccountId, AccountEmployeeId, PendingEmailType, True)
        Dim drEmployees As AccountEmployee.vueAccountEmployeeRow
        If dtEmployees.Rows.Count > 0 Then
            drEmployees = dtEmployees.Rows(0)
            For Each drEmployees In dtEmployees.Rows
                Dim TimesheetOverduePeriods As Short = IIf(IsDBNull(drEmployees.Item("TimesheetOverduePeriods")), 4, drEmployees.Item("TimesheetOverduePeriods"))
                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.AccountEmployeeId, UserCurrentDateTime.Date, UserCurrentDateTime.Date, UserCurrentDateTime.Date, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                TimeEntryStartDate = TimesheetPeriodDaysArray(0)
                TimeEntryEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
                For i As Integer = 0 To TimesheetOverduePeriods - 1
                    TimeEntryStartDate = TimeEntryStartDate.AddDays(-1)
                    SystemTimesheetPeriodType = IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly")
                    WorkingDaysArray = DateTimeUtilities.GetWorkingDays(drEmployees.AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate, True, SystemTimesheetPeriodType, IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                    If WorkingDaysArray.Count > 0 Then
                        If CheckCreatedDateForPreviousPeriod(WorkingDaysArray, drEmployees.CreatedOn) = True Then
                            TimeEntryStartDate = WorkingDaysArray(0)
                            TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
                            SystemTimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, SystemTimesheetPeriodType)
                            TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate, True, SystemTimesheetPeriodType, IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                            Dim TimesheetStatus As String = CheckOverDuePeriodsAndGetPeriodStatus(drEmployees.AccountId, drEmployees.AccountEmployeeId, SystemTimesheetPeriodType, TimesheetPeriodDaysArray)
                            If TimesheetStatus = "Not Submitted" Or TimesheetStatus = "Rejected" Then
                                LoggingBLL.WriteToLog("SendTimesheetOverdueNotification:WorkingDaysArrayStartDate = " & TimeEntryStartDate & " WorkingDaysArrayEndDate = " & TimeEntryEndDate & "AccountEmployeeId=" & drEmployees.AccountEmployeeId & " " & PendingEmailType)
                                strTable = strTable & "<table border=1 width=100%> "
                                strTable = strTable & CreateStringOfWorkingDaysInHTMLFormatForEmail(WorkingDaysArray, CultureInfoName, True)
                                Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = Me.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(drEmployees.AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                                strTable = strTable & CreateStringOfTimeEntryHoursInHTMLFormatForEmail(WorkingDaysArray, dtEmployeesWithTimeEntry, drEmployees.EmployeeName, True, drEmployees.MinimumHoursPerWeek, TimesheetStatus)
                                strTable = strTable & "</table> <br/> "
                            End If
                        End If
                    End If
                    If WorkingDaysArray.Count = 0 Then
                        Dim dtdate As Date = TimeEntryStartDate.AddDays(-1)
                        TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.AccountEmployeeId, dtdate, dtdate, dtdate, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                        TimeEntryStartDate = TimesheetPeriodDaysArray(0)
                    End If
                Next
            Next
            Dim endtime As DateTime = Now
            Dim a As Double = (endtime - starttime).TotalSeconds
            If strTable <> "" Then
                EMailUtilities.SendEMail(GetTimesheetOverdueSubjectByEmail(PendingEmailType), "TimesheetOverdueTemplate", GetPreparedEMailMessageForTimesheetOverdue(strTable, PendingEmailType), EmailAddress, , , GetTimesheetOverdueNotificationInformationForm(PendingEmailType))
            End If
        End If
    End Sub
    Public Function CheckCreatedDateForPreviousPeriod(WorkingDaysArray As ArrayList, CreatedDate As DateTime) As Boolean
        For n As Integer = 0 To WorkingDaysArray.Count - 1
            If WorkingDaysArray(n) >= CreatedDate.Date Then
                Return True
            End If
        Next
    End Function
    ''' <summary>
    ''' get timeentryperiod and return period status
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="SystemTimesheetPeriodType"></param>
    ''' <param name="TimesheetPeriodDaysArray"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckOverDuePeriodsAndGetPeriodStatus(AccountId As Integer, AccountEmployeeId As Integer, SystemTimesheetPeriodType As String, TimesheetPeriodDaysArray As ArrayList)
        Dim dtStartDate As Date = TimesheetPeriodDaysArray(0)
        Dim dtEndDate As Date = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, dtStartDate, dtEndDate, SystemTimesheetPeriodType)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.Submitted = False And dr.Rejected = False And dr.Approved = False And dr.InApproval = False Then
                Return "Not Submitted"
            ElseIf dr.Submitted = True And dr.Approved = True And dr.Rejected = False Then
                Return "Approved"
            ElseIf dr.Rejected = True And dr.Submitted = False Then
                Return "Rejected"
            ElseIf dr.Submitted = True And dr.Rejected = False And dr.Approved = False And dr.InApproval = True Then
                Return "Submitted"
            ElseIf dr.Submitted = True And dr.Rejected = False And dr.Approved = False And dr.InApproval = False Then
                Return "Submitted"
            ElseIf dr.Submitted = False And dr.Approved = True Then
                Return "Not Submitted"
            ElseIf dr.Submitted = False And dr.InApproval = True Then
                Return "Not Submitted"
            ElseIf dr.Submitted = True And dr.Rejected = True And dr.Approved = False And dr.InApproval = True Then
                Return "Rejected"
            Else
                Return "Not Submitted"
            End If
        Else
            Return "Not Submitted"
        End If
    End Function
    ''' <summary>
    ''' Prepared EMail Message For Timesheet Overdue
    ''' </summary>
    ''' <param name="strTable"></param>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForTimesheetOverdue(ByVal strTable As String, PendingEmailType As String) As StringDictionary
        Dim dict As New StringDictionary
        dict.Add("[strtable]", strTable)
        dict.Add("[strheader]", GetHEADERForTimesheetOverdueTemplate(PendingEmailType))
        Return dict
    End Function
    ''' <summary>
    ''' get header string for timesheet overdue template.
    ''' </summary>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHEADERForTimesheetOverdueTemplate(PendingEmailType As String) As String
        If PendingEmailType = "Administrator" Then
            Return "The following timesheets are overdue for Administrator:"
        ElseIf PendingEmailType = "ProjectManager" Then
            Return "The following timesheets are overdue for Project Manager:"
        ElseIf PendingEmailType = "TeamLead" Then
            Return "The following timesheets are overdue for Team Lead:"
        ElseIf PendingEmailType = "EmployeeManager" Then
            Return "The following timesheets are overdue for Employee Manager:"
        ElseIf PendingEmailType = "EmployeeOwn" Then
            Return "Your following timesheets are overdue:"
        End If
    End Function
    ''' <summary>
    ''' Get Timesheet Overdue With Preference
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetOverdueWithPreference() As AccountEmployeeTimeEntry.vueTimesheetOverdueNotificationWithPreferenceDataTable
        Dim _vueTimesheetOverdueNotificationWithPreferenceTableAdapter As New vueTimesheetOverdueNotificationWithPreferenceTableAdapter
        Return _vueTimesheetOverdueNotificationWithPreferenceTableAdapter.GetData
    End Function
    ''' <summary>
    ''' Check employee timesheet overdue.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="UserCurrentDateTime"></param>
    ''' <param name="TimesheetOverdueAfterDays"></param>
    ''' <param name="SystemTimesheetPeriodType"></param>
    ''' <param name="EmployeeWeekStartDay"></param>
    ''' <param name="SystemInitialDayOfFirstPeriod"></param>
    ''' <param name="SystemInitialDayOfLastPeriod"></param>
    ''' <param name="InitialDayOfTheMonth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsCurrentTimesheetOverdue(AccountEmployeeId As Integer, UserCurrentDateTime As Date, TimesheetOverdueAfterDays As Short, SystemTimesheetPeriodType As String, EmployeeWeekStartDay As Integer, SystemInitialDayOfFirstPeriod As Integer, SystemInitialDayOfLastPeriod As Integer, InitialDayOfTheMonth As Integer) As Boolean
        Dim WorkingDaysArray As ArrayList
        WorkingDaysArray = Me.GetWorkingDays(AccountEmployeeId, UserCurrentDateTime.Date, UserCurrentDateTime.Date, UserCurrentDateTime.Date, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
        If WorkingDaysArray.Count > 0 Then
            Dim dtdate As Date = WorkingDaysArray(WorkingDaysArray.Count - 1)
            dtdate = dtdate.AddDays(TimesheetOverdueAfterDays)
            If UserCurrentDateTime.Date = dtdate.Date Then
                Return True
            ElseIf UserCurrentDateTime.Date < dtdate.Date Then
                dtdate = WorkingDaysArray(0)
                dtdate = dtdate.AddDays(-1)
                WorkingDaysArray = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, dtdate, dtdate, dtdate, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
                If WorkingDaysArray.Count > 0 Then
                    dtdate = WorkingDaysArray(WorkingDaysArray.Count - 1)
                    dtdate = dtdate.AddDays(TimesheetOverdueAfterDays)
                    If UserCurrentDateTime.Date = dtdate.Date Then
                        Return True
                    End If
                End If
            End If
        End If
    End Function
    Public Function GetWorkingDays(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, Optional ByVal ForEmail As Boolean = False, Optional ByVal SystemTimesheetPeriodType As String = "", _
    Optional ByVal EmployeeWeekStartDay As Integer = 0, Optional ByVal SystemInitialDayOfFirstPeriod As Integer = 0, Optional ByVal SystemInitialDayOfLastPeriod As Integer = 0, Optional ByVal InitialDayOfTheMonth As Integer = 0) As ArrayList
        Dim WorkingDaysArray As ArrayList
        Dim dtedate As Date = Now.Date
        WorkingDaysArray = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, dtedate, dtedate, dtedate, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
        If SystemTimesheetPeriodType = "Daily" And WorkingDaysArray.Count = 0 Then
            For n As Integer = 0 To 6
                dtedate = dtedate.AddDays(-1)
                WorkingDaysArray = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, dtedate, dtedate, dtedate, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
                If WorkingDaysArray.Count > 0 Then
                    Return WorkingDaysArray
                End If
            Next
        End If
        Return WorkingDaysArray
    End Function
    ''' <summary>
    ''' Get Timesheet Overdue With Preference for Administrator
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetOverdueWithPreferenceForAdministrator() As AccountEmployeeTimeEntry.vueTimesheetOverdueNotificationWithPreferenceForAdministratorDataTable
        Dim _vueTimesheetOverdueNotificationWithPreferenceForAdministratorTableAdapter As New vueTimesheetOverdueNotificationWithPreferenceForAdministratorTableAdapter
        Return _vueTimesheetOverdueNotificationWithPreferenceForAdministratorTableAdapter.GetData
    End Function
    ''' <summary>
    ''' Get Timesheet Overdue With Preference for Employee Manager
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetOverdueWithPreferenceForEmployeeManager() As AccountEmployeeTimeEntry.vueTimesheetOverdueNotificationWithPreferenceForEmployeeManagerDataTable
        Dim _vueTimesheetOverdueNotificationWithPreferenceForEmployeeManagerTableAdapter As New vueTimesheetOverdueNotificationWithPreferenceForEmployeeManagerTableAdapter
        Return _vueTimesheetOverdueNotificationWithPreferenceForEmployeeManagerTableAdapter.GetData
    End Function
    ''' <summary>
    ''' Get Timesheet Overdue With Preference for Project manager
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetOverdueWithPreferenceForProjectManager() As AccountEmployeeTimeEntry.vueTimesheetOverdueNotificationWithPreferenceForProjectManagerDataTable
        Dim _vueTimesheetOverdueNotificationWithPreferenceForProjectManagerTableAdapter As New vueTimesheetOverdueNotificationWithPreferenceForProjectManagerTableAdapter
        Return _vueTimesheetOverdueNotificationWithPreferenceForProjectManagerTableAdapter.GetData
    End Function
    ''' <summary>
    ''' Get Timesheet Overdue With Preference for Team Lead
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetOverdueWithPreferenceForTeamLead() As AccountEmployeeTimeEntry.vueTimesheetOverdueNotificationWithPreferenceForTeamLeadDataTable
        Dim _vueTimesheetOverdueNotificationWithPreferenceForTeamLeadTableAdapter As New vueTimesheetOverdueNotificationWithPreferenceForTeamLeadTableAdapter
        Return _vueTimesheetOverdueNotificationWithPreferenceForTeamLeadTableAdapter.GetData
    End Function
    ''' <summary>
    ''' Get timesheet overdue email subject by emailtype.
    ''' </summary>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTimesheetOverdueSubjectByEmail(ByVal PendingEmailType As String) As String
        If PendingEmailType = "Administrator" Then
            Return "Timesheets are overdue for Administrator"
        ElseIf PendingEmailType = "ProjectManager" Then
            Return "Timesheets are overdue for Project Manager"
        ElseIf PendingEmailType = "TeamLead" Then
            Return "Timesheets are overdue for Team Lead"
        ElseIf PendingEmailType = "EmployeeManager" Then
            Return "Timesheets are overdue for Employee Manager"
        ElseIf PendingEmailType = "EmployeeOwn" Then
            Return "Timesheets are overdue"
        End If
    End Function
    ''' <summary>
    ''' Get timesheet overdue email Information Form by emailtype.
    ''' </summary>
    ''' <param name="PendingEmailType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTimesheetOverdueNotificationInformationForm(ByVal PendingEmailType As String) As String
        If PendingEmailType = "Administrator" Then
            Return EMailUtilities.TIMESHEET_OVERDUE_NOTIFICATION_INFORMATION_FORM_FOR_ADMINISTRATOR
        ElseIf PendingEmailType = "ProjectManager" Then
            Return EMailUtilities.TIMESHEET_OVERDUE_NOTIFICATION_INFORMATION_FORM_FOR_PROJECT_MANAGER
        ElseIf PendingEmailType = "TeamLead" Then
            Return EMailUtilities.TIMESHEET_OVERDUE_NOTIFICATION_INFORMATION_FORM_FOR_TEAM_LEAD
        ElseIf PendingEmailType = "EmployeeManager" Then
            Return EMailUtilities.TIMESHEET_OVERDUE_NOTIFICATION_INFORMATION_FORM_FOR_EMPLOYEE_MANAGER
        ElseIf PendingEmailType = "EmployeeOwn" Then
            Return EMailUtilities.TIMESHEET_OVERDUE_NOTIFICATION_INFORMATION_FORM
        End If
    End Function
    ''' <summary>
    ''' Send timesheet due notification email. Create table for Administrator, Employee manager, Project manager, Team lead or employee own.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="EmployeeName"></param>
    ''' <param name="EmailAddress"></param>
    ''' <param name="PendingEmailType"></param>
    ''' <param name="CultureInfoName"></param>
    ''' <remarks></remarks>
    Public Sub SendTimesheetdueNotification(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, _
                                            ByVal EmployeeName As String, ByVal EmailAddress As String, _
                                            ByVal CultureInfoName As String, _
                                            ByVal SystemTimesheetPeriodType As String, ByVal EmployeeWeekStartDay As Integer, _
                                            ByVal SystemInitialDayOfFirstPeriod As Integer, ByVal SystemInitialDayOfLastPeriod As Integer, _
                                            ByVal InitialDayOfTheMonth As Integer, ByVal TimesheetOverduePeriods As Short, ByVal MinimumHoursPerWeek As Double, ByVal UserCurrentDateTime As DateTime)
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim strTable As String = ""
        Dim WorkingDaysArray As ArrayList
        Dim TimesheetPeriodDaysArray As ArrayList
        Dim TimeEntryStartDate As Date = UserCurrentDateTime.Date
        Dim TimeEntryEndDate As Date = UserCurrentDateTime.Date
        Dim WeekStartDate As Date
        WorkingDaysArray = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
        Dim starttime As DateTime = Now
        If WorkingDaysArray.Count > 0 Then
            TimeEntryStartDate = WorkingDaysArray(0)
            TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
            TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
            Dim TimesheetStatus As String = CheckOverDuePeriodsAndGetPeriodStatus(AccountId, AccountEmployeeId, SystemTimesheetPeriodType, TimesheetPeriodDaysArray)
            If TimesheetStatus = "Not Submitted" Or TimesheetStatus = "Rejected" Then
                LoggingBLL.WriteToLog("SendTimesheetdueNotification:WorkingDaysArrayStartDate = " & TimeEntryStartDate & " WorkingDaysArrayEndDate = " & TimeEntryEndDate & "AccountEmployeeId=" & AccountEmployeeId)
                strTable = strTable & "<table border=1 width=100%> "
                strTable = strTable & CreateStringOfWorkingDaysInHTMLFormatForEmail(WorkingDaysArray, CultureInfoName, True)
                Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = Me.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                strTable = strTable & CreateStringOfTimeEntryHoursInHTMLFormatForEmail(WorkingDaysArray, dtEmployeesWithTimeEntry, EmployeeName, True, MinimumHoursPerWeek, TimesheetStatus)
                strTable = strTable & "</table> <br/> "
            End If

            Dim endtime As DateTime = Now
            Dim a As Double = (endtime - starttime).TotalSeconds
            If strTable <> "" Then
                EMailUtilities.SendEMail("Your timesheet is due", "TimesheetDueTemplate", GetPreparedEMailMessageForTimesheetdue(strTable, TimeEntryStartDate, TimeEntryEndDate), EmailAddress, , , "Timesheet is due")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Prepared EMail Message For Timesheet due
    ''' </summary>
    ''' <param name="strTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForTimesheetdue(ByVal strTable As String, TimeEntryStartDate As Date, TimeEntryEndDate As Date) As StringDictionary
        Dim dict As New StringDictionary
        dict.Add("[strtable]", strTable)
        dict.Add("[strperiod]", TimeEntryStartDate.ToLongDateString & " to " & TimeEntryEndDate.ToLongDateString)
        Return dict
    End Function
    ''' <summary>
    ''' Get Timesheet Due Notification Email With Preference.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetDueNotificationEmailWithPreference() As AccountEmployeeTimeEntry.vueTimesheetDueNotificationEmailWithPreferenceDataTable
        Dim _vueTimesheetDueNotificationEmailWithPreferenceTableAdapter As New vueTimesheetDueNotificationEmailWithPreferenceTableAdapter
        Return _vueTimesheetDueNotificationEmailWithPreferenceTableAdapter.GetData
    End Function
    ''' <summary>
    ''' Check employee current timesheet due then return true.
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="UserCurrentDateTime"></param>
    ''' <param name="SystemTimesheetPeriodType"></param>
    ''' <param name="EmployeeWeekStartDay"></param>
    ''' <param name="SystemInitialDayOfFirstPeriod"></param>
    ''' <param name="SystemInitialDayOfLastPeriod"></param>
    ''' <param name="InitialDayOfTheMonth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsCurrentTimesheetdue(AccountEmployeeId As Integer, UserCurrentDateTime As Date, SystemTimesheetPeriodType As String, EmployeeWeekStartDay As Integer, SystemInitialDayOfFirstPeriod As Integer, SystemInitialDayOfLastPeriod As Integer, InitialDayOfTheMonth As Integer) As Boolean
        Dim WorkingDaysArray As ArrayList
        WorkingDaysArray = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, UserCurrentDateTime.Date, UserCurrentDateTime.Date, UserCurrentDateTime.Date, True, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth)
        If WorkingDaysArray.Count > 0 Then
            Dim dtdate As Date = WorkingDaysArray(WorkingDaysArray.Count - 1)
            If UserCurrentDateTime.Date = dtdate.Date Then
                Return True
            End If
        End If
    End Function
    Public Sub UpdateCustomFieldInTimeEntry(CustomFieldColumnName As String, ByVal AccountId As Integer)
        Adapter.UpdateTimeEntryCustomFieldByCustomFieldId(CustomFieldColumnName, AccountId)
    End Sub
    Public Function GetMissingTimeEntryPeriodReport(MissingPeriodReportWhereClause As String, MissingPeriodReportStartAndEndDate As Hashtable, WhereClause As String) As DataTable
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtMissing As New DataTable
        AddColumnForMissingTimeEntryReport(dtMissing)
        Dim TimesheetPeriodDaysArray As ArrayList
        Dim TimeEntryStartDate As Date = Now.Date
        Dim TimeEntryEndDate As Date = Now.Date
        Dim SearchStartDate As Date
        Dim SearchEndDate As Date
        If MissingPeriodReportStartAndEndDate.Count = 2 Then
            SearchStartDate = MissingPeriodReportStartAndEndDate("TimeEntryStartDate")
            SearchEndDate = MissingPeriodReportStartAndEndDate("TimeEntryEndDate")
        End If
        Dim dtDate As Date = SearchEndDate
        If (Not WhereClause.Contains("(Approved = 1)") AndAlso Not WhereClause.Contains("(Submitted = 1)")) Then
            Dim dtEmployees As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetvueAccountEmployeeForReportByWhereClause(IIf(MissingPeriodReportWhereClause <> "", " Where ", "") & MissingPeriodReportWhereClause)
            Dim drEmployees As AccountEmployee.vueAccountEmployeeRow
            For Each drEmployees In dtEmployees.Rows
                Dim TimeEntryViewType As String = IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly")
                dtDate = SearchEndDate
                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.AccountEmployeeId, SearchEndDate, SearchEndDate, SearchEndDate, True, TimeEntryViewType, IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                TimeEntryStartDate = TimesheetPeriodDaysArray(0)
                TimeEntryEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
                Dim dtPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByTimeEntryDateAndTimeEntryView(drEmployees.AccountId, drEmployees.AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"))
                Dim drPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
                If dtPeriod.Rows.Count = 0 Then
                    AddColumnValueForMissingTimeEntryReport(dtMissing, drEmployees.AccountEmployeeId, drEmployees.EmployeeName, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType, IIf(Not IsDBNull(drEmployees.Item("AccountLocation")), drEmployees.Item("AccountLocation"), ""), IIf(Not IsDBNull(drEmployees.Item("EmployeeCode")), drEmployees.Item("EmployeeCode"), ""), IIf(Not IsDBNull(drEmployees.Item("Role")), drEmployees.Item("Role"), ""), drEmployees.EMailAddress, IIf(Not IsDBNull(drEmployees.Item("DepartmentName")), drEmployees.Item("DepartmentName"), ""), IIf(Not IsDBNull(drEmployees.Item("MinimumHoursPerDay")), drEmployees.Item("MinimumHoursPerDay"), 0), IIf(Not IsDBNull(drEmployees.Item("MaximumHoursPerDay")), drEmployees.Item("MaximumHoursPerDay"), 0), IIf(Not IsDBNull(drEmployees.Item("MaximumHoursPerWeek")), drEmployees.Item("MaximumHoursPerWeek"), 0), IIf(Not IsDBNull(drEmployees.Item("MinimumHoursPerWeek")), drEmployees.Item("MinimumHoursPerWeek"), 0), IIf(Not IsDBNull(drEmployees.Item("HoursPerDay")), drEmployees.Item("HoursPerDay"), 0), IIf(Not IsDBNull(drEmployees.Item("HiredDate")), drEmployees.Item("HiredDate"), #1/1/1900#))
                End If
                dtDate = TimeEntryStartDate.AddDays(-1)
                Do While TimesheetPeriodDaysArray.Contains(SearchStartDate) = False
                    TimeEntryViewType = IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly")
                    TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.AccountEmployeeId, dtDate, dtDate, dtDate, True, TimeEntryViewType, IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.SystemInitialDayOfFirstPeriod, drEmployees.SystemInitialDayOfLastPeriod, drEmployees.InitialDayOfTheMonth)
                    TimeEntryStartDate = TimesheetPeriodDaysArray(0)
                    TimeEntryEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
                    dtPeriod = AccountEmployeeTimeEntryPeriodAdapter.GetDataByTimeEntryDateAndTimeEntryView(drEmployees.AccountId, drEmployees.AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"))
                    If dtPeriod.Rows.Count = 0 Then
                        AddColumnValueForMissingTimeEntryReport(dtMissing, drEmployees.AccountEmployeeId, drEmployees.EmployeeName, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType, IIf(Not IsDBNull(drEmployees.Item("AccountLocation")), drEmployees.Item("AccountLocation"), ""), IIf(Not IsDBNull(drEmployees.Item("EmployeeCode")), drEmployees.Item("EmployeeCode"), ""), IIf(Not IsDBNull(drEmployees.Item("Role")), drEmployees.Item("Role"), ""), drEmployees.EMailAddress, IIf(Not IsDBNull(drEmployees.Item("DepartmentName")), drEmployees.Item("DepartmentName"), ""), IIf(Not IsDBNull(drEmployees.Item("MinimumHoursPerDay")), drEmployees.Item("MinimumHoursPerDay"), 0), IIf(Not IsDBNull(drEmployees.Item("MaximumHoursPerDay")), drEmployees.Item("MaximumHoursPerDay"), 0), IIf(Not IsDBNull(drEmployees.Item("MaximumHoursPerWeek")), drEmployees.Item("MaximumHoursPerWeek"), 0), IIf(Not IsDBNull(drEmployees.Item("MinimumHoursPerWeek")), drEmployees.Item("MinimumHoursPerWeek"), 0), IIf(Not IsDBNull(drEmployees.Item("HoursPerDay")), drEmployees.Item("HoursPerDay"), 0), IIf(Not IsDBNull(drEmployees.Item("HiredDate")), drEmployees.Item("HiredDate"), #1/1/1900#))
                    End If
                    dtDate = TimeEntryStartDate.AddDays(-1)
                Loop
            Next
        End If
        Return dtMissing
    End Function
    Public Sub AddColumnValueForMissingTimeEntryReport(dt As DataTable, AccountEmployeeId As Integer, EmployeeName As String, StartDate As Date, EndDate As Date, _
                                                       TimeEntryViewType As String, AccountLocation As String, EmployeeCode As String, _
                                                       Role As String, EMailAddress As String, DepartmentName As String, MinimumHoursPerDay As Double, _
                                                       MaximumHoursPerDay As Double, MaximumHoursPerWeek As Double, MinimumHoursPerWeek As Double, _
                                                       HoursPerDay As Double, Optional ByVal HiredDate As Date = #1/1/1900#)
        Dim objRow As DataRow
        objRow = dt.NewRow()
        'objRow("AccountEmployeeId") = AccountEmployeeId
        objRow("EmployeeName") = EmployeeName
        objRow("TimeEntryStartDate") = StartDate
        objRow("TimeEntryEndDate") = EndDate
        objRow("Submitted") = False
        objRow("Approved") = False
        objRow("Rejected") = False
        objRow("InApproval") = False
        objRow("ApprovalStatus") = "Not Submitted"
        objRow("TotalHours") = 0
        objRow("Amount") = 0
        'objRow("BaseCurrencyAmount") = 0
        objRow("TimesheetHours") = 0
        objRow("TimeOffHours") = 0
        objRow("SubmittedHours") = 0
        objRow("ApprovedHours") = 0
        objRow("RejectedHours") = 0
        objRow("Percentage") = 0
        objRow("BillableTotalHours") = 0
        objRow("MinimumHoursPerDay") = MinimumHoursPerDay
        objRow("MaximumHoursPerDay") = MaximumHoursPerDay
        objRow("MaximumHoursPerWeek") = MaximumHoursPerWeek
        objRow("MinimumHoursPerWeek") = MinimumHoursPerWeek
        objRow("HoursPerDay") = HoursPerDay
        objRow("BillingRate") = 0
        objRow("CurrencyAmount") = 0
        'objRow("FormulaField3") = 0
        'objRow("FormulaField5") = 0
        'objRow("FormulaField2") = 0
        'objRow("FormulaField1") = 0
        'objRow("FormulaField4") = 0
        objRow("TimeEntryViewType") = TimeEntryViewType
        objRow("AccountLocation") = AccountLocation
        objRow("EmployeeCode") = EmployeeCode
        objRow("Role") = Role
        objRow("EMailAddress") = EMailAddress
        objRow("DepartmentName") = DepartmentName
        If HiredDate <> "#1/1/1900#" Then
            objRow("HiredDate") = HiredDate
        End If
        dt.Rows.Add(objRow)
    End Sub
    Public Sub AddColumnForMissingTimeEntryReport(dt As DataTable)
        'dt.Columns.Add("AccountEmployeeId", GetType(Integer))
        dt.Columns.Add("EmployeeName", GetType(String))
        dt.Columns.Add("TimeEntryStartDate", GetType(Date))
        dt.Columns.Add("TimeEntryEndDate", GetType(Date))
        dt.Columns.Add("Submitted", GetType(Boolean))
        dt.Columns.Add("Approved", GetType(Boolean))
        dt.Columns.Add("Rejected", GetType(Boolean))
        dt.Columns.Add("InApproval", GetType(Boolean))
        dt.Columns.Add("ApprovalStatus", GetType(String))
        dt.Columns.Add("TotalHours", GetType(Double))
        dt.Columns.Add("Amount", GetType(Decimal))
        'dt.Columns.Add("BaseCurrencyAmount", GetType(Decimal))
        dt.Columns.Add("TimesheetHours", GetType(Double))
        dt.Columns.Add("TimeOffHours", GetType(Double))
        dt.Columns.Add("SubmittedHours", GetType(Double))
        dt.Columns.Add("ApprovedHours", GetType(Double))
        dt.Columns.Add("RejectedHours", GetType(Double))
        dt.Columns.Add("Percentage", GetType(Integer))
        dt.Columns.Add("MinimumHoursPerDay", GetType(Double))
        dt.Columns.Add("BillableTotalHours", GetType(Double))
        dt.Columns.Add("MaximumHoursPerDay", GetType(Double))
        dt.Columns.Add("MaximumHoursPerWeek", GetType(Double))
        dt.Columns.Add("MinimumHoursPerWeek", GetType(Double))
        dt.Columns.Add("HoursPerDay", GetType(Double))
        dt.Columns.Add("BillingRate", GetType(Decimal))
        dt.Columns.Add("CurrencyAmount", GetType(Double))
        'dt.Columns.Add("FormulaField3", GetType(Decimal))
        'dt.Columns.Add("FormulaField5", GetType(Decimal))
        'dt.Columns.Add("FormulaField2", GetType(Decimal))
        'dt.Columns.Add("FormulaField1", GetType(Decimal))
        'dt.Columns.Add("FormulaField4", GetType(Decimal))
        dt.Columns.Add("TimeEntryViewType", GetType(String))
        dt.Columns.Add("AccountLocation", GetType(String))
        dt.Columns.Add("EmployeeCode", GetType(String))
        dt.Columns.Add("Role", GetType(String))
        dt.Columns.Add("EMailAddress", GetType(String))
        dt.Columns.Add("DepartmentName", GetType(String))
        dt.Columns.Add("HiredDate", GetType(Date))
    End Sub
    Public Function GetTimeEntryPeriodicSubmissionReport(dtEmployees As DataTable, MissingPeriodReportStartAndEndDate As Hashtable) As DataTable
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim SystemTimesheetPeriodType As String = ""
        Dim dtMissing As New DataTable
        Dim WorkingDaysArray As ArrayList
        Dim TimesheetPeriodDaysArray As ArrayList
        Dim TimeEntryStartDate As Date = Now.Date
        Dim TimeEntryEndDate As Date = Now.Date
        Dim SearchStartDate As Date
        Dim SearchEndDate As Date
        If MissingPeriodReportStartAndEndDate.Count = 2 Then
            SearchStartDate = MissingPeriodReportStartAndEndDate("TimeEntryStartDate")
            SearchEndDate = MissingPeriodReportStartAndEndDate("TimeEntryEndDate")
        End If
        Dim dtDate As Date = SearchEndDate
        Dim drEmployees As DataRow
        For Each drEmployees In dtEmployees.Rows
            Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = Me.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeId(drEmployees.Item("AccountEmployeeId"))
            dtDate = SearchEndDate
            TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.Item("AccountEmployeeId"), dtDate, dtDate, dtDate, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.Item("SystemInitialDayOfFirstPeriod"), drEmployees.Item("SystemInitialDayOfLastPeriod"), drEmployees.Item("InitialDayOfTheMonth"))
            WorkingDaysArray = DateTimeUtilities.GetWorkingDays(drEmployees.Item("AccountEmployeeId"), dtDate, dtDate, dtDate, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.Item("SystemInitialDayOfFirstPeriod"), drEmployees.Item("SystemInitialDayOfLastPeriod"), drEmployees.Item("InitialDayOfTheMonth"))
            If WorkingDaysArray.Count > 0 Then
                TimeEntryStartDate = WorkingDaysArray(0)
                TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
                If SystemTimesheetPeriodType <> drEmployees.Item("SystemTimesheetPeriodType") Or ((WorkingDaysArray.Count + 1) > dtMissing.Columns.Count) Then
                    AddColumnForTimeEntryPeriodicSubmissionReport(dtMissing, WorkingDaysArray)
                End If
                AddColumnValueForTimeEntryPeriodicSubmissionReport(dtMissing, WorkingDaysArray, dtEmployeesWithTimeEntry, drEmployees.Item("CultureInfoName"), drEmployees.Item("EmployeeName"))
            End If
            dtDate = TimesheetPeriodDaysArray(0).AddDays(-1)
            Do While TimesheetPeriodDaysArray.Contains(SearchStartDate) = False
                'SystemTimesheetPeriodType = IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly")
                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(drEmployees.Item("AccountEmployeeId"), dtDate, dtDate, dtDate, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.Item("SystemInitialDayOfFirstPeriod"), drEmployees.Item("SystemInitialDayOfLastPeriod"), drEmployees.Item("InitialDayOfTheMonth"))
                WorkingDaysArray = DateTimeUtilities.GetWorkingDays(drEmployees.Item("AccountEmployeeId"), dtDate, dtDate, dtDate, True, IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly"), IIf(Not IsDBNull(drEmployees.Item("EmployeeWeekStartDay")), drEmployees.Item("EmployeeWeekStartDay"), 1), drEmployees.Item("SystemInitialDayOfFirstPeriod"), drEmployees.Item("SystemInitialDayOfLastPeriod"), drEmployees.Item("InitialDayOfTheMonth"))
                If WorkingDaysArray.Count > 0 Then
                    TimeEntryStartDate = WorkingDaysArray(0)
                    TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
                    If (WorkingDaysArray.Count + 1) > dtMissing.Columns.Count Then
                        AddColumnForTimeEntryPeriodicSubmissionReport(dtMissing, WorkingDaysArray)
                    End If
                    AddColumnValueForTimeEntryPeriodicSubmissionReport(dtMissing, WorkingDaysArray, dtEmployeesWithTimeEntry, drEmployees.Item("CultureInfoName"), drEmployees.Item("EmployeeName"))
                End If
                dtDate = TimesheetPeriodDaysArray(0).AddDays(-1)
            Loop
            SystemTimesheetPeriodType = IIf(Not IsDBNull(drEmployees.Item("SystemTimesheetPeriodType")), drEmployees.Item("SystemTimesheetPeriodType"), "Weekly")
        Next
        Return dtMissing
    End Function
    Public Sub AddColumnForTimeEntryPeriodicSubmissionReport(dt As DataTable, WorkingDaysArray As ArrayList)
        If Not dt.Columns.Contains("EmployeeName") Then
            dt.Columns.Add("EmployeeName", GetType(String))
        End If
        For n As Integer = dt.Columns.Count + 1 To WorkingDaysArray.Count + 1
            dt.Columns.Add(n - 1, GetType(String))
        Next
    End Sub
    Public Sub AddColumnValueForTimeEntryPeriodicSubmissionReport(dt As DataTable, WorkingDaysArray As ArrayList, dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable, CultureInfoName As String, EmployeeName As String)
        Dim objRow As DataRow
        objRow = dt.NewRow
        Dim TotalHours As String = "00:00"
        Dim TotalMinutes As Integer = 0
        objRow("EmployeeName") = EmployeeName
        For n As Integer = 0 To WorkingDaysArray.Count - 1
            Dim DateHeader As String = LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDaysArray(n)) & " - " & LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocaleForEmail(WorkingDaysArray(n), CultureInfoName) & " - "
            Dim dr() As DataRow = dtEmployeesWithTimeEntry.Select("TimeEntryDate = '" & WorkingDaysArray(n) & "'")
            If dr.Length > 0 Then
                TotalMinutes = dr(0).Item("TotalMinutes")
            End If
            TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(TotalMinutes)
            objRow(n + 1) = DateHeader & TotalHours
            TotalMinutes = 0
        Next
        dt.Rows.Add(objRow)
    End Sub
    Public Function UpdateTimesheetApproval(ByVal TimeEntryAccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal AccountEmployeeId As Integer, ByVal EmailAddress As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal Comments As String, ByVal TotalMinutes As Integer, ByVal IsApproved As Boolean, ByVal IsRejected As Boolean) As Boolean
        Dim rowaffected As Boolean = 0
        If IsApproved = True Then
            Dim TLBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForTeamLeadApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInTeamLeadApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateApprovedInTeamLeadApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInTeamLeadApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForTeamLead(Date.Now, Comments, False, True, False, TLBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            Me.SendTimesheetApprovedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        Else
            Dim TLBatchId As Guid = System.Guid.NewGuid
            Adapter.UpdateTimesheetEntriesForTeamLeadApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInTeamLeadApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            Me.UpdateRejectedInTeamLeadApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForTeamLead(Date.Now, Comments, True, False, True, TLBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
            ''Me.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
            Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
            AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
        End If
        rowaffected = 1
        Return rowaffected
    End Function
    Public Sub UpdateEmployeeTimeOffHoursForTimeEntryArchiveForTimeOffRequest(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal TotalTime As String, ByVal IsTimeOffConsumed As Boolean, Optional ByVal AccountEmployeeTimeEntryId As Integer = 0, Optional ByVal PolicyExecutionType As String = "", Optional ByVal PolicyEarnResetAutidAction As String = "", Optional ByVal AuditSource As String = "", Optional ByVal AccountEmployeeTimeOffRequestId As Object = "")
        Dim HoursOff As Double
        Dim TimeOffrequestBLL As New AccountEmployeeTimeOffRequestBLL
        Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
        Dim dttimeoffrequest As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable = TimeOffrequestBLL.GetAccountEmployeeTimeOffRequestByEmployeeRequestId(AccountEmployeeTimeOffRequestId)
        Dim drtimeoffrequest As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow
        If dttimeoffrequest.Rows.Count > 0 Then
            drtimeoffrequest = dttimeoffrequest.Rows(0)
            If drtimeoffrequest.Approved = False Then
                HoursOff = drtimeoffrequest.HoursOff
            Else
                HoursOff = -drtimeoffrequest.HoursOff
            End If
            If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, HoursOff, PolicyExecutionType, PolicyEarnResetAutidAction, AuditSource) And AccountEmployeeTimeEntryId <> 0 Then
                Me.UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId, IsTimeOffConsumed)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get BillingMode By AccountClientId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <param name="AccountWorkTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function IsBillingModePerHour(ByVal AccountClientId As Integer) As Boolean
        Dim ClientBLL As New AccountPartyBLL
        Dim dtClient As TimeLiveDataSet.AccountPartyDataTable = ClientBLL.GetAccountPartiesByAccountPartyId(AccountClientId)
        Dim drClient As TimeLiveDataSet.AccountPartyRow
        If dtClient.Rows.Count > 0 Then
            drClient = dtClient.Rows(0)
            If Not IsDBNull(drClient.Item("FixedBidBillingMode")) Then
                If drClient.FixedBidBillingMode = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
        Return True
    End Function
    Public Function GetFixBidCost(ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer) As Double
        Dim ClientBLL As New AccountPartyBLL
        Dim ProjectBLl As New AccountProjectBLL
        Dim TaskBLL As New AccountProjectTaskBLL
        Dim dtClient As TimeLiveDataSet.AccountPartyDataTable = ClientBLL.GetAccountPartiesByAccountPartyId(AccountClientId)
        Dim drClient As TimeLiveDataSet.AccountPartyRow
        If dtClient.Rows.Count > 0 Then
            drClient = dtClient.Rows(0)
            If Not IsDBNull(drClient.Item("FixedBidBillingMode")) Then
                If drClient.FixedBidBillingMode = 1 Then
                    Return drClient.FixedCost
                ElseIf drClient.FixedBidBillingMode = 2 Then
                    Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLl.GetAccountProjectsByAccountProjectId(AccountProjectId)
                    Dim drProject As TimeLiveDataSet.AccountProjectRow
                    If dtProject.Rows.Count > 0 Then
                        drProject = dtProject.Rows(0)
                        Return drProject.FixedCost
                    End If
                ElseIf drClient.FixedBidBillingMode = 3 Then
                    Dim dtTask As TimeLiveDataSet.AccountProjectTaskDataTable = TaskBLL.GetAccountProjectTasksByAccountProjectTaskId(AccountProjectTaskId)
                    Dim drTask As TimeLiveDataSet.AccountProjectTaskRow
                    If dtTask.Rows.Count > 0 Then
                        drTask = dtTask.Rows(0)
                        Return drTask.FixedCost
                    End If
                End If
            End If
        End If

    End Function
    Public Function UpdateTimeEntryClientRecord(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As String, ByVal TimeEntryEndDate As String)
        Me.Adapter.UpdateTimeEntryClientRecord(DBUtilities.GetSessionAccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForTimeEntryApproval(ByVal ApproverEmployeeId As Integer) As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingForApprovalOnlyEmployeesDataTable
        Dim _vueTimesheetSummaryPendingForApprovalOnlyEmployeesTableAdapter As New vueTimesheetSummaryPendingForApprovalOnlyEmployeesTableAdapter
        Return _vueTimesheetSummaryPendingForApprovalOnlyEmployeesTableAdapter.GetDataByApproverEmployeeId(ApproverEmployeeId)
    End Function
    ''' <summary>
    ''' Delete records from approval project if exists. if project is deleted from timeentry.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub DeleteApprovalProjectIfNotExistInAccountEmployeeTimeEntry(ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        AccountEmployeeTimeEntryApprovalProjectAdapter.DeleteApprovalProjectIfNotExistInAccountEmployeeTimeEntry(AccountEmployeeTimeEntryPeriodId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetEstimatedHoursByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEstimatedHoursDataTable
        Dim _vueAccountEmployeeTimeEntryForEstimatedHoursTableAdapter As New vueAccountEmployeeTimeEntryForEstimatedHoursTableAdapter
        Return _vueAccountEmployeeTimeEntryForEstimatedHoursTableAdapter.GetData(AccountProjectTaskId, AccountEmployeeTimeEntryPeriodId)
    End Function

    Public Function GetTimeEntryPeriodByAccountEmployeeIdAndStartDate(ByVal AccountEmployeeId As Integer, ByVal StartDate As Date) As Guid
        Dim TimeEntryPeriod As New AccountEmployeeTimeEntryPeriodTableAdapter
        Dim Period = TimeEntryPeriod.GetTimeEntryPeriodByAccountEmployeeIdAndStartDate(AccountEmployeeId, StartDate)
        Dim row As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If Period.Count = 1 Then
            For Each row In Period
                Return row.AccountEmployeeTimeEntryPeriodId
            Next
        End If
        Return Guid.Empty
    End Function
    Public Function GetTimesheetApprovalCount(ByVal ApproverEmployeeId As Integer) As Integer
        Dim vb As New vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter
        Return vb.GetTimeEntryApprovalCount(ApproverEmployeeId)
    End Function
    Public Function GetProjectNameByTimeEntryId(ByVal AccountTimeEntryId As Integer) As String
        Return Me.Adapter.GetProjectNameByTimeEntryId(AccountTimeEntryId)
    End Function
End Class