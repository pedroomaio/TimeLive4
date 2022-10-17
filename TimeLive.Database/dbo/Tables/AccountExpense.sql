CREATE TABLE [dbo].[AccountExpense] (
    [AccountExpenseId]       INT            IDENTITY (1, 1) NOT NULL,
    [AccountExpenseName]     NVARCHAR (200) NOT NULL,
    [AccountExpenseTypeId]   INT            NOT NULL,
    [IsBillable]             BIT            NULL,
    [AccountId]              INT            NOT NULL,
    [CreatedOn]              DATETIME       CONSTRAINT [DF_AccountExpense_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]    INT            NOT NULL,
    [ModifiedOn]             DATETIME       CONSTRAINT [DF_AccountExpense_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]   INT            NOT NULL,
    [IsDisabled]             BIT            CONSTRAINT [DF_AccountExpense_IsDisabled] DEFAULT ((0)) NOT NULL,
    [DefaultExpenseRate]     FLOAT (53)     NULL,
    [DisabledEditingOfRate]  BIT            CONSTRAINT [DF_AccountExpense_DisabledEditingOfRate] DEFAULT ((0)) NOT NULL,
    [MasterAccountExpenseId] SMALLINT       NULL,
    [Reimburse]              BIT            NULL,
    CONSTRAINT [PK_AccountExpense] PRIMARY KEY CLUSTERED ([AccountExpenseId] ASC),
    CONSTRAINT [FK_AccountExpense_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_AccountExpense_AccountExpenseType] FOREIGN KEY ([AccountExpenseTypeId]) REFERENCES [dbo].[AccountExpenseType] ([AccountExpenseTypeId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountExpenseName]
    ON [dbo].[AccountExpense]([AccountId] ASC, [AccountExpenseTypeId] ASC, [AccountExpenseName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountExpense]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountExpenseTypeId]
    ON [dbo].[AccountExpense]([AccountExpenseTypeId] ASC);


GO
CREATE STATISTICS [_dta_stat_215059902_1_5_2_10]
    ON [dbo].[AccountExpense]([AccountExpenseId], [AccountId], [AccountExpenseName], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_215059902_1_5_3_2]
    ON [dbo].[AccountExpense]([AccountExpenseId], [AccountId], [AccountExpenseTypeId], [AccountExpenseName]);


GO
CREATE STATISTICS [_dta_stat_215059902_1_5_10]
    ON [dbo].[AccountExpense]([AccountExpenseId], [AccountId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_215059902_2_4_1]
    ON [dbo].[AccountExpense]([AccountExpenseName], [IsBillable], [AccountExpenseId]);


GO
CREATE STATISTICS [_dta_stat_215059902_2_5]
    ON [dbo].[AccountExpense]([AccountExpenseName], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_215059902_1_2]
    ON [dbo].[AccountExpense]([AccountExpenseId], [AccountExpenseName]);


GO
CREATE STATISTICS [_dta_stat_215059902_10_1]
    ON [dbo].[AccountExpense]([IsDisabled], [AccountExpenseId]);


GO
CREATE STATISTICS [_dta_stat_215059902_5_10]
    ON [dbo].[AccountExpense]([AccountId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_215059902_1_3]
    ON [dbo].[AccountExpense]([AccountExpenseId], [AccountExpenseTypeId]);

