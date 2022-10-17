CREATE VIEW dbo.vueAccountProjectTaskBillingRate
AS
SELECT     dbo.AccountProjectTask.*
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId