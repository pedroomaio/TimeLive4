
Partial Class AccountAdmin_Controls_ctlAccountEMailNotificationPreferenceList
    Inherits System.Web.UI.UserControl

    Protected Sub btnUpdateEMailNotificationPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL

        For Each row In Me.GridView1.Rows

            objAccountEMailNotificationPreference.UpdateAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId, _
            Nothing, Nothing, Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), _
            CType(row.FindControl("chkEnableDisable"), CheckBox).Checked, Me.GridView1.DataKeys(row.RowIndex)(0), _
            CType(row.FindControl("chkMonday"), CheckBox).Checked, CType(row.FindControl("chkTuesday"), CheckBox).Checked, _
            CType(row.FindControl("chkWednesday"), CheckBox).Checked, CType(row.FindControl("chkThursday"), CheckBox).Checked, _
            CType(row.FindControl("chkFriday"), CheckBox).Checked, CType(row.FindControl("chkSaturday"), CheckBox).Checked, _
            CType(row.FindControl("chkSunday"), CheckBox).Checked)
        Next
        UIUtilities.RedirectToAdminHomePage()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objAccountEMailNotificationPreference As New AccountEMailNotificationPreferenceBLL
        objAccountEMailNotificationPreference.InsertDefaultAccountEMailNotificationPreference(DBUtilities.GetSessionAccountId)
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndButton(98, Me.GridView1, btnUpdateEMailNotificationPreferences)
        'Me.btnUpdateEMailNotificationPreferences.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(98, 3)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            HideWeekDaysCheckBox(e.Row)
        End If
    End Sub
    Public Sub HideWeekDaysCheckBox(ByVal row As GridViewRow)
        If IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("IsWeekDayAllow")) Then
            CType(row.FindControl("chkMonday"), CheckBox).Visible = False
            CType(row.FindControl("chkTuesday"), CheckBox).Visible = False
            CType(row.FindControl("chkWednesday"), CheckBox).Visible = False
            CType(row.FindControl("chkThursday"), CheckBox).Visible = False
            CType(row.FindControl("chkFriday"), CheckBox).Visible = False
            CType(row.FindControl("chkSaturday"), CheckBox).Visible = False
            CType(row.FindControl("chkSunday"), CheckBox).Visible = False
        End If
    End Sub
End Class
