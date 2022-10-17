

CREATE PROCEDURE [dbo].[InsertAbsentDate]
    (
@startdate datetime,    
@enddate datetime,
@AccountEmployeeId integer,
@AccountId integer
            )
AS

    SET NOCOUNT ON

IF NOT EXISTS (SELECT * FROM tempdb.dbo.sysobjects WHERE NAME = '##temp')
create table ##temp(AbsentDate datetime, 
AccountEmployeeId int,
AccountId int)


IF EXISTS (SELECT * FROM tempdb.dbo.sysobjects WHERE NAME = '##temp')
delete from ##temp where AccountId = @AccountId and AccountEmployeeId = @AccountEmployeeId

insert into ##temp(AbsentDate, AccountEmployeeId, AccountId) 
Select dateadd(day,number,@startdate), @AccountEmployeeId as AccountEmployeeId, @AccountId as AccountId
from master.dbo.spt_values  where master.dbo.spt_values.type='P' 
and dateadd(day,number,@startdate)<=@enddate  



-- Create Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus
Print 'Create Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus'