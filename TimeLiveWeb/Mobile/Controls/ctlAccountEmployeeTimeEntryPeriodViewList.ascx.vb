
Partial Class Mobile_Controls_ctlAccountEmployeeTimeEntryPeriodViewList
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
    Public Sub SetPeriodInTimeEntry()
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        TimeEntryAccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        AddValuesInViewState()
        Dim dtdate As Date = GetCurrentDate()
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
        lblPeriodDate.Text = dtStartDate & " - " & dtEndDate
        lblheader.Text = TimesheetPeriodType & " View"
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPeriodInTimeEntry()
        If Me.Request.QueryString("IsDelete") = "True" Then
            DeleteAccountEmployeeTimeEntry(Me.Request.QueryString("AccountEmployeeTimeEntryId"))
        End If
        ShowDate()
        LockWeekView()
        SetTimeSheetStatus()
    End Sub
    Public Sub SetTimeSheetStatus()
        Call New AccountEmployeeTimeEntryBLL().SetTimesheetStatus(lblTimesheetStatus, imgTSL, dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId)
    End Sub
    Public Function GetCurrentDate() As Date
        If Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            Me.txtTimeEntryDate.PostedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
            Me.txtTimeEntryDate.PostedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        ElseIf Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        End If
    End Function
    Public Sub ShowDate()
        Me.lblDayView.PostBackUrl = "~/Mobile/AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate)
        Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryStartDate").DefaultValue = Me.ViewState("dtStartDate")
        Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryEndDate").DefaultValue = Me.ViewState("dtEndDate")
        Me.dsAccountEmployeeTimeEntry.SelectParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = Me.ViewState("dtAccountEmployeeTimeEntryPeriodId").ToString
    End Sub
    Protected Sub txtTimeEntryDate_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeEntryDate.DateChanged
        Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate), False)
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("~/Mobile/AccountEmployeeTimeEntryForm.aspx?ViewType=PeriodView&TimeEntryDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(txtTimeEntryDate.PostedDate), False)
    End Sub
    Public Sub LockWeekView()
        If AccountEmployeeTimeEntryBLL.CheckSubmittedAndLockDayView(Me.ViewState("dtStartDate"), Me.ViewState("dtEndDate"), Me.ViewState("TimesheetPeriodType"), DBUtilities.GetSessionAccountEmployeeId) = True Then
            btnAdd.Enabled = False
        End If
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim objTimeEntry As New AccountEmployeeTimeEntryBLL
        SetPeriodInTimeEntry()
        Dim dv As DataView = objTimeEntry.GetAccountEmployeeTimeEntriesForPeriodView(TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, dtAccountEmployeeTimeEntryPeriodId, False, , , True)
        If dv.Table.Rows.Count > 0 Then
            If ValidateTimeEntryWeekView(dv.Table) Then
                AddAndUpdatePeriodRecord()
                SubmitTimeEntries(dv.Table)
                Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate), False)
            End If
        End If
    End Sub
    Public Sub SubmitTimeEntries(ByVal dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable)
        Dim objTimeEntry As New AccountEmployeeTimeEntryBLL
        Dim HTApprovalProject As New Hashtable
        Dim HTProjectApproved As New Hashtable
        Dim dr As DataRow
        For Each dr In dt.Rows
            Dim ApprovalProjectIdDataKey As Object
            Dim ProjectApprovedDataKey As Object
            Dim dtApprovalProjectId As Guid
            Dim dtAccountProjectId As Integer
            dtAccountProjectId = dr.Item("AccountProjectId")
            If Not dtAccountProjectId = 0 And Not HTApprovalProject.Contains("AccountProjectId=" & dtAccountProjectId) Then
                ApprovalProjectIdDataKey = IIf(IsDBNull(dr.Item("AccountEmployeeTimeEntryApprovalProjectId")), System.DBNull.Value, dr.Item("AccountEmployeeTimeEntryApprovalProjectId"))
                ProjectApprovedDataKey = IIf(IsDBNull(dr.Item("ProjectApproved")), False, dr.Item("ProjectApproved"))

                If objTimeEntry.SetApprovalStateForApprovalProject(dtAccountProjectId) = True Then
                    ProjectApprovedDataKey = True
                End If
                If Not IsDBNull(ApprovalProjectIdDataKey) Then
                    dtApprovalProjectId = ApprovalProjectIdDataKey
                    objTimeEntry.UpdateAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, True, "NULL", False, ProjectApprovedDataKey, False, dtApprovalProjectId)
                Else
                    dtApprovalProjectId = objTimeEntry.AddAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, True, False, False, ProjectApprovedDataKey, False, False)
                End If
                objTimeEntry.UpdateAccountEmployeeTimeEntryApprovalProjectIdByPeriodIdAndProjectId(dtApprovalProjectId, dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, True, ProjectApprovedDataKey)
                HTApprovalProject.Add("AccountProjectId=" & dtAccountProjectId, dtApprovalProjectId)
                HTProjectApproved.Add("AccountProjectId=" & dtAccountProjectId, ProjectApprovedDataKey)
            End If
            ProjectApprovedDataKey = HTProjectApproved.Item("AccountProjectId=" & dtAccountProjectId)
        Next
        objTimeEntry.SetAccountEmployeeTimeEntryPeriodApprovalStatus(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId)
    End Sub
    Public Function ValidateTimeEntryWeekView(ByVal dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable) As Boolean
        If Me.ValidateDayHours(dt) <> True Then
            Return False
        End If

        If Me.ValidateWeekHours(dt) <> True Then
            Return False
        End If
        Return True
    End Function
    Public Function ValidateDayHours(ByVal dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable) As Boolean
        Dim objrow As DataRow
        Dim DayHours As Double
        Dim TotalTime As String
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            For Each objrow In dt.Rows
                If CType(objrow.Item("TimeEntryDate"), Date).Date = WorkingDays(dayNo) Then
                    TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(objrow.Item("TotalTime"))
                    DayHours += Convert.ToDouble(DBUtilities.GetMinutesOfTime(TotalTime) / 60)
                End If
            Next
            If Math.Round(DayHours) > MaxDayHours Then
                Me.ShowNotFoundMessage("You may not enter more than " & MaxDayHours & " hours per day.")
                Return False
            End If
            If Math.Round(DayHours) < MinDayHours Then
                Me.ShowNotFoundMessage("You may not enter less than " & MinDayHours & " hours per day.")
                Return False
            End If
            DayHours = 0
        Next
        Return True
    End Function
    Public Function ValidateWeekHours(ByVal dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable) As Boolean
        Dim objrow As DataRow
        Dim WeekHours As Double
        Dim TotalTime As String
        For Each objrow In dt.Rows
            TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(objrow.Item("TotalTime"))
            WeekHours += Convert.ToDouble(DBUtilities.GetMinutesOfTime(TotalTime) / 60)
        Next
        If Math.Round(WeekHours) > MaxWeekHours Then
            Me.ShowNotFoundMessage("You may not enter more than " & MaxWeekHours & " hours in a period.")
            Return False
        End If
        If Math.Round(WeekHours) < MinWeekHours Then
            Me.ShowNotFoundMessage("You may not enter less than " & MinWeekHours & " hours in a period.")
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
    Public Sub AddAndUpdatePeriodRecord()
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            dtAccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, True, False, False, False, TimesheetPeriodType)
        Else
            objTimeEntryBLL.UpdateAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, True, False, False, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId)
        End If
        Me.ViewState.Add("dtAccountEmployeeTimeEntryPeriodId", dtAccountEmployeeTimeEntryPeriodId)
    End Sub
    Protected Sub R_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles R.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim Time As String = DBUtilities.GetMinutesOfTime(DataBinder.Eval(e.Item.DataItem, "TotalTime"))
            TotalTime += CSng(Time)
            lblTotalTime.Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime)
            If AccountEmployeeTimeEntryBLL.DoUnlockForRepeater(e) = False Then
                CType(e.Item.FindControl("lnkWeekView"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).OnClientClick = ""
            End If
            SetPeriodInTimeEntry()
            If AccountEmployeeTimeEntryBLL.CheckSubmittedAndLockWeekView(dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId) = True Then
                CType(e.Item.FindControl("lnkWeekView"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).Enabled = False
                CType(e.Item.FindControl("lnkDelete"), LinkButton).OnClientClick = ""
                btnAdd.Enabled = False
                btnSubmit.Enabled = False
            End If
        End If
    End Sub
    Public Sub DeleteAccountEmployeeTimeEntry(ByVal AccountEmployeeTimeEntryId As Integer)
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        objTimeEntryBLL.DeleteAccountEmployeeTimeEntryForMobile(AccountEmployeeTimeEntryId, TimesheetPeriodType, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate)
        Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate), False)
    End Sub
End Class
