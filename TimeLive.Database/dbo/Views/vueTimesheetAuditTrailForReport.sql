
CREATE VIEW dbo.vueTimesheetAuditTrailForReport
AS
SELECT     dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.Type, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.TableName, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.PK, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AuditFieldName, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AuditOldValue, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AuditNewValue, 
                      CONVERT(DateTime, CONVERT(VARCHAR(10), dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.UpdateDate, 120), 120) AS UpdateDate, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.TotalTime, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.UserName, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.UpdatedBy, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountId, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.OldValue, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.NewValue, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.FieldName, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.Date, dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountProjectTaskId, dbo.AccountProject.ProjectName, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountEmployee.TimeZoneId, dbo.SystemTimeZone.TimeZoneDifference
FROM         dbo.SystemTimeZone INNER JOIN
                      dbo.AccountEmployee ON dbo.SystemTimeZone.SystemTimeZoneId = dbo.AccountEmployee.TimeZoneId RIGHT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON 
                      dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.vueAccountEmployeeTimeEnryAuditTrailUnionForReport.AccountProjectId = dbo.AccountProject.AccountProjectId