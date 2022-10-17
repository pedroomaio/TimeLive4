CREATE TABLE [dbo].[MasterAccountBillingType] (
    [MasterAccountBillingTypeId] SMALLINT       NOT NULL,
    [TemplateId]                 SMALLINT       NOT NULL,
    [BillingCategoryId]          TINYINT        NOT NULL,
    [BillingType]                NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MasterAccountBillingType] PRIMARY KEY CLUSTERED ([MasterAccountBillingTypeId] ASC)
);

