CREATE TABLE [dbo].[MasterAccountRole] (
    [MasterAccountRoleId] SMALLINT       NOT NULL,
    [TemplateId]          SMALLINT       NOT NULL,
    [Role]                NVARCHAR (100) NOT NULL,
    [IsSystemRole]        BIT            NULL,
    [LDAPGroup]           NVARCHAR (100) NULL,
    CONSTRAINT [PK_MasterAccountRole] PRIMARY KEY CLUSTERED ([MasterAccountRoleId] ASC)
);

