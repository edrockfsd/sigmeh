using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Sigmeh.Framework
{
    public class Utils
    {
        public static void Notificar(RadNotification ntfGeral, string msg, Enums.TipoNotificacao notifyType)
        {
            ntfGeral.Position = NotificationPosition.TopRight;
            ntfGeral.Width = Unit.Pixel(330);
            ntfGeral.Height = Unit.Pixel(200);                        
            ntfGeral.CssClass = "WelcomeNotification";
            ntfGeral.Title = "SIGMEH"; //Mudar depois para os parâmetros de sistema ou web.config
            ntfGeral.ShowCloseButton = true;            
            ntfGeral.Animation = NotificationAnimation.Fade;
            ntfGeral.AnimationDuration = 500;
            ntfGeral.AutoCloseDelay = 3000;
            ntfGeral.Pinned = true;
            ntfGeral.EnableRoundedCorners = true;
            ntfGeral.EnableShadow = true;
            ntfGeral.KeepOnMouseOver = true;
            ntfGeral.VisibleTitlebar = true;            
            //ntfGeral.Opacity = 95;


            switch (notifyType)
            {
                case Enums.TipoNotificacao.Informacao:
                    ntfGeral.Text = msg;
                    ntfGeral.TitleIcon = "../../Images/sigmeh_icon.png";
                    ntfGeral.ContentIcon = "info";
                    //ntfGeral.ShowSound = "../../Sounds/notify.wav";
                    break;
                case Enums.TipoNotificacao.Alerta:
                    ntfGeral.Text = msg;                    
                    ntfGeral.TitleIcon = "warning";
                    ntfGeral.ContentIcon = "warning";
                    //ntfGeral.ShowSound = "warning";
                    break;
                case Enums.TipoNotificacao.Erro:
                    ntfGeral.Text = msg;           
                    ntfGeral.TitleIcon = "delete";
                    ntfGeral.ContentIcon = "delete";
                    //ntfGeral.ShowSound = "warning";
                    break;
                default:
                    break;
            }

            ntfGeral.Show();
        }

        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;

            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// Apresenta mensagem com resultado da busca na base de dados para os combobox com load on demand
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static string GetStatusMessage(int offset, int total)
        {
            if (total <= 0)
                return "Sem resultados";

            return String.Format("Items <b>1</b>-<b>{0}</b> de <b>{1}</b>", offset, total);

        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
