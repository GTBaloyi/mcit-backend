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
    public class PaymentRepository : IPaymentRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(PaymentEntity payment)
        {
            try
            {
                var local = _context.Set<PaymentEntity>().Local.FirstOrDefault(entry => entry.id.Equals(payment.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.payments.Remove(payment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<PaymentEntity> GetAll()
        {
            try
            {
                return _context.payments.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<PaymentEntity> GetByCompanyRegistration(string companyRegistration)
        {
            try
            {
                return _context.payments.Where(x => x.companyRegistration == companyRegistration).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<PaymentEntity> GetByDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _context.payments.Where(x => x.date_of_payment >= startDate && x.date_of_payment < endDate).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public PaymentEntity GetById(int id)
        {
            try
            {
                return _context.payments.Find(id);
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<PaymentEntity> GetByInvoice(string invoiceReference)
        {
            try
            {
                return _context.payments.Where(x => x.invoice_reference == invoiceReference).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Insert(PaymentEntity payment)
        {
            try
            {
                _context.payments.Add(payment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return true;
            }
        }

        public bool Update(PaymentEntity payment)
        {
            try
            {
                var local = _context.Set<PaymentEntity>().Local.FirstOrDefault(entry => entry.id.Equals(payment.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(payment).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }
    }
}
