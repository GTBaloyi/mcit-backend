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
        ProjectProgress GetById(int id);
        ProjectProgress GetByProjectNumber(string projectNumber);
        List<ProjectProgress> GetByProjectStatus(string projectStatus);
        List<ProjectProgress> GetByStartQuarter(string startQuarter);
        List<ProjectProgress> GetByEndQuater(string endQuarter);
        bool Update(ProjectProgress projectProgress);
        bool Delete(ProjectProgress projectProgress);
        bool Insert(ProjectProgress projectProgress);
    }
}
