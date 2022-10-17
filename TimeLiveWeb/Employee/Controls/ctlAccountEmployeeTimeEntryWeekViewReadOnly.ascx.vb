
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryWeekViewReadOnly
    Inherits System.Web.UI.UserControl
    Dim dtStartDate As DateTime = #11/1/2006#
    Dim dtEndDate As DateTime = #11/7/2006#
    Dim dtAccountEmployeeId As Integer
    Dim dtTimesheetPeriodType As String
    Dim WorkingDays As ArrayList
    Dim WorkingDaysCount As Integer
    Dim EmployeeName As String
    Dim TimesheetPrintFooter As String

    Protected Sub WG_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles WG.RowDataBound
        Dim TotalTime(WorkingDaysCount) As Integer
        Dim TotalHours(WorkingDaysCount) As Decimal
        Dim TotalPercentage(WorkingDaysCount) As Integer
        Dim TotalGridTime As Integer
        Dim TotalGridHours As Decimal
        If e.Row.RowType = DataControlRowType.DataRow Then
            For dayNo As Integer = 0 To WorkingDaysCount - 1
                If DBUtilities.IsTimeEntryHoursFormat = "Time" Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Or Me.WG.DataKeys(e.Row.RowIndex).Item("IsTimeOff") = "True" And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet Then
                    If Not IsDBNull(Me.WG.DataKeys(e.Row.RowIndex).Item("TotalTime" & dayNo)) Then
                        If DBUtilities.GetClockStartEndBy = "Account" Then
                            If DBUtilities.GetShowClockStartEnd = True Then
                                CType(e.Row.Cells(3 + dayNo).FindControl("ST" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "StartTime" & dayNo))
                                CType(e.Row.Cells(3 + dayNo).FindControl("ET" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "EndTime" & dayNo))
                            End If
                        Else
                            If DBUtilities.ShowClockStartEndEmployee = True Then
                                CType(e.Row.Cells(3 + dayNo).FindControl("ST" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "StartTime" & dayNo))
                                CType(e.Row.Cells(3 + dayNo).FindControl("ET" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "EndTime" & dayNo))
                            End If
                        End If

                        If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                            CType(e.Row.Cells(3 + dayNo).FindControl("TT" & dayNo), Label).Text = Format(Me.WG.DataKeys(e.Row.RowIndex).Item("Hours" & dayNo), "00.00")
                        Else
                            CType(e.Row.Cells(3 + dayNo).FindControl("TT" & dayNo), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DBUtilities.GetMinutesOfTime(CType(Me.WG.DataKeys(e.Row.RowIndex).Item("TotalTime" & dayNo), Date)))
                        End If

                    End If
                End If
                If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
                    If Not IsDBNull(Me.WG.DataKeys(e.Row.RowIndex).Item("TotalTime" & dayNo)) Then
                        If DBUtilities.GetClockStartEndBy = "Account" Then
                            If DBUtilities.GetShowClockStartEnd = True Then
                                CType(e.Row.Cells(3 + dayNo).FindControl("ST" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "StartTime" & dayNo))
                                CType(e.Row.Cells(3 + dayNo).FindControl("ET" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "EndTime" & dayNo))
                            End If
                        Else
                            If DBUtilities.ShowClockStartEndEmployee = True Then
                                CType(e.Row.Cells(3 + dayNo).FindControl("ST" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "StartTime" & dayNo))
                                CType(e.Row.Cells(3 + dayNo).FindControl("ET" & dayNo), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "EndTime" & dayNo))
                            End If
                        End If

                        CType(e.Row.Cells(3 + dayNo).FindControl("TT" & dayNo), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DBUtilities.GetMinutesOfTime(CType(Me.WG.DataKeys(e.Row.RowIndex).Item("TotalTime" & dayNo), Date)))
                    End If
                End If
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet Then
                    If Not IsDBNull(Me.WG.DataKeys(e.Row.RowIndex).Item("Percentage" & dayNo)) Then
                        CType(e.Row.Cells(3 + dayNo).FindControl("P" & dayNo), Label).Text = CType(Me.WG.DataKeys(e.Row.RowIndex).Item("Percentage" & dayNo), Integer) & "%"
                    End If
                End If

                If Me.WG.DataKeys(e.Row.RowIndex).Item("IsTimeOff") = "True" Then

                    SetupRowAttachmentLink(e.Row)

                End If
            Next

        End If



        If e.Row.RowType = DataControlRowType.Footer Then
            For i As Integer = 0 To WorkingDaysCount - 1
                TotalTime(i) = 0
                TotalPercentage(i) = 0
            Next
            Dim objrow As GridViewRow
            For Each objrow In Me.WG.Rows
                For dayNo As Integer = 0 To WorkingDaysCount - 1
                    If DBUtilities.IsTimeEntryHoursFormat = "Time" Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Or Me.WG.DataKeys(objrow.RowIndex).Item("IsTimeOff") = "True" And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet Then
                        If Not IsDBNull(Me.WG.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo)) Then
                            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                                TotalHours(0 + dayNo) = TotalHours(0 + dayNo) + Me.WG.DataKeys(objrow.RowIndex).Item("Hours" & dayNo)
                                CType(e.Row.Cells(3 + dayNo).FindControl("sumTime" & dayNo), Label).Text = Format(TotalHours(dayNo), "00.00")
                            Else
                                TotalTime(0 + dayNo) = TotalTime(0 + dayNo) + DBUtilities.GetMinutesOfTime(CType(Me.WG.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo), Date))
                                CType(e.Row.Cells(3 + dayNo).FindControl("sumTime" & dayNo), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime(dayNo))
                            End If
                        End If
                    End If
                    If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
                        If Not IsDBNull(Me.WG.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo)) Then
                            TotalTime(0 + dayNo) = TotalTime(0 + dayNo) + DBUtilities.GetMinutesOfTime(CType(Me.WG.DataKeys(objrow.RowIndex).Item("TotalTime" & dayNo), Date))
                            CType(e.Row.Cells(3 + dayNo).FindControl("sumTime" & dayNo), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime(dayNo))
                        End If
                    End If
                    If LocaleUtilitiesBLL.ShowPercentageInTimesheet Then
                        If Not IsDBNull(Me.WG.DataKeys(objrow.RowIndex).Item("Percentage" & dayNo)) Then
                            TotalPercentage(0 + dayNo) = TotalPercentage(0 + dayNo) + CType(Me.WG.DataKeys(objrow.RowIndex).Item("Percentage" & dayNo), Integer)
                            CType(e.Row.Cells(3 + dayNo).FindControl("sumP" & dayNo), Label).Text = TotalPercentage(dayNo) & "%"
                        Else
                            TotalPercentage(0 + dayNo) = TotalPercentage(0 + dayNo) + 0
                            CType(e.Row.Cells(3 + dayNo).FindControl("sumP" & dayNo), Label).Text = TotalPercentage(dayNo) & "%"
                        End If
                    End If
                Next
                If DBUtilities.GetShowClockStartEnd = True Then
                    'CType(objrow.FindControl("lblST"), Label).Visible = True
                    'CType(objrow.FindControl("lblET"), Label).Visible = True
                End If
            Next
            For dayNo As Integer = 0 To WorkingDaysCount - 1
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    TotalGridHours += TotalHours(0 + dayNo)
                    lblTimesheetPrintFooterTotalDurationValue.Text = Format(TotalGridHours, "00.00")
                    lblTimesheetPrintFooterTotalHoursValue.Text = Format(TotalGridHours, "00.00")
                Else
                    TotalGridTime += TotalTime(0 + dayNo)
                    lblTimesheetPrintFooterTotalDurationValue.Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalGridTime)
                    lblTimesheetPrintFooterTotalHoursValue.Text = DBUtilities.GetHoursOfMinutesAsString(TotalGridTime)
                End If

            Next
            If Me.WG.DataKeys.Count > 0 Then
                lblTimesheetDescriptionValue.Text = IIf(IsDBNull(Me.WG.DataKeys(0).Item("PeriodDescription")), "", Me.WG.DataKeys(0).Item("PeriodDescription"))
            End If
        End If
    End Sub

    Private Sub SetupRowAttachmentLink(row As GridViewRow)
        Dim AccountProjectId = CType(row.Cells(1).FindControl("AccountProjectIdHidden"), HiddenField).Value
        Dim TimeOffTypeId = CType(row.Cells(2).FindControl("TimeOffTypeIdHidden"), HiddenField).Value
        Dim hyperlinkControl = CType(row.Cells(4).FindControl("ATLink"), HyperLink)

        Dim TimeOffAttachmentsBLL = New TimeOffAttachmentsBLL
        Dim count = TimeOffAttachmentsBLL.CountAttachmentsByProjectIdAndTimeOffTypeAndPeriodId(AccountProjectId, New Guid(TimeOffTypeId), Me.ViewState("dtStartDate"), Me.ViewState("AccountEmployeeId"))
        If count > 0 Then
            hyperlinkControl.Visible = True
            hyperlinkControl.Text = count
            hyperlinkControl.NavigateUrl = "~/Employee/TimeOffAttachments.aspx?ReadOnly=true&AccountProjectId=" & AccountProjectId & "&AccountTimeOffType=" & TimeOffTypeId & "&StartDate=" & Me.ViewState("dtStartDate") & "&AccountEmployeeId=" & Me.ViewState("AccountEmployeeId")

            Dim attachments = TimeOffAttachmentsBLL.GetTimeOffAttachmentsByProjectIdAndTimeOffTypeAndAccountEmployeeIdAndDate(AccountProjectId, New Guid(TimeOffTypeId), Me.ViewState("dtStartDate"), Me.ViewState("AccountEmployeeId"))
            If attachments.Count > 0 Then
                Dim att = attachments(0)
                If Not att.TimeOffAttachmentId = 0 Then
                    If UIUtilities.IsFileAnImage(att.AttachmentLocalPath) Then
                        CType(row.FindControl("imgTooltip"), System.Web.UI.WebControls.Image).ImageUrl = "~/Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/TimeOffAttachments/" & att.TimeEntryId & "/" & att.AttachmentLocalPath)
                        hyperlinkControl.CssClass = "tooltip"
                        hyperlinkControl.Attributes("data-tooltip-content") = "#" + CType(row.FindControl("tooltipContent"), Label).ClientID
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub ShowDate(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal TimesheetPeriodType As String)
        dtAccountEmployeeId = AccountEmployeeId
        dtTimesheetPeriodType = TimesheetPeriodType
        Me.ViewState.Add("dtStartDate", dtStartDate)
        Me.ViewState.Add("dtEndDate", dtEndDate)
        Me.ViewState.Add("AccountEmployeeId", dtAccountEmployeeId)
        Me.ViewState.Add("TimesheetPeriodType", dtTimesheetPeriodType)
        Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("AccountEmployeeId").DefaultValue = dtAccountEmployeeId
        Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimeEntryStartDate").DefaultValue = dtStartDate
        Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimeEntryEndDate").DefaultValue = dtEndDate
        'Me.dsAccountEmployeeTimeEntriesWeek.SelectParameters("TimesheetPeriodType").DefaultValue = dtTimesheetPeriodType
        Me.dsAccountEmployeeTimeEntriesWeekForRelevantProject.SelectParameters("AccountEmployeeId").DefaultValue = dtAccountEmployeeId
        Me.dsAccountEmployeeTimeEntriesWeekForRelevantProject.SelectParameters("TimeEntryStartDate").DefaultValue = dtStartDate
        Me.dsAccountEmployeeTimeEntriesWeekForRelevantProject.SelectParameters("TimeEntryEndDate").DefaultValue = dtEndDate
        'Me.dsAccountEmployeeTimeEntriesWeekForRelevantProject.SelectParameters("TimesheetPeriodType").DefaultValue = dtTimesheetPeriodType
    End Sub
    Public Sub Show()
        Dim dtDate As Date
        dtStartDate = dtStartDate.Date
        dtEndDate = dtEndDate.Date
        If Not Request.QueryString("StartDate") Is Nothing And Not Request.QueryString("TimesheetPeriodType") Is Nothing Then
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetViewAccountEmployeesByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId"))
            Dim drEmployee As AccountEmployee.vueAccountEmployeeRow
            If dtEmployee.Rows.Count > 0 Then
                drEmployee = dtEmployee.Rows(0)
                dtDate = LocaleUtilitiesBLL.ConvertBaseDateStringToDate(Me.Request.QueryString("StartDate"))
                dtTimesheetPeriodType = Me.Request.QueryString("TimesheetPeriodType")
                dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, dtTimesheetPeriodType, drEmployee.EmployeeWeekStartDay, drEmployee.SystemInitialDayOfFirstPeriod, drEmployee.SystemInitialDayOfLastPeriod, drEmployee.InitialDayOfTheMonth)
                dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, dtTimesheetPeriodType, drEmployee.EmployeeWeekStartDay, drEmployee.SystemInitialDayOfFirstPeriod, drEmployee.SystemInitialDayOfLastPeriod, drEmployee.InitialDayOfTheMonth)
                WorkingDays = DateTimeUtilities.GetWorkingDays(Me.Request.QueryString("AccountEmployeeId"), dtDate, dtStartDate, dtEndDate)
                WorkingDaysCount = WorkingDays.Count
            End If
        End If
        Me.AddColumnsInWGByDate(dtDate)
        Me.HideColumnsInGridView()
        Me.lblEmployeeName.Text = GetEmployeeName()
        Me.lblStartDate.Text = LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(dtStartDate)
        Me.lblEndDate.Text = LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(dtEndDate)
    End Sub
    Public Sub AddColumnsInWGByDate(ByVal dtDate As Date)
        Dim AccountEmployeeTimeEntryDataKeyNames As String
        Dim TotalTimeDataKeyNames As String
        Dim PercentageDataKeyNames As String
        Dim HoursDataKeyNames As String
        Dim DataKeyNames As String
        For dayNo As Integer = 0 To WorkingDaysCount - 1
            AccountEmployeeTimeEntryDataKeyNames += "AccountEmployeeTimeEntryId" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            TotalTimeDataKeyNames += "TotalTime" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            PercentageDataKeyNames += "Percentage" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            HoursDataKeyNames += "Hours" & dayNo & IIf(dayNo = WorkingDaysCount - 1, "", ",")
            dtDate = dtStartDate.AddDays(dayNo)
            Dim DayMonth As String = LocaleUtilitiesBLL.GetDayDateAndMonthInCurrentLocale(WorkingDays(dayNo))
            Dim dayname As String = ResourceHelper.GetFromResource(LocaleUtilitiesBLL.GetDayInCurrentLocale(WorkingDays(dayNo)))
            Dim dtcolumn As New TemplateField
            dtcolumn.HeaderText = dayname + "<br>" + DayMonth
            Dim IsEnable As Boolean = True
            dtcolumn.ItemTemplate = New ReadOnlyTimesheetItemTemplate("ST" & dayNo, "ET" & dayNo, "TT" & dayNo, IsEnable, "P" & dayNo)
            dtcolumn.FooterTemplate = New ReadOnlyTimesheetFooterTemplate("sumTime" & dayNo, "sumP" & dayNo)
            Me.WG.Columns.Add(dtcolumn)
            dtcolumn.Visible = IsEnable
            dtcolumn.ItemStyle.Width = Unit.Pixel(12)
            dtcolumn.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            dtcolumn.FooterStyle.HorizontalAlign = HorizontalAlign.Center
        Next
        DataKeyNames = AccountEmployeeTimeEntryDataKeyNames + "," + TotalTimeDataKeyNames + "," + PercentageDataKeyNames + "," + "IsTimeOff" + "," + HoursDataKeyNames + "," + "PeriodDescription"
        Me.WG.DataKeyNames = DataKeyNames.Split(",".ToCharArray(), WorkingDaysCount * 4 + 3)
    End Sub
    Public Function HideColumnInGridViewByWorkingDays(ByVal DayHeader As String, ByVal dayNo As Integer) As Boolean
        Dim BLL As New AccountWorkingDayBLL
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dt As TimeLiveDataSet.vueAccountWorkingDayDataTable = BLL.GetAccountWorkingDaysByAccountIdAndAccountWorkingDayTypeId(DBUtilities.GetSessionAccountId, EmployeeBLL.GetAccountWorkingDayTypeIdByEmployeeId(Me.Request.QueryString("AccountEmployeeId")))
        Dim dr As TimeLiveDataSet.vueAccountWorkingDayRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If Left(dr.WorkingDay, 3) = DayHeader Then
                    Return True
                End If
            Next
            Return False
        End If
    End Function
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.Show()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Public Sub HideColumnsInGridView()
        If DBUtilities.GetShowClientInTimesheet = False Then
            Me.WG.Columns(0).Visible = False
        End If
        If DBUtilities.IsShowCostCenterInTimeSheet = False Then
            Me.WG.Columns(3).Visible = False
        Else
            Me.WG.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
        End If
        If DBUtilities.IsShowWorkTypeInTimeSheet = False Then
            Me.WG.Columns(4).Visible = False
        End If
    End Sub
    Public Function GetEmployeeName() As String
        dtAccountEmployeeId = IIf(Me.Request.QueryString("AccountEmployeeId") Is Nothing, 0, Me.Request.QueryString("AccountEmployeeId"))
        Dim BLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = BLL.GetAccountEmployeesByAccountEmployeeId(dtAccountEmployeeId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow
        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            If DBUtilities.GetShowEmployeeNameBy = 1 Then
                EmployeeName = drEmployee.FirstName & " " & drEmployee.LastName
            Else
                EmployeeName = drEmployee.LastName & " " & drEmployee.FirstName
            End If
            Return EmployeeName
        Else
            Return ""
        End If
    End Function
    Public Sub SetGridViewDataSource(ByVal chkShowAllValue As Boolean)
        Me.WG.DataSourceID = ""
        Dim AccountEmployeeId As Integer = Me.ViewState("AccountEmployeeId")
        Dim TimesheetPeriodType As String = Me.ViewState("TimesheetPeriodType")
        Dim dtDate As Date = Me.ViewState("dtStartDate")
        If chkShowAllValue <> True Then
            Me.ShowDate(AccountEmployeeId, dtDate, TimesheetPeriodType)
            Me.WG.DataSourceID = "dsAccountEmployeeTimeEntriesWeekForRelevantProject"
        Else
            Me.ShowDate(AccountEmployeeId, dtDate, TimesheetPeriodType)
            Me.WG.DataSourceID = "dsAccountEmployeeTimeEntriesWeek"
        End If
        Me.WG.DataBind()
    End Sub
End Class
