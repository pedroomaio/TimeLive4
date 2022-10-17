
CREATE VIEW dbo.VueAccountEmployeeChart
AS
SELECT     dbo.SystemChartType.SystemChartTypeName, dbo.SystemCharts.SystemChartName, dbo.AccountEmployeeCharts.AccountChartId, 
                      dbo.AccountEmployeeCharts.AccountId, dbo.AccountEmployeeCharts.AccountEmployeeId, dbo.AccountEmployeeCharts.CreatedOn, 
                      dbo.AccountEmployeeCharts.CreatedByEmployeeId, dbo.AccountEmployeeCharts.ModifiedOn, dbo.AccountEmployeeCharts.ModifiedByEmployeeId, 
                      dbo.AccountEmployeeCharts.SystemChartId, dbo.AccountEmployeeCharts.IsCollectPieSlices, dbo.AccountEmployeeCharts.CollectedThreshold, 
                      dbo.AccountEmployeeCharts.CollectedColor, dbo.AccountEmployeeCharts.CollectedLabel, dbo.AccountEmployeeCharts.CollectedLegendText, 
                      dbo.AccountEmployeeCharts.IsShowExploded, dbo.AccountEmployeeCharts.SystemChartTypeId, dbo.AccountEmployeeCharts.LabelStyle, 
                      dbo.AccountEmployeeCharts.DrawingStyle, dbo.AccountEmployeeCharts.DoughnutRadius, dbo.AccountEmployeeCharts.IsShowLegend, 
                      dbo.AccountEmployeeCharts.AccountChartName, dbo.AccountEmployeeCharts.IsShowas3D, dbo.AccountEmployeeCharts.PointWidth, 
                      dbo.AccountEmployeeCharts.RotationAngle, dbo.AccountEmployeeCharts.PointsGap, dbo.AccountEmployeeCharts.MinPointHeight, 
                      dbo.AccountEmployeeCharts.LabelsPlacement, dbo.AccountEmployeeCharts.StandardPalette, dbo.AccountEmployeeCharts.CustomPalette, 
                      dbo.AccountEmployeeCharts.IsHideSupplementalChart, dbo.AccountEmployeeCharts.CollectedPercentage, dbo.AccountEmployeeCharts.SupplementalChartSize, 
                      dbo.AccountEmployeeCharts.IsCollectSmallSegments
FROM         dbo.AccountEmployeeCharts INNER JOIN
                      dbo.SystemCharts ON dbo.AccountEmployeeCharts.SystemChartId = dbo.SystemCharts.SystemChartId INNER JOIN
                      dbo.SystemChartType ON dbo.AccountEmployeeCharts.SystemChartTypeId = dbo.SystemChartType.SystemChartTypeId