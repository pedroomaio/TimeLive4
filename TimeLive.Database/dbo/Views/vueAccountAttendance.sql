
CREATE VIEW dbo.vueAccountAttendance
AS
SELECT     dbo.AccountAbsenceType.AbsenceDescription, dbo.AccountAbsenceType.AccountAbsenceTypeId, dbo.AccountEmployeeAttendance.AttendanceDate, 
                      dbo.AccountEmployee.AccountEmployeeId, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.Account.AccountId, dbo.AccountEmployeeAttendance.InOut, 
                      dbo.AccountEmployeeAttendance.AttendanceTime, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountEmployeeAttendance.AccountEmployeeAttendanceId, CASE WHEN InOut = 'Out' THEN
                          (SELECT     TOP 1 AttendanceTime
                            FROM          AccountEmployeeAttendance Related
                            WHERE      Related.AccountEmployeeId = AccountEmployeeAttendance.AccountEmployeeId AND CONVERT(varchar, Related.attendancedate, 112) 
                                                   = CONVERT(varchar, AccountEmployeeAttendance.AttendanceDate, 112) AND replace(CONVERT(varchar, Related.AttendanceTime, 114), ':',
                                                    '') < replace(CONVERT(varchar, AccountEmployeeAttendance.AttendanceTime, 114), ':', '')
                            ORDER BY AttendanceTime DESC) ELSE 0 END AS RelatedAttendanceTimeIn, dbo.AccountLocation.AccountLocation
FROM         dbo.AccountLocation RIGHT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountLocation.AccountLocationId = dbo.AccountEmployee.AccountLocationId RIGHT OUTER JOIN
                      dbo.AccountEmployeeAttendance ON dbo.AccountEmployee.AccountId = dbo.AccountEmployeeAttendance.AccountId AND 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeAttendance.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountPreferences INNER JOIN
                      dbo.Account ON dbo.AccountPreferences.AccountId = dbo.Account.AccountId ON 
                      dbo.AccountEmployeeAttendance.AccountId = dbo.Account.AccountId LEFT OUTER JOIN
                      dbo.AccountAbsenceType ON dbo.AccountEmployeeAttendance.AccountId = dbo.AccountAbsenceType.AccountId AND 
                      dbo.AccountEmployeeAttendance.AccountAbsenceTypeId = dbo.AccountAbsenceType.AccountAbsenceTypeId