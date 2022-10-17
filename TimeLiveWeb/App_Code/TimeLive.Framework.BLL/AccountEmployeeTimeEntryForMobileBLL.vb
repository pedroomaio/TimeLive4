Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountEmployeeTimeEntryTableAdapters
Imports System.Data.SqlClient
Imports System.Threading
Imports TimeLiveDataSet
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTimeEntryForMobileBLL
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
    Protected ReadOnly Property AccountEmployeeTimeEntryPeriodAdapter() As AccountEmployeeTimeEntryPeriodTableAdapter
        Get
            If _AccountEmployeeTimeEntryPeriodAdapter Is Nothing Then
                _AccountEmployeeTimeEntryPeriodAdapter = New AccountEmployeeTimeEntryPeriodTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryPeriodAdapter
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
    ''' Get submitted employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSubmittedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetSubmittedTimeEntryTimeOff(AccountEmployeeTimeEntryPeriodId)
    End Function
    ''' <summary>
    ''' Get approved employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetApprovedTimeEntryTimeOff(AccountEmployeeTimeEntryPeriodId)
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
    ''' Get rejected employee time entry time off by employee time entry periodid of specified AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedAccountEmployeeTimeEntryTimeOffByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        Return Adapter.GetRejectedTimeEntryTimeOff(AccountEmployeeTimeEntryPeriodId)
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
    ''' Returns approved status record of specified AccountEmployeeTimeEntryApprovalProjectId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryApprovalProject datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntryFromMobileAPI(ByVal AccountId As Integer, _
                    ByVal AccountEmployeeId As Integer, _
                    ByVal TimeEntryDate As DateTime, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal Description As String, _
                    ByVal Submitted As Boolean, _
                    Optional ByVal AccountWorkTypeId As Integer = 0, _
                    Optional ByVal AccountCostCenterId As Integer = 0
                   ) As String
        If TotalTime > "23:59" Then
            Throw New Exception("You may not enter more than 24 hours per day")
        End If
        Dim AccountEmployeeTimeEntryPeriodId As Guid
        Dim TimesheetPeriodType As String
        Dim PeriodStartDate As Date
        Dim PeriodEndDate As Date
        If AccountWorkTypeId = 0 Then
            Dim WorkTypeBLL As New AccountWorkTypeBLL
            AccountWorkTypeId = WorkTypeBLL.GetAccountWorkTypeByAccountId(AccountId).Rows(0)("AccountWorkTypeId")
        End If
        If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            SetPeriodDataByAccountEmployeeIdAndTimeEntryDateForAPI(AccountId, AccountEmployeeId, TimeEntryDate, , , True)
            TimesheetPeriodType = TimesheetPeriodTypeTS
            PeriodStartDate = PeriodStartDateTS
            PeriodEndDate = PeriodEndDateTS
            AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodIdTS
        End If
        Description = IIf(Description = "", Nothing, Description)
        AccountIdWS = AccountId
        Dim InsertedAccountEmployeeTimeEntryId As Integer = Me.AddAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, AccountProjectId, AccountProjectTaskId, Description, False, Now, Now, 0, Submitted, AccountWorkTypeId, AccountCostCenterId, TimesheetPeriodTypeTS, PeriodStartDateTS, PeriodEndDateTS, AccountEmployeeTimeEntryPeriodIdTS, False, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty, 0, , , , , , , , , , , , , , , , True)
        Me.SetAccountEmployeeTimeEntryApprovalProject(InsertedAccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId, AccountProjectId, AccountEmployeeId, 0, Submitted, False, False, False, False, TimesheetPeriodType, AccountProjectId, , True)
        Me.SetAccountEmployeeTimeEntryPeriodApprovalStatus(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType, AccountEmployeeTimeEntryPeriodId, True)
    End Function
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
                    Optional ByVal CustomField15 As String = "", _
                    Optional ByVal IsFromAPI As Boolean = False _
                    ) As Integer
        ' Create a new ProductRow instance
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
            If IsTimeOff = True And AccountEmployeeTimeOffRequestId = System.Guid.Empty And Approved = True Then
                Me.UpdateEmployeeTimeOffHours(AccountEmployeeId, AccountTimeOffTypeId, TimeOffConsumedHours, InsertedAccountEmployeeTimeEntryId)
            End If
            If IsTimeOff = False And Percentage <> 0 Then
                Call New AccountProjectTaskBLL().UpdatePercentageAndCompleteTask(AccountProjectTaskId, Nothing, 0, Percentage)
            End If
            If Not IsFromAPI Then
                Me.AfterUpdate(TimeEntryDate)
            End If
            Return InsertedAccountEmployeeTimeEntryId
        Catch ex As Exception
            Throw ex
        End Try
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
                    Optional ByVal PeriodDescription As String = "PeriodDescription", _
                    Optional ByVal IsFromAPI As Boolean = False _
                    ) As Guid
        Try
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
            If Not IsFromAPI Then
                Me.AfterUpdate()
            End If
            Dim rowsAffected As Integer = AccountEmployeeTimeEntryPeriodAdapter.Update(dtAccountEmployeeTimeEntryPeriod)
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
                    ByVal IsEmailSend As Boolean, _
                    Optional ByVal IsFromAPI As Boolean = False _
                    ) As Guid
        ' Create a new ProductRow instance

        Try

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
            If Not IsFromAPI Then
                Me.AfterUpdate()
            End If

            Dim rowsAffected As Integer = AccountEmployeeTimeEntryApprovalProjectAdapter.Update(dtAccountEmployeeTimeEntryApprovalProject)

            Return nAccountEmployeeTimeEntryApprovalProjectId

        Catch ex As Exception
            Throw ex
        End Try

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
                    Optional ByVal CustomField15 As String = "", _
                    Optional ByVal IsFromAPI As Boolean = False _
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
            Dim UpdatedAccountEmployeeTimeEntryId As Integer = Me.Adapter.TimeEntryUpdate(AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, _
            AccountProjectId, IIf(IsTimeOff, Nothing, AccountProjectTaskId), _
            Description, Approved, _
            Now, Submitted, Rejected, IIf(AccountWorkTypeId <> 0 And IsTimeOff = False, AccountWorkTypeId, Nothing), _
            IIf(Not AccountCostCenterId <= 0 And IsTimeOff = False, AccountCostCenterId, Nothing), AccountEmployeeTimeEntryPeriodId, _
            IsTimeOff, AccountTimeOffTypeId, _
            BillingRate, EmployeeRate, BillingRateCurrencyId, EmployeeRateCurrencyId, _
            BillingRateExchangeRate, EmployeeRateExchangeRate, AccountBaseCurrencyId, AccountEmployeeTimeEntryApprovalProjectId, Original_AccountEmployeeTimeEntryId, Percentage, Hours, IIf(IsBillingModePerHour = True, False, True), _
            CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, _
            CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15)
            'Me.AfterUpdate(TimeEntryDate)
            If IsTimeOff = True And TimeOffConsumedHours <> 0 And Approved = True Then
                Call New AccountEmployeeTimeOffBLL().SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, TimeOffConsumedHours)
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
    ''' Update employee time off hours of specified AccountEmployeeId, AccountTimeOffTypeId, TotalTime
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountTimeOffTypeId"></param>
    ''' <param name="TotalTime"></param>
    ''' <remarks></remarks>
    Public Sub UpdateEmployeeTimeOffHours(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal TotalTime As String, Optional ByVal AccountEmployeeTimeEntryId As Integer = 0)
        Dim HoursOff As Double
        Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
        Dim strHoursOff As String() = Split(Replace(TotalTime, ":", "."), ".")
        If strHoursOff.Count = 1 Then
            HoursOff = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strHoursOff(0), 0)
        Else
            HoursOff = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(strHoursOff(0), strHoursOff(1))
        End If

        If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, HoursOff) And AccountEmployeeTimeEntryId <> 0 Then
            Me.UpdateIsTimeOffConsumedByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId, True)
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
    ''' Returns all AccountEmployeeTimeEntry records
    ''' </summary>
    ''' <returns>AccountEmployeeTimeEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryByTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountEmployeeTimeEntryDataTable", "GetAccountEmployeeTimeEntryByTimeEntryId", "AccountEmployeeTimeEntryId=" & AccountEmployeeTimeEntryId)
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountEmployeeTimeEntryByTimeEntryId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        GetAccountEmployeeTimeEntryByTimeEntryId = Adapter.GetDataByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        'CacheManager.AddAccountDataInCache(GetAccountEmployeeTimeEntryByTimeEntryId, strCacheKey)
        'End If
        Return GetAccountEmployeeTimeEntryByTimeEntryId
    End Function
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


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function UpdateAccountEmployeeTimeEntryFromMobileAPI(ByVal AccountEmployeeTimeEntryId As Integer, _
                    ByVal AccountId As Integer, _
                    ByVal AccountEmployeeId As Integer, _
                    ByVal TimeEntryDate As DateTime, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal Description As String, _
                    ByVal Submitted As Boolean, _
                    Optional ByVal AccountWorkTypeId As Integer = 0, _
                    Optional ByVal AccountCostCenterId As Integer = 0
                   ) As Boolean
        If TotalTime > "23:59" Then
            Throw New Exception("You may not enter more than 24 hours per day")
        End If
        Dim AccountEmployeeTimeEntryPeriodId As Guid
        Dim TimesheetPeriodType As String
        Dim PeriodStartDate As Date
        Dim PeriodEndDate As Date
        If AccountWorkTypeId = 0 Then
            Dim WorkTypeBLL As New AccountWorkTypeBLL
            AccountWorkTypeId = WorkTypeBLL.GetAccountWorkTypeByAccountId(AccountId).Rows(0)("AccountWorkTypeId")
        End If
        If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            SetPeriodDataByAccountEmployeeIdAndTimeEntryDateForAPI(AccountId, AccountEmployeeId, TimeEntryDate, , , True)
            TimesheetPeriodType = TimesheetPeriodTypeTS
            PeriodStartDate = PeriodStartDateTS
            PeriodEndDate = PeriodEndDateTS
            AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodIdTS
        End If
        Description = IIf(Description = "", Nothing, Description)
        AccountIdWS = AccountId
        Me.UpdateAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, AccountProjectId, AccountProjectTaskId, Description, False, False, False, False, Now, AccountEmployeeTimeEntryId, 0, Submitted, AccountWorkTypeId, AccountCostCenterId, TimesheetPeriodTypeTS, PeriodStartDateTS, PeriodEndDateTS, AccountEmployeeTimeEntryPeriodIdTS, False, System.Guid.Empty, System.Guid.Empty, 0, , , , , , , , , , , , , , , , True)
        Me.SetAccountEmployeeTimeEntryApprovalProject(AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryPeriodId, AccountProjectId, AccountEmployeeId, 0, Submitted, False, False, False, False, TimesheetPeriodType, AccountProjectId, , True)
        Me.SetAccountEmployeeTimeEntryPeriodApprovalStatus(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType, AccountEmployeeTimeEntryPeriodId, True)
    End Function
    Public Sub UpdateAccountEmployeeTimeEntryPeriodAndApprovalProjectForMobile(ByVal AccountEmployeeTimeEntryPeriodId As String, AccountEmployeeId As Integer)
        Try
            If AccountEmployeeTimeEntryPeriodId.ToString <> "" Then
                Dim PeriodId As New Guid(AccountEmployeeTimeEntryPeriodId)
                Dim EmployeeBLL As New AccountEmployeeBLL
                Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
                Dim MaxHoursPerDay As Integer = drEmployee.MaximumHoursPerDay
                Dim MinHoursPerDay As Integer = drEmployee.MinimumHoursPerDay
                Dim exmsg As String
                Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryPeriodId(PeriodId)
                Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If dr.Hours > MaxHoursPerDay Then
                            Throw New Exception("You may not enter more than " + MaxHoursPerDay.ToString + " hours per day.")
                        End If
                        If dr.Hours < MinHoursPerDay Then
                            Throw New Exception("You may not enter less than " + MinHoursPerDay.ToString + " hours per day.")
                        End If
                    Next
                End If
                Adapter.UpdateAccountEmployeeTimeEntryForMobile(PeriodId)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateAccountEmployeeTimeEntryPeriodForMobile(PeriodId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateAccountEmployeeTimeEntryApprovalProjectForMobile(PeriodId)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub




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
                ByVal Original_AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                Optional ByVal IsFromAPI As Boolean = False _
                ) As Boolean
        Dim dtAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = AccountEmployeeTimeEntryApprovalProjectAdapter.GetDataByAccountEmployeeTimeEntryApprovalProjectId(Original_AccountEmployeeTimeEntryApprovalProjectId)
        Dim drAccountEmployeeTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        'System.Web.HttpContext.Current.Session("AccountEmployeeTimeEntryApprovalProjectId") = Original_AccountEmployeeTimeEntryApprovalProjectId
        If dtAccountEmployeeTimeEntryApprovalProject.Rows.Count > 0 Then
            drAccountEmployeeTimeEntryApprovalProject = dtAccountEmployeeTimeEntryApprovalProject.Rows(0)
            With drAccountEmployeeTimeEntryApprovalProject
                .AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
                .AccountProjectId = AccountProjectId
                .TimeEntryAccountEmployeeId = TimeEntryAccountEmployeeId
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
            If Not IsFromAPI Then
                Me.AfterUpdate()
            End If
            Return rowsAffected = 1
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
        Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
        Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.Rows(0)
        'System.Web.HttpContext.Current.Session("AccountEmployeeTimeEntryPeriodId") = Original_AccountEmployeeTimeEntryPeriodId
        With drAccountEmployeeTimeEntryPeriod
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
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
        Return Original_AccountEmployeeTimeEntryPeriodId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeEntryForMobile(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForMobileDataTable
        Dim _vueAccountEmployeeTimeEntryForMobileTableAdapter As New AccountEmployeeTimeEntryTableAdapters.vueAccountEmployeeTimeEntryForMobileTableAdapter
        Return _vueAccountEmployeeTimeEntryForMobileTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId, TimeEntryDate)
    End Function
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
    Public Function GetTimeEntryPeriodIdForTimeEntry(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimesheetPeriodType As String, ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal InApproval As Boolean, Optional ByVal IsFromTimeOffRequest As Boolean = False, Optional ByVal IsFromAPI As Boolean = False) As Guid
        Dim dtWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = Me.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, TimesheetPeriodType)
        Dim drWeekView As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
        If dtWeekView.Rows.Count = 0 Then
            Dim AccountEmployeeTimeEntryPeriodId As Guid = Me.AddAccountEmployeeTimeEntryPeriod(AccountId, AccountEmployeeId, PeriodStartDate, PeriodEndDate, Submitted, Rejected, Approved, InApproval, TimesheetPeriodType, "", IsFromAPI)
            Return AccountEmployeeTimeEntryPeriodId
        Else
            drWeekView = dtWeekView.Rows(0)
            If Not IsFromTimeOffRequest Then
                If Not IsFromAPI Then
                    Me.UpdateAccountEmployeeTimeEntryPeriod(drWeekView.AccountId, drWeekView.AccountEmployeeId, drWeekView.TimeEntryStartDate, drWeekView.TimeEntryEndDate, Submitted, Rejected, Approved, TimesheetPeriodType, drWeekView.AccountEmployeeTimeEntryPeriodId)
                End If
            End If
            Return drWeekView.AccountEmployeeTimeEntryPeriodId
        End If
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
        'If DBUtilities.IsApplicationContext Then
        'Dim strParameters As String = CacheManager.GetEmployeeCacheKeyParameterForTimeEntryData("AccountId=" & AccountId & "_AccountEmployeeId=" & AccountEmployeeId & "_TimeEntryStartDate=" & TimeEntryStartDate & "_TimeEntryEndDate=" & TimeEntryEndDate & "_TimeEntryViewType=" & TimeEntryViewType, TimeEntryStartDate, TimeEntryEndDate)
        ' Creating of unique cache key by combining of parameter value and function name
        'strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("AccountEmployeeTimeEntryPeriodDataTable", "GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView", strParameters)
        ' If found in cache, then return from cache collection
        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView = CacheManager.GetItemFromCache(strCacheKey)
        'Return GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView
        'End If
        'End If
        GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView = AccountEmployeeTimeEntryPeriodAdapter.GetDataByTimeEntryDateAndTimeEntryView(AccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType)
        'CacheManager.AddAccountEmployeeDataInCache(GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView, strCacheKey)
        Return GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView
    End Function
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
    Public Sub SetAccountEmployeeTimeEntryApprovalProject(ByVal AccountEmployeeTimeEntryId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal AccountProjectId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal ApprovedByEmployeeId As Integer, ByVal Submitted As Boolean, ByVal InApproval As Boolean, ByVal IsRejected As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal TimeEntryMode As String, ByVal Old_AccountProjectId As Integer, Optional ByVal TimeEntryDate As Date = #1/1/2007#, Optional ByVal IsFromAPI As Boolean = False)
        Dim dtTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = Me.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, AccountProjectId)
        Dim drTimeEntryApprovalProject As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
        If dtTimeEntryApprovalProject.Rows.Count = 0 Then
            Dim AccountEmployeeTimeEntryApprovalProjectId As Guid = Me.AddAccountEmployeeTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId, AccountProjectId, TimeEntryAccountEmployeeId, ApprovedByEmployeeId, Submitted, InApproval, IsRejected, IIf(Submitted = True, Me.SetApprovalStateForApprovalProject(AccountProjectId), False), Rejected, False, IsFromAPI)
            Me.UpdateAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryId, AccountEmployeeTimeEntryApprovalProjectId, IsFromAPI)
        Else
            drTimeEntryApprovalProject = dtTimeEntryApprovalProject.Rows(0)
            With drTimeEntryApprovalProject
                Me.UpdateAccountEmployeeTimeEntryApprovalProject(.AccountEmployeeTimeEntryPeriodId, AccountProjectId, .TimeEntryAccountEmployeeId, IIf(IsDBNull(.Item("ApprovedByEmployeeId")), Nothing, .Item("ApprovedByEmployeeId")), IIf(.Submitted = True, True, Submitted), IIf(.InApproval = True, True, InApproval), IIf(Submitted = True, IsRejected, .IsRejected), IIf(.Submitted = True, IIf(.Approved = True, True, Approved), IIf(Submitted = True, IIf(Me.SetApprovalStateForApprovalProject(AccountProjectId) = True, True, .Approved), .Approved)), IIf(Submitted = True, Rejected, .Rejected), .AccountEmployeeTimeEntryApprovalProjectId, IsFromAPI)
                Me.UpdateAccountEmployeeTimeEntryApprovalProjectId(AccountEmployeeTimeEntryId, .AccountEmployeeTimeEntryApprovalProjectId, IsFromAPI)
            End With
        End If
        'Me.CheckAndDeleteAccountEmployeeTimeEntryApprovalProject(Old_AccountProjectId, AccountProjectId, AccountEmployeeTimeEntryPeriodId)
        If Not IsFromAPI Then
            Me.AfterUpdate(TimeEntryDate)
        End If
    End Sub
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
    Public Sub SetAccountEmployeeTimeEntryPeriodApprovalStatus(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, ByVal TimeEntryPeriodType As String, ByVal AccountEmployeeTimeEntryPeriodId As Guid, Optional ByVal IsFromAPI As Boolean = False)
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
            If (dtSubmittedTimeEntryApprovalProjects.Rows.Count = dtTimeEntryApprovalProject.Rows.Count And dtTimeEntryApprovalProject.Rows.Count <> 0) Or (dtSubmittedTimeEntryForTimeOff.Rows.Count = dtTimeEntryForTimeOff.Rows.Count And dtTimeEntryForTimeOff.Rows.Count <> 0) Then
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
        If Not IsFromAPI Then
            Me.AfterUpdate(PeriodStartDate)
        End If
    End Sub
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
    Public Sub UpdateAccountEmployeeTimeEntries(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        Me.Adapter.TimeEntriesUpdate(AccountId, AccountEmployeeId)
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
                ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                Optional ByVal IsFromAPI As Boolean = False _
                ) As Boolean
        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = Adapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)
        AddOldObjectInSession(Original_AccountEmployeeTimeEntryId)
        With AccountEmployeeTimeEntry
            .AccountEmployeeTimeEntryApprovalProjectId = AccountEmployeeTimeEntryApprovalProjectId
        End With
        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeTimeEntry)
        If Not IsFromAPI Then
            Me.AfterUpdate()
        End If
        Return rowsAffected = 1
    End Function
    Public Function SetTimesheetStatusForMobile(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As String
        Dim BLL As New AccountEmployeeTimeEntryForMobileBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdForMobile(AccountEmployeeTimeEntryPeriodId)
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
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryPeriodIdForMobile(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
        Return AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
    End Function
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
    Public Function SetPeriodDataByAccountEmployeeIdAndTimeEntryDateForAPI(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, Optional ByVal Submitted As Boolean = False, Optional ByVal Approved As Boolean = False, Optional ByVal IsFromAPI As Boolean = False) As Guid
        Me.SetDataInVariableForAPI(AccountEmployeeId)
        Dim dtPeriodStartDate As Date = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, SystemTimesheetPeriodTypeWS, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
        Dim dtPeriodEndDate As Date = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, SystemTimesheetPeriodTypeWS, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryForMobileBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodTypeWS)
        If TimesheetPeriodType <> SystemTimesheetPeriodTypeWS Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, EmployeeWeekStartDayWS, SystemInitialDayOfFirstPeriodWS, SystemInitialDayOfLastPeriodWS, InitialDayOfTheMonthWS)
        End If
        Dim dtAccountEmployeeTimeEntryPeriodId As Guid = Me.GetTimeEntryPeriodIdForTimeEntry(AccountId, AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, TimesheetPeriodType, Submitted, Approved, False, False, , IsFromAPI)
        TimesheetPeriodTypeTS = TimesheetPeriodType
        PeriodStartDateTS = dtPeriodStartDate
        PeriodEndDateTS = dtPeriodEndDate
        AccountEmployeeTimeEntryPeriodIdTS = dtAccountEmployeeTimeEntryPeriodId
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
        Dim BLL As New AccountEmployeeTimeEntryForMobileBLL
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

        ''Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function UpdateTimesheetApprovalForMobile(ByVal AccountId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal EmployeeName As String, ByVal AccountEmployeeId As Integer, ByVal EmailAddress As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal Comments As String, ByVal TotalMinutes As Integer, ByVal IsApproved As Boolean, ByVal IsRejected As Boolean, ByVal SystemApproverTypeId As Integer) As Boolean
        Dim MobileBLL As New AccountEmployeeTimeEntryForMobileBLL
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim rowaffected As Boolean = 0
        If IsApproved = True Then
            If SystemApproverTypeId = 1 Then
                Dim TLBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForTeamLeadApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInTeamLeadApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateApprovedInTeamLeadApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInTeamLeadApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForTeamLead(Date.Now, Comments, False, True, False, TLBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                MobileBLL.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            ElseIf SystemApproverTypeId = 2 Then
                Dim PMBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForProjectManagerApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInProjectManagerApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateApprovedInProjectManagerApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInProjectManagerApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForProjectManager(Date.Now, Comments, False, True, False, PMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            ElseIf SystemApproverTypeId = 3 Then
                Dim SEBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForSpecificEmployeeApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificEmployeeApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInSpecificEmployeeApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInSpecificEmployeeApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificEmployee(Date.Now, Comments, False, True, False, SEBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            ElseIf SystemApproverTypeId = 4 Then
                Dim SEUBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForSpecificExternalUserApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificExternalUserApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInSpecificExternalUserApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInSpecificExternalUserApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificExternalUser(Date.Now, Comments, False, True, False, SEUBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            ElseIf SystemApproverTypeId = 5 Then
                Dim EMBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForEmployeeManagerApproval(True, False, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInEmployeeManagerApprovalProject(True, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateApprovedInEmployeeManagerApprovalProject(True, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateIsEmailSendInEmployeeManagerApprovalProject(False, AccountEmployeeTimeEntryPeriodId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForEmployeeManager(Date.Now, Comments, False, True, False, EMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, True)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateApprovedInPeriod(AccountEmployeeTimeEntryPeriodId, True, AccountEmployeeId, Date.Now)
            End If
        ElseIf IsRejected = True Then
            If SystemApproverTypeId = 1 Then
                Dim TLBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForTeamLeadApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInTeamLeadApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateRejectedInTeamLeadApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForTeamLead(Date.Now, Comments, True, False, True, TLBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                ''TimeEntryBLL.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
                'Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
            ElseIf SystemApproverTypeId = 2 Then
                Dim PMBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForProjectManagerApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInProjectManagerApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateRejectedInProjectManagerApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForProjectManager(Date.Now, Comments, True, False, True, PMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                ''TimeEntryBLL.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
            ElseIf SystemApproverTypeId = 3 Then
                Dim SEBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForSpecificEmployeeApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificEmployeeApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateRejectedInSpecificEmployeeApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificEmployee(Date.Now, Comments, True, False, True, SEBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                ''TimeEntryBLL.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
                ''Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
            ElseIf SystemApproverTypeId = 4 Then
                Dim SEUBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForSpecificExternalUserApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInSpecificExternalUserApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateRejectedInSpecificExternalUserApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForSpecificExternalUser(Date.Now, Comments, True, False, True, SEUBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                ''TimeEntryBLL.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
                ''Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
            ElseIf SystemApproverTypeId = 5 Then
                Dim EMBatchId As Guid = System.Guid.NewGuid
                Adapter.UpdateTimesheetEntriesForEmployeeManagerApprovalReject(False, True, Date.Now, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalProjectAdapter.UpdateInApprovalInEmployeeManagerApprovalProject(False, AccountEmployeeId, Date.Now, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                TimeEntryBLL.UpdateRejectedInEmployeeManagerApprovalProject(True, True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                AccountEmployeeTimeEntryApprovalAdapter.InsertTimesheetApprovalEntriesForEmployeeManager(Date.Now, Comments, True, False, True, EMBatchId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryAccountEmployeeId)
                ''TimeEntryBLL.UpdatePreviousStatusInTimesheetApproval(True, AccountEmployeeTimeEntryPeriodId, AccountProjectId)
                Me.UpdateInApprovalInAccountEmployeeTimeEntryPeriod(AccountEmployeeTimeEntryPeriodId, False)
                AccountEmployeeTimeEntryPeriodAdapter.UpdateRejectedInPeriod(True, False, False, Date.Now, AccountEmployeeId, AccountEmployeeTimeEntryPeriodId)
                ''Me.SendTimesheetRejectedEMailSummary(EmployeeName, TotalMinutes, Comments, TimeEntryStartDate, TimeEntryEndDate, EmailAddress, AccountEmployeeTimeEntryPeriodId)
            End If
            
        End If

        rowaffected = 1
        Return rowaffected
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function GetPeriodStartDateAndEndDate(ByVal Original_AccountEmployeeTimeEntryPeriodId As Guid) As Date

        ' Update the product record

        Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = AccountEmployeeTimeEntryPeriodAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(Original_AccountEmployeeTimeEntryPeriodId)
        Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow = dtAccountEmployeeTimeEntryPeriod.Rows(0)

        If dtAccountEmployeeTimeEntryPeriod.Rows.Count > 0 Then
            Return drAccountEmployeeTimeEntryPeriod.TimeEntryStartDate

        End If
        ''Me.AfterUpdate()
        ' Return true if precisely one row was updated, otherwise false
    End Function
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
End Class
