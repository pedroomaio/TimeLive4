
Partial Class ProjectAdmin_Controls_ctlProjectView
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtProjectId.Text = CType(New AccountProjectBLL().GetAccountProjectsByAccountProjectId(Me.Request.QueryString("AccountProjectId")).Rows(0), TimeLiveDataSet.AccountProjectRow).AccountProjectId
        Dim AccountProjectBLL As New AccountProjectBLL
        Dim dt As TimeLiveDataSet.AccountProjectDataTable = AccountProjectBLL.GetAccountProjectsByAccountProjectId(Me.Request.QueryString("AccountProjectId"))
        Dim dr As TimeLiveDataSet.AccountProjectRow = dt.Rows(0)
        If Not IsDBNull(dr("ProjectCode")) Then
            txtProjectCode.Text = Convert.ToString(CType(New AccountProjectBLL().GetAccountProjectsByAccountProjectId(Me.Request.QueryString("AccountProjectId")).Rows(0), TimeLiveDataSet.AccountProjectRow).ProjectCode)
        Else
            txtProjectCode.Text = ""
        End If
        txtProjectName.Text = CType(New AccountProjectBLL().GetAccountProjectsByAccountProjectId(Me.Request.QueryString("AccountProjectId")).Rows(0), TimeLiveDataSet.AccountProjectRow).ProjectName
    End Sub
End Class
