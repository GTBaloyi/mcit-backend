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
    public class QuarterRepository : IQuarterRepository
    {

        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public QuarterRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool Delete(QuarterEntity quarter)
        {
            try
            {

                var local = _context.Set<QuarterEntity>().Local.FirstOrDefault(entry => entry.id.Equals(quarter.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.quarter.Remove(quarter);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<QuarterEntity> GetAll()
        {
            try
            {
                return _context.quarter.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public QuarterEntity GetById(int id)
        {
            try
            {
                return _context.quarter.Find(id);
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public QuarterEntity GetByQuarter(string quarter)
        {
            try
            {
                return _context.quarter.Where(x => x.quarter == quarter).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Insert(QuarterEntity quarter)
        {
            try
            {
                _context.quarter.Add(quarter);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return true;
            }
        }

        public bool Update(QuarterEntity quarter)
        {
            try
            {
                var local = _context.Set<QuarterEntity>().Local.FirstOrDefault(entry => entry.id.Equals(quarter.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(quarter).State = EntityState.Modified;
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
