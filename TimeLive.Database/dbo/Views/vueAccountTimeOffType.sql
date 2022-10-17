
CREATE VIEW dbo.vueAccountTimeOffType
AS
SELECT     dbo.AccountTimeOffType.AccountTimeOffTypeId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                      dbo.AccountTimeOffType.AccountId, dbo.AccountTimeOffType.CreatedByEmployeeId, dbo.AccountTimeOffType.CreatedOn, 
                      dbo.AccountTimeOffType.ModifiedByEmployeeId, dbo.AccountTimeOffType.ModifiedOn, dbo.AccountTimeOffType.IsDisabled, 
                      dbo.AccountTimeOffType.MasterTimeOffTypeId
FROM         dbo.AccountEmployeeTimeOff RIGHT OUTER JOIN
                      dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
WHERE     (dbo.AccountEmployeeTimeOff.IsDisabled <> 1)