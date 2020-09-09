using backend.Models.Response;
using backend.Models.Request;
using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IInvoiceService
    {
        InvoiceResponseModel GenerateInvoice(InvoiceRequestModel model);
        List<InvoiceResponseModel> GetById(string companyRegistration);
        InvoiceResponseModel GetByInvoiceReference(string invoiceReference);
        List<InvoiceResponseModel> GetAll();
        void Delete(string reference);
        InvoiceResponseModel Update(InvoiceRequestModel model);
        InvoiceEntity GetByReferernce(string reference);



    }
}
