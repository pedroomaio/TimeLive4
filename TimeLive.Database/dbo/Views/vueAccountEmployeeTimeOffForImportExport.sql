
CREATE VIEW dbo.vueAccountEmployeeTimeOffForImportExport
AS
SELECT     dbo.AccountEmployeeTimeEntry.TimeEntryDate, ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2) AS TotalTime, dbo.AccountTimeOffType.AccountTimeOffType, 
                      CASE WHEN dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountEmployeeTimeEntry.Description, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountProject.ProjectName, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeId, dbo.AccountEmployeeTimeEntry.Submitted
FROM         dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId
WHERE     (dbo.AccountEmployeeTimeEntry.IsTimeOff = 1) AND (dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId IS NULL)