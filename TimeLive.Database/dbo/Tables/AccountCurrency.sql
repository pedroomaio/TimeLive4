CREATE TABLE [dbo].[AccountCurrency] (
    [AccountCurrencyId]             INT      IDENTITY (1, 1) NOT NULL,
    [AccountCurrencyExchangeRateId] INT      NULL,
    [SystemCurrencyId]              INT      NOT NULL,
    [AccountId]                     INT      NOT NULL,
    [Disabled]                      BIT      NOT NULL,
    [MasterAccountCurrencyId]       SMALLINT NULL,
    CONSTRAINT [PK_AccountCurrency] PRIMARY KEY CLUSTERED ([AccountCurrencyId] ASC),
    CONSTRAINT [FK_AccountCurrency_AccountCurrencyExchangeRate] FOREIGN KEY ([AccountCurrencyExchangeRateId]) REFERENCES [dbo].[AccountCurrencyExchangeRate] ([AccountCurrencyExchangeRateId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountCurrency]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountCurrency_5_1424060159__K4_K1_K3_K5_K2_6]
    ON [dbo].[AccountCurrency]([AccountId] ASC, [AccountCurrencyId] ASC, [SystemCurrencyId] ASC, [Disabled] ASC, [AccountCurrencyExchangeRateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountCurrencyExchangeRateId]
    ON [dbo].[AccountCurrency]([AccountCurrencyExchangeRateId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemCurrencyId]
    ON [dbo].[AccountCurrency]([AccountId] ASC, [SystemCurrencyId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountCurrency]
    ON [dbo].[AccountCurrency]([AccountCurrencyId] ASC);


GO
CREATE STATISTICS [_dta_stat_1424060159_1_3_4_5_2]
    ON [dbo].[AccountCurrency]([AccountCurrencyId], [SystemCurrencyId], [AccountId], [Disabled], [AccountCurrencyExchangeRateId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_1_2_3_4]
    ON [dbo].[AccountCurrency]([AccountCurrencyId], [AccountCurrencyExchangeRateId], [SystemCurrencyId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_4_5_1_2]
    ON [dbo].[AccountCurrency]([AccountId], [Disabled], [AccountCurrencyId], [AccountCurrencyExchangeRateId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_3_4_2]
    ON [dbo].[AccountCurrency]([SystemCurrencyId], [AccountId], [AccountCurrencyExchangeRateId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_5_1_2]
    ON [dbo].[AccountCurrency]([Disabled], [AccountCurrencyId], [AccountCurrencyExchangeRateId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_1_4]
    ON [dbo].[AccountCurrency]([AccountCurrencyId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_2_3]
    ON [dbo].[AccountCurrency]([AccountCurrencyExchangeRateId], [SystemCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_1424060159_4_2]
    ON [dbo].[AccountCurrency]([AccountId], [AccountCurrencyExchangeRateId]);

