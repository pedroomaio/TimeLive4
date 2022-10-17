Imports System.Web.UI.DataVisualization.Charting
Partial Class Employee_Controls_ctlProjectTaskbyEstimatedCost
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '' ''Dim Status As String
        '' ''Dim TaskName As String
        '' ''Dim Percent As Double
        '' ''Dim BLL As New AccountProjectTaskBLL
        '' ''Dim dt As TimeLiveDataSet.vueAccountProjectTaskDataTable = BLL.GetAssignedOpenAccountProjectTasksByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountId)
        '' ''Dim dr As TimeLiveDataSet.vueAccountProjectTaskRow

        '' ''If dt.Rows.Count > 0 Then
        '' ''    dr = dt.Rows(0)
        '' ''    Status = dr.TaskStatus
        '' ''    TaskName = dr.TaskName
        '' ''    Percent = dr.CompletedPercent

        If DropDownList1.SelectedValue = "Column" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Column
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = True
        ElseIf DropDownList1.SelectedValue = "Pie" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Pie
            Me.Chart1.Legends(0).Enabled = True
            Me.LabelGC.Visible = False
        ElseIf DropDownList1.SelectedValue = "Bubble" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bubble
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = True
        ElseIf DropDownList1.SelectedValue = "Doughnut" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Doughnut
            Me.Chart1.Legends(0).Enabled = True
            Me.LabelGC.Visible = False
        ElseIf DropDownList1.SelectedValue = "Area" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Area
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = True
        ElseIf DropDownList1.SelectedValue = "Bar" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bar
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = True
        End If

        'If DropDownList2.SelectedValue = "CompletePercent" Then
        '    Chart1.Series("DropDownList2").XValueMember = "CompletePercent"
        'ElseIf DropDownList2.SelectedValue = "Pie" Then
        '    Chart1.Series("Default").ChartType = SeriesChartType.Pie
        'ElseIf DropDownList2.SelectedValue = "Bubble" Then
        '    Chart1.Series("Default").ChartType = SeriesChartType.Bubble
        'ElseIf DropDownList2.SelectedValue = "Doughnut" Then
        '    Chart1.Series("Default").ChartType = SeriesChartType.Doughnut
        'End If
        'Chart1.Series(0).IsValueShownAsLabel = True
        'Chart1.Series(0).IsVisibleInLegend = False
        'Chart1.Legends(0).Enabled = True
        Me.Chart1.Series(0)("PieLabelStyle") = "inside"
        Me.Chart1.Series(0).LegendText = "#VALX (#VALY)"
        Me.Chart1.Series(0).Label = "#VALY"
        Me.Chart1.Series(0)("PieLabelStyle") = "Disabled"
        '' ''    Me.Chart1.DataSource = dt
        '' ''    Me.Chart1.Series(0).ChartType = SeriesChartType.Column
        '' ''    Me.Chart1.Series(0)("DrawingStyle") = "Emboss"
        '' ''    Me.Chart1.Series(0).XValueMember = TaskName
        '' ''    Me.Chart1.Series(0).YValueMembers = Percent
        '' ''    Me.Chart1.Series(0).IsValueShownAsLabel = True
        '' ''Me.Chart1.DataBind()
        '' ''End If
        'Chart1.Series("Default")("PieLabelStyle") = "Disabled"
        'Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
        'Chart1.Legends(0).Enabled = True

        'Me.Chart1.Series(0).BorderWidth = 1
        'Me.Chart1.Series(0).BorderColor = System.Drawing.Color.FromArgb(26, 59, 105)
        'For Each dp As DataPoint In Chart1.Series(0).Points
        '    Chart1.Legends(0).CustomItems.Add(dp.Color, dp.AxisLabel) ' Display label & column color in Legend
        'Next

    End Sub
End Class
