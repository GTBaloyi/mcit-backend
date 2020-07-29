using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepo;
        private readonly IEntityBuilder _entityBuilder;

        public QuotationService(IEntityBuilder builder, IQuotationRepository quotationRepo)
        {
            _quotationRepo = quotationRepo;
            _entityBuilder = builder;

        }

        public void Delete(int id)
        {
            QuotationEntity entity = _quotationRepo.GetById(id);
            _quotationRepo.Delete(entity);
        }

        public List<QuotationResponseModel> GetAll()
        {
            List<QuotationEntity> entities = _quotationRepo.GetAll();
            List<QuotationResponseModel> models = new List<QuotationResponseModel>();
            if (entities != null)
            {
                foreach (QuotationEntity quote in entities)
                {
                    QuotationResponseModel model = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quote.Items);
                    models.Add(model);
                }
                return models;
            }
            else
            {
                return null;
            }


        }

        public QuotationResponseModel GetById(int id)
        {
            QuotationEntity quote = _quotationRepo.GetById(id);
            if (quote != null)
            {
                return new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quote.Items);
            }
            else
            {
                return null;
            }
        }

        public QuotationResponseModel Update(QuotationModel model)
        {

            QuotationEntity quote = _entityBuilder.buildQuotationEntity(model.Quote_reference, model.Quote_expiryDate, model.Date_generated, model.Email, model.Company_name, model.Bill_address, model.Phone_number, model.Grand_total, model.Items);

            if (_quotationRepo.Update(quote))
            {
                QuotationResponseModel response = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, model.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quote.Items);
                return response;
            }
            else
            {
                return null;
            }
        }

        public bool NewQuotation(QuotationModel model)
        {
            QuotationEntity quote = _entityBuilder.buildQuotationEntity(model.Quote_reference, model.Quote_expiryDate, model.Date_generated, model.Email, model.Company_name, model.Bill_address, model.Phone_number, model.Grand_total, model.Items);
            if (_quotationRepo.Save(quote))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<QuotationResponseModel> GetQuotationByCompany(string companyName)
        {
            List<QuotationEntity> allQuotations = _quotationRepo.GetAll();
            List<QuotationResponseModel> quotations = new List<QuotationResponseModel>();
            foreach(QuotationEntity quote in allQuotations)
            {
                if(quote.Company_name.ToLower() == companyName.ToLower())
                {
                    QuotationResponseModel data = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quote.Items);
                    quotations.Add(data);
                }

            }

            return quotations;

           
        }
    }
}
