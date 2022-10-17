
CREATE VIEW dbo.ViewAccountEmployeeTimeOffApprovalPending
AS
SELECT     dbo.vueAccountApproverType.AccountApprovalTypeId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsTimeOff, 
                      dbo.vueAccountApproverType.AccountId
FROM         dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff INNER JOIN
                      dbo.vueAccountEmployeeTimeOffRequestApproval ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalTypeId = dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalTypeId INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeOffRequestApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId AND 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
GROUP BY dbo.vueAccountApproverType.AccountApprovalTypeId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsTimeOff, dbo.vueAccountApproverType.AccountId