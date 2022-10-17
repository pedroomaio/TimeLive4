
CREATE VIEW dbo.vueAccountEmployeeAbsenceForReport
AS                      
SELECT     dbo.AccountEmployeeAttendance.AccountEmployeeAttendanceId, dbo.AccountEmployeeAttendance.AccountId, dbo.AccountEmployeeAttendance.AccountEmployeeId, 
                      dbo.AccountEmployeeAttendance.AttendanceDate, dbo.AccountEmployeeAttendance.AccountAbsenceTypeId, dbo.AccountEmployeeAttendance.AttendanceTime, 
                      dbo.AccountEmployeeAttendance.InOut, dbo.AccountEmployeeAttendance.CreatedByEmployeeId, dbo.AccountEmployeeAttendance.CreatedOn, 
                      dbo.AccountEmployeeAttendance.ModifiedByEmployeeId, dbo.AccountEmployeeAttendance.ModifiedOn, dbo.AccountAbsenceType.AbsenceDescription, 
                      ISNULL(dbo.AccountEmployee.EmployeeCode, N'') AS EmployeeCode, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName
FROM         dbo.AccountEmployeeAttendance INNER JOIN
                      dbo.AccountAbsenceType ON dbo.AccountEmployeeAttendance.AccountAbsenceTypeId = dbo.AccountAbsenceType.AccountAbsenceTypeId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeAttendance.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId