
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly
    Inherits System.Web.UI.UserControl
    Public SubmittedBy As String
    Public SubmittedOn As Date

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles A.DataBound
        Me.GetSubmittedByAndSubmittedOn()

        Me.SB.Text = SubmittedBy
        Me.LSO.Text = SubmittedOn
        Me.L.Text = ResourceHelper.GetFromResource("Timesheet Approval Detail")

    End Sub
    Public Sub GetSubmittedByAndSubmittedOn()
        Dim AccountEmployeeTimeEntryPeriodId As Guid = New System.Guid(Me.dsAccountEmployeeTimeEntryApprovalDetailsReadOnly.SelectParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim dt As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodDataTable = BLL.GetvueAccountEmployeeTimeEntryPeriodByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        Dim dr As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("SubmittedDate")) Then
                If IsDBNull(dr.Item("SubmittedBy")) Then
                    SubmittedBy = dr.TimeEntryEmployeeName
                Else
                    SubmittedBy = dr.SubmittedBy
                End If
                SubmittedOn = dr.SubmittedDate
            End If
        Else
            SubmittedBy = ""
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles A.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Status As String = ""
            Dim Projects As String = ""
            If IsDBNull(e.Row.DataItem("BatchId")) Then
                Projects = ""
            Else
                Dim BLL As New AccountEmployeeTimeEntryBLL
                Projects = BLL.GetProjectsForApprovalDetailReadOnly(e.Row.DataItem("BatchId"))
            End If
            CType(e.Row.FindControl("P"), Label).Text = Projects
            If IsDBNull(e.Row.DataItem("ApproverName")) Then
                Status = ResourceHelper.GetFromResource("Approved")
            Else
                If e.Row.DataItem("IsApproved") = True Then
                    Status = ResourceHelper.GetFromResource("Approved")
                ElseIf e.Row.DataItem("IsReject") = True Then
                    Status = ResourceHelper.GetFromResource("Rejected")
                End If
            End If
            CType(e.Row.FindControl("S"), Label).Text = Status
        End If
    End Sub
    Public Sub Show(ByVal AccountEmployeeTimeEntryPeriodId As Guid)
        Me.dsAccountEmployeeTimeEntryApprovalDetailsReadOnly.SelectParameters("AccountEmployeeTimeEntryPeriodId").DefaultValue = AccountEmployeeTimeEntryPeriodId.ToString
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Me.A.Columns(0).HeaderText = ResourceHelper.GetFromResource("Approved")
    End Sub
End Class
