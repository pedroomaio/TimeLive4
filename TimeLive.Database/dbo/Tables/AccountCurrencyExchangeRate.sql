CREATE TABLE [dbo].[AccountCurrencyExchangeRate] (
    [AccountCurrencyExchangeRateId]       INT        IDENTITY (1, 1) NOT NULL,
    [ExchangeRateEffectiveStartDate]      DATETIME   NOT NULL,
    [ExchangeRateEffectiveEndDate]        DATETIME   NOT NULL,
    [ExchangeRate]                        FLOAT (53) NOT NULL,
    [AccountId]                           INT        NOT NULL,
    [AccountCurrencyId]                   INT        NOT NULL,
    [MasterAccountCurrencyExchangeRateId] SMALLINT   NULL,
    CONSTRAINT [PK_AccountCurrencyExchangeRate] PRIMARY KEY CLUSTERED ([AccountCurrencyExchangeRateId] ASC),
    CONSTRAINT [FK_AccountCurrencyExchangeRate_AccountCurrency] FOREIGN KEY ([AccountCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountCurrencyExchangeRate_AccountCurrencyExchangeRate] FOREIGN KEY ([AccountCurrencyExchangeRateId]) REFERENCES [dbo].[AccountCurrencyExchangeRate] ([AccountCurrencyExchangeRateId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExchangeRateEffectiveStartDate]
    ON [dbo].[AccountCurrencyExchangeRate]([ExchangeRateEffectiveStartDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExchangeRateEffectiveEndDate]
    ON [dbo].[AccountCurrencyExchangeRate]([ExchangeRateEffectiveEndDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MasterAccountCurrencyExchangeRateId]
    ON [dbo].[AccountCurrencyExchangeRate]([MasterAccountCurrencyExchangeRateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountCurrencyExchangeRate]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountCurrencyId]
    ON [dbo].[AccountCurrencyExchangeRate]([AccountCurrencyId] ASC);


GO
CREATE STATISTICS [_dta_stat_1392060045_1_4]
    ON [dbo].[AccountCurrencyExchangeRate]([AccountCurrencyExchangeRateId], [ExchangeRate]);


GO
CREATE STATISTICS [_dta_stat_1392060045_2_1]
    ON [dbo].[AccountCurrencyExchangeRate]([ExchangeRateEffectiveStartDate], [AccountCurrencyExchangeRateId]);

