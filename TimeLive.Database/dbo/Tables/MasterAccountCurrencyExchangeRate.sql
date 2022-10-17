CREATE TABLE [dbo].[MasterAccountCurrencyExchangeRate] (
    [MasterAccountCurrencyExchangeRateId] SMALLINT NOT NULL,
    [ExchangeRateEffectiveStartDate]      DATETIME NULL,
    [ExchangeRateEffectiveEndDate]        DATETIME NULL,
    [ExchangeRate]                        MONEY    NOT NULL,
    [MasterAccountCurrencyId]             SMALLINT NULL,
    CONSTRAINT [PK_MasterAccountCurrencyExchangeRate] PRIMARY KEY CLUSTERED ([MasterAccountCurrencyExchangeRateId] ASC)
);

