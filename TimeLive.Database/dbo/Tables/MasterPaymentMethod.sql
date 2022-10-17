CREATE TABLE [dbo].[MasterPaymentMethod] (
    [MasterPaymentMethodId] SMALLINT      NOT NULL,
    [PaymentMethod]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SystemPaymentMethod] PRIMARY KEY CLUSTERED ([MasterPaymentMethodId] ASC)
);

