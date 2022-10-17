
CREATE function [dbo].[AccountProjectTaskWithParentTask]
(@AccountProjectId int
)

returns table
as
return (

WITH CTE AS
(   SELECT  IsBillable, AccountProjectID, AccountProjectTaskId, TaskName,  ParentAccountProjectTaskId, 0 [Level]
    FROM    AccountProjectTask 
    --where AccountProjectId = 1587
    UNION ALL
    SELECT  cte.isbillable, cte.AccountProjectId, cte.AccountProjectTaskId, CTE.TaskName, AccountProjectTask.ParentAccountProjectTaskId, Level + 1
    FROM    CTE
            INNER JOIN AccountProjectTask
                ON CTE.ParentAccountProjectTaskId = AccountProjectTask.AccountProjectTaskId
    WHERE   AccountProjectTask.ParentAccountProjectTaskId IS NOT NULL
    -- and  cte.accountProjectId = 1587
)

SELECT  c.IsBillable, c.AccountProjectID, c.AccountProjectTaskId, c.TaskName, c.ParentAccountProjectTaskId
FROM    (   SELECT  *, MAX([Level]) OVER (PARTITION BY TaskName) [MaxLevel]
            FROM    CTE
        ) c
WHERE   MaxLevel = Level 

)