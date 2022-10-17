CREATE TABLE [dbo].[AccountPaymentMethod] (
    [AccountPaymentMethodId] INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]              INT            NOT NULL,
    [PaymentMethod]          NVARCHAR (100) NOT NULL,
    [MasterPaymentMethodId]  SMALLINT       NULL,
    [IsDisabled]             BIT            NOT NULL,
    CONSTRAINT [PK_AccountPaymentMethod] PRIMARY KEY CLUSTERED ([AccountPaymentMethodId] ASC),
    CONSTRAINT [FK_AccountPaymentMethod_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountPaymentMethod_MasterPaymentMethod] FOREIGN KEY ([MasterPaymentMethodId]) REFERENCES [dbo].[MasterPaymentMethod] ([MasterPaymentMethodId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountPaymentMethod]
    ON [dbo].[AccountPaymentMethod]([AccountId] ASC, [PaymentMethod] ASC);


GO
CREATE STATISTICS [_dta_stat_1031062809_2_5_1]
    ON [dbo].[AccountPaymentMethod]([AccountId], [IsDisabled], [AccountPaymentMethodId]);


GO
CREATE STATISTICS [_dta_stat_1031062809_1_5]
    ON [dbo].[AccountPaymentMethod]([AccountPaymentMethodId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1031062809_2_1]
    ON [dbo].[AccountPaymentMethod]([AccountId], [AccountPaymentMethodId]);

