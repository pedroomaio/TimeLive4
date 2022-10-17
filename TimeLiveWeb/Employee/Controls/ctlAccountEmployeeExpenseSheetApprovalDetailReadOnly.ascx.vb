
Partial Class Employee_Controls_ctlAccountEmployeeExpenseSheetApprovalDetailReadOnly
    Inherits System.Web.UI.UserControl
    Public SubmittedBy As String
    Public SubmittedOn As Date

    Public Sub GetSubmittedByAndSubmittedOn()
        Dim AccountEmployeeExpenseSheetId As Guid = New System.Guid(Me.dsAccountEmployeeExpenseSheetApprovalDetailReadOnlyObject.SelectParameters("AccountEmployeeExpenseSheetId").DefaultValue)
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim dt As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = BLL.GetvueAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.vueAccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("SubmittedDate")) Then
                SubmittedBy = dr.EmployeeName
                SubmittedOn = dr.SubmittedDate
            End If
        Else
            SubmittedBy = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.GetSubmittedByAndSubmittedOn()

        Me.lblSubmittedBy.Text = SubmittedBy
        Me.lblSubmittedOn.Text = SubmittedOn
        Me.Literal1.Text = ResourceHelper.GetFromResource("Expense Approval Detail")
    End Sub
    Public Sub Show(ByVal AccountEmployeeExpenseSheetId As Guid)
        Me.dsAccountEmployeeExpenseSheetApprovalDetailReadOnlyObject.SelectParameters("AccountEmployeeExpenseSheetId").DefaultValue = AccountEmployeeExpenseSheetId.ToString
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Status As String = ""
            If IsDBNull(e.Row.DataItem("ApprovalEmployeeName")) Then
                Status = "Approved"
            Else
                If e.Row.DataItem("IsApproved") = True Then
                    Status = "Approved"
                ElseIf e.Row.DataItem("IsRejected") = True Then
                    Status = "Rejected"
                End If
            End If
            CType(e.Row.FindControl("lblStatus"), Label).Text = Status
        End If
    End Sub
End Class
