CREATE TABLE [dbo].[Audit] (
    [Type]       NVARCHAR (2)    NULL,
    [TableName]  NVARCHAR (256)  NULL,
    [PK]         VARCHAR (50)    NULL,
    [FieldName]  NVARCHAR (256)  NULL,
    [OldValue]   NVARCHAR (2000) NULL,
    [NewValue]   NVARCHAR (2000) NULL,
    [UpdateDate] DATETIME        NULL,
    [UserName]   INT             NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Audit]
    ON [dbo].[Audit]([Type] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PK]
    ON [dbo].[Audit]([PK] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TableName]
    ON [dbo].[Audit]([TableName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FieldName]
    ON [dbo].[Audit]([FieldName] ASC);


GO
CREATE STATISTICS [_dta_stat_1381579960_3_2_7]
    ON [dbo].[Audit]([PK], [TableName], [UpdateDate]);


GO
CREATE STATISTICS [_dta_stat_1381579960_7_2]
    ON [dbo].[Audit]([UpdateDate], [TableName]);


GO
CREATE STATISTICS [_dta_stat_1381579960_4_7]
    ON [dbo].[Audit]([FieldName], [UpdateDate]);

