CREATE TABLE [dbo].[AccountExpenseEntry] (
    [AccountExpenseEntryId]              INT              IDENTITY (1, 1) NOT NULL,
    [AccountExpenseEntryDate]            DATETIME         NOT NULL,
    [AccountId]                          INT              NOT NULL,
    [AccountEmployeeId]                  INT              NOT NULL,
    [AccountProjectId]                   INT              NOT NULL,
    [AccountExpenseId]                   INT              NOT NULL,
    [Description]                        NVARCHAR (4000)  NULL,
    [Amount]                             FLOAT (53)       NOT NULL,
    [TeamLeadApproved]                   BIT              NULL,
    [ProjectManagerApproved]             BIT              NULL,
    [AdministratorApproved]              BIT              NULL,
    [Approved]                           BIT              NULL,
    [TimeSheetApprovalPathId]            TINYINT          NULL,
    [CreatedOn]                          DATETIME         NOT NULL,
    [CreatedByEmployeeId]                INT              NOT NULL,
    [ModifiedOn]                         DATETIME         NOT NULL,
    [ModifiedByEmployeeId]               INT              NOT NULL,
    [IsBillable]                         BIT              NULL,
    [Rejected]                           BIT              NULL,
    [Quantity]                           FLOAT (53)       NULL,
    [Rate]                               FLOAT (53)       NULL,
    [AmountBeforeTax]                    FLOAT (53)       NULL,
    [TaxAmount]                          FLOAT (53)       NULL,
    [Reimburse]                          BIT              CONSTRAINT [DF_AccountExpenseEntry_Reimburse] DEFAULT ((0)) NOT NULL,
    [AccountCurrencyId]                  INT              NULL,
    [AccountPaymentMethodId]             INT              NULL,
    [AccountBaseCurrencyId]              INT              NULL,
    [ExchangeRate]                       FLOAT (53)       NULL,
    [Submitted]                          BIT              NULL,
    [AccountTaxZoneId]                   INT              NULL,
    [AccountTimeExpenseBillingExpenseId] UNIQUEIDENTIFIER NULL,
    [Billed]                             BIT              NULL,
    [AccountEmployeeExpenseSheetId]      UNIQUEIDENTIFIER NULL,
    [OldAccountExpenseEntryId]           INT              NULL,
    [AccountProjectTaskId]               BIGINT           NULL,
    [IsEmailSend]                        BIT              NULL,
    [CustomField1]                       NVARCHAR (2000)  NULL,
    [CustomField2]                       NVARCHAR (2000)  NULL,
    [CustomField3]                       NVARCHAR (2000)  NULL,
    [CustomField4]                       NVARCHAR (2000)  NULL,
    [CustomField5]                       NVARCHAR (2000)  NULL,
    [CustomField6]                       NVARCHAR (2000)  NULL,
    [CustomField7]                       NVARCHAR (2000)  NULL,
    [CustomField8]                       NVARCHAR (2000)  NULL,
    [CustomField9]                       NVARCHAR (2000)  NULL,
    [CustomField10]                      NVARCHAR (2000)  NULL,
    [CustomField11]                      NVARCHAR (2000)  NULL,
    [CustomField12]                      NVARCHAR (2000)  NULL,
    [CustomField13]                      NVARCHAR (2000)  NULL,
    [CustomField14]                      NVARCHAR (2000)  NULL,
    [CustomField15]                      NVARCHAR (2000)  NULL,
    [AccountClientId]                    INT              NULL,
    CONSTRAINT [PK_AccountExpenseEntry] PRIMARY KEY CLUSTERED ([AccountExpenseEntryId] ASC),
    CONSTRAINT [FK_AccountExpenseEntry_AccountCurrency] FOREIGN KEY ([AccountCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountEmployeeExpenseSheet] FOREIGN KEY ([AccountEmployeeExpenseSheetId]) REFERENCES [dbo].[AccountEmployeeExpenseSheet] ([AccountEmployeeExpenseSheetId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountExpenseEntry_AccountExpense] FOREIGN KEY ([AccountExpenseId]) REFERENCES [dbo].[AccountExpense] ([AccountExpenseId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountExpenseEntry] FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountExpenseEntry1] FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountPaymentMethod] FOREIGN KEY ([AccountPaymentMethodId]) REFERENCES [dbo].[AccountPaymentMethod] ([AccountPaymentMethodId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]),
    CONSTRAINT [FK_AccountExpenseEntry_AccountTaxZone] FOREIGN KEY ([AccountTaxZoneId]) REFERENCES [dbo].[AccountTaxZone] ([AccountTaxZoneId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Submitted]
    ON [dbo].[AccountExpenseEntry]([Submitted] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountExpenseEntry_5_343060358__K5_K1_K12_K29_K19_K4_K25_K6_K2_3_7_8]
    ON [dbo].[AccountExpenseEntry]([AccountProjectId] ASC, [AccountExpenseEntryId] ASC, [Approved] ASC, [Submitted] ASC, [Rejected] ASC, [AccountEmployeeId] ASC, [AccountCurrencyId] ASC, [AccountExpenseId] ASC, [AccountExpenseEntryDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetApprovalPathId]
    ON [dbo].[AccountExpenseEntry]([TimeSheetApprovalPathId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeamLeadApproved]
    ON [dbo].[AccountExpenseEntry]([TeamLeadApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectManagerApproved]
    ON [dbo].[AccountExpenseEntry]([ProjectManagerApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Approved]
    ON [dbo].[AccountExpenseEntry]([Approved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AdministratorApproved]
    ON [dbo].[AccountExpenseEntry]([AdministratorApproved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountExpenseEntry]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountExpenseEntry]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountExpenseId]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountExpenseEntryDate]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId] ASC);


GO
CREATE STATISTICS [_dta_stat_343060358_1_4_12_3_2_18_6_31_26_30_25_5]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryId], [AccountEmployeeId], [Approved], [AccountId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountPaymentMethodId], [AccountTaxZoneId], [AccountCurrencyId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_343060358_3_2_18_12_6_31_1_26_30_25_5]
    ON [dbo].[AccountExpenseEntry]([AccountId], [AccountExpenseEntryDate], [IsBillable], [Approved], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountExpenseEntryId], [AccountPaymentMethodId], [AccountTaxZoneId], [AccountCurrencyId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_343060358_12_6_31_1_26_30_25_5_3_4_2]
    ON [dbo].[AccountExpenseEntry]([Approved], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountExpenseEntryId], [AccountPaymentMethodId], [AccountTaxZoneId], [AccountCurrencyId], [AccountProjectId], [AccountId], [AccountEmployeeId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_4_12_5_3_2_18_6_31_1_26_30]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId], [Approved], [AccountProjectId], [AccountId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountExpenseEntryId], [AccountPaymentMethodId], [AccountTaxZoneId]);


GO
CREATE STATISTICS [_dta_stat_343060358_5_12_3_2_18_6_31_1_26_30]
    ON [dbo].[AccountExpenseEntry]([AccountProjectId], [Approved], [AccountId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountExpenseEntryId], [AccountPaymentMethodId], [AccountTaxZoneId]);


GO
CREATE STATISTICS [_dta_stat_343060358_25_4_12_3_2_18_6_31_1_26]
    ON [dbo].[AccountExpenseEntry]([AccountCurrencyId], [AccountEmployeeId], [Approved], [AccountId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountExpenseEntryId], [AccountPaymentMethodId]);


GO
CREATE STATISTICS [_dta_stat_343060358_29_19_12_25_1_4_5_6_2]
    ON [dbo].[AccountExpenseEntry]([Submitted], [Rejected], [Approved], [AccountCurrencyId], [AccountExpenseEntryId], [AccountEmployeeId], [AccountProjectId], [AccountExpenseId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_25_12_3_2_18_6_31_1_26]
    ON [dbo].[AccountExpenseEntry]([AccountCurrencyId], [Approved], [AccountId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId], [AccountExpenseEntryId], [AccountPaymentMethodId]);


GO
CREATE STATISTICS [_dta_stat_343060358_1_4_25_6_12_29_19_2]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryId], [AccountEmployeeId], [AccountCurrencyId], [AccountExpenseId], [Approved], [Submitted], [Rejected], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_29_19_12_1_6_5_4]
    ON [dbo].[AccountExpenseEntry]([Submitted], [Rejected], [Approved], [AccountExpenseEntryId], [AccountExpenseId], [AccountProjectId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_343060358_29_19_12_25_1_6_4]
    ON [dbo].[AccountExpenseEntry]([Submitted], [Rejected], [Approved], [AccountCurrencyId], [AccountExpenseEntryId], [AccountExpenseId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_343060358_12_29_19_4_5_25_6]
    ON [dbo].[AccountExpenseEntry]([Approved], [Submitted], [Rejected], [AccountEmployeeId], [AccountProjectId], [AccountCurrencyId], [AccountExpenseId]);


GO
CREATE STATISTICS [_dta_stat_343060358_12_3_4_2_18_6_31]
    ON [dbo].[AccountExpenseEntry]([Approved], [AccountId], [AccountEmployeeId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId], [AccountTimeExpenseBillingExpenseId]);


GO
CREATE STATISTICS [_dta_stat_343060358_2_1_3_4_6_25_5]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryDate], [AccountExpenseEntryId], [AccountId], [AccountEmployeeId], [AccountExpenseId], [AccountCurrencyId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_343060358_4_5_25_6_1_12_29]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId], [AccountProjectId], [AccountCurrencyId], [AccountExpenseId], [AccountExpenseEntryId], [Approved], [Submitted]);


GO
CREATE STATISTICS [_dta_stat_343060358_4_1_5_2_3_6]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId], [AccountExpenseEntryId], [AccountProjectId], [AccountExpenseEntryDate], [AccountId], [AccountExpenseId]);


GO
CREATE STATISTICS [_dta_stat_343060358_1_6_25_5_4_2]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryId], [AccountExpenseId], [AccountCurrencyId], [AccountProjectId], [AccountEmployeeId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_3_4_1_6_25_5]
    ON [dbo].[AccountExpenseEntry]([AccountId], [AccountEmployeeId], [AccountExpenseEntryId], [AccountExpenseId], [AccountCurrencyId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_343060358_1_12_3_2_18_6]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryId], [Approved], [AccountId], [AccountExpenseEntryDate], [IsBillable], [AccountExpenseId]);


GO
CREATE STATISTICS [_dta_stat_343060358_29_19_12_25_1_5]
    ON [dbo].[AccountExpenseEntry]([Submitted], [Rejected], [Approved], [AccountCurrencyId], [AccountExpenseEntryId], [AccountProjectId]);


GO
CREATE STATISTICS [_dta_stat_343060358_6_4_12_3_2]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseId], [AccountEmployeeId], [Approved], [AccountId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_6_29_19_12_25]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseId], [Submitted], [Rejected], [Approved], [AccountCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_343060358_5_29_19_12_25]
    ON [dbo].[AccountExpenseEntry]([AccountProjectId], [Submitted], [Rejected], [Approved], [AccountCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_343060358_4_29_19_12_1]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId], [Submitted], [Rejected], [Approved], [AccountExpenseEntryId]);


GO
CREATE STATISTICS [_dta_stat_343060358_4_29_19_12_25]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId], [Submitted], [Rejected], [Approved], [AccountCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_343060358_2_1_29_19_12]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryDate], [AccountExpenseEntryId], [Submitted], [Rejected], [Approved]);


GO
CREATE STATISTICS [_dta_stat_343060358_25_4_1_2_3]
    ON [dbo].[AccountExpenseEntry]([AccountCurrencyId], [AccountEmployeeId], [AccountExpenseEntryId], [AccountExpenseEntryDate], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_343060358_3_4_2_18]
    ON [dbo].[AccountExpenseEntry]([AccountId], [AccountEmployeeId], [AccountExpenseEntryDate], [IsBillable]);


GO
CREATE STATISTICS [_dta_stat_343060358_1_29_19_12]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryId], [Submitted], [Rejected], [Approved]);


GO
CREATE STATISTICS [_dta_stat_343060358_19_1_5_12]
    ON [dbo].[AccountExpenseEntry]([Rejected], [AccountExpenseEntryId], [AccountProjectId], [Approved]);


GO
CREATE STATISTICS [_dta_stat_343060358_6_12_3_2]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseId], [Approved], [AccountId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_4_1_6_2]
    ON [dbo].[AccountExpenseEntry]([AccountEmployeeId], [AccountExpenseEntryId], [AccountExpenseId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_2_3_4]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryDate], [AccountId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_343060358_19_1_12]
    ON [dbo].[AccountExpenseEntry]([Rejected], [AccountExpenseEntryId], [Approved]);


GO
CREATE STATISTICS [_dta_stat_343060358_5_1_6]
    ON [dbo].[AccountExpenseEntry]([AccountProjectId], [AccountExpenseEntryId], [AccountExpenseId]);


GO
CREATE STATISTICS [_dta_stat_343060358_1_4_2]
    ON [dbo].[AccountExpenseEntry]([AccountExpenseEntryId], [AccountEmployeeId], [AccountExpenseEntryDate]);


GO
CREATE STATISTICS [_dta_stat_343060358_12_1_29]
    ON [dbo].[AccountExpenseEntry]([Approved], [AccountExpenseEntryId], [Submitted]);


GO
CREATE STATISTICS [_dta_stat_343060358_25_29_19]
    ON [dbo].[AccountExpenseEntry]([AccountCurrencyId], [Submitted], [Rejected]);


GO
CREATE STATISTICS [_dta_stat_343060358_19_12]
    ON [dbo].[AccountExpenseEntry]([Rejected], [Approved]);


GO

CREATE trigger [AuditTriggerAccountExpenseEntry] on [dbo].[AccountExpenseEntry] for insert, update, delete
as

declare @bit int ,
	@field int ,
	@maxfield int ,
	@char int ,
	@fieldname nvarchar(256) ,
	@TableName nvarchar(256) ,
	@PKCols nvarchar(2000) ,
	@sql nvarchar(4000), 
	@UpdateDate nvarchar(42) ,
	@UserName nvarchar(256) ,
	@Type nchar(1) ,
	@PKSelect nvarchar(2000)
	
	select @TableName = 'AccountExpenseEntry'

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
	
	-- Get primary key columns for full outer join
	select	@PKCols = coalesce(@PKCols + ' and', ' on') + ' i.' + c.COLUMN_NAME + ' = d.' + c.COLUMN_NAME
	from	INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,
		INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	where 	pk.TABLE_NAME = @TableName
	and	CONSTRAINT_TYPE = 'PRIMARY KEY'
	and	c.TABLE_NAME = pk.TABLE_NAME
	and	c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	
	-- Get primary key select for insert
	select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(nvarchar(200),coalesce(i.' + COLUMN_NAME +',d.' + COLUMN_NAME + '))+''>''' 
	from	INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,
		INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	where 	pk.TABLE_NAME = @TableName
	and	CONSTRAINT_TYPE = 'PRIMARY KEY'
	and	c.TABLE_NAME = pk.TABLE_NAME
	and	c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	
	if @PKCols is null
	begin
		raiserror('no PK on table %s', 16, -1, @TableName)
		return
	end
	
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
			select @sql = @sql + 	',' + Replace(Replace(@PKSelect,'<AccountExpenseEntryId=',''),'>','')
			select @sql = @sql + 	',''' + @fieldname + ''''
			select @sql = @sql + 	',convert(nvarchar(2000),d.' + @fieldname + ')'
			select @sql = @sql + 	',convert(nvarchar(2000),i.' + @fieldname + ')'
			select @sql = @sql + 	',''' + @UpdateDate + ''''
			select @sql = @sql + 	',''' + @UserName + ''''
			select @sql = @sql + 	' from #ins i full outer join #del d'
			select @sql = @sql + 	@PKCols
			select @sql = @sql + 	' where i.' + @fieldname + ' <> d.' + @fieldname 
			select @sql = @sql + 	' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)' 
			select @sql = @sql + 	' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)' 
			exec (@sql)
		end
	end