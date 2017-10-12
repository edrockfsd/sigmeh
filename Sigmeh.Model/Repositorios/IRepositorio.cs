using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Sigmeh.Framework;

namespace Sigmeh.Model.Repositorios
{
    public interface IRepositorio<T> : IDisposable
    {
        IList<T> BuscarTodos();
        int ContarTodos();
        IList<T> BuscarTodos(Expression<Func<T, bool>> predicate);
        Enums.StatusTransacao Adicionar(T entidade);
        Enums.StatusTransacao Remover(T entidade);
        Enums.StatusTransacao Atualizar(T entidade);
    }
}
