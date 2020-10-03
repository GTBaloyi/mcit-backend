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


        public ClientReportService(IClientServices clientService,IInvoiceService invoiceService)
        {
            _clientService = clientService;
            _invoiceService = invoiceService;
        }

        public ClientInvoiceSummary clientInvoiceSummary(string companyRegistration)
        {
            return null;
        }


    }
}
