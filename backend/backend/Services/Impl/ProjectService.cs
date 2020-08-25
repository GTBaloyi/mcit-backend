﻿using backend.DataAccess.Database.Entities;
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

        public ProjectService(IProjectRepository projectRepository, IEntityBuilder entityBuilder)
        {
            _entityBuilder = entityBuilder;
            _projectRepository = projectRepository;
        }

        public bool createProject(ProjectInformationRequestModel project)
        {
            string projectNumber = createProjectNumber();
            string employeesAssigned = assignedEmployees(project.assignedEmployees);
            ProjectEntity newProject = _entityBuilder.buildProjectEntity(0, projectNumber, project.projectName, project.isSequential, project.projectDescription, project.invoiceReferenceNumber, project.companyRegistrationNumber, employeesAssigned, DateTime.Now.Date);
            return _projectRepository.Insert(newProject);
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
            throw new NotImplementedException();
        }

        public List<ProjectInformationResponseModel> getAllProjects()
        {
            List<ProjectInformationResponseModel> projects = new List<ProjectInformationResponseModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetAll();

            if (projectEntities != null)
            {
                for (int i = 0; i < projectEntities.Count; i++)
                {
                    string[] employees = projectEntities[i].assigned_employees.Split(",");
                    projects.Add(new ProjectInformationResponseModel
                    {
                        id = projectEntities[i].id,
                        projectNumber = projectEntities[i].project_number,
                        projectName = projectEntities[i].project_name,
                        isSequential = projectEntities[i].isSequential,
                        projectDescription = projectEntities[i].project_description,
                        invoiceReferenceNumber = projectEntities[i].invoice_reference,
                        companyRegistrationNumber = projectEntities[i].company_registration,
                        assignedEmployees = employees,
                        createdOn = projectEntities[i].createdOn
                    });
                }
            }
            

            return projects;
        }

        public ProjectInformationResponseModel getProjectByInvoice(string invoiceId)
        {
            ProjectEntity projectEntities = _projectRepository.GetByInvoice(invoiceId);
            string[] employees = projectEntities.assigned_employees.Split(",");
            

            return new ProjectInformationResponseModel
            {
                id = projectEntities.id,
                projectNumber = projectEntities.project_number,
                projectName = projectEntities.project_name,
                isSequential = projectEntities.isSequential,
                projectDescription = projectEntities.project_description,
                invoiceReferenceNumber = projectEntities.invoice_reference,
                companyRegistrationNumber = projectEntities.company_registration,
                assignedEmployees = employees,
                createdOn = projectEntities.createdOn
            };
        }

        public ProjectInformationResponseModel getProjectByProjectNumber(string projectNumber)
        {
            ProjectEntity projectEntities = _projectRepository.GetByProjectNumber(projectNumber);
            string[] employees = projectEntities.assigned_employees.Split(",");


            return new ProjectInformationResponseModel
            {
                id = projectEntities.id,
                projectNumber = projectEntities.project_number,
                projectName = projectEntities.project_name,
                isSequential = projectEntities.isSequential,
                projectDescription = projectEntities.project_description,
                invoiceReferenceNumber = projectEntities.invoice_reference,
                companyRegistrationNumber = projectEntities.company_registration,
                assignedEmployees = employees,
                createdOn = projectEntities.createdOn
            };
        }

        public List<ProjectInformationResponseModel> getProjects(string companyRegistrationNumber)
        {
            List<ProjectInformationResponseModel> projects = new List<ProjectInformationResponseModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetByCompanyRegistration(companyRegistrationNumber);

            if (projectEntities != null)
            {
                for (int i = 0; i < projectEntities.Count; i++)
                {
                    string[] employees = projectEntities[i].assigned_employees.Split(",");
                    projects.Add(new ProjectInformationResponseModel
                    {
                        id = projectEntities[i].id,
                        projectNumber = projectEntities[i].project_number,
                        projectName = projectEntities[i].project_name,
                        isSequential = projectEntities[i].isSequential,
                        projectDescription = projectEntities[i].project_description,
                        invoiceReferenceNumber = projectEntities[i].invoice_reference,
                        companyRegistrationNumber = projectEntities[i].company_registration,
                        assignedEmployees = employees,
                        createdOn = projectEntities[i].createdOn
                    });
                }
            }


            return projects;
        }

        public List<ProjectInformationResponseModel> getProjectsByAssignedEmployees(string employeeIDs)
        {
            List<ProjectInformationResponseModel> projects = new List<ProjectInformationResponseModel>();
            List<ProjectEntity> projectEntities = _projectRepository.GetAll();

            
            if (projectEntities != null)
            {

                for (int i = 0; i < projectEntities.Count; i++)
                {
                    string[] employees = projectEntities[i].assigned_employees.Split(",");
                    for (int k = 0; k < employees.Length; k++)
                    {
                        if (employees[k] == employeeIDs)
                        {
                            projects.Add(new ProjectInformationResponseModel
                            {
                                id = projectEntities[i].id,
                                projectNumber = projectEntities[i].project_number,
                                projectName = projectEntities[i].project_name,
                                isSequential = projectEntities[i].isSequential,
                                projectDescription = projectEntities[i].project_description,
                                invoiceReferenceNumber = projectEntities[i].invoice_reference,
                                companyRegistrationNumber = projectEntities[i].company_registration,
                                assignedEmployees = employees,
                                createdOn = projectEntities[i].createdOn
                            });
                        }
                    }
                    
                }
            }


            return projects;
        }

        public bool updateProject(ProjectInformationRequestModel project)
        {
            ProjectEntity existingRecord = _projectRepository.GetByProjectNumber(project.projectNumber);
            if(existingRecord != null)
            {
                string employeesAssigned = assignedEmployees(project.assignedEmployees);
                ProjectEntity updateProject = _entityBuilder.buildProjectEntity(existingRecord.id,project.projectNumber, project.projectName, project.isSequential, project.projectDescription, project.invoiceReferenceNumber, project.companyRegistrationNumber, employeesAssigned,project.createdOn);
                return _projectRepository.Update(updateProject);
            }

            return false;
            
        }
    }
}