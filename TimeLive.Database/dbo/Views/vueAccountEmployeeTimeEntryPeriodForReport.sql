
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPeriodForReport
AS
SELECT     dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, 
                      dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, 
                      dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, dbo.vueAccountEmployee.EmployeeName, 
                      dbo.vueAccountEmployee.AccountLocationId, dbo.vueAccountEmployee.AccountDepartmentId, dbo.vueAccountEmployee.AccountLocation, 
                      dbo.vueAccountEmployee.Role, dbo.vueAccountEmployee.DepartmentName, dbo.vueAccountEmployee.EMailAddress, dbo.vueAccountEmployee.AccountRoleId, 
                      CASE WHEN AccountEmployeeTimeEntryPeriod.Submitted = 1 AND 
                      AccountEmployeeTimeEntryPeriod.Approved = 0 THEN 'Submitted' WHEN AccountEmployeeTimeEntryPeriod.Approved = 1 THEN 'Approved' WHEN AccountEmployeeTimeEntryPeriod.Rejected
                       = 1 THEN 'Rejected' WHEN AccountEmployeeTimeEntryPeriod.Submitted = 0 AND AccountEmployeeTimeEntryPeriod.Approved = 0 AND 
                      AccountEmployeeTimeEntryPeriod.Rejected = 0 THEN 'Not Submitted' END AS ApprovalStatus, 
                      { fn DAYOFMONTH(dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate) } AS DayNo, MONTH(dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate) 
                      AS MonthNo, DATEPART(week, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate) - DATEPART(week, DATEADD(month, DATEDIFF(month, 0, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate), 0)) + 1 AS WeekNo, YEAR(dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate) AS Year, 
                      LEFT({ fn MONTHNAME(dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate) }, 3) + ' - ' + CONVERT(nvarchar(10), 
                      YEAR(dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate)) AS Period, { fn DAYNAME(dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate) 
                      } AS WeekDayName, SUM(CONVERT(float, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalMinutes) / 60) AS TotalHours, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalMinutes * dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRate / 60, 0)) 
                      AS Amount, SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRate, 0)) AS BillingRate, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.SubmittedHours, 0)) AS SubmittedHours, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ApprovedHours, 0)) AS ApprovedHours, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.RejectedHours, 0)) AS RejectedHours, ISNULL(dbo.vueAccountEmployee.EmployeeCode, '') 
                      AS EmployeeCode, SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRateExchangeRate, 0)) AS BillingRateExchangeRate, 
                      dbo.AccountEmployeeTimeEntryPeriod.ApprovedOn, dbo.AccountEmployeeTimeEntryPeriod.RejectedOn, 
                      dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientContactName, N'') AS ClientContactName, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentCode, N'') AS ClientDepartmentCode, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentName, N'') AS ClientDepartmentName, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentLocation, N'') AS ClientDepartmentLocation, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeOffHours, 0)) AS TimeOffHours, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimesheetHours, 0)) AS TimesheetHours, 
                      SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Percentage, 0)) AS Percentage, 
                      SUM(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillableHours) AS BillableTotalHours, dbo.vueAccountEmployee.AccountWorkingDayTypeId, 
                      dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, dbo.vueAccountEmployee.HiredDate
FROM         dbo.AccountEmployeeTimeEntryPeriod INNER JOIN
                      dbo.vueAccountEmployee ON dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport ON 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountEmployeeTimeEntryPeriodId
GROUP BY dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, 
                      dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, 
                      dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, dbo.vueAccountEmployee.EmployeeName, 
                      dbo.vueAccountEmployee.AccountLocationId, dbo.vueAccountEmployee.AccountDepartmentId, dbo.vueAccountEmployee.AccountLocation, 
                      dbo.vueAccountEmployee.Role, dbo.vueAccountEmployee.DepartmentName, dbo.vueAccountEmployee.EMailAddress, dbo.vueAccountEmployee.AccountRoleId, 
                      dbo.vueAccountEmployee.EmployeeCode, dbo.AccountEmployeeTimeEntryPeriod.ApprovedOn, dbo.AccountEmployeeTimeEntryPeriod.RejectedOn, 
                      dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientContactName, N''), 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentCode, N''), 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentName, N''), 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentLocation, N''), dbo.vueAccountEmployee.AccountWorkingDayTypeId, 
                      dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, dbo.vueAccountEmployee.HiredDate