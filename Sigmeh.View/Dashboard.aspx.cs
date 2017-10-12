using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sigmeh.Model;
using System.Data;
using Sigmeh.Repository;
using System.Collections;

namespace Sigmeh.View
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarTileStatusEquipamentosSaida((List<int>)Session["ssnLstEmpresaMaeID"]);
            }
        }

        protected void CarregarTileStatusEquipamentosSaida(List<int> lstEmpresaMaeID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                List<ManutencaoTipoContagem> statusSaidaEquipamento = oUnitOfWork.EquipamentoREP.BuscarStatusSaidaEquipamentoPorEmpresa(lstEmpresaMaeID);      
                
                lblAtrasadosPreventiva.Text = (statusSaidaEquipamento.Where(sse => sse.Status == -1 && sse.ManutencaoTipoID == 1).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == -1 && sse.ManutencaoTipoID == 1).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0"; 
                lblAtrasadosCalibracao.Text = (statusSaidaEquipamento.Where(sse => sse.Status == -1 && sse.ManutencaoTipoID == 3).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == -1 && sse.ManutencaoTipoID == 3).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0"; 
                lblAtrasadosTotal.Text = (statusSaidaEquipamento.Where(sse => sse.Status == -1).Sum(a => a.ManutencaoTipoQtde) != null) ? statusSaidaEquipamento.Where(sse => sse.Status == -1).Sum(a => a.ManutencaoTipoQtde).ToString() : "0";

                lbl7DiasPreventiva.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 7 && sse.ManutencaoTipoID == 1).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 7 && sse.ManutencaoTipoID == 1).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0";
                lbl7DiasCalibracao.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 7 && sse.ManutencaoTipoID == 3).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 7 && sse.ManutencaoTipoID == 3).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0";
                lbl7DiasTotal.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 7).Sum(a => a.ManutencaoTipoQtde) != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 7).Sum(a => a.ManutencaoTipoQtde).ToString() : "0";

                lbl15DiasPreventiva.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 15 && sse.ManutencaoTipoID == 1).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 15 && sse.ManutencaoTipoID == 1).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0";
                lbl15DiasCalibracao.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 15 && sse.ManutencaoTipoID == 3).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 15 && sse.ManutencaoTipoID == 3).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0";
                lbl15DiasTotal.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 15).Sum(a => a.ManutencaoTipoQtde) != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 15).Sum(a => a.ManutencaoTipoQtde).ToString() : "0";

                lbl30DiasPreventiva.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 30 && sse.ManutencaoTipoID == 1).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 30 && sse.ManutencaoTipoID == 1).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0";
                lbl30DiasCalibracao.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 30 && sse.ManutencaoTipoID == 3).FirstOrDefault() != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 30 && sse.ManutencaoTipoID == 3).FirstOrDefault().ManutencaoTipoQtde.ToString() : "0";
                lbl30DiasTotal.Text = (statusSaidaEquipamento.Where(sse => sse.Status == 30).Sum(a => a.ManutencaoTipoQtde) != null) ? statusSaidaEquipamento.Where(sse => sse.Status == 30).Sum(a => a.ManutencaoTipoQtde).ToString() : "0";
                
               

                tllSaida.Groups[0].Tiles[0].FindControl("lblAtrasadossPreventiva");
                
            }
        }

        protected void tllSaida_TileClick(object sender, Telerik.Web.UI.TileListEventArgs e)
        {
            switch (e.Tile.Name)
            {
                case "atrasados":
                    Response.Redirect("EquipamentoLis.aspx?diasPrazo=-1");
                    break;
                case "sete_dias":
                    Response.Redirect("EquipamentoLis.aspx?diasPrazo=7");
                    break;
                case "quinze_dias":
                    Response.Redirect("EquipamentoLis.aspx?diasPrazo=15");
                    break;
                case "trinta_dias":
                    Response.Redirect("EquipamentoLis.aspx?diasPrazo=30");
                    break;
            }
        }

    }
}