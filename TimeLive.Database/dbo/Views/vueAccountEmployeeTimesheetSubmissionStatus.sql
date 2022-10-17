
CREATE VIEW dbo.vueAccountEmployeeTimesheetSubmissionStatus
AS
SELECT     AccountEmployeeId, EmployeeName, DepartmentName, TimeEntryDate, NotEntered, SUM(Submitted) AS Submitted, Approved, Rejected, Role, AccountId, Entered, 
                      IsDisabled
FROM         dbo.vueAccountEmployeeTimesheetSubmissionStatusALL
GROUP BY AccountEmployeeId, EmployeeName, DepartmentName, TimeEntryDate, NotEntered, Approved, Rejected, Role, AccountId, Entered, IsDisabled