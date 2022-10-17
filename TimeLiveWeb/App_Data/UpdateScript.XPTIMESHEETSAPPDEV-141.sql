USE [TIMELIVE]
GO

Alter table AccountEmployeeTimeOffRequest
Alter column RequestSubmitDate DateTIme NULL

GO
/****** Object:  View [dbo].[vueAccountEmployeeTimeOffRequest]    Script Date: 04/01/2017 11:47:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vueAccountEmployeeTimeOffRequest]
AS
SELECT        dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId, 
                         dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                         dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, dbo.AccountEmployeeTimeOffRequest.Description, 
                         dbo.AccountEmployeeTimeOffRequest.ApprovedOn, dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.CreatedByEmployee, 
                         dbo.AccountEmployeeTimeOffRequest.CreatedOn, dbo.AccountEmployeeTimeOffRequest.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOffRequest.ModifiedOn, 
                         dbo.AccountEmployeeTimeOffRequest.AccountId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                         dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, CASE WHEN dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate IS NULL THEN 'Saved'  WHEN (dbo.AccountEmployeeTimeOffRequest.Approved IS NULL OR
                         dbo.AccountEmployeeTimeOffRequest.Approved = 0) AND (dbo.AccountEmployeeTimeOffRequest.Rejected IS NULL OR
                         dbo.AccountEmployeeTimeOffRequest.Rejected = 0) 
                         THEN 'Submitted' WHEN dbo.AccountEmployeeTimeOffRequest.Approved = 1 THEN 'Approved' WHEN dbo.AccountEmployeeTimeOffRequest.Rejected = 1 THEN 'Rejected' END AS ApprovalStatus, 
                         dbo.AccountEmployeeTimeOff.Earned, dbo.AccountEmployeeTimeOff.Consume, dbo.AccountEmployeeTimeOff.Available, dbo.AccountEmployeeTimeOff.LastEarnedDate, 
                         dbo.AccountEmployeeTimeOff.CarryForward, dbo.AccountEmployeeTimeOff.LastResetDate, dbo.AccountEmployeeTimeOffRequest.AccountProjectId, dbo.AccountTimeOffType.Paid, dbo.AccountTimeOffType.Color, 
                         dbo.AccountTimeOffType.BriefExplanation, dbo.AccountTimeOffType.ScheduleWeekends 
						 FROM            
						 dbo.AccountEmployeeTimeOffRequest INNER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                         dbo.AccountEmployeeTimeOff ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId AND 
                         dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId LEFT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
GO



ALTER VIEW [dbo].[vueAccountEmployeeTimeOff]
AS
SELECT        dbo.AccountTimeOffType.AccountTimeOffType, aeto.AccountEmployeeTimeOffId, aeto.AccountEmployeeId, aeto.AccountId, 
						 aeto.AccountTimeOffTypeId, dbo.vueAccountWorkingDayType.HoursPerDay, 
						 ROUND(aeto.Earned / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) AS EarnedDay, 
						 ROUND(aeto.Consume / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) 
						 AS ConsumeDay, ISNULL(ROUND((aeto.Available - ISNULL(SUM(vtorRequested.HoursOff), 0)) / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2), 0) AS AvailableDay,
						 ROUND(aeto.Earned, 2) AS Earned, ROUND(aeto.Consume, 2) AS Consume, ISNULL(ROUND(aeto.Available - ISNULL(SUM(vtorRequested.HoursOff), 0), 2), 0) AS Available,
						  aeto.LastEarnedDate, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
						 ROUND(aeto.CarryForward / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) 
						 AS CarryForwardDay, ROUND(aeto.CarryForward, 2) AS CarryForward, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountTimeOffPolicy.MasterTimeOffPolicyId, 
						 aeto.AccountTimeOffPolicyId, aeto.LastResetDate, aeto.IsDisabled, dbo.AccountTimeOffPolicyDetail.IsInclude, 
						 dbo.vueAccountEmployee.AccountWorkingDayTypeId, dbo.AccountTimeOffType.Color, dbo.AccountTimeOffType.Paid, dbo.AccountTimeOffType.BriefExplanation, dbo.AccountTimeOffType.ScheduleWeekends,
						 ISNULL((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Submitted'), 0) AS RequestedHours,
						 ISNULL(ROUND((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Submitted') / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2), 0) AS RequestedDays,
						 ISNULL((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Approved'), 0) AS ApprovedHours,
						 ISNULL(ROUND((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Approved') / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2), 0) AS ApprovedDays,
						 ISNULL((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Rejected'), 0) AS RejectedHours,
						 ISNULL(ROUND((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Rejected') / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2), 0) AS RejectedDays,
						 ISNULL((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Saved'), 0) AS SavedHours,
						 ISNULL(ROUND((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Saved') / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2), 0) AS SavedDays
FROM            dbo.AccountEmployeeTimeOff as aeto INNER JOIN
						 dbo.AccountTimeOffPolicy ON aeto.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
						 dbo.AccountTimeOffPolicyDetail ON dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyId INNER JOIN
						 dbo.vueAccountEmployee ON aeto.AccountEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId INNER JOIN
						 dbo.vueAccountWorkingDayType ON dbo.vueAccountEmployee.AccountWorkingDayTypeId = dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId LEFT OUTER JOIN
						 dbo.AccountTimeOffType ON dbo.AccountTimeOffPolicyDetail.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId AND 
						 aeto.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
	LEFT OUTER JOIN vueAccountEmployeeTimeOffRequest as vtorRequested ON aeto.AccountTimeOffTypeId = vtorRequested.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtorRequested.AccountEmployeeId AND (vtorRequested.ApprovalStatus = 'Submitted' OR vtorRequested.ApprovalStatus ='Saved')
WHERE        (dbo.AccountTimeOffType.IsDisabled <> 1)
GROUP BY dbo.AccountTimeOffType.AccountTimeOffType, aeto.AccountEmployeeTimeOffId, aeto.AccountEmployeeId, aeto.AccountId, 
						 aeto.AccountTimeOffTypeId, dbo.vueAccountWorkingDayType.HoursPerDay, aeto.Earned, aeto.Consume, aeto.Available,
						 aeto.LastEarnedDate, dbo.AccountTimeOffType.IsTimeOffRequestRequired, aeto.CarryForward,
						 dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountTimeOffPolicy.MasterTimeOffPolicyId, aeto.AccountTimeOffPolicyId,
						 aeto.LastResetDate, aeto.IsDisabled, dbo.AccountTimeOffPolicyDetail.IsInclude, dbo.vueAccountEmployee.AccountWorkingDayTypeId,
						 dbo.AccountTimeOffType.Color, dbo.AccountTimeOffType.Paid, dbo.AccountTimeOffType.BriefExplanation, dbo.AccountTimeOffType.ScheduleWeekends

GO



GO



ALTER VIEW [dbo].[vueAccountEmployeeTimeOffRequestApprovalPending]
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
                      dbo.vueAccountEmployeeTimeOffRequestApproval.Rejected = 0) AND (dbo.vueAccountEmployeeTimeOffRequestApproval .RequestSubmitDate IS NOT NULL ) AND
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
GO

