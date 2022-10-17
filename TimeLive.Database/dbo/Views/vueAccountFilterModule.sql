
CREATE VIEW dbo.vueAccountFilterModule
AS
SELECT     a.AccountFilterModuleId, a.SystemFilterModuleId, a.SystemFilterModuleFieldId, a.AccountId, a.AccountEmployeeId, a.AccountFilterModuleName, 
                      a.AccountFilterModuleText, a.CreatedOn, a.CreatedByEmployeeId, a.ModifiedOn, a.ModifiedByEmployeeId, b.SystemFilterModuleName, 
                      c.SystemFilterModuleFieldName, c.IsGridViewFilter, a.AccountFilterModuleDefaultName, c.SystemFilterModuleFieldCaption
FROM         dbo.AccountFilterModule AS a INNER JOIN
                      dbo.SystemFilterModule AS b ON a.SystemFilterModuleId = b.SystemFilterModuleId INNER JOIN
                      dbo.SystemFilterModuleField AS c ON a.SystemFilterModuleFieldId = c.SystemFilterModuleFieldId