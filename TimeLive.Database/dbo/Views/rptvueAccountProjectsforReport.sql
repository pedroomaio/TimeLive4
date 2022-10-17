﻿
CREATE VIEW dbo.rptvueAccountProjectsforReport
AS
SELECT     dbo.rptvueAccountProjects.AccountProjectId, dbo.rptvueAccountProjects.AccountId, dbo.rptvueAccountProjects.AccountProjectTypeId, dbo.rptvueAccountProjects.AccountClientId, dbo.rptvueAccountProjects.ProjectBillingTypeId, dbo.rptvueAccountProjects.ProjectName, 
                      dbo.rptvueAccountProjects.ProjectDescription, dbo.rptvueAccountProjects.StartDate, dbo.rptvueAccountProjects.AccountMilestoneId, dbo.rptvueAccountProjects.Deadline, dbo.rptvueAccountProjects.LeaderEmployeeId, dbo.rptvueAccountProjects.ProjectManagerEmployeeId, 
                      dbo.rptvueAccountProjects.EstimatedTime, dbo.rptvueAccountProjects.EstimatedDurationUnit, dbo.rptvueAccountProjects.ProjectCode, dbo.rptvueAccountProjects.DefaultBillingRate, dbo.rptvueAccountProjects.IsActive, dbo.rptvueAccountProjects.ProjectStatusId, 
                      dbo.rptvueAccountProjects.AccountPriorityId, dbo.rptvueAccountProjects.CreatedOn, dbo.rptvueAccountProjects.CreatedByEmployeeId, dbo.rptvueAccountProjects.ModifiedOn, dbo.rptvueAccountProjects.ModifiedByEmployeeId, dbo.rptvueAccountProjects.ProjectBillingRateTypeId, 
                      dbo.rptvueAccountProjects.TimeSheetApprovalTypeId, dbo.rptvueAccountProjects.ExpenseApprovalTypeId, dbo.rptvueAccountProjects.IsDisabled, dbo.rptvueAccountProjects.IsTemplate, dbo.rptvueAccountProjects.IsProject, dbo.rptvueAccountProjects.AccountProjectTemplateId, 
                      dbo.rptvueAccountProjects.ClientNick, dbo.rptvueAccountProjects.ClientName, dbo.rptvueAccountProjects.ProjectType, dbo.rptvueAccountProjects.BillingType, dbo.rptvueAccountProjects.Status, dbo.rptvueAccountProjects.EstimatedDuration, 
                      dbo.rptvueAccountProjects.AccountClientContactId, dbo.rptvueAccountProjects.AccountClientDepartmentId, dbo.rptvueAccountProjects.ClientDepartmentCode, dbo.rptvueAccountProjects.ClientDepartmentName, 
                      dbo.rptvueAccountProjects.ClientDepartmentLocation, dbo.rptvueAccountProjects.ExpenseApprovalTypeName, dbo.rptvueAccountProjects.TimesheetApprovalTypeName, dbo.rptvueAccountProjects.ClientContactName, dbo.rptvueAccountProjects.TeamLead, 
                      dbo.rptvueAccountProjects.ProjectManager, dbo.rptvueAccountProjects.ProjectBillingRateType, dbo.rptvueAccountProjects.BillableTotalHours, dbo.rptvueAccountProjects.NonBillableTotalHours, dbo.rptvueAccountProjects.TotalEmployeeCost, dbo.rptvueAccountProjects.TotalTimeAmount, 
                      ISNULL(dbo.rptvueAccountProjects.TotalTaskEstimatedCost, 0) AS TotalTaskEstimatedCost, SUM(CASE WHEN dbo.rptvueAccountExpenseEntry.IsBillable = 1 THEN dbo.rptvueAccountExpenseEntry.NetAmount ELSE 0 END) AS TotalBillableExpense, 
                      SUM(CASE WHEN dbo.rptvueAccountExpenseEntry.IsBillable = 0 THEN dbo.rptvueAccountExpenseEntry.NetAmount ELSE 0 END) AS TotalNonBillableExpense, ISNULL(SUM(dbo.rptvueAccountExpenseEntry.NetAmount), 0) AS NetAmount, 
                      ISNULL(dbo.rptvueAccountProjects.TotalTaskEstimatedHours, 0) AS TotalTaskEstimatedHours, dbo.rptvueAccountProjects.TotalHours, dbo.rptvueAccountProjects.BillableTimeAmount, dbo.rptvueAccountProjects.NonBillableTimeAmount, 
                      SUM(dbo.rptvueAccountExpenseEntry.CurrencyNetAmount) AS NetAmounts, dbo.rptvueAccountProjects.CustomField1, dbo.rptvueAccountProjects.CustomField2, dbo.rptvueAccountProjects.CustomField3, dbo.rptvueAccountProjects.CustomField4, 
                      dbo.rptvueAccountProjects.CustomField5, dbo.rptvueAccountProjects.CustomField6, dbo.rptvueAccountProjects.CustomField7, dbo.rptvueAccountProjects.CustomField8, dbo.rptvueAccountProjects.CustomField9, dbo.rptvueAccountProjects.CustomField10, 
                      dbo.rptvueAccountProjects.CustomField11, dbo.rptvueAccountProjects.CustomField12, dbo.rptvueAccountProjects.CustomField13, dbo.rptvueAccountProjects.CustomField14, dbo.rptvueAccountProjects.CustomField15, dbo.rptvueAccountProjects.ProjectEstimatedCost
FROM         dbo.rptvueAccountProjects LEFT OUTER JOIN
                      dbo.rptvueAccountExpenseEntry ON dbo.rptvueAccountExpenseEntry.AccountProjectId = dbo.rptvueAccountProjects.AccountProjectId
GROUP BY dbo.rptvueAccountProjects.AccountProjectId, dbo.rptvueAccountProjects.AccountId, dbo.rptvueAccountProjects.AccountProjectTypeId, dbo.rptvueAccountProjects.AccountClientId, dbo.rptvueAccountProjects.ProjectName, dbo.rptvueAccountProjects.ProjectBillingTypeId, 
                      dbo.rptvueAccountProjects.ProjectDescription, dbo.rptvueAccountProjects.StartDate, dbo.rptvueAccountProjects.AccountMilestoneId, dbo.rptvueAccountProjects.Deadline, dbo.rptvueAccountProjects.LeaderEmployeeId, dbo.rptvueAccountProjects.ProjectManagerEmployeeId, 
                      dbo.rptvueAccountProjects.EstimatedTime, dbo.rptvueAccountProjects.EstimatedDurationUnit, dbo.rptvueAccountProjects.ProjectCode, dbo.rptvueAccountProjects.DefaultBillingRate, dbo.rptvueAccountProjects.IsActive, dbo.rptvueAccountProjects.ProjectStatusId, 
                      dbo.rptvueAccountProjects.AccountPriorityId, dbo.rptvueAccountProjects.CreatedOn, dbo.rptvueAccountProjects.CreatedByEmployeeId, dbo.rptvueAccountProjects.ModifiedOn, dbo.rptvueAccountProjects.ModifiedByEmployeeId, dbo.rptvueAccountProjects.ProjectBillingRateTypeId, 
                      dbo.rptvueAccountProjects.TimeSheetApprovalTypeId, dbo.rptvueAccountProjects.ExpenseApprovalTypeId, dbo.rptvueAccountProjects.IsDisabled, dbo.rptvueAccountProjects.IsTemplate, dbo.rptvueAccountProjects.IsProject, dbo.rptvueAccountProjects.AccountProjectTemplateId, 
                      dbo.rptvueAccountProjects.ClientNick, dbo.rptvueAccountProjects.ClientName, dbo.rptvueAccountProjects.ProjectType, dbo.rptvueAccountProjects.BillingType, dbo.rptvueAccountProjects.Status, dbo.rptvueAccountProjects.EstimatedDuration, 
                      dbo.rptvueAccountProjects.AccountClientContactId, dbo.rptvueAccountProjects.AccountClientDepartmentId, dbo.rptvueAccountProjects.ClientDepartmentCode, dbo.rptvueAccountProjects.ClientDepartmentName, 
                      dbo.rptvueAccountProjects.ClientDepartmentLocation, dbo.rptvueAccountProjects.ExpenseApprovalTypeName, dbo.rptvueAccountProjects.TimesheetApprovalTypeName, dbo.rptvueAccountProjects.ClientContactName, dbo.rptvueAccountProjects.TeamLead, 
                      dbo.rptvueAccountProjects.ProjectManager, dbo.rptvueAccountProjects.ProjectBillingRateType, dbo.rptvueAccountProjects.BillableTotalHours, dbo.rptvueAccountProjects.NonBillableTotalHours, dbo.rptvueAccountProjects.TotalEmployeeCost, dbo.rptvueAccountProjects.TotalTimeAmount, 
                      dbo.rptvueAccountProjects.TotalTaskEstimatedCost, ISNULL(dbo.rptvueAccountProjects.TotalTaskEstimatedHours, 0), dbo.rptvueAccountProjects.TotalHours, dbo.rptvueAccountProjects.BillableTimeAmount, dbo.rptvueAccountProjects.NonBillableTimeAmount, 
                      dbo.rptvueAccountProjects.CustomField1, dbo.rptvueAccountProjects.CustomField2, dbo.rptvueAccountProjects.CustomField3, dbo.rptvueAccountProjects.CustomField4, dbo.rptvueAccountProjects.CustomField5, dbo.rptvueAccountProjects.CustomField6, 
                      dbo.rptvueAccountProjects.CustomField7, dbo.rptvueAccountProjects.CustomField8, dbo.rptvueAccountProjects.CustomField9, dbo.rptvueAccountProjects.CustomField10, dbo.rptvueAccountProjects.CustomField11, dbo.rptvueAccountProjects.CustomField12, 
                      dbo.rptvueAccountProjects.CustomField13, dbo.rptvueAccountProjects.CustomField14, dbo.rptvueAccountProjects.CustomField15, dbo.rptvueAccountProjects.ProjectEstimatedCost