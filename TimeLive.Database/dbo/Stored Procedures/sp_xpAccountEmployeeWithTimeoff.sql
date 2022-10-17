-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpAccountEmployeeWithTimeoff]
	@ipPrefix nvarchar(50),
	@ipFirstName nvarchar(150),
	@ipLastname nvarchar(150),
	@ipEmailAddress nvarchar(100),
	@ipAccountDepartmentId int,
	@ipAccountLocationId int,
	@ipUsername nvarchar(100),
	@ipHiredDate datetime,
	@ipEmployeeManagerId int, -- new field
	@ipAccountHolidayTypeId uniqueidentifier, -- new field
	@ipAccountTimeOffPolicyId uniqueidentifier, -- new field
	@ipEmployeeTimeoffApprovalTypeId int, -- new field
	@ipNumberOfTimeoffVacationDays int, -- new field
	@opNewEmployeeId int output,
	@opErrorCode int output,
	@opErrorMesssage nvarchar(255) output
AS
	SET NOCOUNT ON;

	-- Declare constants
	Declare @CONST_ACCOUNTID int 					= 354, -- constant Account Id
			@CONST_DEFAULT_ROLE_STR varchar(4) 		= 'USER',
			@CONST_EMPLOYED_STR varchar(10) 		= 'EMPLOYED',
			@CONST_TIMEZONE_STR varchar(10) 		= 'CASABLANCA',	
			@CONST_CREATEDBY_EMPLOYEEID int 		= 478, --RMDM
			@CONST_TEMPLATE_EMPLOYEEID int 			= 479, -- RPLP
			@CONST_WORKDAY_TYPEID_STR varchar(30) 	= 'FULL-TIME WITH WEEKENDS',
			@CONST_EMPTYPE_TYPEID_STR varchar(30) 	= 'FULL-TIME SALARIED',
			@CONST_TEMPLATE_PASS varchar(50) 		= 'EYurn9sETnb4w/4ibnCn6j6LBNU=',
			@CONST_TEMPLATE_LANGUAGE varchar(5) 	= 'en-US',
			@CONST_SYSTEM_STR varchar(15)			= 'System',
           	@CONST_NEWROW_STR varchar(15)			= 'New Row Added',
           	@CONST_EMPLOYEE_STR varchar(10)			= 'Employee'
			
	
	-- Define Variables (account employee insert)
	Declare @AccountProjectId int,
			@Password nvarchar(100), 
			@MiddleName nvarchar(40), 
			@AccountId int, 
			@AccountRoleId int,  
			@CountryId smallint, 
			@BillingTypeId int, 
			@StatusId int, 
			@IsDeleted bit, 
			@IsDisabled bit,
			@TimeZoneId tinyint, 
			@CreatedOn datetime, 
			@CreatedByEmployeeId int, 
			@ModifiedOn datetime, 
			@ModifiedByEmployeeId int, 
			@AccountBillingRateId int, 
			@JobTitle nvarchar(50),
			@EmployeePayTypeId uniqueidentifier, 
			@AccountWorkingDayTypeId uniqueidentifier, 
			@LastScheduledEmailSentTime datetime,
			@EmployeeCode nvarchar(100),
			@TimeOffApprovalTypeId int,
			@InitialPolicy int
			
	-- Define Variables (account billing rate insert)			
	Declare @SystemBillingRateTypeId smallint, 
			@BillingRate money, 
			@StartDate datetime, 
			@EndDate datetime, 
			@AccountWorkTypeId int, 
			@EmployeeRate money, 
			@BillingRateCurrencyId int, 
			@EmployeeRateCurrencyId int, 
			@AccountEmployeeId int


	-------------------------------------------------------------------------------------------- 
	-- Select data from template user and initialize some variables for AccountEnmployee table
	-------------------------------------------------------------------------------------------- 
	Select 
		@MiddleName 				= '', 
		@AccountId 					= @CONST_ACCOUNTID,
		@AccountRoleId 				= (	select ar.AccountRoleId 
										from AccountRole ar 
										where ar.AccountId=@CONST_ACCOUNTID 
											and UPPER("Role") = UPPER(@CONST_DEFAULT_ROLE_STR) 
											and ar.IsDisabled = 0 
											and ar.IsDeleted = 0),
		@CountryId 					= CountryId,
		@BillingTypeId 				= BillingTypeId, 
		@StatusId 					= (	select AccountStatusId 
										from AccountStatus acs 
										where acs.AccountId=@CONST_ACCOUNTID 
											and UPPER(Status) = UPPER(@CONST_EMPLOYED_STR) 
											and acs.IsDisabled = 0), --> EMPLOYED
    	@IsDeleted 					= 0,
    	@IsDisabled 				= 0,
		@TimeZoneId 				= (	select SystemTimezoneId 
										from SystemTimezone st 
										where UPPER(Timezone) = UPPER(@CONST_TIMEZONE_STR)), 
		@CreatedByEmployeeId		= @CONST_CREATEDBY_EMPLOYEEID, 
		@ModifiedByEmployeeId 		= @CONST_CREATEDBY_EMPLOYEEID,
		@AccountBillingRateId 		= AccountBillingRateId, 
		@JobTitle 					= NULL, 
		@AccountWorkingDayTypeId 	= (	select AccountWorkingDayTypeId 
										from AccountWorkingDayType
										where UPPER(AccountWorkingDayType) = UPPER(@CONST_WORKDAY_TYPEID_STR)),
		@LastScheduledEmailSentTime = LastScheduledEmailSentTime,
		@EmployeeCode 				= UPPER(@ipUsername),
		@EmployeePayTypeId				= (	select AccountEmployeeTypeId 
										from AccountEmployeeType  aet
										where aet.accountId=@CONST_ACCOUNTID 
											and isDisabled=0 
											and UPPER(aet.AccountEmployeeType) = UPPER(@CONST_EMPTYPE_TYPEID_STR)),
		@InitialPolicy				= 1,
		@CreatedOn 					= GetDate(), 
		@ModifiedOn 				= GetDate() 
	from [dbo].[AccountEmployee] 
	where AccountEmployeeId = @CONST_TEMPLATE_EMPLOYEEID -- RPLP
	
	--------------------------------------------------------------------------------------------
	-- Prepare data to second Insert Table AccountBillingRate
	--------------------------------------------------------------------------------------------
	Select  @SystemBillingRateTypeId 	= SystemBillingRateTypeId, 
			@BillingRate 				= BillingRate, 
			@AccountWorkTypeId 			= AccountWorkTypeId, 
			@EmployeeRate 				= EmployeeRate, 
			@BillingRateCurrencyId 		= BillingRateCurrencyId, 
			@EmployeeRateCurrencyId 	= EmployeeRateCurrencyId,
			@StartDate 					= GetDate(), 
			@EndDate 					= DateAdd(year,1,@StartDate)
	from [dbo].[AccountBillingRate] 
	where AccountEmployeeId = @CONST_TEMPLATE_EMPLOYEEID -- RPLP


	BEGIN TRY 
		BEGIN TRANSACTION
	
		--First INSERT
		INSERT INTO [dbo].[AccountEmployee](
			[Password],  							--1
			[UserInterfaceLanguage],				--2
			[Prefix], 								--3
			[FirstName], 							--4
			[LastName], 							--5
			[MiddleName], 							--6
			[EMailAddress], 						--7
			[AccountId], 							--8
			[AccountDepartmentId], 					--9
			[AccountRoleId], 						--10
			[AccountLocationId],	 				--11
			[CountryId], 							--12
			[BillingTypeId], 						--13
			[StatusId], 							--14	
			[IsDeleted], 							--15
			[IsDisabled],							--16
			[TimeZoneId], 							--17
			[CreatedOn], 							--18
			[CreatedByEmployeeId],	 				--19
			[ModifiedOn], 							--20
			[ModifiedByEmployeeId],					--21
			[AccountBillingRateId],				 	--22
			[Username],			 					--23
			[EmployeeCode], 						--24
			[HiredDate],							--25
			[AccountWorkingDayTypeId],			 	--26
			[LastScheduledEmailSentTime],			--27
			-- new fields
			[EmployeeManagerId],					--28
			[AccountHolidayTypeId],					--29
			[AccountTimeOffPolicyId],				--30
			[TimeOffApprovalTypeId],				--31
			[EmployeePayTypeId],					--32
			[LastTimeOffCalculationScheduledTime],	--33	
			[InitialPolicy]							--34
			)
		VALUES(
			@CONST_TEMPLATE_PASS,			--1
			@CONST_TEMPLATE_LANGUAGE,		--2
			@ipPrefix,						--3
			@ipFirstName,					--4
			@ipLastName,					--5
			@MiddleName,					--6
			@ipEmailAddress,				--7
			@CONST_ACCOUNTID,				--8
			@ipAccountDepartmentId,			--9
		    @AccountRoleId,					--10
			@ipAccountLocationId,			--11
		    @CountryId,						--12
		    @BillingTypeId,					--13
		    @StatusId,						--14
		    @IsDeleted,						--15
		    @IsDisabled,					--16
		    @TimeZoneId,					--17
		    @CreatedOn,						--18
		    @CreatedByEmployeeId,			--19
		    @ModifiedOn,					--20
		    @ModifiedByEmployeeId,			--21
		    @AccountBillingRateId,			--22
		    @ipEmailAddress,				--23
		    @EmployeeCode,					--24
			@ipHiredDate,					--25
		    @AccountWorkingDayTypeId,		--26
		    @LastScheduledEmailSentTime,	--27
		    -- new fields
		    @ipEmployeeManagerId,			--28
			@ipAccountHolidayTypeId,		--29
			@ipAccountTimeOffPolicyId,		--30
			@ipEmployeeTimeoffApprovalTypeId,--31
			@EmployeePayTypeId,				--32
			GetDate(),						--33
			@InitialPolicy					--34
		    )
		 
		--Select key to insert next
		Select @AccountEmployeeId = SCOPE_IDENTITY()
		
		--Second INSERT for billng rate
		INSERT INTO [dbo].[AccountBillingRate] (
			[AccountId], 				--1
			[SystemBillingRateTypeId], 	--2
			[BillingRate], 				--3
			[StartDate], 				--4
			[EndDate], 					--5
			[AccountEmployeeId], 		--6
			[AccountWorkTypeId], 		--7
			[EmployeeRate], 			--8
			[BillingRateCurrencyId], 	--9
			[EmployeeRateCurrencyId])	--10
		VALUES
			(@CONST_ACCOUNTID,			--1
			@SystemBillingRateTypeId,	--2
			@BillingRate,				--3
			@StartDate,					--4
			@EndDate,					--5
			@AccountEmployeeId,			--6
			@AccountWorkTypeId,			--7
			@EmployeeRate,				--8
			@BillingRateCurrencyId,		--9
			@EmployeeRateCurrencyId)	--10
		
		--Select key to insert next
		Select @AccountBillingRateId = SCOPE_IDENTITY()
		
		-----------------------------------------------------------
		--Update Account Employee table with other extra fields.
		-----------------------------------------------------------
		Update [dbo].[AccountEmployee] 
			set AccountBillingRateId = @AccountBillingRateId
			where AccountEmployeeId = @AccountEmployeeId
		
		-------------------------------------------
		-- Insert Timeoff types
		-------------------------------------------
		IF NOT (@ipAccountTimeOffPolicyId IS NULL)
		BEGIN
			Declare @AccountTimeOffTypeId UNIQUEIDENTIFIER
				 
			DECLARE cTimeoffTypesCursor CURSOR FOR   
				select ad.AccountTimeOffTypeId from AccountTimeOffPolicyDetail ad, AccountTimeOffType atot
				where ad.AccountTimeOffTypeId = atot.AccountTimeOffTypeId 
					and ad.AccountTimeOffPolicyId = @ipAccountTimeOffPolicyId--  '99D08A8F-AD40-490D-A0B5-2CFFC8D2769B'
					and ad.accountId = @CONST_ACCOUNTID
					and atot.isDisabled=0;  
		  
			OPEN cTimeoffTypesCursor 
		  
			FETCH NEXT FROM cTimeoffTypesCursor   
			INTO @AccountTimeOffTypeId 
		  
			WHILE @@FETCH_STATUS = 0  
			BEGIN  
			    INSERT INTO [dbo].[AccountEmployeeTimeOff]
		           ([AccountEmployeeId],
		           [AccountId],
		           [AccountTimeOffTypeId],
		           [Earned],
		           [Consume],
		           [Available],
		           [LastEarnedDate],
		           [CreatedByEmployeeId],
		           [CreatedOn],
		           [ModifiedByEmployeeId],
		           [ModifiedOn],
		           [CarryForward],
		           [AccountTimeOffPolicyId],
		           [LastResetDate],
		           [IsDisabled],
		           [PolicyExecutionType],
		           [PolicyEarnResetAutidAction],
		           [AuditSource],
		           [LastCarryForwardExpiryDate])
		     VALUES
		           (@AccountEmployeeId, --<AccountEmployeeId, int,>
		           @CONST_ACCOUNTID, --<AccountId, int,>
		           @AccountTimeOffTypeId,--AccountTimeOffTypeId: Tipo de TimeOff, neste caso será Vacation
		           0, --<Earned, float,>
		           0, --<Consume, float,>
		           0, --<Available, float,>
		           NULL, --<LastEarnedDate, datetime,>
		           @CONST_CREATEDBY_EMPLOYEEID, --<CreatedByEmployeeId, int,>
		           GetDate(), --<CreatedOn, datetime,>
		           @CONST_CREATEDBY_EMPLOYEEID, --<ModifiedByEmployeeId, int,>
		           GetDate(), --<ModifiedOn, datetime,>
		           0, --<CarryForward, float,>
		           @ipAccountTimeOffPolicyId, --<AccountTimeOffPolicyId, uniqueidentifier,>
		           NULL, --<LastResetDate, datetime,>
		           0, --<IsDisabled, bit,>
		           @CONST_SYSTEM_STR, --<PolicyExecutionType, nvarchar(250),>
		           @CONST_NEWROW_STR, --<PolicyEarnResetAutidAction, nvarchar(250),>
		           @CONST_EMPLOYEE_STR, --<AuditSource, nvarchar(250),>
		           NULL --<LastCarryForwardExpiryDate, datetime,>
		       	)
		       	-- next row
		       	FETCH NEXT FROM cTimeoffTypesCursor   
				INTO @AccountTimeOffTypeId 
			END  -- while 
			--cleanup
			CLOSE cTimeoffTypesCursor;  
			DEALLOCATE cTimeoffTypesCursor; 
			
			-------------
			-- set nr of vacation days earned and available
			-------------	
			UPDATE [dbo].[AccountEmployeeTimeOff]
			SET [Earned] = @ipNumberOfTimeoffVacationDays,
				[Available] = @ipNumberOfTimeoffVacationDays,
				[PolicyEarnResetAutidAction] = 'Reset First Time-Earned Each Year',
				[LastEarnedDate] = (Select CONCAT(year(getdate()),'0101')),
				[LastResetDate] = (Select CONCAT(year(getdate()),'0101'))
			WHERE AccountEmployeeId = @AccountEmployeeId
				and AccountId= @CONST_ACCOUNTID
		        and AccountTimeOffTypeId = @AccountTimeOffTypeId
	      	
		END; -- IF
		
		-- Insert into HR Absence
	/*	INSERT INTO [dbo].[AccountProjectEmployee]
			([AccountId], 
			[AccountProjectId], 
			[AccountEmployeeId], 
			[TaskCompletedPercentage], 
			[TaskCompleted], 
			[AccountRoleId], 
			[AccountBillingRateId], 
			[AccountProjectEmployeeTemplateId])
		VALUES
			(@CONST_ACCOUNTID
			,378
			,@AccountEmployeeId
			,NULL
			,NULL
			,0
			,NULL
			,NULL)
		*/

		COMMIT TRANSACTION
	
		
	    SELECT @opNewEmployeeId=@AccountEmployeeId, @opErrorCode=0 , @opErrorMesssage='User successfully created';
	
   	END TRY  
	BEGIN CATCH  
		ROLLBACK
		IF (SELECT CURSOR_STATUS('global','cTimeoffTypesCursor')) >=0 
    	BEGIN
        	CLOSE cTimeoffTypesCursor;  
			DEALLOCATE cTimeoffTypesCursor;
		END
	   	SELECT @opNewEmployeeId=NULL, @opErrorCode=ERROR_NUMBER(), @opErrorMesssage=ERROR_MESSAGE() ;
	END CATCH