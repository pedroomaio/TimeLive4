CREATE TABLE [dbo].[AccountEmployeeTimeEntryApproval] (
    [TimeSheetApprovalId]              INT              IDENTITY (1, 1) NOT NULL,
    [AccountEmployeeTimeEntryId]       INT              NOT NULL,
    [TimeSheetApprovalTypeId]          INT              NOT NULL,
    [TimeSheetApprovalPathId]          INT              NOT NULL,
    [ApprovedByEmployeeId]             INT              NOT NULL,
    [ApprovedOn]                       DATETIME         NOT NULL,
    [Comments]                         NVARCHAR (1500)  NULL,
    [IsReject]                         BIT              CONSTRAINT [DF_TimeSheetApproval_IsReject] DEFAULT ((0)) NOT NULL,
    [IsApproved]                       BIT              CONSTRAINT [DF_TimeSheetApproval_IsApproved] DEFAULT ((0)) NOT NULL,
    [AccountEmployeeTimeEntryPeriodId] UNIQUEIDENTIFIER NULL,
    [AccountProjectId]                 INT              NULL,
    [PreviousStatus]                   BIT              NULL,
    [BatchId]                          UNIQUEIDENTIFIER NULL,
    [ApprovalPathSequence]             TINYINT          NULL,
    CONSTRAINT [PK_TimeSheetApproval] PRIMARY KEY CLUSTERED ([TimeSheetApprovalId] ASC),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath] FOREIGN KEY ([TimeSheetApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountApprovalType] FOREIGN KEY ([TimeSheetApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry] FOREIGN KEY ([AccountEmployeeTimeEntryId]) REFERENCES [dbo].[AccountEmployeeTimeEntry] ([AccountEmployeeTimeEntryId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntryPeriod] FOREIGN KEY ([AccountEmployeeTimeEntryPeriodId]) REFERENCES [dbo].[AccountEmployeeTimeEntryPeriod] ([AccountEmployeeTimeEntryPeriodId])
);


GO
CREATE NONCLUSTERED INDEX [IX_BatchId]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([BatchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsReject]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([IsReject] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsApproved]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([IsApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntryApproval_10_103059503__K10_K2_K4_K5_K7_K8_K9_K13_3_6]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountEmployeeTimeEntryPeriodId] ASC, [AccountEmployeeTimeEntryId] ASC, [TimeSheetApprovalPathId] ASC, [ApprovedByEmployeeId] ASC, [IsReject] ASC, [IsApproved] ASC, [BatchId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntryApproval_5_103059503__K11_K10_K4_K12_K8_K1_K7_K9]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountEmployeeTimeEntryPeriodId] ASC, [AccountEmployeeTimeEntryId] ASC, [TimeSheetApprovalPathId] ASC, [ApprovedByEmployeeId] ASC, [IsReject] ASC, [IsApproved] ASC, [BatchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeEntryPeriodId]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountEmployeeTimeEntryPeriodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ApprovedByEmployeeId]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([ApprovedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetApprovalPathId]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalPathId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetApprovalTypeId]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryId]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountEmployeeTimeEntryId] ASC);


GO
CREATE STATISTICS [_dta_stat_103059503_7_8_9_13_10]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([Comments], [IsReject], [IsApproved], [BatchId], [AccountEmployeeTimeEntryPeriodId]);


GO
CREATE STATISTICS [_dta_stat_103059503_2_4_5]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountEmployeeTimeEntryId], [TimeSheetApprovalPathId], [ApprovedByEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_103059503_4_1_8_12_11_10_7_9]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalPathId], [TimeSheetApprovalId], [IsReject], [PreviousStatus], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [Comments], [IsApproved]);


GO
CREATE STATISTICS [_dta_stat_103059503_12_8_11_10_4_7_9]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([PreviousStatus], [IsReject], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [TimeSheetApprovalPathId], [Comments], [IsApproved]);


GO
CREATE STATISTICS [_dta_stat_103059503_4_7_8_9_1_12]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalPathId], [Comments], [IsReject], [IsApproved], [TimeSheetApprovalId], [PreviousStatus]);


GO
CREATE STATISTICS [_dta_stat_103059503_11_10_1_8_12]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [TimeSheetApprovalId], [IsReject], [PreviousStatus]);


GO
CREATE STATISTICS [_dta_stat_103059503_8_11_10_4_12]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([IsReject], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [TimeSheetApprovalPathId], [PreviousStatus]);


GO
CREATE STATISTICS [_dta_stat_103059503_4_8_1_12_7]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalPathId], [IsReject], [TimeSheetApprovalId], [PreviousStatus], [Comments]);


GO
CREATE STATISTICS [_dta_stat_103059503_4_8_12_11]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalPathId], [IsReject], [PreviousStatus], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_103059503_1_4_7_8]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalId], [TimeSheetApprovalPathId], [Comments], [IsReject]);


GO
CREATE STATISTICS [_dta_stat_103059503_11_1_8_12]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([AccountProjectId], [TimeSheetApprovalId], [IsReject], [PreviousStatus]);


GO
CREATE STATISTICS [_dta_stat_103059503_12_11_10]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([PreviousStatus], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId]);


GO
CREATE STATISTICS [_dta_stat_103059503_1_8_12]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalId], [IsReject], [PreviousStatus]);


GO
CREATE STATISTICS [_dta_stat_103059503_1_2]
    ON [dbo].[AccountEmployeeTimeEntryApproval]([TimeSheetApprovalId], [AccountEmployeeTimeEntryId]);

