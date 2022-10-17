
Partial Class AccountAdmin_Controls_ctlTimeEntryArchive
    Inherits System.Web.UI.UserControl
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim TotalTime As Integer
    Dim TimesheetPeriodTypeTS As String
    Dim PeriodStartDateTS As Date
    Dim PeriodEndDateTS As Date
    Dim AccountEmployeeTimeEntryPeriodIdTS As Guid
    Dim FilterBLL As New AccountFilterModuleBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            ReportUtilities.SetDefaultValuesOfFilerItem(ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)

            Me.ShowGridFromFilter()
            Me.Literal5.Text = ResourceHelper.GetFromResource("Time Entry Archive")
            Me.Literal1.Text = ResourceHelper.GetFromResource("Search Parameters")
            Me.Literal2.Text = ResourceHelper.GetFromResource("Employees")
            Me.Literal10.Text = ResourceHelper.GetFromResource("Client Name")
            Me.Literal3.Text = ResourceHelper.GetFromResource("Project")
            Me.Literal4.Text = ResourceHelper.GetFromResource("Project Tasks")
            Me.Literal6.Text = ResourceHelper.GetFromResource("Approved")
            Me.Literal7.Text = ResourceHelper.GetFromResource("Include Date Range")
            Me.Literal8.Text = ResourceHelper.GetFromResource("Start Date")
            Me.Literal9.Text = ResourceHelper.GetFromResource("End Date")

            If LocaleUtilitiesBLL.IsShowEmployeeNameWithCode = True Then
                ddlEmployees.DataSource = dsEmployeesObject
                ddlEmployees.DataValueField = "AccountEmployeeId"
                ddlEmployees.DataTextField = "EmployeeNameWithCodeWithDisabled"

            Else
                ddlEmployees.DataSource = dsEmployeesObject
                ddlEmployees.DataValueField = "AccountEmployeeId"
                ddlEmployees.DataTextField = "EmployeeName"

            End If
            ddlEmployees.DataBind()
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)

            ''If System.Web.HttpContext.Current.Session("ResetSelectedFilter") = 1 Then
            ''    System.Web.HttpContext.Current.Session.Remove("ResetSelectedFilter")
            ''    Response.Redirect(Request.RawUrl, False)
            ''End If
            ShowGridFromFilter()
        End If
        If System.Web.HttpContext.Current.Session("CascadingReset") = 1 Then
            CascadingDropdownvalueForReset()
            System.Web.HttpContext.Current.Session.Remove("CascadingReset")
        End If
    End Sub
    Public Sub CascadingDropdownvalueForReset()
        Me.dsUpdateTimeEntry.SelectParameters("AccountProjectTaskId").DefaultValue = Me.ddlProjectTasks.SelectedValue
        Dim nAccountProjectTaskId As Object
        nAccountProjectTaskId = System.Web.HttpContext.Current.Session("ProjectTaskID")
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & True & "," & nAccountProjectTaskId & "," & DBUtilities.GetSessionAccountId
        System.Web.HttpContext.Current.Session.Remove("ProjectTaskID")
    End Sub
    Public Sub ShowGridFromFilter()
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        Me.dsUpdateTimeEntry.SelectParameters("AccountEmployees").DefaultValue = ddlEmployees.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("AccountProjectId").DefaultValue = Me.ddlProjects.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("AccountProjectTaskId").DefaultValue = Me.ddlProjectTasks.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("AccountPartyId").DefaultValue = Me.ddlClients.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked
        Me.dsUpdateTimeEntry.SelectParameters("TimeEntryStartDate").DefaultValue = Me.StartDate.SelectedDate
        Me.dsUpdateTimeEntry.SelectParameters("TimeEntryEndDate").DefaultValue = Me.EndDate.SelectedDate
        Me.dsUpdateTimeEntry.SelectParameters("Approval").DefaultValue = Me.ddlApproved.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("Billable").DefaultValue = -1

        Me.GridView1.DataBind()
        AccountPagePermissionBLL.SetPagePermissionForGridView(113, Me.GridView1, 11, 12)
        Me.btnDeleteSelectedItem.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(113, 4)
        Dim nAccountProjectTaskId As Long
        If ddlProjectTasks.SelectedValue = "" Then
            nAccountProjectTaskId = 0
        Else
            nAccountProjectTaskId = ddlProjectTasks.SelectedValue
        End If
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & True & "," & nAccountProjectTaskId & "," & DBUtilities.GetSessionAccountId
    End Sub



    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        ShowGridFromFilter()
        'Response.Redirect(Request.RawUrl, False)
        RaiseEvent btnShowClick(sender, e)
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        If Me.GridView1.Rows.Count <> 0 Then
            Me.CheckAll.Visible = True
            Me.UnCheckAll.Visible = True
        Else
            Me.CheckAll.Visible = False
            Me.UnCheckAll.Visible = False
        End If
        If Me.GridView1.Rows.Count > 0 Then
            Me.btnDeleteSelectedItem.Visible = True
        Else
            Me.btnDeleteSelectedItem.Visible = False
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" Then
            Me.GridView1.Columns(8).Visible = True
            Me.GridView1.Columns(5).Visible = False
            Me.GridView1.Columns(6).Visible = False
            Me.GridView1.Columns(7).Visible = False
        ElseIf LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "Time" Or LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
            Me.GridView1.Columns(8).Visible = True
        ElseIf LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And DBUtilities.IsTimeEntryHoursFormat = "None" Then
            Me.GridView1.Columns(8).Visible = False
            Me.GridView1.Columns(5).Visible = True
            Me.GridView1.Columns(6).Visible = True
            Me.GridView1.Columns(7).Visible = True
        End If
    End Sub
    Dim Hours As Decimal = 0
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        TotalTime = TotalTime + DBUtilities.GetMinutesOfTime(CType(DataBinder.Eval(e.Row.DataItem, "TotalTime"), Date))
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TaskName")) Then
                CType(e.Row.Cells(3).FindControl("Label7"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "TaskName").ToString.Length > 25, Left(DataBinder.Eval(e.Row.DataItem, "TaskName"), 23) & "..", DataBinder.Eval(e.Row.DataItem, "TaskName"))
                If DataBinder.Eval(e.Row.DataItem, "TaskName").ToString.Length > 25 Then
                    CType(e.Row.Cells(3).FindControl("Label7"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "TaskName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectName")) Then
                CType(e.Row.Cells(2).FindControl("Label1"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 25, Left(DataBinder.Eval(e.Row.DataItem, "ProjectName"), 23) & "..", DataBinder.Eval(e.Row.DataItem, "ProjectName"))
                If DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 25 Then
                    CType(e.Row.Cells(2).FindControl("Label1"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "ProjectName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                CType(e.Row.Cells(8).FindControl("Label20"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
            Else
                CType(e.Row.Cells(8).FindControl("Label20"), Label).Text = 0 & "%"
            End If
            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Hours")) Then
                    CType(e.Row.Cells(7).FindControl("Label4"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Hours")
                    Hours = Hours + CType(e.Row.Cells(7).FindControl("Label4"), Label).Text
                Else
                    CType(e.Row.Cells(7).FindControl("Label4"), Label).Text = Hours
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("SumTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime)
            Else
                CType(e.Row.Cells(3).FindControl("SumTime"), Label).Text = Hours
            End If
        End If

    End Sub

    Protected Sub btnDeleteSelectedItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        Dim Original_AccountEmployeeTimeEntryId As Integer
        Dim AccountEmployeeTimeEntryPeriodId As Guid
        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkDelete"), CheckBox).Checked = True Then
                Original_AccountEmployeeTimeEntryId = CType(row.Cells(13).FindControl("Label6"), Label).Text
                Dim BLL As New AccountEmployeeTimeEntryBLL
                Dim AccountEmployeeTimeEntryApprovalProjectId As Guid
                Dim dtTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = BLL.GetAccountEmployeeTimeEntriesByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
                Dim drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow
                If dtTimeEntry.Rows.Count > 0 Then
                    drTimeEntry = dtTimeEntry.Rows(0)
                    If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryApprovalProjectId")) Then
                        AccountEmployeeTimeEntryApprovalProjectId = drTimeEntry.AccountEmployeeTimeEntryApprovalProjectId
                    End If
                    If Not IsDBNull(drTimeEntry.Item("AccountEmployeeTimeEntryPeriodId")) Then
                        AccountEmployeeTimeEntryPeriodId = drTimeEntry.AccountEmployeeTimeEntryPeriodId
                    End If
                End If
                Original_AccountEmployeeTimeEntryId = New AccountEmployeeTimeEntryBLL().DeleteAccountEmployeeTimeEntry(Original_AccountEmployeeTimeEntryId, IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex)("TimeEntryViewType")), "", Me.GridView1.DataKeys(row.RowIndex)("TimeEntryViewType")), Me.GridView1.DataKeys(row.RowIndex)("AccountEmployeeId"), IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex)("TimeEntryStartDate")), #1/1/2007#, Me.GridView1.DataKeys(row.RowIndex)("TimeEntryStartDate")), IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex)("TimeEntryEndDate")), #1/1/2007#, Me.GridView1.DataKeys(row.RowIndex)("TimeEntryEndDate")), AccountEmployeeTimeEntryApprovalProjectId, AccountEmployeeTimeEntryPeriodId)
            End If
        Next
        Me.GridView1.DataBind()
    End Sub
    Protected Sub CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = True
        Next
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub UnCheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = False
        Next
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted

    End Sub

    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated

    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim AccountEmployeeTimeEntryApprovalProjectIdDataKeyValue As Guid = IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId")), System.Guid.Empty, Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId"))
        Dim AccountEmployeeTimeEntryPeriodIdDataKeyValue As Guid = IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryPeriodId")), System.Guid.Empty, Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryPeriodId"))

        ''AccountEmployeeTimeOffRequestId
        Dim AccountEmployeeTimeOffRequestIdDataKeyValue As Guid = IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeOffRequestId")), System.Guid.Empty, Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeOffRequestId"))

        Me.dsUpdateTimeEntry.UpdateParameters("Original_AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodIdDataKeyValue.ToString
        Me.dsUpdateTimeEntry.UpdateParameters("Original_AccountEmployeeTimeEntryApprovalProjectId").DefaultValue = AccountEmployeeTimeEntryApprovalProjectIdDataKeyValue.ToString


        Me.dsUpdateTimeEntry.UpdateParameters("original_IsTimeOff").DefaultValue = IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("IsTimeOff")), False, Me.GridView1.DataKeys(e.RowIndex)("IsTimeOff"))
        If AccountEmployeeTimeOffRequestIdDataKeyValue <> System.Guid.Empty Then
            Me.dsUpdateTimeEntry.UpdateParameters("original_AccountEmployeeTimeOffRequestId").DefaultValue = AccountEmployeeTimeOffRequestIdDataKeyValue.ToString
        End If
        If IsDBNull(AccountEmployeeTimeEntryPeriodIdDataKeyValue) OrElse AccountEmployeeTimeEntryPeriodIdDataKeyValue = System.Guid.Empty Then
            'Me.SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeId"), Me.GridView1.DataKeys(e.RowIndex)("TimeEntryDate"), CType(Me.GridView1.Rows(e.RowIndex).FindControl("chkSubmitted"), CheckBox).Checked, CType(Me.GridView1.Rows(e.RowIndex).FindControl("chkApproved"), CheckBox).Checked)
            Me.dsUpdateTimeEntry.UpdateParameters("Original_AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodIdTS.ToString
            'Me.dsUpdateTimeEntry.UpdateParameters("Original_TimeEntryStartDate").DefaultValue = PeriodStartDateTS
            'Me.dsUpdateTimeEntry.UpdateParameters("Original_TimeEntryEndDate").DefaultValue = PeriodEndDateTS
            'Me.dsUpdateTimeEntry.UpdateParameters("Original_TimeEntryViewType").DefaultValue = TimesheetPeriodTypeTS
        Else
            ''Call New AccountEmployeeTimeEntryBLL().UpdateAccountEmployeeTimeEntryPeriodStatusForTimeEntryArchive(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeId"), CType(Me.GridView1.Rows(e.RowIndex).FindControl("chkSubmitted"), CheckBox).Checked, CType(Me.GridView1.Rows(e.RowIndex).FindControl("chkApproved"), CheckBox).Checked, False, AccountEmployeeTimeEntryPeriodIdDataKeyValue)
            Me.dsUpdateTimeEntry.UpdateParameters("Original_AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodIdDataKeyValue.ToString
        End If
    End Sub
    Public Function SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, Optional ByVal Submitted As Boolean = False, Optional ByVal Approved As Boolean = False) As Guid
        Dim dtPeriodStartDate As Date = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, DBUtilities.GetEmployeeTimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        Dim dtPeriodEndDate As Date = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, DBUtilities.GetEmployeeTimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, DBUtilities.GetEmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> DBUtilities.GetEmployeeTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        End If
        Dim dtAccountEmployeeTimeEntryPeriodId As Guid = New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodIdForTimeEntry(DBUtilities.GetSessionAccountId, AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, TimesheetPeriodType, Submitted, Approved, False, False)
        TimesheetPeriodTypeTS = TimesheetPeriodType
        PeriodStartDateTS = dtPeriodStartDate
        PeriodEndDateTS = dtPeriodEndDate
        AccountEmployeeTimeEntryPeriodIdTS = dtAccountEmployeeTimeEntryPeriodId
    End Function
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Dim AccountEmployeeTimeEntryApprovalProjectIdDataKeyValue As Guid = IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId")), System.Guid.Empty, Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryApprovalProjectId"))
        Dim AccountEmployeeTimeEntryPeriodIdDataKeyValue As Guid = IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryPeriodId")), System.Guid.Empty, Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
        Call New AccountEmployeeTimeEntryBLL().DeleteAccountEmployeeTimeEntry(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTimeEntryId"), IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("TimeEntryViewType")), "", Me.GridView1.DataKeys(e.RowIndex)("TimeEntryViewType")), Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeId"), IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("TimeEntryStartDate")), #1/1/2007#, Me.GridView1.DataKeys(e.RowIndex)("TimeEntryStartDate")), IIf(IsDBNull(Me.GridView1.DataKeys(e.RowIndex)("TimeEntryEndDate")), #1/1/2007#, Me.GridView1.DataKeys(e.RowIndex)("TimeEntryEndDate")), AccountEmployeeTimeEntryApprovalProjectIdDataKeyValue, AccountEmployeeTimeEntryPeriodIdDataKeyValue)
        Me.GridView1.DataBind()
        'Me.RefreshPage()
    End Sub
    Public Sub RefreshPage()
        Dim url As String = Me.Page.Request.RawUrl
        Response.Redirect(url, False)
    End Sub
    '    Dim FilterBLL As New AccountFilterModuleBLL
    '    'Session("IsAdd") = "1"
    '    FilterBLL.ResetFilters(Me, Me.Page)
    '    ShowGridFromFilterForReset()
    '    Dim MyCascading As AjaxControlToolkit.CascadingDropDown
    '    MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
    '    MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & True & "," & 0 & "," & DBUtilities.GetSessionAccountId
    Public Sub ShowGridFromFilterForReset()
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        Me.dsUpdateTimeEntry.SelectParameters("AccountEmployees").DefaultValue = ddlEmployees.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("AccountProjectId").DefaultValue = Me.ddlProjects.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("AccountProjectTaskId").DefaultValue = Me.ddlProjectTasks.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("AccountPartyId").DefaultValue = Me.ddlClients.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked
        Me.dsUpdateTimeEntry.SelectParameters("TimeEntryStartDate").DefaultValue = Me.StartDate.SelectedDate
        Me.dsUpdateTimeEntry.SelectParameters("TimeEntryEndDate").DefaultValue = Me.EndDate.SelectedDate
        Me.dsUpdateTimeEntry.SelectParameters("Approval").DefaultValue = Me.ddlApproved.SelectedValue
        Me.dsUpdateTimeEntry.SelectParameters("Billable").DefaultValue = -1

        Me.GridView1.DataBind()
        AccountPagePermissionBLL.SetPagePermissionForGridView(113, Me.GridView1, 11, 12)
        Me.btnDeleteSelectedItem.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(113, 4)
        Dim nAccountProjectTaskId As Long
        If ddlProjectTasks.SelectedValue = "" Then
            nAccountProjectTaskId = 0
        Else
            nAccountProjectTaskId = ddlProjectTasks.SelectedValue
        End If
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & True & "," & nAccountProjectTaskId & "," & DBUtilities.GetSessionAccountId
    End Sub
End Class
