#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
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
	public partial class CanalComunicacao
	{
		private int _entidadeID;
		public virtual int EntidadeID
		{
			get
			{
				return this._entidadeID;
			}
			set
			{
				this._entidadeID = value;
			}
		}
		
		private int _canalComunicacaoID;
		public virtual int CanalComunicacaoID
		{
			get
			{
				return this._canalComunicacaoID;
			}
			set
			{
				this._canalComunicacaoID = value;
			}
		}
		
		private int _canalComunicacaoTipoID;
		public virtual int CanalComunicacaoTipoID
		{
			get
			{
				return this._canalComunicacaoTipoID;
			}
			set
			{
				this._canalComunicacaoTipoID = value;
			}
		}
		
		private string _descricao;
		public virtual string Descricao
		{
			get
			{
				return this._descricao;
			}
			set
			{
				this._descricao = value;
			}
		}
		
		private DateTime _dataCriacao;
		public virtual DateTime DataCriacao
		{
			get
			{
				return this._dataCriacao;
			}
			set
			{
				this._dataCriacao = value;
			}
		}
		
		private int _usuarioCriadorID;
		public virtual int UsuarioCriadorID
		{
			get
			{
				return this._usuarioCriadorID;
			}
			set
			{
				this._usuarioCriadorID = value;
			}
		}
		
		private DateTime _dataModificacao;
		public virtual DateTime DataModificacao
		{
			get
			{
				return this._dataModificacao;
			}
			set
			{
				this._dataModificacao = value;
			}
		}
		
		private int _usuarioModificadorID;
		public virtual int UsuarioModificadorID
		{
			get
			{
				return this._usuarioModificadorID;
			}
			set
			{
				this._usuarioModificadorID = value;
			}
		}
		
		private bool _isPrincipal;
		public virtual bool IsPrincipal
		{
			get
			{
				return this._isPrincipal;
			}
			set
			{
				this._isPrincipal = value;
			}
		}
		
		private CanalComunicacaoTipo _canalComunicacaoTipo;
		public virtual CanalComunicacaoTipo CanalComunicacaoTipo
		{
			get
			{
				return this._canalComunicacaoTipo;
			}
			set
			{
				this._canalComunicacaoTipo = value;
			}
		}
		
		private Entidade _entidade;
		public virtual Entidade Entidade
		{
			get
			{
				return this._entidade;
			}
			set
			{
				this._entidade = value;
			}
		}
		
		private Entidade _entidade1;
		public virtual Entidade Entidade1
		{
			get
			{
				return this._entidade1;
			}
			set
			{
				this._entidade1 = value;
			}
		}
		
		private Entidade _entidade2;
		public virtual Entidade Entidade2
		{
			get
			{
				return this._entidade2;
			}
			set
			{
				this._entidade2 = value;
			}
		}
		
	}
}
#pragma warning restore 1591
