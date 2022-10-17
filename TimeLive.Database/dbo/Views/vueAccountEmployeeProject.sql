
CREATE VIEW dbo.vueAccountEmployeeProject
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.AccountId, dbo.AccountProject.ProjectName, dbo.AccountProjectEmployee.AccountProjectEmployeeId, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.IsDisabled, dbo.AccountProject.IsDeleted, dbo.AccountParty.IsDeleted AS IsDeletedClient, 
                      dbo.AccountPartyDepartment.PartyDepartmentName AS ClientDepartment, dbo.AccountParty.PartyName AS ClientName
FROM         dbo.AccountProjectEmployee RIGHT OUTER JOIN
                      dbo.AccountParty INNER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProject.AccountId = dbo.AccountEmployee.AccountId ON 
                      dbo.AccountParty.AccountPartyId = dbo.AccountProject.AccountClientId LEFT OUTER JOIN
                      dbo.AccountPartyDepartment ON dbo.AccountProject.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId ON 
                      dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountProject.AccountProjectId AND dbo.AccountProjectEmployee.AccountId = dbo.AccountProject.AccountId AND 
                      dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId
                      where dbo.AccountProject.IsTemplate <> 1