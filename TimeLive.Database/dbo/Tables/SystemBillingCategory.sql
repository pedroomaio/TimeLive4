CREATE TABLE [dbo].[SystemBillingCategory] (
    [SystemBillingCategoryId] TINYINT        NOT NULL,
    [SystemBillingCategory]   NVARCHAR (300) NOT NULL,
    CONSTRAINT [PK_SystemBillingType] PRIMARY KEY CLUSTERED ([SystemBillingCategoryId] ASC)
);

