CREATE TABLE [dbo].[SystemBillingRateType] (
    [SystemBillingRateTypeId] SMALLINT       NOT NULL,
    [SystemBillingRateType]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SystemBillingRateType] PRIMARY KEY CLUSTERED ([SystemBillingRateTypeId] ASC)
);

