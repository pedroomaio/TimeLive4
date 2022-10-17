CREATE TABLE [dbo].[AccountEmployeeTimeEntryPeriod] (
    [AccountEmployeeTimeEntryPeriodId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeTimeEntryPeriod_AccountEmployeeTimeEntryPeriodId] DEFAULT (newid()) NOT NULL,
    [AccountId]                        INT              NOT NULL,
    [AccountEmployeeId]                INT              NOT NULL,
    [TimeEntryStartDate]               DATETIME         NOT NULL,
    [TimeEntryEndDate]                 DATETIME         NOT NULL,
    [TimeEntryViewType]                NVARCHAR (50)    NOT NULL,
    [Submitted]                        BIT              NOT NULL,
    [Approved]                         BIT              NOT NULL,
    [Rejected]                         BIT              NOT NULL,
    [InApproval]                       BIT              NOT NULL,
    [SubmittedDate]                    DATETIME         NULL,
    [ApprovedOn]                       DATETIME         NULL,
    [ApprovedByEmployeeId]             INT              NULL,
    [RejectedOn]                       DATETIME         NULL,
    [RejectedByEmployeeId]             INT              NULL,
    [SubmittedBy]                      INT              NULL,
    [CreatedByEmployeeId]              INT              NULL,
    [ModifiedByEmployeeId]             INT              NULL,
    [PeriodDescription]                NVARCHAR (2000)  NULL,
    [CreatedOn]                        DATETIME         NULL,
    [ModifiedOn]                       DATETIME         NULL,
    CONSTRAINT [PK_AccountEmployeeTimeEntryPeriod] PRIMARY KEY CLUSTERED ([AccountEmployeeTimeEntryPeriodId] ASC),
    CONSTRAINT [FK_AccountEmployeeTimeEntryPeriod_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountEmployeeTimeEntryPeriod_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_ApprovedByEmployeeId]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([ApprovedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_RejectedByEmployeeId]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([RejectedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_RejectedOn]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([RejectedOn] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_ApprovedOn]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([ApprovedOn] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_Submitted]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([Submitted] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_Rejected]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([Rejected] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_InApproval]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([InApproval] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_Approved]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([Approved] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_TimeEntryEndDate]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([TimeEntryEndDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod_TimeEntryStartDate]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([TimeEntryStartDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeTimeEntryPeriod]
    ON [dbo].[AccountEmployeeTimeEntryPeriod]([AccountId] ASC, [AccountEmployeeId] ASC, [TimeEntryStartDate] ASC, [TimeEntryEndDate] ASC, [TimeEntryViewType] ASC);


GO

CREATE trigger [AuditTriggerAccountEmployeeTimeEntryPeriod] on [dbo].[AccountEmployeeTimeEntryPeriod] for insert, update, delete
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
	
	select @TableName = 'AccountEmployeeTimeEntryPeriod'

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
			select @sql = @sql + 	',' + Replace(Replace(@PKSelect,'<AccountEmployeeTimeEntryPeriodId=',''),'>','')
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