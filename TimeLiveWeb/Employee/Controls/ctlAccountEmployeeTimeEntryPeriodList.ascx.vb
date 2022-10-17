''' <summary>
''' Employee controls account employee time entry period list class
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryPeriodList
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' Page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Dim FilterBLL As New AccountFilterModuleBLL
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Literal3.Text = ResourceHelper.GetFromResource("Approval Status:")
        Dim AccountEmployeeId As Integer = IIf(ddlEmployee.SelectedValue = "", Me.Request.QueryString("AccountEmployeeId"), ddlEmployee.SelectedValue)
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndEdit(18, Me.GridView1, 8)
        If Not AccountPagePermissionBLL.IsPageHasPermissionOf(18, 3) = True Then
            btnAddTimesheet.Enabled = False
        End If
        If Not Me.IsPostBack Then
            
            AccountEmployeeBLL.SetDataForEmployeeDropdown(18, ddlEmployee)
            Me.ddlEmployee.SelectedValue = AccountEmployeeId
            AddListItemInDropDown()
            Me.ddlApprovalStatus.SelectedValue = 1
            SetDateValue()
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
            Me.SetSelectParameters()
        End If
        If DBUtilities.GetSessionAccountId <> 6373 Then
            Me.GridView1.Columns(9).Visible = False
        End If
    End Sub
    ''' <summary>
    ''' Set edit url of specified TimeEntryStartDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetEditURL(ByVal TimeEntryStartDate As Date, ByVal AccountEmployeeId As Integer) As String
        If Me.Request.QueryString("ViewType") Is Nothing OrElse Me.Request.QueryString("ViewType") = "WeekView" Then
            Return "~/Employee/AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(TimeEntryStartDate) & "&" & "AccountEmployeeId=" & AccountEmployeeId
        ElseIf Me.Request.QueryString("ViewType") = "DayView" Then
            Return "~/Employee/AccountEmployeeTimeEntryDayView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(TimeEntryStartDate) & "&" & "AccountEmployeeId=" & AccountEmployeeId
        Else
            Return "~/Employee/AccountEmployeeTimeEntryPeriodView.aspx?StartDate=" & LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(TimeEntryStartDate) & "&" & "AccountEmployeeId=" & AccountEmployeeId
        End If
    End Function
    ''' <summary>
    ''' Grid view row data bound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblPSD As Label = CType(e.Row.FindControl("lblPSD"), Label)
            Dim lblPED As Label = CType(e.Row.FindControl("lblPED"), Label)
            Dim lblTotalDuration As Label = CType(e.Row.FindControl("lblTotalDuration"), Label)
            Dim Submitted As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "Submitted")), "", DataBinder.Eval(e.Row.DataItem, "Submitted"))
            Dim Approved As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "Approved")), "", DataBinder.Eval(e.Row.DataItem, "Approved"))
            Dim Rejected As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "Rejected")), "", DataBinder.Eval(e.Row.DataItem, "Rejected"))
            Dim InApproval As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "InApproval")), "", DataBinder.Eval(e.Row.DataItem, "InApproval"))
            Dim lblTimesheetStatus As Label = CType(e.Row.FindControl("lblTimesheetStatus"), Label)
            CType(e.Row.FindControl("lnkEdit"), HyperLink).Text = ""
            If Not Submitted = "" Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TotalMinutes")) Then
                    lblTotalDuration.Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) Then
                    lblPSD.Text = DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TimeEntryEndDate")) Then
                    lblPED.Text = DataBinder.Eval(e.Row.DataItem, "TimeEntryEndDate")
                End If
                Dim TimeEntryStartDate As Date = DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")
                Dim AccountEmployeeId As Integer = DataBinder.Eval(e.Row.DataItem, "AccountEmployeeId")
                CType(e.Row.FindControl("lnkEdit"), HyperLink).Text = "Open"
                CType(e.Row.FindControl("lnkEdit"), HyperLink).NavigateUrl = SetEditURL(TimeEntryStartDate, AccountEmployeeId)
                SetStatusColumnValues(Submitted, Approved, Rejected, InApproval, lblTimesheetStatus)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set status column values of specified Submitted, Approved, Rejected, InApproval, lblTimesheetStatus
    ''' </summary>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="InApproval"></param>
    ''' <param name="lblTimesheetStatus"></param>
    ''' <remarks></remarks>
    Public Sub SetStatusColumnValues(ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal InApproval As Boolean, ByVal lblTimesheetStatus As Label)
        If Submitted = False And Rejected = False And Approved = False And InApproval = False Then
            lblTimesheetStatus.Text = "Not Submitted"
        ElseIf Submitted = True And Approved = True And Rejected = False Then
            lblTimesheetStatus.Text = ResourceHelper.GetFromResource("Approved")
        ElseIf Rejected = True And Submitted = False Then
            lblTimesheetStatus.Text = "Rejected"
        ElseIf Submitted = True And Rejected = False And Approved = False And InApproval = True Then
            lblTimesheetStatus.Text = "Submitted"
        ElseIf Submitted = True And Rejected = False And Approved = False And InApproval = False Then
            lblTimesheetStatus.Text = "Submitted"
        ElseIf Submitted = False And Approved = True Then
            lblTimesheetStatus.Text = "Not Submitted"
        ElseIf Submitted = False And InApproval = True Then
            lblTimesheetStatus.Text = "Not Submitted"
        End If
    End Sub
    ''' <summary>
    ''' Button show click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        Me.StartDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDateTextBox.PostedDate)
        Me.EndDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDateTextBox.PostedDate)
        Me.SetSelectParameters()
        Me.GridView1.DataBind()
        'Response.Redirect(Request.RawUrl, False)
        RaiseEvent btnShowClick(sender, e)
    End Sub
    ''' <summary>
    ''' Add list item in drop down
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddListItemInDropDown()
        Me.AddDropDownItem("All Timesheet Periods", 0, Me.ddlApprovalStatus)
        Me.AddDropDownItem("All Open Timesheet Periods", 1, Me.ddlApprovalStatus)
        Me.AddDropDownItem("Not Submitted", 2, Me.ddlApprovalStatus)
        Me.AddDropDownItem("Submitted", 3, Me.ddlApprovalStatus)
        Me.AddDropDownItem("Approved", 4, Me.ddlApprovalStatus)
        Me.AddDropDownItem("Rejected", 5, Me.ddlApprovalStatus)
    End Sub
    ''' <summary>
    ''' Add drop down item of specified Text, value, ddl
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <param name="value"></param>
    ''' <param name="ddl"></param>
    ''' <remarks></remarks>
    Public Sub AddDropDownItem(ByVal Text As String, ByVal value As String, ByVal ddl As DropDownList)
        Dim item As New System.Web.UI.WebControls.ListItem
        ddl.AppendDataBoundItems = True
        item.Text = ResourceHelper.GetFromResource(Text)
        item.Value = value
        ddl.Items.Add(item)
    End Sub
    ''' <summary>
    ''' Set date value
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDateValue()
        Me.StartDateTextBox.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        Me.EndDateTextBox.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
    End Sub
    ''' <summary>
    ''' Button add time sheet click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAddTimesheet_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(SetEditURL(LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone, ddlEmployee.SelectedValue), False)
    End Sub
    ''' <summary>
    ''' Drop down list employee selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.GridView1.DataBind()
    End Sub
    ''' <summary>
    ''' Set select parameters
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetSelectParameters()
        Me.dsAccountEmployeeTimeEntryPeriodListObject.SelectParameters("AccountEmployeeId").DefaultValue = Me.ddlEmployee.SelectedValue
        Me.dsAccountEmployeeTimeEntryPeriodListObject.SelectParameters("PeriodStartDate").DefaultValue = StartDateTextBox.SelectedDate
        Me.dsAccountEmployeeTimeEntryPeriodListObject.SelectParameters("PeriodEndDate").DefaultValue = EndDateTextBox.SelectedDate
        Me.dsAccountEmployeeTimeEntryPeriodListObject.SelectParameters("IncludeDateRange").DefaultValue = chkIncludeDateRange.Checked
        Me.dsAccountEmployeeTimeEntryPeriodListObject.SelectParameters("TimesheetApprovalStatusId").DefaultValue = Me.ddlApprovalStatus.SelectedValue
    End Sub

End Class
