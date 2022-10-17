CREATE TABLE [dbo].[AccountEmployeeAttendance] (
    [AccountEmployeeAttendanceId] BIGINT       IDENTITY (1, 1) NOT NULL,
    [AccountId]                   INT          NOT NULL,
    [AccountEmployeeId]           INT          NOT NULL,
    [AttendanceDate]              DATETIME     NOT NULL,
    [AccountAbsenceTypeId]        INT          NULL,
    [AttendanceTime]              DATETIME     NULL,
    [InOut]                       NVARCHAR (6) NULL,
    [CreatedByEmployeeId]         INT          CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [CreatedOn]                   DATETIME     CONSTRAINT [DF_AccountEmployeeAttendance_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]        INT          CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [ModifiedOn]                  DATETIME     CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [InApproval]                  BIT          NULL,
    [Approved]                    BIT          NULL,
    [Rejected]                    BIT          NULL,
    [ApprovedOn]                  DATETIME     NULL,
    [ApprovedBy]                  INT          NULL,
    CONSTRAINT [PK_AccountEmployeeAttendance] PRIMARY KEY CLUSTERED ([AccountEmployeeAttendanceId] ASC),
    CONSTRAINT [FK_AccountEmployeeAttendance_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_AccountEmployeeAttendance_AccountAbsenceType] FOREIGN KEY ([AccountAbsenceTypeId]) REFERENCES [dbo].[AccountAbsenceType] ([AccountAbsenceTypeId]),
    CONSTRAINT [FK_AccountEmployeeAttendance_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountAbsenceTypeId]
    ON [dbo].[AccountEmployeeAttendance]([AccountAbsenceTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AttendanceDate]
    ON [dbo].[AccountEmployeeAttendance]([AttendanceDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountEmployeeAttendance]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountEmployeeAttendance]([AccountEmployeeId] ASC);

