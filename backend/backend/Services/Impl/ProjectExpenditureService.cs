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
    public class ProjectExpenditureService : IProjectExpenditureService
    {
        private readonly IProjectExpenditureRepository _projectExpenditureRepo;
        private readonly IEntityBuilder _entityBuilder;

        public ProjectExpenditureService(IProjectExpenditureRepository projectExpenditureRepo, IEntityBuilder entityBuilder)
        {
            _projectExpenditureRepo = projectExpenditureRepo;
            _entityBuilder = entityBuilder;
        }

        public bool createProjectExpediture(ProjectExpenditureRequestModel projectExpenditure)
        {
            ProjectExpenditure projectExpenditureEntity = _entityBuilder.buildProjectExpenditureEntity(0, projectExpenditure.projectNumber, projectExpenditure.focusArea, projectExpenditure.item, projectExpenditure.actualCost, projectExpenditure.targetCost);
            return _projectExpenditureRepo.Insert(projectExpenditureEntity);
        }

        public bool deleteProject(ProjectExpenditureRequestModel projectExpenditure)
        {
            if(_projectExpenditureRepo.GetById(projectExpenditure.id) != null)
            {
                ProjectExpenditure projectExpenditureEntity = _entityBuilder.buildProjectExpenditureEntity(0, projectExpenditure.projectNumber, projectExpenditure.focusArea, projectExpenditure.item, projectExpenditure.actualCost, projectExpenditure.targetCost);
                return _projectExpenditureRepo.Delete(projectExpenditureEntity);
            }
            else
            {
                throw new McpCustomException("Project Expenditure with ID " + projectExpenditure.id + "doesn't exist");
            }
        }

        public List<ProjectExpenditureResponseModel> getAllProjectExpenditures()
        {
            List<ProjectExpenditure> projectExpenditureEntity = _projectExpenditureRepo.GetAll();
            List<ProjectExpenditureResponseModel> results = new List<ProjectExpenditureResponseModel>();

            foreach(ProjectExpenditure expense in projectExpenditureEntity)
            {
                results.Add(new ProjectExpenditureResponseModel
                {
                    id = expense.id,
                    projectNumber = expense.project_number,
                    focusArea = expense.focus_area,
                    item = expense.item,
                    actualCost = expense.actual_cost,
                    targetCost = expense.target_cost

                });
            }

            return results;
        }

        public List<ProjectExpenditureResponseModel> getProjectExpenditureByFocusArea(string focusArea)
        {
            List<ProjectExpenditure> projectExpenditureEntity = _projectExpenditureRepo.GetByFocusArea(focusArea);
            List<ProjectExpenditureResponseModel> results = new List<ProjectExpenditureResponseModel>();

            foreach (ProjectExpenditure expense in projectExpenditureEntity)
            {
                results.Add(new ProjectExpenditureResponseModel
                {
                    id = expense.id,
                    projectNumber = expense.project_number,
                    focusArea = expense.focus_area,
                    item = expense.item,
                    actualCost = expense.actual_cost,
                    targetCost = expense.target_cost

                });
            }

            return results;
        }

        public List<ProjectExpenditureResponseModel> getProjectExpenditureByItem(string item)
        {
            List<ProjectExpenditure> projectExpenditureEntity = _projectExpenditureRepo.GetByItem(item);
            List<ProjectExpenditureResponseModel> results = new List<ProjectExpenditureResponseModel>();

            foreach (ProjectExpenditure expense in projectExpenditureEntity)
            {
                results.Add(new ProjectExpenditureResponseModel
                {
                    id = expense.id,
                    projectNumber = expense.project_number,
                    focusArea = expense.focus_area,
                    item = expense.item,
                    actualCost = expense.actual_cost,
                    targetCost = expense.target_cost

                });
            }

            return results;
        }

        public ProjectExpenditureResponseModel getProjectExpenditureByProjectNumber(string projectNumber)
        {
            ProjectExpenditure projectExpenditureEntity = _projectExpenditureRepo.GetByProjectNumber(projectNumber);
            if (projectExpenditureEntity != null)
            {
                return new ProjectExpenditureResponseModel
                {
                    id = projectExpenditureEntity.id,
                    projectNumber = projectExpenditureEntity.project_number,
                    focusArea = projectExpenditureEntity.focus_area,
                    item = projectExpenditureEntity.item,
                    actualCost = projectExpenditureEntity.actual_cost,
                    targetCost = projectExpenditureEntity.target_cost

                };
            }

            throw new McpCustomException("There is no project expenditure associated with project " + projectNumber);
        }

        public bool updateProjectExpenditure(ProjectExpenditureRequestModel projectExpenditure)
        {
            if (_projectExpenditureRepo.GetById(projectExpenditure.id) != null)
            {
                ProjectExpenditure projectExpenditureEntity = _entityBuilder.buildProjectExpenditureEntity(0, projectExpenditure.projectNumber, projectExpenditure.focusArea, projectExpenditure.item, projectExpenditure.actualCost, projectExpenditure.targetCost);
                return _projectExpenditureRepo.Update(projectExpenditureEntity);
            }

            throw new McpCustomException("There is no project expenditure associated with id " + projectExpenditure.id);
        }
    }
}
