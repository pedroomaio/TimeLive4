
Partial Class ProjectAdmin_AccountProjectGantt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode

        If System.Web.HttpContext.Current.Request.QueryString("Source") = "MyProjects" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(27)
        ElseIf System.Web.HttpContext.Current.Request.QueryString("Source") = "ProjectTemplates" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(103, "~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True")
        Else
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(31)
        End If

    End Function
End Class
