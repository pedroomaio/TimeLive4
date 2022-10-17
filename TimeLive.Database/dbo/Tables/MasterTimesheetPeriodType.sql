CREATE TABLE [dbo].[MasterTimesheetPeriodType] (
    [MasterTimesheetPeriodTypeId]    SMALLINT NOT NULL,
    [SystemTimesheetPeriodTypeId]    SMALLINT NOT NULL,
    [SystemInitialDaysOfThePeriodId] SMALLINT NULL,
    [InitialDayOfTheMonth]           SMALLINT NULL,
    CONSTRAINT [PK_MasterTimesheetType] PRIMARY KEY CLUSTERED ([MasterTimesheetPeriodTypeId] ASC)
);

