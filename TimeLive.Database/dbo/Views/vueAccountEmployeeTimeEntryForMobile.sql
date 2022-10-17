
CREATE VIEW dbo.vueAccountEmployeeTimeEntryForMobile
AS 
SELECT     dbo.AccountEmployee.AccountEmployeeId, MAX(dbo.AccountEmployee.AccountId) AS AccountId, SUM(DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, 
                      CASE WHEN dbo.AccountPreferences.CultureInfoName IS NULL OR
                      dbo.AccountPreferences.CultureInfoName = 'auto' THEN 'en-us' ELSE dbo.AccountPreferences.CultureInfoName END AS CultureInfoName, 
                      MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) AS EmployeeName, 
                      MAX(dbo.vueAccountWorkingDayType.HoursPerDay) AS HoursPerDay, MAX(dbo.vueAccountWorkingDayType.WeekStartDay) 
                      AS EmployeeWeekStartDay, MAX(dbo.vueAccountWorkingDayType.SystemTimesheetPeriodTypeId) AS SystemTimesheetPeriodTypeId, 
                      MAX(dbo.vueAccountWorkingDayType.SystemInitialDaysOfThePeriodId) AS SystemInitialDaysOfThePeriodId, 
                      MAX(ISNULL(dbo.vueAccountWorkingDayType.InitialDayOfTheMonth, 1)) AS InitialDayOfTheMonth, 
                      MAX(dbo.vueAccountWorkingDayType.SystemTimesheetPeriodType) AS SystemTimesheetPeriodType, 
                      MAX(dbo.vueAccountWorkingDayType.SystemInitialDaysOfThePeriod) AS SystemInitialDaysOfThePeriod, 
                      MAX(ISNULL(dbo.vueAccountWorkingDayType.SystemInitialDayOfFirstPeriod, 1)) AS SystemInitialDayOfFirstPeriod, 
                      MAX(ISNULL(dbo.vueAccountWorkingDayType.SystemInitialDayOfLastPeriod, 16)) AS SystemInitialDayOfLastPeriod, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectId, dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                      dbo.AccountWorkType.AccountWorkTypeId, dbo.AccountWorkType.AccountWorkType
FROM         dbo.AccountWorkType RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId ON 
                      dbo.AccountWorkType.AccountWorkTypeId = dbo.AccountEmployeeTimeEntry.AccountWorkTypeId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountEmployeeTimeEntry.AccountPartyId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.vueAccountWorkingDayType ON 
                      dbo.AccountEmployee.AccountWorkingDayTypeId = dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId
GROUP BY dbo.AccountEmployee.AccountEmployeeId, dbo.AccountPreferences.CultureInfoName, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectId, dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                      dbo.AccountWorkType.AccountWorkTypeId, dbo.AccountWorkType.AccountWorkType