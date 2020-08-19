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

        public InvoiceService(IEntityBuilder builder, IInvoiceRepository i_invoiceRepo, IQuotationItemsRepository quotationItemsRepository)
        {
            _invoiceRepo = i_invoiceRepo;
            _entityBuilder = builder;
            _quotationItemsRepository = quotationItemsRepository;

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
            /*List<InvoiceEntity> entity = _invoiceRepo.GetById(companyRegistration);
            List<InvoiceResponseModel> result = new List<InvoiceResponseModel>();

            if (entity != null)
            {
                foreach (InvoiceEntity invoiceResult in entity)
                {
                    List<QuotationItemEntity> items = _quotationItemsRepository.GetByQuote(invoiceResult.quotation_reference);
                    InvoiceResponseModel ans = new InvoiceResponseModel(invoiceResult.id, invoiceResult.reference, invoiceResult.invoice_date, invoiceResult.date_due, items, invoiceResult.vat_number, invoiceResult.bill_address,
                                                                            invoiceResult.vat, invoiceResult.subtotal, invoiceResult.quantity, invoiceResult.total_due, invoiceResult.company_registration, invoiceResult.generatedBy, invoiceResult.approvedBy);

                    result.Add(ans);
                }

                return result;
            }
            else
            {
                return null;
            }*/

            return null;
        }


        public InvoiceResponseModel Update(InvoiceRequestModel model)
        {
            InvoiceEntity invoice;

            /*  InvoiceEntity invoice = _entityBuilder.buildInvoiceEntity(model.id, model.reference, model.invoice_date, model.date_due, model.quotation_Reference, model.vat_number, model.bill_address,
                                                                          model.vat, model.subtotal, model.quantity, model.total_due, model.company_registration,model.generatedBy,model.approvedBy);

              if (_invoiceRepo.Update(invoice))
              {
                  List<QuotationItemEntity> items = _quotationItemsRepository.GetByQuote(invoice.quotation_reference);
                  InvoiceResponseModel respose = new InvoiceResponseModel(invoice.id, invoice.reference, invoice.invoice_date, invoice.date_due,items, invoice.vat_number, invoice.bill_address,
                                                                              invoice.vat, invoice.subtotal, invoice.quantity, invoice.total_due, invoice.company_registration, invoice.generatedBy, invoice.approvedBy);
                  return respose;
              }
              else
              {
                  return null;
              }*/
            return null;
        }

        public bool GenerateInvoice(InvoiceRequestModel model)
        {
            
            string invoice_reference = generateInvoiceReference();
            InvoiceEntity invoice = _entityBuilder.buildInvoiceEntity(0, invoice_reference, DateTime.Now, DateTime.Now.AddDays(model.daysBeforeExpiry),model.quotation_Reference,model.vat_percentage, model.bill_address,
                                                                        model.vat,model.discount, model.subtotal,  model.grand_total, model.company_registration, model.generatedBy, model.approvedBy);
            if (_invoiceRepo.Save(invoice))
            {
                return true;
            }
            else
            {
                return false;
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

