USE [sigmeh]
GO

/****** Object:  Table [dbo].[EnderecoTipo]    Script Date: 18/11/2013 22:40:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EnderecoTipo](
	[EnderecoTipoID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[UsuarioCriadorID] [int] NOT NULL,
	[DataModificacao] [datetime] NOT NULL,
	[UsuarioModificadorID] [int] NOT NULL,
 CONSTRAINT [PK_EnderecoTipo_EnderecoTipoID] PRIMARY KEY CLUSTERED 
(
	[EnderecoTipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EnderecoTipo] ADD  CONSTRAINT [DF_EnderecoTipo_DataCriacao]  DEFAULT (getdate()) FOR [DataCriacao]
GO

ALTER TABLE [dbo].[EnderecoTipo] ADD  CONSTRAINT [DF_EnderecoTipo_DataModificacao]  DEFAULT (getdate()) FOR [DataModificacao]
GO

ALTER TABLE [dbo].[EnderecoTipo]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoTipo_Entidade] FOREIGN KEY([UsuarioCriadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[EnderecoTipo] CHECK CONSTRAINT [FK_EnderecoTipo_Entidade]
GO

ALTER TABLE [dbo].[EnderecoTipo]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoTipo_Entidade1] FOREIGN KEY([UsuarioModificadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[EnderecoTipo] CHECK CONSTRAINT [FK_EnderecoTipo_Entidade1]
GO

