using backend.DataAccess.Database.Entities;
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
        private EnquiryEntity enquiryEntity;
       
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

        public EnquiryEntity buildEnquiryEntity(int id, int focusAreaId, DateTime enquiryDate, string quarter, string company, string companyRegistrationNumber, string description, int serviceTechId, int socioEconomicImpactId, int productExpectationid, double projectBudget, DateTime expectedCompletion)
        {
            enquiryEntity = new EnquiryEntity();
            enquiryEntity.id = id;
            enquiryEntity.focus_area_fk = focusAreaId;
            enquiryEntity.enquiry_date = enquiryDate;
            enquiryEntity.quarter = quarter;
            enquiryEntity.company = company;
            enquiryEntity.company_registration_number = companyRegistrationNumber;
            enquiryEntity.description = description;
            enquiryEntity.service_tech_fk = serviceTechId;
            enquiryEntity.socio_economic_impact_fk = socioEconomicImpactId;
            enquiryEntity.product_expectation_fk = productExpectationid;
            enquiryEntity.project_budget = projectBudget;
            enquiryEntity.expected_completion = expectedCompletion;

            return enquiryEntity;
        }

        public UsersEntity buildUserEntity(string username, string password, int retry, int userStatusId, int accessId, int companyRepId, DateTime lastLogin, string otp, string location)
        {
            userEntity = new UsersEntity();
            userEntity.username = username;
            userEntity.password = password;
            userEntity.retry = retry;
            userEntity.user_status_fk = userStatusId;
            userEntity.access_fk = accessId;
            userEntity.company_rep_fk = companyRepId;
            userEntity.last_login = lastLogin;
            userEntity.otp = otp;
            userEntity.location = location;

            return userEntity;
        }

        public InvoiceEntity buildInvoiceEntity(int id, string reference, DateTime invoice_date, DateTime date_due, string title, string description, string vat_number, int bill_to_id,
        string Vat, string terms, double total, double subtotal, int quantity, double total_due, int user_id)
        {
            InvoiceEntity InvoiceEntity = new InvoiceEntity();
            InvoiceEntity.id = id;
            InvoiceEntity.reference = reference;
            InvoiceEntity.invoice_date = invoice_date;
            InvoiceEntity.date_due = date_due;
            InvoiceEntity.title = title;
            InvoiceEntity.description = description;
            InvoiceEntity.vat_number = vat_number;
            InvoiceEntity.bill_to_id = bill_to_id;
            InvoiceEntity.Vat = Vat;
            InvoiceEntity.terms = terms;
            InvoiceEntity.total = total;
            InvoiceEntity.subtotal = subtotal;
            InvoiceEntity.quantity = quantity;
            InvoiceEntity.total_due = total_due;
            InvoiceEntity.user_id = user_id;
            return InvoiceEntity;
        }
    }
}
