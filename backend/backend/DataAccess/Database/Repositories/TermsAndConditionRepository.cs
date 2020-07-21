using backend.DataAccess.Database.Entities;
using backend.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public class TermsAndConditionRepository : ITermsAndConditionsRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public TermsAndConditionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TermsAndConditionsEntity> getAll()
        {
            throw new NotImplementedException();
        }

        public TermsAndConditionsEntity getById(int id)
        {
            throw new NotImplementedException();
        }

        public TermsAndConditionsEntity getByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool save(TermsAndConditionsEntity data)
        {
            throw new NotImplementedException();
        }

        public bool update(TermsAndConditionsEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
