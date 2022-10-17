
CREATE VIEW dbo.rptvueExpenseSheetAuditTrail
AS
SELECT     Type, TableName, PK, AuditFieldName, AuditOldVal, AuditNewVal, UpdateDate, UserName, OldValue, NewValue, FieldName, UpdatedBy, 
                      AccountEmployeeId, AccountId, Date, AccountProjectId, AccountExpenseId, Amount, AccountExpenseName, ProjectName
FROM         dbo.vueExpenseSheetAuditTrailForReport