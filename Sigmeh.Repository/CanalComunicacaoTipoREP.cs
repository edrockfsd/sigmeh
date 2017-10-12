using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigmeh.Repository
{
    public class CanalComunicacaoTipoREP : Repositorio<CanalComunicacaoTipo>, IDisposable 
    {
        public CanalComunicacaoTipoREP(EntitiesModel context) : base(context) { }

        public void Dispose()
        {

        }

        public Dictionary<int, string> BuscarTodosKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.CanalComunicacaoTipos.ToDictionary(cct => cct.CanalComunicacaoTipoID, cct => cct.Descricao);
            }
        }
    }
}
