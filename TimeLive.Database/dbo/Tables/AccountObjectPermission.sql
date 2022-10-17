CREATE TABLE [dbo].[AccountObjectPermission] (
    [AccountObjectPermissionId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReportPermission_AccountReportPermissionId] DEFAULT (newid()) NOT NULL,
    [AccountReportId]           UNIQUEIDENTIFIER NOT NULL,
    [AccountRoleId]             INT              NOT NULL,
    [AccountId]                 INT              NOT NULL,
    [ShowReport]                BIT              CONSTRAINT [DF_AccountReportPermission_ShowReport] DEFAULT ((0)) NOT NULL,
    [AllowCustomization]        BIT              CONSTRAINT [DF_AccountReportPermission_AllowCustomization] DEFAULT ((0)) NOT NULL,
    [AllowAllUser]              BIT              CONSTRAINT [DF_AccountReportPermission_AllowAllUser] DEFAULT ((0)) NOT NULL,
    [AllowOwnReport]            BIT              CONSTRAINT [DF_AccountReportPermission_AllowOwnReport] DEFAULT ((0)) NOT NULL,
    [AllowOwnTeam]              BIT              CONSTRAINT [DF_AccountReportPermission_AllowOwnTeam] DEFAULT ((0)) NOT NULL,
    [AllowOwnProject]           BIT              CONSTRAINT [DF_AccountReportPermission_AllowOwnProject] DEFAULT ((0)) NOT NULL,
    [AllowOwnSubOrdinates]      BIT              CONSTRAINT [DF_AccountReportPermission_AllowOwnSubOrdinates] DEFAULT ((0)) NOT NULL,
    [AllowOwnApproval]          BIT              CONSTRAINT [DF_AccountObjectPermission_AllowOwnApproval] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_AccountReportPermission] PRIMARY KEY CLUSTERED ([AccountObjectPermissionId] ASC),
    CONSTRAINT [FK_AccountObjectPermission_AccountReport] FOREIGN KEY ([AccountReportId]) REFERENCES [dbo].[AccountReport] ([AccountReportId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountObjectPermission_5_318064319__K3_K2_K1_4_5_6_7_8_9_10_11_12]
    ON [dbo].[AccountObjectPermission]([AccountRoleId] ASC, [AccountReportId] ASC, [AccountObjectPermissionId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountObjectPermission]
    ON [dbo].[AccountObjectPermission]([AccountReportId] ASC, [AccountRoleId] ASC, [AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_318064319_3_1_2_10]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountObjectPermissionId], [AccountReportId], [AllowOwnProject]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_3_2_12]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountRoleId], [AccountReportId], [AllowOwnApproval]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_1_2_11]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountObjectPermissionId], [AccountReportId], [AllowOwnSubOrdinates]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_1_2_7]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountObjectPermissionId], [AccountReportId], [AllowAllUser]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_3_2_8]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountRoleId], [AccountReportId], [AllowOwnReport]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_3_2_9]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountRoleId], [AccountReportId], [AllowOwnTeam]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_2_8]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountReportId], [AllowOwnReport]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_2_7]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountReportId], [AllowAllUser]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_2_8]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountReportId], [AllowOwnReport]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_2_7]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountReportId], [AllowAllUser]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_2_9]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountReportId], [AllowOwnTeam]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_2_10]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountReportId], [AllowOwnProject]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_2_12]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountReportId], [AllowOwnApproval]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_2_11]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountReportId], [AllowOwnSubOrdinates]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_2_10]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountReportId], [AllowOwnProject]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_2_11]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountReportId], [AllowOwnSubOrdinates]);


GO
CREATE STATISTICS [_dta_stat_318064319_2_1_3]
    ON [dbo].[AccountObjectPermission]([AccountReportId], [AccountObjectPermissionId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_2_12]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AccountReportId], [AllowOwnApproval]);


GO
CREATE STATISTICS [_dta_stat_318064319_3_2_9]
    ON [dbo].[AccountObjectPermission]([AccountRoleId], [AccountReportId], [AllowOwnTeam]);


GO
CREATE STATISTICS [_dta_stat_318064319_9_1]
    ON [dbo].[AccountObjectPermission]([AllowOwnTeam], [AccountObjectPermissionId]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_11]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AllowOwnSubOrdinates]);


GO
CREATE STATISTICS [_dta_stat_318064319_8_1]
    ON [dbo].[AccountObjectPermission]([AllowOwnReport], [AccountObjectPermissionId]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_7]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AllowAllUser]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_12]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AllowOwnApproval]);


GO
CREATE STATISTICS [_dta_stat_318064319_1_10]
    ON [dbo].[AccountObjectPermission]([AccountObjectPermissionId], [AllowOwnProject]);

