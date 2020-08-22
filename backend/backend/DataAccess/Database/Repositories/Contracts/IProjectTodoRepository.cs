using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    interface IProjectTodoRepository
    {
        List<ProjectTODO> GetAll();
        ProjectTODO GetById(int id);
        ProjectTODO GetByProjectNumber(string projectNumber);
        List<ProjectTODO> GetByProjectStatus(string focusArea);
        List<ProjectTODO> GetByStartQuarter(string item);
        bool Update(ProjectTODO projectTODO);
        bool Delete(ProjectTODO projectTODO);
        bool Insert(ProjectTODO projectTODO);
    }
}
