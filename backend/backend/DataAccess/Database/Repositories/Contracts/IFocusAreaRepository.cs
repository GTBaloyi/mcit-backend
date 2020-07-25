using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IFocusAreaRepository
    {
        FocusAreaEntity GetById(int id);
        FocusAreaEntity GetByName(string focusAreaName);
        List<FocusAreaEntity> GetAll();
        bool Save(FocusAreaEntity focusArea);
        bool Delete(int id);
        bool Update(FocusAreaEntity focusArea);
        void SaveChanges();
    }
}
