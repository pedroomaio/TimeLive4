CREATE TABLE [dbo].[AccountPriority] (
    [AccountPriorityId] INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]         INT            NOT NULL,
    [Priority]          NVARCHAR (100) NOT NULL,
    [PriorityOrder]     TINYINT        NOT NULL,
    [IsDisabled]        BIT            CONSTRAINT [DF_AccountPriority_IsDisabled_1] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountPriority] PRIMARY KEY CLUSTERED ([AccountPriorityId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountPriority_10_1207063436__K1_3]
    ON [dbo].[AccountPriority]([AccountPriorityId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PriorityOrder]
    ON [dbo].[AccountPriority]([PriorityOrder] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountPriority]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_1207063436_2_1_5_4]
    ON [dbo].[AccountPriority]([AccountId], [AccountPriorityId], [IsDisabled], [PriorityOrder]);


GO
CREATE STATISTICS [_dta_stat_1207063436_4_1_2]
    ON [dbo].[AccountPriority]([PriorityOrder], [AccountPriorityId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1207063436_1_5_4]
    ON [dbo].[AccountPriority]([AccountPriorityId], [IsDisabled], [PriorityOrder]);


GO
CREATE STATISTICS [_dta_stat_1207063436_2_5]
    ON [dbo].[AccountPriority]([AccountId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1207063436_3_1]
    ON [dbo].[AccountPriority]([Priority], [AccountPriorityId]);

