
CREATE PROCEDURE [dbo].[sp_xpTimeSheetProjectEmployeeDataSet] 
	-- Add the parameters for the stored procedure here
	@pStartDate datetime, 
	@pEndDate datetime,
	--@pEmployee int,
	@pProject int,
	@pEmployee int,
	@pVacations bit,
	@pCustomer int,
	@pShowExtraTime bit
AS
	DECLARE @query varchar(2000),
	@return_value INT,
	@var_start_date varchar(12),
	@var_end_date varchar(12)

 begin
/*
insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pStartDate))
insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pEndDate))
--insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pEmployee))
insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pProject))
insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pVacations))
insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pCustomer))
insert into xp_holidays(date,description) values(getdate(),convert(varchar(10),@pShowExtraTime))
*/
set @var_start_date = @pStartDate
set @var_end_date = @pEndDate

EXEC	@return_value = [dbo].[sp_xpNumberWorkDays]
		@startDate = @var_start_date,
		@endDate = @var_end_date

	
set @query = 'SELECT TIMEENTRYDATE AS _DATE, PROJECTCODE AS _PROJCODE, DESCRIPTION AS _DESC, HOURS + ' + ''':''' + '+ MINUTES AS _HOURS, CAST (HOURS AS INTEGER) AS _SUM_HOURS, CAST (MINUTES AS INTEGER) AS _SUM_MINUTES, IsOverTime AS _IS_OVER_TIME, 0 AS _DUMMY_EXTRA_HOURS, ' + convert(varchar,@return_value) + ' AS DifDays, isnull((select top 1 description from dbo.xp_holidays where convert(varchar,date,103) = convert(varchar,TIMEENTRYDATE,103)),''null'') as Holiday, EMPLOYEECODE, ( select count( distinct vxp.ACCOUNTEMPLOYEEID) from VXP_DETAILTIMESHEET vxp where  vxp.ACCOUNTPROJECTID = ' + convert(varchar,@pProject) +'AND vxp.TIMEENTRYDATE >= convert(datetime, '''+ convert(varchar,@pStartDate,103) + ''' ,103) AND  vxp.TIMEENTRYDATE <= convert(datetime, '''+ convert(varchar,@pEndDate,103) + ''' ,103)) as DistinctEmployee, (Select top 1 A.EMPLOYEECODE + '' - '' + FIRSTNAME + '' '' + LASTNAME AS ACCOUNTEMPLOYEEID FROM ACCOUNTEMPLOYEE A WHERE A.ACCOUNTEMPLOYEEID = t.ACCOUNTEMPLOYEEID) AS EmployeeName' 
set @query = @query + ' FROM VXP_DETAILTIMESHEET as t' 
set @query = @query + ' WHERE TIMEENTRYDATE >= convert(datetime, '''+ convert(varchar,@pStartDate,103) + ''' ,103) '
set @query = @query + ' AND  TIMEENTRYDATE <= convert(datetime, '''+ convert(varchar,@pEndDate,103) + ''' ,103) '
set @query = @query + ' AND ACCOUNTEMPLOYEEID = ' + convert(varchar, @pEmployee)+ ' '
if(@pProject != 0)
 begin
	if(convert(int,@pVacations) != 0)
	 begin
		set @query = @query + ' AND (  ACCOUNTPROJECTID = ' + convert(varchar,@pProject)
		set @query = @query + ' OR ACCOUNTPROJECTID = 378 )'-- xpand absence
	end else  begin
		set @query = @query + ' AND ACCOUNTPROJECTID = ' + convert(varchar,@pProject)
	end 
end else begin --todos
	if(convert(int,@pVacations) = 0) begin --mas se nao se quiser ferias
		set @query = @query + ' AND ACCOUNTPROJECTID <> 378 ' -- xpand absence
	end 
end 
if(@pCustomer != 0) begin --escolhe cliente
	if(convert(int,@pVacations) != 0) begin --mas tb quer ver férias
		set @query = @query + '  AND ( ACCOUNTCLIENTID = ' + convert(varchar,@pCustomer) 	
		set @query = @query + ' OR ACCOUNTPROJECTID = 378)' -- xpand absence
	end else begin
		set @query = @query + ' AND ACCOUNTCLIENTID = ' + convert(varchar,@pCustomer)
	end 
end if(convert(int,@pShowExtraTime) = 0) begin --ver apenas horas normais
	set @query = @query + ' AND UPPER(IsOverTime) = '+ '''F'''
end 
set @query = @query + ' ORDER BY TIMEENTRYDATE ASC, EMPLOYEECODE ASC, ACCOUNTEMPLOYEEID ASC,  ACCOUNTPROJECTID ASC, PROJECTCODE ASC, _IS_OVER_TIME ASC'


if @query is null begin
	SELECT getdate() AS _DATE, 1 AS _PROJCODE, 1 AS _DESC, 1 AS _HOURS, 1 AS _SUM_HOURS, 1 AS _SUM_MINUTES, 1 AS _IS_OVER_TIME, 0 AS _DUMMY_EXTRA_HOURS, 0 AS DifDays, '' as Holiday, '' as EMPLOYEECODE, 1 as DistinctEmployee, '' as EmployeeName
end
else
begin
	print(@query)
	execute(@query)
end

END