using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Sigmeh.Repository
{
    public class EquipamentoREP : Repositorio<Equipamento>, IDisposable
    {
        private EntitiesModel dbContext;

        public EquipamentoREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose() { }


        /// <summary>
        /// Método que busca todos os objetos Equipamento (todas as versões)
        /// </summary>
        /// <param name="pEquipamentoID">ID do equipamento do qual se deseja buscar os objetos de Equipamento</param>
        /// <returns>Lista de objetos de Equipamento do Equipamento com ID passado como parâmetro</returns>
        public IList<Equipamento> BuscarTodosPorID(int pEquipamentoID)
        {
            return base.BuscarTodos(eqp => eqp.EquipamentoID == pEquipamentoID).ToList();
        }

        /// <summary>
        /// Busca o registro de Equipamento baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pEquipamentoID">ID do Equipamento do qual se necessita o registro</param>
        /// <returns>Resultado da buscar por registro de Equipamento com ID passado como parâmetro</returns>
        public Equipamento BuscarPorID(int pEquipamentoID)
        {
            return base.BuscarTodos(eqp => eqp.EquipamentoID == pEquipamentoID).FirstOrDefault();
        }

        public IQueryable BuscarTodosAtuais(List<int> lstEmpresaMaeID, int? pDiasPrazo = null)
        {
            List<Equipamento> lstEquipamento = new List<Equipamento>(); // Variável de retorno

            // Listando equipamentos da(s) empresa(s) mãe selecionadas
            var result = from eqp in dbContext.Equipamentos
                         where (lstEmpresaMaeID.Contains(eqp.EmpresaVinculadaID))
                         select new Equipamento
                         {
                             EquipamentoID = eqp.EquipamentoID,
                             NumeroSerie = eqp.NumeroSerie,
                             Tag = eqp.Tag,
                             Patrimonio = eqp.Patrimonio,
                             Marca_Modelo = eqp.Marca_Modelo,
                             Localizacao = eqp.Localizacao,
                             Acessorios = eqp.Acessorios,
                             Descricao = eqp.Descricao,
                             EmpresaVinculadaID = eqp.EmpresaVinculadaID
                         };


            // Se o parâmetro de dias de prazo não for nulo, considerar apenas os  equipamentos da empresa já se enquadram em um status de saída com dias de prazo entre 30, 15, 7 e atrasado (para sair para manutenção)
            if (pDiasPrazo != null)
            {
                List<int> lstEquipamentoPorStatusSaida;
                switch (pDiasPrazo.Value)
                {
                    case -1:
                        lstEquipamentoPorStatusSaida = (from vw in dbContext.Vw_StatusSaidaEquipamentos
                                                        where lstEmpresaMaeID.Contains(vw.EmpresaVinculadaID)
                                                        && vw.DiasPrazo <= pDiasPrazo.Value
                                                        select vw.EquipamentoID).ToList();
                        break;
                    case 7:
                        lstEquipamentoPorStatusSaida = (from vw in dbContext.Vw_StatusSaidaEquipamentos
                                                        where lstEmpresaMaeID.Contains(vw.EmpresaVinculadaID)
                                                        && vw.DiasPrazo >= 0
                                                        && vw.DiasPrazo <= pDiasPrazo.Value
                                                        select vw.EquipamentoID).ToList();
                        break;
                    case 15:
                        lstEquipamentoPorStatusSaida = (from vw in dbContext.Vw_StatusSaidaEquipamentos
                                                        where lstEmpresaMaeID.Contains(vw.EmpresaVinculadaID)
                                                        && vw.DiasPrazo > 7
                                                        && vw.DiasPrazo <= pDiasPrazo.Value
                                                        select vw.EquipamentoID).ToList();
                        break;
                    case 30:
                        lstEquipamentoPorStatusSaida = (from vw in dbContext.Vw_StatusSaidaEquipamentos
                                                        where lstEmpresaMaeID.Contains(vw.EmpresaVinculadaID)
                                                        && vw.DiasPrazo > 15
                                                        && vw.DiasPrazo <= pDiasPrazo.Value
                                                        select vw.EquipamentoID).ToList();
                        break;
                    default:
                        lstEquipamentoPorStatusSaida = new List<int>();
                        break;

                }

                if (lstEquipamentoPorStatusSaida != null)
                {
                    lstEquipamento = result.Where(eqp => (lstEquipamentoPorStatusSaida.Contains(eqp.EquipamentoID))).ToList();
                }

            }// Sem filtro de dias de prazo
            else
            {
                lstEquipamento = result.ToList();
            }

            // Consultando os dias para cada manutenção do equipamento (por tipo de manutenção)
            var result2 = from eqp in lstEquipamento
                          let proxPreventiva =
                          (
                             from vw in dbContext.Vw_StatusSaidaEquipamentos
                             where vw.EquipamentoID == eqp.EquipamentoID && vw.ManutencaoTipoID == 1
                             select vw.DiasPrazo
                          ).FirstOrDefault()
                          let proxCalibracao =
                          (
                             from vw in dbContext.Vw_StatusSaidaEquipamentos
                             where vw.EquipamentoID == eqp.EquipamentoID && vw.ManutencaoTipoID == 3
                             select vw.DiasPrazo
                          ).FirstOrDefault()
                          select new
                          {
                              EquipamentoID = eqp.EquipamentoID,
                              NumeroSerie = eqp.NumeroSerie,
                              Tag = eqp.Tag,
                              Patrimonio = eqp.Patrimonio,
                              Marca_Modelo = eqp.Marca_Modelo,
                              Localizacao = eqp.Localizacao,
                              Acessorios = eqp.Acessorios,
                              Descricao = eqp.Descricao,
                              EmpresaVinculadaID = eqp.EmpresaVinculadaID,
                              ProxPreventiva = proxPreventiva,
                              ProxCalibracao = proxCalibracao,
                          };

            return result2.AsQueryable();
        }

        public Dictionary<int, string> FiltrarTodosKeyValue(string pTextoBusca)
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                var result = from eqp in dbContext.Equipamentos
                             where eqp.NumeroSerie.Contains(pTextoBusca)
                             select new Equipamento
                             {
                                 EquipamentoID = eqp.EquipamentoID,
                                 NumeroSerie = eqp.NumeroSerie
                             };

                return result.Distinct().ToDictionary(eqp2 => eqp2.EquipamentoID, eqp2 => eqp2.NumeroSerie);
            }
        }

        public List<ManutencaoTipoContagem> BuscarStatusSaidaEquipamentoPorEmpresa(List<int> lstEmpresaMaeID)
        {
            var lstManutencaoTipoStatus = (from vwSSE in dbContext.Vw_StatusSaidaEquipamentos
                                           where vwSSE.ManutencaoTipoID != 2 // Manutenção corretiva não entra na regra
                                           && (lstEmpresaMaeID.Contains(vwSSE.EmpresaVinculadaID))
                                           && vwSSE.DiasPrazo <= 30
                                           select new
                                           {
                                               vwSSE.ManutencaoTipoID,
                                               Status = (vwSSE.DiasPrazo < 0) ? -1 : (vwSSE.DiasPrazo > 0 && vwSSE.DiasPrazo <= 7) ? 7 : (vwSSE.DiasPrazo > 7 && vwSSE.DiasPrazo <= 15) ? 15 : (vwSSE.DiasPrazo > 15 && vwSSE.DiasPrazo <= 30) ? 30 : 32 // 32 pq é obrigatório passar um valor (e um mês tem no máximo 31 dias).
                                           }).ToList();

            var result = from mts in lstManutencaoTipoStatus
                         group mts by new { mts.ManutencaoTipoID, mts.Status } into g
                         select new ManutencaoTipoContagem
                         {
                             ManutencaoTipoID = g.Key.ManutencaoTipoID,
                             ManutencaoTipoQtde = g.Count(),
                             Status = g.Key.Status
                         };

            return result.ToList();
        }

        public DateTime? BuscarDataManutencao(int pEquipamentoID, int pManutencaoTipoID, string pCondicaoManutencao)
        {
            switch (pCondicaoManutencao)
            {
                case "realizada":
                    return (from vwSSE in dbContext.Vw_StatusSaidaEquipamentos where vwSSE.EquipamentoID == pEquipamentoID && vwSSE.ManutencaoTipoID == pManutencaoTipoID select vwSSE.DataRealizacao).FirstOrDefault();
                    break;
                case "prevista":
                    return (from vwSSE in dbContext.Vw_StatusSaidaEquipamentos where vwSSE.EquipamentoID == pEquipamentoID && vwSSE.ManutencaoTipoID == pManutencaoTipoID select vwSSE.DataPrevista).FirstOrDefault();
                    break;
                default:
                    return new DateTime();
                    break;
            }
        }
    }

    /// <summary>
    /// Classe usada somente para usar como retorno de uma pesquisa
    /// </summary>
    public class ManutencaoTipoContagem
    {
        public int ManutencaoTipoID;
        public int ManutencaoTipoQtde;
        public int Status;
    }
}
