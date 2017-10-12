using System;
using System.Collections.Generic;
using System.Linq;
using Sigmeh.Model.Repositorios;
using Sigmeh.Model;
using Sigmeh.Framework;

namespace Sigmeh.Repository
{
    public class CanalComunicacaoREP : Repositorio<CanalComunicacao>, IDisposable
    {
        private EntitiesModel dbContext;

        public CanalComunicacaoREP(EntitiesModel context) : base(context) { this.dbContext = context; }

        public void Dispose()
        {

        }

        /// <summary>
        /// Busca os registros de canais de comunicação baseado no ID da entidade passada
        /// </summary>
        /// <param name="pEntidadeID">ID da entidade da qual se necessita os registros de canais de comunicação</param>
        /// <returns>Lista de registros de canais de comunicação pertencentes a entidade passada como parâmetro</returns>
        public IList<result_BuscarCanaisPorEntidade> BuscarPorEntidade(int pEntidadeID)
        { 
            return dbContext.Stp_BuscarCanaisPorEntidade(pEntidadeID).ToList();
        }
        /// <summary>
        /// Busca o registro de canal de comunicação baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pCanalComunicacaoID">ID do canal de comunicação do qual se necessita o registro</param>
        /// <returns>Resultado da buscar por registro de canal de comunicação com ID passado como parâmetro</returns>
        public CanalComunicacao BuscarPorID(int pCanalComunicacaoID)
        {
            return base.BuscarTodos(cc => cc.CanalComunicacaoID == pCanalComunicacaoID).FirstOrDefault();
        }
        /// <summary>
        /// Método que mantém somente 1 registro de canal de comunicação como principal para cada entidade
        /// </summary>
        /// <param name="opCanalComunicacao">Canal de comunicação que será o registro configurado como principal</param>
        /// <returns>Status de sucesso para transação sem erros e falha se houver algum erro</returns>
        public Enums.StatusTransacao AplicarRegistroPrincipal(CanalComunicacao opCanalComunicacao)
        {
            try
            {
                IList<CanalComunicacao> lstCanalComunicacao = base.BuscarTodos(cc => cc.EntidadeID == cc.EntidadeID);
                // Se houver somente 1 registro, este deve ser o principal
                if (lstCanalComunicacao.Count == 1)
                {
                    lstCanalComunicacao.FirstOrDefault().IsPrincipal = true;
                }
                else
                {
                    foreach (CanalComunicacao ccItem in lstCanalComunicacao)
                    {
                        if (ccItem.CanalComunicacaoID != opCanalComunicacao.CanalComunicacaoID)
                        {
                            ccItem.IsPrincipal = false;
                        }
                        else
                        {
                            ccItem.IsPrincipal = true;
                        }
                    }
                }
                return Enums.StatusTransacao.Sucesso;
            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                throw ex;
            }
        }
        /// <summary>
        /// Método que remove a configuração de principal do objeto canal de comunicação enviado como parâmetro e altera o registro de canal de comunicação principal para o primeiro registro de canal de comunicação da entidade (se houver)
        /// </summary>
        /// <param name="opCanalComunicacao">Objeto Canal de comunicação que perderá a configuração de registro principal</param>
        /// <returns>Status de sucesso para transação sem erros e falha se houver algum erro</returns>
        public Enums.StatusTransacao RemoverRegistroPrincipal(CanalComunicacao opCanalComunicacao)
        {
            try
            {
                IList<CanalComunicacao> lstCanalComunicacao = base.BuscarTodos(cc => cc.EntidadeID == opCanalComunicacao.EntidadeID);

                if (lstCanalComunicacao.Count == 1)
                {
                    lstCanalComunicacao.FirstOrDefault().IsPrincipal = true;
                    return Enums.StatusTransacao.Sucesso;
                }
                
                //Primeiro garante que todos os registros não tem índice de principal
                foreach (CanalComunicacao ccItem in lstCanalComunicacao)
                {
                    ccItem.IsPrincipal = false;
                }

                //Após isto, busca o primeiro registro de canal de telefone da entidade, que seja diferente do parâmetro enviado e configura como principal
                base.BuscarTodos(cc => cc.EntidadeID == opCanalComunicacao.EntidadeID && cc.CanalComunicacaoID != opCanalComunicacao.CanalComunicacaoID).FirstOrDefault().IsPrincipal = true;

                return Enums.StatusTransacao.Sucesso;
            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                throw ex;
            }
        }
    }
}
