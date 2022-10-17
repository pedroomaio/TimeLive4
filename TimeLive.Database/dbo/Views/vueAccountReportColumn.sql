
CREATE VIEW dbo.vueAccountReportColumn
AS
SELECT     dbo.AccountReportColumn.AccountReportColumnId, dbo.AccountReportColumn.AccountReportId, dbo.AccountReportColumn.Caption, 
                      dbo.AccountReportColumn.SystemReportDataSourceFieldId, dbo.AccountReportColumn.ColumnOrder, 
                      dbo.AccountReportColumn.SystemReportCalculationTypeId, dbo.AccountReport.AccountReportCategoryId, dbo.AccountReport.ReportName, 
                      dbo.AccountReport.ReportDescription, dbo.AccountReport.ReportIconPath, dbo.AccountReport.AccountId, 
                      dbo.SystemReportFieldType.SystemReportFieldType, dbo.SystemReportDataSource.ReportDataSourceName, 
                      dbo.SystemReportDataSource.ReportDatasource, dbo.SystemReportDataSource.ReportDataSourceType, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceField, dbo.SystemReportDataSourceField.SystemReportDataSourceFieldWidth, 
                      dbo.SystemReportDataSourceField.DefaultAvailable, dbo.SystemReportDataSourceField.CurrencyField, dbo.SystemReportDataSourceField.Formula, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldColumnOrder, dbo.SystemReportDataSourceField.SystemReportFieldTypeId, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldCaption, dbo.SystemReportDataSourceField.SystemReportDataSourceId, 
                      dbo.AccountReportColumn.ColumnFormula
FROM         dbo.AccountReportColumn INNER JOIN
                      dbo.AccountReport ON dbo.AccountReportColumn.AccountReportId = dbo.AccountReport.AccountReportId INNER JOIN
                      dbo.SystemReportDataSourceField ON 
                      dbo.AccountReportColumn.SystemReportDataSourceFieldId = dbo.SystemReportDataSourceField.SystemReportDataSourceFieldId INNER JOIN
                      dbo.SystemReportDataSource ON 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceId = dbo.SystemReportDataSource.SystemReportDataSourceId INNER JOIN
                      dbo.SystemReportFieldType ON dbo.SystemReportDataSourceField.SystemReportFieldTypeId = dbo.SystemReportFieldType.SystemReportFieldTypeId