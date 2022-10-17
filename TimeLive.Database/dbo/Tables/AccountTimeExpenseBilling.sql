CREATE TABLE [dbo].[AccountTimeExpenseBilling] (
    [AccountTimeExpenseBillingId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTimeExpenseBilling_AccountTimeExpenseBillingId] DEFAULT (newid()) NOT NULL,
    [AccountId]                   INT              NOT NULL,
    [AccountClientId]             INT              NOT NULL,
    [AccountCurrencyId]           INT              NOT NULL,
    [BillingCycleStartDate]       DATETIME         NOT NULL,
    [BillingCycleEndDate]         DATETIME         NOT NULL,
    [InvoiceNumber]               VARCHAR (50)     NULL,
    [InvoiceDate]                 DATETIME         NOT NULL,
    [PONumber]                    VARCHAR (50)     NULL,
    [Description]                 NVARCHAR (1000)  NULL,
    [CreatedOn]                   DATETIME         NOT NULL,
    [CreatedByEmployeeId]         INT              NULL,
    [ModifiedOn]                  DATETIME         NOT NULL,
    [ModifiedByEmployeeId]        INT              NULL,
    [IsDisabled]                  BIT              NULL,
    [SubTotal]                    FLOAT (53)       NULL,
    [TaxCode1]                    FLOAT (53)       NULL,
    [TaxCode2]                    FLOAT (53)       NULL,
    [GrandTotal]                  FLOAT (53)       NULL,
    [IsPaid]                      BIT              NULL,
    [AccountProjectId]            INT              NULL,
    [Terms]                       NVARCHAR (1000)  NULL,
    [BankDetails]                 NVARCHAR (1000)  NULL,
    [ParentAccountProjectTaskId]  INT              NULL,
    [GroupTimesheetBillingListBy] NVARCHAR (100)   NULL,
    [GroupExpenseBillingListBy]   NVARCHAR (100)   NULL,
    CONSTRAINT [PK_AccountTimeExpenseBilling] PRIMARY KEY CLUSTERED ([AccountTimeExpenseBillingId] ASC),
    CONSTRAINT [FK_AccountTimeExpenseBilling_AccountCurrency] FOREIGN KEY ([AccountCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]),
    CONSTRAINT [FK_AccountTimeExpenseBilling_AccountParty] FOREIGN KEY ([AccountClientId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountCurrencyId]
    ON [dbo].[AccountTimeExpenseBilling]([AccountCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountClientId]
    ON [dbo].[AccountTimeExpenseBilling]([AccountClientId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountTimeExpenseBilling]
    ON [dbo].[AccountTimeExpenseBilling]([InvoiceNumber] ASC, [AccountId] ASC);

