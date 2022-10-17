
Partial Class AccountAdmin_Controls_ctlAccountBillingRateList
    Inherits System.Web.UI.UserControl
    Dim sbti As Integer

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
        End If
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If


    End Sub

    Protected Sub dsAccountBillingRateFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountBillingRateFormViewObject.Inserted

        DBUtilities.AfterInsert(Me.GridView1)
        'Me.BoundGrid()

        'Dim BillingRateBLL As New AccountBillingRateBLL
        'If Me.FormView1.CurrentMode = FormViewMode.Edit Then
        '    'If CType(Me.FormView1.FindControl("chkSelect"), CheckBox).Checked = True Then
        '    '    BillingRateBLL.UpdateBillingRateOfTimeEntry(BillingRateBLL.GetLastInsertedId, CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate)
        '    'End If
        'End If
    End Sub

    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            e.Values.Item("SystemBillingRateTypeId") = Me.ddlSystemBillingRateTypeId.SelectedValue
            e.Values.Item("AccountId") = DBUtilities.GetSessionAccountId
            e.Values.Item("AccountEmployeeId") = Me.Request.QueryString("AccountEmployeeId")
            e.Values.Item("AccountProjectEmployeeId") = Me.Request.QueryString("AccountProjectEmployeeId")
            e.Values.Item("AccountProjectRoleId") = Me.Request.QueryString("AccountProjectRoleId")
            e.Values.Item("AccountProjectTaskId") = Me.Request.QueryString("AccountProjectTaskId")
            e.Values.Item("AccountWorkTypeId") = Me.Request.QueryString("AccountWorkTypeId")
        End If

    End Sub

    Protected Sub GridView1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBinding

    End Sub

    Protected Sub GridView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Load
        Dim Grid As GridView = Me.UpdatePanel2.FindControl("GridView1")
        Grid.DataSourceID = ""
        If Me.Request.QueryString("SystemBillingRateTypeId") = 1 Then
            Grid.DataSourceID = "dsAccountEmployeeBillingRate"
            Grid.DataBind()
            EmployeeNameTextBox.Text = CType(New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId")).Rows(0), AccountEmployee.AccountEmployeeRow).FirstName + " " + CType(New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId")).Rows(0), AccountEmployee.AccountEmployeeRow).LastName
            Me.ddlSystemBillingRateTypeId.SelectedValue = Me.Request.QueryString("SystemBillingRateTypeId")
            lblProjectName.Visible = False
            ProjectNameTextBox.Visible = False
        ElseIf Me.Request.QueryString("SystemBillingRateTypeId") = 2 Then
            Grid.DataSourceID = "dsAccountProjectRoleBillingRate"
            Grid.DataBind()
            ProjectNameTextBox.Text = CType(New AccountProjectRoleBLL().GetvueAccountProjectRolesByAccountProjectRoleId(Me.Request.QueryString("AccountProjectRoleId")).Rows(0), TimeLiveDataSet.vueAccountProjectRoleRow).ProjectName
            EmployeeNameTextBox.Visible = False
            lblEmployeeName.Visible = False
            Me.ddlSystemBillingRateTypeId.SelectedValue = Me.Request.QueryString("SystemBillingRateTypeId")
        ElseIf Me.Request.QueryString("SystemBillingRateTypeId") = 3 Then
            Grid.DataSourceID = "dsAccountProjectEmployeeBillingRate"
            Grid.DataBind()
            ProjectNameTextBox.Text = CType(New AccountProjectEmployeeBLL().GetAccountProjectEmployeesByAccountProjectEmployeeId(Me.Request.QueryString("AccountProjectEmployeeId")).Rows(0), TimeLiveDataSet.vueAccountProjectEmployeeRow).ProjectName
            EmployeeNameTextBox.Text = CType(New AccountProjectEmployeeBLL().GetAccountProjectEmployeesByAccountProjectEmployeeId(Me.Request.QueryString("AccountProjectEmployeeId")).Rows(0), TimeLiveDataSet.vueAccountProjectEmployeeRow).FullName
            Me.ddlSystemBillingRateTypeId.SelectedValue = Me.Request.QueryString("SystemBillingRateTypeId")
            Me.ddlSystemBillingRateTypeId.SelectedValue = Me.Request.QueryString("SystemBillingRateTypeId")
        ElseIf Me.Request.QueryString("SystemBillingRateTypeId") = 4 Then
            Grid.DataSourceID = "dsAccountProjectTaskBillingRate"
            Grid.DataBind()
            lblEmployeeName.Visible = False
            EmployeeNameTextBox.Visible = False
            ProjectNameTextBox.Text = CType(New AccountProjectTaskBLL().GetvueAccountProjectEmployeeTaskByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId")).Rows(0), TimeLiveDataSet.vueAccountProjectEmployeeTaskRow).ProjectName
            ProjectTaskTextBox.Text = CType(New AccountProjectTaskBLL().GetvueAccountProjectEmployeeTaskByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId")).Rows(0), TimeLiveDataSet.vueAccountProjectEmployeeTaskRow).TaskName
            Me.ddlSystemBillingRateTypeId.SelectedValue = Me.Request.QueryString("SystemBillingRateTypeId")
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
        'If e.CommandName = "Delete" Then
        '    Dim BillingRateId As Integer = Convert.ToInt32(e.CommandArgument)
        '    Dim BillingRateBLL As New AccountBillingRateBLL
        '    BillingRateBLL.DeleteAccountBillingRate(BillingRateId)
        'End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermission(95, Me.GridView1, Me.FormView1, "btnAdd", 4, 5)
        If Not Me.IsPostBack Then
        End If
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub


    Protected Sub dsAccountBillingRateFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountBillingRateFormViewObject.Updated
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Dim BillingRateBLL As New AccountBillingRateBLL

        If CType(Me.FormView1.FindControl("chkUpdateBillingRate"), CheckBox).Checked = True Then
            BillingRateBLL.UpdateBillingRateOfTimeEntry(Me.FormView1.DataKey("AccountBillingRateId"), Me.Request.QueryString("SystemBillingRateTypeId"), Me.Request.QueryString("AccountProjectEmployeeId"), Me.Request.QueryString("AccountProjectRoleId"), Me.Request.QueryString("AccountEmployeeId"), Me.Request.QueryString("AccountProjectTaskId"), CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text, Me.Request.QueryString("AccountWorkTypeId"), CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId)
        End If
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("SystemBillingRateTypeId") = Me.Request.QueryString("SystemBillingRateTypeId")
            e.NewValues.Item("AccountId") = DBUtilities.GetSessionAccountId
            e.NewValues.Item("AccountEmployeeId") = Me.Request.QueryString("AccountEmployeeId")
            e.NewValues.Item("AccountProjectEmployeeId") = Me.Request.QueryString("AccountProjectEmployeeId")
            e.NewValues.Item("AccountProjectRoleId") = Me.Request.QueryString("AccountProjectRoleId")
            e.NewValues.Item("AccountProjectTaskId") = Me.Request.QueryString("AccountProjectTaskId")
            e.NewValues.Item("AccountWorkTypeId") = Me.Request.QueryString("AccountWorkTypeId")
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim BillingRateId As Integer = Me.GridView1.DataKeys(e.RowIndex)("AccountBillingRateId")
        Dim objBillingRate As New AccountBillingRateBLL
        objBillingRate.DeleteAccountBillingRate(BillingRateId)
        Me.GridView1.DataBind()
        '        e.Cancel = False
    End Sub

    Protected Sub dsAccountEmployeeBillingRate_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsAccountEmployeeBillingRate.Selecting
        e.InputParameters("AccountEmployeeId") = Me.Request.QueryString("AccountEmployeeId")
        e.InputParameters("AccountWorkTypeId") = Me.Request.QueryString("AccountWorkTypeId")
    End Sub

    Protected Sub dsAccountProjectRoleBillingRate_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsAccountProjectRoleBillingRate.Selecting
        e.InputParameters("AccountProjectRoleId") = Me.Request.QueryString("AccountProjectRoleId")
        e.InputParameters("AccountWorkTypeId") = Me.Request.QueryString("AccountWorkTypeId")
    End Sub

    Protected Sub dsAccountProjectEmployeeBillingRate_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsAccountProjectEmployeeBillingRate.Selecting
        e.InputParameters("AccountProjectEmployeeId") = Me.Request.QueryString("AccountProjectEmployeeId")
        e.InputParameters("AccountWorkTypeId") = Me.Request.QueryString("AccountWorkTypeId")
    End Sub

    Protected Sub dsAccountProjectTaskBillingRate_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsAccountProjectTaskBillingRate.Selecting
        e.InputParameters("AccountProjectTaskId") = Me.Request.QueryString("AccountProjectTaskId")
        e.InputParameters("AccountWorkTypeId") = Me.Request.QueryString("AccountWorkTypeId")
    End Sub
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode

        If System.Web.HttpContext.Current.Request.QueryString("SystemBillingRateTypeId") = "1" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(4)
        ElseIf System.Web.HttpContext.Current.Request.QueryString("SystemBillingRateTypeId") = "2" Then
            If Me.Request.QueryString("Source") = "MyProjects" Then
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(86, "~/ProjectAdmin/AccountProjectRole.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects", 27)
            ElseIf Me.Request.QueryString("Source") = "ProjectTemplates" Then
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(86, "~/ProjectAdmin/AccountProjectRole.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&IsTemplate=True&Source=ProjectTemplates", 103)
            Else
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(86, "~/ProjectAdmin/AccountProjectRole.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId"), 31)
            End If
        ElseIf System.Web.HttpContext.Current.Request.QueryString("SystemBillingRateTypeId") = "3" Then
            If Me.Request.QueryString("Source") = "MyProjects" Then
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(88, "~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects", 27)
            ElseIf Me.Request.QueryString("Source") = "ProjectTemplates" Then
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(88, "~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&IsTemplate=True&Source=ProjectTemplates", 103)
            Else
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(88, "~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId"), 31)
            End If
        ElseIf System.Web.HttpContext.Current.Request.QueryString("SystemBillingRateTypeId") = "4" Then
            If Me.Request.QueryString("Source") = "MyProjects" Then
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(32, "~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=MyProjects", 27)
            ElseIf Me.Request.QueryString("Source") = "ProjectTemplates" Then
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(32, "~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&IsTemplate=True&Source=ProjectTemplates", 103)
            Else
                Return AccountPagePermissionBLL.ChangeCurrentNodeParent(32, "~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"), 31)
            End If
        End If

    End Function

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
End Class
