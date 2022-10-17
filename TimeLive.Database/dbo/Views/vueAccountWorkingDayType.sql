
CREATE VIEW dbo.vueAccountWorkingDayType
AS
SELECT     dbo.AccountWorkingDayType.AccountWorkingDayTypeId, dbo.AccountWorkingDayType.AccountId, dbo.AccountWorkingDayType.AccountWorkingDayType, 
                      dbo.AccountWorkingDayType.HoursPerDay, dbo.AccountWorkingDayType.WeekStartDay, dbo.AccountWorkingDayType.CreatedByEmployeeId, 
                      dbo.AccountWorkingDayType.CreatedOn, dbo.AccountWorkingDayType.ModifiedByEmployeeId, dbo.AccountWorkingDayType.ModifiedOn, 
                      dbo.AccountWorkingDayType.IsDisabled, dbo.SystemWorkingDay.WorkingDay, dbo.AccountWorkingDayType.MasterWorkingDayTypeId, 
                      dbo.SystemWorkingDay.SQLServerWeekDayNo, dbo.AccountWorkingDayType.MinimumHoursPerDay, dbo.AccountWorkingDayType.MaximumHoursPerDay, 
                      dbo.AccountWorkingDayType.MinimumHoursPerWeek, dbo.AccountWorkingDayType.MaximumHoursPerWeek, 
                      dbo.vueAccountTimesheetPeriodType.SystemTimesheetPeriodTypeId, dbo.vueAccountTimesheetPeriodType.SystemInitialDaysOfThePeriodId, 
                      dbo.vueAccountTimesheetPeriodType.InitialDayOfTheMonth, dbo.vueAccountTimesheetPeriodType.SystemTimesheetPeriodType, 
                      dbo.vueAccountTimesheetPeriodType.SystemInitialDaysOfThePeriod, dbo.vueAccountTimesheetPeriodType.SystemInitialDayOfFirstPeriod, 
                      dbo.vueAccountTimesheetPeriodType.SystemInitialDayOfLastPeriod, dbo.vueAccountTimesheetPeriodType.AccountTimesheetPeriodTypeId, 
                      dbo.AccountWorkingDayType.TimesheetOverdueAfterDays, ISNULL(dbo.AccountWorkingDayType.MinimumPercentagePerDay, 0) AS MinimumPercentagePerDay, 
                      ISNULL(dbo.AccountWorkingDayType.MaximumPercentagePerDay, 100) AS MaximumPercentagePerDay, 
                      ISNULL(dbo.AccountWorkingDayType.MinimumPercentagePerWeek, 0) AS MinimumPercentagePerWeek, 
                      ISNULL(dbo.AccountWorkingDayType.MaximumPercentagePerWeek, 500) AS MaximumPercentagePerWeek, 
                      dbo.AccountWorkingDayType.LockAllPreviousTimesheets, dbo.AccountWorkingDayType.LockAllFutureTimesheets, 
                      dbo.AccountWorkingDayType.LockPreviousTimesheetPeriods, dbo.AccountWorkingDayType.LockFutureTimsheetPeriods, 
                      dbo.AccountWorkingDayType.LockPreviousNextMonthTimesheetOn, dbo.AccountWorkingDayType.EnableBalanceValidationForTimeOff,
                      dbo.AccountWorkingDayType.LockAllPeriodExceptPrevious, dbo.AccountWorkingDayType.LockAllPeriodExceptNext, 
                      dbo.AccountWorkingDayType.ShowClockStartEndEmployee
FROM         dbo.AccountWorkingDayType LEFT OUTER JOIN
                      dbo.vueAccountTimesheetPeriodType ON 
                      dbo.AccountWorkingDayType.AccountTimesheetPeriodTypeId = dbo.vueAccountTimesheetPeriodType.AccountTimesheetPeriodTypeId LEFT OUTER JOIN
                      dbo.SystemWorkingDay ON dbo.AccountWorkingDayType.WeekStartDay = dbo.SystemWorkingDay.WorkingDayNo