CREATE TABLE [dbo].[SystemEmployeeDashboard] (
    [SystemEmployeeDashboardId]   UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_AccountEmployeeDashboardId] DEFAULT (newid()) NOT NULL,
    [SystemEmployeeDashboardName] NVARCHAR (200)   NULL,
    [SortOrder]                   INT              NULL,
    [SystemFeatureId]             UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_SystemEmployeeDashboard] PRIMARY KEY CLUSTERED ([SystemEmployeeDashboardId] ASC)
);

