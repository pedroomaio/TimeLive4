CREATE TABLE [dbo].[AccountCostCenter] (
    [AccountCostCenterId]   INT            IDENTITY (1, 1) NOT NULL,
    [AccountCostCenterCode] NVARCHAR (14)  NOT NULL,
    [AccountCostCenter]     NVARCHAR (100) NOT NULL,
    [AccountId]             INT            NOT NULL,
    [CreatedOn]             DATETIME       CONSTRAINT [DF_AccountCostCenter_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]   INT            NOT NULL,
    [ModifiedOn]            DATETIME       CONSTRAINT [DF_AccountCostCenter_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]  INT            NOT NULL,
    [IsDisabled]            BIT            CONSTRAINT [DF_AccountCostCenter_IsDisabled] DEFAULT ((0)) NOT NULL,
    [MasterCostCenterId]    SMALLINT       NULL,
    [SortOrder]             SMALLINT       NULL,
    CONSTRAINT [PK_AccountCostCenter] PRIMARY KEY CLUSTERED ([AccountCostCenterId] ASC),
    CONSTRAINT [FK_AccountCostCenter_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountCostCenter_MasterCostCenter] FOREIGN KEY ([MasterCostCenterId]) REFERENCES [dbo].[MasterCostCenter] ([MasterCostCenterId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountCostCenter_10_798729998__K1]
    ON [dbo].[AccountCostCenter]([AccountCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MasterCostCenterId]
    ON [dbo].[AccountCostCenter]([MasterCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ModifiedByEmployeeId]
    ON [dbo].[AccountCostCenter]([ModifiedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatedByEmployeeId]
    ON [dbo].[AccountCostCenter]([CreatedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountCostCenter]([AccountId] ASC);

