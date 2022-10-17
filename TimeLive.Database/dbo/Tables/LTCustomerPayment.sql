CREATE TABLE [dbo].[LTCustomerPayment] (
    [AccountPaymentDetailId] INT           IDENTITY (1, 1) NOT NULL,
    [HostedAccountId]        INT           NULL,
    [CustomerId]             INT           NULL,
    [TimeStamp]              DATETIME      CONSTRAINT [DF_SystemPayment_TimeStamp] DEFAULT (getdate()) NOT NULL,
    [OrderNumber]            VARCHAR (50)  NOT NULL,
    [OrderDate]              SMALLDATETIME NOT NULL,
    [Status]                 VARCHAR (10)  NOT NULL,
    [OrderAmount]            INT           NOT NULL,
    [FirstName]              VARCHAR (100) NOT NULL,
    [LastName]               VARCHAR (100) NOT NULL,
    [Address1]               VARCHAR (200) NULL,
    [Address2]               VARCHAR (200) NULL,
    [City]                   VARCHAR (50)  NULL,
    [State]                  VARCHAR (50)  NULL,
    [Country]                VARCHAR (50)  NULL,
    [PostalCode]             VARCHAR (30)  NULL,
    [Phone]                  VARCHAR (50)  NULL,
    [PackageTypeId]          TINYINT       NULL,
    [SerialNumber]           VARCHAR (50)  NOT NULL,
    [Quantity]               INT           NULL,
    [Price]                  INT           NULL,
    CONSTRAINT [PK_SystemPayment] PRIMARY KEY CLUSTERED ([AccountPaymentDetailId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderNumbe]
    ON [dbo].[LTCustomerPayment]([OrderNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PackageTypeId]
    ON [dbo].[LTCustomerPayment]([PackageTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_HostedAccountId]
    ON [dbo].[LTCustomerPayment]([HostedAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LTCustomerPayment]
    ON [dbo].[LTCustomerPayment]([CustomerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPaymentDetailId]
    ON [dbo].[LTCustomerPayment]([AccountPaymentDetailId] ASC);

