
CREATE VIEW dbo.vueAccountWorkingDay
AS
SELECT     dbo.SystemWorkingDay.WorkingDayNo, dbo.SystemWorkingDay.WorkingDay, dbo.AccountWorkingDay.AccountWorkingDayId, 
                      dbo.AccountWorkingDay.AccountId, dbo.AccountWorkingDay.AccountWorkingDayTypeId, dbo.AccountWorkingDayType.WeekStartDay
FROM         dbo.AccountWorkingDay LEFT OUTER JOIN
                      dbo.AccountWorkingDayType ON 
                      dbo.AccountWorkingDay.AccountWorkingDayTypeId = dbo.AccountWorkingDayType.AccountWorkingDayTypeId RIGHT OUTER JOIN
                      dbo.SystemWorkingDay ON dbo.AccountWorkingDay.WorkingDayNo = dbo.SystemWorkingDay.WorkingDayNo