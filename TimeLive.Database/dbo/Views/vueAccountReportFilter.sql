
CREATE VIEW dbo.vueAccountReportFilter
AS
SELECT     dbo.SystemReportDataSource.ReportDataSourceName, dbo.SystemReportDataSource.ReportDatasource, 
                      dbo.SystemReportDataSource.ReportDataSourceType, dbo.SystemReportDataSource.SystemReportDataSourceId, dbo.AccountReport.AccountReportId, 
                      dbo.AccountReport.AccountReportCategoryId, dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, 
                      dbo.AccountReport.ReportIconPath, dbo.AccountReport.AccountId, dbo.AccountReportDataSourceMapping.AccountReportDataSourceMappingId, 
                      dbo.SystemReportFilterSourceMapping.IsRequired, dbo.SystemReportFilterSourceMapping.IsAllowAll, 
                      dbo.SystemReportFilterSourceMapping.SystemReportFilterMappingId, dbo.SystemReportFilterSource.SystemReportFilterSource, 
                      dbo.SystemReportFilterSource.SystemReportFilterSourceId, dbo.SystemReportFilterSource.ClassName, dbo.SystemReportFilterSource.ClassFunction, 
                      dbo.SystemReportFilterSource.ParameterName1, dbo.SystemReportFilterSource.Caption, dbo.SystemReportFilterSource.FilterSourceType, 
                      dbo.SystemReportFilterSource.FilterSource, dbo.SystemReportFilterSource.FilterOperator, dbo.SystemReportFilterSource.IsOptional, 
                      dbo.SystemReportFilterSource.FilterField, dbo.SystemReportFilterSource.ParentFilterSource, 
                      dbo.SystemReportFilterSourceMapping.FilterSequence
FROM         dbo.AccountReportDataSourceMapping INNER JOIN
                      dbo.AccountReport ON dbo.AccountReportDataSourceMapping.AccountReportId = dbo.AccountReport.AccountReportId INNER JOIN
                      dbo.SystemReportDataSource ON 
                      dbo.AccountReportDataSourceMapping.SystemReportDataSourceId = dbo.SystemReportDataSource.SystemReportDataSourceId INNER JOIN
                      dbo.SystemReportFilterSourceMapping ON 
                      dbo.SystemReportDataSource.SystemReportDataSourceId = dbo.SystemReportFilterSourceMapping.SystemReportDataSourceId INNER JOIN
                      dbo.SystemReportFilterSource ON 
                      dbo.SystemReportFilterSourceMapping.SystemReportFilterSourceId = dbo.SystemReportFilterSource.SystemReportFilterSourceId