
CREATE PROCEDURE [dbo].[sp_xpGetTimeoffPoliciesInfo]
	
AS
BEGIN

Declare @CONST_ACCOOUNTID int = 354 -- constant Account Id
	
Select AccountTimeOffPolicyId, AccountTimeOffPolicy
FROM [dbo].[AccountTimeOffPolicy]
where isDisabled=0
and accountId=@CONST_ACCOOUNTID

END;