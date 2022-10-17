CREATE TABLE [dbo].[AccountEmployeeDashboard] (
    [AccountEmployeeDashboardId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeDashboard_AccountEmployeeDashboardId] DEFAULT (newid()) NOT NULL,
    [AccountId]                  INT              NOT NULL,
    [AccountEmployeeId]          INT              NOT NULL,
    [SystemEmployeeDashboardId]  UNIQUEIDENTIFIER NULL,
    [CreatedOn]                  DATETIME         NULL,
    [CreatedByEmployeeId]        INT              NULL,
    [ModifiedOn]                 DATETIME         NULL,
    [ModifiedByEmployeeId]       INT              NULL,
    [IsPanelView]                BIT              NULL,
    [SortOrder]                  INT              NULL,
    CONSTRAINT [PK_AccountEmployeeDashboard] PRIMARY KEY CLUSTERED ([AccountEmployeeDashboardId] ASC)
);

