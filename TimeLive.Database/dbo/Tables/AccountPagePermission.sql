CREATE TABLE [dbo].[AccountPagePermission] (
    [AccountPagePermissionId]      BIGINT   IDENTITY (1, 1) NOT NULL,
    [AccountId]                    INT      NOT NULL,
    [AccountRoleId]                INT      NOT NULL,
    [SystemSecurityCategoryPageId] INT      NOT NULL,
    [SystemPermissionId]           INT      NULL,
    [ShowAllData]                  BIT      NULL,
    [ShowMyData]                   BIT      NULL,
    [ShowMyProjectsData]           BIT      NULL,
    [ShowMyTeamsData]              BIT      NULL,
    [TillDate]                     DATETIME NULL,
    [TillHours]                    INT      NULL,
    [ShowMySubOrdinatesData]       BIT      NULL,
    CONSTRAINT [PK_AccountPagePermission] PRIMARY KEY CLUSTERED ([AccountPagePermissionId] ASC),
    CONSTRAINT [FK_AccountPagePermission_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountPagePermission_AccountRole] FOREIGN KEY ([AccountRoleId]) REFERENCES [dbo].[AccountRole] ([AccountRoleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountPagePermission_SystemPermission] FOREIGN KEY ([SystemPermissionId]) REFERENCES [dbo].[SystemPermission] ([SystemPermissionId]),
    CONSTRAINT [FK_AccountPagePermission_SystemSecurityCategoryPage] FOREIGN KEY ([SystemSecurityCategoryPageId]) REFERENCES [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountPagePermission_5_936390405__K2_1_3_4_5_6_7_8_9_10_11]
    ON [dbo].[AccountPagePermission]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPagePermission_SystemSecurityCategoryPageId]
    ON [dbo].[AccountPagePermission]([SystemSecurityCategoryPageId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPagePermission_SystemPermissionId]
    ON [dbo].[AccountPagePermission]([SystemPermissionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPagePermission_AccountRoleId]
    ON [dbo].[AccountPagePermission]([AccountRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPagePermission_AccountId]
    ON [dbo].[AccountPagePermission]([AccountId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountPagePermission]
    ON [dbo].[AccountPagePermission]([AccountId] ASC, [AccountRoleId] ASC, [SystemSecurityCategoryPageId] ASC, [SystemPermissionId] ASC);


GO
CREATE STATISTICS [_dta_stat_936390405_2_1_3_4_5]
    ON [dbo].[AccountPagePermission]([AccountId], [AccountPagePermissionId], [AccountRoleId], [SystemSecurityCategoryPageId], [SystemPermissionId]);


GO
CREATE STATISTICS [_dta_stat_936390405_2_3_4_1]
    ON [dbo].[AccountPagePermission]([AccountId], [AccountRoleId], [SystemSecurityCategoryPageId], [AccountPagePermissionId]);


GO
CREATE STATISTICS [_dta_stat_936390405_1_3_4_5]
    ON [dbo].[AccountPagePermission]([AccountPagePermissionId], [AccountRoleId], [SystemSecurityCategoryPageId], [SystemPermissionId]);


GO
CREATE STATISTICS [_dta_stat_936390405_1_2_3]
    ON [dbo].[AccountPagePermission]([AccountPagePermissionId], [AccountId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_936390405_4_2]
    ON [dbo].[AccountPagePermission]([SystemSecurityCategoryPageId], [AccountId]);

