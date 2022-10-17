
CREATE VIEW dbo.vueExpenseSheetAuditTrailForReport
AS
SELECT     dbo.vueExpenseSheetAuditTrailUnionForReport.Type, dbo.vueExpenseSheetAuditTrailUnionForReport.TableName, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.PK, dbo.vueExpenseSheetAuditTrailUnionForReport.AuditFieldName, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.AuditOldVal, dbo.vueExpenseSheetAuditTrailUnionForReport.AuditNewVal, CONVERT(DateTime, 
                      CONVERT(VARCHAR(10), dbo.vueExpenseSheetAuditTrailUnionForReport.UpdateDate, 120), 120) AS UpdateDate, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.UserName, dbo.vueExpenseSheetAuditTrailUnionForReport.OldValue, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.NewValue, dbo.vueExpenseSheetAuditTrailUnionForReport.FieldName, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.UpdatedBy, dbo.vueExpenseSheetAuditTrailUnionForReport.AccountEmployeeId, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.AccountId, dbo.vueExpenseSheetAuditTrailUnionForReport.Date, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.AccountProjectId, dbo.vueExpenseSheetAuditTrailUnionForReport.AccountExpenseId, 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.Amount, dbo.AccountExpense.AccountExpenseName, dbo.AccountProject.ProjectName
FROM         dbo.vueExpenseSheetAuditTrailUnionForReport LEFT OUTER JOIN
                      dbo.AccountExpense ON 
                      dbo.vueExpenseSheetAuditTrailUnionForReport.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.vueExpenseSheetAuditTrailUnionForReport.AccountProjectId = dbo.AccountProject.AccountProjectId