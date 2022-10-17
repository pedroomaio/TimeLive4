CREATE TABLE [dbo].[AccountExpenseEntryApproval] (
    [ExpenseApprovalId]     INT            IDENTITY (1, 1) NOT NULL,
    [AccountExpenseEntryId] INT            NOT NULL,
    [ExpenseApprovalTypeId] INT            NOT NULL,
    [ExpenseApprovalPathId] INT            NOT NULL,
    [ApprovedByEmployeeId]  INT            NOT NULL,
    [ApprovedOn]            DATETIME       NOT NULL,
    [Comments]              NVARCHAR (400) NULL,
    [IsRejected]            BIT            CONSTRAINT [DF_ExpenseApproval_IsRejected] DEFAULT ((0)) NOT NULL,
    [IsApproved]            BIT            CONSTRAINT [DF_ExpenseApproval_IsApproved] DEFAULT ((0)) NOT NULL,
    [ApprovalPathSequence]  TINYINT        NULL,
    CONSTRAINT [PK_ExpenseApproval] PRIMARY KEY CLUSTERED ([ExpenseApprovalId] ASC),
    CONSTRAINT [FK_AccountExpenseEntryApproval_AccountApprovalPath] FOREIGN KEY ([ExpenseApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId]),
    CONSTRAINT [FK_AccountExpenseEntryApproval_AccountApprovalType] FOREIGN KEY ([ExpenseApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]),
    CONSTRAINT [FK_AccountExpenseEntryApproval_AccountExpenseEntry] FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ApprovedByEmployeeId]
    ON [dbo].[AccountExpenseEntryApproval]([ApprovedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExpenseApprovalPathId]
    ON [dbo].[AccountExpenseEntryApproval]([ExpenseApprovalPathId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExpenseApprovalTypeId]
    ON [dbo].[AccountExpenseEntryApproval]([ExpenseApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountExpenseEntryId]
    ON [dbo].[AccountExpenseEntryApproval]([AccountExpenseEntryId] ASC);

