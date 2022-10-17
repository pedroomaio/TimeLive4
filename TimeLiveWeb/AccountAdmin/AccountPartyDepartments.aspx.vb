
Partial Class AccountAdmin_AccountPartyDepartments
    Inherits System.Web.UI.Page
    Protected Sub CtlAccountPartyDepartmentList1_EditClick1(ByVal sender As Object, ByVal CommandArgs As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountPartyDepartmentList1.EditClick
        If Me.CtlAccountPartyDepartmentList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountPartyDepartmentList1_btnAddClientDepartmentClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountPartyDepartmentList1.btnAddClientDepartmentClick
        If Me.CtlAccountPartyDepartmentList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
End Class
