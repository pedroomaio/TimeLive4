GO
CREATE PROCEDURE [dbo].[spTimeSheetsFaults]
    @StartDateGET datetime,   
    @EndDateGET datetime,
	@AssignedEmployeeGET nvarchar(max),
	@ProjectNameGET nvarchar(max),
	@StatusGET nvarchar(max)

AS   
BEGIN

DECLARE @startDate DATETIME = Convert(DateTime, Convert(VARCHAR(10), @StartDateGET , 120), 120)
DECLARE @endDate DATETIME = Convert(DateTime, Convert(VARCHAR(10), @EndDateGET , 120),120)
DECLARE @DynamicCalendar table(TimeEntryDate datetime);

-- Create Dynamic Calendar

;WITH DateRange(RunningDate) AS
(
   SELECT @startDate AS RunningDate
   UNION ALL
   SELECT RunningDate + 1
   FROM DateRange
   WHERE RunningDate < @endDate 
)

Insert into @DynamicCalendar(TimeEntryDate)
Select RunningDate 
from DateRange
Where DATEPART(DW, RunningDate) <> 1 AND DATEPART(DW, RunningDate) <> 7
option (maxrecursion 0);

-- Insert into each Employee Full calendar for the range

--<Create the Cursor from a list of all employees without Disabeld on them>
DECLARE CursorEmployees CURSOR FOR(
Select Distinct AccountEmployeeId , EmployeeName from VueAccountEmployeeTimeEntry where EmployeeName Not Like '%(Disbaled)' And EmployeeName Not Like '%(Disabeld)');
--<Create the Cursor From a list of all dynamic dates>
DECLARE CursorDynamicCalendar CURSOR FOR(
Select * from @DynamicCalendar)
--<Variable that will hold employees names in the foreach>
DECLARE @Employees int;
DECLARE @EmployeeName nvarchar(max);
--<Table that will hold all the employees with all dates>
DECLARE @AllEmployeesWithDates table(AccountEmployeeId int , EmployeeName nvarchar(max) , TimeEntryDate datetime);

Declare @DateStep datetime;

Open CursorEmployees

Fetch next from CursorEmployees
Into @Employees , @EmployeeName

WHILE @@FETCH_STATUS = 0  
BEGIN

Open CursorDynamicCalendar
Fetch next from CursorDynamicCalendar
Into @DateStep
WHILE @@FETCH_STATUS = 0  
BEGIN
	Insert into @AllEmployeesWithDates(AccountEmployeeId , EmployeeName , TimeEntryDate)
	Select @Employees , @EmployeeName , @DateStep	
	Fetch next from CursorDynamicCalendar
	Into @DateStep
END
CLOSE CursorDynamicCalendar  

FETCH NEXT FROM CursorEmployees   
INTO @Employees , @EmployeeName

END

CLOSE CursorEmployees  
DEALLOCATE CursorEmployees  
DEALLOCATE CursorDynamicCalendar 

-- At this point the --> @AllEmployeesWithDates has all the Employees With the dates

SELECT 
a.EmployeeName, 
a.TimeEntryDate,
b.TeamLeadApproved,
b.ProjectManagerApproved,
b.IsTimeOff, 
b.ProjectName,

CASE WHEN b.TimeEntryDate IS NULL THEN 'Not Saved' ELSE (CASE WHEN b.Approved = 1 THEN 'Approved' ELSE CASE WHEN b.Submitted = 1 THEN 'Submitted' ELSE CASE WHEN b.Rejected = 1 then 'Rejected' ELSE 'Saved' END END END) END as [Status],

--Approval Type

CASE WHEN b.TimeEntryDate IS NULL OR (b.Approved = 0 AND b.Submitted = 0 AND b.Rejected = 0) OR (b.Approved = 0 AND b.Submitted = 0 AND b.Rejected = 1) THEN
'Employee'
ELSE
(Select PrjTB.ApprovalTypeName FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId) END as [ApprovalType],

--STATUS COLUMN

CASE WHEN (Select PrjTB.ApprovalTypeName FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId) LIKE '%HR (Expense Approval)%' THEN

 CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 0 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [ADM]' FROM dbo.AccountEmployee AccTable Where AccTable.EmployeeCode = (SELECT LEFT(PrjTB.ApprovalTypeName , 4) FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId))

 ELSE CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 1 AND b.Approved = 0 THEN 'HR'

 END END

ELSE CASE WHEN (Select PrjTB.ApprovalTypeName FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId) LIKE 'Project Manager -> Account Manager%' THEN

 CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 0 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [PM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = b.ProjectManagerEmployeeId) 

 ELSE CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 1 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [EMP_MNGR]' FROM dbo.AccountEmployee AccTable Where AccTable.EmployeeCode = (SELECT REPLACE(RIGHT(PrjTB.ApprovalTypeName , 5),')','') FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId))

 END END

ELSE CASE WHEN b.TimeEntryDate IS NULL OR (b.Approved = 0 AND b.Submitted = 0 AND b.Rejected = 0) OR (b.Approved = 0 AND b.Submitted = 0 AND b.Rejected = 1) THEN
(Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [EMP]'FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = a.AccountEmployeeId)
ELSE
 (CASE b.TimeSheetApprovalTypeId 
 WHEN 296 THEN 'N/A'
 WHEN 297 THEN 

 CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 0 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [TL]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = b.LeaderEmployeeId) 

 ELSE CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 1 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [PM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = b.ProjectManagerEmployeeId)

 END END

 WHEN 298 THEN (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [TL]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = b.LeaderEmployeeId)
 WHEN 299 THEN (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [PM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = b.ProjectManagerEmployeeId)
 WHEN 300 THEN (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [ADM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = 478)
 WHEN 306 THEN (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [ADM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = 478)
 WHEN 307 THEN (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [ADM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = 478)
 END) END END END as [Contact]
 
FROM @AllEmployeesWithDates a
left join VueAccountEmployeeTimeEntry b on a.TimeEntryDate = b.TimeEntryDate and a.AccountEmployeeId = b.AccountEmployeeId
WHERE (@AssignedEmployeeGET is NULL OR a.AccountEmployeeId = @AssignedEmployeeGET)
AND (@ProjectNameGET is NULL OR b.ProjectName = @ProjectNameGET)
AND (@StatusGET is NULL OR CASE WHEN b.TimeEntryDate IS NULL THEN 'Not Saved' ELSE (CASE WHEN b.Approved = 1 THEN 'Approved' ELSE CASE WHEN b.Submitted = 1 THEN 'Submitted' ELSE CASE WHEN b.Rejected = 1 then 'Rejected' ELSE 'Saved' END END END) END = @StatusGET)
AND CASE WHEN b.TimeEntryDate IS NULL THEN 'Not Saved' ELSE (CASE WHEN b.Approved = 1 THEN 'Approved' ELSE CASE WHEN b.Submitted = 1 THEN 'Submitted' ELSE CASE WHEN b.Rejected = 1 then 'Rejected' ELSE 'Saved' END END END) END <> 'Approved'
ORDER BY a.EmployeeName
END

GO

GO

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Defines ReportDataSource
 Insert into SystemReportDataSource values
 ('EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'Time Entry Faults' , 'rptvueAccountEmployeeTimeEntryPeriods' , 'View' , '/Images/TimeEntryPeriod.gif' , null)

 --Define ReportDataSource Columns
 Insert into SystemReportDataSourceField values
('F4D73CC0-92CE-4BE9-AAA4-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'Status' , 180 , 1 , null , null , 15 , '91402610-EEF0-4DD0-ACA3-0080F53389FA' , 'Status' , 0 , 0),
('F4D73CC0-92CE-4BE9-AAA5-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'TimeEntryDate' , 180 , 1 , null , null , 1 , '48B9EF68-B4F6-4C75-B8DE-C547939179CE' , 'Date' , 0 , 0),
('F4D73CC0-92CE-4BE9-AAA6-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'ProjectName' , 250 , 1  , null , null , 3 , '91402610-EEF0-4DD0-ACA3-0080F53389FA' , 'Project Name' , 0 , 0),
('F4D73CC0-92CE-4BE9-AAA7-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'EmployeeName' , 300 , 0 , null , null , 35 , '91402610-EEF0-4DD0-ACA3-0080F53389FA' , 'Employee Name' , 0 , 0),
('F4D73CC0-92CE-4BE9-AAA8-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'IsTimeOff' , 200 , 0 , null , null , 37 , 'B2CB6685-3A4B-4CF9-A15A-D01A63031E2B' , 'Is TimeOff' , 0 , 0),
('F4D73CC0-92CE-4BE9-AAA9-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'ApprovalType' , 200 , 0 , null , null , 39 , '91402610-EEF0-4DD0-ACA3-0080F53389FA' , 'Approval Type' , 0 , 0),
('F4D73CC0-92CE-4BE9-AA10-DA8BBF9CD7A4' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 'Contact' , 180 , 0 , null , null , 51 , '91402610-EEF0-4DD0-ACA3-0080F53389FA' , 'Contact' , 0 , 0);

-- Set Filters
Insert into SystemReportFilterSourceMapping values
('8EF6F0BC-E840-AAAA-8B90-02420C77A315' , '5A1515DA-E197-49C1-83FC-B0D5A9A3034A' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 0 , 0 , 4),
('9E09833A-BFB9-4B00-8032-E94DD903D201' , '4F471B5B-2394-4379-A666-D696E2DFB0EF' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 0 , 1 , 1),
('9E09833A-BFB9-4B00-8032-E94DD903D202' , '8F7F0CC7-E5E4-4F40-924A-60A126092CC0' , 'EE5F3316-3A5E-484E-AE9E-9B11F0990997' , 1 , 1 , 2)
