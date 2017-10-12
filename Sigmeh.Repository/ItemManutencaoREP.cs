using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class ItemManutencaoREP : Repositorio<ItemManutencao>, IDisposable
    {
        private EntitiesModel dbContext;

        public ItemManutencaoREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Método que retorna os itens de manutenção de determinado registro de manutenção
        /// </summary>
        /// <param name="pRegistroManutencaoID">ID do registro de manutenção do qual se espera a lista de itens de manutenção associados</param>
        /// <returns>Lista de itens de manutenção vinculados ao registro de manutenção enviado como parâmetro</returns>
        public IList<ItemManutencao> BuscarPorRegistroManutencao(int pRegistroManutencaoID)
        {
            return base.BuscarTodos(itm => itm.RegistroManutencaoID == pRegistroManutencaoID).ToList();
        }

        /// <summary>
        /// Busca o registro de item de manutenção baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pItemManutencaoID">ID do item de manutenção do qual se necessita o registro</param>
        /// <returns>Objeto de negócio ItemManutencao</returns>
        public ItemManutencao BuscarPorID(int pItemManutencaoID)
        {
            return base.BuscarTodos(itm => itm.ItemManutencaoID == pItemManutencaoID).FirstOrDefault();
        }
    }
}
