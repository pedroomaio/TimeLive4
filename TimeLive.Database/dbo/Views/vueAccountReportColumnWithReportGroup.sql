
CREATE VIEW dbo.vueAccountReportColumnWithReportGroup
AS
SELECT     dbo.AccountReportColumn.AccountReportColumnId, dbo.AccountReportColumn.AccountReportId, dbo.AccountReportColumn.Caption, 
                      dbo.AccountReportColumn.SystemReportDataSourceFieldId, dbo.AccountReportColumn.ColumnOrder, dbo.AccountReportGroup.AccountReportGroupId, 
                      dbo.AccountReportGroup.ReportGroup, dbo.AccountReportGroup.ReportGroupFieldLabel, dbo.AccountReportGroup.ReportGroupFieldOrder
FROM         dbo.AccountReportColumn INNER JOIN
                      dbo.AccountReportGroup ON dbo.AccountReportColumn.AccountReportId = dbo.AccountReportGroup.AccountReportId