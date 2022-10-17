CREATE TABLE [dbo].[SystemChartType] (
    [SystemChartTypeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemChartType_SystemChartTypeId] DEFAULT (newid()) NOT NULL,
    [SystemChartTypeName] VARCHAR (50)     NULL,
    CONSTRAINT [PK_SystemChartType] PRIMARY KEY CLUSTERED ([SystemChartTypeId] ASC)
);

