
CREATE VIEW dbo.vueTimesheetApprovalSequence
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEmployeeTimeEntryApproval.AccountProjectId AND 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId AND
                       dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId AND 
                      dbo.AccountEmployeeTimeEntryApproval.PreviousStatus <> 1 AND dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1