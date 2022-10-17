
Partial Class Reports_ControlsReports_fltEmployeeListReport
    Inherits System.Web.UI.UserControl

    Public Event FilterClick(ByVal AccountLocationId As Integer, ByVal AccountDepartmentId As Integer, ByVal AccountRoleId As Integer)


    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent FilterClick(Me.ddlLocation.SelectedValue, Me.ddlDepartment.SelectedValue, Me.ddlRole.SelectedValue)
    End Sub
    
End Class
