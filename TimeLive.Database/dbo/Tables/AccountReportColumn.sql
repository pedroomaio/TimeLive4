CREATE TABLE [dbo].[AccountReportColumn] (
    [AccountReportColumnId]         UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportColumn_AccountReportColumnId] DEFAULT (newid()) NOT NULL,
    [AccountReportId]               UNIQUEIDENTIFIER NOT NULL,
    [Caption]                       NVARCHAR (100)   NOT NULL,
    [SystemReportDataSourceFieldId] UNIQUEIDENTIFIER NULL,
    [ColumnOrder]                   INT              NOT NULL,
    [SystemReportCalculationTypeId] UNIQUEIDENTIFIER NULL,
    [ColumnFormula]                 NVARCHAR (200)   NULL,
    CONSTRAINT [PK_AccountReportColumn] PRIMARY KEY CLUSTERED ([AccountReportColumnId] ASC),
    CONSTRAINT [FK_AccountReportColumn_AccountReport] FOREIGN KEY ([AccountReportId]) REFERENCES [dbo].[AccountReport] ([AccountReportId]) ON DELETE CASCADE
);


GO
CREATE STATISTICS [_dta_stat_590065288_2_4_5]
    ON [dbo].[AccountReportColumn]([AccountReportId], [SystemReportDataSourceFieldId], [ColumnOrder]);


GO
CREATE STATISTICS [_dta_stat_590065288_1_4_5]
    ON [dbo].[AccountReportColumn]([AccountReportColumnId], [SystemReportDataSourceFieldId], [ColumnOrder]);


GO
CREATE STATISTICS [_dta_stat_590065288_5_2]
    ON [dbo].[AccountReportColumn]([ColumnOrder], [AccountReportId]);


GO
CREATE STATISTICS [_dta_stat_590065288_5_1]
    ON [dbo].[AccountReportColumn]([ColumnOrder], [AccountReportColumnId]);

