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

        public InvoiceService(IEntityBuilder builder, IInvoiceRepository i_invoiceRepo)
        {
            _invoiceRepo = i_invoiceRepo;
            _entityBuilder = builder;

        }

        public void Delete(int id)
        {
            InvoiceEntity entity = _invoiceRepo.GetById(id);
            _invoiceRepo.Delete(entity);
        }

        public List<InvoiceResponseModel> GetAll()
        {
            List<InvoiceEntity> entities = _invoiceRepo.GetAll();
            List<InvoiceResponseModel> models = new List<InvoiceResponseModel>();
            if (entities != null)
            {
                foreach (InvoiceEntity entity in entities)
                {
                    InvoiceResponseModel model = new InvoiceResponseModel(entity.id, entity.reference, entity.invoice_date, entity.date_due, entity.title, entity.description, entity.vat_number, entity.bill_to_id,
          entity.Vat, entity.terms, entity.total, entity.subtotal, entity.quantity, entity.total_due, entity.user_id);
                    models.Add(model);
                }
                return models;
            }
            else
            {
                return null;
            }


        }

        public InvoiceResponseModel GetById(int id)
        {
            InvoiceEntity entity = _invoiceRepo.GetById(id);
            if (entity != null)
            {
                return new InvoiceResponseModel(id, entity.reference, entity.invoice_date, entity.date_due, entity.title, entity.description, entity.vat_number, entity.bill_to_id,
          entity.Vat, entity.terms, entity.total, entity.subtotal, entity.quantity, entity.total_due, entity.user_id);
            }
            else
            {
                return null;
            }
        }


        public InvoiceResponseModel Update(InvoiceRequestModel model)
        {

            
            InvoiceEntity invoice = _entityBuilder.buildInvoiceEntity(model.id, model.reference, model.invoice_date, model.date_due, model.title, model.description, model.vat_number, model.bill_to_id,
          model.Vat, model.terms, model.total, model.subtotal, model.quantity, model.total_due, model.user_id);

            if (_invoiceRepo.Update(invoice))
            {
                InvoiceResponseModel respose = new InvoiceResponseModel(invoice.id, invoice.reference, invoice.invoice_date, invoice.date_due, invoice.title, invoice.description, invoice.vat_number, invoice.bill_to_id,
          invoice.Vat, invoice.terms, invoice.total, invoice.subtotal, invoice.quantity, invoice.total_due, invoice.user_id);
                return respose;
            }
            else
            {
                return null;
            }
        }

        public bool GenerateInvoice(InvoiceRequestModel model)
        {
            InvoiceEntity invoice = _entityBuilder.buildInvoiceEntity(model.id, model.reference, model.invoice_date, model.date_due, model.title, model.description, model.vat_number, model.bill_to_id,
          model.Vat, model.terms, model.total, model.subtotal, model.quantity, model.total_due, model.user_id);
            if (_invoiceRepo.Save(invoice))
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

