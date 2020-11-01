using Amazon;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
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

        public async Task<bool> SendEmailAsync(string subject, string body, string receipentEmail)
        {
            string api = "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";
            var client = new SendGridClient(api);
            var msgs = new SendGridMessage()
            {
                From = new EmailAddress("mcit.uj@gmail.com"),
                Subject = subject,
                HtmlContent = body
            };
            msgs.AddTo(new EmailAddress(receipentEmail));
            var responses = await client.SendEmailAsync(msgs);
            return true;
        }

        public async Task<bool> SendEmailWithAttachmentAsync(string subject, string body, string receipentEmail, string filePath)
        {
            
            string api = "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";
            var client = new SendGridClient(api);
            var msgs = new SendGridMessage()
            {
                From = new EmailAddress("mcit.uj@gmail.com"),
                Subject = subject,
                HtmlContent = body
            };
            msgs.AddTo(new EmailAddress(receipentEmail));
            var responses = await client.SendEmailAsync(msgs);
            return true;

        }

    }
}
