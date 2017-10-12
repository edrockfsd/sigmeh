using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Model.Repositorios;
using System;
using System.Collections.Generic;

namespace Sigmeh.Repository
{
    public class UsuarioREP : Repositorio<Usuario>, IDisposable
    {
        private EntitiesModel dbContext;

        public UsuarioREP(EntitiesModel context)
            : base(context)
        {
            dbContext = context;
        }

        public void Dispose()
        {

        }

        public IList<Perfil> BuscarPerfis(int pUsuarioID)
        {
            return dbContext.Usuarios.Where(usu => usu.UsuarioID == pUsuarioID).FirstOrDefault().Perfils;
        }

        public bool EhAutorizado(int pUsuarioID, string pDescricaoArea)
        {
            IList<Perfil> perfis = dbContext.Usuarios.Where(usu => usu.UsuarioID == pUsuarioID).FirstOrDefault().Perfils;

            if (perfis.Where(per => per.Areas.Any(are => are.Url.ToLower() == pDescricaoArea.ToLower())).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario Autenticar(string pLogin, string pSenha)
        {
            return dbContext.Usuarios.Where(usu => usu.Login.Equals(pLogin, StringComparison.CurrentCultureIgnoreCase) && usu.Senha.Equals(pSenha, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public IList<Entidade> ListarEmpresasUsuario(int pUsuarioID)
        {
            // Se for entidade do tipo 2, retorna os pais diretamente
            // Se for entidade do tipo 3, e tiver como pai entidade do tipo 2, precisa buscar os "avós"

            int _entidadeTipoID = dbContext.Entidades.Where(enc => enc.EntidadeID.Equals(pUsuarioID)).FirstOrDefault().EntidadeTipoID;
            List<int> lstIDEntidadesPai = new List<int>(); // Objeto usado para guardar os IDs das entidades pai do usuário

            switch (_entidadeTipoID)
            {
                case 1: // Tipo de entidade Hospital não terá acesso direto ao sistema, somente através de funcionário vinculado             
                    break;
                case 2:// Tipo de entidade Empresa de manutenção
                    lstIDEntidadesPai = dbContext.Entidades.Where(ent => ent.EntidadeID.Equals(pUsuarioID)).FirstOrDefault().EntidadesRelacaoPai.Select(enr => enr.EntidadeID).ToList();
                    break;
                case 3:// Tipo de entidade Funcionário
                    lstIDEntidadesPai = dbContext.Entidades.Where(ent => ent.EntidadeID.Equals(pUsuarioID)).FirstOrDefault().EntidadesRelacaoPai.Select(ent => ent.EntidadeID).ToList(); //.FirstOrDefault().EntidadesRelacaoPai.Select(enr => enr.EntidadeID).ToList(); // Uma entidade do tipo 3 só pode ter 1 pai e ao mesmo tempo não pode ser pai.
                    break;
            }

            List<Entidade> result = (from ent in dbContext.Entidades
                                     where lstIDEntidadesPai.Contains(ent.EntidadeID)
                                     select ent).ToList();

            return result;
        }
    }
}


