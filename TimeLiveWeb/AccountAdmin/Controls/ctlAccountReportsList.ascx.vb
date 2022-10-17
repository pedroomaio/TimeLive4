
Imports TimeLive.WebReport

Partial Class AccountAdmin_Controls_ctlAccountReportsList
    Inherits System.Web.UI.UserControl

    Private Sub AccountAdmin_Controls_ctlAccountReportsList_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub Update_bt_Click(sender As Object, e As EventArgs)

        For Each item As GridViewRow In GridView1.Rows
            Dim ReportId As String = GridView1.DataKeys(item.RowIndex)("AccountReportId")
            Dim Visible As Boolean = CType(item.Cells(2).Controls(1), CheckBox).Checked
            Dim bll As New ReportDesignBLL

            bll.UpdateMyReportGrid(ReportId, Visible)

        Next

    End Sub
    Protected Sub ActiveAll_Click(sender As Object, e As EventArgs)
        For Each item As GridViewRow In GridView1.Rows
            If CType(item.Cells(2).Controls(1), CheckBox).Checked = False Then
                CType(item.Cells(2).Controls(1), CheckBox).Checked = True
            End If
        Next
    End Sub
End Class
