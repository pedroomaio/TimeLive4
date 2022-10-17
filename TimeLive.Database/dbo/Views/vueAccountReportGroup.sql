
CREATE VIEW dbo.vueAccountReportGroup
AS
SELECT     dbo.AccountReportGroup.AccountReportGroupId, dbo.AccountReportGroup.AccountReportId, dbo.AccountReportGroup.ReportGroup, 
                      dbo.AccountReportGroup.ReportGroupFieldLabel, dbo.AccountReportGroup.ReportGroupFieldOrder, 
                      dbo.AccountReportGroup.SystemReportDataSourceFieldId, dbo.SystemReportDataSourceField.SystemReportDataSourceId, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceField, dbo.SystemReportDataSourceField.SystemReportDataSourceFieldWidth, 
                      dbo.SystemReportDataSourceField.DefaultAvailable, dbo.SystemReportDataSourceField.CurrencyField, dbo.SystemReportDataSourceField.Formula, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldColumnOrder, dbo.SystemReportDataSourceField.SystemReportFieldTypeId, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldCaption, dbo.SystemReportDataSource.ReportDataSourceName, 
                      dbo.SystemReportDataSource.ReportDatasource, dbo.SystemReportDataSource.ReportDataSourceType, 
                      dbo.SystemReportFieldType.SystemReportFieldType, dbo.AccountReport.AccountReportCategoryId, dbo.AccountReport.ReportName, 
                      dbo.AccountReport.ReportDescription, dbo.AccountReport.ReportIconPath, dbo.AccountReport.AccountId
FROM         dbo.AccountReportGroup INNER JOIN
                      dbo.SystemReportDataSourceField ON 
                      dbo.AccountReportGroup.SystemReportDataSourceFieldId = dbo.SystemReportDataSourceField.SystemReportDataSourceFieldId INNER JOIN
                      dbo.SystemReportDataSource ON 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceId = dbo.SystemReportDataSource.SystemReportDataSourceId INNER JOIN
                      dbo.SystemReportFieldType ON 
                      dbo.SystemReportDataSourceField.SystemReportFieldTypeId = dbo.SystemReportFieldType.SystemReportFieldTypeId INNER JOIN
                      dbo.AccountReport ON dbo.AccountReportGroup.AccountReportId = dbo.AccountReport.AccountReportId