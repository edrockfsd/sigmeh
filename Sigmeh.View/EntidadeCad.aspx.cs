using System;
using System.Linq;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Repository;
using Telerik.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace Sigmeh.View
{
    public partial class EntidadeCad : System.Web.UI.Page
    {
        #region campos, propriedades, variáveis e etc
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularCombos();

                if (!string.IsNullOrEmpty(Request["entidadeID"]))
                {
                    if (!string.IsNullOrEmpty(Request["isNew"]))
                    {
                        Utils.Notificar(ntfGeral, "Registro de entidade salvo.", Enums.TipoNotificacao.Informacao);
                    }

                    CarregarDadosBasicosEntidade(int.Parse(Request["entidadeID"]));
                }
            }
        }
        protected void menu_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "novo":
                    Response.Redirect("EntidadeCad.aspx");
                    break;
                case "listar":
                    break;
                case "salvar":
                    // Registro básico de entidade
                    SalvarDadosBasicosEntidade();
                    break;
                case "salvar_como":
                    break;
                case "imprimir":
                    break;
            }
        }

        #region entidade

        #region métodos
        private void CarregarDadosBasicosEntidade(int pEntidadeID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                try
                {
                    Entidade oEntidade = oUnitOfWork.EntidadeREP.BuscarPorID(pEntidadeID);                    

                    ddlTipoEntidade.SelectedValue = oEntidade.EntidadeTipoID.ToString();
                    txtObservacao.Text = oEntidade.Observacao;
                    chkIsInativo.Checked = oEntidade.Inativo;

                    if (oEntidade.TipoPessoa == "PF")
                    {
                        rbtPessoaFisica.Checked = true;
                        ConfigurarTelaPessoaFisica();
                        txtNome.Text = oEntidade.Nome;
                        txtApelido.Text = oEntidade.Apelido;
                        txtCPF.Text = oEntidade.CPF;
                        txtDataNascimento.SelectedDate = oEntidade.DataNascimento;
                    }
                    if (oEntidade.TipoPessoa == "PJ")
                    {
                        rbtPessoaJuridica.Checked = true;
                        ConfigurarTelaPessoaJuridica();
                        txtRazaoSocial.Text = oEntidade.Nome;
                        txtFantasia.Text = oEntidade.Apelido;
                        txtCNPJ.Text = oEntidade.CNPJ;
                    }

                    hdnIsEntidadeValida.Value = "true"; // Se for passado um código de entidade não válido, os grids não devem ser mostrados/habilitados para execução de operações.
                }
                catch (Exception ex)
                {
                    hdnIsEntidadeValida.Value = "false"; // Se for passado um código de entidade não válido, os grids não devem ser mostrados/habilitados para execução de operações.

                    Utils.Notificar(ntfGeral, "Não foi possível carregar os dados da entidade selecionada. Selecione uma entidade válida", Enums.TipoNotificacao.Erro);
                    Log.Trace(ex, true);
                }
            }
        }
        private void PopularCombos()
        {
            ddlTipoEntidade.DataValueField = "Key";
            ddlTipoEntidade.DataTextField = "Value";

            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                ddlTipoEntidade.DataSource = oUnitOfWork.EntidadeTipoREP.BuscarTodosKeyValue().OrderByDescending(ent => ent.Key);
            }

            ddlTipoEntidade.DataBind();
        }
        private void SalvarDadosBasicosEntidade()
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                try
                {
                    Entidade _entidade;

                    // Inserção
                    if (string.IsNullOrEmpty(Request["EntidadeID"]))
                    {
                        _entidade = new Entidade();                        
                        _entidade.Rowguid = SequentialGuid.NewGuid();
                        _entidade.DataCriacao = DateTime.Now;
                        _entidade.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                        _entidade.Inativo = chkIsInativo.Checked;

                        _entidade.EntidadeTipoID = int.Parse(ddlTipoEntidade.SelectedValue);
                        if (rbtPessoaFisica.Checked)
                        {
                            _entidade.CPF = txtCPF.Text;
                            _entidade.CNPJ = null;
                            _entidade.TipoPessoa = rbtPessoaFisica.Value;
                            _entidade.Nome = txtNome.Text.Trim();
                            _entidade.Apelido = txtApelido.Text.Trim();
                        }
                        else
                        {
                            _entidade.CNPJ = txtCNPJ.Text;
                            _entidade.CPF = null;
                            _entidade.TipoPessoa = rbtPessoaJuridica.Value;
                            _entidade.Nome = txtRazaoSocial.Text.Trim();
                            _entidade.Apelido = txtFantasia.Text.Trim();
                        }
                        _entidade.DataNascimento = txtDataNascimento.SelectedDate;
                        _entidade.DataModificacao = DateTime.Now;
                        _entidade.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                        _entidade.Observacao = txtObservacao.Text;

                        oUnitOfWork.EntidadeREP.Adicionar(_entidade);                        
                    }
                    // Atualização
                    else
                    {
                        _entidade = oUnitOfWork.EntidadeREP.BuscarPorID(int.Parse(Request["entidadeID"]));                        
                        _entidade.Inativo = chkIsInativo.Checked;
                        _entidade.EntidadeTipoID = int.Parse(ddlTipoEntidade.SelectedValue);
                        if (rbtPessoaFisica.Checked)
                        {
                            _entidade.CPF = txtCPF.Text;
                            _entidade.CNPJ = null;
                            _entidade.TipoPessoa = rbtPessoaFisica.Value;
                            _entidade.Nome = txtNome.Text.Trim();
                            _entidade.Apelido = txtApelido.Text.Trim();
                        }
                        else
                        {
                            _entidade.CNPJ = txtCNPJ.Text;
                            _entidade.CPF = null;
                            _entidade.TipoPessoa = rbtPessoaJuridica.Value;
                            _entidade.Nome = txtRazaoSocial.Text.Trim();
                            _entidade.Apelido = txtFantasia.Text.Trim();
                        }
                        _entidade.DataNascimento = txtDataNascimento.SelectedDate;
                        _entidade.DataModificacao = DateTime.Now;
                        _entidade.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                        _entidade.Observacao = txtObservacao.Text;

                        oUnitOfWork.EntidadeREP.Atualizar(_entidade);
                    }
                    
                    oUnitOfWork.Save();

                    if (string.IsNullOrEmpty(Request["EntidadeID"])) // TODO: Alterar os métodos de manutenção de relacionamentos de entidade
                    {
                        if (_entidade.EntidadeTipoID <= 1)
                        {
                            //_entidade.EntidadesRelacaoFilho.Add(oUnitOfWork.EntidadeREP.BuscarPorID(int.Parse(Session["ssnLoggedUserID"].ToString())));
                            //oUnitOfWork.Save();
                            oUnitOfWork.EntidadeREP.InserirRelacao(_entidade.EntidadeID, int.Parse(Session["ssnLoggedUserID"].ToString()));
                            oUnitOfWork.EntidadeREP.InserirUsuario(_entidade.EntidadeID, Utils.RemoveSpecialCharacters(_entidade.Apelido.Trim()).ToLower() + "usr", Utils.RemoveSpecialCharacters(_entidade.Apelido.Trim()).ToLower() + "psw");
                            oUnitOfWork.EntidadeREP.InserirUsuarioPerfil(_entidade.EntidadeID, 2);
                        }
                        else
                        {
                            //_entidade.EntidadesRelacaoFilho.Add(oUnitOfWork.EntidadeREP.BuscarPorID(int.Parse(Session["ssnLoggedUserID"].ToString())));
                            //oUnitOfWork.Save();
                            oUnitOfWork.EntidadeREP.InserirRelacao(int.Parse(Session["ssnLoggedUserID"].ToString()), _entidade.EntidadeID);
                            oUnitOfWork.EntidadeREP.InserirUsuario(_entidade.EntidadeID, Utils.RemoveSpecialCharacters(_entidade.Apelido.Trim()).ToLower() + "usr", Utils.RemoveSpecialCharacters(_entidade.Apelido.Trim()).ToLower() + "psw");

                            if (_entidade.EntidadeTipoID == 2)
                                oUnitOfWork.EntidadeREP.InserirUsuarioPerfil(_entidade.EntidadeID, 2);
                            else
                                oUnitOfWork.EntidadeREP.InserirUsuarioPerfil(_entidade.EntidadeID, 3);
                        }
                    }

                    Utils.Notificar(ntfGeral, "Entidade salva.", Enums.TipoNotificacao.Informacao);
                    // Para o caso de inserção
                    if (string.IsNullOrEmpty(Request["entidadeID"]))
                    {
                        Response.Redirect(string.Format("EntidadeCad.aspx?entidadeID={0}&isNew=true", _entidade.EntidadeID.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Utils.Notificar(ntfGeral, "Falha ao tentar salvar a entidade.", Enums.TipoNotificacao.Erro);
                    Log.Trace(ex, true);
                }
            }
        }
        private void ConfigurarTelaPessoaFisica()
        {
            lblApelido.Visible = true;
            txtApelido.Visible = true;
            lblNome.Visible = true;
            txtNome.Visible = true;
            lblDataNascimento.Visible = true;
            txtDataNascimento.Visible = true;
            lblCPF.Visible = true;
            txtCPF.Visible = true;

            lblRazaoSocial.Visible = false;
            txtRazaoSocial.Visible = false;
            lblFantasia.Visible = false;
            txtFantasia.Visible = false;
            lblCNPJ.Visible = false;
            txtCNPJ.Visible = false;
        }
        private void ConfigurarTelaPessoaJuridica()
        {
            lblApelido.Visible = false;
            txtApelido.Visible = false;
            lblNome.Visible = false;
            txtNome.Visible = false;
            txtDataNascimento.Visible = false;
            lblDataNascimento.Visible = false;
            lblCPF.Visible = false;
            txtCPF.Visible = false;

            lblRazaoSocial.Visible = true;
            txtRazaoSocial.Visible = true;
            lblFantasia.Visible = true;
            txtFantasia.Visible = true;
            lblCNPJ.Visible = true;
            txtCNPJ.Visible = true;
        }

        #endregion
        #region eventos
        protected void rbtPessoaFisica_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPessoaFisica();
        }
        protected void rbtPessoaJuridica_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPessoaJuridica();
        }
        #endregion

        #endregion

        #region canais de comunicação

        #region métodos

        #endregion
        #region eventos
        protected void grdCanaisComunicacao_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request["EntidadeID"] != null && bool.Parse(hdnIsEntidadeValida.Value))
            {
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    grdCanaisComunicacao.DataSource = oUnitOfWork.CanalComunicacaoREP.BuscarPorEntidade(int.Parse(Request["EntidadeID"]));
                }
            }
        }
        protected void grdCanaisComunicacao_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            try
            {
                for (int i = 0; i < e.Commands.Count; i++)
                {
                    var currentCommand = e.Commands[i];

                    if (currentCommand.Type.ToString() == "Insert")
                    {
                        if (!string.IsNullOrEmpty(Request["EntidadeID"]))
                        {
                            CanalComunicacao _canalComunicacao = new CanalComunicacao();
                            _canalComunicacao.EntidadeID = int.Parse(Request["EntidadeID"]);
                            _canalComunicacao.CanalComunicacaoTipoID = int.Parse(currentCommand.NewValues["CanalComunicacaoTipoID"].ToString());
                            _canalComunicacao.Descricao = currentCommand.NewValues["Descricao"].ToString();
                            _canalComunicacao.DataCriacao = DateTime.Now;
                            _canalComunicacao.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                            _canalComunicacao.DataModificacao = DateTime.Now;
                            _canalComunicacao.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString()); ;

                            using (UnitOfWork oUnitOfWork = new UnitOfWork())
                            {
                                // Persistindo o obj. canal na base de dados
                                oUnitOfWork.CanalComunicacaoREP.Adicionar(_canalComunicacao);
                                oUnitOfWork.Save();

                                // Se o canal for principal, os outros devem ser "não principais"
                                if (bool.Parse(currentCommand.NewValues["IsPrincipal"].ToString()))
                                {
                                    oUnitOfWork.CanalComunicacaoREP.AplicarRegistroPrincipal(_canalComunicacao);
                                    oUnitOfWork.Save();
                                }
                                else
                                {
                                    oUnitOfWork.CanalComunicacaoREP.RemoverRegistroPrincipal(_canalComunicacao);
                                    oUnitOfWork.Save();
                                }
                            }
                        }
                        else
                        {
                            Utils.Notificar(ntfGeral, "Entidade desconhecida. Selecione uma entidade para adicionar canais de comunicação.", Enums.TipoNotificacao.Alerta);
                        }
                    }
                    if (currentCommand.Type.ToString() == "Update")
                    {
                        using (UnitOfWork oUnitOfWork = new UnitOfWork())
                        {
                            if (!string.IsNullOrEmpty(Request["EntidadeID"]))
                            {
                                CanalComunicacao _canalComunicacao = oUnitOfWork.CanalComunicacaoREP.BuscarPorID(int.Parse(currentCommand.NewValues["CanalComunicacaoID"].ToString()));
                                _canalComunicacao.CanalComunicacaoTipoID = int.Parse(currentCommand.NewValues["CanalComunicacaoTipoID"].ToString());
                                _canalComunicacao.Descricao = currentCommand.NewValues["Descricao"].ToString();
                                _canalComunicacao.DataModificacao = DateTime.Now;
                                _canalComunicacao.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());


                                oUnitOfWork.CanalComunicacaoREP.Atualizar(_canalComunicacao);
                                oUnitOfWork.Save();

                                // Se o canal for principal, os outros devem ser "não principais"
                                if (bool.Parse(currentCommand.NewValues["IsPrincipal"].ToString()))
                                {
                                    oUnitOfWork.CanalComunicacaoREP.AplicarRegistroPrincipal(_canalComunicacao);
                                    oUnitOfWork.Save();
                                }
                                else
                                {
                                    oUnitOfWork.CanalComunicacaoREP.RemoverRegistroPrincipal(_canalComunicacao);
                                    oUnitOfWork.Save();
                                }
                            }
                            else
                            {
                                Utils.Notificar(ntfGeral, "Entidade desconhecida. Selecione uma entidade para adicionar canais de comunicação.", Enums.TipoNotificacao.Alerta);
                            }

                        }
                    }
                    if (currentCommand.Type.ToString() == "Delete")
                    {
                        using (UnitOfWork oUnitOfWork = new UnitOfWork())
                        {
                            if (!string.IsNullOrEmpty(Request["EntidadeID"]))
                            {
                                CanalComunicacao _canalComunicacao = oUnitOfWork.CanalComunicacaoREP.BuscarPorID(int.Parse(currentCommand.NewValues["CanalComunicacaoID"].ToString()));

                                // Se o canal for principal, o primeiro canal que sobrar deve tomar o posto de canal principal
                                if (_canalComunicacao.IsPrincipal)
                                {
                                    oUnitOfWork.CanalComunicacaoREP.RemoverRegistroPrincipal(_canalComunicacao);
                                }

                                oUnitOfWork.CanalComunicacaoREP.Remover(_canalComunicacao);
                                oUnitOfWork.Save();
                            }
                            else
                            {
                                Utils.Notificar(ntfGeral, "Entidade desconhecida. Selecione uma entidade para excluir.", Enums.TipoNotificacao.Alerta);
                            }

                        }
                    }
                }

                Utils.Notificar(ntfGeral, "Registros de Canal de comunicação atualizados.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao salvar.", Enums.TipoNotificacao.Erro);
            }
        }
        #endregion

        #endregion

        #region telefone

        #region métodos

        #endregion
        #region eventos

        protected void grdTelefone_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (Request["EntidadeID"] != null && bool.Parse(hdnIsEntidadeValida.Value))
            {
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {

                    grdTelefone.DataSource = oUnitOfWork.TelefoneREP.BuscarPorEntidade(int.Parse(Request["EntidadeID"]));
                }
            }
        }
        protected void grdTelefone_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            try
            {
                for (int i = 0; i < e.Commands.Count; i++)
                {
                    var currentCommand = e.Commands[i];

                    if (currentCommand.Type.ToString() == "Insert")
                    {
                        if (!string.IsNullOrEmpty(Request["EntidadeID"]))
                        {
                            Telefone _telefone = new Telefone();
                            _telefone.EntidadeID = int.Parse(Request["EntidadeID"]);
                            _telefone.TelefoneTipoID = int.Parse(currentCommand.NewValues["TelefoneTipoID"].ToString());
                            _telefone.DDD = int.Parse(currentCommand.NewValues["DDD"].ToString());
                            _telefone.Numero = int.Parse(currentCommand.NewValues["Numero"].ToString());
                            _telefone.DataCriacao = DateTime.Now;
                            _telefone.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                            _telefone.DataModificacao = DateTime.Now;
                            _telefone.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());

                            using (UnitOfWork oUnitOfWork = new UnitOfWork())
                            {
                                // Persistindo o obj. telefone na base de dados
                                oUnitOfWork.TelefoneREP.Adicionar(_telefone);
                                oUnitOfWork.Save();

                                // Se o telefone, os outros não podem ser "não principais"
                                if (bool.Parse(currentCommand.NewValues["IsPrincipal"].ToString()))
                                {
                                    oUnitOfWork.TelefoneREP.AplicarRegistroPrincipal(_telefone);
                                    oUnitOfWork.Save();
                                }
                                else
                                {
                                    oUnitOfWork.TelefoneREP.RemoverRegistroPrincipal(_telefone);
                                    oUnitOfWork.Save();
                                }
                            }
                        }
                        else
                        {
                            Utils.Notificar(ntfGeral, "Entidade desconhecida. Selecione uma entidade para adicionar canais de comunicação.", Enums.TipoNotificacao.Alerta);
                        }
                    }
                    if (currentCommand.Type.ToString() == "Update")
                    {
                        using (UnitOfWork oUnitOfWork = new UnitOfWork())
                        {
                            if (!string.IsNullOrEmpty(Request["EntidadeID"]))
                            {
                                Telefone _telefone = oUnitOfWork.TelefoneREP.BuscarPorID(int.Parse(currentCommand.NewValues["TelefoneID"].ToString()));
                                _telefone.TelefoneTipoID = int.Parse(currentCommand.NewValues["TelefoneTipoID"].ToString());
                                _telefone.DDD = int.Parse(currentCommand.NewValues["DDD"].ToString());
                                _telefone.Numero = int.Parse(currentCommand.NewValues["Numero"].ToString());
                                _telefone.DataModificacao = DateTime.Now;
                                _telefone.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());


                                oUnitOfWork.TelefoneREP.Atualizar(_telefone);
                                oUnitOfWork.Save();

                                // Se o telefone, os outros devem ser "não principais"
                                if (bool.Parse(currentCommand.NewValues["IsPrincipal"].ToString()))
                                {
                                    oUnitOfWork.TelefoneREP.AplicarRegistroPrincipal(_telefone);
                                    oUnitOfWork.Save();
                                }
                                else
                                {
                                    oUnitOfWork.TelefoneREP.RemoverRegistroPrincipal(_telefone);
                                    oUnitOfWork.Save();
                                }
                            }
                            else
                            {
                                Utils.Notificar(ntfGeral, "Entidade desconhecida. Selecione uma entidade para adicionar canais de comunicação.", Enums.TipoNotificacao.Alerta);
                            }

                        }
                    }
                    if (currentCommand.Type.ToString() == "Delete")
                    {
                        using (UnitOfWork oUnitOfWork = new UnitOfWork())
                        {
                            if (!string.IsNullOrEmpty(Request["EntidadeID"]))
                            {
                                Telefone _telefone = oUnitOfWork.TelefoneREP.BuscarPorID(int.Parse(currentCommand.NewValues["TelefoneID"].ToString()));

                                // Se o telefone, o primeiro canal que sobrar deve tomar o posto de canal principal
                                if (_telefone.IsPrincipal)
                                {
                                    oUnitOfWork.TelefoneREP.RemoverRegistroPrincipal(_telefone);
                                }

                                oUnitOfWork.TelefoneREP.Remover(_telefone);
                                oUnitOfWork.Save();
                            }
                            else
                            {
                                Utils.Notificar(ntfGeral, "Entidade desconhecida. Selecione uma entidade para excluir.", Enums.TipoNotificacao.Alerta);
                            }

                        }
                    }
                }

                Utils.Notificar(ntfGeral, "Registros de telefone atualizados.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao salvar.", Enums.TipoNotificacao.Erro);
            }
        }

        #endregion

        #endregion

        #region endereços

        #region métodos

        #endregion
        #region eventos

        protected void btnPesquisarCEP_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            ImageButton btnPesquisarCEP = (ImageButton)sender;
            if (btnPesquisarCEP.NamingContainer is GridDataItem)
            {
                GridDataItem editItem = (GridDataItem)btnPesquisarCEP.NamingContainer;
                RadMaskedTextBox txtCEP = (RadMaskedTextBox)editItem.FindControl("txtCEP");
                if (!string.IsNullOrEmpty(txtCEP.Text))
                {
                    RadTextBox txtLogradouro = (RadTextBox)editItem.FindControl("txtLogradouro");
                    RadTextBox txtBairro = (RadTextBox)editItem.FindControl("txtBairro");
                    RadTextBox txtCidadeNome = (RadTextBox)editItem.FindControl("txtCidadeNome");
                    HiddenField hdnCidadeID = (HiddenField)editItem.FindControl("hdnCidadeID");
                    RadTextBox txtUF = (RadTextBox)editItem.FindControl("txtUF");
                    RadTextBox txtPaisNome = (RadTextBox)editItem.FindControl("txtPaisNome");

                    result_BuscarEnderecoCep _buscarEnderecoCep;
                    using (UnitOfWork oUnitOfWork = new UnitOfWork())
                    {
                        _buscarEnderecoCep = oUnitOfWork.EntidadeREP.BuscarEnderecoCep(txtCEP.Text, txtBairro.Text, txtLogradouro.Text, null);
                    }

                    if (_buscarEnderecoCep != null)
                    {
                        txtLogradouro.Text = _buscarEnderecoCep.Logradouro;
                        txtBairro.Text = _buscarEnderecoCep.BairroNome;
                        txtCidadeNome.Text = _buscarEnderecoCep.CidadeNome;
                        hdnCidadeID.Value = _buscarEnderecoCep.CidadeID.ToString();
                        txtUF.Text = _buscarEnderecoCep.Sigla;
                    }
                    else
                    {
                        Utils.Notificar(ntfGeral, "C.E.P não encontrado.", Enums.TipoNotificacao.Alerta);
                    }

                }
                else
                {
                    Utils.Notificar(ntfGeral, "Informe um número válido de C.E.P para efetuar a pesquisa.", Enums.TipoNotificacao.Alerta);
                }
            }
            if (btnPesquisarCEP.NamingContainer is GridDataInsertItem)
            {
                GridDataInsertItem insertItem = (GridDataInsertItem)btnPesquisarCEP.NamingContainer;
                RadMaskedTextBox txtCEP = (RadMaskedTextBox)insertItem.FindControl("txtCEP");
                if (!string.IsNullOrEmpty(txtCEP.Text))
                {
                    RadTextBox txtLogradouro = (RadTextBox)insertItem.FindControl("txtLogradouro");
                    RadTextBox txtBairro = (RadTextBox)insertItem.FindControl("txtBairro");
                    RadTextBox txtCidadeNome = (RadTextBox)insertItem.FindControl("txtCidadeNome");
                    HiddenField hdnCidadeID = (HiddenField)insertItem.FindControl("hdnCidadeID");
                    RadTextBox txtUF = (RadTextBox)insertItem.FindControl("txtUF");
                    RadTextBox txtPaisNome = (RadTextBox)insertItem.FindControl("txtPaisNome");

                    result_BuscarEnderecoCep _buscarEnderecoCep;
                    using (UnitOfWork oUnitOfWork = new UnitOfWork())
                    {
                        _buscarEnderecoCep = oUnitOfWork.EntidadeREP.BuscarEnderecoCep(txtCEP.Text, txtBairro.Text, txtLogradouro.Text, null);
                    }

                    if (_buscarEnderecoCep != null)
                    {
                        txtLogradouro.Text = _buscarEnderecoCep.Logradouro;
                        txtBairro.Text = _buscarEnderecoCep.BairroNome;
                        txtCidadeNome.Text = _buscarEnderecoCep.CidadeNome;
                        hdnCidadeID.Value = _buscarEnderecoCep.CidadeID.ToString();
                        txtUF.Text = _buscarEnderecoCep.Sigla;
                    }
                    else
                    {
                        Utils.Notificar(ntfGeral, "C.E.P não encontrado.", Enums.TipoNotificacao.Alerta);
                    }
                }
                else
                {
                    Utils.Notificar(ntfGeral, "Informe um número válido de C.E.P para efetuar a pesquisa.", Enums.TipoNotificacao.Alerta);
                }
            }




        }
        protected void grdEndereco_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (Request["EntidadeID"] != null && bool.Parse(hdnIsEntidadeValida.Value))
            {
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {

                    grdEndereco.DataSource = oUnitOfWork.EnderecoREP.BuscarPorEntidade(int.Parse(Request["EntidadeID"]));
                }
            }
        }
        protected void grdEndereco_InsertCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataInsertItem insertedItem = (GridDataInsertItem)e.Item;
                Endereco _endereco = new Endereco();
                _endereco.EntidadeID = int.Parse(Request["EntidadeID"]);
                _endereco.Cep = (insertedItem["colCEP"].FindControl("txtCEP") as RadMaskedTextBox).Text;
                _endereco.Logradouro = (insertedItem["colLogradouro"].FindControl("txtLogradouro") as RadTextBox).Text;
                _endereco.Numero = int.Parse((insertedItem["colNumero"].FindControl("txtNumero") as RadMaskedTextBox).Text);
                _endereco.Complemento = (insertedItem["colComplemento"].FindControl("txtComplemento") as RadTextBox).Text;
                _endereco.Bairro = (insertedItem["colBairro"].FindControl("txtBairro") as RadTextBox).Text;
                _endereco.CidadeID = int.Parse((insertedItem["colCidade"].FindControl("hdnCidadeID") as HiddenField).Value);
                _endereco.EnderecoTipoID = int.Parse((insertedItem["colEnderecoTipo"].Controls[1] as RadComboBox).SelectedValue);
                _endereco.DataCriacao = DateTime.Now;
                _endereco.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                _endereco.DataModificacao = DateTime.Now;
                _endereco.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    oUnitOfWork.EnderecoREP.Adicionar(_endereco);
                    oUnitOfWork.Save();

                    // Se o canal for principal, os outros devem ser "não principais"
                    if ((insertedItem["colIsPrincipal"].Controls[0] as CheckBox).Checked)
                    {
                        oUnitOfWork.EnderecoREP.AplicarRegistroPrincipal(_endereco);
                        oUnitOfWork.Save();
                    }
                    else
                    {
                        oUnitOfWork.EnderecoREP.RemoverRegistroPrincipal(_endereco);
                        oUnitOfWork.Save();
                    }
                }

                Utils.Notificar(ntfGeral, "Registros de endereço atualizados.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar incluir registro de endereço.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdEndereco_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem editedItem = (GridDataItem)e.Item;

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    Endereco _endereco = oUnitOfWork.EnderecoREP.BuscarPorID(int.Parse(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["EnderecoID"].ToString()));
                    _endereco.EntidadeID = int.Parse(Request["EntidadeID"]);
                    _endereco.Cep = (editedItem["colCEP"].FindControl("txtCEP") as RadMaskedTextBox).Text;
                    _endereco.Logradouro = (editedItem["colLogradouro"].FindControl("txtLogradouro") as RadTextBox).Text;
                    _endereco.Numero = int.Parse((editedItem["colNumero"].FindControl("txtNumero") as RadMaskedTextBox).Text);
                    _endereco.Complemento = (editedItem["colComplemento"].FindControl("txtComplemento") as RadTextBox).Text;
                    _endereco.Bairro = (editedItem["colBairro"].FindControl("txtBairro") as RadTextBox).Text;
                    _endereco.CidadeID = int.Parse((editedItem["colCidade"].FindControl("hdnCidadeID") as HiddenField).Value);
                    _endereco.IsPrincipal = (editedItem["colIsPrincipal"].Controls[0] as CheckBox).Checked;
                    _endereco.EnderecoTipoID = int.Parse((editedItem["colEnderecoTipo"].Controls[1] as RadComboBox).SelectedValue);
                    _endereco.DataModificacao = DateTime.Now;
                    _endereco.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());


                    oUnitOfWork.EnderecoREP.Atualizar(_endereco);
                    oUnitOfWork.Save();

                    // Se o endereço for principal, os outros devem ser "não principais"
                    if ((editedItem["colIsPrincipal"].Controls[0] as CheckBox).Checked)
                    {
                        oUnitOfWork.EnderecoREP.AplicarRegistroPrincipal(_endereco);
                        oUnitOfWork.Save();
                    }
                    else
                    {
                        oUnitOfWork.EnderecoREP.RemoverRegistroPrincipal(_endereco);
                        oUnitOfWork.Save();
                    }
                }

                Utils.Notificar(ntfGeral, "Registros de endereço atualizados.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar incluir registro de endereço.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdEndereco_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem editedItem = (GridDataItem)e.Item;

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    Endereco _endereco = oUnitOfWork.EnderecoREP.BuscarPorID(int.Parse(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["EnderecoID"].ToString()));

                    // Se o endereço for principal, o sistema deve delegar o índice de principal a outro registro de endereço da entidade (se houver)
                    if ((editedItem["colIsPrincipal"].Controls[0] as CheckBox).Checked)
                    {
                        oUnitOfWork.EnderecoREP.RemoverRegistroPrincipal(_endereco);
                    }

                    oUnitOfWork.EnderecoREP.Remover(_endereco);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registros de endereço atualizados.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar excluir registro de endereço.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdEndereco_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.IsInEditMode)
            {
                GridDataItem editItem = (GridDataItem)e.Item;
                RadComboBox ddlEnderecoTipo = (RadComboBox)editItem.FindControl("ddlEnderecoTipo");
                HiddenField hdnEnderecoTipoID = (HiddenField)editItem.FindControl("hdnEnderecoTipoID");
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    ddlEnderecoTipo.DataSource = oUnitOfWork.EnderecoTipoREP.BuscarTodosKeyValue();
                }
                ddlEnderecoTipo.DataValueField = "Key";
                ddlEnderecoTipo.DataTextField = "Value";
                ddlEnderecoTipo.SelectedValue = hdnEnderecoTipoID.Value;
                ddlEnderecoTipo.DataBind();
            }
        }

        #endregion

        #endregion
    }
}