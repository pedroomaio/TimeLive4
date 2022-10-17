
Partial Class AccountAdmin_AccountPartyContacts
    Inherits System.Web.UI.Page
    Protected Sub CtlAccountPartyContactList1_EditClick1(ByVal sender As Object, ByVal CommandArgs As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountPartyContactList1.EditClick
        If Me.CtlAccountPartyContactList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountPartyContactList1_btnAddClientContactClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountPartyContactList1.btnAddClientContactClick
        If Me.CtlAccountPartyContactList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
End Class
