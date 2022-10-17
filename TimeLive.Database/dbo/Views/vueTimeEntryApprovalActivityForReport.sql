
CREATE VIEW dbo.vueTimeEntryApprovalActivityForReport
AS
SELECT     dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId, dbo.AccountEmployeeTimeEntryApproval.ApprovedOn, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountEmployeeTimeEntryForReport.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryForReport.ProjectName, dbo.vueAccountEmployeeTimeEntryForReport.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryForReport.TotalTime, dbo.vueAccountEmployeeTimeEntryForReport.StartTime, 
                      dbo.vueAccountEmployeeTimeEntryForReport.EndTime, dbo.vueAccountEmployeeTimeEntryForReport.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryForReport.ClientName, dbo.vueAccountEmployeeTimeEntryForReport.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryForReport.ApproverComments, dbo.vueAccountEmployeeTimeEntryForReport.TotalHours, 
                      dbo.vueAccountEmployeeTimeEntryForReport.Approved, dbo.vueAccountEmployeeTimeEntryForReport.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountProjectId, dbo.vueAccountEmployeeTimeEntryForReport.Description, 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountId, dbo.vueAccountEmployeeTimeEntryForReport.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountClientId, dbo.vueAccountEmployeeTimeEntryForReport.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryForReport.BillingType, dbo.vueAccountEmployeeTimeEntryForReport.IsBillable, 
                      dbo.vueAccountEmployeeTimeEntryForReport.Rejected, dbo.vueAccountEmployeeTimeEntryForReport.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountDepartmentId, dbo.vueAccountEmployeeTimeEntryForReport.DepartmentName, 
                      dbo.vueAccountEmployeeTimeEntryForReport.ProjectCode, dbo.vueAccountEmployeeTimeEntryForReport.TaskCode, 
                      dbo.vueAccountEmployeeTimeEntryForReport.ClientNick, dbo.AccountApprovalType.ApprovalTypeName, 
                      dbo.SystemApproverType.SystemApproverType, dbo.vueAccountEmployee.EmployeeName AS ApproverEmployeeName, 
                      dbo.vueAccountEmployee.EMailAddress AS ApproverEmailAddress, dbo.vueAccountEmployeeTimeEntryForReport.Submitted, 
                      CASE WHEN AccountEmployeeTimeEntryApproval.IsApproved = 1 THEN 'Approved' WHEN AccountEmployeeTimeEntryApproval.IsReject = 1 THEN 'Rejected'
                       END AS Status, dbo.vueAccountEmployeeTimeEntryForReport.EmployeeCode, dbo.vueAccountEmployeeTimeEntryForReport.AccountLocation, 
                      dbo.vueAccountEmployee.Role, dbo.vueAccountEmployeeTimeEntryForReport.DepartmentCode, dbo.vueAccountEmployee.AccountLocationId, 
                      dbo.vueAccountEmployee.AccountRoleId, dbo.vueAccountEmployeeTimeEntryForReport.ProjectDescription, 
                      dbo.vueAccountEmployeeTimeEntryForReport.TaskDescription, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate AS PeriodStartDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate AS PeriodEndDate, CONVERT(varchar(10), 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 111) + ' - ' + CONVERT(varchar(10), 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 111) AS Period
FROM         dbo.vueAccountEmployeeTimeEntryForReport INNER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId
                       RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountProjectId = dbo.AccountEmployeeTimeEntryApproval.AccountProjectId AND 
                      dbo.vueAccountEmployeeTimeEntryForReport.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId
                       LEFT OUTER JOIN
                      dbo.vueAccountEmployee ON 
                      dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.SystemApproverType INNER JOIN
                      dbo.AccountApprovalPath ON dbo.SystemApproverType.SystemApproverTypeId = dbo.AccountApprovalPath.SystemApproverTypeId ON 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId = dbo.AccountApprovalPath.AccountApprovalPathId LEFT OUTER JOIN
                      dbo.AccountApprovalType ON 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryForReport.AccountEmployeeTimeEntryPeriodId IS NOT NULL)