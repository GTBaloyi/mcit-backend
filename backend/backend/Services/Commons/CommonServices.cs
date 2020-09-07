using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace backend.Services.Commons
{
    public class CommonServices
    {
        public bool companyExist(string registrationNumber)
        {
            return true;
        }

        public bool SendEmail(string subject, string body, string receipentEmail)
        {
            var fromAddress = new MailAddress("mcit.uj@gmail.com", "MCIT");
            const string fromPassword = "AluwanI@123";

            var toAddress = new MailAddress(receipentEmail);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.IsBodyHtml = true;
                smtp.Send(message);
                return true;
            }

        }

        public bool SendEmailWithAttachment(string subject, string body, string receipentEmail, string filePath)
        {
            var fromAddress = new MailAddress("mcit.uj@gmail.com", "MCIT");
            const string fromPassword = "AluwanI@123";

            var toAddress = new MailAddress(receipentEmail);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.Attachments.Add(new System.Net.Mail.Attachment(filePath));
                message.IsBodyHtml = true;
                smtp.Send(message);
                return true;
            }

        }
    }
}
