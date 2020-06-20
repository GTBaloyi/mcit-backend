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
        public InvoiceEntity GetById(int id);
        public bool Save(InvoiceEntity invoice);
        public bool Update(InvoiceEntity invoice);
        public bool Delete(InvoiceEntity invoice);
    }
}
