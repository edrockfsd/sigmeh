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

namespace Sigmeh.Model	
{
	public partial class result_BuscarEnderecoPorEntidade
	{
		private int _enderecoID;
		public virtual int EnderecoID
		{
			get
			{
				return this._enderecoID;
			}
			set
			{
				this._enderecoID = value;
			}
		}
		
		private string _cep;
		public virtual string cep
		{
			get
			{
				return this._cep;
			}
			set
			{
				this._cep = value;
			}
		}
		
		private string _logradouro;
		public virtual string Logradouro
		{
			get
			{
				return this._logradouro;
			}
			set
			{
				this._logradouro = value;
			}
		}
		
		private int? _numero;
		public virtual int? Numero
		{
			get
			{
				return this._numero;
			}
			set
			{
				this._numero = value;
			}
		}
		
		private string _complemento;
		public virtual string Complemento
		{
			get
			{
				return this._complemento;
			}
			set
			{
				this._complemento = value;
			}
		}
		
		private string _bairro;
		public virtual string Bairro
		{
			get
			{
				return this._bairro;
			}
			set
			{
				this._bairro = value;
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
		
		private int _cidadeID;
		public virtual int CidadeID
		{
			get
			{
				return this._cidadeID;
			}
			set
			{
				this._cidadeID = value;
			}
		}
		
		private string _cidadeNome;
		public virtual string CidadeNome
		{
			get
			{
				return this._cidadeNome;
			}
			set
			{
				this._cidadeNome = value;
			}
		}
		
		private string _uF;
		public virtual string UF
		{
			get
			{
				return this._uF;
			}
			set
			{
				this._uF = value;
			}
		}
		
		private string _tipoDescricao;
		public virtual string TipoDescricao
		{
			get
			{
				return this._tipoDescricao;
			}
			set
			{
				this._tipoDescricao = value;
			}
		}
		
		private int _enderecoTipoID;
		public virtual int EnderecoTipoID
		{
			get
			{
				return this._enderecoTipoID;
			}
			set
			{
				this._enderecoTipoID = value;
			}
		}
		
	}
}
#pragma warning restore 1591
