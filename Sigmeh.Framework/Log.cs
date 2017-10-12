using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Sigmeh.Framework
{
    public class Log
    {
        public static void Trace(Exception ex, bool isNotificarViaEmail)
        {
            try
            {
                string sDiretorioLog = System.AppDomain.CurrentDomain.BaseDirectory;

                sDiretorioLog += "errorlog.txt";

                if (ex.Message.Contains("Thread was being aborted"))
                    return;


                string[] stack_trace_method = ex.StackTrace.Split('\n');
                string metodo = stack_trace_method[stack_trace_method.Length - 1].ToString();

                System.Text.StringBuilder message = new System.Text.StringBuilder();
                message.AppendLine(DateTime.Now.ToString());
                message.AppendLine("Error: " + ex.Message.Replace("\n", " ").Replace("<br>", ""));

                if (ex.Message.Contains("inner exception"))
                    message.AppendLine("Inner Exception: " + ex.InnerException.Message.Replace("\n", " ").Replace("<br>", ""));

                StreamWriter sw = File.AppendText(sDiretorioLog);
                sw.WriteLine(message.ToString());
                sw.Close();

                NotificarViaEmail(ex, isNotificarViaEmail);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public static void NotificarViaEmail(Exception ex, bool sendMail = true)
        {
            string[] stack_trace_method = new string[1] { "" };
            string metodo;
            try
            {
                if (ex.Message.Contains("Thread was being aborted"))
                    return;


                if (ex.StackTrace != null)
                    stack_trace_method = ex.StackTrace.Split('\n');
                metodo = stack_trace_method[stack_trace_method.Length - 1].ToString();


                System.Text.StringBuilder message = new System.Text.StringBuilder();
                message.AppendLine(DateTime.Now.ToString());
                message.AppendLine("Error: " + ex.Message.Replace("\n", " ").Replace("<br>", ""));

                if (ex.Message.Contains("inner exception"))
                    message.AppendLine("Inner Exception: " + ex.InnerException.Message.Replace("\n", " ").Replace("<br>", ""));

                string[] computer_name = System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                message.AppendLine("Client Name: " + computer_name[0].ToString());
                computer_name = null;

                message.AppendLine("Client IP: " + Utils.GetIPAddress());
                message.AppendLine("Server Name: " + HttpContext.Current.Server.MachineName);
                message.AppendLine("Page: " + HttpContext.Current.Request.Path.Substring(HttpContext.Current.Request.Path.LastIndexOf("/") + 1));
                message.AppendLine("Method: " + metodo);
                message.AppendLine("Navigator: " + HttpContext.Current.Request.Browser["Browser"].ToString() + " - " + HttpContext.Current.Request.Browser["Version"].ToString());
                foreach (DictionaryEntry item in ex.Data)
                    message.AppendLine("Data: " + item.Key + "=" + item.Value);
                message.AppendLine("");

                System.IO.StreamWriter sw = System.IO.File.AppendText(HttpContext.Current.Server.MapPath("~/errorlog.txt"));
                sw.WriteLine(message.ToString());
                sw.Close();


                if (sendMail)
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["send_email_on_error"].ToString()))
                    {
                        Mail.AttachLog = false;
                        Mail.LogPath = HttpContext.Current.Server.MapPath(@"~/errorlog.txt");
                        Mail.Body = message.ToString().Replace("\r\n", "<br>");
                        Mail.EmailTo = System.Configuration.ConfigurationManager.AppSettings["EmailOwner"].ToString();
                        Mail.Subject = "Erro na aplicação Sigmeh";

                        Mail.Send();
                    }
                }

            }
            catch (Exception ex2)
            {
                
            }
        }
    }
}
