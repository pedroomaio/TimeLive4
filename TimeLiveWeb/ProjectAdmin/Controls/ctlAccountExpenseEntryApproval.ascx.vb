
Partial Class AccountAdmin_Controls_ctlAccountExpenseEntryApproval
    Inherits System.Web.UI.UserControl

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtExpenseEntryStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtExpenseEntryStartDate.PostedDate)
        Me.txtExpenseEntryEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtExpenseEntryEndDate.PostedDate)
        Me.RefreshGridApprovalEntriesForTeamLead()
    End Sub
    Public Sub RefreshGridApprovalEntriesForTeamLead()
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("ExpenseEntryAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("ExpenseEntryStartDate").DefaultValue = Me.txtExpenseEntryStartDate.SelectedValue
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("ExpenseEntryEndDate").DefaultValue = Me.txtExpenseEntryEndDate.SelectedValue
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("ExpenseEntryAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("ExpenseEntryStartDate").DefaultValue = Me.txtExpenseEntryStartDate.SelectedValue
        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("ExpenseEntryEndDate").DefaultValue = Me.txtExpenseEntryEndDate.SelectedValue
        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("ExpenseEntryAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("ExpenseEntryStartDate").DefaultValue = Me.txtExpenseEntryStartDate.SelectedValue
        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("ExpenseEntryEndDate").DefaultValue = Me.txtExpenseEntryEndDate.SelectedValue
        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.dsApprovalEntriesForSpeicifExternalUserObject.SelectParameters("ExpenseEntryAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsApprovalEntriesForSpeicifExternalUserObject.SelectParameters("ExpenseEntryStartDate").DefaultValue = Me.txtExpenseEntryStartDate.SelectedValue
        Me.dsApprovalEntriesForSpeicifExternalUserObject.SelectParameters("ExpenseEntryEndDate").DefaultValue = Me.txtExpenseEntryEndDate.SelectedValue
        Me.dsApprovalEntriesForSpeicifExternalUserObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("ExpenseEntryAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("ExpenseEntryStartDate").DefaultValue = Me.txtExpenseEntryStartDate.SelectedValue
        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("ExpenseEntryEndDate").DefaultValue = Me.txtExpenseEntryEndDate.SelectedValue
        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
        Me.GridView3.DataBind()
        Me.GridView4.DataBind()
        Me.GridView5.DataBind()



    End Sub

    Protected Sub btnUpdate1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate1.Click

        Me.ForApproved()
        Me.ForReject()
        Me.RefreshGridApprovalEntriesForTeamLead()

        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub dsApprovalEntriesForTeamLeadObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsApprovalEntriesForTeamLeadObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub ApprovalEntriesForProjectManagerObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ApprovalEntriesForProjectManagerObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub ApprovalEntriesForSpecificEmployeeObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ApprovalEntriesForSpecificEmployeeObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub dsApprovalEntriesForSpeicifExternalUserObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsApprovalEntriesForSpeicifExternalUserObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Public Sub ForApproved()
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL

        For Each row As GridViewRow In Me.GridView1.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApproved(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("chkTeamLead"), CheckBox), CType(row.FindControl("TeamLeadCommentsTextBox"), TextBox).Text, "TeamLead", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedValue, Me.txtExpenseEntryEndDate.SelectedValue, DBUtilities.GetSessionAccountEmployeeId, Me.GridView1.DataKeys(row.RowIndex)(1))
        Next

        For Each row1 As GridViewRow In Me.GridView2.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApproved(Me.GridView2.DataKeys(row1.RowIndex)(0), CType(row1.FindControl("chkProjectManager"), CheckBox), CType(row1.FindControl("ProjectManagerCommentsTextBox"), TextBox).Text, "ProjectManager", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedValue, Me.txtExpenseEntryEndDate.SelectedValue, DBUtilities.GetSessionAccountEmployeeId, Me.GridView2.DataKeys(row1.RowIndex)(1))
        Next

        For Each row2 As GridViewRow In Me.GridView3.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApproved(Me.GridView3.DataKeys(row2.RowIndex)(0), CType(row2.FindControl("chkSpecificEmployee"), CheckBox), CType(row2.FindControl("SpecificEmployeeCommentsTextBox"), TextBox).Text, "SpecificEmployee", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedValue, Me.txtExpenseEntryEndDate.SelectedValue, DBUtilities.GetSessionAccountEmployeeId, Me.GridView3.DataKeys(row2.RowIndex)(1))
        Next

        For Each row3 As GridViewRow In Me.GridView4.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApproved(Me.GridView4.DataKeys(row3.RowIndex)(0), CType(row3.FindControl("chkSpecificExternalUser"), CheckBox), CType(row3.FindControl("SpecificExternalUserCommentsTextBox"), TextBox).Text, "SpecificExternalUser", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedValue, Me.txtExpenseEntryEndDate.SelectedValue, DBUtilities.GetSessionAccountEmployeeId, Me.GridView4.DataKeys(row3.RowIndex)(1))
        Next

        For Each row4 As GridViewRow In Me.GridView5.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApproved(Me.GridView5.DataKeys(row4.RowIndex)(0), CType(row4.FindControl("chkEmployeeManager"), CheckBox), CType(row4.FindControl("EmployeeManagerCommentsTextBox"), TextBox).Text, "EmployeeManager", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedValue, Me.txtExpenseEntryEndDate.SelectedValue, DBUtilities.GetSessionAccountEmployeeId, Me.GridView5.DataKeys(row4.RowIndex)(1))
        Next
    End Sub
    Public Sub ForReject()
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL

        For Each row As GridViewRow In Me.GridView1.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForRejected(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("chkTeamLeadRejected"), CheckBox), CType(row.FindControl("TeamLeadCommentsTextBox"), TextBox).Text, "TeamLead", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedDate, Me.txtExpenseEntryEndDate.SelectedDate, DBUtilities.GetSessionAccountEmployeeId, Me.GridView1.DataKeys(row.RowIndex)(1))
        Next

        For Each row1 As GridViewRow In Me.GridView2.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForRejected(Me.GridView2.DataKeys(row1.RowIndex)(0), CType(row1.FindControl("chkProjectManagerRejected"), CheckBox), CType(row1.FindControl("ProjectManagerCommentsTextBox"), TextBox).Text, "ProjectManager", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedDate, Me.txtExpenseEntryEndDate.SelectedDate, DBUtilities.GetSessionAccountEmployeeId, Me.GridView2.DataKeys(row1.RowIndex)(1))
        Next

        For Each row2 As GridViewRow In Me.GridView3.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForRejected(Me.GridView3.DataKeys(row2.RowIndex)(0), CType(row2.FindControl("chkSpecificEmployeeRejected"), CheckBox), CType(row2.FindControl("SpecificEmployeeCommentsTextBox"), TextBox).Text, "SpecificEmployee", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedDate, Me.txtExpenseEntryEndDate.SelectedDate, DBUtilities.GetSessionAccountEmployeeId, Me.GridView3.DataKeys(row2.RowIndex)(1))
        Next

        For Each row3 As GridViewRow In Me.GridView4.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForRejected(Me.GridView4.DataKeys(row3.RowIndex)(0), CType(row3.FindControl("chkSpecificExternalUserRejected"), CheckBox), CType(row3.FindControl("SpecificExternalUserCommentsTextBox"), TextBox).Text, "SpecificExternalUser", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedDate, Me.txtExpenseEntryEndDate.SelectedDate, DBUtilities.GetSessionAccountEmployeeId, Me.GridView4.DataKeys(row3.RowIndex)(1))
        Next

        For Each row4 As GridViewRow In Me.GridView5.Rows
            ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForRejected(Me.GridView5.DataKeys(row4.RowIndex)(0), CType(row4.FindControl("chkEmployeeManagerRejected"), CheckBox), CType(row4.FindControl("EmployeeManagerCommentsTextBox"), TextBox).Text, "EmployeeManager", Me.ddlAccountEmployeeId.SelectedValue, Me.chkIncludeDateRange.Checked, Me.txtExpenseEntryStartDate.SelectedDate, Me.txtExpenseEntryEndDate.SelectedDate, DBUtilities.GetSessionAccountEmployeeId, Me.GridView5.DataKeys(row4.RowIndex)(1))
        Next
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        For Each gvr As GridViewRow In GridView1.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkTeamLead"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs1", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView1.Rows.Count <> 0 Then
            Me.CheckAllTeamLead.Visible = True
            Me.UnCheckAllTeamLead.Visible = True
        Else
            Me.CheckAllTeamLead.Visible = False
            Me.UnCheckAllTeamLead.Visible = False
        End If
    End Sub
    Public Function GetEmployeeNavigateURL(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs, ByVal ApprovalType As String)
        Return "~/Employee/AccountExpenseEntryReadOnly.aspx?AccountEmployeeExpenseSheetId=" & DataBinder.Eval(e.Row.DataItem, "AccountEmployeeExpenseSheetId").ToString & "&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "ExpenseEntryAccountEmployeeId") & "&ApprovalType=" & ApprovalType
    End Function
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = GetEmployeeNavigateURL(e, "TeamLead")
        End If
    End Sub

    Protected Sub GridView2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.DataBound
        For Each gvr As GridViewRow In GridView2.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkProjectManager"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs2", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView2.Rows.Count <> 0 Then
            Me.CheckAllProjectManager.Visible = True
            Me.UnCheckAllProjectMananger.Visible = True
        Else
            Me.CheckAllProjectManager.Visible = False
            Me.UnCheckAllProjectMananger.Visible = False
        End If
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = GetEmployeeNavigateURL(e, "ProjectManager")
        End If
    End Sub

    Protected Sub GridView3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView3.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkSpecificEmployee"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs3", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView3.Rows.Count <> 0 Then
            Me.CheckAllSpecificEmployee.Visible = True
            Me.UnCheckAllSpecificEmployee.Visible = True
        Else
            Me.CheckAllSpecificEmployee.Visible = False
            Me.UnCheckAllSpecificEmployee.Visible = False
        End If
    End Sub

    Protected Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = GetEmployeeNavigateURL(e, "SpecificEmployee")
        End If
    End Sub
    Protected Sub GridView4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView4.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkSpecificExternalUser"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs4", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView4.Rows.Count <> 0 Then
            Me.CheckAllSpecificExternalUser.Visible = True
            Me.UnCheckAllSpecificExternalUser.Visible = True
        Else
            Me.CheckAllSpecificExternalUser.Visible = False
            Me.UnCheckAllSpecificExternalUser.Visible = False
        End If
    End Sub

    Protected Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = GetEmployeeNavigateURL(e, "SpecificExternalUser")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If LocaleUtilitiesBLL.IsShowEmployeeNameWithCode = True Then

                ddlAccountEmployeeId.DataSource = dsAccountEmployeeObject
                ddlAccountEmployeeId.DataValueField = "AccountEmployeeId"
                ddlAccountEmployeeId.DataTextField = "EmployeeNameWithCode"

            Else

                ddlAccountEmployeeId.DataSource = dsAccountEmployeeObject
                ddlAccountEmployeeId.DataValueField = "AccountEmployeeId"
                ddlAccountEmployeeId.DataTextField = "EmployeeName"

            End If
            ddlAccountEmployeeId.DataBind()
        End If
        Me.Literal4.Text = ResourceHelper.GetFromResource("Employee Name:")
        Me.Literal5.Text = ResourceHelper.GetFromResource("Include Date Range:")
        Me.Literal6.Text = ResourceHelper.GetFromResource("Expense Entry Start Date:")
        Me.Literal7.Text = ResourceHelper.GetFromResource("Expense Entry End Date:")
    End Sub

    Protected Sub GridView5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView5.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView5.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkEmployeeManager"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs5", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView5.Rows.Count <> 0 Then
            Me.CheckAllEmployeeManager.Visible = True
            Me.UnCheckAllEmployeeManager.Visible = True
        Else
            Me.CheckAllEmployeeManager.Visible = False
            Me.UnCheckAllEmployeeManager.Visible = False
        End If
    End Sub

    Protected Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = GetEmployeeNavigateURL(e, "EmployeeManager")
        End If
    End Sub

    Protected Sub dsApprovalEntriesForEmployeeManagerObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsApprovalEntriesForEmployeeManagerObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub CheckAllEmployeeManager_Click(sender As Object, e As System.EventArgs) Handles CheckAllEmployeeManager.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllProjectManager_Click(sender As Object, e As System.EventArgs) Handles CheckAllProjectManager.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllSpecificEmployee_Click(sender As Object, e As System.EventArgs) Handles CheckAllSpecificEmployee.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllSpecificExternalUser_Click(sender As Object, e As System.EventArgs) Handles CheckAllSpecificExternalUser.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllTeamLead_Click(sender As Object, e As System.EventArgs) Handles CheckAllTeamLead.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllEmployeeManager_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllEmployeeManager.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllProjectMananger_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllProjectMananger.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllSpecificEmployee_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllSpecificEmployee.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllSpecificExternalUser_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllSpecificExternalUser.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllTeamLead_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllTeamLead.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub
End Class
