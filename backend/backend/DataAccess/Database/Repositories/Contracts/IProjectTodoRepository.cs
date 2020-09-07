using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IProjectTodoRepository
    {
        List<ProjectTODO> GetAll();
        ProjectTODO GetById(int id);
        List<ProjectTODO> GetByProjectNumber(string projectNumber);
        List<ProjectTODO> GetByFocusArea(string focusArea);
        List<ProjectTODO> GetByItem(string item);
        bool Update(ProjectTODO projectTODO);
        bool Delete(ProjectTODO projectTODO);
        bool Insert(ProjectTODO projectTODO);
    }
}
