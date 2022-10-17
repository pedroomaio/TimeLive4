CREATE SERVICE [SMEService]
    AUTHORIZATION [dbo]
    ON QUEUE [dbo].[SMEPostQueue]
    ([SMEContract]);

