using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Models;
using backend.Models.General;
using backend.Models.Response;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class EmployeeReportsServices : IEmployeeReportsServices
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IClientServices clientServices;
        private readonly IProjectRepository _projectRepository;
        private readonly IQuotationRepository _quotationRepo;

        public EmployeeReportsServices(IInvoiceRepository invoiceRepo, IClientServices clientServices, IProjectRepository projectRepository, IQuotationRepository quotationRepo)
        {
            _invoiceRepo = invoiceRepo;
            this.clientServices = clientServices;
            _projectRepository = projectRepository;
            _quotationRepo = quotationRepo;
        }

        public ClientsGeneralReportsModel GetClientsGeneralReports()
        {
            List<ClientRegistrationRequestModel> allClients = clientServices.GetAllClients();
            int allActive = 0;
            int allInActive = 0;
            int deactivated = 0;
            int suspended = 0;
            foreach (ClientRegistrationRequestModel client in allClients)
            {
                if(client.userStatus == 1)
                {
                    allActive++;
                }
                else
                {
                    allInActive++;
                }

                if (client.userStatus == 3)
                {
                    suspended++;
                }

                if (client.userStatus == 4)
                {
                    deactivated++;
                }
            }

            List<ProjectEntity> allProjects = _projectRepository.GetAll();
            double[] totalRating = new double[allProjects.Count];
            for(int i=0;  i < allProjects.Count; i++)
            {
                if (allProjects[i].project_satisfaction != 0)
                {
                    totalRating[i] = allProjects[i].project_satisfaction;
                }
            }

            return new ClientsGeneralReportsModel
            {
                totalInActiveClients = allInActive,
                totalActiveClients = allActive,
                totalDeactivatedClients = deactivated,
                averageClientSatisfaction = totalRating.Average(),
                totalSuspendedClients = suspended
            };

        }

        public InvoiceGeneralReportsModel GetInvoiceGeneralReports()
        {
            List<InvoiceEntity> allInvoices = _invoiceRepo.GetAll();
            int invoiceFullyPaid = 0;
            int invoiceUnpaid = 0;
            int invoiceOverdue = 0;
            foreach (InvoiceEntity invoice in allInvoices)
            {
                if(invoice.amount_payed >= invoice.grand_total)
                {
                    invoiceFullyPaid++;
                }

                if (invoice.amount_payed < invoice.grand_total)
                {
                    invoiceUnpaid++;
                }

                if (invoice.amount_payed < invoice.grand_total && invoice.date_due.Date > DateTime.Now.Date)
                {
                    invoiceOverdue++;
                }
            }

            return new InvoiceGeneralReportsModel
            {
                totalInvoices = allInvoices.Count,
                totalPaidInvoice = invoiceFullyPaid,
                totalOverdueInvoice = invoiceOverdue,
                totalUnpaidInvoice = invoiceUnpaid
            };
        }

        public QuotationGeneralReportModel GetQuotationGeneralReport()
        {
            List<QuotationEntity> quotationEntities = _quotationRepo.GetAll();
            QuotationGeneralReportModel result = new QuotationGeneralReportModel();

            foreach(QuotationEntity quotation in quotationEntities)
            {
                if(quotation.status == "Accepted")
                {
                    result.totalAccepted++;
                }

                if (quotation.status == "Pending Client Approval")
                {
                    result.totalPendingCustomerApproval++;
                }

                if (quotation.status == "Pending Manager Approval")
                {
                    result.totalPendingManagerApproval++;
                }

                if (quotation.status == "Pending")
                {
                    result.totalPendingEmployeeAttention++;
                }

                if (quotation.status == "rejected")
                {
                    result.totalRejected++;
                }

                result.totalQuotationsRequested++;
            }

            return result;
        }
    }
}
