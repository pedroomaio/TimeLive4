Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.DataVisualization.Charting
Partial Class Employee_Controls_ctlChartCustomization
    Inherits System.Web.UI.UserControl
    Dim AccountChartId As Guid
    Dim ChartBLL As New AccountEmployeeChartBLL
    Protected text_Legend As System.Web.UI.WebControls.TextBox
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim SystemChartId As New Guid(Me.Request.QueryString("SystemChartId"))
        Dim ChartTypeId As Guid
        Dim dtChart As AccountEmployeeChart.AccountEmployeeChartsDataTable = ChartBLL.GetAccountEmployeeChartsBySystemChartId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemChartId)
        Dim drChart As AccountEmployeeChart.AccountEmployeeChartsRow
        If dtChart.Rows.Count > 0 Then
            drChart = dtChart.Rows(0)
            If Not Me.IsPostBack Then
                ChartTypeId = drChart.SystemChartTypeId
                txtChartName.Text = drChart.AccountChartName
                chkShowExplode.Checked = drChart.IsShowExploded
                AccountChartId = drChart.AccountChartId
                ddlCollectedThreshold.SelectedValue = drChart.CollectedThreshold
                chkShowLegend.Checked = drChart.IsShowLegend
                chkShow3D.Checked = drChart.IsShowas3D
                ddlChartType.SelectedValue = ChartTypeId.ToString
                ddlChartType.DataBind()
                Dim SystemChartType As String = ChartTypeId.ToString
                If SystemChartType = "160d96e5-5526-465b-a380-0a875ce44181" Or SystemChartType = "d4f7b1c3-00cb-4f98-a6c0-55b8db2bfe54" Or SystemChartType = "98f6e6ad-a121-4ec3-a757-d95fdb028d1b" Then
                    chkShowExplode.Enabled = False
                    chkShowLegend.Enabled = False
                    ddlCollectedThreshold.Enabled = False
                Else
                    chkShowExplode.Enabled = True
                    chkShowLegend.Enabled = True
                    ddlCollectedThreshold.Enabled = True
                End If
            Else
                AccountChartId = drChart.AccountChartId
            End If
        End If
        'If ddlChartType.SelectedIndex = 1 OrElse ddlChartType.SelectedIndex = 2 Then

        'ElseIf ddlChartType.SelectedIndex = 4 OrElse ddlChartType.SelectedIndex = 5 Then


        'ElseIf ddlChartType.SelectedIndex = 3 OrElse ddlChartType.SelectedIndex = 7 Then


        'ElseIf ddlChartType.SelectedIndex = 8 OrElse ddlChartType.SelectedIndex = 0 OrElse ddlChartType.SelectedIndex = 6 Then
        'End If
    End Sub
    Protected Sub SaveCustomized_Click(sender As Object, e As System.EventArgs) Handles SaveCustomized.Click

        Dim SystemChartId As New Guid(Me.Request.QueryString("SystemChartId"))
        Dim SystemChartTypeId As New Guid(ddlChartType.SelectedValue)
        ChartBLL.UpdateAccountEmployeeChartsForSelectedField(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemChartTypeId, AccountChartId,
                                             SystemChartId, txtChartName.Text, chkShowExplode.Checked, chkShowLegend.Checked, chkShow3D.Checked, ddlCollectedThreshold.SelectedValue)
        Response.Redirect("~/Employee/Default.aspx", False)

    End Sub
    Protected Sub Cancel_Click(sender As Object, e As System.EventArgs) Handles Cancel.Click
        Response.Redirect("~/Employee/Default.aspx", False)
    End Sub

    Protected Sub ddlChartType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlChartType.SelectedIndexChanged
        If ddlChartType.SelectedValue = "160d96e5-5526-465b-a380-0a875ce44181" Or ddlChartType.SelectedValue = "d4f7b1c3-00cb-4f98-a6c0-55b8db2bfe54" Or ddlChartType.SelectedValue = "98f6e6ad-a121-4ec3-a757-d95fdb028d1b" Then
            chkShowExplode.Enabled = False
            chkShowLegend.Enabled = False
            ddlCollectedThreshold.Enabled = False
        ElseIf ddlChartType.SelectedValue = "0d8703f3-7e4f-4590-b674-629e31a557f8" Then
            chkShowExplode.Enabled = True
            chkShowLegend.Enabled = True
            ddlCollectedThreshold.Enabled = True
        End If
    End Sub
End Class
'Label.Text = DateAndTime.Now
'<asp:Label ID="Label" runat="server" Text=""></asp:Label>--%>