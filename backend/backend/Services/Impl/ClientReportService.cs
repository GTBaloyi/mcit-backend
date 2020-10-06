using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Models.Response;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class ClientReportService : IClientsReportsService
    {
        private readonly IClientServices _clientService;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceRepository _invoiceRepo;


        public ClientReportService(IClientServices clientService,IInvoiceService invoiceService, IInvoiceRepository _invoiceRepo)
        {
            _clientService = clientService;
            _invoiceService = invoiceService;
            this._invoiceRepo = _invoiceRepo;
        }

        public ClientInvoiceSummary clientInvoiceSummary(string companyRegistration)
        {
            List<InvoiceEntity> invoice = _invoiceRepo.GetById(companyRegistration);
            return null;
        }


    }
}
