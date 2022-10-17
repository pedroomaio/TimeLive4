
CREATE VIEW dbo.vueTimesheetSequenceForApprovalPendingEmail
AS
SELECT   
  dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, 
  dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
					  min(dbo.AccountApprovalPath.ApprovalPathSequence) as ApprovalPathSequence,
                      dbo.AccountProject.AccountProjectId
FROM         dbo.AccountApprovalType INNER JOIN
                      dbo.AccountEmployeeTimeEntryApprovalProject INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntryApprovalProject.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountProject.TimeSheetApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId
					   LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountApprovalPath.ApprovalPathSequence = dbo.AccountEmployeeTimeEntryApproval.ApprovalPathSequence AND 
                      dbo.AccountEmployeeTimeEntryApproval.PreviousStatus <> 1 AND dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1 AND 
                      dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId
                       AND dbo.AccountEmployeeTimeEntryApprovalProject.AccountProjectId = dbo.AccountEmployeeTimeEntryApproval.AccountProjectId
					    RIGHT OUTER JOIN                      dbo.AccountEmployee
					   RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId ON 
                      dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId
		where TimeSheetApprovalId IS NULL
		group by   dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId,   dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountProject.AccountProjectId