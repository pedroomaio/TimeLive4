
CREATE VIEW dbo.vueAccountEMployeeAttendanceforReport
AS  
SELECT     AbsenceDescription, AttendanceDate, CASE WHEN [In] = 'In' THEN [In] ELSE NULL END AS [In], CASE WHEN [In] = 'In' THEN TimeIn ELSE NULL 
                      END AS TimeIn, CASE WHEN Out = 'Out' THEN Out ELSE NULL END AS Out, CASE WHEN Out = 'Out' THEN TimeOut ELSE NULL END AS TimeOut, 
                      EmployeeName, ISNULL(EmployeeCode, N'') AS EmployeeCode, AccountEmployeeId, AccountId, ISNULL(TotalHours, 0) AS TotalHours, 
                      ISNULL(TotalMinutes, 0) AS TotalMinutes, AccountLocation AS Location
FROM         dbo.vueAccountEmployeeAttendanceDetail