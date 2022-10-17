Imports Microsoft.VisualBasic
Imports System.Web
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class OverDueTimesheetsBLL


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetOverdueByAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As DataTable
        Dim SystemTimesheetPeriodType As String
        Dim WorkingDaysArray As ArrayList
        Dim TimesheetPeriodDaysArray As ArrayList
        Dim TimeEntryStartDate As Date = Now.Date
        Dim TimeEntryEndDate As Date = Now.Date
        Dim WeekStartDate As Date
        Dim CultureInfoName As String = LocaleUtilitiesBLL.GetCurrentCulture()
        If CultureInfoName = "auto" Then
            CultureInfoName = "en-us"
        End If
        Dim SumTotalMinutes As Integer
        Dim TotalHours As String = "00:00"
        Dim TotalMinutes As Integer = 0
        Dim starttime As DateTime = Now
        Dim dtOverdue As New DataTable
        Dim drOverdue As DataRow
        Dim CreatedOn As Date
        Dim BLLAccountEmployeeTimeEntry As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(AccountEmployeeId)
        Dim TimesheetOverduePeriods As Short = DBUtilities.GetSessionTimesheetOverduePeriods
        TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(AccountEmployeeId, Now.Date, Now.Date, Now.Date)
        WorkingDaysArray = DateTimeUtilities.GetWorkingDaysPeriodStartDateAndPeriodEndDate(AccountEmployeeId, Now.Date, Now.Date, Now.Date)
        For n As Integer = 0 To WorkingDaysArray.Count - 1
            dtOverdue.Columns.Add("OverdueColumn" & n, GetType(String))
        Next
        dtOverdue.Columns.Add("MinimumHours", GetType(String))
        dtOverdue.Columns.Add("TotalHours", GetType(String))
        dtOverdue.Columns.Add("TimesheetStatus", GetType(String))
        TimeEntryStartDate = TimesheetPeriodDaysArray(0)
        TimeEntryEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
        For i As Integer = 0 To TimesheetOverduePeriods - 1
            TimeEntryStartDate = TimeEntryStartDate.AddDays(-1)
            SystemTimesheetPeriodType = DBUtilities.GetEmployeeTimesheetPeriodType
            WorkingDaysArray = DateTimeUtilities.GetWorkingDaysPeriodStartDateAndPeriodEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
            If WorkingDaysArray.Count > 0 Then
                If BLLAccountEmployeeTimeEntry.CheckCreatedDateForPreviousPeriod(WorkingDaysArray, LocaleUtilitiesBLL.GetSessionEmployeeCreatedOnDate) = True Then
                    TimeEntryStartDate = WorkingDaysArray(0)
                    TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
                    TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
                    Dim TimesheetStatus As String = BLLAccountEmployeeTimeEntry.CheckOverDuePeriodsAndGetPeriodStatus(AccountId, AccountEmployeeId, SystemTimesheetPeriodType, TimesheetPeriodDaysArray)
                    If TimesheetStatus = "Not Submitted" Or TimesheetStatus = "Rejected" Then
                        drOverdue = dtOverdue.NewRow
                        Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = BLLAccountEmployeeTimeEntry.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                        For na As Integer = 0 To WorkingDaysArray.Count - 1
                            If WorkingDaysArray(na) <= Now.Date Then
                                Dim dr() As DataRow = dtEmployeesWithTimeEntry.Select("TimeEntryDate = '" & WorkingDaysArray(na) & "'")
                                If dr.Length > 0 Then
                                    TotalMinutes = dr(0).Item("TotalMinutes")
                                End If
                                TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(TotalMinutes)
                                SumTotalMinutes += TotalMinutes
                            End If
                            If Not drOverdue("OverdueColumn" & na) Is Nothing Then
                                drOverdue("OverdueColumn" & na) = LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDaysArray(na)) & "+" & LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocaleForEmail(WorkingDaysArray(na), CultureInfoName) & " - " & TotalHours
                            End If
                            TotalMinutes = 0
                        Next
                        drOverdue("MinimumHours") = DBUtilities.GetMinimumHoursPerWeek
                        drOverdue("TotalHours") = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(SumTotalMinutes)
                        drOverdue("TimesheetStatus") = TimesheetStatus
                        dtOverdue.Rows.Add(drOverdue)
                    End If
                End If
            End If
            If WorkingDaysArray.Count = 0 Then
                Dim dtdate As Date = TimeEntryStartDate.AddDays(-1)
                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(AccountEmployeeId, dtdate, dtdate, dtdate)
                TimeEntryStartDate = TimesheetPeriodDaysArray(0)
            End If
        Next
        UIUtilities.FixTableForNoRecords(dtOverdue)
        Return dtOverdue
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimesheetDueByAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As DataTable
        Dim SystemTimesheetPeriodType As String
        Dim WorkingDaysArray As ArrayList
        Dim TimesheetPeriodDaysArray As ArrayList
        Dim TimeEntryStartDate As Date = Now.Date
        Dim TimeEntryEndDate As Date = Now.Date
        Dim WeekStartDate As Date
        Dim CultureInfoName As String = LocaleUtilitiesBLL.GetCurrentCulture()
        If CultureInfoName = "auto" Then
            CultureInfoName = "en-us"
        End If
        Dim SumTotalMinutes As Integer
        Dim TotalHours As String = "00:00"
        Dim TotalMinutes As Integer = 0
        Dim starttime As DateTime = Now
        Dim dtDue As New DataTable
        Dim drDue As DataRow
        Dim CreatedOn As Date
        Dim BLLAccountEmployeeTimeEntry As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(AccountEmployeeId)
        Dim TimesheetOverduePeriods As Short = DBUtilities.GetSessionTimesheetOverduePeriods
        TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(AccountEmployeeId, Now.Date, Now.Date, Now.Date)
        WorkingDaysArray = DateTimeUtilities.GetWorkingDaysPeriodStartDateAndPeriodEndDate(AccountEmployeeId, Now.Date, Now.Date, Now.Date)
        For n As Integer = 0 To WorkingDaysArray.Count - 1
            dtDue.Columns.Add("DueColumn" & n, GetType(String))
            dtDue.Columns.Add("DueHours" & n, GetType(String))
            'dtDue.Columns.Add("DueTime" & n, GetType(String))
        Next
        dtDue.Columns.Add("MinimumHours", GetType(String))
        dtDue.Columns.Add("TotalHours", GetType(String))
        dtDue.Columns.Add("TimesheetStatus", GetType(String))
        TimeEntryStartDate = TimesheetPeriodDaysArray(0)
        TimeEntryEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
        SystemTimesheetPeriodType = DBUtilities.GetEmployeeTimesheetPeriodType
        WorkingDaysArray = DateTimeUtilities.GetWorkingDaysPeriodStartDateAndPeriodEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
        If WorkingDaysArray.Count > 0 And IsCurrentTimesheetdue(AccountEmployeeId) Then
            If BLLAccountEmployeeTimeEntry.CheckCreatedDateForPreviousPeriod(WorkingDaysArray, LocaleUtilitiesBLL.GetSessionEmployeeCreatedOnDate) = True Then
                TimeEntryStartDate = WorkingDaysArray(0)
                TimeEntryEndDate = WorkingDaysArray(WorkingDaysArray.Count - 1)
                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryStartDate, TimeEntryEndDate)
                Dim TimesheetStatus As String = BLLAccountEmployeeTimeEntry.CheckOverDuePeriodsAndGetPeriodStatus(AccountId, AccountEmployeeId, SystemTimesheetPeriodType, TimesheetPeriodDaysArray)
                If TimesheetStatus = "Not Submitted" Or TimesheetStatus = "Rejected" Then
                    drDue = dtDue.NewRow
                    Dim dtEmployeesWithTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEmailDataTable = BLLAccountEmployeeTimeEntry.GetvueAccountEmployeeTimeEntryForEmailByAccountEmployeeIdAndStartAndEndDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
                    For na As Integer = 0 To WorkingDaysArray.Count - 1
                        If WorkingDaysArray(na) <= Now.Date Then
                            Dim dr() As DataRow = dtEmployeesWithTimeEntry.Select("TimeEntryDate = '" & WorkingDaysArray(na) & "'")
                            If dr.Length > 0 Then
                                TotalMinutes = dr(0).Item("TotalMinutes")
                            End If
                            TotalHours = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(TotalMinutes)
                            SumTotalMinutes += TotalMinutes
                        End If
                        If Not drDue("DueColumn" & na) Is Nothing Then
                            drDue("DueColumn" & na) = LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDaysArray(na)) & " " & LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocaleForEmail(WorkingDaysArray(na), CultureInfoName)
                            drDue("DueHours" & na) = TotalHours
                            'drDue("DueTime" & na) = Now.Date
                        End If
                        TotalMinutes = 0
                    Next
                    drDue("MinimumHours") = DBUtilities.GetMinimumHoursPerWeek
                    drDue("TotalHours") = DBUtilities.GetDateTimeOfMinutesAsStringForEmail(SumTotalMinutes)
                    drDue("TimesheetStatus") = TimesheetStatus
                    dtDue.Rows.Add(drDue)
                End If
            End If
        End If
        If WorkingDaysArray.Count = 0 Then
            Dim dtdate As Date = TimeEntryStartDate.AddDays(-1)
            TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartAndEndDate(AccountEmployeeId, dtdate, dtdate, dtdate)
            TimeEntryStartDate = TimesheetPeriodDaysArray(0)
        End If
        UIUtilities.FixTableForNoRecords(dtDue)
        Return dtDue
    End Function
    Public Function IsCurrentTimesheetdue(AccountEmployeeId As Integer) As Boolean
        Dim WorkingDaysArray As ArrayList
        WorkingDaysArray = DateTimeUtilities.GetWorkingDaysPeriodStartDateAndPeriodEndDate(AccountEmployeeId, Now.Date, Now.Date, Now.Date)
        If WorkingDaysArray.Count > 0 Then
            Dim dtdate As Date = WorkingDaysArray(WorkingDaysArray.Count - 1)
            If Now.Date = dtdate.Date Then
                Return True
            End If
        End If
    End Function
End Class
