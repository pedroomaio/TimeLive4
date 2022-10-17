CREATE TABLE [dbo].[AccountTimeExpenseBillingExpense] (
    [AccountTimeExpenseBillingExpenseId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTimeExpenseBillingExpense_AccountTimeExpenseBillingExpenseId] DEFAULT (newid()) NOT NULL,
    [AccountTimeExpenseBillingId]        UNIQUEIDENTIFIER NOT NULL,
    [AccountId]                          INT              NOT NULL,
    [AccountProjectId]                   INT              NULL,
    [AccountExpenseTypeId]               INT              NULL,
    [AccountExpenseId]                   INT              NULL,
    [Description]                        NVARCHAR (1000)  NULL,
    [ActualExpenseAmount]                FLOAT (53)       NULL,
    [BilledExpenseAmount]                FLOAT (53)       NULL,
    [CreatedOn]                          DATETIME         NULL,
    [CreatedByEmployeeId]                INT              NULL,
    [ModifiedOn]                         DATETIME         NULL,
    [ModifiedByEmployeeId]               INT              NULL,
    [AccountTaxCodeId1]                  INT              NULL,
    [AccountTaxCodeId2]                  INT              NULL,
    [TaxCode1]                           FLOAT (53)       NULL,
    [TaxCode2]                           FLOAT (53)       NULL,
    [AccountExpenseEntryId]              INT              NULL,
    CONSTRAINT [PK_AccountTimeExpenseBillingExpense] PRIMARY KEY CLUSTERED ([AccountTimeExpenseBillingExpenseId] ASC),
    CONSTRAINT [FK_AccountTimeExpenseBillingExpense_AccountExpense] FOREIGN KEY ([AccountExpenseId]) REFERENCES [dbo].[AccountExpense] ([AccountExpenseId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingExpense_AccountExpenseType] FOREIGN KEY ([AccountExpenseTypeId]) REFERENCES [dbo].[AccountExpenseType] ([AccountExpenseTypeId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingExpense_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingExpense_AccountTimeExpenseBilling] FOREIGN KEY ([AccountTimeExpenseBillingId]) REFERENCES [dbo].[AccountTimeExpenseBilling] ([AccountTimeExpenseBillingId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IXXX_AccountExpenseId]
    ON [dbo].[AccountTimeExpenseBillingExpense]([AccountExpenseId] ASC);


GO
CREATE NONCLUSTERED INDEX [IXXX_AccountExpenseTypeId]
    ON [dbo].[AccountTimeExpenseBillingExpense]([AccountExpenseTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IXXX_AccountProjectId]
    ON [dbo].[AccountTimeExpenseBillingExpense]([AccountProjectId] ASC);

