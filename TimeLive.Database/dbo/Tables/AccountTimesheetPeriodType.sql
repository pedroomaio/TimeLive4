CREATE TABLE [dbo].[AccountTimesheetPeriodType] (
    [AccountTimesheetPeriodTypeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTimesheetType_AccountTimesheetTypeId] DEFAULT (newid()) NOT NULL,
    [AccountId]                      INT              NOT NULL,
    [SystemTimesheetPeriodTypeId]    SMALLINT         NOT NULL,
    [SystemInitialDaysOfThePeriodId] SMALLINT         NULL,
    [InitialDayOfTheMonth]           SMALLINT         NULL,
    [CreatedOn]                      DATETIME         NOT NULL,
    [CreatedByEmployeeId]            INT              NOT NULL,
    [ModifiedOn]                     DATETIME         NOT NULL,
    [ModifiedByEmployeeId]           INT              NOT NULL,
    [IsDisabled]                     BIT              NOT NULL,
    [MasterTimesheetPeriodTypeId]    SMALLINT         NOT NULL,
    CONSTRAINT [PK_AccountTimesheetType] PRIMARY KEY CLUSTERED ([AccountTimesheetPeriodTypeId] ASC),
    CONSTRAINT [FK_AccountTimesheetPeriodType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountTimesheetPeriodType_MasterTimesheetPeriodType] FOREIGN KEY ([MasterTimesheetPeriodTypeId]) REFERENCES [dbo].[MasterTimesheetPeriodType] ([MasterTimesheetPeriodTypeId]),
    CONSTRAINT [FK_AccountTimesheetPeriodType_SystemInitialDaysOfThePeriod] FOREIGN KEY ([SystemInitialDaysOfThePeriodId]) REFERENCES [dbo].[SystemInitialDaysOfThePeriod] ([SystemInitialDaysOfThePeriodId]),
    CONSTRAINT [FK_AccountTimesheetPeriodType_SystemTimesheetPeriodType] FOREIGN KEY ([SystemTimesheetPeriodTypeId]) REFERENCES [dbo].[SystemTimesheetPeriodType] ([SystemTimesheetPeriodTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemTimesheetPeriodTypeId]
    ON [dbo].[AccountTimesheetPeriodType]([SystemTimesheetPeriodTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemInitialDaysOfThePeriodId]
    ON [dbo].[AccountTimesheetPeriodType]([SystemInitialDaysOfThePeriodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MasterTimesheetPeriodTypeId]
    ON [dbo].[AccountTimesheetPeriodType]([MasterTimesheetPeriodTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_InitialDayOfTheMonth]
    ON [dbo].[AccountTimesheetPeriodType]([InitialDayOfTheMonth] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTimesheetPeriodType_AccountId]
    ON [dbo].[AccountTimesheetPeriodType]([AccountId] ASC);

