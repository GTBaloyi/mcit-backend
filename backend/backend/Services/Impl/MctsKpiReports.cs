using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.General;
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
        private readonly IProjectTodoRepository _projectTodoRepo;
        private readonly IProductRepository _productRepository;
        private readonly IFocusAreaRepository _focusArea;
        private readonly IQuotationItemsRepository _quotationItemsRepo;
        public MctsKpiReports(IQuotationItemsRepository quotationItemsRepo, IFocusAreaRepository focusArea, IProductRepository productRepository, IProjectTodoRepository projectTodoRepo, ITargetSettingRepository targetSettingRepository, IQuotationRepository quotationRepo, IQuarterRepository quarterRepo, IProjectExpenditureRepository projectexpenseRepo, IEntityBuilder entityBuilder,IProjectRepository projectRepo, IInvoiceRepository invoiceRepo, IProjectProgressRepository projectProgressRepo, IPaymentRepository paymentRepo)
        {
            this._projectRepo = projectRepo;
            this._invoiceRepo = invoiceRepo;
            this._projectProgressRepo = projectProgressRepo;
            this._paymentRepo = paymentRepo;
            this._entityBuilder = entityBuilder;
            this._projectExpenseRepo = projectexpenseRepo;
            this._quarterRepo = quarterRepo;
            this._quotationRepo = quotationRepo;
            this._projectTodoRepo = projectTodoRepo;
            this._targetSettingRepository = targetSettingRepository;
            this._productRepository = productRepository;
            this._focusArea = focusArea;
            this._quotationItemsRepo = quotationItemsRepo;
        }

        public bool GenerateMctsKpiTarget(TargetSettingModel targets)
        {
            return false;
        }

        public ProjectsEntryModel GetAllFocusAreaProjects()
        {
            return null;

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

        public List<PerformanceIndicatorModel> GetCustomerSatisfaction()
        {
            List<TargetSettingsEntity> targetSettings = _targetSettingRepository.GetByTitle("Percentage Customer Satisfaction");
            List<ProjectProgress> allProjectProgress = _projectProgressRepo.GetAll();
            List<ProjectEntity> allProjects = _projectRepo.GetAll();
            List<QuarterEntity> allQuarters = _quarterRepo.GetAll();
            List<PerformanceIndicatorModel> result = new List<PerformanceIndicatorModel>();

            int total = 0;
            double satisfactions = 0;
            foreach (TargetSettingsEntity target in targetSettings)
            {
                PerformanceIndicatorModel indicatorModel = new PerformanceIndicatorModel();
                foreach (QuarterEntity quarters in allQuarters)
                {
                    foreach (ProjectProgress projectProgress in allProjectProgress)
                    {
                        string endQuarter = _quarterRepo.GetByDate(projectProgress.actual_end_date).quarter;

                        if (endQuarter == quarters.quarter)
                        {
                            total++;
                            if (projectProgress.target_end_quarter == endQuarter)
                            {
                                satisfactions += _projectRepo.GetByProjectNumber(projectProgress.project_number).project_satisfaction;
                            }
                        }
                    }

                    if (quarters.quarter == "Q1")
                    {
                        indicatorModel.firstQuarterActual = satisfactions/ total;
                    }

                    if (quarters.quarter == "Q2")
                    {
                        indicatorModel.secondQuarterActual = satisfactions / total;
                    }

                    if (quarters.quarter == "Q3")
                    {
                        indicatorModel.thirdQuarterActual = satisfactions / total;
                    }

                    if (quarters.quarter == "Q4")
                    {
                        indicatorModel.thirdQuarterActual = satisfactions / total;
                    }
                }
                indicatorModel.overallTarget = target.overallTarget;
                indicatorModel.category = target.category;
                indicatorModel.actualOverallTarget = (indicatorModel.firstQuarterActual + indicatorModel.secondQuarterActual + indicatorModel.thirdQuarterActual + indicatorModel.fourthQuarterActual) / 4;
                indicatorModel.title = target.title;
                indicatorModel.firstQuarterTarget = target.q1_target;
                indicatorModel.secondQuarterTarget = target.q2_target;
                indicatorModel.thirdQuarterTarget = target.q3_target;
                indicatorModel.fourthQuarterTarget = target.q4_target;
                result.Add(indicatorModel);

            }

            return result;
        }

        public List<ProjectsEntryModel> GetFocusAreaFinancials()
        {
            List<ProjectEntity> projects = _projectRepo.GetAll();
            List<FocusAreaEntity> focusAreas = _focusArea.GetAll();
            List<ProjectsEntryModel> results = new List<ProjectsEntryModel>();

            foreach (ProjectEntity project in projects)
            {
                string quotationReference = _invoiceRepo.GetByReference(project.invoice_reference).quotation_reference;
                List<QuotationItemEntity> quoteItems = _quotationItemsRepo.GetByQuote(quotationReference);
                ProjectsEntryModel record = new ProjectsEntryModel();

                record.quarter = _quarterRepo.GetByDate(_projectProgressRepo.GetByProjectNumber(project.project_number).actual_start_date).quarter;
                foreach (QuotationItemEntity quoteItem in quoteItems)
                {
                    
                    if(quoteItem.FocusArea == "Physical Metallurgy")
                    {
                            
                        record.physicalMetallurgyProjects += quoteItem.Total;
                            
                    }
                    else
                    {
                        if (quoteItem.FocusArea == "Moulding Tech")
                        {
                               
                            record.mouldingTechProjects += quoteItem.Total;
                                
                            
                        } 
                        else
                        {
                            if (quoteItem.FocusArea == "Foundry Tech")
                            {
                               
                                   
                                record.foundryTechProjects += quoteItem.Total;
                                    
                                
                            }
                            else
                            {
                                if (quoteItem.FocusArea == "SupportEquipment")
                                {
                                    record.supportTechProjects += quoteItem.Total;
                                }
                                else
                                {
                                    record.otherProjects += quoteItem.Total;
                                }
                            }
                        }
                    }
                    record.total = record.supportTechProjects + record.physicalMetallurgyProjects + record.mouldingTechProjects + record.foundryTechProjects + record.otherProjects;
                    results.Add(record);
                }


            }

            List<ProjectsEntryModel> finalResults = new List<ProjectsEntryModel>();
            ProjectsEntryModel finalist = new ProjectsEntryModel();
            finalist.quarter = "Q1";
            foreach(ProjectsEntryModel result in results)
            {
                if(result.quarter == "Q1")
                {
                    finalist.mouldingTechProjects += result.mouldingTechProjects;
                    finalist.otherProjects += result.otherProjects;
                    finalist.physicalMetallurgyProjects += result.physicalMetallurgyProjects;
                    finalist.supportTechProjects += result.supportTechProjects;
                    finalist.total += result.total;
                }
            }
            finalResults.Add(finalist);

            finalist = new ProjectsEntryModel();
            finalist.quarter = "Q2";
            foreach (ProjectsEntryModel result in results)
            {
                if (result.quarter == "Q2")
                {
                    finalist.mouldingTechProjects += result.mouldingTechProjects;
                    finalist.otherProjects += result.otherProjects;
                    finalist.physicalMetallurgyProjects += result.physicalMetallurgyProjects;
                    finalist.supportTechProjects += result.supportTechProjects;
                    finalist.total += result.total;
                }
            }
            finalResults.Add(finalist);

            finalist = new ProjectsEntryModel();
            finalist.quarter = "Q3";
            foreach (ProjectsEntryModel result in results)
            {
                if (result.quarter == "Q3")
                {
                    finalist.mouldingTechProjects += result.mouldingTechProjects;
                    finalist.otherProjects += result.otherProjects;
                    finalist.physicalMetallurgyProjects += result.physicalMetallurgyProjects;
                    finalist.supportTechProjects += result.supportTechProjects;
                    finalist.total += result.total;
                }
            }
            finalResults.Add(finalist);

            finalist = new ProjectsEntryModel();
            finalist.quarter = "Q4";
            foreach (ProjectsEntryModel result in results)
            {
                if (result.quarter == "Q4")
                {
                    finalist.mouldingTechProjects += result.mouldingTechProjects;
                    finalist.otherProjects += result.otherProjects;
                    finalist.physicalMetallurgyProjects += result.physicalMetallurgyProjects;
                    finalist.supportTechProjects += result.supportTechProjects;
                    finalist.total += result.total;
                }
            }
            finalResults.Add(finalist);

            return finalResults;
        }

        public List<PerformanceIndicatorModel> GetProjectsDeliveredInTime()
        {
            List<TargetSettingsEntity> targetSettings = _targetSettingRepository.GetByTitle("Projects Delivered in time");
            List<ProjectProgress> allProjectProgress = _projectProgressRepo.GetAll();
            List<QuarterEntity> allQuarters = _quarterRepo.GetAll();
            List<PerformanceIndicatorModel> results = new List<PerformanceIndicatorModel>();
            int total = 0;
            int endInTime = 0;
            foreach (TargetSettingsEntity targetSetting in targetSettings)
            {
                PerformanceIndicatorModel indicatorModel = new PerformanceIndicatorModel();

                foreach (QuarterEntity quarters in allQuarters)
                {
                    foreach (ProjectProgress projectProgress in allProjectProgress)
                    {
                        /*List<ProjectTODO> pTodos = _projectTodoRepo.GetByProjectNumber(projectProgress.project_number);
                        foreach(ProjectTODO todo in pTodos)
                        {
                            
                        }*/
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

                indicatorModel.overallTarget = targetSetting.overallTarget;
                indicatorModel.category = targetSetting.category;
                indicatorModel.actualOverallTarget = (indicatorModel.firstQuarterActual + indicatorModel.secondQuarterActual + indicatorModel.thirdQuarterActual + indicatorModel.fourthQuarterActual) / 4;
                indicatorModel.title = targetSetting.title;
                indicatorModel.firstQuarterTarget = targetSetting.q1_target;
                indicatorModel.secondQuarterTarget = targetSetting.q2_target;
                indicatorModel.thirdQuarterTarget = targetSetting.q3_target;
                indicatorModel.fourthQuarterTarget = targetSetting.q4_target;
                results.Add(indicatorModel);
            }
            return results;
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
