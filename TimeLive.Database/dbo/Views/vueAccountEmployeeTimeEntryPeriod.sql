
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPeriod
AS
SELECT     dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, 
                      dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, 
                      dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS TimeEntryEmployeeName, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS SubmittedBy
FROM         dbo.AccountEmployeeTimeEntryPeriod INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployeeTimeEntryPeriod.SubmittedBy = AccountEmployee_1.AccountEmployeeId