CREATE TABLE [dbo].[SystemSecurityCategory] (
    [SystemSecurityCategoryId] INT            IDENTITY (1, 1) NOT NULL,
    [SystemSecurityCategory]   NVARCHAR (100) NOT NULL,
    [IsSiteMapPage]            BIT            NULL,
    CONSTRAINT [PK_SystemSecurityCategory] PRIMARY KEY CLUSTERED ([SystemSecurityCategoryId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemSecurityCategory_IsSiteMapPag]
    ON [dbo].[SystemSecurityCategory]([IsSiteMapPage] ASC);

