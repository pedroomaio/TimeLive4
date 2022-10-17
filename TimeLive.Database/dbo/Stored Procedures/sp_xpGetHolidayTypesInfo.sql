
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetHolidayTypesInfo]
	
AS
BEGIN

Declare @CONST_ACCOOUNTID int = 354 -- constant Account Id
	
Select AccountHolidayTypeId, AccountHolidayType
FROM [dbo].[AccountHolidayType]
where isDisabled=0
and accountId=@CONST_ACCOOUNTID

END;