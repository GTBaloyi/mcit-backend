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
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(ProductsEntity product)
        {
            try
            {
                _context.products.Remove(product);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public ProductsEntity GetById(int id)
        {
            try
            {
                ProductsEntity product = _context.products.Find(id);
                return product;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public List<ProductsEntity> GetAll()
        {
            try
            {
                List<ProductsEntity> product = _context.products.ToList();
                return product;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }

        }

        public bool Save(ProductsEntity product)
        {
            try
            {
                _context.products.Add(product);
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



        public bool Update(ProductsEntity product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return false;
            }

        }

        public List<ProductsEntity> GetByFocusArea(int focusAreaId)
        {
            try
            {
                return _context.products.Where(x => x.focus_area_fk == focusAreaId).ToList();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                return null;
            }
        }
    }
}
