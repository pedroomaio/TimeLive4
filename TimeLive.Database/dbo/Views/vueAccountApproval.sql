
CREATE VIEW dbo.vueAccountApproval
AS
SELECT     AccountId, MasterAccountApprovalTypeId, AccountApprovalTypeId, ApprovalTypeName, IsTimeOffApprovalTypes
FROM         dbo.AccountApprovalType