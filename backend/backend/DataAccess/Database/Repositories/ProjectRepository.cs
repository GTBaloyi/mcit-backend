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
    public class ProjectRepository : IProjectRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(ProjectEntity project)
        {
            try
            {
                var local = _context.Set<ProjectEntity>().Local.FirstOrDefault(entry => entry.id.Equals(project.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.project.Remove(project);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public List<ProjectEntity> GetAll()
        {
            try
            {
                return _context.project.ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public List<ProjectEntity> GetByCompanyRegistration(string companyRegistration)
        {
            try
            {
                return _context.project.Where(x => x.company_registration == companyRegistration).ToList();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public ProjectEntity GetById(int id)
        {
            try
            {
                return _context.project.Find(id);
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public ProjectEntity GetByInvoice(string invoiceReference)
        {
            try
            {
                return _context.project.Where(x => x.invoice_reference == invoiceReference).First();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public ProjectEntity GetByProjectNumber(string projectNumber)
        {
            try
            {
                return _context.project.Where(x => x.project_number == projectNumber).First();
            }
            catch (Exception e)
            {
                logger.Info(e);
                return null;
            }
        }

        public bool Insert(ProjectEntity project)
        {
            try
            {
                _context.project.Add(project);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Info(e);
                return false;
            }
        }

        public bool Update(ProjectEntity project)
        {
            try
            {
                var local = _context.Set<ProjectEntity>().Local.FirstOrDefault(entry => entry.id.Equals(project.id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(project).State = EntityState.Modified;
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
