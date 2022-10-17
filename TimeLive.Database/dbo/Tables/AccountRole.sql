CREATE TABLE [dbo].[AccountRole] (
    [AccountRoleId]        INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]            INT            NOT NULL,
    [Role]                 NVARCHAR (50)  NOT NULL,
    [IsDisabled]           BIT            CONSTRAINT [DF_AccountRole_IsDisabled] DEFAULT ((0)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_AccountRole_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]            DATETIME       CONSTRAINT [DF_AccountRole_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]  INT            NOT NULL,
    [ModifiedOn]           DATETIME       CONSTRAINT [DF_AccountRole_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId] INT            NOT NULL,
    [MasterAccountRoleId]  SMALLINT       NULL,
    [LDAPRole]             NVARCHAR (200) NULL,
    [DefaultAccountPageId] INT            NULL,
    CONSTRAINT [PK_AccountRole] PRIMARY KEY CLUSTERED ([AccountRoleId] ASC),
    CONSTRAINT [FK_AccountRole_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountRole_5_115583550__K1_3_10]
    ON [dbo].[AccountRole]([AccountRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountRole_5_115583550__K2_K3_K1_4_5_6_7_8_9_10_11_12]
    ON [dbo].[AccountRole]([AccountId] ASC, [Role] ASC, [AccountRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountRole]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_115583550_3_1_10_2_4]
    ON [dbo].[AccountRole]([Role], [AccountRoleId], [MasterAccountRoleId], [AccountId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_115583550_2_4_1_3]
    ON [dbo].[AccountRole]([AccountId], [IsDisabled], [AccountRoleId], [Role]);


GO
CREATE STATISTICS [_dta_stat_115583550_2_10_1_4]
    ON [dbo].[AccountRole]([AccountId], [MasterAccountRoleId], [AccountRoleId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_115583550_10_1_4_3]
    ON [dbo].[AccountRole]([MasterAccountRoleId], [AccountRoleId], [IsDisabled], [Role]);


GO
CREATE STATISTICS [_dta_stat_115583550_4_1_3]
    ON [dbo].[AccountRole]([IsDisabled], [AccountRoleId], [Role]);


GO
CREATE STATISTICS [_dta_stat_115583550_2_1]
    ON [dbo].[AccountRole]([AccountId], [AccountRoleId]);

