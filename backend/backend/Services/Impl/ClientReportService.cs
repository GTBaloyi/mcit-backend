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
        private readonly IInvoiceRepository _invoiceRepo;


        public ClientReportService(IClientServices clientService, IInvoiceRepository _invoiceRepo)
        {
            _clientService = clientService;
            this._invoiceRepo = _invoiceRepo;
        }

        public ClientInvoiceSummary clientInvoiceSummaries()
        {
            List<InvoiceEntity> invoice = _invoiceRepo.GetAll();
            ClientInvoiceSummary clientInvoiceSummary = new ClientInvoiceSummary();
            foreach(InvoiceEntity i in invoice)
            {
                clientInvoiceSummary.paidInvoiceAmount += i.amount_payed;

                if (i.grand_total >= i.amount_payed && i.amount_due == 0)
                {
                    clientInvoiceSummary.paidInvoices++;
                }

                if(i.amount_due > 0 && i.date_due <= DateTime.Now)
                {
                    clientInvoiceSummary.unpaidInvoices++;
                    clientInvoiceSummary.unpaidInvoiceAmount += i.amount_due;
                }

                if (i.amount_due > 0 && i.date_due > DateTime.Now)
                {
                    clientInvoiceSummary.overdueInvoices++;
                    clientInvoiceSummary.overdueInvoiceAmount += i.amount_due;
                }
            }

            return clientInvoiceSummary;

        }

        public ClientInvoiceSummary clientInvoiceSummary(string companyRegistration)
        {
            List<InvoiceEntity> invoice = _invoiceRepo.GetById(companyRegistration);
            ClientInvoiceSummary clientInvoiceSummary = new ClientInvoiceSummary();
            foreach(InvoiceEntity i in invoice)
            {
                clientInvoiceSummary.paidInvoiceAmount += i.amount_payed;
                
                if(i.grand_total >= i.amount_payed && i.amount_due == 0)
                {
                    clientInvoiceSummary.paidInvoices++;

                }

                if(i.amount_due > 0 && i.date_due <= DateTime.Now)
                {
                    clientInvoiceSummary.unpaidInvoices++;
                    clientInvoiceSummary.unpaidInvoiceAmount += i.amount_due;

                }

                if (i.amount_due > 0 && i.date_due > DateTime.Now)
                {
                    clientInvoiceSummary.overdueInvoices++;
                    clientInvoiceSummary.overdueInvoiceAmount += i.amount_due;
                }
            }


            return clientInvoiceSummary;
        }


    }
}
