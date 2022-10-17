CREATE TABLE [dbo].[SystemEarnPeriod] (
    [SystemEarnPeriodId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemEarnPeriod_SystemEarnPeriodId] DEFAULT (newid()) NOT NULL,
    [SystemEarnPeriod]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_SystemEarnPeriod] PRIMARY KEY CLUSTERED ([SystemEarnPeriodId] ASC)
);

