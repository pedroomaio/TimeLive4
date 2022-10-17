CREATE TABLE [dbo].[AccountReportGroup] (
    [AccountReportGroupId]          UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportGroup_AccountReportGroupId] DEFAULT (newid()) NOT NULL,
    [AccountReportId]               UNIQUEIDENTIFIER NOT NULL,
    [ReportGroup]                   NVARCHAR (100)   NOT NULL,
    [ReportGroupFieldLabel]         NVARCHAR (100)   NOT NULL,
    [ReportGroupFieldOrder]         INT              NOT NULL,
    [SystemReportDataSourceFieldId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AccountReportGroup] PRIMARY KEY CLUSTERED ([AccountReportGroupId] ASC),
    CONSTRAINT [FK_AccountReportGroup_AccountReport] FOREIGN KEY ([AccountReportId]) REFERENCES [dbo].[AccountReport] ([AccountReportId]) ON DELETE CASCADE
);

