    
CREATE VIEW dbo.vueAccountEmployeeHolidayTypesWithDetail
AS                  
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountHolidayTypeId, dbo.AccountHolidayType.AccountHolidayType, 
                      dbo.AccountEmployee.AccountId, dbo.AccountHolidayTypeDetail.HolidayName, dbo.AccountHolidayTypeDetail.HolidayDate, 
                      dbo.AccountHolidayTypeDetail.MasterHolidayTypeDetailId, YEAR(dbo.AccountHolidayTypeDetail.HolidayDate) AS Year, 
                      dbo.AccountHolidayTypeDetail.AccountHolidayTypeDetailId
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountHolidayType ON dbo.AccountEmployee.AccountHolidayTypeId = dbo.AccountHolidayType.AccountHolidayTypeId INNER JOIN
                      dbo.AccountHolidayTypeDetail ON dbo.AccountHolidayType.AccountHolidayTypeId = dbo.AccountHolidayTypeDetail.AccountHolidayTypeId