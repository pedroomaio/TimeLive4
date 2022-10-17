CREATE TABLE [dbo].[MasterCostCenter] (
    [MasterCostCenterId]   SMALLINT       NOT NULL,
    [MasterCostCenterCode] NVARCHAR (14)  NOT NULL,
    [MasterCostCenter]     NVARCHAR (100) NOT NULL,
    [MasterSortOrder]      SMALLINT       NULL,
    CONSTRAINT [PK_MasterCostCenter] PRIMARY KEY CLUSTERED ([MasterCostCenterId] ASC)
);

