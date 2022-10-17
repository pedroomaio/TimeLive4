CREATE TABLE [dbo].[AccountType] (
    [AccountTypeId] SMALLINT       IDENTITY (1, 1) NOT NULL,
    [AccountType]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblCompanyType] PRIMARY KEY CLUSTERED ([AccountTypeId] ASC)
);

