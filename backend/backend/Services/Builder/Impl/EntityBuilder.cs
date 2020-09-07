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
        public QuotationEntity quotationEntity { get; set; }
        private EmployeesEntity employeesEntity;
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

        public InvoiceEntity buildInvoiceEntity(int id, string reference, DateTime invoice_date, DateTime date_due, string quotation_reference, double vat_percentage, string bill_address,
        double vat, double discount, double subtotal, double grand_total, string company_registration, string generatedBy, string approvedBy, double amount_due, double amount_payed)
        {
            InvoiceEntity InvoiceEntity = new InvoiceEntity();
            InvoiceEntity.id = id;
            InvoiceEntity.reference = reference;
            InvoiceEntity.invoice_date = invoice_date;
            InvoiceEntity.date_due = date_due;
            InvoiceEntity.quotation_reference = quotation_reference;
            InvoiceEntity.vat_percentage = vat_percentage;
            InvoiceEntity.bill_address = bill_address;
            InvoiceEntity.vat = vat;
            InvoiceEntity.discount = discount;
            InvoiceEntity.subtotal = subtotal;
            InvoiceEntity.grand_total = grand_total;
            InvoiceEntity.company_registration = company_registration;
            InvoiceEntity.generatedBy = generatedBy;
            InvoiceEntity.approvedBy = approvedBy;
            InvoiceEntity.amount_due = amount_due;
            InvoiceEntity.amount_payed = amount_payed;
            return InvoiceEntity;
        }

        public QuotationEntity buildQuotationEntity(string Quote_reference, DateTime Quote_expiryDate, DateTime Date_generated, string Email, string Company_name, string Company_Registration,string bill_address, string Phone_number, double subTotal, double vat, double vatAmount, double discount, double Grand_total, string status, string description, string reason, string generatedBy, string approvedBy)
        {
            quotationEntity = new QuotationEntity();
            quotationEntity.Quote_reference = Quote_reference;
            quotationEntity.Date_generated = Date_generated;
            quotationEntity.Quote_expiryDate = Quote_expiryDate;
            quotationEntity.Email = Email;
            quotationEntity.Company_name = Company_name;
            quotationEntity.Company_Registration = Company_Registration;
            quotationEntity.Bill_address = bill_address;
            quotationEntity.Phone_Number = Phone_number;
            quotationEntity.SubTotal = subTotal;
            quotationEntity.Vat = vat;
            quotationEntity.Vat_Amount = vatAmount;
            quotationEntity.Discount = discount;
            quotationEntity.Grand_total = Grand_total;
            quotationEntity.status = status;
            quotationEntity.description = description;
            quotationEntity.reason = reason;
            quotationEntity.generatedBy = generatedBy;
            quotationEntity.approvedBy = approvedBy;
            return quotationEntity;
        }

        public EmployeesEntity BuildEmployeesEntity(int id, string employeeNumber,string name, string surname, int positionId, string email, string cell, string address, DateTime createdOn)
        {
            employeesEntity = new EmployeesEntity();
            employeesEntity.id = id;
            employeesEntity.employee_number = employeeNumber;
            employeesEntity.name = name;
            employeesEntity.surname = surname;
            employeesEntity.position_fk = positionId;
            employeesEntity.email = email;
            employeesEntity.cell = cell;
            employeesEntity.address = address;
            employeesEntity.created_on = createdOn;
            return employeesEntity;
        }

        public ProjectEntity buildProjectEntity(int id, string projectNumber, string projectName, bool isSequential, string projectDescription, string invoiceReference,
                                                    string companyRegistration, string assignedEmployees, DateTime createdOn)
        {
            return new ProjectEntity
            {
                id = id,
                project_number = projectNumber,
                project_name = projectName,
                isSequential = isSequential,
                project_description = projectDescription,
                invoice_reference = invoiceReference,
                company_registration = companyRegistration,
                assigned_employees = assignedEmployees,
                createdOn = createdOn
            };

        }

        public ProjectProgress buildProjectProgressEntity(int id, string projectNumber, DateTime targetStartDate, int duration, DateTime actualStartDate, DateTime actualEndDate, string projectStatus, double ProjectStatusPercentage, string startQuarter, string currentQuarter, string targetEndQuarter)
        {
            return  new ProjectProgress
            {
                id = id,
                project_number = projectNumber,
                target_start_date = targetStartDate,
                target_duration = duration,
                actual_start_date = actualStartDate,
                actual_end_date = actualEndDate,
                project_status = projectStatus,
                project_status_percentage = ProjectStatusPercentage,
                start_quarter = startQuarter,
                current_quarter = currentQuarter,
                target_end_quarter = targetEndQuarter
            };

        }

        public ProjectExpenditure buildProjectExpenditureEntity(int id, string projectNumber, string focusArea, string item, double actualCost, double targetCost)
        {
            return new ProjectExpenditure
            {
                id = id,
                project_number = projectNumber,
                focus_area = focusArea,
                item = item,
                actual_cost = actualCost,
                target_cost = targetCost
            };

        }

        public ProjectTODO buildProjectTODOEntity(int id, string projectNumber, int sequence, bool isSequential, string focusArea, string item, DateTime dateStarted, DateTime dateEnded)
        {
            return new ProjectTODO
            {
                id = id,
                project_number = projectNumber,
                sequence = sequence,
                isSequential = isSequential,
                focus_area = focusArea,
                item = item,
                date_started = dateStarted,
                date_ended = dateEnded
            };
        }
    }
}
