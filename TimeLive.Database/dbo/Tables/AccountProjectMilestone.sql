CREATE TABLE [dbo].[AccountProjectMilestone] (
    [AccountProjectMilestoneId]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [AccountId]                         INT            NOT NULL,
    [AccountProjectId]                  INT            NOT NULL,
    [MilestoneDescription]              NVARCHAR (500) NOT NULL,
    [MilestoneDate]                     SMALLDATETIME  NOT NULL,
    [CreatedOn]                         DATETIME       NULL,
    [CreatedByEmployeeId]               INT            NULL,
    [ModifiedOn]                        DATETIME       NULL,
    [ModifiedByEmployeeId]              INT            NULL,
    [AccountProjectMilestoneTemplateId] BIGINT         NULL,
    [Comments]                          NVARCHAR (500) NULL,
    [Completed]                         BIT            NULL,
    [IsDisabled]                        BIT            NULL,
    CONSTRAINT [PK_AccountProjectMilestone] PRIMARY KEY CLUSTERED ([AccountProjectMilestoneId] ASC),
    CONSTRAINT [FK_AccountProjectMilestone_Account1] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountProjectMilestone_AccountProject1] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProjectMilestone_10_1638401006__K1_4]
    ON [dbo].[AccountProjectMilestone]([AccountProjectMilestoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountProjectMilestone]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountProjectMilestone]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_1638401006_3_1]
    ON [dbo].[AccountProjectMilestone]([AccountProjectId], [AccountProjectMilestoneId]);


GO
CREATE STATISTICS [_dta_stat_1638401006_4_1]
    ON [dbo].[AccountProjectMilestone]([MilestoneDescription], [AccountProjectMilestoneId]);

