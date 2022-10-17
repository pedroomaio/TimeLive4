
CREATE FUNCTION [dbo].[GET_TZVALUE]
    (@EmployeeTimeZone as float)
RETURNS float
AS
BEGIN
-- DECLARE VARIABLES
Declare @TimezoneValue as float

Set @TimezoneValue = datediff(mi,getutcdate(),getdate()) + (@EmployeeTimeZone*60) - (datediff(mi,getutcdate(),getdate())*2)
Return @TimezoneValue
END