
Imports AccountExpenseEntryTableAdapters

Partial Class Employee_Controls_ctlManageApprovals
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim vb As New AccountExpenseEntryBLL
        Dim vbOff As New AccountEmployeeTimeOffRequestBLL
        Dim vbTime As New AccountEmployeeTimeEntryBLL
        Me.Literal1.Text = ResourceHelper.GetFromResource("Manage Approvals")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Approvals")
        Me.HyperLinkProjectMilestone.ToolTip = ResourceHelper.GetFromResource("Timesheet Approval")
        Me.TextHyperlinkDepartment.ToolTip = ResourceHelper.GetFromResource("Timesheet Approval")
        Me.TextHyperlinkDepartment.Text = ResourceHelper.GetFromResource("Timesheet Approval")
        Me.HyperLinkRoles.ToolTip = ResourceHelper.GetFromResource("Expense Approval")
        Me.TextHyperlinkRoles.ToolTip = ResourceHelper.GetFromResource("Expense Approval")
        Me.TextHyperlinkRoles.Text = ResourceHelper.GetFromResource("Expense Approval")
        Me.HyperLinkWorkingDays.ToolTip = ResourceHelper.GetFromResource("Time Off Approval")
        Me.TextHyperlinkWorkingDays.ToolTip = ResourceHelper.GetFromResource("Time Off Approval")
        Me.TextHyperlinkWorkingDays.Text = ResourceHelper.GetFromResource("Time Off Approval")
        Dim ExpenseCount As Integer = vb.GetApprovalCount(DBUtilities.GetSessionAccountEmployeeId)
        Dim TimeOffCount As Integer = vbOff.GetTimeOffApprovalCount(DBUtilities.GetSessionAccountEmployeeId)
        Dim TimesheetCount As Integer = vbTime.GetTimesheetApprovalCount(DBUtilities.GetSessionAccountEmployeeId)

        If ExpenseCount = 0 Then
            Me.ExpenseApproval.Attributes.Add("Class", "notify-approval")
        Else
            Me.ExpenseApproval.Attributes.Add("Class", "notify-newapproval")
            Me.ExpenseApproval.InnerText = ExpenseCount.ToString()
        End If
        If TimeOffCount = 0 Then
            Me.TimeOffApproval.Attributes.Add("Class", "notify-approval")
        Else
            Me.TimeOffApproval.Attributes.Add("Class", "notify-newapproval")
            Me.TimeOffApproval.InnerText = TimeOffCount.ToString()
        End If
        If TimesheetCount = 0 Then
            Me.TimesheetApproval.Attributes.Add("Class", "notify-approval")
        Else
            Me.TimesheetApproval.Attributes.Add("Class", "notify-newapproval")
            Me.TimesheetApproval.InnerText = TimesheetCount.ToString()
        End If
    End Sub
End Class
