
    CREATE FUNCTION [dbo].[CombineValuesForTimeEntryApprover]
    (
    @AccountProjectID INT --AccountProjectID from TableA which is used to fetch corresponding records
    )
    RETURNS NVARCHAR(4000)
    AS
    BEGIN
    DECLARE @SomeColumnList NVARCHAR(4000);
	Declare @ApproverPathSeq int;
	
    SELECT @SomeColumnList = COALESCE(@SomeColumnList + case when @approverpathseq = C.approvalpathsequence then ' / ' else ' --> ' end, '') 
    + CAST(C.ApproverEmployeeName AS nvarchar(1000)) + ' (' + c.ApproverType + ')',@approverpathseq = C.approvalpathsequence
    FROM vueAccountEmployeeTimeEntryWithApprover C
    WHERE C.AccountProjectId = @AccountProjectID
    order by approvalpathsequence;

    RETURN 
    (
    SELECT @SomeColumnList
    )
    END