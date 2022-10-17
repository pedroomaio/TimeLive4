
Partial Class Mobile_Controls_ctlAccountEmployeeTimeEntryForm
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
    Dim EmployeeName As String
    Dim WorkingDays As ArrayList
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Not Me.Request.QueryString("TimeEntryDate") Is Nothing Then
                Me.TimeEntryDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("TimeEntryDate"))
                Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("TimeEntryDate"))
                'Me.txtTimeEntryDate.PostedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("TimeEntryDate"))
                Me.ViewState.Add("TimeEntryDate", Me.txtTimeEntryDate.PostedDate)
            Else
                Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
                Me.txtTimeEntryDate.PostedDate = Me.txtTimeEntryDate.SelectedDate
                Me.TimeEntryDate = Me.txtTimeEntryDate.SelectedDate
                Me.ViewState.Add("TimeEntryDate", Me.txtTimeEntryDate.PostedDate)
            End If
            BindTimeEntry()
        End If
        If Me.ViewState("TimeEntryDate") <> Me.txtTimeEntryDate.PostedDate Then
            Me.ViewState.Add("TimeEntryDate", Me.txtTimeEntryDate.PostedDate)
        End If
        Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.ViewState("TimeEntryDate"))
        'Me.txtTimeEntryDate.SelectedValue = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtTimeEntryDate.PostedDate)
        Me.txtTimeEntryDate.VisibleDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.ViewState("TimeEntryDate"))
    End Sub
    Public Sub SetPeriodInTimeEntry()
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        TimeEntryAccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        AddValuesInViewState()
        Dim dtdate As Date = Me.txtTimeEntryDate.PostedDate
        dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtdate, Me.ViewState("EmployeeTimesheetPeriodType"), Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtdate, Me.ViewState("EmployeeTimesheetPeriodType"), Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(Me.ViewState("TimeEntryAccountEmployeeId"), dtStartDate, dtEndDate, Me.ViewState("EmployeeTimesheetPeriodType"))
        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtdate, TimesheetPeriodType, Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtdate, TimesheetPeriodType, Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        End If
        WeekStartDayChanged()
        dtAccountEmployeeTimeEntryPeriodId = New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodIdForPeriodView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
        If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            dtAccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, False, False, False, False, TimesheetPeriodType)
        End If
        dsAccountProjectTasksObject.SelectParameters("Completed").DefaultValue = LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet
        AddValuesInViewState()
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
            EmployeeName = drEmployee.EmployeeNameWithCode
        Else
            EmployeeTimesheetPeriodType = DBUtilities.GetEmployeeTimesheetPeriodType
            EmployeeWeekStartDay = DBUtilities.GetSessionEmployeeWeekStartDay
            EmployeeInitialDayOfFirstPeriod = DBUtilities.GetSystemInitialDayOfFirstPeriod
            EmployeeInitialDayOfLastPeriod = DBUtilities.GetSystemInitialDayOfLastPeriod
            EmployeeInitialDayOfTheMonth = DBUtilities.GetInitialDayOfTheMonth
            MinDayHours = DBUtilities.GetMinimumHoursPerDay
            MaxDayHours = DBUtilities.GetMaximumHoursPerDay
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
    Protected Sub ddlAccountClientId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccountClientId.SelectedIndexChanged
        ddlAccountProjectId.DataBind()
    End Sub
    Public Sub Save()
        Dim objTimeEntry As New AccountEmployeeTimeEntryBLL
        Try
            If Me.Request.QueryString("AccountEmployeeTimeEntryId") Is Nothing Then
                InsertRecord()
            Else
                UpdateRecord()
            End If
            objTimeEntry.UpdateAccountEmployeeTimeEntryPeriodStatus(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, False, False, False, False, dtAccountEmployeeTimeEntryPeriodId)
        Catch ex As Exception
            Throw ex.InnerException
        End Try
    End Sub
    Public Sub InsertRecord()
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        TimeEntryBLL.AddAccountEmployeeTimeEntry(Me.ViewState("TimeEntryAccountEmployeeId"), txtTimeEntryDate.PostedDate, IIf(StartTime.Text = "", Nothing, StartTime.Text), _
        IIf(EndTime.Text = "", Nothing, EndTime.Text), TotalTime.Text, ddlAccountProjectId.SelectedValue, ddlAccountProjectTaskId.SelectedValue, _
        Description.Text, False, Now, Now, 0, False, ddlAccountWorkTypeId.SelectedValue, 0, Me.ViewState("TimesheetPeriodType"), Me.ViewState("dtStartDate"), Me.ViewState("dtEndDate"), Me.ViewState("dtAccountEmployeeTimeEntryPeriodId"), _
        False, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty, 0)
    End Sub
    Public Sub UpdateRecord()
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        TimeEntryBLL.UpdateAccountEmployeeTimeEntry(Me.ViewState("TimeEntryAccountEmployeeId"), txtTimeEntryDate.PostedDate, IIf(StartTime.Text = "", Nothing, StartTime.Text), _
        IIf(EndTime.Text = "", Nothing, EndTime.Text), TotalTime.Text, ddlAccountProjectId.SelectedValue, ddlAccountProjectTaskId.SelectedValue, _
        Me.Description.Text, False, False, False, False, Now, Me.Request.QueryString("AccountEmployeeTimeEntryId"), _
        0, False, ddlAccountWorkTypeId.SelectedValue, 0, Me.ViewState("TimesheetPeriodType"), Me.ViewState("dtStartDate"), Me.ViewState("dtEndDate"), _
        Me.ViewState("dtAccountEmployeeTimeEntryPeriodId"), False, System.Guid.Empty, System.Guid.Empty, 0)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateTimeEntry() Then
            SetPeriodInTimeEntry()
            Save()
            Response.Redirect(SetNavigateURL(txtTimeEntryDate.PostedDate), False)
        End If
    End Sub
    Public Sub BindTimeEntry()
        Dim AccountEmployeeTimeEntryId As Integer
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        If Not Me.Request.QueryString("AccountEmployeeTimeEntryId") Then
            AccountEmployeeTimeEntryId = Me.Request.QueryString("AccountEmployeeTimeEntryId")
        End If
        Dim dt As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = TimeEntryBLL.GetvueAccountEmployeeTimeEntryWithLastStatusByAccountEmployeeTimeEntryId(AccountEmployeeTimeEntryId)
        Dim dr As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.txtTimeEntryDate.SelectedDate = dr.TimeEntryDate
            Me.ViewState.Add("TimeEntryDate", dr.TimeEntryDate)
            Me.ddlAccountClientId.SelectedValue = dr.AccountClientId
            If Not IsDBNull(dr.Item("AccountProjectId")) Then
                Me.ddlAccountProjectId.SelectedValue = dr.AccountProjectId
            End If
            If Not IsDBNull(dr.Item("AccountProjectTaskId")) Then
                Me.ddlAccountProjectTaskId.SelectedValue = dr.AccountProjectTaskId
            End If
            If Not IsDBNull(dr.Item("AccountWorkTypeId")) Then
                Me.ddlAccountWorkTypeId.SelectedValue = dr.AccountWorkTypeId
            End If
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If DBUtilities.GetShowClockStartEnd Then
                    If Not IsDBNull(dr.Item("StartTime")) Then
                        Me.StartTime.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(dr.StartTime)
                    End If
                    If Not IsDBNull(dr.Item("EndTime")) Then
                        Me.EndTime.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(dr.EndTime)
                    End If
                End If
            Else
                If DBUtilities.ShowClockStartEndEmployee Then
                    If Not IsDBNull(dr.Item("StartTime")) Then
                        Me.StartTime.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(dr.StartTime)
                    End If
                    If Not IsDBNull(dr.Item("EndTime")) Then
                        Me.EndTime.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(dr.EndTime)
                    End If
                End If
            End If
           
            Me.TotalTime.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(dr.TotalTime)
            If Not IsDBNull(dr.Item("Description")) Then
                Me.Description.Text = dr.Description
            End If
            dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = dr.AccountProjectId
            dsAccountProjectTasksObject.SelectParameters("AccountProjectTaskId").DefaultValue = dr.AccountProjectTaskId
            ddlAccountClientId.DataBind()
            ddlAccountProjectId.DataBind()
            Me.btnSave.Text = "Update"
        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect(SetNavigateURL(txtTimeEntryDate.PostedDate), False)
    End Sub
    Protected Sub ddlAccountProjectId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccountProjectId.SelectedIndexChanged
        dsAccountProjectTasksObject.SelectParameters("AccountProjectTaskId").DefaultValue = ""
    End Sub
    Public Sub HideControlsByPreferenceSettings()
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = False Then
                Me.StartTime.Visible = False
                Me.EndTime.Visible = False
            End If
        Else
            If DBUtilities.ShowClockStartEndEmployee = False Then
                Me.StartTime.Visible = False
                Me.EndTime.Visible = False
            End If
        End If
        If DBUtilities.IsShowWorkTypeInTimeSheet = False Then
            Me.ddlAccountWorkTypeId.Visible = False
        End If
        If DBUtilities.GetShowClientInTimesheet = False Then
            Me.ddlAccountClientId.Visible = False
        End If
    End Sub
    Public Sub SetTimeFormatInGrid()
        If DBUtilities.IsNotSupportedCultureFormats = True Then
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If DBUtilities.GetShowClockStartEnd = True Then
                    DBUtilities.SetMaskEditExtenderCultureToUS(MaskedEditExtenderStartTime)
                    DBUtilities.SetMaskEditExtenderCultureToUS(MaskedEditExtenderEndTime)
                End If
            Else
                If DBUtilities.ShowClockStartEndEmployee = True Then
                    DBUtilities.SetMaskEditExtenderCultureToUS(MaskedEditExtenderStartTime)
                    DBUtilities.SetMaskEditExtenderCultureToUS(MaskedEditExtenderEndTime)
                End If
            End If
            DBUtilities.SetMaskEditExtenderCultureToUS(MaskedEditExtenderTotalTime)
        End If
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = True Then
                MaskedEditExtenderStartTime.AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                MaskedEditExtenderEndTime.AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
            End If
        Else
            If DBUtilities.ShowClockStartEndEmployee = True Then
                MaskedEditExtenderStartTime.AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                MaskedEditExtenderEndTime.AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
            End If
        End If
        MaskedEditExtenderTotalTime.AcceptAMPM = False
    End Sub
    Public Sub SetPermission()
        If AccountPagePermissionBLL.IsPageHasPermissionOf(18, 3) = False Then
            btnSave.Enabled = False
        End If
    End Sub
    Public Function SetNavigateURL(ByVal TimeEntryStartDate As Date) As String
        If Me.Request.QueryString("ViewType") Is Nothing OrElse Me.Request.QueryString("ViewType") = "WeekView" Then
            Return "~/Mobile/AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(TimeEntryStartDate)
        ElseIf Me.Request.QueryString("ViewType") = "DayView" Then
            Return "~/Mobile/AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(TimeEntryStartDate)
        Else
            Return "~/Mobile/AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(TimeEntryStartDate)
        End If
    End Function
    Public Function ValidateTimeEntry() As Boolean
        If ddlAccountProjectTaskId.SelectedValue = "" Then
            Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
            Return False
        End If
        If TotalTime.Text = "" Then
            Me.ShowNotFoundMessage("Please enter value in total time.")
            Return False
        End If
        If DBUtilities.GetMinutesOfTime(TotalTime.Text) = "0" Then
            Me.ShowNotFoundMessage("Please enter value more than 0 in total time.")
            Return False
        End If
        Return True
    End Function
    Public Sub ShowNotFoundMessage(ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
End Class