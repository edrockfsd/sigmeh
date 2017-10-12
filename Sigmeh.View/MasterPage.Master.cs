using Sigmeh.Framework;
using Sigmeh.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Sigmeh.View
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ssnLoggedUserID"] == null)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "onLoad", "DisplaySessionTimeout();", true);

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    if (System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToUpper() != "HOME.ASPX" &&
                        System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToUpper() != "ACESSONEGADO.ASPX" &&
                        System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToUpper() != "ERRO.ASPX")
                    {
                        if (!oUnitOfWork.UsuarioREP.EhAutorizado(int.Parse(Session["ssnLoggedUserID"].ToString()), System.IO.Path.GetFileName(Request.Url.AbsolutePath)))
                        {
                            Response.Redirect("~/AcessoNegado.aspx");
                        }
                    }

                    if (string.IsNullOrEmpty(btnUsuario.Text))
                    {
                        Sigmeh.Model.Usuario usuario = oUnitOfWork.UsuarioREP.BuscarTodos(usu => usu.UsuarioID.Equals(int.Parse(Session["ssnLoggedUserID"].ToString()))).FirstOrDefault();
                        btnUsuario.Text = usuario.Entidade.Nome;
                    }
                }

                CarregarEmpresas(int.Parse(Session["ssnLoggedUserID"].ToString()));

                if (Session["ssnLstEmpresaMaeID"] != null)
                {
                    if (!string.IsNullOrEmpty(Session["ssnLstEmpresaMaeID"].ToString()))
                    {
                        SelecionarEmpresasMae((List<int>)Session["ssnLstEmpresaMaeID"]);
                    }
                }
            }

            if (Request.Params["__EVENTTARGET"] != null)
            {
                if (Request.Params["__EVENTTARGET"].ToString().Contains("ddlEmpresa"))
                {
                    AtualizarListaEmpresasMaeID();
                }
            }
            
            if (ddlEmpresa.CheckedItems.Count <= 0)
            {
                SelecionarPrimeiraEmpresaMae();
            }
        }

        protected void btnSairSistema_Click(object sender, EventArgs e)
        {
            Session.Remove("ssnLoggedUserID");
            Response.Redirect("~/Account/Login.aspx");
        }

        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            //TODO:Acessar tela de conta do usuário
        }

        protected void CarregarEmpresas(int pUsuarioID)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                ddlEmpresa.DataSource = oUnitOfWork.UsuarioREP.ListarEmpresasUsuario(pUsuarioID);
                ddlEmpresa.DataBind();

                if (Session["ssnLstEmpresaMaeID"] == null) // Deve ser executado somente no momento do login
                {
                    List<int> lstEmpresaMaeID = new List<int>();
                    foreach (RadComboBoxItem item in ddlEmpresa.Items)
                    {
                        item.Checked = true;
                        lstEmpresaMaeID.Add(int.Parse(item.Value));
                    }
                    Session.Add("ssnLstEmpresaMaeID", lstEmpresaMaeID); // Configurado como Todas  
                }                  
            }
        }

        protected void SelecionarEmpresasMae(List<int> lstEmpresaMaeID)
        {
            foreach (RadComboBoxItem item in ddlEmpresa.Items)
            {
                foreach (int EmpresaMaeIDItem in lstEmpresaMaeID)
                {
                    if (item.Value.Equals(EmpresaMaeIDItem.ToString()))
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        protected void AtualizarListaEmpresasMaeID()
        {
            List<int> lstEmpresaMaeID = new List<int>();
            foreach (RadComboBoxItem item in ddlEmpresa.CheckedItems)
            {   
                lstEmpresaMaeID.Add(int.Parse(item.Value));
            }
            
            if (lstEmpresaMaeID.Count <= 0) //  Usuário deve ter obrigatoriamente uma empresa mãe selecionada
            {
                SelecionarPrimeiraEmpresaMae();
            }
            else
            {
                Session.Add("ssnLstEmpresaMaeID", lstEmpresaMaeID);
            }
        }

        protected void SelecionarPrimeiraEmpresaMae()
        {
            ddlEmpresa.Items[0].Checked = true;
            Session.Add("ssnLstEmpresaMaeID", new List<int>() { int.Parse(ddlEmpresa.Items[0].Value) });
            Utils.Notificar(ntfMaster, "Pelo menos uma empresa deve estar selecionada.", Enums.TipoNotificacao.Alerta);
        }

    }
}