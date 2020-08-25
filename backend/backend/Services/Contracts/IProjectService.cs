using backend.Models.Request;
using backend.Models.Response;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IProjectService
    {
        bool createProject(ProjectInformationRequestModel project);
        bool updateProject(ProjectInformationRequestModel project);
        List<ProjectInformationResponseModel> getAllProjects();
        List<ProjectInformationResponseModel> getProjects(string companyRegistrationNumber);
        List<ProjectInformationResponseModel> getProjectsByAssignedEmployees(string employeeIDs);
        ProjectInformationResponseModel getProjectByInvoice(string invoiceId);
        ProjectInformationResponseModel getProjectByProjectNumber(string projectNumber);
        bool deleteProject(string projectNumber);
    }
}
