
CREATE VIEW dbo.vueAccountProjectEmployeFullJoin
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountEmployee.Password, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, 
                      dbo.AccountEmployee.AccountId, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS FullName, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.IsDisabled, dbo.AccountEmployee.IsDeleted, 
                      dbo.AccountProject.IsDeleted AS IsDeletedProject, dbo.AccountParty.IsDeleted AS IsDeletedClient
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProject.AccountId = dbo.AccountEmployee.AccountId INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId AND 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId