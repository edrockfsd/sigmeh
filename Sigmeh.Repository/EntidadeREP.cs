using System;
using System.Collections.Generic;
using System.Linq;
using Sigmeh.Model.Repositorios;
using Sigmeh.Model;

namespace Sigmeh.Repository
{
    public class EntidadeREP : Repositorio<Entidade>, IDisposable
    {
        private EntitiesModel dbContext;

        public EntidadeREP(EntitiesModel context) : base(context) { this.dbContext = context; }

        public void Dispose()
        {

        }

        public IQueryable FiltrarEntidade(bool pInativo, int pUsuarioID)
        {   
            Entidade _usuarioLogado = dbContext.Entidades.Where(ent => ent.EntidadeID.Equals(pUsuarioID)).FirstOrDefault();
            int _entidadePaiID = pUsuarioID;
            if (_usuarioLogado.EntidadeTipoID == 3)
            {
                _entidadePaiID = _usuarioLogado.EntidadesRelacaoPai.Select(enr => enr.EntidadeID).FirstOrDefault(); // Contando que uma entidade de tipo 3 (funcionário), sempre tenha unicamente 1 pai;
                pUsuarioID = _entidadePaiID;
            }

            var query1 = from ent in dbContext.Entidades                         
                         join tel in dbContext.Telefones
                         on new { idj = ent.EntidadeID, isp = true }
                         equals new { idj = tel.EntidadeID, isp = tel.IsPrincipal }
                         into ent_tel
                         from tel in ent_tel.DefaultIfEmpty()
                         join cac in dbContext.CanalComunicacaos 
                         on new { idj = ent.EntidadeID, isp = true }
                         equals new { idj = cac.EntidadeID, isp = cac.IsPrincipal }
                         into ent_cac
                         from cac in ent_cac.DefaultIfEmpty()
                         where ent.EntidadesRelacaoPai.Select(enr => enr.EntidadeID).Contains(_entidadePaiID)
                         select new
                         {
                             ent.EntidadeID,
                             ent.Nome,
                             ent.Apelido,
                             TipoPessoa = ent.TipoPessoa.Substring(1, 1),
                             CPF_CNPJ = ent.TipoPessoa == "PF" ? ent.CPF : ent.TipoPessoa == "PJ" ? ent.CNPJ : "",
                             ent.RG,
                             ent.DataNascimento,
                             ent.Observacao,
                             ent.DataModificacao,
                             ent.UsuarioModificadorID,                             
                             ent.Inativo,
                             Telefone = string.Format("({0}){1}", tel.DDD, tel.Numero),
                             Canal = cac.Descricao,
                             EntidadeTipo = ent.EntidadeTipoID == 1 ? "hospital" : ent.EntidadeTipoID == 2 ? "emp_manutencao" : ent.EntidadeTipoID == 3 ? "funcionario" : ""
                         };

            var query2 = from ent in dbContext.Entidades                         
                         join tel in dbContext.Telefones
                         on new { idj = ent.EntidadeID, isp = true }
                         equals new { idj = tel.EntidadeID, isp = tel.IsPrincipal }
                         into ent_tel
                         from tel in ent_tel.DefaultIfEmpty()
                         join cac in dbContext.CanalComunicacaos
                         on new { idj = ent.EntidadeID, isp = true }
                         equals new { idj = cac.EntidadeID, isp = cac.IsPrincipal }
                         into ent_cac
                         from cac in ent_cac.DefaultIfEmpty()
                         where ent.EntidadeID == pUsuarioID
                         select new
                         {
                             ent.EntidadeID,
                             ent.Nome,
                             ent.Apelido,
                             TipoPessoa = ent.TipoPessoa.Substring(1, 1),
                             CPF_CNPJ = ent.TipoPessoa == "PF" ? ent.CPF : ent.TipoPessoa == "PJ" ? ent.CNPJ : "",
                             ent.RG,
                             ent.DataNascimento,
                             ent.Observacao,
                             ent.DataModificacao,
                             ent.UsuarioModificadorID,                             
                             ent.Inativo,
                             Telefone = string.Format("({0}){1}", tel.DDD, tel.Numero),
                             Canal = cac.Descricao,
                             EntidadeTipo = ent.EntidadeTipoID == 1 ? "hospital" : ent.EntidadeTipoID == 2 ? "emp_manutencao" : ent.EntidadeTipoID == 3 ? "funcionario" : ""
                         };


            return query1.Concat(query2).AsQueryable();
        }

        /// <summary>
        /// Busca o registro de Entidade baseado nos dados do objeto de Entidade passado como parâmetro
        /// </summary>
        /// <param name="opEntidade">Objeto Entidade do qual se necessita o registro de Entidade</param>
        /// <returns>Resultado da buscar por registro de Entidade com ID do obj. Entidade passado como parâmetro</returns>
        public Entidade BuscarPorID(int pEntidadeID)
        {
            return base.BuscarTodos(enc => enc.EntidadeID == pEntidadeID).FirstOrDefault();
        }

        /// <summary>
        /// Retorna key/value pair (EntidadeID e Nome) do tipo Hospital (entidadeTipo igual a 1) baseado no texto de busca (para a propriedade nome)
        /// </summary>
        /// <param name="pTextoBusca">Texto para busca de entidades baseado no nome </param>
        /// <returns>Retorna dicionário com dados de EntidadeID e Nome</returns>
        public Dictionary<int, string> FiltrarHospitalKeyValue(string pTextoBusca)
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                var result = from ent in dbContext.Entidades                             
                             where ent.Nome.Contains(pTextoBusca)
                             && ent.EntidadeTipoID == 1
                             select new Entidade
                             {
                                 EntidadeID = ent.EntidadeID,
                                 Nome = ent.Nome
                             };

                return result.Distinct().ToDictionary(enc2 => enc2.EntidadeID, enc2 => enc2.Nome);
            }
        }

        /// <summary>
        /// Retorna key/value pair (EntidadeID e Nome) do tipo Funcionario (entidadeTipo igual a 3) baseado no texto de busca (para a propriedade nome)
        /// </summary>
        /// <param name="pTextoBusca">Texto para busca de entidades baseado no nome </param>
        /// <returns>Retorna dicionário com dados de EntidadeID e Nome</returns>
        public Dictionary<int, string> FiltrarFuncionarioKeyValue(string pTextoBusca)
        {
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                var result = from ent in dbContext.Entidades
                             where ent.Nome.Contains(pTextoBusca)
                             && ent.EntidadeTipoID == 3
                             select new Entidade
                             {
                                 EntidadeID = ent.EntidadeID,
                                 Nome = ent.Nome
                             };

                return result.Distinct().ToDictionary(enc2 => enc2.EntidadeID, enc2 => enc2.Nome);
            }
        }

        /// <summary>
        /// Retorna uma lista de conteúdos de entidade, baseado na lista de id passada como parâmetro
        /// </summary>
        /// <param name="lstEntidadeID"></param>
        /// <returns></returns>
        public List<Entidade> BuscarLista(List<int> lstEntidadeID)
        {
            List<Entidade> result = (from ent in dbContext.Entidades
                                     where lstEntidadeID.Contains(ent.EntidadeID)
                                     select ent).ToList();

            return result;
        }

        public void InserirRelacao(int pEntidadePaiID, int pEntidadeFilhoID)
        {
            dbContext.ExecuteNonQuery(string.Format("INSERT INTO dbo.EntidadeRelacao ( EntidadePaiID, EntidadeFilhoID ) VALUES  ({0}, {1})", pEntidadePaiID, pEntidadeFilhoID));            
            dbContext.SaveChanges();
        }

        public void InserirUsuario(int pEntidadeID, string pLogin, string pSenha)
        {
            dbContext.ExecuteNonQuery(string.Format("INSERT INTO dbo.Usuario ( UsuarioID, Login, Senha ) VALUES  ({0}, '{1}', '{2}')", pEntidadeID, pLogin, pSenha));
            dbContext.SaveChanges();
        }

        public void InserirUsuarioPerfil(int pEntidadeID, int pPerfilID)
        {   
            dbContext.ExecuteNonQuery(string.Format("INSERT INTO dbo.UsuarioPerfil ( UsuarioID, PerfilID ) VALUES  ({0}, {1})", pEntidadeID, pPerfilID));
            
            dbContext.SaveChanges();
        }

        public result_BuscarEnderecoCep BuscarEnderecoCep(string cep, string bairro, string logradouro, int? cidadeID)
        {
            return dbContext.Stp_BuscarEnderecoCep(cep, bairro, logradouro, cidadeID).FirstOrDefault();
        }
    }
}
