Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TimeEntries
    Inherits System.Web.Services.WebService
    Dim EmployeeTimesheetPeriodType As String
    Dim EmployeeWeekStartDay As Integer
    Dim EmployeeInitialDayOfFirstPeriod As Integer
    Dim EmployeeInitialDayOfLastPeriod As Integer
    Dim EmployeeInitialDayOfTheMonth As Integer
    Dim AccountEmployeeTimeEntryPeriodIdTS As Guid
    Dim TimesheetPeriodTypeTS As String
    Dim PeriodStartDateTS As Date
    Dim PeriodEndDateTS As Date
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function TimeEntryObject(ByVal objTimeEntry As TimeEntry) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function TimesheetPeriodForMobileObject(ByVal objTimeEntry As TimeSheetPeriodForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function TimesheetWorkingDaysObject(ByVal objTimeEntry As TimesheetWorkingDays) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function TimeEntryForMobileObject(ByVal objTimeEntry As TimeEntryForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function TimesheetApprovalObject(ByVal objTimesheetApproval As TimesheetApprovalObject) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTimesheetPeriod(ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim objTimeSheetPeriod As New TimeSheetPeriodForMobile
        Dim objTimeSheetPeriodArray As New ArrayList
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
        EmployeeTimesheetPeriodType = IIf(Not IsDBNull(drEmployee.Item("SystemTimesheetPeriodType")), drEmployee.Item("SystemTimesheetPeriodType"), "Weekly")
        EmployeeWeekStartDay = IIf(Not IsDBNull(drEmployee.Item("EmployeeWeekStartDay")), drEmployee.Item("EmployeeWeekStartDay"), 1)
        EmployeeInitialDayOfFirstPeriod = drEmployee.SystemInitialDayOfFirstPeriod
        EmployeeInitialDayOfLastPeriod = drEmployee.SystemInitialDayOfLastPeriod
        EmployeeInitialDayOfTheMonth = drEmployee.InitialDayOfTheMonth

        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtStartDate As Date = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        Dim dtEndDate As Date = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)

        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryForMobileBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtStartDate, dtEndDate, EmployeeTimesheetPeriodType)

        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        End If
        objTimeSheetPeriod = New TimeSheetPeriodForMobile
        Dim dtAccountEmployeeTimeEntryPeriodId = New AccountEmployeeTimeEntryForMobileBLL().GetTimeEntryPeriodIdForPeriodView(AccountId, AccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
        Dim Status As String
        With objTimeSheetPeriod
            .StartDate = dtStartDate
            .EndDate = dtEndDate
            .TimesheetPeriodType = TimesheetPeriodType
            .TimesheetPeriodId = dtAccountEmployeeTimeEntryPeriodId.ToString
            If dtAccountEmployeeTimeEntryPeriodId <> System.Guid.Empty Then
                Status = New AccountEmployeeTimeEntryForMobileBLL().SetTimesheetStatusForMobile(dtAccountEmployeeTimeEntryPeriodId)
                .TimesheetStatus = Status
            Else
                .TimesheetStatus = "Not Submitted"
            End If
            If Status = "Submitted" Or Status = "Approved" Then
                .DisableTimeEntry = True
            Else
                .DisableTimeEntry = False
            End If
        End With
        objTimeSheetPeriodArray.Add(objTimeSheetPeriod)
        Return objTimeSheetPeriodArray
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAllTimeEntriesByDateRange(ByVal StartDate As Date, ByVal EndDate As Date) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TimeEntryArrayList As New ArrayList
        Dim objTimeEntry As New TimeEntry
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBDataTable = TimeEntryBLL.GetTimeEntriesByAccountIdAndDateRange(AccountId, StartDate, EndDate)
        Dim drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow
        For Each drTimeEntry In dtTimeEntry.Rows
            objTimeEntry = New TimeEntry
            With objTimeEntry
                .EmployeeName = drTimeEntry.EmployeeName
                If IsDBNull(drTimeEntry.Item("IsBillable")) Then
                    .IsBillable = False
                Else
                    .IsBillable = drTimeEntry.IsBillable
                End If
                .ProjectName = drTimeEntry.ProjectName
                .TaskName = drTimeEntry.TaskName
                .TaskDescription = drTimeEntry.TaskDescription
                .TotalTime = drTimeEntry.TotalTime
                .TimeEntryDate = drTimeEntry.TimeEntryDate
                If Not IsDBNull(drTimeEntry.Item("TimeEntryDescription")) Then
                    .TimeEntryDescription = drTimeEntry.TimeEntryDescription
                Else
                    .TimeEntryDescription = ""
                End If
                .ClientName = drTimeEntry.PartyName
                .Milestone = drTimeEntry.MilestoneDescription
                .EmployeeDepartment = drTimeEntry.DepartmentName
                .EmployeeType = drTimeEntry.AccountEmployeeType
                .WorkType = drTimeEntry.AccountWorkType
                If IsDBNull(drTimeEntry.Item("AccountCostCenter")) Then
                    .CostCenter = "Default Cost Center"
                Else
                    .CostCenter = drTimeEntry.AccountCostCenter
                End If
                .TaskWithParent = New AccountProjectTaskBLL().GetTaskNameForWSByAccountProjectTaskId(drTimeEntry.AccountProjectId, drTimeEntry.AccountProjectTaskId)
            End With
            TimeEntryArrayList.Add(objTimeEntry)
        Next
        Return TimeEntryArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTimesheetWorkingDaysWithHours(ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        'Try
        Dim WorkingDaysArray As ArrayList
        Dim objWorkingDays As New TimesheetWorkingDays
        Dim objWorkingDaysArray As New ArrayList
        Dim TimeEntryStartDate As Date = Now.Date
        Dim TimeEntryEndDate As Date = Now.Date
        Dim SumTotalMinutes As Integer
        Dim TotalHours As String = "00:00"
        Dim TotalMinutes As Integer = 0
        Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
        EmployeeTimesheetPeriodType = IIf(Not IsDBNull(drEmployee.Item("SystemTimesheetPeriodType")), drEmployee.Item("SystemTimesheetPeriodType"), "Weekly")
        EmployeeWeekStartDay = IIf(Not IsDBNull(drEmployee.Item("EmployeeWeekStartDay")), drEmployee.Item("EmployeeWeekStartDay"), 1)
        EmployeeInitialDayOfFirstPeriod = drEmployee.SystemInitialDayOfFirstPeriod
        EmployeeInitialDayOfLastPeriod = drEmployee.SystemInitialDayOfLastPeriod
        EmployeeInitialDayOfTheMonth = drEmployee.InitialDayOfTheMonth
        Dim dtStartDate As Date = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        Dim dtEndDate As Date = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryForMobileBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtStartDate, dtEndDate, EmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        End If
        Dim BLLAccountEmployeeTimeEntry As New AccountEmployeeTimeEntryForMobileBLL
        WorkingDaysArray = DateTimeUtilities.GetWorkingDays(AccountEmployeeId, dtDate, dtStartDate, dtEndDate, True, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        If WorkingDaysArray.Count > 0 Then
            TimeEntryStartDate = WorkingDaysArray(0)
            TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
            Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = BLLAccountEmployeeTimeEntry.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
            Dim AccountBLL As New AccountBLL
            Dim dtPreferences As AccountPreferences.AccountPreferencesDataTable = AccountBLL.GetPreferencesByAccountId(AccountId)
            Dim drPreferences As AccountPreferences.AccountPreferencesRow
            drPreferences = dtPreferences.Rows(0)
            For na As Integer = 0 To WorkingDaysArray.Count - 1
                objWorkingDays = New TimesheetWorkingDays
                TotalHours = "00:00"
                Dim dr() As DataRow = dtEmployeesWithTimeEntry.Select("TimeEntryDate = '" & WorkingDaysArray(na) & "'")
                If dr.Length > 0 Then
                    TotalMinutes = dr(0).Item("TotalMinutes")
                End If
                TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForMobile(TotalMinutes)
                SumTotalMinutes += TotalMinutes

                With objWorkingDays
                    .TimeEntryDate = WorkingDaysArray(na)
                    .TotalHours = TotalHours
                    If Not IsDBNull(drPreferences.Item("ShowClientInTimesheet")) Then
                        .ShowClientInTimesheet = drPreferences.ShowClientInTimesheet
                    Else
                        .ShowClientInTimesheet = False
                    End If
                    If Not IsDBNull(drPreferences.Item("ShowWorkTypeInTimeSheet")) Then
                        .ShowWorkTypeInTimeSheet = drPreferences.ShowWorkTypeInTimeSheet
                    Else
                        .ShowWorkTypeInTimeSheet = False
                    End If
                    If Not IsDBNull(drPreferences.Item("ShowCostCenterInTimeSheet")) Then
                        .ShowCostCenterInTimeSheet = drPreferences.ShowCostCenterInTimeSheet
                    Else
                        .ShowCostCenterInTimeSheet = False
                    End If
                    If Not IsDBNull(drPreferences.Item("ShowClockStartEnd")) Then
                        .ShowClockStartEnd = drPreferences.ShowClockStartEnd
                    Else
                        .ShowClockStartEnd = False
                    End If
                End With
                objWorkingDaysArray.Add(objWorkingDays)
                TotalMinutes = 0
            Next
        End If
        Return objWorkingDaysArray
        'Catch ex As Exception

        'End Try
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTimeEntryDetail(ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim SumTotalMinutes As Integer
        Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim TotalHours As String = "00:00"
        Dim TotalMinutes As Integer = 0
        Dim objTimeEntry As New TimeEntryForMobile
        Dim objTimeEntryArray As New ArrayList
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim BLLAccountEmployeeTimeEntry As New AccountEmployeeTimeEntryForMobileBLL
        Dim AccountBLL As New AccountBLL
        Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForMobileDataTable = BLLAccountEmployeeTimeEntry.GetvueAccountEmployeeTimeEntryForMobile(AccountEmployeeId, dtDate)
        Dim drEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForMobileRow
        Dim dtPreferences As AccountPreferences.AccountPreferencesDataTable = AccountBLL.GetPreferencesByAccountId(AccountId)
        Dim drPreferences As AccountPreferences.AccountPreferencesRow
        drPreferences = dtPreferences.Rows(0)
        For Each drEmployeesWithTimeEntry In dtEmployeesWithTimeEntry.Rows
            TotalHours = "00:00"
            TotalMinutes = drEmployeesWithTimeEntry.TotalMinutes
            TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForMobile(TotalMinutes)
            SumTotalMinutes += TotalMinutes
            objTimeEntry = New TimeEntryForMobile
            With objTimeEntry
                .AccountEmployeeTimeEntryID = drEmployeesWithTimeEntry.AccountEmployeeTimeEntryId
                .ProjectName = drEmployeesWithTimeEntry.ProjectName
                .AccountProjectID = drEmployeesWithTimeEntry.AccountProjectId
                .TaskName = drEmployeesWithTimeEntry.TaskName
                .AccountProjectTaskID = drEmployeesWithTimeEntry.AccountProjectTaskId
                .AccountWorkTypeID = drEmployeesWithTimeEntry.AccountWorkTypeId
                .WorkTypeName = drEmployeesWithTimeEntry.AccountWorkType
                If Not IsDBNull(drEmployeesWithTimeEntry.Item("StartTime")) Then
                    .StartTime = drEmployeesWithTimeEntry.StartTime
                Else
                    .StartTime = ""
                End If
                If Not IsDBNull(drEmployeesWithTimeEntry.Item("EndTime")) Then
                    .EndTime = drEmployeesWithTimeEntry.EndTime
                Else
                    .EndTime = ""
                End If
                .TotalHours = TotalHours
                If Not IsDBNull(drEmployeesWithTimeEntry.Item("Description")) Then
                    .Description = drEmployeesWithTimeEntry.Description
                Else
                    .Description = ""
                End If
                If Not IsDBNull(drPreferences.Item("ShowClientInTimesheet")) Then
                    .ShowClientInTimesheet = drPreferences.ShowClientInTimesheet
                Else
                    .ShowClientInTimesheet = False
                End If
                If Not IsDBNull(drPreferences.Item("ShowWorkTypeInTimeSheet")) Then
                    .ShowWorkTypeInTimeSheet = drPreferences.ShowWorkTypeInTimeSheet
                Else
                    .ShowWorkTypeInTimeSheet = False
                End If
                If Not IsDBNull(drPreferences.Item("ShowCostCenterInTimeSheet")) Then
                    .ShowCostCenterInTimeSheet = drPreferences.ShowCostCenterInTimeSheet
                Else
                    .ShowCostCenterInTimeSheet = False
                End If
                If Not IsDBNull(drPreferences.Item("ShowClockStartEnd")) Then
                    .ShowClockStartEnd = drPreferences.ShowClockStartEnd
                Else
                    .ShowClockStartEnd = False
                End If

                Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = New AccountProjectBLL().GetAccountClientByAccountProjectIdandIsDisabled(0, drEmployeesWithTimeEntry.AccountProjectId)
                Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
                If dtProject.Rows.Count > 0 Then
                    drProject = dtProject.Rows(0)
                    If Not IsDBNull(drProject.Item("AccountClientId")) Then
                        .AccountClientId = drProject.AccountClientId
                    Else
                        .AccountClientId = 0
                    End If
                    If Not IsDBNull(drProject.Item("PartyName")) Then
                        .ClientName = drProject.PartyName
                    Else
                        .ClientName = 0
                    End If
                End If
            End With
            objTimeEntryArray.Add(objTimeEntry)
            TotalMinutes = 0
        Next
        Return objTimeEntryArray
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTimeEntriesByEmployeeIdAndDateRange(ByVal AccountEmployeeId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TimeEntryArrayList As New ArrayList
        Dim objTimeEntry As New TimeEntry
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBDataTable = TimeEntryBLL.GetTimeEntriesByAccountEmployeeIdAndDateRange(AccountId, AccountEmployeeId, StartDate, EndDate)
        Dim drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow
        For Each drTimeEntry In dtTimeEntry.Rows
            objTimeEntry = New TimeEntry
            With objTimeEntry
                .EmployeeName = drTimeEntry.EmployeeName
                If IsDBNull(drTimeEntry.Item("IsBillable")) Then
                    .IsBillable = False
                Else
                    .IsBillable = drTimeEntry.IsBillable
                End If
                .ProjectName = drTimeEntry.ProjectName
                .TaskName = drTimeEntry.TaskName
                .TaskDescription = drTimeEntry.TaskDescription
                If Not IsDBNull(drTimeEntry.Item("TimeEntryDescription")) Then
                    .TimeEntryDescription = drTimeEntry.TimeEntryDescription
                Else
                    .TimeEntryDescription = ""
                End If
                .TotalTime = drTimeEntry.TotalTime
                .TimeEntryDate = drTimeEntry.TimeEntryDate
                .ClientName = drTimeEntry.PartyName
                .Milestone = drTimeEntry.MilestoneDescription
                .EmployeeDepartment = drTimeEntry.DepartmentName
                .EmployeeType = drTimeEntry.AccountEmployeeType
                .WorkType = drTimeEntry.AccountWorkType
                If IsDBNull(drTimeEntry.Item("AccountCostCenter")) Then
                    .CostCenter = "Default Cost Center"
                Else
                    .CostCenter = drTimeEntry.AccountCostCenter
                End If
                .TaskWithParent = New AccountProjectTaskBLL().GetTaskNameForWSByAccountProjectTaskId(drTimeEntry.AccountProjectId, drTimeEntry.AccountProjectTaskId)
            End With
            TimeEntryArrayList.Add(objTimeEntry)
        Next
        Return TimeEntryArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTimesheetApprovalTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objTimesheetApprovalType As New AccountApprovalBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nTimesheetApprovalTypeId As Integer = objTimesheetApprovalType.GetAccountApprovalTypesByAccountIdForTimeSheetApproval(AccountId).Rows(0).Item(0)
        Return nTimesheetApprovalTypeId
    End Function
    Public Function GetTimesheetPeriodId(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, ByVal TimeEntryBLL As AccountEmployeeTimeEntryForMobileBLL) As Guid
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
        EmployeeTimesheetPeriodType = IIf(Not IsDBNull(drEmployee.Item("SystemTimesheetPeriodType")), drEmployee.Item("SystemTimesheetPeriodType"), "Weekly")
        EmployeeWeekStartDay = IIf(Not IsDBNull(drEmployee.Item("EmployeeWeekStartDay")), drEmployee.Item("EmployeeWeekStartDay"), 1)
        EmployeeInitialDayOfFirstPeriod = drEmployee.SystemInitialDayOfFirstPeriod
        EmployeeInitialDayOfLastPeriod = drEmployee.SystemInitialDayOfLastPeriod
        EmployeeInitialDayOfTheMonth = drEmployee.InitialDayOfTheMonth
        Dim dtPeriodStartDate As Date = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        Dim dtPeriodEndDate As Date = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryForMobileBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, EmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> DBUtilities.GetEmployeeTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        End If
        Return TimeEntryBLL.GetTimeEntryPeriodIdForTimeEntry(AccountId, AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, TimesheetPeriodType, False, False, False, False)
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub InsertTimeEntry(ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal TotalTime As Double, _
                    ByVal Description As String, _
                    ByVal Submitted As Boolean)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        TimeEntryBLL.AddAccountEmployeeTimeEntryFromAPI(AccountId, AccountEmployeeId, dtDate, AccountProjectId, AccountProjectTaskId, TotalTime, Description, Submitted)
    End Sub
    <WebMethod()> _
   <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddTimeEntry(ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal Description As String,
                    ByVal AccountWorkTypeId As Integer, ByVal AccountCostCenterId As Integer) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim TimeEntry As New ArrayList
            If StartTime = "" Then
                StartTime = Nothing
            End If
            If EndTime = "" Then
                EndTime = Nothing
            End If
            Dim objTimeEntry = "Insert Record Succesfully"
            Dim TimeEntryBLL As New AccountEmployeeTimeEntryForMobileBLL
            Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
            Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
            Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
            TimeEntryBLL.AddAccountEmployeeTimeEntryFromMobileAPI(AccountId, AccountEmployeeId, dtDate, AccountProjectId, AccountProjectTaskId, StartTime, EndTime, TotalTime, Description, False, AccountWorkTypeId, AccountCostCenterId)
            TimeEntry.Add(objTimeEntry)
            Return objTimeEntry
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    <WebMethod()> _
 <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function UpdateTimeEntry(ByVal AccountEmployeeTimeEntryId As Integer, _
                    ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer, _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal StartTime As String, _
                    ByVal EndTime As String, _
                    ByVal TotalTime As String, _
                    ByVal Description As String,
                    ByVal AccountWorkTypeId As Integer, ByVal AccountCostCenterId As Integer)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim TimeEntry As New ArrayList
            If StartTime = "" Then
                StartTime = Nothing
            End If
            If EndTime = "" Then
                EndTime = Nothing
            End If
            Dim objTimeEntry = "Update Record Succesfully"
            Dim TimeEntryBLL As New AccountEmployeeTimeEntryForMobileBLL
            Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
            Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
            Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
            TimeEntryBLL.UpdateAccountEmployeeTimeEntryFromMobileAPI(AccountEmployeeTimeEntryId, AccountId, AccountEmployeeId, dtDate, AccountProjectId, AccountProjectTaskId, StartTime, EndTime, TotalTime, Description, False, AccountWorkTypeId, AccountCostCenterId)
            TimeEntry.Add(objTimeEntry)
            Return objTimeEntry
        Catch ex As Exception
            Throw ex.InnerException
        End Try
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function SubmitTimesheet(ByVal AccountEmployeeTimeEntryPeriodId As String) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
            Dim TimeEntryBLL As New AccountEmployeeTimeEntryForMobileBLL
            Dim PeriodId As New Guid(AccountEmployeeTimeEntryPeriodId)
            TimeEntryBLL.UpdateAccountEmployeeTimeEntryPeriodAndApprovalProjectForMobile(AccountEmployeeTimeEntryPeriodId, AccountEmployeeId)
            Return "Record Updated"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTimesheetApprovals() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TimesheetApprovalArrayList As New ArrayList
        Dim objTimesheetApproval As New TimesheetApprovalObject
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim TotalHours As String = "00:00"
        Dim dtTimesheetApproval As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingForApprovalDataTable = TimeEntryBLL.GetApprovalEntriesForMobile(AccountEmployeeId)
        Dim drTimesheetApproval As AccountEmployeeTimeEntry.vueTimesheetSummaryPendingForApprovalRow
        For Each drTimesheetApproval In dtTimesheetApproval.Rows
            objTimesheetApproval = New TimesheetApprovalObject
            With objTimesheetApproval
                .EmployeeName = drTimesheetApproval.EmployeeName
                .StartDate = drTimesheetApproval.TimeEntryStartDate
                .EndDate = drTimesheetApproval.TimeEntryEndDate
                TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForMobile(drTimesheetApproval.TotalMinutes)
                .TotalHours = TotalHours
                .TimesheetPeriodId = drTimesheetApproval.AccountEmployeeTimeEntryPeriodId.ToString
                .SystemApproverTypeId = drTimesheetApproval.SystemApproverTypeId

            End With
            TimesheetApprovalArrayList.Add(objTimesheetApproval)
        Next
        Return TimesheetApprovalArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function UpdateTimesheetApprovals(ApprovalList As ArrayList) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim TimesheetApprovalArrayList As New ArrayList
            Dim objTimesheetApproval As New TimesheetApprovalObject
            Dim TimeEntryMobileBLL As New AccountEmployeeTimeEntryForMobileBLL
            Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL

            Dim EmployeeBLL As New AccountEmployeeBLL
            Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
            Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
            For i As Integer = 0 To ApprovalList.Count - 1
                Dim nodetest = ApprovalList.Item(i)
                Dim systemapprovertypeid = nodetest(0).firstchild.value
                Dim TimeEntryPeriodId As New Guid(nodetest(1).firstchild.value.ToString)
                Dim IsApprove = nodetest(2).firstchild.value
                Dim IsReject = nodetest(3).firstchild.value

                Dim dtAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodDataTable = TimeEntryBLL.GetvueAccountEmployeeTimeEntryPeriodByAccountEmployeeTimeEntryPeriodId(TimeEntryPeriodId)
                Dim drAccountEmployeeTimeEntryPeriod As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodRow
                If dtAccountEmployeeTimeEntryPeriod.Rows.Count > 0 Then
                    drAccountEmployeeTimeEntryPeriod = dtAccountEmployeeTimeEntryPeriod.Rows(0)

                    Dim dtemployee As AccountEmployee.AccountEmployeeDataTable = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    Dim dremployee As AccountEmployee.AccountEmployeeRow = dtemployee.Rows(0)

                    TimeEntryMobileBLL.UpdateTimesheetApprovalForMobile(AccountId, AccountEmployeeId, dremployee.FirstName & " " & dremployee.LastName, AccountEmployeeId, dremployee.EMailAddress, drAccountEmployeeTimeEntryPeriod.TimeEntryStartDate, drAccountEmployeeTimeEntryPeriod.TimeEntryEndDate, TimeEntryPeriodId, "MObile Test", 0, IsApprove, IsReject, systemapprovertypeid)
                End If
            Next
            Return "Record Updated"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
End Class