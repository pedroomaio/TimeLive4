
Partial Class Employee_MyProjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CtlMyProjects1_btnShowClick(sender As Object, e As System.EventArgs) Handles CtlMyProjects1.btnShowClick
        Master.SetFilterFromMasterPage()
    End Sub
End Class
