using backend.DataAccess.Contracts;
using backend.DataAccess.Database.Repositories;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.Exceptions;
using backend.Models;
using backend.Services.Builder;
using backend.Services.Commons;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class ClientService : IClientServices
    {
        private readonly ICompanyRepRepository _companyRepRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly IUsersRepository _userRepo;
        private readonly IEntityBuilder _entityBuilder;

        public ClientService(ICompanyRepository companyRepository, ICompanyRepRepository companyRepRepository, IUsersRepository userRepo, IEntityBuilder entityBuilder)
        {
            _companyRepo = companyRepository;
            _companyRepRepo = companyRepRepository;
            _userRepo = userRepo;
            _entityBuilder = entityBuilder;
        }

        public bool DeleteClient(string companyRegistrationNumber)
        {
            try
            {
                CompanyEntity company = _companyRepo.GetByRegistrationNumber(companyRegistrationNumber);
                CompanyRepresentativeEntity rep = _companyRepRepo.GetByCompany(company.id);

                _userRepo.DeleteUser(_userRepo.GetUser(rep.email));
                _companyRepRepo.Delete(rep);
                _companyRepo.Delete(company);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<ClientRegistrationRequestModel> GetAllClients()
        {
            try
            {
                List<ClientRegistrationRequestModel> result = new List<ClientRegistrationRequestModel>();
                List<CompanyEntity> company = _companyRepo.GetList();
                List<UsersEntity> users = _userRepo.GetUsers();
                foreach(CompanyEntity comp in company)
                {
                    CompanyRepresentativeEntity companyRep = _companyRepRepo.GetByCompany(comp.id);
                    ClientRegistrationRequestModel client = new ClientRegistrationRequestModel();
                    client.contactName = companyRep.name;
                    client.contactSurname = companyRep.surname;
                    client.title = companyRep.title;
                    client.gender = companyRep.gender;
                    client.contactEmail = companyRep.email;
                    client.contactNumber = companyRep.phone;
                    client.companyName = comp.name;
                    client.companyRegistrationNumber = comp.registration_number;
                    client.isCompanyPresent = comp.isCompanyPresent;
                    client.companyProfile = comp.company_profile;
                    client.dateGenerated = companyRep.date_captured;
                    foreach(UsersEntity user in users)
                    {
                        if(user.username == companyRep.email)
                        {
                            client.userStatus = user.user_status_fk;
                        }
                    }
                    result.Add(client);
                }

                return result;
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ClientRegistrationRequestModel GetClient(string companyRegistrationNumber)
        {
            try
            {
                CompanyEntity company = _companyRepo.GetByRegistrationNumber(companyRegistrationNumber);
                CompanyRepresentativeEntity companyRep = _companyRepRepo.GetByCompany(company.id);
                ClientRegistrationRequestModel client = new ClientRegistrationRequestModel();
                UsersEntity user = _userRepo.GetUser(companyRep.email);
                client.contactName = companyRep.name;
                client.contactSurname = companyRep.surname;
                client.title = companyRep.title;
                client.gender = companyRep.gender;
                client.contactEmail = companyRep.email;
                client.contactNumber = companyRep.phone;
                client.companyName = company.name;
                client.companyRegistrationNumber = company.registration_number;
                client.isCompanyPresent = company.isCompanyPresent;
                client.companyProfile = company.company_profile;
                client.dateGenerated = companyRep.date_captured;
               
                if (user.username == companyRep.email)
                {
                    client.userStatus = user.user_status_fk;
                }
                
                return client;

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ClientRegistrationRequestModel GetClientByEmail(string email)
        {
            try
            {

                CompanyRepresentativeEntity companyRep = _companyRepRepo.GetByEmail(email);
                CompanyEntity company = _companyRepo.GetById(companyRep.company_fk);
                UsersEntity user = _userRepo.GetUser(companyRep.email);
                ClientRegistrationRequestModel client = new ClientRegistrationRequestModel();
                client.contactName = companyRep.name;
                client.contactSurname = companyRep.surname;
                client.title = companyRep.title;
                client.gender = companyRep.gender;
                client.contactEmail = companyRep.email;
                client.contactNumber = companyRep.phone;
                client.companyName = company.name;
                client.companyRegistrationNumber = company.registration_number;
                client.isCompanyPresent = company.isCompanyPresent;
                client.companyProfile = company.company_profile;
                client.dateGenerated = companyRep.date_captured;

                if (user.username == companyRep.email)
                {
                    client.userStatus = user.user_status_fk;
                }
                return client;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateClient(ClientRegistrationRequestModel client)
        {
            try
            {
                CompanyRepresentativeEntity companyRep = _companyRepRepo.GetByEmail(client.contactEmail);
                CompanyEntity company = _companyRepo.GetById(companyRep.company_fk);

                if (companyRep == null)
                    throw new McpCustomException("Client doesn't exist in users list");

                CompanyRepresentativeEntity compRep = _entityBuilder.buildCompanyRepEntity(companyRep.id, client.title, client.contactName, client.contactSurname, client.gender, companyRep.email,client.contactNumber, company.id, companyRep.date_captured,"");
                

                CompanyEntity comp = _entityBuilder.buildCompanyEntity(company.id, client.companyName, client.companyRegistrationNumber, client.companyProfile, client.isCompanyPresent, "");
                UsersEntity user = _userRepo.GetUser(client.contactEmail);
                user.user_status_fk = client.userStatus;
                //TODO: client update status
                //user.password;
                _userRepo.UpdateUser(user);

                return _companyRepo.Update(comp) && _companyRepRepo.Update(compRep);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
