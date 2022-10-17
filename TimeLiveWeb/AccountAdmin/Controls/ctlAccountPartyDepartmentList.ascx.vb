
Partial Class AccountAdmin_Controls_ctlAccountPartyDepartmentList
    Inherits System.Web.UI.UserControl
    Public Event EditClick(ByVal sender As Object, ByVal CommandArgs As GridViewCommandEventArgs)
    Public Event btnAddClientDepartmentClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.FormView1.Visible = True
            Me.GridView1.Visible = False
            Me.btnAdd.Visible = False
            RaiseEvent EditClick(sender, e)
        End If
    End Sub

    Protected Sub dsAccountPartyDepartmentFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountPartyDepartmentFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountPartyDepartmentFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountPartyDepartmentFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(97, Me.GridView1, Me.FormView1, "btnAdd", 4, 5)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            Me.FormView1.Visible = False
            Me.GridView1.Visible = True
            Me.btnAdd.Visible = True
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.FormView1.Visible = True
            Me.GridView1.Visible = False
            Me.btnAdd.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Me.FormView1.Visible = True
        Me.GridView1.Visible = False
        Me.btnAdd.Visible = False
        RaiseEvent btnAddClientDepartmentClick(sender, e)
    End Sub
End Class






