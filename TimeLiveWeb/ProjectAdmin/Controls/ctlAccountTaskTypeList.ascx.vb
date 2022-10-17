
Partial Class AccountAdmin_Controls_ctlAccountTaskTypeList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub dsAccountTaskTypeObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaskTypeObject.Inserted

    End Sub

    Protected Sub dsAccountTaskTypeObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTaskTypeObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountTaskTypeObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaskTypeObject.Updated

    End Sub

    Protected Sub dsAccountTaskTypeObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTaskTypeObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.dsAccountTaskTypeObject.Update()
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub dsAccountTaskTypeFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaskTypeFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountTaskTypeFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaskTypeFormObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
End Class
