
CREATE VIEW dbo.vueAccountPartyContact
AS
SELECT     dbo.AccountPartyContact.AccountPartyContactId, dbo.AccountPartyContact.AccountPartyId, dbo.AccountPartyContact.FirstName, dbo.AccountPartyContact.LastName, 
                      dbo.AccountPartyContact.Telephone1, dbo.AccountPartyContact.Telephone2, dbo.AccountPartyContact.Fax, dbo.AccountPartyContact.EMailAddress, 
                      dbo.AccountPartyContact.State, dbo.AccountPartyContact.City, dbo.AccountPartyContact.Zip, dbo.AccountPartyContact.CountryId, dbo.AccountPartyContact.Address1, 
                      dbo.AccountPartyContact.Address2, dbo.AccountPartyContact.AccountPartyDepartmentId, dbo.AccountPartyContact.Location, dbo.AccountParty.PartyName, 
                      dbo.AccountParty.PartyNick, dbo.AccountParty.AccountId
FROM         dbo.AccountPartyContact LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountPartyContact.AccountPartyId = dbo.AccountParty.AccountPartyId