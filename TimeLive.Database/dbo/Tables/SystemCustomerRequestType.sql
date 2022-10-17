CREATE TABLE [dbo].[SystemCustomerRequestType] (
    [CustomerRequestTypeId] TINYINT        NOT NULL,
    [CustomerRequestType]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CustomerRequest] PRIMARY KEY CLUSTERED ([CustomerRequestTypeId] ASC)
);

