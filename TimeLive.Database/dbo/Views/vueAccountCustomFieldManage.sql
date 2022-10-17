
CREATE VIEW dbo.vueAccountCustomFieldManage
AS
SELECT     dbo.AccountCustomField.AccountCustomFieldId, dbo.AccountCustomField.AccountId, dbo.AccountCustomField.MasterCustomDataTypeId, 
                      dbo.AccountCustomField.DatabaseFieldName, dbo.AccountCustomField.CustomFieldName, dbo.AccountCustomField.CustomFieldCaption, 
                      dbo.AccountCustomField.DefaultValue, dbo.AccountCustomField.MaximumLength, dbo.AccountCustomField.MinimumValue, dbo.AccountCustomField.MaximumValue, 
                      dbo.AccountCustomField.DropDownOptions, dbo.AccountCustomField.IsRequired, dbo.AccountCustomField.IsDisabled, dbo.MasterEntityType.MasterEntityTypeName, 
                      dbo.AccountCustomField.MasterEntityTypeId, dbo.MasterCustomDataType.MasterCustomDataTypeName
FROM         dbo.AccountCustomField LEFT OUTER JOIN
                      dbo.MasterEntityType ON dbo.AccountCustomField.MasterEntityTypeId = dbo.MasterEntityType.MasterEntityTypeId LEFT OUTER JOIN
                      dbo.MasterCustomDataType ON dbo.AccountCustomField.MasterCustomDataTypeId = dbo.MasterCustomDataType.MasterCustomDataTypeId