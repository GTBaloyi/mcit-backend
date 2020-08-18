using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Commons;
using backend.Services.Contracts;
using FluentNHibernate.Conventions.Inspections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepo;
        private readonly IQuotationItemsRepository _quotationItemsRepo;
        private readonly IEntityBuilder _entityBuilder;
        private readonly CommonServices commonServices = new CommonServices();
        private readonly CommonMethods commonMethods = new CommonMethods();
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public QuotationService(IEntityBuilder builder, IQuotationRepository quotationRepo, IQuotationItemsRepository quotationItemsRepo, IEmailTemplateRepository emailTemplateRepository)
        {
            _quotationRepo = quotationRepo;
            _quotationItemsRepo = quotationItemsRepo;
            _emailTemplateRepository = emailTemplateRepository;
            _entityBuilder = builder;

        }

        public void Delete(int id)
        {
            QuotationEntity entity = _quotationRepo.GetById(id);
            _quotationRepo.Delete(entity);
        }

        public List<QuotationResponseModel> GetAll()
        {
            try
            {
                List<QuotationEntity> entities = _quotationRepo.GetAll();
                List<QuotationResponseModel> models = new List<QuotationResponseModel>();

                if (entities.Count != 0)
                {
                    foreach (QuotationEntity q in entities)
                    {
                        List<QuotationItemEntity> quotationItems = _quotationItemsRepo.GetByQuote(q.Quote_reference);
                        foreach (QuotationEntity quote in entities)
                        {
                            QuotationResponseModel model = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quotationItems, quote.status);
                            models.Add(model);
                        }

                    }
                }

                return models;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public QuotationResponseModel GetById(int id)
        {

            try
            {
                QuotationEntity quote = _quotationRepo.GetById(id);

                if (quote != null)
                {

                    List<QuotationItemEntity> items = _quotationItemsRepo.GetByQuote(quote.Quote_reference);
                    List<QuotationItemEntity> quoteItems = new List<QuotationItemEntity>();
                    foreach (QuotationItemEntity qItems in items)
                    {
                        quoteItems.Add(qItems);
                    }
                    return new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quoteItems, quote.status);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            

        }

        public QuotationResponseModel Update(QuotationModel model)
        {
            try
            {
                QuotationEntity quote = _entityBuilder.buildQuotationEntity(model.Quote_reference, model.Quote_expiryDate, model.Date_generated, model.Email, model.Company_name, model.Bill_address, model.Phone_number, model.Grand_total, model.status);
                quote.Quote_id = model.quote_id;
                List<QuotationItemEntity> quoteItem = new List<QuotationItemEntity>();
                foreach (QuotationItemEntity item in model.Items)
                {
                    _quotationItemsRepo.Update(item);
                    quoteItem.Add(item);
                }

                if (_quotationRepo.Update(quote))
                {

                    QuotationResponseModel response = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, model.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, quoteItem, quote.status);

                    statusCheck(response);
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void statusCheck(QuotationResponseModel response)
        {
            string emailMessage = "";
            if (response.status.ToLower() == "pending")
            {
                emailMessage = _emailTemplateRepository.GetByType("QuotationPending").code;
                emailMessage = emailMessage.Replace("{company_name}", response.Company_name);
                emailMessage = emailMessage.Replace("{quotationi_status}", "Pending");
            }

            if (response.status.ToLower() == "pending manager approval")
            {
                emailMessage = _emailTemplateRepository.GetByType("QuotationPendingManagerApproval").code;
                emailMessage = emailMessage.Replace("{company_name}", response.Company_name);
                emailMessage = emailMessage.Replace("{quotationi_status}", "Pending Manager Approval");

            }

            if (response.status.ToLower() == "pending client approval")
            {
                emailMessage = _emailTemplateRepository.GetByType("QuotationClientApproval").code;
                emailMessage = emailMessage.Replace("{company_name}", response.Company_name);
                emailMessage = emailMessage.Replace("{quotationi_status}", "Pending Client Approval");
            }

            if (response.status.ToLower() == "accepted")
            {
                emailMessage = _emailTemplateRepository.GetByType("QuotationApproved").code;
                emailMessage = emailMessage.Replace("{company_name}", response.Company_name);
                emailMessage = emailMessage.Replace("{quotationi_status}", "Quotation Accepted");
            }

            if (response.status.ToLower() == "rejected")
            {
                emailMessage = _emailTemplateRepository.GetByType("QuotationRejected").code;
                emailMessage = emailMessage.Replace("{company_name}", response.Company_name);
                emailMessage = emailMessage.Replace("{quotationi_status}", "Quotation Rejected");
            }
            commonServices.SendEmail("MCTS: Quotation Status Update", emailMessage, response.Email);
        }

        public bool NewQuotation(QuotationModel model)
        {
            try
            {
                model.Date_generated = DateTime.Now;
                model.Quote_expiryDate = model.Date_generated.AddDays(30);
                model.Quote_reference = generateQuotationReference();

                QuotationEntity quote = _entityBuilder.buildQuotationEntity(model.Quote_reference, model.Quote_expiryDate, model.Date_generated, model.Email, model.Company_name, model.Bill_address, model.Phone_number, model.Grand_total, model.status);
                if (_quotationRepo.Save(quote))
                {
                    foreach (QuotationItemEntity item in model.Items)
                    {
                        QuotationEntity quotation = _quotationRepo.GetAll().Last();
                        item.quote_reference = quotation.Quote_reference;
                        _quotationItemsRepo.Save(item);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        private string generateQuotationReference()
        {
            string date = DateTime.Now.Year+""+DateTime.Now.Month+""+DateTime.Now.Day+""+0;
            int number = 1;
            List<QuotationEntity> quotations = _quotationRepo.GetAll();

            if (quotations.Count != 0)
            {
                return "mcts-q" + date + "" + quotations.Last().Quote_id + 1;
            }
            else
            {
                return "mcts-q" + date + ""+ 1;
            }
        }

        public List<QuotationResponseModel> GetQuotationByCompany(string email)
        {
            try
            {
                List<QuotationResponseModel> results = new List<QuotationResponseModel>();
                List<QuotationEntity> allQuotations = _quotationRepo.GetAll();
                foreach (QuotationEntity quote in allQuotations)
                {
                    if (quote.Email.ToLower() == email.ToLower())
                    {
                        List<QuotationResponseModel> quotations = new List<QuotationResponseModel>();
                        List<QuotationItemEntity> quotationsItems = _quotationItemsRepo.GetByQuote(quote.Quote_reference);

                        List<QuotationItemEntity> items = new List<QuotationItemEntity>();
                        foreach (QuotationItemEntity qItems in quotationsItems)
                        {
                            items.Add(qItems);
                        }

                        QuotationResponseModel data = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Bill_address, quote.Phone_Number, quote.Grand_total, items, quote.status);
                        results.Add(data);
                    }

                }

                return results;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
