
CREATE VIEW dbo.vueTotalApprovalProjects
AS
SELECT     dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, COUNT(dbo.AccountEmployeeTimeEntry.Approved) AS TotalCount
FROM         dbo.AccountEmployeeTimeEntryPeriod INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId
WHERE     (dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId IS NULL)
GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId