
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingForTimeOff
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TimeEntryDate, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.StartTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EndTime, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Description, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AdministratorApproved, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.CreatedOn, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Rejected, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Submitted, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsTimeOff, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Hours, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeOffRequestId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ApprovalTypeName, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountExternalUserId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EmployeeManagerId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ModifiedOn, 
                      MAX(dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TimeSheetApprovalId) AS TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ApprovedByEmployeeId, MAX(dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Comments) 
                      AS Comments, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsReject, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EMailAddress, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TotalMinutes, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeEntryPeriodId, dbo.AccountTimeOffType.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Available
FROM         dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff LEFT OUTER JOIN
                      dbo.AccountTimeOffType ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalPathId IN
                          (SELECT     TOP (1) AccountApprovalPathId
                            FROM          dbo.vueTimeSheetApprovalSequenceForTimeOff
                            WHERE      (TimeSheetApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeEntryId))) AND 
                      (dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Approved = 0) AND (dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Rejected IS NULL OR
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Rejected = 0) AND (dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Submitted = 1)
GROUP BY dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TimeEntryDate, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.StartTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EndTime, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Description, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AdministratorApproved, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.CreatedOn, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Rejected, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Submitted, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsTimeOff, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Hours, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeOffRequestId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ApprovalTypeName, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountExternalUserId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EmployeeManagerId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ModifiedOn, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.ApprovedByEmployeeId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsReject, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EmployeeName, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountTimeOffType, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.IsApproved, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.AccountEmployeeTimeEntryPeriodId, 
                      dbo.AccountTimeOffType.AccountId, dbo.vueAccountEmployeeTimeEntryApprovalForTimeOff.Available