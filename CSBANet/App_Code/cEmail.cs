using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.IO;




using System.Net;

using SendGrid;

namespace CSBA.App_Code
{
    public class cMail
    {
        public static void SendMessage(string fromEmail, string toEmail, string subject, string body, string strFileName, Attachment att)
        {
            MailMessage message = new MailMessage(
               fromEmail,
               toEmail,
               subject,
               body);

            message.IsBodyHtml = true;
            message.Attachments.Add(att);

            var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = section.Network.Host.ToString();
            client.Port = section.Network.Port;
            client.EnableSsl = section.Network.EnableSsl;
            client.Credentials = new System.Net.NetworkCredential(section.Network.UserName.ToString(), section.Network.Password.ToString());

            try
            {
                //var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
                //// Create the email object first, then add the properties.
                //SendGridMessage myMessage = new SendGridMessage();
                //myMessage.AddTo(toEmail);
                //myMessage.From = new MailAddress(fromEmail, fromEmail);
                //myMessage.Subject = subject + " sent via SendGrid";
                //myMessage.Html = body;
                //myMessage.AddAttachment(strFileName);



                //// Create credentials, specifying your user name and password.
                //NetworkCredential credentials = new System.Net.NetworkCredential(section.Network.UserName.ToString(), section.Network.Password.ToString());

                //// Create an Web transport for sending email.
                //var transportWeb = new Web(credentials);

                //// Send the email, which returns an awaitable task.
                //transportWeb.DeliverAsync(myMessage);

                client.Send(message);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static string PopulateBody(string TemplateLoc, string[,] MergeValues)
        {

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(TemplateLoc)))
            {
                body = reader.ReadToEnd();
            }
            int ItemCount = MergeValues.GetLength(1);

            for (int i = 0; i < ItemCount; i++)
            {
                body = body.Replace(MergeValues[i, 0], MergeValues[i, 1]);
            }

            return body;
        }

    }
}