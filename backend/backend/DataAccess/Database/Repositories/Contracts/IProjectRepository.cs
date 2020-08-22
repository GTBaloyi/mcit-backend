using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IProjectRepository
    {
        List<ProjectEntity> GetAll();
        ProjectEntity GetById(int id);
        ProjectEntity GetByProjectNumber(string projectNumber);
        ProjectEntity GetByInvoice(string invoiceReference);
        List<ProjectEntity> GetByCompanyRegistration(string companyRegistration);
        bool Update(ProjectEntity project);
        bool Delete(ProjectEntity project);
        bool Insert(ProjectEntity project);
    }
}
