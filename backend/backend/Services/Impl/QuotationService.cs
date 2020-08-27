using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
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
        private readonly IProductRepository _productsRepo;
        private readonly IEntityBuilder _entityBuilder;
        private readonly CommonServices commonServices = new CommonServices();
        private readonly CommonMethods commonMethods = new CommonMethods();
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public QuotationService(IEntityBuilder builder, IQuotationRepository quotationRepo, IQuotationItemsRepository quotationItemsRepo, IEmailTemplateRepository emailTemplateRepository, IProductRepository productRepository)
        {
            _quotationRepo = quotationRepo;
            _quotationItemsRepo = quotationItemsRepo;
            _emailTemplateRepository = emailTemplateRepository;
            _entityBuilder = builder;
            _productsRepo = productRepository;

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
                        QuotationResponseModel model = new QuotationResponseModel(q.Quote_id, q.Quote_reference, q.Quote_expiryDate, q.Date_generated, q.Email, q.Company_name, q.Company_Registration, q.Bill_address, q.Phone_Number, q.SubTotal, q.Vat, q.Vat_Amount, q.Discount, q.Grand_total, quotationItems, q.status, q.reason, q.description);
                        models.Add(model);
                        

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
                    return new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Company_Registration, quote.Bill_address, quote.Phone_Number, quote.SubTotal, quote.Vat, quote.Vat_Amount, quote.Discount, quote.Grand_total, quoteItems, quote.status, quote.reason, quote.description);
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

        public QuotationResponseModel GetByReference(string quoteReference)
        {

            try
            {
                QuotationEntity quote = _quotationRepo.GetByReference(quoteReference);

                if (quote != null)
                {

                    List<QuotationItemEntity> items = _quotationItemsRepo.GetByQuote(quote.Quote_reference);
                    List<QuotationItemEntity> quoteItems = new List<QuotationItemEntity>();
                    foreach (QuotationItemEntity qItems in items)
                    {
                        quoteItems.Add(qItems);
                    }
                    return new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Company_Registration, quote.Bill_address, quote.Phone_Number, quote.SubTotal, quote.Vat, quote.Vat_Amount, quote.Discount, quote.Grand_total, quoteItems, quote.status, quote.reason, quote.description);
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
                QuotationEntity quote = _entityBuilder.buildQuotationEntity(model.Quote_reference, model.Quote_expiryDate, model.Date_generated, model.Email, model.Company_name,model.Company_Registration, model.Bill_address, model.Phone_number,model.SubTotal, 0.15, model.vatAmount, model.discount, model.Grand_total, model.status, model.description, model.reason, model.generatedBy, model.approvedBy);
                quote.Quote_id = model.quote_id;
                List<QuotationItemEntity> quoteItem = new List<QuotationItemEntity>();
                foreach (QuotationItemEntity item in model.Items)
                {

                    _quotationItemsRepo.Update(item);
                    quoteItem.Add(item);
                }

                if (_quotationRepo.Update(quote))
                {

                    QuotationResponseModel response = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, model.Email, quote.Company_name, quote.Company_Registration, quote.Bill_address, quote.Phone_Number, quote.SubTotal, quote.Vat, quote.Vat_Amount, quote.Discount, quote.Grand_total, quoteItem, quote.status, quote.reason, quote.description);

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

        public string NewQuotation(QuotationModel model)
        {
            try
            {
                model.Date_generated = DateTime.Now;
                model.Quote_expiryDate = model.Date_generated.AddDays(30);
                model.Quote_reference = generateQuotationReference();

                QuotationEntity quote = _entityBuilder.buildQuotationEntity(model.Quote_reference, model.Quote_expiryDate, model.Date_generated, model.Email, model.Company_name, model.Company_Registration, model.Bill_address, model.Phone_number,0,0,0,0,0, model.status, model.description, model.reason, model.generatedBy, model.approvedBy);
                if (_quotationRepo.Save(quote))
                {
                   // if(model.Items)
                    foreach (QuotationItemEntity item in model.Items)
                    {
                        QuotationEntity quotation = _quotationRepo.GetAll().Last();
                        item.quote_reference = quotation.Quote_reference;
                        _quotationItemsRepo.Save(item);
                    }
                    return model.Quote_reference;
                }
                else
                {
                    throw new McpCustomException("Could not create quotation");
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

                        QuotationResponseModel data = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quote.Email, quote.Company_name, quote.Company_Registration, quote.Bill_address, quote.Phone_Number, quote.SubTotal, quote.Vat, quote.Vat_Amount, quote.Discount, quote.Grand_total, items, quote.status, quote.reason, quote.description);
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

        public QuotationResponseModel GenerateQuotation(QuotationModel quotation)
        {
           
            try
            {

                QuotationEntity quote = _entityBuilder.buildQuotationEntity(quotation.Quote_reference, quotation.Quote_expiryDate, quotation.Date_generated, quotation.Email, quotation.Company_name, quotation.Company_Registration, quotation.Bill_address, quotation.Phone_number, 0,0, 0,0, quotation.Grand_total, quotation.status, quotation.description, quotation.reason, quotation.generatedBy, quotation.approvedBy);
                quote.Quote_id = quotation.quote_id;
                List<QuotationItemEntity> quoteItem = new List<QuotationItemEntity>();
                quotation.Items = generateProductsList(quotation.Items, quotation.Quote_reference);
                foreach (QuotationItemEntity item in quotation.Items)
                {
                    ProductsEntity product = _productsRepo.GetByName(item.Item);
                    double totalTestMinutes = item.numberOfTests * product.time_study_per_test;
                    double ratePerMinute = product.rate_per_hour / 60;
                    item.Unit_Price = Math.Round( (totalTestMinutes * ratePerMinute),2);
                    item.Total = item.Unit_Price * item.Quantity;
                    quote.SubTotal += Math.Round(item.Total,2);
                    _quotationItemsRepo.Update(item);
                    quoteItem.Add(item);

                }

                double calculateTotal =quote.SubTotal - (quote.SubTotal * quotation.discount);
                quote.Vat = 0.15;
                quote.Vat_Amount = Math.Round((calculateTotal * quote.Vat),2);
                quote.Grand_total = Math.Round((calculateTotal + quote.Vat_Amount),2);
                

                if (_quotationRepo.Update(quote))
                {
                    QuotationResponseModel response = new QuotationResponseModel(quote.Quote_id, quote.Quote_reference, quote.Quote_expiryDate, quote.Date_generated, quotation.Email, quote.Company_name, quote.Company_Registration, quote.Bill_address, quote.Phone_Number, quote.SubTotal, quote.Vat, quote.Vat_Amount, quote.Discount, quote.Grand_total, quoteItem, quote.status, quote.reason, quote.description);
                    statusCheck(response);
                    return response;
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

        private List<QuotationItemEntity> generateProductsList(List<QuotationItemEntity> newList, string quotationReference)
        {
            List<QuotationItemEntity> results = new List<QuotationItemEntity>();

            List<QuotationItemEntity> oldList = _quotationItemsRepo.GetByQuote(quotationReference);


            foreach (QuotationItemEntity oldItem in oldList)
            {
                QuotationItemEntity itemExist = newList.Find(x => x.id == oldItem.id);
                if(itemExist != null)
                {
                    _quotationItemsRepo.Update(itemExist);
                    results.Add(itemExist);
                }
                else
                {
                    _quotationItemsRepo.Delete(oldItem);
                }
            }

            foreach(QuotationItemEntity newItem in newList)
            {
                //Check new product Add it
                QuotationItemEntity itemExist = oldList.Find(x => x.id == newItem.id);
                if (itemExist == null)
                {
                    _quotationItemsRepo.Save(newItem);

                    results.Add(newItem);
                }
            }

            return results;
        }
    }
}
