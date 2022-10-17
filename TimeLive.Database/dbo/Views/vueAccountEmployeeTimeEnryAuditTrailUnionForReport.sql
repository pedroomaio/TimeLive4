
CREATE VIEW dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport
AS
SELECT     Type, TableName, PK, AuditFieldName, AuditOldValue, AuditNewValue, UpdateDate, TotalTime, UserName, UpdatedBy, AccountEmployeeId, AccountId, 
                      OldValue, NewValue, FieldName, Date, AccountProjectId, AccountProjectTaskId
FROM         dbo.vueAccountEmployeeTimeEntryAuditTrailForReport
UNION ALL
SELECT     Type, TableName, PK, AuditFieldName, AuditOldValue, AuditNewValue, UpdateDate, TotalTime, UserName, UpdatedBy, AccountEmployeeId, AccountId, 
                      OldValue, NewValue, FieldName, Date, AccountProjectId, AccountProjectTaskId
FROM         dbo.vueAccountEmployeeTimeEntryPeriodAuditTrailForReport