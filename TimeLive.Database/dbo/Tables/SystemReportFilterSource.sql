CREATE TABLE [dbo].[SystemReportFilterSource] (
    [SystemReportFilterSourceId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemReportFilterSource_SystemReportFilterSourceId] DEFAULT (newid()) NOT NULL,
    [SystemReportFilterSource]   NVARCHAR (200)   NOT NULL,
    [ClassName]                  VARCHAR (50)     NULL,
    [ClassFunction]              VARCHAR (50)     NULL,
    [ParameterName1]             VARCHAR (50)     NULL,
    [Caption]                    NVARCHAR (100)   NULL,
    [FilterSourceType]           NVARCHAR (100)   NULL,
    [FilterSource]               NVARCHAR (100)   NULL,
    [FilterOperator]             NVARCHAR (50)    NULL,
    [IsOptional]                 BIT              NULL,
    [FilterField]                NVARCHAR (100)   NULL,
    [ParentFilterSource]         NVARCHAR (50)    NULL,
    CONSTRAINT [PK_SystemReportFilterSource] PRIMARY KEY CLUSTERED ([SystemReportFilterSourceId] ASC)
);

