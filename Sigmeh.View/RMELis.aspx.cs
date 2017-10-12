using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sigmeh.Model;
using Sigmeh.Repository;
using Telerik.Web.UI;
using System.Data;

namespace Sigmeh.View
{
    public partial class RMELis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void grdRME_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            UnitOfWork oUnitOfWork = new UnitOfWork();
            if (!string.IsNullOrEmpty(Request["equipamentoID"]))
            {
                Page.Title = "Lista de registros de manuteção para o Equipamento: [" + oUnitOfWork.EquipamentoREP.BuscarPorID(int.Parse(Request["equipamentoID"])).NumeroSerie + "]";
                grdRME.DataSource = oUnitOfWork.RegistroManutencaoREP.BuscarTodosAtuaisPorEquipamento(int.Parse(Request["equipamentoID"]));
            }
            else
                grdRME.DataSource = oUnitOfWork.RegistroManutencaoREP.BuscarTodosAtuais((List<int>)Session["ssnLstEmpresaMaeID"]);
        }

        protected void grdRME_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowDblClick")
            {
                Response.Redirect("RMECad.aspx?registroManutencaoID=" + e.Item.OwnerTableView.DataKeyValues[int.Parse(e.CommandArgument.ToString())]["RegistroManutencaoID"].ToString(), true);
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

        protected void menu_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "imprimir":
                    ImprimirLote();
                    break;
            }
        }

        private void ImprimirLote()
        {
            DataTable dtRMEID = new DataTable();
            dtRMEID.TableName = "dtRMEID";
            dtRMEID.Columns.Add("registroManutencaoID", typeof(int));

            foreach (GridDataItem item in grdRME.MasterTableView.Items)
            {
                if (item is GridDataItem)
                {
                    CheckBox chkSelecao = (CheckBox)item["colCheck"].FindControl("colCheckSelectCheckBox");

                    if (chkSelecao != null)
                    {
                        if (chkSelecao.Checked)
                        {
                            dtRMEID.Rows.Add(int.Parse(item.OwnerTableView.DataKeyValues[item.ItemIndex]["RegistroManutencaoID"].ToString()));
                        }
                    }
                }
            }

            DataSet dsRMEID = new DataSet();
            dsRMEID.DataSetName = "dsRMEID";
            dsRMEID.Tables.Add(dtRMEID);

            Session["xml_RMEID"] = dsRMEID.GetXml();

            Response.Redirect("Reports/RMERel.aspx", true);
        }
    }
}