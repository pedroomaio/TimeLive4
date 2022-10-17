CREATE TABLE [dbo].[MasterAccountCurrency] (
    [MasterAccountCurrencyId]             SMALLINT NOT NULL,
    [MasterAccountCurrencyExchangeRateId] SMALLINT NOT NULL,
    [SystemCurrencyId]                    INT      NOT NULL,
    CONSTRAINT [PK_MasterAccountCurrency] PRIMARY KEY CLUSTERED ([MasterAccountCurrencyId] ASC)
);

