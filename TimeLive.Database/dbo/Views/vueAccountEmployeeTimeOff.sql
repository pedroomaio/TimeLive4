
CREATE VIEW [dbo].[vueAccountEmployeeTimeOff]
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