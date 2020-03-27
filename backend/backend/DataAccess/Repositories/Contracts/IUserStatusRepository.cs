using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Contracts
{
    public interface IUserStatusRepository 
    {
        UserStatusEntity GetUserStatus(int id);
        List<UserStatusEntity> GetUserStatuses();
        bool CreateUserStatus(UserStatusEntity user);
        bool UpdateUserStatus(UserStatusEntity user);
        bool DeleteUserStatus(UserStatusEntity user);
        void Save();
    }
}
