
CREATE VIEW dbo.vueAccountEmployeeTimeEntryCurrentApprover
AS
Select FirstName + ' ' + LastName as ApproverEmployeeName,TimesheetApprover.* from
(
Select 
case when SystemApproverTypeId = 1 then AccountProject.LeaderEmployeeId
when SystemApproverTypeId = 2 then AccountProject.ProjectManagerEmployeeId
when SystemApproverTypeId = 3 then AccountApprovalPath.AccountEmployeeId
when SystemApproverTypeId = 4 then AccountApprovalPath.AccountExternalUserId 
when SystemApproverTypeId = 5 then EM.AccountEmployeeId End as ApproverEmployeeID,
 CASE WHEN systemapprovertypeid = 1 THEN 'TL' WHEN systemapprovertypeid = 2 THEN 'PM' WHEN systemapprovertypeid
                       = 3 THEN 'SEM' WHEN systemapprovertypeid = 4 THEN 'SEU' WHEN systemapprovertypeid = 5 THEN 'EM'
                       END AS ApproverType, ApprovalPathSequence ,
AccountEmployeeTimeEntryId from AccountEmployeeTimeEntry
left outer join AccountProject on AccountProject.AccountProjectId = AccountEmployeeTimeEntry.AccountProjectId
left outer join AccountApprovalType on AccountApprovalType.AccountApprovalTypeId = AccountProject.TimeSheetApprovalTypeId
left outer join AccountApprovalPath on AccountApprovalPath.AccountApprovalTypeId = AccountApprovalType.AccountApprovalTypeId 
left outer join AccountEmployee on AccountEmployee.AccountEmployeeId = AccountEmployeeTimeEntry.AccountEmployeeId
left outer join AccountEmployee as EM on EM.AccountEmployeeId = AccountEmployee.EmployeeManagerId
where 
  (ApprovalPathSequence IN
                          (SELECT     TOP (1) ApprovalPathSequence
                            FROM          dbo.vueTimesheetSequenceForApproval
                            WHERE      (TimeSheetApprovalId IS NULL) AND (AccountProjectId = AccountEmployeeTimeEntry.AccountProjectId) AND 
                                                   (AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId)))
)TimesheetApprover 
left outer join dbo.AccountEmployee on ApproverEmployeeID = dbo.AccountEmployee.AccountEmployeeId