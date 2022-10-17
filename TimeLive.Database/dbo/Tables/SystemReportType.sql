CREATE TABLE [dbo].[SystemReportType] (
    [SystemReportTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportType_AccountReportTypeId] DEFAULT (newid()) NOT NULL,
    [SystemReportType]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_AccountReportType] PRIMARY KEY CLUSTERED ([SystemReportTypeId] ASC)
);

