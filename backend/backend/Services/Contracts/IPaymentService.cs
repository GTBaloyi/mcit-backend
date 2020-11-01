using backend.DataAccess.Database.Entities;
using backend.Models.Request;
using backend.Models.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IPaymentService
    {
        List<PaymentResponseModel> GetAllPayments();
        Task<bool> CreatePaymentAsync(PaymentRequestModel payment);
        bool UpdatePayment(PaymentRequestModel payment);
        List<PaymentResponseModel> GetByInvoice(string invoice);
        List<PaymentResponseModel> GetByCompanyRegistration(string companyRegistration);
        List<PaymentResponseModel> GetByDates(DateTime startDate, DateTime endDate);
        Task<bool> UploadProofOfPaymentAsync(IFormFile proofOfPayment, string fileName);
        bool DeletePayment(PaymentRequestModel payment);


    }
}
