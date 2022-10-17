ALTER TABLE AccountTimeOffType
ADD Paid Bit NOT NULL DEFAULT(0), Color varchar(10) NOT NULL DEFAULT('#000000'), BriefExplanation varchar(100) Not Null Default('No description'), ScheduleWeekends Bit NOT NULL DEFAULT(0)
GO

ALTER TABLE AccountEmployeeTimeOffRequest ADD Deleted BIT NOT NULL DEFAULT 0
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
						 ISNULL(ROUND((SELECT SUM(vtor.HoursOff) FROM vueAccountEmployeeTimeOffRequest as vtor WHERE aeto.AccountTimeOffTypeId = vtor.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtor.AccountEmployeeId AND vtor.ApprovalStatus = 'Rejected') / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2), 0) AS RejectedDays
FROM            dbo.AccountEmployeeTimeOff as aeto INNER JOIN
						 dbo.AccountTimeOffPolicy ON aeto.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
						 dbo.AccountTimeOffPolicyDetail ON dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyId INNER JOIN
						 dbo.vueAccountEmployee ON aeto.AccountEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId INNER JOIN
						 dbo.vueAccountWorkingDayType ON dbo.vueAccountEmployee.AccountWorkingDayTypeId = dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId LEFT OUTER JOIN
						 dbo.AccountTimeOffType ON dbo.AccountTimeOffPolicyDetail.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId AND 
						 aeto.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
	LEFT OUTER JOIN vueAccountEmployeeTimeOffRequest as vtorRequested ON aeto.AccountTimeOffTypeId = vtorRequested.AccountTimeOffTypeId  AND aeto.AccountEmployeeId = vtorRequested.AccountEmployeeId AND vtorRequested.ApprovalStatus = 'Submitted'
WHERE        (dbo.AccountTimeOffType.IsDisabled <> 1)
GROUP BY dbo.AccountTimeOffType.AccountTimeOffType, aeto.AccountEmployeeTimeOffId, aeto.AccountEmployeeId, aeto.AccountId, 
						 aeto.AccountTimeOffTypeId, dbo.vueAccountWorkingDayType.HoursPerDay, aeto.Earned, aeto.Consume, aeto.Available,
						 aeto.LastEarnedDate, dbo.AccountTimeOffType.IsTimeOffRequestRequired, aeto.CarryForward,
						 dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountTimeOffPolicy.MasterTimeOffPolicyId, aeto.AccountTimeOffPolicyId,
						 aeto.LastResetDate, aeto.IsDisabled, dbo.AccountTimeOffPolicyDetail.IsInclude, dbo.vueAccountEmployee.AccountWorkingDayTypeId,
						 dbo.AccountTimeOffType.Color, dbo.AccountTimeOffType.Paid, dbo.AccountTimeOffType.BriefExplanation, dbo.AccountTimeOffType.ScheduleWeekends

GO

ALTER VIEW [dbo].[vueAccountEmployeeTimeOffRequest]
AS
SELECT        dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId, 
                         dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                         dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, dbo.AccountEmployeeTimeOffRequest.Description, 
                         dbo.AccountEmployeeTimeOffRequest.ApprovedOn, dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.CreatedByEmployee, 
                         dbo.AccountEmployeeTimeOffRequest.CreatedOn, dbo.AccountEmployeeTimeOffRequest.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOffRequest.ModifiedOn, 
                         dbo.AccountEmployeeTimeOffRequest.AccountId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                         dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, CASE WHEN (dbo.AccountEmployeeTimeOffRequest.Approved IS NULL OR
                         dbo.AccountEmployeeTimeOffRequest.Approved = 0) AND (dbo.AccountEmployeeTimeOffRequest.Rejected IS NULL OR
                         dbo.AccountEmployeeTimeOffRequest.Rejected = 0) 
                         THEN 'Submitted' WHEN dbo.AccountEmployeeTimeOffRequest.Approved = 1 THEN 'Approved' WHEN dbo.AccountEmployeeTimeOffRequest.Rejected = 1 THEN 'Rejected' END AS ApprovalStatus, 
                         dbo.AccountEmployeeTimeOff.Earned, dbo.AccountEmployeeTimeOff.Consume, dbo.AccountEmployeeTimeOff.Available, dbo.AccountEmployeeTimeOff.LastEarnedDate, 
                         dbo.AccountEmployeeTimeOff.CarryForward, dbo.AccountEmployeeTimeOff.LastResetDate, dbo.AccountEmployeeTimeOffRequest.AccountProjectId, dbo.AccountTimeOffType.Paid, dbo.AccountTimeOffType.Color, 
                         dbo.AccountTimeOffType.BriefExplanation, dbo.AccountTimeOffType.ScheduleWeekends, dbo.AccountEmployeeTimeOffRequest.Deleted 
FROM            dbo.AccountEmployeeTimeOffRequest INNER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                         dbo.AccountEmployeeTimeOff ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId AND 
                         dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId LEFT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
WHERE dbo.AccountEmployeeTimeOffRequest.Deleted = 0
GO

ALTER VIEW [dbo].[VueAccountEmployeeTimeOffTypeIsInclude]
AS
SELECT dbo.AccountEmployee.AccountEmployeeId, b.AccountTimeOffTypeId, b.AccountTimeOffType, b.IsTimeOffRequestRequired, b.AccountId, b.CreatedByEmployeeId, b.CreatedOn, b.ModifiedByEmployeeId, b.ModifiedOn, 
				  b.IsDisabled, b.MasterTimeOffTypeId, a.IsInclude, b.ScheduleWeekends
FROM     dbo.AccountTimeOffPolicyDetail AS a INNER JOIN
				  dbo.AccountTimeOffType AS b ON a.AccountTimeOffTypeId = b.AccountTimeOffTypeId INNER JOIN
				  dbo.AccountTimeOffPolicy ON a.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
				  dbo.AccountEmployee ON dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId = dbo.AccountEmployee.AccountTimeOffPolicyId

GO


/* Desfazer as alterações anteriores para o delete e update dos TimeOffRequests  -> Remover flag Deleted */

GO
ALTER TABLE [dbo].[AccountEmployeeTimeOffRequest] DROP CONSTRAINT [DF__AccountEm__Delet__3E2DB63A];


GO
ALTER TABLE [dbo].[AccountEmployeeTimeOffRequest] DROP COLUMN [Deleted];


GO

ALTER VIEW [dbo].[vueAccountEmployeeTimeOffRequest]
AS
SELECT        dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId, 
                         dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                         dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, dbo.AccountEmployeeTimeOffRequest.Description, 
                         dbo.AccountEmployeeTimeOffRequest.ApprovedOn, dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.CreatedByEmployee, 
                         dbo.AccountEmployeeTimeOffRequest.CreatedOn, dbo.AccountEmployeeTimeOffRequest.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOffRequest.ModifiedOn, 
                         dbo.AccountEmployeeTimeOffRequest.AccountId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                         dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, CASE WHEN (dbo.AccountEmployeeTimeOffRequest.Approved IS NULL OR
                         dbo.AccountEmployeeTimeOffRequest.Approved = 0) AND (dbo.AccountEmployeeTimeOffRequest.Rejected IS NULL OR
                         dbo.AccountEmployeeTimeOffRequest.Rejected = 0) 
                         THEN 'Submitted' WHEN dbo.AccountEmployeeTimeOffRequest.Approved = 1 THEN 'Approved' WHEN dbo.AccountEmployeeTimeOffRequest.Rejected = 1 THEN 'Rejected' END AS ApprovalStatus, 
                         dbo.AccountEmployeeTimeOff.Earned, dbo.AccountEmployeeTimeOff.Consume, dbo.AccountEmployeeTimeOff.Available, dbo.AccountEmployeeTimeOff.LastEarnedDate, 
                         dbo.AccountEmployeeTimeOff.CarryForward, dbo.AccountEmployeeTimeOff.LastResetDate, dbo.AccountEmployeeTimeOffRequest.AccountProjectId, dbo.AccountTimeOffType.Paid, dbo.AccountTimeOffType.Color, 
                         dbo.AccountTimeOffType.BriefExplanation, dbo.AccountTimeOffType.ScheduleWeekends
FROM            dbo.AccountEmployeeTimeOffRequest INNER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                         dbo.AccountEmployeeTimeOff ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId AND 
                         dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId LEFT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
GO