
Partial Class ProjectAdmin_Controls_ctlAccountProjectTaskEmployeeList
    Inherits System.Web.UI.UserControl

    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        Dim objAccountProjectTaskEmployee As New AccountProjectTaskEmployeeBLL

        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkSelected"), CheckBox).Checked = True And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                objAccountProjectTaskEmployee.AddAccountProjectTaskEmployee(64, 0, Me.GridView1.DataKeys(row.RowIndex).Item(1), Me.GridView1.DataKeys(row.RowIndex).Item(2), 100)
            Else
                If CType(row.FindControl("chkSelected"), CheckBox).Checked = False And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectTaskEmployee.DeleteAccountProjectTaskEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0))
                End If
            End If
        Next

        Me.GridView1.DataBind()

    End Sub
End Class
