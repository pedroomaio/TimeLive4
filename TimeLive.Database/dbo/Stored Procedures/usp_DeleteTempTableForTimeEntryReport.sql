
Create PROCEDURE [dbo].[usp_DeleteTempTableForTimeEntryReport]
    (
    @AccountEmployeeId integer
	)
AS
   
declare @TableName1 nvarchar(500),@TableName2 nvarchar(500),@TableName3 nvarchar(500),@TableName4 nvarchar(500)

set @TableName1 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_1'
set @TableName2 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_2'
set @TableName3 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_3'
set @TableName4 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_4'



IF EXISTS (select 1 from information_schema.tables where table_name = @TableName1 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName1)
IF EXISTS (select 1 from information_schema.tables where table_name = @TableName2 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName2)
IF EXISTS (select 1 from information_schema.tables where table_name = @TableName3 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName3)
IF EXISTS (select 1 from information_schema.tables where table_name = @TableName4 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName4)