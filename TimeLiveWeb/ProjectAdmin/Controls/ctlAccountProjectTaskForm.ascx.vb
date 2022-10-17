Partial Class ProjectAdmin_Controls_ctlAccountProjectTaskForm
    Inherits System.Web.UI.UserControl

    Public WithEvents oListBox As ListBox
    Public ListControlValues As Hashtable
    Public Event UpdateIssueClick(ByVal sender As Object)
    Public Event SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event btnCancelClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event btnUpdateClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event AddClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
    Public Event Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
    Dim CustomFieldCaption As String
    Dim IsParentTask As Boolean
    Dim MasterEntityTypeId As New Guid("c9a8f7f1-1b2d-48da-aae9-74f92892a896")
    Protected Sub dsAccountProjectTaskFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskFormObject.Inserted

        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        ' Add Task Billing rate of task
        'ProjectTaskBLL.AddBillingRateOfTask(0, Now.Date, Now.Date, New AccountWorkTypeBLL().GetDefaultWorkType(DBUtilities.GetSessionAccountId), 0, DBUtilities.GetAccountBaseCurrencyId, DBUtilities.GetAccountBaseCurrencyId, e.ReturnValue)

        If CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked <> False Then

        Else
            Dim ts As New AccountProjectTaskEmployeeBLL
            Dim l As ListBox = Me.FormView1.FindControl("ListBoxEmployees")

            For Each s As ListItem In l.Items
                If s.Selected Then
                    ts.AddAccountProjectTaskEmployee(DBUtilities.GetSessionAccountId, 0, e.ReturnValue, s.Value, 100)
                End If
            Next
        End If

        Dim TaskBLL As New AccountProjectTaskBLL
        If Me.Request.QueryString("IsTemplate") Is Nothing Then
            TaskBLL.SendNewTaskEMail(e.ReturnValue)
        End If
        RaiseEvent Inserted(sender, e)
        ''Dim dtPTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = ProjectTaskBLL.GetAccountProjectTaskByvueAccountProjectTaskId(e.ReturnValue)
        ''Dim drPTask As TimeLiveDataSet.vueAccountProjectTaskRow
        ''If dtPTask.Rows.Count > 0 Then
        ''    drPTask = dtPTask.Rows(0)
        ''    IsParentTask = drPTask.IsParentTask
        ''End If
        If Me.Request.QueryString("IsTemplate") Is Nothing Then
            If Not Me.Request.QueryString("AccountProjectId") Is Nothing Then
                'If IsParentTask <> True And CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked <> True Then
                '   Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & ProjectTaskBLL.GetLastInsertedId & "&AccountProjectId=" & IIf(Me.Request.QueryString("AccountProjectId") = "", Me.Request.QueryString("AccountProjectId"), Me.Request.QueryString("AccountProjectId")), False)
                'Else
                Server.Transfer("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&IsTaskAdd=1", False)
                'End If
                Session("AccountProjectTaskId") = e.ReturnValue
                Session("IsAdd") = "1"
            Else
                ''s.Redirect("~/Employee/MyTasks.aspx?" & "&Source=MyTasks", False)
                Server.Transfer("~/Employee/MyTasks.aspx?" & "&Source=MyTasks&IsTaskAdd=1")
            End If
        Else
            Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & IIf(Me.Request.QueryString("AccountProjectId") = "", Me.Request.QueryString("AccountProjectId"), Me.Request.QueryString("AccountProjectId")) & "&IsTemplate=True" & "&Source=ProjectTemplates", False)
        End If

    End Sub
    Protected Sub dsAccountProjectTaskFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskFormObject.Inserting
        Dim AccountId As Integer = DBUtilities.GetSessionAccountId
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("DeadlineDate"), "DeadlineDate", e)
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("StartDate"), "StartDate", e)
        DBUtilities.SetRowForInserting(e)

        ''Advance Options
        e.InputParameters("AccountProjectId") = IIf(Me.Request.QueryString("AccountProjectId") Is Nothing, CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue, Me.Request.QueryString("AccountProjectId"))
        e.InputParameters("ParentAccountProjectTaskId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).SelectedValue
        If CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).SelectedValue <> "" Then
            e.InputParameters("AccountProjectMilestoneId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).SelectedValue
        Else
            ' ''e.Cancel = True
            ' ''CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdValidation"), RequiredFieldValidator).Enabled = True
            ' ''Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
            ' ''UIUtilities.ShowMessage("Field is required.", CurrentPage)
            ' ''Me.FormView1.Visible = True
        End If
        e.InputParameters("EstimatedCost") = IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("EstimatedCostTextBox1"), TextBox).Text = "", 0, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("EstimatedCostTextBox1"), TextBox).Text)

        e.InputParameters("EstimatedCurrencyId") = DBUtilities.GetAccountBaseCurrencyId
        e.InputParameters("EstimatedTimeSpent") = IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("EstimatedTimeSpentTextBox1"), TextBox).Text = "", 0, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("EstimatedTimeSpentTextBox1"), TextBox).Text)
        If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
            e.InputParameters("FixedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("txtFixedCostInsert"), TextBox).Text
        Else
            e.InputParameters("FixedCost") = 0
        End If
        e.InputParameters("Duration") = IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("DurationTextBoxinsert"), TextBox).Text = "", 0, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("DurationTextBoxinsert"), TextBox).Text)
        e.InputParameters("DurationUnit") = "Hours"
        e.InputParameters("IsParentTask") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("CheckBox4"), CheckBox).Checked
        e.InputParameters("TaskCode") = CType(Me.FormView1.FindControl("TaskCodeTextBoxInsert"), TextBox).Text
        e.InputParameters("TaskDescription") = CType(Me.FormView1.FindControl("TaskDescriptionTextBoxInsert"), TextBox).Text
        e.InputParameters("EstimatedTimeSpentUnit") = Nothing
        e.InputParameters("AccountBillingRateId") = 0
        e.InputParameters("CreatedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
        e.InputParameters("ModifiedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId

        Dim dttaskStatus As TimeLiveDataSet.AccountStatusDataTable = New AccountStatusBLL().GetAccountsStatusByStatusTypeId(DBUtilities.GetSessionAccountId, 4)
        Dim drtaskStatus As TimeLiveDataSet.AccountStatusRow
        drtaskStatus = dttaskStatus.Rows(0)
        If dttaskStatus.Rows.Count > 0 Then
            e.InputParameters("TaskStatusId") = drtaskStatus.AccountStatusId
        End If
        ''design change
        'Dim dtTaskType As TimeLiveDataSet.AccountTaskTypeDataTable = New AccountTaskTypeBLL().GetAccountTaskTypesByAccountId(DBUtilities.GetSessionAccountId)
        'Dim drTaskType As TimeLiveDataSet.AccountTaskTypeRow
        'drTaskType = dtTaskType.Rows(0)
        'If dtTaskType.Rows.Count > 0 Then
        e.InputParameters("AccountTaskTypeId") = CType(Me.FormView1.FindControl("ddlTaskTypeInsert"), DropDownList).SelectedValue
        e.InputParameters("IsBillable") = CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked
        'End If
        Dim dtPriority As TimeLiveDataSet.AccountPriorityDataTable = New AccountPriorityBLL().GetAccountPrioritiesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drPriority As TimeLiveDataSet.AccountPriorityRow
        drPriority = dtPriority.Rows(0)
        If dtPriority.Rows.Count > 0 Then
            e.InputParameters("AccountPriorityId") = drPriority.AccountPriorityId
        End If
    End Sub
    Protected Sub dsAccountProjectTaskFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskFormObject.Updated
        Dim ts As New AccountProjectTaskEmployeeBLL

        Dim l As ListBox = Me.FormView1.FindControl("ListBoxEmployeesUpdate")

        Me.ListControlValues = Me.ViewState("ListViewControl")

        For Each s As ListItem In l.Items
            If s.Selected And Not ListControlValues.ContainsKey(s.Value) Then
                ts.AddAccountProjectTaskEmployee(DBUtilities.GetSessionAccountId, 0, Me.dsAccountProjectTaskFormObject.SelectParameters("AccountProjectTaskId").DefaultValue, s.Value, 100)
            ElseIf s.Selected = False And ListControlValues.ContainsKey(s.Value) Then
                ts.DeleteAccountProjectTaskEmployeeId(ListControlValues.Item(s.Value))
            End If
        Next

        Dim TaskBLL As New AccountProjectTaskBLL
        If Me.Request.QueryString("IsTemplate") Is Nothing Then
            TaskBLL.SendUpdatedTaskEMail(Me.dsAccountProjectTaskFormObject.SelectParameters("AccountProjectTaskId").DefaultValue)
        End If

        Dim objAccountBillingRate As New AccountBillingRateBLL
        Dim objAccountProjectTask As New AccountProjectTaskBLL

        Dim dtProjectTask As TimeLiveDataSet.vueAccountProjectTaskWithBillingRateDataTable = objAccountProjectTask.GetAccountProjectTaskWithBillingRateByAccountProjectTaskId(Me.FormView1.DataKey("AccountProjectTaskId"), CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
        Dim drProjectTask As TimeLiveDataSet.vueAccountProjectTaskWithBillingRateRow = dtProjectTask.Rows(0)

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            BillingRateTextBox.Text = IIf(BillingRateTextBox.Text = "", 0, BillingRateTextBox.Text)
            EmployeeRateTextBox.Text = IIf(EmployeeRateTextBox.Text = "", 0, EmployeeRateTextBox.Text)
            If IsDBNull(drProjectTask("StartDate")) Then
                'change in currency
                objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 4, 0, 0, 0, Me.FormView1.DataKey("AccountProjectTaskId"), BillingRateTextBox.Text, BillingRateStartDateTextBox.SelectedDate, BillingRateEndDateTextBox.SelectedDate, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue, EmployeeRateTextBox.Text, IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId), IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId))
                objAccountProjectTask.UpdateAccountBillingRateId(objAccountBillingRate.GetLastInsertedId, Me.FormView1.DataKey("AccountProjectTaskId"))
                Me.UpdateWorkTypeBillingRateOfProjectTask(DBUtilities.GetSessionAccountId, 4, Me.FormView1.DataKey("AccountProjectTaskId"), objAccountBillingRate.GetLastInsertedId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            ElseIf BillingRateStartDateTextBox.SelectedDate = drProjectTask.StartDate Then
                objAccountBillingRate.UpdateAccountBillingRate(DBUtilities.GetSessionAccountId, 4, 0, 0, 0, BillingRateTextBox.Text, BillingRateStartDateTextBox.SelectedDate, BillingRateEndDateTextBox.SelectedDate, Me.FormView1.DataKey("AccountProjectTaskId"), CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue, EmployeeRateTextBox.Text, IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId), IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId), drProjectTask.AccountBillingRateId)
            ElseIf BillingRateStartDateTextBox.SelectedDate <> drProjectTask.StartDate Then
                objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 4, 0, 0, 0, Me.FormView1.DataKey("AccountProjectTaskId"), BillingRateTextBox.Text, BillingRateStartDateTextBox.SelectedDate, BillingRateEndDateTextBox.SelectedDate, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue, EmployeeRateTextBox.Text, IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId), IIf(CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId))
                objAccountProjectTask.UpdateAccountBillingRateId(objAccountBillingRate.GetLastInsertedId, Me.FormView1.DataKey("AccountProjectTaskId"))
                Me.UpdateWorkTypeBillingRateOfProjectTask(DBUtilities.GetSessionAccountId, 4, Me.FormView1.DataKey("AccountProjectTaskId"), objAccountBillingRate.GetLastInsertedId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            End If
        End If

        RaiseEvent Updated(sender, e)

    End Sub
    Public Sub UpdateWorkTypeBillingRateOfProjectTask(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer)

        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim objAccountProjectTask As New AccountProjectTaskBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectTaskWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectTaskId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow

        If objAccountProjectTask.IfWorkTypeBillingRateExistOfProjectTask(AccountId, SystemBillingRateTypeId, AccountProjectTaskId, AccountWorkTypeId) <> True Then
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, 0, 0, AccountProjectTaskId, AccountBillingRateId, AccountWorkTypeId)
        Else
            If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
                drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
                objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, 0, 0, AccountProjectTaskId, AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
            End If
        End If

    End Sub
    Protected Sub dsAccountProjectTaskFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskFormObject.Updating
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("DeadlineDate"), "DeadlineDate", e)
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("StartDate"), "StartDate", e)
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        'Dim BLL As New AccountProjectTaskAttachmentBLL
        'Dim AccountProjectTaskId = New AccountProjectTaskBLL().GetLastInsertedId

        'BLL.FileUpload(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("AttachmentFileUpload1"), AccountProjectTaskId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("AttachmentNameTextBox1"), TextBox).Text)
        Me.FormView1.Visible = False
        ''Me.UpdatePanel2.UpdateMode = UpdatePanelUpdateMode.Conditional
        RaiseEvent AddClick(sender, e)
    End Sub
    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        Dim TaskBll As New AccountProjectTaskBLL
        Dim CompletedTaskStatusId As Integer
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Updating(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
        If Not Me.Request.QueryString("IsTemplate") Is Nothing Then
            System.Web.HttpContext.Current.Session.Add("IsTemplate", True)
        End If
        e.NewValues.Item("AccountProjectId") = Me.Request.QueryString("AccountProjectId")

        'Other Options  Accordion 
        e.NewValues.Item("TaskCode") = CType(Me.FormView1.FindControl("TaskCodeTextBoxEdit"), TextBox).Text
        CompletedTaskStatusId = TaskBll.GetCompletedTaskStatusId("Completed")
        e.NewValues.Item("AccountTaskTypeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("DropDownList1"), DropDownList).SelectedValue
        If CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("TaskDescriptionTextBox"), TextBox).Text <> "" Then
            e.NewValues.Item("TaskDescription") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("TaskDescriptionTextBox"), TextBox).Text
        Else
            e.NewValues.Item("TaskDescription") = " "
        End If
        e.NewValues.Item("TaskStatusId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("DropDownList6"), DropDownList).SelectedValue
        e.NewValues.Item("CompletedPercent") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedPercentTextBox"), TextBox).Text
        e.NewValues.Item("Completed") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedCheckBox"), CheckBox).Checked
        e.NewValues.Item("AccountPriorityId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("DropDownList7"), DropDownList).SelectedValue
        e.NewValues.Item("IsForAllProjectTask") = CType(Me.FormView1.FindControl("checkbox5"), CheckBox).Checked
        e.NewValues.Item("IsForAllEmployees") = CType(Me.FormView1.FindControl("CheckBox3"), CheckBox).Checked
        e.NewValues.Item("IsDisabled") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("chkIsDisabled"), CheckBox).Checked

        'Advance Options Accordion 
        e.NewValues.Item("ParentAccountProjectTaskId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue
        e.NewValues.Item("AccountProjectMilestoneId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlAccountProjectMilestoneId"), DropDownList).SelectedValue
        e.NewValues.Item("EstimatedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("EstimatedCostTextBox"), TextBox).Text
        e.NewValues.Item("EstimatedTimeSpent") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("EstimatedTimeSpentTextBox"), TextBox).Text
        If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
            e.NewValues.Item("FixedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("txtFixedCost"), TextBox).Text
        Else
            e.NewValues.Item("FixedCost") = 0
        End If

        e.NewValues.Item("EstimatedCurrencyId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlEstimatedCurrencyId"), DropDownList).SelectedValue
        e.NewValues.Item("original_Predecessors") = Me.FormView1.DataKey(1)
        ''e.NewValues.Item("DurationUnit") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList3"), DropDownList).SelectedValue
        e.NewValues.Item("DurationUnit") = "Hours"
        e.NewValues.Item("Duration") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DurationTextBox"), TextBox).Text
        e.NewValues.Item("IsParentTask") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("CheckBox1"), CheckBox).Checked

        'Task Billing Rate Accordion 
        e.NewValues.Item("IsBillable") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("chkIsBillable"), CheckBox).Checked


        'Task Attachment Accordion 


    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermissionForFormView(AccountPagePermissionBLL.GetPageIdByPage(Me.Page), Me.FormView1, "Add")
        Dim ddlTaskStatusId As New DropDownList
        Dim BillingRateTextBox As New TextBox
        Dim EmployeeRateTextBox As New TextBox
        Dim BillingRateStartDateTextBox As New eWorld.UI.CalendarPopup
        Dim BillingRateEndDateTextBox As New eWorld.UI.CalendarPopup
        Dim ddlBillingRateCurrencyId As New DropDownList
        Dim ddlEstimatedCurrencyId As New DropDownList
        Dim AccountProjectId As Integer = 0
        If Not Me.FormView1.FindControl("ddlAccountProjectId") Is Nothing Then
            If CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue <> "" Then
                AccountProjectId = IIf(Me.Request.QueryString("AccountProjectId") Is Nothing, CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue, Me.Request.QueryString("AccountProjectId"))
            End If
        Else
            AccountProjectId = Me.Request.QueryString("AccountProjectId")
        End If

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.FormView1.Visible = True


            Me.RefreshEmployeesListBox(Me.FormView1.DataItem("AccountProjectTaskId"), AccountProjectId, Me.FormView1.DataItem("AccountProjectMilestoneId"))

            'Other Options  MyAccordion AccordionPane4 
            Me.Literal20.Text = ResourceHelper.GetFromResource("Other Options")
            'Me.Literal601.Text = ResourceHelper.GetFromResource("Task Code:")
            'Me.Literal8.Text = ResourceHelper.GetFromResource("Task Description:")
            'Me.Literal9.Text = ResourceHelper.GetFromResource("Task Type:")
            Me.Literal13.Text = ResourceHelper.GetFromResource("Priority:")
            Me.Literal12.Text = ResourceHelper.GetFromResource("Task Status:")
            Me.Literal64.Text = ResourceHelper.GetFromResource("Completed%:")
            Me.Literal16.Text = ResourceHelper.GetFromResource("Completed:")
            Me.Literal19.Text = ResourceHelper.GetFromResource("Disabled:")

            If Not IsDBNull(Me.FormView1.DataItem("TaskCode")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("TaskCodeTextBoxEdit"), TextBox).Text = Me.FormView1.DataItem("TaskCode")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("TaskCodeTextBoxEdit"), TextBox).Text = ""
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TaskDescription")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("TaskDescriptionTextBox"), TextBox).Text = Me.FormView1.DataItem("TaskDescription")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("TaskDescriptionTextBox"), TextBox).Text = ""
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountTaskTypeId")) Then
                Me.dsAccountProjectTaskTypeObject.SelectParameters("AccountTaskTypeId").DefaultValue = Me.FormView1.DataItem("AccountTaskTypeId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("DropDownList1"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTaskTypeId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountPriorityId")) Then
                Me.dsAccountPriorityObject.SelectParameters("AccountPriorityId").DefaultValue = Me.FormView1.DataItem("AccountPriorityId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("DropDownList7"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountPriorityId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TaskStatusId")) Then
                Me.dsProjectTaskStatusObject.SelectParameters("AccountStatusId").DefaultValue = Me.FormView1.DataItem("TaskStatusId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("DropDownList6"), DropDownList).SelectedValue = Me.FormView1.DataItem("TaskStatusId")
            End If
            If LocaleUtilitiesBLL.ShowPercentageInTimesheet() Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedPercentTextBox"), TextBox).Enabled = False
            End If
            If Not IsDBNull(Me.FormView1.DataItem("CompletedPercent")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedPercentTextBox"), TextBox).Text = Me.FormView1.DataItem("CompletedPercent")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedPercentTextBox"), TextBox).Text = 0
            End If
            If Not IsDBNull(Me.FormView1.DataItem("CompletedPercent")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedPercentTextBox"), TextBox).Text = Me.FormView1.DataItem("CompletedPercent")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedPercentTextBox"), TextBox).Text = 0
            End If
            If Not IsDBNull(Me.FormView1.DataItem("Completed")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("CompletedCheckBox"), CheckBox).Checked = Me.FormView1.DataItem("Completed")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsDisabled")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("chkIsDisabled"), CheckBox).Checked = Me.FormView1.DataItem("IsDisabled")
            End If
            'Advance Options MyAccordion AccordionPane1
            Me.Literal63.Text = ResourceHelper.GetFromResource("Advance Options")
            Me.Literal22.Text = ResourceHelper.GetFromResource("Estimated Cost:")
            Me.Literal23.Text = ResourceHelper.GetFromResource("Estimated Time (Hours):")
            Me.Literal3.Text = ResourceHelper.GetFromResource("Parent Task:")
            Me.Literal5.Text = ResourceHelper.GetFromResource("Milestone:")
            Me.Literal10.Text = ResourceHelper.GetFromResource("Duration:")
            Me.Literal17.Text = ResourceHelper.GetFromResource("Is Parent:")

            If Not IsDBNull(Me.FormView1.DataItem("ParentAccountProjectTaskId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue = Me.FormView1.DataItem("ParentAccountProjectTaskId")
            End If

            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataSource = dsAccountProjectMilestone
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataTextField = "MilestoneDescription"
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataValueField = "AccountProjectMilestoneId"
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataBind()

            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectMilestoneId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlAccountProjectMilestoneId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountProjectMilestoneId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("DurationUnit")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList3"), DropDownList).SelectedValue = Me.FormView1.DataItem("DurationUnit")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedTimeSpentUnit")) Then
                If Me.FormView1.DataItem("EstimatedTimeSpentUnit") <> "" Then
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlEstimatedTimeSpentUnit"), DropDownList).SelectedValue = Me.FormView1.DataItem("EstimatedTimeSpentUnit")
                End If
            End If
            Dim ddlEstimatedCurrencyIdEdit As New DropDownList
            ddlEstimatedCurrencyIdEdit = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlEstimatedCurrencyId"), DropDownList)
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedCurrencyId")) Then
                Me.dsEstimatedCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = Me.FormView1.DataItem("EstimatedCurrencyId")
                ddlEstimatedCurrencyIdEdit.SelectedValue = Me.FormView1.DataItem("EstimatedCurrencyId")
                ddlEstimatedCurrencyIdEdit.DataBind()
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedCost")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("EstimatedCostTextBox"), TextBox).Text = Me.FormView1.DataItem("EstimatedCost")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("EstimatedCostTextBox"), TextBox).Text = 0
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedTimeSpent")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("EstimatedTimeSpentTextBox"), TextBox).Text = Me.FormView1.DataItem("EstimatedTimeSpent")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("EstimatedTimeSpentTextBox"), TextBox).Text = 0
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                If Not IsDBNull(Me.FormView1.DataItem("FixedCost")) Then
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("txtFixedCost"), TextBox).Text = Me.FormView1.DataItem("FixedCost")
                Else
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("txtFixedCost"), TextBox).Text = 0
                End If
            End If
            If Not IsDBNull(Me.FormView1.DataItem("Duration")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DurationTextBox"), TextBox).Text = Me.FormView1.DataItem("Duration")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DurationTextBox"), TextBox).Text = 8
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsParentTask")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("CheckBox1"), CheckBox).Checked = Me.FormView1.DataItem("IsParentTask")
            End If


            'Task Billing Rate MyAccordion AccordionPane2
            Me.Literal65.Text = ResourceHelper.GetFromResource("Task Billing Rate")
            Me.Literal18.Text = ResourceHelper.GetFromResource("Billable:")
            Me.Literal29.Text = ResourceHelper.GetFromResource("Billing Rate:")
            Me.Literal25.Text = ResourceHelper.GetFromResource("Work Type:")
            Me.Literal26.Text = ResourceHelper.GetFromResource("Employee Rate Currency:")
            Me.Literal28.Text = ResourceHelper.GetFromResource("Billing Rate Currency:")
            Me.Literal31.Text = ResourceHelper.GetFromResource("Billing Rate Start Date:")
            Me.Literal62.Text = ResourceHelper.GetFromResource("Billing Rate End Date:")
            Me.Literal27.Text = ResourceHelper.GetFromResource("Employee Rate:")

            AccountCustomFieldBLL.SetCustomValuesForFormView_DataBound(FormView1)
            Dim ddlAccountWorkTypeIdEdit As New DropDownList
            ddlAccountWorkTypeIdEdit = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList)
            ddlAccountWorkTypeIdEdit.DataBind()
            GetBillingAndEmployeeRateOfProjectTask(DBUtilities.GetSessionAccountId, 4, Me.FormView1.DataKey("AccountProjectTaskId"), ddlAccountWorkTypeIdEdit.SelectedValue)

            If Not IsDBNull(Me.FormView1.DataItem("IsBillable")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("chkIsBillable"), CheckBox).Checked = Me.FormView1.DataItem("IsBillable")
            End If


            'Task Attachment MyAccordion AccordionPane3
            Me.Literal56.Text = ResourceHelper.GetFromResource("Task Attachment")
            Me.Literal68.Text = ResourceHelper.GetFromResource("Attachment Name:")
            Me.Literal69.Text = ResourceHelper.GetFromResource("File Path:")

        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then

            Me.RefreshEmployeesListBox(0, AccountProjectId, )


            Me.FormView1.Visible = False
            If AccountPagePermissionBLL.GetPageIdByPage(Me.Page) = 28 Then
                CType(Me.FormView1.FindControl("ListBoxEmployees"), ListBox).DataSourceID = ""
                AccountEmployeeBLL.SetDataForEmployeeListBox(28, CType(Me.FormView1.FindControl("ListBoxEmployees"), ListBox), 2, AccountProjectId)
            End If


            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("DurationTextBoxinsert"), TextBox).Text = 8
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("EstimatedCostTextBox1"), TextBox).Text = 0
            If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("txtFixedCostInsert"), TextBox).Text = 0
            End If
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("EstimatedTimeSpentTextBox1"), TextBox).Text = 0

            'ddlParentAccountProjectTaskId
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).DataSource = dsParentAccountProjectTaskObject
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).DataTextField = "TaskName"
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).DataValueField = "AccountProjectTaskId"
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).DataBind()


            Me.Literal36.Text = ResourceHelper.GetFromResource("Milestone:")
            Me.Literal35.Text = ResourceHelper.GetFromResource("Parent Task:")
            Me.Literal49.Text = ResourceHelper.GetFromResource("Is Parent:")

        End If

        If Not Request.QueryString("AccountProjectId") Is Nothing Then

            If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                If Me.Request.QueryString("AccountProjectId") <> Request.QueryString("AccountProjectId") Then
                    CType(Me.FormView1.FindControl("Add"), Button).Enabled = False
                    CType(Me.FormView1.FindControl("lblProjectTeamException"), Label).Visible = True
                    CType(Me.FormView1.FindControl("lblProjectTeamException"), Label).Text = ResourceHelper.GetFromResource("strmsg")
                End If
                Me.RefreshEmployeesListBox(0, AccountProjectId)
            ElseIf Me.FormView1.CurrentMode = FormViewMode.Edit Then
                Me.RefreshEmployeesListBox(Me.FormView1.DataItem("AccountProjectTaskId"), AccountProjectId, Me.FormView1.DataItem("AccountProjectMilestoneId"))
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").Visible = False
            Else
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").Visible = True
            End If
            If DBUtilities.IsBillingFeature = False Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").Visible = False
            Else
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").Visible = True
            End If
            If DBUtilities.IsProjectManagementFeature = True Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").Visible = True
            Else
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").Visible = False
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If DBUtilities.IsProjectManagementFeature = True Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").Visible = True
            Else
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").Visible = False
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If DBUtilities.IsProjectManagementFeature = True Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").Visible = True
            Else
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").Visible = False
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ItemCreated
        AccountCustomFieldBLL.CreateCustomFieldOnFormView_ItemCreated(FormView1, MasterEntityTypeId, "30%", "68%", "26px")
        Dim objFormRow As FormViewRow = Me.FormView1.Row
        Dim objListBox As ListBox = objFormRow.FindControl("ListBoxEmployeesUpdate")
        If Not objListBox Is Nothing Then
            Me.oListBox = objListBox
        End If
    End Sub
    Protected Sub oListBox_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles oListBox.DataBound
        Dim BLL As New AccountProjectTaskEmployeeBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable

        dt = BLL.GetAccountProjectTaskEmployeesByAccountProjectTaskId(Me.dsAccountProjectTaskFormObject.SelectParameters("AccountProjectTaskId").DefaultValue)

        Dim objRow As TimeLiveDataSet.AccountProjectTaskEmployeeRow

        Dim objFormRow As FormViewRow = Me.FormView1.Row

        ListControlValues = New Hashtable

        Dim objListBox As ListBox = objFormRow.FindControl("ListBoxEmployees")
        For Each objRow In dt.Rows

            For Each item As ListItem In oListBox.Items

                If item.Value = objRow.AccountEmployeeId Then
                    item.Selected = True
                    ListControlValues.Add(CStr(objRow.AccountEmployeeId), objRow.AccountProjectTaskEmployeeId)
                End If

            Next

        Next
        Me.ViewState.Add("ListViewControl", ListControlValues)
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Me.Request.QueryString("AccountProjectId") Is Nothing Then
        '    Me.dsAccountProjectMilestone.SelectParameters("IsMyTask").DefaultValue = True
        'Else
        '    Me.dsAccountProjectMilestone.SelectParameters("IsMyTask").DefaultValue = False
        'End If
    End Sub
    Public Sub SetDefaults()
        RefreshEmployeesListBox()
    End Sub
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Inserting(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
    End Sub
    Private Sub RefreshEmployeesListBox(Optional ByVal AccountProjectTaskId As Integer = 0, Optional ByVal AccountProjectId As Integer = 0, Optional ByVal AccountProjectMilestoneid As Integer = 0)
        Me.RefillParentTask(AccountProjectId)
        Me.RefillMilestone(AccountProjectId, AccountProjectMilestoneid)


        Me.dsAccountProjectTask.SelectParameters("AccountProjectId").DefaultValue = AccountProjectId
        Me.dsAccountProjectTaskInsert.SelectParameters("AccountProjectId").DefaultValue = AccountProjectId

        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("ListBoxEmployees"), ListBox).Items.Clear()
            If AccountPagePermissionBLL.GetPageIdByPage(Me.Page) = 28 Then
                CType(Me.FormView1.FindControl("ListBoxEmployees"), ListBox).DataSourceID = ""
                AccountEmployeeBLL.SetDataForEmployeeListBox(28, CType(Me.FormView1.FindControl("ListBoxEmployees"), ListBox), 2, AccountProjectId)
            End If
            CType(Me.FormView1.FindControl("ListBoxEmployees"), ListBox).DataBind()
        ElseIf Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.dsAccountProjectTask.SelectParameters("AccountProjectTaskId").DefaultValue = AccountProjectTaskId
            CType(Me.FormView1.FindControl("ListBoxEmployeesUpdate"), ListBox).Items.Clear()
            CType(Me.FormView1.FindControl("ListBoxEmployeesUpdate"), ListBox).DataBind()

        End If
    End Sub
    Public Sub RefillParentTask(Optional ByVal AccountProjectId As Integer = 0)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).Items.Clear()

        ElseIf Me.FormView1.CurrentMode = FormViewMode.Edit Then
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlParentAccountProjectTaskId"), DropDownList).Items.Clear()
        End If
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = ResourceHelper.GetFromResource("<RootLevel>")
        item.Value = "0"
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).Items.Add(item)
        ElseIf Me.FormView1.CurrentMode = FormViewMode.Edit Then
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlParentAccountProjectTaskId"), DropDownList).Items.Add(item)
        End If
        dsParentAccountProjectTaskObject.SelectParameters("AccountProjectId").DefaultValue = AccountProjectId

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectTaskId")) Then
                dsParentAccountProjectTaskObject.SelectParameters("ParentAccountProjectTaskId").DefaultValue = Me.FormView1.DataItem("AccountProjectTaskId")
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlParentAccountProjectTaskIdinsert"), DropDownList).DataBind()
        ElseIf Me.FormView1.CurrentMode = FormViewMode.Edit Then
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlParentAccountProjectTaskId"), DropDownList).DataBind()
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectTaskId")) Then
                dsParentAccountProjectTaskObject.SelectParameters("AccountProjectId").DefaultValue = AccountProjectId
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ParentAccountProjectTaskId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue = Me.FormView1.DataItem("ParentAccountProjectTaskId")
            End If
        End If

    End Sub
    Public Sub RefillMilestone(Optional ByVal AccountProjectId As Integer = 0, Optional ByVal AccountProjectMilestoneId As Integer = 0)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).Items.Clear()
            'If Me.Request.QueryString("AccountProjectId") Is Nothing Then
            '    Me.dsAccountProjectMilestone.SelectParameters("IsMyTask").DefaultValue = True
            'Else
            '    Me.dsAccountProjectMilestone.SelectParameters("IsMyTask").DefaultValue = False
            'End If
            dsAccountProjectMilestone.SelectParameters("AccountProjectId").DefaultValue = AccountProjectId
            dsAccountProjectMilestone.SelectParameters("AccountProjectMilestoneId").DefaultValue = 0
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).DataSource = dsAccountProjectMilestone
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).DataTextField = "MilestoneDescription"
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).DataValueField = "AccountProjectMilestoneId"
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("ddlAccountProjectMilestoneIdinsert"), DropDownList).DataBind()
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            dsAccountProjectMilestone.SelectParameters("AccountProjectMilestoneId").DefaultValue = AccountProjectMilestoneId
            dsAccountProjectMilestone.SelectParameters("AccountProjectId").DefaultValue = AccountProjectId
        End If
    End Sub
    Protected Sub FormView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewPageEventArgs)

    End Sub
    Protected Sub DropDownList8_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub ddlAccountProjectId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshEmployeesListBox()
    End Sub
    Protected Sub ddlAccountWorkTypeId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GetBillingAndEmployeeRateOfProjectTask(DBUtilities.GetSessionAccountId, 4, Me.FormView1.DataKey("AccountProjectTaskId"), CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
    End Sub
    Public Sub GetBillingAndEmployeeRateOfProjectTask(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountWorkTypeId As Integer)
        Dim WorkTypeBLL As New AccountWorkTypeBLL
        Dim BillingRateBLL As New AccountBillingRateBLL

        Dim ddlBillingRateCurrencyIdEdit As New DropDownList
        ddlBillingRateCurrencyIdEdit = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlBillingRateCurrencyId"), DropDownList)

        Dim ddlEmployeeRateCurrencyIdEdit As New DropDownList
        ddlEmployeeRateCurrencyIdEdit = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlEmployeeRateCurrencyId"), DropDownList)

        Dim BillingRateTextBox As New TextBox
        BillingRateTextBox = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("BillingRateTextBox"), TextBox)

        EmployeeRateTextBox = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("EmployeeRateTextBox"), TextBox)

        Dim BillingRateStartDateTextBox As New eWorld.UI.CalendarPopup
        BillingRateStartDateTextBox = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("BillingRateStartDateTextBox"), eWorld.UI.CalendarPopup)

        Dim BillingRateEndDateTextBox As New eWorld.UI.CalendarPopup
        BillingRateEndDateTextBox = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup)

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = WorkTypeBLL.GetProjectTaskWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectTaskId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow

        If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
            drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)

            Dim dtAccountBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountBillingRateId(drAccountWorkTypeBillingRate.AccountBillingRateId)
            Dim drAccountBillingRate As AccountBillingRate.AccountBillingRateRow

            If dtAccountBillingRate.Rows.Count > 0 Then
                drAccountBillingRate = dtAccountBillingRate.Rows(0)
                If Not IsDBNull(drAccountBillingRate.BillingRateCurrencyId) Then
                    Me.dsBillingRateCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = drAccountBillingRate.BillingRateCurrencyId
                    ddlBillingRateCurrencyIdEdit.SelectedValue = drAccountBillingRate.BillingRateCurrencyId
                    ddlBillingRateCurrencyIdEdit.DataBind()
                End If

                If Not IsDBNull(drAccountBillingRate.EmployeeRateCurrencyId) Then
                    Me.dsEmployeeRateCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = drAccountBillingRate.EmployeeRateCurrencyId
                    ddlEmployeeRateCurrencyIdEdit.SelectedValue = drAccountBillingRate.EmployeeRateCurrencyId
                    ddlEmployeeRateCurrencyIdEdit.DataBind()
                End If

                BillingRateTextBox.Text = drAccountBillingRate.BillingRate
                EmployeeRateTextBox.Text = drAccountBillingRate.EmployeeRate
                BillingRateStartDateTextBox.SelectedDate = drAccountBillingRate.StartDate
                BillingRateEndDateTextBox.SelectedDate = drAccountBillingRate.EndDate
            Else
                ddlBillingRateCurrencyIdEdit.SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                ddlEmployeeRateCurrencyIdEdit.SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                BillingRateStartDateTextBox.Text = 0
                EmployeeRateTextBox.Text = 0
            End If
        Else
            ddlBillingRateCurrencyIdEdit.SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            ddlEmployeeRateCurrencyIdEdit.SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            BillingRateTextBox.Text = 0
            EmployeeRateTextBox.Text = 0
            BillingRateStartDateTextBox.SelectedDate = Date.Today
            BillingRateEndDateTextBox.SelectedDate = Date.Today
            BillingRateEndDateTextBox.SelectedDate = BillingRateEndDateTextBox.SelectedDate.AddYears(1)
        End If

    End Sub
    Protected Sub CustomValidator3_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane5").FindControl("TaskDescriptionTextBox"), TextBox).Text.Length > 5000 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AccountProjectTaskId As Integer = Me.FormView1.DataKey("AccountProjectTaskId")
        Dim AccountWorkTypeId As Integer = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue
        If Me.Request.QueryString("Source") = "MyProjects" Then
            Response.Redirect("~/AccountAdmin/AccountBillingRate.aspx?AccountProjectTaskId=" & AccountProjectTaskId & "&SystemBillingRateTypeId=4&AccountWorkTypeId=" & AccountWorkTypeId & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=MyProjects", False)
        ElseIf Me.Request.QueryString("Source") = "ProjectTemplates" Then
            Response.Redirect("~/AccountAdmin/AccountBillingRate.aspx?AccountProjectTaskId=" & AccountProjectTaskId & "&SystemBillingRateTypeId=4&AccountWorkTypeId=" & AccountWorkTypeId & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=ProjectTemplates", False)
        Else
            Response.Redirect("~/AccountAdmin/AccountBillingRate.aspx?AccountProjectTaskId=" & AccountProjectTaskId & "&SystemBillingRateTypeId=4&AccountWorkTypeId=" & AccountWorkTypeId & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId"), False)
        End If
    End Sub
    Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub FormView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewPageEventArgs)

    End Sub
    Protected Sub FormView1_PageIndexChanging2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewPageEventArgs)

    End Sub
    Protected Sub CompletedPercentTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub Add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = False
        'Me.UpdatePanel2.UpdateMode = UpdatePanelUpdateMode.Conditional
        RaiseEvent AddClick(sender, e)
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.Visible = False
        RaiseEvent btnUpdateClick(sender, e)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.UpdatePanel2.UpdateMode = UpdatePanelUpdateMode.Always
        'Me.FormView1.Visible = False
        RaiseEvent btnCancelClick(sender, e)
        'Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"))
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        RaiseEvent btnUpdateClick(sender, e)
        Dim BLL As New AccountProjectTaskAttachmentBLL
        Dim AccountProjectTaskId = Me.FormView1.DataKey("AccountProjectTaskId")
        BLL.FileUpload(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("AttachmentFileUpload"), AccountProjectTaskId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("AttachmentNameTextBox"), TextBox).Text)
    End Sub
    Protected Sub btnTaskTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Request.QueryString("Source") = "MyTasks" Then
            Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.FormView1.DataKey("AccountProjectTaskId") & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=MyTasks&Selected=True", False)
        Else
            Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.FormView1.DataKey("AccountProjectTaskId") & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Selected=True", False)
        End If
    End Sub
    Protected Sub MyAccordion_ItemCreated(sender As Object, e As AjaxControlToolkit.AccordionItemEventArgs)

    End Sub
    Protected Sub MyAccordion_Load(sender As Object, e As System.EventArgs)

    End Sub

    Protected Sub ddlAccountProjectId_SelectedIndexChanged1(sender As Object, e As System.EventArgs)
        Me.RefreshEmployeesListBox(0, CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue)
        RaiseEvent SelectIndexChanged(sender, e)
    End Sub
End Class