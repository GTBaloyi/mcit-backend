using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Insert(CompanyEntity company)
        {
            try
            {
                _context.company.Add(company);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool Delete(CompanyEntity company)
        {
            try
            {
                var local = _context.Set<CompanyEntity>().Local.FirstOrDefault(entry => entry.id.Equals(company.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.company.Remove(company);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public List<CompanyEntity> GetList()
        {
            return _context.company.ToList();
        }

        public CompanyEntity GetById(int id)
        {
            return _context.company.Find(id);
        }

        public bool Update(CompanyEntity company)
        {
            try
            {
                var local = _context.Set<CompanyEntity>().Local.FirstOrDefault(entry => entry.id.Equals(company.id));
                if(local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(company).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public CompanyEntity GetByRegistrationNumber(string registration)
        {
            try
            {
                List<CompanyEntity> queryResponse = _context.company.Where(x => x.registration_number == registration).ToList();
                return queryResponse.FirstOrDefault();

            } 
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
    }
}
