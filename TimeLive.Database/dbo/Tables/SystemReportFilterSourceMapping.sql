CREATE TABLE [dbo].[SystemReportFilterSourceMapping] (
    [SystemReportFilterMappingId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemReportFilterSourceMapping_SystemReportFilterMappingId] DEFAULT (newid()) NOT NULL,
    [SystemReportFilterSourceId]  UNIQUEIDENTIFIER NOT NULL,
    [SystemReportDataSourceId]    UNIQUEIDENTIFIER NOT NULL,
    [IsRequired]                  BIT              CONSTRAINT [DF_SystemReportFilterSourceMapping_IsRequired] DEFAULT ((0)) NOT NULL,
    [IsAllowAll]                  BIT              CONSTRAINT [DF_SystemReportFilterSourceMapping_IsAllowAll] DEFAULT ((0)) NOT NULL,
    [FilterSequence]              INT              NULL,
    CONSTRAINT [PK_SystemReportFilterSourceMapping] PRIMARY KEY CLUSTERED ([SystemReportFilterMappingId] ASC)
);

