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
	public partial class RegistroManutencaoArquivo
	{
		private int _registroManutencaoID;
		public virtual int RegistroManutencaoID
		{
			get
			{
				return this._registroManutencaoID;
			}
			set
			{
				this._registroManutencaoID = value;
			}
		}
		
		private string _arquivoNome;
		public virtual string ArquivoNome
		{
			get
			{
				return this._arquivoNome;
			}
			set
			{
				this._arquivoNome = value;
			}
		}
		
		private string _arquivoUrl;
		public virtual string ArquivoUrl
		{
			get
			{
				return this._arquivoUrl;
			}
			set
			{
				this._arquivoUrl = value;
			}
		}
		
		private RegistroManutencao _registroManutencao;
		public virtual RegistroManutencao RegistroManutencao
		{
			get
			{
				return this._registroManutencao;
			}
			set
			{
				this._registroManutencao = value;
			}
		}
		
	}
}
#pragma warning restore 1591