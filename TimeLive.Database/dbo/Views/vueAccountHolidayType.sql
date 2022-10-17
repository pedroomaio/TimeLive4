
CREATE VIEW dbo.vueAccountHolidayType
AS
SELECT     AccountHolidayTypeId, MasterHolidayTypeId, AccountHolidayType, AccountId, IsDisabled
FROM         dbo.AccountHolidayType