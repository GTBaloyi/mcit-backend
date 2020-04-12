using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Contracts
{
    public interface ICompanyRepRepository
    {
        List<CompanyRepresentativeEntity> GetList();
        CompanyRepresentativeEntity GetById(int id);
        CompanyRepresentativeEntity GetByEmail(string email);
        bool Update(CompanyRepresentativeEntity businessRepresentative);
        bool Delete(CompanyRepresentativeEntity businessRepresentative);
        bool Insert(CompanyRepresentativeEntity businessRepresentative);
    }
}
