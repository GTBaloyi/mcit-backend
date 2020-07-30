using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IQuotationItemsRepository
    {
        public List<QuotationItemEntity> GetAll();
        public List<QuotationItemEntity> GetByQuote(int quoteFk);
        public QuotationItemEntity GetById(int id);
        public bool Save(QuotationItemEntity item);
        public bool Update(QuotationItemEntity item);
        public bool Delete(QuotationItemEntity item);
    }
}
