    
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApprovalDetail
AS                   
SELECT     dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId AS TimeOffAccountEmployeeId, dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, 
                      dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                      dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, 
                      dbo.AccountEmployeeTimeOffRequest.Description, dbo.AccountEmployeeTimeOffRequest.ApprovedOn, 
                      dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.AccountId, 
                      dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId, dbo.AccountEmployeeTimeOffRequestApproval.ApprovedByEmployeeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.ApprovedOn AS ApprovedOnApproval, dbo.AccountEmployeeTimeOffRequestApproval.IsRejected, 
                      dbo.AccountEmployeeTimeOffRequestApproval.IsApproved, dbo.AccountEmployeeTimeOffRequestApproval.Comments, 
                      dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalTypeId, dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestApprovalId, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS FullName, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2
                       AND dbo.AccountEmployee.IsDisabled = 0 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ',
                       '') + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeNameWithCode, 
                      dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.EmployeeManagerId, dbo.AccountEmployeeTimeOffRequestApproval.CreatedByEmployeeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.CreatedOn, dbo.AccountEmployeeTimeOffRequestApproval.ModifiedByEmployeeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.ModifiedOn, dbo.AccountProject.ProjectManagerEmployeeId AS ProjectManagerId, 
                      dbo.AccountProject.LeaderEmployeeId AS TeamLeadId, dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployeeTimeOff.Available, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApproverName, dbo.SystemApproverType.SystemApproverType
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.AccountPreferences RIGHT OUTER JOIN
                      dbo.AccountTimeOffType RIGHT OUTER JOIN
                      dbo.SystemApproverType INNER JOIN
                      dbo.AccountApprovalPath ON dbo.SystemApproverType.SystemApproverTypeId = dbo.AccountApprovalPath.SystemApproverTypeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequestApproval INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.AccountEmployeeTimeOffRequestApproval.ApprovedByEmployeeId = AccountEmployee_1.AccountEmployeeId RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequest INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId = dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId
                       ON dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId ON 
                      dbo.AccountTimeOffType.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId ON 
                      dbo.AccountPreferences.AccountId = dbo.AccountEmployeeTimeOffRequest.AccountId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeOffRequest.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeOff ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId AND 
                      dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId
WHERE     (dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalTypeId IS NOT NULL)