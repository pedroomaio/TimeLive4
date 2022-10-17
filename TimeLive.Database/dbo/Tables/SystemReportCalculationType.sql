CREATE TABLE [dbo].[SystemReportCalculationType] (
    [SystemReportCalculationTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemReportSummaryCalculationType_SystemReportCalculationTypeId_1] DEFAULT (newid()) NOT NULL,
    [CalculationType]               NVARCHAR (50)    NULL,
    [ExcludeForCalculationSummary]  BIT              CONSTRAINT [DF_SystemReportCalculationType_ExcludeForCalculationSummary] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SystemReportSummaryCalculationType] PRIMARY KEY CLUSTERED ([SystemReportCalculationTypeId] ASC)
);

