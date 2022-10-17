CREATE FUNCTION [dbo].[getLastBusinessDay]
(
	-- Add the parameters for the function here
	@anydateofMonth DATETIME
)
RETURNS DATETIME
AS
BEGIN
	-- Declare the return variable here
	DECLARE @lastBusinessDay DATETIME
 
	-- Add the T-SQL statements to compute the return value here
 
		DECLARE @givendate DATETIME
		SET @givendate = @anydateofMonth
 
		DECLARE @dates TABLE
		(
		 DATE DATETIME not null
		)
 
		DECLARE @govtHolidays TABLE
		(
			Holidays DATETIME not null,
			Description VARCHAR(100)
		)
 
		--Insert the govt holidays as per your need
		INSERT INTO @govtHolidays(holidays, Description)
			SELECT STR(YEAR(@givendate)) + '-' + 'Jan-01', 'New Year’s Day'UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'April-25', 'April-25' UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'May-01', 'Dia Trabalhador'UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Jun-03', 'Corpo de Deus'UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Jun-10', 'Dia de Portuga'UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Aug-15', 'August-15' UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Oct-05', 'Republica'UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Nov-01', 'Nov-01' UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Dec-01', 'Dec-01' UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Dec-08', 'Dec-08'UNION All
			SELECT STR(YEAR(@givendate)) + '-' + 'Dec-25', 'Christmas' 
 
		DECLARE @MONTH INT
		SET @MONTH = MONTH(@givendate)
 
		SET @givendate = STR(YEAR(@givendate)) + '-' + STR(MONTH(@givendate)) + '-01' 
 
		WHILE DATEPART(MM,@givendate) = @MONTH
		 BEGIN
			IF( @@DATEFIRST = 7 and DATEPART(dw, @givendate) between 2 and 6)
			BEGIN
				INSERT INTO @dates VALUES (@givendate)
			END
			ELSE
		IF(@@DATEFIRST = 1 and DATEPART(dw, @givendate) between 1 and 5)
			BEGIN
				INSERT INTO @dates VALUES (@givendate);
			END
			SET @givendate = DATEADD(dd, 1, @givendate);
		 END 
 
		SELECT @lastBusinessDay = MAX(DATE) FROM (SELECT DATE FROM @dates WHERE DATE not in (SELECT Holidays FROM @govtHolidays)) workingDays
 
	-- Return the result of the function
	RETURN @lastBusinessDay
 
END