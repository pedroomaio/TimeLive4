
Partial Class AccountAdmin_frmAccountEmployees
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub CtlAccountEmployeeForm1_btnAddEmployeeClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountEmployeeForm1.btnAddEmployeeClick
        If Me.CtlAccountEmployeeForm1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountEmployeeForm1_EditClick1(ByVal sender As Object, ByVal CommandArgs As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountEmployeeForm1.EditClick
        If Me.CtlAccountEmployeeForm1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
End Class
