using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
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

        public PaymentService(IPaymentRepository paymentRepo, IEntityBuilder entityBuilder)
        {
            _paymentRepo = paymentRepo;
            _entityBuilder = entityBuilder;
        }

        public bool CreatePaymentAsync(PaymentRequestModel payment)
        {
            PaymentEntity paymentEntity = _entityBuilder.buildPaymentEntity(0, payment.invoiceReference, payment.dateOfPayment, payment.proofOfPaymentURL, payment.paymentType, payment.companyRegistration, payment.amount);
            return _paymentRepo.Insert(paymentEntity);
        }

        public bool DeletePayment(PaymentRequestModel payment)
        {
            throw new NotImplementedException();
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
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference

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
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference

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
                    dateOfPayment = payment.date_of_payment,
                    companyRegistration = payment.companyRegistration,
                    invoiceReference = payment.invoice_reference

                });
            }

            return results;
        }

        public bool UpdatePayment(PaymentRequestModel payment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadProofOfPaymentAsync(IFormFile proofOfPayment)
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
                    Key = "proof-of-payment/" + proofOfPayment.FileName,
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
    }
}
