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
	public partial class Cidade
	{
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
		
		private int? _estadoID;
		public virtual int? EstadoID
		{
			get
			{
				return this._estadoID;
			}
			set
			{
				this._estadoID = value;
			}
		}
		
		private int _paisID;
		public virtual int PaisID
		{
			get
			{
				return this._paisID;
			}
			set
			{
				this._paisID = value;
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
		
		private short _dDD;
		public virtual short DDD
		{
			get
			{
				return this._dDD;
			}
			set
			{
				this._dDD = value;
			}
		}
		
		private bool? _capital;
		public virtual bool? Capital
		{
			get
			{
				return this._capital;
			}
			set
			{
				this._capital = value;
			}
		}
		
		private Estado _estado;
		public virtual Estado Estado
		{
			get
			{
				return this._estado;
			}
			set
			{
				this._estado = value;
			}
		}
		
		private Pai _pai;
		public virtual Pai Pai
		{
			get
			{
				return this._pai;
			}
			set
			{
				this._pai = value;
			}
		}
		
		private IList<Bairro> _bairros = new List<Bairro>();
		public virtual IList<Bairro> Bairros
		{
			get
			{
				return this._bairros;
			}
		}
		
		private IList<Logradouro> _logradouros = new List<Logradouro>();
		public virtual IList<Logradouro> Logradouros
		{
			get
			{
				return this._logradouros;
			}
		}
		
		private IList<Endereco> _enderecos = new List<Endereco>();
		public virtual IList<Endereco> Enderecos
		{
			get
			{
				return this._enderecos;
			}
		}
		
	}
}
#pragma warning restore 1591
