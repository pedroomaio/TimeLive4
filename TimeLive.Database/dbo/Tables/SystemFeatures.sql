CREATE TABLE [dbo].[SystemFeatures] (
    [SystemFeatureId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemFeatures_SystemFeatureId] DEFAULT (newid()) NOT NULL,
    [SystemFeatureName] NVARCHAR (100)   NULL,
    [SortOrder]         INT              NULL,
    CONSTRAINT [PK_SystemFeatures] PRIMARY KEY CLUSTERED ([SystemFeatureId] ASC)
);

