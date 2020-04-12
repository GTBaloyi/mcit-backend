using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface ICompanyRepository
    {
        List<CompanyEntity> GetList();
        CompanyEntity GetByRegistrationNumber(string registration);
        CompanyEntity GetById(int id);
        bool Update(CompanyEntity company);
        bool Delete(CompanyEntity company);
        bool Insert(CompanyEntity company);
    }
}
