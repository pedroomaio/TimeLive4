CREATE TABLE [dbo].[AccountProjectTask] (
    [AccountProjectTaskId]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [AccountProjectId]             INT             NOT NULL,
    [ParentAccountProjectTaskId]   BIGINT          NULL,
    [TaskName]                     NVARCHAR (200)  NOT NULL,
    [TaskDescription]              NVARCHAR (4000) NOT NULL,
    [AccountTaskTypeId]            INT             NOT NULL,
    [Duration]                     DECIMAL (18, 2) NULL,
    [DurationUnit]                 NVARCHAR (20)   NULL,
    [DeadlineDate]                 SMALLDATETIME   NULL,
    [CompletedPercent]             FLOAT (53)      NULL,
    [Completed]                    BIT             CONSTRAINT [DF_AccountProjectTask_Completed] DEFAULT ((0)) NOT NULL,
    [IsParentTask]                 BIT             NULL,
    [IsForAllEmployees]            BIT             CONSTRAINT [DF_AccountProjectTask_IsForAllEmployees] DEFAULT ((0)) NULL,
    [AccountPriorityId]            INT             CONSTRAINT [DF_AccountProjectTask_AccountPriorityId] DEFAULT ((0)) NOT NULL,
    [TaskStatusId]                 INT             NULL,
    [AccountProjectMilestoneId]    BIGINT          CONSTRAINT [DF_AccountProjectTask_AccountProjectMilestoneId] DEFAULT ((0)) NOT NULL,
    [IsReOpen]                     BIT             CONSTRAINT [DF_AccountProjectTask_IsReOpen] DEFAULT ((0)) NOT NULL,
    [CreatedOn]                    DATETIME        NULL,
    [CreatedByEmployeeId]          INT             NULL,
    [ModifiedOn]                   DATETIME        NULL,
    [ModifiedByEmployeeId]         INT             NULL,
    [EstimatedCost]                FLOAT (53)      NULL,
    [EstimatedTimeSpent]           FLOAT (53)      NULL,
    [EstimatedTimeSpentUnit]       NVARCHAR (20)   NULL,
    [IsBillable]                   BIT             NULL,
    [IsDisabled]                   BIT             CONSTRAINT [DF_AccountProjectTask_IsDisabled] DEFAULT ((0)) NOT NULL,
    [AccountBillingRateId]         INT             NULL,
    [IsForAllProjectTask]          BIT             NULL,
    [TaskCode]                     NVARCHAR (30)   NULL,
    [AccountProjectTaskTemplateId] INT             NULL,
    [EstimatedCurrencyId]          INT             NULL,
    [StartDate]                    SMALLDATETIME   NULL,
    [Predecessors]                 NVARCHAR (50)   NULL,
    [CustomField1]                 NVARCHAR (2000) NULL,
    [CustomField2]                 NVARCHAR (2000) NULL,
    [CustomField3]                 NVARCHAR (2000) NULL,
    [CustomField4]                 NVARCHAR (2000) NULL,
    [CustomField5]                 NVARCHAR (2000) NULL,
    [CustomField6]                 NVARCHAR (2000) NULL,
    [CustomField7]                 NVARCHAR (2000) NULL,
    [CustomField8]                 NVARCHAR (2000) NULL,
    [CustomField9]                 NVARCHAR (2000) NULL,
    [CustomField10]                NVARCHAR (2000) NULL,
    [CustomField11]                NVARCHAR (2000) NULL,
    [CustomField12]                NVARCHAR (2000) NULL,
    [CustomField13]                NVARCHAR (2000) NULL,
    [CustomField14]                NVARCHAR (2000) NULL,
    [CustomField15]                NVARCHAR (2000) NULL,
    [FixedCost]                    FLOAT (53)      NULL,
    CONSTRAINT [PK_tblTask] PRIMARY KEY CLUSTERED ([AccountProjectTaskId] ASC),
    CONSTRAINT [FK_AccountProjectTask_AccountBillingRate] FOREIGN KEY ([AccountBillingRateId]) REFERENCES [dbo].[AccountBillingRate] ([AccountBillingRateId]),
    CONSTRAINT [FK_AccountProjectTask_AccountCurrency] FOREIGN KEY ([EstimatedCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]),
    CONSTRAINT [FK_AccountProjectTask_AccountPriority] FOREIGN KEY ([AccountPriorityId]) REFERENCES [dbo].[AccountPriority] ([AccountPriorityId]),
    CONSTRAINT [FK_AccountProjectTask_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]),
    CONSTRAINT [FK_AccountProjectTask_AccountProjectMilestone] FOREIGN KEY ([AccountProjectMilestoneId]) REFERENCES [dbo].[AccountProjectMilestone] ([AccountProjectMilestoneId]),
    CONSTRAINT [FK_AccountProjectTask_AccountProjectTask] FOREIGN KEY ([ParentAccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]),
    CONSTRAINT [FK_AccountProjectTask_AccountStatus] FOREIGN KEY ([TaskStatusId]) REFERENCES [dbo].[AccountStatus] ([AccountStatusId]),
    CONSTRAINT [FK_AccountProjectTask_AccountTaskType] FOREIGN KEY ([AccountTaskTypeId]) REFERENCES [dbo].[AccountTaskType] ([AccountTaskTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_DeadlineDate]
    ON [dbo].[AccountProjectTask]([DeadlineDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaskName]
    ON [dbo].[AccountProjectTask]([TaskName] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProjectTask_10_1004634722__K4_K1_K2_K13_K28_K12_K26_K11_3_5_6_7_8_9_10_14_15_16_17_18_19_20_21_29]
    ON [dbo].[AccountProjectTask]([TaskName] ASC, [AccountProjectTaskId] ASC, [AccountProjectId] ASC, [IsForAllEmployees] ASC, [IsForAllProjectTask] ASC, [IsParentTask] ASC, [IsDisabled] ASC, [Completed] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsBillable]
    ON [dbo].[AccountProjectTask]([IsBillable] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EstimatedCurrencyId]
    ON [dbo].[AccountProjectTask]([EstimatedCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProjectTask_10_851534117__K1]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaskStatusId]
    ON [dbo].[AccountProjectTask]([TaskStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ParentAccountProjectTaskId]
    ON [dbo].[AccountProjectTask]([ParentAccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ModifiedByEmployeeId]
    ON [dbo].[AccountProjectTask]([ModifiedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsReOpen]
    ON [dbo].[AccountProjectTask]([IsReOpen] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsParentTask]
    ON [dbo].[AccountProjectTask]([IsParentTask] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsForAllEmployees]
    ON [dbo].[AccountProjectTask]([IsForAllEmployees] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatedByEmployeeId]
    ON [dbo].[AccountProjectTask]([CreatedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Completed]
    ON [dbo].[AccountProjectTask]([Completed] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTaskTypeId]
    ON [dbo].[AccountProjectTask]([AccountTaskTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectMilestoneId]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountProjectTask]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPriorityId]
    ON [dbo].[AccountProjectTask]([AccountPriorityId] ASC);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_2_1_28_12_26_13_11_21_19_6_15_14_4]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [AccountProjectId], [AccountProjectTaskId], [IsForAllProjectTask], [IsParentTask], [IsDisabled], [IsForAllEmployees], [Completed], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_2_21_19_16_6_15_14_11_12_13_26_4]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [AccountProjectId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [Completed], [IsParentTask], [IsForAllEmployees], [IsDisabled], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_21_19_2_1_12_26_28_13_16_6_15_14_4]
    ON [dbo].[AccountProjectTask]([ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_21_1_19_16_6_15_14_11_12_26_13]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [ModifiedByEmployeeId], [AccountProjectTaskId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [Completed], [IsParentTask], [IsDisabled], [IsForAllEmployees]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_2_21_19_16_6_15_14_12_26_13_4]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [AccountProjectId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [IsParentTask], [IsDisabled], [IsForAllEmployees], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_1_28_12_26_13_14_11_21_19_16_6]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [AccountProjectTaskId], [IsForAllProjectTask], [IsParentTask], [IsDisabled], [IsForAllEmployees], [AccountPriorityId], [Completed], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_21_19_16_6_15_14_12_26_13_4]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [IsParentTask], [IsDisabled], [IsForAllEmployees], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_13_26_12_14_1_11_2_21_19_16_6]
    ON [dbo].[AccountProjectTask]([IsForAllEmployees], [IsDisabled], [IsParentTask], [AccountPriorityId], [AccountProjectTaskId], [Completed], [AccountProjectId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_1_12_26_28_13_14_16_21_19_6]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees], [AccountPriorityId], [AccountProjectMilestoneId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountTaskTypeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_2_21_1_19_6_15_14_12_26_13]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [AccountProjectId], [ModifiedByEmployeeId], [AccountProjectTaskId], [CreatedByEmployeeId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [IsParentTask], [IsDisabled], [IsForAllEmployees]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_2_1_28_12_26_13_11_21_19_16]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [AccountProjectId], [AccountProjectTaskId], [IsForAllProjectTask], [IsParentTask], [IsDisabled], [IsForAllEmployees], [Completed], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_13_26_12_11_2_21_19_16_6_15]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [IsForAllEmployees], [IsDisabled], [IsParentTask], [Completed], [AccountProjectId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_13_26_12_1_11_2_21_19_16]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [IsForAllEmployees], [IsDisabled], [IsParentTask], [AccountProjectTaskId], [Completed], [AccountProjectId], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectMilestoneId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_2_1_12_26_28_13_16_21_19]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees], [AccountProjectMilestoneId], [ModifiedByEmployeeId], [CreatedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_1_28_12_26_13_6_11_21_19]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [AccountProjectTaskId], [IsForAllProjectTask], [IsParentTask], [IsDisabled], [IsForAllEmployees], [AccountTaskTypeId], [Completed], [ModifiedByEmployeeId], [CreatedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_11_1_2_21_16_6_15_14]
    ON [dbo].[AccountProjectTask]([IsParentTask], [Completed], [AccountProjectTaskId], [AccountProjectId], [ModifiedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_6_13_26_12_1_11_2_21_19]
    ON [dbo].[AccountProjectTask]([AccountTaskTypeId], [IsForAllEmployees], [IsDisabled], [IsParentTask], [AccountProjectTaskId], [Completed], [AccountProjectId], [ModifiedByEmployeeId], [CreatedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_1_12_26_28_13_6_16_21]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees], [AccountTaskTypeId], [AccountProjectMilestoneId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_13_2_11_12_26_1_21_28_19]
    ON [dbo].[AccountProjectTask]([IsForAllEmployees], [AccountProjectId], [Completed], [IsParentTask], [IsDisabled], [AccountProjectTaskId], [ModifiedByEmployeeId], [IsForAllProjectTask], [CreatedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_1_14_19_11_2_21_16_6]
    ON [dbo].[AccountProjectTask]([IsParentTask], [AccountProjectTaskId], [AccountPriorityId], [CreatedByEmployeeId], [Completed], [AccountProjectId], [ModifiedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_21_19_26_13_12_1_2_4]
    ON [dbo].[AccountProjectTask]([ModifiedByEmployeeId], [CreatedByEmployeeId], [IsDisabled], [IsForAllEmployees], [IsParentTask], [AccountProjectTaskId], [AccountProjectId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_12_1_19_11_2_21_16]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [IsParentTask], [AccountProjectTaskId], [CreatedByEmployeeId], [Completed], [AccountProjectId], [ModifiedByEmployeeId], [AccountProjectMilestoneId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_4_1_2_13_28_12_26_11]
    ON [dbo].[AccountProjectTask]([TaskName], [AccountProjectTaskId], [AccountProjectId], [IsForAllEmployees], [IsForAllProjectTask], [IsParentTask], [IsDisabled], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_13_26_12_1_11_2_21]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [IsForAllEmployees], [IsDisabled], [IsParentTask], [AccountProjectTaskId], [Completed], [AccountProjectId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_26_16_2_12_1_21_13_28]
    ON [dbo].[AccountProjectTask]([IsDisabled], [AccountProjectMilestoneId], [AccountProjectId], [IsParentTask], [AccountProjectTaskId], [ModifiedByEmployeeId], [IsForAllEmployees], [IsForAllProjectTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_2_21_16_6_15_14_12]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [AccountProjectId], [ModifiedByEmployeeId], [AccountProjectMilestoneId], [AccountTaskTypeId], [TaskStatusId], [AccountPriorityId], [IsParentTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_26_13_12_1_6_2_4]
    ON [dbo].[AccountProjectTask]([IsDisabled], [IsForAllEmployees], [IsParentTask], [AccountProjectTaskId], [AccountTaskTypeId], [AccountProjectId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_2_12_26_28_13_16]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [AccountProjectId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees], [AccountProjectMilestoneId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_6_12_1_19_11_2_21]
    ON [dbo].[AccountProjectTask]([AccountTaskTypeId], [IsParentTask], [AccountProjectTaskId], [CreatedByEmployeeId], [Completed], [AccountProjectId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_26_13_12_1_2_4]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [IsDisabled], [IsForAllEmployees], [IsParentTask], [AccountProjectTaskId], [AccountProjectId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_1_12_26_28_13_21]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_28_16_2_12_26_1_21]
    ON [dbo].[AccountProjectTask]([IsForAllProjectTask], [AccountProjectMilestoneId], [AccountProjectId], [IsParentTask], [IsDisabled], [AccountProjectTaskId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_2_28_12_26_13_11]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [AccountProjectId], [IsForAllProjectTask], [IsParentTask], [IsDisabled], [IsForAllEmployees], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_26_13_12_1_2_4]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [IsDisabled], [IsForAllEmployees], [IsParentTask], [AccountProjectTaskId], [AccountProjectId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_28_2_11_12_26_1_21]
    ON [dbo].[AccountProjectTask]([IsForAllProjectTask], [AccountProjectId], [Completed], [IsParentTask], [IsDisabled], [AccountProjectTaskId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_14_26_13_12_1_2_4]
    ON [dbo].[AccountProjectTask]([AccountPriorityId], [IsDisabled], [IsForAllEmployees], [IsParentTask], [AccountProjectTaskId], [AccountProjectId], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_13_26_12_21_19_1_11]
    ON [dbo].[AccountProjectTask]([IsForAllEmployees], [IsDisabled], [IsParentTask], [ModifiedByEmployeeId], [CreatedByEmployeeId], [AccountProjectTaskId], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_4_2_1_12_26_28_13]
    ON [dbo].[AccountProjectTask]([TaskName], [AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask], [IsForAllEmployees]);


GO
CREATE STATISTICS [_dta_stat_1004634722_6_1_16_14_15_31]
    ON [dbo].[AccountProjectTask]([AccountTaskTypeId], [AccountProjectTaskId], [AccountProjectMilestoneId], [AccountPriorityId], [TaskStatusId], [EstimatedCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_14_2_1_12_26_28]
    ON [dbo].[AccountProjectTask]([AccountPriorityId], [AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_13_16_2_12_26_1]
    ON [dbo].[AccountProjectTask]([IsForAllEmployees], [AccountProjectMilestoneId], [AccountProjectId], [IsParentTask], [IsDisabled], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_12_1_19_11_2]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [IsParentTask], [AccountProjectTaskId], [CreatedByEmployeeId], [Completed], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_2_12_26_13_4]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [AccountProjectId], [IsParentTask], [IsDisabled], [IsForAllEmployees], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_2_1_12_26_28]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_6_2_1_12_26_28]
    ON [dbo].[AccountProjectTask]([AccountTaskTypeId], [AccountProjectId], [AccountProjectTaskId], [IsParentTask], [IsDisabled], [IsForAllProjectTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_26_2_11_12_1_21]
    ON [dbo].[AccountProjectTask]([IsDisabled], [AccountProjectId], [Completed], [IsParentTask], [AccountProjectTaskId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_12_26_13_4]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [IsParentTask], [IsDisabled], [IsForAllEmployees], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_26_1_2_13]
    ON [dbo].[AccountProjectTask]([IsParentTask], [IsDisabled], [AccountProjectTaskId], [AccountProjectId], [IsForAllEmployees]);


GO
CREATE STATISTICS [_dta_stat_1004634722_11_12_26_1_13]
    ON [dbo].[AccountProjectTask]([Completed], [IsParentTask], [IsDisabled], [AccountProjectTaskId], [IsForAllEmployees]);


GO
CREATE STATISTICS [_dta_stat_1004634722_26_13_12_1_21]
    ON [dbo].[AccountProjectTask]([IsDisabled], [IsForAllEmployees], [IsParentTask], [AccountProjectTaskId], [ModifiedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_1_2_19_11]
    ON [dbo].[AccountProjectTask]([IsParentTask], [AccountProjectTaskId], [AccountProjectId], [CreatedByEmployeeId], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_1_11_13]
    ON [dbo].[AccountProjectTask]([IsParentTask], [AccountProjectTaskId], [Completed], [IsForAllEmployees]);


GO
CREATE STATISTICS [_dta_stat_1004634722_11_12_13_26]
    ON [dbo].[AccountProjectTask]([Completed], [IsParentTask], [IsForAllEmployees], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1004634722_13_2_1_12]
    ON [dbo].[AccountProjectTask]([IsForAllEmployees], [AccountProjectId], [AccountProjectTaskId], [IsParentTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_19_1_12_11]
    ON [dbo].[AccountProjectTask]([CreatedByEmployeeId], [AccountProjectTaskId], [IsParentTask], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_21_19_13_26]
    ON [dbo].[AccountProjectTask]([ModifiedByEmployeeId], [CreatedByEmployeeId], [IsForAllEmployees], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_1_16_6]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [AccountProjectTaskId], [AccountProjectMilestoneId], [AccountTaskTypeId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_11_1_2_15]
    ON [dbo].[AccountProjectTask]([Completed], [AccountProjectTaskId], [AccountProjectId], [TaskStatusId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_26_13_4]
    ON [dbo].[AccountProjectTask]([IsParentTask], [IsDisabled], [IsForAllEmployees], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_14_1_16]
    ON [dbo].[AccountProjectTask]([AccountPriorityId], [AccountProjectTaskId], [AccountProjectMilestoneId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_15_1_11]
    ON [dbo].[AccountProjectTask]([TaskStatusId], [AccountProjectTaskId], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_19_12_11]
    ON [dbo].[AccountProjectTask]([CreatedByEmployeeId], [IsParentTask], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_14_13_26]
    ON [dbo].[AccountProjectTask]([AccountPriorityId], [IsForAllEmployees], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_2_11]
    ON [dbo].[AccountProjectTask]([IsParentTask], [AccountProjectId], [Completed]);


GO
CREATE STATISTICS [_dta_stat_1004634722_2_13_26]
    ON [dbo].[AccountProjectTask]([AccountProjectId], [IsForAllEmployees], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1004634722_4_2_12]
    ON [dbo].[AccountProjectTask]([TaskName], [AccountProjectId], [IsParentTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_1_12_4]
    ON [dbo].[AccountProjectTask]([AccountProjectTaskId], [IsParentTask], [TaskName]);


GO
CREATE STATISTICS [_dta_stat_1004634722_12_16_2]
    ON [dbo].[AccountProjectTask]([IsParentTask], [AccountProjectMilestoneId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_25_1]
    ON [dbo].[AccountProjectTask]([IsBillable], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_16_1]
    ON [dbo].[AccountProjectTask]([AccountProjectMilestoneId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_1004634722_14_12]
    ON [dbo].[AccountProjectTask]([AccountPriorityId], [IsParentTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_21_12]
    ON [dbo].[AccountProjectTask]([ModifiedByEmployeeId], [IsParentTask]);


GO
CREATE STATISTICS [_dta_stat_1004634722_4_12]
    ON [dbo].[AccountProjectTask]([TaskName], [IsParentTask]);


GO

CREATE trigger [tr_trigtest] on [dbo].[AccountProjectTask] for update, delete
as

declare @bit int ,
	@field int ,
	@maxfield int ,
	@char int ,
	@fieldname nvarchar(256) ,
	@TableName nvarchar(256) ,
	@PKCols nvarchar(2000) ,
	@sql nvarchar(4000), 
	@UpdateDate nvarchar(42) ,
	@UserName nvarchar(256) ,
	@Type nchar(1) ,
	@PKSelect nvarchar(2000)
	
	select @TableName = 'AccountProjectTask'

	-- date and user
	select 	@UserName = 0 ,
		@UpdateDate = convert(nvarchar(16), getdate(), 112) + ' ' + convert(nvarchar(16), getdate(), 114)



	-- Action
	if exists (select * from inserted)
		if exists (select * from deleted)
			Begin
				select @Type = 'U'
				select @UserName  = ModifiedByEmployeeId from inserted
			End 
		else
			Begin
				select @UserName  = CreatedByEmployeeId from inserted
				select @Type = 'I'
			End
	else
		Begin
			select @Type = 'D'
			select @UserName  = ModifiedByEmployeeId from deleted
		End 
	
	-- get list of columns
	select * into #ins from inserted
	select * into #del from deleted
	
	-- Get primary key columns for full outer join
	select	@PKCols = coalesce(@PKCols + ' and', ' on') + ' i.' + c.COLUMN_NAME + ' = d.' + c.COLUMN_NAME
	from	INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,
		INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	where 	pk.TABLE_NAME = @TableName
	and	CONSTRAINT_TYPE = 'PRIMARY KEY'
	and	c.TABLE_NAME = pk.TABLE_NAME
	and	c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	
	-- Get primary key select for insert
	select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(nvarchar(200),coalesce(i.' + COLUMN_NAME +',d.' + COLUMN_NAME + '))+''>''' 
	from	INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,
		INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	where 	pk.TABLE_NAME = @TableName
	and	CONSTRAINT_TYPE = 'PRIMARY KEY'
	and	c.TABLE_NAME = pk.TABLE_NAME
	and	c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	
	if @PKCols is null
	begin
		raiserror('no PK on table %s', 16, -1, @TableName)
		return
	end
	
	select @field = 0, @maxfield = max(ORDINAL_POSITION) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName
	while @field < @maxfield
	begin
		select @field = min(ORDINAL_POSITION) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName and ORDINAL_POSITION > @field
		select @bit = (@field - 1 )% 8 + 1
		select @bit = power(2,@bit - 1)
		select @char = ((@field - 1) / 8) + 1
		if substring(COLUMNS_UPDATED(),@char, 1) & @bit > 0 or @Type in ('I','D')
		begin
			select @fieldname = COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName and ORDINAL_POSITION = @field
			select @sql = 		'insert Audit (Type, TableName, PK, FieldName, OldValue, NewValue, UpdateDate, UserName)'
			select @sql = @sql + 	' select ''' + @Type + ''''
			select @sql = @sql + 	',''' + @TableName + ''''
			select @sql = @sql + 	',' + Replace(Replace(@PKSelect,'<AccountProjectTaskId=',''),'>','')
			select @sql = @sql + 	',''' + @fieldname + ''''
			select @sql = @sql + 	',convert(nvarchar(2000),d.' + @fieldname + ')'
			select @sql = @sql + 	',convert(nvarchar(2000),i.' + @fieldname + ')'
			select @sql = @sql + 	',''' + @UpdateDate + ''''
			select @sql = @sql + 	',''' + @UserName + ''''
			select @sql = @sql + 	' from #ins i full outer join #del d'
			select @sql = @sql + 	@PKCols
			select @sql = @sql + 	' where i.' + @fieldname + ' <> d.' + @fieldname 
			select @sql = @sql + 	' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)' 
			select @sql = @sql + 	' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)' 
			exec (@sql)
		end
	end