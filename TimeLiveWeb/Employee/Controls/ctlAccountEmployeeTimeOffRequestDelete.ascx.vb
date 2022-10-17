
Partial Class Employee_Controls_ctlAccountEmployeeTimeOffRequestDelete
    Inherits System.Web.UI.UserControl
    Protected Sub TimeOffRequestDelete()


        Dim requestId = New Guid(CType(Me.TimeOffRequesId.Value, String))
        Dim accountEmployeeTimeOffRequest = New AccountEmployeeTimeOffRequestBLL()
        Dim request = accountEmployeeTimeOffRequest.GetAccountEmployeeTimeOffRequestByEmployeeRequestId(requestId)

        If request.Count > 0 Then

            If request(0).AccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId Then
                Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, requestId, True)
                accountEmployeeTimeOffRequest.DeleteAccountEmployeeTimeOffRequest(requestId)
                Response.Redirect("~/Employee/MyTimeOff.aspx")
            End If
        End If

    End Sub
End Class
