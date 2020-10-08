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
    public class TargetSettingRepository : ITargetSettingRepository
    {


        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public TargetSettingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(TargetSettingsEntity targetSettings)
        {
            try
            {
                var local = _context.Set<TargetSettingsEntity>().Local.FirstOrDefault(entry => entry.id.Equals(targetSettings.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.targetSettings.Remove(targetSettings);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<TargetSettingsEntity> GetAll()
        {
            try
            {
                return _context.targetSettings.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public TargetSettingsEntity GetById(int id)
        {
            try
            {
                return _context.targetSettings.Find(id);
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }
    

        public List<TargetSettingsEntity> GetByTitle(string title)
        {
             try
            {
                return _context.targetSettings.Where(x => x.title == title).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Save(TargetSettingsEntity targetSettings)
        {
            try
            {
                _context.targetSettings.Add(targetSettings);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return true;
            }
        }

        public bool Update(TargetSettingsEntity targetSettings)
        {
            try
            {
                var local = _context.Set<TargetSettingsEntity>().Local.FirstOrDefault(entry => entry.id.Equals(targetSettings.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(targetSettings).State = EntityState.Modified;
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
