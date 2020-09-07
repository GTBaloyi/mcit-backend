using backend.Models.Request;
using backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IProjectProgressService
    {
        bool createProjectProgress(ProjectProgressRequestModel propjectProgress);
        bool updateProjectProgress(ProjectProgressRequestModel projectProgres);
        List<ProjectProgressResponseModel> getAllProjectProgress();
        List<ProjectProgressResponseModel> getProjectProgressByQuarter(string quarter);
        ProjectProgressResponseModel getProjectProgressByStatus(string status);
        ProjectProgressResponseModel getProjectProgressByProjectNumber(string projectNumber);
        bool deleteProject(string projectNumber);
    }
}
