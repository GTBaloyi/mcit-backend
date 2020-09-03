using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public class ProjectTodosRepository : IProjectTodoRepository
    {

        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProjectTodosRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool Delete(ProjectTODO projectTODO)
        {
            try
            {
                _context.projectTODOs.Remove(projectTODO);
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<ProjectTODO> GetAll()
        {
            try
            {
                return _context.projectTODOs.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public ProjectTODO GetById(int id)
        {
            try
            {
                return _context.projectTODOs.Find(id);
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectTODO> GetByProjectNumber(string projectNumber)
        {
            try
            {
                return _context.projectTODOs.Where(x => x.project_number == projectNumber).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectTODO> GetByFocusArea(string focusArea)
        {
            try
            {
                return _context.projectTODOs.Where(x => x.focus_area == focusArea).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectTODO> GetByItem(string item)
        {
            try
            {
                return _context.projectTODOs.Where(x => x.item == item).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Insert(ProjectTODO projectTODO)
        {
            try
            {
                _context.projectTODOs.Add(projectTODO);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return true;
            }
        }

        public bool Update(ProjectTODO projectTODO)
        {
            try
            {
                var local = _context.Set<ProjectTODO>().Local.FirstOrDefault(entry => entry.id.Equals(projectTODO.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(projectTODO).State = EntityState.Modified;
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
