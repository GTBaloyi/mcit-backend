using backend.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IQuarterService
    {
        List<QuarterModel> GetAll();
        QuarterModel GetById(int id);
        QuarterModel GetByQuarter(string quarter);
        bool UpdateQuarter(QuarterModel quarter);
        bool DeleteQuarter(QuarterModel quarter);
        bool InsertQuarter(QuarterModel quarter);
    }
}
