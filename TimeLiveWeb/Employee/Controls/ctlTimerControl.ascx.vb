Imports System.Windows.Forms.Timer
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
''' <summary>
''' Controls for employee timer control 
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlTimerControl
    Inherits System.Web.UI.UserControl
    Dim pausetimer As Boolean = False
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
    Dim dtStartDate As Date = #11/1/2006#
    Dim dtEndDate As Date = #11/7/2006#
    Dim TimeEntryDate As DateTime = #11/7/2006#
    'Dim WV As New ASP.employee_controls_ctlaccountemployeetimeentryweekview_ascx
    'Dim DV As New ASP.employee_controls_ctlaccountemployeetimeentrydayview_ascx
    Dim StartDate As Date = #11/7/2006#
    Dim MyDate As Date = #11/7/2006#
    Dim Mode As String
    Dim Culture As String
    ''' <summary>
    ''' call pageinit event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim TimeEntryMode As String
        TimeEntryMode = DBUtilities.GetDefaultTimeEntryMode()
        TimeEntryAccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        'StartDate = LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(Me.Request.QueryString("StartDate"))
        StartDate = GetCurrentDate()
        'LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("StartDate"))
        Mode = Me.Request.QueryString("TimeEntryMode")

        dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(StartDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(StartDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, EmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(StartDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(StartDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        End If
        If Mode = "Day View" Then
            txtTimeEntryDate.LowerBoundDate = StartDate
            txtTimeEntryDate.UpperBoundDate = StartDate
            txtTimeEntryDate.VisibleDate = StartDate
            Culture = LocaleUtilitiesBLL.GetCurrentCulture
            If Culture = "auto" Then
                Culture = LocaleUtilitiesBLL.GetCurrentThreadCulture.ToString
            End If
            Me.txtTimeEntryDate.Culture = LocaleUtilitiesBLL.GetCultureInfoByCulture(Culture)
        Else
            Culture = LocaleUtilitiesBLL.GetCurrentCulture
            txtTimeEntryDate.LowerBoundDate = dtStartDate
            txtTimeEntryDate.UpperBoundDate = dtEndDate
            txtTimeEntryDate.VisibleDate = dtStartDate
            If Culture = "auto" Then
                Culture = LocaleUtilitiesBLL.GetCurrentThreadCulture.ToString
            End If
            Me.txtTimeEntryDate.Culture = LocaleUtilitiesBLL.GetCultureInfoByCulture(Culture)
            'Dim PDate As String = Convert.ToString(txtTimeEntryDate.PostedDate)
            'MyDate = Date.Parse(PDate)
        End If
    End Sub
    Public Function GetCurrentDate() As Date
        If Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertCurrentDateStringToDate(Me.txtTimeEntryDate.PostedDate)
            Return Me.txtTimeEntryDate.SelectedDate
        End If
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Dim tdate = LocaleUtilitiesBLL.ConvertDateBaseToStringForAllCultureTimer(txtTimeEntryDate.PostedDate)
    End Sub
    ''' <summary>
    ''' call button start timer click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnStartTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartTimer.Click
        If IsValidDataAvailable() Then
            Timer1.Enabled = True
            Dim TimeZoneStartTime As DateTime
            If hid_Ticker.Value = "0" Then
                TimeZoneStartTime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZone
                'txtStartTime.Text = DateTime.Now.ToString("HH:mm")
                txtStartTime.Text = TimeZoneStartTime.ToShortTimeString
            End If
            If Not IsPostBack Then
                hid_Ticker.Value = New TimeSpan(0, 0, 0).ToString()
            End If
            btnPauseTimer.Enabled = True
            btnEndTimer.Enabled = True
            btnStartTimer.Enabled = False
            ddlAccountClientId.Enabled = False
            ddlAccountProjectId.Enabled = False
            ddlAccountProjectTaskId.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' call button end timer click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnEndTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEndTimer.Click
        Timer1.Enabled = False
        Dim TimeZoneEndTime As DateTime
        TimeZoneEndTime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZone
        txtEndTime.Text = TimeZoneEndTime.ToShortTimeString
        Dim StartTime As DateTime = txtStartTime.Text
        Dim SH = StartTime.Hour
        Dim SM = StartTime.Minute
        Dim EndTime As DateTime = txtEndTime.Text
        Dim EH = EndTime.Hour
        Dim EM = EndTime.Minute
        Dim MinutesTotal = EM - SM
        Dim HoursTotal = EH - SH
        txtTimesheetTotal.Text = Convert.ToString(HoursTotal).PadLeft(2, "0") + ":" + Convert.ToString(MinutesTotal).PadLeft(2, "0")
        btnStartTimer.Text = "Start Timer"
        btnPauseTimer.Enabled = False
        btnEndTimer.Enabled = False
        ddlAccountClientId.Enabled = True
        ddlAccountProjectId.Enabled = True
        ddlAccountProjectTaskId.Enabled = True
        hid_Ticker.Value = 0
        Dim dtAccountEmployeeTimeEntryPeriodId As New Guid
        Dim bll As New AccountEmployeeTimeEntryBLL
        If Mode = "Day View" Then
            Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = bll.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
            Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                dtAccountEmployeeTimeEntryPeriodId = dr.AccountEmployeeTimeEntryPeriodId
            End If
            If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                dtAccountEmployeeTimeEntryPeriodId = bll.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate, False, False, False, False, TimesheetPeriodType, "")
            Else
                bll.UpdateAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate, False, False, False, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId, "")
            End If
            Dim WorkType As Integer = Me.GetStandardWorkType
            Dim AccountCostCenterId As Integer = DBUtilities.IsShowCostCenterInTimeSheet
            bll.AddAccountEmployeeTimeEntry(DBUtilities.GetSessionAccountEmployeeId, txtTimeEntryDate.SelectedDate, txtStartTime.Text, txtEndTime.Text, txtTimesheetTotal.Text, ddlAccountProjectId.SelectedValue, ddlAccountProjectTaskId.SelectedValue, "", False, Today.Date, Today.Date, 0, False, WorkType, AccountCostCenterId, TimesheetPeriodType, dtStartDate, dtEndDate, dtAccountEmployeeTimeEntryPeriodId, False, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty, 0)
            Dim strScript As String = "window.opener.location.href='AccountEmployeeTimeEntryDayView.aspx?Mode=Day&StartDate=" & Me.Request.QueryString("StartDate") & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId & "'; window.close();"
            If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
            End If
        Else
            Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = bll.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
            Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                dtAccountEmployeeTimeEntryPeriodId = dr.AccountEmployeeTimeEntryPeriodId
            End If

            If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                dtAccountEmployeeTimeEntryPeriodId = bll.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate, False, False, False, False, TimesheetPeriodType, "")
            Else
                bll.UpdateAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate, False, False, False, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId, "")
            End If
            Dim WorkType As Integer = Me.GetStandardWorkType
            Dim AccountCostCenterId As Integer = DBUtilities.IsShowCostCenterInTimeSheet
            bll.AddAccountEmployeeTimeEntry(DBUtilities.GetSessionAccountEmployeeId, txtTimeEntryDate.SelectedDate, txtStartTime.Text, txtEndTime.Text, txtTimesheetTotal.Text, ddlAccountProjectId.SelectedValue, ddlAccountProjectTaskId.SelectedValue, "", False, Today.Date, Today.Date, 0, False, WorkType, AccountCostCenterId, TimesheetPeriodType, dtStartDate, dtEndDate, dtAccountEmployeeTimeEntryPeriodId, False, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty, 0)
            Dim strScript As String = "window.opener.location.href='AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & Me.Request.QueryString("StartDate") & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId & "'; window.close();"
            If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
            End If
        End If
    End Sub
    ''' <summary>
    ''' time_tick event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        hid_Ticker.Value = TimeSpan.Parse(hid_Ticker.Value).Add(New TimeSpan(0, 0, 1)).ToString()
        lblTimer.Text = "Time spent: " + hid_Ticker.Value.ToString()
    End Sub
    ''' <summary>
    ''' pausetimer click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnPauseTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Timer1.Enabled = False
        pausetimer = True
        If pausetimer = True Then
            btnStartTimer.Text = "Resume Timer"
            btnStartTimer.Enabled = True
            btnPauseTimer.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' set data for working days, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
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
    Protected Sub ddlProjectTasks_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub txtTimeEntryDate_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    ''' <summary>
    ''' get standard work type this function
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStandardWorkType() As Decimal
        Dim BLL As New AccountWorkTypeBLL
        Dim dt As TimeLiveDataSet.AccountWorkTypeDataTable = BLL.GetAccountWorkTypesByAccountIdAndAccountWorkType(DBUtilities.GetSessionAccountId)
        Dim dr As TimeLiveDataSet.AccountWorkTypeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountWorkTypeId
        End If
    End Function
    ''' <summary>
    ''' set client dropdown select index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlAccountClientId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddlAccountProjectId.DataBind()
    End Sub
    ''' <summary>
    ''' set proejct dropdown select index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlAccountProjectId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dsAccountProjectTasksObject.SelectParameters("AccountProjectTaskId").DefaultValue = ""
    End Sub
    ''' <summary>
    ''' validation for project and task
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidDataAvailable() As Boolean
        If ddlAccountProjectId Is Nothing Then
            Return False
        End If
        If ddlAccountProjectTaskId.SelectedValue = "" Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' get client preference setting 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HideControlsByPreferenceSettings()
        If DBUtilities.GetShowClientInTimesheet = False Then
            Me.ddlAccountClientId.Visible = False
        End If
    End Sub

    Protected Sub txtTimeEntryDate_DateChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        'Culture = LocaleUtilitiesBLL.GetCurrentCulture
        'Me.txtTimeEntryDate.Culture = LocaleUtilitiesBLL.GetCultureInfoByCulture(Culture)
        'Me.txtTimeEntryDate.SelectedDate = txtTimeEntryDate.PostedDate
    End Sub
End Class