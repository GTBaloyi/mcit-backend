using backend.DataAccess;
using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using backend.DataAccess.Repositories;
using backend.Exceptions;
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
        private readonly ICompanyRepRepository _companyRepRepo;
        private readonly IUserStatusRepository _userStatusRepo;
        public UserService(IUsersRepository userRepo, ICompanyRepRepository companyRepRepository, IUserStatusRepository userStatusRepository)
        {
            _userRepo = userRepo;
            _companyRepRepo = companyRepRepository;
            _userStatusRepo = userStatusRepository;

        }

        public LoginResponseModel loginService(string username, string password)
        {
            try
            {
                var result = _userRepo.GetUser(username);
                if(result !=null)
                {
                    if (result.password == password)
                    {
                        if(result.user_status_fk == 1)
                        {
                            CompanyRepresentativeEntity userInfo = _companyRepRepo.GetBusinessRepresentative(result.company_rep_fk);
                            LoginResponseModel loginResponse = new LoginResponseModel(userInfo.name, userInfo.surname, userInfo.avatar_path, result.access_fk, true);
                            return loginResponse;
                        } else
                        {
                            Dictionary<string, string> error = new Dictionary<string, string>();
                            error.Add("user_access", ""+result.user_status_fk);
                            throw new LoginException("User's account is" + findUserStatus(result.user_status_fk));
                        }
                    }
                    else
                    {
                        UsersModel user = new UsersModel(result.username, result.password, result.retry, result.user_status_fk, result.access_fk);
                        saveRetry(user);
                        throw new LoginException("Incorrect password");
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

        private string findUserStatus(int user_status_fk)
        {
            return _userStatusRepo.GetUserStatus(user_status_fk).status;
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
                data.user_status_fk = (int)user.userStatus + 1;
            }

            data.access_fk = (int)user.access;
            _userRepo.UpdateUser(data);
            _userRepo.Save();
        }
    }
}
