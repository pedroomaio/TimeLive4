CREATE TABLE [dbo].[AccountModuleFields] (
    [AccountModuleFieldId]   UNIQUEIDENTIFIER CONSTRAINT [DF_AccountModuleField_AccountModuleFieldId] DEFAULT (newid()) NOT NULL,
    [AccountModuleFieldName] NVARCHAR (200)   NOT NULL,
    [SystemModuleFieldId]    UNIQUEIDENTIFIER NOT NULL,
    [AccountModuleViewId]    UNIQUEIDENTIFIER NULL,
    [AccountId]              INT              NOT NULL,
    [AccountEmployeeId]      INT              NOT NULL,
    [SortOrder]              INT              NOT NULL,
    [CreatedOn]              DATETIME         NULL,
    [CreatedBy]              INT              NULL,
    [ModifiedOn]             DATETIME         NULL,
    [ModifiedBy]             INT              NULL,
    CONSTRAINT [PK_AccountModuleField] PRIMARY KEY CLUSTERED ([AccountModuleFieldId] ASC)
);

