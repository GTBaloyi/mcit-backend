using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public interface ITermsAndConditionsRepository
    {
        TermsAndConditionsEntity getByTitle(string title);
        List<TermsAndConditionsEntity> getAll();
        TermsAndConditionsEntity getById(int id);
        bool save(TermsAndConditionsEntity data);
        bool update(TermsAndConditionsEntity data);
        bool delete(int id);
    }
}
