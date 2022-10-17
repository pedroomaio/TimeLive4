
   CREATE FUNCTION [dbo].[CombineValuesForTimeEntryCurrentApprover]
    (
    @AccountEmployeeTimeEntryId INT --AccountEmployeeTimeEntryId from TableA which is used to fetch corresponding records
    )
    RETURNS NVARCHAR(4000)
    AS
    BEGIN
    DECLARE @SomeColumnList NVARCHAR(4000);
	Declare @ApproverPathSeq int;
	
    SELECT @SomeColumnList = COALESCE(@SomeColumnList + ' / ', '') + CAST(C.ApproverEmployeeName AS nvarchar(1000)) + ' (' + c.ApproverType + ')',@approverpathseq = C.approvalpathsequence
    FROM vueAccountEmployeeTimeEntryCurrentApprover C
    WHERE C.AccountEmployeeTimeEntryId = @AccountEmployeeTimeEntryId
    
    RETURN 
    (
    SELECT @SomeColumnList
    )
    END