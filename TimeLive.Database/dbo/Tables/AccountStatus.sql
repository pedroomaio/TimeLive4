CREATE TABLE [dbo].[AccountStatus] (
    [AccountStatusId]       INT           IDENTITY (1, 1) NOT NULL,
    [AccountId]             INT           NOT NULL,
    [StatusTypeId]          INT           NOT NULL,
    [Status]                NVARCHAR (90) NOT NULL,
    [IsDisabled]            BIT           CONSTRAINT [DF_AccountStatus_IsDisabled] DEFAULT ((0)) NOT NULL,
    [MasterAccountStatusId] INT           NULL,
    CONSTRAINT [PK_AccountStatus] PRIMARY KEY CLUSTERED ([AccountStatusId] ASC),
    CONSTRAINT [FK_AccountStatus_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountStatus_5_2102402659__K1_4]
    ON [dbo].[AccountStatus]([AccountStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountStatus_5_2102402659__K2_K1_K3_4_5]
    ON [dbo].[AccountStatus]([AccountId] ASC, [AccountStatusId] ASC, [StatusTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StatusTypeId]
    ON [dbo].[AccountStatus]([StatusTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountStatus]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_2102402659_1_2_3_5_6]
    ON [dbo].[AccountStatus]([AccountStatusId], [AccountId], [StatusTypeId], [IsDisabled], [MasterAccountStatusId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_6_1_2_3]
    ON [dbo].[AccountStatus]([MasterAccountStatusId], [AccountStatusId], [AccountId], [StatusTypeId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_3_1_5_6]
    ON [dbo].[AccountStatus]([StatusTypeId], [AccountStatusId], [IsDisabled], [MasterAccountStatusId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_2_1_3_5]
    ON [dbo].[AccountStatus]([AccountId], [AccountStatusId], [StatusTypeId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_2102402659_5_1_6]
    ON [dbo].[AccountStatus]([IsDisabled], [AccountStatusId], [MasterAccountStatusId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_3_1_6]
    ON [dbo].[AccountStatus]([StatusTypeId], [AccountStatusId], [MasterAccountStatusId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_2_3_5]
    ON [dbo].[AccountStatus]([AccountId], [StatusTypeId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_2102402659_2_3_1]
    ON [dbo].[AccountStatus]([AccountId], [StatusTypeId], [AccountStatusId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_4_1]
    ON [dbo].[AccountStatus]([Status], [AccountStatusId]);


GO
CREATE STATISTICS [_dta_stat_2102402659_1_3]
    ON [dbo].[AccountStatus]([AccountStatusId], [StatusTypeId]);

