using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IProjectProgressRepository
    {
        List<ProjectProgress> GetAll();
        ProjectEntity GetById(int id);
        ProjectEntity GetByProjectNumber(string projectNumber);
        List<ProjectProgress> GetByProjectStatus(string projectStatus);
        List<ProjectProgress> GetByStartQuarter(string startQuarter);
        List<ProjectProgress> GetByEndQuater(string endQuarter);
        bool Update(ProjectProgress businessRepresentative);
        bool Delete(ProjectProgress businessRepresentative);
        bool Insert(ProjectProgress businessRepresentative);
    }
}
