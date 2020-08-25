using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Repositories
{
    public class AccessLevelRepository : IAccessLevelRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public AccessLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AccessLevelEntity> GetAccessLevels()
        {
            try
            {
                return _context.accessLevel.ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public AccessLevelEntity GetAccessLevel(int id)
        {
            try
            {
               return _context.accessLevel.Find(id);
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public bool UpdateAccessLevel(AccessLevelEntity accessLevel)
        {
            try
            {


                var local = _context.Set<AccessLevelEntity>().Local.FirstOrDefault(entry => entry.id.Equals(accessLevel));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(accessLevel).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool CreateAccessLevel(AccessLevelEntity accessLevel)
        {
            try
            {
                _context.accessLevel.Add(accessLevel);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool DeleteAccessLevel(AccessLevelEntity accessLevel)
        {
            try
            {
                _context.accessLevel.Remove(accessLevel);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        void IAccessLevelRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
