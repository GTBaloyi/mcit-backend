using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    interface IEnquiryRepository
    {
        public List<EnquiryEntity> GetAll();
        public EnquiryEntity GetById(int id);
        public bool Save(EnquiryEntity enquiry);
        public bool Update(EnquiryEntity enquiry);
        public bool Delete(int id);
    }
}
