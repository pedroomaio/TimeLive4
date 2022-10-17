
Partial Class Reports_ControlsFilter_fltProjectListReport
    Inherits System.Web.UI.UserControl

    Public Event FilterClick(ByVal AccountClientId As Integer, ByVal IsActive As Boolean, ByVal ProjectStatusId As Integer)
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent FilterClick(Me.ddlClientName.SelectedValue, Me.ddlActiveStatus.SelectedValue, ddlProjectStatus.SelectedValue)
    End Sub
End Class
