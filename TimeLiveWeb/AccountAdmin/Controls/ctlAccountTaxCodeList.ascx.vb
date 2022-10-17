
Partial Class AccountAdmin_Controls_ctlAccountTaxCodeList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub dsAccountTaxCodeFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaxCodeFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountTaxCodeFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaxCodeFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(107, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)
        ShowData()
        Me.Label15.Text = ResourceHelper.GetFromResource("Tax Zone:")
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInInsertMode = True
        End If
    End Sub

    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        e.Values("AccountTaxZoneId") = Me.ddlTaxZone.SelectedValue
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInEditMode = True
        End If
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        'If Me.FormView1.CurrentMode = FormViewMode.Edit Then
        '    e.NewValues.Item("AccountTaxZoneId") = Me.ddlTaxZone.SelectedValue
        'End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Public Sub ShowData()
        Me.dsAccountTaxCodeGridViewObject.SelectParameters("AccountTaxZoneId").DefaultValue = Me.ddlTaxZone.SelectedValue
        GridView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ShowData()
        End If
    End Sub

    Protected Sub ddlTaxZone_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTaxZone.SelectedIndexChanged
        ShowData()
        'GridView1.DataBind()
    End Sub
End Class
