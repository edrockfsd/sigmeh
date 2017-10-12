using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class RegistroManutencaoREP : Repositorio<RegistroManutencao>, IDisposable
    {
        private EntitiesModel dbContext;

        public RegistroManutencaoREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Busca o registro de manutenção de equipamento baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pEquipamentoID">ID do registro de manutenção de equipamento do qual se necessita os dados</param>
        /// <returns>Registro de manutenção de equipamento</returns>
        public RegistroManutencao BuscarPorID(int pRegistroManutencaoID)
        {
            return base.BuscarTodos(rmn => rmn.RegistroManutencaoID == pRegistroManutencaoID).FirstOrDefault();
        } 
        
        public IList<RegistroManutencao> BuscarPorEquipamento(int pEquipamentoID)
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                var result = from rmn in dbContext.RegistroManutencaos                             
                             where rmn.EquipamentoID == pEquipamentoID
                             select new RegistroManutencao 
                             { 
                                RegistroManutencaoID = rmn.RegistroManutencaoID
                             };
                             
                return result.Distinct().ToList();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// Esse título do método é devido ao modelo de dados, que persiste registros a cada alteração (os registros não são alterados, sempre é salvo um novo).
        public IQueryable BuscarTodosAtuais(List<int> lstEmpresaMaeID)
        {
            var result = from rmn in dbContext.RegistroManutencaos                         
                         join entExecutor in dbContext.Entidades
                         on rmn.ExecutorID equals entExecutor.EntidadeID                         
                         join entAprovador in dbContext.Entidades
                         on rmn.AprovadorID equals entAprovador.EntidadeID                         
                         join eqp in dbContext.Equipamentos
                         on rmn.EquipamentoID equals eqp.EquipamentoID                         
                         join man in dbContext.ManutencaoTipos
                         on rmn.ManutencaoTipoID equals man.ManutencaoTipoID                         
                         select new
                         {
                             RegistroManutencaoID = rmn.RegistroManutencaoID,
                             EquipamentoNumeroSerie = eqp.NumeroSerie,
                             Executor = entExecutor.Nome,
                             Aprovador = entAprovador.Nome,                             
                             ManutencaoTipo = man.Descricao,
                             DataRealizacao = rmn.DataRealizacao.ToShortDateString(),
                             RelatorioDescricao = rmn.RelatorioDescricao,
                             DefeitoDescricao = rmn.DefeitoDescricao,
                             EmpresaVinculadaID = eqp.EmpresaVinculadaID

                         };

            if (lstEmpresaMaeID.Count > 0)
            {
                result = result.Where(rmn => lstEmpresaMaeID.Contains(rmn.EmpresaVinculadaID));
            }

            return result.AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEquipamentoID"></param>
        /// <returns></returns>
        /// Esse título do método é devido ao modelo de dados, que persiste registros a cada alteração (os registros não são alterados, sempre é salvo um novo).
        public IQueryable BuscarTodosAtuaisPorEquipamento(int pEquipamentoID)
        {
            var result = from rmn in dbContext.RegistroManutencaos                         
                         join entExecutor in dbContext.Entidades
                         on rmn.ExecutorID equals entExecutor.EntidadeID                         
                         join entAprovador in dbContext.Entidades
                         on rmn.AprovadorID equals entAprovador.EntidadeID                                                
                         join eqp in dbContext.Equipamentos
                         on rmn.EquipamentoID equals eqp.EquipamentoID                         
                         join man in dbContext.ManutencaoTipos
                         on rmn.ManutencaoTipoID equals man.ManutencaoTipoID
                         where eqp.EquipamentoID == pEquipamentoID
                         select new
                         {
                             RegistroManutencaoID = rmn.RegistroManutencaoID,
                             EquipamentoNumeroSerie = eqp.NumeroSerie,
                             Executor = entExecutor.Nome,
                             Aprovador = entAprovador.Nome,                             
                             ManutencaoTipo = man.Descricao,
                             DataRealizacao = rmn.DataRealizacao.ToShortDateString(),
                             RelatorioDescricao = rmn.RelatorioDescricao,
                             DefeitoDescricao = rmn.DefeitoDescricao
                         };

            return result.AsQueryable();
        }

        /// <summary>
        /// Método que checa se existe algum registro de manutenção aberto para determinado equipamento
        /// </summary>
        /// <param name="pEquipamentoID">ID do equipamento a ser verificado</param>
        /// <returns>0 Se não houver registros de manutenção para o equipamento. Se houver, retorna o ID do registro de manutenção em aberto para o equipamento</returns>
        public int ChecarRMEAberto(int pEquipamentoID)
        {
            RegistroManutencao _RegistroManutencao = dbContext.RegistroManutencaos.FirstOrDefault(rmn => rmn.EquipamentoID == pEquipamentoID && rmn.ManutencaoStatusID != 5);
            
            if ( _RegistroManutencao != null)
            {
                return _RegistroManutencao.RegistroManutencaoID;
            }
            else
            {
                return 0;
            }
        }
    }
}
