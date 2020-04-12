using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Contracts
{
    public interface IUsersRepository 
    {
        UsersEntity GetUser(string username);
        List<UsersEntity> GetUsers();
        bool SaveUser(UsersEntity user);
        bool DeleteUser(UsersEntity user);
        bool UpdateUser(UsersEntity user);
        void Save();
    }
}
