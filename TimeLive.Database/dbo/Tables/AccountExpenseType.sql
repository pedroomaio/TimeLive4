CREATE TABLE [dbo].[AccountExpenseType] (
    [AccountExpenseTypeId]       INT            IDENTITY (1, 1) NOT NULL,
    [ExpenseType]                NVARCHAR (100) NOT NULL,
    [AccountId]                  INT            NOT NULL,
    [CreatedOn]                  DATETIME       CONSTRAINT [DF_AccountExpenseType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]                 DATETIME       CONSTRAINT [DF_AccountExpenseType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]        INT            CONSTRAINT [DF_AccountExpenseType_CreatedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [ModifiedByEmployeeId]       INT            CONSTRAINT [DF_AccountExpenseType_ModifiedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [IsDisabled]                 BIT            CONSTRAINT [DF_AccountExpenseType_IsDisabled] DEFAULT ((0)) NOT NULL,
    [AccountTaxCodeId]           INT            NULL,
    [IsQuantityField]            BIT            CONSTRAINT [DF_AccountExpenseType_IsQuantityField] DEFAULT ((0)) NOT NULL,
    [QuantityFieldCaption]       NVARCHAR (100) NULL,
    [MasterAccountExpenseTypeId] SMALLINT       NULL,
    CONSTRAINT [PK_AccountExpenseType] PRIMARY KEY CLUSTERED ([AccountExpenseTypeId] ASC),
    CONSTRAINT [FK_AccountExpenseType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_AccountExpenseType_AccountTaxCode] FOREIGN KEY ([AccountTaxCodeId]) REFERENCES [dbo].[AccountTaxCode] ([AccountTaxCodeId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountExpenseType_5_631061384__K3_K1_2_4_5_6_7_8_9_10]
    ON [dbo].[AccountExpenseType]([AccountId] ASC, [AccountExpenseTypeId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountExpenseType]
    ON [dbo].[AccountExpenseType]([AccountId] ASC, [ExpenseType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountExpenseType]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_631061384_1_3]
    ON [dbo].[AccountExpenseType]([AccountExpenseTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_631061384_2_1]
    ON [dbo].[AccountExpenseType]([ExpenseType], [AccountExpenseTypeId]);

