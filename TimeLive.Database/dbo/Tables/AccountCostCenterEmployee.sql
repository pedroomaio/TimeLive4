CREATE TABLE [dbo].[AccountCostCenterEmployee] (
    [AccountCostCenterEmployeeId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountCostCenterEmployee_AccountCostCenterEmployeeId] DEFAULT (newid()) NOT NULL,
    [AccountCostCenterId]         INT              NULL,
    [AccountId]                   INT              NULL,
    [AccountEmployeeId]           INT              NULL,
    CONSTRAINT [PK_AccountCostCenterEmployee] PRIMARY KEY CLUSTERED ([AccountCostCenterEmployeeId] ASC)
);

