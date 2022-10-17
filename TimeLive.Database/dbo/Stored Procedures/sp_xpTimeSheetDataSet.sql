
CREATE PROCEDURE [dbo].[sp_xpTimeSheetDataSet] 
	-- Add the parameters for the stored procedure here
	@pStartDate datetime, 
	@pEndDate datetime,
	@pMonth varchar(10),
	@pYear varchar(4),
	@pEmployee int,
	@pProject int,
	@pVacations bit,
	@pCustomer int,
	@pShowExtraTime bit
AS
	DECLARE @query varchar(2000),
	@return_value INT,
	@var_start_date varchar(12),
	@var_end_date varchar(12)

 begin

/*insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pStartDate))
insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pEndDate))
insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pEmployee))
insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pProject))
insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pVacations))
insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pCustomer))
insert into xp_vacationmap_DEV(date,description) values(getdate(),convert(varchar(10),@pShowExtraTime))*/


set @var_start_date = @pStartDate
set @var_end_date = @pEndDate

EXEC	@return_value = [dbo].[sp_xpNumberWorkDays]
		@startDate = @var_start_date,
		@endDate = @var_end_date

if(@pMonth is null)
 begin
	set @var_start_date = @pStartDate
	set @var_end_date = @pEndDate

	EXEC	@return_value = [dbo].[sp_xpNumberWorkDays]
			@startDate = @var_start_date,
			@endDate = @var_end_date
 end
else
 begin
	set @var_start_date = convert(datetime,'01/'+@pMonth+'/2011',103)
	set @var_end_date = DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,convert(datetime,'01/'+@pMonth+'/2011',103))+1,0))

	EXEC	@return_value = [dbo].[sp_xpNumberWorkDays]
			@startDate = @var_start_date,
			@endDate = @var_end_date
 end
	
set @query = 'SELECT TIMEENTRYDATE AS _DATE, PROJECTCODE AS _PROJCODE, DESCRIPTION AS _DESC, HOURS + ' + ''':''' + '+ MINUTES AS _HOURS, CAST (HOURS AS INTEGER) AS _SUM_HOURS, CAST (MINUTES AS INTEGER) AS _SUM_MINUTES, IsOverTime AS _IS_OVER_TIME, 0 AS _DUMMY_EXTRA_HOURS, ' + convert(varchar,@return_value) + ' AS DifDays, isnull((select top 1 description from dbo.xp_holidays where convert(varchar,date,103) = convert(varchar,TIMEENTRYDATE,103)),''null'') as Holiday ' 
set @query = @query + ' FROM VXP_DETAILTIMESHEET' 
set @query = @query + ' WHERE '
set @query = @query + ' ACCOUNTEMPLOYEEID = ' + convert(varchar, @pEmployee)+ ' '

if(@pMonth is null)
 begin
	set @query = @query + ' AND TIMEENTRYDATE >= convert(datetime, '''+ convert(varchar,@pStartDate,103) + ''' ,103) '
	set @query = @query + ' AND  TIMEENTRYDATE <= convert(datetime, '''+ convert(varchar,@pEndDate,103) + ''' ,103) '
	--select null
 end
else
 begin --convert(varchar,datepart(month, TIMEENTRYDATE))
	set @query = @query + ' AND  convert(varchar,datepart(month, TIMEENTRYDATE)) = '''+@pMonth+''' ' 
 end
 
 if(@pYear is not null)
begin 
  set @query = @query + ' AND  convert(varchar,datepart(year,  TIMEENTRYDATE)) = '''+@pYear+''' '
end


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
set @query = @query + ' ORDER BY EMPLOYEECODE ASC, ACCOUNTEMPLOYEEID ASC, TIMEENTRYDATE ASC, ACCOUNTPROJECTID ASC, PROJECTCODE ASC, _IS_OVER_TIME ASC'




if @query is null begin
	SELECT getdate() AS _DATE, 3 AS _PROJCODE, 1 AS _DESC, 1 AS _HOURS, 1 AS _SUM_HOURS, 1 AS _SUM_MINUTES, 1 AS _IS_OVER_TIME, 0 AS _DUMMY_EXTRA_HOURS, 0 AS DifDays, '' as Holiday
end
else
begin
	print(@query)
	execute(@query)
end

END