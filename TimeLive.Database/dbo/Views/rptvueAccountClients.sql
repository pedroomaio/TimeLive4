
CREATE VIEW dbo.rptvueAccountClients
AS
SELECT     AccountClientId, ClientTypeId, AccountId, ClientName, ClientNick, EMailAddress, Address1, Address2, CountryId, State, City, ZipCode, Telephone1, Telephone2, Fax, 
                      DefaultCurrencyId, DefaultBillingRate, Website, Notes, IsDisabled, IsDeleted, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, Country, 
                      CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, 
                      CustomField12, CustomField13, CustomField14, CustomField15
FROM         dbo.vueAccountClientForReport