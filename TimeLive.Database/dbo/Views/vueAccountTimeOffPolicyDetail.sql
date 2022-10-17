
CREATE VIEW dbo.vueAccountTimeOffPolicyDetail
AS
SELECT     dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyDetailId, dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyId, 
                      dbo.AccountTimeOffPolicyDetail.AccountTimeOffTypeId, dbo.AccountTimeOffPolicyDetail.SystemEarnPeriodId, 
                      dbo.AccountTimeOffPolicyDetail.SystemResetToZeroTypeId, dbo.AccountTimeOffPolicyDetail.InitialSetToHours, 
                      dbo.AccountTimeOffPolicyDetail.ResetToHours, dbo.AccountTimeOffPolicyDetail.EarnHours, dbo.AccountTimeOffPolicyDetail.CarryOver, 
                      dbo.AccountTimeOffPolicyDetail.MaximumAvailable, dbo.AccountTimeOffPolicyDetail.AccountId, dbo.AccountTimeOffPolicyDetail.CreatedByEmployeeId,
                       dbo.AccountTimeOffPolicyDetail.CreatedOn, dbo.AccountTimeOffPolicyDetail.ModifiedByEmployeeId, dbo.AccountTimeOffPolicyDetail.ModifiedOn, 
                      dbo.AccountTimeOffPolicyDetail.MasterTimeOffPolicyDetailId, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, 
                      dbo.AccountTimeOffPolicy.MasterTimeOffPolicyId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                      dbo.AccountTimeOffType.MasterTimeOffTypeId, dbo.AccountTimeOffPolicyDetail.EffectiveDate, dbo.AccountTimeOffPolicyDetail.IsInclude, 
                      dbo.AccountTimeOffPolicy.IsDisabled, dbo.AccountTimeOffPolicyDetail.AdditionalHours, dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate
FROM         dbo.AccountTimeOffPolicyDetail INNER JOIN
                      dbo.AccountTimeOffPolicy ON dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
                      dbo.AccountTimeOffType ON dbo.AccountTimeOffPolicyDetail.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
WHERE     (dbo.AccountTimeOffType.IsDisabled <> 1)