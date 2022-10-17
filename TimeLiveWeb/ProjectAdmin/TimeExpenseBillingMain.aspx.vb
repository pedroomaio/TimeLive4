
Partial Class ProjectAdmin_TimeExpenseBillingMain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Literal1.Text = ResourceHelper.GetFromResource("Account Time Expense Billing")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Time Expense Billing")

        Me.HyperLinkProjectMilestone.ToolTip = ResourceHelper.GetFromResource("Invoice Management")
        Me.TextHyperlinkDepartment.ToolTip = ResourceHelper.GetFromResource("Invoice Management")
        Me.TextHyperlinkDepartment.Text = ResourceHelper.GetFromResource("Invoice Management")
        Me.HyperLinkRoles.ToolTip = ResourceHelper.GetFromResource("Time Billing Worksheet")
        Me.TextHyperlinkRoles.ToolTip = ResourceHelper.GetFromResource("Time Billing Worksheet")
        Me.TextHyperlinkRoles.Text = ResourceHelper.GetFromResource("Time Billing Worksheet")
        Me.HyperLinkWorkingDays.ToolTip = ResourceHelper.GetFromResource("Expense Billing Worksheet")
        Me.TextHyperlinkWorkingDays.ToolTip = ResourceHelper.GetFromResource("Expense Billing Worksheet")
        Me.TextHyperlinkWorkingDays.Text = ResourceHelper.GetFromResource("Expense Billing Worksheet")
    End Sub
End Class
