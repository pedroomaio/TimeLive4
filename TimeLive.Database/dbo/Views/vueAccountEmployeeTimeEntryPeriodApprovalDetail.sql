
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPeriodApprovalDetail
AS
SELECT     dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId, 
                      dbo.AccountEmployeeTimeEntryApproval.ApprovedOn, dbo.AccountEmployeeTimeEntryApproval.Comments, 
                      dbo.AccountEmployeeTimeEntryApproval.IsReject, dbo.AccountEmployeeTimeEntryApproval.IsApproved, 
                      dbo.SystemApproverType.SystemApproverType, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS ApproverName, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS TimeEntryEmployeeName, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, CAST(dbo.AccountEmployeeTimeEntryApproval.ApprovedOn AS nvarchar(20)) AS ApprovalDate, 
                      dbo.AccountEmployeeTimeEntryApproval.BatchId, dbo.AccountEmployeeTimeEntryApprovalProject.Submitted, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.InApproval, dbo.AccountEmployeeTimeEntryApprovalProject.IsRejected, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.Approved, dbo.AccountEmployeeTimeEntryApprovalProject.Rejected
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId INNER
                       JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeId = AccountEmployee_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApprovalProject ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryApprovalProjectId
                       AND 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId
                       LEFT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountApprovalPath INNER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId INNER JOIN
                      dbo.SystemApproverType ON dbo.AccountApprovalPath.SystemApproverTypeId = dbo.SystemApproverType.SystemApproverTypeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId
                       LEFT OUTER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId
WHERE     (dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId IS NOT NULL) OR
                      (dbo.AccountApprovalType.AccountApprovalTypeId IS NULL)