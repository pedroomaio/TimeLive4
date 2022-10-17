
CREATE  VIEW [dbo].[vueProjectSummary]
AS
SELECT     ProjectName, EmployeeName, TaskName, TotalTime, AccountEmployeeId, AccountProjectId, TimeEntryDate,
AccountId, AccountPartyId, PartyName, AccountProjectTaskId, TotalMinutes / 60 AS TotalMinutes, Approved
FROM         dbo.vueAccountEmployeeTimeEntry
WHERE     (IsTimeOff IS NULL) OR
                      (IsTimeOff = 0)