
Partial Class AccountAdmin_Controls_ctlAccountTimeOffTypeList
    Inherits System.Web.UI.UserControl
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IsBillable As Boolean = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "IsTimeOffRequestRequired")), False, DataBinder.Eval(e.Row.DataItem, "IsTimeOffRequestRequired"))
            If IsBillable <> True And Not e.Row.FindControl("lblTimeOffRequest") Is Nothing Then
                CType(e.Row.Cells(1).FindControl("lblTimeOffRequest"), Label).Text = "No"
            ElseIf IsBillable <> False And Not e.Row.FindControl("lblTimeOffRequest") Is Nothing Then
                CType(e.Row.Cells(1).FindControl("lblTimeOffRequest"), Label).Text = "Yes"
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub dsAccountTimeOffTypeFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTimeOffTypeFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountTimeOffTypeFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTimeOffTypeFormViewObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountTimeOffTypeFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTimeOffTypeFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(138, Me.GridView1, Me.FormView1, "btnAdd", 2, 3)

        CType(Me.FormView1.FindControl("txtSelectedColor"), TextBox).CssClass += " jscolor {hash:true}"
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub dsAccountTimeOffTypeFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTimeOffTypeFormViewObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Call New AccountTimeOffTypeBLL().DeleteAccountTimeOffTypes(Me.GridView1.DataKeys(e.RowIndex)("AccountTimeOffTypeId"))
        e.Cancel = True
        Response.Redirect("~/AccountAdmin/AccountTimeOffTypes.aspx", False)
    End Sub
End Class
