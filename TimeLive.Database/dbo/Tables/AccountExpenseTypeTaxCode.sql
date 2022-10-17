CREATE TABLE [dbo].[AccountExpenseTypeTaxCode] (
    [AccountExpenseTypeTaxCodeId]       INT           IDENTITY (1, 1) NOT NULL,
    [AccountExpenseTypeId]              INT           NOT NULL,
    [AccountTaxZoneId]                  INT           NOT NULL,
    [AccountTaxCodeId]                  INT           NOT NULL,
    [AccountId]                         INT           NOT NULL,
    [CreatedOn]                         SMALLDATETIME NOT NULL,
    [ModifiedOn]                        SMALLDATETIME NOT NULL,
    [CreatedByEmployeeId]               INT           NOT NULL,
    [ModifiedByEmployeeId]              INT           NOT NULL,
    [MasterAccountExpenseTypeTaxCodeId] INT           NULL,
    CONSTRAINT [PK_AccountExpenseTypeTaxCode] PRIMARY KEY CLUSTERED ([AccountExpenseTypeTaxCodeId] ASC),
    CONSTRAINT [FK_AccountExpenseTypeTaxCode_AccountTaxCode] FOREIGN KEY ([AccountTaxCodeId]) REFERENCES [dbo].[AccountTaxCode] ([AccountTaxCodeId]),
    CONSTRAINT [FK_AccountExpenseTypeTaxCode_AccountTaxZone] FOREIGN KEY ([AccountTaxZoneId]) REFERENCES [dbo].[AccountTaxZone] ([AccountTaxZoneId])
);


GO
CREATE STATISTICS [_dta_stat_698537622_1_3_2_4]
    ON [dbo].[AccountExpenseTypeTaxCode]([AccountExpenseTypeTaxCodeId], [AccountTaxZoneId], [AccountExpenseTypeId], [AccountTaxCodeId]);


GO
CREATE STATISTICS [_dta_stat_698537622_2_1_4]
    ON [dbo].[AccountExpenseTypeTaxCode]([AccountExpenseTypeId], [AccountExpenseTypeTaxCodeId], [AccountTaxCodeId]);


GO
CREATE STATISTICS [_dta_stat_698537622_1_4]
    ON [dbo].[AccountExpenseTypeTaxCode]([AccountExpenseTypeTaxCodeId], [AccountTaxCodeId]);


GO
CREATE STATISTICS [_dta_stat_698537622_3_2]
    ON [dbo].[AccountExpenseTypeTaxCode]([AccountTaxZoneId], [AccountExpenseTypeId]);

