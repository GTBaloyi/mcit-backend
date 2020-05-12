using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.DataAccess.Database.Entities;
using backend.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.DataAccess.Database.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public QuotationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(QuotationEntity quote)
        {
            try
            {
                _context.quotation.Remove(quote);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public QuotationEntity GetById(int id)
        {
            try
            {
                QuotationEntity quote = _context.quotation.Find(id);
                return quote;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public List<QuotationEntity> GetAll()
        {
            try
            {
                List<QuotationEntity> quotes = _context.quotation.ToList();
                return quotes;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public bool Save(QuotationEntity quote)
        {
            try
            {
                _context.quotation.Add(quote);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }



        public bool Update(QuotationEntity quote)
        {
            try
            {
                _context.Entry(quote).State = EntityState.Modified;
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

