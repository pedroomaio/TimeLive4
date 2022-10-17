
CREATE VIEW dbo.vueApprovedCountApprovalProjects
AS
SELECT     dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, COUNT(dbo.AccountEmployeeTimeEntry.Approved) AS ApprovedCount
FROM         dbo.AccountEmployeeTimeEntryPeriod INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId
WHERE     (dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId IS NULL) AND (dbo.AccountEmployeeTimeEntry.Submitted = 1) AND 
                      (dbo.AccountEmployeeTimeEntry.Rejected Is NULL Or dbo.AccountEmployeeTimeEntry.Rejected = 0) AND (dbo.AccountEmployeeTimeEntry.Approved = 1)
GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId