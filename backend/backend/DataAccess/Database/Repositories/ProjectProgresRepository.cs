using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public class ProjectProgresRepository : IProjectProgressRepository
    {

        public ProjectProgresRepository()
        {

        }

        public bool Delete(ProjectProgress businessRepresentative)
        {
            throw new NotImplementedException();
        }

        public List<ProjectProgress> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProjectProgress> GetByEndQuater(string endQuarter)
        {
            throw new NotImplementedException();
        }

        public ProjectEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectEntity GetByProjectNumber(string projectNumber)
        {
            throw new NotImplementedException();
        }

        public List<ProjectProgress> GetByProjectStatus(string projectStatus)
        {
            throw new NotImplementedException();
        }

        public List<ProjectProgress> GetByStartQuarter(string startQuarter)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProjectProgress businessRepresentative)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProjectProgress businessRepresentative)
        {
            throw new NotImplementedException();
        }
    }
}
