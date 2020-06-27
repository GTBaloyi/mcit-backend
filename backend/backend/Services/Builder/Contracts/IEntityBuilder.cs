using backend.DataAccess.Database.Entities;
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
        QuotationEntity buildQuotationEntity( int Quote_reference, DateTime Quote_expiryDate, DateTime Date_generated, string Email, string Company_name, string bill_address, string Phone_number, double Grand_total, List<QuotationItemEntity> items);
        InvoiceEntity buildInvoiceEntity(int id, string reference, DateTime invoice_date, DateTime date_due, string title, string description, string vat_number, int bill_to_id,
        string Vat, string terms, double total, double subtotal, int quantity, double total_due, int user_id);
    }
}
