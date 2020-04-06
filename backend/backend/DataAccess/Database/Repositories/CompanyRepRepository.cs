using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Repositories
{
    public class CompanyRepRepository : ICompanyRepRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public CompanyRepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CompanyRepresentativeEntity> GetBusinessRepresentatives()
        {
            try
            {
                return _context.businessRepresentatives.ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public CompanyRepresentativeEntity GetBusinessRepresentative(int id)
        {
            try
            {
                return _context.businessRepresentatives.Find(id);
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public bool UpdateBusinessRepresentative(CompanyRepresentativeEntity businessRepresentative)
        {
            try
            {
                 _context.Entry(businessRepresentative).State = EntityState.Modified;
                 return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool DeleteBusinessRepresentative(CompanyRepresentativeEntity businessRepresentative)
        {
            try
            {
                _context.businessRepresentatives.Remove(businessRepresentative);
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool CreateBusinessRepresentative(CompanyRepresentativeEntity businessRepresentative)
        {
            try
            {
                _context.businessRepresentatives.Add(businessRepresentative);
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }
    }
}
