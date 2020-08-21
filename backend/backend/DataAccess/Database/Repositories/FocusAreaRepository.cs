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
    public class FocusAreaRepository : IFocusAreaRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public FocusAreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool Delete(int id)
        {
            try
            {
                FocusAreaEntity focusArea =  this.GetById(id);
                _context.focusAreas.Remove(focusArea);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public List<FocusAreaEntity> GetAll()
        {
            try
            {
                return _context.focusAreas.ToList();
            } 
            catch(Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public FocusAreaEntity GetById(int id)
        {
            try
            {
                FocusAreaEntity focusArea = _context.focusAreas.Find(id);
                return focusArea;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }
        }

        public bool Save(FocusAreaEntity focusArea)
        {
            try
            {
                _context.focusAreas.Add(focusArea);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();

        }

        public bool Update(FocusAreaEntity focusArea)
        {
            try
            {
                _context.Entry(focusArea).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public FocusAreaEntity GetByName(string focusAreaName)
        {
            try
            {
               return _context.focusAreas.Where(x => x.name == focusAreaName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }
    }
}
