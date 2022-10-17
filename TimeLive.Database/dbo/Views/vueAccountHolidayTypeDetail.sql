
CREATE VIEW dbo.vueAccountHolidayTypeDetail
AS
SELECT     AccountHolidayTypeDetailId, AccountHolidayTypeId, MasterHolidayTypeDetailId, HolidayName, HolidayDate, AccountId, YEAR(HolidayDate) AS Year
FROM         dbo.AccountHolidayTypeDetail