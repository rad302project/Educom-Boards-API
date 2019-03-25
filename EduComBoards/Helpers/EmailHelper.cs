using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common.Helpers
{
    public class EMailHelper
    {
        public static readonly string emailSender = "educomdiscussions@outlook.com";
        public static readonly string emailCredentials = "BigGary1337";
        public static readonly string smtpClient = "smtp-mail.outlook.com";
        public static readonly string emailBody = "Someone commented on the a topic you're involved in <a href='{0}'>here.</a>";
        private string senderAddress;
        private string clientAddress;
        private string netPassword;
        public EMailHelper(string sender, string Password, string client)
        {
            senderAddress = sender;
            netPassword = Password;
            clientAddress = client;
        }
        public bool SendEmail(string recipient, string subject, string message)
        {
            bool isMessageSent = false;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(clientAddress);
            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(senderAddress, netPassword);
            client.EnableSsl = true;
            client.Credentials = credentials;
            try
            {
                var mail = new System.Net.Mail.MailMessage(senderAddress.Trim(), recipient.Trim());
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                client.Send(mail);
                isMessageSent = true;
            }
            catch (Exception ex)
            {
                isMessageSent = false;
            }
            return isMessageSent;
        }
    }
}