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
        bool GenerateInvoice(InvoiceRequestModel model);
        InvoiceResponseModel GetById(int id);
        List<InvoiceResponseModel> GetAll();
        void Delete(int id);
        InvoiceResponseModel Update(InvoiceRequestModel model);


    }
}
