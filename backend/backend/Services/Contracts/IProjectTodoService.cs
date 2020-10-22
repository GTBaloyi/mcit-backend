using backend.DataAccess.Database.Entities;
using backend.Models.Request;
using backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IProjectTodoService
    {
        bool createProjectTodo(ProjectTodosRequestModel projectTODO);
        bool updateProjectTodo(ProjectTodosRequestModel projectTODO);
        List<ProjectTodoResponseModel> getAllProjectTodos();
        List<ProjectTodoResponseModel> getProjectTodoByFocusArea(string focusArea);
        List<ProjectTodoResponseModel> getProjectTodoByEmployee(string employee);
        List<ProjectTodoResponseModel> getProjectTodoByEmployeeProject(string employee, string projectNumber);
        List<ProjectTodoResponseModel> getProjectTodoByItem(string item);
        List<ProjectTodoResponseModel> getProjectTodoByDateRange(DateTime startDate, DateTime endDate);
        List<ProjectTodoResponseModel> getProjectTodoByProjectNumber(string projectNumber);
        bool deleteProject(int projectNumber);
    }
}
