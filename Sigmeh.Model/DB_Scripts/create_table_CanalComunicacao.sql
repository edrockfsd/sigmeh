USE [sigmeh]
GO

/****** Object:  Table [dbo].[CanalComunicacao]    Script Date: 18/11/2013 22:38:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CanalComunicacao](
	[EntidadeID] [int] NOT NULL,
	[CanalComunicacaoID] [int] IDENTITY(1,1) NOT NULL,
	[CanalComunicacaoTipoID] [int] NOT NULL,
	[Descricao] [varchar](50) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[UsuarioCriadorID] [int] NOT NULL,
	[DataModificacao] [datetime] NOT NULL,
	[UsuarioModificadorID] [int] NOT NULL,
	[Principal] [bit] NOT NULL,
 CONSTRAINT [PK_CanalComunicacao_CanalComunicacaoID] PRIMARY KEY CLUSTERED 
(
	[EntidadeID] ASC,
	[CanalComunicacaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CanalComunicacao] ADD  CONSTRAINT [DF_CanalComunicacao_DataCriacao]  DEFAULT (getdate()) FOR [DataCriacao]
GO

ALTER TABLE [dbo].[CanalComunicacao] ADD  CONSTRAINT [DF_CanalComunicacao_DataModificacao]  DEFAULT (getdate()) FOR [DataModificacao]
GO

ALTER TABLE [dbo].[CanalComunicacao]  WITH CHECK ADD  CONSTRAINT [FK_CanalComunicacao_CanalComunicacaoTipo] FOREIGN KEY([CanalComunicacaoTipoID])
REFERENCES [dbo].[CanalComunicacaoTipo] ([CanalComunicacaoTipoID])
GO

ALTER TABLE [dbo].[CanalComunicacao] CHECK CONSTRAINT [FK_CanalComunicacao_CanalComunicacaoTipo]
GO

ALTER TABLE [dbo].[CanalComunicacao]  WITH CHECK ADD  CONSTRAINT [FK_CanalComunicacao_Entidade] FOREIGN KEY([UsuarioCriadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[CanalComunicacao] CHECK CONSTRAINT [FK_CanalComunicacao_Entidade]
GO

ALTER TABLE [dbo].[CanalComunicacao]  WITH CHECK ADD  CONSTRAINT [FK_CanalComunicacao_Entidade_EntidadeID] FOREIGN KEY([EntidadeID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[CanalComunicacao] CHECK CONSTRAINT [FK_CanalComunicacao_Entidade_EntidadeID]
GO

ALTER TABLE [dbo].[CanalComunicacao]  WITH CHECK ADD  CONSTRAINT [FK_CanalComunicacao_Entidade1] FOREIGN KEY([UsuarioModificadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[CanalComunicacao] CHECK CONSTRAINT [FK_CanalComunicacao_Entidade1]
GO

