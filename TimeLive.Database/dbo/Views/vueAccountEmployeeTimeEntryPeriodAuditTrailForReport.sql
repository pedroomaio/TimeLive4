
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPeriodAuditTrailForReport
AS
SELECT     dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldValue, 
                      dbo.Audit.NewValue AS AuditNewValue, dbo.Audit.UpdateDate, NULL AS AccountProjectId, NULL AS AccountProjectTaskId, NULL AS TotalTime, 
                      dbo.Audit.UserName, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS UpdatedBy, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, 
                      CASE WHEN FieldName = 'SubmittedBy' THEN AccountEmployeeOld.FirstName + ' ' + AccountEmployeeOld.LastName WHEN FieldName = 'ApprovedByEmployeeId'
                       THEN AccountEmployeeOld.FirstName + ' ' + AccountEmployeeOld.LastName WHEN FieldName = 'RejectedByEmployeeId' THEN AccountEmployeeOld.FirstName
                       + ' ' + AccountEmployeeOld.LastName WHEN FieldName = 'Submitted' THEN CASE WHEN Audit.OldValue <> '1' THEN 'No' WHEN Audit.OldValue = '1' THEN
                       'Yes' END WHEN FieldName = 'Approved' THEN CASE WHEN Audit.OldValue <> '1' THEN 'No' WHEN Audit.OldValue = '1' THEN 'Yes' END WHEN FieldName
                       = 'Rejected' THEN CASE WHEN Audit.OldValue <> '1' THEN 'No' WHEN Audit.OldValue = '1' THEN 'Yes' END ELSE Audit.OldValue END AS OldValue, 
                      CASE WHEN FieldName = 'SubmittedBy' THEN AccountEmployeeNew.FirstName + ' ' + AccountEmployeeNew.LastName WHEN FieldName = 'ApprovedByEmployeeId'
                       THEN AccountEmployeeNew.FirstName + ' ' + AccountEmployeeNew.LastName WHEN FieldName = 'RejectedByEmployeeId' THEN AccountEmployeeNew.FirstName
                       + ' ' + AccountEmployeeNew.LastName WHEN FieldName = 'Submitted' THEN CASE WHEN Audit.NewValue <> '1' THEN 'No' WHEN Audit.NewValue = '1'
                       THEN 'Yes' END WHEN FieldName = 'Approved' THEN CASE WHEN Audit.NewValue <> '1' THEN 'No' WHEN Audit.NewValue = '1' THEN 'Yes' END WHEN
                       FieldName = 'Rejected' THEN CASE WHEN Audit.NewValue <> '1' THEN 'No' WHEN Audit.NewValue = '1' THEN 'Yes' END ELSE Audit.NewValue END AS
                       NewValue, 
                      CASE WHEN FieldName = 'SubmittedBy' THEN 'Submitted By' WHEN FieldName = 'ApprovedByEmployeeId' THEN 'Approved By' WHEN FieldName = 'RejectedByEmployeeId'
                       THEN 'Rejected By' ELSE Audit.FieldName END AS FieldName, CONVERT(varchar, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 106) 
                      + ' - ' + CONVERT(varchar, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 106) AS Date
FROM         dbo.AccountEmployeeTimeEntryPeriod RIGHT OUTER JOIN
                      dbo.Audit ON dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = dbo.Audit.PK LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployeeOld ON dbo.Audit.OldValue = CONVERT(nvarchar(50), AccountEmployeeOld.AccountEmployeeId) 
                      LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployeeNew ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountEmployeeNew.AccountEmployeeId) 
                      LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.Audit.UserName = dbo.AccountEmployee.AccountEmployeeId
WHERE     (dbo.Audit.TableName = 'AccountEmployeeTimeEntryPeriod ') AND (dbo.Audit.FieldName IN ('Submitted', 'Approved', 'Rejected', 'SubmittedDate', 
                      'ApprovedOn', 'RejectedOn', 'SubmittedBy', 'ApprovedByEmployeeId', 'RejectedByEmployeeId', 'PeriodDescription'))