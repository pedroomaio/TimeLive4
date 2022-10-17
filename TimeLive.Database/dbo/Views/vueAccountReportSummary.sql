
CREATE VIEW dbo.vueAccountReportSummary
AS
SELECT     dbo.AccountReportSummary.AccountReportSummaryId, dbo.AccountReportSummary.AccountReportGroupId, 
                      dbo.AccountReportSummary.AccountReportId, dbo.AccountReportSummary.SystemReportCalculationTypeId, 
                      dbo.AccountReportSummary.AccountReportColumnId, dbo.AccountReportSummary.SummaryCaption, dbo.AccountReportSummary.IsShowGroupTotal, 
                      dbo.AccountReportSummary.IsShowGrandTotal, dbo.SystemReportCalculationType.CalculationType, dbo.AccountReportGroup.ReportGroup, 
                      dbo.AccountReportGroup.ReportGroupFieldLabel, dbo.AccountReportGroup.ReportGroupFieldOrder, dbo.AccountReportColumn.Caption, 
                      dbo.AccountReportColumn.ColumnOrder, dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, dbo.AccountReport.ReportIconPath, 
                      dbo.AccountReport.AccountId, dbo.SystemReportDataSource.ReportDataSourceName, dbo.SystemReportDataSource.ReportDatasource, 
                      dbo.SystemReportDataSource.ReportDataSourceType, dbo.SystemReportDataSourceField.SystemReportDataSourceField, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldWidth, dbo.SystemReportDataSourceField.DefaultAvailable, 
                      dbo.SystemReportDataSourceField.CurrencyField, dbo.SystemReportDataSourceField.Formula, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldColumnOrder, dbo.SystemReportDataSourceField.SystemReportFieldTypeId, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldCaption, dbo.SystemReportFieldType.SystemReportFieldType, 
                      dbo.SystemReportDataSourceField.ShowCurrencyCodeInSummary
FROM         dbo.AccountReportSummary INNER JOIN
                      dbo.SystemReportCalculationType ON 
                      dbo.AccountReportSummary.SystemReportCalculationTypeId = dbo.SystemReportCalculationType.SystemReportCalculationTypeId INNER JOIN
                      dbo.AccountReportColumn ON dbo.AccountReportSummary.AccountReportColumnId = dbo.AccountReportColumn.AccountReportColumnId INNER JOIN
                      dbo.AccountReport ON dbo.AccountReportSummary.AccountReportId = dbo.AccountReport.AccountReportId INNER JOIN
                      dbo.SystemReportDataSourceField ON 
                      dbo.AccountReportColumn.SystemReportDataSourceFieldId = dbo.SystemReportDataSourceField.SystemReportDataSourceFieldId INNER JOIN
                      dbo.SystemReportDataSource ON 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceId = dbo.SystemReportDataSource.SystemReportDataSourceId INNER JOIN
                      dbo.SystemReportFieldType ON 
                      dbo.SystemReportDataSourceField.SystemReportFieldTypeId = dbo.SystemReportFieldType.SystemReportFieldTypeId LEFT OUTER JOIN
                      dbo.AccountReportGroup ON dbo.AccountReportSummary.AccountReportGroupId = dbo.AccountReportGroup.AccountReportGroupId