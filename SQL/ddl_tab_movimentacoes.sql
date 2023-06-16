USE [DbMovCon]
GO

/****** Object:  Table [dbo].[Movimentacoes]    Script Date: 16/06/2023 10:34:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movimentacoes](
	[PK_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](11) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[DataHoraInicio] [datetime2](7) NOT NULL,
	[DataHoraFim] [datetime2](7) NULL,
	[TipoConteiner] [varchar](10) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[Categoria] [varchar](20) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Movimentacoes]  WITH CHECK ADD  CONSTRAINT [FK_Numero] FOREIGN KEY([Numero])
REFERENCES [dbo].[Conteineres] ([Numero])
GO

ALTER TABLE [dbo].[Movimentacoes] CHECK CONSTRAINT [FK_Numero]
GO


