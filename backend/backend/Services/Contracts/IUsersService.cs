using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IUsersService
    {
        UsersModel loginService(String username, string password);
    }
}
