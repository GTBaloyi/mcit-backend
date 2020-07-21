using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IQuotationRepository
    {
        public List<QuotationEntity> GetAll();
        public QuotationEntity GetById(int id);
        public bool Save(QuotationEntity quote);
        public bool Update(QuotationEntity quote);
        public bool Delete(QuotationEntity quote);
    }
}
