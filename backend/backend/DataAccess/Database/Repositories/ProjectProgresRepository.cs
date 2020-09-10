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
    public class ProjectProgresRepository : IProjectProgressRepository
    {

        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProjectProgresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(ProjectProgress projectProgress)
        {
            try
            {
                var local = _context.Set<ProjectProgress>().Local.FirstOrDefault(entry => entry.id.Equals(projectProgress.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.projectProgresses.Remove(projectProgress);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<ProjectProgress> GetAll()
        {
            try
            {
                return _context.projectProgresses.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectProgress> GetByEndQuater(string endQuarter)
        {
            throw new NotImplementedException();
        }

        public ProjectProgress GetById(int id)
        {
            try
            {
                return _context.projectProgresses.Find(id);
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public ProjectProgress GetByProjectNumber(string projectNumber)
        {
            try
            {
                return _context.projectProgresses.Where(x => x.project_number == projectNumber).First();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectProgress> GetByProjectStatus(string projectStatus)
        {
            try
            {
                return _context.projectProgresses.Where(x => x.project_status == projectStatus).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectProgress> GetByStartQuarter(string startQuarter)
        {
            try
            {
                return _context.projectProgresses.Where(x => x.start_quarter == startQuarter).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Insert(ProjectProgress projectProgress)
        {
            try
            {
                _context.projectProgresses.Add(projectProgress);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return true;
            }
        }

        public bool Update(ProjectProgress projectProgress)
        {
            try
            {
                var local = _context.Set<ProjectProgress>().Local.FirstOrDefault(entry => entry.id.Equals(projectProgress.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(projectProgress).State = EntityState.Modified;
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
