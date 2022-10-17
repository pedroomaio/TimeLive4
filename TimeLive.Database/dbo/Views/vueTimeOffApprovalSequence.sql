
CREATE VIEW dbo.vueTimeOffApprovalSequence
AS
SELECT     dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployee.TimeOffApprovalTypeId, 
                      dbo.AccountApprovalType.AccountApprovalTypeId, dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestApprovalId
FROM         dbo.AccountApprovalType INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountEmployee.TimeOffApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequest ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequestApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId AND 
                      dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId = dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId AND 
                      dbo.AccountEmployeeTimeOffRequestApproval.IsRejected <> 1