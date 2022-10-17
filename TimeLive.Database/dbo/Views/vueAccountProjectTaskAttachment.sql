CREATE VIEW dbo.vueAccountProjectTaskAttachment
AS
SELECT     dbo.AccountProjectTaskAttachment.AccountProjectTaskAttachmentId, dbo.AccountProjectTaskAttachment.AccountProjectTaskId, 
                      dbo.AccountProjectTaskAttachment.AttachmentName, dbo.AccountProjectTaskAttachment.AttachmentLocalPath, 
                      dbo.AccountProjectTaskAttachment.CreatedOn, dbo.AccountProjectTaskAttachment.CreatedByEmployeeId, 
                      dbo.AccountProjectTaskAttachment.ModifiedOn, dbo.AccountProjectTaskAttachment.ModifiedByEmployeeId, dbo.AccountProjectTask.AccountProjectId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountEmployee.AccountId
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTaskAttachment ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskAttachment.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProject RIGHT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId ON 
                      dbo.AccountProjectTaskAttachment.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId