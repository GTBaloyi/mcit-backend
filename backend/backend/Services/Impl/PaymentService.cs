using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using backend.DataAccess.Contracts;
using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Commons;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly IEntityBuilder _entityBuilder;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly ICompanyRepRepository _companyRepRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly CommonServices commonServices;

        public PaymentService(IInvoiceRepository invoiceRepository, IPaymentRepository paymentRepo, IEntityBuilder entityBuilder, ICompanyRepository companyRepository, IEmailTemplateRepository emailTemplateRepository, ICompanyRepRepository companyRepRepository)
        {
            _paymentRepo = paymentRepo;
            _entityBuilder = entityBuilder;
            _companyRepository = companyRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _companyRepRepository = companyRepRepository;
            commonServices = new CommonServices();
            _invoiceRepository = invoiceRepository;
        }

        public bool CreatePayment(PaymentRequestModel payment)
        {
            PaymentEntity paymentEntity = _entityBuilder.buildPaymentEntity(0, payment.invoiceReference, payment.dateOfPayment, payment.proofOfPaymentURL, payment.paymentType, payment.companyRegistration, payment.amount, payment.status, payment.approvedBy);
            CompanyEntity company = _companyRepository.GetByRegistrationNumber(payment.companyRegistration);
            string companyEmail = _companyRepRepository.GetByCompany(company.id).email;
            _paymentRepo.Insert(paymentEntity);
            if(payment.status == "Approved")
            {
                if (_invoiceRepository.Update(updateInvoice(payment.invoiceReference, payment.amount)))
                {
                    string emailBody = _emailTemplateRepository.GetByType("PaymentConfirmation").code.Replace("{company_name}", company.name);
                    emailBody = emailBody.Replace("{invoiceReference}", payment.invoiceReference);

                    if (commonServices.SendEmail("Payment Confirmation For Invoice #" + payment.invoiceReference, emailBody, companyEmail))
                    {
                        return true;
                    }
                    else
                    {
                        throw new McpCustomException("Payment saved but could not email the client");
                    }
                }
                else
                {
                    throw new McpCustomException("Payment saved but could not update invoice. Please update invoice manually");
                }
            } 
            else
            {
                string emailBody = _emailTemplateRepository.GetByType("PaymentConfirmation").code.Replace("{company_name}", company.name);
                emailBody = emailBody.Replace("{invoiceReference}", payment.invoiceReference);

                if (commonServices.SendEmail("Payment Confirmation For Invoice #" + payment.invoiceReference, emailBody, companyEmail))
                {
                    return true;
                }
                else
                {
                    throw new McpCustomException("Payment saved but could not email the client");
                }
            }
            
            
        }

        private InvoiceEntity updateInvoice(string invoiceReference, double amount)
        {
            InvoiceEntity invoice = _invoiceRepository.GetByReference(invoiceReference);
            if(invoice != null)
            {
                invoice.amount_payed += amount;
                invoice.amount_due -= amount;
            }
            
            return invoice;
        }

        public bool DeletePayment(PaymentRequestModel payment)
        {
           
            if(_paymentRepo.GetById(payment.paymentId) != null)
            {
                PaymentEntity paymentEntity = _entityBuilder.buildPaymentEntity(0, payment.invoiceReference, payment.dateOfPayment, payment.proofOfPaymentURL, payment.paymentType, payment.companyRegistration, payment.amount, payment.status, payment.approvedBy);
                _paymentRepo.Delete(paymentEntity);
                return true;
            }
            else
            {
                throw new McpCustomException("This payment doesn't exist");
            }
        }

        public List<PaymentResponseModel> GetByCompanyRegistration(string companyRegistration)
        {
            List<PaymentEntity> payments = _paymentRepo.GetByCompanyRegistration(companyRegistration);
            List<PaymentResponseModel> results = new List<PaymentResponseModel>();

            foreach (PaymentEntity payment in payments)
            {
                results.Add(new PaymentResponseModel
                {
                    paymentId = payment.id,
                    paymentType = payment.paymentType,
                    amount = payment.amount,
                    proofOfPaymentURL = payment.pop_attachment_path,
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference,
                    approvedBy = payment.approved_by,
                    status = payment.status

                });
            }

            return results;
        }

        public List<PaymentResponseModel> GetByDates(DateTime startDate, DateTime endDate)
        {
            List<PaymentEntity> payments = _paymentRepo.GetByDates(startDate, endDate);
            List<PaymentResponseModel> results = new List<PaymentResponseModel>();

            foreach (PaymentEntity payment in payments)
            {
                results.Add(new PaymentResponseModel
                {
                    paymentId = payment.id,
                    paymentType = payment.paymentType,
                    amount = payment.amount,
                    proofOfPaymentURL = payment.pop_attachment_path,
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference,
                    approvedBy = payment.approved_by,
                    status = payment.status

                });
            }

            return results;
        }

        public List<PaymentResponseModel> GetByInvoice(string invoice)
        {
            List<PaymentEntity> payments = _paymentRepo.GetByInvoice(invoice);
            List<PaymentResponseModel> results = new List<PaymentResponseModel>();

            foreach (PaymentEntity payment in payments)
            {
                results.Add(new PaymentResponseModel
                {
                    paymentId = payment.id,
                    paymentType = payment.paymentType,
                    amount = payment.amount,
                    proofOfPaymentURL = payment.pop_attachment_path,
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference,
                    approvedBy = payment.approved_by,
                    status = payment.status

                });
            }

            return results;
        }

        public bool UpdatePayment(PaymentRequestModel payment)
        {
            if (_paymentRepo.GetById(payment.paymentId) != null)
            {
                PaymentEntity paymentEntity = _entityBuilder.buildPaymentEntity(0, payment.invoiceReference, payment.dateOfPayment, payment.proofOfPaymentURL, payment.paymentType, payment.companyRegistration, payment.amount, payment.status, payment.approvedBy);
                
                
                if (payment.status == "Approved" && _paymentRepo.Update(paymentEntity))
                {
                    _invoiceRepository.Update(updateInvoice(payment.invoiceReference, payment.amount));
                }
                else
                {
                    throw new McpCustomException("Could not update invoice balance");
                }
                return true;
            }
            else
            {
                throw new McpCustomException("This payment doesn't exist");
            }
        }

        public async Task<bool> UploadProofOfPaymentAsync(IFormFile proofOfPayment, string fileName)
        {
            try
            {
                var credentials = new BasicAWSCredentials("AKIAWULUEPHBJDNDSAXH", "BPihEz/cIlUIp6GgXVI5R/6CqUlE4C4lpBc8F61H");
                var config = new AmazonS3Config
                {
                    RegionEndpoint = Amazon.RegionEndpoint.USEast1
                };

                using var client = new AmazonS3Client(credentials, config);
                await using var newMemoryStream = new MemoryStream();
                proofOfPayment.CopyTo(newMemoryStream);

                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = "proof-of-payment/" + fileName,
                    BucketName = "mcts-storage",
                    CannedACL = S3CannedACL.PublicRead
                };
                
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
                return true;
            }
            catch (Exception)
            {
                throw new McpCustomException("Could not save proof of payment");
            }
        }

        public List<PaymentResponseModel> GetAllPayments()
        {
            List<PaymentEntity> payments = _paymentRepo.GetAll();
            List<PaymentResponseModel> results = new List<PaymentResponseModel>();

            foreach (PaymentEntity payment in payments)
            {
                results.Add(new PaymentResponseModel
                {
                    paymentId = payment.id,
                    paymentType = payment.paymentType,
                    amount = payment.amount,
                    proofOfPaymentURL = payment.pop_attachment_path,
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference,
                    approvedBy = payment.approved_by,
                    status = payment.status

                });
            }

            return results;
        }
    }
}
