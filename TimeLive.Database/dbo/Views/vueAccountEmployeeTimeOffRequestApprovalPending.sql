
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApprovalPending
AS  
SELECT     dbo.vueAccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.TimeOffAccountEmployeeId, dbo.vueAccountEmployeeTimeOffRequestApproval.RequestSubmitDate, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.HoursOff, dbo.vueAccountEmployeeTimeOffRequestApproval.StartDate, dbo.vueAccountEmployeeTimeOffRequestApproval.EndDate, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.InApproval, dbo.vueAccountEmployeeTimeOffRequestApproval.Approved, dbo.vueAccountEmployeeTimeOffRequestApproval.Rejected, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.Description, dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedOn, dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedBy, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.DayOff, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountId, dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeOffRequestApproval.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountExternalUserId, dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovalPathSequence, 
                      CASE WHEN systemapprovertypeid = 1 THEN TeamLeadId WHEN systemapprovertypeid = 2 THEN ProjectManagerId WHEN systemapprovertypeid = 3 THEN AccountEmployeeId 
                      WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId END AS AccountEmployeeId, dbo.vueAccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedByEmployeeId, MAX(dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedOnApproval) AS ApprovedOnApproval, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.IsRejected, dbo.vueAccountEmployeeTimeOffRequestApproval.IsApproved, MAX(dbo.vueAccountEmployeeTimeOffRequestApproval.Comments) AS Comments, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.TimeOffApprovalTypeId, dbo.vueAccountEmployeeTimeOffRequestApproval.FirstName, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.LastName, dbo.vueAccountEmployeeTimeOffRequestApproval.FullName, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.IsTimeOffRequestRequired, dbo.vueAccountEmployeeTimeOffRequestApproval.EMailAddress, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalTypeId, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.EmployeeManagerId, dbo.vueAccountEmployeeTimeOffRequestApproval.CreatedByEmployeeId, 
                      MAX(dbo.vueAccountEmployeeTimeOffRequestApproval.CreatedOn) AS CreatedOn, dbo.vueAccountEmployeeTimeOffRequestApproval.ProjectManagerId, dbo.vueAccountEmployeeTimeOffRequestApproval.TeamLeadId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.EmployeeNameWithCode, isnull(dbo.vueAccountEmployeeTimeOffRequestApproval.Available,0) as Available, 
                      isnull(dbo.vueAccountEmployeeTimeOffRequestApproval.AvailableDay,0) as AvailableDay
FROM         dbo.vueAccountEmployeeTimeOffRequestApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeOffRequestApproval.Approved IS NULL OR
                      dbo.vueAccountEmployeeTimeOffRequestApproval.Approved = 0) AND (dbo.vueAccountEmployeeTimeOffRequestApproval.Rejected IS NULL OR
                      dbo.vueAccountEmployeeTimeOffRequestApproval.Rejected = 0) AND 
                      (dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovalPathSequence IN
                          (SELECT     TOP (1) ApprovalPathSequence
                            FROM          dbo.vueTimeOffApprovalSequence AS vueTimeOffApprovalSequence_1
                            WHERE      (AccountEmployeeTimeOffRequestApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeOffRequestId = dbo.vueAccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId)))
GROUP BY dbo.vueAccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.TimeOffAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.RequestSubmitDate, dbo.vueAccountEmployeeTimeOffRequestApproval.HoursOff, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.StartDate, dbo.vueAccountEmployeeTimeOffRequestApproval.EndDate, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.InApproval, dbo.vueAccountEmployeeTimeOffRequestApproval.Approved, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.Rejected, dbo.vueAccountEmployeeTimeOffRequestApproval.Description, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedOn, dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedBy, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.DayOff, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovalTypeName, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovalPathSequence, 
                      CASE WHEN systemapprovertypeid = 1 THEN TeamLeadId WHEN systemapprovertypeid = 2 THEN ProjectManagerId WHEN systemapprovertypeid = 3
                       THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId
                       END, dbo.vueAccountEmployeeTimeOffRequestApproval.TimeOffApprovalPathId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.ApprovedByEmployeeId, dbo.vueAccountEmployeeTimeOffRequestApproval.IsRejected, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.IsApproved, dbo.vueAccountEmployeeTimeOffRequestApproval.TimeOffApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.FirstName, dbo.vueAccountEmployeeTimeOffRequestApproval.LastName, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.FullName, dbo.vueAccountEmployeeTimeOffRequestApproval.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.IsTimeOffRequestRequired, dbo.vueAccountEmployeeTimeOffRequestApproval.EMailAddress, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalTypeId, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.EmployeeManagerId, dbo.vueAccountEmployeeTimeOffRequestApproval.CreatedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.ProjectManagerId, dbo.vueAccountEmployeeTimeOffRequestApproval.TeamLeadId, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.EmployeeNameWithCode, dbo.vueAccountEmployeeTimeOffRequestApproval.Available, 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AvailableDay