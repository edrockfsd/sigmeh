using Sigmeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;

namespace Sigmeh.Controller
{
    public class EntidadeController
    {        
        private EntidadeDAO _entidadeDAO;

        public EntidadeController()
        {   
            this._entidadeDAO = new EntidadeDAO();
        }

        public virtual IList<Entidade> ObterEntidades()
        {
            return this._entidadeDAO.ObterTodos();
        }
    }
}
