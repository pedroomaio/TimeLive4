Imports System.Collections.Specialized
Imports System.Collections.Generic
Imports System.Drawing
''' <summary>
''' Employee controls of employee time entry for week view
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryWeekView
    Inherits System.Web.UI.UserControl

    Public Const CLIENT_COLUMN As Integer = 0
    Public Const PROJECT_COLUMN As Integer = 1
    Public Const WORKTYPE_COLUMN As Integer = 4
    Public Const COSTCENTER_COLUMN As Integer = 3
    Dim dtStartDate As DateTime = #11/1/2006#
    Dim dtEndDate As DateTime = #11/7/2006#
    Dim dtCopyFromStartDate As DateTime = #11/1/2006#
    Dim dtCopyFromEndDate As DateTime = #11/7/2006#
    Public newRows As List(Of Integer)
    Dim StartDate As Date
    Dim SubmittedDayNo As New Hashtable
    Dim WorkingDays As ArrayList
    Dim WorkingDaysCount As Integer
    Dim TimesheetPeriodType As String
    Dim ButtonClicked As String
    Dim dtAccountEmployeeTimeEntryPeriodId As Guid
    Dim dtCopyAccountEmployeeTimeEntryPeriodId As Guid
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
    Dim MinDayPercentage As Double
    Dim MaxDayPercentage As Double
    Dim MinWeekPercentage As Double
    Dim MaxWeekPercentage As Double
    Dim EmployeeName As String
    Dim LockDate = Date.DaysInMonth(Now.Year, Now.Month)
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
        AuthenticateBLL.CheckSession(Page)
        Me.Show()
        Me.ShowTimerTimesheet()
        Me.ShowOfflineTimesheet()
        Me.ExportOfflineTimesheet()
        Me.ShowAttachment()
    End Sub
    ''' <summary>
    ''' Get current date 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentDate() As Date
        If Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            Me.ddlEmployee.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
            Me.ddlEmployee.SelectedValue = Me.Request.QueryString("AccountEmployeeId")
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        ElseIf Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Me.ddlEmployee.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Me.ddlEmployee.SelectedValue = Me.Request.QueryString("AccountEmployeeId")
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        End If
    End Function
    ''' <summary>
    ''' Get copy date
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCopyDate() As Date
        If Me.Request.QueryString("CopyDate") Is Nothing And Me.IsPostBack = False Then
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("CopyDate") Is Nothing And Me.IsPostBack = False Then
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("CopyDate"))
        ElseIf Me.Request.QueryString("CopyDate") Is Nothing And Me.IsPostBack = True Then
            If Not Me.CopyFromCalendarPopup.PostedDate Is Nothing Then
                Return Me.CopyFromCalendarPopup.PostedDate
            Else
                Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            End If
        ElseIf Not Me.Request.QueryString("CopyDate") Is Nothing And Me.IsPostBack = True Then
            Return Me.CopyFromCalendarPopup.PostedDate
        End If
    End Function
    ''' <summary>
    ''' Set data in variable for geting working days of specified AccountEmployeeId
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
            MinDayPercentage = drEmployee.MinimumPercentagePerDay
            MaxDayPercentage = drEmployee.MaximumPercentagePerDay
            MinWeekPercentage = drEmployee.MinimumPercentagePerWeek
            MaxWeekPercentage = drEmployee.MaximumPercentagePerWeek
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
            MinDayPercentage = DBUtilities.GetMinimumPercentagePerDay
            MaxDayPercentage = DBUtilities.GetMaximumPercentagePerDay
            MinWeekPercentage = DBUtilities.GetMinimumPercentagePerWeek
            MaxWeekPercentage = DBUtilities.GetMaximumPercentagePerWeek
            EmployeeName = DBUtilities.GetEmployeeNameWithCode
        End If
    End Sub
    ''' <summary>
    ''' Changed week start day
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WeekStartDayChanged()
        Dim NewStartDate As Date = New AccountEmployeeTimeEntryBLL().GetPeriodStartDate(TimeEntryAccountEmployeeId, dtEndDate, TimesheetPeriodType)
        Dim NewEndDate As Date = New AccountEmployeeTimeEntryBLL().GetPeriodEndDate(TimeEntryAccountEmployeeId, dtEndDate, TimesheetPeriodType)
        If Not NewStartDate = Nothing Then
            dtStartDate = NewStartDate
            dtEndDate = NewEndDate
        End If
    End Sub
    ''' <summary>
    ''' Show
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Show()
        'If Not Me.IsPostBack Then
        AccountEmployeeBLL.SetDataForEmployeeDropdown(18, ddlEmployee)
        'End If
        Dim dtDate As Date
        Dim dtCopyDate As Date
        dtDate = GetCurrentDate()

        TimeEntryAccountEmployeeId = Me.ddlEmployee.SelectedValue
        LoggingBLL.WriteToLog("Show: ddlEmployee.SelectedValue=" & ddlEmployee.SelectedValue)
        SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, EmployeeTimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, EmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        End If
        WeekStartDayChanged()
        WorkingDays = DateTimeUtilities.GetWorkingDays(TimeEntryAccountEmployeeId, dtDate, dtStartDate, dtEndDate)
        If WorkingDays.Count <> 0 Then
            dtCopyDate = GetCopyDate()
            dtCopyFromStartDate = DateTimeUtilities.GetCopyFromStartDateByTimesheetPeriodType(dtCopyDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
            dtCopyFromEndDate = DateTimeUtilities.GetCopyFromEndDateByTimesheetPeriodType(dtCopyDate, TimesheetPeriodType, EmployeeWeekStartDay, EmployeeInitialDayOfFirstPeriod, EmployeeInitialDayOfLastPeriod, EmployeeInitialDayOfTheMonth)
        End If
        WorkingDaysCount = WorkingDays.Count
        Me.lblCurrenctdate.Text = LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(dtStartDate) & " - " & LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(dtEndDate)
        Me.RefreshWeekView(False)
        Me.AddColumnsInWGByDate(dtDate)
        Me.HideColumnsInGridView()
        If Not dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            btnAudit.Visible = True
            btnAttachment.Visible = True
        End If
        WeekButton1.Attributes.Add("onclick", "javascript: if ( Page_ClientValidate() )" + "{" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + "}" + Me.Page.ClientScript.GetPostBackEventReference(WeekButton1, ""))
        btnTopSave.Attributes.Add("onclick", "javascript: if ( Page_ClientValidate() )" + "{" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + "}" + Me.Page.ClientScript.GetPostBackEventReference(btnTopSave, ""))
        btnCopy.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForWeekView + "javascript:" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnCopy, ""))
        btnCopyActivities.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForWeekView + "javascript:" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnCopyActivities, ""))
        btnCopyFromTemplate.Attributes.Add("onclick", ResourceHelper.GetCopyFromTemplateMessageJavascriptForWeekView + "javascript:" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnCopyFromTemplate, ""))
        btnSubmit.Attributes.Add("onclick", ResourceHelper.GetSubmitMessageJavascript + "javascript: if ( Page_ClientValidate() )" + "{" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + "}" + Me.Page.ClientScript.GetPostBackEventReference(btnSubmit, ""))
        btnTopSubmit.Attributes.Add("onclick", ResourceHelper.GetSubmitMessageJavascript + "javascript: if ( Page_ClientValidate() )" + "{" + btnCopyFromTemplate.ClientID + ".disabled=true;" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + WeekButton1.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSubmit.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnTopSubmit.ClientID + ".disabled=true;" + "}" + Me.Page.ClientScript.GetPostBackEventReference(btnTopSubmit, ""))
        System.Web.HttpContext.Current.Session("TotalApprovedEntries") = Nothing
        'btnSubmit.Attributes.Add("onclick", ResourceHelper.GetSubmitMessageJavascript)
        'btnTopSubmit.Attributes.Add("onclick", ResourceHelper.GetSubmitMessageJavascript)
        btnMyPeriods.PostBackUrl = "~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=PeriodView"
        btnTimesheetTemplate.PostBackUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewTemplate.aspx"
        btnAudit.PostBackUrl = "~/Employee/AccountEmployeeTimeEntryAudit.aspx?AccountEmployeeTimeEntryPeriodId=" & dtAccountEmployeeTimeEntryPeriodId.ToString
        btnDayView.PostBackUrl = "~/Employee/AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId
        Dim URL As String = "AccountEmployeeTimeEntryWeekViewReadOnly.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(dtStartDate) & "&IsPrint=True" & "&TimesheetPeriodType=" & TimesheetPeriodType
        btnPrint.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes'); return false;")
        If WorkingDaysCount = 0 Then
            DisableControlsInNonWorkingDay()
        End If
        'If DBUtilities.GetSessionAccountId = 6455 Then
        '    btnCopyFromTemplate.Visible = False
        '    btnTimesheetTemplate.Visible = False
        'End If
    End Sub
    ''' <summary>
    ''' Disable controls in non working day
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisableControlsInNonWorkingDay()
        G.Visible = False
        WeekButton1.Visible = False
        btnTopSave.Visible = False
        btnCopy.Visible = False
        btnCopyActivities.Visible = False
        btnCopyFromTemplate.Visible = False
        btnSubmit.Visible = False
        btnTopSubmit.Visible = False
        CopyFromCalendarPopup.Visible = False
        lblPermissionMessage.Visible = True
        lblCopyFrom.Visible = False
        Label4.Visible = False
        txtPeriodDescription.Visible = False
        btnPrint.Visible = False
        btnExportOfflineTimesheet.Visible = False
        btnImportOfflineTimesheet.Visible = False
        btnAudit.Visible = False
        btnTimerTimesheet.Visible = False
        lblTimesheetStatus.Text = ResourceHelper.GetFromResource("Not Submitted")
        imgTSL.ImageUrl = "~/images/NotSubmittedStatus.gif"
        txtTimesheetTotal.Text = "00:00"
    End Sub
    ''' <summary>
    ''' Add columns in grid view by date
    ''' </summary>
    ''' <param name="dtDate"></param>
    ''' <remarks></remarks>
    Public Sub AddColumnsInWGByDate(ByVal dtDate As Date)
        Dim AccountEmployeeTimeEntryDataKeyNames As String
        Dim TotalTimeDataKeyNames As String
        Dim HoursDataKeyNames As String
        Dim StartTimeDataKeyNames As String
        Dim EndTimeDataKeyNames As String
        Dim DescriptionDataKeyNames As String
        Dim TotalApprovedDataKeyNames As String
        Dim TotalRejectedDataKeyNames As String
        Dim TotalSubmittedDataKeyNames As String
        Dim PercentageDataKeyNames As String
        Dim CustomField1DataKeyNames As String
        Dim CustomField2DataKeyNames As String
        Dim CustomField3DataKeyNames As String
        Dim CustomField4DataKeyNames As String
        Dim CustomField5DataKeyNames As String
        Dim CustomField6DataKeyNames As String
        Dim CustomField7DataKeyNames As String
        Dim CustomField8DataKeyNames As String
        Dim CustomField9DataKeyNames As String
        'Dim PeriodDescriptionDataKeyNames As String
        Dim DataKeyNames As String
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            AccountEmployeeTimeEntryDataKeyNames += "AccountEmployeeTimeEntryId" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            TotalTimeDataKeyNames += "TotalTime" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            StartTimeDataKeyNames += "StartTime" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            EndTimeDataKeyNames += "EndTime" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            DescriptionDataKeyNames += "Description" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            TotalSubmittedDataKeyNames += "Submitted" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            TotalApprovedDataKeyNames += "Approved" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            TotalRejectedDataKeyNames += "Rejected" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            PercentageDataKeyNames += "Percentage" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            HoursDataKeyNames += "Hours" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField1DataKeyNames += "CustomField1" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField2DataKeyNames += "CustomField2" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField3DataKeyNames += "CustomField3" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField4DataKeyNames += "CustomField4" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField5DataKeyNames += "CustomField5" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField6DataKeyNames += "CustomField6" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField7DataKeyNames += "CustomField7" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField8DataKeyNames += "CustomField8" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            CustomField9DataKeyNames += "CustomField9" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            'PeriodDescriptionDataKeyNames += "PeriodDescription" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            dtDate = WorkingDays(dayNo)
            Dim DayMonth As String = LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocale(WorkingDays(dayNo))
            Dim HolidayDate As String = LocaleUtilitiesBLL.GetDayDateInCurrentLocale(WorkingDays(dayNo))
            Dim StatusHolidayImage As New System.Web.UI.WebControls.Image
            Dim dayname As String = ResourceHelper.GetFromResource(LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDays(dayNo)))
            Dim dtcolumn As New TemplateField
            dtcolumn.HeaderText = dayname + "<br>" + DayMonth
            Dim IsEnable As Boolean = True
            Dim IsVisible As Boolean = False
            dtcolumn.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            dtcolumn.FooterStyle.HorizontalAlign = HorizontalAlign.Center
            dtcolumn.ItemStyle.Width = 50


            Dim HolidayBLL As New AccountHolidayTypeBLL
            Dim HolidayTypeId As Guid
            Dim dtHolidayEmployee As AccountHolidayType.vueAccountHolidayEmployeeDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeesByAccountEmployeeId(Me.ddlEmployee.SelectedValue)
            Dim drHolidayEmployee As AccountHolidayType.vueAccountHolidayEmployeeRow
            If dtHolidayEmployee.Rows.Count > 0 Then
                drHolidayEmployee = dtHolidayEmployee.Rows(0)
                HolidayTypeId = drHolidayEmployee.AccountHolidayTypeId
            End If
            Dim HolidayDataTable As DataTable = HolidayBLL.GetvueAccountHolidayTypeDetailByAccountIdandHolidayDate(HolidayDate, HolidayTypeId)
            If HolidayDataTable.Rows.Count > 0 Then
                IsVisible = True
            End If
            dtcolumn.HeaderTemplate = New TimesheetHeaderTemplate("i" & dayNo, "<br>" + dayname + "<br>" + DayMonth, IsVisible)
            dtcolumn.ItemTemplate = New TimesheetItemTemplate("S" & dayNo, "E" & dayNo, "TT" & dayNo, "MS" & dayNo, "ME" & dayNo, "MT" & dayNo, "VS" & dayNo, "VE" & dayNo, "VT" & dayNo, "i" & dayNo, IsEnable, "PC" & dayNo, "MP" & dayNo, "VP" & dayNo, "NV" & dayNo, "AT" & dayNo, "In" & dayNo)
            dtcolumn.FooterTemplate = New TimesheetFooterTemplate("st" & dayNo, IsEnable, "spc" & dayNo)
            Me.G.Columns.Add(dtcolumn)
            dtcolumn.Visible = IsEnable
        Next

        If WorkingDaysCount <> 0 Then
            DataKeyNames = AccountEmployeeTimeEntryDataKeyNames + "," + TotalTimeDataKeyNames + "," +
                StartTimeDataKeyNames + "," + EndTimeDataKeyNames + "," + DescriptionDataKeyNames + "," +
                "PeriodDescription" + "," + "IsTimeOff" + "," + "AccountEmployeeTimeOffRequestId" + "," +
                "AccountEmployeeTimeEntryApprovalProjectId" + "," + "ProjectApproved" + "," + "AccountProjectId" +
                "," + "AccountProjectTaskId" + "," + "AccountCostCenterId" + "," + "AccountWorkTypeId" + "," +
                "AccountTimeOffTypeId" + "," + TotalApprovedDataKeyNames + "," + TotalSubmittedDataKeyNames + "," +
                TotalRejectedDataKeyNames + "," + PercentageDataKeyNames + "," + HoursDataKeyNames +
                "," + CustomField1DataKeyNames + "," +
                CustomField2DataKeyNames + "," + CustomField3DataKeyNames + "," + CustomField4DataKeyNames + "," _
                + CustomField5DataKeyNames + "," + CustomField6DataKeyNames + "," + CustomField7DataKeyNames + "," _
                + CustomField8DataKeyNames + "," + CustomField9DataKeyNames
            Me.G.DataKeyNames = DataKeyNames.Split(",".ToCharArray(), WorkingDaysCount * 19 + 11)
        End If
    End Sub
    ''' <summary>
    ''' Page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = ResourceHelper.GetFromResource("Time Entry Date:")
        Me.Label3.Text = ResourceHelper.GetFromResource("Timesheet Status:")
        Me.lblTSTotal.Text = ResourceHelper.GetFromResource("Timesheet Total:")
        If Not AccountPagePermissionBLL.IsPageHasPermissionOf(18, 3) = True Then
            SetPermissionForEditTimesheet(False)
        End If
        'Me.Page.Form.DefaultButton = Me.WeekButton1.UniqueID
        EmployeeNameLabel.Text = ResourceHelper.GetFromResource("Employees:")
        If Not Me.IsPostBack Then
            Dim bll As New AccountEmployeeTimeEntryBLL
            bll.UpdateTimeEntryClientRecord(Me.ddlEmployee.SelectedValue, LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQureyForReport(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtStartDate.Date.ToString)), LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQureyForReport(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtEndDate.Date.ToString)))
        End If
        Dim TimeEntrybll As New AccountEmployeeTimeEntryBLL
        Dim Time = TimeEntrybll.GetMissingEntrysPeriods(Me.ddlEmployee.SelectedValue)
        Dim WarningNow = 1
        If Time.Rows.Count >= 1 Then

            If Time.Rows(0)("Total") >= 1 Then
                WarningsHolder.Attributes.Add("class", "WarningsHolder")
            Else
                WarningsHolder.Visible = False
            End If

            Warning.Visible = True

            If Time.Rows(0)("Rejected") >= 1 Then
                WarningHolderFill(WarningNow, "You have " + Time.Rows(0)("Rejected").ToString() + " " + " rejected timesheet period" + IIf(Time.Rows(0)("Rejected") > 1, "s.", "."))
                WarningNow += 1
            End If
            If Time.Rows(0)("NotSaved") >= 1 Then
                WarningHolderFill(WarningNow, "You have " + Time.Rows(0)("NotSaved").ToString() + " " + " missing timesheet period" + IIf(Time.Rows(0)("NotSaved") > 1, "s", "") + " to fill.")
                WarningNow += 1
            End If
            If Time.Rows(0)("Saved") >= 1 Then
                WarningHolderFill(WarningNow, "You have " + Time.Rows(0)("Saved").ToString() + " " + " saved (not submitted) timesheet period" + IIf(Time.Rows(0)("Saved") > 1, "s.", "."))
                WarningNow += 1
            End If

            WarningText.Text = "To verify this situation click "
            WarningLink.Text = "here"
            WarningLink.PostBackUrl = "~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" + ddlEmployee.SelectedItem.Value + "&ViewType=PeriodView"

        Else
            Warning.Visible = False
        End If

    End Sub

    Sub WarningHolderFill(ByVal Warningnr As Integer, ByVal text As String)
        If Warningnr = 1 Then
            WarningHolder1.Text = text
        End If
        If Warningnr = 2 Then
            WarningHolder2.Text = text
        End If
        If Warningnr = 3 Then
            WarningHolder3.Text = text
        End If
    End Sub
    ''' <summary>
    ''' Set permission for edit in time sheet of specified IsEditPermission
    ''' </summary>
    ''' <param name="IsEditPermission"></param>
    ''' <remarks></remarks>
    Public Sub SetPermissionForEditTimesheet(ByVal IsEditPermission As Boolean)
        WeekButton1.Enabled = IsEditPermission
        btnTopSave.Enabled = IsEditPermission
        btnSubmit.Enabled = IsEditPermission
        btnTopSubmit.Enabled = IsEditPermission
        btnCopy.Enabled = IsEditPermission
        btnCopyActivities.Enabled = IsEditPermission
        btnCopyFromTemplate.Enabled = IsEditPermission
    End Sub
    ''' <summary>
    ''' Set time format in grid of specified object row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetTimeFormatInGrid(ByVal objRow As GridViewRow)
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            If DBUtilities.IsNotSupportedCultureFormats = True Then
                If DBUtilities.GetClockStartEndBy = "Account" Then
                    If DBUtilities.GetShowClockStartEnd = True Then
                        If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                            DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MS" & dayNo))
                            DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("ME" & dayNo))
                        End If
                    End If
                ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
                    If DBUtilities.ShowClockStartEndEmployee = True Then
                        If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                            DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MS" & dayNo))
                            DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("ME" & dayNo))
                        End If
                    End If

                End If
                DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MT" & dayNo))
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set cascading account id of specified object row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetCascadingAccountId(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") <> "Yes" Then
        If DBUtilities.GetShowClientInTimesheet = False And DBUtilities.GetShowProjectInTimesheet = False Then
            MyCascading = CType(objRow.FindControl("CT"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ParentControlID = Nothing
        ElseIf DBUtilities.GetShowProjectInTimesheet = False And DBUtilities.GetShowClientInTimesheet = True Then
            MyCascading = CType(objRow.FindControl("CT"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ParentControlID = "C"
        Else
            MyCascading = CType(objRow.FindControl("CT"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ParentControlID = "P"
        End If
        Dim dsObject As ObjectDataSource
        dsObject = CType(objRow.Cells(0).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
        dsObject = CType(objRow.Cells(0).FindControl("dsAccountClientObject"), ObjectDataSource)
        Dim AccountProjectId As Integer = dsObject.SelectParameters("AccountClientId").DefaultValue
        MyCascading.Category = TimeEntryAccountEmployeeId & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & AccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & AccountProjectId & "," & DBUtilities.GetShowAdditionalTaskInformationType & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetShowProjectInTimesheet
    End Sub
    ''' <summary>
    ''' Set javascript of on change
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetJavascriptOfOnChange()
        Dim objRow As TableRow
        For Each objRow In Me.G.Rows
            If objRow.Cells(2).Controls.Count > 0 Then
                For dayNo As Integer = 0 To WorkingDaysCount - 1
                    If DBUtilities.GetClockStartEndBy = "Account" Then
                        If DBUtilities.GetShowClockStartEnd = True Then
                            If Not CType(objRow.Cells(5 + dayNo).FindControl("S" & dayNo), TextBox) Is Nothing Then
                                CType(objRow.Cells(5 + dayNo).FindControl("S" & dayNo), TextBox).Attributes.Add("onchange", "javascript:OnTimeChange(this);")
                                CType(objRow.Cells(5 + dayNo).FindControl("E" & dayNo), TextBox).Attributes.Add("onchange", "javascript:OnTimeChange(this);")
                            End If
                        End If
                    ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
                        If DBUtilities.ShowClockStartEndEmployee = True Then
                            If Not CType(objRow.Cells(5 + dayNo).FindControl("S" & dayNo), TextBox) Is Nothing Then
                                CType(objRow.Cells(5 + dayNo).FindControl("S" & dayNo), TextBox).Attributes.Add("onchange", "javascript:OnTimeChange(this);")
                                CType(objRow.Cells(5 + dayNo).FindControl("E" & dayNo), TextBox).Attributes.Add("onchange", "javascript:OnTimeChange(this);")
                            End If
                        End If
                    End If
                    If Not CType(objRow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox) Is Nothing Then
                        CType(objRow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Attributes.Add("onchange", "javascript:UpdateSum(" & dayNo & ",this);")
                        CType(objRow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Attributes.Add("onkeydown", "return (event.keyCode!=13);")
                    End If
                    If Not CType(objRow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox) Is Nothing Then
                        CType(objRow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Attributes.Add("onchange", "javascript:UpdateSum(" & dayNo & ",this);")
                    End If
                Next
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set ajax extender in row of specified object row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetAjaxExtenderInRow(ByVal objRow As GridViewRow)
        If objRow.Cells(2).Controls.Count > 0 Then
            Dim CustomFieldBLL As New AccountCustomFieldBLL
            Dim MasterEntityTypeId As New Guid("369ed0fb-d317-4244-9f20-b7d834521e2b")
            Dim dt As AccountCustomField.vueAccountCustomFieldManageDataTable = CustomFieldBLL.GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId(DBUtilities.GetSessionAccountId, MasterEntityTypeId)
            For dayNo As Integer = 0 To WorkingDaysCount - 1
                Me.SetAjaxExtender(dayNo, objRow, dt)
                Me.SetAjaxExtenderDataItem(dayNo, objRow)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Set ajax extender of all rows
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetAjaxExtenderOfAllRows()
        Dim objRow As GridViewRow
        For Each objRow In Me.G.Rows
            If objRow.Cells(5).FindControl("Pn0" & objRow.RowIndex) Is Nothing Then
                Me.SetAjaxExtenderInRow(objRow)
            End If
        Next
    End Sub
    ''' <summary>
    ''' Disable time entry in week rows of specified object row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub DisableTimeEntryInWeekRows(ByVal objRow As GridViewRow)
        If objRow.Cells(2).Controls.Count > 0 Then
            For dayNo As Integer = 0 To WorkingDaysCount - 1
                Me.DisableWeekTimeEntries(dayNo, objRow)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Disable time entry of week
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisableTimeEntryOfWeek()
        Dim objRow As GridViewRow
        For Each objRow In Me.G.Rows
            Me.DisableTimeEntryInWeekRows(objRow)
        Next
    End Sub
    ''' <summary>
    ''' Show not found message of specified strMessage
    ''' </summary>
    ''' <param name="strMessage"></param>
    ''' <remarks></remarks>
    Public Sub ShowNotFoundMessage(ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    ''' <summary>
    ''' Validate time entry week view of specified btnClicked
    ''' </summary>
    ''' <param name="btnClicked"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateTimeEntryWeekView(ByVal btnClicked As String) As Boolean
        ButtonClicked = btnClicked
        Dim objrow As GridViewRow
        Dim TimeEntered As Boolean
        Dim PHT As New Hashtable
        Dim PC As Integer
        For Each objrow In Me.G.Rows
            If objrow.Cells(2).Controls.Count > 0 Then
                For dayNo As Integer = 0 To WorkingDaysCount - 1
                    If Not CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox) Is Nothing Then
                        If CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" And CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue = "" And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                            Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
                            Return False
                        End If
                        If CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" And CType(objrow.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList).SelectedValue = "" And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then
                            Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
                            Return False
                        End If
                        If CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue <> "" And CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text = "" And IsDBNull(Me.G.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId" & dayNo)) Then
                            If TimeEntered <> True Then
                                TimeEntered = False
                            End If
                            If LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet Then
                                TimeEntered = True
                            End If
                        ElseIf CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue = "" And CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text = "" And IsDBNull(Me.G.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId" & dayNo)) Then
                            If TimeEntered <> True Then
                                TimeEntered = False
                            End If
                        Else
                            TimeEntered = True
                        End If
                    End If
                    If Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then

                    End If
                    If Not CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox) Is Nothing And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                        If CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" And CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue = "" Then
                            Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
                            Return False
                        End If
                        If CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" Then
                            If CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text > 100 Then
                                Me.ShowNotFoundMessage("You may not enter more than 100 percent.")
                                Return False
                            End If
                        End If
                        If CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue <> "" And CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" And IsDBNull(Me.G.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId" & dayNo)) Or (CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" And Not IsDBNull(Me.G.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId" & dayNo)) And IsDBNull(Me.G.DataKeys(objrow.RowIndex)("Percentage" & dayNo))) Then
                            SetValuesInPercentageHashTable(PHT, CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue, CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text)
                        ElseIf CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue <> "" And CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" And Not IsDBNull(Me.G.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId" & dayNo)) Then
                            If Me.G.DataKeys(objrow.RowIndex)("Percentage" & dayNo) <> CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text Then
                                PC = CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text - Me.G.DataKeys(objrow.RowIndex)("Percentage" & dayNo)
                                SetValuesInPercentageHashTable(PHT, CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue, PC)
                            End If
                        End If
                        If CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue <> "" And CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text = "" And IsDBNull(Me.G.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId" & dayNo)) Then
                            If TimeEntered <> True Then
                                TimeEntered = False
                            End If
                            If LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet Then
                                TimeEntered = True
                            End If
                        Else
                            TimeEntered = True
                        End If
                    End If
                Next
            End If

            'TimeEntered = False
        Next
        If TimeEntered = False Then
            Me.ShowNotFoundMessage("Please enter hours to save timesheet.")
            Return False
        End If
        If btnClicked = "Submit" And DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Then
        ElseIf btnClicked = "Submit" Then
            If Me.ValidateDayHours <> True Then
                Return False
            End If

            If Me.ValidateWeekHours <> True Then
                Return False
            End If

            If LocaleUtilitiesBLL.EnableTaskHoursValidation Then
                If Me.ValidateEstimatedHours <> True Then
                    Return False
                End If
            End If
        End If
        If btnClicked = "Submit" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Then
            If Me.ValidateDayPercentage <> True Then
                Return False
            End If

            If Me.ValidateWeekPercentage <> True Then
                Return False
            End If
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet Then
            If LocaleUtilitiesBLL.EnableCalculateTaskPercentageAutomatically Then
                If Me.ValidatePercentage(PHT) <> True Then
                    Me.ShowNotFoundMessage("You may not enter more than 100 percent in a task.")
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Public Sub SetValuesInPercentageHashTable(PHT As Hashtable, AccountProjectTaskId As Integer, Percentage As Double)
        Dim TEMP As Integer
        If PHT.Contains(AccountProjectTaskId) Then
            TEMP = PHT.Item(AccountProjectTaskId)
            TEMP = TEMP + Percentage
            PHT.Item(AccountProjectTaskId) = TEMP
        Else
            PHT.Add(AccountProjectTaskId, Percentage)
        End If
    End Sub
    Public Function ValidatePercentage(PHT As Hashtable) As Boolean
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        If PHT.Count > 0 Then
            For n As Integer = 0 To PHT.Count - 1
                Dim CompletedPercent As Integer = ProjectTaskBLL.GetCompletedPercentByAccountProjectTaskId(PHT.Keys(n))
                If (CompletedPercent + PHT.Values(n)) > 100 Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    ''' <summary>
    ''' Validate Day Percentage
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateDayPercentage() As Boolean
        Dim objrow As GridViewRow
        Dim DayPercentage As Integer
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            For Each objrow In Me.G.Rows
                If objrow.Cells(2).Controls.Count > 0 Then
                    If CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" Then
                        DayPercentage += CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text
                    End If
                End If
            Next
            If DayPercentage > MaxDayPercentage Then
                Me.ShowNotFoundMessage("You may not enter more than " & MaxDayPercentage & " percent per day.")
                Return False
            End If
            If DayPercentage < MinDayPercentage Then
                Me.ShowNotFoundMessage("You may not enter less than " & MinDayPercentage & " percent per day.")
                Return False
            End If
            DayPercentage = 0
        Next
        Return True
    End Function
    ''' <summary>
    ''' Validate Week Percentage
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateWeekPercentage() As Boolean
        Dim objrow As GridViewRow
        Dim WeekPercentage As Double
        For Each objrow In Me.G.Rows
            If objrow.Cells(2).Controls.Count > 0 Then
                For dayNo As Integer = 0 To WorkingDaysCount - 1
                    If CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text <> "" Then
                        WeekPercentage += CType(objrow.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text
                    End If
                Next
            End If
        Next
        If WeekPercentage > MaxWeekPercentage Then
            Me.ShowNotFoundMessage("You may not enter more than " & MaxWeekPercentage & " percent in a period.")
            Return False
        End If
        If WeekPercentage < MinWeekPercentage Then
            Me.ShowNotFoundMessage("You may not enter less than " & MinWeekPercentage & " percent in a period.")
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Validate day hours
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateDayHours() As Boolean
        Dim objrow As GridViewRow
        Dim DayHours As Double
        Dim disablevalidation As Boolean = False
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            For Each objrow In Me.G.Rows
                If objrow.Cells(2).Controls.Count > 0 Then
                    If CheckHolidayIcon(WorkingDays(dayNo), dayNo) = True Then
                        disablevalidation = True
                    End If
                    If CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" Then
                        If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                            DayHours += Convert.ToDouble(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text)
                        Else
                            DayHours += Convert.ToDouble(DBUtilities.GetMinutesOfTime(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) / 60)
                        End If
                    End If
                End If
            Next
            If DayHours > MaxDayHours Then
                Me.ShowNotFoundMessage("You may not enter more than " & MaxDayHours & " hours per day.")
                Return False
            End If

            If DayHours < MinDayHours Then
                If disablevalidation <> True Then
                    Me.ShowNotFoundMessage("You may not enter less than " & MinDayHours & " hours per day.")
                    Return False
                End If
            End If
            DayHours = 0
            disablevalidation = False
        Next
        Return True
    End Function
    ''' <summary>
    ''' Validate week hours
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateWeekHours() As Boolean
        Dim objrow As GridViewRow
        Dim WeekHours As Double
        Dim HolidayHours As Double
        Dim EnterHolidayHours As Double
        Dim HolidayCount As Double = Me.GetHolidaysCount(Me.ViewState("dtStartDate"), Me.ViewState("dtEndDate"))
        For Each objrow In Me.G.Rows
            If objrow.Cells(2).Controls.Count > 0 Then
                For dayNo As Integer = 0 To WorkingDaysCount - 1
                    If CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" Then
                        If Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" And CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" Then
                            If CheckHolidayIcon(WorkingDays(dayNo), dayNo) = True Then
                                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                                    EnterHolidayHours += Convert.ToDouble(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text)
                                Else
                                    EnterHolidayHours += Convert.ToDouble(DBUtilities.GetMinutesOfTime(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) / 60)
                                End If
                            End If
                        End If
                        If CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue <> "" And CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" Then
                            If CheckHolidayIcon(WorkingDays(dayNo), dayNo) = True Then
                                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                                    EnterHolidayHours += Convert.ToDouble(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text)
                                Else
                                    EnterHolidayHours += Convert.ToDouble(DBUtilities.GetMinutesOfTime(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) / 60)
                                End If
                            End If
                        End If
                        If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                            WeekHours += Convert.ToDouble(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text)
                        Else
                            WeekHours += Convert.ToDouble(DBUtilities.GetMinutesOfTime(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) / 60)
                        End If
                    End If
                Next

            End If
        Next
        Dim ValidateMinWeekHours As Double
        If Math.Round(HolidayCount) <> 0 Then
            ValidateMinWeekHours = MinWeekHours
            If Math.Round(MinDayHours) <> 0 Then
                HolidayHours = MinDayHours * HolidayCount
                MinWeekHours -= HolidayHours
                MinWeekHours += EnterHolidayHours
            Else
                HolidayHours = MinWeekHours / WorkingDaysCount
                MinWeekHours -= (HolidayHours * HolidayCount)
                'MinWeekHours += EnterHolidayHours
            End If
        End If

        If Math.Round(WeekHours, 2) > Math.Round(MaxWeekHours, 2) Then
            Me.ShowNotFoundMessage("You may not enter more than " & Math.Round(MaxWeekHours, 2) & " hours in a period.")
            Return False
        End If
        If Math.Round(WeekHours, 2) < Math.Round(MinWeekHours, 2) Then
            Me.ShowNotFoundMessage("You may not enter less than " & Math.Round(ValidateMinWeekHours, 2) & " hours in a period.")
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Fix rows
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FixRows()
        If Me.G.Rows.Count > 0 Then
            Exit Sub
        End If
        Dim objRow As TableRow
        For Each objRow In Me.G.Rows
            If objRow.Cells(2).Controls.Count > 0 Then
                For dayNo As Integer = 0 To WorkingDaysCount - 1
                    If DBUtilities.GetClockStartEndBy = "Account" Then
                        If DBUtilities.GetShowClockStartEnd = True Then
                            CType(objRow.FindControl("S" & dayNo), TextBox).Text = ""
                            CType(objRow.FindControl("E" & dayNo), TextBox).Text = ""
                        End If
                    ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
                        If DBUtilities.ShowClockStartEndEmployee = True Then
                            CType(objRow.FindControl("S" & dayNo), TextBox).Text = ""
                            CType(objRow.FindControl("E" & dayNo), TextBox).Text = ""
                        End If
                    End If
                    CType(objRow.FindControl("TT" & dayNo), TextBox).Text = ""
                Next
            End If
        Next
    End Sub
    ''' <summary>
    ''' Grid data bound
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub WG_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles G.DataBound
        If Me.ViewState("IsCopyFromDate") = "True" Then
            lblTimesheetStatus.Text = ResourceHelper.GetFromResource("Not Submitted")
            imgTSL.ImageUrl = "~/images/NotSubmittedStatus.gif"
        Else
            Call New AccountEmployeeTimeEntryBLL().SetTimesheetStatus(lblTimesheetStatus, imgTSL, dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId)
        End If

        Dim objRow As GridViewRow
        For Each objRow In Me.G.Rows
            If objRow.RowType = DataControlRowType.DataRow Then
                Me.ShowDataForddlAccountCostCenterId(objRow)
                Me.SetCascadingAccountId(objRow)
                Me.SetTimeFormatInGrid(objRow)
                Me.SetClientCascadingEnabled(objRow)
                'For dayNo As Integer = 0 To WorkingDaysCount - 1
                '    ShowTimeEntryStatus(objRow, dayNo)
                'Next
            End If
        Next

        Me.SetJavascriptOfOnChange()
        HideTotalTimeTextBoxForPercentage()
        HideStartEndTime()
        Me.SetAjaxExtenderOfAllRows()
        If AccountEmployeeTimeEntryBLL.CheckSubmittedAndLockWeekView(dtStartDate, dtEndDate, TimesheetPeriodType, TimeEntryAccountEmployeeId) = True And Me.ViewState("IsCopyFromDate") = "False" Then
            Me.DisableTimeEntryOfWeek()
            Me.btnSubmit.Enabled = False
            Me.btnTopSubmit.Enabled = False
            Me.WeekButton1.Enabled = False
            Me.btnTopSave.Enabled = False
            Me.btnCopy.Enabled = False
            Me.btnCopyActivities.Enabled = False
            Me.btnCopyFromTemplate.Enabled = False
            Me.txtPeriodDescription.ReadOnly = True
            Me.btnTimerTimesheet.Enabled = False
            Me.btnExportOfflineTimesheet.Enabled = False
            Me.btnImportOfflineTimesheet.Enabled = False

        End If
        If DBUtilities.GetLockAllPreviousTimesheets Then
            Me.DisableAllPreviousTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockAllFutureTimesheets Then
            Me.DisableAllFutureTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockAllPeriodExceptPrevious Then
            Me.UnlockPreviousPeriodsTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockAllPeriodExceptNext Then
            Me.UnlockNextPeriodsTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockPreviousTimesheetPeriods Then
            Me.DisablePreviousPeriodsTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockNextTimsheetPeriods Then
            Me.DisableNextPeriodsTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockPreviousNextMonthTimesheetOn Then
            Dim No As Integer = DBUtilities.GetLockPreviousNextMonthTimesheetOn
            Me.DisablePreviousNextMonthTimeEntryOfWeek(No)
        End If
        Me.ShowCopyButtonsByPreference()
        If Me.G.DataKeys.Count > 0 Then
            Me.txtPeriodDescription.Text = IIf(IsDBNull(Me.G.DataKeys(0).Item("PeriodDescription")), "", Me.G.DataKeys(0).Item("PeriodDescription"))
        Else
            Me.txtPeriodDescription.ReadOnly = True
        End If
        If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Then
            btnTimerTimesheet.Visible = False
        End If

        SetGridColumnSpanForTimeOff()
        SetProjectWidthForTimeOff()

    End Sub
    Public Sub ShowCopyButtonsByPreference()
        If Not DBUtilities.ShowCopyActivitiesButtonInTimesheet Then
            btnCopyActivities.Visible = False
        End If
        If Not DBUtilities.ShowCopyTimesheetButton Then
            btnCopy.Visible = False
        End If
        'If Not DBUtilities.ShowCopyActivitiesButtonInTimesheet And Not DBUtilities.ShowCopyTimesheetButton Then
        '    CopyFromCalendarPopup.Visible = False
        '    lblCopyFrom.Visible = False
        'End If
    End Sub
    ''' <summary>
    ''' Hide start end time
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HideStartEndTime()
        Dim objRow As GridViewRow
        For Each objRow In Me.G.Rows
            If objRow.RowType = DataControlRowType.DataRow Then
                ' Hide Control if ShowClockStartEnd = false
                If WorkingDaysCount <> 0 Then
                    If DBUtilities.GetClockStartEndBy = "Account" Then
                        If DBUtilities.GetShowClockStartEnd = False Or Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "True" Or DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                            CType(objRow.FindControl("lS"), Label).Visible = False
                            CType(objRow.FindControl("lE"), Label).Visible = False
                            For dayNo As Integer = 0 To WorkingDaysCount - 1
                                If Not CType(objRow.FindControl("S" & dayNo), TextBox) Is Nothing Then
                                    CType(objRow.FindControl("S" & dayNo), TextBox).Visible = False
                                    CType(objRow.FindControl("E" & dayNo), TextBox).Visible = False
                                End If
                            Next
                        End If
                    ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
                        If DBUtilities.ShowClockStartEndEmployee = False Or Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "True" Or DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                            CType(objRow.FindControl("lS"), Label).Visible = False
                            CType(objRow.FindControl("lE"), Label).Visible = False
                            For dayNo As Integer = 0 To WorkingDaysCount - 1
                                If Not CType(objRow.FindControl("S" & dayNo), TextBox) Is Nothing Then
                                    CType(objRow.FindControl("S" & dayNo), TextBox).Visible = False
                                    CType(objRow.FindControl("E" & dayNo), TextBox).Visible = False
                                End If
                            Next
                        End If
                    End If
                    If DBUtilities.IsTimeEntryHoursFormat = "None" And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                        CType(objRow.FindControl("lT"), Label).Visible = False
                    End If
                    If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Or Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "True" Then
                        CType(objRow.FindControl("lP"), Label).Visible = False
                    End If
                    If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
                        CType(objRow.FindControl("lT"), Label).Visible = True
                    End If
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Grid row data bound
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub WG_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles G.RowDataBound
        Dim TotalGridTime As Decimal
        Dim TotalTime(WorkingDaysCount) As Integer
        Dim Percentage(WorkingDaysCount) As Integer
        Dim TotalHours(WorkingDaysCount) As Decimal
        Dim SubmittedTime As Boolean
        Dim IsApprovedTime As Boolean
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataValue As Object
            Dim objDropdown As DropDownList
            Dim objTextbox As TextBox
            Dim dsObject As ObjectDataSource
            Me.SetRowDataBoundInPeriodViewDataRow(objDropdown, objTextbox, dsObject, dataValue, MyCascading, e.Row, SubmittedTime, IsApprovedTime, TotalTime, Percentage, TotalHours)
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Me.SetRowDataBoundInPeriodViewFooterRow(e.Row, TotalTime, TotalGridTime, Percentage, TotalHours)
        End If
    End Sub
    Public Sub HideTotalTimeTextBoxForPercentage()
        Dim Row As GridViewRow
        For Each Row In Me.G.Rows
            If Row.RowType = DataControlRowType.DataRow Then
                If WorkingDaysCount <> 0 Then
                    For dayNo As Integer = 0 To WorkingDaysCount - 1
                        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" And Me.G.DataKeys(Row.RowIndex)("IsTimeOff").ToString = "False" Then
                            If Not CType(Row.FindControl("TT" & dayNo), TextBox) Is Nothing Then
                                CType(Row.FindControl("TT" & dayNo), TextBox).Visible = False
                            End If
                        End If
                        If Me.G.DataKeys(Row.RowIndex)("IsTimeOff").ToString = "True" Then
                            If Not CType(Row.FindControl("PC" & dayNo), TextBox) Is Nothing Then
                                CType(Row.FindControl("PC" & dayNo), TextBox).Visible = False
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Add submitted day no in hash table of specified objrow, dayNo
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <param name="dayNo"></param>
    ''' <remarks></remarks>
    Public Sub AddSubmittedDayNoInHashTable(ByVal objrow As GridViewRow, ByVal dayNo As Integer)
        If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(objrow, dayNo) = False Then
            If Not SubmittedDayNo.Contains(dayNo) Then
                SubmittedDayNo.Add(dayNo, dayNo)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get cell value of specified objRow, nCellIndex, strObjectId
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="nCellIndex"></param>
    ''' <param name="strObjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCellValue(ByVal objRow As GridViewRow, ByVal nCellIndex As Integer, ByVal strObjectId As String) As Object

        Dim UIObject As Object = objRow.Cells(nCellIndex).FindControl(strObjectId)

        If UIObject Is Nothing Then
            Return Nothing
        End If

        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedValue
        ElseIf TypeOf UIObject Is eWorld.UI.TimePicker Then
            Return UIObject.controls(1).text
        Else
            Return UIObject.Text()
        End If

    End Function
    Public Function GetCellValueForCustomField(UIObject As Object) As Object
        If UIObject Is Nothing Then
            Return Nothing
        End If

        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedValue
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Return UIObject.SelectedDate
        Else
            Return UIObject.Text()
        End If

    End Function
    Public Sub SetCellValue(UIObject As Object, ColumnData As Object, AccountEmployeeTimeEntryId As Object, ByVal IsCopyActivities As Object)
        If UIObject Is Nothing Then
            Exit Sub
        End If
        If Not IsDBNull(ColumnData) Then
            If TypeOf UIObject Is DropDownList Then
                If IsCopyActivities Is Nothing Then
                    UIObject.SelectedValue = ColumnData
                End If
            ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
                If IsCopyActivities Is Nothing Then
                    UIObject.SelectedDate = ColumnData
                End If
            Else
                If IsCopyActivities Is Nothing Then
                    UIObject.Text() = ColumnData
                End If
            End If
        End If
        If Not IsDBNull(AccountEmployeeTimeEntryId) And IsDBNull(ColumnData) Then
            If TypeOf UIObject Is TextBox Then
                UIObject.Text() = ""
            End If
        End If
    End Sub
    Public Sub DisableCustomFields(UIObject As Object)
        If UIObject Is Nothing Then
            Exit Sub
        End If
        If TypeOf UIObject Is DropDownList Then
            UIUtilities.MakeDropdownReadonly(UIObject)
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            UIUtilities.MakeCalendarPopUpReadonly(UIObject)
        Else
            UIUtilities.MakeTextboxReadonly(UIObject)
        End If
    End Sub
    Dim IsDeletedTimeEntryPeriod As Boolean
    ''' <summary>
    ''' Update row of specified objRow, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="ApprovalProjectId"></param>
    ''' <param name="ProjectApproved"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRow(ByVal objRow As GridViewRow, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal ApprovalProjectId As Guid, ByVal ProjectApproved As Boolean, ByVal Submitted As Boolean)
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim startTime As Date
        If objRow.RowType = DataControlRowType.DataRow Then
            For n As Integer = 0 To WorkingDaysCount - 1
                Dim OldProjectApproved As Boolean = IIf(IsDBNull(Me.G.DataKeys(objRow.RowIndex).Item("Approved" & n)), False, Me.G.DataKeys(objRow.RowIndex).Item("Approved" & n))
                'Dim Submitted As Boolean = IIf(ButtonClicked = "Submit", True, False)
                If Me.G.DataKeys(objRow.RowIndex).Item("IsTimeOff") = True And (Submitted = True Or OldProjectApproved = True) Then
                    ProjectApproved = IIf(IsDBNull(Me.G.DataKeys(objRow.RowIndex).Item("Approved" & n)), False, Me.G.DataKeys(objRow.RowIndex).Item("Approved" & n))
                    If objTimeEntryBLL.SetApprovalStateForTimeOff(TimeEntryAccountEmployeeId) = True Then
                        ProjectApproved = True
                    End If
                End If
                Me.UpdateDay(n, objRow, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved, Submitted)
            Next
        End If
    End Sub
    'Public Sub InsertRow(ByVal objRow As GridViewRow, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
    '    If objRow.RowType = DataControlRowType.DataRow Then
    '        For n As Integer = 0 To WorkingDaysCount - 1
    '            Me.UpdateDay(n, objRow, AccountEmployeeTimeEntryPeriodId)
    '        Next
    '    End If
    'End Sub
    ''' <summary>
    ''' Update day of specified DayNo, objRow, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved
    ''' </summary>
    ''' <param name="DayNo"></param>
    ''' <param name="objRow"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="ApprovalProjectId"></param>
    ''' <param name="ProjectApproved"></param>
    ''' <remarks></remarks>
    Public Sub UpdateDay(ByVal DayNo As Integer, ByVal objRow As GridViewRow, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal ApprovalProjectId As Guid, ByVal ProjectApproved As Boolean, ByVal Submitted As Boolean)
        With Me.dsAccountEmployeeTimeEntriesWeek
            Dim UpdateId As Integer
            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountEmployeeTimeOffRequestId")) Then
                Exit Sub
            End If
            If objRow.RowIndex >= Me.G.DataKeys.Count Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function UpdateDay: InsertRecord objRow.RowIndex >= Me.G.DataKeys.Count" & " ApprovalProjectId= " & ApprovalProjectId.ToString)
                Me.InsertRecord(objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved)
                Exit Sub
            End If
            If Me.ViewState("IsCopyFromDate") = "True" Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function UpdateDay: InsertRecord Me.ViewState(IsCopyFromDate) = True" & " ApprovalProjectId= " & ApprovalProjectId.ToString)
                Me.InsertRecord(objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved)
                Exit Sub
            End If
            If IsDBNull(Me.G.DataKeys(objRow.RowIndex).Item("AccountEmployeeTimeEntryId" & DayNo)) Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function UpdateDay: InsertRecord IsDBNull(Me.G.DataKeys(objRow.RowIndex).Item(AccountEmployeeTimeEntryId & DayNo))" & " ApprovalProjectId= " & ApprovalProjectId.ToString)
                ' ''If IsDeletedTimeEntryPeriod = True Then
                ' ''    Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
                ' ''    AccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.GetAccountEmployeeTimeEntryPeriodIdByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
                ' ''    If AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                ' ''        AccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, IIf(ButtonClicked = "Submit", True, False), False, False, False, TimesheetPeriodType, txtPeriodDescription.Text)
                ' ''    End If

                ' ''    Dim dtApproval As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = objTimeEntryBLL.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(AccountEmployeeTimeEntryPeriodId, Me.GetCellValue(objRow, 0, "P"))
                ' ''    Dim drApproval As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
                ' ''    If dtApproval.Rows.Count = 0 Then
                ' ''        ApprovalProjectId = objTimeEntryBLL.AddAccountEmployeeTimeEntryApprovalProject(AccountEmployeeTimeEntryPeriodId, Me.GetCellValue(objRow, 0, "P"), TimeEntryAccountEmployeeId, 0, Submitted, False, False, ProjectApproved, False, False)
                ' ''    Else
                ' ''        drApproval = dtApproval.Rows(0)
                ' ''        ApprovalProjectId = drApproval.AccountEmployeeTimeEntryApprovalProjectId
                ' ''    End If
                ' ''    Me.InsertRecord(objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved)
                ' ''    Exit Sub
                ' ''Else

                Me.InsertRecord(objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved)

                Exit Sub
            End If
            UpdateId = Me.G.DataKeys(objRow.RowIndex).Item("AccountEmployeeTimeEntryId" & DayNo)
            Dim BLL As New AccountEmployeeTimeEntryBLL
            If UpdateId = 0 Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function UpdateDay: InsertRecord UpdateId=" & UpdateId & " ApprovalProjectId= " & ApprovalProjectId.ToString)

                Me.InsertRecord(objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved)

                ''unknown
            ElseIf UpdateId > 0 And (Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) <> "" Or Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo) <> "") Then
                If IsRowChanged(objRow, DayNo) Then
                    'LoggingBLL.WriteToLog("TimeEntryPeriod: Function UpdateDay: UpdateRecord :IsRowChanged: UpdateId=" & UpdateId & " ApprovalProjectId= " & ApprovalProjectId.ToString)
                    Me.UpdateRecord(UpdateId, objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved, Submitted)

                End If
            ElseIf UpdateId > 0 And (Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) = "" And DBUtilities.IsTimeEntryHoursFormat = "Time") Or (Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) = "" And DBUtilities.IsTimeEntryHoursFormat = "Decimal") Or (Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo) = "" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" And Me.G.DataKeys(objRow.RowIndex).Item("IsTimeOff").ToString = "False") Or (Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) = "" And Me.G.DataKeys(objRow.RowIndex).Item("IsTimeOff").ToString = "True") Or (Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) = "" And DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False) Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function UpdateDay: UpdateRecord :DeleteAccountEmployeeTimeEntry: UpdateId=" & UpdateId & " TimesheetPeriodType= " & TimesheetPeriodType & " ApprovalProjectId= " & ApprovalProjectId.ToString & " AccountEmployeeTimeEntryPeriodId= " & AccountEmployeeTimeEntryPeriodId.ToString)
                Dim TimeOffAttachmentsBLL = New TimeOffAttachmentsBLL
                If Me.G.DataKeys(objRow.RowIndex)("IsTimeOff") = True Then
                    TimeOffAttachmentsBLL.DeleteTimeOffAttachmentsFiles(UpdateId)
                End If
                IsDeletedTimeEntryPeriod = BLL.DeleteAccountEmployeeTimeEntryForWeekView(UpdateId, TimesheetPeriodType, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, ApprovalProjectId, AccountEmployeeTimeEntryPeriodId)
            End If
        End With
    End Sub

    ''' <summary>
    ''' Is valid data available of specified DayNo, objrow
    ''' </summary>
    ''' <param name="DayNo"></param>
    ''' <param name="objrow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidDataAvailable(ByVal DayNo As Integer, ByVal objrow As GridViewRow) As Boolean
        If Me.GetCellValue(objrow, 0, "P") Is Nothing Then
            Return False
        End If
        If Me.GetCellValue(objrow, 0, "PT") = "" And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        If Me.GetCellValue(objrow, DayNo + 5, "TT" & DayNo) = "" And DBUtilities.IsTimeEntryHoursFormat = "Time" Or Me.GetCellValue(objrow, DayNo + 5, "TT" & DayNo) = "" And DBUtilities.IsTimeEntryHoursFormat = "Decimal" Or (Me.GetCellValue(objrow, DayNo + 5, "TT" & DayNo) = "" And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True") Then
            Return False
        End If
        If Me.GetCellValue(objrow, DayNo + 5, "PC" & DayNo) = "" And LocaleUtilitiesBLL.ShowPercentageInTimesheet() And DBUtilities.IsTimeEntryHoursFormat = "None" And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        If Me.GetCellValue(objrow, DayNo + 5, "TT" & DayNo) = "" And DBUtilities.IsTimeEntryHoursFormat() = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet() = False And Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Insert record of specified objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="DayNo"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="ApprovalProjectId"></param>
    ''' <param name="ProjectApproved"></param>
    ''' <remarks></remarks>
    Public Sub InsertRecord(ByVal objRow As GridViewRow, ByVal DayNo As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal ApprovalProjectId As Guid, ByVal ProjectApproved As Boolean)
        If Not IsValidDataAvailable(DayNo, objRow) Then
            Return
        End If
        Try
            With Me.dsAccountEmployeeTimeEntriesWeek
                .InsertParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
                If Me.GetCellValue(objRow, 1, "PT") <> "" And DBUtilities.GetShowProjectInTimesheet = False Then
                    .InsertParameters("AccountProjectId").DefaultValue = IIf(Me.GetCellValue(objRow, 0, "P") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 1, "PT"), True), Me.GetCellValue(objRow, 0, "P"))
                Else
                    .InsertParameters("AccountProjectId").DefaultValue = Me.GetCellValue(objRow, 0, "P")
                End If
                .InsertParameters("TimeEntryDate").DefaultValue = WorkingDays(DayNo)
                If Me.GetCellValue(objRow, 1, "PT") <> "" And DBUtilities.GetShowClientInTimesheet = False Then
                    .InsertParameters("AccountPartyId").DefaultValue = IIf(Me.GetCellValue(objRow, 1, "C") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 1, "PT"), False), Me.GetCellValue(objRow, 1, "C"))
                Else
                    .InsertParameters("AccountPartyId").DefaultValue = Me.GetCellValue(objRow, 1, "C")
                End If
                .InsertParameters("AccountProjectTaskId").DefaultValue = Me.GetCellValue(objRow, 1, "PT")
                .InsertParameters("AccountCostCenterId").DefaultValue = Me.GetCellValue(objRow, 2, "CC")
                .InsertParameters("AccountWorkTypeId").DefaultValue = IIf(Me.GetCellValue(objRow, 3, "W") = "", GetStandardWorkType, Me.GetCellValue(objRow, 3, "W"))
                .InsertParameters("StartTime").DefaultValue = Me.GetCellValue(objRow, DayNo + 5, "S" & DayNo)
                .InsertParameters("EndTime").DefaultValue = Me.GetCellValue(objRow, DayNo + 5, "E" & DayNo)
                .InsertParameters("TotalTime").DefaultValue = IIf(Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) <> "", Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo), "0")
                .InsertParameters("TimesheetPeriodType").DefaultValue = TimesheetPeriodType
                .InsertParameters("PeriodStartDate").DefaultValue = dtStartDate
                .InsertParameters("PeriodEndDate").DefaultValue = dtEndDate
                .InsertParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodId.ToString
                If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender And DBUtilities.GetShowDescriptionInWeekView Then
                    .InsertParameters("Description").DefaultValue = CType(objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("DS" & DayNo & objRow.RowIndex), TextBox).Text
                End If
                .InsertParameters("IsTimeOff").DefaultValue = Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString
                .InsertParameters("AccountTimeOffTypeId").DefaultValue = Me.GetCellValue(objRow, 1, "ddlTimeOffTypeId")
                .InsertParameters("AccountEmployeeTimeOffRequestId").DefaultValue = System.Guid.Empty.ToString
                .InsertParameters("AccountEmployeeTimeEntryApprovalProjectId").DefaultValue = ApprovalProjectId.ToString
                .InsertParameters("Approved").DefaultValue = ProjectApproved
                .InsertParameters("Percentage").DefaultValue = Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo)
                '.InsertParameters("Hours").DefaultValue = IIf(Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) <> "", Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo), "0")
                For n As Integer = 1 To 9
                    If Not objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex) Is Nothing Then
                        If Not objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("CustomField" & n & DayNo & objRow.RowIndex) Is Nothing Then
                            .InsertParameters("CustomField" & n).DefaultValue = Me.GetCellValueForCustomField(objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("CustomField" & n & DayNo & objRow.RowIndex))
                        End If
                    End If
                Next
                .Insert()
            End With
        Catch ex As Exception
            Throw ex.InnerException
        End Try
    End Sub
    ''' <summary>
    ''' Update record of specified UpdateId, objRow, DayNo, AccountEmployeeTimeEntryPeriodId, ApprovalProjectId, ProjectApproved
    ''' </summary>
    ''' <param name="UpdateId"></param>
    ''' <param name="objRow"></param>
    ''' <param name="DayNo"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <param name="ApprovalProjectId"></param>
    ''' <param name="ProjectApproved"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRecord(ByVal UpdateId As Integer, ByVal objRow As GridViewRow, ByVal DayNo As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Guid, ByVal ApprovalProjectId As Guid, ByVal ProjectApproved As Boolean, ByVal Submitted As Boolean)
        If Not IsValidDataAvailable(DayNo, objRow) Then
            Return
        End If
        Try
            With Me.dsAccountEmployeeTimeEntriesWeek
                .UpdateParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
                .UpdateParameters("Original_AccountEmployeeTimeEntryId").DefaultValue = UpdateId
                If Me.GetCellValue(objRow, 1, "PT") <> "" And DBUtilities.GetShowProjectInTimesheet = False Then
                    .UpdateParameters("AccountProjectId").DefaultValue = IIf(Me.GetCellValue(objRow, 0, "P") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 1, "PT"), True), Me.GetCellValue(objRow, 0, "P"))
                Else
                    .UpdateParameters("AccountProjectId").DefaultValue = Me.GetCellValue(objRow, 0, "P")
                End If
                .UpdateParameters("TimeEntryDate").DefaultValue = WorkingDays(DayNo)
                .UpdateParameters("AccountProjectTaskId").DefaultValue = Me.GetCellValue(objRow, 1, "PT")
                If Me.GetCellValue(objRow, 1, "PT") <> "" And DBUtilities.GetShowClientInTimesheet = False Then
                    .UpdateParameters("AccountPartyId").DefaultValue = IIf(Me.GetCellValue(objRow, 1, "C") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 1, "PT"), False), Me.GetCellValue(objRow, 1, "C"))
                Else
                    .UpdateParameters("AccountPartyId").DefaultValue = Me.GetCellValue(objRow, 1, "C")
                End If
                .UpdateParameters("AccountCostCenterId").DefaultValue = Me.GetCellValue(objRow, 2, "CC")
                .UpdateParameters("AccountWorkTypeId").DefaultValue = IIf(Me.GetCellValue(objRow, 3, "W") = "", GetStandardWorkType, Me.GetCellValue(objRow, 3, "W"))
                .UpdateParameters("StartTime").DefaultValue = Me.GetCellValue(objRow, DayNo + 5, "S" & DayNo)
                .UpdateParameters("EndTime").DefaultValue = Me.GetCellValue(objRow, DayNo + 5, "E" & DayNo)
                .UpdateParameters("TotalTime").DefaultValue = IIf(Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) <> "", Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo), "0")
                If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("TotalTime" & DayNo)) And Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo) = "" And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                    .UpdateParameters("TotalTime").DefaultValue = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(Me.G.DataKeys(objRow.RowIndex)("TotalTime" & DayNo))
                End If
                .UpdateParameters("TimesheetPeriodType").DefaultValue = TimesheetPeriodType
                .UpdateParameters("PeriodStartDate").DefaultValue = dtStartDate
                .UpdateParameters("PeriodEndDate").DefaultValue = dtEndDate
                .UpdateParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodId.ToString
                If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender And DBUtilities.GetShowDescriptionInWeekView Then
                    .UpdateParameters("Description").DefaultValue = CType(objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("DS" & DayNo & objRow.RowIndex), TextBox).Text
                    'Else
                    '    .UpdateParameters("Description").DefaultValue = "WeekViewDescription"
                End If

                .UpdateParameters("IsTimeOff").DefaultValue = Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString
                .UpdateParameters("AccountTimeOffTypeId").DefaultValue = Me.GetCellValue(objRow, 1, "ddlTimeOffTypeId")
                .UpdateParameters("AccountEmployeeTimeEntryApprovalProjectId").DefaultValue = ApprovalProjectId.ToString
                .UpdateParameters("Approved").DefaultValue = ProjectApproved
                .UpdateParameters("Percentage").DefaultValue = Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo)
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("Percentage" & DayNo)) And Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo) = "" And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                    .UpdateParameters("Percentage").DefaultValue = Me.G.DataKeys(objRow.RowIndex)("Percentage" & DayNo)
                End If

                For n As Integer = 1 To 9
                    If Not objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex) Is Nothing Then
                        If Not objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("CustomField" & n & DayNo & objRow.RowIndex) Is Nothing Then
                            .UpdateParameters("CustomField" & n).DefaultValue = Me.GetCellValueForCustomField(objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("CustomField" & n & DayNo & objRow.RowIndex))
                        End If
                    End If
                Next
                .Update()

            End With

        Catch ex As Exception
            Throw ex.InnerException
        End Try
    End Sub

    ''' <summary>
    ''' Get attendance date by no of specified DayNo
    ''' </summary>
    ''' <param name="DayNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAttendanceDateByNo(ByVal DayNo As Integer) As DateTime
        Return DateAdd(DateInterval.Day, DayNo, dtStartDate)
    End Function
    ''' <summary>
    ''' Save
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save(URL As String)
        Dim StartTime As DateTime = Now
        Dim EndTime As DateTime
        Dim IsError As Boolean = False
        Dim HTApprovalProject As New Hashtable
        Dim HTProjectApproved As New Hashtable
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim IsAlreadyDeleted As Boolean = False
        Dim EXdtApprovalProjectId As Guid
        Dim EXdtAccountProjectId As Integer
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: StartTime= " & StartTime & " Session_AccountEMployeeID=" & DBUtilities.GetSessionAccountEmployeeId & " DropDownAccountEmployeeId=" & TimeEntryAccountEmployeeId)
        Try
            Dim objRow As GridViewRow
            If Me.ViewState("IsCopyFromDate") = "True" Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: IsCopyFromDate=True")
                If IsAlreadyDeleted = False Then
                    DeleteOldWeekEntriesForNewCopyEntries(TimeEntryAccountEmployeeId, Me.ViewState("dtStartDate"), Me.ViewState("dtEndDate"))
                    IsAlreadyDeleted = True
                    'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: END DeleteOldWeekEntriesForNewCopyEntries: IsAlreadyDeleted=True")
                End If
            End If
            If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: AddAccountEmployeeTimeEntryPeriod dtAccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString)
                dtAccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, IIf(ButtonClicked = "Submit", True, False), False, False, False, TimesheetPeriodType, txtPeriodDescription.Text)
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: AddAccountEmployeeTimeEntryPeriod dtAccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString)
            Else
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: dtAccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString & " TimeEntryAccountEmployeeId=" & TimeEntryAccountEmployeeId & " dtStartDate=" & dtStartDate & " dtEndDate=" & dtEndDate & " Submit=" & IIf(ButtonClicked = "Submit", True, False))
                objTimeEntryBLL.UpdateAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, IIf(ButtonClicked = "Submit", True, False), False, False, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId, txtPeriodDescription.Text)
            End If
            For Each objRow In Me.G.Rows
                Dim Submitted As Boolean = IIf(ButtonClicked = "Submit", True, False)
                Dim IsTimeOff As Boolean = Me.G.DataKeys(objRow.RowIndex).Item("IsTimeOff")
                Dim ApprovalProjectIdDataKey As Object
                Dim ProjectApprovedDataKey As Object
                Dim dtApprovalProjectId As Guid
                Dim dtAccountProjectId As Integer
                Dim AccountProjectIdDataKey As Object
                Dim ProjectRejectedDataKey As Object
                dtAccountProjectId = IIf(CType(objRow.FindControl("P"), DropDownList).SelectedValue = "", 0, CType(objRow.FindControl("P"), DropDownList).SelectedValue)
                EXdtAccountProjectId = dtAccountProjectId
                AccountProjectIdDataKey = IIf(IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountProjectId")), dtAccountProjectId, Me.G.DataKeys(objRow.RowIndex)("AccountProjectId"))
                ProjectRejectedDataKey = IIf(IsDBNull(Me.G.DataKeys(objRow.RowIndex)("Rejected0")), False, Me.G.DataKeys(objRow.RowIndex)("Rejected0"))
                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Outerloop: dtAccountProjectId= " & dtAccountProjectId.ToString & " EXdtAccountProjectId=" & EXdtAccountProjectId & " AccountProjectIdDataKey=" & AccountProjectIdDataKey & " ProjectRejectedDataKey=" & ProjectRejectedDataKey & " IsTimeOff=" & IsTimeOff)
                For n As Integer = 0 To WorkingDaysCount - 1

                    If (Me.GetCellValue(objRow, n + 5, "TT" & n) <> "" Or CType(objRow.Cells(5 + n).FindControl("TT" & n), TextBox).Visible = False) And Not dtAccountProjectId = 0 And Not HTApprovalProject.Contains("AccountProjectId=" & dtAccountProjectId) And IsTimeOff <> True Then
                        ' ''If IsDeletedTimeEntryPeriod = True Then
                        ' ''    dtAccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.GetAccountEmployeeTimeEntryPeriodIdByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
                        ' ''    If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
                        ' ''        dtAccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, IIf(ButtonClicked = "Submit", True, False), False, False, False, TimesheetPeriodType, txtPeriodDescription.Text)
                        ' ''        If dtAccountEmployeeTimeEntryPeriodId <> System.Guid.Empty Then
                        ' ''            '''''''''''''''''''''    IsDeletedTimeEntryPeriod = False
                        ' ''        End If
                        ' ''    End If
                        ' ''    Dim dtApproval As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = objTimeEntryBLL.GetAccountEmployeeTimeEntryApprovalProjectByTimeEntryPeriodIdAndAccountProjectId(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId)
                        ' ''    Dim drApproval As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
                        ' ''    If dtApproval.Rows.Count = 0 Then
                        ' ''        dtApprovalProjectId = objTimeEntryBLL.AddAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, Submitted, False, False, IIf(Submitted = True, ProjectApprovedDataKey, False), False, False)
                        ' ''    Else
                        ' ''        drApproval = dtApproval.Rows(0)
                        ' ''        dtApprovalProjectId = drApproval.AccountEmployeeTimeEntryApprovalProjectId
                        ' ''    End If
                        ' ''End If
                        If Not IsAlreadyDeleted = True Then
                            ApprovalProjectIdDataKey = Me.G.DataKeys(objRow.RowIndex).Item("AccountEmployeeTimeEntryApprovalProjectId")
                            ProjectApprovedDataKey = IIf(IsDBNull(Me.G.DataKeys(objRow.RowIndex).Item("ProjectApproved")), False, Me.G.DataKeys(objRow.RowIndex).Item("ProjectApproved"))
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop1: IsAlreadyDeleted= " & IsAlreadyDeleted & " ApprovalProjectIdDataKey=" & ApprovalProjectIdDataKey.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey)
                        Else
                            ApprovalProjectIdDataKey = System.DBNull.Value
                            ProjectApprovedDataKey = False
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop2: IsAlreadyDeleted= " & IsAlreadyDeleted & " ApprovalProjectIdDataKey=" & ApprovalProjectIdDataKey.ToString & " ProjectApprovedDataKey=False")
                        End If
                        If Not IsDBNull(ApprovalProjectIdDataKey) And dtAccountProjectId = AccountProjectIdDataKey Then
                            dtApprovalProjectId = ApprovalProjectIdDataKey
                            EXdtApprovalProjectId = dtApprovalProjectId
                            If objTimeEntryBLL.SetApprovalStateForApprovalProject(dtAccountProjectId) = True And Submitted = True Then
                                ProjectApprovedDataKey = True
                            End If
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop3: dtApprovalProjectId= " & dtApprovalProjectId.ToString & " AccountProjectIdDataKey= " & AccountProjectIdDataKey & " dtAccountProjectId=" & dtAccountProjectId & " ApprovalProjectIdDataKey=" & ApprovalProjectIdDataKey.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey & "  " & dtAccountProjectId & "=" & AccountProjectIdDataKey)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop3: Start UpdateAccountEmployeeTimeEntryApprovalProject")
                            objTimeEntryBLL.UpdateAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, Submitted, "NULL", False, ProjectApprovedDataKey, IIf(Submitted = True, False, ProjectRejectedDataKey), dtApprovalProjectId)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop3: End UpdateAccountEmployeeTimeEntryApprovalProject")
                        ElseIf Not IsDBNull(ApprovalProjectIdDataKey) And dtAccountProjectId <> AccountProjectIdDataKey Then
                            dtApprovalProjectId = objTimeEntryBLL.GetApprovalProjectIdByTimesheetPeriodIdAndProjectId(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId)
                            ProjectApprovedDataKey = objTimeEntryBLL.GetApprovedStatusByAccountEmployeeTimeEntryApprovalProjectId(dtApprovalProjectId)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop4: dtApprovalProjectId= " & dtApprovalProjectId.ToString & " AccountProjectIdDataKey= " & AccountProjectIdDataKey & " dtAccountProjectId=" & dtAccountProjectId & " ApprovalProjectIdDataKey=" & ApprovalProjectIdDataKey.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey & "  " & dtAccountProjectId & "<>" & AccountProjectIdDataKey)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop4: Start UpdateAccountEmployeeTimeEntryApprovalProject")
                            objTimeEntryBLL.UpdateAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, Submitted, "NULL", False, ProjectApprovedDataKey, IIf(Submitted = True, False, ProjectRejectedDataKey), dtApprovalProjectId)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop4: End UpdateAccountEmployeeTimeEntryApprovalProject")
                        ElseIf IsDBNull(ApprovalProjectIdDataKey) Then
                            dtApprovalProjectId = objTimeEntryBLL.GetApprovalProjectIdByTimesheetPeriodIdAndProjectId(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId)
                            ProjectApprovedDataKey = objTimeEntryBLL.GetApprovedStatusByAccountEmployeeTimeEntryApprovalProjectId(dtApprovalProjectId)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop5: dtApprovalProjectId= " & dtApprovalProjectId.ToString & " ApprovalProjectIdDataKey=" & ApprovalProjectIdDataKey.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey & " dtAccountProjectId= " & dtAccountProjectId)
                            If dtApprovalProjectId <> System.Guid.Empty Then
                                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop5: Start UpdateAccountEmployeeTimeEntryApprovalProject")
                                objTimeEntryBLL.UpdateAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, Submitted, "NULL", False, ProjectApprovedDataKey, IIf(Submitted = True, False, ProjectRejectedDataKey), dtApprovalProjectId)
                                'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop5: End UpdateAccountEmployeeTimeEntryApprovalProject")
                            End If
                        End If
                        If objTimeEntryBLL.SetApprovalStateForApprovalProject(dtAccountProjectId) = True And Submitted = True Then
                            ProjectApprovedDataKey = True
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop6: dtAccountProjectId= " & dtAccountProjectId & " Submitted=" & Submitted & " ProjectApprovedDataKey=" & ProjectApprovedDataKey)
                        End If
                        If dtApprovalProjectId = System.Guid.Empty Then
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop7: Start AddAccountEmployeeTimeEntryApprovalProject dtApprovalProjectId= " & dtApprovalProjectId.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey)
                            dtApprovalProjectId = objTimeEntryBLL.AddAccountEmployeeTimeEntryApprovalProject(dtAccountEmployeeTimeEntryPeriodId, dtAccountProjectId, TimeEntryAccountEmployeeId, 0, Submitted, False, False, IIf(Submitted = True, ProjectApprovedDataKey, False), False, False)
                            'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop7: Start AddAccountEmployeeTimeEntryApprovalProject dtApprovalProjectId= " & dtApprovalProjectId.ToString)
                        End If
                        HTApprovalProject.Add("AccountProjectId=" & dtAccountProjectId, dtApprovalProjectId)
                        HTProjectApproved.Add("AccountProjectId=" & dtAccountProjectId, ProjectApprovedDataKey)
                    End If
                    ProjectApprovedDataKey = HTProjectApproved.Item("AccountProjectId=" & dtAccountProjectId)
                Next
                If objRow.RowType = DataControlRowType.DataRow Then
                    'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop8 : Start UpdateRow dtAccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey & "Submitted= " & Submitted)

                    Me.UpdateRow(objRow, dtAccountEmployeeTimeEntryPeriodId, HTApprovalProject("AccountProjectId=" & dtAccountProjectId), ProjectApprovedDataKey, Submitted)


                    'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save Innerloop8 : End UpdateRow dtAccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString & " ProjectApprovedDataKey=" & ProjectApprovedDataKey & "Submitted= " & Submitted)
                End If
            Next
            'objTimeEntryBLL.DeleteAccountEmployeeTimeEntryApprovalProjectIfNotExist(dtAccountEmployeeTimeEntryPeriodId)
            objTimeEntryBLL.DeleteApprovalProjectIfNotExistInAccountEmployeeTimeEntry(dtAccountEmployeeTimeEntryPeriodId)
            objTimeEntryBLL.SetAccountEmployeeTimeEntryPeriodApprovalStatus(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId)
            Dim TimeOffBLL As New AccountEmployeeTimeOffRequestBLL
            If ButtonClicked = "Submit" Then
                objTimeEntryBLL.SendPendingTimesheetForSpecificTimeEntryPeriodWithThread(dtAccountEmployeeTimeEntryPeriodId)
                TimeOffBLL.SendPendingTimeEntryForTimeOffInstantEmailWithThread(dtAccountEmployeeTimeEntryPeriodId)
            End If
            EndTime = Now
            Dim totalTime As Long = DateDiff(DateInterval.Second, StartTime, EndTime)
            System.Diagnostics.Trace.Write(totalTime)

        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                ShowErrorMessage(Replace(Replace(Replace(ex.InnerException.Message, "'", ""), """", ""), vbCrLf, ""), URL)
            Else
                ShowErrorMessage(Replace(Replace(Replace(ex.Message, "'", ""), """", ""), vbCrLf, ""), URL)
            End If
            LoggingBLL.WriteExceptionNoRaiseToLog("TimeEntry Period View Save(): ButtonClicked= " & ButtonClicked & " dtApprovalProjectId= " & EXdtApprovalProjectId.ToString & " PeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString & " ProjectId= " & EXdtAccountProjectId & " EmployeeId= " & TimeEntryAccountEmployeeId, ex)
            'Throw ex
            IsError = True
        End Try
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function Save: EndTime= " & EndTime & " Session_AccountEMployeeID=" & DBUtilities.GetSessionAccountEmployeeId & " DropDownAccountEmployeeId=" & TimeEntryAccountEmployeeId)
        If Not IsError Then
            Response.Redirect(URL, False)
        End If
    End Sub

    ''' <summary>
    ''' Is row changed event
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsRowChanged(ByVal objRow As GridViewRow, ByVal DayNo As Integer) As Boolean
        If objRow.RowType = DataControlRowType.DataRow Then

            If (Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryId" & DayNo)) And LocaleUtilitiesBLL.IsShowProjectForTimeOff) Or Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                Dim AccountProjectId As Integer
                Dim OldAccountProjectId As Integer
                If Me.GetCellValue(objRow, 1, "P") <> "" Then
                    AccountProjectId = Me.GetCellValue(objRow, 1, "P")
                End If
                If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountProjectId")) Then
                    OldAccountProjectId = Me.G.DataKeys(objRow.RowIndex)("AccountProjectId")
                End If
                If OldAccountProjectId <> AccountProjectId Then
                    Return True
                End If
            End If

            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("PT")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.GetCellValue(objRow, 2, "PT") = "" Then
                    Return False
                End If
            End If
            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountProjectTaskId")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.G.DataKeys(objRow.RowIndex)("AccountProjectTaskId") <> Me.GetCellValue(objRow, 2, "PT") Then
                    Return True
                End If
            End If

            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountCostCenterId")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.G.DataKeys(objRow.RowIndex)("AccountCostCenterId") <> Me.GetCellValue(objRow, 3, "CC") Then
                    Return True
                End If
            ElseIf IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountCostCenterId")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.GetCellValue(objRow, 3, "CC") <> "0" Then
                    Return True
                End If
            End If

            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountWorkTypeId")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.G.DataKeys(objRow.RowIndex)("AccountWorkTypeId") <> Me.GetCellValue(objRow, 4, "W") Then
                    Return True
                End If
            End If
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If DBUtilities.GetShowClockStartEnd = True And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.G.DataKeys(objRow.RowIndex)("StartTime" & DayNo), Me.GetCellValue(objRow, DayNo + 5, "S" & DayNo)) Then
                        Return True
                    End If
                End If
                If DBUtilities.GetShowClockStartEnd = True And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.G.DataKeys(objRow.RowIndex)("EndTime" & DayNo), Me.GetCellValue(objRow, DayNo + 5, "E" & DayNo)) Then
                        Return True
                    End If
                End If
            ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
                If DBUtilities.ShowClockStartEndEmployee = True And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.G.DataKeys(objRow.RowIndex)("StartTime" & DayNo), Me.GetCellValue(objRow, DayNo + 5, "S" & DayNo)) Then
                        Return True
                    End If
                End If
                If DBUtilities.ShowClockStartEndEmployee = True And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.G.DataKeys(objRow.RowIndex)("EndTime" & DayNo), Me.GetCellValue(objRow, DayNo + 5, "E" & DayNo)) Then
                        Return True
                    End If
                End If
            End If

            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("TotalTime" & DayNo)) Then
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    If Me.G.DataKeys(objRow.RowIndex)("Hours" & DayNo) <> CDec(Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo)) Then
                        Return True
                    End If
                Else
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.G.DataKeys(objRow.RowIndex)("TotalTime" & DayNo), Me.GetCellValue(objRow, DayNo + 5, "TT" & DayNo)) Then
                        Return True
                    End If
                End If
            End If

            Dim percentage As Double
            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("Percentage" & DayNo)) Then
                percentage = Me.G.DataKeys(objRow.RowIndex)("Percentage" & DayNo)
            End If
            If LocaleUtilitiesBLL.ShowPercentageInTimesheet() And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If percentage <> IIf(Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo) = "", 0, Me.GetCellValue(objRow, DayNo + 5, "PC" & DayNo)) Then
                    Return True
                End If
            End If

            Dim strDescription As String
            If IsDBNull(Me.G.DataKeys(objRow.RowIndex)("Description" & DayNo)) Then
                strDescription = ""
            Else
                strDescription = Me.G.DataKeys(objRow.RowIndex)("Description" & DayNo)
            End If
            If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender And DBUtilities.GetShowDescriptionInWeekView Then
                If strDescription <> CType(objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("DS" & DayNo & objRow.RowIndex), TextBox).Text Then
                    Return True
                End If
            End If
            Dim Submitted As Boolean = IIf(ButtonClicked = "Submit", True, False)
            If Submitted = True Then
                Dim SubmittedDataKey As Boolean
                If IsDBNull(Me.G.DataKeys(objRow.RowIndex)("Submitted" & DayNo)) Then
                    SubmittedDataKey = False
                Else
                    SubmittedDataKey = Me.G.DataKeys(objRow.RowIndex)("Submitted" & DayNo)
                End If
                If SubmittedDataKey <> Submitted Then
                    Return True
                End If
            End If
            If Not IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountTimeOffTypeId")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "True" Then
                If Me.G.DataKeys(objRow.RowIndex)("AccountTimeOffTypeId").ToString <> Me.GetCellValue(objRow, 2, "ddlTimeOffTypeId") Then
                    Return True
                End If
            End If
            If IsDBNull(Me.G.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId")) And Me.G.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                Return True
            End If
            If Not objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex) Is Nothing Then
                For n As Integer = 1 To 9
                    Dim strcustomfield As String
                    If IsDBNull(Me.G.DataKeys(objRow.RowIndex)("CustomField" & n & DayNo)) Then
                        strcustomfield = ""
                    Else
                        strcustomfield = Me.G.DataKeys(objRow.RowIndex)("CustomField" & n & DayNo)
                    End If
                    If strcustomfield <> GetCellValueForCustomField(objRow.Cells(DayNo + 5).FindControl("Pn" & DayNo & objRow.RowIndex).FindControl("CustomField" & n & DayNo & objRow.RowIndex)) Then
                        Return True
                    End If
                Next
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' Delete old week entries for new copy entries of specified AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <remarks></remarks>
    Public Sub DeleteOldWeekEntriesForNewCopyEntries(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries AccountEmployeeId= " & AccountEmployeeId & " TimeEntryStartDate= " & TimeEntryStartDate & " TimeEntryEndDate=" & TimeEntryEndDate)
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries: Start DeleteTimeEntryWeekViewByEmployeeIdAndTimeEntryDate AccountEmployeeId= " & AccountEmployeeId & " TimeEntryStartDate= " & TimeEntryStartDate & " TimeEntryEndDate=" & TimeEntryEndDate)
        TimeEntryBLL.DeleteTimeEntryWeekViewByEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate)
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries: End DeleteTimeEntryWeekViewByEmployeeIdAndTimeEntryDate AccountEmployeeId= " & AccountEmployeeId & " TimeEntryStartDate= " & TimeEntryStartDate & " TimeEntryEndDate=" & TimeEntryEndDate)
        Dim AccountEmployeeTimeEntryPeriodId As Guid = TimeEntryBLL.GetAccountEmployeeTimeEntryPeriodIdByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimesheetPeriodType)
        If Not AccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectDataTable = TimeEntryBLL.GetAccountEmployeeTimeEntryApprovalProjectByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
            Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectRow
            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries: Start DeleteAccountEmployeeTimeEntryApprovalProject AccountEmployeeTimeEntryPeriodId= " & AccountEmployeeTimeEntryPeriodId.ToString & " dr.AccountEmployeeTimeEntryApprovalProjectId= " & dr.AccountEmployeeTimeEntryApprovalProjectId.ToString)
                    TimeEntryBLL.DeleteAccountEmployeeTimeEntryApprovalProject(dr.AccountEmployeeTimeEntryApprovalProjectId)
                    'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries: End DeleteAccountEmployeeTimeEntryApprovalProject AccountEmployeeTimeEntryPeriodId= " & AccountEmployeeTimeEntryPeriodId.ToString & " dr.AccountEmployeeTimeEntryApprovalProjectId= " & dr.AccountEmployeeTimeEntryApprovalProjectId.ToString)
                Next
            End If
        End If
        If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            dtAccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntryPeriodId
        End If
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries: Start DeleteAccountEmployeeTimeEntryPeriod AccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString & " TimesheetPeriodType= " & TimesheetPeriodType)
        TimeEntryBLL.DeleteAccountEmployeeTimeEntryPeriod(AccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimesheetPeriodType, dtAccountEmployeeTimeEntryPeriodId)
        'LoggingBLL.WriteToLog("TimeEntryPeriod: Function DeleteOldWeekEntriesForNewCopyEntries: End DeleteAccountEmployeeTimeEntryPeriod AccountEmployeeTimeEntryPeriodId= " & dtAccountEmployeeTimeEntryPeriodId.ToString & " TimesheetPeriodType= " & TimesheetPeriodType)
        dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty
    End Sub
    ''' <summary>
    ''' Grid row updating event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub WG_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles G.RowUpdating
        Dim objRow As GridViewRow = Me.G.Rows(e.RowIndex)
        If objRow.RowType = DataControlRowType.DataRow Then
        End If
    End Sub
    ''' <summary>
    ''' Show date of specified dtDate, CopyFromDate, IsCopyFromDate
    ''' </summary>
    ''' <param name="dtDate"></param>
    ''' <param name="CopyFromDate"></param>
    ''' <param name="IsCopyFromDate"></param>
    ''' <remarks></remarks>
    Public Sub ShowDate(ByVal dtDate As Date, ByVal CopyFromDate As Date, ByVal IsCopyFromDate As Boolean, ByVal IsFromTemplate As Boolean)
        Me.ViewState.Add("dtStartDate", dtStartDate)
        Me.ViewState.Add("dtEndDate", dtEndDate)
        Me.ViewState.Add("dtCopyFromStartDate", dtCopyFromStartDate)
        Me.ViewState.Add("dtCopyFromEndDate", dtCopyFromEndDate)
        Me.ViewState.Add("IsCopyFromDate", IsCopyFromDate)

        If IsCopyFromDate = False Then
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
            dtAccountEmployeeTimeEntryPeriodId = New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodIdForPeriodView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
            Me.ViewState.Add("dtAccountEmployeeTimeEntryPeriodId", dtAccountEmployeeTimeEntryPeriodId)
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimeEntryStartDate").DefaultValue = dtStartDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimeEntryEndDate").DefaultValue = dtEndDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = dtAccountEmployeeTimeEntryPeriodId.ToString
        Else
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
            dtCopyAccountEmployeeTimeEntryPeriodId = New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodIdForPeriodView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtCopyFromStartDate, dtCopyFromEndDate, TimesheetPeriodType)
            Me.ViewState.Add("dtCopyAccountEmployeeTimeEntryPeriodId", dtCopyAccountEmployeeTimeEntryPeriodId)
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimeEntryStartDate").DefaultValue = dtCopyFromStartDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimeEntryEndDate").DefaultValue = dtCopyFromEndDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("CopyToStartDate").DefaultValue = dtStartDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("CopyToEndDate").DefaultValue = dtEndDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("IsCopy").DefaultValue = IsCopyFromDate
            Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = dtCopyAccountEmployeeTimeEntryPeriodId.ToString
        End If
        Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("IsFromTemplate").DefaultValue = IsFromTemplate
        If IsFromTemplate Then
            Me.ViewState.Add("IsCopyFromDate", True)
        End If
    End Sub
    ''' <summary>
    ''' Button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles WeekButton1.Click
        If Me.ValidateTimeEntryWeekView("Save") = True Then
            Dim URL As String = "AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("dtStartDate")) & "&" & "AccountEmployeeId=" & TimeEntryAccountEmployeeId
            Me.Save(URL)
            'Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("dtStartDate")) & "&" & "AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
        End If
    End Sub
    Public Sub ShowErrorMessage(ByVal message As String, URL As String)
        Dim strMessage As String = message
        Dim strScript As String = "alert('" & strMessage & "'); window.location = '" & URL & "';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    ''' <summary>
    ''' Button submit click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.ValidateTimeEntryWeekView("Submit") = True Then
            dsAccountEmployeeTimeEntriesWeek.InsertParameters("Submitted").DefaultValue = True
            dsAccountEmployeeTimeEntriesWeek.UpdateParameters("Submitted").DefaultValue = True
            Dim URL As String = "~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=PeriodView"
            Me.Save(URL)
            'Response.Redirect("~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=PeriodView", False)
            'Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & Me.ViewState("dtStartDate") & "&" & "AccountEmployeeId=" & TimeEntryAccountEmployeeId)
        End If
    End Sub
    ''' <summary>
    ''' Get standard work type
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
    ''' Hide columns in grid view
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HideColumnsInGridView()
        If DBUtilities.IsShowCostCenterInTimeSheet = False Then
            Me.G.Columns(COSTCENTER_COLUMN).Visible = False
        Else
            Me.G.Columns(COSTCENTER_COLUMN).HeaderText = ResourceHelper.GetFromResource("Cost Center")
        End If
        If DBUtilities.IsShowWorkTypeInTimeSheet = False Then
            Me.G.Columns(WORKTYPE_COLUMN).Visible = False
        End If
        If DBUtilities.GetShowClientInTimesheet = False Then
            Me.G.Columns(CLIENT_COLUMN).Visible = False
        End If
        ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") = "Yes" Then
        If DBUtilities.GetShowProjectInTimesheet = False Then
            Me.G.Columns(PROJECT_COLUMN).Visible = False
        End If
        ''End If
    End Sub
    ''' <summary>
    ''' Show data for cost center id of specified object row
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <remarks></remarks>
    Public Sub ShowDataForddlAccountCostCenterId(ByVal objrow As GridViewRow)
        If Not CType(objrow.Cells(2).FindControl("CC"), DropDownList) Is Nothing Then
            CType(objrow.Cells(2).FindControl("CC"), DropDownList).Items.Clear()
            Dim item As New System.Web.UI.WebControls.ListItem
            item.Text = "<None>"
            item.Value = "0"
            item.Enabled = False
            CType(objrow.Cells(2).FindControl("CC"), DropDownList).Items.Add(item)
            CType(objrow.Cells(2).FindControl("CC"), DropDownList).DataBind()
        End If
    End Sub
    ''' <summary>
    ''' Show time entry status of specified row, dayNo
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="dayNo"></param>
    ''' <remarks></remarks>
    Public Sub ShowTimeEntryStatus(ByVal row As GridViewRow, ByVal dayNo As Integer)
        AccountEmployeeTimeEntryBLL.SetSubmittedStatus("i" & dayNo, row, 5 + dayNo, "Approved" & dayNo, "Submitted" & dayNo, "Rejected" & dayNo, Nothing, dayNo)
    End Sub
    ''' <summary>
    ''' Set ajax extender data item of specified DayNo, Row
    ''' </summary>
    ''' <param name="DayNo"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetAjaxExtenderDataItem(ByVal DayNo As Integer, ByVal Row As GridViewRow)
        If Not Row.Cells(5 + DayNo).FindControl("Pn" & DayNo & Row.RowIndex) Is Nothing Then
            If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender Then
                If DBUtilities.GetShowDescriptionInWeekView Then
                    Dim objTextbox As TextBox
                    objTextbox = Row.Cells(5 + DayNo).FindControl("Pn" & DayNo & Row.RowIndex).FindControl("DS" & DayNo & Row.RowIndex)
                    If Not objTextbox Is Nothing Then
                        If Not IsDBNull(DataBinder.Eval(Row.DataItem, "Description" & DayNo)) Then
                            objTextbox.Text = DataBinder.Eval(Row.DataItem, "Description" & DayNo)
                        End If
                    End If
                End If
                For n As Integer = 1 To 9
                    SetCellValue(Row.Cells(5 + DayNo).FindControl("Pn" & DayNo & Row.RowIndex).FindControl("CustomField" & n & DayNo & Row.RowIndex), IIf(IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")), DataBinder.Eval(Row.DataItem, "CustomField" & n & DayNo), System.DBNull.Value), DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId" & DayNo), Me.Request.QueryString("IsCopyActivities"))
                Next
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set ajax extender of specified DayNo, Row
    ''' </summary>
    ''' <param name="DayNo"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetAjaxExtender(ByVal DayNo As Integer, ByVal Row As GridViewRow, dt As AccountCustomField.vueAccountCustomFieldManageDataTable)
        If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender And (Not CType(Row.Cells(6 + DayNo).FindControl("TT" & DayNo), TextBox) Is Nothing Or Not CType(Row.Cells(6 + DayNo).FindControl("PC" & DayNo), TextBox) Is Nothing) Then
            Dim IsShowDescriptionPopUp As Boolean = DBUtilities.GetShowDescriptionInWeekView
            Dim objPanel As New Panel
            Dim IsCustomField As Boolean
            Dim TotalRows As Integer
            Dim CustomControlsBLL As New AspNetCustomControlsBLL
            Dim dr As AccountCustomField.vueAccountCustomFieldManageRow
            For Each dr In dt.Rows
                If dr.IsDisabled <> True Then
                    If TotalRows <> 0 Then
                        objPanel.Controls.Add(New LiteralControl("<br />"))
                    End If
                    TotalRows += 1
                    objPanel.Controls.Add(CustomControlsBLL.AddLabel(dr.DatabaseFieldName & DayNo & Row.RowIndex, dr.CustomFieldCaption, "PL"))
                    objPanel.Controls.Add(New LiteralControl("<br />"))
                    If dr.MasterCustomDataTypeId.ToString = "7e295184-9623-4445-b99f-48f07929dce5" Then 'For TextBox
                        objPanel.Controls.Add(CustomControlsBLL.AddTextBox(dr.DatabaseFieldName & DayNo & Row.RowIndex, IIf(Not IsDBNull(dr.Item("MaximumLength")), dr.Item("MaximumLength"), 0), IIf(Not IsDBNull(dr.Item("DefaultValue")), dr.Item("DefaultValue"), ""), 200, "pttest", IIf(dt.Rows.Count = TotalRows And Not IsShowDescriptionPopUp, "hidepopup('" & Row.UniqueID & DayNo & "');", "")))
                        If dr.IsRequired Then
                            'objPanel.Controls.Add(CustomControlsBLL.AddRequiredFieldValidator(dr.DatabaseFieldName & DayNo & Row.RowIndex, dr.DatabaseFieldName & DayNo & Row.RowIndex))
                        End If
                        IsCustomField = True
                    ElseIf dr.MasterCustomDataTypeId.ToString = "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then 'For DropDownList
                        Dim ddl As DropDownList = CustomControlsBLL.AddDropDownList(dr.DatabaseFieldName & DayNo & Row.RowIndex, "pttest", IIf(dt.Rows.Count = TotalRows And Not IsShowDescriptionPopUp, "hidepopup('" & Row.UniqueID & DayNo & "');", ""), 200)
                        objPanel.Controls.Add(ddl)
                        If Not IsDBNull(dr.Item("DropDownOptions")) Then
                            Dim ddlitems() As String = Split(dr.DropDownOptions, "+")
                            For n As Integer = 0 To ddlitems.Length - 1
                                CustomControlsBLL.AddDropDownListItem(ddlitems(n), ddlitems(n), ddl)
                            Next
                        End If
                        If Not IsDBNull(dr.Item("DefaultValue")) Then
                            ddl.SelectedValue = dr.DefaultValue
                        End If
                        IsCustomField = True
                    ElseIf dr.MasterCustomDataTypeId.ToString = "5942a0be-e7fe-4abb-b96f-f0b20d744ce3" Then 'For Date
                        objPanel.Controls.Add(CustomControlsBLL.AddDateCalendarPopup(dr.DatabaseFieldName & DayNo & Row.RowIndex, "pttest", IIf(dt.Rows.Count = TotalRows And Not IsShowDescriptionPopUp, "hidepopup('" & Row.UniqueID & DayNo & "');", ""), 160, True))
                        IsCustomField = True
                    ElseIf dr.MasterCustomDataTypeId.ToString = "bacd6824-9011-4c30-864f-0899fefc004f" Then 'For Number
                        objPanel.Controls.Add(CustomControlsBLL.AddTextBox(dr.DatabaseFieldName & DayNo & Row.RowIndex, , IIf(Not IsDBNull(dr.Item("DefaultValue")), dr.Item("DefaultValue"), ""), 200, "pttest", IIf(dt.Rows.Count = TotalRows And Not IsShowDescriptionPopUp, "hidepopup('" & Row.UniqueID & DayNo & "');", "")))
                        If dr.IsRequired Then
                            'objPanel.Controls.Add(CustomControlsBLL.AddRequiredFieldValidator(dr.DatabaseFieldName & DayNo & Row.RowIndex, dr.DatabaseFieldName & DayNo & Row.RowIndex))
                        End If
                        'objPanel.Controls.Add(CustomControlsBLL.AddRangeValidator(dr.DatabaseFieldName & DayNo & Row.RowIndex, dr.DatabaseFieldName & DayNo & Row.RowIndex, IIf(Not IsDBNull(dr.Item("MinimumValue")), dr.Item("MinimumValue"), ""), IIf(Not IsDBNull(dr.Item("MaximumValue")), dr.Item("MaximumValue"), "")))
                        IsCustomField = True
                    End If
                    objPanel.Controls.Add(New LiteralControl("<br />"))
                End If
            Next
            If IsShowDescriptionPopUp Then
                If IsCustomField Then
                    objPanel.Controls.Add(New LiteralControl("<br />"))
                End If
                Dim lbl As New Label()
                lbl.Text = "Description:"
                lbl.CssClass = "PL"

                Dim txt As New TextBox
                txt.ID = "DS" & DayNo & Row.RowIndex
                txt.TextMode = TextBoxMode.MultiLine
                txt.CssClass = "pt"
                txt.Width = 200
                txt.Height = 75
                txt.Attributes.Add("onblur", "hidepopup('" & Row.UniqueID & DayNo & "');")
                objPanel.Controls.Add(lbl)
                objPanel.Controls.Add(txt)
            End If
            If IsCustomField Or IsShowDescriptionPopUp Then
                objPanel.Style.Add("DISPLAY", "none")
                Row.Cells(6 + DayNo).Controls.Add(objPanel)
                objPanel.ID = "Pn" & DayNo & Row.RowIndex
                objPanel.CssClass = "IP"

                Dim objExtender As New AjaxControlToolkit.PopupControlExtender
                objExtender.ID = "Ex" & DayNo & Row.RowIndex
                objExtender.TargetControlID = CType(Row.Cells(6 + DayNo).FindControl("TT" & DayNo), TextBox).ID
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet() And Me.G.DataKeys(Row.RowIndex)("IsTimeOff").ToString = "False" Then
                    objExtender.TargetControlID = CType(Row.Cells(6 + DayNo).FindControl("PC" & DayNo), TextBox).ID
                End If
                objExtender.PopupControlID = objPanel.ID
                objExtender.BehaviorID = Row.UniqueID & DayNo
                objExtender.Position = AjaxControlToolkit.PopupControlPopupPosition.Bottom
                objExtender.OffsetX = -170
                Row.Cells(6 + DayNo).Controls.Add(objExtender)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Disable week time entries of specified dayno, Row
    ''' </summary>
    ''' <param name="dayno"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub DisableWeekTimeEntries(ByVal dayno As Integer, ByVal Row As GridViewRow)
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = True Then
                If Not CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox) Is Nothing Then
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox))
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("E" & dayno), TextBox))
                End If
            End If
        ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
            If DBUtilities.ShowClockStartEndEmployee = True Then
                If Not CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox) Is Nothing Then
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox))
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("E" & dayno), TextBox))
                End If
            End If
        End If
        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(0).FindControl("C"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(0).FindControl("P"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(1).FindControl("PT"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(2).FindControl("W"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(3).FindControl("CC"), DropDownList))
        If Not CType(Row.Cells(5 + dayno).FindControl("TT" & dayno), TextBox) Is Nothing Then
            UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("TT" & dayno), TextBox))
        End If
        If Not CType(Row.Cells(5 + dayno).FindControl("PC" & dayno), TextBox) Is Nothing Then
            UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("PC" & dayno), TextBox))
        End If
        If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender = True And DBUtilities.GetShowDescriptionInWeekView Then
            If Not CType(Row.Cells(5 + dayno).FindControl("DS" & dayno & Row.RowIndex), TextBox) Is Nothing Then
                UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("DS" & dayno & Row.RowIndex), TextBox))
            End If
        End If
        If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender = True Then
            For n As Integer = 1 To 9
                DisableCustomFields(Row.Cells(5 + dayno).FindControl("CustomField" & n & dayno & Row.RowIndex))
            Next
        End If
    End Sub
    ''' <summary>
    ''' Refresh week view of specified bDateSelect
    ''' </summary>
    ''' <param name="bDateSelect"></param>
    ''' <remarks></remarks>
    Public Sub RefreshWeekView(Optional ByVal bDateSelect As Boolean = False)
        If bDateSelect = False Then
            TimeEntryAccountEmployeeId = Me.ddlEmployee.SelectedValue
            'LoggingBLL.WriteToLog("RefreshWeekView: ddlEmployee.SelectedValue=" & ddlEmployee.SelectedValue)
            Me.lnkTimesheetPeriodList.NavigateUrl = "~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=PeriodView"
            Dim CopyFromStartDate As Date = #1/1/2006#
            Dim IsCopyFrom As Boolean = False
            If Not Request.QueryString("CopyDate") Is Nothing Then
                CopyFromStartDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("CopyDate"))
                IsCopyFrom = True
            End If
            Dim IsFromTemplate As Boolean = False
            If Not Request.QueryString("IsFromTemplate") Is Nothing Then
                IsFromTemplate = True
            End If
            Me.ShowDate(Me.txtTimeEntryDate.SelectedDate.Date, CopyFromStartDate, IsCopyFrom, IsFromTemplate)
            CW2.Show(Me.GetAccountEmployeeTimeEntryPeriodId)
            Me.MsgBoxTagged(TimeEntryAccountEmployeeId)
        Else
            TimeEntryAccountEmployeeId = Me.ddlEmployee.SelectedValue
            If txtTimeEntryDate.SelectedDate.Year < 1753 Or txtTimeEntryDate.SelectedDate.Year > 9999 Then
                Me.txtTimeEntryDate.PostedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            End If
            Me.MsgBoxTagged(TimeEntryAccountEmployeeId)
            Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
        End If
    End Sub
    ''' <summary>
    ''' Get employee time entry period id
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAccountEmployeeTimeEntryPeriodId() As Guid
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = BLL.GetAccountEmployeeTimeEntryPeriodByTimeEntryDateAndTimeEntryView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
        Dim dr As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountEmployeeTimeEntryPeriodId
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' Image button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtStartDate.AddDays(-1)) & "&" & "AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
    End Sub
    ''' <summary>
    ''' Image button click event 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtEndDate.AddDays(1)) & "&" & "AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
    End Sub
    ''' <summary>
    ''' Text time entry date changed event 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub txtTimeEntryDate_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeEntryDate.DateChanged
        Me.RefreshWeekView(True)
    End Sub

    ''' <summary>
    ''' Set client cascading enabled 
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetClientCascadingEnabled(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        Dim dsObject As ObjectDataSource = CType(objRow.Cells(1).FindControl("dsAccountProjectsObject"), ObjectDataSource)
        Dim AccountProjectId As Integer = dsObject.SelectParameters("AccountProjectId").DefaultValue
        MyCascading = CType(objRow.FindControl("CP"), AjaxControlToolkit.CascadingDropDown)
        If DBUtilities.GetShowClientInTimesheet = False Then
            MyCascading.ParentControlID = Nothing
        End If
        MyCascading.Category = TimeEntryAccountEmployeeId & "," & AccountProjectId & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetSessionAccountId & "," & 0 & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetShowProjectInTimesheet
    End Sub
    ''' <summary>
    ''' Button copy click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        If Not VerifyIfTimeSheetHasTimeOffRequestRequired() Then
            Response.Redirect(GetCopyURL(False), False)
        Else
            Me.ShowNotFoundMessage("You cannot copy the timesheet because in this week you have some entries from ""My Timeoff"". If you want to proceed with this operation, please delete your requests from this week.")
        End If
    End Sub
    ''' <summary>
    ''' Button copy activities click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnCopyActivities_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyActivities.Click
        If Not VerifyIfTimeSheetHasTimeOffRequestRequired() Then
            Response.Redirect(GetCopyURL(True), False)
        Else
            Me.ShowNotFoundMessage("You cannot copy the timesheet because in this week you have some entries from ""My Timeoff"". If you want to proceed with this operation, please delete your requests from this week.")
        End If
    End Sub

    Private Function VerifyIfTimeSheetHasTimeOffRequestRequired() As Boolean
        Dim TimeOffRequestBLL As New AccountEmployeeTimeOffRequestBLL
        Dim res = TimeOffRequestBLL.VerifyTimeOffRequestPeriodOverlaping(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dtStartDate, dtEndDate)
        If res.Count = 0 Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Get copy url of specified IsCopyActivities
    ''' </summary>
    ''' <param name="IsCopyActivities"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCopyURL(ByVal IsCopyActivities As Boolean) As String
        If IsCopyActivities Then
            Return "AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&CopyDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.CopyFromCalendarPopup.PostedDate) & "&IsCopyActivities=True" & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId
        End If
        Return "AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&CopyDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.CopyFromCalendarPopup.PostedDate) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId
    End Function
    ''' <summary>
    ''' Expand forum paths event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode
        Return AccountPagePermissionBLL.ChangeCurrentNodeParent(25)
    End Function
    ''' <summary>
    ''' Page unload event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    ''' <summary>
    ''' Set client value on row data bound of specified objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary> 
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetClientValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        If DBUtilities.GetShowClientInTimesheet = True Then
            objDropdown = CType(Row.Cells(0).FindControl("C"), DropDownList)
            dsObject = CType(Row.Cells(0).FindControl("dsAccountClientObject"), ObjectDataSource)
            If Not objDropdown Is Nothing Then

                Dim dtvueProjects As AccountClient.TimeEntryClientDataTable = New AccountPartyBLL().GetAccountPartiesForTimeEntryByAccountEmployeeId(ddlEmployee.SelectedValue, IIf(Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")), DataBinder.Eval(Row.DataItem, "AccountClientId"), 0))
                Dim drvueProjects As AccountClient.TimeEntryClientRow
                If dtvueProjects.Rows.Count > 0 Then
                    drvueProjects = dtvueProjects.Rows(0)

                    '''If DBUtilities.GetShowProjectInTimesheet = False And DBUtilities.GetShowClientInTimesheet = True Then
                    If DBUtilities.HideProjectFromApplication = True Then
                        'If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") = "Yes" Then
                        Dim dtCLient As TimeLiveDataSet.AccountPartyDataTable = New AccountPartyBLL().GetAccountPartiesByAccountIdAndAccountPartyId(DBUtilities.GetSessionAccountId, IIf(Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")), DataBinder.Eval(Row.DataItem, "AccountClientId"), 0))
                        Dim drClient As TimeLiveDataSet.AccountPartyRow
                        If dtCLient.Rows.Count > 0 Then
                            drClient = dtCLient.Rows(0)
                        End If
                        If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then
                            dataValue = DataBinder.Eval(Row.DataItem, "AccountClientId")
                            objDropdown.SelectedValue = dataValue
                        End If
                        objDropdown.DataSource = dtCLient
                        objDropdown.DataBind()
                        'End If
                    Else
                        If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then
                            dataValue = DataBinder.Eval(Row.DataItem, "AccountClientId")
                            objDropdown.SelectedValue = dataValue
                        End If
                        objDropdown.DataSource = dtvueProjects
                        objDropdown.DataBind()
                    End If
                End If
            End If
            If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                UIUtilities.MakeDropdownReadonly(objDropdown)
            End If
        End If
    End Sub
    Dim TemplateAccountProjectId As Integer
    ''' <summary>
    ''' Set project value on row data bound of specified objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary>
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetProjectValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(0).FindControl("P"), DropDownList)
        dsObject = CType(Row.Cells(0).FindControl("dsAccountProjectsObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If (Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectId")) And Me.ViewState("IsCopyFromDate") = "False") Or (Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectId")) And Me.ViewState("IsCopyFromDate") = "True" And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False") Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectId")
                dsObject.SelectParameters("AccountProjectId").DefaultValue = dataValue
                objDropdown.SelectedValue = dataValue
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If
                MyCascading = CType(Row.Cells(1).FindControl("CP"), AjaxControlToolkit.CascadingDropDown)
                MyCascading.SelectedValue = dataValue
                MyCascading.Category = TimeEntryAccountEmployeeId & "," & dataValue & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountClientId") & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType()

            Else
                If Not Me.IsPostBack Then
                    If LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet And IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectId")) Then
                        Dim dtvueProjects As TimeLiveDataSet.vueAccountProjectsDataTable = New AccountProjectBLL().GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient(0, TimeEntryAccountEmployeeId, LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet)
                        Dim drvueProjects As TimeLiveDataSet.vueAccountProjectsRow
                        If dtvueProjects.Rows.Count > 0 Then
                            drvueProjects = dtvueProjects.Rows(0)
                            dsObject.SelectParameters("AccountProjectId").DefaultValue = drvueProjects.AccountProjectId
                            TemplateAccountProjectId = drvueProjects.AccountProjectId
                            objDropdown.SelectedValue = drvueProjects.AccountProjectId
                            MyCascading = CType(Row.Cells(1).FindControl("CP"), AjaxControlToolkit.CascadingDropDown)
                            MyCascading.SelectedValue = drvueProjects.AccountProjectId
                            MyCascading.Category = TimeEntryAccountEmployeeId & "," & drvueProjects.AccountProjectId & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountClientId") & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType()
                        End If
                    End If
                End If
            End If
            If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
                If LocaleUtilitiesBLL.IsShowProjectForTimeOff = False Then
                    objDropdown.Visible = False
                Else
                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Or Not IsDBNull(Me.G.DataKeys(Row.RowIndex)("AccountEmployeeTimeOffRequestId")) Then
                        UIUtilities.MakeDropdownReadonly(objDropdown)
                    End If

                End If
                CType(Row.Cells(1).FindControl("lblTimeTypes"), Label).Visible = True
                CType(Row.Cells(1).FindControl("lblTimeTypes"), Label).Text = ResourceHelper.GetFromResource("Time Off")
                CType(Row.Cells(1).FindControl("lblTimeTypes"), Label).Font.Bold = True
                MyCascading = CType(Row.Cells(1).FindControl("CP"), AjaxControlToolkit.CascadingDropDown)
                MyCascading.ContextKey = "isTimeOff"
            End If
            MyCascading = CType(Row.Cells(1).FindControl("CP"), AjaxControlToolkit.CascadingDropDown)

            If LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet Then
                MyCascading.PromptText = Nothing
                MyCascading.LoadingText = Nothing
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set task value on row data bound of specified objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary>
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetTaskValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(1).FindControl("PT"), DropDownList)
        dsObject = CType(Row.Cells(0).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)

        If Not objDropdown Is Nothing Then
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")) Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")
                dsObject.SelectParameters("AccountProjectTaskId").DefaultValue = dataValue
                objDropdown.DataBind()
                objDropdown.SelectedValue = dataValue
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If

                MyCascading = CType(Row.Cells(1).FindControl("CT"), AjaxControlToolkit.CascadingDropDown)
                MyCascading.SelectedValue = dataValue
                MyCascading.Category = TimeEntryAccountEmployeeId & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & dataValue & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountProjectId") & "," & DBUtilities.GetShowAdditionalTaskInformationType()
            End If
            If System.Configuration.ConfigurationManager.AppSettings("TimeSheetTaskSelected") = "Yes" Then
                UIUtilities.MakeDropdownReadonlyForTaskCascadian(objDropdown)
            End If
            If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
                objDropdown.Visible = False
                CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList).Attributes.Add("width", "100%")
                CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList).Visible = True
                If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId")) Then
                    dataValue = DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId").ToString
                    Dim category = "isRequired"
                    If IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                        category = "notRequired"
                    End If

                    CType(Row.Cells(1).FindControl("dsTimeOffTypesObject"), ObjectDataSource).SelectParameters("AccountTimeOffTypeId").DefaultValue = dataValue
                    CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList).DataBind()
                    CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList).SelectedValue = DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId").ToString

                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList))
                    End If

                    MyCascading = CType(Row.Cells(1).FindControl("TT"), AjaxControlToolkit.CascadingDropDown)
                    MyCascading.SelectedValue = dataValue
                    MyCascading.Category = category
                    If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList))
                    End If
                End If
            End If
            If LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet Then
                MyCascading.PromptText = Nothing
                MyCascading.LoadingText = Nothing
            End If
            If Not Me.IsPostBack Then
                If LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet And IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")) Then
                    If Me.GetCellValue(Row, 1, "PT") = "" Then
                        Dim dtvueProjectTask As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable = New AccountProjectTaskBLL().GetAssignedProjectTasksFromvueAccountProjectTask(IIf(IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectId")), TemplateAccountProjectId, DataBinder.Eval(Row.DataItem, "AccountProjectId")), TimeEntryAccountEmployeeId, 0, DBUtilities.GetSessionAccountId, LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet)
                        Dim drvueProjectTask As TimeLiveDataSet.AccountProjectTaskTimesheetRow
                        If dtvueProjectTask.Rows.Count > 0 Then
                            drvueProjectTask = dtvueProjectTask.Rows(0)
                            dsObject.SelectParameters("AccountProjectTaskId").DefaultValue = drvueProjectTask.AccountProjectTaskId
                            objDropdown.DataBind()
                            objDropdown.SelectedValue = drvueProjectTask.AccountProjectTaskId


                            MyCascading = CType(Row.Cells(1).FindControl("CT"), AjaxControlToolkit.CascadingDropDown)

                            MyCascading.SelectedValue = drvueProjectTask.AccountProjectTaskId
                            MyCascading.Category = TimeEntryAccountEmployeeId & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & drvueProjectTask.AccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountProjectId") & "," & DBUtilities.GetShowAdditionalTaskInformationType()
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' Set cost center value on row data bound of specified, objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary>
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetCostCenterValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(2).FindControl("CC"), DropDownList)
        dsObject = CType(Row.Cells(2).FindControl("dsAccountCostCenterObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
                objDropdown.Visible = False
            Else
                dataValue = DataBinder.Eval(Row.DataItem, "AccountCostCenterId")
                If Not IsDBNull(dataValue) Then
                    dsObject.SelectParameters("AccountCostCenterId").DefaultValue = dataValue
                    objDropdown.DataBind()
                    objDropdown.SelectedValue = dataValue
                Else
                    objDropdown.SelectedValue = objDropdown.Items(0).Value
                End If
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If
            End If
        End If
    End Sub
    ''' <summary> 
    ''' Set work type value on row data bound of specified objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary> 
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetWorkTypeValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(3).FindControl("W"), DropDownList)
        dsObject = CType(Row.Cells(3).FindControl("dsAccountWorkTypeObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
                objDropdown.Visible = False
            Else
                dataValue = DataBinder.Eval(Row.DataItem, "AccountWorkTypeId")
                If Not IsDBNull(dataValue) Then
                    dsObject.SelectParameters("AccountWorkTypeId").DefaultValue = dataValue
                    objDropdown.SelectedValue = dataValue
                    objDropdown.DataBind()
                End If
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set time and description values on row data bound of specified Row, IsApprovedTime, objTextBox, TotalTime
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="SubmittedTime"></param>
    ''' <param name="IsApprovedTime"></param>
    ''' <param name="objTextBox"></param>
    ''' <param name="TotalTime"></param>
    ''' <remarks></remarks>
    Public Sub SetTimeAndDescriptionValuesOnRowDataBound(ByVal Row As GridViewRow, ByVal SubmittedTime As Boolean, ByVal IsApprovedTime As Boolean, ByVal objTextBox As TextBox, ByVal TotalTime() As Integer, ByVal Percentage() As Integer, TotalHours() As Decimal)
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            If Me.Request.QueryString("IsCopyActivities") Is Nothing Then
                SubmittedTime = IIf(IsDBNull(DataBinder.Eval(Row.DataItem, "Submitted" & dayNo)), False, DataBinder.Eval(Row.DataItem, "Submitted" & dayNo))
                IsApprovedTime = IIf(IsDBNull(DataBinder.Eval(Row.DataItem, "IsApproved" & dayNo)), False, DataBinder.Eval(Row.DataItem, "IsApproved" & dayNo))

                If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId" & dayNo)) And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" And Me.ViewState("IsCopyFromDate") = "False" Then
                    CType(Row.Cells(5 + dayNo).FindControl("AT" & dayNo), HyperLink).Visible = True
                    CType(Row.Cells(5 + dayNo).FindControl("AT" & dayNo), HyperLink).NavigateUrl = "~/Employee/TimeOffAttachments.aspx?ReadOnly=false&TimeEntry=" & DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId" & dayNo)
                    Dim BLL = New TimeOffAttachmentsBLL
                    Dim count = BLL.CountAttachmentsByTimeEntryId(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId" & dayNo))
                    If count <> 0 Then
                        CType(Row.Cells(5 + dayNo).FindControl("In" & dayNo), Label).Visible = True
                        CType(Row.Cells(5 + dayNo).FindControl("In" & dayNo), Label).ToolTip = "This entry has " & count & " attachments"
                        CType(Row.Cells(5 + dayNo).FindControl("AT" & dayNo), HyperLink).Attributes.Add("style", "margin-left: -10px !important;")
                        CType(Row.Cells(5 + dayNo).FindControl("AT" & dayNo), HyperLink).Text = "Attach..."

                    End If
                End If

                If (Not IsDBNull(DataBinder.Eval(Row.DataItem, "TotalTime" & dayNo)) And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False) Or (Not IsDBNull(DataBinder.Eval(Row.DataItem, "TotalTime" & dayNo)) And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat <> "None") Then
                    If Me.ViewState("IsCopyFromDate") = "False" Then
                        ShowTimeEntryStatus(Row, dayNo)
                    End If
                    Me.AddSubmittedDayNoInHashTable(Row, dayNo)
                    If DBUtilities.GetClockStartEndBy = "Account" Then
                        If DBUtilities.GetShowClockStartEnd = True And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False" And DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                            objTextBox = CType(Row.Cells(5 + dayNo).FindControl("S" & dayNo), TextBox)
                            If DBUtilities.IsNotSupportedCultureFormats <> True Then
                                objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo))
                            Else
                                If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                                    If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo)) <> "" Then
                                        objTextBox.Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo))
                                    End If
                                Else
                                    objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo))
                                End If
                            End If
                            If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                                UIUtilities.MakeTextboxReadonly(objTextBox)
                            End If
                            objTextBox = CType(Row.Cells(5 + dayNo).FindControl("E" & dayNo), TextBox)
                            If DBUtilities.IsNotSupportedCultureFormats <> True Then
                                objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo))
                            Else
                                If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                                    If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo)) <> "" Then
                                        objTextBox.Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo))
                                    End If
                                Else
                                    objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo))
                                End If
                            End If
                            If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                                UIUtilities.MakeTextboxReadonly(objTextBox)
                            End If
                        End If
                    ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
                        If DBUtilities.ShowClockStartEndEmployee = True And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False" And DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                            objTextBox = CType(Row.Cells(5 + dayNo).FindControl("S" & dayNo), TextBox)
                            If DBUtilities.IsNotSupportedCultureFormats <> True Then
                                objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo))
                            Else
                                If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                                    If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo)) <> "" Then
                                        objTextBox.Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo))
                                    End If
                                Else
                                    objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime" & dayNo))
                                End If
                            End If
                            If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                                UIUtilities.MakeTextboxReadonly(objTextBox)
                            End If
                            objTextBox = CType(Row.Cells(5 + dayNo).FindControl("E" & dayNo), TextBox)

                            If DBUtilities.IsNotSupportedCultureFormats <> True Then
                                objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo))
                            Else
                                If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                                    If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo)) <> "" Then
                                        objTextBox.Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo))
                                    End If
                                Else
                                    objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime" & dayNo))
                                End If
                            End If
                            If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                                UIUtilities.MakeTextboxReadonly(objTextBox)
                            End If
                        End If
                    End If
                    objTextBox = CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox)

                    If Me.ViewState("IsCopyFromDate") = "False" Or ((DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False")) Then
                        If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                            objTextBox.Text = Format(DataBinder.Eval(Row.DataItem, "Hours" & dayNo), "#0.00")
                            TotalHours(0 + dayNo) = TotalHours(0 + dayNo) + DataBinder.Eval(Row.DataItem, "Hours" & dayNo)
                        Else
                            If DBUtilities.IsNotSupportedCultureFormats = True Then
                                objTextBox.Text = DBUtilities.GetDateTimeOfMinutesAsString(DBUtilities.GetMinutesOfTime(CType(DataBinder.Eval(Row.DataItem, "TotalTime" & dayNo), Date)))
                            Else
                                objTextBox.Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(DataBinder.Eval(Row.DataItem, "TotalTime" & dayNo))
                            End If
                            TotalTime(0 + dayNo) = TotalTime(0 + dayNo) + DBUtilities.GetMinutesOfTime(CType(DataBinder.Eval(Row.DataItem, "TotalTime" & dayNo), Date))
                        End If

                        If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                            UIUtilities.MakeTextboxReadonly(objTextBox)
                        End If
                    End If
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                CType(Row.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).ReadOnly = True
            End If
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "Percentage" & dayNo)) And LocaleUtilitiesBLL.ShowPercentageInTimesheet() And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False" Then
                CType(Row.Cells(5 + dayNo).FindControl("PC" & dayNo), TextBox).Text = DataBinder.Eval(Row.DataItem, "Percentage" & dayNo)
                Percentage(0 + dayNo) = Percentage(0 + dayNo) + DataBinder.Eval(Row.DataItem, "Percentage" & dayNo)
                ShowTimeEntryStatus(Row, dayNo)
            End If
            If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender = True And DBUtilities.GetShowDescriptionInWeekView Then
                objTextBox = CType(Row.Cells(5 + dayNo).FindControl("DS" & dayNo & Row.RowIndex), TextBox)
                If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Or Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                    UIUtilities.MakeTextboxReadonly(objTextBox)
                End If
                If Not Me.Request.QueryString("IsCopyActivities") Is Nothing Then
                    objTextBox.Text = ""
                End If
            End If
            If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender = True Then
                For n As Integer = 1 To 9
                    If AccountEmployeeTimeEntryBLL.DoUnlockBydayNo(Row, dayNo) = False And Me.ViewState("IsCopyFromDate") = "False" Or Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                        DisableCustomFields(Row.Cells(5 + dayNo).FindControl("CustomField" & n & dayNo & Row.RowIndex))
                    End If
                Next
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set sum time value on row data bound of specified Row, TotalTime, TotalGridTime
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="TotalTime"></param>
    ''' <param name="TotalGridTime"></param>
    ''' <remarks></remarks>
    Public Sub SetSumTimeValueOnRowDataBound(ByVal Row As GridViewRow, ByVal TotalTime() As Integer, ByVal TotalGridTime As Decimal, ByVal Percentage() As Integer, TotalHours() As Decimal)
        Dim objrow As GridViewRow
        If Me.Request.QueryString("IsCopyActivities") Is Nothing Then
            For Each objrow In Me.G.Rows
                If (Me.ViewState("IsCopyFromDate") = "False" Or Me.G.DataKeys(objrow.RowIndex).Item("IsTimeOff").ToString = "False") Then
                    For dayNo As Integer = 0 To WorkingDaysCount - 1
                        If (Not IsDBNull(Me.G.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo)) And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False) Or (Not IsDBNull(Me.G.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo)) And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat <> "None") Then
                            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                                TotalHours(0 + dayNo) = TotalHours(0 + dayNo) + Me.G.DataKeys(objrow.RowIndex).Item("Hours" & dayNo)
                                'TotalTime(0 + dayNo) = TotalTime(0 + dayNo) + Me.G.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo)
                                CType(Row.Cells(5 + dayNo).FindControl("st" & dayNo), TextBox).Text = Format(TotalHours(dayNo), "#0.00")
                            Else
                                TotalTime(0 + dayNo) = TotalTime(0 + dayNo) + DBUtilities.GetMinutesOfTime(CType(Me.G.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo), Date))
                                CType(Row.Cells(5 + dayNo).FindControl("st" & dayNo), TextBox).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime(dayNo))
                            End If
                        End If
                        If Not IsDBNull(Me.G.DataKeys(objrow.RowIndex).Item("Percentage" & dayNo)) And LocaleUtilitiesBLL.ShowPercentageInTimesheet() Then
                            Percentage(0 + dayNo) = Percentage(0 + dayNo) + Me.G.DataKeys(objrow.RowIndex).Item("Percentage" & dayNo)
                            CType(Row.Cells(5 + dayNo).FindControl("spc" & dayNo), TextBox).Text = Percentage(dayNo) & "%"
                        End If
                        If LocaleUtilitiesBLL.ShowPercentageInTimesheet() And DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet() = False Then
                            CType(Row.Cells(5 + dayNo).FindControl("st" & dayNo), TextBox).Visible = False
                        End If
                    Next
                End If
            Next
        End If
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                TotalGridTime += TotalHours(0 + dayNo)
                txtTimesheetTotal.Text = Format(TotalGridTime, "#0.00")
            Else
                TotalGridTime += TotalTime(0 + dayNo)
                txtTimesheetTotal.Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalGridTime)
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set row data bound in period view data row of specified objDropdown, objDropdown, dsObject, dataValue, MyCascading, Row, SubmittedTime, IsApprovedTime, TotalTime
    ''' </summary>
    ''' <param name="objDropdown"></param>
    ''' <param name="objTextBox"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <param name="SubmittedTime"></param>
    ''' <param name="IsApprovedTime"></param>
    ''' <param name="TotalTime"></param>
    ''' <remarks></remarks>
    Public Sub SetRowDataBoundInPeriodViewDataRow(ByVal objDropdown As DropDownList, ByVal objTextBox As TextBox, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow, ByVal SubmittedTime As Boolean, ByVal IsApprovedTime As Boolean, ByVal TotalTime() As Integer, ByVal Percentage() As Integer, ByVal TotalHours() As Decimal)
        If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" And IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
            Me.btnCopy.Enabled = False
            Me.btnCopyActivities.Enabled = False
        End If
        Me.SetAjaxExtenderInRow(Row)
        Me.SetClientValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetProjectValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetTaskValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetTimeAndDescriptionValuesOnRowDataBound(Row, SubmittedTime, IsApprovedTime, objTextBox, TotalTime, Percentage, TotalHours)
        Me.SetCostCenterValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetWorkTypeValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
    End Sub
    ''' <summary>
    ''' Set row data bound in period view footer row of specified Row, TotalTime, TotalGridTime
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="TotalTime"></param>
    ''' <param name="TotalGridTime"></param>
    ''' <remarks></remarks>
    Public Sub SetRowDataBoundInPeriodViewFooterRow(ByVal Row As GridViewRow, ByVal TotalTime() As Integer, ByVal TotalGridTime As Decimal, ByVal Percentage() As Integer, TotalHours() As Decimal)
        Me.SetSumTimeValueOnRowDataBound(Row, TotalTime, TotalGridTime, Percentage, TotalHours)
    End Sub
    ''' <summary>
    ''' Set grid column span for time off
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGridColumnSpanForTimeOff()
        If WorkingDaysCount <> 0 Then
            For rowIndex As Integer = 0 To G.Rows.Count - 1
                Dim gvRow As GridViewRow = G.Rows(rowIndex)
                If Me.G.DataKeys(gvRow.RowIndex)("IsTimeOff").ToString = "True" Then
                    For cellCount As Integer = 0 To gvRow.Cells.Count - 1
                        If DBUtilities.GetShowClientInTimesheet = True And cellCount = 0 Then
                            'gvRow.Cells(cellCount).ColumnSpan = 2
                            ' gvRow.Cells(cellCount).FindControl("lblTimeTypesClient").Visible = True
                            'gvRow.Cells(cellCount + 1).Visible = False
                            'Dim TimeOffLabel As New Label
                            'TimeOffLabel.Text = "Time Off"
                            'TimeOffLabel.Font.Bold = True
                            'gvRow.Cells(cellCount).HorizontalAlign = HorizontalAlign.Left
                            'gvRow.Cells(cellCount).VerticalAlign = VerticalAlign.Top
                            'gvRow.Cells(cellCount).Controls.Add(TimeOffLabel)
                        End If
                        If cellCount = 1 Then
                            gvRow.Cells(cellCount).HorizontalAlign = HorizontalAlign.Left
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And G.Columns.Item(cellCount).HeaderText = "Task" Then
                            gvRow.Cells(cellCount).ColumnSpan = 2
                            gvRow.Cells(cellCount + 1).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And G.Columns.Item(cellCount).HeaderText = "Task" Then
                            gvRow.Cells(cellCount).ColumnSpan = 2
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And G.Columns.Item(cellCount).HeaderText = "Task" Then
                            gvRow.Cells(cellCount).ColumnSpan = 3
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' Set project width for time off 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetProjectWidthForTimeOff()
        Dim browser As System.Web.HttpBrowserCapabilities = System.Web.HttpContext.Current.Request.Browser
        If WorkingDaysCount <> 0 Then
            For Each objrow As GridViewRow In Me.G.Rows
                If objrow.RowType = DataControlRowType.DataRow Then
                    If Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then
                        CType(objrow.Cells(0).FindControl("P"), DropDownList).Width = Unit.Percentage(85)
                    ElseIf Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                        CType(objrow.Cells(0).FindControl("P"), DropDownList).Width = Unit.Pixel(400)
                    End If
                    If DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False Then
                        If Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" And Not IsCurrentPeriodTypeForDefaultUI() Then
                            CType(objrow.Cells(1).FindControl("PT"), DropDownList).Width = Unit.Percentage(100)
                            CType(objrow.Cells(0).FindControl("P"), DropDownList).Width = Unit.Percentage(100)
                        ElseIf Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then
                            CType(objrow.Cells(1).FindControl("ddlTimeOffTypeId"), DropDownList).Width = Unit.Percentage(100)
                        End If
                    ElseIf (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False) _
                        Or (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True) Then
                        If Me.G.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" And TimesheetPeriodType = "Daily" Then
                            CType(objrow.Cells(1).FindControl("PT"), DropDownList).Width = Unit.Percentage(100)
                            CType(objrow.Cells(0).FindControl("P"), DropDownList).Width = Unit.Percentage(100)
                            If DBUtilities.IsShowCostCenterInTimeSheet Then
                                CType(objrow.Cells(2).FindControl("CC"), DropDownList).Width = Unit.Percentage(100)
                            End If
                            If DBUtilities.IsShowWorkTypeInTimeSheet Then
                                CType(objrow.Cells(2).FindControl("W"), DropDownList).Width = Unit.Percentage(100)
                            End If
                        End If
                    End If
                    'If Not System.Configuration.ConfigurationManager.AppSettings("TS_RESIZE") Is Nothing Then
                    If LocaleUtilitiesBLL.EnableAutoResizeTimesheet Then
                        CType(objrow.Cells(0).FindControl("C"), DropDownList).Width = Unit.Percentage(100)
                        CType(objrow.Cells(2).FindControl("PT"), DropDownList).Width = Unit.Percentage(100)
                        CType(objrow.Cells(1).FindControl("P"), DropDownList).Width = Unit.Percentage(100)
                        CType(objrow.Cells(1).FindControl("lblTimeTypes"), Label).Width = Unit.Percentage(30)
                        If DBUtilities.IsShowCostCenterInTimeSheet Then
                            CType(objrow.Cells(2).FindControl("CC"), DropDownList).Width = Unit.Percentage(100)
                        End If
                        If DBUtilities.IsShowWorkTypeInTimeSheet Then
                            CType(objrow.Cells(2).FindControl("W"), DropDownList).Width = Unit.Percentage(100)
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Public Function IsCurrentPeriodTypeForDefaultUI() As Boolean
        If TimesheetPeriodType = "Monthly" Or TimesheetPeriodType = "BiWeekly" Or TimesheetPeriodType = "Semi-Monthly" Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Employee selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployee.SelectedIndexChanged
        Me.RefreshWeekView(True)

    End Sub
    ''' <summary>
    ''' Button audit click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAudit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAudit.Click
        Response.Redirect("AccountEmployeeTimeEntryAudit.aspx?AccountEmployeeTimeEntryPeriodId=" & dtAccountEmployeeTimeEntryPeriodId.ToString, False)
    End Sub
    ''' <summary>
    ''' Button my periods click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnMyPeriods_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMyPeriods.Click
        Response.Redirect("~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=PeriodView", False)
    End Sub
    ''' <summary>
    ''' Button day view click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDayView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDayView.Click
        Response.Redirect("~/Employee/AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
    End Sub
    ''' <summary>
    ''' Check holiday icon of specified Holidaydate, dayNo
    ''' </summary>
    ''' <param name="Holidaydate"></param>
    ''' <param name="dayNo"></param>
    ''' <remarks></remarks>
    Public Function CheckHolidayIcon(ByVal Holidaydate As Date, ByVal dayNo As Integer) As Boolean
        Dim HolidayBLL As New AccountHolidayTypeBLL
        Dim HolidayTypeId As Guid
        Dim dtHolidayEmployee As AccountHolidayType.vueAccountHolidayEmployeeDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeesByAccountEmployeeId(Me.ddlEmployee.SelectedValue)
        Dim drHolidayEmployee As AccountHolidayType.vueAccountHolidayEmployeeRow
        If dtHolidayEmployee.Rows.Count > 0 Then
            drHolidayEmployee = dtHolidayEmployee.Rows(0)
            HolidayTypeId = drHolidayEmployee.AccountHolidayTypeId
        End If
        Dim HolidayDataTable As DataTable = HolidayBLL.GetvueAccountHolidayTypeDetailByAccountIdandHolidayDate(Holidaydate, HolidayTypeId)
        If HolidayDataTable.Rows.Count > 0 Then
            'Me.G.HeaderRow.FindControl("imgH" & dayNo).Visible = True
            Return True
        End If
    End Function
    Protected Sub btnTimerTimesheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimerTimesheet.Click
        ShowTimerTimesheet()
    End Sub

    Public Sub ShowTimerTimesheet()
        Dim URL As String = "TimerControl.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&TimesheetPeriodType=" & TimesheetPeriodType
        btnTimerTimesheet.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=540,height=365,left=400,top=290,scrollbars=yes'); return false;")
    End Sub
    Protected Sub btnImportOfflineTimesheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportOfflineTimesheet.Click
        ShowOfflineTimesheet()
    End Sub
    Public Function GetWhereClause() As String
        Dim sql As String = ""
        sql = sql & "(TimeEntryDate >= " & LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQurey(dtStartDate) & ") AND (TimeEntryDate <= " & LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQurey(dtEndDate) & ") "

        sql = sql + " And AccountEmployeeId = " & TimeEntryAccountEmployeeId

        sql = sql & " And AccountId = " & DBUtilities.GetSessionAccountId
        Return sql
    End Function
    Public Sub ShowOfflineTimesheet()
        Dim URL As String = "OfflineTimesheet.aspx?Mode=PeriodView&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtStartDate) & "&EndDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtEndDate) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId
        btnImportOfflineTimesheet.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=535,height=200,left=280,top=280,scrollbars=yes'); return false;")
    End Sub
    Public Sub ExportOfflineTimesheet()
        Dim URL As String = "ExportOfflineTimesheet.aspx?TimeEntryAccountEmployeeId=" & TimeEntryAccountEmployeeId & "&WhereClause=" & Me.GetWhereClause
        btnExportOfflineTimesheet.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=535,height=200,left=280,top=280,scrollbars=yes'); return false;")

    End Sub
    Public Sub DisableAllPreviousTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)
        If TimesheetPeriodDaysArray.Count > 0 Then
            Dim dtdate As Date = TimesheetPeriodDaysArray(0)
            If dtCurrentDate < dtdate Then
                For Each objRow In Me.G.Rows
                    Me.DisableTimeEntryInWeekRows(objRow)
                    Me.LockTimesheetButtons()
                Next
            End If
        End If
    End Sub
    Public Sub DisableAllFutureTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then

            Dim dtEndDate As Date = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
            'dtEndDate = dtEndDate.AddDays(+1)
            'Dim TimeEntryDate As New Date(txtTimeEntryDate.SelectedDate.Year, txtTimeEntryDate.SelectedDate.Month, txtTimeEntryDate.SelectedDate.Day)

            If dtCurrentDate > dtEndDate Then
                For Each objRow In Me.G.Rows
                    Me.DisableTimeEntryInWeekRows(objRow)
                    Me.LockTimesheetButtons()
                Next
            End If
        End If
    End Sub
    Public Sub DisablePreviousPeriodsTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then

            Dim dtdate As Date = TimesheetPeriodDaysArray(0)
            dtdate = dtdate.AddDays(-1)
            For n As Integer = 1 To DBUtilities.GetLockPreviousTimesheetPeriods()

                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtdate, dtdate, dtdate)
                If TimesheetPeriodDaysArray.Contains(dtCurrentDate) Then

                    For Each objRow In Me.G.Rows
                        Me.DisableTimeEntryInWeekRows(objRow)
                        Me.LockTimesheetButtons()
                    Next
                End If

                dtdate = TimesheetPeriodDaysArray(0)
                dtdate = dtdate.AddDays(-1)
            Next
        End If
    End Sub
    Public Sub DisablePreviousNextMonthTimeEntryOfWeek(ByVal No As Integer)
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        Dim EndDate As Date
        Dim StartDate As Date
        Dim CheckDate As Date
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()
        If No > LockDate Then
            No = LockDate
        End If
        CheckDate = New Date(Now.Year, Now.Month, No)
        StartDate = New Date(Now.Year, Now.Month, 1)
        EndDate = New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))
        'Else
        'StartDate = New Date(Now.Year, Now.Month - 1, No)
        'EndDate = New Date(Now.Year, Now.Month, No)

        If CheckDate <= Now.Date Then
            Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, StartDate, EndDate)
            If TimesheetPeriodDaysArray.Count > 0 Then
                'Dim dtdate As Date = TimesheetPeriodDaysArray(0)
                'dtdate = dtdate.AddDays(-1)
                Dim CurrentPeriodTimesheetPeriodDaysArray As ArrayList
                CurrentPeriodTimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtCurrentDate, Now.Date, Now.Date)
                Dim Array As Integer = 0
                Dim Count = CurrentPeriodTimesheetPeriodDaysArray.Count
                For n As Integer = 1 To Count
                    If Not TimesheetPeriodDaysArray.Contains(CurrentPeriodTimesheetPeriodDaysArray(Array)) Then
                        'For dayNo As Integer = 0 To WorkingDaysCount - 1
                        Dim WorkingDayArray As ArrayList = WorkingDays
                        If Array <= WorkingDays.ToArray.Length - 1 Then
                            DisableTimeEntryOfDays(Array)
                        End If
                        'Next
                    End If
                    Count = Count - 1
                    Array = Array + 1
                    'dtdate = TimesheetPeriodDaysArray(0)
                    'dtdate = dtdate.AddDays(-1)
                Next
            End If
        End If
    End Sub
    Public Sub DisableTimeEntryInDayRows(ByVal objRow As GridViewRow, ByVal DayNo As Integer)
        If objRow.Cells(2).Controls.Count > 0 Then
            'For dayNo As Integer = 0 To WorkingDaysCount - 1
            Me.DisableWeekTimeEntriesWithoutDropdown(DayNo, objRow)
            'Next
        End If
    End Sub
    ''' <summary>
    ''' Disable time entry of week
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisableTimeEntryOfDays(ByVal DayNo As Integer)
        Dim objRow As GridViewRow
        For Each objRow In Me.G.Rows
            Me.DisableTimeEntryInDayRows(objRow, DayNo)
        Next
    End Sub
    Public Sub LockTimesheetButtons()
        Me.btnSubmit.Enabled = False
        Me.btnTopSubmit.Enabled = False
        Me.WeekButton1.Enabled = False
        Me.btnTopSave.Enabled = False
        Me.btnCopy.Enabled = False
        Me.btnCopyActivities.Enabled = False
        Me.btnCopyFromTemplate.Enabled = False
        Me.txtPeriodDescription.ReadOnly = True
        Me.btnTimerTimesheet.Enabled = False
    End Sub
    Public Sub DisableNextPeriodsTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then

            Dim dtEndDate As Date = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
            dtEndDate = dtEndDate.AddDays(+1)
            For n As Integer = 1 To DBUtilities.GetLockNextTimsheetPeriods()

                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtEndDate, dtEndDate, dtEndDate)
                If TimesheetPeriodDaysArray.Contains(dtCurrentDate) Then
                    For Each objRow In Me.G.Rows
                        Me.DisableTimeEntryInWeekRows(objRow)
                        Me.LockTimesheetButtons()
                    Next
                End If
                dtEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
                dtEndDate = dtEndDate.AddDays(+1)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Disable week time entries of specified dayno, Row
    ''' </summary>
    ''' <param name="dayno"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub DisableWeekTimeEntriesWithoutDropdown(ByVal dayno As Integer, ByVal Row As GridViewRow)
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = True Then
                If Not CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox) Is Nothing Then
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox))
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("E" & dayno), TextBox))
                End If
            End If
        ElseIf DBUtilities.GetClockStartEndBy = "Employee" Then
            If DBUtilities.ShowClockStartEndEmployee = True Then
                If Not CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox) Is Nothing Then
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("S" & dayno), TextBox))
                    UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("E" & dayno), TextBox))
                End If
            End If
        End If
        If Not CType(Row.Cells(5 + dayno).FindControl("TT" & dayno), TextBox) Is Nothing Then
            UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("TT" & dayno), TextBox))
        End If
        If Not CType(Row.Cells(5 + dayno).FindControl("PC" & dayno), TextBox) Is Nothing Then
            UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("PC" & dayno), TextBox))
        End If
        If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender = True And DBUtilities.GetShowDescriptionInWeekView Then
            If Not CType(Row.Cells(5 + dayno).FindControl("DS" & dayno & Row.RowIndex), TextBox) Is Nothing Then
                UIUtilities.MakeTextboxReadonly(CType(Row.Cells(5 + dayno).FindControl("DS" & dayno & Row.RowIndex), TextBox))
            End If
        End If
        If BrowserUtilitiesBLL.IsCompatibleBrowserForPopupExtender = True Then
            For n As Integer = 1 To 9
                DisableCustomFields(Row.Cells(5 + dayno).FindControl("CustomField" & n & dayno & Row.RowIndex))
            Next
        End If
    End Sub
    Public Sub UnlockPreviousPeriodsTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        'Dim CurrentPeriodTimesheetPeriodDaysArray As ArrayList
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()

        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)
        'CurrentPeriodTimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtCurrentDate, Now.Date, Now.Date)
        If TimesheetPeriodDaysArray.Count > 0 Then
            Dim Array As New ArrayList
            Dim dtdate As Date = TimesheetPeriodDaysArray(0)
            dtdate = dtdate.AddDays(-1)
            For n As Integer = 1 To DBUtilities.GetLockAllPeriodExceptPrevious()

                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtdate, dtdate, dtdate)

                dtdate = TimesheetPeriodDaysArray(0)
                dtdate = dtdate.AddDays(-1)
            Next
            If dtdate >= dtCurrentDate Then
                For Each objRow In Me.G.Rows
                    Me.DisableTimeEntryInWeekRows(objRow)
                    Me.LockTimesheetButtons()
                Next
            End If
        End If
    End Sub
    Public Sub UnlockNextPeriodsTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = GetCurrentDateForIsLockFeature()
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then

            Dim dtEndDate As Date = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
            dtEndDate = dtEndDate.AddDays(+1)
            For n As Integer = 1 To DBUtilities.GetLockAllPeriodExceptNext

                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtEndDate, dtEndDate, dtEndDate)

                dtEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
                dtEndDate = dtEndDate.AddDays(+1)
            Next
            If dtEndDate <= dtCurrentDate Then
                For Each objRow In Me.G.Rows
                    Me.DisableTimeEntryInWeekRows(objRow)
                    Me.LockTimesheetButtons()
                Next
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get current date 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentDateForIsLockFeature() As Date
        If Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = False Then
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        ElseIf Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Return LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        ElseIf Not Me.Request.QueryString("StartDate") Is Nothing And Me.IsPostBack = True Then
            Return LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        End If
    End Function

    Protected Sub btnCopyFromTemplate_Click(sender As Object, e As System.EventArgs) Handles btnCopyFromTemplate.Click
        Dim URL As String = "AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&IsFromTemplate=True&IsCopyActivities=True" & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId
        Response.Redirect(URL, False)
    End Sub
    Public Sub MsgBoxTagged(ByVal AccountEmployeeId As Integer)
        Dim EmployeeBLL As New AccountEmployeeBLL
        If System.Configuration.ConfigurationManager.AppSettings("Timesheet_Popup") = "Yes" Then
            If EmployeeBLL.IsLocationExist(AccountEmployeeId) Then
                'If Not Me.IsPostBack Then
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "Windows", "myAlert();", True)
                Me.ASPNET_MsgBoxTagged("Timesheet submission in TimeLive solely serves the purpose of resources planning & utilization. This does not serve the purpose of Overtime Claims. For claiming Overtime, please follow separate HR policy on related topic.", Me.Page)
                'End If
            End If
        End If
    End Sub
    Public Sub ASPNET_MsgBoxTagged(ByVal Message As String, ByVal callingPage As Page)
        ScriptManager.RegisterStartupScript(callingPage, callingPage.GetType, "Msgbox", "alert('" + Message + "');", True)
        ''ScriptManager.RegisterStartupScript(callingPage, callingPage.GetType,"popup","alert('Thank you for visiting the MedInfo website. Your request has been submitted.');",true);Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnAttachment_Click(sender As Object, e As System.EventArgs) Handles btnAttachment.Click
        Me.ShowAttachment()
    End Sub
    Public Sub ShowAttachment()
        Dim URL As String = ConfigurationManager.AppSettings.Get("SitePrefix") & "AccountAdmin/AccountAttachmentsPopUp.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtStartDate) & "&EndDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(dtEndDate) & "&TimesheetPeriodType=" & TimesheetPeriodType & "&AccountEmployeeTimeEntryPeriodId=" & dtAccountEmployeeTimeEntryPeriodId.ToString & "&AccountAttachmentTypeId=2"
        btnAttachment.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=720,height=500,left=400,top=190,scrollbars=yes'); return false;")
    End Sub
    Public Function GetHolidaysCount(ByVal TimeEntryStartdate As Date, ByVal TimeEntryEnddate As Date) As Double
        Dim HolidayBLL As New AccountHolidayTypeBLL
        Dim HolidayTypeId As Guid
        Dim dtHolidayEmployee As AccountHolidayType.vueAccountHolidayEmployeeDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeesByAccountEmployeeId(Me.ddlEmployee.SelectedValue)
        Dim drHolidayEmployee As AccountHolidayType.vueAccountHolidayEmployeeRow
        If dtHolidayEmployee.Rows.Count > 0 Then
            drHolidayEmployee = dtHolidayEmployee.Rows(0)
            HolidayTypeId = drHolidayEmployee.AccountHolidayTypeId

            Dim dtHolidaydetail As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable = HolidayBLL.GetvueAccountEmployeeHolidayTypewithDetailByAccountIdAndAccountHolidayTypeIdForTimeEntry(DBUtilities.GetSessionAccountId, ddlEmployee.SelectedValue, TimeEntryStartdate, TimeEntryEnddate, drHolidayEmployee.AccountHolidayTypeId)
            Return dtHolidaydetail.Rows.Count
        End If
        Return 0
    End Function
    Public Function ValidateEstimatedHours() As Boolean
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim objrow As GridViewRow
        Dim Totalhours As Double
        Dim EstimatedHours As Double
        Dim tempvalue As Double
        Dim totaltime As Double
        Dim TaskIdHashtable As New Hashtable
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            For Each objrow In Me.G.Rows
                If CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue <> "" Then
                    If CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text <> "" Then
                        If TaskIdHashtable.ContainsKey(CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue) Then
                            tempvalue = TaskIdHashtable.Item(CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue)
                            TaskIdHashtable.Remove(CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue)
                            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                                totaltime = Convert.ToDouble(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) + Convert.ToDouble(tempvalue)
                            Else
                                totaltime = Convert.ToDouble(DBUtilities.GetMinutesOfTime(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) / 60) + Convert.ToDouble(tempvalue)
                            End If
                            TaskIdHashtable.Add(CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue, totaltime)
                        Else
                            TaskIdHashtable.Add(CType(objrow.Cells(1).FindControl("PT"), DropDownList).SelectedValue, Convert.ToDouble(DBUtilities.GetMinutesOfTime(CType(objrow.Cells(5 + dayNo).FindControl("TT" & dayNo), TextBox).Text) / 60))
                        End If
                    End If
                End If
            Next
        Next

        For i As Integer = 0 To TaskIdHashtable.Count - 1
            Dim dttimeentry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEstimatedHoursDataTable = TimeEntryBLL.GetEstimatedHoursByAccountProjectTaskId(TaskIdHashtable.Keys(i), dtAccountEmployeeTimeEntryPeriodId)
            Dim drtimeentry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForEstimatedHoursRow
            If dttimeentry.Rows.Count > 0 Then
                drtimeentry = dttimeentry.Rows(0)
                If Not IsDBNull(drtimeentry.Item("EstimatedTimeSpent")) And Not IsDBNull(drtimeentry.Item("TotalHours")) Then
                    EstimatedHours = drtimeentry.EstimatedTimeSpent
                    Totalhours = drtimeentry.TotalHours
                    Dim thours = Totalhours + TaskIdHashtable.Item(TaskIdHashtable.Keys(i))
                    If Math.Round(EstimatedHours, 2) < Math.Round(thours, 2) Then
                        Me.ShowNotFoundMessage("You may not enter more than " & Math.Round(EstimatedHours, 2) & " hours in " & drtimeentry.TaskName)
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function
End Class