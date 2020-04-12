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
using backend.Services.Commons;
using backend.Services.Builder;
using backend.DataAccess.Database.Repositories.Contracts;

namespace backend.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _userRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly ICompanyRepRepository _companyRepRepo;
        private readonly IUserStatusRepository _userStatusRepo;
        private readonly CommonServices commonServices;
        private readonly CommonMethods commonMethods;
        private readonly IEntityBuilder _entityBuilder;

        public UserService(IUsersRepository userRepo, ICompanyRepRepository companyRepRepository, IUserStatusRepository userStatusRepository, IEntityBuilder entityBuilder, ICompanyRepository companyRepository)
        {
            _userRepo = userRepo;
            _companyRepRepo = companyRepRepository;
            _userStatusRepo = userStatusRepository;
            commonServices = new CommonServices();
            commonMethods = new CommonMethods();
            _entityBuilder = entityBuilder;
            _companyRepo = companyRepository;
            
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
                            CompanyRepresentativeEntity userInfo = _companyRepRepo.GetById(result.company_rep_fk);
                            LoginResponseModel loginResponse = new LoginResponseModel(userInfo.name, userInfo.surname, userInfo.avatar_path, result.access_fk, true);
                            return loginResponse;
                        } else
                        {
                            string status = _userStatusRepo.GetUserStatus(result.user_status_fk).status;
                            throw new McpCustomException("User's account is" + status);
                        }
                    }
                    else
                    {
                        UsersModel user = new UsersModel(result.username, result.password, result.retry, result.user_status_fk, result.access_fk);
                        saveRetry(user);
                        throw new McpCustomException("Incorrect password");
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

        public ClientRegistrationResponseModel registerService(ClientRegistrationRequestModel data)
        {
            try
            {
                if (commonServices.companyExist(data.companyRegistrationNumber))
                {
                    CompanyEntity companyEntity = _entityBuilder.buildCompanyEntity(0, data.companyName, data.companyRegistrationNumber, data.companyProfile, data.isCompanyPresent, "");
                    if (_companyRepo.Insert(companyEntity))
                    {
                        int companyId = _companyRepo.GetByRegistrationNumber(data.companyRegistrationNumber).id;
                        CompanyRepresentativeEntity companyRepEntity = _entityBuilder.buildCompanyRepEntity(0, data.title, data.contactName, data.contactSurname, data.gender, data.contactEmail, data.contactNumber, companyId, DateTime.Now, data.avatar);

                        if (_companyRepRepo.Insert(companyRepEntity))
                        {
                            int companyRepId = _companyRepRepo.GetByEmail(data.contactEmail).id;
                            string otp = commonMethods.generateCode(4);
                            string defaultPassword = commonMethods.generateCode(8);
                            UsersEntity user = _entityBuilder.buildUserEntity(data.contactEmail, defaultPassword, 0, 2, 3, companyRepId, DateTime.Now, otp, null);
                            if (_userRepo.SaveUser(user))
                            {
                                //TODO: Send email
                                return new ClientRegistrationResponseModel(200, "Company, Company Representative and user details registered successfully");
                            }
                            else
                            {
                                CompanyEntity deleteCompany = _companyRepo.GetById(companyId);
                                _companyRepo.Delete(deleteCompany);

                                CompanyRepresentativeEntity deleteCompanyRep = _companyRepRepo.GetById(companyId);
                                _companyRepRepo.Delete(deleteCompanyRep);

                                throw new McpCustomException("Could not save new user");
                            }
                        }
                        else
                        {
                            CompanyEntity deleteCompany = _companyRepo.GetById(companyId);
                            _companyRepo.Delete(deleteCompany);

                            throw new McpCustomException("Could not save company representative");
                        }
                        // _companyRepo.GetCompany()
                    }
                    else
                    {
                        throw new McpCustomException("Company not saved");
                    }


                }
                else
                {
                    throw new McpCustomException("Company does not exist");
                }
            }
            catch(McpCustomException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw e;
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
                data.user_status_fk = (int)user.userStatus + 1;
            }

            data.access_fk = (int)user.access;
            _userRepo.UpdateUser(data);
            _userRepo.Save();
        }
    }
}
