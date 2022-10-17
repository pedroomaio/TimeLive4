CREATE TABLE [dbo].[SystemSecurityCategoryMasterAccountRole] (
    [SystemSecurityCategoryMasterAccountRoleId] SMALLINT NOT NULL,
    [SystemSecurityCategoryId]                  INT      NULL,
    [MasterRoleId]                              SMALLINT NOT NULL,
    [ShowAllData]                               BIT      NULL,
    [ShowMyData]                                BIT      NULL,
    [ShowMyProjectsData]                        BIT      NULL,
    [ShowMyTeamsData]                           BIT      NULL,
    [ShowClientData]                            BIT      NULL,
    [ShowMySubOrdinatesData]                    BIT      NULL,
    CONSTRAINT [PK_SystemSecurityCategoryMasterAccountRole] PRIMARY KEY CLUSTERED ([SystemSecurityCategoryMasterAccountRoleId] ASC),
    CONSTRAINT [FK_SystemSecurityCategoryMasterAccountRole_MasterAccountRole] FOREIGN KEY ([MasterRoleId]) REFERENCES [dbo].[MasterAccountRole] ([MasterAccountRoleId]),
    CONSTRAINT [FK_SystemSecurityCategoryMasterAccountRole_SystemSecurityCategoryMasterAccountRole] FOREIGN KEY ([SystemSecurityCategoryId]) REFERENCES [dbo].[SystemSecurityCategory] ([SystemSecurityCategoryId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryMasterAccountRole_SystemSecurityCategoryId]
    ON [dbo].[SystemSecurityCategoryMasterAccountRole]([SystemSecurityCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryMasterAccountRole_MasterRoleId]
    ON [dbo].[SystemSecurityCategoryMasterAccountRole]([MasterRoleId] ASC);

