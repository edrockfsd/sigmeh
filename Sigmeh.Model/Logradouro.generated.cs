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
	public partial class Logradouro
	{
		private int _logradouroID;
		public virtual int LogradouroID
		{
			get
			{
				return this._logradouroID;
			}
			set
			{
				this._logradouroID = value;
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
		
		private int? _bairroIDInicio;
		public virtual int? BairroIDInicio
		{
			get
			{
				return this._bairroIDInicio;
			}
			set
			{
				this._bairroIDInicio = value;
			}
		}
		
		private int? _bairroIDFim;
		public virtual int? BairroIDFim
		{
			get
			{
				return this._bairroIDFim;
			}
			set
			{
				this._bairroIDFim = value;
			}
		}
		
		private string _nome;
		public virtual string Nome
		{
			get
			{
				return this._nome;
			}
			set
			{
				this._nome = value;
			}
		}
		
		private string _cEP;
		public virtual string CEP
		{
			get
			{
				return this._cEP;
			}
			set
			{
				this._cEP = value;
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
		
		private string _tipo;
		public virtual string Tipo
		{
			get
			{
				return this._tipo;
			}
			set
			{
				this._tipo = value;
			}
		}
		
		private Cidade _cidade;
		public virtual Cidade Cidade
		{
			get
			{
				return this._cidade;
			}
			set
			{
				this._cidade = value;
			}
		}
		
		private Bairro _bairro;
		public virtual Bairro Bairro
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
		
		private Bairro _bairro1;
		public virtual Bairro Bairro1
		{
			get
			{
				return this._bairro1;
			}
			set
			{
				this._bairro1 = value;
			}
		}
		
	}
}
#pragma warning restore 1591
