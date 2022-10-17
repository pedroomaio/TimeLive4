
CREATE PROCEDURE [dbo].[DeleteScript] 
    (
@AccountId integer
            )
AS
	SET NOCOUNT ON

IF EXISTS (SELECT * FROM AccountAttachments WHERE AccountExpenseEntryId in (Select AccountExpenseEntryId from AccountExpenseEntry Where AccountId <> @AccountId))
BEGIN
delete from AccountAttachments Where AccountExpenseEntryId in (Select AccountExpenseEntryId from AccountExpenseEntry Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountExpenseEntry WHERE AccountId = @AccountId)
BEGIN
delete from AccountExpenseEntry where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTimeExpenseBillingExpense WHERE AccountId = @AccountId)
BEGIN
delete from AccountTimeExpenseBillingExpense where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTimeExpenseBillingTimesheet WHERE AccountId = @AccountId)
BEGIN
delete from AccountTimeExpenseBillingTimesheet where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTimeExpenseBilling WHERE AccountId = @AccountId)
BEGIN
delete from AccountTimeExpenseBilling where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accountholidaytypedetail WHERE AccountId = @AccountId)
BEGIN
delete from accountholidaytypedetail where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accountholidaytype WHERE AccountId = @AccountId)
BEGIN
delete from accountholidaytype where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountExpense WHERE AccountId = @AccountId)
BEGIN
delete from AccountExpense where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountExpenseTypeTaxCode WHERE AccountId = @AccountId)
BEGIN
delete From AccountExpenseTypeTaxCode where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountExpenseType WHERE AccountId = @AccountId)
BEGIN
delete from AccountExpenseType where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTaxCode WHERE AccountId = @AccountId)
BEGIN
delete from AccountTaxCode where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountPaymentMethod WHERE AccountId = @AccountId)
BEGIN
delete from AccountPaymentMethod where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountPreferences WHERE AccountId = @AccountId)
BEGIN
delete from AccountPreferences where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountWorkTypeBillingRate WHERE AccountId = @AccountId)
BEGIN
delete from AccountWorkTypeBillingRate where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountEmployeeTimeEntry Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId))
BEGIN
delete from AccountEmployeeTimeEntry 
Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountEmployeeTimeEntry Where AccountProjectTaskId in (Select AccountProjectTaskId from AccountProjectTask Where AccountProjectId  in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId)))
BEGIN
delete from AccountEmployeeTimeEntry 
Where AccountProjectTaskId in (Select AccountProjectTaskId from AccountProjectTask Where AccountProjectId  in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId))
END
IF EXISTS (SELECT * FROM AccountProjectTask Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId))
BEGIN
Delete From AccountProjectTask 
Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountProjectMilestone Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId))
BEGIN
delete from AccountProjectMilestone 
Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM accountemailnotificationpreference where accountprojectid not in (Select AccountProjectId from AccountProject where accountid = @AccountId))
BEGIN
delete from accountemailnotificationpreference 
where accountprojectid not in (Select AccountProjectId from AccountProject where accountid = @AccountId)
END
IF EXISTS (SELECT * FROM accountemailnotificationpreference where AccountEmployeeId not in (Select AccountEmployeeId from AccountEmployee where accountid = @AccountId))
BEGIN
delete from accountemailnotificationpreference
where AccountEmployeeId not in (Select AccountEmployeeId from AccountEmployee where accountid = @AccountId)
END
IF EXISTS (SELECT * FROM accountemailnotificationpreference where AccountId <> @AccountId)
BEGIN
delete from accountemailnotificationpreference where AccountId <> @AccountId
END
IF EXISTS (SELECT * FROM AccountEmployeeTimeEntry Where AccountEmployeeId in (Select AccountEmployeeId from AccountEmployee Where AccountId <> @AccountId))
BEGIN
delete from AccountEmployeeTimeEntry 
Where AccountEmployeeId in (Select AccountEmployeeId from AccountEmployee Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountEmployeeTimeEntryApprovalProject Where TimeEntryAccountEmployeeId in (Select AccountEmployeeId from AccountEmployee Where AccountId <> @AccountId))
BEGIN
delete from AccountEmployeeTimeEntryApprovalProject 
Where TimeEntryAccountEmployeeId in (Select AccountEmployeeId from AccountEmployee Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountEmployeeTimeEntryPeriod where AccountId <> @AccountId)
BEGIN
delete from AccountEmployeeTimeEntryPeriod
where AccountId <> @AccountId
END
IF EXISTS (SELECT * FROM AccountProjectRole Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId))
BEGIN
delete From AccountProjectRole
Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountEmployeeTimeOffRequest where AccountEmployeeId in (Select AccountEmployeeId from AccountEmployee where accountid <> @AccountId))
BEGIN
delete from AccountEmployeeTimeOffRequest
where AccountEmployeeId in (Select AccountEmployeeId from AccountEmployee where accountid <> @AccountId)
END
IF EXISTS (SELECT * FROM AccountProject where accountid <> @AccountId)
BEGIN
delete from AccountProject where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM EmailMessage where EmailTo in (Select EmailAddress from AccountEmployee Where AccountId <> @AccountId))
BEGIN
delete From EmailMessage where EmailTo in (Select EmailAddress from AccountEmployee Where AccountId <> @AccountId)
END
IF EXISTS (SELECT * FROM accountemployeeattendance where accountid <> @AccountId)
BEGIN
delete from accountemployeeattendance where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountEmployeeExpenseSheet where accountid <> @AccountId)
BEGIN
delete from AccountEmployeeExpenseSheet
where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountApprovalPath where accountid <> @AccountId)
BEGIN
delete from AccountApprovalPath
where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accountemployee where accountid <> @AccountId)
BEGIN
delete from accountemployee where accountid  <> @AccountId
END
IF EXISTS (SELECT * FROM AccountParty WHERE AccountId = @AccountId)
BEGIN
delete from AccountParty where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accountstatus where accountid <> @AccountId)
BEGIN
delete from accountstatus where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accountworkingdaytype where accountid <> @AccountId)
BEGIN
delete from accountworkingdaytype where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accounttimesheetperiodtype where accountid <> @AccountId)
BEGIN
delete from accounttimesheetperiodtype where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM accountcostcenter where accountid <> @AccountId)
BEGIN
delete from accountcostcenter where accountid <> @AccountId
END

IF EXISTS (SELECT * FROM Account where accountid <> @AccountId)
BEGIN
delete from Account where accountid <> @AccountId
END


IF EXISTS (SELECT * FROM AccountPriority where accountid <> @AccountId)
BEGIN
delete From AccountPriority where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountWorkTypeBillingRate where accountid <> @AccountId)
BEGIN
delete from AccountWorkTypeBillingRate where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountBillingRate where accountid <> @AccountId)
BEGIN
delete From AccountBillingRate where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountCurrency where accountid <> @AccountId)
BEGIN
delete from AccountCurrency where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountCurrencyExchangeRate where accountid <> @AccountId)
BEGIN
delete from AccountCurrencyExchangeRate where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTimeOffPolicy where accountid <> @AccountId)
BEGIN
delete from AccountTimeOffPolicy where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTimeOffType where accountid <> @AccountId)
BEGIN
delete from AccountTimeOffType where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountTaxZone where accountid <> @AccountId)
BEGIN
delete From AccountTaxZone where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountCostCenter where accountid <> @AccountId)
BEGIN
delete From AccountCostCenter where accountid <> @AccountId
END
IF EXISTS (SELECT * FROM AccountWorkType where accountid <> @AccountId)
BEGIN
delete From AccountWorkType where accountid <> @AccountId
END
BEGIN
delete From LTCustomer 
delete From LTCustomerPayment
delete from EmailMessage

/****** Object:  Table [dbo].[Audit]    Script Date: 04/02/2011 17:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Audit]') AND type in (N'U'))
DROP TABLE [dbo].[Audit]

CREATE TABLE [dbo].[Audit](
	[Type] [nvarchar](2)  NULL,
	[TableName] [nvarchar](256) NULL,
	[PK] [varchar](50) NULL,
	[FieldName] [nvarchar](256) NULL,
	[OldValue] [nvarchar](2000) NULL,
	[NewValue] [nvarchar](2000) NULL,
	[UpdateDate] [datetime] NULL,
	[UserName] [int] NULL
) ON [PRIMARY]
END