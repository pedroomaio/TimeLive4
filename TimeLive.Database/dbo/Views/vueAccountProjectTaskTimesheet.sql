
CREATE VIEW dbo.vueAccountProjectTaskTimesheet
AS
SELECT     dbo.AccountProjectTask.*, dbo.AccountProject.AccountId, dbo.AccountProject.IsTemplate
FROM         dbo.AccountProjectTask INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId