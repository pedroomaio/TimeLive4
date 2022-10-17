CREATE TABLE [dbo].[MasterAccountExpense] (
    [MasterExpenseId]       SMALLINT       NOT NULL,
    [Expense]               NVARCHAR (100) NOT NULL,
    [MasterExpenseTypeId]   SMALLINT       NOT NULL,
    [DefaultExpenseRate]    FLOAT (53)     NULL,
    [DisabledEditingOfRate] BIT            CONSTRAINT [DF_MasterAccountExpense_DisabledEditingOfRate] DEFAULT ((0)) NOT NULL
);

