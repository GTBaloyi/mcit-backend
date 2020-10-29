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
        public MctsKpiReports(IFocusAreaRepository focusArea, IProductRepository productRepository, IProjectTodoRepository projectTodoRepo, ITargetSettingRepository targetSettingRepository, IQuotationRepository quotationRepo, IQuarterRepository quarterRepo, IProjectExpenditureRepository projectexpenseRepo, IEntityBuilder entityBuilder,IProjectRepository projectRepo, IInvoiceRepository invoiceRepo, IProjectProgressRepository projectProgressRepo, IPaymentRepository paymentRepo)
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
        }

        public bool GenerateMctsKpiTarget(TargetSettingModel targets)
        {
            return false;
        }

        public ProjectsEntryModel GetAllFocusAreaProjects()
        {
            List<ProjectEntity> projects = _projectRepo.GetAll();
            List<FocusAreaEntity> focusAreas = _focusArea.GetAll();
            int q1 = 0;
            int q2 = 0;
            int q3 = 0;
            int q4 = 0;

            foreach (ProjectEntity project in projects)
            {
                string startQuarter = _quarterRepo.GetByDate(_projectProgressRepo.GetByProjectNumber(project.project_number).actual_start_date).quarter;
                foreach(FocusAreaEntity focusArea in focusAreas)
                {
                    ProjectsEntryModel record = new ProjectsEntryModel();
                    
                    List<ProjectTODO> todos = _projectTodoRepo.GetByProjectNumber(project.project_number);
                    foreach (ProjectTODO todo in todos)
                    {
                        if ( _focusArea.GetByName(todo.focus_area).name == focusArea.name)
                        {
                                    
                            if(startQuarter == "Q1")
                            {

                                q1++;
                                //rec
                            }

                            if (startQuarter == "Q2")
                            {
                                //record.firstQuarter++;
                            }

                            if (startQuarter == "Q3")
                            {
                               // record.firstQuarter++;
                            }

                            if (startQuarter == "Q4")
                            {
                                //record.firstQuarter++;
                            }
                        }
                     
                    }

                }
                
            }
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

        public PerformanceIndicatorModel GetCustomerSatisfaction()
        {
            TargetSettingsEntity targetSettings = _targetSettingRepository.GetByTitle("Percentage Customer Satisfaction");
            List<ProjectProgress> allProjectProgress = _projectProgressRepo.GetAll();
            List<ProjectEntity> allProjects = _projectRepo.GetAll();
            List<QuarterEntity> allQuarters = _quarterRepo.GetAll();
            PerformanceIndicatorModel indicatorModel = new PerformanceIndicatorModel();
            int total = 0;
            double satisfactions = 0;
            if (targetSettings != null)
            {
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
                    throw new McpCustomException("Could not find target setting 'Percentage Customer Satisfaction'. Please create target setting with that that title");
                }
            }
            else
            {
                throw new McpCustomException("Could not find target setting 'Percentage Customer Satisfaction'. Please create target setting with that that title");

            }
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
