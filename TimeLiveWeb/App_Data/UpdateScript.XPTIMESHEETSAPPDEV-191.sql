/****** Object:  StoredProcedure [dbo].[spTimeSheetsFaults]    Script Date: 29/03/2017 13:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spTimeSheetsFaults]
    @StartDateGET datetime,   
    @EndDateGET datetime,
	@AssignedEmployeeGET nvarchar(max),
	@ProjectNameGET nvarchar(max),
	@DisabledGET bit
AS   

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
Select Distinct AccountEmployeeId , FirstName , LastName , MiddleName , HiredDate , TerminationDate , EmployeeCode , IsDisabled , IsDeleted from AccountEmployee
WHERE @AssignedEmployeeGET is null or @AssignedEmployeeGET = AccountEmployeeId 
AND (@DisabledGET = 1 or IsDisabled <> 1)
AND IsDeleted <> 1)
--<Create the Cursor From a list of all dynamic dates>
DECLARE CursorDynamicCalendar CURSOR FOR(
Select * from @DynamicCalendar)
--<Variable that will hold employees names in the foreach>

DECLARE @Employees int;
DECLARE @EmployeeName nvarchar(max);
DECLARE @FirstName nvarchar(max);
DECLARE @MiddleName nvarchar(max);
DECLARE @LastName nvarchar(max);
DECLARE @HiredDate datetime;
DECLARE @TerminationDate datetime;
DECLARE @IsDisabled bit;
DECLARE @IsDeleted bit;
DECLARE @EmployeeCode nvarchar(5);

--<Table that will hold all the employees with all dates>
DECLARE @AllEmployeesWithDates table(AccountEmployeeId int , EmployeeName nvarchar(max) , TimeEntryDate datetime);

Declare @DateStep datetime;

Open CursorEmployees

Fetch next from CursorEmployees
Into @Employees , @FirstName , @LastName , @MiddleName , @HiredDate , @TerminationDate , @EmployeeCode , @IsDisabled , @IsDeleted

WHILE @@FETCH_STATUS = 0  
BEGIN

Open CursorDynamicCalendar
Fetch next from CursorDynamicCalendar
Into @DateStep
WHILE @@FETCH_STATUS = 0  
BEGIN
	
	DECLARE @DisabledLabel nvarchar(max);
	SET @DisabledLabel = IIF(@IsDisabled = 1, ' (Disabled)' , '')

	SET @EmployeeName = @EmployeeCode + ' - ' + @FirstName + ' ' + @LastName + @DisabledLabel

	Insert into @AllEmployeesWithDates(AccountEmployeeId , EmployeeName , TimeEntryDate)
	Select @Employees , @EmployeeName , @DateStep	
	Where 
	(@HiredDate is null or @DateStep >= @HiredDate)
	AND (@TerminationDate is null or @DateStep <= @TerminationDate)
	Fetch next from CursorDynamicCalendar
	Into @DateStep

END
CLOSE CursorDynamicCalendar  

FETCH NEXT FROM CursorEmployees   
Into @Employees , @FirstName , @LastName , @MiddleName , @HiredDate , @TerminationDate , @EmployeeCode , @IsDisabled , @IsDeleted

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

CASE WHEN b.IsTimeOff = 1 and b.Submitted = 1 and b.Approved = 0 and b.Rejected = 0 THEN
'Employee Manager'
ELSE CASE WHEN b.TimeEntryDate IS NULL OR (b.Approved = 0 AND b.Submitted = 0 AND b.Rejected = 0) OR (b.Approved = 0 AND b.Submitted = 0 AND b.Rejected = 1) THEN
'Employee'
ELSE
(Select PrjTB.ApprovalTypeName FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId) END END as [ApprovalType],

--STATUS COLUMN

CASE WHEN b.IsTimeOff = 1 and b.Submitted = 1 and b.Approved = 0 and b.Rejected = 0 then

(Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [EMP_MNGR]' 
FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = 
(select EmployeeManagerId from accountemployee Where AccountEmployeeId = b.AccountEmployeeId)) -- Id do manager

ELSE CASE WHEN (Select PrjTB.ApprovalTypeName FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId) LIKE '%HR (Expense Approval)%' THEN

 CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 0 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [ADM]' FROM dbo.AccountEmployee AccTable Where AccTable.EmployeeCode = (SELECT LEFT(PrjTB.ApprovalTypeName , 4) FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId))

 ELSE CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 1 AND b.Approved = 0 THEN 'HR'

 END END

ELSE CASE WHEN (Select PrjTB.ApprovalTypeName FROM dbo.AccountApprovalType PrjTB WHERE PrjTB.AccountApprovalTypeId = b.TimeSheetApprovalTypeId) LIKE 'Project Manager -> Account Manager%' THEN

 CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 0 AND b.Approved = 0 THEN
 (Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [PM]' FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = b.ProjectManagerEmployeeId) 

 ELSE CASE WHEN (Select ATEP.InApproval FROM AccountEmployeeTimeEntryPeriod ATEP Where ATEP.AccountEmployeeTimeEntryPeriodId = b.AccountEmployeeTimeEntryPeriodId) = 1 AND b.Approved = 0 THEN

(Select AccTable.EmployeeCode + ' - ' + AccTable.FirstName + ' ' + AccTable.LastName + ' [EMP_MNGR]' 
FROM dbo.AccountEmployee AccTable Where AccTable.AccountEmployeeId = 
(select EmployeeManagerId from accountemployee Where AccountEmployeeId = b.AccountEmployeeId)) -- Id do manager

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
 END) END END END END as [Contact]
 
FROM @AllEmployeesWithDates a
left join VueAccountEmployeeTimeEntry b on a.TimeEntryDate = b.TimeEntryDate and a.AccountEmployeeId = b.AccountEmployeeId
inner join AccountEmployee acc on a.AccountEmployeeId = acc.AccountEmployeeId
WHERE (@AssignedEmployeeGET is NULL OR a.AccountEmployeeId = @AssignedEmployeeGET)
AND (@ProjectNameGET is NULL OR b.ProjectName = @ProjectNameGET)
AND CASE WHEN b.TimeEntryDate IS NULL THEN 'Not Saved' ELSE (CASE WHEN b.Approved = 1 THEN 'Approved' ELSE CASE WHEN b.Submitted = 1 THEN 'Submitted' ELSE CASE WHEN b.Rejected = 1 then 'Rejected' ELSE 'Saved' END END END) END <> 'Approved'
AND (@DisabledGET = 1 or acc.IsDisabled = @DisabledGET)
AND acc.IsDeleted <> 1
ORDER BY a.EmployeeName , a.TimeEntryDate