
Partial Class ProjectAdmin_Default
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' form load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim pbll As New AccountPagePermissionBLL
        If AccountPagePermissionBLL.IsPageHasPermissionOf(34, 1) = True Then
            Response.Redirect("~/Employee/MyProjects.aspx", False)
        Else
            EncodeSiteMenuTitle()
            Response.Redirect("~/ProjectAdmin/TimeSheetApproval.aspx", False)
        End If
    End Sub
    ''' <summary>
    ''' Manage Site Menu URL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EncodeSiteMenuTitle() As String
        Dim pbll As New AccountPagePermissionBLL
        Return "~/ProjectAdmin/TimeSheetApproval.aspx"
    End Function
End Class
