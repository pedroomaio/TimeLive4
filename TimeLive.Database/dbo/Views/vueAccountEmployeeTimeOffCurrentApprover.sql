
CREATE VIEW dbo.vueAccountEmployeeTimeOffCurrentApprover
AS
SELECT     dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS ApproverEmployeeName, TimesheetApprover.ApproverEmployeeID, 
                      TimesheetApprover.ApproverType, TimesheetApprover.ApprovalPathSequence, TimesheetApprover.AccountEmployeeTimeOffRequestId 
FROM         (SELECT     CASE WHEN SystemApproverTypeId = 1 THEN AccountProject.LeaderEmployeeId WHEN SystemApproverTypeId = 2 THEN AccountProject.ProjectManagerEmployeeId
                                               WHEN SystemApproverTypeId = 3 THEN AccountApprovalPath.AccountEmployeeId WHEN SystemApproverTypeId = 4 THEN AccountApprovalPath.AccountExternalUserId
                                               WHEN SystemApproverTypeId = 5 THEN EM.AccountEmployeeId END AS ApproverEmployeeID, 
                                              CASE WHEN systemapprovertypeid = 1 THEN 'TL' WHEN systemapprovertypeid = 2 THEN 'PM' WHEN systemapprovertypeid = 3 THEN 'SEM' WHEN systemapprovertypeid
                                               = 4 THEN 'SEU' WHEN systemapprovertypeid = 5 THEN 'EM' END AS ApproverType, dbo.AccountApprovalPath.ApprovalPathSequence,
      dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId
                       FROM          dbo.AccountEmployeeTimeOffRequest LEFT OUTER JOIN
                                              dbo.AccountProject ON dbo.AccountEmployeeTimeOffRequest.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                        dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeID  LEFT OUTER JOIN
                                              dbo.AccountApprovalType ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountEmployee.TimeOffApprovalTypeId LEFT OUTER JOIN
                                              dbo.AccountApprovalPath ON dbo.AccountApprovalPath.AccountApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId LEFT OUTER JOIN
                                              dbo.AccountEmployee AS EM ON EM.AccountEmployeeId = dbo.AccountEmployee.EmployeeManagerId
                       WHERE       dbo.AccountEmployeeTimeOffRequest.Rejected <> 1 and 
                           (dbo.AccountApprovalPath.ApprovalPathSequence IN
                                                  (SELECT     TOP (1) ApprovalPathSequence
                                                    FROM          dbo.vueTimeOffApprovalSequence 
                                                       WHERE      (AccountEmployeeTimeOffRequestApprovalId IS NULL) AND (AccountEmployeeTimeOffRequestId = dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId)))) 
                      AS TimesheetApprover LEFT OUTER JOIN
                      dbo.AccountEmployee ON TimesheetApprover.ApproverEmployeeID = dbo.AccountEmployee.AccountEmployeeId