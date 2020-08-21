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
        QuotationEntity buildQuotationEntity( string Quote_reference, DateTime Quote_expiryDate, DateTime Date_generated, string Email, string Company_name, string Company_Registration, string bill_address, string Phone_number, double Grand_total, string status,string description, string reason);
        InvoiceEntity buildInvoiceEntity(int id, string reference, DateTime invoice_date, DateTime date_due, string quotation_reference, double vat_percentage, string bill_address,
        double vat, double discount ,double subtotal, double grand_total, string company_registration, string generatedBy, string approvedBy, double amount_due, double amount_payed);
        EmployeesEntity BuildEmployeesEntity(string employeeNumber,string name, string surname, int positionId, string email, string cell, string address, DateTime createdOn);
    }
}
