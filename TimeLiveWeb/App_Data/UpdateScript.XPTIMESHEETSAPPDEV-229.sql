
/****** Object:  StoredProcedure [dbo].[sp_xpTimeSheetsMissingDays]    Script Date: 19/04/2017 12:20:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sp_xpTimeSheetsMissingDays] 
	@AssingedEmployeeIdGET nvarchar(max)
AS   

DECLARE @HiredDate datetime
set @HiredDate = (Select HiredDate From AccountEmployee Where AccountEmployeeId = @AssingedEmployeeIdGET)

DECLARE @StartOfYear DATETIME 
SET @StartOfYear = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)

Declare @HiredCalculatedDate Datetime
SET @HiredCalculatedDate = CASE WHEN @HiredDate > @StartOfYear THEN @HiredDate ELSE @StartOfYear END;

DECLARE @startDate DATETIME = Convert(DateTime, Convert(VARCHAR(10), @HiredCalculatedDate  , 120), 120) -- Primeiro dia de trabalho
DECLARE @endDate DATETIME = Convert(DateTime, Convert(VARCHAR(10), (SELECT DATEADD(day,-1 - (DATEPART(weekday, GETDATE()) + @@DATEFIRST) % 7,GETDATE())) , 120),120) -- Ultima sexta feira
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
Where DATEPART(DW, RunningDate) = 2
option (maxrecursion 0);

--<Create the Cursor From a list of all dynamic dates>
DECLARE CursorDynamicCalendar CURSOR FOR(
Select * from @DynamicCalendar)

Declare @DateStep datetime;
Declare @Periods table(PeriodId nvarchar(max) , Submitted bit , Approved bit , Rejected bit , StartDay datetime , EndDay datetime)

--<Start Cursor>
Open CursorDynamicCalendar
Fetch next from CursorDynamicCalendar
Into @DateStep
WHILE @@FETCH_STATUS = 0  
BEGIN

Insert into @Periods values 
((Select AccountEmployeeTimeEntryPeriodId From VueAccountEmployeeTimeEntryPeriod Where AccountEmployeeId = @AssingedEmployeeIdGET AND TimeEntryStartDate = @DateStep),
(Select Submitted From VueAccountEmployeeTimeEntryPeriod Where AccountEmployeeId = @AssingedEmployeeIdGET AND TimeEntryStartDate = @DateStep),
(Select Approved From VueAccountEmployeeTimeEntryPeriod Where AccountEmployeeId = @AssingedEmployeeIdGET AND TimeEntryStartDate = @DateStep),
(Select Rejected From VueAccountEmployeeTimeEntryPeriod Where AccountEmployeeId = @AssingedEmployeeIdGET AND TimeEntryStartDate = @DateStep),
@DateStep,
DATEADD(DAY , 6 , @DateStep))

Fetch next from CursorDynamicCalendar
Into @DateStep

END
CLOSE CursorDynamicCalendar  

Select 
SUM(CASE WHEN pr.Submitted = 0 AND pr.Approved = 0 AND pr.Rejected = 0 THEN 1 ELSE 0 END) AS Saved, 
SUM(CASE WHEN pr.Rejected = 1 AND pr.Approved = 0 THEN 1 ELSE 0 END) AS Rejected,
SUM(CASE WHEN ISNULL(pr.PeriodId , '') = '' THEN 1 ELSE 0 END) AS NotSaved,
SUM(CASE WHEN pr.Approved = 1 OR pr.Submitted = 1 THEN 0 ELSE 1 END) AS Total
FROM @Periods pr