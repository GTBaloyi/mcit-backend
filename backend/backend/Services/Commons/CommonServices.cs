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

        public bool SendEmail(string subject, string body, string receipentEmail)
        {
            Amazon.SimpleEmail.AmazonSimpleEmailServiceClient sesClient =
                new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(RegionEndpoint.USEast2);
            Amazon.SimpleEmail.Model.SendEmailRequest sendRquest = new Amazon.SimpleEmail.Model.SendEmailRequest()
            {
                Destination = new Amazon.SimpleEmail.Model.Destination()
                {
                    ToAddresses = new List<string>() { receipentEmail }
                },
                Message = new Amazon.SimpleEmail.Model.Message
                {
                    Body = new Amazon.SimpleEmail.Model.Body
                    {
                        Html = new Amazon.SimpleEmail.Model.Content
                        {
                            Charset = "UTF-8",
                            Data = body
                        },
                        Text = new Amazon.SimpleEmail.Model.Content
                        {
                            Charset = "UTF-8",
                            Data = body
                        }

                    },
                    Subject = new Amazon.SimpleEmail.Model.Content
                    {
                        Charset = "UTF-8",
                        Data = subject
                    }
                },
                Source = "mcit.uj@gmail.com"
            };

            var res = sesClient.SendEmailAsync(sendRquest);
            Task.WaitAll(res);
            string messageId = res.Result.MessageId;
            return true;

            /* var fromAddress = new MailAddress("mcit.uj@gmail.com", "MCIT");
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
             }*/

        }

        public bool SendEmailWithAttachment(string subject, string body, string receipentEmail, string filePath)
        {
            /*try
            {
                Amazon.SimpleEmail.AmazonSimpleEmailServiceClient sesClient =
                new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(RegionEndpoint.USEast2);
                Amazon.SimpleEmail.Model.SendEmailRequest sendRquest = new Amazon.SimpleEmail.Model.SendEmailRequest()
                {
                    Destination = new Amazon.SimpleEmail.Model.Destination()
                    {
                        ToAddresses = new List<string>() { receipentEmail }
                    },
                    Message = new Amazon.SimpleEmail.Model.Message
                    {
                        Body = new Amazon.SimpleEmail.Model.Body
                        {
                            Html = new Amazon.SimpleEmail.Model.Content
                            {
                                Charset = "UTF-8",
                                Data = body
                            },
                            Text = new Amazon.SimpleEmail.Model.Content
                            {
                                Charset = "UTF-8",
                                Data = body
                            }

                        },
                        Subject = new Amazon.SimpleEmail.Model.Content
                        {
                            Charset = "UTF-8",
                            Data = subject
                        }
                    },
                    Source = "mcit.uj@gmail.com"
                };

                var res = sesClient.SendEmailAsync(sendRquest);
                Task.WaitAll(res);
                string messageId = res.Result.MessageId;
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
            */
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
    
    }
}
