using backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IClientsReportsService
    {
        ClientInvoiceSummary clientInvoiceSummary(string companyRegistration);
        ClientInvoiceSummary clientInvoiceSummaries();
    }
}
