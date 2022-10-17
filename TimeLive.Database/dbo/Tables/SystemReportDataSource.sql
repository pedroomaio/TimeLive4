CREATE TABLE [dbo].[SystemReportDataSource] (
    [SystemReportDataSourceId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportDataSource_SystemReportDataSourceId] DEFAULT (newid()) NOT NULL,
    [ReportDataSourceName]     NVARCHAR (100)   NOT NULL,
    [ReportDatasource]         NVARCHAR (100)   NOT NULL,
    [ReportDataSourceType]     NVARCHAR (100)   NOT NULL,
    [DefaultIconPath]          NVARCHAR (200)   NULL,
    [SystemFeatureId]          UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AccountReportDataSource] PRIMARY KEY CLUSTERED ([SystemReportDataSourceId] ASC)
);

