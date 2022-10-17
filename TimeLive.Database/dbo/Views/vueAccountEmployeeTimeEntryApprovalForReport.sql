
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalForReport
AS
SELECT     dbo.AccountEmployeeTimeEntryApproval.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProject.AccountId, 
                      dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId, dbo.AccountProject.AccountClientId, dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick, 
                      CASE WHEN AccountEmployee.IsDisabled = 1 THEN AccountEmployee.FirstName + ' ' + AccountEmployee.LastName + ' ' + '(Disabled)' ELSE AccountEmployee.FirstName
                       + ' ' + AccountEmployee.LastName END AS EmployeeName, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApprovalEmployeeName, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.AccountEmployeeTimeEntryApproval.ApprovedOn, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, dbo.AccountEmployeeTimeEntryApproval.IsApproved, 
                      dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryApproval.PreviousStatus, 
                      dbo.AccountEmployeeTimeEntryApproval.BatchId, ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeNameWithCode, dbo.AccountEmployee.IsDisabled
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId RIGHT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 INNER JOIN
                      dbo.AccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntryApproval.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      AccountEmployee_1.AccountEmployeeId = dbo.AccountEmployeeTimeEntryApproval.ApprovedByEmployeeId ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId