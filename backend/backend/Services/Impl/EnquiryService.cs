using backend.DataAccess;
using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using backend.DataAccess.Database.Entities;
using backend.DataAccess.Repositories;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Commons;
using backend.Services.Builder;
using backend.DataAccess.Database.Repositories.Contracts;

namespace backend.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IEnquiryRepository _enquiryRepo;
        private readonly IEntityBuilder _entityBuilder;

        public EnquiryService(IEntityBuilder builder, IEnquiryRepository enquiryRepo)
        {
            _enquiryRepo = enquiryRepo;
            _entityBuilder = builder;

        }

        public void Delete(int id)
        {
            EnquiryEntity entity = _enquiryRepo.GetById(id);
            _enquiryRepo.Delete(entity);
        }

        public List<EnquiryRequestModel> GetAll()
        {
            List<EnquiryEntity> entities = _enquiryRepo.GetAll();
            List<EnquiryRequestModel> models = new List<EnquiryRequestModel>();
           
            foreach(EnquiryEntity entity in entities)
            {
                EnquiryRequestModel model = new EnquiryRequestModel();
                model.id = entity.id;
                model.focus_area_fk = entity.focus_area_fk;
                model.enquiry_date = entity.enquiry_date;
                model.quarter = entity.quarter;
                model.company = entity.company;
                model.company_registration_number = entity.company_registration_number;
                model.description = entity.description;
                model.service_tech_fk = entity.service_tech_fk;
                model.socio_economic_impact_fk = entity.socio_economic_impact_fk;
                model.product_expectation_fk = entity.product_expectation_fk;
                model.project_budget = entity.project_budget;
                model.expected_completion = entity.expected_completion;

                models.Add(model);
            }
            return models;
        }

        public EnquiryRequestModel GetById(int id)
        {
            EnquiryEntity entity = _enquiryRepo.GetById(id);
            if (entity != null)
            {
                EnquiryRequestModel model = new EnquiryRequestModel();
                model.id = id;
                model.focus_area_fk = entity.focus_area_fk;
                model.enquiry_date = entity.enquiry_date;
                model.quarter = entity.quarter;
                model.company = entity.company;
                model.company_registration_number = entity.company_registration_number;
                model.description = entity.description;
                model.service_tech_fk = entity.service_tech_fk;
                model.socio_economic_impact_fk = entity.socio_economic_impact_fk;
                model.product_expectation_fk = entity.product_expectation_fk;
                model.project_budget = entity.project_budget;
                model.expected_completion = entity.expected_completion;
                return model;
            }
            else
            {
                return null;
            }
        }

        public EnquiryResponseModel Save(EnquiryEntity enquiry)
        {
            if (_enquiryRepo.Save(enquiry))
            {
                EnquiryResponseModel respose = new EnquiryResponseModel(001, "Enquiry saved successfully");
                return respose;
            }
            else
            {
                EnquiryResponseModel respose = new EnquiryResponseModel(002, "Enquiry could not be saved");
                return respose;
            }
        }

        public EnquiryResponseModel Update(EnquiryRequestModel model)
        {
            
            EnquiryEntity enquiry = _entityBuilder.buildEnquiryEntity(model.id, model.focus_area_fk, model.enquiry_date, model.quarter, model.company, model.company_registration_number, model.description, model.service_tech_fk, model.socio_economic_impact_fk, model.product_expectation_fk, model.project_budget, model.expected_completion);

            if (_enquiryRepo.Update(enquiry))
            {
                EnquiryResponseModel respose = new EnquiryResponseModel(201, "Enquiry updated successfully");
                return respose;
            }
            else
            {
                EnquiryResponseModel respose = new EnquiryResponseModel(202, "Enquiry could not be Updated");
                return respose;
            }
        }
        public EnquiryResponseModel NewEnquiry(int id, int focusAreaId, DateTime enquiryDate, string quarter, string company, string companyRegistrationNumber, string description, int serviceTechId, int socioEconomicImpactId, int productExpectationid, double projectBudget, DateTime expectedCompletion)
        {
            EnquiryRequestModel model = new EnquiryRequestModel();
            model.id = id;
            model.focus_area_fk = focusAreaId;
            model.enquiry_date = enquiryDate;
            model.quarter = quarter;
            model.company = company;
            model.company_registration_number = companyRegistrationNumber;
            model.description = description;
            model.service_tech_fk = serviceTechId;
            model.socio_economic_impact_fk = socioEconomicImpactId;
            model.product_expectation_fk = productExpectationid;
            model.project_budget = projectBudget;
            model.expected_completion = expectedCompletion;
            EnquiryEntity enquiry = _entityBuilder.buildEnquiryEntity(id, focusAreaId, enquiryDate, quarter, company, companyRegistrationNumber, description, serviceTechId, socioEconomicImpactId, productExpectationid, projectBudget, expectedCompletion);

            EnquiryResponseModel response = Save(enquiry);
            return response;

        }

    }

}

