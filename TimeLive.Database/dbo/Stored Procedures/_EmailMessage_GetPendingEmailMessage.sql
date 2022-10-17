

-- =======================================================
-- ALTER PROCEDURE [dbo].[_EmailMessage_GetPendingEmailMessage]
-- =======================================================
CREATE PROCEDURE [dbo].[_EmailMessage_GetPendingEmailMessage]
AS
SELECT  [ID], [ChangeStamp], [Priority], [Status], 
             [NumberOfRetry], [RetryTime], [MaximumRetry], 
             [ExpiryDatetime], [ArrivedDateTime], [SenderInfo], 
             [EmailTo], [EmailFrom], [EmailSubject], 
             [EmailBody], [EmailCC], [EmailBCC], [IsHtml]
FROM dbo.[EmailMessage]
WHERE  Status = 0 
ORDER BY Priority,RetryTime