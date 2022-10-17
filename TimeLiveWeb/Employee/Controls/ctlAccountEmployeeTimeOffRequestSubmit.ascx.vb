
Partial Class Employee_Controls_ctlAccountEmployeeTimeOffRequestSubmit
    Inherits System.Web.UI.UserControl

    Public Sub TimeOffRequestSubmit()

        Dim requestId = New Guid(CType(Me.TimeOffRequesId.Value, String))
        Dim accountEmployeeTimeOffRequest = New AccountEmployeeTimeOffRequestBLL()
        Dim request = accountEmployeeTimeOffRequest.GetAccountEmployeeTimeOffRequestByEmployeeRequestId(requestId)

        If request.Count > 0 Then

            If request(0).AccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId Then 'And request(0).Rejected = True Then
                Dim AccountEmployeeTimeEntryBLL As New AccountEmployeeTimeEntryBLL

                accountEmployeeTimeOffRequest.SubmitTimeOffRequest(DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountId, requestId)
                AccountEmployeeTimeEntryBLL.SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, requestId)
                Response.Redirect("~/Employee/MyTimeOff.aspx")
            End If
        End If
    End Sub

End Class
