CREATE TABLE [dbo].[AccountEmployeeExpenseSheet] (
    [AccountEmployeeExpenseSheetId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeExpenseSheet_AccountEmployeeExpenseSheetId] DEFAULT (newid()) NOT NULL,
    [AccountId]                     INT              NOT NULL,
    [AccountEmployeeId]             INT              NOT NULL,
    [Description]                   NVARCHAR (500)   NOT NULL,
    [ExpenseSheetDate]              DATETIME         NOT NULL,
    [Approved]                      BIT              CONSTRAINT [DF_AccountEmployeeExpenseSheet_Approved] DEFAULT ((0)) NOT NULL,
    [Rejected]                      BIT              CONSTRAINT [DF_AccountEmployeeExpenseSheet_Rejected] DEFAULT ((0)) NOT NULL,
    [Submitted]                     BIT              CONSTRAINT [DF_AccountEmployeeExpenseSheet_Submitted] DEFAULT ((0)) NOT NULL,
    [InApproval]                    BIT              CONSTRAINT [DF_AccountEmployeeExpenseSheet_InApproval] DEFAULT ((0)) NOT NULL,
    [CreatedByEmployeeId]           INT              NULL,
    [CreatedOn]                     DATETIME         CONSTRAINT [DF_AccountEmployeeExpenseSheet_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedByEmployeeId]          INT              NULL,
    [ModifiedOn]                    DATETIME         CONSTRAINT [DF_AccountEmployeeExpenseSheet_ModifiedOn] DEFAULT (getdate()) NULL,
    [SubmittedDate]                 DATETIME         NULL,
    [ApprovedOn]                    DATETIME         NULL,
    [ApprovedByEmployeeId]          INT              NULL,
    [RejectedOn]                    DATETIME         NULL,
    [RejectedByEmployeeId]          INT              NULL,
    [CustomField1]                  NVARCHAR (2000)  NULL,
    [CustomField2]                  NVARCHAR (2000)  NULL,
    [CustomField3]                  NVARCHAR (2000)  NULL,
    [CustomField4]                  NVARCHAR (2000)  NULL,
    [CustomField5]                  NVARCHAR (2000)  NULL,
    [CustomField6]                  NVARCHAR (2000)  NULL,
    [CustomField7]                  NVARCHAR (2000)  NULL,
    [CustomField8]                  NVARCHAR (2000)  NULL,
    [CustomField9]                  NVARCHAR (2000)  NULL,
    [CustomField10]                 NVARCHAR (2000)  NULL,
    [CustomField11]                 NVARCHAR (2000)  NULL,
    [CustomField12]                 NVARCHAR (2000)  NULL,
    [CustomField13]                 NVARCHAR (2000)  NULL,
    [CustomField14]                 NVARCHAR (2000)  NULL,
    [CustomField15]                 NVARCHAR (2000)  NULL,
    CONSTRAINT [PK_AccountEmployeeExpenseSheet] PRIMARY KEY CLUSTERED ([AccountEmployeeExpenseSheetId] ASC),
    CONSTRAINT [FK_AccountEmployeeExpenseSheet_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEmployeeExpenseSheet_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId_1]
    ON [dbo].[AccountEmployeeExpenseSheet]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId_1]
    ON [dbo].[AccountEmployeeExpenseSheet]([AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployee_AccountId]
    ON [dbo].[AccountEmployeeExpenseSheet]([AccountEmployeeId] ASC, [AccountId] ASC);


GO

CREATE trigger [AuditTriggerAccountEmployeeExpenseSheet] on [dbo].[AccountEmployeeExpenseSheet] for insert, update, delete
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
	
	select @TableName = 'AccountEmployeeExpenseSheet'

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
			select @sql = @sql + 	',' + Replace(Replace(@PKSelect,'<AccountEmployeeExpenseSheetId=',''),'>','')
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