CREATE TABLE [dbo].[AccountEmployeeTimeEntryApprovalProject] (
    [AccountEmployeeTimeEntryApprovalProjectId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeTimeEntryApprovalProject_AccountEmployeeTimeEntryApprovalProjectId] DEFAULT (newid()) NOT NULL,
    [AccountEmployeeTimeEntryPeriodId]          UNIQUEIDENTIFIER NOT NULL,
    [AccountProjectId]                          INT              NOT NULL,
    [TimeEntryAccountEmployeeId]                INT              NOT NULL,
    [ApprovedByEmployeeId]                      INT              NULL,
    [Submitted]                                 BIT              NOT NULL,
    [InApproval]                                BIT              NOT NULL,
    [IsRejected]                                BIT              NOT NULL,
    [Approved]                                  BIT              NOT NULL,
    [Rejected]                                  BIT              NOT NULL,
    [CreatedOn]                                 DATETIME         NOT NULL,
    [CreatedByEmployeeId]                       INT              NOT NULL,
    [ModifiedOn]                                DATETIME         NOT NULL,
    [ModifiedByEmployeeId]                      INT              NOT NULL,
    [IsEmailSend]                               BIT              NULL,
    CONSTRAINT [PK_AccountEmployeeTimeEntryApprovalProject] PRIMARY KEY CLUSTERED ([AccountEmployeeTimeEntryApprovalProjectId] ASC),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApprovalProject_AccountEmployee] FOREIGN KEY ([TimeEntryAccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApprovalProject_AccountEmployee1] FOREIGN KEY ([ApprovedByEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApprovalProject_AccountEmployeeTimeEntryPeriod] FOREIGN KEY ([AccountEmployeeTimeEntryPeriodId]) REFERENCES [dbo].[AccountEmployeeTimeEntryPeriod] ([AccountEmployeeTimeEntryPeriodId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntryApprovalProject_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId])
);


GO
CREATE NONCLUSTERED INDEX [IX_TimeEntryAccountEmployeeId]
    ON [dbo].[AccountEmployeeTimeEntryApprovalProject]([TimeEntryAccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountEmployeeTimeEntryApprovalProject]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriodId]
    ON [dbo].[AccountEmployeeTimeEntryApprovalProject]([AccountEmployeeTimeEntryPeriodId] ASC);

