
CREATE VIEW dbo.rptvueTimeEntryPeriodicSubmission
AS
SELECT     AccountId, AccountEmployeeId, EmployeeName, SystemTimesheetPeriodType, EmployeeWeekStartDay, SystemInitialDayOfFirstPeriod, 
                      SystemInitialDayOfLastPeriod, InitialDayOfTheMonth, CASE WHEN CultureInfoName IS NULL 
                      THEN 'en-us' WHEN CultureInfoName = 'auto' THEN 'en-us' ELSE CultureInfoName END AS CultureInfoName
FROM         dbo.vueAccountEmployee