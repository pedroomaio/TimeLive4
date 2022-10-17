
CREATE VIEW dbo.vueAccountStatus
AS
SELECT     dbo.AccountStatus.AccountStatusId, dbo.AccountStatus.AccountId, dbo.AccountStatus.StatusTypeId, dbo.AccountStatus.Status, 
                      dbo.SystemStatusType.SystemStatusType, dbo.AccountStatus.IsDisabled, dbo.AccountStatus.MasterAccountStatusId
FROM         dbo.AccountStatus LEFT OUTER JOIN
                      dbo.SystemStatusType ON dbo.AccountStatus.StatusTypeId = dbo.SystemStatusType.SystemStatusTypeId