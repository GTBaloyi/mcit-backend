using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Builder
{
    public class EntityBuilder : IEntityBuilder
    {
        private CompanyEntity companyEntity;
        private CompanyRepresentativeEntity companyRepEntity;
        private UsersEntity userEntity;
       
        public CompanyEntity buildCompanyEntity(int id,string name, string companyRegistration, string companyProfile, bool isCompanyPresent, string quarter)
        {
            companyEntity = new CompanyEntity();
            if(id != 0)
            {
                companyEntity.id = id;
            }

            companyEntity.name = name;
            companyEntity.registration_number = companyRegistration;
            companyEntity.company_profile = companyProfile;
            companyEntity.isCompanyPresent = isCompanyPresent;
            companyEntity.quarter = quarter;


            return companyEntity;
        }

        public CompanyRepresentativeEntity buildCompanyRepEntity(int id, string title, string name, string surname, string gender, string email, string phone, int companyId, DateTime dateCaptured, string avatar)
        {
            companyRepEntity = new CompanyRepresentativeEntity();
            companyRepEntity.id = id;
            companyRepEntity.title = title;
            companyRepEntity.name = name;
            companyRepEntity.surname = surname;
            companyRepEntity.gender = gender;
            companyRepEntity.email = email;
            companyRepEntity.phone = phone;
            companyRepEntity.company_fk = companyId;
            companyRepEntity.date_captured = dateCaptured;
            companyRepEntity.avatar_path = avatar;

            return companyRepEntity;
        }

        public UsersEntity buildUserEntity(string username, string password, int retry, int userStatusId, int accessId, int companyId, DateTime lastLogin, string otp, string location)
        {
            userEntity = new UsersEntity();
            userEntity.username = username;
            userEntity.password = password;
            userEntity.retry = retry;
            userEntity.user_status_fk = userStatusId;
            userEntity.access_fk = accessId;
            userEntity.company_rep_fk = companyId;
            userEntity.last_login = lastLogin;
            userEntity.otp = otp;
            userEntity.location = location;

            return userEntity;
        }
    }
}
