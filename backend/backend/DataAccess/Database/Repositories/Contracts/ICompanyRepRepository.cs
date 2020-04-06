using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Contracts
{
    public interface ICompanyRepRepository
    {
        List<CompanyRepresentativeEntity> GetBusinessRepresentatives();
        CompanyRepresentativeEntity GetBusinessRepresentative(int id);
        bool UpdateBusinessRepresentative(CompanyRepresentativeEntity businessRepresentative);
        bool DeleteBusinessRepresentative(CompanyRepresentativeEntity businessRepresentative);
        bool CreateBusinessRepresentative(CompanyRepresentativeEntity businessRepresentative);
    }
}
