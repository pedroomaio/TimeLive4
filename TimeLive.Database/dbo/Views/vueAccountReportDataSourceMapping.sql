
CREATE VIEW dbo.vueAccountReportDataSourceMapping
AS
SELECT     dbo.AccountReportDataSourceMapping.*, dbo.SystemReportDataSource.ReportDataSourceName, dbo.SystemReportDataSource.ReportDatasource, 
                      dbo.SystemReportDataSource.ReportDataSourceType
FROM         dbo.AccountReportDataSourceMapping INNER JOIN
                      dbo.SystemReportDataSource ON 
                      dbo.AccountReportDataSourceMapping.SystemReportDataSourceId = dbo.SystemReportDataSource.SystemReportDataSourceId