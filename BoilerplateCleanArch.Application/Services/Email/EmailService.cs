using BoilerplateCleanArch.Application.Interfaces.Email;
using System;
using System.Net.Mail;
using System.Net;
using BoilerplateCleanArch.Application.DTOS.Email;

namespace BoilerplateCleanArch.Application.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool Send(string toName, string toEmail, string subject, string body, string fromName = "", string fromEmail = "")
        {
            var smptClient = new SmtpClient(ConfigurationDTO.Smtp.Host, ConfigurationDTO.Smtp.Port);

            smptClient.Credentials = new NetworkCredential(ConfigurationDTO.Smtp.UserName, ConfigurationDTO.Smtp.Password);
            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smptClient.EnableSsl = true;

            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smptClient.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}