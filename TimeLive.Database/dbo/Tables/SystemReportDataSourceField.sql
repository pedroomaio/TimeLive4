CREATE TABLE [dbo].[SystemReportDataSourceField] (
    [SystemReportDataSourceFieldId]          UNIQUEIDENTIFIER CONSTRAINT [DF_SystemReportDataSourceField_SystemReportDataSourceFieldId] DEFAULT (newid()) NOT NULL,
    [SystemReportDataSourceId]               UNIQUEIDENTIFIER NOT NULL,
    [SystemReportDataSourceField]            NVARCHAR (100)   NOT NULL,
    [SystemReportDataSourceFieldWidth]       INT              NOT NULL,
    [DefaultAvailable]                       BIT              CONSTRAINT [DF_SystemReportDataSourceField_DefaultAvailable] DEFAULT ((0)) NOT NULL,
    [CurrencyField]                          NVARCHAR (100)   NULL,
    [Formula]                                NVARCHAR (200)   NULL,
    [SystemReportDataSourceFieldColumnOrder] INT              NOT NULL,
    [SystemReportFieldTypeId]                UNIQUEIDENTIFIER NOT NULL,
    [SystemReportDataSourceFieldCaption]     NVARCHAR (100)   NOT NULL,
    [ShowCurrencyCodeInSummary]              BIT              CONSTRAINT [DF_SystemReportDataSourceField_ShowCurrencyCodeInSummary] DEFAULT ((0)) NOT NULL,
    [IsFormulaField]                         BIT              CONSTRAINT [DF_SystemReportDataSourceField_IsFormulaField] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SystemReportDataSourceField] PRIMARY KEY CLUSTERED ([SystemReportDataSourceFieldId] ASC)
);


GO
CREATE STATISTICS [_dta_stat_638065459_1_2_9]
    ON [dbo].[SystemReportDataSourceField]([SystemReportDataSourceFieldId], [SystemReportDataSourceId], [SystemReportFieldTypeId]);

