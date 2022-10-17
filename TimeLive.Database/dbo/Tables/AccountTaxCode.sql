CREATE TABLE [dbo].[AccountTaxCode] (
    [AccountTaxCodeId] INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]        INT            NOT NULL,
    [TaxCode]          NVARCHAR (100) NOT NULL,
    [Formula]          NVARCHAR (200) NOT NULL,
    [MasterTaxCodeId]  SMALLINT       NULL,
    [IsDisabled]       BIT            NOT NULL,
    [AccountTaxZoneId] INT            NULL,
    CONSTRAINT [PK_AccountTaxCode] PRIMARY KEY CLUSTERED ([AccountTaxCodeId] ASC),
    CONSTRAINT [FK_AccountTaxCode_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountTaxCode_AccountTaxZone] FOREIGN KEY ([AccountTaxZoneId]) REFERENCES [dbo].[AccountTaxZone] ([AccountTaxZoneId]),
    CONSTRAINT [FK_AccountTaxCode_MasterTaxCode] FOREIGN KEY ([MasterTaxCodeId]) REFERENCES [dbo].[MasterTaxCode] ([MasterTaxCodeId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TaxCode]
    ON [dbo].[AccountTaxCode]([AccountId] ASC, [TaxCode] ASC, [AccountTaxZoneId] ASC);


GO
CREATE STATISTICS [_dta_stat_483584861_1_2_7]
    ON [dbo].[AccountTaxCode]([AccountTaxCodeId], [AccountId], [AccountTaxZoneId]);


GO
CREATE STATISTICS [_dta_stat_483584861_2_7]
    ON [dbo].[AccountTaxCode]([AccountId], [AccountTaxZoneId]);


GO
CREATE STATISTICS [_dta_stat_483584861_7_1]
    ON [dbo].[AccountTaxCode]([AccountTaxZoneId], [AccountTaxCodeId]);

