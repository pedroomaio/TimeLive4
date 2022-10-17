
Partial Class AccountAdmin_Controls_ctlAccountTaxZoneList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            'Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub dsAccountTaxZoneFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaxZoneFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountTaxZoneFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTaxZoneFormViewObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountTaxZoneFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTaxZoneFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(117, Me.GridView1, Me.FormView1, "ADDButton", 2, 3)
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub dsAccountTaxZoneFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTaxZoneFormViewObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
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

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInEditMode = True
        End If
    End Sub
    Public Sub CheckIsDisabledForLastRecord()
        Dim dt As TimeLiveDataSet.AccountTaxZoneDataTable = New AccountTaxZoneBLL().GetAccountTaxZonesByAccountIdAndIsDisabled(DBUtilities.GetSessionAccountId, 0)
        Dim Count As Integer = dt.Rows.Count
        If CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Checked = False Then
            Count += 1
        ElseIf CType(Me.FormView1.FindControl("IsDisabledCheckBox"), CheckBox).Checked = True Then
            Count -= 1
        End If
        If Count < 1 Then
            Throw New Exception("You should have atleast one " & """Tax Zone""" & " avaiable in Timelive.")
        End If
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        CheckIsDisabledForLastRecord()
    End Sub
End Class
