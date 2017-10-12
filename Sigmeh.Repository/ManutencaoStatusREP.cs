using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigmeh.Repository
{
    public class ManutencaoStatusREP : Repositorio<ManutencaoStatus>, IDisposable 
    {
        public ManutencaoStatusREP(EntitiesModel context) : base(context) { }

        public void Dispose()
        {

        }

        public Dictionary<int, string> BuscarTodosKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.ManutencaoStatus.ToDictionary(mns => mns.ManutencaoStatusID, mns => mns.Descricao);
            }
        }
    }
}
