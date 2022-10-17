Partial Class Employee_Controls_ctlAccountProjectTaskCommentsList
    Inherits System.Web.UI.UserControl
    Public Event ItemUpdating As FormViewUpdateEventHandler
    Public WithEvents oListBox As ListBox
    Public ListControlValues As Hashtable
    Dim AccountProjectTaskId As Integer
    Dim ischeckAccountId As Boolean
    Protected Sub dsAccountProjectTaskCommentsForm_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)

    End Sub
    Protected Sub dsAccountProjectTaskCommentsForm_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskCommentsForm.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountProjectTaskCommentsForm_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskCommentsForm.Inserting
        DBUtilities.SetRowForInserting(e)

    End Sub
    Protected Sub oListBox_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles oListBox.DataBound

        Dim BLL As New AccountProjectTaskEmployeeBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable

        If Not Request.QueryString("AccountProjectTaskId") Is Nothing Then
            AccountProjectTaskId = Request.QueryString("AccountProjectTaskId")
        Else
            AccountProjectTaskId = dsAccountProjectTaskFormObject.SelectParameters("AccountProjectTaskId").DefaultValue
        End If

        dt = BLL.GetAccountProjectTaskEmployeesByAccountProjectTaskId(AccountProjectTaskId)

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

    Protected Sub dsAccountProjectTaskCommentsForm_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskCommentsForm.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub dsAccountProjectTaskCommentsForm_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskCommentsForm.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub dsAccountProjectTaskFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskFormObject.Inserted
        Me.RedirectToMyTask()
    End Sub
    Public Sub RedirectToMyTask()
        UIUtilities.RedirectToMyTask()
    End Sub

    Protected Sub dsAccountProjectTaskFormObject_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskFormObject.Selected
        'e.
    End Sub

    Protected Sub dsAccountProjectTaskFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskFormObject.Updated
        Dim ts As New AccountProjectTaskEmployeeBLL

        Dim l As ListBox = Me.FormView1.FindControl("ListBoxEmployeesUpdate")

        Me.ListControlValues = Me.ViewState("ListViewControl")

        For Each s As ListItem In l.Items
            If s.Selected And Not ListControlValues.ContainsKey(s.Value) Then
                ts.AddAccountProjectTaskEmployee(DBUtilities.GetSessionAccountId, 0, Me.ViewState("AccountProjectTaskId"), s.Value, 100)
            ElseIf s.Selected = False And ListControlValues.ContainsKey(s.Value) Then
                ts.DeleteAccountProjectTaskEmployeeId(ListControlValues.Item(s.Value))
            End If
        Next

        Dim TaskBLL As New AccountProjectTaskBLL
        TaskBLL.SendUpdatedTaskEMail(Me.ViewState("AccountProjectTaskId"))


        Me.RedirectToMyTask()
    End Sub
    Protected Sub dsAccountProjectTaskFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskFormObject.Updating
        DBUtilities.SetRowForUpdating(e)
        e.InputParameters("IsReOpen") = CType(Me.FormView1.FindControl("chkIsReOpen"), CheckBox).Checked
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If ischeckAccountId = False Then
                If AccountPagePermissionBLL.GetPageIdByPage(Me.Page) = 21 Then
                    CType(Me.FormView1.FindControl("ListBoxEmployeesUpdate"), ListBox).DataSourceID = ""
                    AccountEmployeeBLL.SetDataForEmployeeListBox(21, CType(Me.FormView1.FindControl("ListBoxEmployeesUpdate"), ListBox), 3, Me.FormView1.DataItem("AccountProjectId"), Me.FormView1.DataItem("AccountProjectTaskId"))
                End If
                If Not IsDBNull(Me.FormView1.DataItem("EstimatedTimeSpentUnit")) Then
                    'CType(Me.FormView1.FindControl("ddlEstimatedTimeSpentUnit"), DropDownList).SelectedValue = Me.FormView1.DataItem("EstimatedTimeSpentUnit")
                End If
                If Not IsDBNull(Me.FormView1.DataItem("IsBillable")) Then
                    CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked = Me.FormView1.DataItem("IsBillable")
                End If

                Me.RefillParentTask()

                If Not IsDBNull(Me.FormView1.DataItem("AccountProjectId")) Then
                    CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountProjectId")
                End If

                If Not IsDBNull(Me.FormView1.DataItem("AccountTaskTypeId")) Then
                    Me.dsAccountProjectTaskTypeObject.SelectParameters("AccountTaskTypeId").DefaultValue = Me.FormView1.DataItem("AccountTaskTypeId")
                    CType(Me.FormView1.FindControl("DropDownList1"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTaskTypeId")
                End If

                If Not IsDBNull(Me.FormView1.DataItem("TaskStatusId")) Then
                    Me.dsProjectTaskStatusObject.SelectParameters("AccountStatusId").DefaultValue = Me.FormView1.DataItem("TaskStatusId")
                    CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).SelectedValue = Me.FormView1.DataItem("TaskStatusId")
                End If

                If Not IsDBNull(Me.FormView1.DataItem("AccountPriorityId")) Then
                    Me.dsAccountPriorityObject.SelectParameters("AccountPriorityId").DefaultValue = Me.FormView1.DataItem("AccountPriorityId")
                    CType(Me.FormView1.FindControl("ddlAccountPriority"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountPriorityId")
                End If
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedCost")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("EstimatedCostTextBox"), TextBox).Text = Me.FormView1.DataItem("EstimatedCost")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("EstimatedCostTextBox"), TextBox).Text = 0
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EstimatedTimeSpent")) Then
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("EstimatedTimeSpentTextBox"), TextBox).Text = Me.FormView1.DataItem("EstimatedTimeSpent")
            Else
                CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("EstimatedTimeSpentTextBox"), TextBox).Text = 0
            End If

            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("Literal63"), Literal).Text = ResourceHelper.GetFromResource("Estimates")
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("Literal23"), Literal).Text = ResourceHelper.GetFromResource("Estimated Cost:")
            CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("Literal24"), Literal).Text = ResourceHelper.GetFromResource("Estimated Hours:")

            CType(Me.FormView1.FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataSource = dsAccountProjectMilestone
            CType(Me.FormView1.FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataTextField = "MilestoneDescription"
            CType(Me.FormView1.FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataValueField = "AccountProjectMilestoneId"

            CType(Me.FormView1.FindControl("ddlAccountProjectMilestoneId"), DropDownList).DataBind()

            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectMilestoneId")) Then
                CType(Me.FormView1.FindControl("ddlAccountProjectMilestoneId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountProjectMilestoneId")
            End If

        End If
    End Sub
    Protected Sub FormView1_ItemCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ItemCreated
        Dim objFormRow As FormViewRow = Me.FormView1.Row
        Dim objListBox As ListBox = objFormRow.FindControl("ListBoxEmployeesUpdate")

        If Not objListBox Is Nothing Then
            Me.oListBox = objListBox
        End If

        If Not Me.FormView1.DataItem Is Nothing Then
            Me.ViewState("AccountProjectId") = Me.FormView1.DataItem("AccountProjectId")
            Me.ViewState("AccountProjectTaskId") = Me.FormView1.DataItem("AccountProjectTaskId")
            Me.dsAccountProjectTask.SelectParameters("AccountProjectId").DefaultValue = Me.ViewState("AccountProjectId")
            'Me.dsAccountProjectMilestone.SelectParameters("AccountProjectId").DefaultValue = Me.ViewState("AccountProjectId")

        End If
    End Sub
    Protected Sub ListBoxEmployeesUpdate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub dsAccountProjectTaskFormObject_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)

    End Sub

    Protected Sub btnAuditTrail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Response.Redirect("~/Employee/Audit.aspx?AccountProjectTaskId=" & Request.QueryString("AccountProjectTaskId"))
        Me.Response.Redirect("~/Employee/AuditTrail.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId"), False)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UIUtilities.RedirectToMyTask()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub Page_Error(sender As Object, e As System.EventArgs) Handles Me.Error

    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        ''if accountid not this account then redirect home page
        If Not Me.Request.QueryString("AccountProjectTaskId") Is Nothing Then
            Dim dttask As TimeLiveDataSet.vueAccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountIdByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId"))
            Dim drtask As TimeLiveDataSet.vueAccountProjectTaskRow
            If dttask.Rows.Count > 0 Then
                drtask = dttask.Rows(0)
                If drtask.AccountId <> DBUtilities.GetSessionAccountId Then
                    ischeckAccountId = True
                    Dim message As String = "This task does not belongs to this account."
                    Dim url As String = "../Employee/Default.aspx"
                    Dim script As String = "window.onload = function(){ alert('"
                    script += message
                    script += "');"
                    script += "window.location = '"
                    script += url
                    script += "'; }"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
                    Me.FormView1.Attributes.Add("Style", "display:none")
                    Me.btnAuditTrail.Attributes.Add("Style", "display:none")
                    Me.AccordionPane1.Attributes.Add("Style", "display:none")
                    Me.AccordionPane2.Attributes.Add("Style", "display:none")
                    Me.MyAccordion1.Attributes.Add("Style", "display:none")

                End If
            End If
        End If
        AttachmentButton = CType(MyAccordion1.FindControl("btnAddAttachment"), Button)
        CommentsButton = CType(MyAccordion1.FindControl("btnAddComments"), Button)
        ShowComments()
        ShowAttachment()
    End Sub
    Dim AttachmentButton As New Button
    Dim CommentsButton As New Button
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnAuditTrail.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(24, 1)

    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        'e.NewValues("EstimatedTimeSpentUnit") = CType(Me.FormView1.FindControl("ddlEstimatedTimeSpentUnit"), DropDownList).SelectedValue
        e.NewValues.Item("ParentAccountProjectTaskId") = CType(Me.FormView1.FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue
        e.NewValues.Item("IsBillable") = CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked
        e.NewValues.Item("AccountTaskTypeId") = CType(Me.FormView1.FindControl("DropDownList1"), DropDownList).SelectedValue
        e.NewValues.Item("TaskStatusId") = CType(Me.FormView1.FindControl("DropDownList6"), DropDownList).SelectedValue
        e.NewValues.Item("AccountPriorityId") = CType(Me.FormView1.FindControl("ddlAccountPriority"), DropDownList).SelectedValue
        e.NewValues.Item("AccountProjectMilestoneId") = CType(Me.FormView1.FindControl("ddlAccountProjectMilestoneId"), DropDownList).SelectedValue
        e.NewValues.Item("IsForAllProjectTask") = CType(Me.FormView1.FindControl("checkbox5"), CheckBox).Checked

        e.NewValues.Item("EstimatedCost") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("EstimatedCostTextBox"), TextBox).Text
        e.NewValues.Item("EstimatedTimeSpent") = CType(Me.FormView1.FindControl("MyAccordion").FindControl("AccordionPane3").FindControl("EstimatedTimeSpentTextBox"), TextBox).Text

    End Sub
    Public Sub RefillParentTask()
        CType(Me.FormView1.FindControl("ddlParentAccountProjectTaskId"), DropDownList).Items.Clear()
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "<RootLevel>"
        item.Value = "0"
        CType(Me.FormView1.FindControl("ddlParentAccountProjectTaskId"), DropDownList).Items.Add(item)

        CType(Me.UpdatePanel2.FindControl("dsParentAccountProjectTaskObject"), ObjectDataSource).SelectParameters("AccountProjectId").DefaultValue = CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
        '  If Me.FormView1.CurrentMode = FormViewMode.Edit Then
        '            If Me.FormView1.DataItem("ParentAccountProjectTaskId") <> 0 Then
        CType(Me.FormView1.FindControl("ddlParentAccountProjectTaskId"), DropDownList).DataBind()

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("ParentAccountProjectTaskId")) Then
                CType(Me.FormView1.FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue = Me.FormView1.DataItem("ParentAccountProjectTaskId")
            End If
        End If
    End Sub

    Protected Sub btnTaskTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.FormView1.DataKey("AccountProjectTaskId") & "&AccountProjectId=" & CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue & "&Source=MyTasks", False)
    End Sub
    Dim Source As String
    Protected Sub btnAddComments_Click(sender As Object, e As System.EventArgs) Handles btnAddComments.Click
        Dim URL As String = "AccountProjectTaskCommentsPopup.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&Source=Comments"
        CommentsButton.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=635,height=300,left=280,top=280,scrollbars=yes'); return false;")
    End Sub
    Public Sub ShowComments()
        Dim URL As String = "AccountProjectTaskCommentsPopup.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&Source=Comments"
        CommentsButton.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=635,height=300,left=280,top=280,scrollbars=yes'); return false;")
    End Sub
    Public Sub ShowAttachment()
        Dim URL As String = "AccountProjectTaskCommentsPopup.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&Source=Attachment"
        AttachmentButton.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=700,height=280,left=280,top=280,scrollbars=yes'); return false;")
    End Sub
    Protected Sub btnAddAttachment_Click(sender As Object, e As System.EventArgs) Handles btnAddAttachment.Click
        Dim URL As String = "AccountProjectTaskCommentsPopup.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&Source=Attachment"
        AttachmentButton.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=700,height=280,left=280,top=280,scrollbars=yes'); return false;")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs)

    End Sub

    Protected Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

    End Sub
End Class
