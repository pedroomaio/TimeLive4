
CREATE VIEW dbo.vueAccountReport
AS
SELECT     dbo.AccountReportCategory.AccountReportCategory, dbo.AccountReport.AccountReportId, dbo.AccountReport.AccountReportCategoryId, 
                      dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, dbo.AccountReport.ReportIconPath, dbo.AccountReport.AccountId, 
                      dbo.AccountReport.SystemReportTypeId, dbo.AccountReport.SystemReportId, dbo.AccountReport.IsConsolidated, dbo.AccountReport.ReportPageName, 
                      dbo.AccountReport.ReportOrder, dbo.AccountReportCategory.SequenceNo, CAST(dbo.AccountReportCategory.SequenceNo AS nvarchar(4000)) 
                      + ' - ' + dbo.AccountReportCategory.AccountReportCategory AS AccountReportCategorySequence,
                      dbo.AccountReportCategory.SystemFeatureId AS SystemFeatureCategoryId, dbo.SystemReportDataSource.SystemFeatureId
FROM         dbo.SystemReportDataSource INNER JOIN
                      dbo.AccountReportDataSourceMapping ON 
                      dbo.SystemReportDataSource.SystemReportDataSourceId = dbo.AccountReportDataSourceMapping.SystemReportDataSourceId RIGHT OUTER JOIN
                      dbo.AccountReport ON dbo.AccountReportDataSourceMapping.AccountReportId = dbo.AccountReport.AccountReportId RIGHT OUTER JOIN
                      dbo.AccountReportCategory ON dbo.AccountReport.AccountReportCategoryId = dbo.AccountReportCategory.AccountReportCategoryId