USE [DbMovCon]
GO

/****** Object:  Table [dbo].[Conteineres]    Script Date: 16/06/2023 10:34:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Conteineres](
	[PK_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](50) NOT NULL,
	[Numero] [varchar](11) NOT NULL,
	[Tipo] [varchar](10) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[Categoria] [varchar](15) NOT NULL,
 CONSTRAINT [AK_Numero] UNIQUE NONCLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


