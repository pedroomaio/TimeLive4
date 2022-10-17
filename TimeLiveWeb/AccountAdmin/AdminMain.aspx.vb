''' <summary>
''' AdminMain web form
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_AdminMain
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' Calling page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Changing text by resource of organization setup group
        Me.Literal1.Text = ResourceHelper.GetFromResource("Administration")
        Me.Literal9.Text = ResourceHelper.GetFromResource("Organization Setup")
        Me.HyperLink55.Text = ResourceHelper.GetFromResource("Locations")
        Me.HyperLink2.ToolTip = ResourceHelper.GetFromResource("Locations")
        Me.HyperLink2.ToolTip = ResourceHelper.GetFromResource("Locations")
        Me.HyperLink3.ToolTip = ResourceHelper.GetFromResource("Departments")
        Me.HyperLink56.ToolTip = ResourceHelper.GetFromResource("Departments")
        Me.HyperLink56.Text = ResourceHelper.GetFromResource("Departments")
        Me.HyperLink54.ToolTip = ResourceHelper.GetFromResource("Roles")
        Me.HyperLink57.ToolTip = ResourceHelper.GetFromResource("Roles")
        Me.HyperLink57.Text = ResourceHelper.GetFromResource("Roles")
        Me.HyperLink61.ToolTip = ResourceHelper.GetFromResource("ReportsAdministration")
        Me.HyperLink61.Text = ResourceHelper.GetFromResource("ReportsAdministration")


        'Changing text by resource of application setup group
        Me.Literal2.Text = ResourceHelper.GetFromResource("Application Setup")
        Me.HyperLink9.ToolTip = ResourceHelper.GetFromResource("Manage Terminology")
        Me.HyperLink9.ToolTip = ResourceHelper.GetFromResource("Manage Terminology")
        Me.HyperLink17.Text = ResourceHelper.GetFromResource("Manage Terminology")
        Me.HyperLink7.ToolTip = ResourceHelper.GetFromResource("Currencies")
        Me.HyperLink7.ToolTip = ResourceHelper.GetFromResource("Currencies")
        Me.HyperLink15.Text = ResourceHelper.GetFromResource("Currencies")
        Me.HyperLink1.ToolTip = ResourceHelper.GetFromResource("Email Notification Preferences")
        Me.HyperLink1.ToolTip = ResourceHelper.GetFromResource("Email Notification Preferences")
        Me.HyperLink13.Text = ResourceHelper.GetFromResource("Email Notification Preferences")
        Me.HyperLink8.ToolTip = ResourceHelper.GetFromResource("Approvals")
        Me.HyperLink8.ToolTip = ResourceHelper.GetFromResource("Approvals")
        Me.HyperLink16.Text = ResourceHelper.GetFromResource("Approvals")
        Me.HyperLink6.ToolTip = ResourceHelper.GetFromResource("Role Permissions")
        Me.HyperLink6.ToolTip = ResourceHelper.GetFromResource("Role Permissions")
        Me.HyperLink14.Text = ResourceHelper.GetFromResource("Role Permissions")
        Me.HyperLink45.ToolTip = ResourceHelper.GetFromResource("Preferences")
        Me.HyperLink45.ToolTip = ResourceHelper.GetFromResource("Preferences")
        Me.HyperLink48.Text = ResourceHelper.GetFromResource("Preferences")
        Me.HyperLink71.ToolTip = ResourceHelper.GetFromResource("Status Type")
        Me.HyperLink71.ToolTip = ResourceHelper.GetFromResource("Status Type")
        Me.HyperLink72.Text = ResourceHelper.GetFromResource("Status Type")
        Me.HyperLink65.ToolTip = ResourceHelper.GetFromResource("External Users")
        Me.HyperLink78.ToolTip = ResourceHelper.GetFromResource("External Users")
        Me.HyperLink78.Text = ResourceHelper.GetFromResource("External Users")
        Me.HyperLink11.ToolTip = ResourceHelper.GetFromResource("Custom Field")
        Me.HyperLink12.ToolTip = ResourceHelper.GetFromResource("Custom Field")
        Me.HyperLink12.Text = ResourceHelper.GetFromResource("Custom Field")

        'Changing text by resource of project / task setup group
        Me.Literal4.Text = ResourceHelper.GetFromResource("Project / Task Setup")
        Me.HyperLink5.ToolTip = ResourceHelper.GetFromResource("Task Types")
        Me.HyperLink5.ToolTip = ResourceHelper.GetFromResource("Task Types")
        Me.HyperLink59.Text = ResourceHelper.GetFromResource("Task Types")
        Me.HyperLink18.ToolTip = ResourceHelper.GetFromResource("Priorities")
        Me.HyperLink18.ToolTip = ResourceHelper.GetFromResource("Priorities")
        Me.HyperLink62.Text = ResourceHelper.GetFromResource("Priorities")
        Me.HyperLink49.ToolTip = ResourceHelper.GetFromResource("Project Types")
        Me.HyperLink49.ToolTip = ResourceHelper.GetFromResource("Project Types")
        Me.HyperLink63.Text = ResourceHelper.GetFromResource("Project Types")
        Me.HyperLink51.ToolTip = ResourceHelper.GetFromResource("Project Templates")
        Me.HyperLink51.ToolTip = ResourceHelper.GetFromResource("Project Templates")
        Me.HyperLink64.Text = ResourceHelper.GetFromResource("Project Templates")
        Me.HyperLink58.ToolTip = ResourceHelper.GetFromResource("Billing Types")
        Me.HyperLink58.ToolTip = ResourceHelper.GetFromResource("Billing Types")
        Me.HyperLink66.Text = ResourceHelper.GetFromResource("Billing Types")

        'Changing text by resource of timesheet setup group
        Me.Literal3.Text = ResourceHelper.GetFromResource("Timesheet Setup")
        Me.HyperLink24.ToolTip = ResourceHelper.GetFromResource("Timesheet Period Types")
        Me.HyperLink36.ToolTip = ResourceHelper.GetFromResource("Timesheet Period Types")
        Me.HyperLink36.Text = ResourceHelper.GetFromResource("Timesheet Period Types")
        Me.HyperLink29.ToolTip = ResourceHelper.GetFromResource("Holiday Types")
        Me.HyperLink42.ToolTip = ResourceHelper.GetFromResource("Holiday Types")
        Me.HyperLink42.Text = ResourceHelper.GetFromResource("Holiday Types")
        Me.HyperLink34.ToolTip = ResourceHelper.GetFromResource("Holiday Select")
        Me.HyperLink43.ToolTip = ResourceHelper.GetFromResource("Holiday Select")
        Me.HyperLink43.Text = ResourceHelper.GetFromResource("Holiday Select")
        Me.HyperLink28.ToolTip = ResourceHelper.GetFromResource("Time Entry Archive")
        Me.HyperLink28.ToolTip = ResourceHelper.GetFromResource("Time Entry Archive")
        Me.HyperLink41.Text = ResourceHelper.GetFromResource("Time Entry Archive")
        Me.HyperLink27.ToolTip = ResourceHelper.GetFromResource("Working Days")
        Me.HyperLink27.ToolTip = ResourceHelper.GetFromResource("Working Days")
        Me.HyperLink38.Text = ResourceHelper.GetFromResource("Working Days")
        Me.HyperLink35.ToolTip = ResourceHelper.GetFromResource("Absence Type")
        Me.HyperLink35.ToolTip = ResourceHelper.GetFromResource("Absence Type")
        Me.HyperLink44.Text = ResourceHelper.GetFromResource("Absence Type")
        Me.HyperLink67.ToolTip = ResourceHelper.GetFromResource("Work Types")
        Me.HyperLink67.ToolTip = ResourceHelper.GetFromResource("Work Types")
        Me.HyperLink68.Text = ResourceHelper.GetFromResource("Work Types")
        Me.HyperLink70.Text = ResourceHelper.GetFromResource("Cost Center")
        Me.HyperLink70.ToolTip = ResourceHelper.GetFromResource("Cost Center")
        Me.HyperLink69.ToolTip = ResourceHelper.GetFromResource("Cost Center")
        Me.HyperLink53.ToolTip = ResourceHelper.GetFromResource("Employee Types")
        Me.HyperLink77.ToolTip = ResourceHelper.GetFromResource("Employee Types")
        Me.HyperLink77.Text = ResourceHelper.GetFromResource("Employee Types")

        'Changing text by resource of time off setup group
        Me.Literal5.Text = ResourceHelper.GetFromResource("Time Off Setup")
        Me.HyperLink30.ToolTip = ResourceHelper.GetFromResource("Time Off Types")
        Me.HyperLink37.ToolTip = ResourceHelper.GetFromResource("Time Off Types")
        Me.HyperLink37.Text = ResourceHelper.GetFromResource("Time Off Types")
        Me.HyperLink18.ToolTip = ResourceHelper.GetFromResource("Time Off Policies")
        Me.HyperLink18.ToolTip = ResourceHelper.GetFromResource("Time Off Policies")
        Me.HyperLink20.Text = ResourceHelper.GetFromResource("Time Off Policies")

        'Changing text by resource of expense setup group
        Me.Literal6.Text = ResourceHelper.GetFromResource("Expense Setup")
        Me.HyperLink31.ToolTip = ResourceHelper.GetFromResource("Expense Entry Archive")
        Me.HyperLink4.ToolTip = ResourceHelper.GetFromResource("Expense Entry Archive")
        Me.HyperLink4.Text = ResourceHelper.GetFromResource("Expense Entry Archive")
        Me.HyperLink60.ToolTip = ResourceHelper.GetFromResource("Tax Code")
        Me.HyperLink80.ToolTip = ResourceHelper.GetFromResource("Tax Code")
        Me.HyperLink80.Text = ResourceHelper.GetFromResource("Tax Code")
        Me.HyperLink40.ToolTip = ResourceHelper.GetFromResource("Payment Method")
        Me.HyperLink47.ToolTip = ResourceHelper.GetFromResource("Payment Method")
        Me.HyperLink47.Text = ResourceHelper.GetFromResource("Payment Method")
        Me.HyperLink81.ToolTip = ResourceHelper.GetFromResource("Tax Zone")
        Me.HyperLink82.ToolTip = ResourceHelper.GetFromResource("Tax Zone")
        Me.HyperLink82.Text = ResourceHelper.GetFromResource("Tax Zone")
        Me.HyperLink25.ToolTip = ResourceHelper.GetFromResource("Expense Types")
        Me.HyperLink32.ToolTip = ResourceHelper.GetFromResource("Expense Types")
        Me.HyperLink32.Text = ResourceHelper.GetFromResource("Expense Types")
        Me.HyperLink26.ToolTip = ResourceHelper.GetFromResource("Expenses")
        Me.HyperLink33.ToolTip = ResourceHelper.GetFromResource("Expenses")
        Me.HyperLink33.Text = ResourceHelper.GetFromResource("Expenses")

        'Changing text by resource of account setup group
        Me.Literal34.Text = ResourceHelper.GetFromResource("Account Setup")
        Me.HyperLink22.ToolTip = ResourceHelper.GetFromResource("Disable Account")
        Me.HyperLink23.ToolTip = ResourceHelper.GetFromResource("Disable Account")
        Me.HyperLink23.Text = ResourceHelper.GetFromResource("Disable Account")
        Me.HyperLink50.ToolTip = ResourceHelper.GetFromResource("Feature Management")
        Me.HyperLink39.ToolTip = ResourceHelper.GetFromResource("License Manager")
        Me.HyperLink52.ToolTip = ResourceHelper.GetFromResource("Feature Management")
        Me.HyperLink52.Text = ResourceHelper.GetFromResource("Feature Management")
        Me.HyperLink46.ToolTip = ResourceHelper.GetFromResource("License Manager")
        Me.HyperLink46.Text = ResourceHelper.GetFromResource("License Manager")
        'Changing text by resource of import / export group
        Me.Literal7.Text = ResourceHelper.GetFromResource("Import / Export")
        Me.HyperLink19.ToolTip = ResourceHelper.GetFromResource("Import / Export CSV")
        Me.HyperLink21.ToolTip = ResourceHelper.GetFromResource("Import / Export CSV")
        Me.HyperLink21.Text = ResourceHelper.GetFromResource("Import / Export CSV")

        '' ''Changing text by resource of Integration group.
        Me.ltIntegration.Text = "Integration"
        Me.hlQBOnline.ToolTip = "QuickBooks Online"
        Me.hlQBOnline2.ToolTip = "QuickBooks Online"
        Me.hlQBOnline2.Text = "QuickBooks Online"

        'Changing text by resource of Currencies and Tax group
        Me.Literal8.Text = ResourceHelper.GetFromResource("Currencies and Tax")
        Me.HyperLink7.ToolTip = ResourceHelper.GetFromResource("Currency")
        Me.HyperLink60.ToolTip = ResourceHelper.GetFromResource("Tax Code")
        Me.HyperLink81.ToolTip = ResourceHelper.GetFromResource("Tax Zone")
       
       
        'Changing text by resource of Billing Setup group
        Me.Literal12.Text = ResourceHelper.GetFromResource("Billing Setup")
        Me.HyperLink58.ToolTip = ResourceHelper.GetFromResource("Billing Types")


    End Sub
End Class
