using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Contracts;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class ProjectProgressService : IProjectProgressService
    {
        private readonly IProjectProgressRepository _projectProgressRepo;
        private readonly IQuarterService quarterService;
        private readonly IEntityBuilder _entityBuilder;
        public ProjectProgressService(IProjectProgressRepository projectProgressRepo, IEntityBuilder entityBuilder,IQuarterService quarterService)
        {
            this._projectProgressRepo = projectProgressRepo;
            this._entityBuilder = entityBuilder;
            this.quarterService = quarterService;
        }

        public bool createProjectProgress(ProjectProgressRequestModel projectProgress)
        {
            if(this._projectProgressRepo.GetByProjectNumber(projectProgress.projectNumber) == null)
            {
                Dictionary<string, string> quarters = GetQuarters(projectProgress.targetStartDate, projectProgress.targetEndDate);
                int duration =(int) (projectProgress.targetStartDate - projectProgress.targetEndDate).TotalDays;
                ProjectProgress projectProgresEntity = _entityBuilder.buildProjectProgressEntity(0, projectProgress.projectNumber, projectProgress.targetStartDate, duration, projectProgress.ActualStartDate, projectProgress.ActualEndDate, projectProgress.projectStatus, projectProgress.progressUpdatePercentage, quarters.GetValueOrDefault("StartQuarter"), quarters.GetValueOrDefault("CurrentQuarter"), quarters.GetValueOrDefault("EndQuarter"));
                return _projectProgressRepo.Insert(projectProgresEntity);
            }
            else
            {
                throw new McpCustomException("Project progress for project number '" + projectProgress.projectNumber + "' already exist");
            }
        }

        private Dictionary<string, string> GetQuarters(DateTime startDate, DateTime endDate)
        {
            List<QuarterModel> quarters = quarterService.GetAll();
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (QuarterModel q in quarters)
            {
                if(q.startDate.Date <= startDate.Date && q.endDate.Date >= startDate.Date )
                {
                    results.Add("StartQuarter", q.quarter);
                }

                if (q.startDate.Date <= DateTime.Now.Date && q.endDate.Date >= DateTime.Now.Date)
                {
                    results.Add("CurrentQuarter", q.quarter);
                }

                if (q.startDate.Date <= endDate.Date && q.endDate.Date >= endDate.Date)
                {
                    results.Add("EndQuarter", q.quarter);
                }

            }

            return results;
        }

        public bool deleteProject(string projectNumber)
        {
            ProjectProgress project = this._projectProgressRepo.GetByProjectNumber(projectNumber);
            if (project != null)
            {
                return _projectProgressRepo.Delete(project);
            }
            else
            {
                throw new McpCustomException("Project progress for project number '" + projectNumber + "' does not exist");
            }
        }

        public List<ProjectProgressResponseModel> getAllProjectProgress()
        {
            List<ProjectProgress> projectProgress = _projectProgressRepo.GetAll();
            List<ProjectProgressResponseModel> result = new List<ProjectProgressResponseModel>();

            foreach(ProjectProgress progress in projectProgress)
            {

                result.Add(new ProjectProgressResponseModel
                {
                    projectNumber = progress.project_number,
                    targetStartDate = progress.target_start_date,
                    targetEndDate = progress.target_start_date.AddDays(progress.target_duration),
                    ActualStartDate = progress.actual_start_date,
                    ActualEndDate = progress.actual_end_date,
                    projectStatus = progress.project_status,
                    progressUpdatePercentage = progress.project_status_percentage,
                    startedQuarter = progress.start_quarter,
                    currentQuarter = progress.current_quarter,
                    endingQuarter = progress.target_end_quarter,
                    projectDuration = progress.target_duration
                });
            }

            return result;
        }

        public ProjectProgressResponseModel getProjectProgressByProjectNumber(string projectNumber)
        {
            ProjectProgress progress = _projectProgressRepo.GetByProjectNumber(projectNumber);
            if (progress != null)
            {
                return new ProjectProgressResponseModel
                {
                    projectNumber = progress.project_number,
                    targetStartDate = progress.target_start_date,
                    targetEndDate = progress.target_start_date.AddDays(progress.target_duration),
                    ActualStartDate = progress.actual_start_date,
                    ActualEndDate = progress.actual_end_date,
                    projectStatus = progress.project_status,
                    progressUpdatePercentage = progress.project_status_percentage,
                    startedQuarter = progress.start_quarter,
                    currentQuarter = progress.current_quarter,
                    endingQuarter = progress.target_end_quarter,
                    projectDuration = progress.target_duration
                };
            }

            throw new McpCustomException("Record not found");
               

        }

        public List<ProjectProgressResponseModel> getProjectProgressByQuarter(string quarter)
        {
            List<ProjectProgress> projectProgress = _projectProgressRepo.GetAll();
            List<ProjectProgressResponseModel> result = new List<ProjectProgressResponseModel>();

            foreach (ProjectProgress progress in projectProgress)
            {
                if(progress.current_quarter == quarter)
                {
                    result.Add(new ProjectProgressResponseModel
                    {
                        projectNumber = progress.project_number,
                        targetStartDate = progress.target_start_date,
                        targetEndDate = progress.target_start_date.AddDays(progress.target_duration),
                        ActualStartDate = progress.actual_start_date,
                        ActualEndDate = progress.actual_end_date,
                        projectStatus = progress.project_status,
                        progressUpdatePercentage = progress.project_status_percentage,
                        startedQuarter = progress.start_quarter,
                        currentQuarter = progress.current_quarter,
                        endingQuarter = progress.target_end_quarter,
                        projectDuration = progress.target_duration
                    });
                }
               
            }

            return result;
        }

        public ProjectProgressResponseModel getProjectProgressByStatus(string status)
        {
            return null;
        }

        public bool updateProjectProgress(ProjectProgressRequestModel projectProgress)
        {
            ProjectProgress project = this._projectProgressRepo.GetByProjectNumber(projectProgress.projectNumber);
            if (project != null)
            {
                Dictionary<string, string> quarters = GetQuarters(projectProgress.ActualStartDate, projectProgress.ActualEndDate);
                int duration = (int)(projectProgress.targetStartDate - projectProgress.targetEndDate).TotalDays;
                ProjectProgress projectProgresEntity = _entityBuilder.buildProjectProgressEntity(project.id, projectProgress.projectNumber, projectProgress.targetStartDate, duration, projectProgress.ActualStartDate, projectProgress.ActualEndDate, projectProgress.projectStatus, projectProgress.progressUpdatePercentage, quarters.GetValueOrDefault("StartQuarter"), quarters.GetValueOrDefault("CurrentQuarter"), quarters.GetValueOrDefault("EndQuarter"));
                return _projectProgressRepo.Update(projectProgresEntity);
            }
            else
            {
                throw new McpCustomException("Project progress for project number '" + projectProgress.projectNumber + "' doesn't exist");
            }
        }
    }
}
