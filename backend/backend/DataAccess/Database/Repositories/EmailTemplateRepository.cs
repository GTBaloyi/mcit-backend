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
    public class EmailTemplateRepository : IEmailTemplateRepository
    {

        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EmailTemplateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Delete(EmailTemplateEntity emailTemplate)
        {

            try
            {
                var local = _context.Set<EmailTemplateEntity>().Local.FirstOrDefault(entry => entry.id.Equals(emailTemplate.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.emailTemplate.Remove(emailTemplate);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public List<EmailTemplateEntity> GetAll()
        {
            try
            {
                return _context.emailTemplate.ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public EmailTemplateEntity GetById(int id)
        {
            return _context.emailTemplate.Find(id);
        }

        public EmailTemplateEntity GetByType(string emailType)
        {
            try
            {
                return _context.emailTemplate.Where(x => x.email_type == emailType).ToList()[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public bool Save(EmailTemplateEntity emailTemplate)
        {
            try
            {
                _context.emailTemplate.Add(emailTemplate);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool Update(EmailTemplateEntity emailTemplate)
        {
            try
            {
                var local = _context.Set<EmailTemplateEntity>().Local.FirstOrDefault(entry => entry.id.Equals(emailTemplate.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(emailTemplate).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
    }
}
