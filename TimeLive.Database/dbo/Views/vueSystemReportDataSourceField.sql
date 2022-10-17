
CREATE VIEW dbo.vueSystemReportDataSourceField
AS
SELECT     dbo.SystemReportDataSourceField.SystemReportDataSourceFieldId, dbo.SystemReportDataSourceField.SystemReportDataSourceId, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceField, dbo.SystemReportDataSourceField.SystemReportDataSourceFieldWidth, 
                      dbo.SystemReportDataSourceField.DefaultAvailable, dbo.SystemReportDataSourceField.CurrencyField, dbo.SystemReportDataSourceField.Formula, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldColumnOrder, dbo.SystemReportDataSourceField.SystemReportFieldTypeId, 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldCaption, dbo.AccountReportColumn.AccountReportColumnId, 
                      dbo.AccountReportColumn.Caption, dbo.AccountReportColumn.ColumnOrder, dbo.AccountReportColumn.SystemReportCalculationTypeId, 
                      dbo.AccountReport.AccountReportCategoryId, dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, 
                      dbo.AccountReport.ReportIconPath, dbo.AccountReport.AccountId, dbo.AccountReport.AccountReportId, 
                      dbo.SystemReportFieldType.SystemReportFieldType, dbo.SystemReportFieldType.IsAllowSummaryCalculation, 
                      dbo.SystemReportDataSourceField.IsFormulaField, dbo.AccountReportColumn.ColumnFormula
FROM         dbo.SystemReportFieldType RIGHT OUTER JOIN
                      dbo.SystemReportDataSourceField ON 
                      dbo.SystemReportFieldType.SystemReportFieldTypeId = dbo.SystemReportDataSourceField.SystemReportFieldTypeId LEFT OUTER JOIN
                      dbo.AccountReport INNER JOIN
                      dbo.AccountReportColumn ON dbo.AccountReport.AccountReportId = dbo.AccountReportColumn.AccountReportId ON 
                      dbo.SystemReportDataSourceField.SystemReportDataSourceFieldId = dbo.AccountReportColumn.SystemReportDataSourceFieldId