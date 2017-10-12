using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigmeh.Repository
{
    public class ManutencaoTipoREP : Repositorio<ManutencaoTipo>, IDisposable 
    {
        public ManutencaoTipoREP(EntitiesModel context) : base(context) { }

        public void Dispose()
        {

        }

        public Dictionary<int, string> BuscarTodosKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.ManutencaoTipos.ToDictionary(mnt => mnt.ManutencaoTipoID, mnt => mnt.Descricao);
            }
        }
    }
}
