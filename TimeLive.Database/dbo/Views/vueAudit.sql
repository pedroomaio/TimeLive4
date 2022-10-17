
CREATE VIEW dbo.vueAudit
AS
SELECT     dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName, dbo.Audit.OldValue, dbo.Audit.NewValue, dbo.Audit.UpdateDate, dbo.Audit.UserName, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.AccountId
FROM         dbo.Audit LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.Audit.NewValue = dbo.AccountStatus.Status AND dbo.Audit.OldValue = dbo.AccountStatus.Status AND 
                      dbo.Audit.FieldName = dbo.AccountStatus.Status AND dbo.Audit.PK = dbo.AccountStatus.AccountStatusId AND dbo.Audit.TableName = 'AccountStatus' LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.Audit.UserName = dbo.AccountEmployee.AccountEmployeeId