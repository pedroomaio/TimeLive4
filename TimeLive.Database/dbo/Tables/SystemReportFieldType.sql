CREATE TABLE [dbo].[SystemReportFieldType] (
    [SystemReportFieldTypeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemReportFieldType_SystemReportFieldTypeId] DEFAULT (newid()) NOT NULL,
    [SystemReportFieldType]     NVARCHAR (100)   NOT NULL,
    [IsAllowSummaryCalculation] BIT              CONSTRAINT [DF_SystemReportFieldType_IsAllowSummaryCalculation] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SystemReportFieldType] PRIMARY KEY CLUSTERED ([SystemReportFieldTypeId] ASC)
);

