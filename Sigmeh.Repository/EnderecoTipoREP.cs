using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigmeh.Repository
{
    public class EnderecoTipoREP : Repositorio<EnderecoTipo>, IDisposable 
    {
        public EnderecoTipoREP(EntitiesModel context) : base(context) { }

        public void Dispose()
        {

        }

        public Dictionary<int, string> BuscarTodosKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.EnderecoTipos.ToDictionary(et => et.EnderecoTipoID, et => et.Descricao);
            }
        }
    }
}
