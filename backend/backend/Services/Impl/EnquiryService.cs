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

        public List<EnquiryResponseModel> GetAll()
        {
            List<EnquiryEntity> entities = _enquiryRepo.GetAll();
            List<EnquiryResponseModel> models = new List<EnquiryResponseModel>();
            if (entities != null)
            {
                foreach (EnquiryEntity entity in entities)
                {
                    EnquiryResponseModel model = new EnquiryResponseModel(entity.id, entity.focus_area_fk, entity.enquiry_date, entity.quarter, entity.company, entity.company_registration_number, entity.description,
                     entity.service_tech_fk, entity.socio_economic_impact_fk, entity.product_expectation_fk, entity.project_budget, entity.expected_completion);                   
                    models.Add(model);
                }
                return models;
            }
            else
            {
                return null;
            }
           
            
        }

        public EnquiryResponseModel GetById(int id)
        {
            EnquiryEntity entity = _enquiryRepo.GetById(id);
            if (entity != null)
            {
                return new EnquiryResponseModel(id, entity.focus_area_fk, entity.enquiry_date, entity.quarter, entity.company, entity.company_registration_number, entity.description,
                     entity.service_tech_fk, entity.socio_economic_impact_fk, entity.product_expectation_fk, entity.project_budget, entity.expected_completion);
            }
            else
            {
                return null;
            }
        }


        public EnquiryResponseModel Update(EnquiryRequestModel model)
        {
            
            EnquiryEntity enquiry = _entityBuilder.buildEnquiryEntity(model.id, model.focus_area_fk, model.enquiry_date, model.quarter, model.company, model.company_registration_number, model.description, model.service_tech_fk, model.socio_economic_impact_fk, model.product_expectation_fk, model.project_budget, model.expected_completion);

            if (_enquiryRepo.Update(enquiry))
            {
                EnquiryResponseModel respose = new EnquiryResponseModel(enquiry.id, enquiry.focus_area_fk, enquiry.enquiry_date, enquiry.quarter, enquiry.company, enquiry.company_registration_number, enquiry.description, enquiry.service_tech_fk, enquiry.socio_economic_impact_fk, enquiry.product_expectation_fk, enquiry.project_budget, enquiry.expected_completion);
                return respose;
            }
            else
            {
                return null;
            }
        }

        public bool NewEnquiry(EnquiryRequestModel model)
        {
            EnquiryEntity enquiry = _entityBuilder.buildEnquiryEntity(0, model.focus_area_fk, model.enquiry_date, model.quarter, model.company, model.company_registration_number, model.description, model.service_tech_fk, model.socio_economic_impact_fk, model.product_expectation_fk, model.project_budget, model.expected_completion);
            if (_enquiryRepo.Save(enquiry))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}

