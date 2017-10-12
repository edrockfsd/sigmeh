using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sigmeh.Model;
using Sigmeh.Repository;

namespace Sigmeh.View
{
    public partial class EntidadeLis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void grdEntidade_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            UnitOfWork oUnitOfWork = new UnitOfWork();
            grdEntidade.DataSource = oUnitOfWork.EntidadeREP.FiltrarEntidade(false, int.Parse(Session["ssnLoggedUserID"].ToString()));                        
        }

        protected void grdEntidade_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowDblClick")
            {                
                Response.Redirect("EntidadeCad.aspx?entidadeID=" + e.Item.OwnerTableView.DataKeyValues[int.Parse(e.CommandArgument.ToString())]["EntidadeID"].ToString(), true);
            }
        }
    }
}