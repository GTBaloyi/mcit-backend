using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    interface IUsersService
    {
        UsersModel loginService(String username, string password);
        UsersModel RegisterClient(ClientModel client);
    }
}
