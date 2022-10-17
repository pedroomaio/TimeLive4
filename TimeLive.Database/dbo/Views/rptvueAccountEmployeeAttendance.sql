
CREATE VIEW dbo.rptvueAccountEmployeeAttendance
AS  
SELECT     AbsenceDescription, AttendanceDate, [In], TimeIn, Out, TimeOut, EmployeeName, EmployeeCode, AccountEmployeeId, AccountId, 
                      REPLACE(TotalMinutes / 60, '', '.00') + ':' + RIGHT('0' + REPLACE(TotalMinutes - TotalMinutes / 60 * 60, '', '.00'), 2) AS TotalTime, 
                      CAST(ROUND(CONVERT(float, TotalMinutes) / 60, 2) AS decimal(18, 2)) AS Hours, Location
FROM         dbo.vueAccountEmployeeAttendanceForReport