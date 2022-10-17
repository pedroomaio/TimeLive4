
CREATE VIEW dbo.vueAccountProjectForProjectSummary
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.AccountId, dbo.AccountProject.AccountProjectTypeId, dbo.AccountProject.AccountClientId, 
                      dbo.AccountProject.ProjectBillingTypeId, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.StartDate, 
                      dbo.AccountProject.AccountMilestoneId, dbo.AccountProject.Deadline, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountProject.EstimatedTime, dbo.AccountProject.EstimatedDuration, dbo.AccountProject.EstimatedDurationUnit, dbo.AccountProject.ProjectCode, 
                      dbo.AccountProject.DefaultBillingRate, dbo.AccountProject.IsActive, dbo.AccountProject.ProjectStatusId, dbo.AccountProject.AccountPriorityId, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountProject.CreatedOn, dbo.AccountProject.CreatedByEmployeeId, 
                      dbo.AccountProject.ModifiedOn, dbo.AccountProject.ModifiedByEmployeeId, dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountProject.AccountPartyContactId, 
                      dbo.AccountProject.AccountPartyDepartmentId, dbo.AccountProject.IsDisabled, dbo.AccountProject.IsTemplate, dbo.AccountProject.IsProject, 
                      dbo.AccountProject.AccountProjectTemplateId, dbo.AccountProject.Completed, dbo.AccountProject.IsDeleted, dbo.AccountParty.PartyName
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId