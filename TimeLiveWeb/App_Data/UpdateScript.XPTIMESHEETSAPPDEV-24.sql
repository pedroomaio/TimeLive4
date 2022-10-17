/****** Object:  StoredProcedure [dbo].[sp_UpdateTimeEntry]    Script Date: 25/11/2016 16:12:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_UpdateTimeEntry]
		   (@AccountEmployeeId int,
           @TimeEntryDate datetime,
           @StartTime datetime,
           @EndTime datetime,
           @TotalTime datetime,
           @AccountProjectId int,
           @AccountProjectTaskId bigint,
           @Description nvarchar(1000),
           @Approved bit,
		   @ModifiedOn datetime,
           @Rejected bit,
           @BillingRate money,
           @Submitted bit,
           @AccountWorkTypeId int,
           @EmployeeRate money,
           @AccountCostCenterId int,
           @BillingRateCurrencyId int,
           @EmployeeRateCurrencyId int,
           @BillingRateExchangeRate float,
           @EmployeeRateExchangeRate float,
           @AccountBaseCurrencyId int,
           @AccountEmployeeTimeEntryPeriodId uniqueidentifier,
           @AccountEmployeeTimeEntryApprovalProjectId uniqueidentifier,
           @ModifiedByEmployeeId int,
           @IsTimeOff bit,
           @AccountTimeOffTypeId uniqueidentifier,
		   @AccountEmployeeTimeEntryId int,
		   @Percentage float,
		   @Hours decimal(18,2),
		   @IsFixedBid bit,
		   @AccountPartyId int,
		   @CustomField1 nvarchar(2000),
		   @CustomField2 nvarchar(2000),
		   @CustomField3 nvarchar(2000),
		   @CustomField4 nvarchar(2000),
		   @CustomField5 nvarchar(2000),
		   @CustomField6 nvarchar(2000),
		   @CustomField7 nvarchar(2000),
		   @CustomField8 nvarchar(2000),
		   @CustomField9 nvarchar(2000),
		   @CustomField10 nvarchar(2000),
		   @CustomField11 nvarchar(2000),
		   @CustomField12 nvarchar(2000),
		   @CustomField13 nvarchar(2000),
		   @CustomField14 nvarchar(2000),
		   @CustomField15 nvarchar(2000))
AS 
BEGIN
UPDATE AccountEmployeeTimeEntry
   SET [TimeEntryDate] = @TimeEntryDate
      ,[StartTime] = @StartTime
      ,[EndTime] = @EndTime
      ,[TotalTime] = @TotalTime
      ,[AccountProjectId] = @AccountProjectId
      ,[AccountProjectTaskId] = @AccountProjectTaskId
      ,[Description] = @Description
      ,[Approved] = @Approved
	  ,[ModifiedOn] =@ModifiedOn
      ,[Rejected] = @Rejected
      ,[BillingRate] = @BillingRate
      ,[Submitted] = @Submitted
      ,[AccountWorkTypeId] = @AccountWorkTypeId
      ,[EmployeeRate] = @EmployeeRate
      ,[AccountCostCenterId] = @AccountCostCenterId
      ,[BillingRateCurrencyId] = @BillingRateCurrencyId
      ,[EmployeeRateCurrencyId] = @EmployeeRateCurrencyId
      ,[BillingRateExchangeRate] = @BillingRateExchangeRate
      ,[EmployeeRateExchangeRate] = @EmployeeRateExchangeRate
      ,[AccountBaseCurrencyId] = @AccountBaseCurrencyId
      ,[AccountEmployeeTimeEntryPeriodId] = @AccountEmployeeTimeEntryPeriodId
      ,[AccountEmployeeTimeEntryApprovalProjectId] = @AccountEmployeeTimeEntryApprovalProjectId
      ,[ModifiedByEmployeeId] = @ModifiedByEmployeeId
      ,[IsTimeOff] = @IsTimeOff
      ,[AccountTimeOffTypeId] = @AccountTimeOffTypeId
      ,[Percentage] = @Percentage
      ,[Hours] = @Hours
      ,[IsFixedBid] = @IsFixedBid
      ,[AccountPartyId] = @AccountPartyId
      ,[CustomField1] = @CustomField1
      ,[CustomField2] = @CustomField2
      ,[CustomField3] = @CustomField3
      ,[CustomField4] = @CustomField4
      ,[CustomField5] = @CustomField5
      ,[CustomField6] = @CustomField6
      ,[CustomField7] = @CustomField7
      ,[CustomField8] = @CustomField8
      ,[CustomField9] = @CustomField9
      ,[CustomField10] = @CustomField10
      ,[CustomField11] = @CustomField11
      ,[CustomField12] = @CustomField12
      ,[CustomField13] = @CustomField13
      ,[CustomField14] = @CustomField14
      ,[CustomField15] = @CustomField15
 WHERE [AccountEmployeeTimeEntryId] = @AccountEmployeeTimeEntryId
END


GO


