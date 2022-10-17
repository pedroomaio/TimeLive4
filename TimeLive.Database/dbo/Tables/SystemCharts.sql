CREATE TABLE [dbo].[SystemCharts] (
    [SystemChartId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemCharts_SystemChartId] DEFAULT (newid()) NOT NULL,
    [SystemChartName] VARCHAR (1000)   NULL,
    CONSTRAINT [PK_SystemCharts] PRIMARY KEY CLUSTERED ([SystemChartId] ASC)
);

