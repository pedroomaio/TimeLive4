
CREATE VIEW dbo.vueAccountEmployeeTimeEntryForReport
AS
SELECT     dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeName, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskName, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Approved, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountProjectId, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TeamLeadApproved, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AdministratorApproved, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.StartTime, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EndTime, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Description, N'') AS Description, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountId, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.WeekDay, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountPartyId AS AccountClientId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.PartyName AS ClientName, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountProjectTaskId, ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingType, N'') 
                      AS BillingType, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ExpenseApprovalTypeId, ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.IsBillable, 0) 
                      AS IsBillable, ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Rejected, 0) AS Rejected, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRate, 0) AS BillingRate, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectBillingRateTypeId, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCode, N'') AS EmployeeCode, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountDepartmentId, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.DepartmentName, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EstimatedCost, 0) AS EstimatedCost, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EstimatedTimeSpent, 0) AS EstimatedHours, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Submitted, 0) AS Submitted, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountWorkType, N'') AS AccountWorkType, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EMailAddress, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountLocation, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountCostCenter, N'') AS AccountCostCenter, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountCostCenterCode, N'') AS AccountCostCenterCode, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountWorkTypeCode, N'') AS AccountWorkTypeCode, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCode, N'') AS ProjectCode, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCode, N'') AS TaskCode, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountLocationId, 
					  ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Comments, N'') AS ApproverComments, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalMinutes * dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRate / 60, 0) 
                      AS Amount, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRateCurrencyId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeRateCurrencyId, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRateExchangeRate, 0) AS BillingRateExchangeRate, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeRateExchangeRate, 0) AS EmployeeRateExchangeRate, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountBaseCurrencyId, 
					  dbo.vueAccountCurrency.CurrencyCode AS BillingRateCurrencyCode, 
                      dbo.vueAccountCurrency.CurrencyCode AS AmountCurrencyCode, 
					  dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountTaskTypeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskStatusId, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountPriorityId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountProjectMilestoneId, dbo.AccountTaskType.TaskType, dbo.AccountStatus.Status AS TaskStatus, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountPriority.Priority, CONVERT(float, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalMinutes) / 60 AS TotalHours, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.DepartmentCode, N'') AS DepartmentCode, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.PartyNick, N'') AS ClientNick, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EstimatedCurrencyId, 
					  vueAccountCurrency_1.CurrencyCode AS EstimatedCurrencyCode, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ApprovedOn,
					   ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeRate, 0) 
                      AS EmployeeRate, 
					  vueAccountCurrency_2.CurrencyCode AS EmployeeRateCurrencyCode, 
                      LeaderEmployee.FirstName + ' ' + LeaderEmployee.LastName AS TeamLeader, 
                      ProjectManagerEmployee.FirstName + ' ' + ProjectManagerEmployee.LastName AS ProjectManager, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeManager, 
                      vueAccountCurrency_1.ExchangeRate AS EstimatedCurrencyExchangeRate, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TotalMinutes * dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeRate / 60, 0) 
                      AS EmployeeCost, { fn DAYOFMONTH(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate) } AS DayNo, 
                      MONTH(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate) AS MonthNo, DATEPART(week, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate) - DATEPART(week, DATEADD(month, DATEDIFF(month, 0, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate), 0)) + 1 AS WeekNo, 
                      YEAR(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate) AS Year, 
                      LEFT({ fn MONTHNAME(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate) }, 3) + ' - ' + CONVERT(nvarchar(10), 
                      YEAR(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate)) AS Period, 
                      { fn DAYNAME(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryDate) } AS WeekDayName, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountRoleId, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Role, 
                      dbo.AccountProjectType.ProjectType, dbo.AccountRole.Role AS ProjectRole, ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectDescription, N'') 
                      AS ProjectDescription, ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskDescription, N'') AS TaskDescription, 
                      dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, dbo.AccountProjectType.AccountProjectTypeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Billed, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountEmployeeTimeEntryPeriodId, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientContactName, N'') AS ClientContactName, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentCode, N'') AS ClientDepartmentCode, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentName, N'') AS ClientDepartmentName, 
                      ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientDepartmentLocation, N'') AS ClientDepartmentLocation, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.IsTimeOff, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountWorkTypeId, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectStatus, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ParentTaskName, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.FirstName, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.LastName, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeType, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.HolidayName, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField1, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField2, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField3, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField4, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField5, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField6, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField7, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField8, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField9, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField10, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField11, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField12, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField13, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField14, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CustomField15, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskStartDate, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskDeadlineDate, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField1, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField2, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField3, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField4, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField5, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField6, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField7, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField8, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField9, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField10, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField11, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField12, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField13, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField14, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskCustomField15,
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectApprover,dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CurrentApprover, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField15, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField14, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField13, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField12, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField11, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField10, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField9, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField8, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField7, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField6, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField5, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField4, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField3, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField2, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ClientCustomField1, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField15, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField14, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField13, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField12, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField11, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField10, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField9, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField8, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField7, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField4, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField3, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField6, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField2, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeCustomField1, CONVERT(VARCHAR(10), 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryStartDate, 110) + ' ' + '-' + ' ' + CONVERT(VARCHAR(10), 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TimeEntryEndDate, 110) AS TimeEntryPeriod, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.JobTitle, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskEnabled, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField1, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField2, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField3, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField4, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField5, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField6, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField7, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField8, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField9, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField10, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField11, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField12, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField13, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField14, 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectCustomField15, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountTimeOffType, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountCostCenterId
					  ,dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.Percentage, dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.CreatedOn, ISNULL(dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectBillingType, N'') 
                      AS ProjectBillingType
FROM         vueAccountEmployeeTimeEntryWithTimeOffForReport LEFT OUTER JOIN
                      dbo.AccountProjectType ON 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountProjectTypeId = dbo.AccountProjectType.AccountProjectTypeId
					  LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId
					  LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.TaskStatusId = dbo.AccountStatus.AccountStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountPriorityId = dbo.AccountPriority.AccountPriorityId LEFT OUTER JOIN
                      dbo.AccountTaskType ON dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountTaskTypeId = dbo.AccountTaskType.AccountTaskTypeId
					  LEFT OUTER JOIN
					 dbo.AccountTimeExpenseBillingTimesheet ON 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId = dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountTimeExpenseBillingTimesheetId
					  LEFT OUTER JOIN
					  dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId 
					  LEFT OUTER JOIN
					  dbo.AccountProjectEmployee ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountEmployeeId AND 
                      dbo.AccountProjectEmployee.AccountProjectId = dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.AccountProjectId
					  LEFT OUTER JOIN
					  dbo.AccountRole ON dbo.AccountRole.AccountRoleId = dbo.AccountProjectEmployee.AccountRoleId
					  LEFT OUTER JOIN
                      dbo.AccountEmployee AS LeaderEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.LeaderEmployeeId = LeaderEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS ProjectManagerEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.ProjectManagerEmployeeId = ProjectManagerEmployee.AccountEmployeeId
					  LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_2 ON 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EmployeeRateCurrencyId = vueAccountCurrency_2.AccountCurrencyId LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_1 ON 
                      dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.EstimatedCurrencyId = vueAccountCurrency_1.AccountCurrencyId LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport.BillingRateCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId