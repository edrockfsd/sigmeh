using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class EquipamentoTipoREP : Repositorio<EquipamentoTipo>, IDisposable
    {
        private EntitiesModel dbContext;

        public EquipamentoTipoREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        public IList<EquipamentoTipo> BuscarDadosGrid()
        {
            var result = from eqt in dbContext.EquipamentoTipos                         
                         select new EquipamentoTipo
                         {
                             EquipamentoTipoID = eqt.EquipamentoTipoID,                             
                             Descricao = eqt.Descricao,
                             Observacao = eqt.Observacao
                         };

            return result.ToList();
        }

        /// <summary>
        /// Busca o registro de Equipamento Tipo baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pEquipamentoTipoID">ID do objeto de  Equipamento Tipo do qual se necessita o registro</param>
        /// <returns>Resultado da buscar por registro de Equipamento Tipo com ID passado como parâmetro</returns>
        public EquipamentoTipo BuscarPorID(int pEquipamentoTipoID)
        {
            return base.BuscarTodos(eqt => eqt.EquipamentoTipoID == pEquipamentoTipoID).FirstOrDefault();
        }

        /// <summary>
        /// Método que retorna objeto key/value pair com dados de equipamento tipo (EquipamentoTipoID/Descricao)
        /// </summary>
        /// <returns>Dicionário com dados key/value pair respectivamente (EquipamentoTipoID/Descricao)</returns>
        public Dictionary<int, string> BuscarTodosKeyValue(string pTexto)
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                return dbContext.EquipamentoTipos.Where(eqt => eqt.Descricao.Contains(pTexto)).ToDictionary(eqt => eqt.EquipamentoTipoID, eqt => eqt.Descricao);
            }
        }
    }
}
