using System;
using System.Collections.Specialized;
using System.Configuration;
using MediatR;
using System.Net;
using System.Net.Mail;
using LearnEnglishWords.Extensions;

namespace LearnEnglishWords.Commands
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand,bool>
    {
        public bool Handle(SendEmailCommand data)
        {
            NameValueCollection emailSettings = (NameValueCollection) ConfigurationManager.GetSection("EmailAppSettings");
            NameValueCollection templateSection = (NameValueCollection)ConfigurationManager.GetSection(data.TempateName+"EmailTemplate");
            
            var fromAddress = new MailAddress(emailSettings.Get("From"), emailSettings.Get("From"));
            var toAddress = new MailAddress(data.Email, data.Email);
           
            string subject = templateSection.Get("Subject").ExFormat(data.Parameters);
            string body = templateSection.Get("Body").ExFormat(data.Parameters).Replace("\n","<br />");

            var smtp = new SmtpClient
            {
                Host = emailSettings.Get("Host"),
                Port = Int32.Parse(emailSettings.Get("Port")),
                EnableSsl = Boolean.Parse(emailSettings.Get("UseSsl")),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, emailSettings.Get("Password"))
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

            return true;
        }
    }
}