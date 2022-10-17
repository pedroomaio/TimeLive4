
Partial Class AccountAdmin_Controls_ctlAccountPriorityList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub dsAccountPriorityFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountPriorityFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountPriorityFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountPriorityFormObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub dsAccountPriorityFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)

    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermission(76, Me.GridView1, Me.FormView1, "Add", 2, 3)
        If FormView1.CurrentMode = FormViewMode.Edit Then
            If Me.GridView1.Rows.Count = 1 Then
                CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Enabled = False
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        If Me.GridView1.Rows.Count = 1 Then
            UIUtilities.ShowMessage("Can't Delete. One row is necessary.", Me.Page)
            e.Cancel = True
        End If

    End Sub
End Class