using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IEmployeesPositionRepository
    {
        List<EmployeesPositionEntity> GetAll();
        EmployeesPositionEntity GetByEmployeePositionById(int id);
        EmployeesPositionEntity GetByEmployeePositionByName(string name);
        bool Save(EmployeesPositionEntity employeesPosition);
        bool Update(EmployeesPositionEntity employeesPosition);
        bool Delete(EmployeesPositionEntity employeesPosition);
    }
}
