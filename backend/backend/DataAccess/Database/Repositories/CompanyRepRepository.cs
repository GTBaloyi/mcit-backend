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

        public List<CompanyRepresentativeEntity> GetList()
        {
            try
            {
                return _context.businessRepresentatives.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public CompanyRepresentativeEntity GetById(int id)
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

        public bool Update(CompanyRepresentativeEntity businessRepresentative)
        {
            try
            {
                var local = _context.Set<CompanyRepresentativeEntity>().Local.FirstOrDefault(entry => entry.id.Equals(businessRepresentative.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(businessRepresentative).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public bool Delete(CompanyRepresentativeEntity businessRepresentative)
        {
            try
            {
                var local = _context.Set<CompanyRepresentativeEntity>().Local.FirstOrDefault(entry => entry.id.Equals(businessRepresentative.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.businessRepresentatives.Remove(businessRepresentative);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public bool Insert(CompanyRepresentativeEntity businessRepresentative)
        {
            try
            {
                _context.businessRepresentatives.Add(businessRepresentative);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public CompanyRepresentativeEntity GetByEmail(string email)
        {
            try
            {
               CompanyRepresentativeEntity rep = _context.businessRepresentatives.Where(x => x.email == email).FirstOrDefault();
                return rep;
            }
            catch (Exception ex)
            {
                logger.Error(ex); 
                throw ex;
            }
        }

        public CompanyRepresentativeEntity GetByCompany(int companyId)
        {
            try
            {
                return _context.businessRepresentatives.Where(x => x.company_fk == companyId).FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
    }
}
