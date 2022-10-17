CREATE TABLE [dbo].[SystemPermission] (
    [SystemPermissionId] INT            NOT NULL,
    [SystemPermission]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SystemPermission] PRIMARY KEY CLUSTERED ([SystemPermissionId] ASC)
);

