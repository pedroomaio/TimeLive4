
CREATE PROCEDURE [dbo].[sp_xpNumberWorkDays] 
	-- Add the parameters for the stored procedure here
	@startDate datetime, @endDate datetime
AS
	DECLARE @CountInicial INT,
			@CountFeriados INT

BEGIN
	
	SELECT @CountInicial = (DATEDIFF(dd, @StartDate, @EndDate) + 1) -
			(DATEDIFF(wk, @StartDate, @EndDate) * 2)
			-(CASE WHEN DATENAME(dw, @startDate) = 'Sunday' THEN 1 ELSE 0 END)
			-(CASE WHEN DATENAME(dw, @endDate) = 'Saturday' THEN 1 ELSE 0 END)

	SELECT  @CountFeriados = count(*)
		FROM dbo.xp_holidays
		WHERE (DATENAME(dw, date) != 'Sunday'
			and DATENAME(dw, date) != 'Saturday')
			and date between  (@startDate) and (@endDate)
	print(@CountInicial - @CountFeriados)
	return @CountInicial - @CountFeriados

END