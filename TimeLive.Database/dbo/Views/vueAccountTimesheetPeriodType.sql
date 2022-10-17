
CREATE VIEW [dbo].[vueAccountTimesheetPeriodType]
AS
SELECT     dbo.AccountTimesheetPeriodType.AccountTimesheetPeriodTypeId, dbo.AccountTimesheetPeriodType.AccountId, 
                      dbo.AccountTimesheetPeriodType.SystemTimesheetPeriodTypeId, dbo.AccountTimesheetPeriodType.SystemInitialDaysOfThePeriodId, 
                      dbo.AccountTimesheetPeriodType.InitialDayOfTheMonth, dbo.AccountTimesheetPeriodType.CreatedOn, 
                      dbo.AccountTimesheetPeriodType.CreatedByEmployeeId, dbo.AccountTimesheetPeriodType.ModifiedOn, 
                      dbo.AccountTimesheetPeriodType.ModifiedByEmployeeId, dbo.AccountTimesheetPeriodType.IsDisabled, 
                      dbo.SystemTimesheetPeriodType.SystemTimesheetPeriodType, dbo.SystemInitialDaysOfThePeriod.SystemInitialDaysOfThePeriod, 
                      dbo.SystemInitialDaysOfThePeriod.SystemInitialDayOfFirstPeriod, dbo.SystemInitialDaysOfThePeriod.SystemInitialDayOfLastPeriod
FROM         dbo.SystemTimesheetPeriodType RIGHT OUTER JOIN
                      dbo.AccountTimesheetPeriodType ON 
                      dbo.SystemTimesheetPeriodType.SystemTimesheetPeriodTypeId = dbo.AccountTimesheetPeriodType.SystemTimesheetPeriodTypeId LEFT OUTER JOIN
                      dbo.SystemInitialDaysOfThePeriod ON 
                      dbo.AccountTimesheetPeriodType.SystemInitialDaysOfThePeriodId = dbo.SystemInitialDaysOfThePeriod.SystemInitialDaysOfThePeriodId