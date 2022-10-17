CREATE TABLE [dbo].[AccountCustomField] (
    [AccountCustomFieldId]   UNIQUEIDENTIFIER CONSTRAINT [DF_AccountCustomField_AccountCustomFieldId] DEFAULT (newid()) NOT NULL,
    [AccountId]              INT              NOT NULL,
    [MasterCustomDataTypeId] UNIQUEIDENTIFIER NOT NULL,
    [MasterEntityTypeId]     UNIQUEIDENTIFIER NOT NULL,
    [DatabaseFieldName]      NVARCHAR (100)   NOT NULL,
    [CustomFieldName]        NVARCHAR (100)   NOT NULL,
    [CustomFieldCaption]     NVARCHAR (100)   NOT NULL,
    [DefaultValue]           NVARCHAR (500)   NULL,
    [MaximumLength]          INT              NULL,
    [MinimumValue]           INT              NULL,
    [MaximumValue]           INT              NULL,
    [DropDownOptions]        NVARCHAR (3000)  NULL,
    [IsRequired]             BIT              NULL,
    [IsDisabled]             BIT              NULL,
    [CreatedOn]              DATETIME         NOT NULL,
    [CreatedByEmployeeId]    INT              NOT NULL,
    [ModifiedOn]             DATETIME         NOT NULL,
    [ModifiedByEmployeeId]   INT              NOT NULL,
    CONSTRAINT [PK_AccountCustomField] PRIMARY KEY CLUSTERED ([AccountCustomFieldId] ASC),
    CONSTRAINT [FK_AccountCustomField_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountCustomField_MasterCustomDataType] FOREIGN KEY ([MasterCustomDataTypeId]) REFERENCES [dbo].[MasterCustomDataType] ([MasterCustomDataTypeId]),
    CONSTRAINT [FK_AccountCustomField_MasterEntityType] FOREIGN KEY ([MasterEntityTypeId]) REFERENCES [dbo].[MasterEntityType] ([MasterEntityTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ModifiedOn]
    ON [dbo].[AccountCustomField]([ModifiedOn] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ModifiedByEmployeeId]
    ON [dbo].[AccountCustomField]([ModifiedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MinimumValue]
    ON [dbo].[AccountCustomField]([MinimumValue] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MaximumValue]
    ON [dbo].[AccountCustomField]([MaximumValue] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MaximumLenght]
    ON [dbo].[AccountCustomField]([MaximumLength] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MasterEntityTypeId]
    ON [dbo].[AccountCustomField]([MasterEntityTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MasterCustomDataTypeId]
    ON [dbo].[AccountCustomField]([MasterCustomDataTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsRequired]
    ON [dbo].[AccountCustomField]([IsRequired] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsDisabled]
    ON [dbo].[AccountCustomField]([IsDisabled] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DatabaseFieldName]
    ON [dbo].[AccountCustomField]([DatabaseFieldName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomFieldName]
    ON [dbo].[AccountCustomField]([CustomFieldName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomFieldCaption]
    ON [dbo].[AccountCustomField]([CustomFieldCaption] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatedOn]
    ON [dbo].[AccountCustomField]([CreatedOn] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatedByEmployeeId]
    ON [dbo].[AccountCustomField]([CreatedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountCustomField]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountCustomFieldId]
    ON [dbo].[AccountCustomField]([AccountCustomFieldId] ASC);

