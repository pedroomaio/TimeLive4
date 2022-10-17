CREATE TABLE [dbo].[SystemCurrency] (
    [CurrencyId]   SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CurrencyCode] NVARCHAR (10)  NOT NULL,
    [Currency]     NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED ([CurrencyId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemCurrency]
    ON [dbo].[SystemCurrency]([CurrencyId] ASC);


GO
CREATE STATISTICS [_dta_stat_1635588965_2_3_1]
    ON [dbo].[SystemCurrency]([CurrencyCode], [Currency], [CurrencyId]);


GO
CREATE STATISTICS [_dta_stat_1635588965_1_3]
    ON [dbo].[SystemCurrency]([CurrencyId], [Currency]);


GO
CREATE STATISTICS [_dta_stat_1635588965_2_1]
    ON [dbo].[SystemCurrency]([CurrencyCode], [CurrencyId]);

