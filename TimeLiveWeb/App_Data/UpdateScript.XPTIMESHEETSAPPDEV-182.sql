
GO

/****** Object:  Table [dbo].[TimeOffAttachments]    Script Date: 17/02/2017 12:00:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimeOffAttachments](
	[TimeOffAttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[TimeEntryId] [int] NULL,
	[AttachmentName] [nvarchar](1000) NOT NULL,
	[AttachmentLocalPath] [nvarchar](1000) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedByEmployeeId] [int] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedByEmployeeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TimeOffAttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TimeOffAttachments]  WITH CHECK ADD FOREIGN KEY([TimeEntryId])
REFERENCES [dbo].[AccountEmployeeTimeEntry] ([AccountEmployeeTimeEntryId])
ON DELETE CASCADE
GO


