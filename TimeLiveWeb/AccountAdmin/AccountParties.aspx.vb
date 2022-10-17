
Partial Class AccountAdmin_frmAccountParty
    Inherits System.Web.UI.Page
    Protected Sub CtlAccountPartyList1_EditClick1(ByVal sender As Object, ByVal CommandArgs As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountPartyList1.EditClick
        If Me.CtlAccountPartyList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountPartyList1_btnAddClientClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountPartyList1.btnAddClientClick
        If Me.CtlAccountPartyList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
End Class
