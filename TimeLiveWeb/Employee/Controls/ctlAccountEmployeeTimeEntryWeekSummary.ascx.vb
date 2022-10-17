
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryWeekSummary
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles G.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblPSD As Label = CType(e.Row.FindControl("lblPSD"), Label)
            Dim lblPED As Label = CType(e.Row.FindControl("lblPED"), Label)
            Dim lblTotalDuration As Label = CType(e.Row.FindControl("lblTotalDuration"), Label)
            Dim Submitted As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "Submitted")), "", DataBinder.Eval(e.Row.DataItem, "Submitted"))
            Dim Approved As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "Approved")), "", DataBinder.Eval(e.Row.DataItem, "Approved"))
            Dim Rejected As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "Rejected")), "", DataBinder.Eval(e.Row.DataItem, "Rejected"))
            Dim InApproval As String = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "InApproval")), "", DataBinder.Eval(e.Row.DataItem, "InApproval"))
            Dim lblTimesheetStatus As Label = CType(e.Row.FindControl("lblTimesheetStatus"), Label)
            If Not Submitted = "" Then
                SetStatusColumnValues(Submitted, Approved, Rejected, InApproval, lblTimesheetStatus)
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TotalMinutes")) Then
                    lblTotalDuration.Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) Then
                    lblPSD.Text = DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TimeEntryEndDate")) Then
                    lblPED.Text = DataBinder.Eval(e.Row.DataItem, "TimeEntryEndDate")
                End If
            End If
        End If
    End Sub
    Public Sub SetStatusColumnValues(ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal InApproval As Boolean, ByVal lblTimesheetStatus As Label)
        If Submitted = False And Rejected = False And Approved = False And InApproval = False Then
            lblTimesheetStatus.Text = "Not Submitted"
        ElseIf Submitted = True And Approved = True And Rejected = False Then
            lblTimesheetStatus.Text = "Approved"
        ElseIf Rejected = True And Submitted = False Then
            lblTimesheetStatus.Text = "Rejected"
        ElseIf Submitted = True And Rejected = False And Approved = False And InApproval = True Then
            lblTimesheetStatus.Text = "Submitted"
        ElseIf Submitted = True And Rejected = False And Approved = False And InApproval = False Then
            lblTimesheetStatus.Text = "Submitted"
        ElseIf Submitted = False And Approved = True Then
            lblTimesheetStatus.Text = "Not Submitted"
        ElseIf Submitted = False And InApproval = True Then
            lblTimesheetStatus.Text = "Not Submitted"
        End If
    End Sub
End Class

