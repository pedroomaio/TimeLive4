
CREATE VIEW dbo.vueAccountEmployeeExpenseSheetAuditTrailForReport
AS
SELECT     dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldVal, 
                      dbo.Audit.NewValue AS AuditNewVal, dbo.Audit.UpdateDate, dbo.Audit.UserName, 
                      CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN AccountEmployeeOld.FirstName + ' ' + AccountEmployeeOld.LastName WHEN FieldName = 'RejectedByEmployeeId'
                       THEN AccountEmployeeOld.FirstName + ' ' + AccountEmployeeOld.LastName WHEN FieldName = 'Approved' THEN CASE WHEN Audit.OldValue = '1' THEN
                       'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Submitted' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue
                       <> '1' THEN 'No' END WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END ELSE
                       Audit.OldValue END AS OldValue, 
                      CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN AccountEmployeeNew.FirstName + ' ' + AccountEmployeeNew.LastName WHEN FieldName =
                       'RejectedByEmployeeId' THEN AccountEmployeeNew.FirstName + ' ' + AccountEmployeeNew.LastName WHEN FieldName = 'SubmittedDate' THEN CONVERT(nvarchar(16),
                       Audit.NewValue, 112) 
                      WHEN FieldName = 'Approved' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Submitted'
                       THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.NewValue
                       = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END ELSE Audit.NewValue END AS NewValue, 
                      CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN 'ApprovedBy' WHEN FieldName = 'RejectedByEmployeeId' THEN 'RejectedBy' ELSE Audit.FieldName
                       END AS FieldName, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS UpdatedBy, 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeId, dbo.AccountEmployeeExpenseSheet.AccountId, 
                      dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate AS Date, NULL AS AccountProjectId, NULL AS AccountExpenseId, NULL AS Amount
FROM         dbo.Audit LEFT OUTER JOIN
                      dbo.AccountEmployeeExpenseSheet ON dbo.Audit.PK = dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployeeOld ON dbo.Audit.OldValue = CONVERT(varchar, AccountEmployeeOld.AccountEmployeeId) 
                      LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployeeNew ON dbo.Audit.NewValue = CONVERT(varchar, AccountEmployeeNew.AccountEmployeeId) 
                      LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.Audit.UserName = dbo.AccountEmployee.AccountEmployeeId
WHERE     (dbo.Audit.TableName = 'AccountEmployeeExpenseSheet') AND (dbo.Audit.Type = 'U') AND (dbo.Audit.FieldName IN (N'ExpenseSheetDate', 
                      N'Description', 'Submitted', 'Approved', 'Rejected', 'SubmittedDate', 'ApprovedOn', 'ApprovedByEmployeeId', 'RejectedByEmployeeId', 'RejectedOn'))