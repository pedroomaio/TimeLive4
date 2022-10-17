CREATE TABLE [dbo].[AccountProject] (
    [AccountProjectId]         INT             IDENTITY (1, 1) NOT NULL,
    [AccountId]                INT             NOT NULL,
    [AccountProjectTypeId]     INT             NOT NULL,
    [AccountClientId]          INT             NOT NULL,
    [ProjectBillingTypeId]     INT             NULL,
    [ProjectName]              NVARCHAR (100)  NOT NULL,
    [ProjectDescription]       NVARCHAR (4000) NOT NULL,
    [StartDate]                SMALLDATETIME   NULL,
    [AccountMilestoneId]       INT             CONSTRAINT [DF_AccountProject_AccountMilestoneId] DEFAULT ((0)) NOT NULL,
    [Deadline]                 SMALLDATETIME   NULL,
    [LeaderEmployeeId]         INT             NULL,
    [ProjectManagerEmployeeId] INT             NOT NULL,
    [EstimatedTime]            SMALLDATETIME   NULL,
    [EstimatedDuration]        FLOAT (53)      NULL,
    [EstimatedDurationUnit]    NVARCHAR (20)   NULL,
    [ProjectCode]              NVARCHAR (100)  NULL,
    [DefaultBillingRate]       MONEY           NULL,
    [IsActive]                 BIT             CONSTRAINT [DF_AccountProject_IsActive] DEFAULT ((1)) NOT NULL,
    [ProjectStatusId]          INT             CONSTRAINT [DF_AccountProject_ProjectStatusId] DEFAULT ((0)) NOT NULL,
    [AccountPriorityId]        INT             NULL,
    [TimeSheetApprovalTypeId]  INT             CONSTRAINT [DF_AccountProject_TimeSheetApprovalTypeId] DEFAULT ((0)) NULL,
    [ExpenseApprovalTypeId]    INT             CONSTRAINT [DF_AccountProject_ExpenseApprovalTypeId] DEFAULT ((0)) NULL,
    [CreatedOn]                DATETIME        NOT NULL,
    [CreatedByEmployeeId]      INT             NOT NULL,
    [ModifiedOn]               DATETIME        NOT NULL,
    [ModifiedByEmployeeId]     INT             NOT NULL,
    [ProjectBillingRateTypeId] INT             NULL,
    [AccountPartyContactId]    INT             NULL,
    [AccountPartyDepartmentId] INT             NULL,
    [IsDisabled]               BIT             CONSTRAINT [DF_AccountProject_IsDisabled] DEFAULT ((0)) NOT NULL,
    [IsTemplate]               BIT             CONSTRAINT [DF_AccountProject_IsTemplate] DEFAULT ((0)) NOT NULL,
    [IsProject]                BIT             CONSTRAINT [DF_AccountProject_IsProject] DEFAULT ((0)) NOT NULL,
    [AccountProjectTemplateId] INT             NULL,
    [Completed]                BIT             CONSTRAINT [DF_AccountProject_Completed] DEFAULT ((0)) NOT NULL,
    [IsDeleted]                BIT             NULL,
    [CustomField1]             NVARCHAR (2000) NULL,
    [CustomField2]             NVARCHAR (2000) NULL,
    [CustomField3]             NVARCHAR (2000) NULL,
    [CustomField4]             NVARCHAR (2000) NULL,
    [CustomField5]             NVARCHAR (2000) NULL,
    [CustomField6]             NVARCHAR (2000) NULL,
    [CustomField7]             NVARCHAR (2000) NULL,
    [CustomField8]             NVARCHAR (2000) NULL,
    [CustomField9]             NVARCHAR (2000) NULL,
    [CustomField10]            NVARCHAR (2000) NULL,
    [CustomField11]            NVARCHAR (2000) NULL,
    [CustomField12]            NVARCHAR (2000) NULL,
    [CustomField13]            NVARCHAR (2000) NULL,
    [CustomField14]            NVARCHAR (2000) NULL,
    [CustomField15]            NVARCHAR (2000) NULL,
    [ProjectPrefix]            NVARCHAR (100)  NULL,
    [IsForAllClientProject]    BIT             NULL,
    [ProjectEstimatedCost]     FLOAT (53)      NULL,
    [FixedCost]                FLOAT (53)      NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([AccountProjectId] ASC),
    CONSTRAINT [FK_AccountProject_AccountApprovalType] FOREIGN KEY ([ExpenseApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]),
    CONSTRAINT [FK_AccountProject_AccountApprovalType2] FOREIGN KEY ([TimeSheetApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]),
    CONSTRAINT [FK_AccountProject_AccountBillingType] FOREIGN KEY ([ProjectBillingTypeId]) REFERENCES [dbo].[AccountBillingType] ([AccountBillingTypeId]),
    CONSTRAINT [FK_AccountProject_AccountEmployee] FOREIGN KEY ([LeaderEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountProject_AccountEmployee1] FOREIGN KEY ([ProjectManagerEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountProject_AccountParty] FOREIGN KEY ([AccountClientId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId]),
    CONSTRAINT [FK_AccountProject_AccountPriority] FOREIGN KEY ([AccountPriorityId]) REFERENCES [dbo].[AccountPriority] ([AccountPriorityId]),
    CONSTRAINT [FK_AccountProject_AccountProjectType] FOREIGN KEY ([AccountProjectTypeId]) REFERENCES [dbo].[AccountProjectType] ([AccountProjectTypeId]),
    CONSTRAINT [FK_AccountProject_AccountStatus] FOREIGN KEY ([ProjectStatusId]) REFERENCES [dbo].[AccountStatus] ([AccountStatusId])
);


GO
CREATE NONCLUSTERED INDEX [IX_IsTemplate]
    ON [dbo].[AccountProject]([IsTemplate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsProject]
    ON [dbo].[AccountProject]([IsProject] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsActive]
    ON [dbo].[AccountProject]([IsActive] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectName]
    ON [dbo].[AccountProject]([ProjectName] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_10_1708637230__K1_K2_K31_K4_6_16]
    ON [dbo].[AccountProject]([AccountProjectId] ASC, [AccountId] ASC, [IsTemplate] ASC, [AccountClientId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_10_1708637230__K1_K31_K30_K4]
    ON [dbo].[AccountProject]([AccountProjectId] ASC, [IsTemplate] ASC, [IsDisabled] ASC, [AccountClientId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K1_K21]
    ON [dbo].[AccountProject]([AccountProjectId] ASC, [TimeSheetApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K1_K21_K6_11_12]
    ON [dbo].[AccountProject]([AccountProjectId] ASC, [TimeSheetApprovalTypeId] ASC, [ProjectName] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K31_K4_K1_6_16]
    ON [dbo].[AccountProject]([IsTemplate] ASC, [AccountClientId] ASC, [AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K21_K1_6_7_11_12_16]
    ON [dbo].[AccountProject]([TimeSheetApprovalTypeId] ASC, [AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K22_K1_6_7_11_12_16]
    ON [dbo].[AccountProject]([ExpenseApprovalTypeId] ASC, [AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K4_K1_K31_K30_K11_K12_K27_K19_K6_2_7_8_10_14_15_16_18_32_33]
    ON [dbo].[AccountProject]([AccountClientId] ASC, [AccountProjectId] ASC, [IsTemplate] ASC, [IsDisabled] ASC, [LeaderEmployeeId] ASC, [ProjectManagerEmployeeId] ASC, [ProjectBillingRateTypeId] ASC, [ProjectStatusId] ASC, [ProjectName] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_5_1708637230__K21_K1_2_3_4_5_6_7_8_10_11_12_13_14_15_16_17_18_19_22_23_24_25_26_27_28_29_30_31_32_33]
    ON [dbo].[AccountProject]([TimeSheetApprovalTypeId] ASC, [AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetApprovalTypeId]
    ON [dbo].[AccountProject]([TimeSheetApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectStatusId]
    ON [dbo].[AccountProject]([ProjectStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectBillingTypeId]
    ON [dbo].[AccountProject]([ProjectBillingTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectBillingRateTypeId]
    ON [dbo].[AccountProject]([ProjectBillingRateTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExpenseApprovalTypeId]
    ON [dbo].[AccountProject]([ExpenseApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectTypeId]
    ON [dbo].[AccountProject]([AccountProjectTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPriorityId]
    ON [dbo].[AccountProject]([AccountPriorityId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPartyDepartmentId]
    ON [dbo].[AccountProject]([AccountPartyDepartmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPartyContactId]
    ON [dbo].[AccountProject]([AccountPartyContactId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountMilestoneId]
    ON [dbo].[AccountProject]([AccountMilestoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountProject_10_917578307__K1]
    ON [dbo].[AccountProject]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectManagerEmployeeId]
    ON [dbo].[AccountProject]([ProjectManagerEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LeaderEmployeeId]
    ON [dbo].[AccountProject]([LeaderEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountProject]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountClientId]
    ON [dbo].[AccountProject]([AccountClientId] ASC);


GO
CREATE STATISTICS [_dta_stat_1708637230_6_11_12_19_1_30_31]
    ON [dbo].[AccountProject]([ProjectName], [LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectStatusId], [AccountProjectId], [IsDisabled], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_30_11_12_19_27_4_31]
    ON [dbo].[AccountProject]([IsDisabled], [LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectStatusId], [ProjectBillingRateTypeId], [AccountClientId], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_31_11_12_19_27_4]
    ON [dbo].[AccountProject]([IsTemplate], [LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectStatusId], [ProjectBillingRateTypeId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_4_1_6]
    ON [dbo].[AccountProject]([AccountClientId], [AccountProjectId], [ProjectName]);


GO
CREATE STATISTICS [_dta_stat_1708637230_4_31_30]
    ON [dbo].[AccountProject]([AccountClientId], [IsTemplate], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1708637230_19_1_30]
    ON [dbo].[AccountProject]([ProjectStatusId], [AccountProjectId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1708637230_27_1_30]
    ON [dbo].[AccountProject]([ProjectBillingRateTypeId], [AccountProjectId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1708637230_30_1]
    ON [dbo].[AccountProject]([IsDisabled], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_6_1]
    ON [dbo].[AccountProject]([ProjectName], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_31_11_12_27_4_1_30_19_6]
    ON [dbo].[AccountProject]([IsTemplate], [LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectBillingRateTypeId], [AccountClientId], [AccountProjectId], [IsDisabled], [ProjectStatusId], [ProjectName]);


GO
CREATE STATISTICS [_dta_stat_1708637230_12_1_2_11_31_30_4_27_19]
    ON [dbo].[AccountProject]([ProjectManagerEmployeeId], [AccountProjectId], [AccountId], [LeaderEmployeeId], [IsTemplate], [IsDisabled], [AccountClientId], [ProjectBillingRateTypeId], [ProjectStatusId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_4_27_19_12_11_2_31]
    ON [dbo].[AccountProject]([AccountProjectId], [AccountClientId], [ProjectBillingRateTypeId], [ProjectStatusId], [ProjectManagerEmployeeId], [LeaderEmployeeId], [AccountId], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_19_11_12_2_30_31_1_4]
    ON [dbo].[AccountProject]([ProjectStatusId], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountId], [IsDisabled], [IsTemplate], [AccountProjectId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_11_12_2_30_31_1_27]
    ON [dbo].[AccountProject]([LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountId], [IsDisabled], [IsTemplate], [AccountProjectId], [ProjectBillingRateTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_11_12_27_4_1_19_31]
    ON [dbo].[AccountProject]([LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectBillingRateTypeId], [AccountClientId], [AccountProjectId], [ProjectStatusId], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_19_1_31_30_11_12_27]
    ON [dbo].[AccountProject]([ProjectStatusId], [AccountProjectId], [IsTemplate], [IsDisabled], [LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectBillingRateTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_12_11_31_1_2_4_19]
    ON [dbo].[AccountProject]([ProjectManagerEmployeeId], [LeaderEmployeeId], [IsTemplate], [AccountProjectId], [AccountId], [AccountClientId], [ProjectStatusId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_19_12_11_31_30_4_1]
    ON [dbo].[AccountProject]([ProjectStatusId], [ProjectManagerEmployeeId], [LeaderEmployeeId], [IsTemplate], [IsDisabled], [AccountClientId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_31_30_4_11_12]
    ON [dbo].[AccountProject]([AccountProjectId], [IsTemplate], [IsDisabled], [AccountClientId], [LeaderEmployeeId], [ProjectManagerEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_3_4_11_12_2]
    ON [dbo].[AccountProject]([AccountProjectId], [AccountProjectTypeId], [AccountClientId], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_31_6_11_12_4]
    ON [dbo].[AccountProject]([AccountProjectId], [IsTemplate], [ProjectName], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_30_11_12_27_4_1]
    ON [dbo].[AccountProject]([IsDisabled], [LeaderEmployeeId], [ProjectManagerEmployeeId], [ProjectBillingRateTypeId], [AccountClientId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_19_31_1_2_4_12]
    ON [dbo].[AccountProject]([ProjectStatusId], [IsTemplate], [AccountProjectId], [AccountId], [AccountClientId], [ProjectManagerEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_31_1_4_19_12_11]
    ON [dbo].[AccountProject]([IsTemplate], [AccountProjectId], [AccountClientId], [ProjectStatusId], [ProjectManagerEmployeeId], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_4_19_12_11_2]
    ON [dbo].[AccountProject]([AccountProjectId], [AccountClientId], [ProjectStatusId], [ProjectManagerEmployeeId], [LeaderEmployeeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_11_12_4_1_19_30]
    ON [dbo].[AccountProject]([LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountClientId], [AccountProjectId], [ProjectStatusId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1708637230_4_11_12_2_30_31]
    ON [dbo].[AccountProject]([AccountClientId], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountId], [IsDisabled], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_11_12_1_31_30_27]
    ON [dbo].[AccountProject]([LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountProjectId], [IsTemplate], [IsDisabled], [ProjectBillingRateTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_27_11_12_2_30_31]
    ON [dbo].[AccountProject]([ProjectBillingRateTypeId], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountId], [IsDisabled], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_2_3_4_11]
    ON [dbo].[AccountProject]([AccountProjectId], [AccountId], [AccountProjectTypeId], [AccountClientId], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_30_2_11_12_1]
    ON [dbo].[AccountProject]([IsDisabled], [AccountId], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_4_12_11_31_30]
    ON [dbo].[AccountProject]([AccountClientId], [ProjectManagerEmployeeId], [LeaderEmployeeId], [IsTemplate], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1708637230_6_11_12_4_1]
    ON [dbo].[AccountProject]([ProjectName], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountClientId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_27_1_31_30_11]
    ON [dbo].[AccountProject]([ProjectBillingRateTypeId], [AccountProjectId], [IsTemplate], [IsDisabled], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_11_12_2_1_3]
    ON [dbo].[AccountProject]([LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountId], [AccountProjectId], [AccountProjectTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_12_11_31_30]
    ON [dbo].[AccountProject]([ProjectManagerEmployeeId], [LeaderEmployeeId], [IsTemplate], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1708637230_2_31_1_4]
    ON [dbo].[AccountProject]([AccountId], [IsTemplate], [AccountProjectId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_2_1_12_11]
    ON [dbo].[AccountProject]([AccountId], [AccountProjectId], [ProjectManagerEmployeeId], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_31_30_11]
    ON [dbo].[AccountProject]([AccountProjectId], [IsTemplate], [IsDisabled], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_31_2_11_12]
    ON [dbo].[AccountProject]([IsTemplate], [AccountId], [LeaderEmployeeId], [ProjectManagerEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_30_11_12_4]
    ON [dbo].[AccountProject]([IsDisabled], [LeaderEmployeeId], [ProjectManagerEmployeeId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_4_31_1]
    ON [dbo].[AccountProject]([AccountClientId], [IsTemplate], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_31_16]
    ON [dbo].[AccountProject]([AccountProjectId], [IsTemplate], [ProjectCode]);


GO
CREATE STATISTICS [_dta_stat_1708637230_12_1_22]
    ON [dbo].[AccountProject]([ProjectManagerEmployeeId], [AccountProjectId], [ExpenseApprovalTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_31_1_12]
    ON [dbo].[AccountProject]([IsTemplate], [AccountProjectId], [ProjectManagerEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_4_2_31]
    ON [dbo].[AccountProject]([AccountClientId], [AccountId], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_2_1_4]
    ON [dbo].[AccountProject]([AccountId], [AccountProjectId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_22_1_4]
    ON [dbo].[AccountProject]([ExpenseApprovalTypeId], [AccountProjectId], [AccountClientId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_12_21]
    ON [dbo].[AccountProject]([AccountProjectId], [ProjectManagerEmployeeId], [TimeSheetApprovalTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_22_6]
    ON [dbo].[AccountProject]([AccountProjectId], [ExpenseApprovalTypeId], [ProjectName]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_22_11]
    ON [dbo].[AccountProject]([AccountProjectId], [ExpenseApprovalTypeId], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_30_31_11]
    ON [dbo].[AccountProject]([IsDisabled], [IsTemplate], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_11_1_21]
    ON [dbo].[AccountProject]([LeaderEmployeeId], [AccountProjectId], [TimeSheetApprovalTypeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_2_1_11]
    ON [dbo].[AccountProject]([AccountId], [AccountProjectId], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_11_12]
    ON [dbo].[AccountProject]([AccountProjectId], [LeaderEmployeeId], [ProjectManagerEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_16_31]
    ON [dbo].[AccountProject]([ProjectCode], [IsTemplate]);


GO
CREATE STATISTICS [_dta_stat_1708637230_2_11]
    ON [dbo].[AccountProject]([AccountId], [LeaderEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1708637230_1_16]
    ON [dbo].[AccountProject]([AccountProjectId], [ProjectCode]);

