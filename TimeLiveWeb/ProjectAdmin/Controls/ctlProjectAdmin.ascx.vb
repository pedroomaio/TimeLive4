
Partial Class ProjectAdmin_Controls_ctlProjectAdmin
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'HyperLinkProjectMilestone.NavigateUrl = "~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects"
        'TextHyperlinkProjectMilestone.NavigateUrl = "~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects"

        Me.CtlAccountProjectForm1.EditRecord(Me.Request.QueryString("AccountProjectId"))

    End Sub
End Class
