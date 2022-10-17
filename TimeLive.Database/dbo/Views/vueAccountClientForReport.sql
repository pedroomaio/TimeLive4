
CREATE VIEW dbo.vueAccountClientForReport
AS
SELECT     dbo.AccountParty.AccountPartyId AS AccountClientId, dbo.AccountParty.PartyTypeId AS ClientTypeId, dbo.AccountParty.AccountId, 
                      dbo.AccountParty.PartyName AS ClientName, ISNULL(dbo.AccountParty.PartyNick, N'') AS ClientNick, ISNULL(dbo.AccountParty.EMailAddress, N'') AS EMailAddress, 
                      ISNULL(dbo.AccountParty.Address1, N'') AS Address1, ISNULL(dbo.AccountParty.Address2, N'') AS Address2, dbo.AccountParty.CountryId, 
                      ISNULL(dbo.AccountParty.State, N'') AS State, ISNULL(dbo.AccountParty.City, N'') AS City, ISNULL(dbo.AccountParty.ZipCode, N'') AS ZipCode, 
                      ISNULL(dbo.AccountParty.Telephone1, N'') AS Telephone1, ISNULL(dbo.AccountParty.Telephone2, N'') AS Telephone2, ISNULL(dbo.AccountParty.Fax, N'') AS Fax, 
                      dbo.AccountParty.DefaultCurrencyId, ISNULL(dbo.AccountParty.DefaultBillingRate, 0) AS DefaultBillingRate, ISNULL(dbo.AccountParty.Website, N'') AS Website, 
                      ISNULL(dbo.AccountParty.Notes, N'') AS Notes, dbo.AccountParty.IsDisabled, dbo.AccountParty.IsDeleted, dbo.AccountParty.CreatedOn, 
                      dbo.AccountParty.CreatedByEmployeeId, dbo.AccountParty.ModifiedOn, dbo.AccountParty.ModifiedByEmployeeId, ISNULL(dbo.SystemCountry.Country, N'') 
                      AS Country, dbo.AccountParty.CustomField1, dbo.AccountParty.CustomField2, dbo.AccountParty.CustomField3, dbo.AccountParty.CustomField4, 
                      dbo.AccountParty.CustomField5, dbo.AccountParty.CustomField6, dbo.AccountParty.CustomField7, dbo.AccountParty.CustomField8, dbo.AccountParty.CustomField9, 
                      dbo.AccountParty.CustomField10, dbo.AccountParty.CustomField11, dbo.AccountParty.CustomField12, dbo.AccountParty.CustomField13, 
                      dbo.AccountParty.CustomField14, dbo.AccountParty.CustomField15
FROM         dbo.AccountParty INNER JOIN
                      dbo.Account ON dbo.AccountParty.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.SystemCountry ON dbo.AccountParty.CountryId = dbo.SystemCountry.CountryId
WHERE     (dbo.AccountParty.IsDeleted <> 1) OR
                      (dbo.AccountParty.IsDeleted IS NULL)