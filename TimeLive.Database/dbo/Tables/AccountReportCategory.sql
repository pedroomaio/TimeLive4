CREATE TABLE [dbo].[AccountReportCategory] (
    [AccountReportCategoryId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportCategory_ReportCategoryId] DEFAULT (newid()) NOT NULL,
    [AccountReportCategory]   NVARCHAR (100)   NOT NULL,
    [AccountId]               INT              NULL,
    [SequenceNo]              INT              NULL,
    [SystemFeatureId]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AccountReportCategory] PRIMARY KEY CLUSTERED ([AccountReportCategoryId] ASC)
);

