using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public class QuotationItemRepository : IQuotationItemsRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public QuotationItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(QuotationItemEntity item)
        {
            try
            {
                _context.quotationItem.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public List<QuotationItemEntity> GetAll()
        {
            try
            {
                List<QuotationItemEntity> item = _context.quotationItem.ToList();
                return item;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }
        }

        public QuotationItemEntity GetById(int id)
        {
            try
            {
                QuotationItemEntity item = _context.quotationItem.Find(id);
                return item;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }
        }

        public List<QuotationItemEntity> GetByQuote(string quoteReference)
        {
            try
            {
                return _context.quotationItem.Where(x => x.quote_reference == quoteReference).ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }
        }

        public bool Save(QuotationItemEntity item)
        {
            try
            {
                _context.quotationItem.Add(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool Update(QuotationItemEntity item)
        {
            try
            {
                var local = _context.Set<QuotationItemEntity>().Local.FirstOrDefault(entry => entry.id.Equals(item.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;

                }
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();

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
