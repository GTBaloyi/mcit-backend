using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Repositories;
using FluentNHibernate.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories
{
    public class ProjectExpenditureRepository : IProjectExpenditureRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ProjectExpenditureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(ProjectExpenditure projectExpenditure)
        {
            try
            {
                _context.projectExpenditures.Remove(projectExpenditure);
                return true;
            }
            catch(Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<ProjectExpenditure> GetAll()
        {
            try
            {
                return _context.projectExpenditures.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public ProjectExpenditure GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectExpenditure GetByProjectNumber(string projectNumber)
        {
            try
            {
                return _context.projectExpenditures.Where(x => x.project_number == projectNumber).First();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectExpenditure> GetByProjectStatus(string focusArea)
        {
            try
            {
                return _context.projectExpenditures.Where(x => x.focus_area == focusArea).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectExpenditure> GetByStartQuarter(string item)
        {
            try
            {
                return _context.projectExpenditures.Where(x => x.item == item).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Insert(ProjectExpenditure projectExpenditure)
        {
            try
            {
                _context.projectExpenditures.Add(projectExpenditure);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public bool Update(ProjectExpenditure projectExpenditure)
        {
            try
            {
                _context.Entry(projectExpenditure).State = EntityState.Modified;
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
