
CREATE VIEW dbo.vueTimeSheetApprovalSequenceForTimeOff
AS
SELECT     dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountEmployee.TimeOffApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId AND 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1 AND 
                      dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId
WHERE     (dbo.AccountEmployeeTimeEntry.IsTimeOff = 1) AND (dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId IS NULL)