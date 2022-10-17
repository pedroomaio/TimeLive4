
Partial Class Employee_frmAccountWorkingDay
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub CtlAccountWorkingDayList1_btnAddWorkingDayClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountWorkingDayList1.btnAddWorkingDayClick
        If Me.CtlAccountWorkingDayList1.FindControl("GridView2").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountWorkingDayList1_EditClick1(ByVal sender As Object, ByVal CommandArgs As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountWorkingDayList1.EditClick
        If Me.CtlAccountWorkingDayList1.FindControl("GridView2").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
End Class
