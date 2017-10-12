using System;
using Sigmeh.Model;
using Sigmeh.Repository;
using Telerik.Web.UI;
using Sigmeh.Framework;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Sigmeh.View
{
    public partial class EquipamentoLis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["delete"]))
                {
                    Utils.Notificar(ntfGeral, "Registro de equipamento excluido.", Enums.TipoNotificacao.Informacao);
                } if (!string.IsNullOrEmpty(Request["diasPrazo"]))
                {
                    rblFiltroStatusSaida.SelectedValue = Request["diasPrazo"].ToString();
                }
            }
        }

        protected void grdEquipamento_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            UnitOfWork oUnitOfWork = new UnitOfWork();
            if (rblFiltroStatusSaida.SelectedValue == "todos")
            {
                grdEquipamento.DataSource = oUnitOfWork.EquipamentoREP.BuscarTodosAtuais((List<int>)Session["ssnLstEmpresaMaeID"]);
            }
            else
            {
                grdEquipamento.DataSource = oUnitOfWork.EquipamentoREP.BuscarTodosAtuais((List<int>)Session["ssnLstEmpresaMaeID"], int.Parse(rblFiltroStatusSaida.SelectedValue));
            }

        }
        protected void grdEquipamento_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowDblClick")
            {
                Response.Redirect("EquipamentoCad.aspx?equipamentoID=" + e.Item.OwnerTableView.DataKeyValues[int.Parse(e.CommandArgument.ToString())]["EquipamentoID"].ToString(), true);
            }
        }
        protected void rblFiltroStatusSaida_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdEquipamento.Rebind();
        }

        protected void grdEquipamento_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            //    using (UnitOfWork oUnitOfWork = new UnitOfWork())
            //    {
            //        item["colUltimaCalibracao"].Text = oUnitOfWork.EquipamentoREP.BuscarDataManutencao(int.Parse(item.GetDataKeyValue("EquipamentoID").ToString()), 3, "realizada").Value.ToString("dd/MM/yyyy"); // Manutenção do tipo 3 é para calibração
            //        item["colProximaCalibracao"].Text = oUnitOfWork.EquipamentoREP.BuscarDataManutencao(int.Parse(item.GetDataKeyValue("EquipamentoID").ToString()), 3, "prevista").Value.ToString("dd/MM/yyyy"); // Manutenção do tipo 3 é para calibração
            //        item["colUltimaPreventiva"].Text = oUnitOfWork.EquipamentoREP.BuscarDataManutencao(int.Parse(item.GetDataKeyValue("EquipamentoID").ToString()), 1, "realizada").Value.ToString("dd/MM/yyyy"); // Manutenção do tipo 1 é para preventiva
            //        item["colProximaPreventiva"].Text = oUnitOfWork.EquipamentoREP.BuscarDataManutencao(int.Parse(item.GetDataKeyValue("EquipamentoID").ToString()), 1, "prevista").Value.ToString("dd/MM/yyyy"); // Manutenção do tipo 1 é para preventiva
            //    }                
            //}
        }
    }
}