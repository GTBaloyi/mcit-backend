using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface ITargetSettingRepository
    {
        public List<TargetSettingsEntity> GetAll();
        public TargetSettingsEntity GetById(int id);
        public List<TargetSettingsEntity> GetByTitle(string email);
        public bool Save(TargetSettingsEntity targetSettings);
        public bool Update(TargetSettingsEntity targetSettings);
        public bool Delete(TargetSettingsEntity targetSettings);
    }
}
