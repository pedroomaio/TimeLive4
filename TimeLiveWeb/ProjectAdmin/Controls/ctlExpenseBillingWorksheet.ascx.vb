Partial Class ProjectAdmin_Controls_ctlExpenseBillingWorksheet
    Inherits System.Web.UI.UserControl
    Dim Amount As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ReportUtilities.SetDefaultValuesOfFilerItemBilling(Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            Me.ShowGridFromFilter()
        End If


        Me.Literal5.Text = ResourceHelper.GetFromResource("Expense Billing Worksheet")
        Me.Literal1.Text = ResourceHelper.GetFromResource("Search Parameters")
        Me.Literal3.Text = ResourceHelper.GetFromResource("Project:")
        Me.Literal4.Text = ResourceHelper.GetFromResource("Client Name:")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Expense Name:")
        Me.Literal6.Text = ResourceHelper.GetFromResource("Expense Type:")
        Me.Literal79.Text = ResourceHelper.GetFromResource("Billed:")
        Me.Literal8.Text = ResourceHelper.GetFromResource("Include Date Range:")
        Me.Literal9.Text = ResourceHelper.GetFromResource("Start Date:")
        Me.Literal10.Text = ResourceHelper.GetFromResource("End Date:")
    End Sub
    Public Sub ShowGridFromFilter()
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)

        Me.dsExpenseBillingWorksheetObject.SelectParameters("AccountProjectId").DefaultValue = Me.ddlProjects.SelectedValue
        Me.dsExpenseBillingWorksheetObject.SelectParameters("AccountExpenseId").DefaultValue = Me.ddlExpense.SelectedValue
        Me.dsExpenseBillingWorksheetObject.SelectParameters("AccountExpenseTypeId").DefaultValue = Me.ddlExpenseType.SelectedValue
        Me.dsExpenseBillingWorksheetObject.SelectParameters("AccountClientId").DefaultValue = Me.ddlClients.SelectedValue
        Me.dsExpenseBillingWorksheetObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked
        Me.dsExpenseBillingWorksheetObject.SelectParameters("ExpenseEntryStartDate").DefaultValue = Me.StartDate.SelectedDate
        Me.dsExpenseBillingWorksheetObject.SelectParameters("ExpenseEntryEndDate").DefaultValue = Me.EndDate.SelectedDate
        Me.dsExpenseBillingWorksheetObject.SelectParameters("Billed").DefaultValue = Me.ddlBilled.SelectedValue

        Me.GridView1.DataBind()
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndEdit(131, GridView1, 8)
        'Me.btnDeleteSelectedItem.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(131, 4)
    End Sub
    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        ShowGridFromFilter()
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
