using backend.DataAccess.Database.Entities;
using backend.Models.Request;
using backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IProjectExpenditureService
    {
        bool createProjectExpediture(ProjectExpenditureRequestModel projectExpenditure);
        bool updateProjectExpenditure(ProjectExpenditureRequestModel projectExpenditure);
        List<ProjectExpenditureResponseModel> getAllProjectExpenditures();
        List<ProjectExpenditureResponseModel> getProjectExpenditureByFocusArea(string focusArea);
        List<ProjectExpenditureResponseModel> getProjectExpenditureByItem(string item);
        ProjectExpenditureResponseModel getProjectExpenditureByProjectNumber(string projectNumber);
        bool deleteProject(ProjectExpenditureRequestModel projectExpenditure);
    }
}
