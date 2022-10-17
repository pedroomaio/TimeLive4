''' <summary>
''' AccountTimeOffPoliciesList control
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_Controls_ctlAccountTimeOffPoliciesList
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' Calling gridview RowDataBound event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        'UIUtilities.OnDeleteException(e)
    End Sub
    ''' <summary>
    ''' Calling page load event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermissionForGridView(139, Me.GridView1, 1, 2)
        Me.btnAdd.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(139, 2)
    End Sub
    ''' <summary>
    ''' Calling when user click the add button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/AccountAdmin/AccountTimeOffPoliciesDetail.aspx", False)
    End Sub
    ''' <summary>
    ''' calling row deleting event. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Call New AccountTimeOffPolicyBLL().DeleteAccountTimeOffPolicy(Me.GridView1.DataKeys(e.RowIndex)("AccountTimeOffPolicyId"))
        e.Cancel = True
        Response.Redirect("~/AccountAdmin/AccountTimeOffPolicies.aspx", False)
    End Sub
End Class
