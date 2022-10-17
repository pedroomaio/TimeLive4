
Partial Class AccountAdmin_Controls_ctlAccountLocationList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub dsAccountLocationObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountLocationObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountLocationObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountLocationObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub dsAccountLocationFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountLocationFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountLocationFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountLocationFormObject.Updated
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

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermission(7, Me.GridView1, Me.FormView1, "Add", 2, 3)
        Dim row As GridViewRow
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            For Each row In Me.GridView1.Rows
                If Me.GridView1.Rows.Count = 1 Then
                    If CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Checked = True Then
                        CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Checked = False
                    End If
                    CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Enabled = True
                End If
            Next
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode
        'Return AccountPagePermissionBLL.ChangeCurrentNode(7, ResourceHelper.GetFromResource("Locations"))
    End Function
End Class
