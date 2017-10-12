USE [sigmeh]
GO

/****** Object:  Table [dbo].[CanalComunicacaoTipo]    Script Date: 18/11/2013 22:39:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CanalComunicacaoTipo](
	[CanalComunicacaoTipoID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[UsuarioCriadorID] [int] NOT NULL,
	[DataModificacao] [datetime] NOT NULL,
	[UsuarioModificadorID] [int] NOT NULL,
 CONSTRAINT [PK_CanalComunicacaoTipo_CanalComunicacaoTipoID] PRIMARY KEY CLUSTERED 
(
	[CanalComunicacaoTipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CanalComunicacaoTipo] ADD  CONSTRAINT [DF_CanalComunicacaoTipo_DataCriacao]  DEFAULT (getdate()) FOR [DataCriacao]
GO

ALTER TABLE [dbo].[CanalComunicacaoTipo] ADD  CONSTRAINT [DF_CanalComunicacaoTipo_DataModificacao]  DEFAULT (getdate()) FOR [DataModificacao]
GO

ALTER TABLE [dbo].[CanalComunicacaoTipo]  WITH CHECK ADD  CONSTRAINT [FK_CanalComunicacaoTipo_Entidade] FOREIGN KEY([UsuarioCriadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[CanalComunicacaoTipo] CHECK CONSTRAINT [FK_CanalComunicacaoTipo_Entidade]
GO

ALTER TABLE [dbo].[CanalComunicacaoTipo]  WITH CHECK ADD  CONSTRAINT [FK_CanalComunicacaoTipo_Entidade1] FOREIGN KEY([UsuarioModificadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[CanalComunicacaoTipo] CHECK CONSTRAINT [FK_CanalComunicacaoTipo_Entidade1]
GO

