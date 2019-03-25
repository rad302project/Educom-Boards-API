using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace EduComBoards.Helpers
{
    public class EmailHelper
    {
        public void SendEmail(string recipientAddress, string recipientName)
        {
            string body = string.Format("{0}, you have a new comment", recipientName);
            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("educomboards@outlook.com", "SheWorksOutTooMuch")
            };
            MailMessage message = new MailMessage();
            message.From = new MailAddress("educomboards@outlook.com");
            message.To.Add(recipientAddress);
            message.Subject = "New Comment";
            message.Body = body;
            smtp.Send(message);
        }
    }
}