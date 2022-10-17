

CREATE PROCEDURE [dbo].[CreateTableforAccountEmployeeTimesheetSubmissionStatus]
    (
@startdate datetime,    
@enddate datetime,
@AccountEmployeeId varchar,
@AccountId integer
            )
AS

    SET NOCOUNT ON

IF EXISTS (SELECT * FROM tempdb.dbo.sysobjects WHERE NAME = '##tempAccountEmployeeTimesheetSubmissionStatusALL')
drop table ##tempAccountEmployeeTimesheetSubmissionStatusALL 


create table ##tempAccountEmployeeTimesheetSubmissionStatusALL 
(AccountEmployeeId int,
EmployeeName varchar(200),
DepartmentName varchar(200),
TimeEntryDate datetime,
NotEntered int,
Entered int,
Submitted int,
Approved int,
Rejected int,
Role varchar(100),
AccountId int)


insert into ##tempAccountEmployeeTimesheetSubmissionStatusALL
(AccountEmployeeId,
EmployeeName,
DepartmentName, 
TimeEntryDate,
NotEntered,
Entered, 
Submitted,
Approved,
Rejected,
Role,
AccountId)
SELECT     [##temp].AccountEmployeeId, CASE WHEN dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, 
                      dbo.AccountDepartment.DepartmentName, AbsentDate AS TimeEntryDate, (CASE WHEN NOT IsNull(AccountEmployeeTimeEntry.TimeEntryDate, 0) 
                      = 0 THEN 0 ELSE 1 END) AS NotEntered, COUNT(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS Entered, 
                      (CASE WHEN dbo.AccountEmployeeTimeEntry.Submitted = 1 THEN COUNT(dbo.AccountEmployeeTimeEntry.Submitted) ELSE 0 END) AS Submitted, 
                      SUM(CASE WHEN Approved = 1 THEN 1 ELSE 0 END) AS Approved, SUM(CASE WHEN Rejected = 1 THEN 1 ELSE 0 END) AS Rejected, dbo.AccountRole.Role, 
                      [##temp].AccountId
FROM         dbo.AccountEmployeeTimeEntry RIGHT OUTER JOIN
                      dbo.tempdb.[##temp] ON dbo.[##temp].AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND 
                      dbo.[##temp].AbsentDate = dbo.AccountEmployeeTimeEntry.TimeEntryDate INNER JOIN
                      dbo.AccountEmployee ON [##temp].AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
GROUP BY [##temp].AccountId, [##temp].AccountEmployeeId, AbsentDate, dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      CASE WHEN dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END, dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role