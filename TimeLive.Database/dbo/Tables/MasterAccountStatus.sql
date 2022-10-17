CREATE TABLE [dbo].[MasterAccountStatus] (
    [MasterAccountStatusId] INT            NOT NULL,
    [AccountTemplateId]     INT            NOT NULL,
    [StatusTypeId]          INT            NOT NULL,
    [Status]                NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MasterAccountStatus] PRIMARY KEY CLUSTERED ([MasterAccountStatusId] ASC)
);

