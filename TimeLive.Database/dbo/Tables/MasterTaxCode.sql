CREATE TABLE [dbo].[MasterTaxCode] (
    [MasterTaxCodeId] SMALLINT       NOT NULL,
    [TaxCode]         NVARCHAR (100) NOT NULL,
    [Formula]         NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_MasterTaxCode] PRIMARY KEY CLUSTERED ([MasterTaxCodeId] ASC)
);

