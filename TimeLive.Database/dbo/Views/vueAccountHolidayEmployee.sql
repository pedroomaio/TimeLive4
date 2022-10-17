
CREATE VIEW dbo.vueAccountHolidayEmployee
AS
SELECT     dbo.AccountHolidayType.AccountHolidayTypeId, dbo.AccountHolidayType.MasterHolidayTypeId, dbo.AccountHolidayType.AccountHolidayType, 
                      dbo.AccountHolidayType.IsDisabled, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId
FROM         dbo.AccountHolidayType INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountHolidayType.AccountHolidayTypeId = dbo.AccountEmployee.AccountHolidayTypeId