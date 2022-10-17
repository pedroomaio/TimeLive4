
CREATE VIEW dbo.VueAccountEmployeeDashboard
AS
SELECT     dbo.AccountEmployeeDashboard.AccountEmployeeDashboardId, dbo.AccountEmployeeDashboard.AccountId, dbo.AccountEmployeeDashboard.AccountEmployeeId, 
                      dbo.AccountEmployeeDashboard.SystemEmployeeDashboardId, dbo.AccountEmployeeDashboard.CreatedOn, 
                      dbo.AccountEmployeeDashboard.CreatedByEmployeeId, dbo.AccountEmployeeDashboard.ModifiedOn, dbo.AccountEmployeeDashboard.ModifiedByEmployeeId, 
                      dbo.SystemEmployeeDashboard.SystemEmployeeDashboardName, dbo.AccountEmployeeDashboard.IsPanelView, dbo.AccountEmployeeDashboard.SortOrder
FROM         dbo.AccountEmployeeDashboard INNER JOIN
                      dbo.SystemEmployeeDashboard ON dbo.AccountEmployeeDashboard.SystemEmployeeDashboardId = dbo.SystemEmployeeDashboard.SystemEmployeeDashboardId