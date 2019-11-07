

/****** Object:  Table [dbo].[BindImage]    Script Date: 07/20/2012 17:19:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BindImage](
	[Pk_id] [int] IDENTITY(1,1) NOT NULL,
	[ImgName] [varchar](50) NULL,
	[ImgPath] [varchar](100) NULL,
	[ImgDesc] [varchar](200) NULL,
	[ImgCategory] [varchar](50) NULL,
	[ImgCategoryId] [varchar](10) NULL,
 CONSTRAINT [PK_BindImage] PRIMARY KEY CLUSTERED 
(
	[Pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

