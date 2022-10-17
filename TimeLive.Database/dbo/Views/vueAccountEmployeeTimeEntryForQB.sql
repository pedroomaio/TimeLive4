
CREATE VIEW dbo.vueAccountEmployeeTimeEntryForQB
AS
SELECT     dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, dbo.AccountProject.IsDisabled, 
                      dbo.AccountProject.IsTemplate, dbo.AccountProject.IsProject, dbo.AccountProject.IsDeleted, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.IsParentTask, dbo.AccountProjectTask.IsBillable, dbo.AccountProjectTask.TaskCode, 
                      LEFT(dbo.AccountParty.PartyName, 41) AS PartyName, dbo.AccountParty.PartyNick, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.AccountId, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountWorkType.AccountWorkType, dbo.AccountCostCenter.AccountCostCenter, dbo.AccountDepartment.DepartmentName, 
                      dbo.AccountEmployeeType.AccountEmployeeType, dbo.AccountProject.AccountProjectId, dbo.AccountProjectTask.AccountProjectTaskId, NULL 
                      AS ServiceItemName, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, ISNULL(dbo.AccountEmployeeType.IsVendor, 0) 
                      AS IsVendor, dbo.AccountWorkType.AccountWorkTypeId, dbo.AccountCostCenter.AccountCostCenterId, dbo.AccountParty.AccountPartyId
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.AccountProjectTask.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId AND 
                      dbo.AccountEmployee.AccountId = dbo.AccountDepartment.AccountId INNER JOIN
                      dbo.AccountEmployeeType ON dbo.AccountEmployee.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId AND 
                      dbo.AccountEmployee.AccountId = dbo.AccountEmployeeType.AccountId LEFT OUTER JOIN
                      dbo.AccountCostCenter ON dbo.AccountEmployeeTimeEntry.AccountCostCenterId = dbo.AccountCostCenter.AccountCostCenterId LEFT OUTER JOIN
                      dbo.AccountWorkType ON dbo.AccountEmployeeTimeEntry.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId