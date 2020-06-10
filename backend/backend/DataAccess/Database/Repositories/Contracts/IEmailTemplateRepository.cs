using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IEmailTemplateRepository
    {
        public List<EmailTemplateEntity> GetAll();
        public EmailTemplateEntity GetById(int id);
        public EmailTemplateEntity GetByType(string emailType);
        public bool Save(EmailTemplateEntity emailTemplate);
        public bool Update(EmailTemplateEntity emailTemplate);
        public bool Delete(EmailTemplateEntity emailTemplate);
    }
}
