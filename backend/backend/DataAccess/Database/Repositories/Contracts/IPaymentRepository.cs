using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        List<PaymentEntity> GetAll();
        PaymentEntity GetById(int id);
        List<PaymentEntity> GetByDates(DateTime startDate, DateTime endDate);
        List<PaymentEntity> GetByInvoice(string invoiceReference);
        List<PaymentEntity> GetByCompanyRegistration(string companyRegistration);
        bool Update(PaymentEntity payment);
        bool Delete(PaymentEntity payment);
        bool Insert(PaymentEntity payment);
    }
}
