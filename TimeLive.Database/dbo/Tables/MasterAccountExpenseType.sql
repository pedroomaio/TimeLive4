CREATE TABLE [dbo].[MasterAccountExpenseType] (
    [MasterAccountExpenseId] SMALLINT       NOT NULL,
    [TemplateId]             SMALLINT       NOT NULL,
    [ExpenseType]            NVARCHAR (100) NOT NULL,
    [IsShowQuantityField]    BIT            NULL,
    [QuantityFieldCaption]   NVARCHAR (100) NULL,
    [IsInputTax]             BIT            NULL,
    [TaxFieldCaption]        NVARCHAR (100) NULL,
    [MasterTaxCodeId]        SMALLINT       NULL,
    CONSTRAINT [PK_MasterAccountExpenseType] PRIMARY KEY CLUSTERED ([MasterAccountExpenseId] ASC)
);

