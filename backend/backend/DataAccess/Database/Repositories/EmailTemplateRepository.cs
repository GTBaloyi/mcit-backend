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
            throw new NotImplementedException();
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
