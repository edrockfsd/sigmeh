using Sigmeh.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sigmeh.View.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                Sigmeh.Model.Usuario usuario = oUnitOfWork.UsuarioREP.Autenticar(((TextBox)pnlLogin.FindControl("UserName")).Text, ((TextBox)pnlLogin.FindControl("Password")).Text);

                if (usuario != null)
                {
                    Session.Add("ssnLoggedUserID", usuario.UsuarioID);                    
                    Response.Redirect("../Home.aspx");                    
                }
            }
        }
    }
}