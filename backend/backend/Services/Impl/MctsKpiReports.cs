using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Models.Reports;
using backend.Services.Builder;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class MctsKpiReports : IMctsKpiReports
    {

        private readonly IProjectRepository _projectRepo;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IProjectProgressRepository _projectProgressRepo;
        private readonly IPaymentRepository _paymentRepo;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IProjectExpenditureRepository _projectExpenseRepo;
        private readonly IQuarterRepository _quarterRepo;
        private readonly IQuotationRepository _quotationRepo;
        private readonly ITargetSettingRepository _targetSettingRepository;

        public MctsKpiReports(ITargetSettingRepository targetSettingRepository, IQuotationRepository quotationRepo, IQuarterRepository quarterRepo, IProjectExpenditureRepository projectexpenseRepo, IEntityBuilder entityBuilder,IProjectRepository projectRepo, IInvoiceRepository invoiceRepo, IProjectProgressRepository projectProgressRepo, IPaymentRepository paymentRepo)
        {
            this._projectRepo = projectRepo;
            this._invoiceRepo = invoiceRepo;
            this._projectProgressRepo = projectProgressRepo;
            this._paymentRepo = paymentRepo;
            this._entityBuilder = entityBuilder;
            this._projectExpenseRepo = projectexpenseRepo;
            this._quarterRepo = quarterRepo;
            this._quotationRepo = quotationRepo;
            this._targetSettingRepository = targetSettingRepository;
        }

        public MctsKpiAllSummaryInfo GetAllSummaryInfo()
        {
            List<TargetSettingsEntity> targets = _targetSettingRepository.GetAll();
            List<ProjectProgress> projectProgresses = _projectProgressRepo.GetAll();
            List<ProjectEntity> project = _projectRepo.GetAll();

            foreach (ProjectEntity  p in project)
            {
                
            }
            string[] summaryTitle = new string[3];
            summaryTitle[0] = "Projects Within Budget (%)";
            summaryTitle[1] = "Projects Delivered on Time (%)";
            summaryTitle[2] = "Average Customer Satisfaction(%)";

            return null;

        }

        public MctsKpiSummaryTile GetSummaryTileInfo()
        {
            List<ProjectProgress> projectProgresses = _projectProgressRepo.GetAll();
            List<ProjectEntity> project = _projectRepo.GetAll();
            int deliveryTotal = 0;
            int deliveryInTime = 0;
            int inBudget = 0;
            int totalBudget = 0;
            foreach (ProjectProgress p in projectProgresses)
            {
                List<QuarterEntity> quarters = _quarterRepo.GetAll();
                if (p.project_status.ToLower() == "completed")
                {
                    deliveryTotal++;
                    if (p.actual_end_date <= _quarterRepo.GetByQuarter(p.target_end_quarter).end_date)
                    {
                        deliveryInTime++;
                    }
                }

            }

            List<InvoiceEntity> invoices = _invoiceRepo.GetAll();
            foreach (ProjectProgress p in projectProgresses)
            {
                foreach (InvoiceEntity i in invoices)
                {
                    totalBudget++;
                    if (_quotationRepo.GetByReference(i.quotation_reference).Grand_total >= i.amount_payed)
                    {
                        inBudget++;
                    }
                }

            }

            return new MctsKpiSummaryTile
            {
                inBudgetProject = (inBudget * 100) / totalBudget,
                onTimeDelivery = (deliveryInTime*100)/deliveryTotal,
                pInvoiceValueAdded = 31.68
            };
        }
    }
}
