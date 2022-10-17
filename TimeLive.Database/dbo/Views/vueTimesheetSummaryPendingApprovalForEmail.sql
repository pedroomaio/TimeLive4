
CREATE VIEW dbo.vueTimesheetSummaryPendingApprovalForEmail
AS
SELECT    TOP 100 Percent dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, 
                      dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, 
                      dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, 
                      SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, 
                      SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, 
                      dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, 
                      dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId, MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) 
                      AS ApproverEmployeeName, MAX(dbo.AccountEmployee.EMailAddress) AS ApproverEMailAddress, 
                      CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) IS NULL OR
                      MAX(dbo.AccountPreferences.CultureInfoName) = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) END AS CultureInfoName, 
                      dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId, 
                      dbo.vueTimesheetSummaryPendingForApproval.SubmittedDate, dbo.AccountEmployee.AccountId, 
                      dbo.vueTimesheetSummaryPendingForApproval.IsEmailSend, dbo.vueTimesheetSummaryPendingForApproval.Submitted, 
                      dbo.vueTimesheetSummaryPendingForApproval.Approved, dbo.vueTimesheetSummaryPendingForApproval.Rejected
FROM         dbo.AccountPreferences INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN
                      dbo.vueTimesheetSummaryPendingForApproval INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON 
                      dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND 
                      dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId
                       AND 
                      dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId
                       ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId
GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, 
                      dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, 
                      dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, 
                      dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, 
                      dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId, 
                      dbo.vueTimesheetSummaryPendingForApproval.SubmittedDate, dbo.AccountEmployee.AccountId, 
                      dbo.vueTimesheetSummaryPendingForApproval.IsEmailSend, dbo.vueTimesheetSummaryPendingForApproval.Submitted, 
                      dbo.vueTimesheetSummaryPendingForApproval.Approved, dbo.vueTimesheetSummaryPendingForApproval.Rejected
ORDER BY dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId