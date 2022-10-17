
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApproval
AS                      
SELECT     dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId AS TimeOffAccountEmployeeId, dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, 
                      dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                      dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, 
                      dbo.AccountEmployeeTimeOffRequest.Description, dbo.AccountEmployeeTimeOffRequest.ApprovedOn, 
                      dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.AccountId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.SystemApproverTypeId, 
                      dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId, dbo.AccountEmployeeTimeOffRequestApproval.ApprovedByEmployeeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.ApprovedOn AS ApprovedOnApproval, dbo.AccountEmployeeTimeOffRequestApproval.IsRejected, 
                      dbo.AccountEmployeeTimeOffRequestApproval.IsApproved, dbo.AccountEmployeeTimeOffRequestApproval.Comments, 
                      dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalTypeId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestApprovalId, dbo.AccountEmployee.FirstName, 
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
                      dbo.AccountApprovalType.AccountApprovalTypeId, dbo.AccountEmployee.EmployeeManagerId, 
                      dbo.AccountEmployeeTimeOffRequestApproval.CreatedByEmployeeId, dbo.AccountEmployeeTimeOffRequestApproval.CreatedOn, 
                      dbo.AccountEmployeeTimeOffRequestApproval.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOffRequestApproval.ModifiedOn, 
                      dbo.AccountProject.ProjectManagerEmployeeId AS ProjectManagerId, dbo.AccountProject.LeaderEmployeeId AS TeamLeadId, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployeeTimeOff.Available, 
                      CASE WHEN dbo.AccountWorkingDayType.HoursPerDay = 0 THEN 0 ELSE dbo.AccountEmployeeTimeOff.Available / dbo.AccountWorkingDayType.HoursPerDay END AS AvailableDay
FROM         dbo.AccountApprovalType INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountEmployee.TimeOffApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId INNER JOIN
                      dbo.AccountWorkingDayType ON 
                      dbo.AccountEmployee.AccountWorkingDayTypeId = dbo.AccountWorkingDayType.AccountWorkingDayTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeOff RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequest LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployeeTimeOffRequest.AccountId = dbo.AccountPreferences.AccountId ON 
                      dbo.AccountEmployeeTimeOff.AccountEmployeeId = dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId AND 
                      dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeOffRequest.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountTimeOffType ON 
                      dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequestApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId AND 
                      dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId = dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId