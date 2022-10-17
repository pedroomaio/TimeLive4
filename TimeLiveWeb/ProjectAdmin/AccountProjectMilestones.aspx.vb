
Partial Class AccountAdmin_frmAccountProjectMilestones
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' The ExpandForumPaths method is called to handle
        ' the SiteMapResolve event.
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths

    End Sub
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode

        If System.Web.HttpContext.Current.Request.QueryString("Source") = "MyProjects" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(37, "~/ProjectAdmin/ProjectAdmin.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"))
        ElseIf System.Web.HttpContext.Current.Request.QueryString("Source") = "ProjectTemplates" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(103, "~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True")
        Else
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(31)
        End If

    End Function

    'Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode
    '    ' The current node represents a Post page in a bulletin board forum.
    '    ' Clone the current node and all of its relevant parents. This
    '    ' returns a site map node that a developer can then
    '    ' walk, modifying each node.Url property in turn.
    '    ' Since the cloned nodes are separate from the underlying
    '    ' site navigation structure, the fixups that are made do not
    '    ' effect the overall site navigation structure.

    '    If SiteMap.CurrentNode Is Nothing Then
    '        Return Nothing
    '    End If

    '    Dim currentNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)
    '    Dim tempNode As SiteMapNode = currentNode

    '    ' Obtain the recent IDs.
    '    Dim AccountProjectId As Integer = System.Web.HttpContext.Current.Request.QueryString("AccountProjectId")

    '    ' The current node, and its parents, can be modified to include
    '    ' dynamic querystring information relevant to the currently
    '    ' executing request.
    '    If Not (0 = AccountProjectId) Then
    '        tempNode.Url = tempNode.Url & "?AccountProjectID=" & AccountProjectId.ToString()
    '    End If

    '    tempNode = tempNode.ParentNode
    '    If Not (0 = AccountProjectId) And Not (tempNode Is Nothing) Then
    '        tempNode.Url = tempNode.Url & "?AccountProjectID=" & AccountProjectId.ToString()
    '    End If



    '    Return currentNode

    'End Function


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
End Class
