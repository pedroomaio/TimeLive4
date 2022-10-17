
CREATE VIEW dbo.vueAccountEmployeeTimeEntryAuditTrailForReport
AS                              
SELECT     dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldValue, 
                      dbo.Audit.NewValue AS AuditNewValue, dbo.Audit.UpdateDate, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.Audit.UserName, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS UpdatedBy, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, dbo.AccountProject.AccountId, 
                      CASE WHEN FieldName = 'AccountProjectId' THEN AccountProjectOld.ProjectName WHEN FieldName = 'AccountProjectTaskId' THEN AccountProjectTaskOld.TaskName
                       WHEN FieldName = 'AccountCostCenterId' THEN AccountCostCenterOld.AccountCostCenter WHEN FieldName = 'AccountWorkTypeId' THEN AccountWorkTypeOld.AccountWorkType
                       WHEN FieldName = 'StartTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.OldValue, 109), 7), ' ', 0) 
                      WHEN FieldName = 'EndTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.OldValue, 109), 7), ' ', 0) WHEN FieldName = 'TotalTime' THEN LEFT(CONVERT(varchar, 
                      CONVERT(datetime, Audit.OldValue), 8), 5) ELSE Audit.OldValue END AS OldValue, 
                      CASE WHEN FieldName = 'AccountProjectId' THEN AccountProjectNew.ProjectName WHEN FieldName = 'AccountProjectTaskId' THEN AccountProjectTaskNew.TaskName
                       WHEN FieldName = 'AccountCostCenterId' THEN AccountCostCenterNew.AccountCostCenter WHEN FieldName = 'AccountWorkTypeId' THEN AccountWorkTypeNew.AccountWorkType
                       WHEN FieldName = 'StartTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.NewValue, 109), 7), ' ', 0) 
                      WHEN FieldName = 'EndTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.NewValue, 109), 7), ' ', 0) WHEN FieldName = 'TotalTime' THEN LEFT(CONVERT(varchar, 
                      CONVERT(datetime, Audit.NewValue), 8), 5) ELSE Audit.NewValue END AS NewValue, 
                      CASE WHEN FieldName = 'AccountProjectId' THEN 'Project Name' WHEN FieldName = 'AccountProjectTaskId' THEN 'Task Name' WHEN FieldName = 'AccountCostCenterId'
                       THEN 'Cost Center' WHEN FieldName = 'AccountWorkTypeId' THEN 'Work Type' ELSE Audit.FieldName END AS FieldName, CONVERT(varchar, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, 106) AS Date, dbo.AccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId
FROM         dbo.AccountPreferences RIGHT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN
                      dbo.Audit LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.Audit.PK = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId LEFT OUTER JOIN
                      dbo.AccountProject AS AccountProjectOld ON dbo.Audit.OldValue = CONVERT(nvarchar(50), AccountProjectOld.AccountProjectId) LEFT OUTER JOIN
                      dbo.AccountProject AS AccountProjectNew ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountProjectNew.AccountProjectId) LEFT OUTER JOIN
                      dbo.AccountProjectTask AS AccountProjectTaskOld ON dbo.Audit.OldValue = CONVERT(nvarchar(50), AccountProjectTaskOld.AccountProjectTaskId) LEFT OUTER JOIN
                      dbo.AccountProjectTask AS AccountProjectTaskNew ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountProjectTaskNew.AccountProjectTaskId) LEFT OUTER JOIN
                      dbo.AccountWorkType AS AccountWorkTypeOld ON dbo.Audit.OldValue = CONVERT(nvarchar(50), AccountWorkTypeOld.AccountWorkTypeId) LEFT OUTER JOIN
                      dbo.AccountWorkType AS AccountWorkTypeNew ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountWorkTypeNew.AccountWorkTypeId) LEFT OUTER JOIN
                      dbo.AccountCostCenter AS AccountCostCenterOld ON dbo.Audit.OldValue = CONVERT(nvarchar(50), AccountCostCenterOld.AccountCostCenterId) LEFT OUTER JOIN
                      dbo.AccountCostCenter AS AccountCostCenterNew ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountCostCenterNew.AccountCostCenterId) ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.Audit.UserName LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId
WHERE     (dbo.Audit.TableName = 'AccountEmployeeTimeEntry') AND (dbo.Audit.FieldName IN ('AccountProjectId', 'AccountProjectTaskId', 'AccountWorkTypeId', 
                      'AccountCostCenterId', 'StartTime', 'EndTime', 'TotalTime', 'Description'))