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
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IQuotationItemsRepository _quotationItemsRepository;
        private readonly IQuotationRepository _quotationRepository;
        private readonly ICompanyRepository _companyRepository;

        public InvoiceService(IEntityBuilder builder, IInvoiceRepository i_invoiceRepo, IQuotationItemsRepository quotationItemsRepository, IQuotationRepository quotationRepository,ICompanyRepository companyRepository)
        {
            _invoiceRepo = i_invoiceRepo;
            _entityBuilder = builder;
            _quotationItemsRepository = quotationItemsRepository;
            _quotationRepository = quotationRepository;
            _companyRepository = companyRepository;

        }

        public InvoiceEntity GetByReferernce (string reference)
        {
           try
            {
                return _invoiceRepo.GetByReference(reference);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void Delete(string referenceId)
        {
            try
            {
                InvoiceEntity entity = _invoiceRepo.GetByReference(referenceId);
                _invoiceRepo.Delete(entity);
            } 
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public List<InvoiceResponseModel> GetAll()
        {
            /*List<InvoiceEntity> entities = _invoiceRepo.GetAll();
            List<InvoiceResponseModel> models = new List<InvoiceResponseModel>();
            
            if (entities != null)
            {
              

                foreach (InvoiceEntity entity in entities)
                {
                    List<QuotationItemEntity> items = _quotationItemsRepository.GetByQuote(entity.quotation_reference);


                    InvoiceResponseModel model = new InvoiceResponseModel(entity.id, entity.reference, entity.invoice_date, entity.date_due, items, entity.vat_number, entity.bill_address,
                                                                            entity.vat,  entity.subtotal, entity.quantity, entity.total_due, entity.company_registration,entity.generatedBy, entity.approvedBy);
                    models.Add(model);
                }
                return models;
            }
            else
            {
                return null;
            }*/

            return null;

        }

        public List<InvoiceResponseModel> GetById(string companyRegistration)
        {

            CompanyEntity company = _companyRepository.GetByRegistrationNumber(companyRegistration);       
            List<InvoiceEntity> savedInvoice = _invoiceRepo.GetAll();
            List<InvoiceResponseModel> results = new List<InvoiceResponseModel>();
            foreach(InvoiceEntity invoiceTemp in savedInvoice)
            {
                if(invoiceTemp.company_registration == companyRegistration)
                {
                    List<QuotationItemEntity> quotationItems = _quotationItemsRepository.GetByQuote(invoiceTemp.quotation_reference);
                    results.Add(new InvoiceResponseModel(invoiceTemp.id, invoiceTemp.reference, invoiceTemp.invoice_date, invoiceTemp.date_due,quotationItems, invoiceTemp.vat_percentage, invoiceTemp.bill_address, invoiceTemp.vat, invoiceTemp.subtotal, invoiceTemp.subtotal, invoiceTemp.company_registration, invoiceTemp.generatedBy, invoiceTemp.approvedBy));
                }
            }


            return results;
        }


        public InvoiceResponseModel Update(InvoiceRequestModel model)
        {
            InvoiceEntity invoice = _entityBuilder.buildInvoiceEntity(model.id, model.reference, DateTime.Now, model.daysBeforeExpiry != 0 ? DateTime.Now.AddDays(model.daysBeforeExpiry) : model.date_due, model.quotation_Reference, model.vat_percentage, model.bill_address,
                                                                        model.vat, model.discount, model.subtotal, model.grand_total, model.company_registration, model.generatedBy, model.approvedBy);
            if (_invoiceRepo.Update(invoice))
            {
                InvoiceEntity savedInvoice = _invoiceRepo.GetByReference(invoice.reference);
                List<QuotationItemEntity> quotationItem = _quotationItemsRepository.GetByQuote(savedInvoice.quotation_reference);

                return new InvoiceResponseModel(savedInvoice.id, savedInvoice.reference, savedInvoice.invoice_date, savedInvoice.date_due, quotationItem, savedInvoice.vat_percentage, savedInvoice.bill_address, savedInvoice.vat, savedInvoice.subtotal, savedInvoice.subtotal, savedInvoice.company_registration, savedInvoice.generatedBy, savedInvoice.approvedBy);
            }
            else
            {
                return null;
            }
        }

        public InvoiceResponseModel GenerateInvoice(InvoiceRequestModel model)
        {

            if(_invoiceRepo.GetByQuotationReference(model.quotation_Reference) == null)
            {
                string invoice_reference = generateInvoiceReference();
                InvoiceEntity invoice = _entityBuilder.buildInvoiceEntity(0, invoice_reference, DateTime.Now, DateTime.Now.AddDays(model.daysBeforeExpiry), model.quotation_Reference, model.vat_percentage, model.bill_address,
                                                                            model.vat, model.discount, model.subtotal, model.grand_total, model.company_registration, model.generatedBy, model.approvedBy);
                if (_invoiceRepo.Save(invoice))
                {
                    InvoiceEntity savedInvoice = _invoiceRepo.GetByReference(invoice_reference);
                    List<QuotationItemEntity> quotationItem = _quotationItemsRepository.GetByQuote(savedInvoice.quotation_reference);

                    return new InvoiceResponseModel(savedInvoice.id, savedInvoice.reference, savedInvoice.invoice_date, savedInvoice.date_due, quotationItem, savedInvoice.vat_percentage, savedInvoice.bill_address, savedInvoice.vat, savedInvoice.subtotal, savedInvoice.subtotal, savedInvoice.company_registration, savedInvoice.generatedBy, savedInvoice.approvedBy);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new McpCustomException("Invoice related to quotation "+ model.quotation_Reference+" already exist");
            }
            
        }

        private string generateInvoiceReference()
        {
            string date = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + 0;
            int number = 1;
            List<InvoiceEntity> invoice = _invoiceRepo.GetAll();

            if (invoice != null)
            {
                return "mcts-i" + date + "" + invoice.Last().id + 1;
            }
            else
            {
                return "mcts-i" + date + "" + 1;
            }
        }

    }

}

