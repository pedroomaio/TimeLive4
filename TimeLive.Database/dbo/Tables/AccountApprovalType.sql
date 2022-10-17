CREATE TABLE [dbo].[AccountApprovalType] (
    [AccountApprovalTypeId]       INT            IDENTITY (1, 1) NOT NULL,
    [ApprovalTypeName]            NVARCHAR (200) NOT NULL,
    [AccountId]                   INT            NOT NULL,
    [MasterAccountApprovalTypeId] SMALLINT       NULL,
    [IsTimeOffApprovalTypes]      BIT            CONSTRAINT [DF_AccountApprovalType_IsTimeOffApprovalTypes] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountApproverType] PRIMARY KEY CLUSTERED ([AccountApprovalTypeId] ASC),
    CONSTRAINT [FK_AccountApprovalType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountApprovalType]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_1210539446_1_3]
    ON [dbo].[AccountApprovalType]([AccountApprovalTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1210539446_1_2]
    ON [dbo].[AccountApprovalType]([AccountApprovalTypeId], [ApprovalTypeName]);

