using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Repository;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Sigmeh.View
{
    public partial class RMECad : System.Web.UI.Page
    {
        #region campos, propriedades e variáveis

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularCombos();

                if (string.IsNullOrEmpty(Request["registroManutencaoID"]))
                {
                    txtDataRealizacao.SelectedDate = DateTime.Now;
                    lblPecas.Visible = false;
                    grdItemManutencao.Visible = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request["isNew"]))
                    {
                        Utils.Notificar(ntfGeral, "Registro de manutenção de equipamento inserido.", Enums.TipoNotificacao.Informacao);
                    }

                    CarregarDadosRME(int.Parse(Request["registroManutencaoID"]));
                }
            }
        }
        protected void menu_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "novo":
                    Response.Redirect("RMECad.aspx");
                    break;
                case "listar":
                    Response.Redirect("RMELis.aspx");
                    break;
                case "salvar":
                    if (string.IsNullOrEmpty(Request["registroManutencaoID"]))
                        Inserir();
                    else
                        Atualizar(int.Parse(Request["registroManutencaoID"]));

                    if (ddlStatus.SelectedItem.Text == "Finalizado")
                    {
                        AlterarControlesFinalizacao();
                    }
                    break;
                case "salvar_como":
                    break;
                case "excluir":
                    Excluir(int.Parse(Request["registroManutencaoID"]));
                    break;
                case "imprimir":
                    break;
            }
        }

        protected void menu_PreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["registroManutencaoID"]))
            {
                menu.FindItemByValue("excluir").Enabled = false;
                menu.FindItemByValue("salvar_como").Enabled = false;
                menu.FindItemByValue("imprimir").Enabled = false;
            }
        }

        #region métodos

        protected void Inserir()
        {
            // Inserção
            if (string.IsNullOrEmpty(Request["registroManutencaoID"]))
            {
                RegistroManutencao _registroManutencao = new RegistroManutencao();                
                _registroManutencao.Rowguid = SequentialGuid.NewGuid();
                _registroManutencao.DataCriacao = DateTime.Now;
                _registroManutencao.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                _registroManutencao.EquipamentoID = int.Parse(hdnEquipamentoID.Value);
                _registroManutencao.ExecutorID = int.Parse(ddlExecutor.SelectedValue);
                _registroManutencao.AprovadorID = int.Parse(ddlAprovador.SelectedValue);
                _registroManutencao.ManutencaoStatusID = int.Parse(ddlStatus.SelectedValue);

                DateTime dtDataRealizacao;
                if (DateTime.TryParse(txtDataRealizacao.SelectedDate.ToString(), out dtDataRealizacao))
                    _registroManutencao.DataRealizacao = dtDataRealizacao;
                else
                    _registroManutencao.DataRealizacao = DateTime.Now;

                _registroManutencao.ManutencaoTipoID = int.Parse(ddlManutencaoTipo.SelectedValue);

                switch (ddlManutencaoTipo.SelectedValue)
                {
                    case "1":
                        _registroManutencao.RelatorioDescricao = txtRelatorioTecnico.Text;
                        _registroManutencao.DefeitoDescricao = null;
                        break;
                    case "2":
                        _registroManutencao.RelatorioDescricao = txtRelatorioTecnico.Text;
                        _registroManutencao.DefeitoDescricao = txtDefeito.Text;
                        break;
                    case "3":
                        _registroManutencao.RelatorioDescricao = null;
                        _registroManutencao.DefeitoDescricao = null;
                        break;
                }


                _registroManutencao.DataModificacao = DateTime.Now;
                _registroManutencao.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    try
                    {
                        oUnitOfWork.RegistroManutencaoREP.Adicionar(_registroManutencao);
                        oUnitOfWork.Save();

                        // TODO: Fazer um método que não precise de redirect (talvez usar hidden field);
                        Response.Redirect(string.Format("RMECad.aspx?registroManutencaoID={0}&isNew=true", _registroManutencao.RegistroManutencaoID), false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    catch (Exception ex)
                    {
                        Utils.Notificar(ntfGeral, "Falha ao tentar salvar registro de manutenção. Contate o administrador", Enums.TipoNotificacao.Erro);
                        Log.Trace(ex, true);
                        if (_registroManutencao.RegistroManutencaoID != null)
                        {
                            oUnitOfWork.RegistroManutencaoREP.Remover(_registroManutencao);
                            oUnitOfWork.Save();
                        }
                    }
                    finally { oUnitOfWork.Dispose(); }

                }
            }
            // Atualização
            else
            {

            }
        }        
        public void CarregarDadosRME(int pRegistroManutencaoID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                RegistroManutencao _RegistroManutencao = oUnitOfWork.RegistroManutencaoREP.BuscarPorID(pRegistroManutencaoID);
                if (_RegistroManutencao == null)
                {
                    Utils.Notificar(ntfGeral, "Registro de Manutenção de Equipamento não encontrado", Enums.TipoNotificacao.Alerta);
                    return;
                }

                Equipamento _Equipamento = oUnitOfWork.EquipamentoREP.BuscarPorID(_RegistroManutencao.EquipamentoID);

                txtEquipamento.Text = _Equipamento.NumeroSerie;
                txtEquipamento.Visible = true;
                ddlEquipamento.Visible = false;
                rfvEquipamento.Enabled = false;

                CarregarDadosEquipamento(oUnitOfWork, _Equipamento);

                ddlManutencaoTipo.Enabled = false;

                ddlManutencaoTipo.SelectedValue = _RegistroManutencao.ManutencaoTipoID.ToString();

                AlterarTipoManutencao(_RegistroManutencao.ManutencaoTipoID);

                RegistroManutencaoArquivo _registroManutencaoArquivo = oUnitOfWork.RegistroManutencaoArquivoREP.BuscarPorID(_RegistroManutencao.RegistroManutencaoID);

                if (_registroManutencaoArquivo != null)
                {
                    string caminhoArquivo = Server.MapPath(_registroManutencaoArquivo.ArquivoUrl);
                    if (File.Exists(caminhoArquivo))
                    {
                        btnCalibracaoUpload.ImageUrl = _registroManutencaoArquivo.ArquivoUrl;
                        btnCalibracaoUpload.Visible = true;
                    }
                }

                ddlStatus.SelectedValue = _RegistroManutencao.ManutencaoStatusID.ToString();

                lblIdentificador.Text = string.Format("{0:0000}", _RegistroManutencao.RegistroManutencaoID);
                txtDataRealizacao.SelectedDate = _RegistroManutencao.DataRealizacao;
                txtDataRealizacao.Enabled = false;

                Entidade oExecutor = oUnitOfWork.EntidadeREP.BuscarPorID(_RegistroManutencao.ExecutorID);
                ddlExecutor.Items.Add(new RadComboBoxItem(oExecutor.Nome, oExecutor.EntidadeID.ToString()));
                ddlExecutor.SelectedValue = oExecutor.EntidadeID.ToString();

                Entidade oAprovador = oUnitOfWork.EntidadeREP.BuscarPorID(_RegistroManutencao.AprovadorID);
                ddlAprovador.Items.Add(new RadComboBoxItem(oAprovador.Nome, oAprovador.EntidadeID.ToString()));
                ddlAprovador.SelectedValue = oAprovador.EntidadeID.ToString();

                txtRelatorioTecnico.Text = _RegistroManutencao.RelatorioDescricao;
                txtDefeito.Text = _RegistroManutencao.DefeitoDescricao;

                if (ddlStatus.SelectedItem.Text == "Finalizado")
                {
                    AlterarControlesFinalizacao();
                }
            }
        }
        public void CarregarDadosEquipamento(UnitOfWork oUnitOfWork, Equipamento opEquipamento)
        {
            hdnEquipamentoID.Value = opEquipamento.EquipamentoID.ToString(); //Esse hidden é usado devido ao textbox usado na atualização. Se fosse usado somente o combo de equipamento, ele seria desnecessário.

            lblNoSerie.Text = opEquipamento.NumeroSerie;
            lblPatrimonio.Text = opEquipamento.Patrimonio;
            lblLocalizacao.Text = opEquipamento.Localizacao;
            lblTag.Text = opEquipamento.Tag;
            lblAcessorios.Text = opEquipamento.Acessorios;
            lblDescricao.Text = opEquipamento.Descricao;
            lblModelo.Text = opEquipamento.Marca_Modelo;
            // TODO: Checar qual melhor parâmetro para montar o código de barras
            //brcGuid.Text = oEquipamento.Equipamento.Rowguid.ToString();

            Entidade oEmpresaVinculada = oUnitOfWork.EntidadeREP.BuscarPorID(opEquipamento.EmpresaVinculadaID);
            txtEmpresaVinculada.Text = oEmpresaVinculada.Apelido;

            EquipamentoTipo oEquipamentoTipo = oUnitOfWork.EquipamentoTipoREP.BuscarPorID(opEquipamento.EquipamentoTipoID);
            txtEquipamentoTipo.Text = oEquipamentoTipo.Descricao;
        }
        private void PopularCombos()
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                ddlManutencaoTipo.DataValueField = "Key";
                ddlManutencaoTipo.DataTextField = "Value";
                ddlManutencaoTipo.DataSource = oUnitOfWork.ManutencaoTipoREP.BuscarTodosKeyValue();
                ddlManutencaoTipo.DataBind();

                ddlStatus.DataValueField = "Key";
                ddlStatus.DataTextField = "Value";
                ddlStatus.DataSource = oUnitOfWork.ManutencaoStatusREP.BuscarTodosKeyValue();
                ddlStatus.DataBind();
            }
        }
        private void Atualizar(int pRegistroManutencaoID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                try
                {
                    RegistroManutencao _registroManutencao = oUnitOfWork.RegistroManutencaoREP.BuscarPorID(pRegistroManutencaoID);
                    _registroManutencao.EquipamentoID = int.Parse(hdnEquipamentoID.Value);
                    _registroManutencao.ExecutorID = int.Parse(ddlExecutor.SelectedValue);
                    _registroManutencao.AprovadorID = int.Parse(ddlAprovador.SelectedValue);
                    _registroManutencao.ManutencaoStatusID = int.Parse(ddlStatus.SelectedValue);

                    DateTime dtDataRealizacao;
                    if (DateTime.TryParse(txtDataRealizacao.SelectedDate.ToString(), out dtDataRealizacao))
                        _registroManutencao.DataRealizacao = dtDataRealizacao;
                    else
                        _registroManutencao.DataRealizacao = DateTime.Now;

                    _registroManutencao.ManutencaoTipoID = int.Parse(ddlManutencaoTipo.SelectedValue);

                    switch (ddlManutencaoTipo.SelectedValue)
                    {
                        case "1":
                            _registroManutencao.RelatorioDescricao = txtRelatorioTecnico.Text;
                            _registroManutencao.DefeitoDescricao = null;
                            break;
                        case "2":
                            _registroManutencao.RelatorioDescricao = txtRelatorioTecnico.Text;
                            _registroManutencao.DefeitoDescricao = txtDefeito.Text;
                            break;
                        case "3":
                            _registroManutencao.RelatorioDescricao = null;
                            _registroManutencao.DefeitoDescricao = null;
                            break;
                    }


                    _registroManutencao.DataModificacao = DateTime.Now;
                    _registroManutencao.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());

                    oUnitOfWork.RegistroManutencaoREP.Atualizar(_registroManutencao);
                    oUnitOfWork.Save();

                    Utils.Notificar(ntfGeral, "Registro de Manutenção de Equipamento atualizado.", Enums.TipoNotificacao.Informacao);
                }
                catch (Exception ex)
                {
                    Utils.Notificar(ntfGeral, "Falha ao tentar salvar equipamento. Contate o administrador", Enums.TipoNotificacao.Erro);
                    Log.Trace(ex, true);
                }
                finally { oUnitOfWork.Dispose(); }
            }
        }
        private void Excluir(int pRegistroManutencaoID)
        {
            throw new NotImplementedException();
        }
        private void AlterarTipoManutencao(int pManutencaoTipoID)
        {
            switch (pManutencaoTipoID)
            {
                case 1:
                    lblRelatorioTecnico.Visible = true;
                    txtRelatorioTecnico.Visible = true;
                    rfvRelatorioTecnico.Visible = true;
                    rfvRelatorioTecnico.Enabled = true;

                    lblTituloManCorretiva.Visible = false;
                    lblDefeito.Visible = false;
                    txtDefeito.Visible = false;
                    txtDefeito.Text = "";
                    rfvDefeito.Visible = false;
                    rfvDefeito.Enabled = false;

                    lblCarregarArquivo.Visible = false;
                    uplImagens.Visible = false;
                    uplImagens.CssClass = "";
                    lblMsgUpl.Visible = false;
                    btnEnviar.Visible = false;

                    if (!string.IsNullOrEmpty(Request["registroManutencaoID"]))
                    {
                        lblPecas.Visible = true;
                        grdItemManutencao.Visible = true;
                    }
                    break;
                case 2:
                    lblRelatorioTecnico.Visible = true;
                    txtRelatorioTecnico.Visible = true;
                    rfvRelatorioTecnico.Visible = true;
                    rfvRelatorioTecnico.Enabled = true;

                    lblTituloManCorretiva.Visible = true;
                    lblDefeito.Visible = true;
                    txtDefeito.Visible = true;
                    rfvDefeito.Visible = true;
                    rfvDefeito.Enabled = true;

                    lblCarregarArquivo.Visible = false;
                    uplImagens.Visible = false;
                    uplImagens.CssClass = "";
                    lblMsgUpl.Visible = false;
                    btnEnviar.Visible = false;

                    if (!string.IsNullOrEmpty(Request["registroManutencaoID"]))
                    {
                        lblPecas.Visible = true;
                        grdItemManutencao.Visible = true;
                    }
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(Request["registroManutencaoID"]))
                    {
                        lblCarregarArquivo.Visible = true;
                        uplImagens.Visible = true;
                        uplImagens.CssClass = "";
                        lblMsgUpl.Visible = true;
                        btnEnviar.Visible = true;
                    }

                    lblRelatorioTecnico.Visible = false;
                    txtRelatorioTecnico.Visible = false;
                    rfvRelatorioTecnico.Visible = false;
                    rfvRelatorioTecnico.Enabled = false;

                    lblTituloManCorretiva.Visible = false;
                    lblDefeito.Visible = false;
                    txtDefeito.Visible = false;
                    rfvDefeito.Visible = false;
                    rfvDefeito.Enabled = false;

                    lblPecas.Visible = false;
                    grdItemManutencao.Visible = false;
                    break;
            }
        }

        #endregion

        #region eventos

        protected void ddlEquipamento_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            Dictionary<int, string> dicEquipamento = null;
            string sTexto = e.Text.Trim();
            int itemOffset = 0;
            int endOffset = 0;

            try
            {
                ddlEquipamento.Items.Clear();

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    dicEquipamento = oUnitOfWork.EquipamentoREP.FiltrarTodosKeyValue(sTexto);
                }

                itemOffset = e.NumberOfItems;
                endOffset = Math.Min(itemOffset + 10, dicEquipamento.Count);
                e.EndOfItems = endOffset == dicEquipamento.Count;

                for (int i = itemOffset; i < endOffset; i++)
                {
                    var item = dicEquipamento.ElementAt(i);

                    ddlEquipamento.Items.Add(new RadComboBoxItem(item.Value, item.Key.ToString()));
                }

                e.Message = Utils.GetStatusMessage(endOffset, dicEquipamento.Count);

            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar carregar dados de equipamentos. Contate o administrador", Enums.TipoNotificacao.Erro);
            }
        }
        protected void ddlEquipamento_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                Equipamento _Equipamento = oUnitOfWork.EquipamentoREP.BuscarPorID(int.Parse(ddlEquipamento.SelectedValue));

                CarregarDadosEquipamento(oUnitOfWork, _Equipamento);

                int _registroManutencaoID = oUnitOfWork.RegistroManutencaoREP.ChecarRMEAberto(_Equipamento.EquipamentoID);
                if (_registroManutencaoID > 0)
                {
                    AlternarStatusControlesPagina(false);
                    pnlMsgRmeAberta.Visible = true;
                    ((HyperLink)pnlMsgRmeAberta.FindControl("lnkRMEAberta")).NavigateUrl = string.Format("RMECad.aspx?registroManutencaoID={0}", _registroManutencaoID);
                }
            }
        }

        protected void ddlManutencaoTipo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            AlterarTipoManutencao(int.Parse(ddlManutencaoTipo.SelectedValue));
        }
        protected void ddlAprovador_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            Dictionary<int, string> dicEntidade = null;
            string sTexto = e.Text.Trim();
            int itemOffset = 0;
            int endOffset = 0;

            try
            {
                ddlAprovador.Items.Clear();

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    dicEntidade = oUnitOfWork.EntidadeREP.FiltrarFuncionarioKeyValue(sTexto);
                }

                itemOffset = e.NumberOfItems;
                endOffset = Math.Min(itemOffset + 10, dicEntidade.Count);
                e.EndOfItems = endOffset == dicEntidade.Count;

                for (int i = itemOffset; i < endOffset; i++)
                {
                    var item = dicEntidade.ElementAt(i);

                    ddlAprovador.Items.Add(new RadComboBoxItem(item.Value, item.Key.ToString()));
                }

                e.Message = Utils.GetStatusMessage(endOffset, dicEntidade.Count);

            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar carregar dados de funcionários. Contate o administrador", Enums.TipoNotificacao.Erro);
            }
        }
        protected void ddlExecutor_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            Dictionary<int, string> dicEntidade = null;
            string sTexto = e.Text.Trim();
            int itemOffset = 0;
            int endOffset = 0;

            try
            {
                ddlExecutor.Items.Clear();

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    dicEntidade = oUnitOfWork.EntidadeREP.FiltrarFuncionarioKeyValue(sTexto);
                }

                itemOffset = e.NumberOfItems;
                endOffset = Math.Min(itemOffset + 10, dicEntidade.Count);
                e.EndOfItems = endOffset == dicEntidade.Count;

                for (int i = itemOffset; i < endOffset; i++)
                {
                    var item = dicEntidade.ElementAt(i);

                    ddlExecutor.Items.Add(new RadComboBoxItem(item.Value, item.Key.ToString()));
                }

                e.Message = Utils.GetStatusMessage(endOffset, dicEntidade.Count);

            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar carregar dados de funcionários. Contate o administrador", Enums.TipoNotificacao.Erro);
            }
        }

        // Item de manutenção (Peças)
        protected void grdItemManutencao_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (Request["registroManutencaoID"] != null)
            {
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    grdItemManutencao.DataSource = oUnitOfWork.ItemManutencaoREP.BuscarPorRegistroManutencao(int.Parse(Request["registroManutencaoID"]));
                }
            }
        }
        protected void grdItemManutencao_InsertCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataInsertItem insertedItem = (GridDataInsertItem)e.Item;
                ItemManutencao _itemManutencao = new ItemManutencao();
                _itemManutencao.RegistroManutencaoID = int.Parse(Request["RegistroManutencaoID"]);
                _itemManutencao.Descricao = (insertedItem["colDescricao"].Controls[0] as TextBox).Text;
                _itemManutencao.Lote = (insertedItem["colLote"].Controls[0] as TextBox).Text;
                _itemManutencao.NumeroSerie = (insertedItem["colNumeroSerie"].Controls[0] as TextBox).Text;
                _itemManutencao.Quantidade = ((insertedItem["colQuantidade"].Controls[0] as RadNumericTextBox).Value != null) ? decimal.Parse((insertedItem["colQuantidade"].Controls[0] as RadNumericTextBox).Value.ToString()) : 0;
                _itemManutencao.Custo = ((insertedItem["colCusto"].Controls[0] as RadNumericTextBox).Value != null) ? decimal.Parse((insertedItem["colCusto"].Controls[0] as RadNumericTextBox).Value.ToString()) : 0;
                _itemManutencao.DataCriacao = DateTime.Now;
                _itemManutencao.UsuarioCriador = int.Parse(Session["ssnLoggedUserID"].ToString());
                _itemManutencao.DataModificacao = DateTime.Now;
                _itemManutencao.UsuarioModificador = int.Parse(Session["ssnLoggedUserID"].ToString());

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    oUnitOfWork.ItemManutencaoREP.Adicionar(_itemManutencao);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registro de produto inserido com sucesso.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar incluir registro de produto.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdItemManutencao_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem editedItem = (GridDataItem)e.Item;

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    ItemManutencao _itemManutencao = oUnitOfWork.ItemManutencaoREP.BuscarPorID(int.Parse(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["ItemManutencaoID"].ToString()));
                    _itemManutencao.RegistroManutencaoID = int.Parse(Request["RegistroManutencaoID"]);
                    _itemManutencao.Descricao = (editedItem["colDescricao"].Controls[0] as TextBox).Text;
                    _itemManutencao.Lote = (editedItem["colLote"].Controls[0] as TextBox).Text;
                    _itemManutencao.NumeroSerie = (editedItem["colNumeroSerie"].Controls[0] as TextBox).Text;
                    _itemManutencao.Quantidade = ((editedItem["colQuantidade"].Controls[0] as RadNumericTextBox).Value != null) ? decimal.Parse((editedItem["colQuantidade"].Controls[0] as RadNumericTextBox).Value.ToString()) : 0;
                    _itemManutencao.Custo = ((editedItem["colCusto"].Controls[0] as RadNumericTextBox).Value != null) ? decimal.Parse((editedItem["colCusto"].Controls[0] as RadNumericTextBox).Value.ToString()) : 0;
                    _itemManutencao.DataModificacao = DateTime.Now;
                    _itemManutencao.UsuarioModificador = int.Parse(Session["ssnLoggedUserID"].ToString());

                    oUnitOfWork.ItemManutencaoREP.Atualizar(_itemManutencao);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registro de produto atualizado.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar incluir registro de produto.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdItemManutencao_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem editedItem = (GridDataItem)e.Item;

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    ItemManutencao _itemManutencao = oUnitOfWork.ItemManutencaoREP.BuscarPorID(int.Parse(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["ItemManutencaoID"].ToString()));

                    oUnitOfWork.ItemManutencaoREP.Remover(_itemManutencao);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registro de produto excluído.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar excluir registro de produto.", Enums.TipoNotificacao.Erro);
            }
        }

        #endregion

        protected void uplImagens_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            // Somente 1 arquivo é permitido
            if (uplImagens.UploadedFiles.Count > 1)
            {
                Utils.Notificar(ntfGeral, "É permitido carregar somente 1 arquivo por registro de manutenção.", Enums.TipoNotificacao.Alerta);
                e.IsValid = false;
                return;
            }
            if (uplImagens.UploadedFiles.Count == 1)
            {
                if (uplImagens.UploadedFiles[0].ContentLength > uplImagens.MaxFileSize)
                {
                    Utils.Notificar(ntfGeral, "O tamanho máximo permitido são 2MB.", Enums.TipoNotificacao.Alerta);
                    e.IsValid = false;
                    return;
                }
            }

            using (UnitOfWork oUnityOfWork = new UnitOfWork())
            {
                RegistroManutencao _RegistroManutencao = oUnityOfWork.RegistroManutencaoREP.BuscarPorID(int.Parse(Request.QueryString["registroManutencaoID"]));
                Equipamento _Equipamento = oUnityOfWork.EquipamentoREP.BuscarPorID(_RegistroManutencao.EquipamentoID);
                string caminhoPastaArquivo = string.Format("~/Upload/{0}/RME/{1}", _Equipamento.EmpresaVinculadaID.ToString(), _RegistroManutencao.RegistroManutencaoID.ToString());


                if (!Directory.Exists(Server.MapPath(caminhoPastaArquivo)))
                {
                    Directory.CreateDirectory(Server.MapPath(caminhoPastaArquivo));
                }
                else
                {
                    // Somente uma imagem é permitida por registro de manutenção do tipo calibração
                    Directory.Delete(Server.MapPath(caminhoPastaArquivo), true);
                    Directory.CreateDirectory(Server.MapPath(caminhoPastaArquivo));
                }

                try
                {
                    uplImagens.TargetFolder = caminhoPastaArquivo;
                    btnCalibracaoUpload.Visible = true;
                    btnCalibracaoUpload.ImageUrl = string.Format("{0}/{1}", caminhoPastaArquivo, uplImagens.UploadedFiles[0].FileName);

                    Utils.Notificar(ntfGeral, "Arquivo carregado.", Enums.TipoNotificacao.Informacao);

                    RegistroManutencaoArquivo _RegistroManutencaoArquivo = oUnityOfWork.RegistroManutencaoArquivoREP.BuscarPorID(_RegistroManutencao.RegistroManutencaoID);
                    if (_RegistroManutencaoArquivo == null)
                        _RegistroManutencaoArquivo = new RegistroManutencaoArquivo();

                    _RegistroManutencaoArquivo.ArquivoNome = uplImagens.UploadedFiles[0].FileName;
                    _RegistroManutencaoArquivo.ArquivoUrl = btnCalibracaoUpload.ImageUrl;

                    if (_RegistroManutencaoArquivo.RegistroManutencaoID == null || _RegistroManutencaoArquivo.RegistroManutencaoID == 0)
                    {
                        _RegistroManutencaoArquivo.RegistroManutencaoID = _RegistroManutencao.RegistroManutencaoID;
                        oUnityOfWork.RegistroManutencaoArquivoREP.Adicionar(_RegistroManutencaoArquivo);
                        oUnityOfWork.Save();
                    }
                    else
                    {
                        oUnityOfWork.RegistroManutencaoArquivoREP.Atualizar(_RegistroManutencaoArquivo);
                        oUnityOfWork.Save();
                    }
                }
                catch (Exception ex)
                {
                    if (!Directory.Exists(Server.MapPath(uplImagens.TargetFolder)))
                    {
                        Directory.Delete(Server.MapPath(uplImagens.TargetFolder), true);
                    }
                    Log.Trace(ex, true);
                    Utils.Notificar(ntfGeral, "Não foi possível carregar o arquivo. Tente novamente em alguns instantes ou contate o administrador", Enums.TipoNotificacao.Erro);
                }
            }
        }
        protected void btnCalibracaoUpload_Click(object sender, ImageClickEventArgs e)
        {
            using (UnitOfWork oUnityOfWork = new UnitOfWork())
            {
                RegistroManutencaoArquivo _RegistroManutencaoArquivo = oUnityOfWork.RegistroManutencaoArquivoREP.BuscarPorID(int.Parse(Request.QueryString["registroManutencaoID"]));

                string caminhoArquivo = Server.MapPath(_RegistroManutencaoArquivo.ArquivoUrl);
                string extensaoArquivo = RetornaExtensaoArquivo(_RegistroManutencaoArquivo.ArquivoNome);

                Response.ContentType = string.Format("application/{0}", extensaoArquivo);
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", _RegistroManutencaoArquivo.ArquivoNome));
                Response.TransmitFile(caminhoArquivo);
                Response.End();
            }
        }
        protected string RetornaExtensaoArquivo(string pNomeArquivo)
        {
            string[] arrNomeArquivo = pNomeArquivo.Split('.');

            return arrNomeArquivo.LastOrDefault();
        }
        protected bool ExcluirArquivoCalibracao()
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                RegistroManutencaoArquivo _registroManutencaoArquivo = oUnitOfWork.RegistroManutencaoArquivoREP.BuscarPorID(int.Parse(Request.QueryString["registroManutencaoID"]));

                if (_registroManutencaoArquivo != null)
                {
                    string caminhoArquivo = Server.MapPath(_registroManutencaoArquivo.ArquivoUrl.Replace(_registroManutencaoArquivo.ArquivoNome, ""));
                    if (Directory.Exists(caminhoArquivo))
                    {
                        Directory.Delete(caminhoArquivo, true);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private void AlterarControlesFinalizacao()
        {
            imgLock.Visible = true;

            menu.FindItemByValue("salvar").Enabled = false;
            menu.FindItemByValue("salvar_como").Enabled = false;

            ddlExecutor.Enabled = false;
            ddlAprovador.Enabled = false;
            ddlStatus.Enabled = false;
            txtRelatorioTecnico.Enabled = false;

            lblCarregarArquivo.Text = "Download de arquivo:";
            lblMsgUpl.Visible = false;
            btnEnviar.Enabled = false;
            btnEnviar.Visible = false;
            uplImagens.Enabled = false;
            uplImagens.Visible = false;
            grdItemManutencao.Enabled = false;
        }
        public void AlternarStatusControlesPagina(bool EhHabilitado)
        {
            ddlEquipamento.Enabled = EhHabilitado;
            txtEmpresaVinculada.Enabled = EhHabilitado;
            txtEquipamentoTipo.Enabled = EhHabilitado;
            ddlManutencaoTipo.Enabled = EhHabilitado;
            ddlStatus.Enabled = EhHabilitado;
            ddlExecutor.Enabled = EhHabilitado;
            txtDataRealizacao.Enabled = EhHabilitado;
            ddlAprovador.Enabled = EhHabilitado;
            txtRelatorioTecnico.Enabled = EhHabilitado;
            txtDefeito.Enabled = EhHabilitado;
            menu.FindItemByValue("salvar").Enabled = EhHabilitado;
            menu.FindItemByValue("salvar_como").Enabled = EhHabilitado;
            menu.FindItemByValue("novo").Enabled = EhHabilitado;
            menu.FindItemByValue("excluir").Enabled = EhHabilitado;
            menu.FindItemByValue("imprimir").Enabled = EhHabilitado;
        }

    }
}