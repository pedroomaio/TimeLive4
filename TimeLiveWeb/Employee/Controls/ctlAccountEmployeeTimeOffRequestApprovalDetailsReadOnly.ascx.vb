
Partial Class Employee_Controls_ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly
    Inherits System.Web.UI.UserControl
    Public SubmittedBy As String
    Public SubmittedOn As Date

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles A.DataBound


    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles A.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Status As String = ""
            If IsDBNull(e.Row.DataItem("ApproverName")) Then
                Status = ResourceHelper.GetFromResource("Approved")
            Else
                If e.Row.DataItem("IsApproved") = True Then
                    Status = ResourceHelper.GetFromResource("Approved")
                ElseIf e.Row.DataItem("IsRejected") = True Then
                    Status = ResourceHelper.GetFromResource("Rejected")
                End If
            End If
            CType(e.Row.FindControl("S"), Label).Text = Status
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim TimeOffRequestId As Guid = New Guid(Me.Request.QueryString("AccountEmployeeTimeOffRequestId"))
        Dim TimeOffRequest = New AccountEmployeeTimeOffRequestBLL()
        Dim res = TimeOffRequest.GetAccountEmployeeTimeOffRequestByEmployeeRequestId(TimeOffRequestId)

        If res.Count > 0 Then

            Me.LSO.Text = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(res(0).RequestSubmitDate)
            Me.lblHoursOff.Text = res(0).HoursOff
            Me.lblDaysOff.Text = res(0).DayOff
            Me.lblStartDate.Text = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(res(0).StartDate)
            Me.lblEndDate.Text = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(res(0).EndDate)
            Me.lblTimeOffType.Text = Me.Request.QueryString("AccountTimeOffType")

        End If
        Me.SB.Text = DBUtilities.GetSessionEmployeeName

    End Sub
End Class
