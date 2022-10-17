
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff
AS
SELECT        dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.AccountEmployeeId AS TimeEntryAccountEmployeeId, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                         dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Description, 
                         dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.CreatedOn, dbo.AccountEmployeeTimeEntry.Rejected, 
                         dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployeeTimeEntry.IsTimeOff, dbo.AccountEmployeeTimeEntry.Hours, dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, 
                         dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountApprovalType.ApprovalTypeName, 
                         dbo.AccountApprovalType.AccountApprovalTypeId, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, 
                         dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountApprovalPath.AccountEmployeeId, dbo.AccountEmployee.EmployeeManagerId, dbo.AccountEmployeeTimeEntry.ModifiedOn, 
                         dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId, dbo.AccountEmployeeTimeEntryApproval.Comments, 
                         dbo.AccountEmployeeTimeEntryApproval.IsReject, dbo.AccountEmployee.EMailAddress, dbo.AccountTimeOffType.AccountTimeOffType, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                         * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, 
                         dbo.AccountEmployeeTimeOff.Available
FROM            dbo.AccountEmployeeTimeEntry INNER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId INNER JOIN
                         dbo.AccountApprovalType ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountEmployee.TimeOffApprovalTypeId INNER JOIN
                         dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId LEFT OUTER JOIN
                         dbo.AccountEmployeeTimeOff ON dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId AND 
                         dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId RIGHT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId LEFT OUTER JOIN
                         dbo.AccountEmployeeTimeEntryApproval ON dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId AND 
                         dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1 AND 
                         dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId
WHERE        (dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId IS NULL) AND (dbo.AccountEmployeeTimeEntry.IsTimeOff = 1)