Partial Class Employee_Controls_ctlAccountWorkingDayList
    Inherits System.Web.UI.UserControl
    Public Event EditClick(ByVal sender As Object, ByVal CommandArgs As GridViewCommandEventArgs)
    Public Event btnAddWorkingDayClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function ShowErrorMessageWhenWorkingDayNotSelected() As Boolean
        Dim row As GridViewRow
        Dim TotalFalse As Integer
        Dim Total As Integer
        For Each row In CType(Me.FormView1.FindControl("GridView1"), GridView).Rows
            Total = CType(Me.FormView1.FindControl("GridView1"), GridView).Rows.Count
            If CType(row.FindControl("chkSelected"), CheckBox).Checked = False Then
                TotalFalse += 1
            End If
        Next
        If Total = TotalFalse Then
            Return False
        Else
            Return True
        End If
    End Function
    Protected Sub dsAccountWorkingDayTypeFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountWorkingDayTypeFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView2)
    End Sub
    Protected Sub dsAccountWorkingDayTypeFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountWorkingDayTypeFormViewObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub dsAccountWorkingDayTypeFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountWorkingDayTypeFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView2)
    End Sub
    Protected Sub dsAccountWorkingDayTypeFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountWorkingDayTypeFormViewObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(13, Me.GridView2, Me.FormView1, "btnAdd", 8, 9)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            Me.FormView1.Visible = False
            Me.GridView2.Visible = True
            Me.btnAddWorkingDay.Visible = True
            Dim row As GridViewRow
            Dim GridView1 As GridView = CType(Me.FormView1.FindControl("GridView1"), GridView)
            For Each row In GridView1.Rows
                If GridView1.DataKeys(row.RowIndex).Item(1) <> 6 And GridView1.DataKeys(row.RowIndex).Item(1) <> 7 Then
                    CType(row.FindControl("chkSelected"), CheckBox).Checked = True
                End If
            Next
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.FormView1.Visible = True
            Me.GridView2.Visible = False
            Me.btnAddWorkingDay.Visible = False
            If Not IsDBNull(Me.FormView1.DataItem("AccountTimesheetPeriodTypeId")) Then
                Me.dsTimesheetPeriodTypeObject.SelectParameters("AccountTimesheetPeriodTypeId").DefaultValue = Me.FormView1.DataItem("AccountTimesheetPeriodTypeId").ToString
                CType(Me.FormView1.FindControl("ddlTimesheetPeriodTypeId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTimesheetPeriodTypeId").ToString
            Else
                Me.dsTimesheetPeriodTypeObject.SelectParameters("AccountTimesheetPeriodTypeId").DefaultValue = System.Guid.Empty.ToString
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TimesheetOverdueAfterDays")) Then
                CType(Me.FormView1.FindControl("txtTimesheetOverdue"), TextBox).Text = Me.FormView1.DataItem("TimesheetOverdueAfterDays")
            Else
                CType(Me.FormView1.FindControl("txtTimesheetOverdue"), TextBox).Text = DBUtilities.GetSessionTimesheetOverdueAfterDays
            End If
            CType(Me.FormView1.FindControl("ddlTimesheetPeriodTypeId"), DropDownList).DataBind()

            Dim BLL As New AccountBLL
            Dim dtPreferences As AccountPreferences.AccountPreferencesDataTable = BLL.GetPreferencesByAccountId(DBUtilities.GetSessionAccountId)
            Dim drPreferences As AccountPreferences.AccountPreferencesRow
            drPreferences = dtPreferences.Rows(0)

            '''''''Enabled/Disable CheckBox in FormView
            If Not IsDBNull(drPreferences.Item("ShowClockStartEndBy")) Then
                If drPreferences.ShowClockStartEndBy = "Account" Then
                    CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Enabled = False
                    CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Checked = False
                ElseIf drPreferences.ShowClockStartEndBy = "Employee" Then
                    CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Enabled = True
                End If
            Else
                CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Enabled = False
                CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Checked = False
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("LockAllPreviousTimesheets")) Then
                CType(Me.FormView1.FindControl("chkLockAllPreviousTimesheets"), CheckBox).Checked = Me.FormView1.DataItem("LockAllPreviousTimesheets")
            Else
                CType(Me.FormView1.FindControl("chkLockAllPreviousTimesheets"), CheckBox).Checked = DBUtilities.GetLockAllPreviousTimesheets
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LockAllFutureTimesheets")) Then
                CType(Me.FormView1.FindControl("chkLockAllFutureTimesheets"), CheckBox).Checked = Me.FormView1.DataItem("LockAllFutureTimesheets")
            Else
                CType(Me.FormView1.FindControl("chkLockAllFutureTimesheets"), CheckBox).Checked = DBUtilities.GetLockAllFutureTimesheets
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LockPreviousTimesheetPeriods")) Then
                CType(Me.FormView1.FindControl("LockPreviousTimesheetPeriodsTextBox"), TextBox).Text = Me.FormView1.DataItem("LockPreviousTimesheetPeriods")
            Else
                CType(Me.FormView1.FindControl("LockPreviousTimesheetPeriodsTextBox"), TextBox).Text = DBUtilities.GetLockPreviousTimesheetPeriods
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LockFutureTimsheetPeriods")) Then
                CType(Me.FormView1.FindControl("LockFutureTimsheetPeriodsTextBox"), TextBox).Text = Me.FormView1.DataItem("LockFutureTimsheetPeriods")
            Else
                CType(Me.FormView1.FindControl("LockFutureTimsheetPeriodsTextBox"), TextBox).Text = DBUtilities.GetLockNextTimsheetPeriods
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LockAllPeriodExceptPrevious")) Then
                CType(Me.FormView1.FindControl("LockAllPeriodExceptPreviousTextBox"), TextBox).Text = Me.FormView1.DataItem("LockAllPeriodExceptPrevious")
            Else
                CType(Me.FormView1.FindControl("LockAllPeriodExceptPreviousTextBox"), TextBox).Text = DBUtilities.GetLockAllPeriodExceptPrevious
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LockAllPeriodExceptNext")) Then
                CType(Me.FormView1.FindControl("LockAllPeriodExceptNextTextBox"), TextBox).Text = Me.FormView1.DataItem("LockAllPeriodExceptNext")
            Else
                CType(Me.FormView1.FindControl("LockAllPeriodExceptNextTextBox"), TextBox).Text = DBUtilities.GetLockAllPeriodExceptNext
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LockPreviousNextMonthTimesheetOn")) Then
                CType(Me.FormView1.FindControl("LockPreviousNextMonthTimesheetOnTextBox"), TextBox).Text = Me.FormView1.DataItem("LockPreviousNextMonthTimesheetOn")
            Else
                CType(Me.FormView1.FindControl("LockPreviousNextMonthTimesheetOnTextBox"), TextBox).Text = DBUtilities.GetLockPreviousNextMonthTimesheetOn
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MinimumHoursPerDay")) Then
                CType(Me.FormView1.FindControl("MinimumHoursPerDayTextBox"), TextBox).Text = Me.FormView1.DataItem("MinimumHoursPerDay")
            Else
                CType(Me.FormView1.FindControl("MinimumHoursPerDayTextBox"), TextBox).Text = DBUtilities.GetMinimumHoursPerDay
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MaximumHoursPerDay")) Then
                CType(Me.FormView1.FindControl("MaximumHoursPerDayTextBox"), TextBox).Text = Me.FormView1.DataItem("MaximumHoursPerDay")
            Else
                CType(Me.FormView1.FindControl("MaximumHoursPerDayTextBox"), TextBox).Text = DBUtilities.GetMaximumHoursPerDay
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MinimumHoursPerWeek")) Then
                CType(Me.FormView1.FindControl("MinimumHoursPerWeekTextBox"), TextBox).Text = Me.FormView1.DataItem("MinimumHoursPerWeek")
            Else
                CType(Me.FormView1.FindControl("MinimumHoursPerWeekTextBox"), TextBox).Text = DBUtilities.GetMinimumHoursPerWeek
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MaximumHoursPerWeek")) Then
                CType(Me.FormView1.FindControl("MaximumHoursPerWeekTextBox"), TextBox).Text = Me.FormView1.DataItem("MaximumHoursPerWeek")
            Else
                CType(Me.FormView1.FindControl("MaximumHoursPerWeekTextBox"), TextBox).Text = DBUtilities.GetMaximumHoursPerWeek
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MinimumPercentagePerDay")) Then
                CType(Me.FormView1.FindControl("MinimumPercentagePerDayTextBox"), TextBox).Text = Me.FormView1.DataItem("MinimumPercentagePerDay")
            Else
                CType(Me.FormView1.FindControl("MinimumPercentagePerDayTextBox"), TextBox).Text = DBUtilities.GetMinimumPercentagePerDay
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MaximumPercentagePerDay")) Then
                CType(Me.FormView1.FindControl("MaximumPercentagePerDayTextBox"), TextBox).Text = Me.FormView1.DataItem("MaximumPercentagePerDay")
            Else
                CType(Me.FormView1.FindControl("MaximumPercentagePerDayTextBox"), TextBox).Text = DBUtilities.GetMaximumPercentagePerDay
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MinimumPercentagePerWeek")) Then
                CType(Me.FormView1.FindControl("MinimumPercentagePerWeekTextBox"), TextBox).Text = Me.FormView1.DataItem("MinimumPercentagePerWeek")
            Else
                CType(Me.FormView1.FindControl("MinimumPercentagePerWeekTextBox"), TextBox).Text = DBUtilities.GetMinimumPercentagePerWeek
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MaximumPercentagePerWeek")) Then
                CType(Me.FormView1.FindControl("MaximumPercentagePerWeekTextBox"), TextBox).Text = Me.FormView1.DataItem("MaximumPercentagePerWeek")
            Else
                CType(Me.FormView1.FindControl("MaximumPercentagePerWeekTextBox"), TextBox).Text = DBUtilities.GetMaximumPercentagePerWeek
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EnableBalanceValidationForTimeOff")) Then
                CType(Me.FormView1.FindControl("chkEnableBalanceValidationForTimeOff"), CheckBox).Checked = Me.FormView1.DataItem("EnableBalanceValidationForTimeOff")
            Else
                CType(Me.FormView1.FindControl("chkEnableBalanceValidationForTimeOff"), CheckBox).Checked = DBUtilities.EnableTimeOffValidation
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ShowClockStartEndEmployee")) Then
                CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Checked = Me.FormView1.DataItem("ShowClockStartEndEmployee")
            Else
                CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Checked = DBUtilities.ShowClockStartEndEmployee
            End If
        End If

    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        If e.Exception Is Nothing Then
            SaveWorkingDays()
            'UIUtilities.RedirectToAdminHomePage()
        Else
            CType(Me.FormView1.FindControl("lblException"), Label).Visible = True
            CType(Me.FormView1.FindControl("lblException"), Label).Text = e.Exception.Message
        End If
        Me.FormView1.DataBind()
    End Sub
    Public Sub SaveWorkingDays()
        Dim row As GridViewRow
        Dim objAccountWorkingDay As New AccountWorkingDayBLL
        Dim GridView1 As GridView = CType(Me.FormView1.FindControl("GridView1"), GridView)
        For Each row In GridView1.Rows
            If CType(row.FindControl("chkSelected"), CheckBox).Checked = True Then
                objAccountWorkingDay.AddAccountWorkingDay(DBUtilities.GetSessionAccountId, GridView1.DataKeys(row.RowIndex).Item(1), System.Web.HttpContext.Current.Session("AccountWorkingDayTypeId"))
            End If
        Next
    End Sub
    Public Sub UpdateWorkingDays()
        Dim row As GridViewRow
        Dim objAccountWorkingDay As New AccountWorkingDayBLL
        Dim GridView1 As GridView = CType(Me.FormView1.FindControl("GridView1"), GridView)
        For Each row In GridView1.Rows
            If CType(row.FindControl("chkSelected"), CheckBox).Checked = True And IsDBNull(GridView1.DataKeys(row.RowIndex).Item(0)) Then
                objAccountWorkingDay.AddAccountWorkingDay(DBUtilities.GetSessionAccountId, GridView1.DataKeys(row.RowIndex).Item(1), FormView1.DataKey("AccountWorkingDayTypeId"))
            Else
                If CType(row.FindControl("chkSelected"), CheckBox).Checked = False And Not IsDBNull(GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountWorkingDay.DeleteAccountWorkingDayId(GridView1.DataKeys(row.RowIndex).Item(0))
                End If
            End If
        Next
    End Sub
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        If Me.ShowErrorMessageWhenWorkingDayNotSelected = False Then
            Throw New Exception("You should have atleast one day selected.")
        End If
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        If e.Exception Is Nothing Then
            UpdateWorkingDays()
            'UIUtilities.RedirectToAdminHomePage()
        Else
            CType(Me.FormView1.FindControl("lblException"), Label).Visible = True
            CType(Me.FormView1.FindControl("lblException"), Label).Text = e.Exception.Message
        End If
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.FormView1.Visible = True
            Me.GridView2.Visible = False
            Me.btnAddWorkingDay.Visible = False
            RaiseEvent EditClick(sender, e)
        End If
    End Sub
    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
    Protected Sub GridView2_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView2.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.ShowErrorMessageWhenWorkingDayNotSelected = False Then
            Throw New Exception("You should have atleast one day selected.")
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("IsDisabled") = CType(Me.FormView1.FindControl("chkIsDisabled"), CheckBox).Checked
            e.NewValues.Item("AccountTimeSheetPeriodTypeId") = CType(Me.FormView1.FindControl("ddlTimesheetPeriodTypeId"), DropDownList).SelectedValue
            e.NewValues.Item("TimesheetOverdueAfterDays") = CType(Me.FormView1.FindControl("txtTimesheetOverdue"), TextBox).Text
            e.NewValues.Item("LockAllPreviousTimesheets") = CType(Me.FormView1.FindControl("chkLockAllPreviousTimesheets"), CheckBox).Checked
            e.NewValues.Item("LockAllFutureTimesheets") = CType(Me.FormView1.FindControl("chkLockAllFutureTimesheets"), CheckBox).Checked
            'chkEnableBalanceValidationForTimeOff
            e.NewValues.Item("EnableBalanceValidationForTimeOff") = CType(Me.FormView1.FindControl("chkEnableBalanceValidationForTimeOff"), CheckBox).Checked
            e.NewValues.Item("LockPreviousTimesheetPeriods") = CType(Me.FormView1.FindControl("LockPreviousTimesheetPeriodsTextBox"), TextBox).Text
            e.NewValues.Item("LockFutureTimsheetPeriods") = CType(Me.FormView1.FindControl("LockFutureTimsheetPeriodsTextBox"), TextBox).Text
            e.NewValues.Item("LockPreviousNextMonthTimesheetOn") = CType(Me.FormView1.FindControl("LockPreviousNextMonthTimesheetOnTextBox"), TextBox).Text
            e.NewValues.Item("LockAllPeriodExceptPrevious") = CType(Me.FormView1.FindControl("LockAllPeriodExceptPreviousTextBox"), TextBox).Text
            e.NewValues.Item("LockAllPeriodExceptNext") = CType(Me.FormView1.FindControl("LockAllPeriodExceptNextTextBox"), TextBox).Text
            e.NewValues.Item("ShowClockStartEndEmployee") = CType(Me.FormView1.FindControl("chkShowClockStartEndEmployee"), CheckBox).Checked
        End If
    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Call New AccountWorkingDayTypeBLL().DeleteAccountWorkingDayType(Me.GridView2.DataKeys(e.RowIndex)("AccountWorkingDayTypeId"))
        e.Cancel = True
        Response.Redirect("~/AccountAdmin/AccountWorkingDay.aspx", False)
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = False
        Me.GridView2.Visible = True
        Me.btnAddWorkingDay.Visible = True
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GridView2.Visible = True
        Me.btnAddWorkingDay.Visible = True
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = False
        Me.GridView2.Visible = True
        Me.btnAddWorkingDay.Visible = True
    End Sub

    Protected Sub btnAddWorkingDay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = True
        Me.GridView2.Visible = False
        Me.btnAddWorkingDay.Visible = False
        RaiseEvent btnAddWorkingDayClick(sender, e)
    End Sub
End Class
