
CREATE VIEW dbo.rptvueAccountEmployeeTimeEntryPeriod
AS
SELECT     dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountEmployeeTimeEntryPeriodId, dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryPeriodForReport.TimeEntryStartDate, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.TimeEntryEndDate, dbo.vueAccountEmployeeTimeEntryPeriodForReport.TimeEntryViewType, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.Submitted, dbo.vueAccountEmployeeTimeEntryPeriodForReport.Approved, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.Rejected, dbo.vueAccountEmployeeTimeEntryPeriodForReport.InApproval, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.SubmittedDate, dbo.vueAccountEmployeeTimeEntryPeriodForReport.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountLocationId, dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountDepartmentId, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountLocation, dbo.vueAccountEmployeeTimeEntryPeriodForReport.Role, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.DepartmentName, dbo.vueAccountEmployeeTimeEntryPeriodForReport.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountRoleId, dbo.vueAccountEmployeeTimeEntryPeriodForReport.ApprovalStatus, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.DayNo, dbo.vueAccountEmployeeTimeEntryPeriodForReport.MonthNo, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.WeekNo, dbo.vueAccountEmployeeTimeEntryPeriodForReport.Year, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.Period, dbo.vueAccountEmployeeTimeEntryPeriodForReport.WeekDayName, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryPeriodForReport.TotalHours, 0) AS TotalHours, dbo.vueAccountEmployeeTimeEntryPeriodForReport.Amount, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.BillingRate, dbo.vueAccountEmployeeTimeEntryPeriodForReport.SubmittedHours, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.ApprovedHours, dbo.vueAccountEmployeeTimeEntryPeriodForReport.RejectedHours, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.EmployeeCode, 
                      CASE WHEN BillingRateExchangeRate > 0 THEN Amount / BillingRateExchangeRate ELSE 0 END AS CurrencyAmount, 
                      CASE WHEN dbo.vueAccountEmployeeTimeEntryPeriodForReport.Approved = 1 THEN dbo.vueAccountEmployeeTimeEntryPeriodForReport.ApprovedOn ELSE NULL 
                      END AS ApprovedDate, 
                      CASE WHEN dbo.vueAccountEmployeeTimeEntryPeriodForReport.Rejected = 1 THEN dbo.vueAccountEmployeeTimeEntryPeriodForReport.RejectedOn ELSE NULL 
                      END AS RejectedDate, AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApprovedByEmployeeName, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS RejectedByEmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.ClientContactName, dbo.vueAccountEmployeeTimeEntryPeriodForReport.ClientDepartmentCode, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.ClientDepartmentName, dbo.vueAccountEmployeeTimeEntryPeriodForReport.ClientDepartmentLocation, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.TimeOffHours, dbo.vueAccountEmployeeTimeEntryPeriodForReport.TimesheetHours, 
                      dbo.AccountWorkingDayType.MinimumHoursPerDay, dbo.AccountWorkingDayType.MaximumHoursPerDay, dbo.AccountWorkingDayType.MinimumHoursPerWeek, 
                      dbo.AccountWorkingDayType.MaximumHoursPerWeek, dbo.AccountWorkingDayType.HoursPerDay, dbo.AccountWorkingDayType.WeekStartDay, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.Percentage, dbo.vueAccountEmployeeTimeEntryPeriodForReport.BillableTotalHours, 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.PeriodDescription, dbo.vueAccountEmployeeTimeEntryPeriodForReport.HiredDate
FROM         dbo.AccountWorkingDayType RIGHT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport ON 
                      dbo.AccountWorkingDayType.AccountWorkingDayTypeId = dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountWorkingDayTypeId AND 
                      dbo.AccountWorkingDayType.AccountId = dbo.vueAccountEmployeeTimeEntryPeriodForReport.AccountId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntryPeriodForReport.RejectedByEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.vueAccountEmployeeTimeEntryPeriodForReport.ApprovedByEmployeeId = AccountEmployee_1.AccountEmployeeId