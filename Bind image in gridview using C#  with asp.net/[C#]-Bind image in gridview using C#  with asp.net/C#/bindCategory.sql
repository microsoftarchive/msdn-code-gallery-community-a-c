

/****** Object:  Table [dbo].[bindCategory]    Script Date: 07/20/2012 17:19:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[bindCategory](
	[pk_id] [int] IDENTITY(1,1) NOT NULL,
	[ImgCategory] [varchar](50) NULL,
	[ImgCategoryId] [varchar](30) NULL,
 CONSTRAINT [PK_bindCategory] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

