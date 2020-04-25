﻿using backend.DataAccess.Database.Entities;
using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Builder
{
    public interface IEntityBuilder
    {
        CompanyEntity buildCompanyEntity(int id, string name,string companyRegistration, string companyProfile, bool isCompanyPresent, string quarter);
        UsersEntity buildUserEntity(string username, string password, int retry, int userStatusId, int accessId, int companyRepId, DateTime lastLogin, string otp, string location);
        CompanyRepresentativeEntity buildCompanyRepEntity(int id, string title, string name, string surname, string gender, string email, string phone, int companyId, DateTime dateCaptured, string avatar);
        EnquiryEntity buildEnquiryEntity(int id, int focusAreaId, DateTime enquiryDate, string quarter, string company, string companyRegistrationNumber, string description, int serviceTechId, int socioEconomicImpactId, int productExpectationid, double projectBudget, DateTime expectedCompletion);
    }
}