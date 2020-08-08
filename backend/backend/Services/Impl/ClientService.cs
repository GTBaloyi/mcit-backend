using backend.DataAccess.Contracts;
using backend.DataAccess.Database.Repositories;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.Models;
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

        public ClientService(ICompanyRepository companyRepository, ICompanyRepRepository companyRepRepository, IUsersRepository userRepo)
        {
            _companyRepo = companyRepository;
            _companyRepRepo = companyRepRepository;
            _userRepo = userRepo;

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
                /*_userRepo.UpdateUser(_userRepo.GetUser(rep.email));
                _companyRepRepo.Delete(rep);
                _companyRepo.Delete(company);*/
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
