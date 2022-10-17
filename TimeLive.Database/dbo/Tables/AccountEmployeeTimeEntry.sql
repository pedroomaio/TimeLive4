CREATE TABLE [dbo].[AccountEmployeeTimeEntry] (
    [AccountEmployeeTimeEntryId]                INT              IDENTITY (1, 1) NOT NULL,
    [AccountEmployeeId]                         INT              NOT NULL,
    [TimeEntryDate]                             DATETIME         NOT NULL,
    [StartTime]                                 DATETIME         NULL,
    [EndTime]                                   DATETIME         NULL,
    [TotalTime]                                 DATETIME         NOT NULL,
    [AccountProjectId]                          INT              NULL,
    [AccountProjectTaskId]                      BIGINT           NULL,
    [Description]                               NVARCHAR (2000)  NULL,
    [TimeSheetApprovalPathId]                   TINYINT          NULL,
    [Approved]                                  BIT              CONSTRAINT [DF_AccountEmployeeTimeEntry_Approved] DEFAULT ((0)) NULL,
    [TeamLeadApproved]                          BIT              CONSTRAINT [DF_AccountEmployeeTimeEntry_TeamLeadApproved] DEFAULT ((0)) NULL,
    [ProjectManagerApproved]                    BIT              CONSTRAINT [DF_AccountEmployeeTimeEntry_ProjectManagerApproved] DEFAULT ((0)) NULL,
    [AdministratorApproved]                     BIT              CONSTRAINT [DF_AccountEmployeeTimeEntry_AdministratorApproved] DEFAULT ((0)) NULL,
    [CreatedOn]                                 DATETIME         NULL,
    [ModifiedOn]                                DATETIME         NULL,
    [Rejected]                                  BIT              CONSTRAINT [DF_AccountEmployeeTimeEntry_Rejected] DEFAULT ((0)) NULL,
    [BillingRate]                               MONEY            NULL,
    [AccountPartyId]                            INT              NULL,
    [Submitted]                                 BIT              NULL,
    [AccountWorkTypeId]                         INT              NULL,
    [EmployeeRate]                              MONEY            NULL,
    [AccountCostCenterId]                       INT              NULL,
    [BillingRateCurrencyId]                     INT              NULL,
    [EmployeeRateCurrencyId]                    INT              NULL,
    [BillingRateExchangeRate]                   FLOAT (53)       NULL,
    [EmployeeRateExchangeRate]                  FLOAT (53)       NULL,
    [AccountBaseCurrencyId]                     INT              NULL,
    [AccountEmployeeTimeEntryPeriodId]          UNIQUEIDENTIFIER NULL,
    [AccountEmployeeTimeEntryApprovalProjectId] UNIQUEIDENTIFIER NULL,
    [AccountTimeExpenseBillingTimesheetId]      UNIQUEIDENTIFIER NULL,
    [Billed]                                    BIT              NULL,
    [CreatedByEmployeeId]                       INT              NULL,
    [ModifiedByEmployeeId]                      INT              NULL,
    [IsTimeOff]                                 BIT              CONSTRAINT [DF_AccountEmployeeTimeEntry_IsTimeOff] DEFAULT ((0)) NOT NULL,
    [Hours]                                     DECIMAL (18, 2)  NULL,
    [AccountTimeOffTypeId]                      UNIQUEIDENTIFIER NULL,
    [AccountEmployeeTimeOffRequestId]           UNIQUEIDENTIFIER NULL,
    [IsTimeOffConsumed]                         BIT              NULL,
    [Percentage]                                INT              NULL,
    [CustomField1]                              NVARCHAR (2000)  NULL,
    [CustomField2]                              NVARCHAR (2000)  NULL,
    [CustomField3]                              NVARCHAR (2000)  NULL,
    [CustomField4]                              NVARCHAR (2000)  NULL,
    [CustomField5]                              NVARCHAR (2000)  NULL,
    [CustomField6]                              NVARCHAR (2000)  NULL,
    [CustomField7]                              NVARCHAR (2000)  NULL,
    [CustomField8]                              NVARCHAR (2000)  NULL,
    [CustomField9]                              NVARCHAR (2000)  NULL,
    [CustomField10]                             NVARCHAR (2000)  NULL,
    [CustomField11]                             NVARCHAR (2000)  NULL,
    [CustomField12]                             NVARCHAR (2000)  NULL,
    [CustomField13]                             NVARCHAR (2000)  NULL,
    [CustomField14]                             NVARCHAR (2000)  NULL,
    [CustomField15]                             NVARCHAR (2000)  NULL,
    [IsFixedBid]                                BIT              NULL,
    CONSTRAINT [PK_AccountTimeEntry] PRIMARY KEY CLUSTERED ([AccountEmployeeTimeEntryId] ASC),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountCostCenter] FOREIGN KEY ([AccountCostCenterId]) REFERENCES [dbo].[AccountCostCenter] ([AccountCostCenterId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountEmployeeTimeEntryApprovalProject] FOREIGN KEY ([AccountEmployeeTimeEntryApprovalProjectId]) REFERENCES [dbo].[AccountEmployeeTimeEntryApprovalProject] ([AccountEmployeeTimeEntryApprovalProjectId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountEmployeeTimeEntryPeriod] FOREIGN KEY ([AccountEmployeeTimeEntryPeriodId]) REFERENCES [dbo].[AccountEmployeeTimeEntryPeriod] ([AccountEmployeeTimeEntryPeriodId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountEmployeeTimeOffRequest] FOREIGN KEY ([AccountEmployeeTimeOffRequestId]) REFERENCES [dbo].[AccountEmployeeTimeOffRequest] ([AccountEmployeeTimeOffRequestId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountTimeOffType] FOREIGN KEY ([AccountTimeOffTypeId]) REFERENCES [dbo].[AccountTimeOffType] ([AccountTimeOffTypeId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountWorkType] FOREIGN KEY ([AccountWorkTypeId]) REFERENCES [dbo].[AccountWorkType] ([AccountWorkTypeId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntry_10_501576825__K1]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Rejected]
    ON [dbo].[AccountEmployeeTimeEntry]([Rejected] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountCostCenterId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BillingRateCurrencyId]
    ON [dbo].[AccountEmployeeTimeEntry]([BillingRateCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeRateCurrencyId]
    ON [dbo].[AccountEmployeeTimeEntry]([EmployeeRateCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Billed]
    ON [dbo].[AccountEmployeeTimeEntry]([Billed] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountBaseCurrencyId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountBaseCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntry_10_2090542581__K2_K3_K1_K7_K8_K21_K23]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeId] ASC, [TimeEntryDate] ASC, [AccountEmployeeTimeEntryId] ASC, [AccountProjectId] ASC, [AccountProjectTaskId] ASC, [AccountWorkTypeId] ASC, [AccountCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntry_10_2090542581__K29_1_7_30]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryPeriodId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntry_5_2090542581__K11_K7_K29_K1_K20_K17_K2_K8_3_6]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved] ASC, [AccountProjectId] ASC, [AccountEmployeeTimeEntryPeriodId] ASC, [AccountEmployeeTimeEntryId] ASC, [Submitted] ASC, [Rejected] ASC, [AccountEmployeeId] ASC, [AccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployeeTimeEntry_5_2090542581__K11_K7_K29_K1_K20_K17_K2_K8_K3_6_9]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved] ASC, [AccountProjectId] ASC, [AccountEmployeeTimeEntryPeriodId] ASC, [AccountEmployeeTimeEntryId] ASC, [Submitted] ASC, [Rejected] ASC, [AccountEmployeeId] ASC, [AccountProjectTaskId] ASC, [TimeEntryDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTimeExpenseBillingTimesheetId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountTimeExpenseBillingTimesheetId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryApprovalProjectId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryApprovalProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriodId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryPeriodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Submitted]
    ON [dbo].[AccountEmployeeTimeEntry]([Submitted] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetApprovalPathId]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeSheetApprovalPathId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeEntryDate]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeamLeadApproved]
    ON [dbo].[AccountEmployeeTimeEntry]([TeamLeadApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectManagerApproved]
    ON [dbo].[AccountEmployeeTimeEntry]([ProjectManagerApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Approved]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AdministratorApproved]
    ON [dbo].[AccountEmployeeTimeEntry]([AdministratorApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectTaskId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [AccountEmployeeId]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeId] ASC);


GO
CREATE STATISTICS [_dta_stat_501576825_1_7_8]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountProjectId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_8_23_21_3_2]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountProjectTaskId], [AccountCostCenterId], [AccountWorkTypeId], [TimeEntryDate], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_8_3_2_21]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountProjectTaskId], [TimeEntryDate], [AccountEmployeeId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_30_7_29]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountEmployeeTimeEntryApprovalProjectId], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_21_23]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountWorkTypeId], [AccountCostCenterId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_30_29]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountEmployeeTimeEntryApprovalProjectId], [AccountEmployeeTimeEntryPeriodId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_23_21]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountCostCenterId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_3_2_1_8_23_21_31_25_24]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [TimeEntryDate], [AccountEmployeeId], [AccountEmployeeTimeEntryId], [AccountProjectTaskId], [AccountCostCenterId], [AccountWorkTypeId], [AccountTimeExpenseBillingTimesheetId], [EmployeeRateCurrencyId], [BillingRateCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_20_17_11_1_7_29_2_8_3]
    ON [dbo].[AccountEmployeeTimeEntry]([Submitted], [Rejected], [Approved], [AccountEmployeeTimeEntryId], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [AccountEmployeeId], [AccountProjectTaskId], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_3_2_1_8_23_21_31_25_24]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate], [AccountEmployeeId], [AccountEmployeeTimeEntryId], [AccountProjectTaskId], [AccountCostCenterId], [AccountWorkTypeId], [AccountTimeExpenseBillingTimesheetId], [EmployeeRateCurrencyId], [BillingRateCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_1_2_8_23_21_31_25_24]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountEmployeeTimeEntryId], [AccountEmployeeId], [AccountProjectTaskId], [AccountCostCenterId], [AccountWorkTypeId], [AccountTimeExpenseBillingTimesheetId], [EmployeeRateCurrencyId], [BillingRateCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_8_11_3_7_2_1_23_21]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectTaskId], [Approved], [TimeEntryDate], [AccountProjectId], [AccountEmployeeId], [AccountEmployeeTimeEntryId], [AccountCostCenterId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_2_8_23_21_31_25_24]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountEmployeeId], [AccountProjectTaskId], [AccountCostCenterId], [AccountWorkTypeId], [AccountTimeExpenseBillingTimesheetId], [EmployeeRateCurrencyId], [BillingRateCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_29_1_2_8_11_20_17_3]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryPeriodId], [AccountEmployeeTimeEntryId], [AccountEmployeeId], [AccountProjectTaskId], [Approved], [Submitted], [Rejected], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_29_2_8_1_11_20]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [AccountEmployeeId], [AccountProjectTaskId], [AccountEmployeeTimeEntryId], [Approved], [Submitted]);


GO
CREATE STATISTICS [_dta_stat_2090542581_3_1_11_7_8_23_21]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate], [AccountEmployeeTimeEntryId], [Approved], [AccountProjectId], [AccountProjectTaskId], [AccountCostCenterId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_11_7_29_20_17_2_8]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [Submitted], [Rejected], [AccountEmployeeId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_20_17_11_1_8_7_29]
    ON [dbo].[AccountEmployeeTimeEntry]([Submitted], [Rejected], [Approved], [AccountEmployeeTimeEntryId], [AccountProjectTaskId], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_11_7_8_2_1_23_21]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved], [AccountProjectId], [AccountProjectTaskId], [AccountEmployeeId], [AccountEmployeeTimeEntryId], [AccountCostCenterId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_21_7_8_23_3]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountWorkTypeId], [AccountProjectId], [AccountProjectTaskId], [AccountCostCenterId], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_11_20_17_29_1_2]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved], [Submitted], [Rejected], [AccountEmployeeTimeEntryPeriodId], [AccountEmployeeTimeEntryId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_20_17_11_1_2_7]
    ON [dbo].[AccountEmployeeTimeEntry]([Submitted], [Rejected], [Approved], [AccountEmployeeTimeEntryId], [AccountEmployeeId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_11_1_3_7_8]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved], [AccountEmployeeTimeEntryId], [TimeEntryDate], [AccountProjectId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_8_1_3_2_21]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectTaskId], [AccountEmployeeTimeEntryId], [TimeEntryDate], [AccountEmployeeId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_20_17_11_3]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [Submitted], [Rejected], [Approved], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_17_7_29_1_11]
    ON [dbo].[AccountEmployeeTimeEntry]([Rejected], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [AccountEmployeeTimeEntryId], [Approved]);


GO
CREATE STATISTICS [_dta_stat_2090542581_1_7_29_11_20]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryId], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [Approved], [Submitted]);


GO
CREATE STATISTICS [_dta_stat_2090542581_8_1_11_2_3]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectTaskId], [AccountEmployeeTimeEntryId], [Approved], [AccountEmployeeId], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_3_1_7_8]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate], [AccountEmployeeTimeEntryId], [AccountProjectId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_1_11_2]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountEmployeeTimeEntryId], [Approved], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_20_17_11]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [Submitted], [Rejected], [Approved]);


GO
CREATE STATISTICS [_dta_stat_2090542581_17_7_29_11]
    ON [dbo].[AccountEmployeeTimeEntry]([Rejected], [AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [Approved]);


GO
CREATE STATISTICS [_dta_stat_2090542581_2_3_7_8]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeId], [TimeEntryDate], [AccountProjectId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_3_1_20_17]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate], [AccountEmployeeTimeEntryId], [Submitted], [Rejected]);


GO
CREATE STATISTICS [_dta_stat_2090542581_2_20_17_11]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeId], [Submitted], [Rejected], [Approved]);


GO
CREATE STATISTICS [_dta_stat_2090542581_8_20_17_11]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectTaskId], [Submitted], [Rejected], [Approved]);


GO
CREATE STATISTICS [_dta_stat_2090542581_3_1_2_21]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate], [AccountEmployeeTimeEntryId], [AccountEmployeeId], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_29_20_17]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountEmployeeTimeEntryPeriodId], [Submitted], [Rejected]);


GO
CREATE STATISTICS [_dta_stat_2090542581_11_2_3_7]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved], [AccountEmployeeId], [TimeEntryDate], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_2_1_8_7]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeId], [AccountEmployeeTimeEntryId], [AccountProjectTaskId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_1_3]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountEmployeeTimeEntryId], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_29_20_17]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountEmployeeTimeEntryPeriodId], [Submitted], [Rejected]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_11_3]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [Approved], [TimeEntryDate]);


GO
CREATE STATISTICS [_dta_stat_2090542581_11_1_2]
    ON [dbo].[AccountEmployeeTimeEntry]([Approved], [AccountEmployeeTimeEntryId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_8_2]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectTaskId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_7_8]
    ON [dbo].[AccountEmployeeTimeEntry]([AccountProjectId], [AccountProjectTaskId]);


GO
CREATE STATISTICS [_dta_stat_2090542581_3_11]
    ON [dbo].[AccountEmployeeTimeEntry]([TimeEntryDate], [Approved]);


GO

CREATE trigger [AuditTriggerAccountEmployeeTimeEntry] on [dbo].[AccountEmployeeTimeEntry] for update, delete
as
declare @bit int ,
	@field int ,
	@maxfield int ,
	@char int ,
	@fieldname nvarchar(256) ,
	@TableName nvarchar(256) ,
	@sql nvarchar(4000), 
	@UpdateDate nvarchar(42) ,
	@UserName nvarchar(256) ,
	@Type nchar(1)
	select @TableName = 'AccountEmployeeTimeEntry'
	-- date and user
	select 	@UserName = 0 ,
		@UpdateDate = convert(nvarchar(16), getdate(), 112) + ' ' + convert(nvarchar(16), getdate(), 114)
	-- Action
	if exists (select * from inserted)
		if exists (select * from deleted)
			Begin
				select @Type = 'U'
				select @UserName  = ModifiedByEmployeeId from inserted
			End 
	-- get list of columns
	select * into #ins from inserted
	select * into #del from deleted
	select @field = 0, @maxfield = max(ORDINAL_POSITION) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName
	while @field < @maxfield
	begin
		select @field = min(ORDINAL_POSITION) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName and ORDINAL_POSITION > @field
		select @bit = (@field - 1 )% 8 + 1
		select @bit = power(2,@bit - 1)
		select @char = ((@field - 1) / 8) + 1
		if substring(COLUMNS_UPDATED(),@char, 1) & @bit > 0 or @Type in ('I','D')
		begin
			select @fieldname = COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName and ORDINAL_POSITION = @field
			select @sql = 		'insert Audit (Type, TableName, PK, FieldName, OldValue, NewValue, UpdateDate, UserName)'
			select @sql = @sql + 	' select ''' + @Type + ''''
			select @sql = @sql + 	',''' + @TableName + ''''
			select @sql = @sql + 	',' + '''''' + '+convert(nvarchar(200),coalesce(i.AccountEmployeeTimeEntryId,d.AccountEmployeeTimeEntryId))+' + ''''''
			select @sql = @sql + 	',''' + @fieldname + ''''
			select @sql = @sql + 	',convert(nvarchar(2000),d.' + @fieldname + ')'
			select @sql = @sql + 	',convert(nvarchar(2000),i.' + @fieldname + ')'
			select @sql = @sql + 	',''' + @UpdateDate + ''''
			select @sql = @sql + 	',''' + @UserName + ''''
			select @sql = @sql + 	' from #ins i full outer join #del d'
			select @sql = @sql + 	' on i.AccountEmployeeTimeEntryId = d.AccountEmployeeTimeEntryId'
			select @sql = @sql + 	' where i.' + @fieldname + ' <> d.' + @fieldname 
			select @sql = @sql + 	' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)' 
			select @sql = @sql + 	' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)' 
			exec (@sql)
		end
	end