CREATE TABLE [dbo].[AccountWorkingDayType] (
    [AccountWorkingDayTypeId]           UNIQUEIDENTIFIER CONSTRAINT [DF_AccountWorkingDayType_AccountWorkingDayTypeId] DEFAULT (newid()) NOT NULL,
    [AccountId]                         INT              NOT NULL,
    [AccountWorkingDayType]             NVARCHAR (500)   NOT NULL,
    [HoursPerDay]                       FLOAT (53)       NOT NULL,
    [WeekStartDay]                      TINYINT          NOT NULL,
    [CreatedByEmployeeId]               INT              NOT NULL,
    [CreatedOn]                         DATETIME         CONSTRAINT [DF_AccountWorkingDayType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]              INT              NOT NULL,
    [ModifiedOn]                        DATETIME         CONSTRAINT [DF_AccountWorkingDayType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [IsDisabled]                        BIT              NULL,
    [MasterWorkingDayTypeId]            UNIQUEIDENTIFIER NULL,
    [MinimumHoursPerDay]                FLOAT (53)       NOT NULL,
    [MaximumHoursPerDay]                FLOAT (53)       NOT NULL,
    [MinimumHoursPerWeek]               FLOAT (53)       NOT NULL,
    [MaximumHoursPerWeek]               FLOAT (53)       NOT NULL,
    [AccountTimesheetPeriodTypeId]      UNIQUEIDENTIFIER NULL,
    [TimesheetOverdueAfterDays]         SMALLINT         NULL,
    [MinimumPercentagePerDay]           INT              NULL,
    [MaximumPercentagePerDay]           INT              NULL,
    [MinimumPercentagePerWeek]          INT              NULL,
    [MaximumPercentagePerWeek]          INT              NULL,
    [LockAllPreviousTimesheets]         BIT              NULL,
    [LockAllFutureTimesheets]           BIT              NULL,
    [LockPreviousTimesheetPeriods]      INT              NULL,
    [LockFutureTimsheetPeriods]         INT              NULL,
    [LockPreviousNextMonthTimesheetOn]  INT              NULL,
    [EnableBalanceValidationForTimeOff] BIT              NULL,
    [LockAllPeriodExceptPrevious]       INT              NULL,
    [LockAllPeriodExceptNext]           INT              NULL,
    [ShowClockStartEndEmployee]         BIT              NULL,
    CONSTRAINT [PK_AccountWorkingDayType] PRIMARY KEY CLUSTERED ([AccountWorkingDayTypeId] ASC),
    CONSTRAINT [FK_AccountWorkingDayType_AccountTimesheetPeriodType] FOREIGN KEY ([AccountTimesheetPeriodTypeId]) REFERENCES [dbo].[AccountTimesheetPeriodType] ([AccountTimesheetPeriodTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_MasterWorkingDayTypeId]
    ON [dbo].[AccountWorkingDayType]([MasterWorkingDayTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTimesheetPeriodTypeId]
    ON [dbo].[AccountWorkingDayType]([AccountTimesheetPeriodTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountWorkingDayType]([AccountId] ASC);

