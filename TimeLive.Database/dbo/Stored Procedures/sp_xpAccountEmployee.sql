-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpAccountEmployee]
	@Prefix nvarchar(50),
	@FirstName nvarchar(150),
	@Lastname nvarchar(150),
	@EmailAddress nvarchar(100),
	@AccountDepartmentId int,
	@AccountLocationId int,
	@Username nvarchar(100),
	@HiredDate datetime,
	@AccountProjectId int
	

AS

SET NOCOUNT ON;

--Prepare data to First Insert Table AccountEmployee
--Define Variables
Declare @Password nvarchar(100), @MiddleName nvarchar(40), @AccountId int, @AccountRoleId int,  @CountryId smallint, @BillingTypeId int, @StatusId int, @IsDeleted bit, @IsDisabled bit,
@TimeZoneId tinyint, @CreatedOn datetime, @CreatedByEmployeeId int, @ModifiedOn datetime, @ModifiedByEmployeeId int, @AccountBillingRateIdd int, @JobTitle nvarchar(200),
@EmployeePayTypeId uniqueidentifier, @AccountWorkingDayTypeId uniqueidentifier, @LastScheduledEmailSentTime datetime, @EmployeeCode nvarchar(100)

--Select data
	Select @Password = Password, @MiddleName = MiddleName, @AccountId = AccountId, @AccountRoleId = AccountRoleId,
	@CountryId = CountryId, @BillingTypeId = BillingTypeId, @StatusId = StatusId, @IsDeleted = IsDeleted, @IsDisabled = IsDisabled,
	@TimeZoneId = TimeZoneId, @CreatedByEmployeeId = CreatedByEmployeeId, @ModifiedByEmployeeId = ModifiedByEmployeeId,
	@AccountBillingRateIdd = AccountBillingRateId, @JobTitle = JobTitle, @EmployeePayTypeId = EmployeePayTypeId, @AccountWorkingDayTypeId = AccountWorkingDayTypeId,
	@LastScheduledEmailSentTime = LastScheduledEmailSentTime, @EmployeeCode = UPPER(@Username), @CreatedOn = GetDate(), @ModifiedOn = GetDate() 
		from [dbo].[AccountEmployee] 
		where AccountEmployeeId = 479

--Prepare data to Second Insert Table AccountBillingRate
--Define Variables
Declare @SystemBillingRateTypeId smallint, @BillingRate money, @StartDate datetime, @EndDate datetime, @AccountWorkTypeId int, @EmployeeRate money, 
@BillingRateCurrencyId int, @EmployeeRateCurrencyId int, @AccountEmployeeId int

--Select data
	Select  @SystemBillingRateTypeId = SystemBillingRateTypeId, @BillingRate = BillingRate, @AccountWorkTypeId = AccountWorkTypeId, @EmployeeRate = EmployeeRate, 
	@BillingRateCurrencyId = BillingRateCurrencyId, @EmployeeRateCurrencyId = EmployeeRateCurrencyId, @StartDate = GetDate(), @EndDate = DateAdd(year,1,@StartDate)
	from [dbo].[AccountBillingRate] where AccountEmployeeId = 479


--Prepare data to Third Insert Table AccountProjectEmployee
--Define Variables
Declare @TaskCompletedPercentage smallint, @TaskCompleted bit, @AccountProjectEmployeeTemplateId bigint

--Select data
	Select @TaskCompletedPercentage= TaskCompletedPercentage, @TaskCompleted = TaskCompleted, @AccountProjectEmployeeTemplateId = AccountProjectEmployeeTemplateId
	from [dbo].[AccountProjectEmployee] where AccountEmployeeId = 479
	Select @AccountProjectId = 422


BEGIN

--First INSERT
INSERT INTO [dbo].[AccountEmployee]
([Password], [UserInterfaceLanguage], [Prefix], 
[FirstName], [LastName], [MiddleName], 
[EMailAddress], [AccountId], [AccountDepartmentId], 
[AccountRoleId], [AccountLocationId], 
[CountryId], [BillingTypeId], [StatusId], [IsDeleted], [IsDisabled],
[TimeZoneId], [CreatedOn], [CreatedByEmployeeId], [ModifiedOn], [ModifiedByEmployeeId],
[AccountBillingRateId], [Username], [EmployeeCode], [EmployeePayTypeId],[HiredDate],
[AccountWorkingDayTypeId], [LastScheduledEmailSentTime])

VALUES
	('EYurn9sETnb4w/4ibnCn6j6LBNU=',
	'en-US',
	@Prefix,
	@FirstName,
	@Lastname,
	'',
	@EmailAddress,
	@AccountId,
	350,
    1166,
	@AccountLocationId,
    @CountryId,
    @BillingTypeId,
    @StatusId,
    @IsDeleted,
    @IsDisabled,
    @TimeZoneId,
    @CreatedOn,
    @CreatedByEmployeeId,
    @ModifiedOn,
    @ModifiedByEmployeeId,
    @AccountBillingRateIdd,
    @EmailAddress,
    @EmployeeCode,
    @EmployeePayTypeId,
	@HiredDate,
    @AccountWorkingDayTypeId,
    @LastScheduledEmailSentTime)

--Select key to insert next
Select @AccountEmployeeId = SCOPE_IDENTITY()

--Second INSERT
INSERT INTO [dbo].[AccountBillingRate] 
([AccountId], [SystemBillingRateTypeId], [BillingRate], 
[StartDate], [EndDate], [AccountEmployeeId], [AccountWorkTypeId], [EmployeeRate], [BillingRateCurrencyId], [EmployeeRateCurrencyId])
VALUES
	(@AccountId
	,@SystemBillingRateTypeId
	,@BillingRate
	,@StartDate
	,@EndDate
	,@AccountEmployeeId
	,@AccountWorkTypeId
	,@EmployeeRate
	,@BillingRateCurrencyId
	,@EmployeeRateCurrencyId)

--Select key to insert next
Declare @AccountBillingRateId int
Select @AccountBillingRateId = SCOPE_IDENTITY()


--Update first table
Update [dbo].[AccountEmployee] 
set AccountBillingRateId = @AccountBillingRateId
where AccountEmployeeId = @AccountEmployeeId

--Third INSERT
INSERT INTO [dbo].[AccountProjectEmployee]
([AccountId], [AccountProjectId], [AccountEmployeeId], [TaskCompletedPercentage], [TaskCompleted], [AccountRoleId], [AccountBillingRateId], [AccountProjectEmployeeTemplateId])
VALUES
	(@AccountId
	,@AccountProjectId
	,@AccountEmployeeId
	,@TaskCompletedPercentage
	,@TaskCompleted
	,@AccountRoleId
	,@AccountBillingRateId
	,@AccountProjectEmployeeTemplateId)

-- Insert into HR Absence
INSERT INTO [dbo].[AccountProjectEmployee]
([AccountId], [AccountProjectId], [AccountEmployeeId], [TaskCompletedPercentage], [TaskCompleted], [AccountRoleId], [AccountBillingRateId], [AccountProjectEmployeeTemplateId])
VALUES
	(@AccountId
	,378
	,@AccountEmployeeId
	,@TaskCompletedPercentage
	,@TaskCompleted
	,@AccountRoleId
	,@AccountBillingRateId
	,@AccountProjectEmployeeTemplateId)

END