using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IInvoiceRepository
    {
        public List<InvoiceEntity> GetAll();
        public List<InvoiceEntity> GetById(string companyRegistration);
        public InvoiceEntity GetByReference(String reference);
        public bool Save(InvoiceEntity invoice);
        public bool Update(InvoiceEntity invoice);
        public bool Delete(InvoiceEntity invoice);
    }
}
