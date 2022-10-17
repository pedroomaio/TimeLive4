''' <summary>
''' AccountApprovalList web user control
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_Controls_ctlAccountApprovalList
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' Calling gridview rowdatabound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IsTimeOffApprovalTypes As Boolean = IIf(IsDBNull(DataBinder.Eval(e.Row.DataItem, "IsTimeOffApprovalTypes")), False, DataBinder.Eval(e.Row.DataItem, "IsTimeOffApprovalTypes"))
            If IsTimeOffApprovalTypes <> True And Not e.Row.FindControl("lblIsTimeOff") Is Nothing Then
                CType(e.Row.Cells(1).FindControl("lblIsTimeOff"), Label).Text = "No"
            ElseIf IsTimeOffApprovalTypes <> False And Not e.Row.FindControl("lblIsTimeOff") Is Nothing Then
                CType(e.Row.Cells(1).FindControl("lblIsTimeOff"), Label).Text = "Yes"
            End If
        End If
    End Sub
    ''' <summary>
    ''' Redirecting on AccountApproval web form by calling add button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("~/AccountAdmin/AccountApproval.aspx", False)
    End Sub
    ''' <summary>
    ''' Calling gridview rowdeleted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
    End Sub
    ''' <summary>
    ''' Calling page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermissionForGridView(93, Me.GridView1, 2, 3)
        Me.btnAdd.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(93, 2)
    End Sub
End Class
