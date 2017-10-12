using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sigmeh.View.Reports
{
    public partial class RMERel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["xml_RMEID"] != null)
                {
                    rptRME oRptRME = new rptRME();
                    oRptRME.ReportParameters["xml_RMEID"].Value = Session["xml_RMEID"].ToString();
                    ReportViewer1.Report = oRptRME;
                    Session["xml_RMEID"] = null;
                }
            }
        }
    }
}