using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Contracts
{
    public interface IAccessLevelRepository
    {
        List<AccessLevelEntity> GetAccessLevels();
        AccessLevelEntity GetAccessLevel(int id);
        bool UpdateAccessLevel(AccessLevelEntity accessLevel);
        bool CreateAccessLevel(AccessLevelEntity accessLevel);
        bool DeleteAccessLevel(AccessLevelEntity accessLevel);
        void Save();
    
    }
}
