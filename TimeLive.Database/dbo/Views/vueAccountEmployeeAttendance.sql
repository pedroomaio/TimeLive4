
CREATE VIEW dbo.vueAccountEmployeeAttendance
AS
SELECT     dbo.AccountEmployeeAttendance.AccountEmployeeAttendanceId, dbo.AccountEmployeeAttendance.AccountId, dbo.AccountEmployeeAttendance.AccountEmployeeId, 
                      dbo.AccountEmployeeAttendance.AttendanceDate, dbo.AccountEmployeeAttendance.AccountAbsenceTypeId, dbo.AccountEmployeeAttendance.AttendanceTime, 
                      dbo.AccountEmployeeAttendance.InOut, dbo.AccountEmployeeAttendance.CreatedByEmployeeId, dbo.AccountEmployeeAttendance.CreatedOn, 
                      dbo.AccountEmployeeAttendance.ModifiedByEmployeeId, dbo.AccountEmployeeAttendance.ModifiedOn, dbo.AccountAbsenceType.AbsenceDescription, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName
FROM         dbo.AccountEmployeeAttendance LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeAttendance.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountAbsenceType ON dbo.AccountEmployeeAttendance.AccountAbsenceTypeId = dbo.AccountAbsenceType.AccountAbsenceTypeId