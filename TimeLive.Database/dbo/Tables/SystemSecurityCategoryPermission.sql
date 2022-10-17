CREATE TABLE [dbo].[SystemSecurityCategoryPermission] (
    [SystemSecurityCategoryPermissionId] INT      NOT NULL,
    [SystemSecurityCategoryId]           INT      NOT NULL,
    [SystemPermissionId]                 INT      NOT NULL,
    [ShowMyData]                         BIT      NULL,
    [ShowMyTeamsData]                    BIT      NULL,
    [ShowMyProjectsData]                 BIT      NULL,
    [ShowAllData]                        BIT      NULL,
    [TillDate]                           DATETIME NULL,
    [TillHours]                          INT      NULL,
    CONSTRAINT [PK_SystemSecurityCategoryPermission] PRIMARY KEY CLUSTERED ([SystemSecurityCategoryPermissionId] ASC),
    CONSTRAINT [FK_SystemSecurityCategoryPermission_SystemPermission] FOREIGN KEY ([SystemPermissionId]) REFERENCES [dbo].[SystemPermission] ([SystemPermissionId]),
    CONSTRAINT [FK_SystemSecurityCategoryPermission_SystemSecurityCategory] FOREIGN KEY ([SystemSecurityCategoryId]) REFERENCES [dbo].[SystemSecurityCategory] ([SystemSecurityCategoryId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryPermission_SystemSecurityCategoryId]
    ON [dbo].[SystemSecurityCategoryPermission]([SystemSecurityCategoryId] ASC);

