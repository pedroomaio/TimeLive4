CREATE TABLE [dbo].[AccountBillingType] (
    [AccountBillingTypeId]       INT            IDENTITY (1, 1) NOT NULL,
    [BillingCategoryId]          TINYINT        CONSTRAINT [DF_AccountBillingType_BillingTypeId] DEFAULT ((0)) NOT NULL,
    [AccountId]                  INT            NOT NULL,
    [BillingType]                NVARCHAR (100) NOT NULL,
    [CreatedOn]                  DATETIME       CONSTRAINT [DF_AccountBillingType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]        INT            CONSTRAINT [DF_AccountBillingType_CreatedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [ModifiedOn]                 DATETIME       CONSTRAINT [DF_AccountBillingType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]       INT            CONSTRAINT [DF_AccountBillingType_ModifiedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [MasterAccountBillingTypeId] SMALLINT       NULL,
    [IsDisabled]                 BIT            CONSTRAINT [DF_AccountBillingType_IsDisabled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountBillingType] PRIMARY KEY CLUSTERED ([AccountBillingTypeId] ASC),
    CONSTRAINT [FK_AccountBillingType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BillingCategoryId]
    ON [dbo].[AccountBillingType]([BillingCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountBillingType]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountBillingType_5_1402540130__K1_4]
    ON [dbo].[AccountBillingType]([AccountBillingTypeId] ASC);


GO
CREATE STATISTICS [_dta_stat_1402540130_3_1_10_2]
    ON [dbo].[AccountBillingType]([AccountId], [AccountBillingTypeId], [IsDisabled], [BillingCategoryId]);


GO
CREATE STATISTICS [_dta_stat_1402540130_10_1_2]
    ON [dbo].[AccountBillingType]([IsDisabled], [AccountBillingTypeId], [BillingCategoryId]);


GO
CREATE STATISTICS [_dta_stat_1402540130_3_2_1]
    ON [dbo].[AccountBillingType]([AccountId], [BillingCategoryId], [AccountBillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1402540130_4_1]
    ON [dbo].[AccountBillingType]([BillingType], [AccountBillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1402540130_3_10]
    ON [dbo].[AccountBillingType]([AccountId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1402540130_1_2]
    ON [dbo].[AccountBillingType]([AccountBillingTypeId], [BillingCategoryId]);

