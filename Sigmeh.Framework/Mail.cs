using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Invitro.Web.Util;
using System.Net.Mail;

namespace Sigmeh.Framework
{
    public enum Status
    {
        Success,
        Error

    }
    /// <summary>
    /// Classe responsável pelo envio de Email
    /// </summary>
    /// 
    public class Mail
    {
        //version 2
        #region Atributos e Propriedades
        static string emailTo;
        static string subject;
        static string body;
        static bool attachLog;
        static string logPath;

        public static string EmailTo
        {
            get { return emailTo; }
            set { emailTo = value; }
        }

        public static string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public static string Body
        {
            get { return body; }
            set { body = value; }
        }
        public static bool AttachLog
        {
            get { return attachLog; }
            set { attachLog = value; }
        }
        public static string LogPath
        {
            get { return logPath; }
            set { logPath = value; }
        }

        #endregion

        public delegate void MailHandler(Status status);
        public static event MailHandler Sent;
        public delegate void ErrorHandler(string msg);
        public static event ErrorHandler onError;


        public static void Send()
        {
            Sent += new MailHandler(OnSent);
            onError += new ErrorHandler(OnError);


            try
            {
                Body = Body.Replace(@"\n", "\n").Replace(@"\r", "\r").Replace(@"\t", "\t");

                //Preparando mensagem de email.
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(
                                    ConfigurationManager.AppSettings["EmailAdmin"],
                                    ConfigurationManager.AppSettings["EmailNameAdmin"],
                                    System.Text.Encoding.UTF8);
                msg.ReplyTo = new MailAddress(
                                    ConfigurationManager.AppSettings["EmailAdmin"],
                                    ConfigurationManager.AppSettings["EmailNameAdmin"],
                                    System.Text.Encoding.UTF8);
                msg.To.Add(EmailTo);

                msg.Subject = Subject;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = Body;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;

                if (attachLog && !logPath.Equals(string.Empty))
                {
                    msg.Attachments.Add(new Attachment(logPath));
                }

                //Criando credenciais para envio da mensagem.
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(
                                            ConfigurationManager.AppSettings["EmailAdmin"],
                                            ConfigurationManager.AppSettings["EmailPasswordAdmin"]);

                //Google funciona em 587 ou 465.
                client.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortAdmin"]);

                //client.Host = "smtp.googlemail.com"; //client.Host = "smtp.gmail.com"; //Preferencial: "smtp.googlemail.com"
                client.Host = ConfigurationManager.AppSettings["SmtpAdmin"];

                //         if (client.Port == 587)
                client.EnableSsl = false;

                client.Timeout = 30000; //Tempo para tentativa de envio de email

                Pop3MailClient pop3client = null;

                if (!client.EnableSsl)
                {
                    //Porta pop3 tcp = 110 / com SSL (gmail) = 995
                    pop3client = (ConfigurationManager.AppSettings["Pop3PortAdmin"] == "995") ?
                        new Pop3MailClient(
                                                ConfigurationManager.AppSettings["Pop3Admin"],
                                                int.Parse(ConfigurationManager.AppSettings["Pop3PortAdmin"]),
                                                true,
                                                ConfigurationManager.AppSettings["EmailAdmin"],
                                                ConfigurationManager.AppSettings["EmailPasswordAdmin"])
                    :
                        new Pop3MailClient(
                                                ConfigurationManager.AppSettings["Pop3Admin"],
                                                int.Parse(ConfigurationManager.AppSettings["Pop3PortAdmin"]),
                                                false,
                                                ConfigurationManager.AppSettings["EmailAdmin"],
                                                ConfigurationManager.AppSettings["EmailPasswordAdmin"]);
                    pop3client.IsAutoReconnect = true;

                    pop3client.ReadTimeout = 60000; //60 segundos para o servidor pop responder
                }
                //Tenta enviar três vezes, questões de autenticação ( em alguns servidores não se consegue enviar o email na primeira tentativa )
                bool enviado = false;
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        if (!client.EnableSsl)
                        {
                            pop3client.Connect();
                            pop3client.Disconnect();
                        }
                        client.Send(msg);

                        enviado = true;
                        break; // Caso tenha sido enviado corretamente apenas sai do loop.
                    }
                    catch
                    {
                        //Caso não funcione com a conta completa pega-se apenas o nome do usuário para as credenciais.
                        // tenta duas vezes com a conta completa, ex: digiquest@gmail.com, e duas vezes somente com o nome de usuário, ex: digiquest.
                        if (i == 2)
                        {
                            pop3client = (ConfigurationManager.AppSettings["Pop3PortAdmin"] == "995") ?
                                new Pop3MailClient(
                                                    ConfigurationManager.AppSettings["Pop3Admin"],
                                                    int.Parse(ConfigurationManager.AppSettings["Pop3PortAdmin"]),
                                                    true,
                                                    ConfigurationManager.AppSettings["EmailAdmin"].Split('@')[0],
                                                    ConfigurationManager.AppSettings["EmailPasswordAdmin"])
                            :
                                new Pop3MailClient(
                                                    ConfigurationManager.AppSettings["Pop3Admin"],
                                                    int.Parse(ConfigurationManager.AppSettings["Pop3PortAdmin"]),
                                                    false,
                                                    ConfigurationManager.AppSettings["EmailAdmin"].Split('@')[0],
                                                    ConfigurationManager.AppSettings["EmailPasswordAdmin"]);

                            client.Credentials = new System.Net.NetworkCredential(
                                                    ConfigurationManager.AppSettings["EmailAdmin"].Split('@')[0],
                                                    ConfigurationManager.AppSettings["EmailPasswordAdmin"]);
                        }
                    }
                }
                if (enviado)
                    Sent(Status.Success);
                else
                    Sent(Status.Error);


            }
            catch (Exception ex)
            {
                //Log.Trace(ex);
            }

        }


        private static void OnSent(Status status)
        {
            if (status == Status.Error)
            {
                Exception ex = new Exception("Não foi possivel enviar o email. A origem da exception não foi detectada.");
                //Log.Trace(ex);
            }

        }

        private static void OnError(string message)
        {
            //string x = message;
        }
    }
}
