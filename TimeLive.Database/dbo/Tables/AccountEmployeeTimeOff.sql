CREATE TABLE [dbo].[AccountEmployeeTimeOff] (
    [AccountEmployeeTimeOffId]   UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeTimeOff_AccountEmployeeTimeOffId] DEFAULT (newid()) NOT NULL,
    [AccountEmployeeId]          INT              NOT NULL,
    [AccountId]                  INT              NOT NULL,
    [AccountTimeOffTypeId]       UNIQUEIDENTIFIER NOT NULL,
    [Earned]                     FLOAT (53)       NULL,
    [Consume]                    FLOAT (53)       NULL,
    [Available]                  FLOAT (53)       NULL,
    [LastEarnedDate]             DATETIME         NULL,
    [CreatedByEmployeeId]        INT              NULL,
    [CreatedOn]                  DATETIME         NULL,
    [ModifiedByEmployeeId]       INT              NULL,
    [ModifiedOn]                 DATETIME         NULL,
    [CarryForward]               FLOAT (53)       NULL,
    [AccountTimeOffPolicyId]     UNIQUEIDENTIFIER NULL,
    [LastResetDate]              DATETIME         NULL,
    [IsDisabled]                 BIT              NULL,
    [PolicyExecutionType]        NVARCHAR (250)   NULL,
    [PolicyEarnResetAutidAction] NVARCHAR (250)   NULL,
    [AuditSource]                NVARCHAR (250)   NULL,
    [LastCarryForwardExpiryDate] DATETIME         NULL,
    CONSTRAINT [PK_AccountEmployeeTimeOff] PRIMARY KEY CLUSTERED ([AccountEmployeeTimeOffId] ASC),
    CONSTRAINT [FK_AccountEmployeeTimeOff_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEmployeeTimeOff_AccountTimeOffPolicy] FOREIGN KEY ([AccountTimeOffPolicyId]) REFERENCES [dbo].[AccountTimeOffPolicy] ([AccountTimeOffPolicyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEmployeeTimeOff_AccountTimeOffType] FOREIGN KEY ([AccountTimeOffTypeId]) REFERENCES [dbo].[AccountTimeOffType] ([AccountTimeOffTypeId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountEmployeeTimeOff]
    ON [dbo].[AccountEmployeeTimeOff]([AccountId] ASC, [AccountEmployeeId] ASC, [AccountTimeOffTypeId] ASC);


GO

CREATE TRIGGER [dbo].[TRGAccountEmployeeTimeOffAfterInsert] ON [dbo].[AccountEmployeeTimeOff] 
FOR INSERT
AS
declare @PolicyExecutedDate datetime
set @PolicyExecutedDate = getdate()
	
 --- before row inserted
	
	insert into AccountEmployeeTimeOffAudit
           (AccountEmployeeId,AccountId,AccountTimeOffTypeId,Earned,Consume,Available,LastEarnedDate,CreatedByEmployeeId,CreatedOn,
           ModifiedByEmployeeId,ModifiedOn,CarryForward,AccountTimeOffPolicyId,LastResetDate,PolicyExecutionType,
           PolicyEarnResetAutidAction,PolicyExecutedDate,BeforeAfterPolicyChange,SystemEarnPeriodId,AccountTimeOffPolicy,SystemResetToZeroTypeId,
           ResetToHours,EarnHours,MaximumAvailable,AccountTimeOffType,InitialSetToHours,EffectiveDate,AuditSource,SystemEarnPeriod,SystemResetToZeroType) 
	Select a.AccountEmployeeId,a.AccountId,a.AccountTimeOffTypeId,a.Earned,a.Consume,a.Available,a.LastEarnedDate,a.CreatedByEmployeeId,
	a.CreatedOn,a.ModifiedByEmployeeId,a.ModifiedOn,a.CarryForward,a.AccountTimeOffPolicyId,a.LastResetDate,a.PolicyExecutionType,
	a.PolicyEarnResetAutidAction,@PolicyExecutedDate,'before New Row Inserted',b.SystemEarnPeriodId,b.AccountTimeOffPolicy,b.SystemResetToZeroTypeId,
	b.ResetToHours,b.EarnHours,b.MaximumAvailable,AccountTimeOffType,b.InitialSetToHours,b.EffectiveDate,a.AuditSource,b.SystemEarnPeriod,b.SystemResetToZeroType from deleted a 
	left outer join vueAccountEmployeeTimeOffLastSchedule b on 
	a.accountemployeeid = b.accountemployeeid and 
	a.accounttimeofftypeid = b.accounttimeofftypeid
 
 --- after row inserted
	
	insert into AccountEmployeeTimeOffAudit
           (AccountEmployeeId,AccountId,AccountTimeOffTypeId,Earned,Consume,Available,LastEarnedDate,CreatedByEmployeeId,CreatedOn,
           ModifiedByEmployeeId,ModifiedOn,CarryForward,AccountTimeOffPolicyId,LastResetDate,PolicyExecutionType,
           PolicyEarnResetAutidAction,PolicyExecutedDate,BeforeAfterPolicyChange,SystemEarnPeriodId,AccountTimeOffPolicy,SystemResetToZeroTypeId,
           ResetToHours,EarnHours,MaximumAvailable,AccountTimeOffType,InitialSetToHours,EffectiveDate,AuditSource,SystemEarnPeriod,SystemResetToZeroType) 
	Select a.AccountEmployeeId,a.AccountId,a.AccountTimeOffTypeId,a.Earned,a.Consume,a.Available,a.LastEarnedDate,a.CreatedByEmployeeId,
	a.CreatedOn,a.ModifiedByEmployeeId,a.ModifiedOn,a.CarryForward,a.AccountTimeOffPolicyId,a.LastResetDate,a.PolicyExecutionType,
	a.PolicyEarnResetAutidAction,@PolicyExecutedDate,'After New Row Inserted',b.SystemEarnPeriodId,b.AccountTimeOffPolicy,b.SystemResetToZeroTypeId,
	b.ResetToHours,b.EarnHours,b.MaximumAvailable,AccountTimeOffType,b.InitialSetToHours,b.EffectiveDate,a.AuditSource,b.SystemEarnPeriod,b.SystemResetToZeroType from inserted a 
	left outer join vueAccountEmployeeTimeOffLastSchedule b on 
	a.accountemployeeid = b.accountemployeeid and 
	a.accounttimeofftypeid = b.accounttimeofftypeid
GO

CREATE TRIGGER [dbo].[TRGAccountEmployeeTimeOffAfterUpdate] ON [dbo].[AccountEmployeeTimeOff] 
FOR UPDATE
AS
declare @PolicyExecutedDate datetime
set @PolicyExecutedDate = getdate()
	
--- insert record before policy change

	insert into AccountEmployeeTimeOffAudit
           (AccountEmployeeId,AccountId,AccountTimeOffTypeId,Earned,Consume,Available,LastEarnedDate,CreatedByEmployeeId,CreatedOn,
           ModifiedByEmployeeId,ModifiedOn,CarryForward,AccountTimeOffPolicyId,LastResetDate,PolicyExecutionType,
           PolicyEarnResetAutidAction,PolicyExecutedDate,BeforeAfterPolicyChange,SystemEarnPeriodId,AccountTimeOffPolicy,SystemResetToZeroTypeId,
           ResetToHours,EarnHours,MaximumAvailable,AccountTimeOffType,InitialSetToHours,EffectiveDate,AuditSource,SystemEarnPeriod,SystemResetToZeroType) 
	Select a.AccountEmployeeId,a.AccountId,a.AccountTimeOffTypeId,a.Earned,a.Consume,a.Available,a.LastEarnedDate,a.CreatedByEmployeeId,
	a.CreatedOn,a.ModifiedByEmployeeId,a.ModifiedOn,a.CarryForward,a.AccountTimeOffPolicyId,a.LastResetDate,a.PolicyExecutionType,
	a.PolicyEarnResetAutidAction,@PolicyExecutedDate,'Before',b.SystemEarnPeriodId,b.AccountTimeOffPolicy,b.SystemResetToZeroTypeId,
	b.ResetToHours,b.EarnHours,b.MaximumAvailable,AccountTimeOffType,b.InitialSetToHours,b.EffectiveDate,a.AuditSource,b.SystemEarnPeriod,b.SystemResetToZeroType from deleted a
	left outer join vueAccountEmployeeTimeOffLastSchedule b on 
	a.accountemployeeid = b.accountemployeeid and 
	a.accounttimeofftypeid = b.accounttimeofftypeid

	
	--- insert record after policy change
	
	insert into AccountEmployeeTimeOffAudit
           (AccountEmployeeId,AccountId,AccountTimeOffTypeId,Earned,Consume,Available,LastEarnedDate,CreatedByEmployeeId,CreatedOn,
           ModifiedByEmployeeId,ModifiedOn,CarryForward,AccountTimeOffPolicyId,LastResetDate,PolicyExecutionType,
           PolicyEarnResetAutidAction,PolicyExecutedDate,BeforeAfterPolicyChange,SystemEarnPeriodId,AccountTimeOffPolicy,SystemResetToZeroTypeId,
           ResetToHours,EarnHours,MaximumAvailable,AccountTimeOffType,InitialSetToHours,EffectiveDate,AuditSource,SystemEarnPeriod,SystemResetToZeroType) 
	Select a.AccountEmployeeId,a.AccountId,a.AccountTimeOffTypeId,a.Earned,a.Consume,a.Available,a.LastEarnedDate,a.CreatedByEmployeeId,
	a.CreatedOn,a.ModifiedByEmployeeId,a.ModifiedOn,a.CarryForward,a.AccountTimeOffPolicyId,a.LastResetDate,a.PolicyExecutionType,
	a.PolicyEarnResetAutidAction,@PolicyExecutedDate,'After',b.SystemEarnPeriodId,b.AccountTimeOffPolicy,b.SystemResetToZeroTypeId,
	b.ResetToHours,b.EarnHours,b.MaximumAvailable,AccountTimeOffType,b.InitialSetToHours,b.EffectiveDate,a.AuditSource,b.SystemEarnPeriod,b.SystemResetToZeroType 
	from inserted a 
	left outer join vueAccountEmployeeTimeOffLastSchedule b on 
	a.accountemployeeid = b.accountemployeeid and 
	a.accounttimeofftypeid = b.accounttimeofftypeid