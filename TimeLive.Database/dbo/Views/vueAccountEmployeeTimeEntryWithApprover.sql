
CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithApprover
AS
select case when TimeEntryApprover.SystemApproverTypeId = 5 then 'SystemApproverTypeId5' else e.FirstName + ' ' + e.LastName end as ApproverEmployeeName, TimeEntryApprover.* from
(
select 
c.SystemApproverTypeID,
c.ApprovalPathSequence,
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid
                       = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN 0
                       END AS ApproverEmployeeId,
                       CASE WHEN systemapprovertypeid = 1 THEN 'TL' WHEN systemapprovertypeid = 2 THEN 'PM' WHEN systemapprovertypeid
                       = 3 THEN 'SEM' WHEN systemapprovertypeid = 4 THEN 'SEU' WHEN systemapprovertypeid = 5 THEN 'EM'
                       END AS ApproverType,
                       a.AccountProjectId, a.AccountId

 from AccountProject a 
left outer join AccountApprovalType b on a.TimeSheetApprovalTypeId = b.AccountApprovalTypeId 
left outer join AccountApprovalPath c on b.AccountApprovalTypeId = c.AccountApprovalTypeId 

)  TimeEntryApprover
 left outer join AccountEmployee E on TimeEntryApprover.ApproverEmployeeId = e.AccountEmployeeId