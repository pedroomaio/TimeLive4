
Partial Class Controls_ctlAccountDepartmentList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            'Me.UpdatePanel2.Update()
        End If
    End Sub

    Protected Sub dsAccountDepartmentObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountDepartmentObject.Inserted
        dbutilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountDepartmentObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountDepartmentObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountDepartmentObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountDepartmentObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub


    Protected Sub dsAccountDepartmentObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountDepartmentObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(3, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)
        Dim row As GridViewRow
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            For Each row In Me.GridView1.Rows
                If Me.GridView1.Rows.Count = 1 Then
                    If CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Checked = True Then
                        CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Checked = False
                    End If
                    CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Enabled = True
                End If
            Next
        End If
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
            '            AccountPagePermissionBLL.SetPagePermission(3, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' AccountPagePermissionBLL.SetPagePermission(3, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)


    End Sub

    Protected Sub FormView1_ModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ModeChanged
        '    AccountPagePermissionBLL.SetPagePermission(3, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)
        'Me.UpdatePanel2.Update()
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
