using System;
using System.Collections.Generic;
using System.Linq;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;

namespace Sigmeh.Repository
{
    public class EntidadeTipoREP : Repositorio<EntidadeTipo>, IDisposable
    {

        public EntidadeTipoREP(EntitiesModel context) : base(context) { }
        
        public void Dispose()
        {
            
        }

        public Dictionary<int, string> BuscarTodosKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.EntidadeTipos.ToDictionary(et => et.EntidadeTipoID, et => et.Descricao);
            }
        }
    }
}
