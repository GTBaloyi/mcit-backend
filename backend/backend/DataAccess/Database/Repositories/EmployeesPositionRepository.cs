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
    public class EmployeesPositionRepository : IEmployeesPositionRepository
    {

        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EmployeesPositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public EmployeesPositionEntity GetByEmployeePositionById(int id)
        {
            try
            {
                return _context.employeesPosition.Find(id);
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public bool Save(EmployeesPositionEntity employeesPosition)
        {
            try
            {
                _context.employeesPosition.Add(employeesPosition);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool Update(EmployeesPositionEntity employeesPosition)
        {
            try
            {
                _context.Entry(employeesPosition).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }
        public bool Delete(EmployeesPositionEntity employeesPositionEntity)
        {
            try
            {
                _context.employeesPosition.Remove(employeesPositionEntity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public List<EmployeesPositionEntity> GetAll()
        {
            try
            {
                return _context.employeesPosition.ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public EmployeesPositionEntity GetByEmployeePositionByName(string name)
        {
            return _context.employeesPosition.Where(x => x.position == name).FirstOrDefault();
        }
    }
}
