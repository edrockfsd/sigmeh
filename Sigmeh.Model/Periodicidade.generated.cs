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
	public partial class Periodicidade
	{
		private int _periodicidadeID;
		public virtual int PeriodicidadeID
		{
			get
			{
				return this._periodicidadeID;
			}
			set
			{
				this._periodicidadeID = value;
			}
		}
		
		private string _intervalo;
		public virtual string Intervalo
		{
			get
			{
				return this._intervalo;
			}
			set
			{
				this._intervalo = value;
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
		
		private IList<Equipamento> _equipamentos = new List<Equipamento>();
		public virtual IList<Equipamento> Equipamentos
		{
			get
			{
				return this._equipamentos;
			}
		}
		
		private IList<Equipamento> _equipamentos1 = new List<Equipamento>();
		public virtual IList<Equipamento> Equipamentos1
		{
			get
			{
				return this._equipamentos1;
			}
		}
		
	}
}
#pragma warning restore 1591
