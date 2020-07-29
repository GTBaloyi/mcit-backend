using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IEmployeesRepository
    {
         List<EmployeesEntity> GetAll();
         EmployeesEntity GetByEmployeeNumber(string employeeNumber);
         bool Save(EmployeesEntity employee);
         bool Update(EmployeesEntity employee);
         bool Delete(EmployeesEntity employee);
    }
}
