using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository 
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteUser(UsersEntity user)
        {
            try
            {
                var local = _context.Set<UsersEntity>().Local.FirstOrDefault(entry => entry.username.Equals(user.username));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.users.Remove(user);
                _context.SaveChanges();

                return true;
            } 
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }
            
        }

        public UsersEntity GetUser(string username)
        {
            try
            {
               return _context.users.Find(username);
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }

        }

        public List<UsersEntity> GetUsers()
        {
            try
            {
                return _context.users.ToList();
                
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw ex;
            }

        }

        public bool SaveUser(UsersEntity user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public bool UpdateUser(UsersEntity user)
        {
            try
            {
                var local = _context.Set<UsersEntity>().Local.FirstOrDefault(entry => entry.username.Equals(user.username));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
