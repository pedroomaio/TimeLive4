Partial Class ProjectAdmin_Controls_ctlAccountProjectForm
    Inherits System.Web.UI.UserControl
    Public ListControlValues As Hashtable
    Public Event btnCancelClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event btnUpdateClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event btnAddClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event btnTemplateClick(ByVal sender As Object)
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
    Public Event Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
    Public AccountProjectIdToOpen As Integer
    Dim MasterEntityTypeId As New Guid("13dbff37-a092-4ae2-a919-775cbed0edc0")
    Dim CustomFieldCaption As String
    Public Sub EditRecord(ByVal pAccountProjectIdToOpen As Integer)
        Me.AccountProjectIdToOpen = pAccountProjectIdToOpen
        Me.ViewState("AccountProjectIdToOpen") = AccountProjectIdToOpen
        Me.FormView1.ChangeMode(FormViewMode.Edit)
        Me.dsAccountProjectFormObject.SelectParameters("AccountProjectId").DefaultValue = Me.AccountProjectIdToOpen
    End Sub
    Protected Sub FormView1_ItemCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ItemCreated
        AccountCustomFieldBLL.CreateCustomFieldOnFormView_ItemCreated(FormView1, MasterEntityTypeId, , , "26px")
    End Sub
    Protected Sub dsAccountProjectFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectFormObject.Inserted
        Dim ProjectBLL As New AccountProjectBLL
        Dim AccountProjectId As Integer
        AccountProjectId = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateid"), DropDownList).SelectedValue
        RaiseEvent Inserted(sender, e)
        '''If DBUtilities.IsBillingFeature = False Then
        If Me.Request.QueryString("IsTemplate") = "True" Then
            Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & New AccountProjectBLL().GetLastInsertedId & "&" & "IsTemplate=True&Source=ProjectTemplates", False)
        Else
            If AccountProjectId <> 0 Then
                Call New AccountProjectEmployeeBLL().InsertProjectEmployeesByProjectTemplate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId, AccountProjectId)
                Call New AccountProjectMilestoneBLL().InsertAccountProjectMilestonesByProjectTemplate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId, AccountProjectId)
                Call New AccountEMailNotificationPreferenceBLL().InsertDefaultAccountEmployeeEMailNotificationPreferenceByProjectTemplate(New AccountProjectBLL().GetLastInsertedId, AccountProjectId)
                Call New AccountProjectTaskBLL().InsertAccountProjectTasksByProjectTemplate(New AccountProjectBLL().GetLastInsertedId, AccountProjectId)
                Call New AccountProjectTaskEmployeeBLL().InsertAccountProjectTaskEmployeeByProjectTaskTemplate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId)
                Call New AccountProjectTaskBLL().UpdateParentAccountProjectTaskId(New AccountProjectBLL().GetLastInsertedId, AccountProjectId)
                Call New AccountBillingRateBLL().InserAccountProjectEmployeeBillingRate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId)
                Call New AccountWorkTypeBLL().InsertWorkTypeBillingRateOfProjectEmployeeByTemplate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId)
                Call New AccountBillingRateBLL().InsertAccountBillingRatesByProjectTaskTemplate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId)
                Call New AccountWorkTypeBLL().InsertWorkTypeBillingRateOfProjectTaskByTemplate(DBUtilities.GetSessionAccountId, New AccountProjectBLL().GetLastInsertedId)
                ProjectBLL.AddAccountProjectEmplyeeForTemplate(DBUtilities.GetSessionAccountId, 0)
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & New AccountProjectBLL().GetLastInsertedId, False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & New AccountProjectBLL().GetLastInsertedId, False)
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    Protected Sub dsAccountProjectFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectFormObject.Inserting
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("Deadline"), "Deadline", e)
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("StartDate"), "StartDate", e)
        DBUtilities.SetRowForInserting(e)
        Dim AccountProjectTypeId As Integer
        Dim AccountBillingTypeId As Integer
        Dim dtProjectType As TimeLiveDataSet.AccountProjectTypeDataTable = New AccountProjectTypeBLL().GetAccountProjectTypeByAccountId(DBUtilities.GetSessionAccountId)
        Dim drProjectType As TimeLiveDataSet.AccountProjectTypeRow
        drProjectType = dtProjectType.Rows(0)
        If dtProjectType.Rows.Count > 0 Then
            AccountProjectTypeId = drProjectType.AccountProjectTypeId
        End If
        Dim dtBillingType As TimeLiveDataSet.AccountBillingTypeDataTable = New AccountBillingTypeBLL().GetAccountBillingTypesForProjectByAccountId(DBUtilities.GetSessionAccountId)
        Dim drBillingType As TimeLiveDataSet.AccountBillingTypeRow
        drBillingType = dtBillingType.Rows(0)
        If dtBillingType.Rows.Count > 0 Then
            AccountBillingTypeId = drBillingType.AccountBillingTypeId
        End If


        e.InputParameters("StartDate") = CType(Me.FormView1.FindControl("StartDate"), eWorld.UI.CalendarPopup).SelectedDate
        e.InputParameters("Deadline") = CType(Me.FormView1.FindControl("Deadline"), eWorld.UI.CalendarPopup).SelectedDate
        e.InputParameters("AccountId") = DBUtilities.GetSessionAccountId
        e.InputParameters("ProjectStatusId") = CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).SelectedValue
        e.InputParameters("EstimatedDuration") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("EstimatedDurationTextBox"), TextBox).Text
        e.InputParameters("ProjectCode") = CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text
        e.InputParameters("EstimatedDurationUnit") = "Hours"

        If CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).SelectedValue <> 0 Then
            Dim AccountProjectId As Integer
            AccountProjectId = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).SelectedValue
            Dim BLL As New AccountProjectBLL
            Dim dt As TimeLiveDataSet.AccountProjectDataTable = BLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
            Dim dr As TimeLiveDataSet.AccountProjectRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                e.InputParameters("AccountProjectTypeId") = dr.AccountProjectTypeId
                If Not IsDBNull(dr.Item("AccountPartyContactId")) Then
                    e.InputParameters("AccountPartyContactId") = dr.AccountPartyContactId
                Else
                    e.InputParameters("AccountPartyContactId") = 0
                End If
                If Not IsDBNull(dr.Item("AccountPartyDepartmentId")) Then
                    e.InputParameters("AccountPartyDepartmentId") = dr.AccountPartyDepartmentId
                Else
                    e.InputParameters("AccountPartyDepartmentId") = dr.AccountPartyDepartmentId
                End If

                e.InputParameters("ProjectBillingTypeId") = dr.ProjectBillingTypeId
                e.InputParameters("LeaderEmployeeId") = dr.LeaderEmployeeId
                e.InputParameters("ProjectManagerEmployeeId") = dr.ProjectManagerEmployeeId
                If Not IsDBNull(dr.Item("TimeSheetApprovalTypeId")) Then
                    e.InputParameters("TimeSheetApprovalTypeId") = dr.TimeSheetApprovalTypeId
                Else
                    e.InputParameters("TimeSheetApprovalTypeId") = 0
                End If
                If Not IsDBNull(dr.Item("ExpenseApprovalTypeId")) Then
                    e.InputParameters("ExpenseApprovalTypeId") = dr.ExpenseApprovalTypeId
                Else
                    e.InputParameters("ExpenseApprovalTypeId") = 0
                End If

                e.InputParameters("ProjectDescription") = dr.ProjectDescription
                e.InputParameters("DefaultBillingRate") = dr.DefaultBillingRate
                e.InputParameters("ProjectBillingRateTypeId") = dr.ProjectBillingRateTypeId
                e.InputParameters("IsProject") = dr.IsProject
                e.InputParameters("CreatedOn") = dr.CreatedOn
                e.InputParameters("CreatedByEmployeeId") = dr.CreatedByEmployeeId
                e.InputParameters("ModifiedOn") = dr.ModifiedOn
                e.InputParameters("ModifiedByEmployeeId") = dr.ModifiedByEmployeeId
                e.InputParameters("Completed") = dr.Completed
                If Not IsDBNull(dr.Item("ProjectPrefix")) Then
                    e.InputParameters("ProjectPrefix") = dr.ProjectPrefix
                End If
                If Not IsDBNull(dr.Item("IsForAllClientProject")) Then
                    e.InputParameters("IsForAllClientProject") = dr.IsForAllClientProject
                Else
                    e.InputParameters("IsForAllClientProject") = False
                End If

            End If

        Else
            e.InputParameters("AccountProjectTypeId") = AccountProjectTypeId
            e.InputParameters("AccountPartyContactId") = 0
            e.InputParameters("AccountPartyDepartmentId") = 0
            e.InputParameters("ProjectBillingTypeId") = AccountBillingTypeId
            e.InputParameters("LeaderEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
            e.InputParameters("ProjectManagerEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
            e.InputParameters("TimeSheetApprovalTypeId") = 0
            e.InputParameters("ExpenseApprovalTypeId") = 0
            e.InputParameters("ProjectDescription") = ""
            e.InputParameters("DefaultBillingRate") = Convert.ToDecimal(0)
            e.InputParameters("ProjectBillingRateTypeId") = 1
            If Not Me.Request.QueryString("IsTemplate") Is Nothing Then
                e.InputParameters("IsTemplate") = True
            Else
                e.InputParameters("IsTemplate") = False
            End If
            e.InputParameters("IsProject") = False
            e.InputParameters("CreatedOn") = Now.Date
            e.InputParameters("CreatedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
            e.InputParameters("ModifiedOn") = Now.Date
            e.InputParameters("ModifiedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
            e.InputParameters("Completed") = False
            e.InputParameters("ProjectPrefix") = ""
            e.InputParameters("IsForAllClientProject") = False
        End If
        If Me.Request.QueryString("IsTemplate") <> "True" Then
            If LocaleUtilitiesBLL.AutoGenerateProjectCode = True Then
                If DBUtilities.IncludeCurrentYearInProjectCode Then
                    Dim ProjectCode() As String = Split(CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text, Date.Now.Year.ToString & "-")
                    e.InputParameters("ProjectCode") = ProjectCode(1)
                    If DBUtilities.GetProjectCodePrefix <> "" Then
                        e.InputParameters("ProjectPrefix") = DBUtilities.GetProjectCodePrefix & "-" & Date.Now.Year.ToString
                    Else
                        e.InputParameters("ProjectPrefix") = Date.Now.Year.ToString
                    End If
                Else
                    Dim ProjectCode() As String = Split(CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text, DBUtilities.GetProjectCodePrefix & "-")
                    If DBUtilities.GetProjectCodePrefix <> "" Then
                        e.InputParameters("ProjectCode") = ProjectCode(1)
                    Else
                        e.InputParameters("ProjectCode") = ProjectCode(0)
                    End If
                    e.InputParameters("ProjectPrefix") = DBUtilities.GetProjectCodePrefix
                    ''Split(CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text, DBUtilities.GetProjectCodePrefix & "-")
                End If
            Else
                e.InputParameters("ProjectCode") = CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text
            End If
        End If
        If DBUtilities.IsProjectManagementFeature = True Then
            e.InputParameters("ProjectEstimatedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("txtProjectEstimatedCost"), TextBox).Text
            If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                e.InputParameters("FixedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("txtFixedCost"), TextBox).Text
            Else
                e.InputParameters("FixedCost") = 0
            End If

            e.InputParameters("AccountProjectTemplateId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).SelectedValue
            e.InputParameters("EstimatedDurationUnit") = "Hours"
            e.InputParameters("EstimatedDuration") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("EstimatedDurationTextBox"), TextBox).Text
        Else
            e.InputParameters("ProjectEstimatedCost") = 0
            e.InputParameters("FixedCost") = 0
            e.InputParameters("AccountProjectTemplateId") = 0
            e.InputParameters("EstimatedDurationUnit") = "Hours"
            e.InputParameters("EstimatedDuration") = 0
        End If
    End Sub
    Protected Sub dsAccountProjectFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectFormObject.Updated
        RaiseEvent Updated(sender, e)
    End Sub
    Protected Sub dsAccountProjectFormObject_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
    End Sub
    Protected Sub dsAccountProjectFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectFormObject.Updating
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("Deadline"), "Deadline", e)
        LocaleUtilitiesBLL.FixDatePickerInternationalDate(Me.FormView1.FindControl("StartDate"), "StartDate", e)
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("ProjectBillingRateTypeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("ddlProjectBillingRateTypeIdEdit"), DropDownList).SelectedValue
            'e.NewValues.Item("ProjectBillingRateTypeId") = AccountProjectBLL.GetProjectBillingRateTypeId(e.Keys(0))
            e.NewValues.Item("TimeSheetApprovalTypeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlTimeSheetApprovalTypeIdEdit"), DropDownList).SelectedValue
            e.NewValues.Item("ExpenseApprovalTypeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlExpenseApprovalTypeIdEdit"), DropDownList).SelectedValue
            e.NewValues.Item("AccountPartyContactId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlAccountPartyContactIdEdit"), DropDownList).SelectedValue
            e.NewValues.Item("AccountPartyDepartmentId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlAccountPartyDepartmentIdEdit"), DropDownList).SelectedValue
            e.NewValues.Item("AccountProjectTypeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlProjectTypeEdit"), DropDownList).SelectedValue
            e.NewValues.Item("AccountClientId") = CType(Me.FormView1.FindControl("DropDownList2"), DropDownList).SelectedValue
            e.NewValues.Item("ProjectBillingTypeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DropDownList4Edit"), DropDownList).SelectedValue
            e.NewValues.Item("ProjectStatusId") = CType(Me.FormView1.FindControl("ddlProjectStatusEdit"), DropDownList).SelectedValue
            e.NewValues.Item("LeaderEmployeeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlTeamLeadEditDropDown"), DropDownList).SelectedValue
            e.NewValues.Item("ProjectManagerEmployeeId") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlProjectManagerEditDropDown"), DropDownList).SelectedValue
            e.NewValues.Item("EstimatedDurationUnit") = "Hours"
            e.NewValues.Item("EstimatedDuration") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("EstimatedDurationTextBoxEdit"), TextBox).Text
            e.NewValues.Item("DefaultBillingRate") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DefaultBillingRateTextBoxEdit"), TextBox).Text
            e.NewValues.Item("ProjectEstimatedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectEstimatedCostEdit"), TextBox).Text
            If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                e.NewValues.Item("FixedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtFixedCostEdit"), TextBox).Text
            Else
                e.NewValues.Item("FixedCost") = 0
            End If

            e.NewValues.Item("IsForAllClientProject") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("chkAllClientProjectEdit"), CheckBox).Checked
            e.NewValues.Item("ProjectDescription") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ProjectDescriptionTextBoxEdit"), TextBox).Text
            e.NewValues.Item("Completed") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("chkCompletedEdit"), CheckBox).Checked
            e.NewValues.Item("IsDisabled") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("chkIsDisabled"), CheckBox).Checked

            'DefaultBillingRate
            If Me.Request.QueryString("IsTemplate") <> "True" Then
                If LocaleUtilitiesBLL.AutoGenerateProjectCode = True Then
                    Dim ProjectCode() As String = Split(CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text, "-")
                    If ProjectCode.Length = 2 Then
                        e.NewValues.Item("ProjectCode") = ProjectCode(1)
                        e.NewValues.Item("ProjectPrefix") = ProjectCode(0)
                    ElseIf ProjectCode.Length = 3 Then
                        e.NewValues.Item("ProjectCode") = ProjectCode(2)
                        e.NewValues.Item("ProjectPrefix") = ProjectCode(0) & "-" & ProjectCode(1)
                    Else
                        e.NewValues.Item("ProjectCode") = ProjectCode(0)
                    End If
                Else
                    e.NewValues.Item("ProjectCode") = CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text
                End If
            End If
            For n As Integer = 1 To 15
                AccountCustomFieldBLL.SetCustomValuesForFormView_Updating(FormView1, e, MasterEntityTypeId, "CustomField" & n)
                If e.Cancel = True Then
                    Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                    CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                    UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
                    RaiseEvent SelectedIndexChanged(sender, e)
                End If
            Next
        End If
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermissionForFormView(31, Me.FormView1, "Add")
        'AccountPagePermissionBLL.SetPagePermissionForFormView(28, Me.FormView1, "Add")
        Dim ddlProjectBillingRateTypeId As New DropDownList
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.FormView1.Visible = True
            ddlProjectBillingRateTypeId = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("ddlProjectBillingRateTypeIdEdit"), DropDownList)
            If Not IsDBNull(Me.FormView1.DataItem("ProjectBillingRateTypeId")) Then
                ddlProjectBillingRateTypeId.SelectedValue = Me.FormView1.DataItem("ProjectBillingRateTypeId")
                ddlProjectBillingRateTypeId.DataBind()
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TimeSheetApprovalTypeId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlTimeSheetApprovalTypeIdEdit"), DropDownList).SelectedValue = Me.FormView1.DataItem("TimeSheetApprovalTypeId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ExpenseApprovalTypeId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlExpenseApprovalTypeIdEdit"), DropDownList).SelectedValue = Me.FormView1.DataItem("ExpenseApprovalTypeId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountPartyContactId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("PartyContactCascadingDropDown"), AjaxControlToolkit.CascadingDropDown).SelectedValue = Me.FormView1.DataItem("AccountPartyContactId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountPartyDepartmentId")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("PartyDepartmentCascadingDropDown"), AjaxControlToolkit.CascadingDropDown).SelectedValue = Me.FormView1.DataItem("AccountPartyDepartmentId")
            End If
            If ddlProjectBillingRateTypeId.SelectedItem.Text <> Resources.TimeLive.Resource.Use_Project_Roles_Billing_Rate Then
                CType(Me.FormView1.FindControl("btnRoleWiseBillingRate"), Button).Visible = False
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectTypeId")) Then
                Me.dsProjectTypeObject.SelectParameters("AccountProjectTypeId").DefaultValue = Me.FormView1.DataItem("AccountProjectTypeId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlProjectTypeEdit"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountProjectTypeId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ProjectBillingTypeId")) Then
                Me.dsBillingTypeObject.SelectParameters("AccountBillingTypeId").DefaultValue = Me.FormView1.DataItem("ProjectBillingTypeId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DropDownList4Edit"), DropDownList).SelectedValue = Me.FormView1.DataItem("ProjectBillingTypeId")
                DropDownList4Edit.DataBind()
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ProjectCode")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ProjectCodeTextBox"), TextBox).Text = Me.FormView1.DataItem("ProjectCode")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ProjectDescription")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ProjectDescriptionTextBoxEdit"), TextBox).Text = Me.FormView1.DataItem("ProjectDescription")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("DefaultBillingRate")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DefaultBillingRateTextBoxEdit"), TextBox).Text = Me.FormView1.DataItem("DefaultBillingRate")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ProjectStatusId")) Then
                Me.dsProjectStatusObject.SelectParameters("AccountStatusId").DefaultValue = Me.FormView1.DataItem("ProjectStatusId")
                CType(Me.FormView1.FindControl("ddlProjectStatusEdit"), DropDownList).SelectedValue = Me.FormView1.DataItem("ProjectStatusId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountClientId")) Then
                Me.dsClientObject.SelectParameters("AccountPartyId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
                CType(Me.FormView1.FindControl("DropDownList2"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountClientId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("LeaderEmployeeId")) Then
                Me.dsEmployeeObject.SelectParameters("AccountEmployeeId").DefaultValue = Me.FormView1.DataItem("LeaderEmployeeId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlTeamLeadEditDropDown"), DropDownList).SelectedValue = Me.FormView1.DataItem("LeaderEmployeeId")
            End If

            If Not IsDBNull(Me.FormView1.DataItem("ProjectManagerEmployeeId")) Then
                Me.dsProjectManagerObject.SelectParameters("AccountEmployeeId").DefaultValue = Me.FormView1.DataItem("ProjectManagerEmployeeId")
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("ddlProjectManagerEditDropDown"), DropDownList).SelectedValue = Me.FormView1.DataItem("ProjectManagerEmployeeId")
            End If
            If Me.Request.QueryString("IsTemplate") = "True" Then
                CType(Me.FormView1.FindControl("Literal1"), Literal).Text = Resources.TimeLive.Resource.Project_Template_Information
                CType(Me.FormView1.FindControl("Literal21"), Literal).Text = Resources.TimeLive.Resource.Project_Template
            Else
                CType(Me.FormView1.FindControl("Literal1"), Literal).Text = Resources.TimeLive.Resource.Project_Information
                CType(Me.FormView1.FindControl("Literal21"), Literal).Text = Resources.TimeLive.Resource.Basic
            End If
            If Me.Request.QueryString("Source") = "MyProjects" Then
                CType(Me.FormView1.FindControl("btnProjectMilestone"), Button).Visible = True
            Else
                CType(Me.FormView1.FindControl("btnProjectMilestone"), Button).Visible = False
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsForAllClientProject")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("chkAllClientProjectEdit"), CheckBox).Checked = Me.FormView1.DataItem("IsForAllClientProject")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("Completed")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("chkCompletedEdit"), CheckBox).Checked = Me.FormView1.DataItem("Completed")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsDisabled")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("OtherAccordion").FindControl("chkIsDisabled"), CheckBox).Checked = Me.FormView1.DataItem("IsDisabled")
            End If

            If Not IsDBNull(Me.FormView1.DataItem("ProjectEstimatedCost")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectEstimatedCostEdit"), TextBox).Text = Me.FormView1.DataItem("ProjectEstimatedCost")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectEstimatedCostEdit"), TextBox).Text = 0
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                If Not IsDBNull(Me.FormView1.DataItem("FixedCost")) Then
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtFixedCostEdit"), TextBox).Text = Me.FormView1.DataItem("FixedCost")
                Else
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtFixedCostEdit"), TextBox).Text = 0
                End If
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedDuration")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("EstimatedDurationTextBoxEdit"), TextBox).Text = Me.FormView1.DataItem("EstimatedDuration")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("EstimatedDurationTextBoxEdit"), TextBox).Text = 0
            End If
            AccountCustomFieldBLL.SetCustomValuesForFormView_DataBound(FormView1)

            'get ProjectEstimated value report view
            ''If Not System.Configuration.ConfigurationManager.AppSettings("PROJECT_ESTIMATES") Is Nothing Then
            If DBUtilities.GetSessionAccountId = 7354 Then
                Dim dtreport As AccountProject.rptvueAccountProjectsReportDataTable = New AccountProjectBLL().GetAccountProjectsByAccountIdAndAccountProjectIdForReport(DBUtilities.GetSessionAccountId, Me.FormView1.DataItem("AccountProjectId"))
                Dim drreport As AccountProject.rptvueAccountProjectsReportRow
                If dtreport.Rows.Count > 0 Then
                    drreport = dtreport.Rows(0)
                    If Not IsDBNull(drreport.Item("ProjectSpentToDate")) Then
                        CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectSpent"), TextBox).Text = drreport.ProjectSpentToDate
                    Else
                        CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectSpent"), TextBox).Text = 0
                    End If
                    If Not IsDBNull(drreport.Item("ProjectBudgetLeft")) Then
                        CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectBudgetLeft"), TextBox).Text = drreport.ProjectBudgetLeft
                    Else
                        CType(Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").FindControl("txtProjectBudgetLeft"), TextBox).Text = 0
                    End If
                End If
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If DBUtilities.IsProjectManagementFeature = False Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").Visible = False
            End If

            CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).DataSource = dsProjectStatusObjectInsert
            CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).DataTextField = "Status"
            CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).DataValueField = "AccountStatusId"
            CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).DataBind()

            ' ''ddlTimeSheetApprovalTypeId
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlTimeSheetApprovalTypeId"), DropDownList).DataSource = dsTimeSheetApprovalType
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlTimeSheetApprovalTypeId"), DropDownList).DataTextField = "ApprovalTypeName"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlTimeSheetApprovalTypeId"), DropDownList).DataValueField = "AccountApprovalTypeId"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlTimeSheetApprovalTypeId"), DropDownList).DataBind()

            ''ddlExpenseApprovalTypeId
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlExpenseApprovalTypeId"), DropDownList).DataSource = dsExpenseApprovalType
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlExpenseApprovalTypeId"), DropDownList).DataTextField = "ApprovalTypeName"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlExpenseApprovalTypeId"), DropDownList).DataValueField = "AccountApprovalTypeId"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlExpenseApprovalTypeId"), DropDownList).DataBind()

            ''ddlProjectType
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlProjectType"), DropDownList).DataSource = dsProjectTypeObjectInsert
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlProjectType"), DropDownList).DataTextField = "ProjectType"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlProjectType"), DropDownList).DataValueField = "AccountProjectTypeId"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("ddlProjectType"), DropDownList).DataBind()

            If DBUtilities.IsProjectManagementFeature = True Then
                'ddlAccountProjectTemplateId
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).DataSource = dsAccountProjectTemplatesObject
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).DataTextField = "ProjectName"
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).DataValueField = "AccountProjectId"
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).DataBind()

                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("EstimatedDurationTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("txtProjectEstimatedCost"), TextBox).Text = 0
                If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("txtFixedCost"), TextBox).Text = 0
                End If

            End If

            ' ''Project Billing Type
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DropDownList4"), DropDownList).DataSource = dsBillingTypeObjectInsert
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DropDownList4"), DropDownList).DataTextField = "BillingType"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DropDownList4"), DropDownList).DataValueField = "AccountBillingTypeId"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DropDownList4"), DropDownList).DataBind()

            ' ''DropDownList3
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList3"), DropDownList).DataSource = dsEmployeeObjectInsert
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList3"), DropDownList).DataTextField = "FullName"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList3"), DropDownList).DataValueField = "AccountEmployeeId"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList3"), DropDownList).DataBind()

            ' ''DropDownList5
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList5"), DropDownList).DataSource = dsEmployeeObjectInsert
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList5"), DropDownList).DataTextField = "FullName"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList5"), DropDownList).DataValueField = "AccountEmployeeId"
            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane1").FindControl("DropDownList5"), DropDownList).DataBind()

            'CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("DefaultBillingRateTextBox"), TextBox).Text = 0


            Me.FormView1.Visible = False


            If Me.Request.QueryString("IsTemplate") = "True" Then
                CType(Me.FormView1.FindControl("Literal20"), Literal).Text = Resources.TimeLive.Resource.Project_Template_Information
                CType(Me.FormView1.FindControl("Literal21"), Literal).Text = Resources.TimeLive.Resource.Project_Template
            Else
                CType(Me.FormView1.FindControl("Literal20"), Literal).Text = "Add Project"
                CType(Me.FormView1.FindControl("Literal21"), Literal).Text = Resources.TimeLive.Resource.Basic
            End If

        End If
        If Me.Request.QueryString("IsTemplate") <> "True" Then
            If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                If LocaleUtilitiesBLL.IsProjectTemplateMandatory = True Then
                    'CType(Me.FormView1.FindControl("CustomValidator3"), CustomValidator).ControlToValidate = CType(Me.FormView1.FindControl("Project"), TextBox).Text
                End If
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If DBUtilities.IsBillingFeature = False Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").Visible = False
            End If
            If DBUtilities.IsProjectManagementFeature = False Then
                Me.FormView1.FindControl("MyAccordion").FindControl("AdvanceAccordion").Visible = False
            End If
        End If
        If Me.Request.QueryString("IsTemplate") <> "True" Then
            If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                If LocaleUtilitiesBLL.AutoGenerateProjectCode = True Then
                    Me.AutoProjectCodeNo(DBUtilities.GetSessionAccountId)
                End If
            End If
        End If
        If Me.Request.QueryString("IsTemplate") <> "True" Then
            If LocaleUtilitiesBLL.AutoGenerateProjectCode = True Then
                CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).ReadOnly = True
            End If
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                If Not IsDBNull(Me.FormView1.DataItem("ProjectPrefix")) Then
                    If Not Me.FormView1.DataItem("ProjectPrefix") = "" Then
                        CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text = Me.FormView1.DataItem("ProjectPrefix") & "-" & Me.FormView1.DataItem("ProjectCode")
                    Else
                        CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text = Me.FormView1.DataItem("ProjectCode")
                    End If
                End If
            End If
        End If
    End Sub
    Protected Sub btnRoleWiseBillingRate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Request.QueryString("IsTemplate") = "True" Then

            Response.Redirect("~/ProjectAdmin/AccountProjectRole.aspx?AccountProjectId=" & Me.FormView1.DataKey("AccountProjectId") & "&" & "IsTemplate=True" & "&Source=ProjectTemplates", False)
        Else
            If Me.Request.QueryString("Source") = "MyProjects" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectRole.aspx?AccountProjectId=" & Me.FormView1.DataKey("AccountProjectId") & "&Source=MyProjects", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectRole.aspx?AccountProjectId=" & Me.FormView1.DataKey("AccountProjectId"), False)
            End If
        End If
    End Sub
    Protected Sub btnProjectEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Request.QueryString("IsTemplate") = "True" Then
            Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Me.FormView1.DataKey("AccountProjectId") & "&" & "IsTemplate=True" & "&Source=ProjectTemplates", False)
        Else
            If Me.Request.QueryString("Source") = "MyProjects" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Me.FormView1.DataKey("AccountProjectId") & "&Source=MyProjects", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Me.FormView1.DataKey("AccountProjectId"), False)
            End If
        End If
    End Sub
    Protected Sub FormView1_ModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ModeChanged
        'CType(Me.FormView1.FindControl("DropDownList2"), DropDownList).DataBind()
    End Sub
    Protected Sub ddlAccountProjectTemplateId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AccountProjectId As Integer
        AccountProjectId = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).SelectedValue
        Dim BLL As New AccountProjectBLL
        Dim dt As TimeLiveDataSet.AccountProjectDataTable = BLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim dr As TimeLiveDataSet.AccountProjectRow
        Try
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                CType(Me.FormView1.FindControl("DropDownList2"), DropDownList).SelectedValue = dr.AccountClientId
                If LocaleUtilitiesBLL.AutoGenerateProjectCode = False Then
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ProjectCodeTextBox"), TextBox).Text = dr.ProjectCode
                End If
                CType(Me.FormView1.FindControl("ProjectNameTextBox"), TextBox).Text = dr.ProjectName
                CType(Me.FormView1.FindControl("StartDate"), eWorld.UI.CalendarPopup).SelectedDate = dr.StartDate
                CType(Me.FormView1.FindControl("Deadline"), eWorld.UI.CalendarPopup).SelectedDate = dr.Deadline
                CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).SelectedValue = dr.ProjectStatusId

                If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then
                    CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("txtFixedCost"), TextBox).Text = dr.FixedCost
                End If


                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("txtProjectEstimatedCost"), TextBox).Text = dr.ProjectEstimatedCost
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("EstimatedDurationTextBox"), TextBox).Text = dr.EstimatedDuration

                RaiseEvent btnTemplateClick(sender)
            Else
                RaiseEvent SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception
            'Response.Redirect("~/ProjectAdmin/AccountProjects.aspx", False)
            RaiseEvent SelectedIndexChanged(sender, e)
            Return
        End Try
    End Sub
    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("ProjectDescriptionTextBox"), TextBox).Text.Length > 4000 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.Visible = False

    End Sub
    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.Visible = False
        RaiseEvent btnCancelClick(sender, e)
        If Me.Request.QueryString("IsTemplate") = "True" Then
            Response.Redirect("~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True", False)
        End If
    End Sub
    Protected Sub Add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Request.QueryString("IsTemplate") Is Nothing Then
            If LocaleUtilitiesBLL.IsProjectTemplateMandatory Then
                If DBUtilities.IsProjectManagementFeature = True Then
                    CType(Me.FormView1.FindControl("CustomValidator3"), CustomValidator).Enabled = True
                    CType(Me.FormView1.FindControl("CustomValidator3"), CustomValidator).IsValid = True
                    CType(Me.FormView1.FindControl("CustomValidator3"), CustomValidator).Validate()
                End If
            End If
        End If
        RaiseEvent btnAddClick(sender, e)
    End Sub
    Private Sub AutoProjectCodeNo(ByVal AccountId As Integer)
        Me.IsValidProjectCodeTextBox()
    End Sub
    Public Function GetProjectCode() As Boolean
        Dim ProjectBll As New AccountProjectBLL
        Dim dtCheckProjectCode As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBll.GetAccountProjectByCheckProjectCode(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ProjectCodeTextBox"), TextBox).Text)
        If dtCheckProjectCode.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function IsValidProjectCodeTextBox() As Boolean
        Dim ProjectBll As New AccountProjectBLL
        ''zeeshan

        Dim ProjectCodePrefix As String
        ProjectCodePrefix = DBUtilities.GetProjectCodePrefix

        If DBUtilities.IncludeCurrentYearInProjectCode Then
            ProjectCodePrefix = IIf(DBUtilities.GetProjectCodePrefix = "", Date.Now.Year.ToString, DBUtilities.GetProjectCodePrefix & "-" & Date.Now.Year.ToString)
        End If
        'end code.


        Dim dtProjectCode As TimeLiveDataSet.AccountProjectCodeDataTable = ProjectBll.GetAccountProjectByLastProjectCode(DBUtilities.GetSessionAccountId, ProjectCodePrefix)
        Dim drProjectCode As TimeLiveDataSet.AccountProjectCodeRow
        drProjectCode = dtProjectCode.Rows(0)
        If Not IsDBNull(drProjectCode.Item("ProjectCode")) Then
            Dim ProjectCode As Single
            If Not Single.TryParse(CType(Me.FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text, ProjectCode) Then
                Dim AccountId = DBUtilities.GetSessionAccountId
                If DBUtilities.IncludeCurrentYearInProjectCode Then
                    CType(FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text = IIf(DBUtilities.GetProjectCodePrefix = "", Date.Now.Year.ToString & "-" & drProjectCode.Item("ProjectCode") + 1, DBUtilities.GetProjectCodePrefix & "-" & Date.Now.Year.ToString & "-" & drProjectCode.Item("ProjectCode") + 1)
                Else
                    CType(FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text = IIf(DBUtilities.GetProjectCodePrefix = "", drProjectCode.Item("ProjectCode") + 1, DBUtilities.GetProjectCodePrefix & "-" & drProjectCode.Item("ProjectCode") + 1)
                End If
                Return False
            End If
            Return True
        ElseIf DBUtilities.IncludeCurrentYearInProjectCode Then
            CType(FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text = IIf(DBUtilities.GetProjectCodePrefix = "", Date.Now.Year.ToString & "-" & 1, DBUtilities.GetProjectCodePrefix & "-" & Date.Now.Year.ToString & "-" & 1)
        Else
            CType(FormView1.FindControl("ProjectCodeTextBox"), TextBox).Text = IIf(DBUtilities.GetProjectCodePrefix = "", 1, DBUtilities.GetProjectCodePrefix & "-" & 1)
        End If
    End Function
    Protected Sub CustomValidator2_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If Me.Request.QueryString("IsTemplate") <> "True" Then
            If LocaleUtilitiesBLL.AutoGenerateProjectCode = True Then
                'If Me.GetProjectCode = True Then
                '    'args.IsValid = False
                'End If
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemInserting(sender As Object, e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Inserting(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub FormView1_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        RaiseEvent btnUpdateClick(sender, e)
        Dim BLL As New AccountProjectAttachmentBLL
        Dim AccountProjectId = Me.FormView1.DataKey("AccountProjectId")
        BLL.FileUpload(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("AttachmentFileUploadEdit"), AccountProjectId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("AttachmentNameTextBoxEdit"), TextBox).Text)
        If Me.Request.QueryString("Source") = "MyProjects" Then
            Response.Redirect("~/Employee/MyProjects.aspx", False)
        ElseIf Not Me.Request.QueryString("IsTemplate") Is Nothing Then
            Response.Redirect("~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True", False)
        Else
            Response.Redirect("~/ProjectAdmin/AccountProjects.aspx", False)
        End If
    End Sub
    Protected Sub FormView1_ItemInserted(sender As Object, e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        'Dim BLL As New AccountProjectAttachmentBLL
        Dim AccountProjectId = New AccountProjectBLL().GetLastInsertedId
        'BLL.FileUpload(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("AttachmentFileUpload"), AccountProjectId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane2").FindControl("AttachmentNameTextBox"), TextBox).Text)
    End Sub
    Protected Sub btnProjectMilestone_Click(sender As Object, e As System.EventArgs)
        Response.Redirect("~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects", False)
        'Me.CtlAccountProjectForm1.EditRecord(Me.Request.QueryString("AccountProjectId"))
    End Sub
    Protected Sub CustomValidator3_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs)

        If CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane4").FindControl("ddlAccountProjectTemplateId"), DropDownList).SelectedValue = 0 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If

    End Sub
End Class
