
CREATE FUNCTION [dbo].[fxp_GetLastDayOfMonth] ( @pInputDate    Varchar(8) )
RETURNS DATETIME
BEGIN

    DECLARE @vOutputDate        DATETIME

	SET @vOutputDate = cast(@pInputDate as DATETIME)
    SET @vOutputDate = CAST(YEAR(@pInputDate) AS VARCHAR(4)) + '/' + 
                       CAST(MONTH(@pInputDate) AS VARCHAR(2)) + '/01'
    SET @vOutputDate = DATEADD(DD, -1, DATEADD(M, 1, @vOutputDate))

    RETURN @vOutputDate

END