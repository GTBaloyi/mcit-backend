using backend.DataAccess;
using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using backend.DataAccess.Repositories;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _userRepo;
        
        public UserService(IUsersRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public UsersModel loginService(string username, string password)
        {
            try
            {
                var result = _userRepo.GetUser(username);
                if(result !=null)
                {
                    UsersModel user = new UsersModel(result.username, null, result.retry, result.user_status_fk, result.access_fk);
                    if (result.password == password)
                    {
                        return user;
                    }
                    else
                    {
                        saveRetry(user);
                        return null;
                    }
                } else
                {
                    return null;
                }
                
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void saveRetry(UsersModel user)
        {

            UsersEntity data = new UsersEntity();
            data.retry = (int)user.retry + 1;
            data.username = user.username;
            data.password = user.password;
            if(data.retry >=3 && user.userStatus ==1)
            {
                data.user_status_fk = 2;
            }
            else
            {
                data.user_status_fk = (int)user.userStatus;
            }

            data.access_fk = (int)user.access;
            _userRepo.UpdateUser(data);
            _userRepo.Save();
        }
    }
}
