
CREATE FUNCTION dbo.timeToDecimal
(
@timeToConvert varchar(25)
)
RETURNS decimal(18, 2)
AS
BEGIN
DECLARE @Result decimal(18, 2)
DECLARE @t varchar(5)
SET @t = cast(datepart(hh,@timeToConvert) as varchar(2)) + ':' + cast(datepart(n,@timeToConvert) as varchar(2))
SET @Result = CAST(DATEDIFF(N, '00:00', @t) AS decimal(18, 2))/60
RETURN @Result
END