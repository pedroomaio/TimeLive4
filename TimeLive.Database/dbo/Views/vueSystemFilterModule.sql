
CREATE VIEW dbo.vueSystemFilterModule
AS
SELECT     a.SystemFilterModuleId, a.SystemFilterModuleName, b.SystemFilterModuleFieldName, b.IsGridViewFilter, b.SystemFilterModuleFieldId, 
                      b.SystemFilterModuleFieldCaption
FROM         dbo.SystemFilterModule AS a INNER JOIN
                      dbo.SystemFilterModuleField AS b ON a.SystemFilterModuleId = b.SystemFilterModuleId