using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class UserService : IUsersService
    {
        
        public UserService()
        {

        }
        public UsersModel loginService(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UsersModel RegisterClient(ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}
