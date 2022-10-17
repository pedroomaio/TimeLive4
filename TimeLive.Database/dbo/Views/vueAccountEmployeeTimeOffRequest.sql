
CREATE VIEW [dbo].[vueAccountEmployeeTimeOffRequest]
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