
Partial Class AccountAdmin_Controls_ctlAccountProjectMilestoneList
    Inherits System.Web.UI.UserControl
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub
    Protected Sub dsAccountProjectMilestoneObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectMilestoneObject.Inserted

    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            If Me.Request.QueryString("AccountProjectMilestoneId") Is Nothing Then
                Me.FormView1.ChangeMode(FormViewMode.Insert)
                Me.FormView1.DataBind()
            Else
                Response.Redirect("~/Employee/MyTasks.aspx", False)
            End If
        End If
    End Sub

    Protected Sub dsAccountProjectMilestoneFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectMilestoneFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountProjectMilestoneFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectMilestoneFormObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountProjectMilestoneFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectMilestoneFormObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
        Dim projectaskbll As New AccountProjectTaskBLL

        Dim TaskStatusId = projectaskbll.GetCompletedTaskStatusId("Completed")
        If CType(Me.FormView1.FindControl("chkCompleted"), CheckBox).Checked = True Then
            projectaskbll.UpdateCompletedInTask(Me.Request.QueryString("AccountProjectId"), Me.FormView1.DataKey(0), TaskStatusId, CType(Me.FormView1.FindControl("chkCompleted"), CheckBox).Checked)
        End If
    End Sub

    Protected Sub dsAccountProjectMilestoneFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectMilestoneFormObject.Updating
        e.InputParameters("Completed") = CType(Me.FormView1.FindControl("chkcompleted"), CheckBox).Checked
        e.InputParameters("IsDisabled") = CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Checked
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermission(30, Me.GridView1, Me.FormView1, "Add", 3, 4)
        If Not Me.Request.QueryString("AccountProjectMilestoneId") Is Nothing Then
            Me.GridView1.Visible = False
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.dsAccountProjectMilestoneFormObject.SelectParameters("AccountProjectMilestoneId").DefaultValue = Me.Request.QueryString("AccountProjectMilestoneId")
        Else
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                If Not IsDBNull(Me.FormView1.DataItem("Completed")) Then
                    CType(Me.FormView1.FindControl("chkCompleted"), CheckBox).Checked = Me.FormView1.DataItem("Completed")
                End If
                If Not IsDBNull(Me.FormView1.DataItem("IsDisabled")) Then
                    CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Checked = Me.FormView1.DataItem("IsDisabled")
                End If
            End If
        End If

    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs)
        'If Not Me.Request.QueryString("AccountProjectMilestoneId") Is Nothing Then
        '    Response.Redirect("~/Employee/MyTasks.aspx", False)
        'End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs)
        'If Not Me.Request.QueryString("AccountProjectMilestoneId") Is Nothing Then
        '    Response.Redirect("~/Employee/MyTasks.aspx", False)
        'End If
    End Sub

    Protected Sub FormView1_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        If Not Me.Request.QueryString("AccountProjectMilestoneId") Is Nothing Then
            Response.Redirect("~/Employee/MyTasks.aspx", False)
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Call New AccountProjectMilestoneBLL().DeleteAccountProjectMilestone(Me.GridView1.DataKeys(e.RowIndex)("AccountProjectMilestoneId"), DBUtilities.GetEmployeeNameWithCode, "Deleted", "Time Off Request")
        '' last error found ObjectDataSource 'dsAccountProjectMilestoneObject' could not find a non-generic method 'DeleteAccountProjectMilestone' that has parameters: original_AccountProjectMilestoneId, original_Comments, original_Completed.
        'original_AccountProjectMilestoneId, original_Comments, original_Completed
    End Sub
End Class
