
CREATE PROCEDURE [dbo].[sp_xpDetailedExpensesbyMonth] 
	-- Add the parameters for the stored procedure here
	@month int, @year int, @employeeId int
AS
	DECLARE @COUNT INT
	DECLARE @KMRATE FLOAT
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Set the Km Rate from a table
select @KMRATE=value from xp_customvalues where description like 'Km' and year= @year
	
	-- Verify if there are no km expenses (if so there is a need to perform a different query)
	SELECT @COUNT=COUNT(*) FROM VXP_DETAILEXPENSE AS DE
		WHERE datename(year,_DATE) = @year
		AND convert(varchar,datepart(month,_DATE)) = @month		
		AND _EMPLOYEE = @employeeId
		AND UPPER(_TYPE) = 'KM'
  
	IF (@COUNT >0)
		-- Normal query with mixed KM and Tolls
		BEGIN
		   SELECT	_ID, 
					_DATE,
					_EMPLOYEE,
					_VEHICLE,
					_CUSTOMER,
					_DESCRIPTION,
					_TIME,
					'Km' as _TYPE,
					ROUND((_QUANTITY + ((SELECT isnull(SUM(_QUANTITY * _AMOUNT),0)
								FROM VXP_DETAILEXPENSE
								WHERE datename(year,_DATE) = @year
									AND convert(varchar,datepart(month,_DATE)) = @month
									AND _EMPLOYEE = @employeeId
									AND UPPER(_TYPE) = 'PORTAGENS') /  _RATE /  (SELECT case when COUNT(*)<>0 then COUNT(*) else 1 end
																		FROM VXP_DETAILEXPENSE
																		WHERE datename(year,_DATE) = @year
																			AND convert(varchar,datepart(month,_DATE)) = @month 
																			AND _EMPLOYEE = @employeeId
																			AND UPPER(_TYPE) = 'KM'))) * (_RATE/@KMRATE),2) as _QUANTITY
			  FROM VXP_DETAILEXPENSE AS DE
				WHERE datename(year,_DATE) = @year
					AND convert(varchar,datepart(month,_DATE)) = @month	
					AND _EMPLOYEE = @employeeId
					and UPPER(_TYPE) = 'KM'
				ORDER BY _EMPLOYEE,_DATE ASC
		END
	ELSE 
		BEGIN
			-- Normal query for Tolls only
			SELECT	_ID, 
					_DATE,
					_EMPLOYEE,
					_VEHICLE,
					_CUSTOMER,
					_DESCRIPTION,
					_TIME,
					'Km' as _TYPE,
					ROUND(_AMOUNT / @KMRATE, 2) as _QUANTITY
			  FROM VXP_DETAILEXPENSE AS DE
				WHERE datename(year,_DATE) = @year
					AND convert(varchar,datepart(month,_DATE)) = @month	
					AND _EMPLOYEE = @employeeId
					and UPPER(_TYPE) = 'PORTAGENS'
				ORDER BY _DATE ASC
		END
END