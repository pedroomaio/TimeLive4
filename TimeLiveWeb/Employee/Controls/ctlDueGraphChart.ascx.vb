Imports System.Web.UI.DataVisualization.Charting
Partial Class Employee_ctlDueGraphChart
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

      
        If DropDownList1.SelectedValue = "Column" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Column
            Me.Chart1.Legends(0).Enabled = False
            Me.Label1.Visible = True
        ElseIf DropDownList1.SelectedValue = "Pie" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Pie
            Me.Chart1.Legends(0).Enabled = True
            Me.Label1.Visible = False
        ElseIf DropDownList1.SelectedValue = "Bubble" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bubble
            Me.Chart1.Legends(0).Enabled = False
            Me.Label1.Visible = True
        ElseIf DropDownList1.SelectedValue = "Doughnut" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Doughnut
            Me.Chart1.Legends(0).Enabled = True
            Me.Label1.Visible = False
        ElseIf DropDownList1.SelectedValue = "Area" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Area
            Me.Chart1.Legends(0).Enabled = False
            Me.Label1.Visible = True
        ElseIf DropDownList1.SelectedValue = "Bar" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bar
            Me.Chart1.Legends(0).Enabled = False
            Me.Label1.Visible = True
        End If

      
        Me.Chart1.Series(0)("PieLabelStyle") = "inside"
        Me.Chart1.Series(0).LegendText = "#VALX (#VALY)"
        Me.Chart1.Series(0).Label = "#PERCENT{P1}"
        Me.Chart1.Series(0)("PieLabelStyle") = "Disabled"


    End Sub
End Class
