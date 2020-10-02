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
    public class InvoiceRepository : IInvoiceRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(InvoiceEntity invoice)
        {
            try
            {
                var local = _context.Set<InvoiceEntity>().Local.FirstOrDefault(entry => entry.id.Equals(invoice.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;

                }
                _context.invoice.Remove(invoice);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public List<InvoiceEntity> GetById(string companyRegistration)
        {
            try
            {
                return _context.invoice.Where(x => x.company_registration == companyRegistration).ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public List<InvoiceEntity> GetAll()
        {
            try
            {
                List<InvoiceEntity> invoices = _context.invoice.ToList();
                return invoices;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public bool Save(InvoiceEntity invoice)
        {
            try
            {
                _context.invoice.Add(invoice);
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



        public bool Update(InvoiceEntity invoice)
        {
            try
            {
                var local = _context.Set<InvoiceEntity>().Local.FirstOrDefault(entry => entry.id.Equals(invoice.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(invoice).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public InvoiceEntity GetByReference(string reference)
        {
            try
            {
                return _context.invoice.Where(x => x.reference == reference).First();
            }
            catch(Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public InvoiceEntity GetByQuotationReference(string quotationReference)
        {
            try
            {
                return _context.invoice.Where(x => x.quotation_reference == quotationReference).First();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }
    }
}

