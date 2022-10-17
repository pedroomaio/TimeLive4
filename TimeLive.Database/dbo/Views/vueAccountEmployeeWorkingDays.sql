
CREATE VIEW dbo.vueAccountEmployeeWorkingDays
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountWorkingDay.WorkingDayNo, dbo.SystemWorkingDay.WorkingDay, 
                      dbo.AccountWorkingDayType.HoursPerDay
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountWorkingDayType ON dbo.AccountEmployee.AccountWorkingDayTypeId = dbo.AccountWorkingDayType.AccountWorkingDayTypeId INNER JOIN
                      dbo.AccountWorkingDay ON dbo.AccountWorkingDayType.AccountWorkingDayTypeId = dbo.AccountWorkingDay.AccountWorkingDayTypeId INNER JOIN
                      dbo.SystemWorkingDay ON dbo.AccountWorkingDay.WorkingDayNo = dbo.SystemWorkingDay.WorkingDayNo