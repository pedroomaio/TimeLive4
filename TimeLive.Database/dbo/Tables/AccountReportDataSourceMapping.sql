CREATE TABLE [dbo].[AccountReportDataSourceMapping] (
    [AccountReportDataSourceMappingId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportDataSourceMapping_AccountReportDataSourceMappingId] DEFAULT (newid()) NOT NULL,
    [AccountReportId]                  UNIQUEIDENTIFIER NOT NULL,
    [SystemReportDataSourceId]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AccountReportDataSourceMapping] PRIMARY KEY CLUSTERED ([AccountReportDataSourceMappingId] ASC),
    CONSTRAINT [FK_AccountReportDataSourceMapping_AccountReport] FOREIGN KEY ([AccountReportId]) REFERENCES [dbo].[AccountReport] ([AccountReportId]) ON DELETE CASCADE
);

