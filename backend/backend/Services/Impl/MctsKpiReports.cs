using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
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

        public bool GenerateMctsKpiTarget(TargetSettingModel targets)
        {
            return false;
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

        public PerformanceIndicatorModel GetProjectsDeliveredInTime()
        {
            TargetSettingsEntity targetSettings = _targetSettingRepository.GetByTitle("Projects Delivered in time");
            List<ProjectProgress> allProjectProgress = _projectProgressRepo.GetAll();
            List<QuarterEntity> allQuarters = _quarterRepo.GetAll();
            PerformanceIndicatorModel indicatorModel = new PerformanceIndicatorModel();
            int total = 0;
            int endInTime = 0;
            if (targetSettings != null)
            {
                foreach (QuarterEntity quarters in allQuarters)
                {
                    foreach (ProjectProgress projectProgress in allProjectProgress)
                    {
                        if (projectProgress.target_end_quarter == quarters.quarter)
                        {
                            total++;
                            string endQuarter = _quarterRepo.GetByDate(projectProgress.actual_end_date).quarter;
                            if (projectProgress.target_end_quarter == endQuarter)
                            {
                                endInTime++;
                            }
                        }
                    }

                    if (quarters.quarter == "Q1")
                    {
                        indicatorModel.firstQuarterActual = (endInTime * 100) / total;
                    }

                    if (quarters.quarter == "Q2")
                    {
                        indicatorModel.secondQuarterActual = (endInTime * 100) / total;
                    }

                    if (quarters.quarter == "Q3")
                    {
                        indicatorModel.thirdQuarterActual = (endInTime * 100) / total;
                    }

                    if (quarters.quarter == "Q4")
                    {
                        indicatorModel.thirdQuarterActual = (endInTime * 100) / total;
                    }
                }


                TargetSettingsEntity target = _targetSettingRepository.GetByTitle("Projects Delivered In Time");
                if (target != null)
                {
                    indicatorModel.overallTarget = target.overallTarget;
                    indicatorModel.category = target.category;
                    indicatorModel.actualOverallTarget = (indicatorModel.firstQuarterActual + indicatorModel.secondQuarterActual + indicatorModel.thirdQuarterActual + indicatorModel.fourthQuarterActual) / 4;
                    indicatorModel.title = target.title;
                    indicatorModel.firstQuarterTarget = target.q1_target;
                    indicatorModel.secondQuarterTarget = target.q2_target;
                    indicatorModel.thirdQuarterTarget = target.q3_target;
                    indicatorModel.fourthQuarterTarget = target.q4_target;
                    return indicatorModel;
                }
                else
                {
                    throw new McpCustomException("Could not find target setting 'Projects Delivered in time'. Please create target setting with that that title");
                }
            }
            else
            {
                throw new McpCustomException("Could not find target setting 'Projects Delivered in time'. Please create target setting with that that title");

            }
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
