USE [AssetManagementDB]
GO

/****** Object:  Table [dbo].[AssetOwner]    Script Date: 2024/05/16 05:17:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AssetOwner](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [varchar](250) NOT NULL,
	[Email] [varchar](250) NULL,
	[PhoneNumber] [varchar](250) NULL,
	[Department] [varchar](250) NULL,
 CONSTRAINT [PK_AssetOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


