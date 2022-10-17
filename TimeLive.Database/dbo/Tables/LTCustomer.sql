CREATE TABLE [dbo].[LTCustomer] (
    [CustomerId]            INT           IDENTITY (1, 1) NOT NULL,
    [AccountId]             INT           NULL,
    [CustomerName]          VARCHAR (250) NULL,
    [Prefix]                VARCHAR (4)   NULL,
    [FirstName]             VARCHAR (50)  NULL,
    [MiddleName]            VARCHAR (20)  NULL,
    [LastName]              VARCHAR (50)  NULL,
    [Address1]              VARCHAR (250) NULL,
    [Address2]              VARCHAR (250) NULL,
    [ZipCode]               VARCHAR (50)  NULL,
    [State]                 VARCHAR (50)  NULL,
    [City]                  VARCHAR (50)  NULL,
    [CountryId]             SMALLINT      NULL,
    [EMailAddress]          VARCHAR (50)  NULL,
    [Telephone]             VARCHAR (50)  NULL,
    [Fax]                   VARCHAR (50)  NULL,
    [CustomerRequestTypeId] TINYINT       NULL,
    [CreatedOn]             DATETIME      CONSTRAINT [DF_LTCustomer_CreatedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[LTCustomer]([AccountId] ASC);

