
CREATE PROCEDURE [dbo].[sp_xpDetailedExpensesGrouped] 
	-- Add the parameters for the stored procedure here
	@startDate datetime, @endDate datetime, @employeeId int
AS
	DECLARE @COUNT INT
	DECLARE @KMRATE FLOAT
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


--Set the Km Rate from a table
select @KMRATE=value from xp_customvalues where description like 'Km' and year= cast(YEAR(@endDate) AS INT)

-- Verify if there are no km expenses (if so there is a need to perform a different query)
SELECT @COUNT=COUNT(*) FROM VXP_DETAILEXPENSE AS DE
		WHERE _DATE >= @startDate
		AND _DATE <= @endDate
		AND _EMPLOYEE = @employeeId
		AND UPPER(_TYPE) = 'KM'


IF (@COUNT >0)
	BEGIN  
		-- Normal query with mixed KM and Tolls
		SELECT A._TYPE, A._RATE, ROUND(SUM(A._QUANTITY),2) AS TOTAL_UNITS, ROUND(SUM(A._QUANTITY * A._RATE),2) AS TOTAL_VALUE
		  FROM (
			SELECT	_ID, 
					_DATE,
					_EMPLOYEE,
					_VEHICLE,
					_CUSTOMER,
					_DESCRIPTION,
					_TIME,
					ROUND((_QUANTITY + ((SELECT isnull(SUM(_QUANTITY * _AMOUNT),0)
								FROM VXP_DETAILEXPENSE
								WHERE _DATE >= @startDate
									AND _DATE <= @endDate
									AND _EMPLOYEE = @employeeId
									AND UPPER(_TYPE) = 'PORTAGENS') /  _RATE / (SELECT case when COUNT(*)<>0 then COUNT(*) else 1 end
																		FROM VXP_DETAILEXPENSE
																		WHERE _DATE >= @startDate
																			AND _DATE <= @endDate
																			AND _EMPLOYEE = @employeeId
																			AND UPPER(_TYPE) = 'KM'))) * (_RATE/@KMRATE),4) as _QUANTITY,
					_TYPE,
					@KMRATE as _RATE
			  FROM VXP_DETAILEXPENSE AS DE
				WHERE _DATE >= @startDate
					AND _DATE <= @endDate 
					AND _EMPLOYEE = @employeeId
					and UPPER(_TYPE) = 'KM'

			)A
		  WHERE A._DATE >= @startDate
				AND A._DATE <= @endDate 
				AND A._EMPLOYEE = @employeeId
		  GROUP BY A._TYPE, A._RATE
	END
ELSE
	BEGIN
		-- Normal query for Tolls only
		SELECT A._TYPE, A._RATE, ROUND(SUM(A._QUANTITY),2) AS TOTAL_UNITS, ROUND(SUM(A._QUANTITY * A._RATE),2) AS TOTAL_VALUE
		  FROM (
			SELECT	_ID, 
					_DATE,
					_EMPLOYEE,
					_VEHICLE,
					_CUSTOMER,
					_DESCRIPTION,
					_TIME,
					ROUND(_AMOUNT / @KMRATE, 2) as _QUANTITY,
					_TYPE,
					@KMRATE as _RATE
			  FROM VXP_DETAILEXPENSE AS DE
				WHERE _DATE >= @startDate
					AND _DATE <= @endDate 
					AND _EMPLOYEE = @employeeId
					and UPPER(_TYPE) = 'PORTAGENS'

			)A
		  WHERE A._DATE >= @startDate
				AND A._DATE <= @endDate 
				AND A._EMPLOYEE = @employeeId
		  GROUP BY A._TYPE, A._RATE
	END
END