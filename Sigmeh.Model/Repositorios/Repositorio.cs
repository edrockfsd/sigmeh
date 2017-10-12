using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Sigmeh.Framework;
using Telerik.OpenAccess;

namespace Sigmeh.Model.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T>
    {
        private EntitiesModel dbContext;

        public Repositorio(EntitiesModel context)
        {
            // TODO: Complete member initialization
            this.dbContext = context;
        }

        public void Dispose()
        {
            // TODO: Implementar método dispose da repositorio
            throw new NotImplementedException();
        }

        public IList<T> BuscarTodos()
        {
            return dbContext.GetAll<T>().ToList();
        }

        public int ContarTodos()
        {
            return this.dbContext.GetAll<T>().Count();
        }

        public IList<T> BuscarTodos(Expression<Func<T, bool>> predicate)
        {
            return this.dbContext.GetAll<T>().Where(predicate).ToList();
        }

        public Enums.StatusTransacao Adicionar(T entidade)
        {
            try
            {
                if (entidade == null)
                {
                    throw new ArgumentNullException("Parâmetro enviado", "O parâmetro passado não pode ser nulo.");
                }

                this.dbContext.Add(entidade);                

                return Enums.StatusTransacao.Sucesso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Enums.StatusTransacao Remover(T entidade)
        {
            try
            {
                if (entidade == null)
                {
                    throw new ArgumentNullException("Parâmetro enviado", "O parâmetro passado não pode ser nulo.");
                }

                this.dbContext.Delete(entidade);
                

                return Enums.StatusTransacao.Sucesso;
            }
            catch (Exception ex)
            {
                // TODO: Desenvolver gerenciamento de erros.
                //ErrorHandler(ex);
                return Enums.StatusTransacao.Falha;
            }
        }

        public Enums.StatusTransacao Atualizar(T entidade)
        {
            try
            {
                if (entidade == null)
                {
                    throw new ArgumentNullException("Parâmetro enviado", "O parâmetro passado não pode ser nulo.");
                }


                T detachedEntidade = this.dbContext.CreateDetachedCopy(entidade);
                this.dbContext.AttachCopy(detachedEntidade);                

                return Enums.StatusTransacao.Sucesso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          
    }
}
