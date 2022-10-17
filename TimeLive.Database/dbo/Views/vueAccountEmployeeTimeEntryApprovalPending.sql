
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPending
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, MAX(dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalId) 
                      AS TimeSheetApprovalId, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, dbo.vueAccountEmployeeTimeEntryApproval.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, dbo.vueAccountEmployeeTimeEntryApproval.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, dbo.vueAccountEmployeeTimeEntryApproval.Comments, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsReject, dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountId, dbo.vueAccountEmployeeTimeEntryApproval.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Description, dbo.vueAccountEmployeeTimeEntryApproval.Submitted, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EmployeeManagerId, dbo.vueAccountEmployeeTimeEntryApproval.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsBillable, dbo.vueAccountEmployeeTimeEntryApproval.BillableTotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApproval.NonBillableTotalMinutes, dbo.vueAccountEmployeeTimeEntryApproval.Rejected, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId, CONVERT(nvarchar(10), 
                      19000100 + ISNULL(dbo.vueAccountWorkingDay.WeekStartDay, 1)) AS EmployeeWeekStartDay, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType
FROM         dbo.AccountEmployeeTimeEntryPeriod INNER JOIN
                      dbo.vueAccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId ON 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId
                       LEFT OUTER JOIN
                      dbo.vueAccountWorkingDay INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountWorkingDay.AccountWorkingDayTypeId = dbo.AccountEmployee.AccountWorkingDayTypeId ON 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApproval.Approved = 0) AND (dbo.vueAccountEmployeeTimeEntryApproval.Submitted = 1) AND 
                      (dbo.vueAccountEmployeeTimeEntryApproval.Rejected IS NULL OR
                      dbo.vueAccountEmployeeTimeEntryApproval.Rejected = 0) AND 
                      (dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId IS NOT NULL) AND 
                      (dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence IN
                          (SELECT     TOP 1 ApprovalPathSequence
                            FROM          dbo.vueTimesheetApprovalSequence
                            WHERE      (TimeSheetApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId)))
GROUP BY dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, dbo.vueAccountEmployeeTimeEntryApproval.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EMailAddress, dbo.vueAccountEmployeeTimeEntryApproval.Description, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EmployeeManagerId, dbo.vueAccountEmployeeTimeEntryApproval.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsBillable, dbo.vueAccountEmployeeTimeEntryApproval.BillableTotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApproval.NonBillableTotalMinutes, dbo.vueAccountEmployeeTimeEntryApproval.Rejected, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Approved, dbo.vueAccountEmployeeTimeEntryApproval.Submitted, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId, dbo.vueAccountWorkingDay.WeekStartDay, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType