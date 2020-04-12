using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Repositories
{
    public class UserStatusRepository : IUserStatusRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public UserStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateUserStatus(UserStatusEntity user)
        {
            try
            {
                 _context.userStatus.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public bool DeleteUserStatus(UserStatusEntity user)
        {
            try
            {
                 _context.userStatus.Remove(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
        }

        public UserStatusEntity GetUserStatus(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserStatusEntity> GetUserStatuses()
        {
            try
            {
                return _context.userStatus.ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateUserStatus(UserStatusEntity user)
        {
            try
            {
                 _context.Entry(user).State = EntityState.Modified;
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
