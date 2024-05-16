USE [AssetManagementDB]
GO

/****** Object:  Table [dbo].[AssetAllocation]    Script Date: 2024/05/16 05:17:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AssetAllocation](
	[AssetId] [uniqueidentifier] NOT NULL,
	[AssetOwnerId] [uniqueidentifier] NOT NULL,
	[AllocationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AssetAllocation] PRIMARY KEY CLUSTERED 
(
	[AssetId] ASC,
	[AssetOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AssetAllocation]  WITH CHECK ADD  CONSTRAINT [FK_AssetAllocation_AssetOwner] FOREIGN KEY([AssetOwnerId])
REFERENCES [dbo].[AssetOwner] ([Id])
GO

ALTER TABLE [dbo].[AssetAllocation] CHECK CONSTRAINT [FK_AssetAllocation_AssetOwner]
GO

ALTER TABLE [dbo].[AssetAllocation]  WITH CHECK ADD  CONSTRAINT [FK_AssetAllocation_Assets] FOREIGN KEY([AssetId])
REFERENCES [dbo].[Assets] ([Id])
GO

ALTER TABLE [dbo].[AssetAllocation] CHECK CONSTRAINT [FK_AssetAllocation_Assets]
GO


