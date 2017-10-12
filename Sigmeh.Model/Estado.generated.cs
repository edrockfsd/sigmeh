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
	public partial class Estado
	{
		private int _estadoID;
		public virtual int EstadoID
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
		
		private string _sigla;
		public virtual string Sigla
		{
			get
			{
				return this._sigla;
			}
			set
			{
				this._sigla = value;
			}
		}
		
		private decimal? _valorAliquotaICMS;
		public virtual decimal? ValorAliquotaICMS
		{
			get
			{
				return this._valorAliquotaICMS;
			}
			set
			{
				this._valorAliquotaICMS = value;
			}
		}
		
		private string _regiao;
		public virtual string Regiao
		{
			get
			{
				return this._regiao;
			}
			set
			{
				this._regiao = value;
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
		
		private IList<Cidade> _cidades = new List<Cidade>();
		public virtual IList<Cidade> Cidades
		{
			get
			{
				return this._cidades;
			}
		}
		
	}
}
#pragma warning restore 1591