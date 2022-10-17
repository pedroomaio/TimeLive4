
CREATE VIEW dbo.rptvueTimesheetAuditTrail
AS
SELECT     Type, TableName, PK, AuditFieldName, AuditOldValue, AuditNewValue, UpdateDate, TotalTime, UserName, UpdatedBy, AccountEmployeeId, AccountId, OldValue, 
                      NewValue, FieldName, Date, AccountProjectId, AccountProjectTaskId, ProjectName, TaskName
FROM         dbo.vueTimesheetAuditTrailForReport