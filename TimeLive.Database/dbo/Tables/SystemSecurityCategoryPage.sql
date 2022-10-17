CREATE TABLE [dbo].[SystemSecurityCategoryPage] (
    [SystemSecurityCategoryPageId]        INT              NOT NULL,
    [SystemSecurityCategoryId]            INT              NOT NULL,
    [SequenceNumber]                      NVARCHAR (20)    NULL,
    [Folder]                              NVARCHAR (100)   NOT NULL,
    [SystemCategoryPage]                  VARCHAR (200)    NULL,
    [SystemCategoryPageDescription]       VARCHAR (200)    NULL,
    [ParentSystemSecurityCateogoryPageId] INT              NULL,
    [IsSiteMapPage]                       BIT              NULL,
    [IsCustomizeable]                     BIT              NULL,
    [IsAllowAdd]                          BIT              NULL,
    [IsAllowEdit]                         BIT              NULL,
    [IsAllowDelete]                       BIT              NULL,
    [IsAllowList]                         BIT              NULL,
    [IsShowDataOptions]                   BIT              NULL,
    [IsShowTillOptions]                   BIT              NULL,
    [IsSystemPage]                        BIT              NULL,
    [ControlLevelPermission]              BIT              NULL,
    [NotShowInPermission]                 BIT              NULL,
    [NotShowInStartupPage]                BIT              NULL,
    [SystemFeatureId]                     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_SystemSecurityCategoryPage] PRIMARY KEY CLUSTERED ([SystemSecurityCategoryPageId] ASC),
    CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory] FOREIGN KEY ([SystemSecurityCategoryId]) REFERENCES [dbo].[SystemSecurityCategory] ([SystemSecurityCategoryId]),
    CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1] FOREIGN KEY ([SystemSecurityCategoryId]) REFERENCES [dbo].[SystemSecurityCategory] ([SystemSecurityCategoryId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryPage_SystemSecurityCategoryId]
    ON [dbo].[SystemSecurityCategoryPage]([SystemSecurityCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryPage_ParentSystemSecurityCateogoryPageId]
    ON [dbo].[SystemSecurityCategoryPage]([ParentSystemSecurityCateogoryPageId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryPage_IsSiteMapPage]
    ON [dbo].[SystemSecurityCategoryPage]([IsSiteMapPage] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryPage_ControlLevelPermission]
    ON [dbo].[SystemSecurityCategoryPage]([ControlLevelPermission] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategoryPage_SequenceNumber]
    ON [dbo].[SystemSecurityCategoryPage]([SequenceNumber] ASC);

