using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class RegistroManutencaoArquivoREP : Repositorio<RegistroManutencaoArquivo>, IDisposable
    {
        private EntitiesModel dbContext;

        public RegistroManutencaoArquivoREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Busca o registro de manutenção de imagem baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pEquipamentoID">ID do registro de manutenção do qual se necessita os dados</param>
        /// <returns>Registro de manutenção de equipamento</returns>
        public RegistroManutencaoArquivo BuscarPorID(int pRegistroManutencaoID)
        {
            return base.BuscarTodos(rmi => rmi.RegistroManutencaoID == pRegistroManutencaoID).FirstOrDefault();
        }   
    }
}
