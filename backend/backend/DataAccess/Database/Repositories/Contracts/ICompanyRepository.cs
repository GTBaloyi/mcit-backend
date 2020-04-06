using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface ICompanyRepository
    {
        List<CompanyEntity> GetCompanies();
        CompanyEntity GetCompany(int id);
        bool UpdateCompany(CompanyEntity company);
        bool DeleteCompany(CompanyEntity company);
        bool CreateCompany(CompanyEntity company);
    }
}
