CREATE TABLE [dbo].[AccountApprovalPath] (
    [AccountApprovalPathId]       INT      IDENTITY (1, 1) NOT NULL,
    [AccountId]                   INT      NOT NULL,
    [AccountApprovalTypeId]       INT      NOT NULL,
    [SystemApproverTypeId]        SMALLINT NOT NULL,
    [AccountExternalUserId]       INT      NULL,
    [AccountEmployeeId]           INT      NULL,
    [ApprovalPathSequence]        TINYINT  NOT NULL,
    [MasterAccountApprovalPathId] SMALLINT NULL,
    CONSTRAINT [PK_AccountApproverPath] PRIMARY KEY CLUSTERED ([AccountApprovalPathId] ASC),
    CONSTRAINT [FK_AccountApprovalPath_AccountApprovalType] FOREIGN KEY ([AccountApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_AccountApprovalPath_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountApprovalPath_AccountEmployee1] FOREIGN KEY ([AccountExternalUserId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountApprovalPath_SystemApproverType] FOREIGN KEY ([SystemApproverTypeId]) REFERENCES [dbo].[SystemApproverType] ([SystemApproverTypeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountApprovalPath]([AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountExternalUserId]
    ON [dbo].[AccountApprovalPath]([AccountExternalUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountApprovalTypeId]
    ON [dbo].[AccountApprovalPath]([AccountApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountApprovalPath]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_641437359_7_3_1_5_4]
    ON [dbo].[AccountApprovalPath]([ApprovalPathSequence], [AccountApprovalTypeId], [AccountApprovalPathId], [AccountExternalUserId], [SystemApproverTypeId]);


GO
CREATE STATISTICS [_dta_stat_641437359_3_7_1_6_4]
    ON [dbo].[AccountApprovalPath]([AccountApprovalTypeId], [ApprovalPathSequence], [AccountApprovalPathId], [AccountEmployeeId], [SystemApproverTypeId]);


GO
CREATE STATISTICS [_dta_stat_641437359_1_3_6_4]
    ON [dbo].[AccountApprovalPath]([AccountApprovalPathId], [AccountApprovalTypeId], [AccountEmployeeId], [SystemApproverTypeId]);


GO
CREATE STATISTICS [_dta_stat_641437359_1_6_4_7]
    ON [dbo].[AccountApprovalPath]([AccountApprovalPathId], [AccountEmployeeId], [SystemApproverTypeId], [ApprovalPathSequence]);


GO
CREATE STATISTICS [_dta_stat_641437359_3_1_5_4]
    ON [dbo].[AccountApprovalPath]([AccountApprovalTypeId], [AccountApprovalPathId], [AccountExternalUserId], [SystemApproverTypeId]);


GO
CREATE STATISTICS [_dta_stat_641437359_1_5_4_7]
    ON [dbo].[AccountApprovalPath]([AccountApprovalPathId], [AccountExternalUserId], [SystemApproverTypeId], [ApprovalPathSequence]);


GO
CREATE STATISTICS [_dta_stat_641437359_1_4_7_3]
    ON [dbo].[AccountApprovalPath]([AccountApprovalPathId], [SystemApproverTypeId], [ApprovalPathSequence], [AccountApprovalTypeId]);


GO
CREATE STATISTICS [_dta_stat_641437359_3_1_4]
    ON [dbo].[AccountApprovalPath]([AccountApprovalTypeId], [AccountApprovalPathId], [SystemApproverTypeId]);


GO
CREATE STATISTICS [_dta_stat_641437359_5_4_7]
    ON [dbo].[AccountApprovalPath]([AccountExternalUserId], [SystemApproverTypeId], [ApprovalPathSequence]);


GO
CREATE STATISTICS [_dta_stat_641437359_6_4_7]
    ON [dbo].[AccountApprovalPath]([AccountEmployeeId], [SystemApproverTypeId], [ApprovalPathSequence]);

