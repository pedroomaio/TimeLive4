
CREATE VIEW dbo.vueAccountEmployeeAttendanceDetail
AS                    
SELECT     AbsenceDescription, AttendanceDate, MIN(InOut) AS [In], MIN(AttendanceTime) AS TimeIn, MAX(InOut) AS Out, MAX(AttendanceTime) AS TimeOut, 
                      SUM(CASE WHEN InOut = 'Out' THEN CONVERT(nvarchar(16), DATEDIFF(hour, CONVERT(NCHAR(16), RelatedAttendanceTimeIn, 8), 
                      CONVERT(NCHAR(16), AttendanceTime, 8))) ELSE 0 END) AS TotalHours, SUM(CASE WHEN InOut = 'Out' THEN CONVERT(nvarchar(16), DATEDIFF(mi, 
                      CONVERT(NCHAR(16), RelatedAttendanceTimeIn, 8), CONVERT(NCHAR(16), AttendanceTime, 8))) ELSE 0 END) AS TotalMinutes, EmployeeName, 
                      EmployeeCode, AccountEmployeeId, AccountId, AccountLocation
FROM         dbo.vueAccountAttendance
GROUP BY AbsenceDescription, AttendanceDate, EmployeeName, EmployeeCode, AccountEmployeeId, AccountId, AccountLocation