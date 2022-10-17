CREATE TABLE [dbo].[SystemInvoiceBillingType] (
    [InvoiceBillingTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemInvoiceBillingType_InvoiceBillingTypeId] DEFAULT (newid()) NOT NULL,
    [InvoiceBillingType]   NVARCHAR (50)    NULL,
    CONSTRAINT [PK_SystemInvoiceBillingType] PRIMARY KEY CLUSTERED ([InvoiceBillingTypeId] ASC)
);

