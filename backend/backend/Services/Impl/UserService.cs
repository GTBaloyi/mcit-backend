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
using backend.Services.Contracts;
using backend.DataAccess.Database.Entities;

namespace backend.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _userRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly ICompanyRepRepository _companyRepRepo;
        private readonly IUserStatusRepository _userStatusRepo;
        private readonly IEmployeesRepository _employeeRepo;
        private readonly CommonServices commonServices;
        private readonly CommonMethods commonMethods;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IEmailTemplateRepository _emailTemplate;

        public UserService(IUsersRepository userRepo, ICompanyRepRepository companyRepRepository, IUserStatusRepository userStatusRepository, IEntityBuilder entityBuilder, ICompanyRepository companyRepository, IEmailTemplateRepository emailTemplateRepository, IEmployeesRepository employeeRepo)
        {
            _userRepo = userRepo;
            _companyRepRepo = companyRepRepository;
            _userStatusRepo = userStatusRepository;
            commonServices = new CommonServices();
            commonMethods = new CommonMethods();
            _entityBuilder = entityBuilder;
            _companyRepo = companyRepository;
            _emailTemplate = emailTemplateRepository;
            _employeeRepo = employeeRepo;
        }

        public bool forgotPassword(string companyRegistration, string emailAddress, string phone)
        {
            CompanyRepresentativeEntity companyRep = _companyRepRepo.GetByEmail(emailAddress);
            CompanyEntity company = _companyRepo.GetByRegistrationNumber(companyRegistration);
            if (companyRep != null && company !=null && companyRep.phone == phone)
            {   
                string name = _companyRepRepo.GetByEmail(emailAddress).name;   
                string  password = commonMethods.generateCode(8);
                UsersEntity user = _userRepo.GetUser(emailAddress);
                user.password =commonMethods.passwordEncyption(password);
                user.user_status_fk = 2;
                _userRepo.UpdateUser(user);
                string template = _emailTemplate.GetByType("ForgotPassword").code;
                string mail = BuildEmail(template,name,password);
                commonServices.SendEmail("Password Reset Successful", mail, emailAddress);
                return true;
            }
            else
            {
                throw new McpCustomException("verification failed");
            }
        }

        private string BuildEmail(string template, string name, string password)
        {
            string result = @template.Replace("{first_name}", name);
            return result.Replace("{pwd}", password);
        }

        

        public LoginResponseModel loginService(string username, string password)
        {
            try
            {
                var result = _userRepo.GetUser(username);
                if(result !=null)
                {
                    if (password == commonMethods.passwordDecryption(result.password))
                    {
                        if(result.access_fk != 1)
                        {
                            EmployeesEntity employeesEntity = _employeeRepo.GetByEmployeeNumber(username);
                            return new LoginResponseModel(employeesEntity.name, employeesEntity.surname, "", result.access_fk, true, result.user_status_fk);
                        }

                        CompanyRepresentativeEntity userInfo = _companyRepRepo.GetById(result.company_rep_fk);
                        LoginResponseModel loginResponse = new LoginResponseModel(userInfo.name, userInfo.surname, userInfo.avatar_path, result.access_fk, true, result.user_status_fk);
                        return loginResponse;
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
                if (commonServices.companyExist(data.companyRegistrationNumber) && _companyRepRepo.GetByEmail(data.contactEmail) == null && _companyRepo.GetByRegistrationNumber(data.companyRegistrationNumber) == null && _userRepo.GetUser(data.contactEmail) == null)
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
                            string defaultPassword =commonMethods.passwordEncyption(commonMethods.generateCode(8));
                            UsersEntity user = _entityBuilder.buildUserEntity(data.contactEmail, defaultPassword, 0,2, 1, companyRepId, DateTime.Now, otp, null);
                            if (_userRepo.SaveUser(user))
                            {
                                //TODO: Send email
                                string template = _emailTemplate.GetByType("Registration").code;
                                string mail = BuildRegistrationEmail(template, data.contactName, user.username, commonMethods.passwordDecryption(user.password));
                                commonServices.SendEmail("MCIT Registration successful", mail, user.username);
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
                    throw new McpCustomException("Company registration / Email already exist in the system");
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

        private string BuildRegistrationEmail(string template, string name, string username, string password)
        {
            string result = @template.Replace("{first_name}", name);
            result = result.Replace("{usr}", username);
            result = result.Replace("{pwd}", password);
            return result;
        }
        public bool resetPassword(string username, string oldPassword, string newPassword, int status)
        {
            
            UsersEntity user = _userRepo.GetUser(username);
            if(user != null)
            {

                if(commonMethods.passwordDecryption(user.password) == oldPassword) 
                { 
                
                    user.password = commonMethods.passwordEncyption(newPassword);
                    if(status == 2)
                    {
                        user.user_status_fk = 1;
                    }
                    if (status == 1)
                    {
                        user.user_status_fk = status;
                    }
                    _userRepo.UpdateUser(user);
                    try
                    {
                        string name = _companyRepRepo.GetByEmail(user.username).name;
                        string template = _emailTemplate.GetByType("ResetPassword").code;
                        string mail = BuildResetPasswordEmail(template, name, newPassword);
                        commonServices.SendEmail("Password Reset Successfully", mail, user.username);
                    }
                    catch(Exception)
                    {

                    }
                    return true;

                } else
                {
                    throw new McpCustomException("Incorrect Password");
                }
            } else
            {
                throw new McpCustomException("username not found");
            }
            
        }

        private string BuildResetPasswordEmail(string template, string name, string password)
        {
            string result = @template.Replace("{first_name}", name);
            result = result.Replace("{pwd}", password);
            return result;
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
