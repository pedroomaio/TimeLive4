CREATE TABLE [dbo].[AccountTimeExpenseBillingTimesheet] (
    [AccountTimeExpenseBillingTimesheetId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTimeExpenseBillingTimesheet_AccountTimeExpenseBillingTimesheetId] DEFAULT (newid()) NOT NULL,
    [AccountTimeExpenseBillingId]          UNIQUEIDENTIFIER NOT NULL,
    [AccountId]                            INT              NOT NULL,
    [AccountProjectId]                     INT              NULL,
    [AccountProjectTaskId]                 BIGINT           NULL,
    [Description]                          NVARCHAR (1000)  NULL,
    [ActualBillingRate]                    FLOAT (53)       NULL,
    [BillingRate]                          FLOAT (53)       NULL,
    [ActualHours]                          FLOAT (53)       NULL,
    [BillHours]                            FLOAT (53)       NULL,
    [TotalAmount]                          FLOAT (53)       NULL,
    [AccountTaxCodeId1]                    INT              NULL,
    [AccountTaxCodeId2]                    INT              NULL,
    [TaxCode1]                             FLOAT (53)       NULL,
    [TaxCode2]                             FLOAT (53)       NULL,
    [CreatedOn]                            DATETIME         NULL,
    [CreatedByEmployeeId]                  INT              NULL,
    [ModifiedOn]                           DATETIME         NULL,
    [ModifiedByEmployeeId]                 INT              NULL,
    [AccountEmployeeTimeEntryId]           INT              NULL,
    CONSTRAINT [PK_AccountTimeExpenseBillingTimesheet] PRIMARY KEY CLUSTERED ([AccountTimeExpenseBillingTimesheetId] ASC),
    CONSTRAINT [FK_AccountTimeExpenseBillingTimesheet_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingTimesheet_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingTimesheet_AccountTaxCode] FOREIGN KEY ([AccountTaxCodeId1]) REFERENCES [dbo].[AccountTaxCode] ([AccountTaxCodeId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingTimesheet_AccountTaxCode1] FOREIGN KEY ([AccountTaxCodeId2]) REFERENCES [dbo].[AccountTaxCode] ([AccountTaxCodeId]),
    CONSTRAINT [FK_AccountTimeExpenseBillingTimesheet_AccountTimeExpenseBilling] FOREIGN KEY ([AccountTimeExpenseBillingId]) REFERENCES [dbo].[AccountTimeExpenseBilling] ([AccountTimeExpenseBillingId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTimeExpenseBillingTimesheet]
    ON [dbo].[AccountTimeExpenseBillingTimesheet]([AccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [IXX_AccountTaxCodeId2]
    ON [dbo].[AccountTimeExpenseBillingTimesheet]([AccountTaxCodeId2] ASC);


GO
CREATE NONCLUSTERED INDEX [IXX_AccountTaxCodeId]
    ON [dbo].[AccountTimeExpenseBillingTimesheet]([AccountTaxCodeId1] ASC);


GO
CREATE NONCLUSTERED INDEX [IXX_AccountProjectId]
    ON [dbo].[AccountTimeExpenseBillingTimesheet]([AccountProjectId] ASC);

