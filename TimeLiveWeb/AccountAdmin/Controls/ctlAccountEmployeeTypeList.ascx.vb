Partial Class AccountAdmin_Controls_ctlAccountEmployeeTypeList
    Inherits System.Web.UI.UserControl
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then

        End If
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Protected Sub dsAccountEmployeeTypeFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountEmployeeTypeFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountEmployeeTypeFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeTypeFormViewObject.Inserting
        DBUtilities.SetRowForInserting(e)
        'e.InputParameters("AccountEmployeeType") = CType(Me.FormView1.FindControl("txtEmployeeType"), TextBox).Text
    End Sub
    Protected Sub dsAccountEmployeeTypeFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountEmployeeTypeFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(128, Me.GridView1, Me.FormView1, "btnAdd", 1, 2)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("IsVendor")) Then
                CType(Me.FormView1.FindControl("IsVendorCheckBox"), CheckBox).Checked = Me.FormView1.DataItem("IsVendor")
            Else
                CType(Me.FormView1.FindControl("IsVendorCheckBox"), CheckBox).Checked = False
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    Protected Sub dsAccountEmployeeTypeFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeTypeFormViewObject.Updating
        DBUtilities.SetRowForUpdating(e)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            'e.NewValues.Item("IsVendor") = CType(Me.FormView1.FindControl("IsVendorCheckBox"), CheckBox).Checked
            e.InputParameters("IsVendor") = CType(Me.FormView1.FindControl("IsVendorCheckBox"), CheckBox).Checked
        End If
        'e.NewValues.Item("ProjectBillingRateTypeId") = CType(Me.FormView1.FindControl("ddlProjectBillingRateTypeId"), DropDownList).SelectedValue
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Call New AccountEmployeeTypeBLL().DeleteAccountEmployeeType(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeTypeId"))
        e.Cancel = True
        Response.Redirect("~/AccountAdmin/AccountEmployeeType.aspx", False)
    End Sub
End Class
