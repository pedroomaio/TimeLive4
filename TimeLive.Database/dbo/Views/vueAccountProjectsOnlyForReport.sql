
CREATE VIEW dbo.vueAccountProjectsOnlyForReport
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.AccountId, dbo.AccountProject.AccountProjectTypeId, dbo.AccountProject.AccountClientId, 
                      dbo.AccountProject.ProjectBillingTypeId, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.StartDate, 
                      dbo.AccountProject.AccountMilestoneId, dbo.AccountProject.Deadline, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProject.EstimatedTime, dbo.AccountProject.EstimatedDurationUnit, 
                      CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix, '') = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + dbo.AccountProject.ProjectCode END AS ProjectCode, 
                      dbo.AccountProject.DefaultBillingRate, dbo.AccountProject.IsActive, dbo.AccountProject.ProjectStatusId, dbo.AccountProject.AccountPriorityId, 
                      dbo.AccountProject.CreatedOn, dbo.AccountProject.CreatedByEmployeeId, dbo.AccountProject.ModifiedOn, dbo.AccountProject.ModifiedByEmployeeId, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProject.AccountPartyContactId AS AccountClientContactId, dbo.AccountProject.AccountPartyDepartmentId AS AccountClientDepartmentId, 
                      dbo.AccountProject.IsDisabled, dbo.AccountProject.IsTemplate, dbo.AccountProject.IsProject, dbo.AccountProject.AccountProjectTemplateId, 
                      dbo.AccountParty.PartyNick AS ClientNick, dbo.AccountParty.PartyName AS ClientName, dbo.AccountProjectType.ProjectType, 
                      dbo.AccountBillingType.BillingType, dbo.AccountStatus.Status, CONVERT(nvarchar(200), dbo.AccountProject.EstimatedDuration) AS EstimatedDuration, 
                      dbo.AccountPartyDepartment.PartyDepartmentCode AS ClientDepartmentCode, dbo.AccountPartyDepartment.PartyDepartmentName AS ClientDepartmentName, 
                      dbo.AccountPartyDepartment.PartyDepartmentLocation AS ClientDepartmentLocation, dbo.AccountPartyContact.FirstName + ' ' + dbo.AccountPartyContact.LastName AS ClientContactName, 
                      AccountApprovalType_1.ApprovalTypeName AS ExpenseApprovalTypeName, dbo.AccountApprovalType.ApprovalTypeName AS TimesheetApprovalTypeName, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND AccountEmployee_1.IsDisabled = 1 THEN AccountEmployee_1.LastName + ' ' + AccountEmployee_1.FirstName + ' ' + '(Disbaled)' 
                      WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND AccountEmployee_1.IsDisabled = 0 THEN AccountEmployee_1.LastName + ' ' + AccountEmployee_1.FirstName 
                      WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND AccountEmployee_1.IsDisabled = 1 THEN AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName + ' ' + '(Disbaled)'
                      ELSE AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName END AS TeamLead, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' 
                      WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
                      WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' 
                      ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS ProjectManager, dbo.SystemProjectBillingRateType.SystemProjectBillingRateType AS ProjectBillingRateType, dbo.AccountProject.CustomField1, 
                      dbo.AccountProject.CustomField2, dbo.AccountProject.CustomField3, dbo.AccountProject.CustomField4, dbo.AccountProject.CustomField5, dbo.AccountProject.CustomField6, dbo.AccountProject.CustomField7, dbo.AccountProject.CustomField8, dbo.AccountProject.CustomField9, 
                      dbo.AccountProject.CustomField10, dbo.AccountProject.CustomField11, dbo.AccountProject.CustomField12, dbo.AccountProject.CustomField13, dbo.AccountProject.CustomField14, dbo.AccountProject.CustomField15, dbo.AccountProject.ProjectEstimatedCost
FROM         dbo.AccountPartyContact RIGHT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.Account ON dbo.AccountProject.AccountId = dbo.Account.AccountId INNER JOIN 
                      dbo.AccountPreferences ON dbo.AccountPreferences.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId AND 
                      dbo.Account.AccountId = dbo.AccountParty.AccountId INNER JOIN
                      dbo.AccountProjectType ON dbo.AccountProject.AccountProjectTypeId = dbo.AccountProjectType.AccountProjectTypeId AND 
                      dbo.Account.AccountId = dbo.AccountProjectType.AccountId INNER JOIN
                      dbo.AccountBillingType ON dbo.AccountProject.ProjectBillingTypeId = dbo.AccountBillingType.AccountBillingTypeId AND 
                      dbo.Account.AccountId = dbo.AccountBillingType.AccountId INNER JOIN
                      dbo.AccountStatus ON dbo.AccountProject.ProjectStatusId = dbo.AccountStatus.AccountStatusId AND 
                      dbo.Account.AccountId = dbo.AccountStatus.AccountId LEFT OUTER JOIN
                      dbo.SystemProjectBillingRateType ON 
                      dbo.AccountProject.ProjectBillingRateTypeId = dbo.SystemProjectBillingRateType.SystemProjectBillingRateTypeId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountProject.ProjectManagerEmployeeId = dbo.AccountEmployee.AccountEmployeeId AND 
                      dbo.Account.AccountId = dbo.AccountEmployee.AccountId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProject.LeaderEmployeeId = AccountEmployee_1.AccountEmployeeId AND 
                      dbo.Account.AccountId = AccountEmployee_1.AccountId LEFT OUTER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId AND 
                      dbo.Account.AccountId = dbo.AccountApprovalType.AccountId LEFT OUTER JOIN
                      dbo.AccountApprovalType AS AccountApprovalType_1 ON 
                      dbo.AccountProject.ExpenseApprovalTypeId = AccountApprovalType_1.AccountApprovalTypeId AND 
                      dbo.Account.AccountId = AccountApprovalType_1.AccountId LEFT OUTER JOIN
                      dbo.AccountPartyDepartment ON dbo.AccountProject.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId ON 
                      dbo.AccountPartyContact.AccountPartyContactId = dbo.AccountProject.AccountPartyContactId
WHERE     (dbo.AccountProject.IsTemplate <> 1) AND (dbo.AccountProject.IsDeleted IS NULL OR dbo.AccountProject.IsDeleted <> 1) AND (dbo.AccountParty.IsDeleted IS NULL OR dbo.AccountParty.IsDeleted <> 1)