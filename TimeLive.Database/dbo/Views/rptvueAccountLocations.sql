
CREATE VIEW dbo.rptvueAccountLocations
AS
SELECT     dbo.AccountLocation.AccountLocation, dbo.AccountLocation.IsDisabled, dbo.AccountLocation.AccountLocationId, dbo.AccountLocation.AccountId
FROM         dbo.AccountLocation INNER JOIN
                      dbo.Account ON dbo.AccountLocation.AccountId = dbo.Account.AccountId