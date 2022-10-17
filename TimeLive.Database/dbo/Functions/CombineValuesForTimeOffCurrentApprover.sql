
   CREATE FUNCTION [dbo].[CombineValuesForTimeOffCurrentApprover]
    (
    @AccountEmployeeTimeOffRequestId uniqueidentifier --AccountEmployeeTimeOffRequestId from TableA which is used to fetch corresponding records
    )
    RETURNS NVARCHAR(4000)
    AS
    BEGIN
    DECLARE @SomeColumnList NVARCHAR(4000);
	Declare @ApproverPathSeq int;
	
    SELECT @SomeColumnList = COALESCE(@SomeColumnList + ' / ', '') + CAST(C.ApproverEmployeeName AS nvarchar(1000)) + ' (' + c.ApproverType + ')',@approverpathseq = C.approvalpathsequence
    FROM vueAccountEmployeeTimeOffCurrentApprover C
    WHERE  C.AccountEmployeeTimeOffRequestId = @AccountEmployeeTimeOffRequestId
    
    RETURN 
    (
    SELECT @SomeColumnList
    )
    END