using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class EnderecoREP : Repositorio<Endereco>, IDisposable
    {
        private EntitiesModel dbContext;

        public EnderecoREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Busca o registro de endereço baseado no ID passado como parâmetro
        /// </summary>
        /// <param name="pCanalComunicacaoID">ID do endereço do qual se necessita o registro</param>
        /// <returns>Resultado da buscar por registro de endereço com ID passado como parâmetro</returns>
        public Endereco BuscarPorID(int pEnderecoID)
        {
            return base.BuscarTodos(ende => ende.EnderecoID == pEnderecoID).FirstOrDefault();
        }
        /// <summary>
        /// Busca os registros de endereço baseado no ID da entidade passada
        /// </summary>
        /// <param name="pEntidadeID">ID da entidade da qual se necessita os registros de endereço</param>
        /// <returns>Lista de registros de endereço pertencentes a entidade passada como parâmetro</returns>
        public IList<result_BuscarEnderecoPorEntidade> BuscarPorEntidade(int pEntidadeID)
        {
            return dbContext.Stp_BuscarEnderecoPorEntidade(pEntidadeID).ToList();
        }
        /// <summary>
        /// Método que mantém somente 1 endereço de telefone como principal para cada entidade
        /// </summary>
        /// <param name="opCanalComunicacao">Endereço que será o registro configurado como principal</param>
        /// <returns>Status de sucesso para transação sem erros e falha se houver algum erro</returns>
        public Enums.StatusTransacao AplicarRegistroPrincipal(Endereco opEndereco)
        {
            try
            {
                IList<Endereco> lstEndereco = base.BuscarTodos(ende => ende.EntidadeID == ende.EntidadeID);
                // Se houver somente 1 registro, este deve ser o principal
                if (lstEndereco.Count == 1)
                {
                    lstEndereco.FirstOrDefault().IsPrincipal = true;
                }
                else
                {
                    foreach (Endereco endeItem in lstEndereco)
                    {
                        if (endeItem.EnderecoID != opEndereco.EnderecoID)
                        {
                            endeItem.IsPrincipal = false;
                        }
                        else
                        {
                            endeItem.IsPrincipal = true;
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
        /// Método que remove a configuração de principal do objeto endereço enviado como parâmetro e altera o registro de endereço principal para o primeiro registro de endereço da entidade (se houver)
        /// </summary>
        /// <param name="opCanalComunicacao">Objeto endereço que perderá a configuração de registro principal</param>
        /// <returns>Status de sucesso para transação sem erros e falha se houver algum erro</returns>
        public Enums.StatusTransacao RemoverRegistroPrincipal(Endereco opEndereco)
        {
            try
            {
                IList<Endereco> lstEndereco = base.BuscarTodos(ende => ende.EntidadeID == opEndereco.EntidadeID);

                if (lstEndereco.Count == 1)
                {
                    lstEndereco.FirstOrDefault().IsPrincipal = true;
                    return Enums.StatusTransacao.Sucesso;
                }

                //Primeiro garante que todos os registros não tem índice de principal
                foreach (Endereco endeItem in lstEndereco)
                {
                    endeItem.IsPrincipal = false;
                }

                //Após isto, busca o primeiro registro de endereço da entidade, que seja diferente do parâmetro enviado e configura como principal
                base.BuscarTodos(ende => ende.EntidadeID == opEndereco.EntidadeID && ende.EnderecoID != opEndereco.EnderecoID).FirstOrDefault().IsPrincipal = true;

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
