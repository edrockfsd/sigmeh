USE [sigmeh]
GO

/****** Object:  Table [dbo].[Criticidade]    Script Date: 18/11/2013 22:39:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Criticidade](
	[CriticidadeID] [int] IDENTITY(1,1) NOT NULL,
	[TempoMaximoManutencao] [int] NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Observacao] [varchar](250) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[UsuarioCriadorID] [int] NOT NULL,
	[DataModificacao] [datetime] NOT NULL,
	[UsuarioModificadorID] [int] NOT NULL,
 CONSTRAINT [PK_Criticidade_CriticidadeID] PRIMARY KEY CLUSTERED 
(
	[CriticidadeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Criticidade] ADD  CONSTRAINT [DF_Criticidade_DataCriacao]  DEFAULT (getdate()) FOR [DataCriacao]
GO

ALTER TABLE [dbo].[Criticidade] ADD  CONSTRAINT [DF_Criticidade_DataModificacao]  DEFAULT (getdate()) FOR [DataModificacao]
GO

ALTER TABLE [dbo].[Criticidade]  WITH CHECK ADD  CONSTRAINT [FK_Criticidade_Entidade] FOREIGN KEY([UsuarioCriadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[Criticidade] CHECK CONSTRAINT [FK_Criticidade_Entidade]
GO

ALTER TABLE [dbo].[Criticidade]  WITH CHECK ADD  CONSTRAINT [FK_Criticidade_Entidade1] FOREIGN KEY([UsuarioModificadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[Criticidade] CHECK CONSTRAINT [FK_Criticidade_Entidade1]
GO

