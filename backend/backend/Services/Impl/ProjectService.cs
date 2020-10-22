using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IProjectExpenditureRepository _projectExpenditureRepository;
        private readonly IProjectTodoRepository _projectTodoRepository;
        private readonly IProjectProgressRepository _projectProgressRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IInvoiceRepository _invoiceRepo;

        public ProjectService(IInvoiceRepository invoiceRepo,IEmployeesRepository employeesRepository,IProjectRepository projectRepository, IEntityBuilder entityBuilder, IProjectExpenditureRepository _projectExpenditureRepository, IProjectTodoRepository _projectTodoRepository, IProjectProgressRepository _projectProgressRepository)
        {
            _entityBuilder = entityBuilder;
            _projectRepository = projectRepository;
            _employeesRepository = employeesRepository;
            this._projectExpenditureRepository = _projectExpenditureRepository;
            this._projectProgressRepository = _projectProgressRepository;
            this._projectTodoRepository = _projectTodoRepository;
            this._invoiceRepo = invoiceRepo;
        }

        public bool createProject(ProjectInformationRequestModel project)
        {
            string projectNumber = createProjectNumber();
            ProjectEntity newProject = _entityBuilder.buildProjectEntity(0, projectNumber, project.projectName, project.projectDescription, project.invoiceReferenceNumber, project.companyRegistrationNumber,project.projectSatisfaction, DateTime.Now.Date, project.projectLeaderId);
            ProjectExpenditure projectExpense = _entityBuilder.buildProjectExpenditureEntity(0, projectNumber, "", "", 0, _invoiceRepo.GetByReference(project.invoiceReferenceNumber).grand_total);
            if(_projectExpenditureRepository.Insert(projectExpense))
            {
                return _projectRepository.Insert(newProject);
            }
            else
            {
                throw new McpCustomException("Could not create project expense");
            }
            
        }

        private string assignedEmployees(string[] assignedEmployees)
        {
            string result = assignedEmployees[0];
            for (int i = 1; i < assignedEmployees.Length; i++)
            {
                result += "," + assignedEmployees[i];
            }
            return result;
        }

        private string createProjectNumber()
        {
            string date = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + 0;
            List<ProjectEntity> projects = _projectRepository.GetAll();

            if (projects.Count != 0)
            {
                return "PJ-" + date + "" + projects.Last().id + 1;
            }
            else
            {
                return "PJ-" + date + "" + 1;
            }
        }

        public bool deleteProject(string projectNumber)
        {
            ProjectEntity project = _projectRepository.GetByProjectNumber(projectNumber);
            if(project != null)
            {
                ProjectExpenditure pe = _projectExpenditureRepository.GetByProjectNumber(projectNumber);
                List<ProjectTODO> pt = _projectTodoRepository.GetByProjectNumber(projectNumber);
                ProjectProgress pp = _projectProgressRepository.GetByProjectNumber(projectNumber);

                bool peResults = pe != null ? _projectExpenditureRepository.Delete(pe) : false;

                foreach(ProjectTODO projTodo in pt)
                {
                    _projectTodoRepository.Delete(projTodo);
                }

                bool ppResults = pp != null ? _projectProgressRepository.Delete(pp) : false;

                return _projectRepository.Delete(project);
            }

            throw new McpCustomException("Project with project number " + projectNumber + " does not exist");

        }

        public List<ProjectInformationResponseModel> getAllProjects()
        {

            List<ProjectInformationResponseModel> projects = new List<ProjectInformationResponseModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetAll();

            if (projectEntities != null)
            {
                for (int i = 0; i < projectEntities.Count; i++)
                {
                   
                    EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(projectEntities[i].project_leader);
                    projects.Add(new ProjectInformationResponseModel
                    {
                        id = projectEntities[i].id,
                        projectNumber = projectEntities[i].project_number,
                        projectName = projectEntities[i].project_name,
                        projectDescription = projectEntities[i].project_description,
                        invoiceReferenceNumber = projectEntities[i].invoice_reference,
                        companyRegistrationNumber = projectEntities[i].company_registration,
                        projectSatisfaction = projectEntities[i].project_satisfaction,
                        projectExpenditure = this.buildProjectExpenditure(_projectExpenditureRepository.GetByProjectNumber(projectEntities[i].project_number)),
                        projectProgress = this.buildProjectProgress(_projectProgressRepository.GetByProjectNumber(projectEntities[i].project_number)),
                        projectTodo = this.buildProjectProjectTodo(_projectTodoRepository.GetByProjectNumber(projectEntities[i].project_number)),
                        createdOn = projectEntities[i].createdOn,
                        projectLeaderId = projectEntities[i].project_leader,
                        projectLeaderNames = employee.name + " "+employee.surname
                    });
                }
            }
            

            return projects;
        }

        public ProjectInformationResponseModel getProjectByInvoice(string invoiceId)
        {
            ProjectEntity projectEntities = _projectRepository.GetByInvoice(invoiceId);
            if(projectEntities != null)
            {
                EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(projectEntities.project_leader);

                return new ProjectInformationResponseModel
                {
                    id = projectEntities.id,
                    projectNumber = projectEntities.project_number,
                    projectName = projectEntities.project_name,
                    projectDescription = projectEntities.project_description,
                    invoiceReferenceNumber = projectEntities.invoice_reference,
                    companyRegistrationNumber = projectEntities.company_registration,
                    projectSatisfaction = projectEntities.project_satisfaction,
                    projectExpenditure = this.buildProjectExpenditure(_projectExpenditureRepository.GetByProjectNumber(projectEntities.project_number)),
                    projectProgress = this.buildProjectProgress(_projectProgressRepository.GetByProjectNumber(projectEntities.project_number)),
                    projectTodo = this.buildProjectProjectTodo(_projectTodoRepository.GetByProjectNumber(projectEntities.project_number)),
                    createdOn = projectEntities.createdOn,
                    projectLeaderId = projectEntities.project_leader,
                    projectLeaderNames = employee.name + " " + employee.surname
                };
            }
            else
            {
                return null;
            }
           
        }

        public ProjectInformationResponseModel getProjectByProjectNumber(string projectNumber)
        {
            ProjectEntity projectEntities = _projectRepository.GetByProjectNumber(projectNumber);

            if (projectEntities != null)
            {
                EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(projectEntities.project_leader);

                return new ProjectInformationResponseModel
                {
                    id = projectEntities.id,
                    projectNumber = projectEntities.project_number,
                    projectName = projectEntities.project_name,
                    projectDescription = projectEntities.project_description,
                    invoiceReferenceNumber = projectEntities.invoice_reference,
                    companyRegistrationNumber = projectEntities.company_registration,
                    projectSatisfaction = projectEntities.project_satisfaction,
                    projectExpenditure = this.buildProjectExpenditure(_projectExpenditureRepository.GetByProjectNumber(projectEntities.project_number)),
                    projectProgress = this.buildProjectProgress(_projectProgressRepository.GetByProjectNumber(projectEntities.project_number)),
                    projectTodo = this.buildProjectProjectTodo(_projectTodoRepository.GetByProjectNumber(projectEntities.project_number)),
                    createdOn = projectEntities.createdOn,
                    projectLeaderId = projectEntities.project_leader,
                    projectLeaderNames = employee.name + " " + employee.surname
                };
            }
            return null;
        }

        public List<ProjectInformationResponseModel> getProjects(string companyRegistrationNumber)
        {
            List<ProjectInformationResponseModel> projects = new List<ProjectInformationResponseModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetByCompanyRegistration(companyRegistrationNumber);

            if (projectEntities != null)
            {
                for (int i = 0; i < projectEntities.Count; i++)
                {
                    EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(projectEntities[i].project_leader);
                    projects.Add(new ProjectInformationResponseModel
                    {
                        id = projectEntities[i].id,
                        projectNumber = projectEntities[i].project_number,
                        projectName = projectEntities[i].project_name,
                        projectDescription = projectEntities[i].project_description,
                        invoiceReferenceNumber = projectEntities[i].invoice_reference,
                        companyRegistrationNumber = projectEntities[i].company_registration,
                        projectSatisfaction = projectEntities[i].project_satisfaction,
                        projectExpenditure = this.buildProjectExpenditure(_projectExpenditureRepository.GetByProjectNumber(projectEntities[i].project_number)),
                        projectProgress = this.buildProjectProgress(_projectProgressRepository.GetByProjectNumber(projectEntities[i].project_number)),
                        projectTodo = this.buildProjectProjectTodo(_projectTodoRepository.GetByProjectNumber(projectEntities[i].project_number)),
                        createdOn = projectEntities[i].createdOn,
                        projectLeaderId = projectEntities[i].project_leader,
                        projectLeaderNames = employee.name + " "+ employee.surname
                    });
                }
            }


            return projects;
        }

        public List<ProjectInformationResponseModel> getProjectsByAssignedEmployees(string employeeIDs)
        {
            List<ProjectInformationResponseModel> results = new List<ProjectInformationResponseModel>();
            List<ProjectEntity> projects = _projectRepository.GetAll();
            List<ProjectTODO> todos = _projectTodoRepository.GetAll();
            if(projects.Count > 0)
            {
                foreach(ProjectEntity project in projects)
                {
                    if(project.project_leader == employeeIDs)
                    {
                        results.Add(getProjectByProjectNumber(project.project_number));
                    }
                }
            }

            if(todos.Count > 0)
            {
                foreach(ProjectTODO todo in todos)
                {
                    String []employees = todo.responsible_employees.Split(',');
                    foreach(String employee in employees)
                    {
                        if (employee == employeeIDs)
                        {
                            results.Add(getProjectByProjectNumber(todo.project_number));
                        }

                    }
                }
            }

            return results;
        }

        public bool updateProject(ProjectInformationRequestModel project)
        {

            ProjectEntity existingRecord = _projectRepository.GetByProjectNumber(project.projectNumber);
            if(existingRecord != null)
            {
                ProjectEntity updateProject = _entityBuilder.buildProjectEntity(existingRecord.id,project.projectNumber, project.projectName, project.projectDescription, project.invoiceReferenceNumber, project.companyRegistrationNumber, project.projectSatisfaction, project.createdOn, project.projectLeaderId);
                return _projectRepository.Update(updateProject);
            }

            throw new McpCustomException("Project reference " + project.projectNumber + "does not exist");
            
        }

        private ProjectExpenditureResponseModel buildProjectExpenditure(ProjectExpenditure projectExpenditure)
        {
            if(projectExpenditure != null)
            {
                return new ProjectExpenditureResponseModel
                {
                    id = projectExpenditure.id,
                    projectNumber = projectExpenditure.project_number,
                    focusArea = projectExpenditure.focus_area,
                    item = projectExpenditure.item,
                    actualCost = projectExpenditure.actual_cost,
                    targetCost = projectExpenditure.target_cost
                };
            }
            else
            {
                return null; 
            }
            
        }

        private List<ResponsibleEmployees> GetResponsibleEmployees(string []employeesId)
        {

            List<ResponsibleEmployees> responsibleEmployees = new List<ResponsibleEmployees>();
            foreach (string emp in employeesId)
            {
                EmployeesEntity e = _employeesRepository.GetByEmployeeNumber(emp);
                if(e != null)
                {
                    responsibleEmployees.Add(new ResponsibleEmployees
                    {
                        name = e.name,
                        employeeNumber = e.employee_number,
                        surname = e.surname
                    });
                }
                
            }

            return responsibleEmployees;
        }
        private List<ProjectTodoResponseModel> buildProjectProjectTodo(List<ProjectTODO> projectTodo)
        {
            List<ProjectTodoResponseModel> result = new List<ProjectTodoResponseModel>();
            foreach(ProjectTODO p in projectTodo)
            {
                string[] employeees = p.responsible_employees.Split(',');
                
                result.Add(new ProjectTodoResponseModel
                {
                    id = p.id,
                    projectNumber = p.project_number,
                    sequenceNumber = p.sequence,
                    isSequential = p.isSequential,
                    focusArea = p.focus_area,
                    item = p.item,
                    status =p.status,
                    dateStarted = p.date_started,
                    dateEnded = p.date_ended,
                    responsibleEmployees = GetResponsibleEmployees(employeees)
                });
            }
            return result;
        }

        private ProjectProgressResponseModel buildProjectProgress(ProjectProgress projectProgress)
        {
            if(projectProgress != null)
            {
                return new ProjectProgressResponseModel
                {
                    projectNumber = projectProgress.project_number,
                    targetStartDate = projectProgress.target_start_date,
                    targetEndDate = projectProgress.target_start_date.AddDays(projectProgress.target_duration),
                    ActualStartDate = projectProgress.actual_start_date,
                    ActualEndDate = projectProgress.actual_end_date,
                    projectStatus = projectProgress.project_status,
                    progressUpdatePercentage = projectProgress.project_status_percentage,
                    startedQuarter = projectProgress.start_quarter,
                    currentQuarter = projectProgress.current_quarter,
                    endingQuarter = projectProgress.target_end_quarter,
                    projectDuration = projectProgress.target_duration
                };
            }
            else
            {
                return null;
            }
            
        }

        public List<ProjectSummaryModel> getAllProjectSummary()
        {
            List<ProjectSummaryModel> projects = new List<ProjectSummaryModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetAll();

            if (projectEntities != null)
            {
                for (int i = 0; i < projectEntities.Count; i++)
                {

                    EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(projectEntities[i].project_leader);
                    ProjectProgress projectProgress = _projectProgressRepository.GetByProjectNumber(projectEntities[i].project_number);
                    projects.Add(new ProjectSummaryModel
                    {
                        
                        id = projectEntities[i].id,
                        projectNumber = projectEntities[i].project_number,
                        projectName = projectEntities[i].project_name,
                        projectDescription = projectEntities[i].project_description,
                        companyRegistrationNumber = projectEntities[i].company_registration,
                        projectStatus = projectProgress.project_status,
                        projectProgress = projectProgress.project_status_percentage,
                        createdOn = projectEntities[i].createdOn,
                        
                    });
                }
            }


            return projects;
        }

        public List<ProjectSummaryModel> getAllProjectSummaryByLeader(string projectLeader)
        {
            List<ProjectSummaryModel> projects = new List<ProjectSummaryModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetAll();

            if (projectEntities != null)
            {
                for (int i = 0; i < projectEntities.Count; i++)
                {

                    EmployeesEntity employee = _employeesRepository.GetByEmployeeNumber(projectEntities[i].project_leader);
                    if(projectLeader == projectEntities[i].project_leader)
                    {
                        ProjectProgress projectProgress = _projectProgressRepository.GetByProjectNumber(projectEntities[i].project_number);
                        projects.Add(new ProjectSummaryModel
                        {

                            id = projectEntities[i].id,
                            projectNumber = projectEntities[i].project_number,
                            projectName = projectEntities[i].project_name,
                            projectDescription = projectEntities[i].project_description,
                            companyRegistrationNumber = projectEntities[i].company_registration,
                            projectStatus = projectProgress.project_status,
                            projectProgress = projectProgress.project_status_percentage,
                            createdOn = projectEntities[i].createdOn,

                        });
                    }
                    
                }
            }


            return projects;
        }
    }
}
