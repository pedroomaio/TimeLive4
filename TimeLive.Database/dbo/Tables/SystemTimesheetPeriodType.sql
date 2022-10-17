CREATE TABLE [dbo].[SystemTimesheetPeriodType] (
    [SystemTimesheetPeriodTypeId] SMALLINT       NOT NULL,
    [SystemTimesheetPeriodType]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SystemTimesheetType] PRIMARY KEY CLUSTERED ([SystemTimesheetPeriodTypeId] ASC)
);

