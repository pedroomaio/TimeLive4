
Partial Class Employee_Controls_ctlAccountEmployeeTimeOffAudit
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetEmployeeName()
        'Me.TimeOffAuditGridView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(167, 1)
        TimeOffAuditGridView.DataBind()
       
    End Sub
    Public Sub GetEmployeeName()
        Dim dt As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetViewAccountEmployeesByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId"))
        Dim dr As AccountEmployee.vueAccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.lblEmployeeName.Text = dr.EmployeeName
        End If
    End Sub
    Protected Sub TimeOffAuditGridView_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles TimeOffAuditGridView.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TimeOffType")) Then
                CType(e.Row.Cells(2).FindControl("lblAccountTimeOffType"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "TimeOffType").ToString.Length > 20, Left(DataBinder.Eval(e.Row.DataItem, "TimeOffType"), 18) & "..", DataBinder.Eval(e.Row.DataItem, "TimeOffType"))
                If DataBinder.Eval(e.Row.DataItem, "TimeOffType").ToString.Length > 20 Then
                    CType(e.Row.Cells(2).FindControl("lblAccountTimeOffType"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "TimeOffType")
                End If
            End If
            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "EarnedDay")) Then
                    CType(e.Row.Cells(2).FindControl("lblEarned"), Label).Text = DataBinder.Eval(e.Row.DataItem, "EarnedDay")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ConsumeDay")) Then
                    CType(e.Row.Cells(3).FindControl("lblConsume"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ConsumeDay")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AvailableDay")) Then
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "CarryForwardDay")) Then
                    CType(e.Row.Cells(5).FindControl("lblCarryForward"), Label).Text = DataBinder.Eval(e.Row.DataItem, "CarryForwardDay")
                End If

                TimeOffAuditGridView.Columns(2).HeaderText = "Earned Days"
                TimeOffAuditGridView.Columns(3).HeaderText = "Consume Days"
                TimeOffAuditGridView.Columns(4).HeaderText = "Available Days"
                TimeOffAuditGridView.Columns(5).HeaderText = "Carry Forward Days"
            Else
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "EarnedHours")) Then
                    CType(e.Row.Cells(2).FindControl("lblEarned"), Label).Text = DataBinder.Eval(e.Row.DataItem, "EarnedHours")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ConsumeHours")) Then
                    CType(e.Row.Cells(3).FindControl("lblConsume"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ConsumeHours")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AvailableHours")) Then
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableHours")
                End If
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "CarryForward")) Then
                    CType(e.Row.Cells(5).FindControl("lblCarryForward"), Label).Text = DataBinder.Eval(e.Row.DataItem, "CarryForward")
                End If

                TimeOffAuditGridView.Columns(2).HeaderText = "Earned Hours"
                TimeOffAuditGridView.Columns(3).HeaderText = "Consume Hours"
                TimeOffAuditGridView.Columns(4).HeaderText = "Available Hours"
                TimeOffAuditGridView.Columns(5).HeaderText = "Carry Forward Hours"
            End If
        End If
    End Sub
End Class
