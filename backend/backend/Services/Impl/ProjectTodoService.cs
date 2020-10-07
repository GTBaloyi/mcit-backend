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
        private readonly IEmployeesRepository _employeesRepository;

        public ProjectTodoService(IProjectTodoRepository todoRepository, IEntityBuilder entityBuilder, IEmployeesRepository employeesRepository)
        {
            _entityBuilder = entityBuilder;
            _todoRepository = todoRepository;
            _employeesRepository = employeesRepository;
        }

        public bool createProjectTodo(ProjectTodosRequestModel projectTODO)
        {
            string employeesResponsible = string.Join(",", projectTODO.responsibleEmployees);
            ProjectTODO todo = _entityBuilder.buildProjectTODOEntity(0, projectTODO.projectNumber, projectTODO.sequenceNumber, projectTODO.isSequential, projectTODO.focusArea, projectTODO.item, projectTODO.status,projectTODO.dateStarted, projectTODO.dateEnded, employeesResponsible);
            return _todoRepository.Insert(todo);
        }

        public bool deleteProject(ProjectTodosRequestModel projectTODO)
        {
            string employeesResponsible = string.Join(",", projectTODO.responsibleEmployees);
            ProjectTODO todo = _entityBuilder.buildProjectTODOEntity(projectTODO.id, projectTODO.projectNumber, projectTODO.sequenceNumber, projectTODO.isSequential, projectTODO.focusArea, projectTODO.item, projectTODO.status, projectTODO.dateStarted, projectTODO.dateEnded, employeesResponsible);
            if(_todoRepository.GetById(todo.id) != null)
            {
                return _todoRepository.Delete(todo);
            }

            throw new McpCustomException("There is no project todo associated with the ID: " + todo.id);
        }

        private List<ResponsibleEmployees> GetResponsibleEmployees(string[] employeesId)
        {
            
            List<ResponsibleEmployees> responsibleEmployees = new List<ResponsibleEmployees>();
            foreach (string emp in employeesId)
            {
                
                    EmployeesEntity e = _employeesRepository.GetByEmployeeNumber(emp);
                    if (e != null )
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

        public List<ProjectTodoResponseModel> getAllProjectTodos()
        {
            List<ProjectTODO> todos = _todoRepository.GetAll();
            List<ProjectTodoResponseModel> results = new List<ProjectTodoResponseModel>();

            foreach(ProjectTODO todo in todos)
            {
                string[] employeees = todo.responsible_employees.Split(',');
                results.Add(new ProjectTodoResponseModel
                {
                    id = todo.id,
                    projectNumber = todo.project_number,
                    sequenceNumber = todo.sequence,
                    isSequential = todo.isSequential,
                    focusArea = todo.focus_area,
                    item = todo.item,
                    status= todo.status,
                    dateStarted = todo.date_started,
                    dateEnded = todo.date_ended,
                    responsibleEmployees = GetResponsibleEmployees(employeees)
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
                    string[] employeees = todo.responsible_employees.Split(',');

                    results.Add(new ProjectTodoResponseModel
                    {
                        id = todo.id,
                        projectNumber = todo.project_number,
                        sequenceNumber = todo.sequence,
                        isSequential = todo.isSequential,
                        focusArea = todo.focus_area,
                        item = todo.item,
                        status = todo.status,
                        dateStarted = todo.date_started,
                        dateEnded = todo.date_ended,
                        responsibleEmployees = GetResponsibleEmployees(employeees)
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
                string[] employeees = todo.responsible_employees.Split(',');
                results.Add(new ProjectTodoResponseModel
                    {
                        id = todo.id,
                        projectNumber = todo.project_number,
                        sequenceNumber = todo.sequence,
                        isSequential = todo.isSequential,
                        focusArea = todo.focus_area,
                        item = todo.item,
                        status = todo.status,
                        dateStarted = todo.date_started,
                        dateEnded = todo.date_ended,
                        responsibleEmployees = GetResponsibleEmployees(employeees)
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
                string[] employeees = todo.responsible_employees.Split(',');
                results.Add(new ProjectTodoResponseModel
                {
                    id = todo.id,
                    projectNumber = todo.project_number,
                    sequenceNumber = todo.sequence,
                    isSequential = todo.isSequential,
                    focusArea = todo.focus_area,
                    item = todo.item,
                    status = todo.status,
                    dateStarted = todo.date_started,
                    dateEnded = todo.date_ended,
                    responsibleEmployees = GetResponsibleEmployees(employeees)
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
                string[] employeees = todo.responsible_employees.Split(',');
                results.Add(new ProjectTodoResponseModel
                {
                    id = todo.id,
                    projectNumber = todo.project_number,
                    sequenceNumber = todo.sequence,
                    isSequential = todo.isSequential,
                    focusArea = todo.focus_area,
                    item = todo.item,
                    status = todo.status,
                    dateStarted = todo.date_started,
                    dateEnded = todo.date_ended,
                    responsibleEmployees = GetResponsibleEmployees(employeees)
                });
            }

            return results;
        }

        public bool updateProjectTodo(ProjectTodosRequestModel projectTODO)
        {
            string employeesResponsible = string.Join(",", projectTODO.responsibleEmployees);
            if (_todoRepository.GetById(projectTODO.id) != null)
            {
                ProjectTODO todo = _entityBuilder.buildProjectTODOEntity(projectTODO.id, projectTODO.projectNumber, projectTODO.sequenceNumber, projectTODO.isSequential, projectTODO.focusArea, projectTODO.item, projectTODO.status, projectTODO.dateStarted, projectTODO.dateEnded, employeesResponsible);
                return _todoRepository.Update(todo);
            }

            throw new McpCustomException("Project Todo with id " + projectTODO.id + " does not exist");
        }
    }
}
