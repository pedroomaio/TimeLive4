
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalWithProject
AS
SELECT     dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId, dbo.AccountEmployeeTimeEntryApproval.ApprovedOn, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId, 
                      dbo.AccountEmployeeTimeEntryApproval.AccountProjectId, dbo.AccountEmployeeTimeEntryApproval.PreviousStatus, 
                      dbo.AccountEmployeeTimeEntryApproval.BatchId, dbo.AccountEmployeeTimeEntryApproval.ApprovalPathSequence, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode
FROM         dbo.AccountEmployeeTimeEntryApproval LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntryApproval.AccountProjectId = dbo.AccountProject.AccountProjectId