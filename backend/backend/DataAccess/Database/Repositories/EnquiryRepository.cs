using backend.DataAccess.Database.Repositories.Contracts;
using backend.DataAccess.Entities;
using backend.DataAccess.Database.Entities;
using backend.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace backend.DataAccess.Database.Repositories
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EnquiryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(EnquiryEntity enquiry)
        {
            try
            {
                _context.enquiry.Remove(enquiry);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public EnquiryEntity GetById(int id)
        {
            try
            {
                EnquiryEntity enquiry = _context.enquiry.Find(id);
                return enquiry;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public List<EnquiryEntity> GetAll()
        {   
            try
            {
                List<EnquiryEntity> enquiries = _context.enquiry.ToList();
                return enquiries;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public bool Save(EnquiryEntity enquiry)
        {
            try
            {
                _context.enquiry.Add(enquiry);
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

      

        public bool Update(EnquiryEntity enquiry)
        {
            try
            {
                _context.Entry(enquiry).State = EntityState.Modified;
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

