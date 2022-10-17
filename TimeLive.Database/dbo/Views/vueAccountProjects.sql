
CREATE VIEW dbo.vueAccountProjects
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProject.StartDate, dbo.AccountProject.ProjectCode, dbo.AccountParty.PartyName, 
                      dbo.AccountProject.AccountClientId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS LeaderName, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS ProjectManagerName, dbo.AccountProject.AccountId, dbo.AccountProject.IsActive, 
                      dbo.AccountProject.Deadline, dbo.AccountProject.EstimatedDuration, dbo.AccountProject.EstimatedDurationUnit, dbo.AccountProject.ProjectStatusId, 
                      dbo.AccountStatus.Status, dbo.AccountProject.IsDisabled, dbo.AccountProject.ProjectDescription, dbo.AccountProject.IsTemplate, dbo.AccountProject.IsProject, 
                      dbo.AccountProject.AccountProjectTemplateId, dbo.SystemProjectBillingRateType.SystemProjectBillingRateType, dbo.AccountProject.AccountProjectTypeId, 
                      dbo.AccountProjectType.ProjectType, dbo.AccountProjectType.MasterAccountProjectTypeId, dbo.AccountProject.IsDeleted, 
                      dbo.AccountPartyDepartment.PartyDepartmentName, dbo.AccountParty.IsDeleted AS IsDeletedClient, dbo.AccountProject.Completed, dbo.Account.IsLock, 
                      AccountApprovalType_1.ApprovalTypeName AS TimesheetApprovalTypeName, dbo.AccountApprovalType.ApprovalTypeName AS ExpenseApprovalTypeName, 
                      dbo.AccountProject.ProjectPrefix, dbo.AccountParty.PartyNick, dbo.AccountParty.IsDisabled AS IsDisabledClient, dbo.AccountProject.IsForAllClientProject
FROM         dbo.AccountEmployee AS AccountEmployee_1 RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.Account INNER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountProjectType ON dbo.AccountProject.AccountProjectTypeId = dbo.AccountProjectType.AccountProjectTypeId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.Account.AccountId = dbo.AccountProject.AccountId LEFT OUTER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProject.ProjectManagerEmployeeId ON 
                      AccountEmployee_1.AccountEmployeeId = dbo.AccountProject.LeaderEmployeeId LEFT OUTER JOIN
                      dbo.AccountApprovalType AS AccountApprovalType_1 ON 
                      dbo.AccountProject.TimeSheetApprovalTypeId = AccountApprovalType_1.AccountApprovalTypeId LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.AccountProject.ProjectStatusId = dbo.AccountStatus.AccountStatusId LEFT OUTER JOIN
                      dbo.AccountPartyDepartment ON dbo.AccountProject.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId LEFT OUTER JOIN
                      dbo.SystemProjectBillingRateType ON dbo.AccountProject.ProjectBillingRateTypeId = dbo.SystemProjectBillingRateType.SystemProjectBillingRateTypeId