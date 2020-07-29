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
    public class EmployeesRepository : IEmployeesRepository
    {

        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EmployeesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool Delete(EmployeesEntity employee)
        {
            try
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public List<EmployeesEntity> GetAll()
        {
            try
            {
                return _context.employees.ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public EmployeesEntity GetByEmployeeNumber(string employeeNumber)
        {
            return _context.employees.Where(x => x.employee_number == employeeNumber).FirstOrDefault();
        }

        public bool Save(EmployeesEntity employee)
        {
            try
            {
                _context.employees.Add(employee);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool Update(EmployeesEntity employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }
    }
}
