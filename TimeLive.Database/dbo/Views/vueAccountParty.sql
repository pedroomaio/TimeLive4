
CREATE VIEW dbo.vueAccountParty
AS
SELECT     dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyTypeId, dbo.AccountParty.AccountId, dbo.AccountParty.PartyName, 
                      dbo.AccountParty.PartyNick, dbo.AccountParty.EMailAddress, dbo.AccountParty.Address1, dbo.AccountParty.Address2, dbo.AccountParty.CountryId, 
                      dbo.AccountParty.State, dbo.AccountParty.City, dbo.AccountParty.ZipCode, dbo.AccountParty.Telephone1, dbo.AccountParty.Telephone2, 
                      dbo.AccountParty.Fax, dbo.AccountParty.DefaultBillingRate, dbo.AccountParty.Website, dbo.AccountParty.Notes, dbo.AccountParty.IsDisabled, 
                      dbo.AccountParty.IsDeleted, dbo.AccountParty.CreatedOn, dbo.AccountParty.CreatedByEmployeeId, dbo.AccountParty.ModifiedOn, 
                      dbo.AccountParty.ModifiedByEmployeeId, dbo.SystemCountry.Country
FROM         dbo.SystemCountry INNER JOIN
                      dbo.AccountParty ON dbo.SystemCountry.CountryId = dbo.AccountParty.CountryId