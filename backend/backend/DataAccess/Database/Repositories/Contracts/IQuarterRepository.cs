using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IQuarterRepository
    {
        List<QuarterEntity> GetAll();
        QuarterEntity GetById(int id);
        QuarterEntity GetByQuarter(string quarter);
        bool Update(QuarterEntity quarter);
        bool Delete(QuarterEntity quarter);
        bool Insert(QuarterEntity quarter);
    }
}
