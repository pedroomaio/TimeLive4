CREATE TABLE [dbo].[MasterAccountExpenseTypeTaxCode] (
    [MasterAccountExpenseTypeTaxCodeId] SMALLINT NOT NULL,
    [MasterAccountExpenseTypeId]        SMALLINT NOT NULL,
    [MasterAccountTaxZoneId]            SMALLINT NOT NULL,
    [MasterAccountTaxCodeId]            SMALLINT NOT NULL,
    CONSTRAINT [PK_MasterAccountExpenseTypeTaxCode] PRIMARY KEY CLUSTERED ([MasterAccountExpenseTypeTaxCodeId] ASC)
);

