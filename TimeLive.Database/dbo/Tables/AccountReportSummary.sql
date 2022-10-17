CREATE TABLE [dbo].[AccountReportSummary] (
    [AccountReportSummaryId]        UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportGroupSummary_AccountReportGroupSummaryId] DEFAULT (newid()) NOT NULL,
    [AccountReportGroupId]          UNIQUEIDENTIFIER NULL,
    [AccountReportId]               UNIQUEIDENTIFIER NOT NULL,
    [SystemReportCalculationTypeId] UNIQUEIDENTIFIER NOT NULL,
    [AccountReportColumnId]         UNIQUEIDENTIFIER NOT NULL,
    [SummaryCaption]                NVARCHAR (100)   NOT NULL,
    [IsShowGroupTotal]              BIT              CONSTRAINT [DF_SystemReportGroupSummary_IsShowGroupTotal] DEFAULT ((0)) NOT NULL,
    [IsShowGrandTotal]              BIT              CONSTRAINT [DF_SystemReportGroupSummary_IsShowGrandTotal] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountReportGroupSummary] PRIMARY KEY CLUSTERED ([AccountReportSummaryId] ASC),
    CONSTRAINT [FK_AccountReportSummary_AccountReport] FOREIGN KEY ([AccountReportId]) REFERENCES [dbo].[AccountReport] ([AccountReportId]) ON DELETE CASCADE
);

