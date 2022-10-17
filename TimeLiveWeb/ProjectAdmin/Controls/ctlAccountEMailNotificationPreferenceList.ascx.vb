
Partial Class ProjectAdmin_Controls_ctlAccountEMailNotificationPreferenceList
    Inherits System.Web.UI.UserControl

    Protected Sub btnUpdateEMailNotificationPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL

        For Each row In Me.GridView1.Rows

            If CType(row.FindControl("chkEnableDisable"), CheckBox).Checked = True Then
                objAccountEMailNotificationPreference.UpdateAccountEMailNotificationPreference(Nothing, Request.QueryString("AccountProjectId"), Nothing, Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), True, Me.GridView1.DataKeys(row.RowIndex)(0))
            ElseIf CType(row.FindControl("chkEnableDisable"), CheckBox).Checked = False Then
                objAccountEMailNotificationPreference.UpdateAccountEMailNotificationPreference(Nothing, Request.QueryString("AccountProjectId"), Nothing, Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), False, Me.GridView1.DataKeys(row.RowIndex)(0))
            End If

        Next
        If Me.Request.QueryString("IsTemplate") = "True" Then
            Response.Redirect("~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True", False)
        Else
            If Me.Request.QueryString("Source") = "MyProjects" Then
                Response.Redirect("~/Employee/MyProjects.aspx", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjects.aspx", False)
            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL
        objAccountEMailNotificationPreference.InsertDefaultAccountProjectEMailNotificationPreference(Me.Request.QueryString("AccountProjectId"))
        Me.btnUpdateEMailNotificationPreferences.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(99, 3)
        ' The ExpandForumPaths method is called to handle
        ' the SiteMapResolve event.
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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
End Class
