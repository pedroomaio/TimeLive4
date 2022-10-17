
Partial Class Employee_AccountProjectTaskComments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim node As New SiteMapNode(SiteMap.Provider, "~/Employee/AccountProjectTaskComments.aspx", "~/Employee/AccountProjectTaskComments.aspx")
        Dim parentNode As SiteMapNode = SiteMap.Provider.FindSiteMapNode("~/Employee/MyTasks.aspx")
        node.ParentNode = parentNode
    End Sub
End Class
