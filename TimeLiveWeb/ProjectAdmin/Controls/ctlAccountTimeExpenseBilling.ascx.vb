Partial Class ProjectAdmin_Controls_ctlAccountTimeExpenseBilling
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermissionForGridView(129, Me.GridView1, 6, 7)
        Me.btnAdd.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(129, 2)
        Me.btnUpdate.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(129, 3)
        If Me.GridView1.Rows.Count <> 0 Then
            Me.btnUpdate.Visible = True
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs)
        UIUtilities.OnDeleteException(e)
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/ProjectAdmin/AccountInvoiceForm.aspx", False)
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Call New AccountTimeExpenseBillingBLL().DeleteAccountTimeExpenseBilling(Me.GridView1.DataKeys(e.RowIndex)("AccountTimeExpenseBillingId"))
        e.Cancel = True
        Me.GridView1.DataBind()
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If Me.GridView1.Rows.Count <> 0 Then
                If CType(row.Cells(0).FindControl("chkPaid"), CheckBox).Checked = True Or CType(row.Cells(0).FindControl("chkPaid"), CheckBox).Checked = False Then
                    Dim Original_AccountTimeExpenseBillingId As Guid
                    If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex)(0)) Then
                        Original_AccountTimeExpenseBillingId = Me.GridView1.DataKeys(row.RowIndex)(0)
                        Dim IsPaid As Boolean
                        IsPaid = CType(row.Cells(0).FindControl("chkpaid"), CheckBox).Checked
                        Call New AccountTimeExpenseBillingBLL().UpdateInvoicePaid(Original_AccountTimeExpenseBillingId, IsPaid)
                    End If
                End If
            End If
        Next
    End Sub

    Protected Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        If Me.GridView1.Rows.Count <> 0 Then
            Dim cbHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("chkCheckAll"), CheckBox)

            'Run the ChangeCheckBoxState client-side function whenever the
            'header checkbox is checked/unchecked
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"

            For Each gvr As GridViewRow In GridView1.Rows
                'Get a programmatic reference to the CheckBox control
                Dim cb As CheckBox = CType(gvr.FindControl("chkpaid"), CheckBox)

                'Add the CheckBox's ID to the client-side CheckBoxIDs array
                ScriptManager.RegisterArrayDeclaration(Me, "CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
            Next
        End If
    End Sub
End Class
