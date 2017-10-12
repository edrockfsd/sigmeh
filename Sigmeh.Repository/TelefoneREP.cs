using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class TelefoneREP : Repositorio<Telefone>, IDisposable
    {
        private EntitiesModel dbContext;
        
        public TelefoneREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Busca o registro de telefone baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pTelefoneID">ID do telefone do qual se necessita o registro</param>
        /// <returns>Resultado da buscar por registro de telefone com ID passado como parâmetro</returns>
        public Telefone BuscarPorID(int pTelefoneID)
        {
            return base.BuscarTodos(cc => cc.TelefoneID == pTelefoneID).FirstOrDefault();
        }
        /// <summary>
        /// Busca os registros de telefone baseado no ID da entidade passada
        /// </summary>
        /// <param name="pEntidadeID">ID da entidade da qual se necessita os registros de telefone</param>
        /// <returns>Lista de registros de telefone pertencentes a entidade passada como parâmetro</returns>
        public IList<result_BuscarTelefonePorEntidade> BuscarPorEntidade(int pEntidadeID)
        {
            return dbContext.Stp_BuscarTelefonePorEntidade(pEntidadeID).ToList();
        }
        /// <summary>
        /// Método que mantém somente 1 registro de telefone como principal para cada entidade
        /// </summary>
        /// <param name="opCanalComunicacao">Telefone que será o registro configurado como principal</param>
        /// <returns>Status de sucesso para transação sem erros e falha se houver algum erro</returns>
        public Enums.StatusTransacao AplicarRegistroPrincipal(Telefone opTelefone)
        {
            try
            {
                IList<Telefone> lstTelefone = base.BuscarTodos(tel => tel.EntidadeID == tel.EntidadeID);
                // Se houver somente 1 registro, este deve ser o principal
                if (lstTelefone.Count == 1)
                {
                    lstTelefone.FirstOrDefault().IsPrincipal = true;
                }
                else
                {
                    foreach (Telefone telItem in lstTelefone)
                    {
                        if (telItem.TelefoneID != opTelefone.TelefoneID)
                        {
                            telItem.IsPrincipal = false;
                        }
                        else
                        {
                            telItem.IsPrincipal = true;
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
        /// Método que remove a configuração de principal do objeto telefone enviado como parâmetro e altera o registro de telefone principal para o primeiro registro de telefone da entidade (se houver)
        /// </summary>
        /// <param name="opCanalComunicacao">Objeto telefone que perderá a configuração de registro principal</param>
        /// <returns>Status de sucesso para transação sem erros e falha se houver algum erro</returns>
        public Enums.StatusTransacao RemoverRegistroPrincipal(Telefone opTelefone)
        {
            try
            {
                IList<Telefone> lstTelefone = base.BuscarTodos(tel => tel.EntidadeID == opTelefone.EntidadeID);
                if (lstTelefone.Count == 1)
                {
                    lstTelefone.FirstOrDefault().IsPrincipal = true;
                    return Enums.StatusTransacao.Sucesso;
                }
                
                //Primeiro garante que todos os registros não tem índice de principal
                foreach (Telefone telItem in lstTelefone)
                {
                    telItem.IsPrincipal = false;                        
                }

                //Após isto, busca o primeiro registro de telefone da entidade, que seja diferente do parâmetro enviado e configura como principal
                base.BuscarTodos(tel => tel.EntidadeID == opTelefone.EntidadeID && tel.TelefoneID != opTelefone.TelefoneID).FirstOrDefault().IsPrincipal = true;

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
