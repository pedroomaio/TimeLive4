CREATE TABLE [dbo].[AccountFeatures] (
    [AccountFeatureId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountFeatures_AccountFeatureId] DEFAULT (newid()) NOT NULL,
    [AccountId]        INT              NULL,
    [SystemFeatureId]  UNIQUEIDENTIFIER NULL,
    [SortOrder]        INT              NULL,
    CONSTRAINT [PK_AccountFeatures] PRIMARY KEY CLUSTERED ([AccountFeatureId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemFeatures]
    ON [dbo].[AccountFeatures]([SystemFeatureId] ASC, [AccountId] ASC);

