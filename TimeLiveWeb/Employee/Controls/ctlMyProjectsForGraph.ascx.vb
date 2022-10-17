
Partial Class Employee_Controls_ctlMyProjectsForGraph
    Inherits System.Web.UI.UserControl
    Dim TimesheetPeriodDaysArray As ArrayList
    Dim TotalFields As Integer
    Dim dtcolumn As New TemplateField
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.dsObjectMyProjectGridView.SelectParameters("Completed").DefaultValue = "0"
        Me.dsObjectMyProjectGridView.SelectParameters("Disabled").DefaultValue = "1"
    End Sub

    Protected Sub MPGV_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles MPGV.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ScheduleStatus")) Then
                Dim schedulestatus As String = DataBinder.Eval(e.Row.DataItem, "ScheduleStatus")
                CType(e.Row.FindControl("Label1"), Label).Text = schedulestatus
            End If
        End If
    End Sub
End Class

