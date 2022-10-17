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
Imports System.Web.UI.DataVisualization.Charting.Utilities
Partial Class Employee_Controls_ctlMyProjectsGraph
    Inherits System.Web.UI.UserControl
    Dim LabelsPlacement As String
    Dim LabelStyle As String
    Dim StandardPalette As String
    Dim CustomPalette As String
    Dim AccountChartId As Guid
    Dim SystemChartId As New Guid("994d6fd5-4366-4e03-bf9f-e61202e8f150")
    Dim ChartTypeId As Guid
    Dim CollectedLabel As String
    Dim IsCollectPieSlices As Boolean
    Dim CollectedThreshold As Integer
    Dim CollectedColor As String
    Dim CollectedLegendText As String
    Dim IsShowExploded As Boolean
    Dim ChartName As String
    Dim ChartTypeName As String = "SeriesChartType"
    Dim IsShowLegend As Boolean
    Dim IsShowas3D As Boolean
    Dim DoughnutRadius As Integer
    Dim DrawingStyle As String
    Dim PointWidth As Double
    Dim RotationAngle As Integer
    Dim PointsGap As Integer
    Dim MinPointHeight As Integer
    Dim IsHideSupplementalChart As Boolean
    Dim CollectedPercentage As Integer
    Dim SupplementalChartSize As String
    Dim IsCollectSmallSegments As Boolean
    Dim ChartBLL As New AccountEmployeeChartBLL
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = ResourceHelper.GetFromResource("Click on chart for more information")
        Dim dt As AccountEmployeeChart.vueAccountProjectsForMyProjectsDataTable = ChartBLL.GetvueMyProjectsByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        If dt.Rows.Count = 0 Then
            Chart1.Visible = False
            lblerror.Visible = True
            LabelGC.Visible = False
            Label1.Visible = False
        Else
            lblerror.Visible = False
            Chart1.Series(0).LegendText = "#VALX (#VALY)"
            Chart1.Series(0).Label = "#VALY"
            ImgBtn_Edit.Visible = True
            Label1.Visible = False
        End If
        If Me.Request.QueryString("IsDetail") <> 1 Then
            hypBack.Visible = False
            Chart1.Width = "500"
            Chart1.Height = "300"
            ImgBtn_Edit.Visible = True
            ChartDashBoardView()
        Else
            hypBack.Visible = True
            Chart1.Width = "700"
            Chart1.Height = "450"
            ImgBtn_Edit.Visible = True
            ChartDetailView()
        End If
    End Sub
    Public Sub ChartDashBoardView()
        Dim series1 As Series = Chart1.Series(0)
        'Dim BLL As New AccountProjectTaskBLL
        Dim dtChart As AccountEmployeeChart.VueAccountEmployeeChartDataTable = ChartBLL.GetvueAccountEmployeeChartsBySystemChartId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemChartId)
        Dim drChart As AccountEmployeeChart.VueAccountEmployeeChartRow
        If dtChart.Rows.Count > 0 Then
            drChart = dtChart.Rows(0)
            'If Not Me.IsPostBack Then
            ChartTypeId = drChart.SystemChartTypeId
            CollectedLabel = drChart.CollectedLabel
            IsCollectPieSlices = drChart.IsCollectPieSlices
            CollectedThreshold = drChart.CollectedThreshold
            CollectedColor = drChart.CollectedColor
            CollectedLegendText = drChart.CollectedLegendText
            IsShowExploded = drChart.IsShowExploded
            ChartName = drChart.AccountChartName
            ChartTypeName = drChart.SystemChartTypeName
            AccountChartId = drChart.AccountChartId
            IsShowLegend = drChart.IsShowLegend
            IsShowas3D = drChart.IsShowas3D
            DoughnutRadius = drChart.DoughnutRadius
            DrawingStyle = drChart.DrawingStyle
            LabelStyle = drChart.LabelStyle
            PointWidth = drChart.PointWidth
            RotationAngle = drChart.RotationAngle
            PointsGap = drChart.PointsGap
            LabelsPlacement = drChart.LabelsPlacement
            MinPointHeight = drChart.MinPointHeight
            StandardPalette = drChart.StandardPalette
            CustomPalette = drChart.CustomPalette
            IsHideSupplementalChart = drChart.IsHideSupplementalChart
            CollectedPercentage = drChart.CollectedPercentage
            SupplementalChartSize = drChart.SupplementalChartSize
            IsCollectSmallSegments = drChart.IsCollectSmallSegments
            lbl2.Text = ChartName
            'End If
        End If

        'Column
        If ChartTypeName = "Column" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Column
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Bar
        ElseIf ChartTypeName = "Bar" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bar
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Area
        ElseIf ChartTypeName = "Area" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Area
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Pie
        ElseIf ChartTypeName = "Pie" Then
            If IsShowLegend = True Then
                Chart1.Series("Default")("PieLabelStyle") = "Disabled"
                Me.Chart1.Legends(0).Enabled = True
            Else
                Chart1.Series("Default")("PieLabelStyle") = "Inside"
                Me.Chart1.Legends(0).Enabled = False
            End If
            Chart1.Series("Default").ChartType = SeriesChartType.Pie
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Chart1.Series(0)("PieDrawingStyle") = drChart.DrawingStyle.ToString
            series1("CollectedThreshold") = drChart.CollectedThreshold.ToString
            series1("CollectedLabel") = drChart.CollectedLabel.ToString
            series1("CollectedLegendText") = drChart.CollectedLegendText.ToString
            series1("CollectedSliceExploded") = drChart.IsShowExploded.ToString
            series1("CollectedColor") = drChart.CollectedColor.ToString
            Me.LabelGC.Visible = False
        End If
    End Sub
    Public Sub ChartDetailView()
        Dim series1 As Series = Chart1.Series(0)
        'Dim BLL As New AccountProjectTaskBLL
        Dim ChartBLL As New AccountEmployeeChartBLL
        Dim dtChart As AccountEmployeeChart.VueAccountEmployeeChartDataTable = ChartBLL.GetvueAccountEmployeeChartsBySystemChartId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemChartId)
        Dim drChart As AccountEmployeeChart.VueAccountEmployeeChartRow
        If dtChart.Rows.Count > 0 Then
            drChart = dtChart.Rows(0)
            'If Not Me.IsPostBack Then
            ChartTypeId = drChart.SystemChartTypeId
            CollectedLabel = drChart.CollectedLabel
            IsCollectPieSlices = drChart.IsCollectPieSlices
            CollectedThreshold = drChart.CollectedThreshold
            CollectedColor = drChart.CollectedColor
            CollectedLegendText = drChart.CollectedLegendText
            IsShowExploded = drChart.IsShowExploded
            ChartName = drChart.AccountChartName
            ChartTypeName = drChart.SystemChartTypeName
            AccountChartId = drChart.AccountChartId
            IsShowLegend = drChart.IsShowLegend
            IsShowas3D = drChart.IsShowas3D
            DoughnutRadius = drChart.DoughnutRadius
            DrawingStyle = drChart.DrawingStyle
            LabelStyle = drChart.LabelStyle
            PointWidth = drChart.PointWidth
            RotationAngle = drChart.RotationAngle
            PointsGap = drChart.PointsGap
            LabelsPlacement = drChart.LabelsPlacement
            MinPointHeight = drChart.MinPointHeight
            StandardPalette = drChart.StandardPalette
            CustomPalette = drChart.CustomPalette
            IsHideSupplementalChart = drChart.IsHideSupplementalChart
            CollectedPercentage = drChart.CollectedPercentage
            SupplementalChartSize = drChart.SupplementalChartSize
            IsCollectSmallSegments = drChart.IsCollectSmallSegments
            lbl2.Text = ChartName
            'End If
        End If
        series1("CollectedThreshold") = "0"
        CollectedColor = False
        CollectedThreshold = False
        CollectedLabel = False
        CollectedLegendText = False
        IsShowExploded = False
        'Kagi
        If ChartTypeName = "Kagi" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Kagi
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Column
        ElseIf ChartTypeName = "Column" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Column
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Bar
        ElseIf ChartTypeName = "Bar" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bar
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Area
        ElseIf ChartTypeName = "Area" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Area
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Bubble
        ElseIf ChartTypeName = "Bubble" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Bubble
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Me.Chart1.Legends(0).Enabled = False
            Me.LabelGC.Visible = False
            'Pie
        ElseIf ChartTypeName = "Pie" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Pie
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Chart1.Series(0)("PieDrawingStyle") = drChart.DrawingStyle.ToString
            If IsShowLegend = True Then
                Me.Chart1.Legends(0).Enabled = True
            Else
                Me.Chart1.Legends(0).Enabled = False
            End If
            Me.LabelGC.Visible = False
            'Doughnut
        ElseIf ChartTypeName = "Doughnut" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Doughnut
            If IsShowLegend = True Then
                Chart1.Series("Default")("PieLabelStyle") = "Disabled"
            Else
                Chart1.Series("Default")("PieLabelStyle") = "Inside"
            End If
            ' Set labels style
            Chart1.Series("Default")("PieLabelStyle") = drChart.LabelStyle.ToString

            ' Set Doughnut hole size
            Chart1.Series("Default")("DoughnutRadius") = drChart.DoughnutRadius.ToString

            ' Enable 3D
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString = True
            Chart1.Series(0)("PieDrawingStyle") = drChart.DrawingStyle.ToString
            If IsShowLegend = True Then
                Me.Chart1.Legends(0).Enabled = True
            Else
                Me.Chart1.Legends(0).Enabled = False
            End If
            Me.LabelGC.Visible = False
            'Funnel
        ElseIf ChartTypeName = "Funnel" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Funnel
            ' Set funnel data point labels style
            Chart1.Series("Default")("FunnelLabelStyle") = drChart.LabelStyle.ToString
            ' Set gap between points
            Chart1.Series("Default")("FunnelPointGap") = drChart.PointsGap.ToString
            ' Set minimum point height
            Chart1.Series("Default")("FunnelMinPointHeight") = drChart.MinPointHeight.ToString
            ' Set 3D mode
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString
            ' Set 3D angle
            Chart1.Series("Default")("Funnel3DRotationAngle") = drChart.RotationAngle.ToString
            ' Set 3D drawing style
            Chart1.Series("Default")("Funnel3DDrawingStyle") = drChart.DrawingStyle.ToString
            Chart1.Width = "550"

            If LabelStyle = "OutSideInColumn" OrElse LabelStyle = "Outside" Then
                Chart1.Series("Default")("FunnelOutsideLabelPlacement") = drChart.LabelsPlacement.ToString
            Else
                Chart1.Series("Default")("FunnelInsideLabelAlignment") = drChart.LabelsPlacement.ToString
            End If
            If IsShowLegend = True Then
                Me.Chart1.Legends(0).Enabled = True
            Else
                Me.Chart1.Legends(0).Enabled = False
            End If
            Me.LabelGC.Visible = False
            'Pyramid
        ElseIf ChartTypeName = "Pyramid" Then
            Chart1.Series("Default").ChartType = SeriesChartType.Pyramid
            ' Set funnel data point labels style
            Chart1.Series("Default")("PyramidLabelStyle") = drChart.LabelStyle.ToString
            ' Set gap between points
            Chart1.Series("Default")("PyramidPointGap") = drChart.PointsGap.ToString
            ' Set minimum point height
            Chart1.Series("Default")("PyramidMinPointHeight") = drChart.MinPointHeight.ToString
            ' Set 3D mode
            Chart1.ChartAreas("Area1").Area3DStyle.Enable3D = drChart.IsShowas3D.ToString
            ' Set 3D angle
            Chart1.Series("Default")("Pyramid3DRotationAngle") = drChart.RotationAngle.ToString
            ' Set 3D drawing style
            Chart1.Series("Default")("Pyramid3DDrawingStyle") = drChart.DrawingStyle.ToString
            If LabelStyle = "OutSideInColumn" OrElse LabelStyle = "Outside" Then
                Chart1.Series("Default")("PyramidOutsideLabelPlacement") = drChart.LabelsPlacement.ToString
            Else
                Chart1.Series("Default")("PyramidInsideLabelAlignment") = drChart.LabelsPlacement.ToString
            End If
            If IsShowLegend = True Then
                Me.Chart1.Legends(0).Enabled = True
            Else
                Me.Chart1.Legends(0).Enabled = False
            End If
            Me.LabelGC.Visible = False
        End If
    End Sub
    Public Sub CustomizePalette()
        If StandardPalette = "None" Then
            Chart1.Palette = ChartColorPalette.None
        ElseIf StandardPalette = "Bright" Then
            Chart1.Palette = ChartColorPalette.Bright
        ElseIf StandardPalette = "Grayscale" Then
            Chart1.Palette = ChartColorPalette.Grayscale
        ElseIf StandardPalette = "Excel" Then
            Chart1.Palette = ChartColorPalette.Excel
        ElseIf StandardPalette = "Light" Then
            Chart1.Palette = ChartColorPalette.Light
        ElseIf StandardPalette = "Pastel" Then
            Chart1.Palette = ChartColorPalette.Pastel
        ElseIf StandardPalette = "EarthTones" Then
            Chart1.Palette = ChartColorPalette.EarthTones
        ElseIf StandardPalette = "SemiTransparent" Then
            Chart1.Palette = ChartColorPalette.SemiTransparent
        ElseIf StandardPalette = "Berry" Then
            Chart1.Palette = ChartColorPalette.Berry
        ElseIf StandardPalette = "Chocolate" Then
            Chart1.Palette = ChartColorPalette.Chocolate
        ElseIf StandardPalette = "Fire" Then
            Chart1.Palette = ChartColorPalette.Fire
        ElseIf StandardPalette = "SeaGreen" Then
            Chart1.Palette = ChartColorPalette.SeaGreen
        ElseIf StandardPalette = "BrightPastel" Then
            Chart1.Palette = ChartColorPalette.BrightPastel
        ElseIf StandardPalette = "Custom" Then
            Chart1.Palette = ChartColorPalette.None
            UpdateCustomPalette()
        Else
            Chart1.PaletteCustomColors = New Color(-1) {}
            Me.Chart1.Palette = StandardPalette
        End If
        Chart1.Series("Default").Palette = ChartColorPalette.BrightPastel
    End Sub
    Private Sub UpdateCustomPalette()
        Dim colorSet As Color()
        If CustomPalette.ToString() = "CorporateGold" Then
            colorSet = New Color(3) {Color.FromArgb(224, 131, 10), Color.FromArgb(255, 227, 130), Color.FromArgb(251, 197, 65), Color.FromArgb(251, 180, 65)}
            Chart1.PaletteCustomColors = colorSet

        ElseIf CustomPalette.ToString() = "CorporateBlue" Then
            colorSet = New Color(3) {Color.FromArgb(5, 100, 146), Color.FromArgb(144, 218, 255), Color.FromArgb(149, 193, 254), Color.FromArgb(65, 140, 240)}
            Chart1.PaletteCustomColors = colorSet
        Else

            colorSet = New Color(3) {Color.FromArgb(120, 147, 190), Color.FromArgb(241, 185, 168), Color.FromArgb(128, 184, 209), Color.FromArgb(243, 210, 136)}
            Chart1.PaletteCustomColors = colorSet
        End If
    End Sub
    Protected Sub Chart1_Click(ByVal sender As Object, ByVal e As ImageMapEventArgs)
        Dim pointIndex As Integer = Integer.Parse(e.PostBackValue)
        Dim series As Series = Chart1.Series("My series")
        If pointIndex >= 0 AndAlso pointIndex < series.Points.Count Then
            series.Points(pointIndex).CustomProperties += "Exploded=true"
        End If
    End Sub
    Protected Sub ImgBtn_Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtn_Edit.Click
        Dim SystemChartId As New Guid("994d6fd5-4366-4e03-bf9f-e61202e8f150")
        Response.Redirect("~/Employee/ChartCustomization.aspx?SystemChartId=" & SystemChartId.ToString, False)
    End Sub
End Class
