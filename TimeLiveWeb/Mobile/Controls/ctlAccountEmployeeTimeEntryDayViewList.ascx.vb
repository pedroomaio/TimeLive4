Partial Class Mobile_Controls_ctlAccountEmployeeTimeEntryDayViewList
    Inherits System.Web.UI.UserControl
    Dim TimeEntryDate As Date
    Dim StartDate As Date
    Dim dtAccountEmployeeTimeEntryPeriodId As Guid
    Dim dtStartDate As DateTime = #11/1/2006#
    Dim dtEndDate As DateTime = #11/7/2006#
    Dim TimesheetPeriodType As String
    Dim EmployeeTimesheetPeriodType As String
    Dim EmployeeWeekStartDay As Integer
    Dim EmployeeInitialDayOfFirstPeriod As Integer
    Dim EmployeeInitialDayOfLastPeriod As Integer
    Dim EmployeeInitialDayOfTheMonth As Integer
    Dim TimeEntryAccountEmployeeId As Integer
    Dim MinDayHours As Double
    Dim MaxDayHours As Double
    Dim MinWeekHours As Double
    Dim MaxWeekHours As Double
    Dim EmployeeName As String
    Dim WorkingDays As ArrayList
    Dim WorkingDaysCount As Integer
    Dim TotalTime As String
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowForDate()
        SetPeriodInTimeEntry()
        If Me.Request.QueryString("IsDelete") = "True" Then
            DeleteAccountEmployeeTimeEntry(Me.Request.QueryString("AccountEmployeeTimeEntryId"))
        End If
        LockDayView()
        SetTimeSheetStatus()
    End Sub
    Public Sub SetTimeSheetStatus()
        Call New AccountEmployeeTimeEntryBLL().SetTimesheetStatus(lblTimesheetStatus, imgTSL, dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId)
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("~/Mobile/AccountEmployeeTimeEntryForm.aspx?ViewType=DayView&TimeEntryDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(txtTimeEntryDate.SelectedDate), False)
    End Sub
    Public Sub ShowForDate()
        If Not Request.QueryString("StartDate") Is Nothing Then
            Me.ViewState.Add("OriginalTimeEntryDate", txtTimeEntryDate.PostedDate)
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("StartDate"))
            Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("StartDate"))
        Else
            Me.ViewState.Add("OriginalTimeEntryDate", Me.txtTimeEntryDate.PostedDate)
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone()
            Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone()
        End If
        Me.ViewState.Add("TimeEntryDate", Me.txtTimeEntryDate.SelectedDate.Date)
        Me.lblPeriodView.PostBackUrl = "~/Mobile/AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate)
        Me.R.DataBind()
    End Sub
    Protected Sub txtTimeEntryDate_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeEntryDate.DateChanged
        Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("OriginalTimeEntryDate")), False)
    End Sub
    Public Sub LockDayView()
        If AccountEmployeeTimeEntryBLL.CheckSubmittedAndLockDayView(Me.ViewState("dtStartDate"), Me.ViewState("dtEndDate"), Me.ViewState("TimesheetPeriodType"), DBUtilities.GetSessionAccountEmployeeId) = True Then
            btnAdd.Enabled = False
        End If
    End Sub
    Public Sub SetPeriodInTimeEntry()
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        TimeEntryAccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        AddValuesInViewState()
        Dim dtdate As Date = Me.ViewState("TimeEntryDate")
        dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtdate, Me.ViewState("EmployeeTimesheetPeriodType"), Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtdate, Me.ViewState("EmployeeTimesheetPeriodType"), Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(Me.ViewState("TimeEntryAccountEmployeeId"), dtStartDate, dtEndDate, Me.ViewState("EmployeeTimesheetPeriodType"))
        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtdate, TimesheetPeriodType, Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtdate, TimesheetPeriodType, Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        End If
        WeekStartDayChanged()
        WorkingDays = DateTimeUtilities.GetWorkingDays(TimeEntryAccountEmployeeId, dtdate, dtStartDate, dtEndDate)
        WorkingDaysCount = WorkingDays.Count
        dtAccountEmployeeTimeEntryPeriodId = New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodIdForPeriodView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
        AddValuesInViewState()
        lblPeriodView.Text = TimesheetPeriodType & " View"
    End Sub
    Public Sub SetDataInVariableForGetWorkingDays(ByVal AccountEmployeeId As Integer)
        If DBUtilities.GetSessionAccountEmployeeId <> AccountEmployeeId Then
            Dim EmployeeBLL As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = EmployeeBLL.GetViewAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
            Dim drEmployee As AccountEmployee.vueAccountEmployeeRow = dtEmployee.Rows(0)
            EmployeeTimesheetPeriodType = IIf(Not IsDBNull(drEmployee.Item("SystemTimesheetPeriodType")), drEmployee.Item("SystemTimesheetPeriodType"), "Weekly")
            EmployeeWeekStartDay = IIf(Not IsDBNull(drEmployee.Item("EmployeeWeekStartDay")), drEmployee.Item("EmployeeWeekStartDay"), 1)
            EmployeeInitialDayOfFirstPeriod = drEmployee.SystemInitialDayOfFirstPeriod
            EmployeeInitialDayOfLastPeriod = drEmployee.SystemInitialDayOfLastPeriod
            EmployeeInitialDayOfTheMonth = drEmployee.InitialDayOfTheMonth
            MinDayHours = drEmployee.MinimumHoursPerDay
            MaxDayHours = drEmployee.MaximumHoursPerDay
            MinWeekHours = drEmployee.MinimumHoursPerWeek
            MaxWeekHours = drEmployee.MaximumHoursPerWeek
            EmployeeName = drEmployee.EmployeeNameWithCode
        Else
            EmployeeTimesheetPeriodType = DBUtilities.GetEmployeeTimesheetPeriodType
            EmployeeWeekStartDay = DBUtilities.GetSessionEmployeeWeekStartDay
            EmployeeInitialDayOfFirstPeriod = DBUtilities.GetSystemInitialDayOfFirstPeriod
            EmployeeInitialDayOfLastPeriod = DBUtilities.GetSystemInitialDayOfLastPeriod
            EmployeeInitialDayOfTheMonth = DBUtilities.GetInitialDayOfTheMonth
            MinDayHours = DBUtilities.GetMinimumHoursPerDay
            MaxDayHours = DBUtilities.GetMaximumHoursPerDay
            MinWeekHours = DBUtilities.GetMinimumHoursPerWeek
            MaxWeekHours = DBUtilities.GetMaximumHoursPerWeek
            EmployeeName = DBUtilities.GetEmployeeNameWithCode
        End If
    End Sub
    Public Sub WeekStartDayChanged()
        Dim NewStartDate As Date = New AccountEmployeeTimeEntryBLL().GetPeriodStartDate(TimeEntryAccountEmployeeId, dtEndDate, TimesheetPeriodType)
        Dim NewEndDate As Date = New AccountEmployeeTimeEntryBLL().GetPeriodEndDate(TimeEntryAccountEmployeeId, dtEndDate, TimesheetPeriodType)
        If Not NewStartDate = Nothing Then
            dtStartDate = NewStartDate
            dtEndDate = NewEndDate
        End If
    End Sub
    Public Sub AddValuesInViewState()
        Me.ViewState.Add("TimeEntryAccountEmployeeId", TimeEntryAccountEmployeeId)
        Me.ViewState.Add("EmployeeTimesheetPeriodType", EmployeeTimesheetPeriodType)
        Me.ViewState.Add("EmployeeWeekStartDay", EmployeeWeekStartDay)
        Me.ViewState.Add("EmployeeInitialDayOfFirstPeriod", EmployeeInitialDayOfFirstPeriod)
        Me.ViewState.Add("EmployeeInitialDayOfLastPeriod", EmployeeInitialDayOfLastPeriod)
        Me.ViewState.Add("EmployeeInitialDayOfTheMonth", EmployeeInitialDayOfTheMonth)
        Me.ViewState.Add("MinDayHours", MinDayHours)
        Me.ViewState.Add("MaxDayHours", MaxDayHours)
        Me.ViewState.Add("TimesheetPeriodType", TimesheetPeriodType)
        Me.ViewState.Add("dtStartDate", dtStartDate)
        Me.ViewState.Add("dtEndDate", dtEndDate)
        Me.ViewState.Add("dtAccountEmployeeTimeEntryPeriodId", dtAccountEmployeeTimeEntryPeriodId)
    End Sub
    Protected Sub R_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles R.ItemDataBound
        If (e.Item.ItemType = ListItemType.Header) Then
            TotalTime = 0
        End If
        If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim Time As String = DBUtilities.GetMinutesOfTime(DataBinder.Eval(e.Item.DataItem, "TotalTime"))
            TotalTime += CSng(Time)
            lblTotalTime.Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime)
            If AccountEmployeeTimeEntryBLL.DoUnlockForRepeater(e) = False Then
                CType(e.Item.FindControl("lnkDayView"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).OnClientClick = ""
            End If
            SetPeriodInTimeEntry()
            If AccountEmployeeTimeEntryBLL.CheckSubmittedAndLockDayView(dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId) = True Then
                CType(e.Item.FindControl("lnkDayView"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).OnClientClick = ""
                btnAdd.Enabled = False
            End If
        End If
    End Sub
    Public Sub DeleteAccountEmployeeTimeEntry(ByVal AccountEmployeeTimeEntryId As Integer)
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        objTimeEntryBLL.DeleteAccountEmployeeTimeEntryForMobile(AccountEmployeeTimeEntryId, TimesheetPeriodType, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate)
        Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("OriginalTimeEntryDate")), False)
    End Sub
End Class