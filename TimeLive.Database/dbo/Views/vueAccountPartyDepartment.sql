
CREATE VIEW dbo.vueAccountPartyDepartment
AS
SELECT     dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick, dbo.AccountPartyDepartment.AccountPartyDepartmentId, dbo.AccountPartyDepartment.AccountPartyId, 
                      dbo.AccountPartyDepartment.PartyDepartmentCode, dbo.AccountPartyDepartment.PartyDepartmentName, dbo.AccountPartyDepartment.PartyDepartmentLocation, 
                      dbo.AccountParty.AccountId
FROM         dbo.AccountParty RIGHT OUTER JOIN
                      dbo.AccountPartyDepartment ON dbo.AccountParty.AccountPartyId = dbo.AccountPartyDepartment.AccountPartyId