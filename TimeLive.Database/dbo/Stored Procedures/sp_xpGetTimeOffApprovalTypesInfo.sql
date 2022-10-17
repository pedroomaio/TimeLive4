
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetTimeOffApprovalTypesInfo]
	
AS
BEGIN

Declare @CONST_ACCOOUNTID int = 354 -- constant Account Id
	
Select AccountApprovalTypeId, ApprovalTypeName
FROM [dbo].[AccountApprovalType]
where IsTimeOffApprovalTypes=1
and accountId=@CONST_ACCOOUNTID

END;