
Partial Class Employee_Controls_ctlAccountEMailNotificationPreferenceList
    Inherits System.Web.UI.UserControl

    Protected Sub btnUpdateEMailNotificationPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL

        For Each row In Me.GridView1.Rows

            If CType(row.FindControl("chkEnableDisable"), CheckBox).Checked = True Then
                objAccountEMailNotificationPreference.UpdateAccountEMailNotificationPreference(Nothing, Nothing, Me.Request.QueryString("AccountEmployeeId"), Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), True, Me.GridView1.DataKeys(row.RowIndex)(0))
            ElseIf CType(row.FindControl("chkEnableDisable"), CheckBox).Checked = False Then
                objAccountEMailNotificationPreference.UpdateAccountEMailNotificationPreference(Nothing, Nothing, Me.Request.QueryString("AccountEmployeeId"), Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), False, Me.GridView1.DataKeys(row.RowIndex)(0))
            End If

        Next

        Response.Redirect("~/AccountAdmin/AccountEmployees.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL
        objAccountEMailNotificationPreference.InsertDefaultAccountEmployeeEMailNotificationPreference(Me.Request.QueryString("AccountEmployeeId"))
        Me.btnUpdateEMailNotificationPreferences.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(100, 3)
    End Sub
End Class
