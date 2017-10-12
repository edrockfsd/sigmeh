USE [sigmeh]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 18/11/2013 22:40:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Endereco](
	[EntidadeID] [int] NOT NULL,
	[EnderecoID] [int] IDENTITY(1,1) NOT NULL,
	[EnderecoTipoID] [int] NOT NULL,
	[cep] [varchar](8) NULL,
	[Logradouro] [varchar](300) NULL,
	[Complemento] [varchar](80) NULL,
	[Numero] [int] NULL,
	[Principal] [bit] NOT NULL,
	[Observacao] [varchar](250) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[UsuarioCriadorID] [int] NOT NULL,
	[DataModificacao] [datetime] NOT NULL,
	[UsuarioModificadorID] [int] NOT NULL,
 CONSTRAINT [PK_Endereco_EnderecoID] PRIMARY KEY CLUSTERED 
(
	[EntidadeID] ASC,
	[EnderecoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Endereco] ADD  CONSTRAINT [DF_Endereco_DataCriacao]  DEFAULT (getdate()) FOR [DataCriacao]
GO

ALTER TABLE [dbo].[Endereco] ADD  CONSTRAINT [DF_Endereco_DataModificacao]  DEFAULT (getdate()) FOR [DataModificacao]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_EnderecoTipo] FOREIGN KEY([EnderecoTipoID])
REFERENCES [dbo].[EnderecoTipo] ([EnderecoTipoID])
GO

ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_EnderecoTipo]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Entidade] FOREIGN KEY([UsuarioCriadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Entidade]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Entidade_EntidadeID] FOREIGN KEY([EntidadeID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Entidade_EntidadeID]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Entidade1] FOREIGN KEY([UsuarioModificadorID])
REFERENCES [dbo].[Entidade] ([EntidadeID])
GO

ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Entidade1]
GO

