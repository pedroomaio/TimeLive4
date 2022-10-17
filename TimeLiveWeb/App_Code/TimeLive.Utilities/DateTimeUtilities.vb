Imports Microsoft.VisualBasic

Public Module DateTimeUtilities
    Dim dtPeriodStartDate As Date = #1/1/2010#
    Dim dtPeriodEndDate As Date = #1/1/2010#
    Dim dtCopyFromStartDate As Date = #1/1/2010#
    Dim dtCopyFromEndDate As Date = #1/1/2010#
    Dim TimesheetPeriodType As String
    Dim SystemTimesheetPeriodType As String
    Dim EmployeeWeekStartDay As Integer
    Dim SystemInitialDayOfFirstPeriod As Integer
    Dim SystemInitialDayOfLastPeriod As Integer
    Dim InitialDayOfTheMonth As Integer
    Public Function GetStartDateOfDay(ByVal dtDate As Date) As Date
        Dim dtStartDate As Date = dtDate.AddDays(0)
        Return dtStartDate
    End Function
    Public Function GetStartDateOfWeek(ByVal dtDate As Date, ByVal WeekStartDay As Integer) As Date
        Dim dtStartDate As Date = dtDate.AddDays(WeekStartDay - GetWorkingDayOfWeek(dtDate))
        If dtDate.Year > 1900 Then
            If dtStartDate > dtDate Then
                dtStartDate = dtStartDate.AddDays(-7)
            End If
        Else
            Exit Function
        End If
        Return dtStartDate
    End Function
    Public Function GetStartDateOfBiWeekly(ByVal dtDate As Date, ByVal WeekStartDay As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As Date
        Dim AccountId As Integer
        Dim EmployeeBLL As New AccountEmployeeBLL
        If AccountEmployeeId <> 0 Then
            AccountId = EmployeeBLL.GetAccountIdByAccountEmployeeId(AccountEmployeeId)
        Else
            AccountId = 0
        End If
        Dim dtStartDate As Date
        If Not System.Configuration.ConfigurationManager.AppSettings("TEMP_ID") Is Nothing Then
            If DBUtilities.IsApplicationContext Then
                If DBUtilities.GetSessionAccountId = System.Configuration.ConfigurationManager.AppSettings("TEMP_ID") Then
                    dtStartDate = DateAdd(DateInterval.Day, -DateDiff(DateInterval.Day, #12/27/2014#, dtDate) Mod 14, dtDate)
                Else
                    dtStartDate = DateAdd(DateInterval.Day, -DateDiff(DateInterval.Day, GetWeekStartDateForBiWeekly(WeekStartDay), dtDate) Mod 14, dtDate)
                End If
            Else
                If AccountId = System.Configuration.ConfigurationManager.AppSettings("TEMP_ID") Then
                    dtStartDate = DateAdd(DateInterval.Day, -DateDiff(DateInterval.Day, #12/27/2014#, dtDate) Mod 14, dtDate)
                Else
                    dtStartDate = DateAdd(DateInterval.Day, -DateDiff(DateInterval.Day, GetWeekStartDateForBiWeekly(WeekStartDay), dtDate) Mod 14, dtDate)
                End If
            End If
        Else
            dtStartDate = DateAdd(DateInterval.Day, -DateDiff(DateInterval.Day, GetWeekStartDateForBiWeekly(WeekStartDay), dtDate) Mod 14, dtDate)
        End If
        If dtStartDate > dtDate Then
            dtStartDate = dtStartDate.AddDays(-14)
        End If
        Return dtStartDate
    End Function
    Public Function GetStartDateOfSemiMonthly(ByVal dtDate As Date, ByVal InitialDayOfFirstPeriod As Integer, ByVal InitialDayOfLastPeriod As Integer) As Date
        Dim FirstPeriodDateStart As Date
        Dim SecondPeriodDateStart As Date
        Dim FirstPeriodDateEnd As Date
        Dim SecondPeriodDateEnd As Date

        Dim FirstPeriodStart As Integer
        Dim SecondPeriodStart As Integer
        Dim FirstPeriodEnd As Integer
        Dim SecondPeriodEnd As Integer

        Dim dtStartDate As Date
        Dim dtEndDate As Date
        Dim PreviousMonthDate As Date
        Dim NextMonthDate As Date

        FirstPeriodStart = InitialDayOfFirstPeriod
        FirstPeriodEnd = InitialDayOfLastPeriod - 1

        SecondPeriodStart = InitialDayOfLastPeriod
        SecondPeriodEnd = InitialDayOfFirstPeriod - 1

        If dtDate.Day >= FirstPeriodStart And dtDate.Day <= FirstPeriodEnd Then
            dtStartDate = DateSerial(dtDate.Year, dtDate.Month, FirstPeriodStart)
        Else
            PreviousMonthDate = DateAdd(DateInterval.Month, -1, dtDate)
            NextMonthDate = DateAdd(DateInterval.Month, +1, dtDate)
            dtStartDate = DateSerial(dtDate.Year, dtDate.Month, SecondPeriodStart)
            dtEndDate = DateSerial(dtDate.Year, dtDate.Month, SecondPeriodEnd)
            If SecondPeriodStart > SecondPeriodEnd Then
                dtStartDate = DateSerial(PreviousMonthDate.Year, PreviousMonthDate.Month, SecondPeriodStart)
                dtEndDate = DateSerial(dtDate.Year, dtDate.Month, SecondPeriodEnd)
                If dtDate.Day >= SecondPeriodStart Then
                    dtStartDate = DateSerial(dtDate.Year, dtDate.Month, SecondPeriodStart)
                    dtEndDate = DateSerial(NextMonthDate.Year, NextMonthDate.Month, SecondPeriodEnd)
                End If
            End If
        End If
        Return dtStartDate
    End Function
    Public Function GetStartDateOfMonth(ByVal dtDate As Date, ByVal InitialDayOfTheMonth As Integer) As Date
        Dim InitialDayOfMonth As Integer = Date.DaysInMonth(dtDate.Year, dtDate.Month)
        If InitialDayOfTheMonth <= InitialDayOfMonth Then
            InitialDayOfMonth = InitialDayOfTheMonth
        End If
        Dim dtStartDate As Date = New Date(dtDate.Year, dtDate.Month, InitialDayOfMonth)
        If dtStartDate.Day > dtDate.Day Then
            dtStartDate = dtStartDate.AddMonths(-1)
        End If
        Return dtStartDate
    End Function
    Public Function GetStartDateOfWeekByEmployee(ByVal dtDate As Date, ByVal AccountEmployeeId As Integer) As Date
        Dim BLL As New AccountWorkingDayBLL
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dt As TimeLiveDataSet.vueAccountWorkingDayDataTable = BLL.GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId(DBUtilities.GetSessionAccountId, EmployeeBLL.GetAccountWorkingDayTypeIdByEmployeeId(AccountEmployeeId))
        Dim dr As TimeLiveDataSet.vueAccountWorkingDayRow
        dr = dt.Rows(0)
        Dim WeekStartDate As Integer = dr.WeekStartDay
        Dim dtStartDate As Date = dtDate.AddDays(WeekStartDate - GetWorkingDayOfWeek(dtDate))
        If dtStartDate > dtDate Then
            dtStartDate = dtStartDate.AddDays(-7)
        End If
        Return dtStartDate
    End Function
    Public Function GetEndDateOfDay(ByVal dtDate As Date) As Date
        Dim dtStartDate As Date = GetStartDateOfDay(dtDate)
        Dim dtEndDate As Date = dtStartDate.AddDays(0)
        Return dtEndDate
    End Function
    Public Function GetEndDateOfWeek(ByVal dtDate As Date, ByVal WeekStartDay As Integer) As Date
        Dim dtStartDate As Date = GetStartDateOfWeek(dtDate, WeekStartDay)
        Dim dtEndDate As Date = dtStartDate.AddDays(6)
        Return dtEndDate
    End Function
    Public Function GetEndDateOfWeekBiWeekly(ByVal dtDate As Date, ByVal WeekStartDay As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As Date
        Dim dtStartDate As Date = GetStartDateOfBiWeekly(dtDate, WeekStartDay, AccountEmployeeId)
        Dim dtEndDate As Date = dtStartDate.AddDays(13)
        Return dtEndDate
    End Function
    Public Function GetEndDateOfSemiMonthly(ByVal dtDate As Date, ByVal InitialDayOfFirstPeriod As Integer, ByVal InitialDayOfLastPeriod As Integer) As Date
        Dim FirstPeriodDateStart As Date
        Dim SecondPeriodDateStart As Date
        Dim FirstPeriodDateEnd As Date
        Dim SecondPeriodDateEnd As Date

        Dim FirstPeriodStart As Integer
        Dim SecondPeriodStart As Integer
        Dim FirstPeriodEnd As Integer
        Dim SecondPeriodEnd As Integer

        Dim dtStartDate As Date
        Dim dtEndDate As Date
        Dim PreviousMonthDate As Date
        Dim NextMonthDate As Date

        FirstPeriodStart = InitialDayOfFirstPeriod
        FirstPeriodEnd = InitialDayOfLastPeriod - 1

        SecondPeriodStart = InitialDayOfLastPeriod
        SecondPeriodEnd = InitialDayOfFirstPeriod - 1

        If dtDate.Day >= FirstPeriodStart And dtDate.Day <= FirstPeriodEnd Then
            dtEndDate = DateSerial(dtDate.Year, dtDate.Month, FirstPeriodEnd)
        Else
            PreviousMonthDate = DateAdd(DateInterval.Month, -1, dtDate)
            NextMonthDate = DateAdd(DateInterval.Month, +1, dtDate)
            dtEndDate = DateSerial(dtDate.Year, dtDate.Month, SecondPeriodEnd)
            If SecondPeriodStart > SecondPeriodEnd Then
                dtEndDate = DateSerial(dtDate.Year, dtDate.Month, SecondPeriodEnd)
                If dtDate.Day >= SecondPeriodStart Then
                    dtEndDate = DateSerial(NextMonthDate.Year, NextMonthDate.Month, SecondPeriodEnd)
                End If
            End If
        End If

        Return dtEndDate
    End Function
    Public Function GetEndDateOfMonth(ByVal dtDate As Date, ByVal InitialDayOfTheMonth As Integer) As Date
        Dim dtStartDate As Date = GetStartDateOfMonth(dtDate, InitialDayOfTheMonth)
        Dim dtEndDate As Date = dtStartDate.AddDays(Date.DaysInMonth(dtStartDate.Year, dtStartDate.Month) - 1)
        Return dtEndDate
    End Function
    Public Function GetEndDateOfWeekByEmployee(ByVal dtDate As Date, ByVal AccountEmployeeId As Integer) As Date
        Dim BLL As New AccountWorkingDayBLL
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dt As TimeLiveDataSet.vueAccountWorkingDayDataTable = BLL.GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId(DBUtilities.GetSessionAccountId, EmployeeBLL.GetAccountWorkingDayTypeIdByEmployeeId(AccountEmployeeId))
        Dim dr As TimeLiveDataSet.vueAccountWorkingDayRow
        dr = dt.Rows(0)
        Dim WeekStartDate As Integer = dr.WeekStartDay
        Dim dtStartDate As Date = GetStartDateOfWeekByEmployee(dtDate, AccountEmployeeId)
        Dim dtEndDate As Date = dtStartDate.AddDays(6)
        Return dtEndDate
    End Function
    Public Function GetStartDateOfWeekForEmail(ByVal dtDate As Date) As Date

        dtDate.AddDays(GetWorkingDayOfWeek(dtDate))

        Dim dtStartDate As Date = dtDate.AddDays(-(GetWorkingDayOfWeek(dtDate) - 1))

        If dtStartDate > dtDate Then
            dtStartDate = dtStartDate.AddDays(-7)
        End If

        LoggingBLL.WriteToLog("GetStartDateOfWeekForEmail" & " " & dtStartDate)
        Return dtStartDate

    End Function
    Public Function GetEndDateOfWeekForEmail(ByVal dtDate As Date) As Date

        dtDate.AddDays(GetWorkingDayOfWeek(dtDate))

        Dim dtStartDate As Date = GetStartDateOfWeekForEmail(dtDate)

        Dim dtEndDate As Date = dtStartDate.AddDays(6)
        LoggingBLL.WriteToLog("GetEndDateOfWeekForEmail" & " " & dtEndDate)
        Return dtEndDate

    End Function

    Public Function GetWorkingDayOfWeek(ByVal dtDate As Date) As Integer

        Dim offset As Double = 0
        Select Case dtDate.DayOfWeek
            Case DayOfWeek.Monday : offset = 1
            Case DayOfWeek.Tuesday : offset = 2
            Case DayOfWeek.Wednesday : offset = 3
            Case DayOfWeek.Thursday : offset = 4
            Case DayOfWeek.Friday : offset = 5
            Case DayOfWeek.Saturday : offset = 6
            Case DayOfWeek.Sunday : offset = 7
        End Select

        Return offset

    End Function
    Public Function GetWeekStartDayForEmail() As Integer
        LoggingBLL.WriteToLog("GetWeekStartDayForEmail" & " " & "19000101")
        Return 19000101
    End Function
    Public Function GetWeekStartDateForBiWeekly(ByVal WeekStarDay As Integer) As Date
        Dim dtdate As Date = #1/1/1900#
        dtdate = dtdate.AddDays(-1)
        dtdate = dtdate.AddDays(WeekStarDay)
        Return dtdate
    End Function
    Public Function GetWorkingDays(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, Optional ByVal ForEmail As Boolean = False, Optional ByVal SystemTimesheetPeriodTypeEmail As String = "", _
    Optional ByVal EmployeeWeekStartDayEmail As Integer = 0, Optional ByVal SystemInitialDayOfFirstPeriodEmail As Integer = 0, Optional ByVal SystemInitialDayOfLastPeriodEmail As Integer = 0, Optional ByVal InitialDayOfTheMonthEmail As Integer = 0) As ArrayList
        If ForEmail = True Then
            SystemTimesheetPeriodType = SystemTimesheetPeriodTypeEmail
            EmployeeWeekStartDay = EmployeeWeekStartDayEmail
            SystemInitialDayOfFirstPeriod = SystemInitialDayOfFirstPeriodEmail
            SystemInitialDayOfLastPeriod = SystemInitialDayOfLastPeriodEmail
            InitialDayOfTheMonth = InitialDayOfTheMonthEmail
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodType)
            If TimesheetPeriodType <> SystemTimesheetPeriodType Then
                dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
                dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            End If
            PeriodStartDate = dtPeriodStartDate
            PeriodEndDate = dtPeriodEndDate
        End If
        Dim BLL As New AccountWorkingDayBLL
        Dim dt As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = BLL.GetWorkingDaysByAccountEmployeeId(AccountEmployeeId)
        Dim dr As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
        Dim WorkingDayArray As New ArrayList
        Dim DaysCount As Integer = DateDiff(DateInterval.Day, PeriodStartDate, PeriodEndDate)
        Dim i As Integer
        For i = 0 To DaysCount
            For Each dr In dt.Rows
                If Left(dr.WorkingDay, 3) = LocaleUtilitiesBLL.GetDayInCurrentLocale(PeriodStartDate) Then
                    WorkingDayArray.Add(PeriodStartDate)
                End If
            Next
            PeriodStartDate = PeriodStartDate.AddDays(1)
        Next
        Return WorkingDayArray
    End Function
    Public Function GetPeriodStartAndEndDate(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date, Optional ByVal ForEmail As Boolean = False, Optional ByVal SystemTimesheetPeriodTypeEmail As String = "", _
  Optional ByVal EmployeeWeekStartDayEmail As Integer = 0, Optional ByVal SystemInitialDayOfFirstPeriodEmail As Integer = 0, Optional ByVal SystemInitialDayOfLastPeriodEmail As Integer = 0, Optional ByVal InitialDayOfTheMonthEmail As Integer = 0) As ArrayList
        If ForEmail = True Then
            SystemTimesheetPeriodType = SystemTimesheetPeriodTypeEmail
            EmployeeWeekStartDay = EmployeeWeekStartDayEmail
            SystemInitialDayOfFirstPeriod = SystemInitialDayOfFirstPeriodEmail
            SystemInitialDayOfLastPeriod = SystemInitialDayOfLastPeriodEmail
            InitialDayOfTheMonth = InitialDayOfTheMonthEmail
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodType)
            If TimesheetPeriodType <> SystemTimesheetPeriodType Then
                dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
                dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            End If
            PeriodStartDate = dtPeriodStartDate
            PeriodEndDate = dtPeriodEndDate
        End If
        Dim WorkingDayArray As New ArrayList
        Dim DaysCount As Integer = DateDiff(DateInterval.Day, PeriodStartDate, PeriodEndDate)
        For i As Integer = 0 To DaysCount
            WorkingDayArray.Add(PeriodStartDate.AddDays(i))
        Next
        Return WorkingDayArray
    End Function
    Public Function GetWorkingDaysPeriodStartDateAndPeriodEndDate(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date) As ArrayList
        dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodType)
        If TimesheetPeriodType <> SystemTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        End If
        PeriodStartDate = dtPeriodStartDate
        PeriodEndDate = dtPeriodEndDate
        Dim BLL As New AccountWorkingDayBLL
        Dim dt As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = BLL.GetWorkingDaysByAccountEmployeeId(AccountEmployeeId)
        Dim dr As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
        Dim WorkingDayArray As New ArrayList
        Dim DaysCount As Integer = DateDiff(DateInterval.Day, PeriodStartDate, PeriodEndDate)
        Dim i As Integer
        For i = 0 To DaysCount
            For Each dr In dt.Rows
                If Left(dr.WorkingDay, 3) = LocaleUtilitiesBLL.GetDayInCurrentLocale(PeriodStartDate) Then
                    WorkingDayArray.Add(PeriodStartDate)
                End If
            Next
            PeriodStartDate = PeriodStartDate.AddDays(1)
        Next
        Return WorkingDayArray
    End Function
    Public Function GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date) As ArrayList
        dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodType)
        If TimesheetPeriodType <> SystemTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        End If
        PeriodStartDate = dtPeriodStartDate
        PeriodEndDate = dtPeriodEndDate
        Dim WorkingDayArray As New ArrayList
        Dim DaysCount As Integer = DateDiff(DateInterval.Day, PeriodStartDate, PeriodEndDate)
        For i As Integer = 0 To DaysCount
            WorkingDayArray.Add(PeriodStartDate.AddDays(i))
        Next
        Return WorkingDayArray
    End Function
    Public Function GetWorkingDaysByDate(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal PeriodStartDate As Date, ByVal PeriodEndDate As Date) As ArrayList
        dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, SystemTimesheetPeriodType)
        If TimesheetPeriodType <> SystemTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        End If
        'PeriodStartDate = dtPeriodStartDate
        'PeriodEndDate = dtPeriodEndDate
        Dim WorkingDayArray As New ArrayList
        Dim DaysCount As Integer = DateDiff(DateInterval.Day, PeriodStartDate, PeriodEndDate)
        For i As Integer = 0 To DaysCount
            WorkingDayArray.Add(PeriodStartDate.AddDays(i))
        Next
        Return WorkingDayArray
    End Function
    Public Sub SetDataInVariableForGetWorkingDays(ByVal AccountEmployeeId As Integer)
        If Not DBUtilities.IsApplicationContext() Then
            Dim EmployeeBLL As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
            Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
            SystemTimesheetPeriodType = IIf(Not IsDBNull(drEmployee.Item("SystemTimesheetPeriodType")), drEmployee.Item("SystemTimesheetPeriodType"), "Weekly")
            EmployeeWeekStartDay = IIf(Not IsDBNull(drEmployee.Item("EmployeeWeekStartDay")), drEmployee.Item("EmployeeWeekStartDay"), 1)
            SystemInitialDayOfFirstPeriod = drEmployee.SystemInitialDayOfFirstPeriod
            SystemInitialDayOfLastPeriod = drEmployee.SystemInitialDayOfLastPeriod
            InitialDayOfTheMonth = drEmployee.InitialDayOfTheMonth
        Else
            SystemTimesheetPeriodType = DBUtilities.GetEmployeeTimesheetPeriodType
            EmployeeWeekStartDay = DBUtilities.GetSessionEmployeeWeekStartDay
            SystemInitialDayOfFirstPeriod = DBUtilities.GetSystemInitialDayOfFirstPeriod
            SystemInitialDayOfLastPeriod = DBUtilities.GetSystemInitialDayOfLastPeriod
            InitialDayOfTheMonth = DBUtilities.GetInitialDayOfTheMonth
        End If
    End Sub

    Public Function GetPeriodStartDateByTimesheetPeriodType(ByVal dtDate As Date, ByVal TimesheetPeriodType As String, ByVal WeekStartDay As Integer, ByVal InitialDayOfFirstPeriod As Integer, ByVal InitialDayOfLastPeriod As Integer, ByVal InitialDayOfTheMonth As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As Date
        If TimesheetPeriodType = "Daily" Then
            Return GetStartDateOfDay(dtDate)
        ElseIf TimesheetPeriodType = "Weekly" Then
            Return GetStartDateOfWeek(dtDate, WeekStartDay)
        ElseIf TimesheetPeriodType = "BiWeekly" Then
            Return GetStartDateOfBiWeekly(dtDate, WeekStartDay, AccountEmployeeId)
        ElseIf TimesheetPeriodType = "Semi-Monthly" Then
            Return GetStartDateOfSemiMonthly(dtDate, InitialDayOfFirstPeriod, InitialDayOfLastPeriod)
        ElseIf TimesheetPeriodType = "Monthly" Then
            Return GetStartDateOfMonth(dtDate, InitialDayOfTheMonth)
        End If
    End Function
    Public Function GetPeriodEndDateByTimesheetPeriodType(ByVal dtDate As Date, ByVal TimesheetPeriodType As String, ByVal WeekStartDay As Integer, ByVal InitialDayOfFirstPeriod As Integer, ByVal InitialDayOfLastPeriod As Integer, ByVal InitialDayOfTheMonth As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As Date
        If TimesheetPeriodType = "Daily" Then
            Return GetEndDateOfDay(dtDate)
        ElseIf TimesheetPeriodType = "Weekly" Then
            Return DateTimeUtilities.GetEndDateOfWeek(dtDate, WeekStartDay)
        ElseIf TimesheetPeriodType = "BiWeekly" Then
            Return GetEndDateOfWeekBiWeekly(dtDate, WeekStartDay, AccountEmployeeId)
        ElseIf TimesheetPeriodType = "Semi-Monthly" Then
            Return GetEndDateOfSemiMonthly(dtDate, InitialDayOfFirstPeriod, InitialDayOfLastPeriod)
        ElseIf TimesheetPeriodType = "Monthly" Then
            Return GetEndDateOfMonth(dtDate, InitialDayOfTheMonth)
        End If
    End Function
    Public Function GetCopyFromStartDateByTimesheetPeriodType(ByVal dtCopyDate As Date, ByVal TimesheetPeriodType As String, ByVal WeekStartDay As Integer, ByVal InitialDayOfFirstPeriod As Integer, ByVal InitialDayOfLastPeriod As Integer, ByVal InitialDayOfTheMonth As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As Date
        If TimesheetPeriodType = "Daily" Then
            Return GetStartDateOfDay(dtCopyDate)
        ElseIf TimesheetPeriodType = "Weekly" Then
            Return GetStartDateOfWeek(dtCopyDate, WeekStartDay)
        ElseIf TimesheetPeriodType = "BiWeekly" Then
            Return GetStartDateOfBiWeekly(dtCopyDate, WeekStartDay, AccountEmployeeId)
        ElseIf TimesheetPeriodType = "Semi-Monthly" Then
            Return GetStartDateOfSemiMonthly(dtCopyDate, InitialDayOfFirstPeriod, InitialDayOfLastPeriod)
        ElseIf TimesheetPeriodType = "Monthly" Then
            Return GetStartDateOfMonth(dtCopyDate, InitialDayOfTheMonth)
        End If
    End Function
    Public Function GetCopyFromEndDateByTimesheetPeriodType(ByVal dtCopyDate As Date, ByVal TimesheetPeriodType As String, ByVal WeekStartDay As Integer, ByVal InitialDayOfFirstPeriod As Integer, ByVal InitialDayOfLastPeriod As Integer, ByVal InitialDayOfTheMonth As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As Date
        If TimesheetPeriodType = "Daily" Then
            Return GetEndDateOfDay(dtCopyDate)
        ElseIf TimesheetPeriodType = "Weekly" Then
            Return DateTimeUtilities.GetEndDateOfWeek(dtCopyDate, WeekStartDay)
        ElseIf TimesheetPeriodType = "BiWeekly" Then
            Return GetEndDateOfWeekBiWeekly(dtCopyDate, WeekStartDay, AccountEmployeeId)
        ElseIf TimesheetPeriodType = "Semi-Monthly" Then
            Return GetEndDateOfSemiMonthly(dtCopyDate, InitialDayOfFirstPeriod, InitialDayOfLastPeriod)
        ElseIf TimesheetPeriodType = "Monthly" Then
            Return GetEndDateOfMonth(dtCopyDate, InitialDayOfTheMonth)
        End If
    End Function
    Public Function GetWorkingDaysForCopy(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date) As ArrayList
        SetDataInVariableForGetWorkingDays(AccountEmployeeId)
        dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(dtDate, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, AccountEmployeeId)
        Dim BLL As New AccountWorkingDayBLL
        Dim dt As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = BLL.GetWorkingDaysByAccountEmployeeId(AccountEmployeeId)
        Dim dr As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
        Dim WorkingDayArray As New ArrayList
        Dim DaysCount As Integer = DateDiff(DateInterval.Day, dtPeriodStartDate, dtPeriodEndDate)
        Dim i As Integer
        For i = 0 To DaysCount
            For Each dr In dt.Rows
                If Left(dr.WorkingDay, 3) = LocaleUtilitiesBLL.GetDayInCurrentLocale(dtPeriodStartDate) Then
                    WorkingDayArray.Add(dtPeriodStartDate)
                End If
            Next
            dtPeriodStartDate = dtPeriodStartDate.AddDays(1)
        Next
        Return WorkingDayArray
    End Function
End Module


