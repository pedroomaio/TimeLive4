
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskDescription, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeId AS TimeEntryAccountEmployeeId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployee.EmployeeManagerId, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, dbo.AccountProjectTask.IsBillable, 
                      CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END AS BillableTotalMinutes, 
                      CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END AS NonBillableTotalMinutes, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, 
                      dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId, dbo.AccountEmployeeTimeEntryApproval.ApprovedOn
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalPath.AccountApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId ON 
                      dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEmployeeTimeEntryApproval.AccountProjectId AND 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId AND
                       dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId AND 
                      dbo.AccountEmployeeTimeEntryApproval.PreviousStatus <> 1 AND dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1