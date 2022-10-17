CREATE TABLE [dbo].[AccountTaskType] (
    [AccountTaskTypeId]       INT            IDENTITY (1, 1) NOT NULL,
    [TaskType]                NVARCHAR (100) NOT NULL,
    [AccountId]               INT            NOT NULL,
    [CreatedOn]               DATETIME       CONSTRAINT [DF_AccountTaskType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]     INT            NOT NULL,
    [ModifiedOn]              DATETIME       CONSTRAINT [DF_AccountTaskType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]    INT            NOT NULL,
    [MasterAccountTaskTypeId] SMALLINT       NULL,
    [IsDisabled]              BIT            CONSTRAINT [DF_AccountTaskType_IsDisabled_1] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tblTaskType] PRIMARY KEY CLUSTERED ([AccountTaskTypeId] ASC),
    CONSTRAINT [FK_AccountTaskType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountTaskType_5_371584462__K1_2]
    ON [dbo].[AccountTaskType]([AccountTaskTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountTaskType]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_371584462_3_9_1_2]
    ON [dbo].[AccountTaskType]([AccountId], [IsDisabled], [AccountTaskTypeId], [TaskType]);


GO
CREATE STATISTICS [_dta_stat_371584462_2_1_3]
    ON [dbo].[AccountTaskType]([TaskType], [AccountTaskTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_371584462_9_1_2]
    ON [dbo].[AccountTaskType]([IsDisabled], [AccountTaskTypeId], [TaskType]);


GO
CREATE STATISTICS [_dta_stat_371584462_1_3]
    ON [dbo].[AccountTaskType]([AccountTaskTypeId], [AccountId]);

