
Partial Class WebReport_Permission_Controls_ctlAccountReportPermission
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.GridView1.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(125, 1)
        Me.btnUpdate.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(125, 3)
        Me.GetReportIdAndReportName()
    End Sub
    Public Sub GetReportIdAndReportName()
        Dim BLL As New TimeLive.WebReport.ReportDesignBLL
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim dt As dsReportDesign.AccountReportDataTable = BLL.GetAccountReportByAccountReportId(AccountReportId)
        Dim dr As dsReportDesign.AccountReportRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.ReportIdTextBox.Text = Convert.ToString(dr.AccountReportId)
            Me.ReportNameTextBox.Text = ResourceHelper.GetFromResource(dr.ReportName)
        End If
    End Sub
    Public Sub UpdateReportPermission()
        Dim row As GridViewRow
        Dim BLL As New ObjectPermissionBLL
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))

        For Each row In Me.GridView1.Rows

            If IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountObjectPermissionId")) And Me.CheckAllCheckBoxValue(row) Then
                BLL.AddAccountObjectPermission(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item("AccountRoleId"), DBUtilities.GetSessionAccountId, CType(row.FindControl("chkShowReport"), CheckBox).Checked, CType(row.FindControl("chkAllowCustomization"), CheckBox).Checked, CType(row.FindControl("chkAllowUser"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnReport"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnTeam"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnProject"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnSubOridinates"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnApproval"), CheckBox).Checked)
            End If

            If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountObjectPermissionId")) And Me.CheckAllCheckBoxValue(row) Then
                If Me.IsRowChanged(row) Then
                    BLL.UpdateAccountObjectPermission(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item("AccountRoleId"), CType(row.FindControl("chkShowReport"), CheckBox).Checked, CType(row.FindControl("chkAllowCustomization"), CheckBox).Checked, CType(row.FindControl("chkAllowUser"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnReport"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnTeam"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnProject"), CheckBox).Checked, CType(row.FindControl("chkAllowOwnSubOridinates"), CheckBox).Checked, Me.GridView1.DataKeys(row.RowIndex).Item("AccountObjectPermissionId"), CType(row.FindControl("chkAllowOwnApproval"), CheckBox).Checked)
                End If
            End If

            If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountObjectPermissionId")) And Me.CheckAllCheckBoxValue(row) = False Then
                BLL.DeleteAccountObjectPermission(Me.GridView1.DataKeys(row.RowIndex).Item("AccountObjectPermissionId"))
            End If
        Next
        Me.GridView1.DataBind()
    End Sub
    Public Function CheckAllCheckBoxValue(ByVal row As GridViewRow) As Boolean
        If CType(row.FindControl("chkShowReport"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowCustomization"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowUser"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowOwnReport"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowOwnTeam"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowOwnProject"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowOwnSubOridinates"), CheckBox).Checked = True Or CType(row.FindControl("chkAllowOwnApproval"), CheckBox).Checked = True Then
            Return True
        End If
        Return False
    End Function
    Public Function IsRowChanged(ByVal row As GridViewRow) As Boolean
        If Me.GridView1.DataKeys(row.RowIndex).Item("ShowReport") <> CType(row.FindControl("chkShowReport"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowCustomization") <> CType(row.FindControl("chkAllowCustomization"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowAllUser") <> CType(row.FindControl("chkAllowUser"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowOwnReport") <> CType(row.FindControl("chkAllowOwnReport"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowOwnTeam") <> CType(row.FindControl("chkAllowOwnTeam"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowOwnProject") <> CType(row.FindControl("chkAllowOwnProject"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowOwnSubOrdinates") <> CType(row.FindControl("chkAllowOwnSubOridinates"), CheckBox).Checked Then
            Return True
        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item("AllowOwnApproval") <> CType(row.FindControl("chkAllowOwnApproval"), CheckBox).Checked Then
            Return True
        End If
        Return False
    End Function

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        UpdateReportPermission()
        Response.Redirect("~/WebReport/MyReports.aspx", False)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            SetCheckBoxesValue(e)
        End If
    End Sub
    Public Sub SetCheckBoxesValue(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ShowReport")) Then
            CType(e.Row.FindControl("chkShowReport"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "ShowReport")
        Else
            CType(e.Row.FindControl("chkShowReport"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowCustomization")) Then
            CType(e.Row.FindControl("chkAllowCustomization"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowCustomization")
        Else
            CType(e.Row.FindControl("chkAllowCustomization"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowAllUser")) Then
            CType(e.Row.FindControl("chkAllowUser"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowAllUser")
        Else
            CType(e.Row.FindControl("chkAllowUser"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowOwnReport")) Then
            CType(e.Row.FindControl("chkAllowOwnReport"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowOwnReport")
        Else
            CType(e.Row.FindControl("chkAllowOwnReport"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowOwnTeam")) Then
            CType(e.Row.FindControl("chkAllowOwnTeam"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowOwnTeam")
        Else
            CType(e.Row.FindControl("chkAllowOwnTeam"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowOwnProject")) Then
            CType(e.Row.FindControl("chkAllowOwnProject"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowOwnProject")
        Else
            CType(e.Row.FindControl("chkAllowOwnProject"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowOwnSubOrdinates")) Then
            CType(e.Row.FindControl("chkAllowOwnSubOridinates"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowOwnSubOrdinates")
        Else
            CType(e.Row.FindControl("chkAllowOwnSubOridinates"), CheckBox).Checked = False
        End If

        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AllowOwnApproval")) Then
            CType(e.Row.FindControl("chkAllowOwnApproval"), CheckBox).Checked = DataBinder.Eval(e.Row.DataItem, "AllowOwnApproval")
        Else
            CType(e.Row.FindControl("chkAllowOwnApproval"), CheckBox).Checked = False
        End If
    End Sub
End Class
