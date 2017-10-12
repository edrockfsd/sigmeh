using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Repository;
using Telerik.Web.UI;
using System.Collections;

namespace Sigmeh.View
{
    public partial class EquipamentoCad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularCombos();

                if (!string.IsNullOrEmpty(Request["equipamentoID"]))
                {
                    if (!string.IsNullOrEmpty(Request["isNew"]))
                    {
                        Utils.Notificar(ntfGeral, "Registro de equipamento salvo.", Enums.TipoNotificacao.Informacao);
                    }

                    CarregarDadosEquipamento(int.Parse(Request["equipamentoID"]));
                }
            }
        }

        private void PopularCombos()
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                ddlPeriodicidade.DataValueField = "Key";
                ddlPeriodicidade.DataTextField = "Value";
                ddlPeriodicidade.DataSource = oUnitOfWork.PeriodicidadeREP.BuscarTodosKeyValue();
                ddlPeriodicidade.DataBind();

                ddlPeriodicidadeCalibracao.DataValueField = "Key";
                ddlPeriodicidadeCalibracao.DataTextField = "Value";
                ddlPeriodicidadeCalibracao.DataSource = oUnitOfWork.PeriodicidadeREP.BuscarPeriodicidadesCalibracaoKeyValue();
                ddlPeriodicidadeCalibracao.DataBind();
            }
        }
        protected void menu_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "novo":
                    Response.Redirect("EquipamentoCad.aspx");
                    break;
                case "listar":
                    Response.Redirect("EquipamentoLis.aspx");
                    break;
                case "salvar":
                    if (string.IsNullOrEmpty(Request["equipamentoID"]))
                        Inserir();
                    else
                        Atualizar(int.Parse(Request["equipamentoID"]));

                    break;
                case "salvar_como":
                    break;
                case "excluir":
                    Excluir(int.Parse(Request["equipamentoID"]));
                    break;
                case "imprimir":
                    break;
            }
        }
        protected void menu_PreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["equipamentoID"]))
            {
                menu.FindItemByValue("excluir").Enabled = false;
            }
            else
            {
                menu.FindItemByValue("excluir").Enabled = true;
            }
        }

        #region métodos

        private void Inserir()
        {
            Equipamento _equipamento = new Equipamento();            
            _equipamento.Rowguid = SequentialGuid.NewGuid();
            _equipamento.DataCriacao = DateTime.Now;
            _equipamento.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
            _equipamento.Inativo = chkIsInativo.Checked;            
            _equipamento.EmpresaVinculadaID = int.Parse(ddlEmpresaVinculada.SelectedValue);
            _equipamento.NumeroSerie = txtNoSerie.Text;
            _equipamento.Tag = txtTag.Text;
            _equipamento.Patrimonio = txtPatrimonio.Text;
            _equipamento.Marca_Modelo = txtMarcaModelo.Text;
            _equipamento.Localizacao = txtLocalizacao.Text;
            _equipamento.Acessorios = txtAcessorios.Text;
            _equipamento.Descricao = txtDescricao.Text;
            _equipamento.DataModificacao = DateTime.Now;
            _equipamento.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
            _equipamento.EquipamentoTipoID = int.Parse(ddlEquipamentoTipo.SelectedValue);
            _equipamento.PeriodicidadeID = int.Parse(ddlPeriodicidade.SelectedValue);
            if (ddlPeriodicidade.SelectedValue == "9") // Se for do tipo "Especificado", deve-se salvar a quantidade de dias especificada para intervalo.
            {
                _equipamento.PeriodicidadeQtdeDias = int.Parse(txtPeriodicidadeDias.Value.ToString());
            }
            else
            {
                _equipamento.PeriodicidadeQtdeDias = null;
            }
            _equipamento.PeriodicidadeCalibracaoID = int.Parse(ddlPeriodicidadeCalibracao.SelectedValue);

            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                try
                {
                    oUnitOfWork.EquipamentoREP.Adicionar(_equipamento);
                    oUnitOfWork.Save();
                    
                    Response.Redirect(string.Format("EquipamentoCad.aspx?equipamentoID={0}&isNew=true", _equipamento.EquipamentoID), false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    Utils.Notificar(ntfGeral, "Falha ao tentar salvar equipamento. Contate o administrador", Enums.TipoNotificacao.Erro);
                    Log.Trace(ex, true);
                }
                finally { oUnitOfWork.Dispose(); }
            }
        }
        protected void Atualizar(int pEquipamentoID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                try
                {
                    Equipamento _equipamento = oUnitOfWork.EquipamentoREP.BuscarPorID(pEquipamentoID);                    
                    _equipamento.Inativo = chkIsInativo.Checked;                    
                    _equipamento.EmpresaVinculadaID = int.Parse(ddlEmpresaVinculada.SelectedValue);
                    _equipamento.NumeroSerie = txtNoSerie.Text;
                    _equipamento.Tag = txtTag.Text;
                    _equipamento.Patrimonio = txtPatrimonio.Text;
                    _equipamento.Marca_Modelo = txtMarcaModelo.Text;
                    _equipamento.Localizacao = txtLocalizacao.Text;
                    _equipamento.Acessorios = txtAcessorios.Text;
                    _equipamento.Descricao = txtDescricao.Text;
                    _equipamento.DataModificacao = DateTime.Now;
                    _equipamento.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                    _equipamento.EquipamentoTipoID = int.Parse(ddlEquipamentoTipo.SelectedValue);
                    _equipamento.PeriodicidadeID = int.Parse(ddlPeriodicidade.SelectedValue);
                    if (ddlPeriodicidade.SelectedValue == "9") // Se for do tipo "Especificado", deve-se salvar a quantidade de dias especificada para intervalo.
                    {
                        _equipamento.PeriodicidadeQtdeDias = int.Parse(txtPeriodicidadeDias.Value.ToString());
                    }
                    else
                    {
                        _equipamento.PeriodicidadeQtdeDias = null;
                    }
                    _equipamento.PeriodicidadeCalibracaoID = int.Parse(ddlPeriodicidadeCalibracao.SelectedValue);

                    oUnitOfWork.EquipamentoREP.Atualizar(_equipamento);
                    oUnitOfWork.Save();

                    Utils.Notificar(ntfGeral, "Registro de Equipamento atualizado.", Enums.TipoNotificacao.Informacao);
                }
                catch (Exception ex)
                {
                    Utils.Notificar(ntfGeral, "Falha ao tentar salvar equipamento. Contate o administrador", Enums.TipoNotificacao.Erro);
                    Log.Trace(ex, true);
                }
                finally { oUnitOfWork.Dispose(); }
            }
        }
        
        protected void CarregarDadosEquipamento(int pEquipamentoID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                Equipamento _equipamento = oUnitOfWork.EquipamentoREP.BuscarPorID(pEquipamentoID);
                if (_equipamento == null)
                {
                    Utils.Notificar(ntfGeral, "Equipamento não encontrado", Enums.TipoNotificacao.Alerta);
                    return;
                }
                chkIsInativo.Checked = _equipamento.Inativo;

                Equipamento _Equipamento = oUnitOfWork.EquipamentoREP.BuscarPorID(_equipamento.EquipamentoID);

                Entidade oEmpresaVinculada = oUnitOfWork.EntidadeREP.BuscarPorID(_Equipamento.EmpresaVinculadaID);
                ddlEmpresaVinculada.Items.Add(new RadComboBoxItem(oEmpresaVinculada.Nome, oEmpresaVinculada.EntidadeID.ToString()));
                ddlEmpresaVinculada.SelectedValue = oEmpresaVinculada.EntidadeID.ToString();

                EquipamentoTipo oEquipamentoTipo = oUnitOfWork.EquipamentoTipoREP.BuscarPorID(_Equipamento.EquipamentoTipoID);
                ddlEquipamentoTipo.Items.Add(new RadComboBoxItem(oEquipamentoTipo.Descricao, oEquipamentoTipo.EquipamentoTipoID.ToString()));
                ddlEquipamentoTipo.SelectedValue = _Equipamento.EquipamentoTipoID.ToString();

                ddlPeriodicidade.SelectedValue = _Equipamento.PeriodicidadeID.ToString();
                if (ddlPeriodicidade.SelectedValue == "9") //9 é o código para periodicidade especificada (customizada);
                {
                    txtPeriodicidadeDias.Visible = true;
                    lblDias.Visible = true;
                    lblRME.Visible = true;
                    txtPeriodicidadeDias.Value = _Equipamento.PeriodicidadeQtdeDias;
                }
                else
                {
                    lblDias.Visible = false;
                    txtPeriodicidadeDias.Visible = false;
                    lblRME.Visible = false;
                }
                ddlPeriodicidadeCalibracao.SelectedValue = _Equipamento.PeriodicidadeCalibracaoID.ToString();

                txtNoSerie.Text = _Equipamento.NumeroSerie;
                txtTag.Text = _Equipamento.Tag;
                txtPatrimonio.Text = _Equipamento.Patrimonio;
                txtMarcaModelo.Text = _Equipamento.Marca_Modelo;
                txtLocalizacao.Text = _Equipamento.Localizacao;
                txtAcessorios.Text = _Equipamento.Acessorios;
                txtDescricao.Text = _Equipamento.Descricao;

            }
        }
        private void Excluir(int pEquipamentoID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                IList<RegistroManutencao> lstRME = oUnitOfWork.RegistroManutencaoREP.BuscarPorEquipamento(pEquipamentoID);

                if (lstRME.Count > 0)
                {
                    BulletedList bltRME = winExclusao.ContentContainer.FindControl("bltRME") as BulletedList;

                    if (bltRME != null)
                    {
                        foreach (RegistroManutencao rmeItem in lstRME)
                        {
                            ListItem lstItem = new ListItem();
                            lstItem.Value = rmeItem.RegistroManutencaoID.ToString();
                            lstItem.Text = string.Format("Identificador: {0}", rmeItem.RegistroManutencaoID.ToString());
                            bltRME.Items.Add(lstItem);
                        }

                        string script = "function f(){$find(\"" + winExclusao.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
                    }
                }
                else
                {
                    try
                    {
                        foreach (Equipamento eqc in oUnitOfWork.EquipamentoREP.BuscarTodosPorID(pEquipamentoID))
                        {
                            oUnitOfWork.EquipamentoREP.Remover(eqc);
                        }

                        oUnitOfWork.EquipamentoREP.Remover(oUnitOfWork.EquipamentoREP.BuscarPorID(pEquipamentoID));
                        oUnitOfWork.Save();

                        Response.Redirect("EquipamentoLis.aspx?delete=sucess");
                    }
                    catch (Exception ex)
                    {
                        Log.Trace(ex, true);
                        Utils.Notificar(ntfGeral, "Erro ao excluir equipamento. Contate o administrador", Enums.TipoNotificacao.Erro);
                    }
                }
            }
        }

        #endregion

        #region eventos

        protected void ddlEmpresaVinculada_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            Dictionary<int, string> dicEntidade = null;
            string sTexto = e.Text.Trim();
            int itemOffset = 0;
            int endOffset = 0;

            try
            {
                ddlEmpresaVinculada.Items.Clear();

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    dicEntidade = oUnitOfWork.EntidadeREP.FiltrarHospitalKeyValue(sTexto);
                }

                itemOffset = e.NumberOfItems;
                endOffset = Math.Min(itemOffset + 10, dicEntidade.Count);
                e.EndOfItems = endOffset == dicEntidade.Count;

                for (int i = itemOffset; i < endOffset; i++)
                {
                    var item = dicEntidade.ElementAt(i);

                    ddlEmpresaVinculada.Items.Add(new RadComboBoxItem(item.Value, item.Key.ToString()));
                }

                e.Message = Utils.GetStatusMessage(endOffset, dicEntidade.Count);

            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar carregar dados de empresas vinculadas. Contate o administrador", Enums.TipoNotificacao.Erro);
            }
        }
        protected void ltvRME_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void bltRME_Click(object sender, BulletedListEventArgs e)
        {
            BulletedList bltRME = winExclusao.ContentContainer.FindControl("bltRME") as BulletedList;
            ListItem lstItem = bltRME.Items[e.Index];
            Response.Redirect(string.Format("RMECad.aspx?registroManutencaoID={0}", lstItem.Value));
        }
        protected void ddlEquipamentoTipo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            Dictionary<int, string> dicEquipamentoTipo = null;
            string sTexto = e.Text.Trim();
            int itemOffset = 0;
            int endOffset = 0;

            try
            {
                ddlEquipamentoTipo.Items.Clear();

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    dicEquipamentoTipo = oUnitOfWork.EquipamentoTipoREP.BuscarTodosKeyValue(sTexto);
                }

                itemOffset = e.NumberOfItems;
                endOffset = Math.Min(itemOffset + 10, dicEquipamentoTipo.Count);
                e.EndOfItems = endOffset == dicEquipamentoTipo.Count;

                for (int i = itemOffset; i < endOffset; i++)
                {
                    var item = dicEquipamentoTipo.ElementAt(i);

                    ddlEquipamentoTipo.Items.Add(new RadComboBoxItem(item.Value, item.Key.ToString()));
                }

                e.Message = Utils.GetStatusMessage(endOffset, dicEquipamentoTipo.Count);
            }
            catch (Exception ex)
            {
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar carregar dados de equipamentos. Contate o administrador", Enums.TipoNotificacao.Erro);
            }
        }

        protected void grdRME_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            UnitOfWork oUnitOfWork = new UnitOfWork();
            if (!string.IsNullOrEmpty(Request["equipamentoID"]))
            {
                grdRME.DataSource = oUnitOfWork.RegistroManutencaoREP.BuscarTodosAtuaisPorEquipamento(int.Parse(Request["equipamentoID"]));
            }
            else
            {
                grdRME.Visible = false;
            }
        }
        protected void grdRME_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                Response.Redirect("RMECad.aspx?registroManutencaoID=" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RegistroManutencaoID"].ToString(), true);
            }
        }
        protected void grdRME_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int maxColumnChar = 20;
                if (item["colRelatorioDescricao"].Text.Length > maxColumnChar)
                {
                    item["colRelatorioDescricao"].Text = string.Format("{0}...", item["colRelatorioDescricao"].Text.Substring(0, maxColumnChar));
                }
                if (item["colDefeitoDescricao"].Text.Length > maxColumnChar)
                {
                    item["colDefeitoDescricao"].Text = string.Format("{0}...", item["colDefeitoDescricao"].Text.Substring(0, maxColumnChar));
                }
            }
        }
        protected void ddlPeriodicidade_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlPeriodicidade.SelectedValue == "9")
            {
                lblDias.Visible = true;
                txtPeriodicidadeDias.Visible = true;
                lblRME.Visible = true;
            }
            else
            {
                lblDias.Visible = false;
                txtPeriodicidadeDias.Visible = false;
                lblRME.Visible = false;
            }
        }
        #endregion


    }
}