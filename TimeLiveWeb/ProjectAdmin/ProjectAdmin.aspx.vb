
Partial Class ProjectAdmin_ProjectAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim node As New SiteMapNode(SiteMap.Provider, "~/ProjectAdmin/ProjectAdmin.aspx", "~/ProjectAdmin/ProjectAdmin.aspx")
        Dim parentNode As SiteMapNode = SiteMap.Provider.FindSiteMapNode("~/Employee/MyProjects.aspx")
        node.ParentNode = parentNode
    End Sub

End Class
