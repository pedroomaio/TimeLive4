
Imports System.Drawing
''' <summary>
''' Controls for employee time entry day view 
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryDayView
    Inherits System.Web.UI.UserControl
    Dim TimeEntryDate As Date
    Dim TotalTime As Integer
    Dim TotalHours As Decimal
    Dim Percentage As Double
    Dim StartDate As Date
    Dim dtAccountEmployeeTimeEntryPeriodId As Guid
    Dim dtStartDate As DateTime = #11/1/2006#
    Dim dtEndDate As DateTime = #11/7/2006#
    Dim TimesheetPeriodType As String
    Public Event AfterAttendanceUpdate()
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
    Dim TotalCustomFields As Integer
    Dim LockDate = Date.DaysInMonth(Now.Year, Now.Month)
    ''' <summary>
    ''' Week start day changed event

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
    ''' Bulk edit grid view data bound event
    ''' </summary
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BulkEditGridViewVB1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles BulkEditGridViewVB1.DataBound
        TotalTime = 0
        TotalHours = 0
        Percentage = 0
        Dim dtDate As Date = Me.ViewState("TimeEntryDate")
        dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, Me.ViewState("EmployeeTimesheetPeriodType"), Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, Me.ViewState("EmployeeTimesheetPeriodType"), Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        TimesheetPeriodType = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(Me.ViewState("TimeEntryAccountEmployeeId"), dtStartDate, dtEndDate, Me.ViewState("EmployeeTimesheetPeriodType"))
        If TimesheetPeriodType <> EmployeeTimesheetPeriodType Then
            dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
            dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, TimesheetPeriodType, Me.ViewState("EmployeeWeekStartDay"), Me.ViewState("EmployeeInitialDayOfFirstPeriod"), Me.ViewState("EmployeeInitialDayOfLastPeriod"), Me.ViewState("EmployeeInitialDayOfTheMonth"))
        End If
        WeekStartDayChanged()
        Me.btnWeekView.Text = TimesheetPeriodType + " " + "Timesheet"
        Dim objRow As GridViewRow
        For Each objRow In Me.BulkEditGridViewVB1.Rows
            If objRow.RowType = DataControlRowType.DataRow Then
                Me.ShowDataForddlAccountCostCenterId(objRow)
                Me.SetCascadingAccountId(objRow)
                SetTimeFormatInGrid(objRow)
                SetPermissionInGrid(objRow)
                SetClientCascadingEnabled(objRow)
                If AccountEmployeeTimeEntryBLL.CheckSubmittedAndLockDayView(dtStartDate, dtEndDate, TimesheetPeriodType, Me.ViewState("TimeEntryAccountEmployeeId")) = True And Me.ViewState("IsCopyFromDate") = "False" Then
                    Me.DisableTimeEntryViewOfWeek(objRow)
                End If
                HideTotalTimeTextBoxForPercentage(objRow)
            End If
        Next
        If Me.ViewState("IsCopyFromDate") = "True" Then
            lblTimesheetStatus.Text = ResourceHelper.GetFromResource("Not Submitted")
            imgTSL.ImageUrl = "~/images/NotSubmittedStatus.gif"
        Else
            Call New AccountEmployeeTimeEntryBLL().SetTimesheetStatus(lblTimesheetStatus, imgTSL, dtStartDate, dtEndDate, TimesheetPeriodType, Me.ViewState("TimeEntryAccountEmployeeId"))
        End If
        If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Then
            btnTimerTimesheet.Visible = False
        End If
        'HideColumnsInGridViewByClient()
        Me.SetResourceInDayView()
        SetGridColumnSpanForTimeOff()
        ShowCopyButtonsByPreference()
        If DBUtilities.GetLockAllFutureTimesheets Then
            DisableAllFutureTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockAllPreviousTimesheets Then
            DisableAllPreviousTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockPreviousTimesheetPeriods Then
            Me.DisablePreviousWeekTimeEntry()
        End If
        If DBUtilities.GetLockNextTimsheetPeriods Then
            Me.DisableNextWeekTimeEntry()
        End If
        If DBUtilities.GetLockAllPeriodExceptPrevious Then
            Me.UnlockPreviousPeriodsTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockAllPeriodExceptNext Then
            Me.UnlockNextPeriodsTimeEntryOfWeek()
        End If
        If DBUtilities.GetLockPreviousNextMonthTimesheetOn Then
            Dim No As Integer = DBUtilities.GetLockPreviousNextMonthTimesheetOn
            Me.DisablePreviousNextMonthTimeEntryOfWeek(No)
        End If
    End Sub
    Public Sub ShowCopyButtonsByPreference()
        If Not DBUtilities.ShowCopyActivitiesButtonInTimesheet Then
            btnCopyActivities.Visible = False
        End If
        If Not DBUtilities.ShowCopyTimesheetButton Then
            btnCopy.Visible = False
        End If
        If Not DBUtilities.ShowCopyActivitiesButtonInTimesheet And Not DBUtilities.ShowCopyTimesheetButton Then
            CopyFromCalendarPopup.Visible = False
            lblCopyFrom.Visible = False
        End If
    End Sub
    Public Sub HideTotalTimeTextBoxForPercentage(Row As GridViewRow)
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" And Me.BulkEditGridViewVB1.DataKeys(Row.RowIndex)("IsTimeOff").ToString = "False" Then
            If Not CType(Row.FindControl("TotalTime"), TextBox) Is Nothing Then
                CType(Row.FindControl("TotalTime"), TextBox).Visible = False
            End If
        End If
        If Me.BulkEditGridViewVB1.DataKeys(Row.RowIndex)("IsTimeOff").ToString = "True" Or LocaleUtilitiesBLL.ShowPercentageInTimesheet() = False Then
            If Not CType(Row.FindControl("Percentage"), TextBox) Is Nothing Then
                CType(Row.FindControl("Percentage"), TextBox).Visible = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set data in variable for get working days of specified AccountEmployeeId
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
    ''' <summary>
    ''' Disable time entry view of week of specified object row of grid view row
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <remarks></remarks>
    Public Sub DisableTimeEntryViewOfWeek(ByVal objrow As GridViewRow)
        If Not CType(objrow.FindControl("ddlAccountClientId"), DropDownList) Is Nothing Then
            UIUtilities.MakeDropdownReadonly(CType(objrow.FindControl("ddlAccountClientId"), DropDownList))
        End If
        UIUtilities.MakeDropdownReadonly(CType(objrow.FindControl("ddlAccountProjectId"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList))
        UIUtilities.MakeDropdownReadonly(CType(objrow.FindControl("ddlTimeOffTypes"), DropDownList))

        If Not CType(objrow.FindControl("ddlAccountWorkTypeId"), DropDownList) Is Nothing Then
            UIUtilities.MakeDropdownReadonly(CType(objrow.FindControl("ddlAccountWorkTypeId"), DropDownList))
        End If
        If Not CType(objrow.FindControl("ddlAccountCostCenterId"), DropDownList) Is Nothing Then
            UIUtilities.MakeDropdownReadonly(CType(objrow.FindControl("ddlAccountCostCenterId"), DropDownList))
        End If
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = True Then
                UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("StartTime"), TextBox))
                UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("EndTime"), TextBox))
            End If
        Else
            If DBUtilities.ShowClockStartEndEmployee = True Then
                UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("StartTime"), TextBox))
                UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("EndTime"), TextBox))
            End If
        End If

        UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("Description"), TextBox))
        UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("TotalTime"), TextBox))
        UIUtilities.MakeTextboxReadonly(CType(objrow.FindControl("Percentage"), TextBox))
        For n As Integer = 1 To 9
            DisableCustomFields(objrow.FindControl("CustomField" & n))
        Next
        btnSubmit.Enabled = False
        btnSave.Enabled = False
        'btnTopSubmit.Enabled = False
        btnTopSave.Enabled = False
        btnCopy.Enabled = False
        btnCopyActivities.Enabled = False
        btnTimerTimesheet.Enabled = False
    End Sub
    ''' <summary>
    ''' Set time format in grid of specified object row of grid view row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetTimeFormatInGrid(ByVal objRow As GridViewRow)
        If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
            With CType(objRow.FindControl("MaskedEditExtenderTotalTime"), AjaxControlToolkit.MaskedEditExtender)
                .Enabled = False
            End With
            With CType(objRow.FindControl("MaskedEditValidatorTotalTime"), AjaxControlToolkit.MaskedEditValidator)
                .Enabled = False
            End With
        Else
            With CType(objRow.FindControl("rvTT"), RangeValidator)
                .Enabled = False
            End With
            If DBUtilities.IsNotSupportedCultureFormats = True Then
                If DBUtilities.GetClockStartEndBy = "Account" Then
                    If DBUtilities.GetShowClockStartEnd = True Then
                        DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MaskedEditExtenderStartTime"))
                        DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MaskedEditExtenderEndTime"))
                    End If
                Else
                    If DBUtilities.ShowClockStartEndEmployee = True Then
                        DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MaskedEditExtenderStartTime"))
                        DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MaskedEditExtenderEndTime"))
                    End If
                End If
                DBUtilities.SetMaskEditExtenderCultureToUS(objRow.FindControl("MaskedEditExtenderTotalTime"))
            End If
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If DBUtilities.GetShowClockStartEnd = True Then
                    CType(objRow.FindControl("MaskedEditExtenderStartTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                    CType(objRow.FindControl("MaskedEditExtenderEndTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                End If
            Else
                If DBUtilities.ShowClockStartEndEmployee = True Then
                    CType(objRow.FindControl("MaskedEditExtenderStartTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                    CType(objRow.FindControl("MaskedEditExtenderEndTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                End If
            End If
            CType(objRow.FindControl("MaskedEditExtenderTotalTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = False
        End If
    End Sub
    ''' <summary>
    ''' Set permission in grid of specified object row of grid view row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetPermissionInGrid(ByVal objRow As GridViewRow)
        If objRow.RowIndex > Me.BulkEditGridViewVB1.Rows.Count - 1 Then
            If AccountPagePermissionBLL.IsPageHasPermissionOf(18, 3) = False Then
                Me.SetPermissionForEdit(objRow)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set permission for edit of specified object row of grid view row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetPermissionForEdit(ByVal objRow As GridViewRow)
        CType(Me.FindControl("btnSave"), Button).Enabled = False
        CType(Me.FindControl("btnSubmit"), Button).Enabled = False
        CType(Me.FindControl("btnTopSave"), Button).Enabled = False
        CType(Me.FindControl("btnTopSubmit"), Button).Enabled = False
    End Sub
    ''' <summary>
    ''' Bulk edit grid view row data bound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BulkEditGridViewVB1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles BulkEditGridViewVB1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim MyCascading As AjaxControlToolkit.CascadingDropDown
            Dim dataValue As Object
            Dim objDropdown As DropDownList
            Dim dsObject As ObjectDataSource
            Me.SetRowDataBoundInDayViewDataRow(objDropdown, dsObject, dataValue, MyCascading, e.Row)
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Me.SetRowDataBoundInDayViewFooterRow(e.Row)
        End If
    End Sub
    ''' <summary>
    ''' Subtract column
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SubtractColumn() As Integer
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = False Then
                Return 2
            Else
                Return 0
            End If
        Else
            If DBUtilities.ShowClockStartEndEmployee = False Then
                Return 2
            Else
                Return 0
            End If
        End If
    End Function
    'Public Sub SetCascadingAccountId(ByVal objRow As GridViewRow)
    '    Dim MyCascading As AjaxControlToolkit.CascadingDropDown
    '    MyCascading = CType(objRow.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
    '    Dim dsObject As ObjectDataSource
    '    dsObject = CType(objRow.Cells(1).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
    '    Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
    '    dsObject = CType(objRow.Cells(1).FindControl("dsAccountProjectsObject"), ObjectDataSource)
    '    Dim AccountProjectId As Integer = dsObject.SelectParameters("AccountProjectId").DefaultValue
    '    MyCascading.Category = Me.ViewState("TimeEntryAccountEmployeeId") & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & AccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & AccountProjectId & "," & DBUtilities.GetShowAdditionalTaskInformationType
    'End Sub
    ''' <summary>
    ''' Set cascading account id of specified object row of grid view row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub SetCascadingAccountId(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        'If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") <> "Yes" Then
        If DBUtilities.GetShowClientInTimesheet = False And DBUtilities.GetShowProjectInTimesheet = False Then
            MyCascading = CType(objRow.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ParentControlID = Nothing
        ElseIf DBUtilities.GetShowProjectInTimesheet = False And DBUtilities.GetShowClientInTimesheet = True Then
            MyCascading = CType(objRow.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ParentControlID = "ddlAccountClientId"
        Else
            MyCascading = CType(objRow.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ParentControlID = "ddlAccountProjectId"
        End If
        Dim dsObject As ObjectDataSource
        dsObject = CType(objRow.Cells(1).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
        Dim AccountProjectId As Integer
        If DBUtilities.GetShowClientInTimesheet = True And DBUtilities.GetShowProjectInTimesheet = False Then
            dsObject = CType(objRow.Cells(1).FindControl("dsAccountClientObject"), ObjectDataSource)
            AccountProjectId = dsObject.SelectParameters("AccountClientId").DefaultValue
        Else
            dsObject = CType(objRow.Cells(1).FindControl("dsAccountProjectsObject"), ObjectDataSource)
            AccountProjectId = dsObject.SelectParameters("AccountProjectId").DefaultValue
        End If
        MyCascading.Category = Me.ViewState("TimeEntryAccountEmployeeId") & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & AccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & AccountProjectId & "," & DBUtilities.GetShowAdditionalTaskInformationType & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetShowProjectInTimesheet
    End Sub
    ''' <summary>
    ''' Get cell value of specified object row of grid view row, nCellIndex, strObjectId
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
    Public Function GetCellValueForCustomField(ByVal objRow As GridViewRow, ByVal nCellIndex As Integer, ByVal strObjectId As String) As Object
        Dim UIObject As Object = objRow.Cells(nCellIndex).FindControl(strObjectId)
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
    ''' <summary>
    ''' Update row of specified object row of grid view row, NewValues
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="NewValues"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRow(ByVal objRow As GridViewRow, ByVal NewValues As System.Collections.Specialized.IOrderedDictionary)
        If objRow.RowType = DataControlRowType.DataRow Then
            NewValues("AccountProjectId") = Me.GetCellValue(objRow, 1, "ddlAccountProjectId")
            NewValues("AccountProjectTaskId") = Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId")
            NewValues("AccountCostCenterId") = Me.GetCellValue(objRow, 3, "ddlAccountCostCenterId")
            NewValues("AccountWorkTypeId") = IIf(Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId") = "", GetStandardWorkType, Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId"))
            NewValues("StartTime") = Me.GetCellValue(objRow, 5, "StartTime")
            NewValues("EndTime") = Me.GetCellValue(objRow, 6, "EndTime")
            NewValues("TotalTime") = Me.GetCellValue(objRow, 7, "TotalTime")
            NewValues("Description") = Me.GetCellValue(objRow, 8, "Description")
        End If
    End Sub
    ''' <summary>
    ''' Bulk edit grid view row updating event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BulkEditGridViewVB1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles BulkEditGridViewVB1.RowUpdating
        Dim objRow As GridViewRow = Me.BulkEditGridViewVB1.Rows(e.RowIndex)
        If objRow.RowType = DataControlRowType.DataRow Then
            Me.UpdateRow(objRow, e.NewValues)
            e.Cancel = Not Me.ValidateRow(objRow, e.NewValues)
        End If
    End Sub
    ''' <summary>
    ''' Validate row of specified object row of grid view row, NewValues
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="NewValues"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateRow(ByVal objRow As GridViewRow, ByVal NewValues As System.Collections.Specialized.IOrderedDictionary) As Boolean
        If Not IsNumeric(NewValues("AccountProjectId")) Or Not IsNumeric(NewValues("AccountProjectTaskId")) Or Not IsNumeric(NewValues("AccountWorkTypeId")) Then
            Return False
        End If
        If NewValues("AccountProjectId") = 0 Or NewValues("AccountProjectTaskId") = 0 Or NewValues("AccountWorkTypeId") = 0 Then
            Return False
        End If
        If NewValues("TotalTime") = "" Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Show not found message of specified string message
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
    ''' Button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.ValidateTimeEntryDayView = True Then
            If Me.ViewState("IsCopyFromDate") = "True" Then
                DeleteOldDayEntriesForNewCopyEntries(Me.ViewState("TimeEntryAccountEmployeeId"), Me.ViewState("TimeEntryDate"))
                Me.dsAccountEmployeeTimeEntry.InsertParameters("TimeEntryDate").DefaultValue = Me.ViewState("TimeEntryDate")
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("TimeEntryDate").DefaultValue = Me.ViewState("TimeEntryDate")
                Me.dsAccountEmployeeTimeEntry.InsertParameters("AccountEmployeeId").DefaultValue = Me.ViewState("TimeEntryAccountEmployeeId")
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("AccountEmployeeId").DefaultValue = Me.ViewState("TimeEntryAccountEmployeeId")
            Else
                Me.dsAccountEmployeeTimeEntry.InsertParameters("TimeEntryDate").DefaultValue = Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("TimeEntryDate").DefaultValue = Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue
                Me.dsAccountEmployeeTimeEntry.InsertParameters("PeriodStartDate").DefaultValue = dtStartDate
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("PeriodStartDate").DefaultValue = dtStartDate
                Me.dsAccountEmployeeTimeEntry.InsertParameters("PeriodEndDate").DefaultValue = dtEndDate
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("PeriodEndDate").DefaultValue = dtEndDate
                Me.dsAccountEmployeeTimeEntry.InsertParameters("TimesheetPeriodType").DefaultValue = TimesheetPeriodType
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("TimesheetPeriodType").DefaultValue = TimesheetPeriodType
                Me.dsAccountEmployeeTimeEntry.InsertParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
                Me.dsAccountEmployeeTimeEntry.UpdateParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
            End If
            Me.SetPeriodIdAndParameters()
            Dim URL As String = "AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("TimeEntryDate")) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId")
            Me.Save(False, URL)
            'Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("TimeEntryDate")) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId"), False)
            'Server.Transfer("AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("TimeEntryDate")) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId"), True)
            '            Response.Tran("AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("TimeEntryDate")) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId"), False)
        End If
    End Sub
    ''' <summary>
    ''' Set period id and parameters
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPeriodIdAndParameters()
        Dim objTimeEntryBLL As New AccountEmployeeTimeEntryBLL
        dtAccountEmployeeTimeEntryPeriodId = Me.ViewState("dtAccountEmployeeTimeEntryPeriodId")
        If dtAccountEmployeeTimeEntryPeriodId = System.Guid.Empty Then
            dtAccountEmployeeTimeEntryPeriodId = objTimeEntryBLL.AddAccountEmployeeTimeEntryPeriod(DBUtilities.GetSessionAccountId, Me.ViewState("TimeEntryAccountEmployeeId"), dtStartDate, dtEndDate, False, False, False, False, TimesheetPeriodType)
        End If
        Me.dsAccountEmployeeTimeEntry.InsertParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = dtAccountEmployeeTimeEntryPeriodId.ToString
        Me.dsAccountEmployeeTimeEntry.UpdateParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = dtAccountEmployeeTimeEntryPeriodId.ToString
    End Sub
    ''' <summary>
    ''' Validate time entry day view
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateTimeEntryDayView() As Boolean
        Dim objrow As GridViewRow
        Dim PHT As New Hashtable
        Dim PC As Integer
        For Each objrow In Me.BulkEditGridViewVB1.Rows
            If objrow.RowType = DataControlRowType.DataRow Then
                If CType(objrow.FindControl("TotalTime"), TextBox).Text <> "" And CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue = "" And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                    Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
                    Return False
                End If
                If CType(objrow.FindControl("TotalTime"), TextBox).Text <> "" And CType(objrow.Cells(1).FindControl("ddlTimeOffTypes"), DropDownList).SelectedValue = "" And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then
                    Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
                    Return False
                End If
                'If CType(objrow.FindControl("TotalTime"), TextBox).Text <> "" Then
                '    If DBUtilities.GetMinutesOfTime(CType(objrow.FindControl("TotalTime"), TextBox).Text) = "0" Then
                '        Me.ShowNotFoundMessage("Please enter value more than 0 in total time.")
                '        Return False
                '    End If
                'End If
                If Not CType(objrow.FindControl("Percentage"), TextBox) Is Nothing And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                    If CType(objrow.FindControl("Percentage"), TextBox).Text <> "" And CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue = "" Then
                        Me.ShowNotFoundMessage(Resources.TimeLive.Resource.TimeEntry_Validation)
                        Return False
                    End If
                    If CType(objrow.FindControl("Percentage"), TextBox).Text <> "" Then
                        If CType(objrow.FindControl("Percentage"), TextBox).Text > 100 Then
                            Me.ShowNotFoundMessage("You may not enter more than 100 percent.")
                            Return False
                        End If
                    End If
                    If CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue <> "" And CType(objrow.FindControl("Percentage"), TextBox).Text <> "" And IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId")) Or (CType(objrow.FindControl("Percentage"), TextBox).Text <> "" And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId")) And IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("Percentage"))) Then
                        SetValuesInPercentageHashTable(PHT, CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue, CType(objrow.FindControl("Percentage"), TextBox).Text)
                    ElseIf CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue <> "" And CType(objrow.FindControl("Percentage"), TextBox).Text <> "" And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId")) Then
                        If Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("Percentage") <> CType(objrow.FindControl("Percentage"), TextBox).Text Then
                            PC = CType(objrow.FindControl("Percentage"), TextBox).Text - Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("Percentage")
                            SetValuesInPercentageHashTable(PHT, CType(objrow.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue, PC)
                        End If
                    End If
                End If
            End If
        Next
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
    ''' Validate day hours
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateDayHours() As Boolean
        Dim objrow As GridViewRow
        Dim DayHours As Double
        For Each objrow In Me.BulkEditGridViewVB1.Rows
            If objrow.RowType = DataControlRowType.DataRow Then
                If CType(objrow.FindControl("TotalTime"), TextBox).Text <> "" Then
                    DayHours += DBUtilities.GetMinutesOfTime(CType(objrow.FindControl("TotalTime"), TextBox).Text) / 60
                End If
            End If
        Next
        If DayHours > MaxDayHours Then
            Me.ShowNotFoundMessage("You may not enter more than " & MaxDayHours & " hours per day.")
            Return False
        End If
        If DayHours < MinDayHours Then
            Me.ShowNotFoundMessage("You may not enter less than " & MinDayHours & " hours per day.")
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Fix rows
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FixRows()
        If Me.BulkEditGridViewVB1.Rows.Count > 0 Then
            Exit Sub
        End If
        Dim objRow As TableRow
        For Each objRow In Me.BulkEditGridViewVB1.Rows
            If objRow.Cells(2).Controls.Count > 0 Then
                If DBUtilities.GetClockStartEndBy = "Account" Then
                    If DBUtilities.GetShowClockStartEnd = True Then
                    End If
                Else
                    If DBUtilities.ShowClockStartEndEmployee = True Then
                    End If
                End If
                If Not objRow.Cells(5 - Me.SubtractColumn).FindControl("TotalTime") Is Nothing Then
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set select parameter of specified IsCopyFrom
    ''' </summary>
    ''' <param name="IsCopyFrom"></param>
    ''' <remarks></remarks>
    Public Sub SetSelectParameter(Optional ByVal IsCopyFrom As Boolean = False)
        If IsCopyFrom = True Then
            Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue = Me.ViewState("CopyFromDate")
            Me.dsAccountEmployeeTimeEntry.SelectParameters("AccountEmployeeId").DefaultValue = Me.ViewState("TimeEntryAccountEmployeeId")
            Me.dsAccountEmployeeTimeEntry.SelectParameters("IsCopy").DefaultValue = IsCopyFrom
        Else
            Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue = Me.TimeEntryDate
            Me.dsAccountEmployeeTimeEntry.SelectParameters("AccountEmployeeId").DefaultValue = TimeEntryAccountEmployeeId
            Me.dsAccountEmployeeTimeEntry.SelectParameters("IsCopy").DefaultValue = IsCopyFrom
        End If
        CType(Me.CtlAccountEmployeeAttendanceList1.FindControl("dsAccountEmployeeAttendanceObject"), ObjectDataSource).SelectParameters("AttendanceDate").DefaultValue = Me.TimeEntryDate
        CType(Me.CtlAccountEmployeeAttendanceList1.FindControl("dsAccountEmployeeAttendanceFormObject"), ObjectDataSource).InsertParameters("AttendanceDate").DefaultValue = Me.TimeEntryDate
        CType(Me.CtlAccountEmployeeAttendanceList1.FindControl("UP").FindControl("GV"), GridView).DataBind()
        System.Web.HttpContext.Current.Session("StoreInSession") = "Yes"
        Me.BulkEditGridViewVB1.DataBind()
        dtAccountEmployeeTimeEntryPeriodId = New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodIdForPeriodView(DBUtilities.GetSessionAccountId, TimeEntryAccountEmployeeId, dtStartDate, dtEndDate, TimesheetPeriodType)
        Me.ViewState.Add("dtAccountEmployeeTimeEntryPeriodId", dtAccountEmployeeTimeEntryPeriodId)
        FixRows()
    End Sub
    ''' <summary>
    ''' Page init event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        AddCustomField()
        btnSave.Attributes.Add("onclick", "javascript: if ( Page_ClientValidate() )" + "{" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSave.ClientID + ".disabled=true;" + "}" + Me.Page.ClientScript.GetPostBackEventReference(btnSave, "") + ";return false;")
        btnTopSave.Attributes.Add("onclick", "javascript: if ( Page_ClientValidate() )" + "{" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSave.ClientID + ".disabled=true;" + "}" + Me.Page.ClientScript.GetPostBackEventReference(btnTopSave, "") + ";return false;")
    End Sub
    ''' <summary>
    ''' Page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TimeEntryAccountEmployeeId = IIf(ddlEmployee.SelectedValue = "", IIf(Me.Request.QueryString("AccountEmployeeId") Is Nothing, DBUtilities.GetSessionAccountEmployeeId, Me.Request.QueryString("AccountEmployeeId")), ddlEmployee.SelectedValue)
        TotalTime = 0
        TotalHours = 0
        Percentage = 0
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(18, ddlEmployee)
            If TimeEntryAccountEmployeeId = 0 Or ddlEmployee.Items.FindByValue(TimeEntryAccountEmployeeId) Is Nothing Then
                TimeEntryAccountEmployeeId = ddlEmployee.SelectedValue
            End If
        End If
        Me.ddlEmployee.SelectedValue = TimeEntryAccountEmployeeId
        SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        If Not Request.QueryString("StartDate") Is Nothing Then
            Me.ViewState.Add("OriginalTimeEntryDate", Me.txtTimeEntryDate.PostedDate)
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("StartDate"))
            Me.lblCurrenctdate.Text = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("StartDate"))
            Me.CheckHolidayIcon(Me.txtTimeEntryDate.SelectedDate)
        Else
            Me.ViewState.Add("OriginalTimeEntryDate", LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate))
            Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            Me.CopyFromCalendarPopup.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            Me.lblCurrenctdate.Text = Me.txtTimeEntryDate.SelectedDate
            Me.CheckHolidayIcon(Me.txtTimeEntryDate.SelectedDate)
        End If
        If Not Me.IsPostBack Then
            Me.RefreshDayView()
        End If
        If Not Me.ViewState("dtAccountEmployeeTimeEntryPeriodId") = System.Guid.Empty Then
            btnAudit.Visible = True
        End If
        'btnCopy.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForDayView)
        'btnCopyActivities.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForDayView)

        btnCopy.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForDayView + "javascript:" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSave.ClientID + ".disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnCopy, ""))
        btnCopyActivities.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForDayView + "javascript:" + btnCopyActivities.ClientID + ".disabled=true;" + btnCopy.ClientID + ".disabled=true;" + btnTopSave.ClientID + ".disabled=true;" + btnSave.ClientID + ".disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnCopyActivities, ""))
        If Not Me.IsPostBack Then
            Me.TimeEntryDate = Now.Date
            HideColumnsInGridViewByClient()
        Else
            Me.TimeEntryDate = Me.ViewState("TimeEntryDate")
            HideColumnsInGridViewByClient()
        End If
        If Not AccountPagePermissionBLL.IsPageHasPermissionOf(18, 3) = True Then
            SetPermissionForEditTimesheet(False)
        End If
        'Me.Page.Form.DefaultButton = Me.btnSave.UniqueID
        Dim URL As String = "TimerControl.aspx?AccountEmployeeId=" & DBUtilities.GetSessionAccountEmployeeId & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(txtTimeEntryDate.SelectedDate) & "&TimesheetPeriodType=" & TimesheetPeriodType & "&TimeEntryMode=" & "Day View"
        btnTimerTimesheet.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=540,height=365,left=400,top=290,scrollbars=yes'); return false;")
        EmployeeNameLabel.Text = ResourceHelper.GetFromResource("Employees:")
    End Sub
    ''' <summary>
    ''' Set permission for edit timesheet of specified IsEditPermission
    ''' </summary>
    ''' <param name="IsEditPermission"></param>
    ''' <remarks></remarks>
    Public Sub SetPermissionForEditTimesheet(ByVal IsEditPermission As Boolean)
        btnSave.Enabled = IsEditPermission
        btnSubmit.Enabled = IsEditPermission
        btnCopy.Enabled = IsEditPermission
        btnCopyActivities.Enabled = IsEditPermission
    End Sub
    ''' <summary>
    ''' Button save click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    End Sub
    ''' <summary>
    ''' Calendar selection changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.SetSelectParameter()
    End Sub
    ''' <summary>
    ''' Is row changed event
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsRowChanged(ByVal objRow As GridViewRow) As Boolean
        If objRow.RowType = DataControlRowType.DataRow Then

            If (Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryId")) And LocaleUtilitiesBLL.IsShowProjectForTimeOff) Or Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                Dim AccountProjectId As Integer
                Dim OldAccountProjectId As Integer
                If Me.GetCellValue(objRow, 1, "ddlAccountProjectId") <> "" Then
                    AccountProjectId = Me.GetCellValue(objRow, 1, "ddlAccountProjectId")
                End If
                If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountProjectId")) Then
                    OldAccountProjectId = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountProjectId")
                End If
                If OldAccountProjectId <> AccountProjectId Then
                    Return True
                End If
            End If

            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountProjectTaskId")) And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId") = "" Then
                    Return False
                End If
            End If
            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountProjectTaskId")) And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountProjectTaskId") <> Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId") Then
                    Return True
                End If
            End If

            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountCostCenterId")) And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountCostCenterId") <> Me.GetCellValue(objRow, 3, "ddlAccountCostCenterId") Then
                    Return True
                End If
            ElseIf IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountCostCenterId")) And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.GetCellValue(objRow, 3, "ddlAccountCostCenterId") <> "0" Then
                    Return True
                End If
            End If

            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountWorkTypeId")) And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountWorkTypeId") <> Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId") Then
                    Return True
                End If
            End If
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If DBUtilities.GetShowClockStartEnd = True And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("StartTime")) Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("StartTime"), Me.GetCellValue(objRow, 5, "StartTime")) Then
                        Return True
                    End If
                End If
                If DBUtilities.GetShowClockStartEnd = True And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("EndTime")) Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("EndTime"), Me.GetCellValue(objRow, 6, "EndTime")) Then
                        Return True
                    End If
                End If
            Else
                If DBUtilities.ShowClockStartEndEmployee = True And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("StartTime")) Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("StartTime"), Me.GetCellValue(objRow, 5, "StartTime")) Then
                        Return True
                    End If
                End If
                If DBUtilities.ShowClockStartEndEmployee = True And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("EndTime")) Then
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("EndTime"), Me.GetCellValue(objRow, 6, "EndTime")) Then
                        Return True
                    End If
                End If
            End If
            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("TotalTime")) Then
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    If CStr(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Hours")) <> Me.GetCellValue(objRow, 7, "TotalTime") Then
                        Return True
                    End If
                Else
                    If LocaleUtilitiesBLL.IsBothTimeAreDiffer(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("TotalTime"), Me.GetCellValue(objRow, 7, "TotalTime")) Then
                        Return True
                    End If
                End If
            End If

            Dim percentage As Double
            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Percentage")) Then
                percentage = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Percentage")
            End If
            If LocaleUtilitiesBLL.ShowPercentageInTimesheet() And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                If percentage <> IIf(Me.GetCellValue(objRow, 7, "Percentage") = "", 0, Me.GetCellValue(objRow, 7, "Percentage")) Then
                    Return True
                End If
            End If

            Dim strDescription As String
            If IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Description")) Then
                strDescription = ""
            Else
                strDescription = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Description")
            End If
            If strDescription <> Me.GetCellValue(objRow, 8, "Description") Then
                Return True
            End If

            If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountTimeOffTypeId")) And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "True" Then
                If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountTimeOffTypeId").ToString <> Me.GetCellValue(objRow, 2, "ddlTimeOffTypes") Then
                    Return True
                End If
            End If
            For n As Integer = 1 To 9
                If objRow.Cells.Count > (8 + n) Then
                    Dim strCustomField As String
                    If IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("CustomField" & n)) Then
                        strCustomField = ""
                    Else
                        strCustomField = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("CustomField" & n)
                    End If
                    If strCustomField <> Me.GetCellValueForCustomField(objRow, 8 + n, "CustomField" & n) Then
                        Return True
                    End If
                End If
            Next
        End If
        Return False
    End Function
    ''' <summary>
    ''' Save
    ''' </summary>
    ''' <param name="IsSubmitted"></param>
    ''' <remarks></remarks>
    Public Sub Save(ByVal IsSubmitted As Boolean, URL As String)
        Dim IsError As Boolean = False
        Try
            Dim objRow As GridViewRow
            For Each objRow In Me.BulkEditGridViewVB1.Rows
                If objRow.RowType = DataControlRowType.DataRow Then
                    If IsSubmitted <> True Then
                        LoggingBLL.WriteToLog("TimeEntryDayView: Function Save: Session-AccountEmployeeId=" & DBUtilities.GetSessionAccountEmployeeId & "Dropdown-AccountEmployeeId=" & ddlEmployee.SelectedValue)
                        UpdateDay(objRow)
                    Else
                        LoggingBLL.WriteToLog("TimeEntryDayView: Function Save: Session-AccountEmployeeId=" & DBUtilities.GetSessionAccountEmployeeId & "Dropdown-AccountEmployeeId=" & ddlEmployee.SelectedValue)
                        UpdateDay(objRow)
                    End If
                End If
            Next
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                ShowErrorMessage(Replace(Replace(Replace(ex.InnerException.Message, "'", ""), """", ""), vbCrLf, ""), URL)
            Else
                ShowErrorMessage(Replace(Replace(Replace(ex.Message, "'", ""), """", ""), vbCrLf, ""), URL)
            End If
            IsError = True
            LoggingBLL.WriteExceptionNoRaiseToLog("TimeEntry Day View Save():", ex)
            'Throw ex.InnerException
        End Try
        If Not IsError Then
            Response.Redirect(URL, False)
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
    ''' Update day
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <remarks></remarks>
    Public Sub UpdateDay(ByVal objrow As GridViewRow)
        If IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("AccountEmployeeTimeEntryId")) Or Me.ViewState("IsCopyFromDate") = "True" Then
            LoggingBLL.WriteToLog("TimeEntryDayView: Function UpdateDay: InsertRecord  AccountEmployeeTimeEntryId is null IsCopyFromDate=" & Me.ViewState("IsCopyFromDate"))
            Me.InsertRecord(objrow, dtAccountEmployeeTimeEntryPeriodId)
        ElseIf Me.IsRowChanged(objrow) Then
            LoggingBLL.WriteToLog("TimeEntryDayView: Function UpdateDay: UpdateRecord")
            Me.UpdateRecord(objrow, dtAccountEmployeeTimeEntryPeriodId)
        End If
    End Sub
    ''' <summary>
    ''' Check valid data available
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidDataAvailable(ByVal objrow As GridViewRow) As Boolean
        If Me.GetCellValue(objrow, 1, "ddlAccountProjectId") Is Nothing And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        If Me.GetCellValue(objrow, 2, "ddlAccountProjectTaskId") = "" And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        If Me.GetCellValue(objrow, 2, "ddlTimeOffTypes") Is Nothing And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then
            Return False
        End If
        If Me.GetCellValue(objrow, 7, "TotalTime") = "" And DBUtilities.IsTimeEntryHoursFormat = "Time" Or Me.GetCellValue(objrow, 7, "TotalTime") = "" And DBUtilities.IsTimeEntryHoursFormat = "Decimal" Or (Me.GetCellValue(objrow, 7, "TotalTime") = "" And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True") Then
            Return False
        End If
        If Me.GetCellValue(objrow, 7, "Percentage") = "" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        If Me.GetCellValue(objrow, 7, "TotalTime") = "" And DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Delete old day entries for new copy entries of specified AccountEmployeeId, TimeEntryDate
    ''' </summary> 
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="TimeEntryDate"></param>
    ''' <remarks></remarks>
    Public Sub DeleteOldDayEntriesForNewCopyEntries(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date)
        Dim dt As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = New AccountEmployeeTimeEntryBLL().GetAccountEmployeeTimeEntriesByDateForCopyTimeSheet(AccountEmployeeId, TimeEntryDate)
        Dim dr As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusRow
        Dim IsDeletedTimeEntryPeriod As Boolean = False
        Dim BLL As New AccountEmployeeTimeEntryBLL
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                IsDeletedTimeEntryPeriod = BLL.DeleteAccountEmployeeTimeEntry(dr.AccountEmployeeTimeEntryId, TimesheetPeriodType, AccountEmployeeId, dtStartDate, dtEndDate, dr.Item("AccountEmployeeTimeEntryApprovalProjectId"), dr.Item("AccountEmployeeTimeEntryPeriodId"))
            Next
            If IsDeletedTimeEntryPeriod Then
                Me.ViewState.Remove("dtAccountEmployeeTimeEntryPeriodId")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Delete row of specified object row, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub DeleteRow(ByVal objRow As GridViewRow, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        LoggingBLL.WriteToLog("TimeEntryDayView-DeleteRow: Start DeleteAccountEmployeeTimeEntry AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString)
        If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff") = True Then
            Dim BLL = New TimeOffAttachmentsBLL
            BLL.DeleteTimeOffAttachmentsFiles(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryId"))
        End If
        Call New AccountEmployeeTimeEntryBLL().DeleteAccountEmployeeTimeEntry(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryId"), TimesheetPeriodType, Me.ViewState("TimeEntryAccountEmployeeId"), dtStartDate, dtEndDate, IIf(IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId")), System.Guid.Empty, Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId")), AccountEmployeeTimeEntryPeriodId)
        LoggingBLL.WriteToLog("TimeEntryDayView-DeleteRow: End DeleteAccountEmployeeTimeEntry AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString)
    End Sub
    ''' <summary>
    ''' Insert record of specified object row, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub InsertRecord(ByVal objRow As GridViewRow, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        If Not IsValidDataAvailable(objRow) Then
            Return
        End If
        With Me.dsAccountEmployeeTimeEntry
            If Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId") <> "" And DBUtilities.GetShowProjectInTimesheet = False Then
                .InsertParameters("AccountProjectId").DefaultValue = IIf(Me.GetCellValue(objRow, 1, "ddlAccountProjectId") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId"), True), Me.GetCellValue(objRow, 1, "ddlAccountProjectId"))
            Else
                .InsertParameters("AccountProjectId").DefaultValue = Me.GetCellValue(objRow, 1, "ddlAccountProjectId")
            End If
            If Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId") <> "" And DBUtilities.GetShowClientInTimesheet = False Then
                .InsertParameters("AccountPartyId").DefaultValue = IIf(Me.GetCellValue(objRow, 0, "ddlAccountClientId") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId"), False), Me.GetCellValue(objRow, 0, "ddlAccountClientId"))
            Else
                .InsertParameters("AccountPartyId").DefaultValue = Me.GetCellValue(objRow, 0, "ddlAccountClientId")
            End If
            .InsertParameters("AccountProjectTaskId").DefaultValue = Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId")
            .InsertParameters("AccountCostCenterId").DefaultValue = Me.GetCellValue(objRow, 3, "ddlAccountCostCenterId")
            .InsertParameters("AccountWorkTypeId").DefaultValue = IIf(Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId") = "", GetStandardWorkType, Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId"))
            .InsertParameters("StartTime").DefaultValue = Me.GetCellValue(objRow, 5, "StartTime")
            .InsertParameters("EndTime").DefaultValue = Me.GetCellValue(objRow, 6, "EndTime")
            .InsertParameters("TotalTime").DefaultValue = IIf(Me.GetCellValue(objRow, 7, "TotalTime") <> "", Me.GetCellValue(objRow, 7, "TotalTime"), "0")
            .InsertParameters("Percentage").DefaultValue = Me.GetCellValue(objRow, 7, "Percentage")
            .InsertParameters("Description").DefaultValue = Me.GetCellValue(objRow, 8, "Description")
            .InsertParameters("TimesheetPeriodType").DefaultValue = TimesheetPeriodType
            .InsertParameters("PeriodStartDate").DefaultValue = dtStartDate
            .InsertParameters("PeriodEndDate").DefaultValue = dtEndDate
            .InsertParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodId.ToString
            .InsertParameters("IsTimeOff").DefaultValue = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff")
            .InsertParameters("AccountTimeOffTypeId").DefaultValue = Me.GetCellValue(objRow, 2, "ddlTimeOffTypes")
            .InsertParameters("AccountEmployeeTimeOffRequestId").DefaultValue = System.Guid.Empty.ToString
            If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff") = True Then
                .InsertParameters("Approved").DefaultValue = IIf(IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Approved")), False, Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Approved"))
            End If
            For n As Integer = 1 To 9
                If objRow.Cells.Count > (8 + n) Then
                    .InsertParameters("CustomField" & n).DefaultValue = Me.GetCellValueForCustomField(objRow, 8 + n, "CustomField" & n)
                End If
            Next
            .Insert()
        End With
    End Sub
    ''' <summary>
    ''' Update record of specified object row, AccountEmployeeTimeEntryPeriodId
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRecord(ByVal objRow As GridViewRow, ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        If (Me.GetCellValue(objRow, 7, "TotalTime") = "" And DBUtilities.IsTimeEntryHoursFormat = "Time") Or (Me.GetCellValue(objRow, 7, "TotalTime") = "" And DBUtilities.IsTimeEntryHoursFormat = "Decimal") Or (Me.GetCellValue(objRow, 7, "Percentage") = "" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex).Item("IsTimeOff").ToString = "False") Or (Me.GetCellValue(objRow, 7, "TotalTime") = "" And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex).Item("IsTimeOff").ToString = "True") Then
            Me.DeleteRow(objRow, AccountEmployeeTimeEntryPeriodId)
            Exit Sub
        End If
        With Me.dsAccountEmployeeTimeEntry
            .UpdateParameters("Original_AccountEmployeeTimeEntryId").DefaultValue = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryId")
            If Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId") <> "" And DBUtilities.GetShowProjectInTimesheet = False Then
                .UpdateParameters("AccountProjectId").DefaultValue = IIf(Me.GetCellValue(objRow, 1, "ddlAccountProjectId") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId"), True), Me.GetCellValue(objRow, 1, "ddlAccountProjectId"))
            Else
                .UpdateParameters("AccountProjectId").DefaultValue = Me.GetCellValue(objRow, 1, "ddlAccountProjectId")
            End If
            If Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId") <> "" And DBUtilities.GetShowClientInTimesheet = False Then
                .UpdateParameters("AccountPartyId").DefaultValue = IIf(Me.GetCellValue(objRow, 0, "ddlAccountClientId") = "", New AccountProjectTaskBLL().GetvueAccountProjectTaskByAccountProjectTaskId(Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId"), False), Me.GetCellValue(objRow, 0, "ddlAccountClientId"))
            Else
                .UpdateParameters("AccountPartyId").DefaultValue = Me.GetCellValue(objRow, 0, "ddlAccountClientId")
            End If
            .UpdateParameters("AccountProjectTaskId").DefaultValue = Me.GetCellValue(objRow, 2, "ddlAccountProjectTaskId")
            .UpdateParameters("AccountCostCenterId").DefaultValue = Me.GetCellValue(objRow, 3, "ddlAccountCostCenterId")
            .UpdateParameters("AccountWorkTypeId").DefaultValue = IIf(Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId") = "", GetStandardWorkType, Me.GetCellValue(objRow, 4, "ddlAccountWorkTypeId"))
            .UpdateParameters("StartTime").DefaultValue = Me.GetCellValue(objRow, 5, "StartTime")
            .UpdateParameters("EndTime").DefaultValue = Me.GetCellValue(objRow, 6, "EndTime")
            .UpdateParameters("TotalTime").DefaultValue = IIf(Me.GetCellValue(objRow, 7, "TotalTime") <> "", Me.GetCellValue(objRow, 7, "TotalTime"), "0")
            If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("TotalTime")) And Me.GetCellValue(objRow, 7, "TotalTime") = "" And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                .UpdateParameters("TotalTime").DefaultValue = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("TotalTime"))
            End If
            .UpdateParameters("Percentage").DefaultValue = Me.GetCellValue(objRow, 7, "Percentage")
            If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Percentage")) And Me.GetCellValue(objRow, 7, "Percentage") = "" And Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff").ToString = "False" Then
                .UpdateParameters("Percentage").DefaultValue = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Percentage")
            End If
            .UpdateParameters("Description").DefaultValue = Me.GetCellValue(objRow, 8, "Description")
            .UpdateParameters("TimesheetPeriodType").DefaultValue = TimesheetPeriodType
            .UpdateParameters("PeriodStartDate").DefaultValue = dtStartDate
            .UpdateParameters("PeriodEndDate").DefaultValue = dtEndDate
            .UpdateParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodId.ToString
            If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff") <> True Then
                If Me.GetCellValue(objRow, 1, "ddlAccountProjectId") = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountProjectId") Then
                    .UpdateParameters("AccountEmployeeTimeEntryApprovalProjectId").DefaultValue = IIf(IsDBNull(Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId").ToString), System.DBNull.Value, Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId").ToString)
                End If
            End If
            .UpdateParameters("IsTimeOff").DefaultValue = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff")
            .UpdateParameters("AccountTimeOffTypeId").DefaultValue = Me.GetCellValue(objRow, 2, "ddlTimeOffTypes")
            If Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("IsTimeOff") = True Then
                .UpdateParameters("Approved").DefaultValue = Me.BulkEditGridViewVB1.DataKeys(objRow.RowIndex)("Approved")
            End If
            For n As Integer = 1 To 9
                If objRow.Cells.Count > (8 + n) Then
                    .UpdateParameters("CustomField" & n).DefaultValue = Me.GetCellValueForCustomField(objRow, 8 + n, "CustomField" & n)
                End If
            Next
            .Update()
        End With
    End Sub
    ''' <summary>
    ''' Show for date of specified dtDate, CopyFromDate, IsCopyFromDate
    ''' </summary>
    ''' <param name="dtDate"></param>
    ''' <param name="CopyFromDate"></param>
    ''' <param name="IsCopyFromDate"></param>
    ''' <remarks></remarks>
    Public Sub ShowForDate(ByVal dtDate As Date, ByVal CopyFromDate As Date, ByVal IsCopyFromDate As Boolean)
        Me.TimeEntryDate = dtDate
        Me.ViewState.Add("TimeEntryDate", Me.TimeEntryDate)
        Me.ViewState.Add("IsCopyFromDate", IsCopyFromDate)
        Me.ViewState.Add("CopyFromDate", CopyFromDate)
        AddValuesInViewState()
        Me.SetSelectParameter(IsCopyFromDate)
    End Sub
    ''' <summary>
    ''' Add values in view state
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddValuesInViewState()
        Me.ViewState.Add("TimeEntryAccountEmployeeId", TimeEntryAccountEmployeeId)
        Me.ViewState.Add("EmployeeTimesheetPeriodType", EmployeeTimesheetPeriodType)
        Me.ViewState.Add("EmployeeWeekStartDay", EmployeeWeekStartDay)
        Me.ViewState.Add("EmployeeInitialDayOfFirstPeriod", EmployeeInitialDayOfFirstPeriod)
        Me.ViewState.Add("EmployeeInitialDayOfLastPeriod", EmployeeInitialDayOfLastPeriod)
        Me.ViewState.Add("EmployeeInitialDayOfTheMonth", EmployeeInitialDayOfTheMonth)
        Me.ViewState.Add("MinDayHours", MinDayHours)
        Me.ViewState.Add("MaxDayHours", MaxDayHours)
    End Sub
    ''' <summary>
    ''' Control account employee attendance list inserted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub CtlAccountEmployeeAttendanceList1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles CtlAccountEmployeeAttendanceList1.Inserted
        Session("TimeEntryDate") = Me.ViewState("TimeEntryDate")
        RaiseEvent AfterAttendanceUpdate()
        Me.BulkEditGridViewVB1.DataBind()
    End Sub
    ''' <summary>
    ''' Control account employee attendance list updated event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub CtlAccountEmployeeAttendanceList1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles CtlAccountEmployeeAttendanceList1.Updated
        Session("TimeEntryDate") = Me.ViewState("TimeEntryDate")
        RaiseEvent AfterAttendanceUpdate()
        Me.BulkEditGridViewVB1.DataBind()
    End Sub
    ''' <summary>
    ''' Refresh page
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshPage()
        Dim url As String = Me.Page.Request.RawUrl
        Response.Redirect(url, False)
    End Sub
    ''' <summary>
    ''' Bulk edit grid view row deleting event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BulkEditGridViewVB1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles BulkEditGridViewVB1.RowDeleting
        Dim AccountEmployeeTimeEntryApprovalProjectIdDataKeyValue As Guid = IIf(IsDBNull(Me.BulkEditGridViewVB1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId")), System.Guid.Empty, Me.BulkEditGridViewVB1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId"))
        Dim AccountEmployeeTimeEntryPeriodIdIdDataKeyValue As Guid = IIf(IsDBNull(Me.BulkEditGridViewVB1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryPeriodId")), System.Guid.Empty, Me.BulkEditGridViewVB1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
        Dim AccountEmployeeTimeEntry As Integer = Me.BulkEditGridViewVB1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryId")
        Dim TimeOffAttachmentsBLL = New TimeOffAttachmentsBLL
        TimeOffAttachmentsBLL.DeleteTimeOffAttachmentsFiles(AccountEmployeeTimeEntry)
        Call New AccountEmployeeTimeEntryBLL().DeleteAccountEmployeeTimeEntry(AccountEmployeeTimeEntry, TimesheetPeriodType, Me.ViewState("TimeEntryAccountEmployeeId"), dtStartDate, dtEndDate, AccountEmployeeTimeEntryApprovalProjectIdDataKeyValue, AccountEmployeeTimeEntryPeriodIdIdDataKeyValue)
        Me.RefreshPage()
    End Sub
    ''' <summary>
    ''' Button submit click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Me.dsAccountEmployeeTimeEntry.InsertParameters("TimeEntryDate").DefaultValue = Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue
        Me.dsAccountEmployeeTimeEntry.UpdateParameters("TimeEntryDate").DefaultValue = Me.dsAccountEmployeeTimeEntry.SelectParameters("TimeEntryDate").DefaultValue
        Me.dsAccountEmployeeTimeEntry.InsertParameters("Submitted").DefaultValue = True
        Me.dsAccountEmployeeTimeEntry.UpdateParameters("Submitted").DefaultValue = True
        Dim URL As String = "AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("TimeEntryDate")) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId")
        Me.Save(True, URL)
        'Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("TimeEntryDate")) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId"), False)
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
    ''' Show data for drop down list account cost center id of specified object row of grid view row
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <remarks></remarks>
    ''' <NONE> REMOVE
    Public Sub ShowDataForddlAccountCostCenterId(ByVal objrow As GridViewRow)
        If Not CType(objrow.Cells(2).FindControl("ddlAccountCostCenterId"), DropDownList) Is Nothing Then
            CType(objrow.Cells(2).FindControl("ddlAccountCostCenterId"), DropDownList).Items.Clear()
            Dim item As New System.Web.UI.WebControls.ListItem
            item.Text = "<None>"
            item.Value = "0"
            item.Enabled = False
            CType(objrow.Cells(2).FindControl("ddlAccountCostCenterId"), DropDownList).Items.Add(item)
            CType(objrow.Cells(2).FindControl("ddlAccountCostCenterId"), DropDownList).DataBind()
        End If
    End Sub
    ''' <summary>
    ''' Hide columns in grid view
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HideColumnsInGridView()
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = False And Me.BulkEditGridViewVB1.Columns.Count = 11 Then
                Me.BulkEditGridViewVB1.Columns.RemoveAt(4)
                Me.BulkEditGridViewVB1.Columns.RemoveAt(4)
            End If
        Else
            If DBUtilities.ShowClockStartEndEmployee = False And Me.BulkEditGridViewVB1.Columns.Count = 11 Then
                Me.BulkEditGridViewVB1.Columns.RemoveAt(4)
                Me.BulkEditGridViewVB1.Columns.RemoveAt(4)
            End If
        End If
        If DBUtilities.IsShowCostCenterInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 11 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(2)
        ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 9 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(2)
        ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 8 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(2)
        End If
        If DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 11 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(3)
        ElseIf DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 10 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(2)
        ElseIf DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 9 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(3)
        ElseIf DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = 8 Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(2)
        End If
    End Sub
    ''' <summary>
    ''' Hide columns in grid view by client
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HideColumnsInGridViewByClient()
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.GetShowClockStartEnd = False And Me.BulkEditGridViewVB1.Columns.Count = (12 + TotalCustomFields) Then
                Me.BulkEditGridViewVB1.Columns.RemoveAt(5)
                Me.BulkEditGridViewVB1.Columns.RemoveAt(5)
            End If
        Else
            If DBUtilities.ShowClockStartEndEmployee = False And Me.BulkEditGridViewVB1.Columns.Count = (12 + TotalCustomFields) Then
                Me.BulkEditGridViewVB1.Columns.RemoveAt(5)
                Me.BulkEditGridViewVB1.Columns.RemoveAt(5)
            End If
        End If
        
        If DBUtilities.IsShowCostCenterInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (12 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(3)
        ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (10 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(3)
        ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (9 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(2)
        End If
        If DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (12 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(4)
        ElseIf DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (11 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(3)
        ElseIf DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (10 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(4)
        ElseIf DBUtilities.IsShowWorkTypeInTimeSheet = False And Me.BulkEditGridViewVB1.Columns.Count = (9 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(3)
        End If
        If DBUtilities.GetShowClientInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (12 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(0)
        ElseIf DBUtilities.GetShowClientInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (11 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(0)
        ElseIf DBUtilities.GetShowClientInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (10 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(0)
        ElseIf DBUtilities.GetShowClientInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (9 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(0)
        ElseIf DBUtilities.GetShowClientInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (8 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(0)
        End If
        If DBUtilities.GetShowProjectInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (12 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(1)
        ElseIf DBUtilities.GetShowProjectInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (11 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(1)
        ElseIf DBUtilities.GetShowProjectInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (10 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(1)
        ElseIf DBUtilities.GetShowProjectInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (9 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(1)
        ElseIf DBUtilities.GetShowProjectInTimesheet = False And Me.BulkEditGridViewVB1.Columns.Count = (8 + TotalCustomFields) Then
            Me.BulkEditGridViewVB1.Columns.RemoveAt(1)
        End If
        WorkingDays = DateTimeUtilities.GetWorkingDays(TimeEntryAccountEmployeeId, Me.txtTimeEntryDate.SelectedDate, dtStartDate, dtEndDate)
        If WorkingDays.IndexOf(Me.txtTimeEntryDate.SelectedDate) = -1 Then
            DisableControlsInNonWorkingDay()
        End If
    End Sub
    ''' <summary>
    ''' Disable controls in non working day
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisableControlsInNonWorkingDay()
        BulkEditGridViewVB1.Visible = False
        btnSave.Visible = False
        CopyFromCalendarPopup.Visible = False
        lblPermissionMessage.Visible = True
        lblCopyFrom.Visible = False
        btnCopy.Visible = False
        btnCopyActivities.Visible = False
    End Sub
    ''' <summary>
    ''' Show time entry status of specified row of grid view row
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Sub ShowTimeEntryStatus(ByVal row As GridViewRow)
        Dim i As Integer = Me.BulkEditGridViewVB1.Columns.Count - (1 + TotalCustomFields)
        If Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(row.RowIndex)("AccountEmployeeTimeEntryId")) Then
            AccountEmployeeTimeEntryBLL.SetSubmittedStatus("imgStatus", row, i, "Approved", "Submitted", "Rejected", Me.BulkEditGridViewVB1, i)
        End If
    End Sub
    ''' <summary>
    ''' Text time entry date changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub txtTimeEntryDate_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeEntryDate.DateChanged
        Me.RefreshDayView(True)
    End Sub
    ''' <summary>
    ''' Refresh day view
    ''' </summary>
    ''' <param name="bDateSelect"></param>
    ''' <remarks></remarks>




    Public Sub RefreshDayView(Optional ByVal bDateSelect As Boolean = False)
        If bDateSelect = False Then
            Me.lnkTimesheetPeriodList.NavigateUrl = "~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=DayView"
            Dim CopyFromStartDate As Date
            Dim IsCopyFrom As Boolean = False
            If Not Request.QueryString("CopyDate") Is Nothing Then
                CopyFromStartDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("CopyDate"))
                IsCopyFrom = True
            End If
            Me.ShowForDate(Me.txtTimeEntryDate.SelectedDate.Date, CopyFromStartDate, IsCopyFrom)
        ElseIf Me.Request.QueryString("StartDate") Is Nothing Then
            Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?Mode=Week&StartDate=" & Me.ViewState("OriginalTimeEntryDate") & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
        Else
            Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.ViewState("OriginalTimeEntryDate")) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
        End If
    End Sub
    ''' <summary>
    ''' Image button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If Not Me.Request.QueryString("StartDate") Is Nothing Then
            StartDate = LocaleUtilitiesBLL.ConvertBaseDateStringToDate(Me.Request.QueryString("StartDate"))
        Else
            StartDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        End If
        Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(StartDate.AddDays(1)) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId"), False)
    End Sub
    ''' <summary>
    ''' Image button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If Not Me.Request.QueryString("StartDate") Is Nothing Then
            StartDate = LocaleUtilitiesBLL.ConvertBaseDateStringToDate(Me.Request.QueryString("StartDate"))
        Else
            StartDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        End If
        Response.Redirect("AccountEmployeeTimeEntryDayView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(StartDate.AddDays(-1)) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId"), False)
    End Sub
    ''' <summary>
    ''' Button copy click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Response.Redirect(GetCopyURL(False), False)
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
        MyCascading = CType(objRow.FindControl("ddlAccountProjectIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
        If DBUtilities.GetShowClientInTimesheet = False Then
            MyCascading.ParentControlID = Nothing
        Else
            MyCascading.ParentControlID = "ddlAccountClientId"
        End If
        MyCascading.Category = Me.ViewState("TimeEntryAccountEmployeeId") & "," & AccountProjectId & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetSessionAccountId & "," & 0 & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetShowProjectInTimesheet
    End Sub
    ''' <summary>
    ''' Button copy activities click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnCopyActivities_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyActivities.Click
        Response.Redirect(GetCopyURL(True), False)
    End Sub
    ''' <summary>
    ''' Get copy url of specified IsCopyActivities
    ''' </summary>
    ''' <param name="IsCopyActivities"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCopyURL(ByVal IsCopyActivities As Boolean) As String
        If IsCopyActivities Then
            Return "AccountEmployeeTimeEntryDayView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&CopyDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.CopyFromCalendarPopup.PostedDate) & "&IsCopyActivities=True" & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId")
        End If
        Return "AccountEmployeeTimeEntryDayView.aspx?Mode=Week&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&CopyDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.CopyFromCalendarPopup.PostedDate) & "&AccountEmployeeId=" & Me.ViewState("TimeEntryAccountEmployeeId")
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
    Public Sub SetTotalTimeLabelValue(ColumnNo As Integer)
        'Me.BulkEditGridViewVB1.Columns(ColumnNo).HeaderText = ResourceHelper.GetFromResource("TotalTime")
        If (DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet = True) Or (DBUtilities.IsTimeEntryHoursFormat = "Time" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True) Or (DBUtilities.IsTimeEntryHoursFormat = "Decimal" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True) Then
            Me.BulkEditGridViewVB1.Columns(ColumnNo).HeaderText = ResourceHelper.GetFromResource("TotalTime") & "/" & "<br/>" & "Task%"
        ElseIf DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Then
            Me.BulkEditGridViewVB1.Columns(ColumnNo).HeaderText = "Percentage"
        Else
            Me.BulkEditGridViewVB1.Columns(ColumnNo).HeaderText = ResourceHelper.GetFromResource("TotalTime")
        End If
    End Sub
    ''' <summary>
    ''' Set resource in day view
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetResourceInDayView()
        Me.lblCurrenctdate2.Text = ResourceHelper.GetFromResource("Time Entry Date:")
        Me.Label3.Text = ResourceHelper.GetFromResource("Timesheet Status:")
        If DBUtilities.GetClockStartEndBy = "Account" Then
            If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(7)
                Me.BulkEditGridViewVB1.Columns(8).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.GetShowClockStartEnd = True And DBUtilities.IsShowWorkTypeInTimeSheet = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(6)
                Me.BulkEditGridViewVB1.Columns(7).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(6)
                Me.BulkEditGridViewVB1.Columns(7).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(5)
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                SetTotalTimeLabelValue(3)
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                SetTotalTimeLabelValue(2)
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(3)
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                SetTotalTimeLabelValue(3)
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("EndTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("TotalTime")
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(5)
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(5)
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(6)
                Me.BulkEditGridViewVB1.Columns(7).HeaderText = ResourceHelper.GetFromResource("Description")
            End If
        Else
            If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(7)
                Me.BulkEditGridViewVB1.Columns(8).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.ShowClockStartEndEmployee = True And DBUtilities.IsShowWorkTypeInTimeSheet = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(6)
                Me.BulkEditGridViewVB1.Columns(7).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(6)
                Me.BulkEditGridViewVB1.Columns(7).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(5)
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                SetTotalTimeLabelValue(3)
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                SetTotalTimeLabelValue(2)
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(3)
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                SetTotalTimeLabelValue(3)
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(4)
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("EndTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("TotalTime")
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(5)
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Cost Center")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(5)
                Me.BulkEditGridViewVB1.Columns(6).HeaderText = ResourceHelper.GetFromResource("Description")
            ElseIf DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.GetShowClientInTimesheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = True Then
                Me.BulkEditGridViewVB1.Columns(0).HeaderText = ResourceHelper.GetFromResource("Client")
                Me.BulkEditGridViewVB1.Columns(1).HeaderText = ResourceHelper.GetFromResource("Project")
                Me.BulkEditGridViewVB1.Columns(2).HeaderText = ResourceHelper.GetFromResource("Project Task")
                Me.BulkEditGridViewVB1.Columns(3).HeaderText = ResourceHelper.GetFromResource("Work Type")
                Me.BulkEditGridViewVB1.Columns(4).HeaderText = ResourceHelper.GetFromResource("StartTime")
                Me.BulkEditGridViewVB1.Columns(5).HeaderText = ResourceHelper.GetFromResource("EndTime")
                SetTotalTimeLabelValue(6)
                Me.BulkEditGridViewVB1.Columns(7).HeaderText = ResourceHelper.GetFromResource("Description")
            End If
        End If
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
            objDropdown = CType(Row.Cells(1).FindControl("ddlAccountClientId"), DropDownList)
            'If Not objDropdown Is Nothing And Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then
            Dim dtvueProjects As AccountClient.TimeEntryClientDataTable = New AccountPartyBLL().GetAccountPartiesForTimeEntryByAccountEmployeeId(ddlEmployee.SelectedValue, IIf(Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")), DataBinder.Eval(Row.DataItem, "AccountClientId"), 0))
            Dim drvueProjects As AccountClient.TimeEntryClientRow
            If dtvueProjects.Rows.Count > 0 Then
                drvueProjects = dtvueProjects.Rows(0)
                If DBUtilities.HideProjectFromApplication = True Then
                    'If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") = "Yes" Then
                    Dim dtCLient As TimeLiveDataSet.AccountPartyDataTable = New AccountPartyBLL().GetAccountPartiesByAccountIdAndAccountPartyId(DBUtilities.GetSessionAccountId, IIf(Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")), DataBinder.Eval(Row.DataItem, "AccountClientId"), 0))
                    Dim drClient As TimeLiveDataSet.AccountPartyRow
                    If dtCLient.Rows.Count > 0 Then
                        drClient = dtCLient.Rows(0)
                    End If
                    ''objDropdown = CType(Row.Cells(1).FindControl("ddlAccountClientId"), DropDownList)
                    If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then
                        dataValue = DataBinder.Eval(Row.DataItem, "AccountClientId")
                        objDropdown.SelectedValue = dataValue
                    End If
                    objDropdown.DataSource = dtCLient
                    objDropdown.DataBind()
                    'End If
                Else
                    ''objDropdown = CType(Row.Cells(1).FindControl("ddlAccountClientId"), DropDownList)
                    If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then
                        dataValue = DataBinder.Eval(Row.DataItem, "AccountClientId")
                        objDropdown.SelectedValue = dataValue
                    End If
                    objDropdown.DataSource = dtvueProjects
                    objDropdown.DataBind()
                End If
            End If
            ' ''objDropdown = CType(Row.Cells(1).FindControl("ddlAccountClientId"), DropDownList)
            ' ''If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then

            ' ''    objDropdown.SelectedValue = DataBinder.Eval(Row.DataItem, "AccountClientId")
            ' ''End If
            ' ''objDropdown.DataSource = dtvueProjects
            ' ''objDropdown.DataBind()
            'End If
            If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                UIUtilities.MakeDropdownReadonly(objDropdown)
            End If

            If Not Row.Cells(1).FindControl("ddlAccountClientId") Is Nothing And TotalCustomFields <> 0 Then
                'CType(Row.Cells(1).FindControl("ddlAccountClientId"), DropDownList).Width = 150
            End If
            'ElseIf DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" And DBUtilities.GetShowClientInTimesheet = True Then
            '    CType(Row.Cells(1).FindControl("ddlAccountClientId"), DropDownList).Visible = False
        End If
    End Sub
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
        objDropdown = CType(Row.Cells(1).FindControl("ddlAccountProjectId"), DropDownList)
        dsObject = CType(Row.Cells(1).FindControl("dsAccountProjectsObject"), ObjectDataSource)
        If Not objDropdown Is Nothing And Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectId")) Then
            dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectId")
            dsObject.SelectParameters("AccountProjectId").DefaultValue = dataValue
            objDropdown.SelectedValue = dataValue
            If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                UIUtilities.MakeDropdownReadonly(objDropdown)
            End If
            MyCascading = CType(Row.Cells(1).FindControl("ddlAccountProjectIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.SelectedValue = dataValue
            MyCascading.Category = Me.ViewState("TimeEntryAccountEmployeeId") & "," & dataValue & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountClientId") & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType
        End If
        If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
            If LocaleUtilitiesBLL.IsShowProjectForTimeOff = False Then
                objDropdown.Visible = False
            Else
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Or Not IsDBNull(Me.BulkEditGridViewVB1.DataKeys(Row.RowIndex)("AccountEmployeeTimeOffRequestId")) Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If
            End If
            CType(Row.Cells(1).FindControl("lblTimeOff"), Label).Visible = True
            CType(Row.Cells(1).FindControl("lblTimeOff"), Label).Text = ResourceHelper.GetFromResource("Time Off")
            CType(Row.Cells(1).FindControl("lblTimeOff"), Label).Font.Bold = True

            MyCascading = CType(Row.Cells(1).FindControl("ddlAccountProjectIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
            MyCascading.ContextKey = "isTimeOff"
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
        objDropdown = CType(Row.Cells(2).FindControl("ddlAccountProjectTaskId"), DropDownList)
        dsObject = CType(Row.Cells(1).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")) Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")
                objDropdown.SelectedValue = dataValue
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If
                MyCascading = CType(Row.Cells(2).FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
                MyCascading.SelectedValue = dataValue
                MyCascading.Category = Me.ViewState("TimeEntryAccountEmployeeId") & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & dataValue & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountProjectId") & "," & DBUtilities.GetShowAdditionalTaskInformationType
                objDropdown.SelectedValue = dataValue
            End If
            If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
                objDropdown.Visible = False
                CType(Row.Cells(1).FindControl("ddlTimeOffTypes"), DropDownList).Visible = True
                If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId")) Then
                    dataValue = DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId").ToString
                    Dim category = "isRequired"
                    If IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                        category = "notRequire"
                        CType(Row.Cells(1).FindControl("linkTimeOffAttachment"), HyperLink).Visible = True
                        CType(Row.Cells(1).FindControl("linkTimeOffAttachment"), HyperLink).NavigateUrl = "~/Employee/TimeOffAttachments.aspx?ReadOnly=false&TimeEntry=" & DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId")
                    End If
                    CType(Row.Cells(1).FindControl("dsTimeOffTypeObject"), ObjectDataSource).SelectParameters("AccountTimeOffTypeId").DefaultValue = DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId").ToString
                    CType(Row.Cells(1).FindControl("ddlTimeOffTypes"), DropDownList).SelectedValue = DataBinder.Eval(Row.DataItem, "AccountTimeOffTypeId").ToString
                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                        UIUtilities.MakeDropdownReadonly(CType(Row.Cells(1).FindControl("ddlTimeOffTypes"), DropDownList))
                    End If
                    MyCascading = CType(Row.Cells(1).FindControl("TT"), AjaxControlToolkit.CascadingDropDown)
                    MyCascading.SelectedValue = dataValue
                    MyCascading.Category = category
                End If
                If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                    UIUtilities.MakeDropdownReadonly(CType(Row.Cells(1).FindControl("ddlTimeOffTypes"), DropDownList))
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' Set cost center value on row data bound of specified objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary>
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetCostCenterValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(3).FindControl("ddlAccountCostCenterId"), DropDownList)
        dsObject = CType(Row.Cells(3).FindControl("dsAccountCostCenterObject"), ObjectDataSource)
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
        objDropdown = CType(Row.Cells(4).FindControl("ddlAccountWorkTypeId"), DropDownList)
        dsObject = CType(Row.Cells(4).FindControl("dsAccountWorkTypeObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" Then
                objDropdown.Visible = False
            ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountWorkTypeId")) Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountWorkTypeId")
                dsObject.SelectParameters("AccountWorkTypeId").DefaultValue = dataValue
                objDropdown.SelectedValue = dataValue
                objDropdown.DataBind()
                If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                    UIUtilities.MakeDropdownReadonly(objDropdown)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set time values on row data bound
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetTimeValuesOnRowDataBound(ByVal Row As GridViewRow)
        If Me.Request.QueryString("IsCopyActivities") Is Nothing Then
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If DBUtilities.GetShowClockStartEnd = True And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False" Then
                    If DBUtilities.IsNotSupportedCultureFormats <> True Then
                        CType(Row.FindControl("StartTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime"))
                        CType(Row.FindControl("EndTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime"))
                    Else
                        If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                            If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime")) <> "" Then
                                CType(Row.FindControl("StartTime"), TextBox).Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "StartTime"))
                            End If
                            If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime")) <> "" Then
                                CType(Row.FindControl("EndTime"), TextBox).Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "EndTime"))
                            End If
                        Else
                            CType(Row.FindControl("StartTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime"))
                            CType(Row.FindControl("EndTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime"))
                        End If
                    End If
                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                        UIUtilities.MakeTextboxReadonly(CType(Row.FindControl("StartTime"), TextBox))
                    End If
                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                        UIUtilities.MakeTextboxReadonly(CType(Row.FindControl("EndTime"), TextBox))
                    End If
                End If
            Else
                If DBUtilities.ShowClockStartEndEmployee = True And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False" Then
                    If DBUtilities.IsNotSupportedCultureFormats <> True Then
                        CType(Row.FindControl("StartTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime"))
                        CType(Row.FindControl("EndTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime"))
                    Else
                        If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = True Then
                            If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime")) <> "" Then
                                CType(Row.FindControl("StartTime"), TextBox).Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "StartTime"))
                            End If
                            If LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime")) <> "" Then
                                CType(Row.FindControl("EndTime"), TextBox).Text = DBUtilities.GetTimeFromDateTimeInUSCulture(DataBinder.Eval(Row.DataItem, "EndTime"))
                            End If
                        Else
                            CType(Row.FindControl("StartTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "StartTime"))
                            CType(Row.FindControl("EndTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(Row.DataItem, "EndTime"))
                        End If
                    End If
                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                        UIUtilities.MakeTextboxReadonly(CType(Row.FindControl("StartTime"), TextBox))
                    End If
                    If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                        UIUtilities.MakeTextboxReadonly(CType(Row.FindControl("EndTime"), TextBox))
                    End If
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "TotalTime")) And DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                CType(Row.FindControl("TotalTime"), TextBox).Text = Format(DataBinder.Eval(Row.DataItem, "Hours"), "00.00")
                TotalHours = TotalHours + DataBinder.Eval(Row.DataItem, "Hours")
            ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, "TotalTime")) Then
                If DBUtilities.IsNotSupportedCultureFormats = True Then
                    CType(Row.FindControl("TotalTime"), TextBox).Text = DBUtilities.GetDateTimeOfMinutesAsString(DBUtilities.GetMinutesOfTime(DataBinder.Eval(Row.DataItem, "TotalTime")))
                Else
                    CType(Row.FindControl("TotalTime"), TextBox).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(DataBinder.Eval(Row.DataItem, "TotalTime"))
                End If
                TotalTime = TotalTime + DBUtilities.GetMinutesOfTime(CType(DataBinder.Eval(Row.DataItem, "TotalTime"), Date))
            End If
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "Percentage")) And LocaleUtilitiesBLL.ShowPercentageInTimesheet() And DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "False" Then
                CType(Row.FindControl("Percentage"), TextBox).Text = DataBinder.Eval(Row.DataItem, "Percentage")
                Percentage = Percentage + DataBinder.Eval(Row.DataItem, "Percentage")
            End If
            If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
                UIUtilities.MakeTextboxReadonly(CType(Row.FindControl("TotalTime"), TextBox))
            End If
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                    CType(Row.FindControl("TotalTime"), TextBox).ReadOnly = True
                    If DBUtilities.GetShowClockStartEnd = True Then
                        CType(Row.FindControl("StartTime"), TextBox).Visible = False
                        CType(Row.FindControl("EndTime"), TextBox).Visible = False
                    End If
                ElseIf DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" And DBUtilities.GetShowClockStartEnd = True Then
                    CType(Row.FindControl("StartTime"), TextBox).Visible = False
                    CType(Row.FindControl("EndTime"), TextBox).Visible = False
                End If
            Else
                If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
                    CType(Row.FindControl("TotalTime"), TextBox).ReadOnly = True
                    If DBUtilities.ShowClockStartEndEmployee = True Then
                        CType(Row.FindControl("StartTime"), TextBox).Visible = False
                        CType(Row.FindControl("EndTime"), TextBox).Visible = False
                    End If
                ElseIf DataBinder.Eval(Row.DataItem, "IsTimeOff").ToString = "True" And DBUtilities.ShowClockStartEndEmployee = True Then
                    CType(Row.FindControl("StartTime"), TextBox).Visible = False
                    CType(Row.FindControl("EndTime"), TextBox).Visible = False
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set description value on row data bound
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetDescriptionValueOnRowDataBound(ByVal Row As GridViewRow)
        If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Or Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
            UIUtilities.MakeTextboxReadonly(CType(Row.FindControl("Description"), TextBox))
            For n As Integer = 1 To 9
                DisableCustomFields(Row.FindControl("CustomField" & n))
            Next
        End If
        If Not Me.Request.QueryString("IsCopyActivities") Is Nothing Then
            CType(Row.FindControl("Description"), TextBox).Text = ""
        End If
        For n As Integer = 1 To 9
            SetCellValue(Row.FindControl("CustomField" & n), DataBinder.Eval(Row.DataItem, "CustomField" & n), DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId"), Me.Request.QueryString("IsCopyActivities"))
        Next
    End Sub
    ''' <summary>
    ''' Set sum time value on row data bound
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetSumTimeValueOnRowDataBound(ByVal Row As GridViewRow)
        If Me.Request.QueryString("IsCopyActivities") Is Nothing Then
            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                CType(Row.Cells(6 - SubtractColumn()).FindControl("sumtime"), TextBox).Text = Format(TotalHours, "00.00")
            Else
                CType(Row.Cells(6 - SubtractColumn()).FindControl("sumtime"), TextBox).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime)
            End If
            If DBUtilities.GetClockStartEndBy = "Account" Then
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And TotalCustomFields = 0 And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                    CType(Row.Cells(6 - SubtractColumn()).FindControl("sumtime"), TextBox).Width = Unit.Percentage(80)
                End If
            Else
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And TotalCustomFields = 0 And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                    CType(Row.Cells(6 - SubtractColumn()).FindControl("sumtime"), TextBox).Width = Unit.Percentage(80)
                End If
            End If
            If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True Then
                CType(Row.Cells(6 - SubtractColumn()).FindControl("sumpercent"), TextBox).Text = Percentage & "%"
                If DBUtilities.GetClockStartEndBy = "Account" Then
                    If TotalCustomFields = 0 And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                        CType(Row.Cells(6 - SubtractColumn()).FindControl("sumPercent"), TextBox).Width = Unit.Percentage(80)
                    End If
                Else
                    If TotalCustomFields = 0 And DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                        CType(Row.Cells(6 - SubtractColumn()).FindControl("sumPercent"), TextBox).Width = Unit.Percentage(80)
                    End If
                End If
            End If
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.IsShowTimeOffInTimesheet = False Then
                    CType(Row.Cells(6 - SubtractColumn()).FindControl("sumtime"), TextBox).Visible = False
                End If
                If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
                    CType(Row.Cells(6 - SubtractColumn()).FindControl("sumPercent"), TextBox).Visible = False
                End If
            End If
    End Sub
    ''' <summary>
    ''' Set column values on row data bound
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetColumnValuesOnRowDataBound(ByVal Row As GridViewRow)
        If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeEntryId")) And Me.ViewState("IsCopyFromDate") = "False" And IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
            Dim i As Integer = Me.BulkEditGridViewVB1.Columns.Count - (2 + TotalCustomFields)
            Me.BulkEditGridViewVB1.Columns(i).Visible = True
            CType(Row.FindControl("btnDelete"), ImageButton).Visible = True
            CType(Row.FindControl("btnDelete"), ImageButton).Enabled = AccountEmployeeTimeEntryBLL.DoUnlock(Row, "btnDelete")
        ElseIf IsDBNull(DataBinder.Eval(Row.DataItem, "AccountEmployeeTimeOffRequestId")) Then
            CType(Row.FindControl("btnDelete"), ImageButton).Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' Set row data bound in day view data row of specified objDropdown, dsObject, dataValue, MyCascading, Row
    ''' </summary>
    ''' <param name="objDropdown"></param>
    ''' <param name="dsObject"></param>
    ''' <param name="dataValue"></param>
    ''' <param name="MyCascading"></param>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetRowDataBoundInDayViewDataRow(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        If Me.ViewState("IsCopyFromDate") = "False" Then
            ShowTimeEntryStatus(Row)
        End If
        If AccountEmployeeTimeEntryBLL.DoUnlock(Row) = False And Me.ViewState("IsCopyFromDate") = "False" Then
            btnCopy.Enabled = False
            btnCopyActivities.Enabled = False
        End If
        Me.SetClientValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetProjectValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetTaskValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetTimeValuesOnRowDataBound(Row)
        Me.SetCostCenterValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetWorkTypeValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, Row)
        Me.SetDescriptionValueOnRowDataBound(Row)
        Me.SetColumnValuesOnRowDataBound(Row)
    End Sub
    ''' <summary>
    ''' Set row data bound in day view footer row
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Public Sub SetRowDataBoundInDayViewFooterRow(ByVal Row As GridViewRow)
        Me.SetSumTimeValueOnRowDataBound(Row)
    End Sub
    ''' <summary>
    ''' Page unload event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

    End Sub
    ''' <summary>
    ''' Set grid column span for time off
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGridColumnSpanForTimeOff()
        For rowIndex As Integer = 0 To BulkEditGridViewVB1.Rows.Count - 1
            Dim gvRow As GridViewRow = BulkEditGridViewVB1.Rows(rowIndex)
            If Me.BulkEditGridViewVB1.DataKeys(gvRow.RowIndex)("IsTimeOff").ToString = "True" Then
                For cellCount As Integer = 0 To gvRow.Cells.Count - 1
                    If DBUtilities.GetShowClientInTimesheet = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Client") Then
                        'gvRow.Cells(cellCount).ColumnSpan = 2
                        'gvRow.Cells(cellCount).FindControl("lblTimeTypesClient").Visible = True
                        'gvRow.Cells(cellCount + 1).Visible = False
                        ' gvRow.Cells(cellCount).HorizontalAlign = HorizontalAlign.Left
                    End If
                    If cellCount = 1 Then
                        gvRow.Cells(cellCount).HorizontalAlign = HorizontalAlign.Left
                    End If
                    If DBUtilities.GetClockStartEndBy = "Account" Then
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 2
                            gvRow.Cells(cellCount + 1).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 4
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                            gvRow.Cells(cellCount + 3).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 2
                            gvRow.Cells(cellCount + 1).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 4
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                            gvRow.Cells(cellCount + 3).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 3
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 5
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                            gvRow.Cells(cellCount + 3).Visible = False
                            gvRow.Cells(cellCount + 4).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 3
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                        End If
                    Else
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 2
                            gvRow.Cells(cellCount + 1).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 4
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                            gvRow.Cells(cellCount + 3).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 2
                            gvRow.Cells(cellCount + 1).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 4
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                            gvRow.Cells(cellCount + 3).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 3
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 5
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                            gvRow.Cells(cellCount + 3).Visible = False
                            gvRow.Cells(cellCount + 4).Visible = False
                        End If
                        If DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True And BulkEditGridViewVB1.Columns.Item(cellCount).HeaderText = ResourceHelper.GetFromResource("Project Task") Then
                            gvRow.Cells(cellCount).ColumnSpan = 3
                            gvRow.Cells(cellCount + 1).Visible = False
                            gvRow.Cells(cellCount + 2).Visible = False
                        End If
                    End If
                Next
            End If
        Next
        SetProjectWidthForTimeOff()
    End Sub
    ''' <summary>
    ''' Set project width for time off
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetProjectWidthForTimeOff()
        Dim browser As System.Web.HttpBrowserCapabilities = System.Web.HttpContext.Current.Request.Browser
        For Each objrow As GridViewRow In Me.BulkEditGridViewVB1.Rows
            If objrow.RowType = DataControlRowType.DataRow Then
                If Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "True" Then
                    CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Percentage(85)
                ElseIf Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                    CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Pixel(400)
                    CType(objrow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Width = Unit.Pixel(400)
                End If

                If DBUtilities.GetClockStartEndBy = "Account" Then
                    If DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then
                        If TotalCustomFields = 0 And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Width = Unit.Percentage(100)
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Percentage(100)
                            Me.BulkEditGridViewVB1.Columns(3).ControlStyle.Width = Unit.Percentage(93.5)
                            Me.BulkEditGridViewVB1.Width = Unit.Percentage(98)
                        End If
                    
                If TotalCustomFields = 0 Then
                    CType(objrow.Cells(1).FindControl("TotalTime"), TextBox).Width = Unit.Percentage(80)
                End If
                    End If
                Else
                    If DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False Then
                        If TotalCustomFields = 0 And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Width = Unit.Percentage(100)
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Percentage(100)
                            Me.BulkEditGridViewVB1.Columns(3).ControlStyle.Width = Unit.Percentage(93.5)
                            Me.BulkEditGridViewVB1.Width = Unit.Percentage(98)
                        End If

                        If TotalCustomFields = 0 Then
                            CType(objrow.Cells(1).FindControl("TotalTime"), TextBox).Width = Unit.Percentage(80)
                        End If
                    End If
                End If
                If DBUtilities.GetClockStartEndBy = "Account" Then
                    If (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = True) _
                        Or (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False) _
                        Or (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False) Then
                        If Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Width = Unit.Percentage(100)
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Percentage(100)
                        End If
                        'Me.BulkEditGridViewVB1.Columns(4).ControlStyle.Width = Unit.Percentage(90)
                    End If
                    If (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.GetShowClockStartEnd = False) And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                        CType(objrow.Cells(4).FindControl("ddlAccountWorkTypeId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                    If (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False) And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                        CType(objrow.Cells(3).FindControl("ddlAccountCostCenterId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                Else
                    If (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = True) _
                       Or (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False) _
                       Or (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False) Then
                        If Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Width = Unit.Percentage(100)
                            CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Percentage(100)
                        End If
                        'Me.BulkEditGridViewVB1.Columns(4).ControlStyle.Width = Unit.Percentage(90)
                    End If
                    If (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = True And DBUtilities.ShowClockStartEndEmployee = False) And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                        CType(objrow.Cells(4).FindControl("ddlAccountWorkTypeId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                    If (DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = True And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.ShowClockStartEndEmployee = False) And Me.BulkEditGridViewVB1.DataKeys(objrow.RowIndex)("IsTimeOff").ToString = "False" Then
                        CType(objrow.Cells(3).FindControl("ddlAccountCostCenterId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                End If
                'If Not System.Configuration.ConfigurationManager.AppSettings("TS_RESIZE") Is Nothing Then
                If LocaleUtilitiesBLL.EnableAutoResizeTimesheet Then
                    If Not CType(objrow.Cells(0).FindControl("ddlAccountClientId"), DropDownList) Is Nothing Then
                        CType(objrow.Cells(0).FindControl("ddlAccountClientId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                    CType(objrow.Cells(2).FindControl("ddlAccountProjectTaskId"), DropDownList).Width = Unit.Percentage(100)
                    CType(objrow.Cells(1).FindControl("ddlAccountProjectId"), DropDownList).Width = Unit.Percentage(100)
                    CType(objrow.Cells(1).FindControl("lblTimeOff"), Label).Width = Unit.Percentage(20)
                    If DBUtilities.IsShowCostCenterInTimeSheet Then
                        CType(objrow.Cells(2).FindControl("ddlAccountCostCenterId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                    If DBUtilities.IsShowWorkTypeInTimeSheet Then
                        CType(objrow.Cells(2).FindControl("ddlAccountWorkTypeId"), DropDownList).Width = Unit.Percentage(100)
                    End If
                    BulkEditGridViewVB1.Width = Unit.Percentage(98)
                    'End If
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Drop down list employee selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployee.SelectedIndexChanged
        RefreshDayView(True)
    End Sub
    ''' <summary>
    ''' Button audit click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAudit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAudit.Click
        Response.Redirect("AccountEmployeeTimeEntryAudit.aspx?AccountEmployeeTimeEntryPeriodId=" & Me.ViewState("dtAccountEmployeeTimeEntryPeriodId").ToString, False)
    End Sub
    ''' <summary>
    ''' Button my periods click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnMyPeriods_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMyPeriods.Click
        Response.Redirect("~/Employee/AccountEmployeeTimeEntryPeriodList.aspx?AccountEmployeeId=" & TimeEntryAccountEmployeeId & "&ViewType=DayView", False)
    End Sub
    ''' <summary>
    ''' Button week view click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnWeekView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWeekView.Click
        Response.Redirect("~/Employee/AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId, False)
    End Sub

    ''' <summary>
    ''' Check holiday icon of specified Holidaydate
    ''' </summary>
    ''' <param name="Holidaydate"></param>
    ''' <remarks></remarks>
    Private Sub CheckHolidayIcon(ByVal Holidaydate As Date)
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
            Me.Image1.Visible = True
        End If

    End Sub
    Protected Sub btnTimerTimesheet_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ShowTimerTimesheet()
    End Sub
    Public Sub ShowTimerTimesheet()
        Dim URL As String = "TimerControl.aspx?AccountEmployeeId=" & DBUtilities.GetSessionAccountEmployeeId & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Me.txtTimeEntryDate.PostedDate) & "&TimesheetPeriodType=" & TimesheetPeriodType & "&TimeEntryMode=" & "Day View"
        btnTimerTimesheet.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=520,height=365,left=280,top=280,scrollbars=yes'); return false;")
    End Sub
    Protected Sub dsAccountEmployeeTimeEntry_Deleting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeTimeEntry.Deleting
        e.Cancel = True
    End Sub
    Public Sub AddCustomField()
        Dim CustomFieldBLL As New AccountCustomFieldBLL
        Dim CustomControlsBLL As New AspNetCustomControlsBLL
        Dim MasterEntityTypeId As New Guid("369ed0fb-d317-4244-9f20-b7d834521e2b")
        Dim dt As AccountCustomField.vueAccountCustomFieldManageDataTable = CustomFieldBLL.GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId(DBUtilities.GetSessionAccountId, MasterEntityTypeId)
        Dim dr As AccountCustomField.vueAccountCustomFieldManageRow
        For Each dr In dt.Rows
            If Not dr.IsDisabled Then
                Dim dtcolumn As New TemplateField
                dtcolumn.HeaderText = dr.CustomFieldCaption
                dtcolumn.ItemTemplate = New TimesheetCustomFieldItemTemplate(dr)
                If Not dr.IsDisabled Then
                    TotalCustomFields += 1
                End If
                If dr.MasterCustomDataTypeId.ToString = "bacd6824-9011-4c30-864f-0899fefc004f" Then
                    dtcolumn.ItemStyle.Width = 50
                    'ElseIf dr.MasterCustomDataTypeId.ToString = "5942a0be-e7fe-4abb-b96f-f0b20d744ce3" Then
                Else
                    dtcolumn.ItemStyle.Width = 150
                End If
                Me.BulkEditGridViewVB1.Columns.Add(dtcolumn)
            End If
        Next
    End Sub
    Public Sub DisableAllPreviousTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then
            If Not TimesheetPeriodDaysArray.Contains(dtCurrentDate) Then
                If dtCurrentDate <= TimesheetPeriodDaysArray(0) Then
                    For Each objRow In Me.BulkEditGridViewVB1.Rows
                        Me.DisableTimeEntryViewOfWeek(objRow)
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub DisableAllFutureTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then
            If Not TimesheetPeriodDaysArray.Contains(dtCurrentDate) Then
                If dtCurrentDate >= TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1) Then
                    For Each objRow In Me.BulkEditGridViewVB1.Rows
                        Me.DisableTimeEntryViewOfWeek(objRow)
                    Next
                End If
            End If
        End If
    End Sub
    Public Sub DisablePreviousWeekTimeEntry()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then

            Dim dtdate As Date = TimesheetPeriodDaysArray(0)
            dtdate = dtdate.AddDays(-1)
            For n As Integer = 1 To DBUtilities.GetLockPreviousTimesheetPeriods()

                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtdate, dtdate, dtdate)
                If TimesheetPeriodDaysArray.Contains(dtCurrentDate) Then

                    For Each objRow In Me.BulkEditGridViewVB1.Rows
                        Me.DisableTimeEntryViewOfWeek(objRow)
                    Next
                End If

                dtdate = TimesheetPeriodDaysArray(0)
                dtdate = dtdate.AddDays(-1)
            Next
        End If
    End Sub
    Public Sub DisableNextWeekTimeEntry()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")
        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)

        If TimesheetPeriodDaysArray.Count > 0 Then

            Dim dtEndDate As Date = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
            dtEndDate = dtEndDate.AddDays(+1)
            For n As Integer = 1 To DBUtilities.GetLockNextTimsheetPeriods()

                TimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtEndDate, dtEndDate, dtEndDate)
                If TimesheetPeriodDaysArray.Contains(dtCurrentDate) Then
                    For Each objRow In Me.BulkEditGridViewVB1.Rows
                        Me.DisableTimeEntryViewOfWeek(objRow)
                    Next
                End If
                dtEndDate = TimesheetPeriodDaysArray(TimesheetPeriodDaysArray.Count - 1)
                dtEndDate = dtEndDate.AddDays(+1)
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
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")
        If No > LockDate Then
            No = LockDate
        End If
        CheckDate = New Date(Now.Year, Now.Month, No)
        StartDate = New Date(Now.Year, Now.Month, No)
        StartDate = New Date(Now.Year, Now.Month, 1)
        EndDate = New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))

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
                        ''Dim WorkingDayArray As ArrayList = WorkingDays
                        ''If Array <= WorkingDays.ToArray.Length - 1 Then
                        If dtCurrentDate = CurrentPeriodTimesheetPeriodDaysArray(Array) Then
                            For Each objRow In Me.BulkEditGridViewVB1.Rows
                                Me.DisableTimeEntryViewOfWeek(objRow)
                            Next
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
    Public Sub UnlockPreviousPeriodsTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        Dim CurrentPeriodTimesheetPeriodDaysArray As ArrayList
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")

        Dim TimesheetPeriodDaysArray As ArrayList = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, Now.Date, Now.Date, Now.Date)
        CurrentPeriodTimesheetPeriodDaysArray = DateTimeUtilities.GetPeriodStartDateAndPeriodEndDateWorkingDaysByDate(TimeEntryAccountEmployeeId, dtCurrentDate, Now.Date, Now.Date)
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
                For Each objRow In Me.BulkEditGridViewVB1.Rows
                    Me.DisableTimeEntryViewOfWeek(objRow)
                Next
            End If
        End If
    End Sub
    Public Sub UnlockNextPeriodsTimeEntryOfWeek()
        Dim objRow As GridViewRow
        Dim bll As New AccountEmployeeTimeEntryBLL
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(TimeEntryAccountEmployeeId)
        Dim dtCurrentDate As Date = Me.ViewState("TimeEntryDate")
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
                For Each objRow In Me.BulkEditGridViewVB1.Rows
                    Me.DisableTimeEntryViewOfWeek(objRow)
                Next
            End If
        End If
    End Sub
End Class