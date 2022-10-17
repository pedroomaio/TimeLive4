
CREATE VIEW dbo.vueAccountProjectTaskWithParentForQB
AS
WITH tree AS (SELECT     AccountProjectId, AccountProjectTaskId, ParentAccountProjectTaskId, LEFT(CONVERT(nvarchar(MAX), TaskName), 31) AS Parents, 
                                                      0 AS TableId
                               FROM         dbo.AccountProjectTask AS t
                               UNION ALL
                               SELECT     t.AccountProjectId, t.AccountProjectTaskId, t.ParentAccountProjectTaskId, base.Parents + ':' + LEFT(CONVERT(nvarchar(MAX), 
                                                     t.TaskName), 31) AS Expr1, 1 AS TableId
                               FROM         tree AS base INNER JOIN
                                                     dbo.AccountProjectTask AS t ON t.ParentAccountProjectTaskId = base.AccountProjectTaskId)
    SELECT     TOP 100 PERCENT AccountProjectId, AccountProjectTaskId, ParentAccountProjectTaskId, MAX(Parents) AS Parents, MAX(TableId) AS TableId
     FROM         tree AS tree_1
     WHERE     (ParentAccountProjectTaskId IS NULL) OR
                            (TableId = 1)
     GROUP BY AccountProjectId, AccountProjectTaskId, ParentAccountProjectTaskId
     ORDER BY AccountProjectTaskId