CREATE TABLE [dbo].[AccountEmployeeTimeOffRequestApproval] (
    [AccountEmployeeTimeOffRequestApprovalId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeTimeOffRequestApproval_AccountEmployeeTimeOffRequestApprovalId] DEFAULT (newid()) NOT NULL,
    [AccountEmployeeTimeOffRequestId]         UNIQUEIDENTIFIER NOT NULL,
    [TimeOffApprovalTypeId]                   INT              NOT NULL,
    [TimeOffApprovalPathId]                   INT              NOT NULL,
    [ApprovedByEmployeeId]                    INT              NOT NULL,
    [ApprovedOn]                              DATETIME         NOT NULL,
    [IsRejected]                              BIT              NOT NULL,
    [IsApproved]                              BIT              NOT NULL,
    [Comments]                                NVARCHAR (400)   NULL,
    [CreatedByEmployeeId]                     INT              NULL,
    [CreatedOn]                               DATETIME         NULL,
    [ModifiedByEmployeeId]                    INT              NULL,
    [ModifiedOn]                              DATETIME         NULL,
    CONSTRAINT [PK_AccountEmployeeTimeOffRequestApproval] PRIMARY KEY CLUSTERED ([AccountEmployeeTimeOffRequestApprovalId] ASC),
    CONSTRAINT [FK_AccountEmployeeTimeOffRequestApproval_AccountApprovalPath] FOREIGN KEY ([TimeOffApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId]),
    CONSTRAINT [FK_AccountEmployeeTimeOffRequestApproval_AccountApprovalType] FOREIGN KEY ([TimeOffApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]),
    CONSTRAINT [FK_AccountEmployeeTimeOffRequestApproval_AccountEmployeeTimeOffRequest] FOREIGN KEY ([AccountEmployeeTimeOffRequestId]) REFERENCES [dbo].[AccountEmployeeTimeOffRequest] ([AccountEmployeeTimeOffRequestId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TimeOffApprovalTypeId]
    ON [dbo].[AccountEmployeeTimeOffRequestApproval]([TimeOffApprovalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeOffApprovalPathId]
    ON [dbo].[AccountEmployeeTimeOffRequestApproval]([TimeOffApprovalPathId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ApprovedByEmployeeId_1]
    ON [dbo].[AccountEmployeeTimeOffRequestApproval]([ApprovedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeOffRequestId]
    ON [dbo].[AccountEmployeeTimeOffRequestApproval]([AccountEmployeeTimeOffRequestId] ASC);

