using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigmeh.Repository
{
    public class PeriodicidadeREP : Repositorio<Periodicidade>, IDisposable 
    {
        public PeriodicidadeREP(EntitiesModel context) : base(context) { }

        public void Dispose()
        {

        }

        public Dictionary<int, string> BuscarTodosKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.Periodicidades.ToDictionary(prd => prd.PeriodicidadeID , prd => prd.Intervalo);
            }
        }

        /// <summary>
        /// Retorna todas as periodicidades, fora a periodicidade do tipo "especificado", a qual não cabe para calibração.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> BuscarPeriodicidadesCalibracaoKeyValue()
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.Periodicidades.Where(prd => prd.PeriodicidadeID != 9).ToDictionary(prd => prd.PeriodicidadeID, prd => prd.Intervalo);
            }
        }
    }
}
