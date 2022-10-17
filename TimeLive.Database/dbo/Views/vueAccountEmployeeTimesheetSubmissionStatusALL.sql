
CREATE VIEW dbo.vueAccountEmployeeTimesheetSubmissionStatusALL
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.AccountDepartment.DepartmentName, 
                      dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 0 AS NotEntered, SUM(1) AS Entered, 
                      (CASE WHEN dbo.vueAccountEmployeeTimeEntry.Submitted = 1 THEN (COUNT(dbo.vueAccountEmployeeTimeEntry.Submitted)) ELSE 0 END) AS Submitted, 
                      SUM(CASE WHEN Approved = 1 THEN 1 ELSE 0 END) AS Approved, SUM(CASE WHEN Rejected = 1 THEN 1 ELSE 0 END) AS Rejected, dbo.AccountRole.Role, 
                      dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.AccountEmployee.IsDisabled
FROM         dbo.vueAccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId
GROUP BY dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.AccountDepartment.DepartmentName, dbo.vueAccountEmployeeTimeEntry.Submitted, 
                      dbo.AccountEmployee.IsDisabled