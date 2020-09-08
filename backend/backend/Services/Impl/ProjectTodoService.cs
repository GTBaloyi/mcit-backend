using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Contracts;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class ProjectTodoService : IProjectTodoService
    {
        private readonly IProjectTodoRepository _todoRepository;
        private readonly IEntityBuilder _entityBuilder;

        public ProjectTodoService(IProjectTodoRepository todoRepository, IEntityBuilder entityBuilder)
        {
            _entityBuilder = entityBuilder;
            _todoRepository = todoRepository;
        }

        public bool createProjectTodo(ProjectTodosRequestModel projectTODO)
        {
            ProjectTODO todo = _entityBuilder.buildProjectTODOEntity(0, projectTODO.projectNumber, projectTODO.sequenceNumber, projectTODO.isSequential, projectTODO.focusArea, projectTODO.item, projectTODO.status,projectTODO.dateStarted, projectTODO.dateEnded);
            return _todoRepository.Insert(todo);
        }

        public bool deleteProject(ProjectTodosRequestModel projectTODO)
        {
            ProjectTODO todo = _entityBuilder.buildProjectTODOEntity(projectTODO.id, projectTODO.projectNumber, projectTODO.sequenceNumber, projectTODO.isSequential, projectTODO.focusArea, projectTODO.item, projectTODO.status, projectTODO.dateStarted, projectTODO.dateEnded);
            if(_todoRepository.GetById(todo.id) != null)
            {
                return _todoRepository.Delete(todo);
            }

            throw new McpCustomException("There is no project todo associated with the ID: " + todo.id);
        }

        public List<ProjectTodoResponseModel> getAllProjectTodos()
        {
            List<ProjectTODO> todos = _todoRepository.GetAll();
            List<ProjectTodoResponseModel> results = new List<ProjectTodoResponseModel>();

            foreach(ProjectTODO todo in todos)
            {
                results.Add(new ProjectTodoResponseModel
                {
                    id = todo.id,
                    projectNumber = todo.project_number,
                    sequenceNumber = todo.sequence,
                    isSequential = todo.isSequential,
                    focusArea = todo.focus_area,
                    item = todo.item,
                    dateStarted = todo.date_started,
                    dateEnded = todo.date_ended
                });
            }

            return results;
        }

        public List<ProjectTodoResponseModel> getProjectTodoByDateRange(DateTime startDate, DateTime endDate)
        {
            List<ProjectTODO> todos = _todoRepository.GetAll();
            List<ProjectTodoResponseModel> results = new List<ProjectTodoResponseModel>();

            foreach (ProjectTODO todo in todos)
            {
                if(todo.date_started >= startDate && todo.date_ended <= endDate)
                {
                    results.Add(new ProjectTodoResponseModel
                    {
                        id = todo.id,
                        projectNumber = todo.project_number,
                        sequenceNumber = todo.sequence,
                        isSequential = todo.isSequential,
                        focusArea = todo.focus_area,
                        item = todo.item,
                        dateStarted = todo.date_started,
                        dateEnded = todo.date_ended
                    });
                }
                
            }

            return results;
        }

        public List<ProjectTodoResponseModel> getProjectTodoByFocusArea(string focusArea)
        {
            List<ProjectTODO> todos = _todoRepository.GetByFocusArea(focusArea);
            List<ProjectTodoResponseModel> results = new List<ProjectTodoResponseModel>();

            foreach (ProjectTODO todo in todos)
            {
                    results.Add(new ProjectTodoResponseModel
                    {
                        id = todo.id,
                        projectNumber = todo.project_number,
                        sequenceNumber = todo.sequence,
                        isSequential = todo.isSequential,
                        focusArea = todo.focus_area,
                        item = todo.item,
                        dateStarted = todo.date_started,
                        dateEnded = todo.date_ended
                    });
            }

            return results;
        }

        public List<ProjectTodoResponseModel> getProjectTodoByItem(string item)
        {
            List<ProjectTODO> todos = _todoRepository.GetByItem(item);
            List<ProjectTodoResponseModel> results = new List<ProjectTodoResponseModel>();

            foreach (ProjectTODO todo in todos)
            {
                results.Add(new ProjectTodoResponseModel
                {
                    id = todo.id,
                    projectNumber = todo.project_number,
                    sequenceNumber = todo.sequence,
                    isSequential = todo.isSequential,
                    focusArea = todo.focus_area,
                    item = todo.item,
                    dateStarted = todo.date_started,
                    dateEnded = todo.date_ended
                });
            }

            return results;
        }

        public List<ProjectTodoResponseModel> getProjectTodoByProjectNumber(string projectNumber)
        {
            List<ProjectTODO> todos = _todoRepository.GetByProjectNumber(projectNumber);
            List<ProjectTodoResponseModel> results = new List<ProjectTodoResponseModel>();

            foreach (ProjectTODO todo in todos)
            {
                results.Add(new ProjectTodoResponseModel
                {
                    id = todo.id,
                    projectNumber = todo.project_number,
                    sequenceNumber = todo.sequence,
                    isSequential = todo.isSequential,
                    focusArea = todo.focus_area,
                    item = todo.item,
                    dateStarted = todo.date_started,
                    dateEnded = todo.date_ended
                });
            }

            return results;
        }

        public bool updateProjectTodo(ProjectTodosRequestModel projectTODO)
        {
            
            if(_todoRepository.GetById(projectTODO.id) != null)
            {
                ProjectTODO todo = _entityBuilder.buildProjectTODOEntity(projectTODO.id, projectTODO.projectNumber, projectTODO.sequenceNumber, projectTODO.isSequential, projectTODO.focusArea, projectTODO.item, projectTODO.status, projectTODO.dateStarted, projectTODO.dateEnded);
                return _todoRepository.Update(todo);
            }

            throw new McpCustomException("Project Todo with id " + projectTODO.id + " does not exist");
        }
    }
}
