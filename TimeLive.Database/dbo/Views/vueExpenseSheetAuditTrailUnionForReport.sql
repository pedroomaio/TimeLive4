
CREATE VIEW dbo.vueExpenseSheetAuditTrailUnionForReport
AS
SELECT     Type, TableName, PK, AuditFieldName, AuditOldVal, AuditNewVal, UpdateDate, UserName, OldValue, NewValue, FieldName, UpdatedBy, 
                      AccountEmployeeId, AccountId, Date, AccountProjectId, AccountExpenseId, Amount
FROM         dbo.vueAccountExpenseEntryAuditTrailForReport
UNION ALL
SELECT     Type, TableName, PK, AuditFieldName, AuditOldVal, AuditNewVal, UpdateDate, UserName, OldValue, NewValue, FieldName, UpdatedBy, 
                      AccountEmployeeId, AccountId, Date, AccountProjectId, AccountExpenseId, Amount
FROM         dbo.vueAccountEmployeeExpenseSheetAuditTrailForReport