USE [AssetManagementDB]
GO

/****** Object:  Table [dbo].[Assets]    Script Date: 2024/05/16 05:17:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assets](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
	[Make] [varchar](200) NULL,
	[Model] [varchar](200) NULL,
	[SerialNumber] [varchar](200) NULL,
	[Category] [varchar](200) NULL,
	[SubCategory] [varchar](200) NULL,
	[Type] [varchar](200) NULL,
	[Status] [varchar](200) NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


