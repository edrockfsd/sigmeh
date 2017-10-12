﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Sigmeh.Model;

namespace Sigmeh.Model	
{
	public partial class EntitiesModel : OpenAccessContext, IEntitiesModelUnitOfWork
	{
		private static string connectionStringName = @"SigmehConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
		
		public EntitiesModel()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public EntitiesModel(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public EntitiesModel(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public EntitiesModel(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public EntitiesModel(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Bairro> Bairros 
		{
			get
			{
				return this.GetAll<Bairro>();
			}
		}
		
		public IQueryable<CanalComunicacao> CanalComunicacaos 
		{
			get
			{
				return this.GetAll<CanalComunicacao>();
			}
		}
		
		public IQueryable<CanalComunicacaoTipo> CanalComunicacaoTipos 
		{
			get
			{
				return this.GetAll<CanalComunicacaoTipo>();
			}
		}
		
		public IQueryable<Cidade> Cidades 
		{
			get
			{
				return this.GetAll<Cidade>();
			}
		}
		
		public IQueryable<Endereco> Enderecos 
		{
			get
			{
				return this.GetAll<Endereco>();
			}
		}
		
		public IQueryable<EnderecoTipo> EnderecoTipos 
		{
			get
			{
				return this.GetAll<EnderecoTipo>();
			}
		}
		
		public IQueryable<Entidade> Entidades 
		{
			get
			{
				return this.GetAll<Entidade>();
			}
		}
		
		public IQueryable<EntidadeTipo> EntidadeTipos 
		{
			get
			{
				return this.GetAll<EntidadeTipo>();
			}
		}
		
		public IQueryable<Estado> Estados 
		{
			get
			{
				return this.GetAll<Estado>();
			}
		}
		
		public IQueryable<Logradouro> Logradouros 
		{
			get
			{
				return this.GetAll<Logradouro>();
			}
		}
		
		public IQueryable<Pai> Pais 
		{
			get
			{
				return this.GetAll<Pai>();
			}
		}
		
		public IQueryable<RegistroManutencao> RegistroManutencaos 
		{
			get
			{
				return this.GetAll<RegistroManutencao>();
			}
		}
		
		public IQueryable<Telefone> Telefones 
		{
			get
			{
				return this.GetAll<Telefone>();
			}
		}
		
		public IQueryable<TelefoneTipo> TelefoneTipos 
		{
			get
			{
				return this.GetAll<TelefoneTipo>();
			}
		}
		
		public IQueryable<Equipamento> Equipamentos 
		{
			get
			{
				return this.GetAll<Equipamento>();
			}
		}
		
		public IQueryable<ManutencaoTipo> ManutencaoTipos 
		{
			get
			{
				return this.GetAll<ManutencaoTipo>();
			}
		}
		
		public IQueryable<ManutencaoStatus> ManutencaoStatus 
		{
			get
			{
				return this.GetAll<ManutencaoStatus>();
			}
		}
		
		public IQueryable<EquipamentoTipo> EquipamentoTipos 
		{
			get
			{
				return this.GetAll<EquipamentoTipo>();
			}
		}
		
		public IQueryable<Periodicidade> Periodicidades 
		{
			get
			{
				return this.GetAll<Periodicidade>();
			}
		}
		
		public IQueryable<Usuario> Usuarios 
		{
			get
			{
				return this.GetAll<Usuario>();
			}
		}
		
		public IQueryable<ItemManutencao> ItemManutencaos 
		{
			get
			{
				return this.GetAll<ItemManutencao>();
			}
		}
		
		public IQueryable<RegistroManutencaoArquivo> RegistroManutencaoArquivos 
		{
			get
			{
				return this.GetAll<RegistroManutencaoArquivo>();
			}
		}
		
		public IQueryable<Perfil> Perfils 
		{
			get
			{
				return this.GetAll<Perfil>();
			}
		}
		
		public IQueryable<Area> Areas 
		{
			get
			{
				return this.GetAll<Area>();
			}
		}
		
		public IQueryable<Vw_StatusSaidaEquipamento> Vw_StatusSaidaEquipamentos 
		{
			get
			{
				return this.GetAll<Vw_StatusSaidaEquipamento>();
			}
		}
		
		public IEnumerable<result_BuscarCanaisPorEntidade> Stp_BuscarCanaisPorEntidade(int? entidadeID)
		{
			int returnValue;
			return Stp_BuscarCanaisPorEntidade(entidadeID, out returnValue);
		}
		
		public IEnumerable<result_BuscarCanaisPorEntidade> Stp_BuscarCanaisPorEntidade(int? entidadeID, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterEntidadeID = new OAParameter();
			parameterEntidadeID.ParameterName = "EntidadeID";
			if(entidadeID.HasValue)
			{
				parameterEntidadeID.Value = entidadeID.Value;
			}
			else
			{
				parameterEntidadeID.DbType = DbType.Int32;
				parameterEntidadeID.Value = DBNull.Value;
			}

			IEnumerable<result_BuscarCanaisPorEntidade> queryResult = this.ExecuteQuery<result_BuscarCanaisPorEntidade>("[dbo].[stp_BuscarCanaisPorEntidade]", CommandType.StoredProcedure, parameterEntidadeID, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<result_BuscarTelefonePorEntidade> Stp_BuscarTelefonePorEntidade(int? entidadeID)
		{
			int returnValue;
			return Stp_BuscarTelefonePorEntidade(entidadeID, out returnValue);
		}
		
		public IEnumerable<result_BuscarTelefonePorEntidade> Stp_BuscarTelefonePorEntidade(int? entidadeID, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterEntidadeID = new OAParameter();
			parameterEntidadeID.ParameterName = "EntidadeID";
			if(entidadeID.HasValue)
			{
				parameterEntidadeID.Value = entidadeID.Value;
			}
			else
			{
				parameterEntidadeID.DbType = DbType.Int32;
				parameterEntidadeID.Value = DBNull.Value;
			}

			IEnumerable<result_BuscarTelefonePorEntidade> queryResult = this.ExecuteQuery<result_BuscarTelefonePorEntidade>("[dbo].[stp_BuscarTelefonePorEntidade]", CommandType.StoredProcedure, parameterEntidadeID, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<result_BuscarEnderecoCep> Stp_BuscarEnderecoCep(string pCEP, string pLogradouroNome, string pBairroNome, int? pCidadeID)
		{
			int returnValue;
			return Stp_BuscarEnderecoCep(pCEP, pLogradouroNome, pBairroNome, pCidadeID, out returnValue);
		}
		
		public IEnumerable<result_BuscarEnderecoCep> Stp_BuscarEnderecoCep(string pCEP, string pLogradouroNome, string pBairroNome, int? pCidadeID, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterPCEP = new OAParameter();
			parameterPCEP.ParameterName = "pCEP";
			parameterPCEP.Size = 50;
			if(pCEP != null)
			{
				parameterPCEP.Value = pCEP;
			}	
			else
			{
				parameterPCEP.DbType = DbType.String;
				parameterPCEP.Value = DBNull.Value;
			}

			OAParameter parameterPLogradouroNome = new OAParameter();
			parameterPLogradouroNome.ParameterName = "pLogradouroNome";
			parameterPLogradouroNome.Size = 50;
			if(pLogradouroNome != null)
			{
				parameterPLogradouroNome.Value = pLogradouroNome;
			}	
			else
			{
				parameterPLogradouroNome.DbType = DbType.String;
				parameterPLogradouroNome.Value = DBNull.Value;
			}

			OAParameter parameterPBairroNome = new OAParameter();
			parameterPBairroNome.ParameterName = "pBairroNome";
			parameterPBairroNome.Size = 50;
			if(pBairroNome != null)
			{
				parameterPBairroNome.Value = pBairroNome;
			}	
			else
			{
				parameterPBairroNome.DbType = DbType.String;
				parameterPBairroNome.Value = DBNull.Value;
			}

			OAParameter parameterPCidadeID = new OAParameter();
			parameterPCidadeID.ParameterName = "pCidadeID";
			if(pCidadeID.HasValue)
			{
				parameterPCidadeID.Value = pCidadeID.Value;
			}
			else
			{
				parameterPCidadeID.DbType = DbType.Int32;
				parameterPCidadeID.Value = DBNull.Value;
			}

			IEnumerable<result_BuscarEnderecoCep> queryResult = this.ExecuteQuery<result_BuscarEnderecoCep>("[dbo].[stp_BuscarEnderecoCep]", CommandType.StoredProcedure, parameterPCEP, parameterPLogradouroNome, parameterPBairroNome, parameterPCidadeID, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<result_BuscarEnderecoPorEntidade> Stp_BuscarEnderecoPorEntidade(int? entidadeID)
		{
			int returnValue;
			return Stp_BuscarEnderecoPorEntidade(entidadeID, out returnValue);
		}
		
		public IEnumerable<result_BuscarEnderecoPorEntidade> Stp_BuscarEnderecoPorEntidade(int? entidadeID, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterEntidadeID = new OAParameter();
			parameterEntidadeID.ParameterName = "EntidadeID";
			if(entidadeID.HasValue)
			{
				parameterEntidadeID.Value = entidadeID.Value;
			}
			else
			{
				parameterEntidadeID.DbType = DbType.Int32;
				parameterEntidadeID.Value = DBNull.Value;
			}

			IEnumerable<result_BuscarEnderecoPorEntidade> queryResult = this.ExecuteQuery<result_BuscarEnderecoPorEntidade>("[dbo].[stp_BuscarEnderecoPorEntidade]", CommandType.StoredProcedure, parameterEntidadeID, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<result_FiltrarEntidade> Stp_FiltrarEntidade(bool? inativo, int? entidadePaiID)
		{
			int returnValue;
			return Stp_FiltrarEntidade(inativo, entidadePaiID, out returnValue);
		}
		
		public IEnumerable<result_FiltrarEntidade> Stp_FiltrarEntidade(bool? inativo, int? entidadePaiID, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterInativo = new OAParameter();
			parameterInativo.ParameterName = "Inativo";
			if(inativo.HasValue)
			{
				parameterInativo.Value = inativo.Value;
			}
			else
			{
				parameterInativo.DbType = DbType.Boolean;
				parameterInativo.Value = DBNull.Value;
			}

			OAParameter parameterEntidadePaiID = new OAParameter();
			parameterEntidadePaiID.ParameterName = "EntidadePaiID";
			if(entidadePaiID.HasValue)
			{
				parameterEntidadePaiID.Value = entidadePaiID.Value;
			}
			else
			{
				parameterEntidadePaiID.DbType = DbType.Int32;
				parameterEntidadePaiID.Value = DBNull.Value;
			}

			IEnumerable<result_FiltrarEntidade> queryResult = this.ExecuteQuery<result_FiltrarEntidade>("[dbo].[stp_FiltrarEntidade]", CommandType.StoredProcedure, parameterInativo, parameterEntidadePaiID, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<result_BuscarStatusSaidaEquipamentoPorEmpresa> Stp_BuscarStatusSaidaEquipamentoPorEmpresa(int? empresaID)
		{
			int returnValue;
			return Stp_BuscarStatusSaidaEquipamentoPorEmpresa(empresaID, out returnValue);
		}
		
		public IEnumerable<result_BuscarStatusSaidaEquipamentoPorEmpresa> Stp_BuscarStatusSaidaEquipamentoPorEmpresa(int? empresaID, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterEmpresaID = new OAParameter();
			parameterEmpresaID.ParameterName = "empresaID";
			if(empresaID.HasValue)
			{
				parameterEmpresaID.Value = empresaID.Value;
			}
			else
			{
				parameterEmpresaID.DbType = DbType.Int32;
				parameterEmpresaID.Value = DBNull.Value;
			}

			IEnumerable<result_BuscarStatusSaidaEquipamentoPorEmpresa> queryResult = this.ExecuteQuery<result_BuscarStatusSaidaEquipamentoPorEmpresa>("[dbo].[stp_BuscarStatusSaidaEquipamentoPorEmpresa]", CommandType.StoredProcedure, parameterEmpresaID, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
			return backend;
		}
	}
	
	public interface IEntitiesModelUnitOfWork : IUnitOfWork
	{
		IQueryable<Bairro> Bairros
		{
			get;
		}
		IQueryable<CanalComunicacao> CanalComunicacaos
		{
			get;
		}
		IQueryable<CanalComunicacaoTipo> CanalComunicacaoTipos
		{
			get;
		}
		IQueryable<Cidade> Cidades
		{
			get;
		}
		IQueryable<Endereco> Enderecos
		{
			get;
		}
		IQueryable<EnderecoTipo> EnderecoTipos
		{
			get;
		}
		IQueryable<Entidade> Entidades
		{
			get;
		}
		IQueryable<EntidadeTipo> EntidadeTipos
		{
			get;
		}
		IQueryable<Estado> Estados
		{
			get;
		}
		IQueryable<Logradouro> Logradouros
		{
			get;
		}
		IQueryable<Pai> Pais
		{
			get;
		}
		IQueryable<RegistroManutencao> RegistroManutencaos
		{
			get;
		}
		IQueryable<Telefone> Telefones
		{
			get;
		}
		IQueryable<TelefoneTipo> TelefoneTipos
		{
			get;
		}
		IQueryable<Equipamento> Equipamentos
		{
			get;
		}
		IQueryable<ManutencaoTipo> ManutencaoTipos
		{
			get;
		}
		IQueryable<ManutencaoStatus> ManutencaoStatus
		{
			get;
		}
		IQueryable<EquipamentoTipo> EquipamentoTipos
		{
			get;
		}
		IQueryable<Periodicidade> Periodicidades
		{
			get;
		}
		IQueryable<Usuario> Usuarios
		{
			get;
		}
		IQueryable<ItemManutencao> ItemManutencaos
		{
			get;
		}
		IQueryable<RegistroManutencaoArquivo> RegistroManutencaoArquivos
		{
			get;
		}
		IQueryable<Perfil> Perfils
		{
			get;
		}
		IQueryable<Area> Areas
		{
			get;
		}
		IQueryable<Vw_StatusSaidaEquipamento> Vw_StatusSaidaEquipamentos
		{
			get;
		}
		IEnumerable<result_BuscarCanaisPorEntidade> Stp_BuscarCanaisPorEntidade(int? entidadeID);
		IEnumerable<result_BuscarCanaisPorEntidade> Stp_BuscarCanaisPorEntidade(int? entidadeID, out int returnValue);
		IEnumerable<result_BuscarTelefonePorEntidade> Stp_BuscarTelefonePorEntidade(int? entidadeID);
		IEnumerable<result_BuscarTelefonePorEntidade> Stp_BuscarTelefonePorEntidade(int? entidadeID, out int returnValue);
		IEnumerable<result_BuscarEnderecoCep> Stp_BuscarEnderecoCep(string pCEP, string pLogradouroNome, string pBairroNome, int? pCidadeID);
		IEnumerable<result_BuscarEnderecoCep> Stp_BuscarEnderecoCep(string pCEP, string pLogradouroNome, string pBairroNome, int? pCidadeID, out int returnValue);
		IEnumerable<result_BuscarEnderecoPorEntidade> Stp_BuscarEnderecoPorEntidade(int? entidadeID);
		IEnumerable<result_BuscarEnderecoPorEntidade> Stp_BuscarEnderecoPorEntidade(int? entidadeID, out int returnValue);
		IEnumerable<result_FiltrarEntidade> Stp_FiltrarEntidade(bool? inativo, int? entidadePaiID);
		IEnumerable<result_FiltrarEntidade> Stp_FiltrarEntidade(bool? inativo, int? entidadePaiID, out int returnValue);
		IEnumerable<result_BuscarStatusSaidaEquipamentoPorEmpresa> Stp_BuscarStatusSaidaEquipamentoPorEmpresa(int? empresaID);
		IEnumerable<result_BuscarStatusSaidaEquipamentoPorEmpresa> Stp_BuscarStatusSaidaEquipamentoPorEmpresa(int? empresaID, out int returnValue);
	}
}
#pragma warning restore 1591
