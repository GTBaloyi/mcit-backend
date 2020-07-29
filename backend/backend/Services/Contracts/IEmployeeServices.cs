using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IEmployeeServices
    {
        List<EmployeeResponseModel> getAllEmployees();
        bool createEmployee(EmployeeRequestModel employee);
        EmployeeResponseModel getEmployeeByEmployeeNumber(string employeeNumber);
        bool updateEmployee(EmployeeResponseModel employee);
        bool deleteEmployee(string employeeNumber);
        List<EmployeesPositionEntity> GetEmployeesPosition();

    }
}
